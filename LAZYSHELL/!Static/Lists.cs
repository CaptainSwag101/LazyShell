using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public static class Lists
    {
        #region Variables
        #region Other
        public static string[] EntranceNames = new string[]
        {
            "no movement for \"Escape\"",
            "slide backward when hit",
            "Bowser Clone sprite",
            "Mario Clone sprite",
            "no reaction when hit",
            "sprite shadow",
            "floating, sprite shadow",
            "floating",
            "floating, slide backward when hit",
            "floating, slide backward when hit",
            "fade out death, floating",
            "fade out death",
            "fade out death",
            "fade out death, Smithy spell cast",
            "fade out death, no \"Escape\" movement",
            "fade out death, no \"Escape\" transition",
            "(normal)",
            "no reaction when hit"
        };
        public static string[] CoinSizes = new string[]
        {
            "none","small","big"
        };
        public static string[] SpriteBehaviors = new string[] {
            "no movement for \"Escape\"",
            "slide backward when hit",
            "Bowser Clone sprite",
            "Mario Clone sprite",
            "no reaction when hit",
            "sprite shadow",
            "floating, sprite shadow",
            "floating",
            "floating, slide backward when hit",
            "floating, slide backward when hit",
            "fade out death, floating",
            "fade out death",
            "fade out death",
            "fade out death, Smithy spell cast",
            "fade out death, no \"Escape\" movement",
            "fade out death, no \"Escape\" transition",
            "(normal)",
            "no reaction when hit"
        };
        public static string[] MonsterSoundStrike = new string[] 
        {
            "bite",
            "pierce",
            "claw",
            "jab",
            "slap",
            "knock",
            "smash",
            "deep knock",
            "punch",
            "bonk",
            "flopping",
            "deep jab",
            "blast",
            "blast"
        };
        public static string[] MonsterSoundOther = new string[] 
        {
            "none",
            "Starslap, Spikey, Enigma",
            "Sparky, Goomba, Birdy",
            "Amanita, Terrapin",
            "Guerilla",
            "Pulsar",
            "Dry Bones",
            "Torte"
        };
        public static string[] CharacterNames = new string[]
        {
            "Mario", "Toadstool", "Bowser", "Geno", "Mallow"
        };
        public static string[] ButtonNames = new string[] 
        { 
            "left", "right", "down", "up", "X", "A", "Y", "B" 
        };
        public static string[] Directions = new string[]
        {
            "east","southeast","south","southwest",
            "west","northwest","north","northeast"
        };
        public static string[] ColorNames = new string[] 
        { 
            "black", "blue", "red", "pink", "green", "aqua", "yellow", "white" 
        };
        public static string[] LayerNames = new string[] 
        { 
            "L1", "L2", "L3", "L4", "Sprites", "BG", "½ intensity", "Minus sub" 
        };
        public static string[] MenuNames = new string[]
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
        #endregion
        #region Maps
        public static string[] MapNames = new string[]
        {
            "To Mario's Pad (before)",
            "Bowser's Keep (before)",
            "To Mario's Pad",
            "Vista Hill",
            "Bowser's Keep",
            "Gate",
            "To Nimbus Land",
            "To Bowser's Keep",
            "Mario's Pad",
            "Mushroom Way",
            "Mushroom Kingdom",
            "Bandit's Way",
            "Kero Sewers",
            "To Mushroom Kingdom",
            "Kero Sewers",
            "Midas River",
            "Tadpole Pond",
            "Rose Way",
            "Rose Town",
            "Forest Maze",
            "Pipe Vault",
            "To Yo'ster Isle",
            "To Moleville",
            "To Pipe Vault",
            "Moleville",
            "Booster Pass",
            "Booster Tower",
            "Booster Hill",
            "Marrymore",
            "To Star Hill",
            "To Marrymore",
            "Star Hill",
            "Seaside Town",
            "Sea",
            "Sunken Ship",
            "To Land's End",
            "To Seaside Town",
            "Land's End",
            "Monstro Town",
            "Bean Valley",
            "Grate Guy's Casino",
            "To Nimbus Land",
            "To Seaside Town",
            "Land's End",
            "Monstro Town",
            "Bean Valley",
            "Grate Guy's Casino",
            "To Nimbus Land",
            "To Bean Valley",
            "Nimbus Land",
            "Barrel Volcano",
            "To Bowser's Keep",
            "Yo'ster Isle",
            "To Pipe Vault",
            "Coal Mines (Bowser's Keep)",
            "Factory (Bowser's Keep)"
        };
        public static string[] ObjectNames = new string[]
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
            			
                    "Mem $70A8",			// 0x10
                    "Mem $70A9",			// 0x11
                    "Mem $70AA",			// 0x12
                    "Mem $70AB",			// 0x13
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
        #endregion
        #region Audio
        public static string[] MusicNames = new string[]
        {
            "{CURRENT}",
            "Dodo\'s Coming",
            "Mushroom Kingdom",
            "Fight Against Stronger Monster",
            "Yo\'ster Island",
            "Seaside Town",
            "Fight Against Monsters",
            "Pipe Vault",
            "Invincible Star",
            "Victory",
            "In The Flower Garden",
            "Bowser\'s Castle (1st time)",
            "Fight Against Bowser",
            "Road Is Full Of Dangers",
            "Mario\'s Pad",
            "Here\'s Some Weapons",
            "Let\'s Race",
            "Tadpole Pond",
            "Rose Town",
            "Race Training",
            "Shock!",
            "Sad Song",
            "Midas River",
            "Got A Star Piece (part 1)",
            "Got A Star Piece (part 2)",
            "Fight Against An Armed Boss",
            "Forest Maze",
            "Dungeon Is Full Of Monsters",
            "Let\'s Play Geno",
            "Start Slot Menu",
            "Long Long Ago",
            "Booster\'s Tower",
            "And My Name\'s Booster",
            "Moleville",
            "Star Hill",
            "Mountain Railroad",
            "Explanation",
            "Booster Hill (start)",
            "Booster Hill",
            "Marrymore",
            "New Partner",
            "Sunken Ship",
            "Still The Road Is Full Of Monsters",
            "{SILENCE}",
            "Sea",
            "Heart Beating A Little Faster (part 1)",
            "Heart Beating A Little Faster (part 2)",
            "Grate Guy\'s Casino",
            "Geno Awakens",
            "Celebrational",
            "Nimbus Land",
            "Monstro Town",
            "Toadofsky",
            "{SILENCE}",
            "Happy Adventure, Delighful Adventure",
            "World Map",
            "Factory",
            "Sword Crashes And Stars Scatter",
            "Conversation With Culex",
            "Fight Against Culex",
            "Victory Against Culex",
            "Valentina",
            "Barrel Volcano",
            "Axem Rangers Drop In",
            "The End",
            "Gate",
            "Bowser\'s Castle (2nd time)",
            "Weapons Factory",
            "Fight Against Smithy 1",
            "Fight Against Smithy 2",
            "Ending Part 1",
            "Ending Part 2",
            "Ending Part 3",
            "Ending Part 4",
            "{SILENCE}",
            "{SILENCE}",
            "{SILENCE}",
            "{SILENCE}",
            "{SILENCE}",
            "{SILENCE}"
        };
        public static string[] SoundNames = new string[]
        {
            "nothing",
            "menu select",
            "menu cancel",
            "menu scroll",
            "jump",
            "block switch",
            "running water",
            "rushing water",
            "waterfall",
            "green switch",
            "trampoline",
            "whoosh away",
            "dizziness",
            "coin",
            "flower",
            "night crickets",
            "open door",
            "open front gate",
            "sudden stop",
            "long fall",
            "lighting bolt",
            "rumbling",
            "close door",
            "helicopter",
            "tapping feet",
            "heel click",
            "laughing Bowser",
            "found an item",
            "pipe entrance",
            "alarm clock",
            "surprised monster",
            "spinning flower",
            "underground warp",
            "jumping/bouncing fish",
            "squirm/writhe",
            "running water",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "pop up from water",
            "ghost float",
            "Goomba taunt",
            "crumbling noise",
            "snooze",
            "minecart start",
            "big shell hit",
            "water droplet",
            "moving yellow switch",
            "deep bounce",
            "bounce",
            "goodnight",
            "lose coins/coin fountain",
            "shake head",
            "finger snap",
            "insert",
            "hovering Frogfucius",
            "dynamite/bomb explosion",
            "deep uh-oh",
            "big yoshi talk",
            "yoshi talk",
            "spinning copters",
            "thwomp stomp",
            "kick ball/shell",
            "sword in keep",
            "",
            "",
            "",
            "mushroom cure",
            "syrup cure",
            "thwomp stomp",
            "Boosters train",
            "rocketing blast",
            "Boosters train horn",
            "exotic bird calls",
            "click",
            "",
            "beeping",
            "star",
            "screeching stop",
            "weird laugh",
            "smoked",
            "flower",
            "big bounce",
            "correct signal",
            "wrong signal",
            "lit fuse",
            "curtain",
            "tumbling boulders",
            "",
            "jump into water",
            "frog coin",
            "level up with star",
            "swinging fist",
            "engage in battle",
            "",
            "tapping feet",
            "minecart ride",
            "Terrapin attack",
            "time running out",
            "Toadstool crying",
            "deep scraping",
            "surprise",
            "off balance",
            "drum roll",
            "drum roll end",
            "big shell hit",
            "abstract music",
            "sleeping",
            "draining water",
            "open chamber door",
            "",
            "",
            "",
            "spinning monster",
            "beckoning Tentacle",
            "Czar Dragon roar",
            "metal/bolt strike",
            "Axem Ranger teleport",
            "",
            "chain/rumbling noise",
            "engine starting",
            "enter deep water",
            "emerge deep water",
            "light rattle",
            "floating/hovering",
            "baby yoshi",
            "big baby yoshi",
            "",
            "honking horn",
            "close hit door",
            "swipe",
            "impending blast",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "metronome upbeat ding",
            "click",
            "blacksmith hammer strike",
            "machine transform",
            "click",
            "surging electricity",
            "casino secret passage",
            "exit to world map",
            "crash hit",
            "slip hit",
            "slot machines",
            "big squish",
            "post-credits Mario theme whistle",
            "Link fanfare",
            "descending fall",
            "hard land",
            "deep underground noise",
            "chomp",
            "ghost",
            "closing gate door"
        };
        public static string[] BattleSoundNames = new string[]
        {
            "____",
            "select action/menu",
            "cancel action/menu",
            "move cursor",
            "Mario's jump",
            "birdie tweet",
            "flower bonus/status up",
            "error/incorrect answer",
            "get dizzy",
            "arrow sling",
            "punch",
            "swoosh/run away",
            "bomb explosion",
            "coin",
            "grab flower",
            "spike strike",
            "bite",
            "falling stars (electroshock?)",
            "shell kick",
            "Drain Beam",
            "Aurora Flash",
            "wing flaps",
            "Electroshock shock",
            "small laser?",
            "____",
            "wing hit",
            "Flame Wall",
            "grab item/1-UP",
            "Flame",
            "Drain",
            "Fire Orb multiple orb hit",
            "Fire Orb background burn",
            "Fire Orb finish",
            "kick?",
            "spike shot",
            "Bombs Away power up",
            "Snowy gathering snow",
            "monster/item toss",
            "hit by tossed item",
            "claw strike",
            "K-9 fang hit",
            "Hammer Bro hammer hit",
            "Johnnys Skewer strike",
            "casting a spell",
            "Thunderbolt second strike",
            "HP Rain cloud",
            "bounce",
            "dry clunk",
            "Marios punch",
            "cymbal crash",
            "tiny shell hit",
            "Super Flame multiple orb hit",
            "Finger Shot/Bullets",
            "Thwomp hit ground",
            "hammer hit from Hammer Time",
            "Marios hammer hit",
            "super/ultra jump 1-UP sound",
            "Water Blast spout?",
            "Marios shell kick up",
            "Marios shell kick forward",
            "cymbal resonance",
            "use item",
            "monster run away",
            "ignition from Geno Blast",
            "egg hatch",
            "Yoshi cant make cookie",
            "Recover HP/MP",
            "stars?",
            "rain cloud",
            "Geno power up",
            "Geno Beam",
            "drum roll (Psycopath/Roulette)",
            "rain cloud appears",
            "correct password",
            "quack?",
            "Yoshi talk",
            "Yoshi make item",
            "stat boost (Geno Boost)",
            "timed stat boost",
            "rumble",
            "hit",
            "hit",
            "big hit",
            "Dry Bones hit",
            "big hit",
            "Jinxs Triple Kick kick",
            "long fall",
            "Lazy Shell kick",
            "ticking bomb",
            "enemy defeated (common explosion)",
            "valor up?",
            "____",
            "fall",
            "Shocker 1",
            "Shocker 2",
            "Bowsers Crusher?",
            "Boulder",
            "toss",
            "click",
            "Willy Wisp",
            "Electroshock sparks",
            "electricity?",
            "Static E!",
            "Crystal hits",
            "Blizzard",
            "Rock Candy",
            "Light Beam",
            "squeak then hit?",
            "howl",
            "bullet shot",
            "huge explosion",
            "Heavy Troopa land?",
            "swing",
            "shot",
            "Spikey attack",
            "hit",
            "Terrapin hit",
            "sting?",
            "jolt?",
            "Meteor Swarm/Snowy",
            "deep swallow",
            "big swing",
            "arrow shot?",
            "Chomp bite",
            "Goomba run forward",
            "spike shot",
            "big object bounces",
            "???",
            "Lil Boo approaches",
            "throw?",
            "Valor Up/Vigor Up",
            "Come Back summon star?",
            "little beep",
            "lullaby",
            "hit",
            "hit",
            "Lil Boo approaches",
            "heavy machine stomp",
            "Endobubble",
            "guitar string?",
            "Come Back star",
            "lullaby",
            "tongue noise?",
            "toss something",
            "Lightning Orb",
            "???",
            "slap",
            "____",
            "finger shot/arm cannon",
            "enemy jumps high",
            "enemy taunts then hits",
            "spores",
            "hit",
            "deep weird voice",
            "buzzing bee",
            "Sparky hit",
            "Chomp bite",
            "weird enemy hit",
            "tongue swing?",
            "big deep hit",
            "wing slap",
            "____",
            "____",
            "____",
            "____",
            "____",
            "____",
            "____",
            "____",
            "____",
            "____",
            "____",
            "____",
            "____",
            "____",
            "____",
            "fade-out",
            "____",
            "____",
            "____",
            "____",
            "____",
            "____",
            "____",
            "____",
            "____",
            "____",
            "____",
            "Petal Blast",
            "???",
            "Come Back",
            "monster call",
            "big shell kick",
            "big shell hit 1",
            "big shell hit 2",
            "explosive attack",
            "hovering attack",
            "smash",
            "Ice Rock",
            "Arrow Rain",
            "Spear Rain",
            "Sword Rain",
            "Corona 1",
            "Corona 2",
            "chomping",
            "Jinxed",
            "monster swing",
            "monster taunt",
            "Smithy Form 1 - light up",
            "Smithy Form 1 - transform",
            "Booster Express train horn"
        };
        #endregion
        #region Battles
        public static string[] BattlefieldNames = new string[]
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
        public static string[] BattleEventNames = new string[]
        {
            "Mallow belts Croco, gets back frog coin",
            "Kinklink flashes, loses grip and Bowser falls",
            "Belome swallows Mallow",
            "Geno fights Bowyer, Mario and Mallow run to help",
            "Mack jumps out of battle off screen",
            "Mack returns to battle",
            "Belome spits out Mallow",
            "Countdown runs schedule, 1:00,3:00,5:00,6:00,7:00",
            "Countdown runs schedule, 6:00,9:00,10:00,12:00",
            "Punchinello interludes and prepares to summon Bob-ombs",
            "Punchinello interludes and prepares to summon Mezzo Bombs",
            "Punchinello summons King Bomb which then explodes",
            "___dialogue from Booster fight",
            "___",
            "INTRO SCENE: Punchinello fight",
            "Croco steals items: \"You want them back?\"",
            "Croco returns items: \"Enough! Here's your junk...\"",
            "INTRO SCENE: Knife Guy & Grate Guy fight",
            "Knife Guy & Grate Guy pair up piggy-back",
            "Knife Guy & Grate Guy separate: \"Yikes! They're pretty tough\"",
            "Mario and party run off of balcony after Knife Guy & Grate Guy fight",
            "Johnny challenges Mario to a one-on-one",
            "Yaridovich 'Mirage Attack'",
            "Yaridovich mirage is destroyed, return to single form",
            "Machine Made Yaridovich 'Multiplier'",
            "Drill Bit",
            "INTRO SCENE: Tentacles rise from holes",
            "beat Tentacles, move on to next",
            "beat Tentacles, move on to King Calamari",
            "jump down King Calamari's cellar hole",
            "jump up King Calamari's cellar hole",
            "Bundt moves, Assistant pokes Torte",
            "Bundt moves again, both cooks run away",
            "candles appear on Bundt",
            "\"Blow those candles out!\"",
            "Raspberry is beaten, Snifits & Booster run in and eat cake",
            "Tentacles throw character off screen",
            "GAME INTRO: Mario hammers Sky Troopa",
            "GAME INTRO: Mario stomps Goomba",
            "GAME INTRO: Mallow uses Thunderbolt",
            "GAME INTRO: Geno attacks",
            "GAME INTRO: Geno uses Geno Beam",
            "Bb-bombs explode",
            "Toad's battle mechanics tutorial",
            "Czar Dragon dies",
            "Zombone dies",
            "Czar Dragon summons Helios",
            "___",
            "Valentina summons Dodo, Dodo carries off middle character",
            "Dodo flutters and leaves battle",
            "Dodo returns to Valentina's formation",
            "Valentina & Dodo are beaten",
            "INTRO SCENE: Domino & Cloaker's introduction",
            "Domino teams up with Mad Adder",
            "Cloaker teams up with Earthlink",
            "Shy Away waters Smilax: part 1",
            "Shy Away waters Smilax: part 2",
            "Shy Away waters Smilax: part 3",
            "Thrax is there",
            "Belome confronts a character: \"You all LOOK delicious...\"",
            "Belome clones someone",
            "only Mario is there",
            "Axem Rangers intro scene",
            "Axem Pink quits",
            "Axem Black quits",
            "Axem Yellow quits",
            "Axem Green quits",
            "Axem Rangers group formation",
            "Axem Red quits",
            "Axem Rangers are defeated",
            "Jinx uses Jinxed",
            "Jinx uses Triple Kick",
            "Jinx uses Quicksilver",
            "Jinx uses Bombs Away",
            "Culex summons crystals",
            "Formless changes into Mokura",
            "Boomer is defeated, chandelier crashing scene",
            "___screen flashes white",
            "Dodo flutters and exits battle",
            "Magikoopa summons monster",
            "no one there",
            "Exor is defeated, cries and opens mouth",
            "Smithy (1st Form) is beaten, ground shakes etc.",
            "___screen flashes white",
            "___screen flashes white",
            "___Fear Roulette",
            "Smelter pours molten liquid, Smithy welds",
            "Smithy transforms into Tank Head",
            "Smithy transforms into Magic Head",
            "Smithy transforms into Chest Head",
            "Smithy transforms into Box Head",
            "Smithy's head fades before transforming into other head",
            "Shelly breaks, Birdo appears",
            "beam of light forms around Smithy head before body appears",
            "Punchinello's bombs explode if still alive",
            "bombs explode",
            "___nothing",
            "Smithy waits before transforming head",
            "Smithy is defeated",
            "___",
            "Earthlink/Mad Adder collapses and dies",
            "___Magikoopa is there",
            "<NONE>"
        };
        public static string[] TargetNames = new string[]
        {
            "Mario",
            "Toadstool",
            "Bowser",
            "Geno",
            "Mallow",
            "____",
            "____",
            "____",
            "____",
            "____",
            "____",
            "____",
            "____",
            "____",
            "____",
            "____",
            "character in slot 1",
            "character in slot 2",
            "character in slot 3",
            "monster 1 (set)",
            "monster 2 (set)",
            "monster 3 (set)",
            "monster 4 (set)",
            "monster 5 (set)",
            "monster 6 (set)",
            "monster 7 (set)",
            "monster 8 (set)",
            "self",
            "all allies, not self",
            "random ally, not self",
            "all allies, and self",
            "random ally, or self",
            "____",
            "____",
            "____",
            "all opponents",
            "at least one opponent",
            "random opponent",
            "____",
            "at least one ally",
            "monster 1 (call)",
            "monster 2 (call)",
            "monster 3 (call)",
            "monster 4 (call)",
            "monster 5 (call)",
            "monster 6 (call)",
            "monster 7 (call)",
            "monster 8 (call)"
        };
        #endregion
        #region Sprites
        public static string[] SpriteNames = new string[]
        {
            "Mario (walking, down-left)",
            "Mario (jump, front)",
            "Mario (walking, up-right)",
            "Mario (surprise, left)",
            "Mario (attack, up-right)",
            "Mario (hammer attack, up-right)",
            "Mario (crouch, up-right)",
            "Toadstool (walking, down-left)",
            "Toadstool (walking, up-right)",
            "Toadstool (surprise)",
            "Toadstool (slap attack)",
            "Toadstool (frying pan attack)",
            "Toadstool (fallen/crying)",
            "Bowser (walking, down-left)",
            "Bowser (walking, up-right)",
            "Bowser (surprise)",
            "Bowser (claw attack)",
            "Bowser (swing ball-chain)",
            "Bowser (cast spell)",
            "Mallow (walking, down-left)",
            "Mallow (walking, up-right)",
            "Mallow (surprise)",
            "Mallow (punch)",
            "Mallow (swing stick)",
            "Mallow (still, up-right)",
            "Geno (walking, down-left)",
            "Geno (walking, up-right)",
            "Geno (surprise)",
            "Geno (elbow shot)",
            "Geno (finger shot)",
            "Geno (morph into cannon)",
            "Hammer",
            "Froggie Stick",
            "Cymbals",
            "Chomp",
            "Frying Pan",
            "Parasol",
            "War Fan",
            "Red Mushroom",
            "Red Scarecrow",
            "Mario's battle portrait",
            "Toadstool's battle portrait",
            "Bowser's battle portrait",
            "Mallow's battle portrait",
            "Geno's battle portrait",
            "Yellow Yoshi",
            "Pink Yoshi",
            "Boshi",
            "Croco",
            "Green Yoshi",
            "Booster",
            "Green Yoshi (walk)",
            "Green Yoshi (laying egg)",
            "King Nimbus",
            "Queen Nimbus",
            "Jonathan Jones",
            "Valentina",
            "Magikoopa",
            "Frogfucius",
            "Tadpole",
            "Thwomp",
            "Big Thwomp",
            "Microbomb",
            "Valentina Statue",
            "Toad",
            "Wallet Guy (also casino assistants)",
            "Raini",
            "Old Man",
            "Old Woman",
            "Green/Brown Toad",
            "Chancellor",
            "Pa Mole",
            "Ma Mole",
            "Girl Mole (pink bow)",
            "Girl Mole (yellow bow)",
            "Nimbusite (blue)",
            "Nimbusite (red)",
            "Nimbusite (brown/green)",
            "Nimbusite (yellow/green)",
            "Nimbus Guard",
            "Toadofsky",
            "Mario Doll (Booster's Castle)",
            "Blue Star Piece",
            "Purple Star Piece",
            "Red Star Piece",
            "Gold Star Piece",
            "Green Star Piece",
            "Light Blue Star Piece",
            "Yellow Star Piece",
            "Geno Doll",
            "Bowser Doll",
            "Mario Doll",
            "Toadstool Doll",
            "Blue Stepping Block",
            "Treasure Chest",
            "Empty Treasure Chest",
            "Mario Doll (surprised)",
            "Toadstool's Parachute",
            "Rolling Barrel",
            "Trampoline (Warp)",
            "Trampoline (Jump)",
            "Teeter-totter",
            "Save Point",
            "Corkpedite",
            "J Puzzle Block",
            "Yellow Stepping Block",
            "Whirlpool (water)",
            "Hinopio",
            "Factory Hex-Nut",
            "Green Switch",
            "Treasure Chest (bad palette)",
            "Nimbusland Bus Driver",
            "Mushroom Boy",
            "Marrymore Man (green)",
            "Marrymore Woman (yellow)",
            "Marrymore Woman (green)",
            "Marrymore Kid (purple)",
            "Marrymore Kid (blue/green)",
            "Marrymore Bright Card buyer (brown/grey)",
            "Rose Town Gardener (green/grey)",
            "Old Woman (green/grey)",
            "Old Woman (purple/grey)",
            "Fat Yoshi Baby",
            "Yoshi Baby Egg",
            "Gameboy Kid",
            "Frogfucius Student",
            "Chomp (behind)",
            "Wiggler (head)",
            "Block Shadow",
            "Red Magikoopa",
            "Wiggler (body segment)",
            "Dodo (as parson)",
            "Moleville Mine Cart",
            "Knife Guy Juggler (still, red balls)",
            "Knife Guy Juggler",
            "Mine Cart (bad palette)",
            "Discolored Mine Cart",
            "Fireball (surface from lava)",
            "Piranha Plant",
            "Goomba",
            "Bullet Bill",
            "Golden Bullet Bill",
            "Factory Clerk (green)",
            "Land's End Cannon",
            "Red Dot?",
            "Bob-omb",
            "Commander Troopa",
            "Golden Belome",
            "Birdy Statue",
            "Shyguy in Bowser's Helicopter",
            "Machine Made Bowyer",
            "Machine Made Yaridovich (out of battle)",
            "Machine Made Axem Red",
            "Gunyolk (top section)",
            "Gunyolk (outer section)",
            "Factory Crane",
            "Blue-Green Star Piece (spinning)",
            "Smithy's Hammer",
            "Smithy's Chest",
            "Poison Toxic Gas",
            "Shelly (bottom section)",
            "Dyna and Mite",
            "Seaside Town Fake (green)",
            "Seaside Town Fake Elder (green)",
            "Seaside Town Elder (yellow/green)",
            "Monstermama (golden/brown/red)",
            "Nimbus Guard",
            "Factory Manager (blue)",
            "Factory Director (red)",
            "Boomer (red)",
            "Dr.Topper (green)",
            "Sparkles from Star Piece",
            "Geno Doll",
            "Smelter (back section)",
            "Small Candy Cloud",
            "Golden Chomp (back)",
            "Chomp (front)",
            "Grate Guy (from casino)",
            "Marrymore Inn Keeper (blue, striped hat)",
            "Rose Town Treasure Holder",
            "Rose Town Woman (blue/pink, braids)",
            "Marrymore Woman (yellow)",
            "Rose Town Old Man (blue/grey)",
            "Old Woman (grey/red)",
            "Kid (red, striped hat)",
            "Gaz (purple)",
            "(nothing)",
            "(nothing)",
            "Cannon Ball",
            "Croco (still)",
            "Bowser w/Toadstool in Helicopter",
            "Miniature Toad",
            "Coin",
            "Small Coin",
            "Frog Coin",
            "Flower",
            "Big Flower",
            "Sparkle (sideways)",
            "Sparkle (downwards)",
            "Sparkle (circular winding)",
            "Explosion",
            "Mokura's Cloud (blue)",
            "Small Frog Coin",
            "Level Up text from Invincible Star",
            "Grey Explosion (when encountering Fireballs)",
            "Miniature Axem Red",
            "Terrapin (still)",
            "Jinx (walk)",
            "Axem Red",
            "Axem Black",
            "Axem Pink",
            "Axem Yellow",
            "Axem Green",
            "Axem Red teleport",
            "Stumpet (head)",
            "Stumpet (roots, right)",
            "Czar Dragon (body)",
            "Growing Vine Beanstalk",
            "Brick Beanstalk Block",
            "Whirlpool (desert)",
            "Yellow Letter",
            "Yaridovich (out of battle)",
            "Banana Peel",
            "Tentacle (extending)",
            "Snifit (black, back)",
            "Level Up Bonus Selection Box",
            "Booster's Tower Entrance Door",
            "Light Green Pipe (top edge)",
            "Level Up Bonus Text",
            "Level Up Bonus Flower",
            "Level Up Bonus Pow Power",
            "Level Up Bonus Star Magic",
            "Level Up Bonus HP",
            "Falling Stepping Bridge Block",
            "Old Classic Mario",
            "Booster's Choo-Choo Train",
            "Magikoopa (blue, walking)",
            "Terrapin (walking)",
            "Splash Water Droplets",
            "Small Sea Fish",
            "Splash Water Geyser",
            "Bowyer",
            "White Gas Cloud",
            "Machine Made Drill Bit",
            "Mushroom House Decor Mailbox",
            "Link Sleeping in Rose Town Inn",
            "Samus Sleeping in Mushroom Kingdom",
            "Grey Stepping Stone",
            "Hinopio's Model Airplane (blue/grey)",
            "Grey Stone Block",
            "Small Black Fence",
            "Wooden Bridge Bowser's Keep (right section)",
            "Grey Stone Bridge Bowser's Keep (right section)",
            "Toadstool Hand Captive from Rope",
            "Plywood Brown Door Bowser's Keep",
            "Beetle",
            "Terrapin",
            "Spikey",
            "Sky Troopa",
            "Mad Mallet",
            "Shaman",
            "Crook",
            "Goomba",
            "Piranha Plant",
            "Amanita",
            "Goby",
            "Bloober",
            "Bandana Red",
            "Lakitu",
            "Birdy",
            "Pinwheel",
            "Rat Funk",
            "K-9",
            "Magmite",
            "The Big Boo",
            "Dry Bones",
            "Greaper",
            "Sparky",
            "Chomp",
            "Pandorite",
            "Shy Ranger",
            "Bob-Omb",
            "Spookum",
            "Hammer Bro",
            "Buzzer",
            "Ameboid",
            "Gecko",
            "Wiggler",
            "Crusty",
            "Magikoopa",
            "Leuko",
            "Jawful",
            "Enigma",
            "Blaster",
            "Guerrilla",
            "Baba Yaga",
            "Hobgoblin",
            "Reacher",
            "Shogun",
            "Orb User",
            "Heavy Troopa",
            "Shadow",
            "Cluster",
            "Bahamutt",
            "Octolot",
            "Frogog",
            "Clerk",
            "Gunyolk",
            "Boomer",
            "Remo Con",
            "Snapdragon",
            "Stumpet",
            "Dodo (2nd time)",
            "Jester",
            "Artichoker",
            "Arachne",
            "Carroboscis",
            "Hippopo",
            "Mastadoom",
            "Corkpedite",
            "Terra Cotta",
            "Spikester",
            "Malakoopa",
            "Pounder",
            "Poundette",
            "Sackit",
            "Gu Goomba",
            "Chewy",
            "Fireball",
            "Mr.Kipper",
            "Factory Chief",
            "Bandana Blue",
            "Manager",
            "Bluebird",
            "__nothing",
            "Alley Rat",
            "Chow",
            "Magmus",
            "Li~L Boo",
            "Vomer",
            "Glum Reaper",
            "Pyrosphere",
            "Chomp Chomp",
            "Hidon",
            "Sling Shy",
            "Rob-Omb",
            "Shy Guy",
            "Ninja",
            "Stinger",
            "Goombette",
            "Geckit",
            "Jabit",
            "Star Cruster",
            "Merlin",
            "Muckle",
            "Forkies",
            "Gorgon",
            "Big Bertha",
            "Chained Kong",
            "Fautso",
            "Straw Head",
            "Juju",
            "Armored Ant",
            "Orbison",
            "Tub-O-Troopa",
            "Doppel",
            "Pulsar",
            "__purple Bahamutt",
            "Octovader",
            "Ribbite",
            "Director",
            "__Gunyolk (yellow)",
            "__Boomer (blue)",
            "Puppox",
            "Fink Flower",
            "Lumbler",
            "Springer",
            "Harlequin",
            "Kriffid",
            "Spinthra",
            "Radish",
            "Crippo",
            "Mastablasta",
            "Pile Driver",
            "Apprentice",
            "__nothing",
            "__nothing",
            "__nothing",
            "__Geno redemption",
            "__little bird",
            "Box Boy",
            "Shelly",
            "Super Spike",
            "Dodo",
            "Oerlikon",
            "Chester",
            "Body",
            "__Pile Driver (body)",
            "Torte",
            "Shy Away",
            "Jinx Clone",
            "Machine Made (Shyster)",
            "Machine Made (Drill Bit)",
            "Formless",
            "Mokura",
            "Fire Crystal",
            "Water Crystal",
            "Earth Crystal",
            "Wind Crystal",
            "Mario Clone",
            "Toadstool 2",
            "Bowser Clone",
            "Geno Clone",
            "Mallow Clone",
            "Shyster",
            "Kinklink",
            "__Toadstool (captive)",
            "Hangin~ Shy",
            "Smelter",
            "Machine Made (Mack)",
            "Machine Made (Bowyer)",
            "Machine Made (Yaridovich)",
            "Machine Made (Axem Pink)",
            "Machine Made (Axem Black)",
            "Machine Made (Axem Red)",
            "Machine Made (Axem Yellow)",
            "Machine Made (Axem Green)",
            "Goomba (Intro)",
            "Hammer Bro (Intro)",
            "Birdo (Intro)",
            "Bb-Bomb",
            "Magidragon",
            "Starslap",
            "Mukumuku",
            "Zeostar",
            "Jagger",
            "Chompweed",
            "Smithy (Tank Head)",
            "Smithy (Box Head)",
            "__Corkpedite",
            "Microbomb",
            "__Thwomp",
            "Grit",
            "Neosquid",
            "Yaridovich (mirage)",
            "Helio",
            "Right Eye",
            "Left Eye",
            "Knife Guy",
            "Grate Guy",
            "Bundt",
            "Jinx (1st time)",
            "Jinx (2nd time)",
            "Count Down",
            "Ding-A-Ling",
            "Belome (1st time)",
            "Belome (2nd time)",
            "__Belome",
            "Smilax",
            "Thrax        ",
            "Megasmilax",
            "Birdo",
            "Eggbert",
            "Axem Yellow",
            "Punchinello",
            "Tentacles (right)",
            "Axem Red",
            "Axem Green",
            "King Bomb",
            "Mezzo Bomb",
            "__Bundt object",
            "Raspberry",
            "King Calamari",
            "Tentacles (left)",
            "Jinx (3rd time)",
            "Zombone",
            "Czar Dragon",
            "Cloaker (1st time)",
            "Domino (2nd time)",
            "Mad Adder",
            "Mack",
            "Bodyguard",
            "Yaridovich",
            "Drill Bit",
            "Axem Pink",
            "Axem Black",
            "Bowyer",
            "Aero",
            "__Exor (mouth)",
            "Exor",
            "Smithy (1st Form)",
            "Shyper",
            "Smithy (Body)",
            "Smithy (Head)",
            "Smithy (Magic Head)",
            "Smithy (Chest Head)",
            "Croco (1st time)",
            "Croco (2nd time)",
            "__Croco",
            "Earth Link",
            "Bowser",
            "Axem Rangers",
            "Booster",
            "Booster",
            "Snifit",
            "Johnny",
            "Johnny",
            "Valentina",
            "Cloaker (2nd time)",
            "Domino (2nd time)",
            "Candle",
            "Culex",
            "A/B/X/Y action button selection in battle",
            "Rainbow Explosion",
            "Blue Explosion",
            "Green Explosion",
            "Enemy Defeated Explosion Stars",
            "Bomb Explosion",
            "Small White Cloud",
            "Drain Explosion",
            "alphabet + symbols",
            "light blue stars",
            "Come Back rainbow star",
            "yellow cure stars",
            "....",
            "Bowyer's arrow",
            "yellow mist / steam",
            "yellow mist / steam forms into small star",
            "very small black dot",
            "HP Rain cloud",
            "stat-boost arrows",
            "black rolling coal rock",
            "blue spark",
            "yellow spark",
            "green spark",
            "red spark",
            "rainbow rain",
            "mushroom spores",
            "Lazy Shell (Heavy Troopa)",
            "Orange Lazy Shell",
            "Green Lazy Shell (Tub-O-Troopa)",
            "Snowy eyes",
            "blinking yellow light circle",
            "purple petal",
            "small pink petal",
            "thrown hammer",
            "Bombs Away electric ball",
            "Fire Orb fireball",
            "Willy Wisp purple electric ball",
            "spore (pink/green)",
            "bolt (hardware-wise)",
            "Mute balloon",
            "'Thank You' red dialogue bubble",
            "'Thank You' purple dialogue bubble",
            "'Thank You' blue dialogue bubble",
            "'Thank You' green dialogue bubble",
            "'Thank You' yellow dialogue bubble",
            "'Psychopath' question mark cloud",
            "thrown shuriken",
            "green cure stars",
            "red cure stars",
            "blue cure stars",
            "yellow reusable item sprite with letter I",
            "A/B/X/Y buttons from Bowyer's Button Lock",
            "Bowser's spike shot",
            "Geno Flash squinting eyes",
            "green item collection",
            "red item collection",
            "blue item collection",
            "yellow item collection",
            "green spore",
            "'Fear' exclamation point",
            "....",
            "Mokura",
            "Drain",
            "sparkles",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "yellow lightning ball",
            "Fire Orb hit explosion",
            "egg",
            "Lightning Orb blue lightning ball",
            "small yellow spike",
            "large yellow spike",
            "white gas cloud",
            "Blast orange gas cloud",
            "Star Egg little brown bird",
            "Poison Gas green gas cloud",
            "white stars",
            "purple gas cloud",
            "yellow star",
            "Diamond Saw snowflake",
            "blue gas cloud",
            "bone throw",
            "spritz bomb",
            "Wind Crystal",
            "green shine web",
            "Mecha-Koopa (Bowser Crush) eyes",
            "Water Crystal",
            "plasm water droplet (blue-green)",
            "Ice Rock",
            "black rock",
            "big pink heart",
            "dark red/yellow fireball",
            "light green stars",
            "light orange stars",
            "Sleepy Time sheep/ram",
            "Geno Beam/Blast/Flash red power-up star",
            "....",
            "blue/green bubbles/circles",
            "sleep ZZZ's",
            "backwards yellow spike",
            "Water Blast water spouts",
            "Gunk Ball / Ink Blast",
            "water spout (red)",
            "Royal Flush card",
            "yellow shaking bell",
            "....",
            "blue music note",
            "white pixel dot",
            "....",
            "blue water surfacing/diving droplets",
            "green water surfacing/diving droplets",
            "yellow water surfacing/diving droplets",
            "....",
            "....",
            "....",
            "....",
            "....",
            "Magikoopa's triangle/circle/X cast magic",
            "....",
            "....",
            "....",
            "....",
            "....",
            "flower bonus",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "marching Luigi",
            "marching Toads",
            "conducting Toadofsky",
            "waving Mallow",
            "waving King & Queen Nimbus",
            "Nimbus Busman, Lakitu & Frogfucius",
            "Tadpole",
            "trumpeting Piranhas",
            "Mole miners & star",
            "Dyna & Mite",
            "Hammer Bros & Chomps",
            "Crook & Croco",
            "Bowser in helicopter chasing",
            "Dodo carrying Valentina",
            "red balloon",
            "Booster riding train",
            "Snifits chasing beetle",
            "bouncing Shysters",
            "Mack, Yaridovich, Bowyer",
            "Smithy",
            "Johnny & mates",
            "blue/red/green Toads",
            "riding Yoshi",
            "waving Mario & Toadstool",
            "sparkle",
            "poof",
            "purple firework",
            "smaller red firework",
            "normal yellow 5-pronged star",
            "brown object dissipating",
            "tiny glowing pixel",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "....",
            "...."
        };
        #endregion
        #region Effects
        public static string[] EffectNames = new string[]
        {
            "___DUMMY",
            "___DUMMY",
            "Thundershock",
            "Thundershock (BG mask)",
            "Crusher",
            "Meteor Blast",
            "Bolt",
            "Star Rain",
            "Flame (fire engulf)",
            "Mute (balloon)",
            "Flame Stone",
            "Bowser Crush",
            "spell cast spade",
            "spell cast heart",
            "spell cast club",
            "spell cast diamond",
            "spell cast star",
            "Terrorize",
            "Snowy (snow BG, 4bpp)",
            "Snowy (snow FG, 2bpp)",
            "Endobubble (black ball/orb)",
            "___DUMMY",
            "Solidify",
            "___DUMMY",
            "___DUMMY",
            "Psych Bomb (BG)",
            "___DUMMY",
            "Dark Star",
            "Willy Wisp (blue orb/ball BG)",
            "___DUMMY",
            "___DUMMY",
            "___DUMMY",
            "Geno Whirl",
            "___DUMMY",
            "___DUMMY",
            "___DUMMY",
            "blank white flash (2bpp)",
            "blank white flash (4bpp)",
            "Boulder",
            "black ball/orb",
            "blank blue flash (2bpp)",
            "blank red flash (2bpp)",
            "blank blue flash (4bpp)",
            "blank red flash (4bpp)",
            "___DUMMY",
            "blank dark blue flash (2bpp)",
            "blank dark blue flash (4bpp)",
            "Meteor Shower (snow/confetti)",
            "purple/violet flash (4bpp)",
            "brown flash (4bpp)",
            "dark red blast",
            "dark blue blast",
            "snow/confetti, green",
            "light blue blast",
            "black ball/orb",
            "red ball/orb",
            "green ball/orb",
            "snow/confetti, slate green",
            "snow/confetti, red",
            "orange/red blast (Fire Bomb)",
            "Ice bomb/Solidify BG (blue freeze)",
            "Static E! (electric blast)",
            "green star bunches",
            "blue star bunches",
            "pink star bunches",
            "yellow star bunches",
            "Aurora Flash",
            "Storm",
            "Electroshock",
            "Smithy Treasure Head spell, red",
            "Smithy Treasure Head spell, green",
            "Smithy Treasure Head spell, blue",
            "Smithy Treasure Head spell, yellow",
            "___DUMMY",
            "___DUMMY",
            "___DUMMY",
            "Flame Wall (orange/red fire)",
            "Petal Blast 1",
            "Petal Blast 2",
            "Drain Beam BG (4bpp)",
            "Drain Beam FG (2bpp)",
            "___DUMMY",
            "electric bolt",
            "Sand Storm BG (2bpp)",
            "___DUMMY",
            "Pollen Nap (yellow pollen)",
            "Geno Beam, blue",
            "Geno Beam, red",
            "Geno Beam, gold",
            "Geno Beam, yellow",
            "Geno Beam, green",
            "Thunderbolt",
            "Light Beam",
            "Meteor Shower",
            "S\'Crow Dust (purple pollen)",
            "HP Rain BG",
            "HP Rain FG",
            "wavy dark blue lines",
            "wavy blue lines",
            "wavy red lines",
            "wavy brown lines",
            "Sand Storm FG (4bpp)",
            "Sledge",
            "Arrow Rain",
            "Spear Rain",
            "Sword Rain",
            "Lightning Orb (BG waves)",
            "Echofinder",
            "Poison Gas FG 1",
            "Poison Gas FG 2",
            "Poison Gas BG",
            "Smithy Transforms (beam effect)",
            "Smelter\'s molten metal",
            "___DUMMY",
            "___DUMMY",
            "___DUMMY",
            "___DUMMY",
            "___DUMMY",
            "___DUMMY",
            "___DUMMY",
            "___DUMMY",
            "___DUMMY",
            "___DUMMY",
            "___DUMMY",
            "___DUMMY",
            "___DUMMY",
            "___DUMMY",
            "___DUMMY"
        };
        #endregion
        #region Levels
        public static string[] LevelNames = new string[]
        {
            "Debug Room",
            "____blue BG, nothing there",
            "Bowser's Keep, outside (Mario enters at beginning of game)",
            "Bowser's Keep 1st time, Area 01",
            "Bowser's Keep 1st time, Area 02",
            "Marrymore, outside (during Booster)",
            "Marrymore Inn, 2F",
            "Marrymore Inn, 1F",
            "Bowser's Keep, Area 09 (tall room, w/o save point this time)",
            "Marrymore Inn, regular room",
            "Bowser's Keep 1st time, Area 04 (Throne Room)",
            "Marrymore Inn, 3F",
            "Marrymore Inn, Suite room",
            "Barrel Volcano, falling into Volcano",
            "Booster Hill",
            "Vista Hill",
            "Mario's Pad",
            "Mushroom Kingdom Castle, Main Hall",
            "Mushroom Kingdom Castle, Throne Room",
            "Mushroom Kingdom Castle, Stair Room to Toadstool's room",
            "Mushroom Kingdom Castle, Toadstool's room",
            "Mushroom Kingdom Castle, branch room to Vault/Guest Room",
            "Mushroom Kingdom Castle, Guest room",
            "Mushroom Kingdom, before Croco, Outside",
            "Sunken Ship, post-KC Area 15 (Bandana Red room w/long stairwell)",
            "Sunken Ship, post-KC Area 16 (Entrance to Johnny's room)",
            "Sunken Ship, post-KC Area 12 (underwater room w/stairwell and Zeostars)",
            "Sunken Ship, post-KC Area 13 (large underwater room with a Bloober)",
            "Sunken Ship, post-KC Area 17 (Johnny's room)",
            "Mushroom Kingdom Castle, Throne Room (Toadstool returns)",
            "Mushroom Kingdom Castle, Toadstool's room (Toadstool returns)",
            "Mushroom Kingdom Castle, Vault",
            "Mushroom Kingdom Castle, Entrance to Toadstool's room",
            "Yo'ster Isle, entrance from Pipe Vault",
            "Yo'ster Isle",
            "Booster Tower, 7F (3-level w/parachuting Spookums)",
            "Booster Tower, 6F Area 04 (3-level w/Thwomp on teeter-totter)",
            "Booster Tower, 4F (3-level room w/jumping Spookums)",
            "Booster Tower, 9F (Booster's bomb-throwing room w/rail tracks)",
            "Booster Tower, 5F (Knife Guy's juggling room)",
            "Booster Tower, 5F (Knife Guy's juggline room, after defeat)",
            "Booster Tower, 8F Area 01 (‘minesweeper' room w/coins and hidden Fireballs)",
            "Booster Tower, 3F Area 02 (NES Mario room)",
            "Booster Tower, 1F Area 01 (main room)",
            "Mushroom Kingdom, before Croco, jumping kid's house (1F)",
            "Mushroom Kingdom, before Croco, jumping kid's house (2F)",
            "Mushroom Kingdom, before Croco, Raz and Raini's house",
            "Mushroom Kingdom, before Croco, Item Shop (top floor)",
            "Booster Tower, 8F Area 02 (Zoom Shoes room)",
            "Mushroom Kingdom, before Croco, Inn (1F)",
            "____blue BG, nothing there",
            "Mushroom Kingdom, before Croco, running kid's house",
            "Mushroom Kingdom, Inn (2F)",
            "Mushroom Kingdom, before Croco, Item Shop (basement)",
            "Booster Hill ____dummy",
            "Pipe Vault Entrance",
            "Kero Sewers, Area 02 (long room w/three pipes)",
            "Kero Sewers, Area 03 (large water room w/pipe in center)",
            "Kero Sewers, Area 06 (long water room w/Rat Funks in a line)",
            "Kero Sewers, Area 05 (super star room w/four Rat Funks)",
            "Kero Sewers, Area 04 (large room w/Pandorite and hiding Rat Funks)",
            "Nimbus Land, outside (during Valentina right before fight)",
            "Kero Sewers, Area 01 (water room w/save)",
            "Marrymore Scene",
            "Marrymore, outside",
            "Marrymore Chapel, sanctuary",
            "Rose Way, exit Area where Bowser's Troops gathered",
            "Midas River, business transaction Area",
            "Midas River, barrel jumping river",
            "Midas River, waterfall",
            "Midas River, 1st tunnel",
            "Midas River, 2nd tunnel (both left and right)",
            "Midas River, 3rd tunnel (on left)",
            "Midas River, 4th tunnel (on very bottom right)",
            "Tadpole Pond, Area 02",
            "Tadpole Pond, Area 01",
            "Bandit's Way, Area 01",
            "Bandit's Way, Area 03",
            "Bandit's Way, Area 04",
            "Rose Way, main Area",
            "Rose Way, two fast-floating platforms",
            "Rose Way, treasure chests w/coins Area",
            "Rose Way, winding path w/Crooks",
            "Rose Town, during Bowyer outside",
            "Rose Town, outside",
            "Rose Town, during Bowyer Inn (1F)",
            "Rose Town, Inn (1F)",
            "Rose Town, Item Shop",
            "Smithy's Final Form Defeat: Geno's Redemption",
            "Rose Town, during Bowyer three grandkids' house",
            "Rose Town, three grandkids' house",
            "Rose Town, couple's house",
            "Grate Guy's Casino, inside casino",
            "Rose Town, during Bowyer treasure house (1F)",
            "Rose Town, treasure house (1F)",
            "Rose Town, during Bowyer Inn (2F)",
            "Rose Town, Inn (2F)",
            "Rose Town, during Bowyer treasure house (2F)",
            "Rose Town, treasure house (2F)",
            "Rose Town, Geno Awakens in Inn (1F)",
            "Booster Pass, Area 01",
            "Booster Pass, Area 02",
            "Moleville, Outside (at exit from Mines)",
            "Smithy Factory, Area 17 (Domino and Cloaker's room)",
            "Grate Guy's Casino, front door",
            "Moleville, Dyna and Mite's House ____dummy",
            "Grate Guy's Casino, outside",
            "Nimbus Castle, Area 09 (Statue Room, after Valentina)",
            "Moleville, Outside",
            "Nimbus Castle, Area 01 (entrance hall)",
            "Nimbus Castle, Area 18 (Dodo's statue-polishing room)",
            "Nimbus Castle, Area 04 (left of 4-way path, right-angle red brick path w/ treasure)",
            "Nimbus Castle, Area 17 (right of 4-way path, Save Point)",
            "Nimbus Castle, Area 16 (small two-door room w/treasure, from Area 15)",
            "Nimbus Castle, Area 10 (red brick 2-level room w/treasure from Birdo's room)",
            "Nimbus Castle, Area 03 (4-way path, during Valentina)",
            "Nimbus Castle, Area 02 (left of Area 01)",
            "Nimbus Castle, Area 15 (front of 4-way path, large right-angle room w/ plant)",
            "Nimbus Castle, Area 05 (long 5-exit room, during Valentina)",
            "Nimbus Castle, Area 06 (left-most front door from Area 05)",
            "Nimbus Castle, Area 13 (Throne Room, during Valentina)",
            "Nimbus Castle, path after Throne Room (2nd)",
            "Nimbus Castle, Area 12 (entrance to throne room)",
            "Pipe Vault, Area 01",
            "Pipe Vault, Area 03 (line of pipes)",
            "Pipe Vault, Area 04 (line of coins, 2 hidden treasures)",
            "Pipe Vault, Area 06 (line of red pipes)",
            "Pipe Vault, Area 02",
            "Pipe Vault, Area 07 (long path w/moving platforms)",
            "Pipe Vault, Area 05",
            "Sea, Area 02 (large room with shop)",
            "Sea, Area 04 (bunch of Zeostars)",
            "Sea, Area 05 (from Area 02 w/save point)",
            "Sea, Area 06 (water room w/whirlpools)",
            "Sea, Area 03 (super star room)",
            "Sea, Area 01 (entrance)",
            "Sea, Area 07 (small underwater room)",
            "Land's End, Area 01",
            "Land's End, Area 02",
            "Land's End, Area 03 (Geckits playing cannonball)",
            "Land's End, Area 01,2 (nothing there, unused?)",
            "Land's End, Area 04 (rotating flowers)",
            "Land's End, Area 05 (sky bridge)",
            "Pipe Vault, Goomba-thumping room",
            "Bowser's Keep 6-door, treasure after each room",
            "Star Hill, Area 01",
            "Pipe Vault, Area 02 ___dummy",
            "GAME INTRO: Midas River, water tunnel",
            "GAME INTRO: Bandit's Way, Area 04",
            "GAME INTRO: Midas River, Barrel Jumping",
            "GAME INTRO: Moleville, outside during Bowser's troop scene",
            "GAME INTRO: Booster Hill",
            "Marrymore Chapel, main hall",
            "Marrymore Chapel, entrance to sanctuary",
            "Marrymore Chapel, sanctuary (during Booster)",
            "Marrymore Chapel, kitchen",
            "Marrymore Chapel, kitchen (no sprites/exits, unused?)",
            "Star Hill, Area 03",
            "Star Hill, Area 02",
            "Star Hill, Area 04",
            "Sunken Ship, Area 01",
            "Sunken Ship, Area 03 (Greapers)",
            "Sunken Ship, Area 04 (Greapers & Dry Bones)",
            "Sunken Ship, puzzle room 2",
            "Sunken Ship, Area 02 (from entrance w/save point)",
            "Sunken Ship, Area 06 (puzzle room passageway)",
            "Sunken Ship, puzzle room 1",
            "Sunken Ship, Area 05 (long stairwell with running Alley Rats)",
            "Sunken Ship, puzzle room 3",
            "Sunken Ship, Area 07 (puzzle room passageway branch room w/Shaman)",
            "Sunken Ship, Area 14 ____dummy",
            "Sunken Ship, puzzle room 4",
            "Sunken Ship, puzzle room 5",
            "Sunken Ship, post-KC Area 01 (small room w/Trampoline)",
            "Sea, Area 08 (shore with Sunken Ship)",
            "Sunken Ship, post-KC Area 05 (w/Dry Bones, linked by Mario mirror room)",
            "Sunken Ship, Area 08 (w/save point and green switch for barrel)",
            "Sunken Ship, Area 09 (Password room)",
            "Sunken Ship, post-KC Area 04 (long stairwell w/running Alley Rats)",
            "Sunken Ship, post-KC Area 06 (Mario Mirror room)",
            "Sunken Ship, post-KC Area 02 (small 2-level room)",
            "Sunken Ship, post-KC Area 03 (Alley Rats on cannons)",
            "Sunken Ship, post-KC Area 07 (three Dry Bones)",
            "Sunken Ship, post-KC Area 08 (secret room with Frog Coin)",
            "Sunken Ship, post-KC Area 09 (Hidon's room w/save point)",
            "Sunken Ship, post-KC Area 14 (secret Safety Ring)",
            "Sunken Ship, post-KC Area 18 (warp room from Johnny's room)",
            "Sunken Ship, post-KC Area 10 (water room with frog coins)",
            "Sunken Ship, post-KC Area 11 (water room with whirlpool)",
            "Mario's Pipehouse",
            "Mushroom Kingdom, during Mack, Outside",
            "Mushroom Kingdom, Outside",
            "Booster Tower, 9F Area 02 (Booster's curtain game room)",
            "Booster Tower, 2F Area 03 (steps w/circling Bob-ombs)",
            "Booster Tower, 2F Area 02 (Booster's railway room)",
            "Booster Tower, 6F Area 02 (Booster's Ancestor Game room)",
            "Booster Tower, 2F Area 01 (w/constantly appearing Spookums)",
            "Booster Tower, 1F Area 02 (high Masher room w/teeter-totter)",
            "Booster Tower, 8F Area 03 (3-level w/one Chomp)",
            "Booster Tower, 9F Area 01 (three yellow platforms w/save point)",
            "Booster Tower, 6F Area 03 (Elder's Room w/Chomp)",
            "Booster Tower, 6F Area 01 (small room w/save point)",
            "Booster Tower Entrance",
            "Mushroom Way, Area 01",
            "Mushroom Way, Area 02",
            "Mushroom Way, Area 03",
            "Bandit's Way, Area 05",
            "Bandit's Way, Area 02",
            "Seaside Town, during Yaridovich Outside",
            "Seaside Town, during Yaridovich Inn (1F)",
            "Seaside Town, during Yaridovich Inn (2F)",
            "Seaside Town, during Yaridovich Elder's House (1F)",
            "Seaside Town, during Yaridovich Elder's House (2F)",
            "Seaside Town, during Yaridovich Beetles Are Us/Bomb Shop",
            "Seaside Town, during Yaridovich Weapons and Armor Shop",
            "Seaside Town, during Yaridovich Health Food Store (left-most)",
            "Seaside Town, during Yaridovich Mushroom Boy Shop (middle)",
            "Seaside Town, during Yaridovich Accessory Shop (right-most)",
            "Seaside Town, during Yaridovich Shed (unused b/c inaccessible)",
            "GAME INTRO: Sea, shore with Sunken Ship",
            "Smithy Factory, Area 02 (w/save point)",
            "Smithy Factory, Area 04 (green switch w/Ameboids)",
            "Smithy Factory, Area 03 (Glum Reapers)",
            "Smithy Factory, Area 07 (Count Down's room)",
            "Forest Maze, Area 01",
            "Forest Maze, Area 05 (tree trunk Area)",
            "Forest Maze, Area 02",
            "Forest Maze, Area 09 (leads to 4-path maze)",
            "Forest Maze, Area 04",
            "Forest Maze, Area 06",
            "Forest Maze, 4-way path from Area 09",
            "Forest Maze, Secret entrance",
            "Forest Maze, Bowyer's practice pad",
            "Forest Maze, Area 03 (underground)",
            "Forest Maze, Secret",
            "Forest Maze, Area 08 (underground)",
            "Forest Maze, Area 07 (underground w/sleeping Wiggler)",
            "Smithy Factory, Area 05 (w/save point)",
            "Smithy Factory, fall from lugnut rooms (Area 06 & prior)",
            "Smithy Factory, Area 06 (Ultra Hammer)",
            "Volcano, Area 21 ____dummy",
            "Volcano, Area 02 ____dummy",
            "Forest Maze, all tree trunk underground areas",
            "GAME INTRO: Mushroom Kingdom Castle, Throne Room",
            "GAME INTRO: Yo'ster Isle, talk to Yoshi & run around",
            "GAME INTRO: Pipe Vault, Area 02 (w/Thwomp)",
            "GAME INTRO: Kero Sewers, Entrance",
            "GAME INTRO: Tadpole Pond, Mario summons tadpoles",
            "GAME INTRO: Mushroom Way, Area 01",
            "GAME INTRO: Vista Hill",
            "GAME INTRO: Booster Tower, balcony with Toadstool crying",
            "Bean Valley, piranha pipe Area",
            "Bean Valley, main Area",
            "Bean Valley, magic brick to Beanstalk Area",
            "Bean Valley, Smilax Area",
            "Monstro Town, Jinx's Dojo",
            "Forest Maze, Small area w/tree trunk (unused?)",
            "GAME INTRO: Forest Maze, fighting Magikoopa at Bowyer's Pad",
            "Booster Tower, Balcony at top floor",
            "Booster Tower, 3F Area 01 (green switch for BP secret)",
            "GAME INTRO: Forest Maze, jumping on Wiggler",
            "Bowser's Keep 1st time, Area 03 (lava room w/bridge)",
            "Land's End Underground, Area 04 (buy super stars)",
            "Land's End Underground, Area 01",
            "Land's End Underground, Area 02",
            "Land's End Underground, Area 03",
            "Bowser's Keep, Area 10 (Magikoopa's room)",
            "Monstro Town, entrance",
            "Belome Temple, Area 08 (Belome's room)",
            "ENDING CREDITS: Nimbus Land, Prince Mallow",
            "Land's End secret underground, Area 01 (leads to Kero Sewers)",
            "Moleville Mines, Area 17 (Punchinello's room)",
            "Moleville Mines, Area 11 (bombed room w/singing Moles)",
            "Moleville Mines, Area 04 (w/trampoline)",
            "Moleville Mines, Area 02",
            "Moleville Mines, Area 06 (small room leading to Area 06)",
            "Moleville Mines, Area 01 (entrance)",
            "Moleville Mines, Area 05 (left of trampoline room)",
            "Moleville Mines, Area 03 (leads back to Area 1)",
            "Moleville Mines, Area 08 (Croco's bombed room)",
            "Moleville Mines, Area 15 (2-level room w/Sparky and 10-coin TC)",
            "Moleville Mines, Area 07 (from Croco's bombed room)",
            "Moleville Mines, Area 10 (small room w/minecart tracks)",
            "Moleville Mines, Area 09 (leads left to Croco's bombed room)",
            "Moleville Mines, Area 18 (minecart room)",
            "Moleville Mines, Area 13 (long minecart tracks room)",
            "Moleville Mines, Area 12 (2-level room, leads to long minecart tracks room)",
            "Moleville Mines, Area 14 (2-level room from long minecart tracks room)",
            "Moleville Mines, Area 16 (large save-point room w/four Bob-ombs)",
            "Moleville Mines, Area 17 (Punchinello's room)",
            "Moleville Mines, Area 19 (from outside after paying)",
            "GAME INTRO: Booster Tower, 7F (parachuting Spookums)",
            "____unmapped house room",
            "____unmapped house room",
            "____unmapped house room",
            "____unmapped house room",
            "____unmapped house room",
            "____unmapped outside townplace (resembles Seaside Town)",
            "____unmapped house room",
            "____unmapped house room",
            "____unmapped house room",
            "Kero Sewers, Area 07 (water switch room w/Boos)",
            "Kero Sewers, Area 08 (Belome's Room)",
            "Kero Sewers, Area 08 (Belome's Room, after defeat)",
            "Seaside Town, Outside",
            "Seaside Town, Inn (1F)",
            "Seaside Town, Inn (2F)",
            "Seaside Town, Elder's house (1F)",
            "Seaside Town, Elder's house (2F)",
            "Seaside Town, Beetles Are Us",
            "Seaside Town, Weapon and Armor shop",
            "Seaside Town, Health Food Store",
            "Seaside Town, Mushroom Boy's Shop",
            "Seaside Town, Accessory Shop",
            "Seaside Town, Shed",
            "Seaside Town, during Yaridovich Beach",
            "Seaside Town, Beach",
            "Land's End Desert, Area 01",
            "Land's End Desert, Area 02",
            "Land's End Desert, Area 06",
            "Mushroom Kingdom Castle, Entrance to Throne room",
            "Bowser's Keep 6-door, Action Room 2-A (slow elevating platforms)",
            "Bowser's Keep 6-door, Action Room 1-A (jumping Terrapin)",
            "Mushroom Kingdom Castle, during Mack entrance to Throne Room",
            "Monstro Town, outside",
            "Mushroom Kingdom Castle, during Mack Main Hall",
            "Mushroom Kingdom Castle, during Mack Throne Room",
            "Mushroom Kingdom Castle, during Mack stairwell to Toadstool's Room",
            "Mushroom Kingdom Castle, during Mack Toadstool's Room",
            "Mushroom Kingdom Castle, during Mack branch room to Vault/Guest Room",
            "Mushroom Kingdom Castle, during Mack Guest room",
            "Mushroom Kingdom Castle, during Mack Vault",
            "Mushroom Kingdom Castle, during Mack entrance to Toadstool's room",
            "Kero Sewers Entrance",
            "Bean Valley pipe room, left-most pipe",
            "Bean Valley pipe room, right-most pipe (large room)",
            "Moleville, Item Shop",
            "Moleville, Inn",
            "Moleville, Dyna and Mite's house",
            "Moleville, Fireworks shop",
            "Moleville, Special item-trading shop",
            "Nimbus Land, Garro's House",
            "Nimbus Land, lower house",
            "Nimbus Land, Inn",
            "Nimbus Land, Item Shop",
            "Nimbus Land, top-right house (Croco drops Signal Ring)",
            "Nimbus Land, Inn (bedroom)",
            "Bean Valley pipe room, top pipe (leads to Grate Guy's Casino)",
            "Bean Valley pipe room, bottom left",
            "Bean Valley pipe room, bottom right",
            "Smithy Factory, Area 01",
            "Culex's Room",
            "Volcano, Area 21 (Czar Dragon's room)",
            "Volcano, Area 18 (Hino Mart)",
            "Volcano, Area 01",
            "Volcano, Area 03 (secret w/two flowers)",
            "Volcano, Area 08",
            "Volcano, Post-CD Area 01",
            "Volcano, Area 11",
            "Volcano, Area 02",
            "Volcano, Area 04 (bunch of steps)",
            "Volcano, Area 09",
            "Volcano, Area 07 (stomping Corkpedite)",
            "Volcano, Area 15 (stomping Corkpedite)",
            "Volcano, Area 14",
            "Volcano, Post-CD Area 03",
            "Volcano, Area 13 (w/save point)",
            "Volcano, Area 17 (leads to Hinopio's Shop)",
            "Nimbus Land, Royal Bus station",
            "Nimbus Land, entrance (w/warp trampoline)",
            "Nimbus Land, entrance to hot springs",
            "Nimbus Land, fall from platform (1st)",
            "Nimbus Land, fall from platform (2nd)",
            "Nimbus Land, fall from platform (3rd)",
            "Nimbus Land, fall from platform (4th)",
            "ENDING CREDITS: Star Pieces shoot through the sky",
            "Bowser's Keep 6-door, Battle Room 2-B (1st fight: Chewy)",
            "Bowser's Keep 6-door, Battle Room 2-C (1st fight: Sparky)",
            "Bean Valley Beanstalks, Area 01",
            "Bean Valley Beanstalks, Area 02",
            "Bean Valley Beanstalks, Area 03 (from right beanstalk of Area 02)",
            "Bean Valley Beanstalks, Area 04 (from left beanstalk of Area 02)",
            "Nimbus Land, entrance (no trampolines/exits)",
            "Volcano, Area 10 (jumping Pyrospheres)",
            "Volcano, Area 05",
            "Volcano, Area 06",
            "Volcano, Area 12 (erupting Stumpet)",
            "Volcano, Area 19 (from Hino Mart w/save point)",
            "Volcano, Post-CD Area 02",
            "Volcano, Area 20 (jumping Pyrospheres)",
            "Volcano, Area 16 (erupting Stumpet)",
            "Volcano, Post-CD Area 04",
            "Volcano, Post-CD Area 06",
            "Volcano, Post-CD Area 07 (warp to World Map)",
            "Volcano, Post-CD Area 05",
            "Monstro Town, Monstermama's house (1F)",
            "Monstro Town, Monstermama's house (2F)",
            "Monstro Town, super-jumping room",
            "Monstro Town, Weapon and Armor Shop",
            "Monstro Town, 3 Musty Fears Inn",
            "Bowser's Keep, Area 13 (2nd throne room, Boomer's room)",
            "Land's End secret underground, Area 02 (leads to Kero Sewers)",
            "Land's End Desert, Area 03",
            "Land's End Desert, Area 05",
            "Land's End Desert, Area 04",
            "Booster Pass, Secret",
            "Factory Grounds, Area 01 (with Toad)",
            "Land's End Cliff (climb w/Sky Troopas)",
            "Nimbus Castle, Area 14 (right-most front door of long 5-exit room) ",
            "Nimbus Castle, Area 09 (Birdo's Room)",
            "Nimbus Castle, Area 07 (straight from Area 06 w/long staircase)",
            "Nimbus Castle, path after Throne room (1st)",
            "Nimbus Castle, Area 11 (long hallway, door to King's Cellar)",
            "Nimbus Castle, King's locked cellar",
            "Nimbus Castle, Area 08 (from Area 07, get Room Key 1 here)",
            "Nimbus Land, small platform after Nimbus Castle throne paths",
            "Nimbus Land, outside (before Valentina)",
            "Gardener's House, outside",
            "Gardener's House",
            "Lazy Shell cloud",
            "Belome Temple, Area 02 (Fortune Room)",
            "Belome Temple, Area 04 (room determined by fortune)",
            "Belome Temple, Area 09 (Belome's Treasure room)",
            "Belome Temple, Area 06 (Belome's fortune room w/elevating platform)",
            "Belome Temple, Area 03 (pipe to room determined by fortune)",
            "Belome Temple, Area 05 (from Fortune Room)",
            "Belome Temple, Area 07 (pipe to Belome's room)",
            "Belome Temple, Area 10 (pipe to Monstro Town)",
            "Belome Temple, Area 01 (w/Warp Trampoline)",
            "GAME INTRO: Nimbus Land, outside with patrolling Birdies",
            "Nimbus Land, outside (during Valentina)",
            "Bowser's Keep 6-door, Puzzle Rooms",
            "ENDING CREDITS: Johnny looking out at sunset on beach shore",
            "Smithy Factory, Area 01 ____dummy",
            "Smithy Factory, Area 09 (falling Axem Reds on conveyor belts)",
            "ENDING CREDITS: Bowser's Keep, Bowser & troops repair",
            "Smithy Factory, Area 01 ____dummy",
            "Nimbus Castle, path after Throne room (3rd)",
            "Nimbus Land, outside (after Valentina)",
            "Bowser's Keep, outside (talk to Exor)",
            "Nimbus Castle, Area 13 (Throne room, after Valentina)",
            "ENDING CREDITS: Toadofsky conducts choir",
            "Smithy Factory, Area 11 (conveyor belts spawning Drill Bits and Macks)",
            "Smithy Factory, Area 16 (small room w/two treasures after falling Yaridovich room)",
            "Smithy Factory, Area 09 ____dummy",
            "Smithy Factory, Area 10 (fall from Area 09)",
            "Bowser's Keep 6-door, exit room after finishing 4 doors",
            "Nimbus Land, hot springs",
            "Bowser's Keep, Area 09 (tall room, w/save point)",
            "Bowser's Keep, Area 11 (Thwomp/Bullet room after Magikoopa's room)",
            "Bowser's Keep, Area 12 (Croco's Shop 2, after Magikoopa's room)",
            "Bowser's Keep, Area 07 (150 coins and a mushroom)",
            "Bowser's Keep, Area 06 (save point w/Croco shop)",
            "Bowser's Keep, Area 05 (dark tunnel, after throne room)",
            "Bowser's Keep, Area 08 (room with 6 doors)",
            "Bowser's Keep 6-door, Action Room 1-C (Gorilla throwing barrels)",
            "Bowser's Keep 6-door, Action Room 2-B (cannonball riding)",
            "Bowser's Keep 6-door, Action Room 2-C (very slow moving circling platforms)",
            "Bowser's Keep 6-door, Action Room 1-B (moving platforms)",
            "Bowser's Keep 6-door, Battle Room 1-A (1st fight: Terra Cotta)",
            "Bowser's Keep 6-door, Battle Room 1-B (1st fight: Alley Rat)",
            "Bowser's Keep 6-door, Battle Room 1-C (1st fight: Bob-Omb)",
            "Bowser's Keep 6-door, Battle Room 2-A (1st fight: Gu Goomba)",
            "Bowser's Keep 6-door, Puzzle Room 1-B (barrel-counting)",
            "Bowser's Keep 6-door, Puzzle Room 1-A (quiz)",
            "Bowser's Keep 6-door, Puzzle Room 2-B (green switches)",
            "Bowser's Keep 6-door, Puzzle Room 1-C (word problem)",
            "Bowser's Keep 6-door, Puzzle Room 2-A (coin collecting)",
            "Bowser's Keep 6-door, Puzzle Room 2-C (ball solitaire)",
            "Factory Grounds, Area 01",
            "Factory Grounds, Area 04 (Gun Yolk's room)",
            "Factory Grounds, Area 02",
            "Factory Grounds, Area 03",
            "Smithy Factory, Area 13 (Bowyers falling down conveyor belts)",
            "Smithy Factory, Area 15 (falling Yaridovichs)",
            "Smithy Factory, Area 12 (lots of consecutive conveyor belts and LIL~BOOS)",
            "Bowser's Keep 2nd Time, Area 01",
            "Bowser's Keep 2nd Time, Area 02",
            "Bowser's Keep 2nd Time, Area 03 (lava room w/bridge)",
            "Bowser's Keep 2nd Time, Area 04 (Throne Room)",
            "Mushroom Kingdom, during Mack, jumping kid's house (1F)",
            "Mushroom Kingdom, during Mack, jumping kid's house (2F)",
            "Mushroom Kingdom, during Mack, Raz and Raini's house",
            "Mushroom Kingdom, during Mack, Item Shop (top floor)",
            "Mushroom Kingdom, during Mack, Item Shop (basement)",
            "Mushroom Kingdom, during Mack, Inn (1F)",
            "ENDING CREDITS: Star Pieces (Rose Town), last star piece to ‘Thank You'",
            "Mushroom Kingdom, during Mack, running kid's house",
            "Mushroom Kingdom, jumping kid's house (1F)",
            "Mushroom Kingdom, jumping kid's house (2F)",
            "Mushroom Kingdom, Raz and Raini's house",
            "Mushroom Kingdom, Item Shop (top floor)",
            "Mushroom Kingdom, Item Shop (basement)",
            "Mushroom Kingdom, Inn (1F)",
            "Mushroom Kingdom, Inn (2F)",
            "Mushroom Kingdom, running kid's house",
            "Factory Grounds, fight with Smithy (uses Sledge)",
            "Nimbus Castle, Area 06 ____dummy",
            "Nimbus Castle, Area 10 ____dummy",
            "Nimbus Castle, Area 05 (long 5-exit room, after Valentina)",
            "Nimbus Castle, Area 04 ____dummy",
            "Nimbus Castle, Area 03 (4-way path, after Valentina)",
            "Nimbus Land, Dream Cushion Dream: small cloud, person cheers on Mario/bed floats",
            "Nimbus Land, Dream Cushion Dream: Heavy Troopa laying on Mario",
            "Nimbus Land, Dream Cushion Dream: Tortes are seasoning Mario",
            "ENDING CREDITS: Yo'ster Isle, Croco racing Yoshi",
            "ENDING CREDITS: Marrymore Chapel, Booster wedding Valentina",
            "Smithy Factory, Area 08 (Trampoline after Count Down)",
            "Smithy Factory, Area 14 (w/save point)",
            "Factory Grounds, Smithy's Pad" 
        };
        public static string[] GraphicSetNames = new string[]
        {
            "{NONE}",
            "Keep walls",
            "Keep wall decor",
            "Keep doormat, doors",
            "Rope bridge, lava",
            "Keep window grates",
            "Gargoyles and pillars",
            "Barrel Volcano",
            "Royal Bus",
            "Kingdom houses",
            "Castle exterior",
            "Castle doors, fireplace",
            "Keep turrets",
            "Keep gargoyle hill",
            "Keep ground",
            "Keep body",
            "Keep body edges",
            "House interior",
            "Grates, stoves",
            "Crates, boxes",
            "Beds",
            "Shacks interior",
            "House exterior",
            "House doors",
            "Mines plywood",
            "Mines crates, lanterns",
            "Town decor",
            "Castle walls",
            "Castle wall decor",
            "Castle interior",
            "Tower wall decor",
            "Tower curtains",
            "Casino interior",
            "Tower floor",
            "____",
            "Forest terrain",
            "Forest tree trunks",
            "Forest battlefield",
            "Forest dirt",
            "Seashells",
            "Ship walls,doors",
            "Ship interior",
            "Ship pipes",
            "Shark emblem",
            "Doors",
            "Desert decor",
            "____",
            "Temple floors",
            "Temple walls",
            "Temple pillars",
            "Temple steps",
            "Shacks",
            "Mountain",
            "Mountain decor",
            "Mines floor",
            "Mines railing",
            "Stalactites/stalagmites",
            "Molten lava",
            "Arrow signs",
            "Palm trees, hills 1",
            "Palm trees, seat",
            "Seashore rocks",
            "Seashore cliffs",
            "Dojo walls, floor",
            "Grassland hills",
            "Grassland grass",
            "Grassland ground",
            "Pipehouse roof",
            "Pipehouse porch",
            "Tower, exterior",
            "Tower, entrance 1",
            "____",
            "Palm trees, hills 2",
            "Tower, entrance 2",
            "Seashore Ship",
            "Yo’ster Isle",
            "Marrymore Scene",
            "Ground puddle",
            "Plains hills, trees",
            "Plains ground, rock",
            "Rotating flowers",
            "Countryside",
            "____",
            "Plains escarpment",
            "Booster Hill sand",
            "Booster Hill cactus",
            "Booster Hill BG",
            "Nimbus Castle, exterior",
            "Nimbus leaves",
            "Nimbus leaves, briar",
            "Exor Battlefield",
            "Exor's hilt",
            "Exor's head",
            "Exor's face",
            "Exor's arms",
            "Ground/Mist",
            "“Hollow” sign",
            "Nimbus exterior",
            "Nimbus Castle walls",
            "Nimbus Castle interior 1",
            "Nimbus Castle interior 2",
            "Smithy Factory, floor",
            "Smithy Factory, pillar top",
            "Smithy Factory, pillar lower",
            "Smithy Factory, pillar floor",
            "Conveyor belts",
            "Seashore Ship, seafloor",
            "Sanctuary walls",
            "Sanctuary organ",
            "Nimbus house interior 1",
            "Nimbus house interior 2",
            "The Blade",
            "Shelly, nest",
            "Birdo's egg, nest",
            "Keep, throne walls",
            "Keep, throne steps",
            "Keep, throne floor",
            "Keep, throne gargoyles",
            "Chandeliers",
            "____",
            "River water",
            "Star Hill exterior",
            "Star Hill decor",
            "Vista Hill Keep",
            "Beanstalks",
            "Seashore Sunset",
            "Factory floor, crane",
            "Factory structures",
            "Stump battlefield top",
            "Stump battlefield lower",
            "Factory conveyor belts",
            "Mist/clouds",
            "Beanstalk leaf (top)",
            "Beanstalk leaf (lower)",
            "Beanstalk vine (top)",
            "Beanstalk leaf (right)",
            "Ship cellar (top)",
            "Ship cellar (bottom)",
            "Ship, barrels",
            "Mines interior",
            "Factory walls",
            "Keep repairs",
            "Czar Dragon gargoyles",
            "Grasslands grass",
            "Grasslands hills",
            "Mountain bushes",
            "House interior corners",
            "Tower, backdoor",
            "Water sewer walls",
            "Tower balcony clouds",
            "Beanstalk leaf (left)",
            "Castle candle holders",
            "Beanstalk clouds",
            "Dirt mountains",
            "Dirt mountains",
            "Tower balcony top",
            "Tower balcony lower",
            "Countdown",
            "Sewers back wall",
            "____palette tiles",
            "Nimbus Castle interior 3",
            "Birdo's nest egg",
            "Birdo's nest",
            "Nimbus briar",
            "Nimbus leaves",
            "____forest vines",
            "____unknown",
            "Town 2, exterior",
            "Keep carpet, walls",
            "Town 2, decor",
            "Forest path",
            "Level-Up FG",
            "Menu BG 1",
            "Menu BG 2",
            "Plains palm trees",
            "Sea Enclave",
            "Sanctuary organ",
            "Level-Up BG",
            "Star Hill",
            "Beach rocks, sunset",
            "Blade Roof",
            "Blade Roof, BG",
            "Blade Roof, BG",
            "Giant snake body",
            "Desert cactus, floor",
            "Factory floor/walls",
            "Factory chains/bolts",
            "Factory structure",
            "Smithy 2, head/pipes",
            "Smithy 2, small heads",
            "Smithy 2, big heads",
            "Culex battlefield BG",
            "Factory metals",
            "Factory chains/bolts",
            "Nimbus throne",
            "Yo’ster Isle flowers",
            "Desk, floors, boxes",
            "Count Down",
            "____",
            "Vista Hill Exor"
        };
        public static string[] TileSetL3Names = new string[]
        {
            "{NOTHING}",
            "Booster Tower",
            "Mansion, inside",
            "Forest Maze",
            "Sunken Ship",
            "Kero Sewers",
            "____",
            "Water",
            "Grasslands",
            "River",
            "____",
            "Waterfall",
            "Clouds",
            "Yo\'ster Isle",
            "Maps",
            "Towns 2",
            "Sewers",
            "Houses, inside",
            "Grasslands 2",
            "Keep, throne",
            "Booster Hill",
            "Star Hill",
            "Marrymore Scene",
            "Nimbus Land",
            "Keep, inside",
            "Temples",
            "Desert",
            "____",
            "Smithy Factory",
            "____",
            "Smithy 2",
            "____",
            "____",
            "____"        
        };
        public static string[] TileSetNames = new string[]
        {
            "Houses, inside  (L1)",
            "Houses, inside  (L2)",
            "____",
            "Keep, puzzles (L2)",
            "Towns 1 (L1)",
            "Towns 1 (L2)",
            "Grasslands 1 (L1)",
            "Towns 2 (L1)",
            "Towns 2 (L2)",
            "Sewers (L1)",
            "Sewers (L2)",
            "Keep, outside (L1)",
            "____",
            "____",
            "Tower, entrance (L1)",
            "Tower, entrance (L2)",
            "Keep, puzzles (L1)",
            "Keep, inside (L1,2)",
            "Pipe Rooms (L1,2)",
            "Mansion (L1)",
            "Mansion (L2)",
            "Forest Maze (L1)",
            "Forest Maze (L2)",
            "Sunken Ship (L1)",
            "Sunken Ship (L2)",
            "Mountains (L1)",
            "Mountains (L2)",
            "Underground (L1,2)",
            "Underground (L1,2)",
            "Tower, inside (L1)",
            "Tower, inside (L2)",
            "Seashore (L1)",
            "Seashore (L2)",
            "Plains (L1,2)",
            "Underground 2 (L1)",
            "Underground 2 (L2)",
            "Riverside (L1)",
            "Riverside (L2)",
            "Clouds (L1)",
            "Clouds (L2)",
            "____",
            "Culex (L1)",
            "Culex (L2)",
            "Grasslands 2 (L1)",
            "Grasslands 2 (L2)",
            "Waterfall (L1)",
            "Waterfall (L2)",
            "Nimbus Castle (L1)",
            "Nimbus Castle (L2)",
            "Yo'ster Isle (L1)",
            "Yo'ster Isle (L2)",
            "Smithy Factory (L1,2)",
            "____",
            "____",
            "Count Down (L1)",
            "____",
            "Sanctuary (L1)",
            "Sanctuary (L2)",
            "Keep, inside (L1,2)",
            "____",
            "____",
            "Shacks (L1)",
            "Grasslands 1 (L2)",
            "Keep, outside (L2)",
            "Keep, throne (L1)",
            "Keep, throne (L2)",
            "Keep, inside (L1)",
            "Keep, inside (L2)",
            "Midas River (L2)",
            "Water Tunnels (L1)",
            "Water Tunnels (L2)",
            "Suite (L1)",
            "Volcano Map (L1)",
            "Star Hill (L1,2)",
            "Vista Hill (L1,2)",
            "Marrymore Scene (L1,2)",
            "Tower Balcony (L1,2)",
            "Bean Valley (L1)",
            "Bean Valley (L2)",
            "Nimbus Land (L1)",
            "Nimbus Land (L2)",
            "Volcano, Map (L2)",
            "Jinx's Dojo (L1,2)",
            "Factory Grounds (L1,2)",
            "____",
            "Ending, Seashore (L1,2)",
            "Ending, Keep (L1,2)",
            "Ending, Toadofsky (L1)",
            "Ending, Toadofsky (L2)",
            "____",
            "Ending, Yo'ster Isle (L1)",
            "Ending, Yo'ster Isle (L2)",
            "____"
        };
        public static string[] TileMapNames = new string[]
        {
            "Bowser’s Keep, outside (L2)",
            "____",
            "Chapel Kitchen (L1)",
            "Chapel Kitchen (L2)",
            "Land's End 1 (L1)",
            "Land's End 1 (L2)",
            "Booster Tower 1 (L1)",
            "Booster Tower 1 (L2)",
            "____",
            "____",
            "Mushroom Kingdom houses (L1)",
            "Mushroom Kingdom houses (L2)",
            "Mario's Pad, outside (L1)",
            "Mario's Pad, outside (L2)",
            "Grate Guy's Casino, outside (L1)",
            "Grate Guy's Casino, outside (L2)",
            "Bowser's Keep 1 (L1)",
            "Bowser's Keep 1 (L2)",
            "Forest Maze 1 (L1)",
            "Forest Maze 1 (L2)",
            "____",
            "____",
            "Rose Town (L1)",
            "Rose Town (L2)",
            "Kero Sewers 1 (L1)",
            "Kero Sewers 1 (L2)",
            "____",
            "____",
            "Tadpole Pond 1 (L1)",
            "Tadpole Pond 1 (L2)",
            "Beach (L1)",
            "Beach (L2)",
            "Castle Rooms (L1)",
            "Castle Rooms (L2)",
            "Sunken Ship 1 (L1)",
            "Sunken Ship 1 (L2)",
            "Forest Maze 1 (L1)",
            "Forest Maze 1 (L2)",
            "Forest Maze 2 (L1)",
            "Forest Maze 2 (L2)",
            "Forest Maze 3 (L1)",
            "Forest Maze 3 (L2)",
            "____",
            "____",
            "Sunken Ship 2 (L1)",
            "Sunken Ship 2 (L2)",
            "Debug Room (L1)",
            "Debug Room (L2)",
            "Barrel Volcano 1 (L1)",
            "Barrel Volcano 1 (L2)",
            "Barrel Volcano 2 (L1)",
            "Barrel Volcano 2 (L2)",
            "Kero Sewers 2 (L1)",
            "Kero Sewers 2 (L2)",
            "Rose Town houses (L1)",
            "Rose Town houses (L2)",
            "Booster Pass secret (L1)",
            "Booster Pass secret (L2)",
            "Booster Tower entrance (L1)",
            "Booster Tower entrance (L2)",
            "Seashore (L1)",
            "Seashore (L2)",
            "Booster Tower 1 (L1)",
            "Booster Tower 1 (L2)",
            "Mushroom Kingdom (L1)",
            "Mushroom Kingdom (L2)",
            "Bowser's Keep outside(L1)",
            "____",
            "Seaside Town houses (L1)",
            "Seaside Town houses (L2)",
            "Moleville shacks (L1)",
            "Moleville shacks (L2)",
            "Forest Maze underground (L1)",
            "Forest Maze underground (L2)",
            "Forest Maze, area 7 (L1)",
            "Forest Maze, area 7 (L2)",
            "Land's End underground (L1)",
            "Land's End underground (L2)",
            "Moleville Mines 1 (L1)",
            "Moleville Mines 1 (L2)",
            "____",
            "____",
            "____",
            "____",
            "Land's End grasslands (L1)",
            "Land's End grasslands (L2)",
            "Moleville Mines 2 (L1)",
            "Moleville Mines 2 (L2)",
            "Moleville Mines 3 (L1)",
            "Moleville Mines 3 (L2)",
            "____",
            "____",
            "Plains (L1)",
            "Plains (L2)",
            "Booster Hill (L1)",
            "Booster Hill (L2)",
            "Tadpole Pond 2 (L1)",
            "Tadpole Pond 2 (L2)",
            "Clouds (L1)",
            "Clouds (L2)",
            "____",
            "____",
            "Bowser's Keep 2 (L1)",
            "Bowser's Keep 2 (L2)",
            "___forest (L1)",
            "___forest (L2)",
            "Midas River (L1)",
            "Midas River (L2)",
            "Yo'ster Isle (L1)",
            "Yo'ster Isle (L2)",
            "Suite (L1)",
            "Suite (L2)",
            "Waterfall (L1)",
            "Waterfall (L2)",
            "___underground (L1)",
            "___underground (L2)",
            "Rose Way (L1)",
            "Rose Way (L2)",
            "____",
            "____",
            "Marrymore (L1)",
            "Marrymore (L2)",
            "Nimbus Castle 1 (L1)",
            "Nimbus Castle 1 (L2)",
            "Nimbus Castle 2 (L1)",
            "Nimbus Castle 2 (L2)",
            "Bowser's Keep Bridge (L1)",
            "Bowser's Keep Bridge (L2)",
            "Sea (L1)",
            "Sea (L2)",
            "Pipe Vault (L1)",
            "Pipe Vault (L2)",
            "____",
            "____",
            "Booster Tower balcony (L1)",
            "Beanstalks (L1)",
            "Smithy Factory 1 (L1)",
            "Smithy Factory 1 (L2)",
            "Smithy Factory 2 (L1)",
            "Smithy Factory 2 (L2)",
            "Smithy Factory 3 (L1)",
            "Smithy Factory 3 (L2)",
            "Nimbus Land houses (L1)",
            "Nimbus Land houses (L2)",
            "Star Hill 2 (L1)",
            "Star Hill 2 (L2)",
            "Bean Valley pipes (L1)",
            "Bean Valley pipes (L2)",
            "____",
            "____",
            "Chapel, main hall (L1)",
            "Chapel, main hall (L2)",
            "Chapel sanctuary (L1)",
            "Chapel sanctuary (L2)",
            "Belome Temple 1 (L1)",
            "Belome Temple 1 (L2)",
            "____",
            "____",
            "____",
            "____",
            "Bandit's Way 1 (L1)",
            "Bandit's Way 1 (L2)",
            "Bandit's Way 2 (L1)",
            "Bandit's Way 2 (L2)",
            "Mario's Pipehouse (L1)",
            "Mario's Pipehouse (L2)",
            "Mushroom Way 1 (L1)",
            "Mushroom Way 1 (L2)",
            "____",
            "____",
            "Kero Sewers, area 1 (L1)",
            "Kero Sewers, area 1 (L2)",
            "Rose Way, area 1 (L1)",
            "Rose Way, area 2 (L2)",
            "Midas River tunnels (L1)",
            "Midas River tunnels (L2)",
            "Booster Pass 1 (L1)",
            "Booster Pass 1 (L2)",
            "Moleville (L1)",
            "Moleville (L2)",
            "Volcano Map (L1)",
            "Volcano Map (L2)",
            "Sunken Ship 3 (L1)",
            "Sunken Ship 3 (L2)",
            "Vista Hill (L1)",
            "Vista Hill (L2)",
            "Marrymore Scene (L1)",
            "Marrymore Scene (L2)",
            "Bean Valley (L1)",
            "Bean Valley (L2)",
            "Beanstalks (L2)",
            "Land's End Underground 2 (L1)",
            "Land's End Underground 2 (L2)",
            "Land's End Desert (L1)",
            "Land's End Desert (L2)",
            "Barrel Volcano 1 (L1)",
            "Barrel Volcano 1 (L2)",
            "Jinx's Dojo (L1)",
            "Factory Grounds 1 (L1)",
            "Monstro Town houses (L1)",
            "Monstro Town houses (L2)",
            "Monstro Town (L1)",
            "Monstro Town (L2)",
            "Bowser's Keep 6-doors 1 (L1)",
            "Bowser's Keep 6-doors 1 (L2)",
            "Culex's Room (L1)",
            "Culex's Room (L2)",
            "Bowser's Keep 6-doors 2 (L1)",
            "Bowser's Keep 6-doors 2 (L2)",
            "Bowser's Keep 3 (L1)",
            "Bowser's Keep 3 (L2)",
            "Bowser's Keep 6-doors 3 (L1)",
            "Bowser's Keep 6-doors 3 (L2)",
            "Bowser's Keep, Magikoopa (L1)",
            "Bowser's Keep, Magikoopa (L1)",
            "Bowser's Keep 6-doors 4 (L1)",
            "Bowser's Keep 6-doors 4 (L2)",
            "Bowser's Keep 6-doors 5 (L1)",
            "Bowser's Keep 6-doors 5 (L2)",
            "Ending: Seashore (L1 & 2)",
            "Factory Grounds 1 (L2)",
            "Factory Grounds 2 (L1)",
            "Factory Grounds 2 (L2)",
            "Ending: Keep repairs (L1)",
            "Ending: Keep repairs (L2)",
            "Ending: Toadofsky (L1)",
            "Ending: Toadofsky (L2)",
            "Bowser's Keep 4 (L1)",
            "Bowser's Keep 4 (L2)",
            "Nimbus clouds 2 (L1)",
            "Nimbus clouds 2 (L2)",
            "Smithy Factory 4 (L1)",
            "Smithy Factory 4 (L2)",
            "____",
            "Ending: Yo'ster Isle (L1)",
            "Ending: Yo'ster Isle (L2)",
            "____",
            "___nothing (L1)",
            "___nothing (L2)",
            "Grate Guy's Casino (L1)",
            "Grate Guy's Casino (L2)",
            "Star Hill 1 (L1)",
            "Star Hill 1 (L2)",
            "____",
            "____"
        };
        public static string[] TileMapL3Names = new string[]
        {
            "{NOTHING}",
            "Booster\'s Tower 1 ",
            "Tadpole Pond 2 ",
            "Mushroom Kingdom Castle ",
            "Forest Maze 1",
            "Forest Maze 2",
            "Sunken Ship 1 ",
            "Kero Sewers 1",
            "Sunken Ship 2 ",
            "Booster\'s Tower 2 ",
            "____",
            "Seashore",
            "Midas River ",
            "____",
            "Waterfall ",
            "____",
            "various areas…",
            "Sea",
            "Tadpole Pond 1 ",
            "Nimbus Clouds",
            "Chapel, main hall ",
            "Plains",
            "Yo\'ster Isle ",
            "Maps",
            "Mushroom Kingdom",
            "Sewers",
            "Pipehouse ",
            "Houses 1",
            "Bowser\'s Keep Throne",
            "Rose Way, area 1 ",
            "Houses 2",
            "____",
            "Rose Way",
            "Moleville shacks ",
            "Houses 3",
            "Suite",
            "Sunken Ship 3",
            "Star Hill 2",
            "Vista Hill ",
            "Seaside Town beach ",
            "Grasslands 2",
            "Marrymore Scene",
            "____",
            "Nimbus Land houses ",
            "Jinx\'s Dojo ",
            "Monstro Town houses",
            "Bowser\'s Keep 6-doors 1",
            "Pipe Rooms",
            "Culex\'s Room ",
            "Bowser\'s Keep 6-doors 2",
            "Bowser\'s Keep 2",
            "Bowser\'s Keep 3",
            "Bowser\'s Keep 6-doors 3",
            "Bowser\'s Keep 6-doors 4",
            "Belome Temple",
            "Land\'s End Desert",
            "Bowser\'s Keep 4",
            "Nimbus Land springs ",
            "Smithy Factory",
            "____",
            "Smithy 2",
            "___nothing",
            "Star Hill 1",
            "____"};
        public static string[] SolidityMapNames = new string[]
        {
            "Debug Room",
            "{NOTHING}",
            "Kero Sewers 1",
            "Bowser\'s Keep 1",
            "____",
            "Mushroom Kingdom Castle",
            "____",
            "____",
            "Gardener\'s House",
            "Seaside Town",
            "____",
            "Forest Maze 3",
            "Midas River, waterfall",
            "Forest Maze 4",
            "Rose Town",
            "____",
            "Forest Maze 2",
            "___underground areas",
            "Sunken Ship 1",
            "Sunken Ship 2",
            "Tadpole Pond 2",
            "____",
            "____",
            "Mushroom Kingdom",
            "Mushroom Kingdom houses",
            "Bowser\'s Keep Throne",
            "Booster\'s Tower 2",
            "Booster\'s Tower 1",
            "Booster\'s Tower entrance",
            "Rose Way",
            "Moleville Mines 1",
            "Moleville Mines 2",
            "Moleville Mines 3",
            "Seaside Town houses",
            "____",
            "Barrel Volcano 1",
            "Barrel Volcano 2",
            "Mario\'s Pad",
            "Rose Town houses",
            "Moleville shacks",
            "Kero Sewers 2",
            "____",
            "____",
            "Bowser\'s Keep 3",
            "Grate Guy\'s Casino",
            "Midas River",
            "Plains",
            "Grasslands",
            "Forest Maze Underground",
            "Forest Maze, area 7",
            "Land\'s End Underground",
            "Suite",
            "____",
            "Nimbus clouds",
            "Nimbus Castle 1",
            "Nimbus Castle 2",
            "Barrel Volcano 3",
            "____",
            "Sea",
            "Pipe Vault",
            "Seashore",
            "____",
            "Smithy Factory 2",
            "Smithy Factory 3",
            "Smithy Factory 1",
            "Tadpole Pond 1",
            "Nimbus Land houses",
            "Star Hill 2",
            "Pipe Rooms",
            "____",
            "____",
            "Chapel, main hall",
            "Chapel sanctuary",
            "Bowser\'s Keep Bridge",
            "Belome\'s Temple 1",
            "____",
            "____",
            "Bandit\'s Way 1",
            "Bandit\'s Way 2",
            "Pipehouse",
            "Mushroom Way 1",
            "____",
            "Kero Sewers 1",
            "Rose Way 1",
            "Waterfall tunnels",
            "Booster Pass 1",
            "Moleville",
            "Marrymore",
            "Marrymore houses",
            "Volcano map",
            "Sunken Ship 2",
            "Vista Hill",
            "Booster Hill",
            "Seaside Town beach",
            "Seaside Town",
            "Land\'s End 1",
            "Land\'s End 2",
            "Bean Valley",
            "Beanstalks",
            "____",
            "Land\'s End 3",
            "Land\'s End desert",
            "Monstro Town houses",
            "Monstro Town",
            "Jinx\'s Dojo",
            "Bowser’s Keep 6-door 1",
            "____",
            "Booster Pass secret",
            "Bowser\'s Keep 4",
            "Bowser\'s Keep 6-door 2",
            "Bowser\'s Keep Magikoopa",
            "Bowser\'s Keep 6-door 3",
            "Bowser\'s Keep 6-door 4",
            "Bowser\'s Keep 6-door 5",
            "Factory Grounds 1",
            "Factory Grounds 2",
            "Bowser\'s Keep 5",
            "Nimbus Clouds 2",
            "Smithy Factory 4",
            "Star Hill 1"};
        public static string[] PaletteSetNames = new string[]
        {
            "Bowser\'s Keep Throne",
            "____",
            "Moleville shacks",
            "Rose Town",
            "____",
            "____",
            "Grasslands 1",
            "____",
            "Bowser\'s Keep Lava",
            "Bowser\'s Keep, outside",
            "Mushroom Kingdom Castle",
            "Forest Maze",
            "Sunken Ship",
            "Sewers",
            "Mountains",
            "Mushroom Kingdom",
            "Marrymore",
            "____",
            "Booster Tower 1",
            "Underground",
            "Bowser\'s Keep 1",
            "Houses",
            "____",
            "____",
            "____",
            "Seaside Town",
            "Booster Tower entrance",
            "Seashore",
            "____",
            "Booster Hill",
            "Rose Way",
            "Nimbus Clouds",
            "Grasslands 2",
            "Culex\'s Room",
            "Plains 1",
            "Plains 2",
            "Nimbus Castle",
            "Grasslands 3",
            "Smithy Factory",
            "____",
            "Sea",
            "Tadpole Pond",
            "Yo\'ster Isle",
            "____",
            "Count Down",
            "Chapel Sanctuary",
            "Bowser\'s Keep Lava",
            "Pipe Rooms",
            "____",
            "Mushroom Kingdom dark",
            "Pipehouse",
            "Waterfall tunnels",
            "Rose Town houses",
            "Rose Town houses",
            "Sewers Gate",
            "Rose Town dark",
            "Booster Tower 2",
            "Suite",
            "Volcano Map",
            "Houses",
            "Star Hill",
            "Marrymore houses",
            "Sunken Ship 2",
            "Vista Hill",
            "Johnny\'s Room",
            "Marrymore Scene",
            "Booster Tower Balcony",
            "Bean Valley",
            "Nimbus Land houses",
            "Jinx\'s Dojo",
            "Monstro Town houses",
            "Monstro Town",
            "Bowser\'s Keep puzzles",
            "Beanstalks",
            "Land\'s End Desert",
            "Seashore sunset",
            "Belome Temple",
            "Nimbus Land",
            "Factory Grounds 2",
            "Factory Grounds 1",
            "Bowser\'s Keep repairs",
            "Nimbus Castle 2",
            "Ending: Toadofsky",
            "Nimbus Land springs",
            "Nimbus Land clouds",
            "Smithy 2",
            "____",
            "Ending: Yo\'ster Isle",
            "Smithy Pad",
            "____",
            "Ending: Nimbus Land",
            "Casino entrance",
            "Casino, inside",
            "Count Down"};
        #endregion
        #region Events
        public static int[][] EventListBoxOpcodes = new int[][]
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
                0x4C,0x4F,0xFB,0xFC,0xFD,0xFD,0xFD
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
                0x9B,0x9C,0x9D,0x9E,0xFD,0xFD,0xFD,0xFD
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
                0xFE,0xFF
            }
        };
        public static int[][] EventListBoxFDOpcodes = new int[][]
        {
            new int[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0x32,0x33,0x34,0x3D,0x3E,0xF9},
            new int[0x02],
            new int[]{0,0,0,0x4B,0x5B,0x64},
            new int[]{0,0,0,0,0,0x50,0x51,0x52,0x53,0x54,0x55,0x56,0x57,0x5C},
            new int[0x02],
            new int[0x04],
            new int[]{0,0,0,0,0x4A,0x4C,0x65},
            new int[0x08],
            new int[]{0,0,0,0,0x4D,0x4E,0x4F,0x66,0x67,0xF8},
            new int[0x06],
            new int[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0x30,0x31},
            new int[]{0,0,0,0,0,0,0,0,0,0,0,0,0x94,0x9C,0xA4,0xA5},
            new int[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0xB6,0xB7},
            new int[]
            {
                0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                0x58,0x59,0x5A,0x5D,0x5E,0xAC,0xB0,0xB1,0xB2,0xB3,0xB4,0xB5
            },
            new int[]{0,0,0x60,0x61},
            new int[0x02],
        };
        public static int[][] ActionListBoxOpcodes = new int[][]
            {
                new int[]   // 0
                {
                    0x00,0x01,0x02,0x03,0x04,0x05,0x06,0x07,
                    0x0A,0x0B,0x0C,0x13,0x15,0x3D,0x09,0xFD,
                    0xFD,0xFD,0xFD,0xFD
                },
                new int[]   // 1
                {
                    0x0D,0x0E,0x0F
                },
                new int[]   // 2
                {
                    0x08,0x10,0xD0
                },
                new int[]   // 3
                {
                    0x26,0x27,0x28
                },
                new int[]   // 4
                {
                    0x40,0x41,0x42,0x43,0x44,0x45,0x46,0x47,
                    0x48,0x4A,0x4B
                },
                new int[]   // 5
                {
                    0x50,0x51,0x52,0x53,0x54,0x55,0x56,0x57,
                    0x58,0x59,0x5A,0x5B,0x5C,0x5D,0x7E,0x7F
                },
                new int[]   // 6
                {
                    0x60,0x61,0x62,0x63,0x64,0x65,0x66,0x67,
                    0x68,0x69,0x6A,0x6B
                },
                new int[]   // 7
                {
                    0x70,0x71,0x72,0x73,0x74,0x75,0x76,0x77,
                    0x78,0x79,0x7A,0x7B,0x7C,0x7D
                },
                new int[]   // 8
                {
                    0x80,0x81,0x82,0x83,0x84,0x87,0x90,0x91,
                    0x92,0x93,0x94,0x95
                },
                new int[]   // 9
                {
                    0x9B,0x9C,0x9D,0x9E
                },
                new int[]   // 10
                {
                    0xA0,0xA4,0xA8,0xA9,0xAA,0xAB,0xB0,0xB1,
                    0xB2,0xB3,0xB5,0xB7,0xBB,0xBC,0xBD,0xC2,
                    0xD6,0xD8,0xDC,0xE0,0xE1,0xE4,0xE5,0xE8,
                    0xE9,0xFD
                },
                new int[]   // 11
                {
                    0xA3,0xA7,0xAC,0xAD,0xAE,0xAF,0xB4,0xB6,
                    0xB8,0xB9,0xBA,0xC0,0xC1,0xC3,0xC4,0xC5,
                    0xC6,0xCA,0xCB,0xDB,0xDF,0xE2,0xE3,0xE6,
                    0xE7,0xEA,0xEB,0xEC,0xED,0xEE,0xEF,0xFD,
                    0xFD,0xFD,0xFD,0xFD,0xFD
                },
                new int[]   // 12
                {
                    0xD2,0xD3,0xD4,0xD7
                },
                new int[]   // 13
                {
                    0xF2,0xF3,0xF4,0xF4,0xF6,0xF7,0xF8,0xFD,
                    0xFD,0xFD,0xFD,0xFD,0xFD,0xFD,0xFD,0xFD,
                    0xFD,0xFD
                },
                new int[]   // 14
                {
                    0xF0,0xF1
                },
                new int[]   // 15
                {
                    0xFE,0xFF
                }
            };
        public static int[][] ActionListBoxFDOpcodes = new int[][]
            {
                new int[]{
                    0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                    0x00,0x01,0x02,0x03,0x0F},
                new int[3],
                new int[3],
                new int[3],
                new int[11],
                new int[16],
                new int[12],
                new int[14],
                new int[12],
                new int[4],
                new int[]{
                    0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                    0,0,0,0,0,0,0,0,0,0,0,0xB6},
                new int[]{
                    0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                    0,0,0,0,0,0,0,0,0,0xB0,0xB1,0xB2,0xB3,0xB4,0xB5},
                new int[4],
                new int[]{
                    0,0,0,0,0,0,0,0x04,0x05,0x06,0x07,
                    0x08,0x09,0x0A,0x0B,0x0C,0x0D,0x0E},
                new int[2],
                new int[2],
            };
        public static string[] ActionListBoxNames(int index)
        {
            switch (index)
            {
                case 0:
                    return new string[] 
                    { 
                    "Visibility = true",			// 0x00
                    "Visibility = false",			// 0x01
                    "Seq playback = true",			// 0x02
                    "Seq playback = false",			// 0x03
                    "Infinite seq playback = true",			// 0x04
                    "Infinite seq playback = false",			// 0x05
                    "Fixed faced direction = true",			// 0x06
                    "Fixed faced direction = false",			// 0x07
                    "Solidity properties =...",			// 0x0A
                    "Solidity properties, set bits...",			// 0x0B
                    "Solidity properties, clear bits...",			// 0x0C
                    "Sprite priority, set =...",			// 0x13
                    "Movement properties |=...",			// 0x15
                    "If in air, jump to...",			// 0x3D
                    "Reset all properties",			// 0x09

                    /********FD OPTIONS********/

                    "Sprite shadow = true",			// 0x00
                    "Sprite shadow = false",			// 0x01
                    "Floating = false",			// 0x02
                    "Floating = true",			// 0x03
                    "Layer priority =...",			// 0x0F
                    };

                case 1:
                    return new string[] 
                    { 
                    "Palette index, set =...",			// 0x0D
                    "Palette index, shift =...",			// 0x0E
                    "Palette index, shift x1",			// 0x0F
                    };

                case 2:
                    return new string[] 
                    { 
                    "Seq playback, sprite +=...",			// 0x08
                    "Playback, set speed =...",			// 0x10
                    "Set action script =...",			// 0xD0
                    };

                case 3:
                    return new string[] 
                    { 
                    "Animation string A...",			// 0x26
                    "Animation string B...",			// 0x27
                    "Animation string C...",			// 0x28
                    };

                case 4:
                    return new string[] 
                    { 
                    "Shift x1 step east",			// 0x40
                    "Shift x1 step southeast",			// 0x41
                    "Shift x1 step south",			// 0x42
                    "Shift x1 step southwest",			// 0x43
                    "Shift x1 step west",			// 0x44
                    "Shift x1 step northwest",			// 0x45
                    "Shift x1 step north",			// 0x46
                    "Shift x1 step northeast",			// 0x47
                    "Shift x1 step in facing direction",			// 0x48
                    "Elevate x1 step up",			// 0x4A
                    "Elevate x1 step down",			// 0x4B
                    };

                case 5:
                    return new string[] 
                    { 
                    "Shift east, isometric units =...",			// 0x50
                    "Shift southeast, isometric units =...",			// 0x51
                    "Shift south, isometric units =...",			// 0x52
                    "Shift southwest, isometric units =...",			// 0x53
                    "Shift west, isometric units =...",			// 0x54
                    "Shift northwest, isometric units =...",			// 0x55
                    "Shift north, isometric units =...",			// 0x56
                    "Shift northeast, isometric units =...",			// 0x57
                    "Shift in facing direction, isometric units =...",			// 0x58
                    "Shift 20 isometric units in facing direction",			// 0x59
                    "Elevate up, isometric units =...",			// 0x5A
                    "Elevate down, isometric units =...",			// 0x5B
                    "Elevate 20 isometric units up",			// 0x5C
                    "Elevate 20 isometric units down",			// 0x5D
                    "Jump, isometric units =...",			// 0x7E
                    "Jump, 1px units =...",			// 0x7F
                    };

                case 6:
                    return new string[] 
                    { 
                    "Shift east, pixels =...",			// 0x60
                    "Shift southeast, pixels =...",			// 0x61
                    "Shift south, pixels =...",			// 0x62
                    "Shift southwest, pixels =...",			// 0x63
                    "Shift west, pixels =...",			// 0x64
                    "Shift northwest, pixels =...",			// 0x65
                    "Shift north, pixels =...",			// 0x66
                    "Shift northeast, pixels =...",			// 0x67
                    "Shift in facing direction, pixels =...",			// 0x68
                    "Shift 16px in facing direction",			// 0x69
                    "Elevate up, pixels =...",			// 0x6A
                    "Elevate down, pixels =...",			// 0x6B
                    };

                case 7:
                    return new string[] 
                    { 
                    "Face east",			// 0x70
                    "Face southeast",			// 0x71
                    "Face south",			// 0x72
                    "Face southwest",			// 0x73
                    "Face west",			// 0x74
                    "Face northwest",			// 0x75
                    "Face north",			// 0x76
                    "Face northeast",			// 0x77
                    "Face Mario",			// 0x78
                    "Turn clockwise 45°",			// 0x79
                    "Face random direction",			// 0x7A
                    "Turn clockwise 45° times...",			// 0x7B
                    "Face east",			// 0x7C
                    "Face southwest",			// 0x7D
                    };

                case 8:
                    return new string[] 
                    { 
                    "Shift to isometric coords...",			// 0x80
                    "Shift isometric units...",			// 0x81
                    "Transfer to isometric coords...",			// 0x82
                    "Transfer isometric units...",			// 0x83
                    "Transfer isometric pixels...",			// 0x84
                    "Transfer to coords of obj...",			// 0x87
                    "Bounce to isometric coords...",			// 0x90
                    "Bounce isometric units...",			// 0x91
                    "Transfer to isometric coords...",			// 0x92
                    "Transfer isometric units...",			// 0x93
                    "Transfer isometric pixels (facing)...",			// 0x94
                    "Transfer to other obj's isometric coords...",			// 0x95
                    };

                case 9:
                    return new string[] 
                    { 
                    "Playback stop, sound",			// 0x9B
                    "Playback start, sound =...",			// 0x9C
                    "Playback start (speaker balance), sound =...",			// 0x9D
                    "Playback fade-out sound, duration...",			// 0x9E
                    };

                case 10:
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
                    "Store to mem from mem $7000 (8-bit)...",         // 0xB5
                    "Store random # to mem...",			// 0xB7
                    "Store to mem from mem $7000 (16-bit)...",        // 0xBB
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

                    "Halve mem...",			// 0xB6
                    };

                case 11:
                    return new string[] 
                    { 
                    "Set mem @ $700C",			// 0xA3
                    "Clear mem @ $700C",			// 0xA7
                    "Mem $700C =...",			// 0xAC
                    "Mem $700C +=...",			// 0xAD
                    "Mem $700C increment",			// 0xAE
                    "Mem $700C decrement",			// 0xAF
                    "Mem $700C = mem...",			// 0xB4
                    "Mem $700C = random # less than...",			// 0xB6
                    "Mem $700C += mem...",			// 0xB8
                    "Mem $700C -= mem...",			// 0xB9
                    "Mem $700C = mem...",			// 0xBA
                    "Mem $700C compare to...",			// 0xC0
                    "Mem $700C compare to mem...",			// 0xC1
                    "Mem $700C = current level",			// 0xC3
                    "Mem $700C = object X coord...",			// 0xC4
                    "Mem $700C = object Y coord...",			// 0xC5
                    "Mem $700C = object Z coord...",			// 0xC6
                    "Mem $700C = held joypad register",			// 0xCA
                    "Mem $700C = tapped joypad register",			// 0xCB
                    "If mem $700C bit(s) set, jump to...",			// 0xDB
                    "If mem $700C bit(s) clear, jump to...",			// 0xDF
                    "If mem $700C =...",			// 0xE2
                    "If mem $700C !=...",			// 0xE3
                    "If mem $700C set, no bits...",			// 0xE6
                    "If mem $700C set, any bits...",			// 0xE7
                    "If equal to zero, jump to...",			// 0xEA
                    "If not equal to zero, jump to...",			// 0xEB
                    "If greater than / equal to, jump to...",			// 0xEC
                    "If less than, jump to...",			// 0xED
                    "If negative, jump to...",			// 0xEE
                    "If positive, jump to...",			// 0xEF

                    /********FD OPTIONS********/

                    "$700C, isolate bits =...",			// 0xB0
                    "$700C, set bits =...",			// 0xB1
                    "$700C, xor bits =...",			// 0xB2
                    "$700C, isolate bits, from mem...",			// 0xB3
                    "$700C, set bits, from mem...",			// 0xB4
                    "$700C, xor bits, from mem...",			// 0xB5
                    };

                case 12:
                    return new string[] 
                    { 
                    "Jump to...",			// 0xD2
                    "Jump to subroutine...",			// 0xD3
                    "Loop start, loop count...",			// 0xD4
                    "Loop end",			// 0xD7
                    };

                case 13:
                    return new string[] 
                    { 
                    "Set obj presence...",			// 0xF2
                    "Set obj event trigger...",			// 0xF3
                    "Set obj: mem $70A8, presence = true (current level)",			// 0xF4
                    "Set obj: mem $70A8, presence = false (current level)",			// 0xF4
                    "Set obj: mem $70A8, event trigger = true",			// 0xF6
                    "Set obj: mem $70A8, event trigger = false",			// 0xF7
                    "If object in level ..., presence =...",			// 0xF8

                    /********FD OPTIONS********/

                    "Obj mem $0E set bit 4",			// 0x04
                    "Obj mem $0E clear bit 4",			// 0x05
                    "Obj mem $0E set bit 5",			// 0x06
                    "Obj mem $0E clear bit 5",			// 0x07
                    "Obj mem $09 set bit 7",			// 0x08
                    "Obj mem $09 clear bit 7",			// 0x09
                    "Obj mem $08 set bit 4",			// 0x0A
                    "Obj mem $08 clear bit 3,4",			// 0x0B
                    "Obj mem $30 clear bit 4",			// 0x0C
                    "Obj mem $30 set bit 4",			// 0x0D
                    "Obj mem $09 clear bit 4,6, set bit 5",			// 0x0E
                    };

                case 14:
                    return new string[] 
                    { 
                    "Delay, frames (8-bit)...",			// 0xF0
                    "Delay, frames (16-bit)...",			// 0xF1
                    };

                case 15:
                    return new string[] 
                    { 
                    "Return queue",			// 0xFE
                    "Return queue all"			// 0xFF
                    };

                default:
                    return new string[] { };
            }
        }
        public static string[] EventListBoxNames(int index)
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
                    "Create NPC packet @ object coords...",			// 0x3E
                    "Create NPC packet @ Mario coords...",			// 0x3F
                    "If Mario on top of an object, jump to...",			// 0x42
                    "Set obj presence...",			// 0xF2
                    "Set obj event trigger...",			// 0xF3
                    "Set obj: mem $70A8, presence = true (current level)",			// 0xF4
                    "Set obj: mem $70A8, presence = false (current level)",			// 0xF5
                    "Set obj: mem $70A8, event trigger = true",			// 0xF6
                    "Set obj: mem $70A8, event trigger = false",			// 0xF7
                    "If object in level ..., presence =...",			// 0xF8

                    /********FD OPTIONS********/

                    "Remember last object",			// 0x32
                    "If running action script, object...",			// 0x33
                    "If underwater, object...",			// 0x34
                    "If in air, object...",			// 0x3D
                    "Create NPC packet with event @ Mario coords...",			// 0x3E
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
                    "HP -= mem $7000, character...",			// 0x56

                    /********FD OPTIONS********/

                    "Experience += experience packet data",			// 0x4B
                    "Restore all HP",			// 0x5B
                    "Experience packet = mem $7000"			// 0x64
                    };

                case 3:
                    return new string[] 
                    { 
                    "Inventory store x1, item...",			// 0x50
                    "Inventory remove x1, item...",			// 0x51
                    "Add to coins...",			// 0x52
                    "Add to frog coins...",			// 0x53
                    "FP -= mem $7000",			// 0x57

                    /********FD OPTIONS********/

                    "Store mem $70A7 to item inventory",			// 0x50
                    "Store mem $70A7 to equipment inventory",			// 0x51
                    "Coins += mem $7000",			// 0x52
                    "Coins -= mem $7000",			// 0x53
                    "Frog coins += mem $7000",			// 0x54
                    "Frog coins -= mem $7000",			// 0x55
                    "Current FP += mem $7000",			// 0x56
                    "Maximum FP += mem $7000",			// 0x57
                    "Restore all FP"			// 0x5C
                    };

                case 4:
                    return new string[] 
                    { 
                    "Engage battle with pack @ $700E",			// 0x49
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
                    "Reset game, choose game",			// 0xFB
                    "Reset game",			// 0xFC

                    /********FD OPTIONS********/

                    "Open, save game",			// 0x4A
                    "Open, menu tutorial...",			// 0x4C
                    "Open, level-up bonus"			// 0x65
                    };

                case 7:
                    return new string[] 
                    { 
                    "Run dlg...",			// 0x60
                    "Run dlg: mem $7000...",			// 0x61
                    "Run timed dlg...",			// 0x62
                    "Append to dlg: mem $7000...",			// 0x63
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

                    "Set inactive sound channels...",        // 0x94
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
                    "Store to mem from mem $7000 (8-bit)...",         // 0xB5
                    "Store random # to mem...",			// 0xB7
                    "Store to mem from mem $7000 (16-bit)...",        // 0xBB
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
                    "Mem $7000 = party capacity",			// 0x37
                    "Mem $7000 = character @ slot...",			// 0x38
                    "Mem $7000 = open item slots",			// 0x55
                    "Mem $7000 = current FP",			// 0x58
                    "Set mem @ mem $7000",			// 0xA3
                    "Clear mem @ mem $7000",			// 0xA7
                    "Mem $7000 =...",			// 0xAC
                    "Mem $7000 +=...",			// 0xAD
                    "Mem $7000 increment",			// 0xAE
                    "Mem $7000 decrement",			// 0xAF
                    "Mem $7000 = mem (8-bit)...",			// 0xB4
                    "Mem $7000 = random # less than...",			// 0xB6
                    "Mem $7000 += mem...",			// 0xB8
                    "Mem $7000 -= mem...",			// 0xB9
                    "Mem $7000 = mem (16-bit)...",			// 0xBA
                    "Mem $7000 compare to...",			// 0xC0
                    "Mem $7000 compare to mem...",			// 0xC1
                    "Mem $7000 = current level",			// 0xC3
                    "Mem $7000 = object X coord...",			// 0xC4
                    "Mem $7000 = object Y coord...",			// 0xC5
                    "Mem $7000 = object Z coord...",			// 0xC6
                    "Mem $7000 = held joypad register",			// 0xCA
                    "Mem $7000 = tapped joypad register",			// 0xCB
                    "If mem $7000 bit(s) set, jump to...",			// 0xDB
                    "If mem $7000 bit(s) clear, jump to...",			// 0xDF
                    "If mem $7000 =...",			// 0xE2
                    "If mem $7000 !=...",			// 0xE3
                    "If mem $7000 set, no bits...",			// 0xE6
                    "If mem $7000 set, any bits...",			// 0xE7
                    "If equal to zero, jump to...",			// 0xEA
                    "If not equal to zero, jump to...",			// 0xEB
                    "If greater than / equal to, jump to...",			// 0xEC
                    "If less than, jump to...",			// 0xED
                    "If negative, jump to...",			// 0xEE
                    "If positive, jump to...",			// 0xEF

                    /********FD OPTIONS********/

                    "Mem $7000 = quantity of item...",			// 0x58
                    "Mem $7000 = coins",			// 0x59
                    "Mem $7000 = frog coins",			// 0x5A
                    "Mem $7000 = equipment of character...",			// 0x5D
                    "Mem $70A7 = quantity of item @ mem $7000",			// 0x5E
                    "Mem $7000 = mem 7F:...",			// 0xAC
                    "Mem $7000 isolate bits =...",			// 0xB0
                    "Mem $7000 set bits =...",			// 0xB1
                    "Mem $7000 xor bits =...",			// 0xB2
                    "Mem $7000 isolate bits = mem...",			// 0xB3
                    "Mem $7000 set bits = mem...",			// 0xB4
                    "Mem $7000 xor bits = mem..."			// 0xB5
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
                    "Return",			// 0xFE
                    "Return all"			// 0xFF
                    };

                default:
                    return new string[] { };
            }
        }
        #endregion
        #endregion
        #region Functions
        public static string Numerize(string item, int index, int length)
        {
            return "{" + index.ToString("d" + length) + "}  " + item;
        }
        public static string Numerize(string[] list, int index, int length)
        {
            return "{" + index.ToString("d" + length) + "}  " + list[index];
        }
        public static string Numerize(string[] list, int index)
        {
            if (index >= list.Length)
                return "ERROR: OUT OF BOUNDS INDEX";
            int length = (list.Length - 1).ToString().Length;
            return "{" + index.ToString("d" + length) + "}  " + list[index];
        }
        public static string[] Numerize(int length, string[] list)
        {
            string[] temp = new string[list.Length];
            for (int i = 0; i < list.Length; i++)
                temp[i] = "{" + i.ToString("d" + length) + "}  " + list[i];
            return temp;
        }
        public static string[] Numerize(string[] list)
        {
            int length = (list.Length - 1).ToString().Length;
            string[] temp = new string[list.Length];
            for (int i = 0; i < list.Length; i++)
                temp[i] = "{" + i.ToString("d" + length) + "}  " + list[i];
            return temp;
        }
        public static string[] Numerize(StringCollection list)
        {
            return Numerize(Convert(list));
        }
        public static string Numerize(StringCollection list, int index)
        {
            return Numerize(Convert(list), index);
        }
        public static string[] Numerize(object[] list)
        {
            return Numerize(Convert(list));
        }
        public static string[] Convert(StringCollection list)
        {
            string[] temp = new string[list.Count];
            list.CopyTo(temp, 0);
            return temp;
        }
        public static string[] Convert(object[] list)
        {
            string[] temp = new string[list.Length];
            for (int i = 0; i < list.Length; i++)
                temp[i] = list[i].ToString();
            return temp;
        }
        /// <summary>
        /// Converts any array to a string array.
        /// </summary>
        /// <param name="list">The array to convert.</param>
        /// <param name="length">The number of elements that the string array will contain.</param>
        /// <param name="startIndex">The index of each string to start at.</param>
        /// <returns></returns>
        public static string[] Convert(object[] list, int length, int startIndex)
        {
            string[] temp = new string[length];
            for (int i = 0; i < list.Length && i < length; i++)
                temp[i] = list[i].ToString().Substring(startIndex);
            return temp;
        }
        public static string[] Convert(object[] list, int length)
        {
            return Convert(list, length, 0);
        }
        public static string[] Convert(ComboBox.ObjectCollection list)
        {
            object[] array = new object[list.Count];
            list.CopyTo(array, 0);
            return Convert(array, list.Count, 0);
        }
        #endregion
    }
}
