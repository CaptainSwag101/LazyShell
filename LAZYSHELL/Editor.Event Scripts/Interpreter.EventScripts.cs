using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.ScriptsEditor.Commands
{
    public partial class Interpreter
    {
        #region Static Data
        private static string[] EventScriptCommands = new string[]
        {
            "Obj: Mario, ",			// 0x00
            "Obj: Toadstool, ",			// 0x01
            "Obj: Bowser, ",			// 0x02
            "Obj: Geno, ",			// 0x03
            "Obj: Mallow, ",			// 0x04
            "Obj: DUMMY 0x05, ",			// 0x05
            "Obj: DUMMY 0x06, ",			// 0x06
            "Obj: DUMMY 0x07, ",			// 0x07
            "Obj: Character in Slot 1, ",			// 0x08
            "Obj: Character in Slot 2, ",			// 0x09
            "Obj: Character in Slot 3, ",			// 0x0A
            "Obj: DUMMY 0x0B, ",			// 0x0B
            "Obj: Screen Focus, ",			// 0x0C
            "Obj: Layer 1, ",			// 0x0D
            "Obj: Layer 2, ",			// 0x0E
            "Obj: Layer 3, ",			// 0x0F
			
            "Obj: Mem $70A8, ",			// 0x10
            "Obj: Mem $70A9, ",			// 0x11
            "Obj: Mem $70AA, ",			// 0x12
            "Obj: Mem $70AB, ",			// 0x13
            "Obj: NPC #0, ",			// 0x14
            "Obj: NPC #1, ",			// 0x15
            "Obj: NPC #2, ",			// 0x16
            "Obj: NPC #3, ",			// 0x17
            "Obj: NPC #4, ",			// 0x18
            "Obj: NPC #5, ",			// 0x19
            "Obj: NPC #6, ",			// 0x1A
            "Obj: NPC #7, ",			// 0x1B
            "Obj: NPC #8, ",			// 0x1C
            "Obj: NPC #9, ",			// 0x1D
            "Obj: NPC #10, ",			// 0x1E
            "Obj: NPC #11, ",			// 0x1F
			
            "Obj: NPC #12, ",			// 0x20
            "Obj: NPC #13, ",			// 0x21
            "Obj: NPC #14, ",			// 0x22
            "Obj: NPC #15, ",			// 0x23
            "Obj: NPC #16, ",			// 0x24
            "Obj: NPC #17, ",			// 0x25
            "Obj: NPC #18, ",			// 0x26
            "Obj: NPC #19, ",			// 0x27
            "Obj: NPC #20, ",			// 0x28
            "Obj: NPC #21, ",			// 0x29
            "Obj: NPC #22, ",			// 0x2A
            "Obj: NPC #23, ",			// 0x2B
            "Obj: NPC #24, ",			// 0x2C
            "Obj: NPC #25, ",			// 0x2D
            "Obj: NPC #26, ",			// 0x2E
            "Obj: NPC #27, ",			// 0x2F
			
            "Freeze all objects until return",			// 0x30
            "Unfreeze all objects",			// 0x31
            "If present, obj: ",			// 0x32
            "UNKCMD 0x33",			// 0x33
            "Joypad (reset @ return) disable: ",			// 0x34
            "Joypad disable: ",			// 0x35
            "Activate party member: ",			// 0x36
            "Mem $7000 = party capacity",			// 0x37
            "Mem $7000 = character @ slot: ",			// 0x38
            "If Mario on top of obj: ",			// 0x39
            "If distance between obj: ",			// 0x3A
            "If distance between obj: ",			// 0x3B
            "UNKCMD 0x3C",			// 0x3C
            "If Mario in air, jump to $",			// 0x3D
            "Create new NPC, packet: ",			// 0x3E
            "Create new NPC, packet: ",			// 0x3F
			
            "Run sync event: ",			// 0x40
            "UNKCMD 0x41",			// 0x41
            "If Mario on top of an obj, jump to $",			// 0x42
            "UNKCMD 0x43",			// 0x43
            "UNKCMD 0x44",			// 0x44
            "UNKCMD 0x45",			// 0x45
            "UNKCMD 0x46",			// 0x46
            "UNKCMD 0x47",			// 0x47
            "UNKCMD 0x48",			// 0x48
            "Engage battle, pack @ $700E",			// 0x49
            "Engage battle, pack: ",			// 0x4A
            "Open, world map point: ",			// 0x4B
            "Open, shop menu: ",			// 0x4C
            "UNKCMD 0x4D",			// 0x4D
            "Run common event: ",			// 0x4E
            "Open, window: ",			// 0x4F
			
            "Inventory store x1, item: ",			// 0x50
            "Inventory remove x1, item: ",			// 0x51
            "Add to coins: ",			// 0x52
            "Add to frog coins: ",			// 0x53
            "Equip to character: ",			// 0x54
            "Mem $7000 = open item slots",			// 0x55
            "HP -= mem $7000, character: ",			// 0x56
            "FP -= mem $7000",			// 0x57
            "Mem $7000 = current FP",			// 0x58
            "UNKCMD 0x59",			// 0x59
            "UNKCMD 0x5A",			// 0x5A
            "UNKCMD 0x5B",			// 0x5B
            "UNKCMD 0x5C",			// 0x5C
            "UNKCMD 0x5D",			// 0x5D
            "UNKCMD 0x5E",			// 0x5E
            "UNKCMD 0x5F",			// 0x5F
			
            "Run dlg: ",			// 0x60
            "Run dlg: mem $7000",			// 0x61
            "Run timed dlg: ",			// 0x62
            "Append to dlg: mem $7000, ",			// 0x63
            "Close dlg",			// 0x64
            "Un-sync dlg",			// 0x65
            "If dlg option B selected, jump to $",			// 0x66
            "If dlg option B selected, jump to $",			// 0x67
            "Open level: [",			// 0x68
            "UNKCMD 0x69",			// 0x69
            "Modify layer of level: ",			// 0x6A
            "Modify solidity of level: ",			// 0x6B
            "UNKCMD 0x6C",			// 0x6C
            "UNKCMD 0x6D",			// 0x6D
            "UNKCMD 0x6E",			// 0x6E
            "UNKCMD 0x6F",			// 0x6F
			
            "Fade-in from black (sync)",			// 0x70
            "Fade-in from black (async)",			// 0x71
            "Fade-in from black (sync), duration: ",			// 0x72
            "Fade-in from black (async), duration: ",			// 0x73
            "Fade-out to black (sync)",			// 0x74
            "Fade-out to black (async)",			// 0x75
            "Fade-out to black (sync), duration: ",			// 0x76
            "Fade-out to black (async), duration: ",			// 0x77
            "Fade-in from color: ",			// 0x78
            "Fade-out to color: ",			// 0x79
            "BG star frame expand",			// 0x7A
            "BG star frame shrink",			// 0x7B
            "BG circle frame expand",			// 0x7C
            "BG circle frame shrink",			// 0x7D
            "BG battle frame close",			// 0x7E
            "UNKCMD 0x7F",			// 0x7F
			
            "Layer tinting, color: ",			// 0x80
            "Layer priorities, set: ",			// 0x81
            "Layer priorities, set to default",			// 0x82
            "Screen flash, color: ",			// 0x83
            "Layer pixels, size: x",			// 0x84
            "UNKCMD 0x85",			// 0x85
            "UNKCMD 0x86",			// 0x86
            "Closing circle effect (non-static), to obj: ",			// 0x87
            "UNKCMD 0x88",			// 0x88
            "Palette transform, set: ",			// 0x89
            "Palette set, set: ",			// 0x8A
            "UNKCMD 0x8B",			// 0x8B
            "UNKCMD 0x8C",			// 0x8C
            "UNKCMD 0x8D",			// 0x8D
            "UNKCMD 0x8E",			// 0x8E
            "Closing circle effect (static), to obj: ",			// 0x8F
			
            "Playback start current volume, track: ",			// 0x90
            "Playback start default volume, track: ",			// 0x91
            "Playback fade-in, track: ",			// 0x92
            "Playback fade-out track",			// 0x93
            "Playback stop track",			// 0x94
            "Playback fade-out track, duration: ",			// 0x95
            "UNKCMD 0x96",			// 0x96
            "Playback adjust track tempo, duration: ",			// 0x97
            "Playback adjust track pitch, duration: ",			// 0x98
            "UNKCMD 0x99",			// 0x99
            "UNKCMD 0x9A",			// 0x9A
            "Playback stop sound",			// 0x9B
            "Playback start, sound: ",			// 0x9C
            "Playback start, sound: ",			// 0x9D
            "Playback fade-out sound, duration: ",			// 0x9E
            "UNKCMD 0x9F",			// 0x9F
			
            "Set mem $",			// 0xA0
            "Set mem $",			// 0xA1
            "Set mem $",			// 0xA2
            "Set mem @ mem $7000",			// 0xA3
            "Clear mem $",			// 0xA4
            "Clear mem $",			// 0xA5
            "Clear mem $",			// 0xA6
            "Clear mem @ mem $7000",			// 0xA7
            "Mem $",			// 0xA8
            "Mem $",			// 0xA9
            "Mem $",			// 0xAA
            "Mem $",			// 0xAB
            "Mem $7000 = ",			// 0xAC
            "Mem $7000 += ",			// 0xAD
            "Mem $7000 increment",			// 0xAE
            "Mem $7000 increment",			// 0xAF
			
            "Mem $",			// 0xB0
            "Mem $",			// 0xB1
            "Mem $",			// 0xB2
            "Mem $",			// 0xB3
            "Mem $7000 = mem $",			// 0xB4
            "Mem $",			// 0xB5
            "Mem $7000 = random # less than: ",			// 0xB6
            "Mem $",			// 0xB7
            "Mem $7000 += mem $",			// 0xB8
            "Mem $7000 -= mem $",			// 0xB9
            "Mem $7000 = mem $",			// 0xBA
            "Mem $",			// 0xBB
            "Mem $",			// 0xBC
            "Mem $",			// 0xBD
            "UNKCMD 0xBE",			// 0xBE
            "UNKCMD 0xBF",			// 0xBF
			
            "Mem compare $7000 to ",			// 0xC0
            "Mem compare $7000 to mem $",			// 0xC1
            "Mem compare 00:",			// 0xC2
            "Mem $7000 = current level",			// 0xC3
            "Mem $7000 = X coord of obj: ",			// 0xC4
            "Mem $7000 = Y coord of obj: ",			// 0xC5
            "Mem $7000 = Z coord of obj: ",			// 0xC6
            "UNKCMD 0xC7",			// 0xC7
            "UNKCMD 0xC8",			// 0xC8
            "UNKCMD 0xC9",			// 0xC9
            "Mem $7000 = held joypad register",			// 0xCA
            "Mem $7000 = tapped joypad register",			// 0xCB
            "UNKCMD 0xCC",			// 0xCC
            "UNKCMD 0xCD",			// 0xCD
            "UNKCMD 0xCE",			// 0xCE
            "UNKCMD 0xCF",			// 0xCF
			
            "Run event (jump to): ",			// 0xD0
            "Run event (sub-routine): ",			// 0xD1
            "Jump to $",			// 0xD2
            "Jump to subroutine $",			// 0xD3
            "Loop start, loop count: ",			// 0xD4
            "UNKCMD 0xD5",			// 0xD5
            "Obj mem = 00:",			// 0xD6
            "Loop end",			// 0xD7
            "If set, mem $",			// 0xD8
            "If set, mem $",			// 0xD9
            "If set, mem $",			// 0xDA
            "If mem $7000 bit(s) set, jump to $",			// 0xDB
            "If clear, mem $",			// 0xDC
            "If clear, mem $",			// 0xDD
            "If clear, mem $",			// 0xDE
            "If mem $7000 bit(s) clear, jump to $",			// 0xDF
			
            "If mem $",			// 0xE0
            "If mem $",			// 0xE1
            "If mem $7000 = ",			// 0xE2
            "If mem $7000 != ",			// 0xE3
            "If mem $",			// 0xE4
            "If mem $",			// 0xE5
            "If mem $7000 set, no bits: ",			// 0xE6
            "If mem $7000 set, any bits: ",			// 0xE7
            "If random # > 128, jump to $",			// 0xE8
            "If random # > 66, jump to $",			// 0xE9
            "If equal to zero, jump to $",			// 0xEA
            "If not equal to zero, jump to $",			// 0xEB
            "If greater than / equal to, jump to $",			// 0xEC
            "If less than, jump to $",			// 0xED
            "If negative, jump to $",			// 0xEE
            "If positive, jump to $",			// 0xEF
			
            "Delay, frames (8-bit): ",			// 0xF0
            "Delay, frames (16-bit): ",			// 0xF1
            "Set obj: ",			// 0xF2
            "Set obj: ",			// 0xF3
            "Set obj: mem $70A8, presence = true (current level)",			// 0xF4
            "Set obj: mem $70A8, presence = false (current level)",			// 0xF4
            "Set obj: mem $70A8, event trigger = true",			// 0xF6
            "Set obj: mem $70A8, event trigger = false",			// 0xF7
            "If obj: ",			// 0xF8
            "Jump to script start",			// 0xF9
            "Jump to script start",			// 0xFA
            "Reset game, choose game",			// 0xFB
            "Reset game",			// 0xFC
            "",			// 0xFD
            "Return",			// 0xFE
            "Return all"			// 0xFF
			        };

        private static string[] EventScriptCommandFDOptions = new string[]
        {
            "UNKCMD 0xFD Option 0x00",			// 0x00
            "UNKCMD 0xFD Option 0x01",			// 0x01
            "UNKCMD 0xFD Option 0x02",			// 0x02
            "UNKCMD 0xFD Option 0x03",			// 0x03
            "UNKCMD 0xFD Option 0x04",			// 0x04
            "UNKCMD 0xFD Option 0x05",			// 0x05
            "UNKCMD 0xFD Option 0x06",			// 0x06
            "UNKCMD 0xFD Option 0x07",			// 0x07
            "UNKCMD 0xFD Option 0x08",			// 0x08
            "UNKCMD 0xFD Option 0x09",			// 0x09
            "UNKCMD 0xFD Option 0x0A",			// 0x0A
            "UNKCMD 0xFD Option 0x0B",			// 0x0B
            "UNKCMD 0xFD Option 0x0C",			// 0x0C
            "UNKCMD 0xFD Option 0x0D",			// 0x0D
            "UNKCMD 0xFD Option 0x0E",			// 0x0E
            "UNKCMD 0xFD Option 0x0F",			// 0x0F
			
            "UNKCMD 0xFD Option 0x10",			// 0x10
            "UNKCMD 0xFD Option 0x11",			// 0x11
            "UNKCMD 0xFD Option 0x12",			// 0x12
            "UNKCMD 0xFD Option 0x13",			// 0x13
            "UNKCMD 0xFD Option 0x14",			// 0x14
            "UNKCMD 0xFD Option 0x15",			// 0x15
            "UNKCMD 0xFD Option 0x16",			// 0x16
            "UNKCMD 0xFD Option 0x17",			// 0x17
            "UNKCMD 0xFD Option 0x18",			// 0x18
            "UNKCMD 0xFD Option 0x19",			// 0x19
            "UNKCMD 0xFD Option 0x1A",			// 0x1A
            "UNKCMD 0xFD Option 0x1B",			// 0x1B
            "UNKCMD 0xFD Option 0x1C",			// 0x1C
            "UNKCMD 0xFD Option 0x1D",			// 0x1D
            "UNKCMD 0xFD Option 0x1E",			// 0x1E
            "UNKCMD 0xFD Option 0x1F",			// 0x1F
			
            "UNKCMD 0xFD Option 0x20",			// 0x20
            "UNKCMD 0xFD Option 0x21",			// 0x21
            "UNKCMD 0xFD Option 0x22",			// 0x22
            "UNKCMD 0xFD Option 0x23",			// 0x23
            "UNKCMD 0xFD Option 0x24",			// 0x24
            "UNKCMD 0xFD Option 0x25",			// 0x25
            "UNKCMD 0xFD Option 0x26",			// 0x26
            "UNKCMD 0xFD Option 0x27",			// 0x27
            "UNKCMD 0xFD Option 0x28",			// 0x28
            "UNKCMD 0xFD Option 0x29",			// 0x29
            "UNKCMD 0xFD Option 0x2A",			// 0x2A
            "UNKCMD 0xFD Option 0x2B",			// 0x2B
            "UNKCMD 0xFD Option 0x2C",			// 0x2C
            "UNKCMD 0xFD Option 0x2D",			// 0x2D
            "UNKCMD 0xFD Option 0x2E",			// 0x2E
            "UNKCMD 0xFD Option 0x2F",			// 0x2F
			
            "Screen, unfixed",			// 0x30
            "Screen, fixed",			// 0x31
            "Remember last obj",			// 0x32
            "If currently running action script, obj: ",			// 0x33
            "If underwater, obj: ",			// 0x34
            "UNKCMD 0xFD Option 0x35",			// 0x35
            "UNKCMD 0xFD Option 0x36",			// 0x36
            "UNKCMD 0xFD Option 0x37",			// 0x37
            "UNKCMD 0xFD Option 0x38",			// 0x38
            "UNKCMD 0xFD Option 0x39",			// 0x39
            "UNKCMD 0xFD Option 0x3A",			// 0x3A
            "UNKCMD 0xFD Option 0x3B",			// 0x3B
            "UNKCMD 0xFD Option 0x3C",			// 0x3C
            "If in air, obj: ",			// 0x3D
            "Create new NPC, packet: ",			// 0x3E
            "UNKCMD 0xFD Option 0x3F",			// 0x3F
			
            "UNKCMD 0xFD Option 0x40",			// 0x40
            "UNKCMD 0xFD Option 0x41",			// 0x41
            "UNKCMD 0xFD Option 0x42",			// 0x42
            "UNKCMD 0xFD Option 0x43",			// 0x43
            "UNKCMD 0xFD Option 0x44",			// 0x44
            "UNKCMD 0xFD Option 0x45",			// 0x45
            "UNKCMD 0xFD Option 0x46",			// 0x46
            "UNKCMD 0xFD Option 0x47",			// 0x47
            "UNKCMD 0xFD Option 0x48",			// 0x48
            "UNKCMD 0xFD Option 0x49",			// 0x49
            "Open, save game",			// 0x4A
            "Experience += current experience packet data",			// 0x4B
            "Open, menu tutorial: ",			// 0x4C
            "Run star piece scene: ",			// 0x4D
            "Run moleville mountain",			// 0x4E
            "Run moleville mountain intro",			// 0x4F
			
            "Store mem $70A7 to item inventory",			// 0x50
            "Store mem $70A7 to equipment inventory",			// 0x51
            "Coins += mem $7000",			// 0x52
            "Coins -= mem $7000",			// 0x53
            "Frog coins += mem $7000",			// 0x54
            "Frog coins -= mem $7000",			// 0x55
            "Current FP += mem $7000",			// 0x56
            "Maximum FP += mem $7000",			// 0x57
            "Mem $7000 = quantity of item: ",			// 0x58
            "Mem $7000 = coins",			// 0x59
            "Mem $7000 = frog coins",			// 0x5A
            "Restore all HP",			// 0x5B
            "Restore all FP",			// 0x5C
            "Mem $7000 = equipment of character: ",			// 0x5D
            "Mem $70A7 = quantity of item @ mem $7000",			// 0x5E
            "UNKCMD 0xFD Option 0x5F",			// 0x5F
			
            "Pause script, resume on next dlg page",			// 0x60
            "Pause script, resume on next dlg page",			// 0x61
            "UNKCMD 0xFD Option 0x62",			// 0x62
            "UNKCMD 0xFD Option 0x63",			// 0x63
            "Experience packet = mem $7000",			// 0x64
            "Open, level-up bonus",			// 0x65
            "Open, character intro title: ",			// 0x66
            "Open, ending credits",			// 0x67
            "UNKCMD 0xFD Option 0x68",			// 0x68
            "UNKCMD 0xFD Option 0x69",			// 0x69
            "UNKCMD 0xFD Option 0x6A",			// 0x6A
            "UNKCMD 0xFD Option 0x6B",			// 0x6B
            "UNKCMD 0xFD Option 0x6C",			// 0x6C
            "UNKCMD 0xFD Option 0x6D",			// 0x6D
            "UNKCMD 0xFD Option 0x6E",			// 0x6E
            "UNKCMD 0xFD Option 0x6F",			// 0x6F
			
            "UNKCMD 0xFD Option 0x70",			// 0x70
            "UNKCMD 0xFD Option 0x71",			// 0x71
            "UNKCMD 0xFD Option 0x72",			// 0x72
            "UNKCMD 0xFD Option 0x73",			// 0x73
            "UNKCMD 0xFD Option 0x74",			// 0x74
            "UNKCMD 0xFD Option 0x75",			// 0x75
            "UNKCMD 0xFD Option 0x76",			// 0x76
            "UNKCMD 0xFD Option 0x77",			// 0x77
            "UNKCMD 0xFD Option 0x78",			// 0x78
            "UNKCMD 0xFD Option 0x79",			// 0x79
            "UNKCMD 0xFD Option 0x7A",			// 0x7A
            "UNKCMD 0xFD Option 0x7B",			// 0x7B
            "UNKCMD 0xFD Option 0x7C",			// 0x7C
            "UNKCMD 0xFD Option 0x7D",			// 0x7D
            "UNKCMD 0xFD Option 0x7E",			// 0x7E
            "UNKCMD 0xFD Option 0x7F",			// 0x7F
			
            "UNKCMD 0xFD Option 0x80",			// 0x80
            "UNKCMD 0xFD Option 0x81",			// 0x81
            "UNKCMD 0xFD Option 0x82",			// 0x82
            "UNKCMD 0xFD Option 0x83",			// 0x83
            "UNKCMD 0xFD Option 0x84",			// 0x84
            "UNKCMD 0xFD Option 0x85",			// 0x85
            "UNKCMD 0xFD Option 0x86",			// 0x86
            "UNKCMD 0xFD Option 0x87",			// 0x87
            "UNKCMD 0xFD Option 0x88",			// 0x88
            "UNKCMD 0xFD Option 0x89",			// 0x89
            "UNKCMD 0xFD Option 0x8A",			// 0x8A
            "UNKCMD 0xFD Option 0x8B",			// 0x8B
            "UNKCMD 0xFD Option 0x8C",			// 0x8C
            "UNKCMD 0xFD Option 0x8D",			// 0x8D
            "UNKCMD 0xFD Option 0x8E",			// 0x8E
            "UNKCMD 0xFD Option 0x8F",			// 0x8F
			
            "UNKCMD 0xFD Option 0x90",			// 0x90
            "UNKCMD 0xFD Option 0x91",			// 0x91
            "UNKCMD 0xFD Option 0x92",			// 0x92
            "UNKCMD 0xFD Option 0x93",			// 0x93
            "Set inactive sound channels: ",			// 0x94
            "UNKCMD 0xFD Option 0x95",			// 0x95
            "UNKCMD 0xFD Option 0x96",			// 0x96
            "UNKCMD 0xFD Option 0x97",			// 0x97
            "UNKCMD 0xFD Option 0x98",			// 0x98
            "UNKCMD 0xFD Option 0x99",			// 0x99
            "UNKCMD 0xFD Option 0x9A",			// 0x9A
            "UNKCMD 0xFD Option 0x9B",			// 0x9B
            "Playback, start sound (sync): ",			// 0x9C
            "Playback, start sound: ",			// 0x9D
            "Playback, start track: ",			// 0x9E
            "Playback, stop track",			// 0x9F
			
            "Playback, stop track",			// 0xA0
            "Playback, stop track",			// 0xA1
            "Playback, stop track",			// 0xA2
            "Playback, fade-out track",			// 0xA3
            "Playback, slow down track",			// 0xA4
            "Playback, speed up track to normal",			// 0xA5
            "Playback, stop track",			// 0xA6
            "UNKCMD 0xFD Option 0xA7",			// 0xA7
            "Mem set, 00:",			// 0xA8
            "Mem set, 00:",			// 0xA9
            "Mem set, 00:",			// 0xAA
            "UNKCMD 0xFD Option 0xAB",			// 0xAB
            "Mem $7000 = mem 7F:",			// 0xAC
            "UNKCMD 0xFD Option 0xAD",			// 0xAD
            "UNKCMD 0xFD Option 0xAE",			// 0xAE
            "UNKCMD 0xFD Option 0xAF",			// 0xAF
			
            "Mem $7000 isolate bits = ",			// 0xB0
            "Mem $7000 set bits = ",			// 0xB1
            "Mem $7000 xor bits = ",			// 0xB2
            "Mem $7000 isolate bits = mem $",			// 0xB3
            "Mem $7000 set bits = mem $",			// 0xB4
            "Mem $7000 xor bits = mem $",			// 0xB5
            "Mem $",			// 0xB6
            "Generate random # less than mem $",			// 0xB7
            "UNKCMD 0xFD Option 0xB8",			// 0xB8
            "UNKCMD 0xFD Option 0xB9",			// 0xB9
            "UNKCMD 0xFD Option 0xBA",			// 0xBA
            "UNKCMD 0xFD Option 0xBB",			// 0xBB
            "UNKCMD 0xFD Option 0xBC",			// 0xBC
            "UNKCMD 0xFD Option 0xBD",			// 0xBD
            "UNKCMD 0xFD Option 0xBE",			// 0xBE
            "UNKCMD 0xFD Option 0xBF",			// 0xBF
			
            "UNKCMD 0xFD Option 0xC0",			// 0xC0
            "UNKCMD 0xFD Option 0xC1",			// 0xC1
            "UNKCMD 0xFD Option 0xC2",			// 0xC2
            "UNKCMD 0xFD Option 0xC3",			// 0xC3
            "UNKCMD 0xFD Option 0xC4",			// 0xC4
            "UNKCMD 0xFD Option 0xC5",			// 0xC5
            "UNKCMD 0xFD Option 0xC6",			// 0xC6
            "UNKCMD 0xFD Option 0xC7",			// 0xC7
            "UNKCMD 0xFD Option 0xC8",			// 0xC8
            "UNKCMD 0xFD Option 0xC9",			// 0xC9
            "UNKCMD 0xFD Option 0xCA",			// 0xCA
            "UNKCMD 0xFD Option 0xCB",			// 0xCB
            "UNKCMD 0xFD Option 0xCC",			// 0xCC
            "UNKCMD 0xFD Option 0xCD",			// 0xCD
            "UNKCMD 0xFD Option 0xCE",			// 0xCE
            "UNKCMD 0xFD Option 0xCF",			// 0xCF
			
            "UNKCMD 0xFD Option 0xD0",			// 0xD0
            "UNKCMD 0xFD Option 0xD1",			// 0xD1
            "UNKCMD 0xFD Option 0xD2",			// 0xD2
            "UNKCMD 0xFD Option 0xD3",			// 0xD3
            "UNKCMD 0xFD Option 0xD4",			// 0xD4
            "UNKCMD 0xFD Option 0xD5",			// 0xD5
            "UNKCMD 0xFD Option 0xD6",			// 0xD6
            "UNKCMD 0xFD Option 0xD7",			// 0xD7
            "UNKCMD 0xFD Option 0xD8",			// 0xD8
            "UNKCMD 0xFD Option 0xD9",			// 0xD9
            "UNKCMD 0xFD Option 0xDA",			// 0xDA
            "UNKCMD 0xFD Option 0xDB",			// 0xDB
            "UNKCMD 0xFD Option 0xDC",			// 0xDC
            "UNKCMD 0xFD Option 0xDD",			// 0xDD
            "UNKCMD 0xFD Option 0xDE",			// 0xDE
            "UNKCMD 0xFD Option 0xDF",			// 0xDF
			
            "UNKCMD 0xFD Option 0xE0",			// 0xE0
            "UNKCMD 0xFD Option 0xE1",			// 0xE1
            "UNKCMD 0xFD Option 0xE2",			// 0xE2
            "UNKCMD 0xFD Option 0xE3",			// 0xE3
            "UNKCMD 0xFD Option 0xE4",			// 0xE4
            "UNKCMD 0xFD Option 0xE5",			// 0xE5
            "UNKCMD 0xFD Option 0xE6",			// 0xE6
            "UNKCMD 0xFD Option 0xE7",			// 0xE7
            "UNKCMD 0xFD Option 0xE8",			// 0xE8
            "UNKCMD 0xFD Option 0xE9",			// 0xE9
            "UNKCMD 0xFD Option 0xEA",			// 0xEA
            "UNKCMD 0xFD Option 0xEB",			// 0xEB
            "UNKCMD 0xFD Option 0xEC",			// 0xEC
            "UNKCMD 0xFD Option 0xED",			// 0xED
            "UNKCMD 0xFD Option 0xEE",			// 0xEE
            "UNKCMD 0xFD Option 0xEF",			// 0xEF
			
            "UNKCMD 0xFD Option 0xF0",			// 0xF0
            "UNKCMD 0xFD Option 0xF1",			// 0xF1
            "UNKCMD 0xFD Option 0xF2",			// 0xF2
            "UNKCMD 0xFD Option 0xF3",			// 0xF3
            "UNKCMD 0xFD Option 0xF4",			// 0xF4
            "UNKCMD 0xFD Option 0xF5",			// 0xF4
            "UNKCMD 0xFD Option 0xF6",			// 0xF6
            "UNKCMD 0xFD Option 0xF7",			// 0xF7
            "Run event: Exor crashes into keep",			// 0xF8
            "Mario glows via super star",			// 0xF9
            "UNKCMD 0xFD Option 0xFA",			// 0xFA
            "UNKCMD 0xFD Option 0xFB",			// 0xFB
            "UNKCMD 0xFD Option 0xFC",			// 0xFC
            "UNKCMD 0xFD Option 0xFD",			// 0xFD
            "Return",			// 0xFE
            "Return all"			// 0xFF
        };

        private static string[] CharacterNames = new string[]
        {
            "Mario","Toadstool","Bowser","Geno","Mallow",
            "INVALID","INVALID","INVALID","INVALID","INVALID",
            "INVALID","INVALID","INVALID","INVALID","INVALID",
        };

        private static string[] EventCategory = new string[]
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
        };
        private static string[] ObjectNames = new string[]
            {
            "Mario",
            "Toadstool",
            "Bowser",
            "Geno",
            "Mallow",
            "DUMMY 0x05",
            "DUMMY 0x06",
            "DUMMY 0x07",
            "Character in Slot 1",
            "Character in Slot 2",
            "Character in Slot 3",
            "DUMMY 0x0B",
            "Screen Focus",
            "Layer 1",
            "Layer 2",
            "Layer 3",

            "Mem $70A8",
            "Mem $70A9",
            "Mem $70AA",
            "Mem $70AB",
            "NPC #0",
            "NPC #1",
            "NPC #2",
            "NPC #3",
            "NPC #4",
            "NPC #5",
            "NPC #6",
            "NPC #7",
            "NPC #8",
            "NPC #9",
            "NPC #10",
            "NPC #11",

            "NPC #12",
            "NPC #13",
            "NPC #14",
            "NPC #15",
            "NPC #16",
            "NPC #17",
            "NPC #18",
            "NPC #19",
            "NPC #20",
            "NPC #21",
            "NPC #22",
            "NPC #23",
            "NPC #24",
            "NPC #25",
            "NPC #26",
            "NPC #27",
            };

        private static string[] Menus = new string[] { 
            "choose game", "overworld menu", "return to world map", "shop 0", "save game", "items maxed out" };
        private static string[] DirectionNames = new string[] { 
            "east", "southeast", "south", "southwest", "west", "northwest", "north", "northeast" };
        private static string[] ColorNames = new string[] { 
            "black", "blue", "red", "pink", "green", "aqua", "yellow", "white" };
        private static string[] ButtonNames = new string[] { "left", "right", "down", "up", "X", "A", "Y", "B" };
        private static string[] BitNames = new string[] { "0", "1", "2", "3", "4", "5", "6", "7" };
        private static string[] LayerNames = new string[] { "L1", "L2", "L3", "L4", "Sprites", "BG", "½ intensity", "Minus sub" };
        private static string[] TutorialNames = new string[] { "How to equip", "How to use items", "How to switch allies", "How to play beetle mania" };
        private static string[] EventNames = new string[] { "Mario falls to pipehouse", "Mario returns to MK", "Mario takes Nimbus bus" };

        #endregion
        public string InterpretEventCommand(EventScriptCommand esc)
        {
            StringBuilder sb = new StringBuilder();
            string a, b, c, d;

            sb.Append(EventScriptCommands[esc.Opcode]);

            switch (esc.Opcode)
            {
                case 0x32:
                    sb.Append(ObjectNames[esc.Option] +
                        ", jump to $" + Bits.GetShort(esc.EventData, 2).ToString("X4"));
                    break;
                case 0x34:
                case 0x35:
                    sb.Append(GetBits((byte)(esc.Option ^ 0xFF), ButtonNames, 8) + ",  enable: " + GetBits(esc.Option, ButtonNames, 8));
                    break;
                case 0x36:
                    a = (esc.EventData[1] & 0x80) == 0x80 ? ", party capacity +1" : "";
                    sb.Append(CharacterNames[esc.Option & 0x1F] + a);
                    break;
                case 0x38:
                    sb.Append((esc.Option - 8).ToString());
                    break;
                case 0x39:
                    sb.Append(ObjectNames[esc.Option] + ", jump to $" + Bits.GetShort(esc.EventData, 2).ToString("X4"));
                    break;
                case 0x3A:
                    sb.Append(ObjectNames[esc.Option] +
                        " and obj: " + ObjectNames[esc.EventData[2]] +
                        " less than (x=" + esc.EventData[3].ToString() +
                        ", y=" + esc.EventData[4].ToString() +
                        "), jump to $" + Bits.GetShort(esc.EventData, 5).ToString("X4"));
                    break;
                case 0x3B:
                    sb.Append(ObjectNames[esc.Option] +
                        " and obj: " + ObjectNames[esc.EventData[2]] +
                        " less than (x=" + esc.EventData[3].ToString() +
                        ", y=" + esc.EventData[4].ToString() +
                        "), jump to $" + Bits.GetShort(esc.EventData, 5).ToString("X4"));
                    break;
                case 0x3D:
                    sb.Append(Bits.GetShort(esc.EventData, 1).ToString("X4"));
                    break;
                case 0x3E:
                    sb.Append(esc.Option.ToString() +
                        ", @ coords of obj: " + ObjectNames[esc.EventData[2]] +
                        ", if obj null jump to $" + Bits.GetShort(esc.EventData, 3).ToString("X4"));
                    break;
                case 0x3F:
                    sb.Append(esc.Option.ToString() +
                        ", @ coords of Mario, if Mario null jump to $" + Bits.GetShort(esc.EventData, 2).ToString("X4"));
                    break;
                case 0x42:
                    sb.Append(Bits.GetShort(esc.EventData, 1).ToString("X4") +
                        ", else jump to $" + Bits.GetShort(esc.EventData, 3).ToString("X4"));
                    break;
                case 0x40:
                    sb.Append((Bits.GetShort(esc.EventData, 1) & 0xFFF).ToString() + ", stop if exit level = ");
                    sb.Append(((esc.EventData[2] & 0x20) == 0x20) ? "true" : "false");
                    break;
                case 0xD0:
                case 0xD1:
                    sb.Append((Bits.GetShort(esc.EventData, 1) & 0xFFF).ToString());
                    break;
                case 0x4B:
                    sb.Append(Model.MapPoints[esc.Option].ToString());
                    break;
                case 0x4C:
                case 0x4F:
                case 0x52:
                case 0x53:
                case 0xD4:
                case 0xF0:
                    sb.Append(esc.Option.ToString());
                    break;
                case 0x4A:
                    sb.Append(esc.Option.ToString() + ", battlefield: [" + esc.EventData[3].ToString("d2") + "]");
                    break;
                case 0x50:
                case 0x51:
                    sb.Append("[" + esc.Option.ToString() + "] \"" + TrimTailSpaces(Model.ItemNames.GetNameByNum(esc.Option)) + "\"");
                    break;
                case 0x54:
                    sb.Append(CharacterNames[esc.Option] +
                        ", with item: [" + esc.EventData[2] + "] \"" + TrimTailSpaces(Model.ItemNames.GetNameByNum(esc.EventData[2])) + "\"");
                    break;
                case 0x4E:
                    switch (esc.Option)
                    {
                        case 2: a = ""; break;
                        case 3: a = ""; break;
                        case 5: a = ": toss item: " + Model.ItemNames.GetNameByNum(esc.EventData[2]); break;
                        case 7: a = ": " + TutorialNames[esc.EventData[2]]; break;
                        case 16: a = ": " + EventNames[esc.EventData[2]]; break;
                        default: a = ""; break;
                    }
                    sb.Append(EventCategory[esc.Option] + a);
                    break;
                case 0x56:
                    sb.Append(CharacterNames[esc.Option & 0x1F]);
                    break;
                case 0x60:
                    a = (esc.EventData[2] & 0x80) == 0x80 ? ", sync = false" : ", sync = true";
                    b = (esc.EventData[2] & 0x20) == 0x20 ? ", closable = true" : ", closable = false";
                    c = (esc.EventData[3] & 0x80) == 0x80 ? ", paper BG = true" : ", paper BG = false";
                    d = (esc.EventData[3] & 0x40) == 0x40 ? ", multi-line = true" : ", multi-line = false";
                    sb.Append("[" + (Bits.GetShort(esc.EventData, 1) & 0xFFF).ToString() + "] \"" +
                        Model.Dialogues[Bits.GetShort(esc.EventData, 1) & 0xFFF].GetDialogueStub(true) + "\"" +
                        a + b + c + d +
                        ", align above obj: " + ObjectNames[esc.EventData[3] & 0x3F]);
                    break;
                case 0x61:
                    a = (esc.Option & 0x80) == 0x80 ? ", sync = false" : ", sync = true";
                    b = (esc.Option & 0x20) == 0x20 ? ", closable = true" : ", closable = false";
                    c = (esc.EventData[2] & 0x80) == 0x80 ? ", paper BG = true" : ", paper BG = false";
                    d = (esc.EventData[2] & 0x40) == 0x40 ? ", multi-line = true" : ", multi-line = false";
                    sb.Append(a + b + c + d +
                        ", align above obj: " + ObjectNames[esc.EventData[2] & 0x3F]);
                    break;
                case 0x62:
                    a = (esc.EventData[2] & 0x80) == 0x80 ? ", sync = false" : ", sync = true";
                    switch ((esc.EventData[2] & 0x60) >> 5)
                    {
                        case 1: b = ", duration: short"; break;
                        case 2: b = ", duration: normal"; break;
                        default: b = ", duration: forever"; break;
                    }
                    sb.Append("[" + (Bits.GetShort(esc.EventData, 1) & 0xFFF).ToString() + "] \"" +
                        Model.Dialogues[Bits.GetShort(esc.EventData, 1) & 0xFFF].GetDialogueStub(true) + "\"" +
                        a + b);
                    break;
                case 0x63:
                    a = (esc.Option & 0x80) == 0x80 ? "sync = false" : "sync = true";
                    b = (esc.Option & 0x20) == 0x20 ? ", closable = true" : ", closable = false";
                    sb.Append(a + b);
                    break;
                case 0x66:
                case 0xD2:
                case 0xD3:
                case 0xDB:
                case 0xDF:
                    sb.Append((Bits.GetShort(esc.EventData, 1)).ToString("X4"));
                    break;
                case 0x67:
                    sb.Append((Bits.GetShort(esc.EventData, 1)).ToString("X4") + ", else if dlg option C selected, jump to $" + (Bits.GetShort(esc.EventData, 3)).ToString("X4"));
                    break;
                case 0x68:
                    sb.Append((Bits.GetShort(esc.EventData, 1) & 0x1FF).ToString("d3") +
                        "], place Mario @ (x=" + esc.EventData[3].ToString() +
                        ", y=" + esc.EventData[4].ToString() +
                        ", z=" + (esc.EventData[5] & 0x1F).ToString() +
                        "), facing: " + DirectionNames[((esc.EventData[5] & 0xE0) >> 5)] +
                        ", run entrance event = " + ((esc.EventData[2] & 0x80) == 0x80 ? "true" : "false") +
                        ", show message = " + ((esc.EventData[2] & 0x08) == 0x08 ? "true" : "false"));
                    break;
                case 0x6A:
                case 0x6B:
                    sb.Append((Bits.GetShort(esc.EventData, 1) & 0x1FF).ToString());
                    sb.Append(", mod # = " + ((esc.EventData[2] & 0x3F) >> 1).ToString() + ", ");
                    if (esc.Opcode == 0x6A) sb.Append("alternate");
                    else sb.Append("permanent");
                    sb.Append(" = " + ((esc.EventData[2] & 0x80) == 0x80 ? "true" : "false"));
                    break;
                case 0x72:
                case 0x73:
                case 0x76:
                case 0x77:
                    sb.Append(esc.Option.ToString());
                    break;
                case 0x78:
                case 0x79:
                    sb.Append(ColorNames[esc.EventData[2]] +
                        ", duration = " + esc.Option.ToString());
                    break;
                case 0x80:
                    sb.Append(Bits.GetShort(esc.EventData, 1).ToString("X4") +
                        ", tint layers: " + GetBits(esc.EventData[3], LayerNames, 8) +
                        ", speed: " + esc.EventData[4].ToString());
                    break;
                case 0x81:
                    sb.Append("mainscreen = (" + GetBits(esc.Option, LayerNames, 8) +
                        "), subscreen = (" + GetBits(esc.EventData[2], LayerNames, 8) +
                        "), color math = (" + GetBits(esc.EventData[3], LayerNames, 8) + ")");
                    break;
                case 0x83:
                    sb.Append(ColorNames[esc.Option]);
                    break;
                case 0x84:
                    sb.Append(((esc.Option & 0xF0) >> 4).ToString() +
                        ", layers: " + GetBits(esc.Option, LayerNames, 4) +
                        ", speed: " + (esc.EventData[2] & 0x3F).ToString());
                    break;
                case 0x89:
                    switch ((esc.Option & 0xE0) >> 5)
                    {
                        case 3: a = ", style: glowing"; break;
                        case 6: a = ", style: glow once"; break;
                        case 7: a = ", style: fade to"; break;
                        default: a = ", style: NULL"; break;
                    }
                    sb.Append(esc.EventData[3].ToString() + ", index: " +
                        esc.EventData[2].ToString() + a + ", duration: " + (esc.Option & 0x0F).ToString());
                    break;
                case 0x8A:
                    sb.Append(esc.EventData[2] + ", indexes 0 to " +
                        (((esc.Option & 0xF0) / 16) + 1).ToString());
                    break;
                case 0x87:
                case 0x8F:
                    sb.Append(ObjectNames[esc.Option] +
                        ", radial distance from obj: " + esc.EventData[2].ToString() + "px" + ", speed: " + esc.EventData[3].ToString());
                    break;
                case 0x90:
                case 0x91:
                case 0x92:
                    sb.Append(Lists.Numerize(Lists.MusicNames, esc.Option));
                    break;
                case 0x95:
                case 0x9E:
                    sb.Append(esc.Option + ", to volume: " + esc.EventData[2].ToString());
                    break;
                case 0x97:
                    if (esc.EventData[2] >= 0xA1) { a = ", speed up"; b = (0x100 - esc.EventData[2]).ToString(); }
                    else { a = ", slow down"; b = esc.EventData[2].ToString(); }
                    sb.Append(esc.Option.ToString() +
                        a + ", tempo: " + b);
                    break;
                case 0x98:
                    a = (esc.EventData[2] & 0x80) == 0x80 ? ", lower" : ", raise";
                    sb.Append(esc.Option.ToString() + a);
                    break;
                case 0x9C:
                    sb.Append(Lists.Numerize(Lists.SoundNames, esc.Option));
                    break;
                case 0x9D:
                    sb.Append(Lists.Numerize(Lists.SoundNames, esc.Option) + ", speaker balance: " +
                        esc.EventData[2].ToString());
                    break;
                case 0xA0:
                case 0xA1:
                case 0xA2:
                    sb.Append((((((esc.Opcode * 0x100) + esc.Option) - 0xA000) / 8) + 0x7040).ToString("X4") +
                        ", bit: " + (esc.Option & 0x07).ToString());
                    break;
                case 0xA4:
                case 0xA5:
                case 0xA6:
                    sb.Append((((((esc.Opcode * 0x100) + esc.Option) - 0xA400) / 8) + 0x7040).ToString("X4") +
                        ", bit: " + (esc.Option & 0x07).ToString());
                    break;
                case 0xA8:
                    sb.Append((esc.Option + 0x70A0).ToString("X4") +
                       " = " + esc.EventData[2]);
                    break;
                case 0xA9:
                    sb.Append((esc.Option + 0x70A0).ToString("X4") +
                         " += " + esc.EventData[2]);
                    break;
                case 0xAA:
                    sb.Append((esc.Option + 0x70A0).ToString("X4") + " increment");
                    break;
                case 0xAB:
                    sb.Append((esc.Option + 0x70A0).ToString("X4") + " decrement");
                    break;
                case 0xAC:
                case 0xAD:
                case 0xC0:
                case 0xF1:
                    sb.Append(Bits.GetShort(esc.EventData, 1).ToString());
                    break;
                case 0xB0:
                    sb.Append(((esc.Option * 2) + 0x7000).ToString("X4") +
                        " = " + Bits.GetShort(esc.EventData, 2).ToString());
                    break;
                case 0xB1:
                    sb.Append(((esc.Option * 2) + 0x7000).ToString("X4") +
                        " += " + Bits.GetShort(esc.EventData, 2).ToString());
                    break;
                case 0xB2:
                    sb.Append(((esc.Option * 2) + 0x7000).ToString("X4") + " increment");
                    break;
                case 0xB3:
                    sb.Append(((esc.Option * 2) + 0x7000).ToString("X4") + " decrement");
                    break;
                case 0xD6:
                    sb.Append(((esc.Option * 2) + 0x7000).ToString("X4"));
                    break;
                case 0xB4:
                    sb.Append((esc.Option + 0x70A0).ToString("X4"));
                    break;
                case 0xB5:
                    sb.Append((esc.Option + 0x70A0).ToString("X4") + " = $7000");
                    break;
                case 0xB6:
                    sb.Append(Bits.GetShort(esc.EventData, 1).ToString());
                    break;
                case 0xB7:
                    sb.Append(((esc.Option * 2) + 0x7000).ToString("X4") +
                        " = random # < " + Bits.GetShort(esc.EventData, 2).ToString());
                    break;
                case 0xB8:
                case 0xB9:
                case 0xBA:
                case 0xC1:
                    sb.Append(((esc.Option * 2) + 0x7000).ToString("X4"));
                    break;
                case 0xC2:
                    sb.Append(((esc.Option * 2) + 0x7000).ToString("X4") + " to " +
                        Bits.GetShort(esc.EventData, 2).ToString());
                    break;
                case 0xBB:
                    sb.Append(((esc.Option * 2) + 0x7000).ToString("X4") + " = mem $7000");
                    break;
                case 0xBC:
                    sb.Append(((esc.Option * 2) + 0x7000).ToString("X4") + " = mem $" +
                    ((esc.EventData[2] * 2) + 0x7000).ToString("X4"));
                    break;
                case 0xBD:
                    sb.Append(((esc.Option * 2) + 0x7000).ToString("X4") + " <=> mem $" +
                        ((esc.EventData[2] * 2) + 0x7000).ToString("X4"));
                    break;
                case 0xC4:
                case 0xC5:
                case 0xC6:
                    sb.Append(ObjectNames[esc.Option & 0x3F]);
                    break;
                case 0xD8:
                case 0xD9:
                case 0xDA:
                    sb.Append((((((esc.Opcode * 0x100) + esc.Option) - 0xD800) / 8) + 0x7040).ToString("X4") + ", bit: " +
                        (esc.Option & 0x07).ToString() + ", jump to $" +
                        (Bits.GetShort(esc.EventData, 2)).ToString("X4"));
                    break;
                case 0xDC:
                case 0xDD:
                case 0xDE:
                    sb.Append((((((esc.Opcode * 0x100) + esc.Option) - 0xDC00) / 8) + 0x7040).ToString("X4") + ", bit: " +
                        (esc.Option & 0x07).ToString() + ", jump to $" +
                        (Bits.GetShort(esc.EventData, 2)).ToString("X4"));
                    break;
                case 0xE0:
                    sb.Append((esc.Option + 0x70A0).ToString("X4") + " = " +
                        esc.EventData[2].ToString() + ", jump to $" +
                        (Bits.GetShort(esc.EventData, 3)).ToString("X4"));
                    break;
                case 0xE1:
                    sb.Append((esc.Option + 0x70A0).ToString("X4") + " != " +
                        esc.EventData[2].ToString() + ", jump to $" +
                        (Bits.GetShort(esc.EventData, 3)).ToString("X4"));
                    break;
                case 0xE2:
                case 0xE3:
                    sb.Append((Bits.GetShort(esc.EventData, 1)).ToString() + ", jump to $" +
                    (Bits.GetShort(esc.EventData, 3)).ToString("X4"));
                    break;
                case 0xE4:
                case 0xE5:
                    sb.Append(((esc.Option * 2) + 0x7000).ToString("X4") + " = " +
                    (Bits.GetShort(esc.EventData, 2)).ToString() + ", jump to $" +
                    (Bits.GetShort(esc.EventData, 4)).ToString("X4"));
                    break;
                case 0xE6:
                case 0xE7:
                    sb.Append(Bits.GetShort(esc.EventData, 1).ToString() + ", jump to $" +
                        Bits.GetShort(esc.EventData, 3).ToString("X4"));
                    break;
                case 0xE8:
                case 0xEA:
                case 0xEB:
                case 0xEC:
                case 0xED:
                case 0xEE:
                case 0xEF:
                    sb.Append(Bits.GetShort(esc.EventData, 1).ToString("X4"));
                    break;
                case 0xE9:
                    sb.Append(Bits.GetShort(esc.EventData, 1).ToString("X4") + ", else jump to $" +
                        Bits.GetShort(esc.EventData, 3).ToString("X4"));
                    break;
                case 0xF2:
                    a = (esc.EventData[2] & 0x80) == 0x80 ? "true" : "false";
                    sb.Append(ObjectNames[((esc.EventData[2] >> 1) & 0x3F)] +
                        ", in level: [" + (Bits.GetShort(esc.EventData, 1) & 0x1FF).ToString("d3") +
                        "], presence = " + a);
                    break;
                case 0xF3:
                    a = (esc.EventData[2] & 0x80) == 0x80 ? "true" : "false";
                    sb.Append(ObjectNames[((esc.EventData[2] >> 1) & 0x3F)] +
                        ", in level: [" + (Bits.GetShort(esc.EventData, 1) & 0x1FF).ToString("d3") +
                        "], event trigger = " + a);
                    break;
                case 0xF8:
                    a = (esc.EventData[2] & 0x80) == 0x80 ? "true" : "false";
                    sb.Append(ObjectNames[((esc.EventData[2] >> 1) & 0x3F)] +
                        ", in level: [" + (Bits.GetShort(esc.EventData, 1) & 0x1FF).ToString("d3") +
                        "], presence = " + a +
                        ", jump to $" + Bits.GetShort(esc.EventData, 3).ToString("X4"));
                    break;
                case 0xFD:
                    sb.Append(ESC_FD_Options(esc));
                    break;
                default:
                    if (esc.Opcode <= 0x2F)
                    {
                        switch (esc.Option)
                        {
                            case 0xF0:
                                a = (esc.EventData[2] & 0x80) == 0x80 ? ", sync = false" : ", sync = true";
                                sb.Append("embedded action script, length: " + (esc.EventData[2] & 0x7F).ToString() + " bytes" + a);
                                break;
                            case 0xF1:
                                a = (esc.EventData[2] & 0x80) == 0x80 ? ", sync = false" : ", sync = true";
                                sb.Append("embedded action script, length: " + (esc.EventData[2] & 0x7F).ToString() + " bytes" + a);
                                break;
                            case 0xF2:
                                sb.Append("action script = " +
                                    Bits.GetShort(esc.EventData, 2).ToString() +
                                    " (sync)");
                                break;
                            case 0xF3:
                                sb.Append("action script = " +
                                    Bits.GetShort(esc.EventData, 2).ToString() +
                                    " (async)");
                                break;
                            case 0xF4:
                                sb.Append("temporary action script = " +
                                    Bits.GetShort(esc.EventData, 2).ToString() +
                                    " (sync)");
                                break;
                            case 0xF5:
                                sb.Append("temporary action script = " +
                                    Bits.GetShort(esc.EventData, 2).ToString() +
                                    " (async)");
                                break;
                            case 0xF6: sb.Append("un-sync action script"); break;
                            case 0xF7: sb.Append("call to Mario's coords"); break;
                            case 0xF8: sb.Append("call"); break;
                            case 0xF9: sb.Append("remove"); break;
                            case 0xFA: sb.Append("pause action script"); break;
                            case 0xFB: sb.Append("resume action script"); break;
                            case 0xFC: sb.Append("enable trigger"); break;
                            case 0xFD: sb.Append("disable trigger"); break;
                            case 0xFE: sb.Append("stop embedded action script"); break;
                            case 0xFF: sb.Append("stop embedded action script"); break;
                            default:
                                a = (esc.Option & 0x80) == 0x80 ? ", sync = false" : ", sync = true";
                                sb.Append("length: " + (esc.Option & 0x7F).ToString() + " bytes" + a);
                                break;
                        }
                    }
                    break;
            }
            return sb.ToString();
        }
        private string ESC_FD_Options(EventScriptCommand esc)
        {
            StringBuilder sb = new StringBuilder();
            string a;

            sb.Append(EventScriptCommandFDOptions[esc.Option]);

            switch (esc.Option)
            {
                case 0x33:
                case 0x34:
                case 0x3D:
                    sb.Append(ObjectNames[esc.EventData[2]] +
                        ", jump to $" +
                        Bits.GetShort(esc.EventData, 3).ToString("X4"));
                    break;
                case 0x3E:
                    sb.Append(esc.EventData[2].ToString() +
                        ", assign event #" + Bits.GetShort(esc.EventData, 3).ToString("X4") +
                        ", jump to $" + Bits.GetShort(esc.EventData, 5).ToString("X4"));
                    break;
                case 0x4C:
                case 0x4D:
                case 0x9C:
                    sb.Append(Lists.Numerize(Lists.SoundNames, esc.EventData[2]));
                    break;
                case 0x9E:
                    sb.Append(Lists.Numerize(Lists.MusicNames, esc.EventData[2]));
                    break;
                case 0x58:
                    sb.Append("[" + esc.EventData[2].ToString() + "] \"" + TrimTailSpaces(Model.ItemNames.GetNameByNum(esc.EventData[2])) + "\"");
                    break;
                case 0x5D:
                    switch (esc.EventData[3] & 0x03)
                    {
                        case 0x01: a = ", type: armor"; break;
                        case 0x02: a = ", type: accessory"; break;
                        default: a = ", type: weapon"; break;
                    }
                    sb.Append(CharacterNames[esc.EventData[2] & 0x0F] + a);
                    break;
                case 0x66:
                    switch (esc.EventData[3])
                    {
                        case 0: a = "\"Super Mario\""; break;
                        case 1: a = "\"Princess Toadstool\""; break;
                        case 2: a = "\"King Bowser\""; break;
                        case 3: a = "\"Mallow\""; break;
                        case 4: a = "\"Geno\""; break;
                        default: a = "\"In...\""; break;
                    }
                    sb.Append(a + ", y=" + esc.EventData[2].ToString());
                    break;
                case 0x94:
                    sb.Append(GetBits(esc.EventData[2], null, 8));
                    break;
                case 0x9D:
                    sb.Append(Lists.Numerize(Lists.SoundNames, esc.EventData[2]) + ", speaker balance: " +
                        esc.EventData[3].ToString());
                    break;
                case 0xA8:
                case 0xA9:
                case 0xAA:
                    sb.Append((((((esc.Option * 0x100) + esc.EventData[2]) - 0xA800) / 8) + 0x7040).ToString("X4") + ", bit: " +
                       (esc.EventData[2] & 0x07).ToString());
                    break;
                case 0xAC:
                    sb.Append((Bits.GetShort(esc.EventData, 2) + 0xF800).ToString("X4"));
                    break;
                case 0xB0:
                case 0xB1:
                case 0xB2:
                    sb.Append(Bits.GetShort(esc.EventData, 2).ToString());
                    break;
                case 0xB3:
                case 0xB4:
                case 0xB5:
                case 0xB7:
                    sb.Append(((esc.EventData[2] * 2) + 0x7000).ToString("X4"));
                    break;
                case 0xB6:
                    sb.Append(((esc.EventData[2] * 2) + 0x7000).ToString("X4") + ", shift bits left: x" +
                        ((esc.EventData[3] ^ 0xFF) + 1).ToString());
                    break;
                default:
                    break;
            }
            return sb.ToString();
        }

        private string TrimTailSpaces(string src)
        {
            int lastIndex = src.Length - 1;

            while (lastIndex >= 0 && (src[lastIndex] == ' ' || src[lastIndex] == '\0'))
                lastIndex--;

            return src.Substring(1, lastIndex + 1);
        }
    }
}