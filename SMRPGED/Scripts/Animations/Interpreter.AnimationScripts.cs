using System;
using System.Collections.Generic;
using System.Text;
using SMRPGED.Properties;

namespace SMRPGED.ScriptsEditor.Commands
{
    public partial class Interpreter
    {
        private UniversalVariables universal = State.Instance.Universal;
        private Settings settings = Settings.Default;

        #region Static Data
        private static string[] AnimationScriptCommands = new string[]
        {
            "Current object = sprite: \"",			// 0x00
            "AMEM $32 = coords: ",			// 0x01
            "",			// 0x02
            "Current sprite: \"",			// 0x03
            "Pause script, resume after ",			// 0x04
            "Remove current object",			// 0x05
            "",			// 0x06
            "Return animation packet",			// 0x07
            "Shift current sprite, ",			// 0x08
            "Jump to address $",			// 0x09
            "{NOOP}",			// 0x0A
            "AMEM $40 = coords: ",			// 0x0B
            "Shift current sprite to coords @ AMEM $40, ",			// 0x0C
            "",			// 0x0D
            "",			// 0x0E
            "",			// 0x0F
			
            "Jump to subroutine $",			// 0x10
            "Return subroutine",			// 0x11
            "",			// 0x12
            "",			// 0x13
            "",			// 0x14
            "",			// 0x15
            "",			// 0x16
            "",			// 0x17
            "",			// 0x18
            "",			// 0x19
            "",			// 0x1A
            "",			// 0x1B
            "",			// 0x1C
            "",			// 0x1D
            "",			// 0x1E
            "",			// 0x1F
			
            "AMEM (8-bit) $",			// 0x20
            "AMEM (16-bit) $",			// 0x21
            "",			// 0x22
            "",			// 0x23
            "If AMEM (8-bit) $",			// 0x24
            "If AMEM (16-bit) $",			// 0x25
            "If AMEM (8-bit) $",			// 0x26
            "If AMEM (16-bit) $",			// 0x27
            "If AMEM (8-bit) $",			// 0x28
            "If AMEM (16-bit) $",			// 0x29
            "If AMEM (8-bit) $",			// 0x2A
            "If AMEM (16-bit) $",			// 0x2B
            "AMEM (8-bit) $",			// 0x2C
            "AMEM (16-bit) $",			// 0x2D
            "AMEM (8-bit) $",			// 0x2E
            "AMEM (16-bit) $",			// 0x2F
			
            "Increment AMEM (8-bit) $",			// 0x30
            "Increment AMEM (16-bit) $",			// 0x31
            "Decrement AMEM (8-bit) $",			// 0x32
            "Decrement AMEM (16-bit) $",			// 0x33
            "Clear AMEM (8-bit) $",			// 0x34
            "Clear AMEM (16-bit) $",			// 0x35
            "Set AMEM $",			// 0x36
            "Clear AMEM $",			// 0x37
            "If set, AMEM $",			// 0x38
            "If clear, AMEM $",			// 0x39
            "",			// 0x3A
            "",			// 0x3B
            "",			// 0x3C
            "",			// 0x3D
            "",			// 0x3E
            "",			// 0x3F
			
            "Pause script until AMEM $",			// 0x40
            "Pause script until AMEM $",			// 0x41
            "",			// 0x42
            "Current sprite sequence playback = ",			// 0x43
            "",			// 0x44
            "AMEM $60 = current target",			// 0x45
            "",			// 0x46
            "",			// 0x47
            "",			// 0x48
            "",			// 0x49
            "",			// 0x4A
            "",			// 0x4B
            "",			// 0x4C
            "",			// 0x4D
            "Pause script until current sprite sequence playback end",			// 0x4E
            "",			// 0x4F
			
            "",			// 0x50
            "If target not dead, jump to address $",			// 0x51
            "",			// 0x52
            "",			// 0x53
            "",			// 0x54
            "",			// 0x55
            "",			// 0x56
            "",			// 0x57
            "",			// 0x58
            "",			// 0x59
            "",			// 0x5A
            "",			// 0x5B
            "",			// 0x5C
            "Run sprite queue @ $",			// 0x5D
            "Return sprite queue",			// 0x5E
            "",			// 0x5F
			
            "",			// 0x60
            "",			// 0x61
            "",			// 0x62
            "Display message from OMEM $60, message type: ",			// 0x63
            "",			// 0x64
            "",			// 0x65
            "",			// 0x66
            "",			// 0x67
            "Run action queue @ $",			// 0x68
            "OMEM $60 = mem 00:072C",			// 0x69
            "Store random # between 0 and ",			// 0x6A
            "Store random # between 0 and ",			// 0x6B
            "",			// 0x6C
            "",			// 0x6D
            "",			// 0x6E
            "",			// 0x6F
			
            "",			// 0x70
            "",			// 0x71
            "Current action object = effect: ",			// 0x72
            "",			// 0x73
            "Pause script until: ",			// 0x74
            "Pause script until: ",			// 0x75
            "",			// 0x76
            "Set graphic properties: ",			// 0x77
            "Set layer priority: ",			// 0x78
            "",			// 0x79
            "Run battle dlg: ",			// 0x7A
            "Pause script, resume on dialogue close",			// 0x7B
            "",			// 0x7C
            "",			// 0x7D
            "Fade-out effect on action object, duration: ",			// 0x7E
            "",			// 0x7F
			
            "",			// 0x80
            "",			// 0x81
            "",			// 0x82
            "",			// 0x83
            "",			// 0x84
            "Fade effect on action object: ",			// 0x85
            "",			// 0x86
            "",			// 0x87
            "",			// 0x88
            "",			// 0x89
            "",			// 0x8A
            "",			// 0x8B
            "",			// 0x8C
            "",			// 0x8D
            "Screen flash color: ",			// 0x8E
            "",			// 0x8F
			
            "",			// 0x90
            "",			// 0x91
            "",			// 0x92
            "",			// 0x93
            "",			// 0x94
            "",			// 0x95
            "",			// 0x96
            "",			// 0x97
            "",			// 0x98
            "",			// 0x99
            "",			// 0x9A
            "",			// 0x9B
            "",			// 0x9C
            "",			// 0x9D
            "",			// 0x9E
            "",			// 0x9F
			
            "",			// 0xA0
            "",			// 0xA1
            "",			// 0xA2
            "",			// 0xA3
            "",			// 0xA4
            "",			// 0xA5
            "",			// 0xA6
            "",			// 0xA7
            "",			// 0xA8
            "",			// 0xA9
            "",			// 0xAA
            "Playback sound: ",			// 0xAB
            "",			// 0xAC
            "",			// 0xAD
            "Playback sound (sync): ",			// 0xAE
            "",			// 0xAF
			
            "Play music: ",			// 0xB0
            "Play music: ",			// 0xB1
            "Stop sound effect",			// 0xB2
            "",			// 0xB3
            "",			// 0xB4
            "",			// 0xB5
            "Fade out current music, speed: ",			// 0xB6
            "",			// 0xB7
            "",			// 0xB8
            "",			// 0xB9
            "",			// 0xBA
            "Set target: ",			// 0xBB
            "",			// 0xBC
            "",			// 0xBD
            "Add value to current coins: ",			// 0xBE
            "Store target Yoshi Cookie to item inventory: ",			// 0xBF
			
            "",			// 0xC0
            "",			// 0xC1
            "",			// 0xC2
            "Mask effect = ",			// 0xC3
            "",			// 0xC4
            "",			// 0xC5
            "Mask effect, set coords:  ",			// 0xC6
            "",			// 0xC7
            "",			// 0xC8
            "",			// 0xC9
            "",			// 0xCA
            "Sprite playback speed = ",			// 0xCB
            "",			// 0xCC
            "",			// 0xCD
            "",			// 0xCE
            "",			// 0xCF
			
            "",			// 0xD0
            "",			// 0xD1
            "",			// 0xD2
            "",			// 0xD3
            "",			// 0xD4
            "",			// 0xD5
            "",			// 0xD6
            "",			// 0xD7
            "",			// 0xD8
            "Display \"Can\'t run\" message",			// 0xD9
            "",			// 0xDA
            "",			// 0xDB
            "",			// 0xDC
            "",			// 0xDD
            "",			// 0xDE
            "",			// 0xDF
			
            "Store OMEM $60 to item inventory",			// 0xE0
            "Run battle event: ",			// 0xE1
            "",			// 0xE2
            "",			// 0xE3
            "",			// 0xE4
            "",			// 0xE5
            "",			// 0xE6
            "",			// 0xE7
            "",			// 0xE8
            "",			// 0xE9
            "",			// 0xEA
            "",			// 0xEB
            "",			// 0xEC
            "",			// 0xED
            "",			// 0xEE
            "",			// 0xEF
			
            "",			// 0xF0
            "",			// 0xF1
            "",			// 0xF2
            "",			// 0xF3
            "",			// 0xF4
            "",			// 0xF4
            "",			// 0xF6
            "",			// 0xF7
            "",			// 0xF8
            "",			// 0xF9
            "",			// 0xFA
            "",			// 0xFB
            "",			// 0xFC
            "",         // 0xFD
            "",         // 0xFE
            ""			// 0xFF
        };
        private string[] effectNames = new string[]
        {
            "___DUMMY",
            "___DUMMY",
            "thundershock",
            "thundershock effect",
            "crusher",
            "meteor blast",
            "bolt",
            "star rain",
            "flame engulf",
            "mute balloon",
            "flame stone",
            "bowser crush",
            "spell cast spade",
            "spell cast heart",
            "spell cast club",
            "spell cast diamond",
            "spell cast star",
            "terrorize",
            "snowy snow 1",
            "snowy snow 2",
            "endobubble black ball",
            "___DUMMY",
            "solidify",
            "___DUMMY",
            "___DUMMY",
            "psych bomb sphere",
            "___DUMMY",
            "black star rain",
            "blue orb/ball",
            "___DUMMY",
            "___DUMMY",
            "___DUMMY",
            "Geno whirl",
            "___DUMMY",
            "___DUMMY",
            "___DUMMY",
            "blank white flash",
            "blank white flash",
            "boulder",
            "black ball/orb",
            "blank blue flash",
            "blank red flash",
            "blank blue flash",
            "blank red flash",
            "___DUMMY",
            "black flash",
            "black flash",
            "meteor shower snow/confetti",
            "black flash",
            "black flash",
            "dark red bomb blast",
            "dark blue bomb blast",
            "greenish snow/confetti",
            "blue bomb blast",
            "black ball/orb",
            "red ball/orb",
            "green ball/orb",
            "greyish-red snow/confetti",
            "red snow/confetti",
            "fire bomb",
            "ice bomb/solidify BG",
            "static e!",
            "green star bunches",
            "blue star bunches",
            "pink star bunches",
            "yellow star bunches",
            "aurora flash",
            "storm",
            "electroshock",
            "treasure head spell 1",
            "treasure head spell 2",
            "treasure head spell 3",
            "treasure head spell 4",
            "___DUMMY",
            "___DUMMY",
            "___DUMMY",
            "flame wall",
            "petals",
            "faster petals",
            "drain beam",
            "drain beam effect",
            "___DUMMY",
            "electric bolt",
            "black flash",
            "___DUMMY",
            "dark yellow pollen",
            "geno beam",
            "geno beam - red",
            "geno beam - gold",
            "geno beam - yellow",
            "geno beam - green",
            "thunderbolt",
            "light beam",
            "meteor shower stars",
            "purple pollen",
            "HP rain - blue",
            "HP rain - dark blue",
            "wavy dark blue lines",
            "wavy blue lines",
            "wavy red lines",
            "wavy brown lines",
            "sand storm sand",
            "sledge",
            "arrow rain BG",
            "spear rain BG",
            "sword rain BG",
            "lightning orb dome waves",
            "echofinder",
            "poison gas BG 1",
            "poison gas BG 2",
            "poison gas green BG",
            "beige beam effect",
            "molten liquid Smelter",
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
            "___DUMMY"};
        private static string[] BattleSoundNames = new string[]
        {
            "[000]  ____",
            "[001]  select action/menu",
            "[002]  cancel action/menu",
            "[003]  move cursor",
            "[004]  Mario's jump",
            "[005]  birdie tweet",
            "[006]  flower bonus/status up",
            "[007]  error/incorrect answer",
            "[008]  get dizzy",
            "[009]  arrow sling",
            "[010]  punch",
            "[011]  swoosh/run away",
            "[012]  bomb explosion",
            "[013]  coin",
            "[014]  grab flower",
            "[015]  spike strike",
            "[016]  bite",
            "[017]  falling stars (electroshock?)",
            "[018]  shell kick",
            "[019]  Drain Beam",
            "[020]  Aurora Flash",
            "[021]  wing flaps",
            "[022]  Electroshock shock",
            "[023]  small laser?",
            "[024]  ____",
            "[025]  wing hit",
            "[026]  Flame Wall",
            "[027]  grab item/1-UP",
            "[028]  Flame",
            "[029]  Drain",
            "[030]  Fire Orb multiple orb hit",
            "[031]  Fire Orb background burn",
            "[032]  Fire Orb finish",
            "[033]  kick?",
            "[034]  spike shot",
            "[035]  Bombs Away power up",
            "[036]  Snowy gathering snow",
            "[037]  monster/item toss",
            "[038]  hit by tossed item",
            "[039]  claw strike",
            "[040]  K-9 fang hit",
            "[041]  Hammer Bro hammer hit",
            "[042]  Johnnys Skewer strike",
            "[043]  casting a spell",
            "[044]  Thunderbolt second strike",
            "[045]  HP Rain cloud",
            "[046]  bounce",
            "[047]  dry clunk",
            "[048]  Marios punch",
            "[049]  cymbal crash",
            "[050]  tiny shell hit",
            "[051]  Super Flame multiple orb hit",
            "[052]  Finger Shot/Bullets",
            "[053]  Thwomp hit ground",
            "[054]  hammer hit from Hammer Time",
            "[055]  Marios hammer hit",
            "[056]  super/ultra jump 1-UP sound",
            "[057]  Water Blast spout?",
            "[058]  Marios shell kick up",
            "[059]  Marios shell kick forward",
            "[060]  cymbal resonance",
            "[061]  use item",
            "[062]  monster run away",
            "[063]  ignition from Geno Blast",
            "[064]  egg hatch",
            "[065]  Yoshi cant make cookie",
            "[066]  Recover HP/MP",
            "[067]  stars?",
            "[068]  rain cloud",
            "[069]  Geno power up",
            "[070]  Geno Beam",
            "[071]  drum roll (Psycopath/Roulette)",
            "[072]  rain cloud appears",
            "[073]  correct password",
            "[074]  quack?",
            "[075]  Yoshi talk",
            "[076]  Yoshi make item",
            "[077]  stat boost (Geno Boost)",
            "[078]  timed stat boost",
            "[079]  rumble",
            "[080]  hit",
            "[081]  hit",
            "[082]  big hit",
            "[083]  Dry Bones hit",
            "[084]  big hit",
            "[085]  Jinxs Triple Kick kick",
            "[086]  long fall",
            "[087]  Lazy Shell kick",
            "[088]  ticking bomb",
            "[089]  enemy defeated (common explosion)",
            "[090]  valor up?",
            "[091]  ____",
            "[092]  fall",
            "[093]  Shocker 1",
            "[094]  Shocker 2",
            "[095]  Bowsers Crusher?",
            "[096]  Boulder",
            "[097]  toss",
            "[098]  click",
            "[099]  Willy Wisp",
            "[100]  Electroshock sparks",
            "[101]  electricity?",
            "[102]  Static E!",
            "[103]  Crystal hits",
            "[104]  Blizzard",
            "[105]  Rock Candy",
            "[106]  Light Beam",
            "[107]  squeak then hit?",
            "[108]  howl",
            "[109]  bullet shot",
            "[110]  huge explosion",
            "[111]  Heavy Troopa land?",
            "[112]  swing",
            "[113]  shot",
            "[114]  Spikey attack",
            "[115]  hit",
            "[116]  Terrapin hit",
            "[117]  sting?",
            "[118]  jolt?",
            "[119]  Meteor Swarm/Snowy",
            "[120]  deep swallow",
            "[121]  big swing",
            "[122]  arrow shot?",
            "[123]  Chomp bite",
            "[124]  Goomba run forward",
            "[125]  spike shot",
            "[126]  big object bounces",
            "[127]  ???",
            "[128]  Lil Boo approaches",
            "[129]  throw?",
            "[130]  Valor Up/Vigor Up",
            "[131]  Come Back summon star?",
            "[132]  little beep",
            "[133]  lullaby",
            "[134]  hit",
            "[135]  hit",
            "[136]  Lil Boo approaches",
            "[137]  heavy machine stomp",
            "[138]  Endobubble",
            "[139]  guitar string?",
            "[140]  Come Back star",
            "[141]  lullaby",
            "[142]  tongue noise?",
            "[143]  toss something",
            "[144]  Lightning Orb",
            "[145]  ???",
            "[146]  slap",
            "[147]  ____",
            "[148]  finger shot/arm cannon",
            "[149]  enemy jumps high",
            "[150]  enemy taunts then hits",
            "[151]  spores",
            "[152]  hit",
            "[153]  deep weird voice",
            "[154]  buzzing bee",
            "[155]  Sparky hit",
            "[156]  Chomp bite",
            "[157]  weird enemy hit",
            "[158]  tongue swing?",
            "[159]  big deep hit",
            "[160]  wing slap",
            "[161]  ____",
            "[162]  ____",
            "[163]  ____",
            "[164]  ____",
            "[165]  ____",
            "[166]  ____",
            "[167]  ____",
            "[168]  ____",
            "[169]  ____",
            "[170]  ____",
            "[171]  ____",
            "[172]  ____",
            "[173]  ____",
            "[174]  ____",
            "[175]  ____",
            "[176]  fade-out",
            "[177]  ____",
            "[178]  ____",
            "[179]  ____",
            "[180]  ____",
            "[181]  ____",
            "[182]  ____",
            "[183]  ____",
            "[184]  ____",
            "[185]  ____",
            "[186]  ____",
            "[187]  ____",
            "[188]  Petal Blast",
            "[189]  ???",
            "[190]  Come Back",
            "[191]  monster call",
            "[192]  big shell kick",
            "[193]  big shell hit 1",
            "[194]  big shell hit 2",
            "[195]  explosive attack",
            "[196]  hovering attack",
            "[197]  smash",
            "[198]  Ice Rock",
            "[199]  Arrow Rain",
            "[200]  Spear Rain",
            "[201]  Sword Rain",
            "[202]  Corona 1",
            "[203]  Corona 2",
            "[204]  chomping",
            "[205]  Jinxed",
            "[206]  monster swing",
            "[207]  monster taunt",
            "[208]  Smithy Form 1 - light up",
            "[209]  Smithy Form 1 - transform",
            "[210]  Booster Express train horn"
        };
        #endregion
        public string InterpretAnimationCommand(AnimationScriptCommand asc)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(AnimationScriptCommands[asc.Opcode]);
            switch (asc.Opcode)
            {
                case 0x01:
                case 0x0B:
                    sb.Append("X=" + (short)BitManager.GetShort(asc.AnimationData, 2) + ",");
                    sb.Append("Y=" + (short)BitManager.GetShort(asc.AnimationData, 4) + ",");
                    sb.Append("Z=" + (short)BitManager.GetShort(asc.AnimationData, 6) + ", offset @ ");
                    switch ((asc.AnimationData[1] & 0xF0) >> 4)
                    {
                        case 0: sb.Append("absolute coords"); break;
                        case 1: sb.Append("caster's initial coords"); break;
                        case 2: sb.Append("target's current coords"); break;
                        case 3: sb.Append("caster's current coords"); break;
                    }
                    break;
                case 0x08:
                    sb.Append("acceleration = " + BitManager.GetShort(asc.AnimationData, 6) + ", ");
                    sb.Append("start val = " + BitManager.GetShort(asc.AnimationData, 2) + ", ");
                    sb.Append("end val = " + BitManager.GetShort(asc.AnimationData, 4) + ", ");
                    sb.Append("apply to axis: ");
                    sb.Append(GetBits((byte)(asc.Option & 0x07), new string[] { "Z", "Y", "X" }, 3));
                    break;
                case 0x0C:
                    switch (asc.Option)
                    {
                        case 0x02: sb.Append("shift, "); break;
                        case 0x04: sb.Append("transfer, "); break;
                    }
                    sb.Append("speed=" + BitManager.GetShort(asc.AnimationData, 2) + ", ");
                    sb.Append("archHeight=" + BitManager.GetShort(asc.AnimationData, 4));
                    break;
                case 0x00:
                case 0x03:
                    sb.Append(settings.SpriteNames[BitManager.GetShort(asc.AnimationData, 3) & 0x3FF] + "\"");
                    sb.Append(", playback seq = " + asc.AnimationData[5].ToString());
                    sb.Append(", coords = AMEM $32");
                    break;
                case 0x04:
                    switch (asc.Option)
                    {
                        case 0x06: sb.Append("sprite shift is complete");
                            break;
                        case 0x10: sb.Append(BitManager.GetShort(asc.AnimationData, 2) + " frames");
                            break;
                    }
                    break;
                case 0x09:
                case 0x10:
                case 0x51:
                    sb.Append(((asc.InternalOffset & 0xFF0000) >> 16).ToString("X2"));
                    sb.Append(BitManager.GetShort(asc.AnimationData, 1).ToString("X4"));
                    break;
                case 0x20:
                case 0x21:
                    sb.Append(((asc.Option & 0x0F) + 0x60).ToString("X2") + " = ");
                    switch ((asc.Option & 0xF0) >> 4)
                    {
                        case 0: sb.Append("");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString()); break;
                        case 1: sb.Append("mem $7E:");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 2: sb.Append("mem $7F:");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 3: sb.Append("AMEM $");
                            sb.Append((asc.AnimationData[2] + 0x60).ToString("X2")); break;
                        case 5: sb.Append("mem $7E:");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 6: sb.Append("OMEM $");
                            sb.Append((asc.AnimationData[2]).ToString("X2")); break;
                    }
                    break;
                case 0x22:
                case 0x23:
                    switch ((asc.Option & 0xF0) >> 4)
                    {
                        case 0: sb.Append("N/A"); break;
                        case 1: sb.Append("Mem $7E:");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 2: sb.Append("Mem $7F:");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 3: sb.Append("AMEM $");
                            sb.Append((asc.AnimationData[2] + 0x60).ToString("X2")); break;
                        case 5: sb.Append("Mem $7E:");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 6: sb.Append("OMEM $");
                            sb.Append((asc.AnimationData[2]).ToString("X2")); break;
                    }
                    sb.Append(" = AMEM $" + ((asc.Option & 0x0F) + 0x60).ToString("X2"));
                    break;
                case 0x24:
                case 0x25:
                    sb.Append(((asc.Option & 0x0F) + 0x60).ToString("X2") + " = ");
                    switch ((asc.Option & 0xF0) >> 4)
                    {
                        case 0: sb.Append("");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString()); break;
                        case 1: sb.Append("mem $7E:");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 2: sb.Append("mem $7F:");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 3: sb.Append("AMEM $");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 5: sb.Append("mem $7E:");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 6: sb.Append("OMEM $");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                    }
                    sb.Append(", jump to $" + ((asc.InternalOffset & 0xFF0000) >> 16).ToString("X2"));
                    sb.Append(BitManager.GetShort(asc.AnimationData, 4).ToString("X4"));
                    break;
                case 0x26:
                case 0x27:
                    sb.Append(((asc.Option & 0x0F) + 0x60).ToString("X2") + " != ");
                    switch ((asc.Option & 0xF0) >> 4)
                    {
                        case 0: sb.Append("");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString()); break;
                        case 1: sb.Append("mem $7E:");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 2: sb.Append("mem $7F:");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 3: sb.Append("AMEM $");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 5: sb.Append("mem $7E:");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 6: sb.Append("OMEM $40");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                    }
                    sb.Append(", jump to $" + ((asc.InternalOffset & 0xFF0000) >> 16).ToString("X2"));
                    sb.Append(BitManager.GetShort(asc.AnimationData, 4).ToString("X4"));
                    break;
                case 0x28:
                case 0x29:
                    sb.Append(((asc.Option & 0x0F) + 0x60).ToString("X2") + " < ");
                    switch ((asc.Option & 0xF0) >> 4)
                    {
                        case 0: sb.Append("");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString()); break;
                        case 1: sb.Append("mem $7E:");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 2: sb.Append("mem $7F:");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 3: sb.Append("AMEM $");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 5: sb.Append("mem $7E:");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 6: sb.Append("OMEM $40");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                    }
                    sb.Append(", jump to $" + ((asc.InternalOffset & 0xFF0000) >> 16).ToString("X2"));
                    sb.Append(BitManager.GetShort(asc.AnimationData, 4).ToString("X4"));
                    break;
                case 0x2A:
                case 0x2B:
                    sb.Append(((asc.Option & 0x0F) + 0x60).ToString("X2") + " >= ");
                    switch ((asc.Option & 0xF0) >> 4)
                    {
                        case 0: sb.Append("");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString()); break;
                        case 1: sb.Append("mem $7E:");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 2: sb.Append("mem $7F:");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 3: sb.Append("AMEM $");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 5: sb.Append("mem $7E:");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 6: sb.Append("OMEM $40");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                    }
                    sb.Append(", jump to $" + ((asc.InternalOffset & 0xFF0000) >> 16).ToString("X2"));
                    sb.Append(BitManager.GetShort(asc.AnimationData, 4).ToString("X4"));
                    break;
                case 0x2C:
                case 0x2D:
                    sb.Append(((asc.Option & 0x0F) + 0x60).ToString("X2") + " += ");
                    switch ((asc.Option & 0xF0) >> 4)
                    {
                        case 0: sb.Append("");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString()); break;
                        case 1: sb.Append("mem $7E:");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 2: sb.Append("mem $7F:");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 3: sb.Append("AMEM $");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 5: sb.Append("mem $7E:");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 6: sb.Append("OMEM $40");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                    }
                    break;
                case 0x2E:
                case 0x2F:
                    sb.Append(((asc.Option & 0x0F) + 0x60).ToString("X2") + " -= ");
                    switch ((asc.Option & 0xF0) >> 4)
                    {
                        case 0: sb.Append("");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString()); break;
                        case 1: sb.Append("mem $7E:");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 2: sb.Append("mem $7F:");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 3: sb.Append("AMEM $");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 5: sb.Append("mem $7E:");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 6: sb.Append("OMEM $40");
                            sb.Append((BitManager.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                    }
                    break;
                case 0x30:
                case 0x31:
                case 0x32:
                case 0x33:
                case 0x34:
                case 0x35:
                    sb.Append(((asc.Option & 0x0F) + 0x60).ToString("X2"));
                    break;
                case 0x36:
                case 0x37:
                    sb.Append(((asc.Option & 0x0F) + 0x60).ToString("X2") + ", bits: ");
                    sb.Append(
                        GetBits(asc.AnimationData[2],
                        new string[] { "0", "1", "2", "3", "4", "5", "6", "7" }, 8));
                    break;
                case 0x38:
                case 0x39:
                    sb.Append(((asc.Option & 0x0F) + 0x60).ToString("X2") + ", bits: ");
                    sb.Append(
                        GetBits(asc.AnimationData[2],
                        new string[] { "0", "1", "2", "3", "4", "5", "6", "7" }, 8));
                    sb.Append(", jump to $" + ((asc.InternalOffset & 0xFF0000) >> 16).ToString("X2"));
                    sb.Append(BitManager.GetShort(asc.AnimationData, 3).ToString("X4"));
                    break;
                case 0x40:
                    sb.Append(((asc.Option & 0x0F) + 0x60).ToString("X2") + ", bits are set: ");
                    sb.Append(
                        GetBits(asc.AnimationData[2],
                        new string[] { "0", "1", "2", "3", "4", "5", "6", "7" }, 8));
                    break;
                case 0x41:
                    sb.Append(((asc.Option & 0x0F) + 0x60).ToString("X2") + ", bits are clear: ");
                    sb.Append(
                        GetBits(asc.AnimationData[2],
                        new string[] { "0", "1", "2", "3", "4", "5", "6", "7" }, 8));
                    break;
                case 0x5D:
                    sb.Append(((asc.InternalOffset & 0xFF0000) >> 16).ToString("X2"));
                    sb.Append(BitManager.GetShort(asc.AnimationData, 3).ToString("X4"));
                    sb.Append(", sprite = ");
                    switch (asc.Option & 0xF8)
                    {
                        case 0x08: sb.Append("slot"); break;
                        case 0x10: sb.Append("???"); break;
                        case 0x20: sb.Append("???"); break;
                        case 0x40: sb.Append("target"); break;
                        case 0x80: sb.Append("???"); break;
                    }
                    sb.Append(" #" + asc.AnimationData[2]);
                    break;
                case 0x63:
                    switch (asc.Option)
                    {
                        case 0x00: sb.Append("attack name"); break;
                        case 0x01: sb.Append("spell name"); break;
                        case 0x02: sb.Append("item name"); break;
                    }
                    break;
                case 0x68:
                    sb.Append(((asc.InternalOffset & 0xFF0000) >> 16).ToString("X2"));
                    sb.Append(BitManager.GetShort(asc.AnimationData, 1).ToString("X4"));
                    sb.Append(", packet = AMEM $60, animation = ");
                    sb.Append(asc.AnimationData[3].ToString());
                    break;
                case 0x6A:
                    sb.Append(asc.AnimationData[2] + " to AMEM $");
                    sb.Append(((asc.Option & 0x0F) + 0x60).ToString("X2"));
                    break;
                case 0x6B:
                    sb.Append(BitManager.GetShort(asc.AnimationData, 2) + " to AMEM $");
                    sb.Append(((asc.Option & 0x0F) + 0x60).ToString("X2"));
                    break;
                case 0x72:
                    sb.Append("\"[" + asc.AnimationData[2].ToString("d3") + "] " + effectNames[asc.AnimationData[2]] + "\"");
                    break;
                case 0x7A:
                    switch (asc.Option)
                    {
                        case 0x00:
                            sb.Append("[" + asc.AnimationData[2].ToString("X2") + "] \"" +
                                universal.BattleDialogues[asc.AnimationData[2]].GetBattleDialogueStub() + "\", type = ");
                            sb.Append("battle dialogue"); break;
                        case 0x01:
                            sb.Append("[" + asc.AnimationData[2].ToString("X2") + "] \"" +
                                "..." + "\", type = ");
                            sb.Append("psychopath message"); break;
                        case 0x02:
                            sb.Append("[" + asc.AnimationData[2].ToString("X2") + "] \"" +
                                "..." + "\", type = ");
                            sb.Append("spell dialogue"); break;
                    }
                    break;
                case 0x43:
                    sb.Append((asc.Option & 0x0F) + ", infinite playback = ");
                    sb.Append(((asc.Option & 0x10) == 0x10 ? "true" : "false"));
                    sb.Append(", playback once = ");
                    sb.Append(((asc.Option & 0x20) == 0x20 ? "true" : "false"));
                    sb.Append(", mirror = ");
                    sb.Append(((asc.Option & 0x80) == 0x80 ? "true" : "false"));
                    break;
                case 0x7E:
                case 0xC3:
                case 0xCB:
                    sb.Append(asc.Option); break;
                case 0x85:
                    sb.Append("duration = " + asc.AnimationData[2]);
                    break;
                case 0xAB:
                case 0xAE:
                    if (asc.Option < BattleSoundNames.Length)
                        sb.Append(BattleSoundNames[asc.Option]);
                    else
                        sb.Append("{NOTHING}");
                    break;
                case 0xB0:
                    sb.Append(asc.Option); break;
                case 0xB1:
                    sb.Append(asc.Option + ", volume: " + BitManager.GetShort(asc.AnimationData, 2)); break;
                case 0xC6:
                    for (int i = 0; i < asc.Option; i++)
                    {
                        if (i % 2 == 0)
                            sb.Append("(" + (sbyte)asc.AnimationData[i + 2] + ",");
                        else
                            sb.Append((sbyte)asc.AnimationData[i + 2] + ")");
                        if (i % 2 != 0 && i < asc.Option - 1)
                            sb.Append(", ");
                    }
                    break;
                case 0x74:
                    switch (asc.AnimationData[2])
                    {
                        case 0x02:
                            sb.Append("fade-in effect complete"); break;
                        case 0x04:
                            sb.Append("fade-out effect complete (4bpp)"); break;
                        case 0x08:
                            sb.Append("fade-out effect complete (2bpp)"); break;
                        default:
                            sb.Append("bits " + BitManager.GetShort(asc.AnimationData, 1).ToString("X4") + " set"); break;
                    }
                    break;
                case 0x75:
                    sb.Append("bits " + BitManager.GetShort(asc.AnimationData, 1).ToString("X4") + " clear"); break;
                case 0x77:
                    sb.Append((asc.Option >> 4) + ", ");
                    if ((asc.Option & 0x02) == 0x02) sb.Append("4bpp = true  ");
                    if ((asc.Option & 0x04) == 0x04) sb.Append("2bpp = true");
                    break;
                case 0x78:
                    sb.Append((asc.Option & 0x0F) + ", upper bits: " + (asc.Option >> 4));
                    break;
                case 0xBB:
                    sb.Append(settings.TargetNames[asc.Option]);
                    break;
                case 0xBC:
                case 0xBD:
                    if (asc.AnimationData[2] == 0xFF)
                    {
                        sb.Append("Remove item from" + (asc.Opcode == 0xBD ? " special" : "") + " item inventory: ");
                        sb.Append(
                            universal.ItemNames.GetNameByNum(Math.Abs((short)BitManager.GetShort(asc.AnimationData, 1))));
                    }
                    else
                    {
                        sb.Append("Store item to" + (asc.Opcode == 0xBD ? " special" : "") + " item inventory: ");
                        sb.Append(universal.ItemNames.GetNameByNum(BitManager.GetShort(asc.AnimationData, 1)));
                    }
                    break;
                case 0xBE:
                    sb.Append(BitManager.GetShort(asc.AnimationData, 1));
                    break;
                case 0xB6:
                    sb.Append(asc.Option + ", volume: " + asc.AnimationData[2]);
                    break;
                case 0x8E:
                    switch (asc.Option & 0x0F)
                    {
                        case 0x00: sb.Append("{none}"); break;
                        case 0x01: sb.Append("red"); break;
                        case 0x02: sb.Append("green"); break;
                        case 0x03: sb.Append("yellow"); break;
                        case 0x04: sb.Append("blue"); break;
                        case 0x05: sb.Append("pink"); break;
                        case 0x06: sb.Append("aqua"); break;
                        case 0x07: sb.Append("white"); break;
                    }
                    sb.Append(", duration: " + asc.AnimationData[2]);
                    break;
                case 0xE1:
                    sb.Append(BitManager.GetShort(asc.AnimationData, 1) + ", offset: " + asc.AnimationData[3]);
                    break;
                default:
                    if (AnimationScriptCommands[asc.Opcode] == "")
                        sb.Append(BitConverter.ToString(asc.AnimationData));
                    break;
            }
            return sb.ToString();
        }
        private string GetBits(byte src, string[] names, int length)
        {
            string bits = "";
            string[] bit = new string[8];
            bool pre = false;

            for (int i = 1, j = 0; j < length; i *= 2, j++)
            {
                if ((src & i) == i)
                {
                    if (pre && j > 0)
                        bit[j] = ", ";
                    bit[j] += names[j];
                    pre = true;
                }
                else bit[j] = "";
            }
            for (int k = 0; k < 8; k++)
                bits += bit[k];

            return bits;
        }
    }
}
