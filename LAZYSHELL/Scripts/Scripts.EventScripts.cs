using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using LAZYSHELL.ScriptsEditor;
using LAZYSHELL.ScriptsEditor.Commands;

namespace LAZYSHELL.ScriptsEditor
{
    public partial class Scripts : Form
    {
        #region Variables
        TreeViewWrapper treeViewWrapper; public TreeViewWrapper TreeViewWrapper { get { return treeViewWrapper; } }
        EventScript[] eventScripts;
        public EventScript[] EventScripts { get { return eventScripts; } set { eventScripts = value; } }
        EventScriptCommand esc;
        ActionQueueCommand aqc;
        TreeNode editedNode;
        int currentScript = 0;
        bool updatingControls = false;

        #region Static Data
        private int[][] eventListBoxOpcodes = new int[][]
        {
            new int[]   // 1
            {
                0x00,
                0x30,0x31,0x32,0x39,0x3A,0x3B,0x3D,0x3E,0x3F,
                0x42,0xF2,0xF3,0xF4,0xF5,0xF6,0xF7,0xF8,
                0xFD,0xFD,0xFD,0xFD,0xFD,0xFD
            },
            new int[]   // 2
            {
                0x34,0x35
            },
            new int[]   // 3
            {
                0x36,0x54,0x56,0xFD,0xFD,0xFD
            },
            new int[]   // 4
            {
                0x50,0x51,0x52,0x53,0x57,0xFD,0xFD,0xFD,
                0xFD,0xFD,0xFD,0xFD,0xFD,0xFD
            },
            new int[]   // 5
            {
                0x49,0x4A
            },
            new int[]   // 6
            {
                0x4B,0x68,0x6A,0x6B
            },
            new int[]   // 7
            {
                0x4C,0x4F,0xFD,0xFD,0xFD
            },
            new int[]   // 8
            {
                0x60,0x61,0x62,0x63,0x64,0x65,0x66,0x67
            },
            new int[]   // 9
            {
                0x40,0x4E,0xD0,0xD1,0xFD,0xFD,0xFD,0xFD,0xFD,0xFD
            },
            new int[]   // 10
            {
                0xD2,0xD3,0xD4,0xD7,0xF9,0xFA
            },
            new int[]   // 11
            {
                0x70,0x71,0x72,0x73,0x74,0x75,0x76,0x77,
                0x78,0x79,0x7A,0x7B,0x7C,0x7D,0x7E,0x80,
                0x81,0x82,0x83,0x84,0x89,0x8A,0x87,0x8F,
                0xFD,0xFD
            },
            new int[]   // 12
            {
                0x90,0x91,0x92,0x93,0x94,0x95,0x97,0x98,
                0x9B,0x9C,0x9D,0x9E,0xFD,0xFD,0xFD
            },
            new int[]   // 13
            {
                0xA0,0xA4,0xA8,0xA9,0xAA,0xAB,0xB0,0xB1,
                0xB2,0xB3,0xB5,0xB7,0xBB,0xBC,0xBD,0xC2,
                0xD6,0xD8,0xDC,0xE0,0xE1,0xE4,0xE5,0xE8,
                0xE9,0xFD,0xFD
            },
            new int[]   // 14
            {
                0x37,0x38,0x55,0x58,0xA3,0xA7,0xAC,0xAD,
                0xAE,0xAF,0xB4,0xB6,0xB8,0xB9,0xBA,0xC0,
                0xC1,0xC3,0xC4,0xC5,0xC6,0xCA,0xCB,0xDB,
                0xDF,0xE2,0xE3,0xE6,0xE7,0xEA,0xEB,0xEC,
                0xED,0xEE,0xEF,0xFD,0xFD,0xFD,0xFD,0xFD,
                0xFD,0xFD,0xFD,0xFD,0xFD,0xFD,0xFD
            },
            new int[]   // 15
            {
                0xF0,0xF1,0xFD,0xFD
            },
            new int[]   // 16
            {
                0xFB,0xFC
            },
            new int[]   // 17
            {
                0xFE,0xFF
            }
        };
        private int[][] eventListBoxFDOpcodes = new int[][]
        {
            new int[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0x32,0x33,0x34,0x3D,0x3E,0xF9},
            new int[0x02],
            new int[]{0,0,0,0x4B,0x5B,0x64},
            new int[]{0,0,0,0,0,0x50,0x51,0x52,0x53,0x54,0x55,0x56,0x57,0x5C},
            new int[0x02],
            new int[0x04],
            new int[]{0,0,0x4A,0x4C,0x65},
            new int[0x08],
            new int[]{0,0,0,0,0x4D,0x4E,0x4F,0x66,0x67,0xF8},
            new int[0x06],
            new int[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0x30,0x31},
            new int[]{0,0,0,0,0,0,0,0,0,0,0,0,0x9C,0xA4,0xA5},
            new int[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0xB6,0xB7},
            new int[]
            {
                0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                0x58,0x59,0x5A,0x5D,0x5E,0xAC,0xB0,0xB1,0xB2,0xB3,0xB4,0xB5
            },
            new int[]{0,0,0x60,0x61},
            new int[0x02],
            new int[0x02],
        };

        private static string[] ObjectNames = new string[]
            {
                    "Mario",// 0x00
                    "Toadstool",			// 0x01
                    "Bowser",			// 0x02
                    "Geno",// 0x03
                    "Mallow",			// 0x04
                    "DUMMY 0x05",			// 0x05
                    "DUMMY 0x06",			// 0x06
                    "DUMMY 0x07",			// 0x07
                    "Character in Slot 1",// 0x08
                    "Character in Slot 2",// 0x09
                    "Character in Slot 3",// 0x0A
                    "DUMMY 0x0B",			// 0x0B
                    "Screen Focus",			// 0x0C
                    "Layer 1",			// 0x0D
                    "Layer 2",			// 0x0E
                    "Layer 3",			// 0x0F
            			
                    "Mem 00:70A8",			// 0x10
                    "Mem 00:70A9",			// 0x11
                    "Mem 00:70AA",			// 0x12
                    "Mem 00:70AB",			// 0x13
                    "NPC #0",			// 0x14
                    "NPC #1",			// 0x15
                    "NPC #2",			// 0x16
                    "NPC #3",			// 0x17
                    "NPC #4",			// 0x18
                    "NPC #5",			// 0x19
                    "NPC #6",			// 0x1A
                    "NPC #7",			// 0x1B
                    "NPC #8",			// 0x1C
                    "NPC #9",			// 0x1D
                    "NPC #10",			// 0x1E
                    "NPC #11",			// 0x1F
            			
                    "NPC #12",			// 0x20
                    "NPC #13",			// 0x21
                    "NPC #14",			// 0x22
                    "NPC #15",			// 0x23
                    "NPC #16",			// 0x24
                    "NPC #17",			// 0x25
                    "NPC #18",			// 0x26
                    "NPC #19",			// 0x27
                    "NPC #20",			// 0x28
                    "NPC #21",			// 0x29
                    "NPC #22",			// 0x2A
                    "NPC #23",			// 0x2B
                    "NPC #24",			// 0x2C
                    "NPC #25",			// 0x2D
                    "NPC #26",			// 0x2E
                    "NPC #27"			// 0x2F
            };
        private static string[] CharacterNames = new string[]
        {
            "Mario", "Toadstool", "Bowser", "Geno", "Mallow"
        };
        private static string[] ButtonNames = new string[] 
        { 
            "left", "right", "down", "up", "X", "A", "Y", "B" 
        };
        private static string[] Directions = new string[]
        {
            "east","southeast","south","southwest",
            "west","northwest","north","northeast"
        };
        private static string[] ColorNames = new string[] 
        { 
            "black", "blue", "red", "pink", "green", "aqua", "yellow", "white" 
        };
        private string[] LayerNames = new string[] 
        { 
            "L1", "L2", "L3", "L4", "Sprites", "BG", "½ intensity", "Minus sub" 
        };
        public static string[] MusicNames = new string[]
            {
            "[00]  {CURRENT}",
            "[01]  Dodo\'s Coming",
            "[02]  Mushroom Kingdom",
            "[03]  Fight Against Stronger Monster",
            "[04]  Yo\'ster Island",
            "[05]  Seaside Town",
            "[06]  Fight Against Monsters",
            "[07]  Pipe Vault",
            "[08]  Invincible Star",
            "[09]  Victory",
            "[10]  In The Flower Garden",
            "[11]  Bowser\'s Castle (1st time)",
            "[12]  Fight Against Bowser",
            "[13]  Road Is Full Of Dangers",
            "[14]  Mario\'s Pad",
            "[15]  Here\'s Some Weapons",
            "[16]  Let\'s Race",
            "[17]  Tadpole Pond",
            "[18]  Rose Town",
            "[19]  Race Training",
            "[20]  Shock!",
            "[21]  Sad Song",
            "[22]  Midas River",
            "[23]  Got A Star Piece (part 1)",
            "[24]  Got A Star Piece (part 2)",
            "[25]  Fight Against An Armed Boss",
            "[26]  Forest Maze",
            "[27]  Dungeon Is Full Of Monsters",
            "[28]  Let\'s Play Geno",
            "[29]  Start Slot Menu",
            "[30]  Long Long Ago",
            "[31]  Booster\'s Tower",
            "[32]  And My Name\'s Booster",
            "[33]  Moleville",
            "[34]  Star Hill",
            "[35]  Mountain Railroad",
            "[36]  Explanation",
            "[37]  Booster Hill (start)",
            "[38]  Booster Hill",
            "[39]  Marrymore",
            "[40]  New Partner",
            "[41]  Sunken Ship",
            "[42]  Still The Road Is Full Of Monsters",
            "[43]  {SILENCE}",
            "[44]  Sea",
            "[45]  Heart Beating A Little Faster (part 1)",
            "[46]  Heart Beating A Little Faster (part 2)",
            "[47]  Grate Guy\'s Casino",
            "[48]  Geno Awakens",
            "[49]  Celebrational",
            "[50]  Nimbus Land",
            "[51]  Monstro Town",
            "[52]  Toadofsky",
            "[53]  {SILENCE}",
            "[54]  Happy Adventure, Delighful Adventure",
            "[55]  World Map",
            "[56]  Factory",
            "[57]  Sword Crashes And Stars Scatter",
            "[58]  Conversation With Culex",
            "[59]  Fight Against Culex",
            "[60]  Victory Against Culex",
            "[61]  Valentina",
            "[62]  Barrel Volcano",
            "[63]  Axem Rangers Drop In",
            "[64]  The End",
            "[65]  Gate",
            "[66]  Bowser\'s Castle (2nd time)",
            "[67]  Weapons Factory",
            "[68]  Fight Against Smithy 1",
            "[69]  Fight Against Smithy 2",
            "[70]  Ending Part 1",
            "[71]  Ending Part 2",
            "[72]  Ending Part 3",
            "[73]  Ending Part 4",
            "[74]  {SILENCE}",
            "[75]  {SILENCE}",
            "[76]  {SILENCE}",
            "[77]  {SILENCE}",
            "[78]  {SILENCE}",
            "[79]  {SILENCE}"
         };
        public static string[] SoundNames = new string[]
            {
            "[000]  nothing",
            "[001]  menu select",
            "[002]  menu cancel",
            "[003]  menu scroll",
            "[004]  jump",
            "[005]  block switch",
            "[006]  running water",
            "[007]  rushing water",
            "[008]  waterfall",
            "[009]  green switch",
            "[010]  trampoline",
            "[011]  whoosh away",
            "[012]  dizziness",
            "[013]  coin",
            "[014]  flower",
            "[015]  night crickets",
            "[016]  open door",
            "[017]  open front gate",
            "[018]  sudden stop",
            "[019]  long fall",
            "[020]  lighting bolt",
            "[021]  rumbling",
            "[022]  close door",
            "[023]  helicopter",
            "[024]  tapping feet",
            "[025]  heel click",
            "[026]  laughing Bowser",
            "[027]  found an item",
            "[028]  pipe entrance",
            "[029]  alarm clock",
            "[030]  surprised monster",
            "[031]  spinning flower",
            "[032]  underground warp",
            "[033]  jumping/bouncing fish",
            "[034]  squirm/writhe",
            "[035]  running water",
            "[036]  ",
            "[037]  ",
            "[038]  ",
            "[039]  ",
            "[040]  ",
            "[041]  ",
            "[042]  ",
            "[043]  pop up from water",
            "[044]  ghost float",
            "[045]  Goomba taunt",
            "[046]  crumbling noise",
            "[047]  snooze",
            "[048]  minecart start",
            "[049]  big shell hit",
            "[050]  water droplet",
            "[051]  moving yellow switch",
            "[052]  deep bounce",
            "[053]  bounce",
            "[054]  goodnight",
            "[055]  lose coins/coin fountain",
            "[056]  shake head",
            "[057]  finger snap",
            "[058]  insert",
            "[059]  hovering Frogfucius",
            "[060]  dynamite/bomb explosion",
            "[061]  deep uh-oh",
            "[062]  big yoshi talk",
            "[063]  yoshi talk",
            "[064]  spinning copters",
            "[065]  thwomp stomp",
            "[066]  kick ball/shell",
            "[067]  sword in keep",
            "[068]  ",
            "[069]  ",
            "[070]  ",
            "[071]  mushroom cure",
            "[072]  syrup cure",
            "[073]  thwomp stomp",
            "[074]  Boosters train",
            "[075]  rocketing blast",
            "[076]  Boosters train horn",
            "[077]  exotic bird calls",
            "[078]  click",
            "[079]  ",
            "[080]  beeping",
            "[081]  star",
            "[082]  screeching stop",
            "[083]  weird laugh",
            "[084]  smoked",
            "[085]  flower",
            "[086]  big bounce",
            "[087]  correct signal",
            "[088]  wrong signal",
            "[089]  lit fuse",
            "[090]  curtain",
            "[091]  tumbling boulders",
            "[092]  ",
            "[093]  jump into water",
            "[094]  frog coin",
            "[095]  level up with star",
            "[096]  swinging fist",
            "[097]  engage in battle",
            "[098]  ",
            "[099]  tapping feet",
            "[100]  minecart ride",
            "[101]  Terrapin attack",
            "[102]  time running out",
            "[103]  Toadstool crying",
            "[104]  deep scraping",
            "[105]  surprise",
            "[106]  off balance",
            "[107]  drum roll",
            "[108]  drum roll end",
            "[109]  big shell hit",
            "[110]  abstract music",
            "[111]  sleeping",
            "[112]  draining water",
            "[113]  open chamber door",
            "[114]  ",
            "[115]  ",
            "[116]  ",
            "[117]  spinning monster",
            "[118]  beckoning Tentacle",
            "[119]  Czar Dragon roar",
            "[120]  metal/bolt strike",
            "[121]  Axem Ranger teleport",
            "[122]  ",
            "[123]  chain/rumbling noise",
            "[124]  engine starting",
            "[125]  enter deep water",
            "[126]  emerge deep water",
            "[127]  light rattle",
            "[128]  floating/hovering",
            "[129]  baby yoshi",
            "[130]  big baby yoshi",
            "[131]  ",
            "[132]  honking horn",
            "[133]  close hit door",
            "[134]  swipe",
            "[135]  impending blast",
            "[136]  ",
            "[137]  ",
            "[138]  ",
            "[139]  ",
            "[140]  ",
            "[141]  ",
            "[142]  ",
            "[143]  metronome upbeat ding",
            "[144]  click",
            "[145]  blacksmith hammer strike",
            "[146]  machine transform",
            "[147]  click",
            "[148]  surging electricity",
            "[149]  casino secret passage",
            "[150]  exit to world map",
            "[151]  crash hit",
            "[152]  slip hit",
            "[153]  slot machines",
            "[154]  big squish",
            "[155]  post-credits Mario theme whistle",
            "[156]  Link fanfare",
            "[157]  descending fall",
            "[158]  hard land",
            "[159]  deep underground noise",
            "[160]  chomp",
            "[161]  ghost",
            "[162]  closing gate door"
            };
        private string[] MenuNames = new string[]
            {
                "choose game",
                "overworld menu",
                "world map",
                "mushroom kingdom shop",
                "save game",
                "items maxed out",
                "___",
                "menu tutorial equip",
                "new star piece",
                "moleville mountain",
                "___",
                "intro moleville mountain",
                "___",
                "7 star pieces",
                "flower garden intro",
                "enter factory gate",
            };
        private static string[] MapNames = new string[]
            {
            "[00]  To Mario's Pad (before)",
            "[01]  Bowser's Keep (before)",
            "[02]  To Mario's Pad",
            "[03]  Vista Hill",
            "[04]  Bowser's Keep",
            "[05]  Gate",
            "[06]  To Nimbus Land",
            "[07]  To Bowser's Keep",
            "[08]  Mario's Pad",
            "[09]  Mushroom Way",
            "[0A]  Mushroom Kingdom",
            "[0B]  Bandit's Way",
            "[0C]  Kero Sewers",
            "[0D]  To Mushroom Kingdom",
            "[0E]  Kero Sewers",
            "[0F]  Midas River",
            "[10]  Tadpole Pond",
            "[11]  Rose Way",
            "[12]  Rose Town",
            "[13]  Forest Maze",
            "[14]  Pipe Vault",
            "[15]  To Yo'ster Isle",
            "[16]  To Moleville",
            "[17]  To Pipe Vault",
            "[18]  Moleville",
            "[19]  Booster Pass",
            "[1A]  Booster Tower",
            "[1B]  Booster Hill",
            "[1C]  Marrymore",
            "[1D]  To Star Hill",
            "[1E]  To Marrymore",
            "[1F]  Star Hill",
            "[20]  Seaside Town",
            "[21]  Sea",
            "[22]  Sunken Ship",
            "[23]  To Land's End",
            "[24]  To Seaside Town",
            "[25]  Land's End",
            "[26]  Monstro Town",
            "[27]  Bean Valley",
            "[28]  Grate Guy's Casino",
            "[29]  To Nimbus Land",
            "[2A]  To Seaside Town",
            "[2B]  Land's End",
            "[2C]  Monstro Town",
            "[2D]  Bean Valley",
            "[2E]  Grate Guy's Casino",
            "[2F]  To Nimbus Land",
            "[30]  To Bean Valley",
            "[31]  Nimbus Land",
            "[32]  Barrel Volcano",
            "[33]  To Bowser's Keep",
            "[34]  Yo'ster Isle",
            "[35]  To Pipe Vault",
            "[36]  Coal Mines (Bowser's Keep)",
            "[37]  Factory (Bowser's Keep)"
            };

        private static string[] BattlefieldNames = new string[]
            {
            "Forest Maze",
            "Forest Maze: Bowyer\'s Pad",
            "Bean Valley: Beanstalks",
            "Sunken Ship: King Calamari\'s Cellar",
            "Sunken Ship",
            "Moleville Mines",
            "___mines",
            "Bowser\'s Keep",
            "Barrel Volcano: Czar Dragon\'s Pad",
            "Grasslands",
            "Mountains",
            "Mushroom Kingdom House",
            "Booster Tower",
            "Mushroom Kingdom Castle",
            "Kero Sewers: Underwater",
            "Mushroom Kingdom Castle",
            "Bowser\'s Keep Turret: Exor",
            "Booster Tower: Balcony",
            "Smithy Factory: Count Down\'s Pad",
            "Smithy Factory",
            "Barrel Volcano",
            "Kero Sewers",
            "Nimbus Castle",
            "Nimbus Castle: Birdo\'s Room",
            "Nimbus Land",
            "Underground",
            "___uses Mushroom Kingdom tiles",
            "___forested area with unique trees",
            "Mushroom Kingdom",
            "Bowser\'s Keep: Chandeliers",
            "Forest Maze: Path to Bowyer",
            "Level Up foreground",
            "Level Up background",
            "Plateaus",
            "___sea enclave",
            "Marrymore Chapel Sanctuary",
            "Star Hill",
            "Seaside Town Beach",
            "Sea",
            "Blade: Axem Rangers",
            "Smithy Factory: Domino & Cloaker\'s Pad",
            "Bean Valley: Grasslands",
            "Belome Temple",
            "Land\'s End Desert",
            "Factory Grounds: Smithy\'s Pad",
            "Smithy\'s Final Form",
            "Jinx\'s Dojo",
            "Culex",
            "Factory Grounds",
            "Bean Valley: Pipe Room",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____",
            "_____"
            };
        #endregion
        #endregion

        #region Methods

        private void InitializeEventScriptsEditor()
        {
            if (settings.EventLabels.Count == 0)
            {
                settings.EventLabels = new System.Collections.Specialized.StringCollection();
                for (int i = 0; i < 4096; i++)
                    settings.EventLabels.Add("EVENT #" + i);
                settings.EventLabels[16] = "Engage in battle (remove permanently after defeat)";
                settings.EventLabels[17] = "Engage in battle (remove temporarily after defeat)";
                settings.EventLabels[18] = "Engage in battle (do not remove after defeat)";
                settings.EventLabels[19] = "Engage in battle (remove permanently after defeat, if ran away, walk through while blinking)";
                settings.EventLabels[20] = "Engage in battle (remove temporarily after defeat, if ran away, walk through while blinking)";
                settings.EventLabels[24] = "Post-battle, check if lost/won, etc.";
                settings.EventLabels[32] = "Hit a treasure with a mushroom/star/flower";
                settings.EventLabels[33] = "Hit a treasure with an item (item bag sprite)";
                settings.EventLabels[34] = "Hit a treasure with coins";
                settings.EventLabels[65] = "Jump on trampoline";
                settings.EventLabels[269] = "Come up from tree trunk";
                settings.EventLabels[1556] = "Jump on wiggler";
            }
            if (settings.ActionLabels.Count == 0)
            {
                settings.ActionLabels = new System.Collections.Specialized.StringCollection();
                for (int i = 0; i < 1024; i++)
                    settings.ActionLabels.Add("ACTION #" + i);
            }
            eventLabel.Text = settings.EventLabels[(int)this.EventNumber.Value];

            treeViewWrapper = new TreeViewWrapper(this.EventScriptTree);
            treeViewWrapper.ChangeScript(eventScripts[(int)this.EventNumber.Value]);

            this.autoPointerUpdateToolStripMenuItem.Checked = state.AutoPointerUpdate;
            eventName.SelectedIndex = 0; // Editing Event Scripts

            UpdateEventScriptsFreeSpace();
        }

        private void SaveEventNotes()
        {
            try
            {
                //this.EventScriptNotes.SaveFile(notes.GetPath() + "main-scripts-event.rtf");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR saving main-scripts-event.rtf, please report this if it persists");
            }
        }

        private string[] EventListBoxNames(int index)
        {
            switch (index)
            {
                case 0:
                    return new string[] 
                    {
                    "Action queue...",      // 0x00 - 0x2F
                    "Freeze all objects until return",			// 0x30
                    "Unfreeze all objects",			// 0x31
                    "If object present...", // 0x32
                    "If Mario on top of object, jump to...",    // 0x39
                    "If distance between object A and...",			// 0x3A
                    "If distance (Z==) between object A and...",			// 0x3B
                    "If Mario in air, jump to...",			// 0x3D
                    "Create new NPC packet @ object coords...",			// 0x3E
                    "Create new NPC packet @ Mario coords...",			// 0x3F
                    "If Mario on top of an object, jump to...",			// 0x42
                    "Set object presence...",			// 0xF2
                    "Set object event trigger...",			// 0xF3
                    "Set object: mem 00:70A8, presence = true (current level)",			// 0xF4
                    "Set object: mem 00:70A8, presence = false (current level)",			// 0xF5
                    "Set object: mem 00:70A8, event trigger = true",			// 0xF6
                    "Set object: mem 00:70A8, event trigger = false",			// 0xF7
                    "If object in level ..., presence =...",			// 0xF8

                    /********FD OPTIONS********/

                    "Remember last object",			// 0x32
                    "If running action script, object...",			// 0x33
                    "If underwater, object...",			// 0x34
                    "If in air, object...",			// 0x3D
                    "Create new NPC packet with event @ Mario coords...",			// 0x3E
                    "Mario glows via super star"			// 0xF9
                                        };

                case 1:
                    return new string[] 
                    {
                    "Joypad enable exclusively (reset @ return)...",			// 0x34
                    "Joypad enable exclusively...",			// 0x35
                                        };

                case 2:
                    return new string[] 
                    { 
                    "Activate party member...",			// 0x36
                    "Equip item to character...",			// 0x54
                    "HP -= mem 00:7000, character...",			// 0x56

                    /********FD OPTIONS********/

                    "Experience += experience packet data",			// 0x4B
                    "Restore all HP",			// 0x5B
                    "Experience packet = mem 00:7000"			// 0x64
                    };

                case 3:
                    return new string[] 
                    { 
                    "Inventory store x1, item...",			// 0x50
                    "Inventory remove x1, item...",			// 0x51
                    "Add to coins...",			// 0x52
                    "Add to frog coins...",			// 0x53
                    "FP -= mem 00:7000",			// 0x57

                    /********FD OPTIONS********/

                    "Store mem 00:70A7 to item inventory",			// 0x50
                    "Store mem 00:70A7 to equipment inventory",			// 0x51
                    "Coins += mem 00:7000",			// 0x52
                    "Coins -= mem 00:7000",			// 0x53
                    "Frog coins += mem 00:7000",			// 0x54
                    "Frog coins -= mem 00:7000",			// 0x55
                    "Current FP += mem 00:7000",			// 0x56
                    "Maximum FP += mem 00:7000",			// 0x57
                    "Restore all FP"			// 0x5C
                    };

                case 4:
                    return new string[] 
                    { 
                    "Engage battle with pack @ 00:700E",			// 0x49
                    "Engage battle with pack..."			// 0x4A
                    };

                case 5:
                    return new string[] 
                    { 
                    "Open, world map point...",			// 0x4B
                    "Open level...",			// 0x68
                    "Modify layer of level...",			// 0x69
                    "Modify solidity of level..."			// 0x6A
                    };

                case 6:
                    return new string[] 
                    { 
                    "Open, shop menu...",			// 0x4C
                    "Open, window...",			// 0x4F

                    /********FD OPTIONS********/

                    "Open, save game",			// 0x4A
                    "Open, menu tutorial...",			// 0x4C
                    "Open, level-up bonus"			// 0x65
                    };

                case 7:
                    return new string[] 
                    { 
                    "Run dlg...",			// 0x60
                    "Run dlg: mem 00:7000...",			// 0x61
                    "Run timed dlg...",			// 0x62
                    "Append to dlg: mem 00:7000...",			// 0x63
                    "Close dlg",			// 0x64
                    "Un-sync dlg",			// 0x65
                    "If dlg option B selected, jump to...",			// 0x66
                    "If dlg option B or C selected, jump to..."			// 0x67
                    };

                case 8:
                    return new string[] 
                    { 
                    "Run synchronous event...",			// 0x40
                    "Run common event...",			// 0x4E
                    "Run event (jump to)...",			// 0xD0
                    "Run event (sub-routine)...",			// 0xD1

                    /********FD OPTIONS********/

                    "Run star piece scene...",			// 0x4D
                    "Run moleville mountain",			// 0x4E
                    "Run moleville mountain intro",			// 0x4F
                    "Run character intro title...",			// 0x66
                    "Run ending credits",			// 0x67
                    "Run Exor crash into keep"			// 0xF8
                    };

                case 9:
                    return new string[] 
                    { 
                    "Jump to...",			// 0xD2
                    "Jump to subroutine...",			// 0xD3
                    "Loop start, loop count...",			// 0xD4
                    "Loop end",			// 0xD7
                    "Jump to script start(A)",			// 0xF9
                    "Jump to script start(B)"			// 0xFA
                    };

                case 10:
                    return new string[] 
                    {
                    "Fade-in from black (sync)",			// 0x70
                    "Fade-in from black (async)",			// 0x71
                    "Fade-in from black (sync), for duration...",			// 0x72
                    "Fade-in from black (async), for duration...",			// 0x73
                    "Fade-out to black (sync)",			// 0x74
                    "Fade-out to black (async)",			// 0x75
                    "Fade-out to black (sync), for duration...",			// 0x76
                    "Fade-out to black (async), for duration...",			// 0x77
                    "Fade-in from color...",			// 0x78
                    "Fade-out to color...",			// 0x79
                    "BG star frame expand",			// 0x7A
                    "BG star frame shrink",			// 0x7B
                    "BG circle frame expand",			// 0x7C
                    "BG circle frame shrink",			// 0x7D
                    "BG battle frame close",			// 0x7E
                    "Layer tinting, color...",			// 0x80
                    "Layer priorities, set...",			// 0x81
                    "Layer priorities, set to default",			// 0x82
                    "Screen flash, color...",			// 0x83
                    "Layer pixels, size: x...",			// 0x84
                    "Palette transform, set...",			// 0x89
                    "Palette set, set...",			// 0x8A
                    "Closing circle effect (non-static), to object...", // 0x87
                    "Closing circle effect (static), to object...",	    // 0x8F

                    /********FD OPTIONS********/

                    "Screen, unfixed",			// 0x30
                    "Screen, fixed"			// 0x31
                    };

                case 11:
                    return new string[] 
                    {
                    "Playback start current volume, track...",			// 0x90
                    "Playback start default volume, track...",			// 0x91
                    "Playback fade-in, track...",			// 0x92
                    "Playback fade-out track",			// 0x93
                    "Playback stop track",			// 0x94
                    "Playback fade-out track, duration...",			// 0x95
                    "Playback adjust track tempo, duration...",			// 0x97
                    "Playback adjust track pitch, duration...",			// 0x98
                    "Playback stop sound",			// 0x9B
                    "Playback start, sound...",			// 0x9C
                    "Playback start (speaker balance), sound...",			// 0x9D
                    "Playback fade-out sound, duration...",			// 0x9E

                    /********FD OPTIONS********/

                    "Playback start, sound (sync)...",             // 0x9C
                    "Playback, slow down track",			// 0xA4
                    "Playback, speed up track to normal"			// 0xA5
                    };

                case 12:
                    return new string[] 
                    { 
                    "Set mem...",			// 0xA0-0xA2
                    "Clear mem...",			// 0xA4-0xA6
                    "Store to mem a value (8-bit)...",			// 0xA8
                    "Add to mem (8-bit)...",			// 0xA9
                    "Increment mem (8-bit)...",// 0xAA
                    "Decrement mem (8-bit)...",// 0xAB
                    "Store to mem a value (16-bit)...",         // 0xB0
                    "Add to mem (16-bit)...",			// 0xB1
                    "Increment mem (16-bit)...",// 0xB2
                    "Decrement mem (16-bit)...",// 0xB3
                    "Store to mem from mem 00:7000 (8-bit)...",         // 0xB5
                    "Store random # to mem...",			// 0xB7
                    "Store to mem from mem 00:7000 (16-bit)...",        // 0xBB
                    "Store to mem from mem (choose both, 16-bit)...",      // 0xBC
                    "Exchange mem...",			// 0xBD
                    "Mem compare to...",			// 0xC2
                    "Object memory = mem...",   // 0xD6
                    "If set, mem...",			// 0xD8-0xDA
                    "If clear, mem...",// 0xDC-0xDE
                    "If mem = (8-bit)...",			// 0xE0
                    "If mem != (8-bit)...",			// 0xE1
                    "If mem = (16-bit)...",			// 0xE4
                    "If mem != (16-bit)...",			// 0xE5
                    "If random # > 128, jump to...",			// 0xE8
                    "If random # > 66, jump to...",			// 0xE9

                    /********FD OPTIONS********/

                    "Double mem...",			// 0xB6
                    "Generate random # < mem..."			// 0xB7
                    };

                case 13:
                    return new string[] 
                    {
                    "Mem 00:7000 = party capacity",			// 0x37
                    "Mem 00:7000 = character @ slot...",			// 0x38
                    "Mem 00:7000 = open item slots",			// 0x55
                    "Mem 00:7000 = current FP",			// 0x58
                    "Set mem @ mem 00:7000",			// 0xA3
                    "Clear mem @ mem 00:7000",			// 0xA7
                    "Mem 00:7000 =...",			// 0xAC
                    "Mem 00:7000 +=...",			// 0xAD
                    "Mem 00:7000 increment",			// 0xAE
                    "Mem 00:7000 decrement",			// 0xAF
                    "Mem 00:7000 = mem (8-bit)...",			// 0xB4
                    "Mem 00:7000 = random # less than...",			// 0xB6
                    "Mem 00:7000 += mem...",			// 0xB8
                    "Mem 00:7000 -= mem...",			// 0xB9
                    "Mem 00:7000 = mem (16-bit)...",			// 0xBA
                    "Mem 00:7000 compare to...",			// 0xC0
                    "Mem 00:7000 compare to mem...",			// 0xC1
                    "Mem 00:7000 = current level",			// 0xC3
                    "Mem 00:7000 = object X coord...",			// 0xC4
                    "Mem 00:7000 = object Y coord...",			// 0xC5
                    "Mem 00:7000 = object Z coord...",			// 0xC6
                    "Mem 00:7000 = held joypad register",			// 0xCA
                    "Mem 00:7000 = tapped joypad register",			// 0xCB
                    "If mem 00:7000 bit(s) set, jump to...",			// 0xDB
                    "If mem 00:7000 bit(s) clear, jump to...",			// 0xDF
                    "If mem 00:7000 =...",			// 0xE2
                    "If mem 00:7000 !=...",			// 0xE3
                    "If mem 00:7000 set, no bits...",			// 0xE6
                    "If mem 00:7000 set, any bits...",			// 0xE7
                    "If equal to zero, jump to...",			// 0xEA
                    "If not equal to zero, jump to...",			// 0xEB
                    "If greater than / equal to, jump to...",			// 0xEC
                    "If less than, jump to...",			// 0xED
                    "If negative, jump to...",			// 0xEE
                    "If positive, jump to...",			// 0xEF

                    /********FD OPTIONS********/

                    "Mem 00:7000 = quantity of item...",			// 0x58
                    "Mem 00:7000 = coins",			// 0x59
                    "Mem 00:7000 = frog coins",			// 0x5A
                    "Mem 00:7000 = equipment of character...",			// 0x5D
                    "Mem 00:70A7 = quantity in inventory of item @ mem 00:7000",			// 0x5E
                    "Mem 00:7000 = mem 7F:...",			// 0xAC
                    "Mem 00:7000 isolate bits =...",			// 0xB0
                    "Mem 00:7000 set bits =...",			// 0xB1
                    "Mem 00:7000 xor bits =...",			// 0xB2
                    "Mem 00:7000 isolate bits = mem...",			// 0xB3
                    "Mem 00:7000 set bits = mem...",			// 0xB4
                    "Mem 00:7000 xor bits = mem..."			// 0xB5
                    };

                case 14:
                    return new string[] 
                    { 
                    "Delay, frames (8-bit)...",			// 0xF0
                    "Delay, frames (16-bit)...",			// 0xF1

                    /********FD OPTIONS********/

                    "Pause script, resume on next dlg page(A)",			// 0x60
                    "Pause script, resume on next dlg page(B)"			// 0x61
                    };

                case 15:
                    return new string[] 
                    {
                    "Reset game, choose game",			// 0xFB
                    "Reset game"			// 0xFC
                    };

                case 16:
                    return new string[] 
                    {
                    "Return",			// 0xFE
                    "Return all"			// 0xFF
                    };

                default:
                    return new string[] { };
            }
        }

        private void ControlEventDisasmMethod()
        {
            updatingControls = false;

            switch (esc.Opcode)
            {
                // Objects
                case 0x32:  // If object present...
                case 0x39:  // If Mario on top of object...
                    if (esc.Opcode == 0x39) labelTitleA.Text = "If Mario on top of object...";
                    else labelTitleA.Text = "If object present...";
                    labelEvtA.Text = "object";
                    labelEvtC.Text = "jump to";
                    evtNameA.Items.AddRange(ObjectNames); evtNameA.Enabled = true;
                    evtNumC.Hexadecimal = true; evtNumC.Maximum = 0xFFFF; evtNumC.Enabled = true;

                    evtNameA.SelectedIndex = esc.Option;
                    evtNumC.Value = BitManager.GetShort(esc.EventData, 2);
                    break;
                case 0x3A:         // If distance between object A and...
                case 0x3B:         // If distance (Z==) between object A and...
                    labelTitleA.Text = "If distance between object A and object B...";
                    labelEvtA.Text = "object A";
                    labelEvtB.Text = "object B";
                    labelEvtC.Text = "less than X";
                    labelEvtD.Text = "less than Y";
                    labelEvtE.Text = "jump to";
                    evtNameA.Items.AddRange(ObjectNames); evtNameA.Enabled = true;
                    evtNameB.Items.AddRange(ObjectNames); evtNameB.Enabled = true;
                    evtNumC.Enabled = true;
                    evtNumD.Enabled = true;
                    evtNumE.Enabled = true; evtNumE.Hexadecimal = true; evtNumE.Maximum = 0xFFFF;

                    evtNameA.SelectedIndex = esc.Option;          // object A
                    evtNameB.SelectedIndex = esc.EventData[2];    // object B
                    evtNumC.Value = esc.EventData[3];
                    evtNumD.Value = esc.EventData[4];
                    evtNumE.Value = BitManager.GetShort(esc.EventData, 5);
                    break;
                case 0x3D:         // If Mario in air...
                    labelTitleC.Text = "If Mario in air...";
                    labelEvtE.Text = "jump to";
                    evtNumE.Enabled = true; evtNumE.Hexadecimal = true; evtNumE.Maximum = 0xFFFF;

                    evtNumE.Value = BitManager.GetShort(esc.EventData, 1);
                    break;
                case 0x3E:         // Create new NPC packet @ obj coords...
                    labelTitleA.Text = "Create new NPC packet @ obj coords...";
                    labelEvtA.Text = "object";
                    labelEvtC.Text = "packet";
                    labelTitleC.Text = "If object null...";
                    labelEvtE.Text = "jump to";
                    evtNameA.Items.AddRange(ObjectNames); evtNameA.Enabled = true;
                    evtNumC.Enabled = true; evtNumC.Maximum = 79;
                    evtNumE.Enabled = true; evtNumE.Hexadecimal = true; evtNumE.Maximum = 0xFFFF;

                    evtNameA.SelectedIndex = esc.EventData[2];
                    evtNumC.Value = esc.Option;
                    evtNumE.Value = BitManager.GetShort(esc.EventData, 3);
                    break;
                case 0x3F:         // Create new NPC packet...
                    labelTitleA.Text = "Create new NPC packet @ Mario coords...";
                    labelEvtC.Text = "packet";
                    labelTitleC.Text = "If Mario null...";
                    labelEvtE.Text = "jump to";
                    evtNumC.Enabled = true; evtNumC.Maximum = 79;
                    evtNumE.Enabled = true; evtNumE.Hexadecimal = true; evtNumE.Maximum = 0xFFFF;

                    evtNumC.Value = esc.Option;
                    evtNumE.Value = BitManager.GetShort(esc.EventData, 2);
                    break;
                case 0x42:         // If Mario on top of an object...
                    labelTitleC.Text = "If Mario on top of an object...";
                    labelEvtE.Text = "jump to";
                    labelEvtF.Text = "else jump to";
                    evtNumE.Enabled = true; evtNumE.Hexadecimal = true; evtNumE.Maximum = 0xFFFF;
                    evtNumF.Enabled = true; evtNumF.Hexadecimal = true; evtNumF.Maximum = 0xFFFF;

                    evtNumE.Value = BitManager.GetShort(esc.EventData, 1);
                    evtNumF.Value = BitManager.GetShort(esc.EventData, 3);
                    break;
                case 0xF2:         // Set object presence...  
                case 0xF3:         // Set object engage type...
                case 0xF8:         // If object in level ..., presence =...
                    if (esc.Opcode == 0xF2)
                    {
                        labelTitleA.Text = "Set presence in...";
                        labelTitleB.Text = "presence is...";
                    }
                    else if (esc.Opcode == 0xF3)
                    {
                        labelTitleA.Text = "Set event trigger...";
                        labelTitleB.Text = "event trigger enabled is...";
                    }
                    else
                    {
                        labelTitleA.Text = "If presence in...";
                        labelTitleB.Text = "presence is...";
                        labelEvtE.Text = "jump to";
                    }
                    labelEvtA.Text = "level";
                    labelEvtB.Text = "for object";
                    evtNameA.Items.AddRange(LevelNames()); evtNameA.Enabled = true;
                    evtNameB.Items.AddRange(ObjectNames); evtNameB.Enabled = true;
                    evtNumA.Enabled = true; evtNumA.Maximum = 511;
                    evtEffects.Items.AddRange(new object[] { "true" }); evtEffects.Enabled = true;
                    if (esc.Opcode == 0xF8)
                        evtNumE.Enabled = true; evtNumE.Hexadecimal = true; evtNumE.Maximum = 0xFFFF;

                    evtNumA.Value = BitManager.GetShort(esc.EventData, 1) & 0x1FF;
                    evtNameA.SelectedIndex = (int)evtNumA.Value;
                    evtNameB.SelectedIndex = (esc.EventData[2] >> 1) & 0x3F;
                    evtEffects.SetItemChecked(0, (esc.EventData[2] & 0x80) == 0x80);
                    if (esc.Opcode == 0xF8)
                        evtNumE.Value = BitManager.GetShort(esc.EventData, 3);
                    /* 
                     * TODO
                     * synchronize evtNameA with evtNumA
                     */
                    break;

                // Joypad
                case 0x34:
                case 0x35:
                    if (esc.Opcode == 0x34) labelTitleB.Text = "Joypad enable exclusively (reset @ return)...";
                    else labelTitleB.Text = "Joypad enable exclusively...";

                    evtEffects.Items.AddRange(ButtonNames); evtEffects.Enabled = true;

                    for (int i = 1, j = 0; j < 8; i *= 2, j++)
                        evtEffects.SetItemChecked(j, (esc.Option & i) == i);
                    break;

                // Party Members
                case 0x36:
                    labelTitleA.Text = "Add character to party...";
                    labelEvtA.Text = "character";
                    evtNameA.Items.AddRange(CharacterNames); evtNameA.Enabled = true;
                    evtEffects.Items.AddRange(new string[] { "increment party capacity" }); evtEffects.Enabled = true;

                    evtNameA.SelectedIndex = esc.Option & 7;
                    evtEffects.SetItemChecked(0, (esc.Option & 0x80) == 0x80);
                    break;
                case 0x54:
                    labelTitleA.Text = "Equip item to character...";
                    labelEvtA.Text = "character";
                    labelEvtB.Text = "item";
                    evtNameA.Items.AddRange(CharacterNames); evtNameA.Enabled = true;
                    evtNameB.Items.AddRange(universal.ItemNames.GetNames()); evtNameB.Enabled = true;
                    evtNumB.Maximum = 176; evtNumB.Enabled = true;

                    evtNameA.SelectedIndex = esc.Option & 7;
                    evtNumB.Value = esc.EventData[2];
                    evtNameB.SelectedIndex = universal.ItemNames.GetIndexFromNum((int)evtNumB.Value);
                    break;
                /* 
                * TODO
                * synchronize evtNameB with evtNumB
                */
                case 0x56:
                    labelTitleA.Text = "Subtract mem 00:7000 from character's HP...";
                    labelEvtA.Text = "character";
                    evtNameA.Items.AddRange(CharacterNames); evtNameA.Enabled = true;

                    evtNameA.SelectedIndex = esc.Option & 7;
                    break;

                // Inventory
                case 0x50:
                case 0x51:
                    if (esc.Opcode == 0x50) labelTitleA.Text = "Put x1 item in inventory...";
                    else labelTitleA.Text = "Remove x1 item in inventory...";

                    labelEvtA.Text = "item";
                    evtNameA.Items.AddRange(universal.ItemNames.GetNames()); evtNameA.Enabled = true;
                    evtNumA.Maximum = 176; evtNumA.Enabled = true;

                    evtNumA.Value = esc.Option;
                    evtNameA.SelectedIndex = universal.ItemNames.GetIndexFromNum((int)evtNumA.Value);
                    break;
                /* 
                * TODO
                * synchronize evtNameA with evtNumA
                */
                case 0x52:
                case 0x53:
                    if (esc.Opcode == 0x52) labelTitleA.Text = "Add to coins...";
                    else labelTitleA.Text = "Add to frog coins...";

                    labelEvtA.Text = "addend";
                    evtNumA.Enabled = true;

                    evtNumA.Value = esc.Option;
                    break;

                // Battle
                case 0x4A:
                    labelTitleA.Text = "Engage in battle with pack...";
                    labelEvtB.Text = "battlefield";
                    labelEvtC.Text = "pack";
                    evtNameB.Items.AddRange(BattlefieldNames); evtNameB.Enabled = true;
                    evtNumB.Maximum = 63; evtNumB.Enabled = true;
                    evtNumC.Enabled = true;

                    evtNumB.Value = esc.EventData[3];
                    evtNameB.SelectedIndex = esc.EventData[3];
                    evtNumC.Value = esc.Option;
                    break;

                // Levels
                /* 
                 * TODO
                 * synchronize evtNameA with evtNumA for case 0x68,0x6A,0x6B
                 */
                case 0x4B:      // Open, world map point...
                    labelTitleA.Text = "Open world map point...";
                    labelEvtA.Text = "point";
                    labelTitleB.Text = "unknown bits";
                    evtNameA.Items.AddRange(MapNames); evtNameA.Enabled = true;
                    evtEffects.Items.AddRange(new string[] { "bit 5", "bit 6", "bit 7" }); evtEffects.Enabled = true;

                    evtNameA.SelectedIndex = esc.Option;
                    evtEffects.SetItemChecked(0, (esc.EventData[2] & 0x20) == 0x20);
                    evtEffects.SetItemChecked(1, (esc.EventData[2] & 0x40) == 0x40);
                    evtEffects.SetItemChecked(2, (esc.EventData[2] & 0x80) == 0x80);
                    break;
                case 0x68:
                    labelTitleA.Text = "Open level and place Mario @ coords...";
                    labelEvtA.Text = "level";
                    labelEvtB.Text = "radial / Z";
                    labelEvtC.Text = "X";
                    labelEvtD.Text = "Y";
                    evtNameA.Items.AddRange(LevelNames()); evtNameA.Enabled = true;
                    evtNameB.Items.AddRange(Directions); evtNameB.Enabled = true;
                    evtNumA.Enabled = true; evtNumA.Maximum = 511;
                    evtNumB.Enabled = true; evtNumB.Maximum = 31;
                    evtNumC.Enabled = true;
                    evtNumD.Enabled = true;
                    evtEffects.Items.AddRange(new object[] { "show message", "run entrance event", "Z coord +½" });
                    evtEffects.Enabled = true;

                    evtNumA.Value = BitManager.GetShort(esc.EventData, 1) & 0x1FF;
                    evtNameA.SelectedIndex = (int)evtNumA.Value;
                    evtNumB.Value = esc.EventData[5] & 0x1F;
                    evtNameB.SelectedIndex = (esc.EventData[5] & 0xE0) >> 5;
                    evtNumC.Value = esc.EventData[3];
                    evtNumD.Value = esc.EventData[4];
                    evtEffects.SetItemChecked(0, (esc.EventData[2] & 0x08) == 0x08);
                    evtEffects.SetItemChecked(1, (esc.EventData[2] & 0x80) == 0x80);
                    evtEffects.SetItemChecked(2, (esc.EventData[4] & 0x80) == 0x80);
                    break;
                case 0x6A:
                case 0x6B:
                    if (esc.Opcode == 0x6A) labelTitleA.Text = "Modify layer of level...";
                    else labelTitleA.Text = "Modify solidity of level...";
                    labelEvtA.Text = "level";

                    evtNameA.Items.AddRange(LevelNames()); evtNameA.Enabled = true;
                    evtNumA.Enabled = true; evtNumA.Maximum = 511;

                    evtNumA.Value = BitManager.GetShort(esc.EventData, 1) & 0x1FF;
                    evtNameA.SelectedIndex = (int)evtNumA.Value;

                    evtEffects.Items.AddRange(new object[] { "permanent" });
                    evtEffects.Enabled = true;
                    evtEffects.SetItemChecked(0, (esc.EventData[2] & 0x80) == 0x80);
                    break;

                // Open window
                case 0x4C:      // Open, shop menu...
                    labelTitleA.Text = "Open shop menu...";
                    labelEvtA.Text = "shop";
                    evtNumA.Enabled = true;

                    evtNumA.Value = esc.Option;
                    break;
                case 0x4F:      // Open, window...
                    labelTitleA.Text = "Open window...";
                    labelEvtA.Text = "window";
                    evtNameA.Items.AddRange(MenuNames);
                    evtNameA.Enabled = true;

                    evtNameA.SelectedIndex = esc.Option;
                    break;

                // Dialogue
                /* 
                 * TODO
                 * synchronize evtNameA with evtNumA for case 0x60 and 0x62
                 */
                case 0x60:
                    labelTitleA.Text = "Run dialogue...";
                    labelEvtA.Text = "dialogue";
                    labelEvtB.Text = "above obj";
                    labelTitleB.Text = "properties";
                    evtNameA.Items.AddRange(DialogueNames()); evtNameA.Enabled = true;
                    evtNumA.Maximum = 4095; evtNumA.Enabled = true;
                    evtNameB.Items.AddRange(ObjectNames); evtNameB.Enabled = true;
                    evtEffects.Items.AddRange(new string[] { "closable", "asynchronous", "multi-line", "paper BG" });
                    evtEffects.Enabled = true;

                    evtNumA.Value = BitManager.GetShort(esc.EventData, 1) & 0xFFF;
                    evtNameA.SelectedIndex = (int)evtNumA.Value;
                    evtNameB.SelectedIndex = esc.EventData[3] & 0x3F;
                    evtEffects.SetItemChecked(0, (esc.EventData[2] & 0x20) == 0x20);
                    evtEffects.SetItemChecked(1, (esc.EventData[2] & 0x80) == 0x80);
                    evtEffects.SetItemChecked(2, (esc.EventData[3] & 0x40) == 0x40);
                    evtEffects.SetItemChecked(3, (esc.EventData[3] & 0x80) == 0x80);
                    break;
                case 0x61:
                    labelTitleA.Text = "Run dialogue from mem 00:7000...";
                    labelEvtA.Text = "above obj";
                    labelTitleB.Text = "properties";
                    evtNameA.Items.AddRange(ObjectNames); evtNameA.Enabled = true;
                    evtEffects.Items.AddRange(new string[] { "closable", "asynchronous", "multi-line", "paper BG" });
                    evtEffects.Enabled = true;

                    evtNameA.SelectedIndex = esc.EventData[2] & 0x3F;
                    evtEffects.SetItemChecked(0, (esc.Option & 0x20) == 0x20);
                    evtEffects.SetItemChecked(1, (esc.Option & 0x80) == 0x80);
                    evtEffects.SetItemChecked(2, (esc.EventData[2] & 0x40) == 0x40);
                    evtEffects.SetItemChecked(3, (esc.EventData[2] & 0x80) == 0x80);
                    break;
                case 0x62:
                    labelTitleA.Text = "Run timed dialogue...";
                    labelEvtA.Text = "dialogue";
                    labelEvtC.Text = "timing";
                    labelTitleB.Text = "properties";
                    evtNameA.Items.AddRange(DialogueNames()); evtNameA.Enabled = true;
                    evtNumA.Maximum = 4095; evtNumA.Enabled = true;
                    evtNumC.Maximum = 3; evtNumC.Enabled = true;
                    evtEffects.Items.AddRange(new string[] { "asynchronous" });
                    evtEffects.Enabled = true;

                    evtNumA.Value = BitManager.GetShort(esc.EventData, 1) & 0xFFF;
                    evtNameA.SelectedIndex = (int)evtNumA.Value;
                    evtNumC.Value = (esc.EventData[2] & 0x60) >> 5;
                    evtEffects.SetItemChecked(0, (esc.EventData[2] & 0x80) == 0x80);
                    break;
                case 0x63:
                    labelTitleA.Text = "Append to current dialogue from mem 00:7000...";
                    labelTitleB.Text = "properties";
                    evtEffects.Items.AddRange(new string[] { "closable", "asynchronous" }); evtEffects.Enabled = true;

                    evtEffects.SetItemChecked(0, (esc.Option & 0x20) == 0x20);
                    evtEffects.SetItemChecked(1, (esc.Option & 0x80) == 0x80);
                    break;
                case 0x66:
                case 0x67:
                    if (esc.Opcode == 0x67)
                    {
                        labelTitleA.Text = "If dialogue option B / C selected, jump to...";
                        labelEvtD.Text = "if C, jump to";
                        evtNumD.Maximum = 0xFFFF; evtNumD.Hexadecimal = true; evtNumD.Enabled = true;
                        evtNumD.Value = BitManager.GetShort(esc.EventData, 3);
                    }
                    else
                        labelTitleA.Text = "If dialogue option B selected, jump to...";

                    labelEvtC.Text = "if B, jump to";
                    evtNumC.Maximum = 0xFFFF; evtNumC.Hexadecimal = true; evtNumC.Enabled = true;
                    evtNumC.Value = BitManager.GetShort(esc.EventData, 1);
                    break;

                // Events
                case 0x40:
                    labelTitleA.Text = "Run synchronous event...";
                    labelEvtC.Text = "event";
                    labelTitleB.Text = "bits";
                    evtNumC.Maximum = 4095; evtNumC.Enabled = true;
                    evtEffects.Items.AddRange(new string[] { "stop event if exit level", "bit 6", "bit 7" }); evtEffects.Enabled = true;

                    evtNumC.Value = BitManager.GetShort(esc.EventData, 1) & 0xFFF;
                    evtEffects.SetItemChecked(0, (esc.EventData[2] & 0x20) == 0x20);
                    evtEffects.SetItemChecked(1, (esc.EventData[2] & 0x40) == 0x40);
                    evtEffects.SetItemChecked(2, (esc.EventData[2] & 0x80) == 0x80);
                    break;
                case 0xD0:
                case 0xD1:
                    if (esc.Opcode == 0xD0) labelTitleA.Text = "Run event (jump to)...";
                    else labelTitleA.Text = "Run event (sub-routine)...";
                    labelEvtC.Text = "event";
                    evtNumC.Maximum = 4095; evtNumC.Enabled = true;

                    evtNumC.Value = BitManager.GetShort(esc.EventData, 1) & 0xFFF;
                    break;
                case 0x4E:
                    labelTitleA.Text = "Run common event...";
                    labelEvtA.Text = "category";
                    evtNameA.Items.AddRange(new string[]
                    {
                        "open select game",
                        "open overworld menu",
                        "open world map point",
                        "open shop menu",
                        "open save game",
                        "open items maxed out menu, toss item",
                        "UNK",
                        "open menu tutorial",
                        "star collection star piece add",
                        "moleville mountain cart race",
                        "UNK",
                        "moleville mountain intro",
                        "UNK",
                        "star piece endings",
                        "garden intro",
                        "entering gate to smithy factory",
                        "world map event"
                    });
                    evtNameA.Enabled = true;

                    evtNameA.SelectedIndex = esc.Option;
                    switch (evtNameA.SelectedIndex)
                    {
                        case 2: // open world map point
                            labelEvtB.Text = "map point";
                            evtNameB.Items.AddRange(MapNames); evtNameB.Enabled = true;

                            evtNameB.SelectedIndex = esc.EventData[2];
                            break;
                        case 3: // open shop menu
                            labelEvtC.Text = "shop menu";
                            evtNumC.Maximum = 32; evtNumC.Enabled = true;

                            evtNumC.Value = esc.EventData[2];
                            break;
                        case 5: // items maxed out
                            labelEvtB.Text = "toss item";
                            evtNameB.Items.AddRange(universal.ItemNames.GetNames()); evtNameB.Enabled = true;
                            evtNumB.Maximum = 176; evtNumB.Enabled = true;

                            evtNumB.Value = esc.EventData[2];
                            evtNameB.SelectedIndex = universal.ItemNames.GetIndexFromNum((int)evtNumB.Value);
                            break;
                        case 7: // menu tutorial
                            labelEvtB.Text = "tutorial";
                            evtNameB.Items.AddRange(new string[] { "How to equip", "How to use items", "How to switch allies", "How to play beetle mania" });
                            evtNameB.Enabled = true;

                            evtNameB.SelectedIndex = esc.EventData[2];
                            break;
                        case 16:    // world map event
                            labelEvtB.Text = "map event";
                            evtNameB.Items.AddRange(new string[] { "Mario falls to pipehouse", "Mario returns to MK", "Mario takes Nimbus bus" });
                            evtNameB.Enabled = true;

                            evtNameB.SelectedIndex = esc.EventData[2];
                            break;
                    }

                    /* 
                     * TODO
                     * in eventHandler set evtNumC maximum and labelEvtC text 
                     * based on selectedIndex in evtNameA
                     */
                    break;

                // Jump to
                case 0xD2:
                case 0xD3:
                    if (esc.Opcode == 0xD2) labelTitleA.Text = "Jump to address...";
                    else labelTitleA.Text = "Jump to subroutine...";

                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true; evtNumC.Maximum = 0xFFFF; evtNumC.Enabled = true;

                    evtNumC.Value = BitManager.GetShort(esc.EventData, 1);
                    break;
                case 0xD4:
                    labelTitleA.Text = "Loop start, loop count...";
                    labelEvtC.Text = "count";
                    evtNumC.Enabled = true;

                    evtNumC.Value = esc.Option;
                    break;

                // Screen effects
                case 0x72:
                case 0x73:
                case 0x76:
                case 0x77:
                    switch (esc.Opcode)
                    {
                        case 0x72: labelTitleA.Text = "Fade in from black (sync), for duration..."; break;
                        case 0x73: labelTitleA.Text = "Fade in from black (async), for duration..."; break;
                        case 0x76: labelTitleA.Text = "Fade out to black (sync), for duration..."; break;
                        case 0x77: labelTitleA.Text = "Fade out to black (async), for duration..."; break;
                    }
                    labelEvtC.Text = "duration";
                    evtNumC.Enabled = true;

                    evtNumC.Value = esc.Option;
                    break;
                case 0x78:
                case 0x79:
                case 0x83:
                    if (esc.Opcode == 0x78) labelTitleA.Text = "Fade in from color...";
                    else if (esc.Opcode == 0x79) labelTitleA.Text = "Fade out to color";
                    else labelTitleA.Text = "Screen flash color...";
                    labelEvtA.Text = "color";
                    evtNameA.Items.AddRange(ColorNames); evtNameA.Enabled = true;

                    if (esc.Opcode != 0x83)
                    {
                        labelEvtC.Text = "duration";
                        evtNumC.Enabled = true;
                        evtNumC.Value = esc.Option;
                        evtNameA.SelectedIndex = esc.EventData[2];
                    }
                    else
                        evtNameA.SelectedIndex = esc.Option;
                    break;
                case 0x80:
                    labelTitleA.Text = "Layer tinting, color...";
                    labelEvtA.Text = "speed";
                    labelEvtB.Text = "red";
                    labelEvtC.Text = "green";
                    labelEvtD.Text = "blue";
                    labelTitleB.Text = "tint layers...";
                    evtNumA.Enabled = true;
                    evtNumB.Enabled = true;
                    evtNumC.Enabled = true;
                    evtNumD.Enabled = true;
                    evtEffects.Items.AddRange(LayerNames); evtEffects.Enabled = true;

                    double multiplier = 8; // 8;
                    ushort color = BitManager.GetShort(esc.EventData, 1);
                    evtNumB.Value = (byte)((color % 0x20) * multiplier);
                    evtNumC.Value = (byte)(((color >> 5) % 0x20) * multiplier);
                    evtNumD.Value = (byte)(((color >> 10) % 0x20) * multiplier);

                    evtNumA.Value = esc.EventData[4];
                    for (int i = 1, j = 0; j < 8; i *= 2, j++)
                        evtEffects.SetItemChecked(j, (esc.EventData[3] & i) == i);
                    break;
                case 0x81:
                    labelTitleA.Text = "Layer priorities, set...";
                    labelTitleB.Text = "mainscreen / subscreen / color math";
                    evtEffects.ColumnWidth = (int)(evtEffects.ColumnWidth / 2);
                    evtEffects.Items.AddRange(new string[]
                    {
                        "L1","L2","L3","Sprites",
                        "L1","L2","L3","Sprites",
                        "L1","L2","L3","Sprites", "BG", "½ intensity", "Minus sub"
                    });
                    evtEffects.Enabled = true;

                    evtEffects.SetItemChecked(0, (esc.Option & 0x01) == 0x01);
                    evtEffects.SetItemChecked(1, (esc.Option & 0x02) == 0x02);
                    evtEffects.SetItemChecked(2, (esc.Option & 0x04) == 0x04);
                    evtEffects.SetItemChecked(3, (esc.Option & 0x10) == 0x10);
                    evtEffects.SetItemChecked(4, (esc.EventData[2] & 0x01) == 0x01);
                    evtEffects.SetItemChecked(5, (esc.EventData[2] & 0x02) == 0x02);
                    evtEffects.SetItemChecked(6, (esc.EventData[2] & 0x04) == 0x04);
                    evtEffects.SetItemChecked(7, (esc.EventData[2] & 0x10) == 0x10);
                    evtEffects.SetItemChecked(8, (esc.EventData[3] & 0x01) == 0x01);
                    evtEffects.SetItemChecked(9, (esc.EventData[3] & 0x02) == 0x01);
                    evtEffects.SetItemChecked(10, (esc.EventData[3] & 0x04) == 0x01);
                    evtEffects.SetItemChecked(11, (esc.EventData[3] & 0x08) == 0x01);
                    evtEffects.SetItemChecked(12, (esc.EventData[3] & 0x20) == 0x20);
                    evtEffects.SetItemChecked(13, (esc.EventData[3] & 0x40) == 0x40);
                    evtEffects.SetItemChecked(14, (esc.EventData[3] & 0x80) == 0x80);
                    /*
                    * TODO
                    * set evtEffects according to evtNameA.SelectedIndex
                    */
                    break;
                case 0x84:
                    labelTitleA.Text = "Layer pixels, size...";
                    labelEvtC.Text = "size times";
                    labelEvtD.Text = "duration";
                    labelTitleB.Text = "effect layers...";
                    evtNumC.Maximum = 15; evtNumC.Enabled = true;
                    evtNumD.Maximum = 63; evtNumD.Enabled = true;
                    evtEffects.Items.AddRange(new string[] { "L1", "L2", "L3", "L4" }); evtEffects.Enabled = true;

                    evtNumC.Value = esc.Option >> 4;
                    evtNumD.Value = esc.EventData[2] & 0x3F;
                    for (int i = 1, j = 0; j < 4; i *= 2, j++)
                        evtEffects.SetItemChecked(j, (esc.Option & i) == i);
                    break;
                case 0x89:
                    labelTitleA.Text = "Palette set transform...";
                    labelEvtA.Text = "style";
                    labelEvtB.Text = "duration";
                    labelEvtC.Text = "pal set";
                    labelEvtD.Text = "pal index";
                    evtNameA.Items.AddRange(new string[] { "nothing", "glow", "set to", "fade to" });
                    evtNameA.Enabled = true;
                    evtNumB.Maximum = 15; evtNumB.Enabled = true;
                    evtNumC.Enabled = true;
                    evtNumD.Maximum = 16; evtNumD.Enabled = true;
                    evtEffects.Enabled = true;

                    switch (esc.Option & 0xE0)
                    {
                        case 0x60: evtNameA.SelectedIndex = 1; break;
                        case 0xC0: evtNameA.SelectedIndex = 2; break;
                        case 0xE0: evtNameA.SelectedIndex = 3; break;
                        default: evtNameA.SelectedIndex = 0; break;
                    }
                    evtNumB.Value = esc.Option & 0x0F;
                    evtNumC.Value = esc.EventData[3];
                    evtNumD.Value = esc.EventData[2];
                    break;
                case 0x8A:
                    labelTitleA.Text = "Palette set change...";
                    labelEvtC.Text = "pal set";
                    labelEvtD.Text = "index 0 to";
                    evtNumC.Enabled = true;
                    evtNumD.Maximum = 16; evtNumD.Minimum = 1; evtNumD.Enabled = true;

                    evtNumC.Value = esc.EventData[2];
                    evtNumD.Value = (esc.Option >> 4) + 1;
                    break;
                case 0x87: labelTitleA.Text = "Closing circle effect to object (non-static)..."; goto case 0x8F;
                case 0x8F:
                    if (esc.Opcode == 0x8F) labelTitleA.Text = "Closing circle effect to object (static)...";
                    labelEvtA.Text = "object";
                    labelEvtC.Text = "min radius";
                    labelEvtD.Text = "speed";
                    evtNameA.Items.AddRange(ObjectNames); evtNameA.Enabled = true;
                    evtNumC.Enabled = true;
                    evtNumD.Enabled = true;

                    evtNameA.SelectedIndex = esc.Option;
                    evtNumC.Value = esc.EventData[2];
                    evtNumD.Value = esc.EventData[3];
                    break;

                // Playback audio
                case 0x90:
                case 0x91:
                case 0x92:
                    if (esc.Opcode == 0x90) labelTitleA.Text = "Playback start at current volume, track...";
                    else if (esc.Opcode == 0x91) labelTitleA.Text = "Playback start at default volume, track...";
                    else labelTitleA.Text = "Playback fade-in track...";
                    labelEvtA.Text = "track";
                    evtNameA.Items.AddRange(MusicNames); evtNameA.Enabled = true;

                    evtNameA.SelectedIndex = esc.Option;
                    break;
                case 0x95:
                    labelTitleA.Text = "Playback fade-out track...";
                    labelEvtC.Text = "duration";
                    labelEvtD.Text = "to volume";
                    evtNumC.Enabled = true;
                    evtNumD.Enabled = true;

                    evtNumC.Value = esc.Option;
                    evtNumD.Value = esc.EventData[2];
                    break;
                case 0x97:
                    labelTitleA.Text = "Playback adjust track tempo...";
                    labelEvtA.Text = "change type";
                    labelEvtD.Text = "duration";
                    evtNameA.Items.AddRange(new string[] { "slow down", "speed up" }); evtNameA.Enabled = true;
                    evtNumC.Enabled = true;
                    evtNumD.Enabled = true;

                    if (esc.EventData[2] >= 0xA1)
                    {
                        labelEvtC.Text = "speed up";
                        evtNumC.Maximum = 94;

                        evtNameA.SelectedIndex = 1;
                        evtNumC.Value = 0x100 - esc.EventData[2];
                    }
                    else
                    {
                        labelEvtC.Text = "slow down";
                        evtNumC.Maximum = 160;

                        evtNameA.SelectedIndex = 0;
                        evtNumC.Value = esc.EventData[2];
                    }
                    evtNumD.Value = esc.Option;
                    /*
                     * TODO
                     * set labelEvtC text and evtNumC value based on what change type is
                     * if slow down, set max to 160, else set max to 94
                     * if speed up, set value = (0x100 - esc.EventData[2]) - 1
                     */
                    break;
                case 0x98:
                    labelTitleA.Text = "Playback adjust track pitch...";
                    labelEvtA.Text = "change type";
                    labelEvtC.Text = "duration";
                    evtNameA.Items.AddRange(new string[] { "raise", "lower" }); evtNameA.Enabled = true;
                    evtNumC.Enabled = true;

                    evtNameA.SelectedIndex = (esc.EventData[2] & 0x80) == 0x80 ? 1 : 0;
                    evtNumC.Value = esc.Option;
                    break;
                case 0x9C:
                    labelTitleA.Text = "Playback start, sound...";
                    labelEvtA.Text = "sound";
                    evtNameA.Items.AddRange(SoundNames); evtNameA.Enabled = true;

                    evtNameA.SelectedIndex = esc.Option;
                    break;
                case 0x9D:
                    labelTitleA.Text = "Playback start (speaker balance), sound...";
                    labelEvtC.Text = "balance";
                    evtNameA.Items.AddRange(SoundNames); evtNameA.Enabled = true;
                    evtNumC.Enabled = true;

                    evtNameA.SelectedIndex = esc.Option;
                    evtNumC.Value = esc.EventData[2];
                    break;
                case 0x9E:
                    labelTitleA.Text = "Playback fade-out sound...";
                    labelEvtC.Text = "duration";
                    labelEvtD.Text = "to volume";
                    evtNumC.Enabled = true;
                    evtNumD.Enabled = true;

                    evtNumC.Value = esc.Option;
                    evtNumD.Value = esc.EventData[2];
                    break;

                // Memory
                case 0xA0:
                case 0xA1:
                case 0xA2:
                case 0xA4:
                case 0xA5:
                case 0xA6:
                    if (esc.Opcode < 0xA4) labelTitleA.Text = "Set mem...";
                    else labelTitleA.Text = "Clear mem...";

                    labelEvtC.Text = "address";
                    labelEvtD.Text = "bit";
                    evtNumC.Hexadecimal = true;
                    evtNumC.Maximum = 0x709F; evtNumC.Minimum = 0x7040;
                    evtNumC.Enabled = true;
                    evtNumD.Maximum = 7; evtNumD.Enabled = true;

                    if (esc.Opcode < 0xA4) evtNumC.Value = ((((esc.Opcode - 0xA0) * 0x100) + esc.Option) >> 3) + 0x7040;
                    else evtNumC.Value = ((((esc.Opcode - 0xA4) * 0x100) + esc.Option) >> 3) + 0x7040;
                    evtNumD.Value = esc.Option & 7;
                    break;
                case 0xA8:
                case 0xA9:
                    if (esc.Opcode == 0xA8) labelTitleA.Text = "Store to mem a value (8-bit)...";
                    else labelTitleA.Text = "Add to mem a value (8-bit)...";
                    labelEvtC.Text = "address";
                    labelEvtD.Text = "value";
                    evtNumC.Hexadecimal = true;
                    evtNumC.Maximum = 0x719F; evtNumC.Minimum = 0x70A0;
                    evtNumC.Enabled = true;
                    evtNumD.Enabled = true;

                    evtNumC.Value = esc.Option + 0x70A0;
                    evtNumD.Value = esc.EventData[2];
                    break;
                case 0xAA:
                case 0xAB:
                    if (esc.Opcode == 0xAA) labelTitleA.Text = "Increment mem (8-bit)...";
                    else labelTitleA.Text = "Decrement mem (8-bit)...";
                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true;
                    evtNumC.Maximum = 0x719F; evtNumC.Minimum = 0x70A0;
                    evtNumC.Enabled = true;

                    evtNumC.Value = esc.Option + 0x70A0;
                    break;
                case 0xB0:
                case 0xB1:
                case 0xC2:
                    if (esc.Opcode == 0xB0) labelTitleA.Text = "Store to mem a value (16-bit)...";
                    else if (esc.Opcode == 0xB1) labelTitleA.Text = "Add to mem a value (16-bit)...";
                    else labelTitleA.Text = "Compare to mem a value (16-bit)...";
                    labelEvtC.Text = "address";
                    labelEvtD.Text = "value";
                    evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                    evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                    evtNumC.Enabled = true;
                    evtNumD.Maximum = 65535; evtNumD.Enabled = true;

                    evtNumC.Value = (esc.Option * 2) + 0x7000;
                    evtNumD.Value = BitManager.GetShort(esc.EventData, 2);
                    break;
                case 0xB2:
                case 0xB3:
                case 0xD6:
                case 0xBB:
                    if (esc.Opcode == 0xB2) labelTitleA.Text = "Increment mem (16-bit)...";
                    else if (esc.Opcode == 0xB3) labelTitleA.Text = "Decrement mem (16-bit)...";
                    else if (esc.Opcode == 0xB6) labelTitleA.Text = "Store to object mem from mem...";
                    else labelTitleA.Text = "Store to mem from mem 00:7000 (16-bit)...";
                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                    evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                    evtNumC.Enabled = true;

                    evtNumC.Value = (esc.Option * 2) + 0x7000;
                    break;
                case 0xB5:
                    labelTitleA.Text = "Store to mem from mem 00:7000 (8-bit)...";
                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true;
                    evtNumC.Maximum = 0x719F; evtNumC.Minimum = 0x70A0;
                    evtNumC.Enabled = true;

                    evtNumC.Value = esc.Option + 0x70A0;
                    break;
                case 0xB7:
                    labelTitleA.Text = "Store random # less than... to mem...";
                    labelEvtC.Text = "address";
                    labelEvtD.Text = "number <";
                    evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                    evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                    evtNumC.Enabled = true;
                    evtNumD.Maximum = 65535; evtNumD.Enabled = true;

                    evtNumC.Value = (esc.Option * 2) + 0x7000;
                    evtNumD.Value = BitManager.GetShort(esc.EventData, 2);
                    break;
                case 0xBC:
                case 0xBD:
                    if (esc.Opcode == 0xBC) labelTitleA.Text = "Store to mem A from mem B (choose both, 16-bit)...";
                    else labelTitleA.Text = "Exchange mem A and mem B (16-bit)...";
                    labelEvtC.Text = "address A";
                    labelEvtD.Text = "address B";
                    evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                    evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                    evtNumC.Enabled = true;
                    evtNumD.Hexadecimal = true; evtNumD.Increment = 2;
                    evtNumD.Maximum = 0x71FE; evtNumD.Minimum = 0x7000;
                    evtNumD.Enabled = true;

                    evtNumC.Value = (esc.Option * 2) + 0x7000;
                    evtNumD.Value = (esc.EventData[2] * 2) + 0x7000;
                    break;
                case 0xD8:
                case 0xD9:
                case 0xDA:
                case 0xDC:
                case 0xDD:
                case 0xDE:
                    if (esc.Opcode < 0xDC) labelTitleA.Text = "If set, mem...";
                    else labelTitleA.Text = "If clear, mem...";

                    labelEvtC.Text = "address";
                    labelEvtD.Text = "bit";
                    labelEvtE.Text = "then jump to...";
                    evtNumC.Hexadecimal = true;
                    evtNumC.Maximum = 0x709F; evtNumC.Minimum = 0x7040;
                    evtNumC.Enabled = true;
                    evtNumD.Maximum = 7; evtNumD.Enabled = true;
                    evtNumE.Hexadecimal = true; evtNumE.Maximum = 0xFFFF; evtNumE.Enabled = true;

                    if (esc.Opcode < 0xDC) evtNumC.Value = ((((esc.Opcode - 0xD8) * 0x100) + esc.Option) >> 3) + 0x7040;
                    else evtNumC.Value = ((((esc.Opcode - 0xDC) * 0x100) + esc.Option) >> 3) + 0x7040;
                    evtNumD.Value = esc.Option & 7;
                    evtNumE.Value = BitManager.GetShort(esc.EventData, 2);
                    break;
                case 0xE0:
                case 0xE1:
                    if (esc.Opcode == 0xE0) labelTitleA.Text = "If mem = (8-bit)...";
                    else labelTitleA.Text = "If mem != (8-bit)...";
                    labelEvtC.Text = "address";
                    labelEvtD.Text = "value";
                    labelEvtE.Text = "then jump to...";
                    evtNumC.Hexadecimal = true;
                    evtNumC.Maximum = 0x719F; evtNumC.Minimum = 0x70A0;
                    evtNumC.Enabled = true;
                    evtNumD.Enabled = true;
                    evtNumE.Hexadecimal = true; evtNumE.Maximum = 0xFFFF; evtNumE.Enabled = true;

                    evtNumC.Value = esc.Option + 0x70A0;
                    evtNumD.Value = esc.EventData[2];
                    evtNumE.Value = BitManager.GetShort(esc.EventData, 3);
                    break;
                case 0xE4:
                case 0xE5:
                    if (esc.Opcode == 0xE4) labelTitleA.Text = "If mem = (16-bit)...";
                    else labelTitleA.Text = "If mem != (16-bit)...";
                    labelEvtC.Text = "address";
                    labelEvtD.Text = "value";
                    labelEvtE.Text = "then jump to...";
                    evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                    evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                    evtNumC.Enabled = true;
                    evtNumD.Maximum = 65535; evtNumD.Enabled = true;
                    evtNumE.Hexadecimal = true; evtNumE.Maximum = 0xFFFF; evtNumE.Enabled = true;

                    evtNumC.Value = (esc.Option * 2) + 0x7000;
                    evtNumD.Value = BitManager.GetShort(esc.EventData, 2);
                    evtNumE.Value = BitManager.GetShort(esc.EventData, 4);
                    break;
                case 0xE8:
                    labelTitleA.Text = "If random # > 128, jump to...";
                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true; evtNumC.Maximum = 0xFFFF; evtNumC.Enabled = true;

                    evtNumC.Value = BitManager.GetShort(esc.EventData, 1);
                    break;
                case 0xE9:
                    labelTitleA.Text = "If random # > 66, jump to address A, else address B...";
                    labelEvtC.Text = "address A";
                    labelEvtD.Text = "address B";
                    evtNumC.Hexadecimal = true; evtNumC.Maximum = 0xFFFF; evtNumC.Enabled = true;
                    evtNumD.Hexadecimal = true; evtNumD.Maximum = 0xFFFF; evtNumD.Enabled = true;

                    evtNumC.Value = BitManager.GetShort(esc.EventData, 1);
                    evtNumD.Value = BitManager.GetShort(esc.EventData, 3);
                    break;

                // Memory 00:7000
                case 0x38:
                    labelTitleA.Text = "Mem 00:7000 = character @ slot...";
                    labelEvtC.Text = "slot";
                    evtNumC.Maximum = 4; evtNumC.Enabled = true;

                    if (esc.Option < 8) esc.Option = 8;
                    evtNumC.Value = esc.Option - 8;
                    break;
                case 0xAC: labelTitleA.Text = "Mem 00:7000 =..."; goto case 0xC0;
                case 0xAD: labelTitleA.Text = "Mem 00:7000 +=..."; goto case 0xC0;
                case 0xB6: labelTitleA.Text = "Mem 00:7000 = random # less than..."; goto case 0xC0;
                case 0xC0:
                    if (esc.Opcode == 0xC0) labelTitleA.Text = "Mem 00:7000 compare to...";
                    labelEvtC.Text = "value";
                    evtNumC.Maximum = 65535; evtNumC.Enabled = true;

                    evtNumC.Value = BitManager.GetShort(esc.EventData, 1);
                    break;
                case 0xB4:
                    labelTitleA.Text = "Mem 00:7000 = mem...";
                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true;
                    evtNumC.Maximum = 0x719F; evtNumC.Minimum = 0x70A0;
                    evtNumC.Enabled = true;

                    evtNumC.Value = esc.Option + 0x70A0;
                    break;
                case 0xB8: labelTitleA.Text = "Mem 00:7000 += mem..."; goto case 0xC1;
                case 0xB9: labelTitleA.Text = "Mem 00:7000 -= mem..."; goto case 0xC1;
                case 0xBA: labelTitleA.Text = "Mem 00:7000 = mem..."; goto case 0xC1;
                case 0xC1:
                    if (esc.Opcode == 0xC1) labelTitleA.Text = "Mem 00:7000 compare to mem...";
                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                    evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                    evtNumC.Enabled = true;

                    evtNumC.Value = (esc.Option * 2) + 0x7000;
                    break;
                case 0xC4: labelTitleA.Text = "Mem 00:7000 = object X coord..."; goto case 0xC6;
                case 0xC5: labelTitleA.Text = "Mem 00:7000 = object Y coord..."; goto case 0xC6;
                case 0xC6:
                    if (esc.Opcode == 0xC6) labelTitleA.Text = "Mem 00:7000 = object Z coord...";
                    labelEvtA.Text = "object";
                    evtNameA.Items.AddRange(ObjectNames); evtNameA.Enabled = true;
                    evtEffects.Items.Add("isometric"); evtEffects.Enabled = true;

                    evtNameA.SelectedIndex = esc.Option & 0x3F;
                    evtEffects.SetItemChecked(0, (esc.Option & 0x80) == 0x80);
                    break;
                case 0xDB: labelTitleA.Text = "If mem 00:7000 bit(s) set, jump to..."; goto case 0xDF;
                case 0xDF:
                    if (esc.Opcode == 0xDF) labelTitleA.Text = "If mem 00:7000 bit(s) clear, jump to...";
                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true; evtNumC.Maximum = 0xFFFF; evtNumC.Enabled = true;

                    evtNumC.Value = BitManager.GetShort(esc.EventData, 1);
                    break;
                case 0xE2: labelTitleA.Text = "If mem 00:7000 = value..."; labelEvtC.Text = "value"; goto case 0xE7;
                case 0xE3: labelTitleA.Text = "If mem 00:7000 != value..."; labelEvtC.Text = "value"; goto case 0xE7;
                case 0xE6: labelTitleA.Text = "If mem 00:7000 set, no bits..."; goto case 0xE7;
                case 0xE7:
                    if (esc.Opcode == 0xE7) labelTitleA.Text = "If mem 00:7000 set, any bits...";
                    if (esc.Opcode > 0xE3) labelEvtC.Text = "bits";
                    labelEvtD.Text = "jump to";
                    evtNumC.Maximum = 65535; evtNumC.Enabled = true;
                    evtNumD.Hexadecimal = true; evtNumD.Maximum = 0xFFFF; evtNumD.Enabled = true;

                    evtNumC.Value = BitManager.GetShort(esc.EventData, 1);
                    evtNumD.Value = BitManager.GetShort(esc.EventData, 3);
                    break;
                case 0xEA: labelTitleA.Text = "If equal to zero, jump to..."; goto case 0xEF;
                case 0xEB: labelTitleA.Text = "If not equal to zero, jump to..."; goto case 0xEF;
                case 0xEC: labelTitleA.Text = "If greater than / equal to, jump to..."; goto case 0xEF;
                case 0xED: labelTitleA.Text = "If less than, jump to..."; goto case 0xEF;
                case 0xEE: labelTitleA.Text = "If negative, jump to..."; goto case 0xEF;
                case 0xEF:
                    if (esc.Opcode == 0xEF) labelTitleA.Text = "If positive, jump to...";
                    labelEvtC.Text = "jump to";
                    evtNumC.Hexadecimal = true; evtNumC.Maximum = 0xFFFF; evtNumC.Enabled = true;

                    evtNumC.Value = BitManager.GetShort(esc.EventData, 1);
                    break;

                // Pause script
                case 0xF0:
                    labelTitleA.Text = "Pause script, frame duration (8-bit)...";
                    labelEvtC.Text = "frames";
                    evtNumC.Enabled = true;

                    evtNumC.Value = esc.Option;
                    break;
                case 0xF1:
                    labelTitleA.Text = "Pause script, frame duration (16-bit)...";
                    labelEvtC.Text = "frames";
                    evtNumC.Maximum = 65535; evtNumC.Enabled = true;

                    evtNumC.Value = BitManager.GetShort(esc.EventData, 1);
                    break;

                default:
                    // Action Queue (same for all sub-indexes, so no need to do a switch for sub)
                    if (esc.Opcode <= 0x2F)
                    {
                        labelTitleA.Text = "Start action queue for object...";
                        labelEvtA.Text = "Object";
                        labelEvtB.Text = "queue type";
                        evtNameA.Items.AddRange(ObjectNames);
                        evtNameB.Items.AddRange(new string[]
                        {                                           // OPTIONS:
                        "start action queue",                   // 0x00 - 0x7F
                        "start embedded action script",         // 0xF0
                        "start embedded action script",         // 0xF1
                        "set action script (sync)",             // 0xF2
                        "set action script (async)",         // 0xF3
                        "set temp action script (sync)",        // 0xF4
                        "set temp action script (async)",    // 0xF5
                        "un-sync action script",                // 0xF6
                        "show object @ Mario's coords",         // 0xF7
                        "show object",                          // 0xF8
                        "remove object",                        // 0xF9
                        "pause action script",                  // 0xFA
                        "resume action script",                 // 0xFB
                        "enable trigger",                       // 0xFC
                        "disable trigger",                      // 0xFD
                        "stop embedded action script",          // 0xFE
                        "set object coords to default"          // 0xFF
                        });
                        evtNameA.Enabled = true;
                        evtNameB.Enabled = true;

                        evtNameA.SelectedIndex = esc.Opcode;
                        if (esc.Option >= 0xF2)
                        {
                            evtNameB.SelectedIndex = esc.Option - 0xEF;
                        }
                        else evtNameB.SelectedIndex = 0;

                        if (esc.Option >= 0xF2 && esc.Option <= 0xF5)
                        {
                            labelEvtC.Text = "action #";
                            evtNumC.Maximum = 0x3FF; evtNumC.Enabled = true;

                            evtNumC.Value = BitManager.GetShort(esc.EventData, 2);
                        }
                        else if (esc.Option < 0xF2)
                        {
                            labelTitleB.Text = "properties...";
                            evtEffects.Items.AddRange(new string[] { "asynchronous" }); evtEffects.Enabled = true;
                            evtEffects.SetItemChecked(0, (esc.Option & 0x80) == 0x80);
                        }

                        /*
                              * TODO
                              * set evtNumC value and labelEvtC text according to evtNameB.SelectedIndex
                              */
                    }
                    else if (esc.Opcode == 0xFD)
                    {
                        switch (esc.Option)
                        {
                            // Objects
                            case 0x33: labelTitleA.Text = "If running action script, object..."; goto case 0x3D;         // If running action script, object...
                            case 0x34: labelTitleA.Text = "If underwater, object..."; goto case 0x3D;        // If underwater, object...
                            case 0x3D:         // If in air, object...
                                if (esc.Option == 0x3D) labelTitleA.Text = "If in air, object...";
                                labelEvtA.Text = "object";
                                labelEvtC.Text = "jump to";
                                evtNameA.Items.AddRange(ObjectNames); evtNameA.Enabled = true;
                                evtNumC.Hexadecimal = true; evtNumC.Maximum = 0xFFFF; evtNumC.Enabled = true;

                                evtNameA.SelectedIndex = esc.EventData[2];
                                evtNumC.Value = BitManager.GetShort(esc.EventData, 3);
                                break;
                            case 0x3E:
                                labelTitleA.Text = "Create new NPC packet with event @ Mario coords...";
                                labelEvtC.Text = "packet";
                                labelEvtD.Text = "event #";
                                labelTitleC.Text = "If Mario invalid, jump to...";
                                labelEvtE.Text = "address";
                                evtNumC.Maximum = 79; evtNumC.Enabled = true;
                                evtNumD.Maximum = 4095; evtNumD.Enabled = true;
                                evtNumE.Hexadecimal = true; evtNumE.Maximum = 0xFFFF; evtNumE.Enabled = true;

                                evtNumC.Value = esc.EventData[2];
                                evtNumD.Value = BitManager.GetShort(esc.EventData, 3) & 0xFFF;
                                evtNumE.Value = BitManager.GetShort(esc.EventData, 5);
                                break;

                            // Menus
                            case 0x4C:
                                labelTitleA.Text = "Open, Toad's menu tutorial...";
                                labelEvtC.Text = "menu";
                                evtNumC.Enabled = true;

                                evtNumC.Value = esc.EventData[2];
                                break;

                            // Run event
                            case 0x4D:
                                labelTitleA.Text = "Run star piece scene...";
                                labelEvtC.Text = "star #";
                                evtNumC.Maximum = 7; evtNumC.Minimum = 1; evtNumC.Enabled = true;

                                if (esc.EventData[2] < 1) esc.EventData[2] = 1;
                                evtNumC.Value = esc.EventData[2];
                                break;
                            case 0x66:
                                labelTitleA.Text = "Run character intro title...";
                                labelEvtA.Text = "title";
                                labelEvtC.Text = "from top";
                                evtNameA.Items.AddRange(new string[] { "Super Mario", "Princess Toadstool", "King Bowser", "Mallow", "Geno", "In..." });
                                evtNameA.Enabled = true;
                                evtNumC.Enabled = true;

                                evtNameA.SelectedIndex = esc.EventData[3];
                                evtNumC.Value = esc.EventData[2];
                                break;

                            // Playback audio
                            case 0x9C:
                                labelTitleA.Text = "Playback start, sound...";
                                labelEvtA.Text = "sound";
                                evtNameA.Items.AddRange(SoundNames); evtNameA.Enabled = true;

                                evtNameA.SelectedIndex = esc.EventData[2];
                                break;

                            // Memory
                            case 0xB6:
                                labelTitleA.Text = "Double mem...";
                                labelEvtC.Text = "address";
                                labelEvtD.Text = "doubles";
                                evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                                evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                                evtNumC.Enabled = true;
                                evtNumD.Maximum = 256; evtNumD.Minimum = 1; evtNumD.Enabled = true;

                                evtNumC.Value = (esc.EventData[2] * 2) + 0x7000;
                                evtNumD.Value = (esc.EventData[3] ^ 0xFF) + 1;
                                break;
                            case 0xB7:
                                labelTitleA.Text = "Generate random # < mem...";
                                labelEvtC.Text = "address";
                                evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                                evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                                evtNumC.Enabled = true;

                                evtNumC.Value = (esc.EventData[2] * 2) + 0x7000;
                                break;

                            // Memory 00:7000
                            case 0x58:
                                labelTitleA.Text = "Mem 00:7000 = quantity of item...";
                                labelEvtA.Text = "item";
                                evtNameA.Items.AddRange(universal.ItemNames.GetNames()); evtNameA.Enabled = true;
                                evtNumA.Maximum = 176; evtNumA.Enabled = true;

                                evtNumA.Value = esc.EventData[2];
                                evtNameA.SelectedIndex = universal.ItemNames.GetIndexFromNum((int)evtNumA.Value);
                                break;
                            case 0x5D:
                                labelTitleA.Text = "Mem 00:7000 = equipment of character...";
                                labelEvtA.Text = "character";
                                labelEvtB.Text = "item type";
                                evtNameA.Items.AddRange(CharacterNames); evtNameA.Enabled = true;
                                evtNameB.Items.AddRange(new string[] { "weapon", "armor", "accessory" });
                                evtNameB.Enabled = true;

                                evtNameA.SelectedIndex = esc.EventData[2];
                                evtNameB.SelectedIndex = esc.EventData[3];
                                break;
                            case 0xAC:
                                labelTitleA.Text = "Mem 00:7000 = mem 7F:...";
                                labelEvtC.Text = "address";
                                evtNumC.Hexadecimal = true;
                                evtNumC.Maximum = 0x7FFFFF; evtNumC.Minimum = 0x7FF800;
                                evtNumC.Enabled = true;

                                evtNumC.Value = BitManager.GetShort(esc.EventData, 2) + 0x7FF800;
                                break;
                            case 0xB0: labelTitleA.Text = "Mem 00:7000 isolate bits =..."; goto case 0xB2;
                            case 0xB1: labelTitleA.Text = "Mem 00:7000 set bits =..."; goto case 0xB2;
                            case 0xB2:
                                if (esc.Option == 0xB2) labelTitleA.Text = "Mem 00:7000 xor bits =...";
                                labelEvtC.Text = "bits";
                                evtNumC.Maximum = 65535; evtNumC.Enabled = true;

                                evtNumC.Value = BitManager.GetShort(esc.EventData, 2);
                                break;
                            case 0xB3: labelTitleA.Text = "Mem 00:7000 isolate bits = mem..."; goto case 0xB5;
                            case 0xB4: labelTitleA.Text = "Mem 00:7000 set bits = mem..."; goto case 0xB5;
                            case 0xB5:
                                if (esc.Option == 0xB5) labelTitleA.Text = "Mem 00:7000 xor bits = mem...";
                                labelEvtC.Text = "address";
                                evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                                evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                                evtNumC.Enabled = true;

                                evtNumC.Value = (esc.EventData[2] * 2) + 0x7000;
                                break;

                            default: break;
                        }
                    }
                    break;
            }

            updatingControls = true;
        }
        private void ControlEventAsmMethod()
        {
            switch (esc.Opcode)
            {
                // Objects
                case 0x32:         // If object present...
                case 0x39:
                    esc.Option = (byte)evtNameA.SelectedIndex;
                    BitManager.SetShort(esc.EventData, 2, (ushort)evtNumC.Value);
                    break;
                case 0x3A:         // If distance between object A and...
                case 0x3B:         // If distance (Z==) between object A and...
                    esc.Option = (byte)evtNameA.SelectedIndex;          // object A
                    esc.EventData[2] = (byte)evtNameB.SelectedIndex;    // object B
                    esc.EventData[3] = (byte)evtNumC.Value;
                    esc.EventData[4] = (byte)evtNumD.Value;
                    BitManager.SetShort(esc.EventData, 5, (ushort)evtNumE.Value);
                    break;
                case 0x3D:         // If Mario in air...
                    BitManager.SetShort(esc.EventData, 1, (ushort)evtNumE.Value);
                    break;
                case 0x3E:         // Create new NPC packet @ obj coords...
                    esc.EventData[2] = (byte)evtNameA.SelectedIndex;
                    esc.Option = (byte)evtNumC.Value;
                    BitManager.SetShort(esc.EventData, 3, (ushort)evtNumE.Value);
                    break;
                case 0x3F:         // Create new NPC packet...
                    esc.Option = (byte)evtNumC.Value;
                    BitManager.SetShort(esc.EventData, 2, (ushort)evtNumE.Value);
                    break;
                case 0x42:         // If Mario on top of an object...
                    BitManager.SetShort(esc.EventData, 1, (ushort)evtNumE.Value);
                    BitManager.SetShort(esc.EventData, 3, (ushort)evtNumF.Value);
                    break;
                case 0xF2:         // Set object presence...  
                case 0xF3:         // Set object engage type...
                case 0xF8:         // If object in level ..., presence =...
                    BitManager.SetShort(esc.EventData, 1, (ushort)evtNumA.Value);
                    esc.EventData[2] &= 1; esc.EventData[2] |= (byte)(evtNameB.SelectedIndex << 1);
                    BitManager.SetBit(esc.EventData, 2, 7, evtEffects.GetItemChecked(0));    // set bit 7 if true
                    if (esc.Opcode == 0xF8)
                        BitManager.SetShort(esc.EventData, 3, (ushort)evtNumE.Value);
                    /* 
                     * TODO
                     * synchronize evtNameA with evtNumA
                     */
                    break;

                // Joypad
                case 0x34:
                case 0x35:
                    for (int i = 0; i < 8; i++)
                        BitManager.SetBit(esc.EventData, 1, i, evtEffects.GetItemChecked(i)); // set bit if true
                    break;

                // Party Members
                case 0x36:
                    esc.Option = (byte)evtNameA.SelectedIndex;
                    BitManager.SetBit(esc.EventData, 1, 7, evtEffects.GetItemChecked(0));
                    break;
                case 0x54:
                    esc.Option = (byte)evtNameA.SelectedIndex;
                    esc.EventData[2] = (byte)evtNumB.Value;
                    break;
                /* 
                * TODO
                * synchronize evtNameB with evtNumB
                */
                case 0x56:
                    esc.Option = (byte)evtNameA.SelectedIndex;
                    break;

                // Inventory
                case 0x50:
                case 0x51:
                    esc.Option = (byte)evtNumA.Value;
                    break;
                /* 
                * TODO
                * synchronize evtNameA with evtNumA
                */
                case 0x52:
                case 0x53:
                    esc.Option = (byte)evtNumA.Value;
                    break;

                // Battle
                case 0x4A:
                    esc.Option = (byte)evtNumC.Value;
                    esc.EventData[3] = (byte)evtNumB.Value;
                    break;

                // Levels
                /* 
                 * TODO
                 * synchronize evtNameA with evtNumA for case 0x68,0x6A,0x6B
                 */
                case 0x4B:      // Open, world map point...
                    esc.Option = (byte)evtNameA.SelectedIndex;

                    BitManager.SetBit(esc.EventData, 2, 5, evtEffects.GetItemChecked(0));
                    BitManager.SetBit(esc.EventData, 2, 6, evtEffects.GetItemChecked(1));
                    BitManager.SetBit(esc.EventData, 2, 7, evtEffects.GetItemChecked(2));
                    break;
                case 0x68:
                    BitManager.SetShort(esc.EventData, 1, (ushort)evtNumA.Value);
                    esc.EventData[5] = (byte)evtNumB.Value;
                    esc.EventData[5] &= 0x1F; esc.EventData[5] |= (byte)(evtNameB.SelectedIndex << 5);
                    esc.EventData[3] = (byte)evtNumC.Value;
                    esc.EventData[4] = (byte)evtNumD.Value;
                    BitManager.SetBit(esc.EventData, 2, 3, evtEffects.GetItemChecked(0));
                    BitManager.SetBit(esc.EventData, 2, 7, evtEffects.GetItemChecked(1));
                    BitManager.SetBit(esc.EventData, 4, 7, evtEffects.GetItemChecked(2));
                    break;
                case 0x6A:
                case 0x6B:
                    BitManager.SetShort(esc.EventData, 1, (ushort)evtNumA.Value);
                    BitManager.SetBit(esc.EventData, 2, 7, evtEffects.GetItemChecked(0));
                    break;

                // Open window
                case 0x4C:      // Open, shop menu...
                    esc.Option = (byte)evtNumA.Value;
                    break;
                case 0x4F:      // Open, window...
                    esc.Option = (byte)evtNameA.SelectedIndex;
                    break;

                // Dialogue
                /* 
                 * TODO
                 * synchronize evtNameA with evtNumA for case 0x60 and 0x62
                 */
                case 0x60:
                    BitManager.SetShort(esc.EventData, 1, (ushort)evtNumA.Value);
                    esc.EventData[3] = (byte)evtNameB.SelectedIndex;
                    BitManager.SetBit(esc.EventData, 2, 5, evtEffects.GetItemChecked(0));
                    BitManager.SetBit(esc.EventData, 2, 7, evtEffects.GetItemChecked(1));
                    BitManager.SetBit(esc.EventData, 3, 6, evtEffects.GetItemChecked(2));
                    BitManager.SetBit(esc.EventData, 3, 7, evtEffects.GetItemChecked(3));
                    break;
                case 0x61:
                    esc.EventData[2] = (byte)evtNameA.SelectedIndex;
                    BitManager.SetBit(esc.EventData, 1, 5, evtEffects.GetItemChecked(0));
                    BitManager.SetBit(esc.EventData, 1, 7, evtEffects.GetItemChecked(1));
                    BitManager.SetBit(esc.EventData, 2, 6, evtEffects.GetItemChecked(2));
                    BitManager.SetBit(esc.EventData, 2, 7, evtEffects.GetItemChecked(3));
                    break;
                case 0x62:
                    BitManager.SetShort(esc.EventData, 1, (ushort)evtNumA.Value);
                    esc.EventData[2] &= 0x1F; esc.EventData[2] |= (byte)((byte)evtNumC.Value << 5);
                    BitManager.SetBit(esc.EventData, 2, 7, evtEffects.GetItemChecked(0));
                    break;
                case 0x63:
                    BitManager.SetBit(esc.EventData, 1, 5, evtEffects.GetItemChecked(0));
                    BitManager.SetBit(esc.EventData, 1, 7, evtEffects.GetItemChecked(1));
                    break;
                case 0x66:
                    BitManager.SetShort(esc.EventData, 1, (ushort)evtNumC.Value);
                    break;
                case 0x67:
                    BitManager.SetShort(esc.EventData, 1, (ushort)evtNumC.Value);
                    BitManager.SetShort(esc.EventData, 3, (ushort)evtNumD.Value);
                    break;

                // Events
                case 0x40:
                    BitManager.SetShort(esc.EventData, 1, (ushort)evtNumC.Value);
                    BitManager.SetBit(esc.EventData, 2, 5, evtEffects.GetItemChecked(0));
                    BitManager.SetBit(esc.EventData, 2, 6, evtEffects.GetItemChecked(1));
                    BitManager.SetBit(esc.EventData, 2, 7, evtEffects.GetItemChecked(2));
                    break;
                case 0xD0:
                case 0xD1:
                    BitManager.SetShort(esc.EventData, 1, (ushort)evtNumC.Value);
                    break;
                case 0x4E:
                    esc.Option = (byte)evtNameA.SelectedIndex;

                    switch (evtNameA.SelectedIndex)
                    {
                        case 2: // open world map point
                            esc.EventData[2] = (byte)evtNameB.SelectedIndex;
                            break;
                        case 3: // open shop menu
                            esc.EventData[2] = (byte)evtNumC.Value;
                            break;
                        case 5: // items maxed out
                            esc.EventData[2] = (byte)evtNumB.Value;
                            break;
                        case 7: // menu tutorial
                            esc.EventData[2] = (byte)evtNameB.SelectedIndex;
                            break;
                        case 16:    // world map event
                            esc.EventData[2] = (byte)evtNameB.SelectedIndex;
                            break;
                    }

                    /* 
                     * TODO
                     * in eventHandler set evtNumC maximum and labelEvtC text 
                     * based on selectedIndex in evtNameA
                     */
                    break;

                // Jump to
                case 0xD2:
                case 0xD3:
                    BitManager.SetShort(esc.EventData, 1, (ushort)evtNumC.Value);
                    break;
                case 0xD4:
                    esc.Option = (byte)evtNumC.Value;
                    break;

                // Screen effects
                case 0x72:
                case 0x73:
                case 0x76:
                case 0x77:
                    esc.Option = (byte)evtNumC.Value;
                    break;
                case 0x78:
                case 0x79:
                case 0x83:
                    if (esc.Opcode != 0x83)
                    {
                        esc.Option = (byte)evtNumC.Value;
                        esc.EventData[2] = (byte)evtNameA.SelectedIndex;
                    }
                    else
                        esc.Option = (byte)evtNameA.SelectedIndex;
                    break;
                case 0x80:
                    ushort color;
                    int r, g, b;
                    r = (int)(evtNumB.Value / 8);
                    g = (int)(evtNumC.Value / 8);
                    b = (int)(evtNumD.Value / 8);
                    color = (ushort)((b << 10) | (g << 5) | r);
                    BitManager.SetShort(esc.EventData, 1, color);

                    esc.EventData[4] = (byte)evtNumA.Value;
                    for (int i = 0; i < 8; i++)
                        BitManager.SetBit(esc.EventData, 3, i, evtEffects.GetItemChecked(i));
                    break;
                case 0x81:
                    BitManager.SetBit(esc.EventData, 1, 0, evtEffects.GetItemChecked(0));
                    BitManager.SetBit(esc.EventData, 1, 1, evtEffects.GetItemChecked(1));
                    BitManager.SetBit(esc.EventData, 1, 2, evtEffects.GetItemChecked(2));
                    BitManager.SetBit(esc.EventData, 1, 4, evtEffects.GetItemChecked(3));
                    BitManager.SetBit(esc.EventData, 2, 0, evtEffects.GetItemChecked(4));
                    BitManager.SetBit(esc.EventData, 2, 1, evtEffects.GetItemChecked(5));
                    BitManager.SetBit(esc.EventData, 2, 2, evtEffects.GetItemChecked(6));
                    BitManager.SetBit(esc.EventData, 2, 4, evtEffects.GetItemChecked(7));
                    BitManager.SetBit(esc.EventData, 3, 0, evtEffects.GetItemChecked(8));
                    BitManager.SetBit(esc.EventData, 3, 1, evtEffects.GetItemChecked(9));
                    BitManager.SetBit(esc.EventData, 3, 2, evtEffects.GetItemChecked(10));
                    BitManager.SetBit(esc.EventData, 3, 4, evtEffects.GetItemChecked(11));
                    BitManager.SetBit(esc.EventData, 3, 5, evtEffects.GetItemChecked(12));
                    BitManager.SetBit(esc.EventData, 3, 6, evtEffects.GetItemChecked(13));
                    BitManager.SetBit(esc.EventData, 3, 7, evtEffects.GetItemChecked(14));
                    /*
                    * TODO
                    * set evtEffects according to evtNameA.SelectedIndex
                    */
                    break;
                case 0x84:
                    esc.Option = (byte)((byte)evtNumC.Value << 4);
                    esc.EventData[2] = (byte)evtNumD.Value;
                    for (int i = 0; i < 4; i++)
                        BitManager.SetBit(esc.EventData, 1, i, evtEffects.GetItemChecked(i));
                    break;
                case 0x89:
                    switch (evtNameA.SelectedIndex)
                    {
                        case 1: esc.Option = 0x60; break;
                        case 2: esc.Option = 0xC0; break;
                        case 3: esc.Option = 0xE0; break;
                        default: esc.Option = 0x00; break;
                    }
                    esc.Option &= 0xF0; esc.Option |= (byte)evtNumB.Value;
                    esc.EventData[3] = (byte)evtNumC.Value;
                    esc.EventData[2] = (byte)evtNumD.Value;
                    break;
                case 0x8A:
                    esc.EventData[2] = (byte)evtNumC.Value;
                    esc.Option = (byte)(((byte)evtNumD.Value << 4) - 1);
                    break;
                case 0x8F:
                    esc.Option = (byte)evtNameA.SelectedIndex;
                    esc.EventData[2] = (byte)evtNumC.Value;
                    esc.EventData[3] = (byte)evtNumD.Value;
                    break;

                // Playback audio
                case 0x90:
                case 0x91:
                case 0x92:
                    esc.Option = (byte)evtNameA.SelectedIndex;
                    break;
                case 0x95:
                    esc.Option = (byte)evtNumC.Value;
                    esc.EventData[2] = (byte)evtNumD.Value;
                    break;
                case 0x97:
                    if (evtNameA.SelectedIndex == 1)
                    {
                        if (evtNumC.Value > 0)
                            esc.EventData[2] = (byte)(0x100 - evtNumC.Value);
                        else esc.EventData[2] = 0;
                    }
                    else
                        esc.EventData[2] = (byte)evtNumC.Value;

                    esc.Option = (byte)evtNumD.Value;
                    /*
                     * TODO
                     * set labelEvtC text and evtNumC value based on what change type is
                     * if slow down, set max to 160, else set max to 94
                     * if speed up, set value = (0x100 - esc.EventData[2]) - 1
                     */
                    break;
                case 0x98:
                    BitManager.SetBit(esc.EventData, 2, 7, evtNameA.SelectedIndex == 1);
                    esc.Option = (byte)evtNumC.Value;
                    break;
                case 0x9C:
                    esc.Option = (byte)evtNameA.SelectedIndex;
                    break;
                case 0x9D:
                    esc.Option = (byte)evtNameA.SelectedIndex;
                    esc.EventData[2] = (byte)evtNumC.Value;
                    break;
                case 0x9E:
                    esc.Option = (byte)evtNumC.Value;
                    esc.EventData[2] = (byte)evtNumD.Value;
                    break;

                // Memory
                case 0xA0:
                case 0xA1:
                case 0xA2:
                    esc.Opcode = (byte)(((((byte)(evtNumC.Value - 0x7040) << 3) & 0x0F00) >> 8) + 0xA0);
                    esc.Option = (byte)(((byte)(evtNumC.Value - 0x7040) << 3) & 0xF8);
                    esc.Option &= 0xF8; esc.Option |= (byte)evtNumD.Value;
                    break;
                case 0xA4:
                case 0xA5:
                case 0xA6:
                    esc.Opcode = (byte)(((((byte)(evtNumC.Value - 0x7040) << 3) & 0x0F00) >> 8) + 0xA4);
                    esc.Option = (byte)(((byte)(evtNumC.Value - 0x7040) << 3) & 0xF8);
                    esc.Option &= 0xF8; esc.Option |= (byte)evtNumD.Value;
                    break;
                case 0xA8:
                case 0xA9:
                    esc.Option = (byte)(evtNumC.Value - 0x70A0);
                    esc.EventData[2] = (byte)evtNumD.Value;
                    break;
                case 0xAA:
                case 0xAB:
                    esc.Option = (byte)(evtNumC.Value - 0x70A0);
                    break;
                case 0xB0:
                case 0xB1:
                case 0xC2:
                    esc.Option = (byte)((evtNumC.Value - 0x7000) / 2);
                    BitManager.SetShort(esc.EventData, 2, (ushort)evtNumD.Value);
                    break;
                case 0xB2:
                case 0xB3:
                case 0xD6:
                case 0xBB:
                    esc.Option = (byte)((evtNumC.Value - 0x7000) / 2);
                    break;
                case 0xB5:
                    esc.Option = (byte)(evtNumC.Value - 0x70A0);
                    break;
                case 0xB7:
                    esc.Option = (byte)((evtNumC.Value - 0x7000) / 2);
                    BitManager.SetShort(esc.EventData, 2, (ushort)evtNumD.Value);
                    break;
                case 0xBC:
                case 0xBD:
                    esc.Option = (byte)((evtNumC.Value - 0x7000) / 2);
                    esc.EventData[2] = (byte)((evtNumD.Value - 0x7000) / 2);
                    break;
                case 0xD8:
                case 0xD9:
                case 0xDA:
                    esc.Opcode = (byte)(((((byte)(evtNumC.Value - 0x7040) << 3) & 0x0F00) >> 8) + 0xD8);
                    esc.Option = (byte)(((byte)(evtNumC.Value - 0x7040) << 3) & 0xF8);
                    esc.Option &= 0xF8; esc.Option |= (byte)evtNumD.Value;
                    BitManager.SetShort(esc.EventData, 2, (ushort)evtNumE.Value);
                    break;
                case 0xDC:
                case 0xDD:
                case 0xDE:
                    esc.Opcode = (byte)(((((byte)(evtNumC.Value - 0x7040) << 3) & 0x0F00) >> 8) + 0xDC);
                    esc.Option = (byte)(((byte)(evtNumC.Value - 0x7040) << 3) & 0xF8);
                    esc.Option &= 0xF8; esc.Option |= (byte)evtNumD.Value;
                    BitManager.SetShort(esc.EventData, 2, (ushort)evtNumE.Value);
                    break;
                case 0xE0:
                case 0xE1:
                    esc.Option = (byte)(evtNumC.Value - 0x70A0);
                    esc.EventData[2] = (byte)evtNumD.Value;
                    BitManager.SetShort(esc.EventData, 3, (ushort)evtNumE.Value);
                    break;
                case 0xE4:
                case 0xE5:
                    esc.Option = (byte)((evtNumC.Value - 0x7000) / 2);
                    BitManager.SetShort(esc.EventData, 2, (ushort)evtNumD.Value);
                    BitManager.SetShort(esc.EventData, 4, (ushort)evtNumE.Value);
                    break;
                case 0xE8:
                    BitManager.SetShort(esc.EventData, 1, (ushort)evtNumC.Value);
                    break;
                case 0xE9:
                    BitManager.SetShort(esc.EventData, 1, (ushort)evtNumC.Value);
                    BitManager.SetShort(esc.EventData, 3, (ushort)evtNumD.Value);
                    break;

                // Memory 00:7000
                case 0x38:
                    if (esc.Option < 8) esc.Option = 8;
                    esc.Option = (byte)(evtNumC.Value + 8);
                    break;
                case 0xAC:
                case 0xAD:
                case 0xB6:
                case 0xC0:
                    BitManager.SetShort(esc.EventData, 1, (ushort)evtNumC.Value);
                    break;
                case 0xB4:
                    esc.Option = (byte)(evtNumC.Value - 0x70A0);
                    break;
                case 0xB8:
                case 0xB9:
                case 0xBA:
                case 0xC1:
                    esc.Option = (byte)((evtNumC.Value - 0x7000) / 2);
                    break;
                case 0xC4:
                case 0xC5:
                case 0xC6:
                    esc.Option = (byte)evtNameA.SelectedIndex;
                    BitManager.SetBit(esc.EventData, 1, 7, evtEffects.GetItemChecked(0));
                    break;
                case 0xDB:
                case 0xDF:
                    BitManager.SetShort(esc.EventData, 1, (ushort)evtNumC.Value);
                    break;
                case 0xE2:
                case 0xE3:
                case 0xE6:
                case 0xE7:
                    BitManager.SetShort(esc.EventData, 1, (ushort)evtNumC.Value);
                    BitManager.SetShort(esc.EventData, 3, (ushort)evtNumD.Value);
                    break;
                case 0xEA:
                case 0xEB:
                case 0xEC:
                case 0xED:
                case 0xEE:
                case 0xEF:
                    BitManager.SetShort(esc.EventData, 1, (ushort)evtNumC.Value);
                    break;

                // Pause script
                case 0xF0:
                    esc.Option = (byte)evtNumC.Value;
                    break;
                case 0xF1:
                    BitManager.SetShort(esc.EventData, 1, (ushort)evtNumC.Value);
                    break;

                default:
                    // Action Queue (same for all sub-indexes, so no need to do a switch for sub)
                    if (esc.Opcode <= 0x2F)
                    {
                        byte temp = esc.Opcode;
                        switch (evtNameB.SelectedIndex)
                        {
                            case 0:
                                esc.Opcode = (byte)evtNameA.SelectedIndex;
                                BitManager.SetBit(esc.EventData, 1, 7, evtEffects.GetItemChecked(0));
                                break;
                            case 1:
                            case 2:
                                esc.EventData = new byte[3];
                                esc.Opcode = (byte)evtNameA.SelectedIndex;
                                esc.Option = (byte)(evtNameB.SelectedIndex + 0xEF);
                                BitManager.SetBit(esc.EventData, 2, 7, evtEffects.GetItemChecked(0));
                                break;
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                                esc.EventData = new byte[4];
                                esc.Opcode = (byte)evtNameA.SelectedIndex;
                                esc.Option = (byte)(evtNameB.SelectedIndex + 0xEF);
                                BitManager.SetShort(esc.EventData, 2, (ushort)evtNumC.Value);
                                break;
                            default:
                                esc.Opcode = (byte)evtNameA.SelectedIndex;
                                esc.Option = (byte)(evtNameB.SelectedIndex + 0xEF);
                                break;
                        }

                        /*
                         * TODO
                         * set evtNumC value and labelEvtC text according to evtNameB.SelectedIndex
                         */
                    }
                    else if (esc.Opcode == 0xFD)
                    {
                        switch (esc.Option)
                        {
                            // Objects
                            case 0x33:
                            case 0x34:
                            case 0x3D:         // If in air, object...
                                esc.EventData[2] = (byte)evtNameA.SelectedIndex;
                                BitManager.SetShort(esc.EventData, 3, (ushort)evtNumC.Value);
                                break;
                            case 0x3E:
                                esc.EventData[2] = (byte)evtNumC.Value;
                                BitManager.SetShort(esc.EventData, 3, (ushort)evtNumD.Value);
                                BitManager.SetShort(esc.EventData, 5, (ushort)evtNumE.Value);
                                break;

                            // Menus
                            case 0x4C:
                                esc.EventData[2] = (byte)evtNumC.Value;
                                break;

                            // Run event
                            case 0x4D:
                                esc.EventData[2] = (byte)evtNumC.Value;
                                break;
                            case 0x66:
                                esc.EventData[3] = (byte)evtNameA.SelectedIndex;
                                esc.EventData[2] = (byte)evtNumC.Value;
                                break;

                            // Playback audio
                            case 0x9C:
                                esc.EventData[2] = (byte)evtNameA.SelectedIndex;
                                break;

                            // Memory
                            case 0xB6:
                                esc.EventData[2] = (byte)((evtNumC.Value - 0x7000) / 2);
                                esc.EventData[3] = (byte)((byte)(evtNumD.Value - 1) ^ 0xFF);
                                break;
                            case 0xB7:
                                esc.EventData[2] = (byte)((evtNumC.Value - 0x7000) / 2);
                                break;

                            // Memory 00:7000
                            case 0x58:
                                esc.EventData[2] = (byte)evtNumA.Value;
                                break;
                            case 0x5D:
                                esc.EventData[2] = (byte)evtNameA.SelectedIndex;
                                esc.EventData[3] = (byte)evtNameB.SelectedIndex;
                                break;
                            case 0xAC:
                                BitManager.SetShort(esc.EventData, 2, (ushort)(evtNumC.Value - 0x7FF800));
                                break;
                            case 0xB0:
                            case 0xB1:
                            case 0xB2:
                                BitManager.SetShort(esc.EventData, 2, (ushort)evtNumC.Value);
                                break;
                            case 0xB3:
                            case 0xB4:
                            case 0xB5:
                                esc.EventData[2] = (byte)((evtNumC.Value - 0x7000) / 2);
                                break;

                            default: break;
                        }
                    }
                    break;
            }
        }

        private string[] LevelNames()
        {
            string[] names;
            System.Collections.Specialized.StringCollection levelNames = settings.LevelNames;
            names = new string[levelNames.Count];

            for (int i = 0; i < levelNames.Count; i++)
            {
                names[i] = "[" + i.ToString("d3") + "]  " + levelNames[i];
            }
            return names;
        }
        private string[] DialogueNames()
        {
            String[] names = new String[universal.Dialogues.Length];

            for (int i = 0; i < universal.Dialogues.Length; i++)
                names[i] = universal.Dialogues[i].GetDialogueStub(true);

            return names;
        }

        private void EditCommand(EventScriptCommand dest, bool insert)
        {

        }
        private void EditCommand(ActionQueueCommand dest, bool insert)
        {

        }
        private void UpdateEditorMask()
        {

        }
        public void UpdateScriptOffsets()
        {
            int delta = treeViewWrapper.ScriptDelta;
            int eventNum = treeViewWrapper.Script.EventNum;
            int end, start;
            int conditionOffset = 0;

            if (eventNum >= 0 && eventNum <= 1535)
            {
                start = 0;
                end = 1535; // Bank 1E

                if (eventNum < end)
                    conditionOffset = eventScripts[eventNum + 1].BaseOffset;
                else
                    conditionOffset = eventScripts[eventNum].BaseOffset + eventScripts[eventNum].ScriptLength; // Dont need to update anything after this event if its the last one                    
            }
            else if (eventNum >= 1536 && eventNum <= 3071)
            {
                start = 1536;
                end = 3071; // Bank 1F

                if (eventNum < end)
                    conditionOffset = eventScripts[eventNum + 1].BaseOffset;
                else
                    conditionOffset = eventScripts[eventNum].BaseOffset + eventScripts[eventNum].ScriptLength; // Dont need to update anything after this event if its the last one
            }
            else if (eventNum >= 3072 && eventNum <= 4095)
            {
                start = 3072;
                end = 4095; // Bank 20

                if (eventNum < end)
                    conditionOffset = eventScripts[eventNum + 1].BaseOffset;
                else
                    conditionOffset = eventScripts[eventNum].BaseOffset + eventScripts[eventNum].ScriptLength; // Dont need to update anything after this event if its the last one
            }
            else
                throw new Exception("Invalid event num");

            if (!state.AutoPointerUpdate)
                conditionOffset = 0x7FFFFFFF;

            if (state.AutoPointerUpdate)
            {
                // Update all pointers before eventOffset
                for (int i = start; i < eventNum; i++)
                    eventScripts[i].UpdateAllOffsets(delta, conditionOffset);
            }

            // Update all events and pointers after edited event
            for (int i = eventNum + 1; i <= end; i++)
                eventScripts[i].UpdateAllOffsets(delta, conditionOffset);

            if (state.AutoPointerUpdate)
            {
                // Update all pointers to edited event
                UpdateCurrentScriptReferencePointers();
            }
            treeViewWrapper.ScriptDelta = 0;
        }
        private void UpdateCurrentScriptReferencePointers()
        {

            EventScript es = treeViewWrapper.Script;

            foreach (EventScriptCommand esc in es.Commands)
            {
                if (esc.IsActionQueueTrigger && esc.EmbeddedActionQueue.ActionQueueCommands != null)
                {
                    foreach (ActionQueueCommand aqc in esc.EmbeddedActionQueue.ActionQueueCommands)
                    {
                        if (aqc.CommandDelta != 0)
                            UpdatePointersToCommand(aqc);
                    }
                }
                else
                {
                    if (esc.CommandDelta != 0)
                        UpdatePointersToCommand(esc);
                }
            }
        }
        private void UpdatePointersToCommand(ActionQueueCommand aqcRef)
        {
            ushort pointer;

            foreach (EventScript es in eventScripts)
            {
                /* 12-31-08
                 * UpdateInternalPointers() in TreeViewWrapper.cs already does this
                 * for the current event script; doing it again for the current script
                 * would screw up the pointers in the current script
                 * thus, the following conditional is needed
                 */
                if (es.EventNum != treeViewWrapper.Script.EventNum)
                {
                    foreach (EventScriptCommand escIterator in es.Commands)
                    {
                        if (escIterator.IsActionQueueTrigger && escIterator.EmbeddedActionQueue.ActionQueueCommands != null)
                        {
                            foreach (ActionQueueCommand aqcIterator in escIterator.EmbeddedActionQueue.ActionQueueCommands)
                            {
                                if (aqcIterator.Opcode == 0xE9)
                                {
                                    pointer = aqcIterator.ReadPointerSpecial(0);
                                    if (pointer == (aqcRef.OriginalOffset & 0xFFFF))
                                    {
                                        aqcIterator.WritePointerSpecial(0, (ushort)(pointer + aqcRef.CommandDelta));
                                    }
                                    pointer = aqcIterator.ReadPointerSpecial(1);
                                    if (pointer == (aqcRef.OriginalOffset & 0xFFFF))
                                    {
                                        aqcIterator.WritePointerSpecial(1, (ushort)(pointer + aqcRef.CommandDelta));
                                    }
                                }
                                else
                                {
                                    pointer = aqcIterator.ReadPointer();
                                    if (pointer == (aqcRef.OriginalOffset & 0xFFFF))
                                    {
                                        aqcIterator.WritePointer((ushort)(pointer + aqcRef.CommandDelta));
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (escIterator.Opcode == 0x42 || escIterator.Opcode == 0xE9 || escIterator.Opcode == 0x67)
                            {
                                pointer = escIterator.ReadPointerSpecial(0);
                                if (pointer == (aqcRef.OriginalOffset & 0xFFFF))
                                {
                                    escIterator.WritePointerSpecial(0, (ushort)(pointer + aqcRef.CommandDelta));
                                }
                                pointer = escIterator.ReadPointerSpecial(1);
                                if (pointer == (aqcRef.OriginalOffset & 0xFFFF))
                                {
                                    escIterator.WritePointerSpecial(1, (ushort)(pointer + aqcRef.CommandDelta));
                                }
                            }
                            else
                            {
                                pointer = escIterator.ReadPointer();
                                if (pointer == (aqcRef.OriginalOffset & 0xFFFF))
                                {
                                    escIterator.WritePointer((ushort)(pointer + aqcRef.CommandDelta));
                                }
                            }
                        }
                    }
                }
            }
        }
        private void UpdatePointersToCommand(EventScriptCommand escRef)
        {
            ushort pointer;
            foreach (EventScript es in eventScripts)
            {
                if (es.EventNum != treeViewWrapper.Script.EventNum)
                {
                    foreach (EventScriptCommand escIterator in es.Commands)
                    {
                        if (escIterator.IsActionQueueTrigger && escIterator.EmbeddedActionQueue.ActionQueueCommands != null)
                        {
                            foreach (ActionQueueCommand aqcIterator in escIterator.EmbeddedActionQueue.ActionQueueCommands)
                            {
                                if (aqcIterator.Opcode == 0xE9)
                                {
                                    pointer = aqcIterator.ReadPointerSpecial(0);
                                    if (pointer == (escRef.OriginalOffset & 0xFFFF))
                                    {
                                        aqcIterator.WritePointerSpecial(0, (ushort)(pointer + escRef.CommandDelta));
                                    }
                                    pointer = aqcIterator.ReadPointerSpecial(1);
                                    if (pointer == (escRef.OriginalOffset & 0xFFFF))
                                    {
                                        aqcIterator.WritePointerSpecial(1, (ushort)(pointer + escRef.CommandDelta));
                                    }
                                }
                                else
                                {
                                    pointer = aqcIterator.ReadPointer();
                                    if (pointer == (escRef.OriginalOffset & 0xFFFF))
                                    {
                                        aqcIterator.WritePointer((ushort)(pointer + escRef.CommandDelta));
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (escIterator.Opcode == 0x42 || escIterator.Opcode == 0xE9 || escIterator.Opcode == 0x67)
                            {
                                pointer = escIterator.ReadPointerSpecial(0);
                                if (pointer == (escRef.OriginalOffset & 0xFFFF))
                                {
                                    escIterator.WritePointerSpecial(0, (ushort)(pointer + escRef.CommandDelta));
                                }
                                pointer = escIterator.ReadPointerSpecial(1);
                                if (pointer == (escRef.OriginalOffset & 0xFFFF))
                                {
                                    escIterator.WritePointerSpecial(1, (ushort)(pointer + escRef.CommandDelta));
                                }
                            }
                            else
                            {
                                pointer = escIterator.ReadPointer();
                                if (pointer == (escRef.OriginalOffset & 0xFFFF))
                                {
                                    escIterator.WritePointer((ushort)(pointer + escRef.CommandDelta));
                                }
                            }
                        }
                    }
                }
            }
        }

        private void PreviewEventOrAction()
        {
            Previewer.Previewer ep = new Previewer.Previewer(model, this.currentScript, this.eventName.SelectedIndex == 0 ? 0 : 2);
            ep.Show();
        }
        private void PreviewBattle()
        {
            Previewer.Previewer bp = new Previewer.Previewer(model, (int)this.monsterNumber.Value, 3);
            bp.Show();
        }

        private void UpdateEventScriptsFreeSpace()
        {
            this.EvtScrLabel9.Text = "AVAILABLE BYTES: " + CalculateEventScriptsLength().ToString();
        }
        private int CalculateEventScriptsLength()
        {
            int totalSize;
            int length = 0;
            int min;
            int max;

            if (currentScript < 0x600)
            {
                totalSize = 0x10000 - 0xC00;
                min = 0; max = 0x600;
            }
            else if (currentScript < 0xC00)
            {
                totalSize = 0x10000 - 0xC00;
                min = 0x600; max = 0xC00;
            }
            else
            {
                totalSize = 0xE000 - 0x800;
                min = 0xC00; max = 0x1000;
            }

            for (int i = min; i < max; i++)
                length += eventScripts[i].Script.Length;

            return totalSize - length - 1;
        }

        /// <summary>
        /// Get the exact index of the node based on all child nodes in the TreeView.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="nodes"></param>
        /// <returns></returns>
        private void InsertEventCommand()
        {
            byte[] temp;
            int opcode;
            int option;

            opcode = eventListBoxOpcodes[cpuCommands.SelectedIndex][cpuExtendedCommands.SelectedIndex];
            option = eventListBoxFDOpcodes[cpuCommands.SelectedIndex][cpuExtendedCommands.SelectedIndex];

            temp = new byte[ScriptEnums.GetEventOpcodeLength(opcode, option)];
            temp[0] = (byte)opcode;
            if (temp.Length > 1)
                temp[1] = (byte)option;
            esc = new EventScriptCommand(temp, 0);

            ControlEventAsmMethod();
            treeViewWrapper.InsertNode(esc);
        }
        private void InsertActionCommand()
        {
            byte[] temp;
            int opcode;
            int option;

            opcode = actionListBoxOpcodes[actionQueueCommands.SelectedIndex][actionQueueExtendedCommands.SelectedIndex];
            option = actionListBoxFDOpcodes[actionQueueCommands.SelectedIndex][actionQueueExtendedCommands.SelectedIndex];

            temp = new byte[ScriptEnums.GetActionQueueOpcodeLength(opcode, option)];
            temp[0] = (byte)opcode;
            if (temp.Length > 1)
                temp[1] = (byte)option;
            aqc = new ActionQueueCommand(temp, 0);

            ControlActionAsmMethod();
            treeViewWrapper.InsertNode(aqc);
        }

        private void LoadLabelSearch()
        {
            listBoxLabels.BeginUpdate();
            listBoxLabels.Nodes.Clear();

            TreeNode item;
            for (int i = 0; i < (actionScript ? settings.ActionLabels.Count : settings.EventLabels.Count); i++)
            {
                if (actionScript)
                {
                    if (Contains(settings.ActionLabels[i].ToString(), nameTextBox.Text, StringComparison.CurrentCultureIgnoreCase))
                    {
                        item = new TreeNode("Action #" + i.ToString() + " - " + settings.ActionLabels[i]); item.Tag = i;
                        listBoxLabels.Nodes.Add(item);
                    }
                }
                else
                {
                    if (Contains(settings.EventLabels[i].ToString(), nameTextBox.Text, StringComparison.CurrentCultureIgnoreCase))
                    {
                        item = new TreeNode("Event #" + i.ToString() + " - " + settings.EventLabels[i]); item.Tag = i;
                        listBoxLabels.Nodes.Add(item);
                    }
                }
            }
            listBoxLabels.EndUpdate();
        }

        public static bool Contains(string original, string value, StringComparison comparisionType)
        {
            return original.IndexOf(value, comparisionType) >= 0;
        }
        private int GetFullNodeIndex(TreeNode node, TreeNodeCollection nodes)
        {
            int index = 0;
            if (node == null)
                return index;
            foreach (TreeNode tn in nodes)
            {
                if (tn == node)
                    return index;
                index++;
                foreach (TreeNode child in tn.Nodes)
                {
                    if (child == node)
                        return index;
                    index++;
                    foreach (TreeNode chld in child.Nodes)
                    {
                        if (chld == node)
                            return index;
                        index++;
                    }
                }
            }
            return index;
        }

        private void ResetAllEventLists()
        {
            ResetAllEventControls();
            buttonInsertEvent.Enabled = false;
            buttonApplyEvent.Enabled = false;
            if (eventName.SelectedIndex == 1)   // Action Scripts
            {
                EventNumber.Maximum = 1023;
                cpuCommands.Enabled = false;
                cpuExtendedCommands.Items.Clear(); cpuExtendedCommands.Enabled = false;
                actionQueueCommands.Enabled = true;
                actionQueueExtendedCommands.Items.Clear(); actionQueueExtendedCommands.ClearSelected(); actionQueueExtendedCommands.Enabled = true;
                actionScript = true;
                treeViewWrapper.ActionScript = true;
            }
            else    // Event Scripts
            {
                EventNumber.Maximum = 4095;
                cpuCommands.Enabled = true;
                cpuExtendedCommands.Items.Clear(); cpuExtendedCommands.Enabled = true;
                actionQueueCommands.Enabled = false;
                actionQueueExtendedCommands.Items.Clear(); actionQueueExtendedCommands.ClearSelected(); actionQueueExtendedCommands.Enabled = false;
                actionScript = false;
                treeViewWrapper.ActionScript = false;
            }
        }
        private void ResetAllEventControls()
        {
            updatingControls = false;

            evtNameA.Items.Clear(); evtNameA.ResetText(); evtNameA.Enabled = false;
            evtNameB.Items.Clear(); evtNameB.ResetText(); evtNameB.Enabled = false;
            evtNumA.Maximum = 255; evtNumA.Hexadecimal = false; evtNumA.Value = 0; evtNumA.Enabled = false;
            evtNumB.Maximum = 255; evtNumB.Hexadecimal = false; evtNumB.Value = 0; evtNumB.Enabled = false;
            evtNumC.Maximum = 255; evtNumC.Hexadecimal = false; evtNumC.Minimum = 0; evtNumC.Increment = 1; evtNumC.Value = 0; evtNumC.Enabled = false;
            evtNumD.Maximum = 255; evtNumD.Hexadecimal = false; evtNumD.Minimum = 0; evtNumD.Increment = 1; evtNumD.Value = 0; evtNumD.Enabled = false;
            evtNumE.Maximum = 255; evtNumE.Hexadecimal = false; evtNumE.Value = 0; evtNumE.Enabled = false;
            evtNumF.Maximum = 255; evtNumF.Value = 0; evtNumF.Enabled = false;
            evtEffects.ColumnWidth = 138; evtEffects.Items.Clear(); evtEffects.Enabled = false;

            labelTitleA.Text = "";
            labelTitleC.Text = "";
            labelTitleB.Text = "";
            labelEvtA.Text = "";
            labelEvtB.Text = "";
            labelEvtC.Text = "";
            labelEvtD.Text = "";
            labelEvtE.Text = "";
            labelEvtF.Text = "";

            updatingControls = true;
        }

        #endregion

        #region Event Handlers
        private void EventNumber_ValueChanged(object sender, EventArgs e)
        {
            if (!updatingScript) return;

            if (actionScript)
            {
                foreach (ActionQueueCommand aq in actionScripts[currentScript].ActionQueueCommands)
                    aq.Set = false;
            }
            else
            {
                foreach (EventScriptCommand es in eventScripts[currentScript].Commands)
                {
                    es.Set = false;
                    if (es.EmbeddedActionQueue == null) continue;
                    foreach (ActionQueueCommand aq in es.EmbeddedActionQueue.ActionQueueCommands)
                        aq.Set = false;
                }
            }
            
            // Update Event Script Offsets
            currentScript = (int)this.EventNumber.Value;

            ResetAllEventLists();
            if (actionScript)
            {
                UpdateActionOffsets();
                treeViewWrapper.ChangeScript(actionScripts[(int)this.EventNumber.Value]);
            }
            else
            {
                UpdateScriptOffsets();
                treeViewWrapper.ChangeScript(eventScripts[(int)this.EventNumber.Value]);
            }

            UpdateCommandData();

            if (actionScript)
                return;

            switch (currentScript)
            {
                case 0x1D6:
                case 0x72D:
                case 0x72F:
                case 0xD01:
                case 0xE91:
                    panel11.Enabled = false;
                    cpuCommands.Enabled = false;
                    cpuExtendedCommands.Enabled = false;
                    actionQueueCommands.Enabled = false;
                    actionQueueExtendedCommands.Enabled = false;
                    MessageBox.Show(
                        "Editing of script #" + currentScript.ToString() + " is not allowed due to parsing issues.",
                        "LAZY SHELL",
                        MessageBoxButtons.OK);
                    break;
                default:
                    panel11.Enabled = true;
                    break;
            }
            if (!actionScript)
                eventLabel.Text = settings.EventLabels[currentScript];
            else
                eventLabel.Text = settings.ActionLabels[currentScript];
        }
        private void eventName_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatingScript = false;

            EventNumber.Value = currentScript = 0;

            if (!actionScript)
                UpdateScriptOffsets();
            else
                UpdateActionOffsets();

            ResetAllEventLists();

            if (actionScript)
                treeViewWrapper.ChangeScript(actionScripts[(int)this.EventNumber.Value]);
            else
                treeViewWrapper.ChangeScript(eventScripts[(int)this.EventNumber.Value]);

            UpdateCommandData();

            if (!actionScript)
                eventLabel.Text = settings.EventLabels[currentScript];
            else
                eventLabel.Text = settings.ActionLabels[currentScript];

            updatingScript = true;
        }
        private void addThisToNotesDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int type = 0;
            int index = 0;
            string label = "";
            string description = "";

            if (contextMenuStrip1.SourceControl.Name == "EventNumber" &&
                eventName.SelectedIndex == 0)
            {
                type = 4;
                index = (int)EventNumber.Value;
                label = description = settings.EventLabels[(int)EventNumber.Value];
            }
            if (contextMenuStrip1.SourceControl.Name == "EventNumber" &&
                eventName.SelectedIndex == 1)
            {
                type = 5;
                index = (int)EventNumber.Value;
                label = description = "ACTION #" + ((int)EventNumber.Value).ToString("d4");
            }
            if (contextMenuStrip1.SourceControl.Name == "monsterNumber")
            {
                type = 6;
                index = (int)monsterNumber.Value;
                label = description = monsterName.Text;
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

        private void EventScriptTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!updatingScript) return;

            if (!panel11.Enabled)
                return;

            // Select New
            UpdateCommandData();

            EventScriptCommand tempEsc;

            // if selecting an action queue/script command
            if (EventScriptTree.SelectedNode.Parent != null || actionScript)
            {
                cpuCommands.Enabled = false;
                cpuExtendedCommands.Enabled = false;
                actionQueueCommands.Enabled = true;
                actionQueueExtendedCommands.Enabled = true;
                if (aqc == null && editedNode == null)    // if an event command is in the COMMAND PROPERTIES panel
                {
                    ResetAllEventControls();
                    buttonInsertEvent.Enabled = false;
                }
            }
            // if selecting an event script command
            else
            {
                tempEsc = (EventScriptCommand)eventScripts[currentScript].Commands[EventScriptTree.SelectedNode.Index];
                if (tempEsc.Opcode <= 0x2F && tempEsc.Option < 0xF2)
                {
                    cpuCommands.Enabled = true;
                    cpuExtendedCommands.Enabled = true;
                    actionQueueCommands.Enabled = true;
                    actionQueueExtendedCommands.Enabled = true;
                }
                else
                {
                    cpuCommands.Enabled = true;
                    cpuExtendedCommands.Enabled = true;
                    actionQueueCommands.Enabled = false;
                    actionQueueExtendedCommands.Enabled = false;
                }
                if (aqc != null && editedNode == null)    // if an action queue command is in the COMMAND PROPERTIES panel
                {
                    ResetAllEventControls();
                    buttonInsertEvent.Enabled = false;
                }
            }

            treeViewWrapper.SelectedNode = EventScriptTree.SelectedNode;
        }
        private void EventScriptTree_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!panel11.Enabled)
                return;

            // Edit Event/ActionQueue
            EvtScrEditCommand_Click(null, null);
        }
        private void EventScriptTree_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
        }
        private void EventScriptTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            EventScriptTree.SelectedNode = e.Node;
            if (e.Button == MouseButtons.Right)
            {
                if (EventScriptTree.SelectedNode.Tag.GetType() == typeof(EventScriptCommand))
                {
                    EventScriptCommand temp = (EventScriptCommand)EventScriptTree.SelectedNode.Tag;
                    if (temp.Opcode == 0x60 || temp.Opcode == 0x62)
                    {
                        e.Node.ContextMenuStrip = contextMenuStripGoto;
                        goToToolStripMenuItem.Text = "Edit dialogue...";
                        goToToolStripMenuItem.Click += new EventHandler(goToDialogue_Click);
                    }
                    // 0xa0 - 0xa6  // 0xd8 - 0xde
                    if (temp.Opcode == 0xA0 || temp.Opcode == 0xA1 || temp.Opcode == 0xA2 ||
                        temp.Opcode == 0xA4 || temp.Opcode == 0xA5 || temp.Opcode == 0xA6 ||
                        temp.Opcode == 0xD8 || temp.Opcode == 0xD9 || temp.Opcode == 0xDA ||
                        temp.Opcode == 0xDC || temp.Opcode == 0xDD || temp.Opcode == 0xDE)
                    {
                        e.Node.ContextMenuStrip = contextMenuStripGoto;
                        goToToolStripMenuItem.Text = "Add to notes database...";
                        goToToolStripMenuItem.Click += new EventHandler(addMemoryToNotesDatabase_Click);
                    }
                    if (temp.Opcode == 0xFD)
                    {
                        if (temp.Option == 0xD8 || temp.Option == 0xD9 || temp.Option == 0xDA ||
                            temp.Option == 0xDC || temp.Option == 0xDD || temp.Option == 0xDE)
                        {
                            e.Node.ContextMenuStrip = contextMenuStripGoto;
                            goToToolStripMenuItem.Text = "Add to notes database...";
                            goToToolStripMenuItem.Click += new EventHandler(addMemoryToNotesDatabase_Click);
                        }
                    }
                }
                else
                {
                    ActionQueueCommand temp = (ActionQueueCommand)EventScriptTree.SelectedNode.Tag;
                    // 0xa0 - 0xa6  // 0xd8 - 0xde
                    if (temp.Opcode == 0xA0 || temp.Opcode == 0xA1 || temp.Opcode == 0xA2 ||
                        temp.Opcode == 0xA4 || temp.Opcode == 0xA5 || temp.Opcode == 0xA6 ||
                        temp.Opcode == 0xD8 || temp.Opcode == 0xD9 || temp.Opcode == 0xDA ||
                        temp.Opcode == 0xDC || temp.Opcode == 0xDD || temp.Opcode == 0xDE)
                    {
                        e.Node.ContextMenuStrip = contextMenuStripGoto;
                        goToToolStripMenuItem.Text = "Add to notes database...";
                        goToToolStripMenuItem.Click += new EventHandler(addMemoryToNotesDatabase_Click);
                    }
                }
            }
        }
        private void EventScriptTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            EventScriptCommand esc;
            ActionQueueCommand aqc;
            if (e.Node.Parent != null || actionScript)
            {
                aqc = (ActionQueueCommand)e.Node.Tag;
                aqc.Set = e.Node.Checked;
            }
            else
            {
                esc = (EventScriptCommand)e.Node.Tag;
                esc.Set = e.Node.Checked;
            }
        }

        private void EvtScrMoveUp_Click(object sender, EventArgs e)
        {
            updatingScript = false;

            if (EventScriptTree.SelectedNode == null) return;

            if (EventScriptTree.SelectedNode != editedNode)
            {
                editedNode = null;
                buttonApplyEvent.Enabled = false;
            }

            try
            {
                esc = (EventScriptCommand)eventScripts[currentScript].Commands[EventScriptTree.SelectedNode.Index];
            }
            catch (Exception ex)
            {
            }
            treeViewWrapper.MoveUp();

            updatingScript = true;
        }
        private void EvtScrMoveDown_Click(object sender, EventArgs e)
        {
            updatingScript = false;

            if (EventScriptTree.SelectedNode == null) return;

            if (EventScriptTree.SelectedNode != editedNode)
            {
                editedNode = null;
                buttonApplyEvent.Enabled = false;
            }

            try
            {
                esc = (EventScriptCommand)eventScripts[currentScript].Commands[EventScriptTree.SelectedNode.Index];
            }
            catch (Exception ex)
            {
            }
            treeViewWrapper.MoveDown();

            updatingScript = true;
        }
        private void EvtScrCopyCommand_Click(object sender, EventArgs e)
        {
            if (EventScriptTree.SelectedNode == null) return;

            treeViewWrapper.Copy();
        }
        private void EvtScrPasteCommand_Click(object sender, EventArgs e)
        {
            if (EventScriptTree.SelectedNode != editedNode)
            {
                editedNode = null;
                buttonApplyEvent.Enabled = false;
            }

            treeViewWrapper.Paste();
            UpdateCommandData();

            EventScriptTree.SelectedNode = treeViewWrapper.SelectedNode;
        }
        private void EvtScrDeleteCommand_Click(object sender, EventArgs e)
        {
            if (EventScriptTree.SelectedNode == null) return;

            if (EventScriptTree.SelectedNode == editedNode)
            {
                editedNode = null;
                buttonApplyEvent.Enabled = false;
            }
            treeViewWrapper.RemoveNode();
            UpdateCommandData();

            EventScriptTree.SelectedNode = treeViewWrapper.SelectedNode;
        }
        private void EvtScrEditCommand_Click(object sender, EventArgs e)
        {
            if (EventScriptTree.SelectedNode == null) return;

            ResetAllEventControls();

            // action queue command
            if (EventScriptTree.SelectedNode.Parent != null)
            {
                esc = (EventScriptCommand)eventScripts[currentScript].Commands[EventScriptTree.SelectedNode.Parent.Index];
                aqc = (ActionQueueCommand)esc.EmbeddedActionQueue.ActionQueueCommands[EventScriptTree.SelectedNode.Index];
                ControlActionDisasmMethod();
            }
            // action script command
            else if (actionScript)
            {
                aqc = (ActionQueueCommand)actionScripts[currentScript].ActionQueueCommands[EventScriptTree.SelectedNode.Index];
                esc = null;
                ControlActionDisasmMethod();
            }
            // event script command
            else
            {
                esc = (EventScriptCommand)eventScripts[currentScript].Commands[EventScriptTree.SelectedNode.Index];
                aqc = null;
                ControlEventDisasmMethod();
            }

            buttonApplyEvent.Enabled = true;

            UpdateCommandData();

            editedNode = EventScriptTree.SelectedNode;
            EventScriptTree.SelectedNode = treeViewWrapper.SelectedNode;

            treeViewWrapper.EditedNode = editedNode;
        }
        private void EvtScrExpandAll_Click(object sender, EventArgs e)
        {
            treeViewWrapper.ExpandAll();
            UpdateCommandData();
        }
        private void EvtScrCollapseAll_Click(object sender, EventArgs e)
        {
            treeViewWrapper.CollapseAll();
            UpdateCommandData();
        }
        private void EvtScrClearAll_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Delete all commands in the current script?",
            "LAZY SHELL", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            treeViewWrapper.ClearAll();
            UpdateCommandData();
        }
        private void EventPreview_Click(object sender, EventArgs e)
        {
            PreviewEventOrAction();
        }

        private void cpuCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            cpuExtendedCommands.Items.Clear();
            cpuExtendedCommands.Items.AddRange(EventListBoxNames(cpuCommands.SelectedIndex));
            cpuExtendedCommands.SelectedIndex = 0;
        }
        private void cpuExtendedCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            actionSelected = false;

            byte[] temp;
            int opcode;
            int option;

            opcode = eventListBoxOpcodes[cpuCommands.SelectedIndex][cpuExtendedCommands.SelectedIndex];
            option = eventListBoxFDOpcodes[cpuCommands.SelectedIndex][cpuExtendedCommands.SelectedIndex];

            temp = new byte[ScriptEnums.GetEventOpcodeLength(opcode, option)];
            temp[0] = (byte)opcode;
            if (temp.Length > 1)
                temp[1] = (byte)option;
            esc = new EventScriptCommand(temp, 0);
            aqc = null;

            editedNode = null;  // the COMMAND PROPERTIES panel now contains a new node instead (2008-11-09)

            ResetAllEventControls();
            ControlEventDisasmMethod();
            buttonInsertEvent.Enabled = true;
            buttonApplyEvent.Enabled = false;
        }
        private void actionQueueCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            actionQueueExtendedCommands.Items.Clear();
            actionQueueExtendedCommands.Items.AddRange(ActionListBoxNames(actionQueueCommands.SelectedIndex));
            actionQueueExtendedCommands.SelectedIndex = 0;
        }
        private void actionQueueExtendedCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            actionSelected = true;

            byte[] temp;
            int opcode;
            int option;

            opcode = actionListBoxOpcodes[actionQueueCommands.SelectedIndex][actionQueueExtendedCommands.SelectedIndex];
            option = actionListBoxFDOpcodes[actionQueueCommands.SelectedIndex][actionQueueExtendedCommands.SelectedIndex];

            temp = new byte[ScriptEnums.GetActionQueueOpcodeLength(opcode, option)];
            temp[0] = (byte)opcode;
            if (temp.Length > 1)
                temp[1] = (byte)option;
            aqc = new ActionQueueCommand(temp, 0);

            editedNode = null;  // the COMMAND PROPERTIES panel now contains a new node instead (2008-11-09)

            ResetAllEventControls();
            ControlActionDisasmMethod();
            buttonInsertEvent.Enabled = true;
            buttonApplyEvent.Enabled = false;
        }
        private void buttonInsertEvent_Click(object sender, EventArgs e)
        {
            EventScriptCommand tempEsc;

            // if editing a non-blank script
            if (EventScriptTree.SelectedNode != null)
            {
                // if inserting action queue/script command
                if (EventScriptTree.SelectedNode.Parent != null || actionScript)
                    InsertActionCommand();

                else
                {
                    tempEsc = (EventScriptCommand)eventScripts[currentScript].Commands[EventScriptTree.SelectedNode.Index];

                    // if adding action queue command to an empty queue trigger
                    if (tempEsc.IsActionQueueTrigger && actionSelected)
                        InsertActionCommand();

                    // if inserting an event command
                    else InsertEventCommand();
                }
            }
            // if inserting action command to a blank action script
            else if (actionScript) InsertActionCommand();

            // if inserting event command to a blank event script
            else InsertEventCommand();

            if (!actionScript) UpdateEventScriptsFreeSpace();
            else UpdateActionScriptsFreeSpace();

            UpdateCommandData();
        }
        private void buttonApplyEvent_Click(object sender, EventArgs e)
        {
            if (editedNode != null)
            {
                if (editedNode.Parent != null || actionScript)
                {
                    ControlActionAsmMethod();
                    treeViewWrapper.ReplaceNode(aqc);

                    UpdateActionScriptsFreeSpace();
                }
                else
                {
                    ControlEventAsmMethod();
                    treeViewWrapper.ReplaceNode(esc);

                    UpdateEventScriptsFreeSpace();
                }
            }

            UpdateCommandData();

            EvtScrEditCommand_Click(null, null);
        }

        private void evtNameA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingControls) return;

            if (aqc != null)
            {
                switch (aqc.Opcode)
                {
                    case 0xF2:
                    case 0xF3:
                    case 0xF8:
                        evtNumA.Value = evtNameA.SelectedIndex;  // Level names
                        break;
                }
            }
            else
            {
                switch (esc.Opcode)
                {
                    case 0xF2:
                    case 0xF3:
                    case 0xF8:
                    case 0x68:
                    case 0x6A:
                    case 0x6B:
                    case 0x60:
                    case 0x62:
                        evtNumA.Value = evtNameA.SelectedIndex;  // Level names, Dialogue names
                        break;
                    case 0x50:
                    case 0x51:
                        evtNumA.Value = universal.ItemNames.GetNumFromIndex(evtNameA.SelectedIndex);    // Item names
                        break;
                    case 0x4E:
                        updatingControls = false;

                        labelEvtB.Text = "";
                        labelEvtC.Text = "";
                        evtNameB.Items.Clear(); evtNameB.ResetText(); evtNameB.Enabled = false;
                        evtNumB.Value = 0; evtNumB.Enabled = false;
                        evtNumC.Value = 0; evtNumC.Maximum = 255; evtNumC.Enabled = false;
                        switch (evtNameA.SelectedIndex)
                        {
                            case 2: // open world map point
                                labelEvtB.Text = "map point";
                                evtNameB.Items.Clear(); evtNameB.Items.AddRange(MapNames); evtNameB.Enabled = true;

                                evtNameB.SelectedIndex = 0;
                                break;
                            case 3: // open shop menu
                                labelEvtC.Text = "shop menu";
                                evtNumC.Maximum = 32; evtNumC.Enabled = true;
                                break;
                            case 5: // items maxed out
                                labelEvtB.Text = "toss item";
                                evtNameB.Items.Clear(); evtNameB.Items.AddRange(universal.ItemNames.GetNames()); evtNameB.Enabled = true;
                                evtNumB.Enabled = true;

                                evtNameB.SelectedIndex = universal.ItemNames.GetIndexFromNum((int)evtNumB.Value);
                                break;
                            case 7: // menu tutorial
                                labelEvtB.Text = "tutorial";
                                evtNameB.Items.Clear(); evtNameB.Items.AddRange(new string[] { "How to equip", "How to use items", "How to switch allies", "How to play beetle mania" });
                                evtNameB.Enabled = true;

                                evtNameB.SelectedIndex = 0;
                                break;
                            case 16:    // world map event
                                labelEvtB.Text = "map event";
                                evtNameB.Items.Clear(); evtNameB.Items.AddRange(new string[] { "Mario falls to pipehouse", "Mario returns to MK", "Mario takes Nimbus bus" });
                                evtNameB.Enabled = true;

                                evtNameB.SelectedIndex = 0;
                                break;
                        }

                        updatingControls = true;
                        break;
                    case 0x97:
                        if (evtNameA.SelectedIndex == 0) { labelEvtC.Text = "slow down"; evtNumC.Maximum = 160; }
                        else { labelEvtC.Text = "speed up"; evtNumC.Maximum = 94; }
                        break;
                    case 0xFD:
                        switch (esc.Option)
                        {
                            case 0x58:
                                evtNumA.Value = universal.ItemNames.GetNumFromIndex(evtNameA.SelectedIndex);    // Item names
                                break;
                        }
                        break;
                }
            }
        }
        private void evtNumA_ValueChanged(object sender, EventArgs e)
        {
            if (!updatingControls) return;

            if (aqc != null)
            {
                switch (aqc.Opcode)
                {
                    case 0xF2:
                    case 0xF3:
                    case 0xF8:
                        evtNameA.SelectedIndex = (int)evtNumA.Value;  // Level names, Dialogue names
                        break;
                }
            }
            else
            {
                switch (esc.Opcode)
                {
                    case 0xF2:
                    case 0xF3:
                    case 0xF8:
                    case 0x68:
                    case 0x6A:
                    case 0x6B:
                    case 0x60:
                    case 0x62:
                        evtNameA.SelectedIndex = (int)evtNumA.Value;  // Level names, Dialogue names
                        break;
                    case 0x50:
                    case 0x51:
                        evtNameA.SelectedIndex = universal.ItemNames.GetIndexFromNum((int)evtNumA.Value);    // Item names
                        break;
                }
            }
        }
        private void evtNameB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingControls) return;

            if (aqc == null)
            {
                switch (esc.Opcode)
                {
                    case 0x54:
                    case 0x4E:
                        evtNumB.Value = universal.ItemNames.GetNumFromIndex(evtNameB.SelectedIndex);    // Item names
                        break;
                    case 0x4A:
                        evtNumB.Value = evtNameB.SelectedIndex; // battlefields
                        break;
                    default:
                        if (esc.Opcode <= 0x2F)
                        {
                            labelEvtC.Text = "";
                            labelTitleB.Text = "";
                            evtNumC.Value = 0; evtNumC.Maximum = 255; evtNumC.Enabled = false;
                            evtEffects.Items.Clear(); evtEffects.Enabled = false;
                            if (evtNameB.SelectedIndex < 3) // queue options need sync bit
                            {
                                labelTitleB.Text = "properties...";
                                evtEffects.Items.AddRange(new string[] { "asynchronous" }); evtEffects.Enabled = true;
                            }
                            else if (evtNameB.SelectedIndex >= 3 && evtNameB.SelectedIndex <= 6) // options 0xF2-0xF5
                            {
                                labelEvtC.Text = "action #";
                                evtNumC.Maximum = 0x3FF; evtNumC.Enabled = true;
                            }
                            else
                            {
                                labelEvtC.Text = "";
                                evtNumC.Enabled = false;
                            }
                        }
                        break;
                }
            }
        }
        private void evtNumB_ValueChanged(object sender, EventArgs e)
        {
            if (!updatingControls) return;

            if (aqc == null)
            {
                switch (esc.Opcode)
                {
                    case 0x54:
                    case 0x4E:
                        evtNameB.SelectedIndex = universal.ItemNames.GetIndexFromNum((int)evtNumB.Value);    // Item names
                        break;
                    case 0x4A:
                        evtNameB.SelectedIndex = (int)evtNumB.Value;    // battlefields
                        break;
                }
            }
        }
        private void evtEffects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (aqc != null)
            {
                switch (aqc.Opcode)
                {
                    case 0x08:
                        labelEvtD.Text = evtEffects.GetItemChecked(0) ? "mold" : "sequence";
                        break;
                }
            }
        }

        // Labels
        private void eventLabel_TextChanged(object sender, EventArgs e)
        {
            if (!actionScript)
                settings.EventLabels[currentScript] = eventLabel.Text;
            else
                settings.ActionLabels[currentScript] = eventLabel.Text;
        }
        private void eventLabel_Leave(object sender, EventArgs e)
        {
            //settings.Save();
        }
        private void searchLabels_Click(object sender, EventArgs e)
        {
            panelSearchLabels.Visible = !panelSearchLabels.Visible;
            if (panelSearchLabels.Visible)
            {
                panelSearchLabels.BringToFront();
                nameTextBox.Focus();
            }
        }
        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            LoadLabelSearch();
        }
        private void nameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                panelSearchLabels.Visible = false;
        }
        private void listBoxLabels_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                TreeNode temp = (TreeNode)listBoxLabels.SelectedNode;
                EventNumber.Value = (int)temp.Tag;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem loading the search item. Try doing another search.");
            }
        }
        private void listBoxLabels_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                panelSearchLabels.Visible = false;
        }

        private void goToDialogue_Click(object sender, EventArgs e)
        {
            if (EventScriptTree.SelectedNode == null) return;

            EventScriptCommand temp = (EventScriptCommand)EventScriptTree.SelectedNode.Tag;
            int num = BitManager.GetShort(temp.EventData, 1) & 0xFFF;

            if (model.Program.Sprites == null)
                model.Program.CreateSpritesWindow();

            model.Program.Sprites.TabControl1.SelectedIndex = 2;
            model.Program.Sprites.DialogueNum.Value = num;
            model.Program.Sprites.BringToFront();
        }
        private void addMemoryToNotesDatabase_Click(object sender, EventArgs e)
        {
            if (EventScriptTree.SelectedNode == null) return;

            int address = 0x7000;
            int addressBit = 0;
            string label = "";
            string description = "";
            if (EventScriptTree.SelectedNode.Tag.GetType() == typeof(EventScriptCommand))
            {
                EventScriptCommand temp = (EventScriptCommand)EventScriptTree.SelectedNode.Tag;
                if (temp.Opcode >= 0xA0 && temp.Opcode <= 0xA2)
                    address = ((((temp.Opcode * 0x100) + temp.Option) - 0xA000) / 8) + 0x7040;
                if (temp.Opcode >= 0xA4 && temp.Opcode <= 0xA6)
                    address = ((((temp.Opcode * 0x100) + temp.Option) - 0xA400) / 8) + 0x7040;
                if (temp.Opcode >= 0xD8 && temp.Opcode <= 0xDA)
                    address = ((((temp.Opcode * 0x100) + temp.Option) - 0xD800) / 8) + 0x7040;
                if (temp.Opcode >= 0xDC && temp.Opcode <= 0xDE)
                    address = ((((temp.Opcode * 0x100) + temp.Option) - 0xDC00) / 8) + 0x7040;
                addressBit = temp.Option & 0x07;
                if (temp.Option == 0xFD)
                {
                    if (temp.Option >= 0xA0 && temp.Option <= 0xA2)
                        address = ((((temp.Option * 0x100) + temp.EventData[2]) - 0xA000) / 8) + 0x7040;
                    if (temp.Option >= 0xA4 && temp.Option <= 0xA6)
                        address = ((((temp.Option * 0x100) + temp.EventData[2]) - 0xA400) / 8) + 0x7040;
                    if (temp.Option >= 0xD8 && temp.Option <= 0xDA)
                        address = ((((temp.Option * 0x100) + temp.EventData[2]) - 0xD800) / 8) + 0x7040;
                    if (temp.Option >= 0xDC && temp.Option <= 0xDE)
                        address = ((((temp.Option * 0x100) + temp.EventData[2]) - 0xDC00) / 8) + 0x7040;
                    addressBit = temp.EventData[2] & 0x07;
                }
            }
            else
            {
                ActionQueueCommand temp = (ActionQueueCommand)EventScriptTree.SelectedNode.Tag;
                if (temp.Opcode >= 0xA0 && temp.Opcode <= 0xA2)
                    address = ((((temp.Opcode * 0x100) + temp.Option) - 0xA000) / 8) + 0x7040;
                if (temp.Opcode >= 0xA4 && temp.Opcode <= 0xA6)
                    address = ((((temp.Opcode * 0x100) + temp.Option) - 0xA400) / 8) + 0x7040;
                if (temp.Opcode >= 0xD8 && temp.Opcode <= 0xDA)
                    address = ((((temp.Opcode * 0x100) + temp.Option) - 0xD800) / 8) + 0x7040;
                if (temp.Opcode >= 0xDC && temp.Opcode <= 0xDE)
                    address = ((((temp.Opcode * 0x100) + temp.Option) - 0xDC00) / 8) + 0x7040;
                addressBit = temp.Option & 0x07;
            }

            label = description = "[" + address.ToString("X4") + ", bit: " + addressBit.ToString() + "]";

            if (model.Program.Notes == null || !model.Program.Notes.Visible)
                model.Program.CreateNotesWindow();
            Notes note = model.Program.Notes;
            if (note.ThisNotes == null)
                note.LoadNotes();
            if (note.ThisNotes != null)
            {
                note.AddingFromEditor(7, address, addressBit, label, description);
                note.BringToFront();
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
