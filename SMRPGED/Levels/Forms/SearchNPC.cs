using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMRPGED
{
    public partial class SearchNPC : Form
    {
        private NPCProperties[] npcProperties;
        private Bitmap spriteImage;
        private int[] spritePixels;
        private int imageWidth;
        private int imageHeight;
        private Levels level;

        private bool updating = false;

        #region Sprite Names
        private string[] spriteNames = new string[]
            {
                "[000]  Mario (walking, down-left)",
                "[001]  Mario (jump, front)",
                "[002]  Mario (walking, up-right)",
                "[003]  Mario (surprise, left)",
                "[004]  Mario (attack, up-right)",
                "[005]  Mario (hammer attack, up-right)",
                "[006]  Mario (crouch, up-right)",
                "[007]  Toadstool (walking, down-left)",
                "[008]  Toadstool (walking, up-right)",
                "[009]  Toadstool (surprise)",
                "[00A]  Toadstool (slap attack)",
                "[00B]  Toadstool (frying pan attack)",
                "[00C]  Toadstool (fallen/crying)",
                "[00D]  Bowser (walking, down-left)",
                "[00E]  Bowser (walking, up-right)",
                "[00F]  Bowser (surprise)",
                "[010]  Bowser (claw attack)",
                "[011]  Bowser (swing ball-chain)",
                "[012]  Bowser (cast spell)",
                "[013]  Mallow (walking, down-left)",
                "[014]  Mallow (walking, up-right)",
                "[015]  Mallow (surprise)",
                "[016]  Mallow (punch)",
                "[017]  Mallow (swing stick)",
                "[018]  Mallow (still, up-right)",
                "[019]  Geno (walking, down-left)",
                "[01A]  Geno (walking, up-right)",
                "[01B]  Geno (surprise)",
                "[01C]  Geno (elbow shot)",
                "[01D]  Geno (finger shot)",
                "[01E]  Geno (morph into cannon)",
                "[01F]  Hammer",
                "[020]  Froggie Stick",
                "[021]  Cymbals",
                "[022]  Chomp",
                "[023]  Frying Pan",
                "[024]  Parasol",
                "[025]  War Fan",
                "[026]  Red Mushroom",
                "[027]  Red Scarecrow",
                "[028]  Mario's battle portrait",
                "[029]  Toadstool's battle portrait",
                "[02A]  Bowser's battle portrait",
                "[02B]  Mallow's battle portrait",
                "[02C]  Geno's battle portrait",
                "[02D]  Yellow Yoshi",
                "[02E]  Pink Yoshi",
                "[02F]  Boshi",
                "[030]  Croco",
                "[031]  Green Yoshi",
                "[032]  Booster",
                "[033]  Green Yoshi (walk)",
                "[034]  Booster (walk)",
                "[035]  King Nimbus",
                "[036]  Queen Nimbus",
                "[037]  Jonathan Jones",
                "[038]  Valentina",
                "[039]  Magikoopa",
                "[03A]  Frogfucius",
                "[03B]  Tadpole",
                "[03C]  Thwomp",
                "[03D]  Big Thwomp",
                "[03E]  Microbomb",
                "[03F]  Valentina Statue",
                "[040]  Toad",
                "[041]  Wallet Guy (also casino assistants)",
                "[042]  Raini",
                "[043]  Old Man",
                "[044]  Old Woman",
                "[045]  Green/Brown Toad",
                "[046]  Chancellor",
                "[047]  Pa Mole",
                "[048]  Ma Mole",
                "[049]  Girl Mole (pink bow)",
                "[04A]  Girl Mole (yellow bow)",
                "[04B]  Nimbusite (blue)",
                "[04C]  Nimbusite (red)",
                "[04D]  Nimbusite (brown/green)",
                "[04E]  Nimbusite (yellow/green)",
                "[04F]  Nimbus Guard",
                "[050]  Toadofsky",
                "[051]  Mario Doll (Booster's Castle)",
                "[052]  Blue Star Piece",
                "[053]  Purple Star Piece",
                "[054]  Red Star Piece",
                "[055]  Gold Star Piece",
                "[056]  Green Star Piece",
                "[057]  Light Blue Star Piece",
                "[058]  Yellow Star Piece",
                "[059]  Geno Doll",
                "[05A]  Bowser Doll",
                "[05B]  Mario Doll",
                "[05C]  Toadstool Doll",
                "[05D]  Blue Stepping Block",
                "[05E]  Treasure Chest",
                "[05F]  Empty Treasure Chest",
                "[060]  Mario Doll (surprised)",
                "[061]  Toadstool's Parachute",
                "[062]  Rolling Barrel",
                "[063]  Warp Spring-board",
                "[064]  Jump Spring-board",
                "[065]  Teeter-totter",
                "[066]  Save Point",
                "[067]  Corkpedite",
                "[068]  J Puzzle Block",
                "[069]  Yellow Stepping Block",
                "[06A]  Water Droplet",
                "[06B]  Hinopio",
                "[06C]  Factory Hex-Nut",
                "[06D]  Green Switch",
                "[06E]  Discolored Treasure Chest?",
                "[06F]  Nimbusland Bus Driver",
                "[070]  Mushroom Boy",
                "[071]  Marrymore Man (green)",
                "[072]  Marrymore Woman (yellow)",
                "[073]  Marrymore Woman (green)",
                "[074]  Marrymore Kid (purple)",
                "[075]  Marrymore Kid (blue/green)",
                "[076]  Marrymore Bright Card buyer (brown/grey)",
                "[077]  Rose Town Gardener (green/grey)",
                "[078]  Old Woman (green/grey)",
                "[079]  Old Woman (purple/grey)",
                "[07A]  Fat Yoshi Baby",
                "[07B]  Yoshi Baby Egg",
                "[07C]  Gameboy Kid",
                "[07D]  Frogfucius Student",
                "[07E]  Chomp (behind)",
                "[07F]  Wiggler (head)",
                "[080]  Block Shadow",
                "[081]  Red Magikoopa",
                "[082]  Wiggler (body segment)",
                "[083]  Dodo (as parson)",
                "[084]  Moleville Mine Cart",
                "[085]  Knife Guy Juggler (still, red balls)",
                "[086]  Knife Guy Juggler",
                "[087]  White Mine Cart?",
                "[088]  Discolored Mine Cart",
                "[089]  Fireball (surface from lava)",
                "[08A]  Piranha Plant",
                "[08B]  Goomba",
                "[08C]  Bullet Bill",
                "[08D]  Golden Bullet Bill",
                "[08E]  Factory Clerk (green)",
                "[08F]  Land's End Cannon",
                "[090]  Red Dot?",
                "[091]  Bob-omb",
                "[092]  Commander Troopa",
                "[093]  Golden Belome",
                "[094]  Birdy Statue",
                "[095]  Shyguy in Bowser's Helicopter",
                "[096]  Machine Made Bowyer",
                "[097]  Machine Made Yaridovich (out of battle)",
                "[098]  Machine Made Axem Red",
                "[099]  Gunyolk (top section)",
                "[09A]  Gunyolk (outer section)",
                "[09B]  Factory Crane",
                "[09C]  Blue-Green Star Piece (spinning)",
                "[09D]  Smithy's Hammer",
                "[09E]  Smithy's Chest",
                "[09F]  Poison Toxic Gas",
                "[0A0]  Shelly (bottom section)",
                "[0A1]  Dyna and Mite",
                "[0A2]  Seaside Town Fake (green)",
                "[0A3]  Seaside Town Fake Elder (green)",
                "[0A4]  Seaside Town Elder (yellow/green)",
                "[0A5]  Monstermama (golden/brown/red)",
                "[0A6]  Nimbus Guard",
                "[0A7]  Factory Manager (blue)",
                "[0A8]  Factory Director (red)",
                "[0A9]  Boomer (red)",
                "[0AA]  Dr.Topper (green)",
                "[0AB]  Sparkles from Star Piece",
                "[0AC]  Geno Doll",
                "[0AD]  Smelter (back section)",
                "[0AE]  Small Candy Cloud",
                "[0AF]  Golden Chomp (back)",
                "[0B0]  Chomp (front)",
                "[0B1]  Grate Guy (from casino)",
                "[0B2]  Marrymore Inn Keeper (blue, striped hat)",
                "[0B3]  Rose Town Treasure Holder",
                "[0B4]  Rose Town Woman (blue/pink, braids)",
                "[0B5]  Marrymore Woman (yellow)",
                "[0B6]  Rose Town Old Man (blue/grey)",
                "[0B7]  Old Woman (grey/red)",
                "[0B8]  Kid (red, striped hat)",
                "[0B9]  Gaz (purple)",
                "[0BA]  (nothing)",
                "[0BB]  (nothing)",
                "[0BC]  Cannon Ball",
                "[0BD]  Croco (still)",
                "[0BE]  Bowser w/Toadstool in Helicopter",
                "[0BF]  Miniature Toad",
                "[0C0]  Coin",
                "[0C1]  Small Coin",
                "[0C2]  Frog Coin",
                "[0C3]  Flower",
                "[0C4]  Big Flower",
                "[0C5]  Sparkle? (sideways)",
                "[0C6]  Sparkle (downwards)",
                "[0C7]  Sparkle (circular winding)",
                "[0C8]  Explosion",
                "[0C9]  Mokura's Cloud (blue)",
                "[0CA]  Small Frog Coin",
                "[0CB]  Level Up text from Invincible Star",
                "[0CC]  Grey Explosion (when encountering Fireballs)",
                "[0CD]  Miniature Axem Red",
                "[0CE]  Terrapin (still)",
                "[0CF]  Jinx (walk)",
                "[0D0]  Axem Red",
                "[0D1]  Axem Black",
                "[0D2]  Axem Pink",
                "[0D3]  Axem Yellow",
                "[0D4]  Axem Green",
                "[0D5]  Axem Red teleport",
                "[0D6]  Stumpet (head)",
                "[0D7]  Stumpet (roots, right)",
                "[0D8]  Czar Dragon (body)",
                "[0D9]  Growing Vine Beanstalk",
                "[0DA]  Brick Beanstalk Block",
                "[0DB]  Yellow Dot?",
                "[0DC]  Yellow Letter",
                "[0DD]  Yaridovich (out of battle)",
                "[0DE]  Banana Peel",
                "[0DF]  Tentacle (extending)",
                "[0E0]  Snifit (black, back)",
                "[0E1]  Level Up Bonus Selection Box",
                "[0E2]  Booster's Tower Entrance Door",
                "[0E3]  Light Green Pipe (top edge)",
                "[0E4]  Level Up Bonus Text",
                "[0E5]  Level Up Bonus Flower",
                "[0E6]  Level Up Bonus Pow Power",
                "[0E7]  Level Up Bonus Star Magic",
                "[0E8]  Level Up Bonus HP",
                "[0E9]  Falling Stepping Bridge Block",
                "[0EA]  Old Classic Mario",
                "[0EB]  Booster's Choo-Choo Train",
                "[0EC]  Magikoopa (blue, walking)",
                "[0ED]  Terrapin (walking)",
                "[0EE]  Splash Water Droplets",
                "[0EF]  Small Sea Fish",
                "[0F0]  Splash Water Geyser",
                "[0F1]  Bowyer",
                "[0F2]  White Gas Cloud",
                "[0F3]  Machine Made Drill Bit",
                "[0F4]  Mushroom House Decor Mailbox",
                "[0F5]  Link Sleeping in Rose Town Inn",
                "[0F6]  Samus Sleeping in Mushroom Kingdom",
                "[0F7]  Grey Stepping Stone",
                "[0F8]  Hinopio's Model Airplane (blue/grey)",
                "[0F9]  Grey Stone Block",
                "[0FA]  Small Black Fence",
                "[0FB]  Wooden Bridge Bowser's Keep (right section)",
                "[0FC]  Grey Stone Bridge Bowser's Keep (right section)",
                "[0FD]  Toadstool Hand Captive from Rope",
                "[0FE]  Plywood Brown Door Bowser's Keep",
                "[0FF]  Beetle",
                "[100]  Terrapin",
                "[101]  Spikey",
                "[102]  Sky Troopa",
                "[103]  Mad Mallet",
                "[104]  Shaman",
                "[105]  Crook",
                "[106]  Goomba",
                "[107]  Piranha Plant",
                "[108]  Amanita",
                "[109]  Goby",
                "[10A]  Bloober",
                "[10B]  Bandana Red",
                "[10C]  Lakitu",
                "[10D]  Birdy",
                "[10E]  Pinwheel",
                "[10F]  Rat Funk",
                "[110]  K-9",
                "[111]  Magmite",
                "[112]  The Big Boo",
                "[113]  Dry Bones",
                "[114]  Greaper",
                "[115]  Sparky",
                "[116]  Chomp",
                "[117]  Pandorite",
                "[118]  Shy Ranger",
                "[119]  Bob-Omb",
                "[11A]  Spookum",
                "[11B]  Hammer Bro",
                "[11C]  Buzzer",
                "[11D]  Ameboid",
                "[11E]  Gecko",
                "[11F]  Wiggler",
                "[120]  Crusty",
                "[121]  Magikoopa",
                "[122]  Leuko",
                "[123]  Jawful",
                "[124]  Enigma",
                "[125]  Blaster",
                "[126]  Guerrilla",
                "[127]  Baba Yaga",
                "[128]  Hobgoblin",
                "[129]  Reacher",
                "[12A]  Shogun",
                "[12B]  Orb User",
                "[12C]  Heavy Troopa",
                "[12D]  Shadow",
                "[12E]  Cluster",
                "[12F]  Bahamutt",
                "[130]  Octolot",
                "[131]  Frogog",
                "[132]  Clerk",
                "[133]  Gunyolk",
                "[134]  Boomer",
                "[135]  Remo Con",
                "[136]  Snapdragon",
                "[137]  Stumpet",
                "[138]  Dodo (2nd time)",
                "[139]  Jester",
                "[13A]  Artichoker",
                "[13B]  Arachne",
                "[13C]  Carroboscis",
                "[13D]  Hippopo",
                "[13E]  Mastadoom",
                "[13F]  Corkpedite",
                "[140]  Terra Cotta",
                "[141]  Spikester",
                "[142]  Malakoopa",
                "[143]  Pounder",
                "[144]  Poundette",
                "[145]  Sackit",
                "[146]  Gu Goomba",
                "[147]  Chewy",
                "[148]  Fireball",
                "[149]  Mr.Kipper",
                "[14A]  Factory Chief",
                "[14B]  Bandana Blue",
                "[14C]  Manager",
                "[14D]  Bluebird",
                "[14E]  __nothing",
                "[14F]  Alley Rat",
                "[150]  Chow",
                "[151]  Magmus",
                "[152]  Li~L Boo",
                "[153]  Vomer",
                "[154]  Glum Reaper",
                "[155]  Pyrosphere",
                "[156]  Chomp Chomp",
                "[157]  Hidon",
                "[158]  Sling Shy",
                "[159]  Rob-Omb",
                "[15A]  Shy Guy",
                "[15B]  Ninja",
                "[15C]  Stinger",
                "[15D]  Goombette",
                "[15E]  Geckit",
                "[15F]  Jabit",
                "[160]  Star Cruster",
                "[161]  Merlin",
                "[162]  Muckle",
                "[163]  Forkies",
                "[164]  Gorgon",
                "[165]  Big Bertha",
                "[166]  Chained Kong",
                "[167]  Fautso",
                "[168]  Straw Head",
                "[169]  Juju",
                "[16A]  Armored Ant",
                "[16B]  Orbison",
                "[16C]  Tub-O-Troopa",
                "[16D]  Doppel",
                "[16E]  Pulsar",
                "[16F]  __purple Bahamutt",
                "[170]  Octovader",
                "[171]  Ribbite",
                "[172]  Director",
                "[173]  __Gunyolk (yellow)",
                "[174]  __Boomer (blue)",
                "[175]  Puppox",
                "[176]  Fink Flower",
                "[177]  Lumbler",
                "[178]  Springer",
                "[179]  Harlequin",
                "[17A]  Kriffid",
                "[17B]  Spinthra",
                "[17C]  Radish",
                "[17D]  Crippo",
                "[17E]  Mastablasta",
                "[17F]  Pile Driver",
                "[180]  Apprentice",
                "[181]  __nothing",
                "[182]  __nothing",
                "[183]  __nothing",
                "[184]  __Geno redemption",
                "[185]  __little bird",
                "[186]  Box Boy",
                "[187]  Shelly",
                "[188]  Super Spike",
                "[189]  Dodo",
                "[18A]  Oerlikon",
                "[18B]  Chester",
                "[18C]  Body",
                "[18D]  __Pile Driver (body)",
                "[18E]  Torte",
                "[18F]  Shy Away",
                "[190]  Jinx Clone",
                "[191]  Machine Made (Shyster)",
                "[192]  Machine Made (Drill Bit)",
                "[193]  Formless",
                "[194]  Mokura",
                "[195]  Fire Crystal",
                "[196]  Water Crystal",
                "[197]  Earth Crystal",
                "[198]  Wind Crystal",
                "[199]  Mario Clone",
                "[19A]  Toadstool 2",
                "[19B]  Bowser Clone",
                "[19C]  Geno Clone",
                "[19D]  Mallow Clone",
                "[19E]  Shyster",
                "[19F]  Kinklink",
                "[1A0]  __Toadstool (captive)",
                "[1A1]  Hangin~ Shy",
                "[1A2]  Smelter",
                "[1A3]  Machine Made (Mack)",
                "[1A4]  Machine Made (Bowyer)",
                "[1A5]  Machine Made (Yaridovich)",
                "[1A6]  Machine Made (Axem Pink)",
                "[1A7]  Machine Made (Axem Black)",
                "[1A8]  Machine Made (Axem Red)",
                "[1A9]  Machine Made (Axem Yellow)",
                "[1AA]  Machine Made (Axem Green)",
                "[1AB]  Goomba (Intro)",
                "[1AC]  Hammer Bro (Intro)",
                "[1AD]  Birdo (Intro)",
                "[1AE]  Bb-Bomb",
                "[1AF]  Magidragon",
                "[1B0]  Starslap",
                "[1B1]  Mukumuku",
                "[1B2]  Zeostar",
                "[1B3]  Jagger",
                "[1B4]  Chompweed",
                "[1B5]  Smithy (Tank Head)",
                "[1B6]  Smithy (Box Head)",
                "[1B7]  __Corkpedite",
                "[1B8]  Microbomb",
                "[1B9]  __Thwomp",
                "[1BA]  Grit",
                "[1BB]  Neosquid",
                "[1BC]  Yaridovich (mirage)",
                "[1BD]  Helio",
                "[1BE]  Right Eye",
                "[1BF]  Left Eye",
                "[1C0]  Knife Guy",
                "[1C1]  Grate Guy",
                "[1C2]  Bundt",
                "[1C3]  Jinx (1st time)",
                "[1C4]  Jinx (2nd time)",
                "[1C5]  Count Down",
                "[1C6]  Ding-A-Ling",
                "[1C7]  Belome (1st time)",
                "[1C8]  Belome (2nd time)",
                "[1C9]  __Belome",
                "[1CA]  Smilax",
                "[1CB]  Thrax        ",
                "[1CC]  Megasmilax",
                "[1CD]  Birdo",
                "[1CE]  Eggbert",
                "[1CF]  Axem Yellow",
                "[1D0]  Punchinello",
                "[1D1]  Tentacles (right)",
                "[1D2]  Axem Red",
                "[1D3]  Axem Green",
                "[1D4]  King Bomb",
                "[1D5]  Mezzo Bomb",
                "[1D6]  __Bundt object",
                "[1D7]  Raspberry",
                "[1D8]  King Calamari",
                "[1D9]  Tentacles (left)",
                "[1DA]  Jinx (3rd time)",
                "[1DB]  Zombone",
                "[1DC]  Czar Dragon",
                "[1DD]  Cloaker (1st time)",
                "[1DE]  Domino (2nd time)",
                "[1DF]  Mad Adder",
                "[1E0]  Mack",
                "[1E1]  Bodyguard",
                "[1E2]  Yaridovich",
                "[1E3]  Drill Bit",
                "[1E4]  Axem Pink",
                "[1E5]  Axem Black",
                "[1E6]  Bowyer",
                "[1E7]  Aero",
                "[1E8]  __Exor (mouth)",
                "[1E9]  Exor",
                "[1EA]  Smithy (1st Form)",
                "[1EB]  Shyper",
                "[1EC]  Smithy (Body)",
                "[1ED]  Smithy (Head)",
                "[1EE]  Smithy (Magic Head)",
                "[1EF]  Smithy (Chest Head)",
                "[1F0]  Croco (1st time)",
                "[1F1]  Croco (2nd time)",
                "[1F2]  __Croco",
                "[1F3]  Earth Link",
                "[1F4]  Bowser",
                "[1F5]  Axem Rangers",
                "[1F6]  Booster",
                "[1F7]  Booster",
                "[1F8]  Snifit",
                "[1F9]  Johnny",
                "[1FA]  Johnny",
                "[1FB]  Valentina",
                "[1FC]  Cloaker (2nd time)",
                "[1FD]  Domino (2nd time)",
                "[1FE]  Candle",
                "[1FF]  Culex",
                "[200]  A/B/X/Y action button selection in battle",
                "[201]  Rainbow Explosion",
                "[202]  Blue Explosion",
                "[203]  Green Explosion",
                "[204]  Enemy Defeated Explosion Stars",
                "[205]  Bomb Explosion",
                "[206]  Small White Cloud",
                "[207]  Drain Explosion",
                "[208]  alphabet + symbols",
                "[209]  light blue stars",
                "[20A]  Come Back rainbow star",
                "[20B]  yellow cure stars",
                "[20C]  ....",
                "[20D]  Bowyer's arrow",
                "[20E]  yellow steam?",
                "[20F]  small black bullet",
                "[210]  very small black bullet",
                "[211]  HP Rain cloud",
                "[212]  stat-boost arrows",
                "[213]  black rolling coal rock",
                "[214]  blue spark",
                "[215]  yellow spark",
                "[216]  green spark",
                "[217]  red spark",
                "[218]  rainbow rain",
                "[219]  mushroom spores",
                "[21A]  Lazy Shell (Heavy Troopa)",
                "[21B]  Orange Lazy Shell",
                "[21C]  Green Lazy Shell (Tub-O-Troopa)",
                "[21D]  Snowy eyes",
                "[21E]  blinking yellow light circle",
                "[21F]  purple petal",
                "[220]  small pink petal",
                "[221]  thrown hammer",
                "[222]  Bombs Away electric ball",
                "[223]  Fire Orb fireball",
                "[224]  Willy Wisp purple electric ball",
                "[225]  spore (pink/green)",
                "[226]  bolt (hardware-wise)",
                "[227]  Mute balloon",
                "[228]  'Thank You' red dialogue bubble",
                "[229]  'Thank You' purple dialogue bubble",
                "[22A]  'Thank You' blue dialogue bubble",
                "[22B]  'Thank You' green dialogue bubble",
                "[22C]  'Thank You' yellow dialogue bubble",
                "[22D]  'Psychopath' question mark cloud",
                "[22E]  thrown shuriken",
                "[22F]  green cure stars",
                "[230]  red cure stars",
                "[231]  blue cure stars",
                "[232]  yellow reusable item sprite with letter I",
                "[233]  'A' button from Bowyer's 'Button Lock'",
                "[234]  Bowser's spike shot",
                "[235]  'Geno Flash' squinting eyes",
                "[236]  green item collection",
                "[237]  red item collection",
                "[238]  blue item collection",
                "[239]  yellow item collection",
                "[23A]  green spore",
                "[23B]  'Fear' exclamation point",
                "[23C]  ....",
                "[23D]  Mokura",
                "[23E]  Drain",
                "[23F]  sparkles",
                "[240]  ....",
                "[241]  ....",
                "[242]  ....",
                "[243]  ....",
                "[244]  ....",
                "[245]  ....",
                "[246]  ....",
                "[247]  ....",
                "[248]  ....",
                "[249]  ....",
                "[24A]  ....",
                "[24B]  ....",
                "[24C]  ....",
                "[24D]  ....",
                "[24E]  ....",
                "[24F]  ....",
                "[250]  ....",
                "[251]  ....",
                "[252]  ....",
                "[253]  ....",
                "[254]  ....",
                "[255]  ....",
                "[256]  ....",
                "[257]  ....",
                "[258]  ....",
                "[259]  ....",
                "[25A]  ....",
                "[25B]  ....",
                "[25C]  ....",
                "[25D]  ....",
                "[25E]  ....",
                "[25F]  ....",
                "[260]  ....",
                "[261]  ....",
                "[262]  ....",
                "[263]  ....",
                "[264]  ....",
                "[265]  ....",
                "[266]  ....",
                "[267]  ....",
                "[268]  ....",
                "[269]  ....",
                "[26A]  ....",
                "[26B]  ....",
                "[26C]  ....",
                "[26D]  ....",
                "[26E]  ....",
                "[26F]  ....",
                "[270]  ....",
                "[271]  ....",
                "[272]  ....",
                "[273]  ....",
                "[274]  ....",
                "[275]  ....",
                "[276]  ....",
                "[277]  ....",
                "[278]  ....",
                "[279]  ....",
                "[27A]  ....",
                "[27B]  ....",
                "[27C]  ....",
                "[27D]  ....",
                "[27E]  ....",
                "[27F]  ....",
                "[280]  ....",
                "[281]  ....",
                "[282]  ....",
                "[283]  ....",
                "[284]  ....",
                "[285]  ....",
                "[286]  ....",
                "[287]  ....",
                "[288]  ....",
                "[289]  ....",
                "[28A]  ....",
                "[28B]  ....",
                "[28C]  ....",
                "[28D]  ....",
                "[28E]  ....",
                "[28F]  ....",
                "[290]  ....",
                "[291]  ....",
                "[292]  ....",
                "[293]  ....",
                "[294]  ....",
                "[295]  ....",
                "[296]  ....",
                "[297]  ....",
                "[298]  ....",
                "[299]  ....",
                "[29A]  ....",
                "[29B]  ....",
                "[29C]  ....",
                "[29D]  ....",
                "[29E]  ....",
                "[29F]  ....",
                "[2A0]  ....",
                "[2A1]  ....",
                "[2A2]  ....",
                "[2A3]  ....",
                "[2A4]  ....",
                "[2A5]  ....",
                "[2A6]  ....",
                "[2A7]  ....",
                "[2A8]  ....",
                "[2A9]  ....",
                "[2AA]  ....",
                "[2AB]  ....",
                "[2AC]  ....",
                "[2AD]  ....",
                "[2AE]  ....",
                "[2AF]  ....",
                "[2B0]  ....",
                "[2B1]  ....",
                "[2B2]  ....",
                "[2B3]  ....",
                "[2B4]  ....",
                "[2B5]  ....",
                "[2B6]  ....",
                "[2B7]  ....",
                "[2B8]  ....",
                "[2B9]  ....",
                "[2BA]  ....",
                "[2BB]  ....",
                "[2BC]  ....",
                "[2BD]  ....",
                "[2BE]  ....",
                "[2BF]  ....",
                "[2C0]  ....",
                "[2C1]  ....",
                "[2C2]  ....",
                "[2C3]  ....",
                "[2C4]  ....",
                "[2C5]  ....",
                "[2C6]  ....",
                "[2C7]  ....",
                "[2C8]  ....",
                "[2C9]  ....",
                "[2CA]  ....",
                "[2CB]  ....",
                "[2CC]  ....",
                "[2CD]  ....",
                "[2CE]  ....",
                "[2CF]  ....",
                "[2D0]  ....",
                "[2D1]  ....",
                "[2D2]  ....",
                "[2D3]  ....",
                "[2D4]  ....",
                "[2D5]  ....",
                "[2D6]  ....",
                "[2D7]  ....",
                "[2D8]  ....",
                "[2D9]  ....",
                "[2DA]  ....",
                "[2DB]  ....",
                "[2DC]  ....",
                "[2DD]  ....",
                "[2DE]  ....",
                "[2DF]  ....",
                "[2E0]  ....",
                "[2E1]  ....",
                "[2E2]  ....",
                "[2E3]  ....",
                "[2E4]  ....",
                "[2E5]  ....",
                "[2E6]  ....",
                "[2E7]  ....",
                "[2E8]  ....",
                "[2E9]  ....",
                "[2EA]  ....",
                "[2EB]  ....",
                "[2EC]  ....",
                "[2ED]  ....",
                "[2EE]  ....",
                "[2EF]  ....",
                "[2F0]  ....",
                "[2F1]  ....",
                "[2F2]  ....",
                "[2F3]  ....",
                "[2F4]  ....",
                "[2F5]  ....",
                "[2F6]  ....",
                "[2F7]  ....",
                "[2F8]  ....",
                "[2F9]  ....",
                "[2FA]  ....",
                "[2FB]  ....",
                "[2FC]  ....",
                "[2FD]  ....",
                "[2FE]  ....",
                "[2FF]  ....",
                "[300]  ....",
                "[301]  yellow lightning ball",
                "[302]  Fire Orb hit explosion",
                "[303]  egg",
                "[304]  Lightning Orb blue lightning ball",
                "[305]  small yellow spike",
                "[306]  large yellow spike",
                "[307]  white gas cloud",
                "[308]  Blast orange gas cloud",
                "[309]  Star Egg little brown bird",
                "[30A]  Poison Gas green gas cloud",
                "[30B]  white stars",
                "[30C]  purple gas cloud",
                "[30D]  yellow star",
                "[30E]  Diamond Saw snowflake",
                "[30F]  blue gas cloud",
                "[310]  bone throw",
                "[311]  spritz bomb",
                "[312]  Wind Crystal",
                "[313]  green shine web",
                "[314]  Mecha-Koopa (Bowser Crush) eyes",
                "[315]  Water Crystal",
                "[316]  plasm water droplet (blue-green)",
                "[317]  Ice Rock",
                "[318]  Ice Rock (grey)",
                "[319]  big pink heart",
                "[31A]  dark red/yellow fireball",
                "[31B]  light green stars",
                "[31C]  light orange stars",
                "[31D]  Sleepy Time sheep/ram",
                "[31E]  Geno Beam/Blast/Flash red power-up star",
                "[31F]  ....",
                "[320]  blue/green bubbles/circles",
                "[321]  sleep ZZZ's",
                "[322]  backwards yellow spike",
                "[323]  Water Blast water spouts",
                "[324]  Gunk Ball / Ink Blast",
                "[325]  water spout (red)",
                "[326]  Royal Flush card",
                "[327]  yellow shaking bell",
                "[328]  ....",
                "[329]  blue music note",
                "[32A]  white pixel dot",
                "[32B]  ....",
                "[32C]  blue water surfacing/diving droplets",
                "[32D]  green water surfacing/diving droplets",
                "[32E]  yellow water surfacing/diving droplets",
                "[32F]  ....",
                "[330]  ....",
                "[331]  ....",
                "[332]  ....",
                "[333]  ....",
                "[334]  Magikoopa's triangle/circle/X cast magic",
                "[335]  ....",
                "[336]  ....",
                "[337]  ....",
                "[338]  ....",
                "[339]  ....",
                "[33A]  flower bonus",
                "[33B]  ....",
                "[33C]  ....",
                "[33D]  ....",
                "[33E]  ....",
                "[33F]  ....",
                "[340]  ....",
                "[341]  ....",
                "[342]  ....",
                "[343]  ....",
                "[344]  ....",
                "[345]  ....",
                "[346]  ....",
                "[347]  ....",
                "[348]  ....",
                "[349]  ....",
                "[34A]  ....",
                "[34B]  ....",
                "[34C]  ....",
                "[34D]  ....",
                "[34E]  ....",
                "[34F]  ....",
                "[350]  ....",
                "[351]  ....",
                "[352]  ....",
                "[353]  ....",
                "[354]  ....",
                "[355]  ....",
                "[356]  ....",
                "[357]  ....",
                "[358]  ....",
                "[359]  ....",
                "[35A]  ....",
                "[35B]  ....",
                "[35C]  ....",
                "[35D]  ....",
                "[35E]  ....",
                "[35F]  ....",
                "[360]  ....",
                "[361]  ....",
                "[362]  ....",
                "[363]  ....",
                "[364]  ....",
                "[365]  ....",
                "[366]  ....",
                "[367]  ....",
                "[368]  ....",
                "[369]  ....",
                "[36A]  ....",
                "[36B]  ....",
                "[36C]  ....",
                "[36D]  ....",
                "[36E]  ....",
                "[36F]  ....",
                "[370]  ....",
                "[371]  ....",
                "[372]  ....",
                "[373]  ....",
                "[374]  ....",
                "[375]  ....",
                "[376]  ....",
                "[377]  ....",
                "[378]  ....",
                "[379]  ....",
                "[37A]  ....",
                "[37B]  ....",
                "[37C]  ....",
                "[37D]  ....",
                "[37E]  ....",
                "[37F]  ....",
                "[380]  ....",
                "[381]  ....",
                "[382]  ....",
                "[383]  ....",
                "[384]  ....",
                "[385]  ....",
                "[386]  ....",
                "[387]  ....",
                "[388]  ....",
                "[389]  ....",
                "[38A]  ....",
                "[38B]  ....",
                "[38C]  ....",
                "[38D]  ....",
                "[38E]  ....",
                "[38F]  ....",
                "[390]  ....",
                "[391]  ....",
                "[392]  ....",
                "[393]  ....",
                "[394]  ....",
                "[395]  ....",
                "[396]  ....",
                "[397]  ....",
                "[398]  ....",
                "[399]  ....",
                "[39A]  ....",
                "[39B]  ....",
                "[39C]  ....",
                "[39D]  ....",
                "[39E]  ....",
                "[39F]  ....",
                "[3A0]  marching Luigi",
                "[3A1]  marching Toads",
                "[3A2]  conducting Toadofsky",
                "[3A3]  waving Mallow",
                "[3A4]  waving King & Queen Nimbus",
                "[3A5]  Nimbus Busman, Lakitu & Frogfucius",
                "[3A6]  Tadpole",
                "[3A7]  trumpeting Piranhas",
                "[3A8]  Mole miners & star",
                "[3A9]  Dyna & Mite",
                "[3AA]  Hammer Bros & Chomps",
                "[3AB]  Crook & Croco",
                "[3AC]  Bowser in helicopter chasing",
                "[3AD]  Dodo carrying Valentina",
                "[3AE]  red balloon",
                "[3AF]  Booster riding train",
                "[3B0]  Snifits chasing beetle",
                "[3B1]  bouncing Shysters",
                "[3B2]  Mack, Yaridovich, Bowyer",
                "[3B3]  Smithy",
                "[3B4]  Johnny & mates",
                "[3B5]  blue/red/green Toads",
                "[3B6]  riding Yoshi",
                "[3B7]  waving Mario & Toadstool",
                "[3B8]  sparkle",
                "[3B9]  poof",
                "[3BA]  purple firework",
                "[3BB]  smaller red firework",
                "[3BC]  normal yellow 5-pronged star",
                "[3BD]  brown object dissipating",
                "[3BE]  tiny glowing pixel",
                "[3BF]  ....",
                "[3C0]  ....",
                "[3C1]  ....",
                "[3C2]  ....",
                "[3C3]  ....",
                "[3C4]  ....",
                "[3C5]  ....",
                "[3C6]  ....",
                "[3C7]  ....",
                "[3C8]  ....",
                "[3C9]  ....",
                "[3CA]  ....",
                "[3CB]  ....",
                "[3CC]  ....",
                "[3CD]  ....",
                "[3CE]  ....",
                "[3CF]  ....",
                "[3D0]  ....",
                "[3D1]  ....",
                "[3D2]  ....",
                "[3D3]  ....",
                "[3D4]  ....",
                "[3D5]  ....",
                "[3D6]  ....",
                "[3D7]  ....",
                "[3D8]  ....",
                "[3D9]  ....",
                "[3DA]  ....",
                "[3DB]  ....",
                "[3DC]  ....",
                "[3DD]  ....",
                "[3DE]  ....",
                "[3DF]  ....",
                "[3E0]  ....",
                "[3E1]  ....",
                "[3E2]  ....",
                "[3E3]  ....",
                "[3E4]  ....",
                "[3E5]  ....",
                "[3E6]  ....",
                "[3E7]  ....",
                "[3E8]  ....",
                "[3E9]  ....",
                "[3EA]  ....",
                "[3EB]  ....",
                "[3EC]  ....",
                "[3ED]  ....",
                "[3EE]  ....",
                "[3EF]  ....",
                "[3F0]  ....",
                "[3F1]  ....",
                "[3F2]  ....",
                "[3F3]  ....",
                "[3F4]  ....",
                "[3F5]  ....",
                "[3F6]  ....",
                "[3F7]  ....",
                "[3F8]  ....",
                "[3F9]  ....",
                "[3FA]  ....",
                "[3FB]  ....",
                "[3FC]  ....",
                "[3FD]  ....",
                "[3FE]  ....",
                "[3FF]  ...."
            };
        #endregion

        public SearchNPC(NPCProperties[] npcProperties, Levels level)
        {
            this.npcProperties = npcProperties;
            this.level = level;
            InitializeComponent();

            this.spriteName.Items.AddRange(spriteNames);
            InitializeNPCs();
        }
        private void InitializeNPCs()
        {
            updating = true;

            this.spriteName.SelectedIndex = npcProperties[(int)npcNum.Value].Sprite;
            this.layerPriority.SetItemChecked(0, npcProperties[(int)npcNum.Value].Priority0);
            this.layerPriority.SetItemChecked(1, npcProperties[(int)npcNum.Value].Priority1);
            this.layerPriority.SetItemChecked(2, npcProperties[(int)npcNum.Value].Priority2);
            this.yPixelShift.Value = npcProperties[(int)npcNum.Value].YPixelShiftUp;
            this.shift16pxDown.Checked = npcProperties[(int)npcNum.Value].Shift16pxDown;
            this.axisAcute.Value = npcProperties[(int)npcNum.Value].AcuteAxis;
            this.axisObtuse.Value = npcProperties[(int)npcNum.Value].ObtuseAxis;
            this.height.Value = npcProperties[(int)npcNum.Value].Height;

            this.unknownBits.SetItemChecked(0, npcProperties[(int)npcNum.Value].B1b2);
            this.unknownBits.SetItemChecked(1, npcProperties[(int)npcNum.Value].B1b3);
            this.unknownBits.SetItemChecked(2, npcProperties[(int)npcNum.Value].B1b4);
            this.unknownBits.SetItemChecked(3, npcProperties[(int)npcNum.Value].B1b5);
            this.unknownBits.SetItemChecked(4, npcProperties[(int)npcNum.Value].B1b6);
            this.unknownBits.SetItemChecked(5, npcProperties[(int)npcNum.Value].B1b7);
            this.unknownBits.SetItemChecked(6, npcProperties[(int)npcNum.Value].B2b0);
            this.unknownBits.SetItemChecked(7, npcProperties[(int)npcNum.Value].B2b1);
            this.unknownBits.SetItemChecked(8, npcProperties[(int)npcNum.Value].B2b2);
            this.unknownBits.SetItemChecked(9, npcProperties[(int)npcNum.Value].B2b3);
            this.unknownBits.SetItemChecked(10, npcProperties[(int)npcNum.Value].B2b4);
            this.unknownBits.SetItemChecked(11, npcProperties[(int)npcNum.Value].B3b5);
            this.unknownBits.SetItemChecked(12, npcProperties[(int)npcNum.Value].B3b6);
            this.unknownBits.SetItemChecked(13, npcProperties[(int)npcNum.Value].B3b7);
            this.unknownBits.SetItemChecked(14, npcProperties[(int)npcNum.Value].B5b5);
            this.unknownBits.SetItemChecked(15, npcProperties[(int)npcNum.Value].B5b6);
            this.unknownBits.SetItemChecked(16, npcProperties[(int)npcNum.Value].B5b7);
            this.unknownBits.SetItemChecked(17, npcProperties[(int)npcNum.Value].B6b2);

            SetSpriteImage();
            
            updating = false;
        }

        private void LoadSearch()
        {
            string npcSearch = "";
            bool notFound;

            int val = (int)spriteName.SelectedIndex;
            for (int i = 0; i < npcProperties.Length; i++)
            {
                notFound = false;
                if (spriteName.SelectedIndex != npcProperties[i].Sprite) notFound = true;
                if (!notFound) npcSearch += "#" + i.ToString() + "\n";
            }
            searchResults.Text = "Found the following NPCs with sprite #" + spriteName.SelectedIndex.ToString() + "...\n\n" + npcSearch;
        }

        private void SetSpriteImage()
        {
            spritePixels = npcProperties[0].CreateImage(3, true, (int)spriteName.SelectedIndex);
            imageWidth = npcProperties[0].ImageWidth;
            imageHeight = npcProperties[0].ImageHeight;
            if (spritePixels.Length == 0) { spritePixels = new int[2]; imageWidth = 1; imageHeight = 1; }
            spriteImage = new Bitmap(DrawImageFromIntArr(spritePixels, imageWidth, imageHeight));
            spritePictureBox.Invalidate();
        }

        private Bitmap DrawImageFromIntArr(int[] arr, int width, int height)
        {
            Bitmap image = null;

            unsafe
            {
                fixed (void* firstPixel = &arr[0])
                {
                    IntPtr ip = new IntPtr(firstPixel);
                    if (image != null)
                        image.Dispose();
                    image = new Bitmap(width, height, width * 4, System.Drawing.Imaging.PixelFormat.Format32bppPArgb, ip);

                }
            }

            return image;

        }

        private void npcNum_ValueChanged(object sender, EventArgs e)
        {
            InitializeNPCs();
        }
        private void spriteName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            SetSpriteImage();
        }
        private void layerPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
        }
        private void shift16pxDown_CheckedChanged(object sender, EventArgs e)
        {
            shift16pxDown.ForeColor = shift16pxDown.Checked ? Color.Black : Color.Gray;

            if (updating) return;
        }
        private void yPixelShift_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
        }
        private void axisAcute_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
        }
        private void axisObtuse_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
        }
        private void height_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
        }
        private void unknownBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            LoadSearch();
        }
        private void spritePictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (spriteImage != null)
                e.Graphics.DrawImage(spriteImage, 128 - (spriteImage.Width / 2), 128 - (spriteImage.Height / 2));
        }

        private void searchSpriteNames_Click(object sender, EventArgs e)
        {
            panelSearchSpriteNames.Visible = !panelSearchSpriteNames.Visible;
            if (panelSearchSpriteNames.Visible)
            {
                panelSearchSpriteNames.BringToFront();
                nameTextBox.Focus();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadSpriteNameSearch();
        }
        private void listBoxSpriteNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                spriteName.SelectedItem = listBoxSpriteNames.SelectedItem;
            }
            catch
            {
                MessageBox.Show("There was a problem loading the search item. Try doing another search.");
            }
        }
        private void nameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                panelSearchSpriteNames.Visible = false;
        }
        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            LoadSpriteNameSearch();
        }
        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                panelSearchSpriteNames.Visible = false;
        }
        private void listBoxSpriteNames_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                panelSearchSpriteNames.Visible = false;
        }

        private void LoadSpriteNameSearch()
        {
            listBoxSpriteNames.BeginUpdate();
            listBoxSpriteNames.Items.Clear();

            for (int i = 0; i < spriteName.Items.Count; i++)
            {
                if (Contains(spriteName.Items[i].ToString(), nameTextBox.Text, StringComparison.CurrentCultureIgnoreCase))
                    listBoxSpriteNames.Items.Add(spriteName.Items[i]);
            }
            listBoxSpriteNames.EndUpdate();
        }
        public static bool Contains(string original, string value, StringComparison comparisionType)
        {
            return original.IndexOf(value, comparisionType) >= 0;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            level.npcID_ValueChanged(null, null);

            npcProperties[(int)npcNum.Value].Sprite = (ushort)spriteName.SelectedIndex;
            npcProperties[(int)npcNum.Value].Priority0 = layerPriority.GetItemChecked(0);
            npcProperties[(int)npcNum.Value].Priority1 = layerPriority.GetItemChecked(1);
            npcProperties[(int)npcNum.Value].Priority2 = layerPriority.GetItemChecked(2);
            npcProperties[(int)npcNum.Value].Shift16pxDown = shift16pxDown.Checked;
            npcProperties[(int)npcNum.Value].YPixelShiftUp = (byte)yPixelShift.Value;
            npcProperties[(int)npcNum.Value].AcuteAxis = (byte)axisAcute.Value;
            npcProperties[(int)npcNum.Value].ObtuseAxis = (byte)axisObtuse.Value;
            npcProperties[(int)npcNum.Value].Height = (byte)height.Value;
            npcProperties[(int)npcNum.Value].B1b2 = unknownBits.GetItemChecked(0);
            npcProperties[(int)npcNum.Value].B1b3 = unknownBits.GetItemChecked(1);
            npcProperties[(int)npcNum.Value].B1b4 = unknownBits.GetItemChecked(2);
            npcProperties[(int)npcNum.Value].B1b5 = unknownBits.GetItemChecked(3);
            npcProperties[(int)npcNum.Value].B1b6 = unknownBits.GetItemChecked(4);
            npcProperties[(int)npcNum.Value].B1b7 = unknownBits.GetItemChecked(5);
            npcProperties[(int)npcNum.Value].B2b0 = unknownBits.GetItemChecked(6);
            npcProperties[(int)npcNum.Value].B2b1 = unknownBits.GetItemChecked(7);
            npcProperties[(int)npcNum.Value].B2b2 = unknownBits.GetItemChecked(8);
            npcProperties[(int)npcNum.Value].B2b3 = unknownBits.GetItemChecked(9);
            npcProperties[(int)npcNum.Value].B2b4 = unknownBits.GetItemChecked(10);
            npcProperties[(int)npcNum.Value].B3b5 = unknownBits.GetItemChecked(11);
            npcProperties[(int)npcNum.Value].B3b6 = unknownBits.GetItemChecked(12);
            npcProperties[(int)npcNum.Value].B3b7 = unknownBits.GetItemChecked(13);
            npcProperties[(int)npcNum.Value].B5b5 = unknownBits.GetItemChecked(14);
            npcProperties[(int)npcNum.Value].B5b6 = unknownBits.GetItemChecked(15);
            npcProperties[(int)npcNum.Value].B5b7 = unknownBits.GetItemChecked(16);
            npcProperties[(int)npcNum.Value].B6b2 = unknownBits.GetItemChecked(17);

            this.Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}