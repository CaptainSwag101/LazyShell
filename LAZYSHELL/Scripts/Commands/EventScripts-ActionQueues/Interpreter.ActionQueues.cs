using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.ScriptsEditor.Commands
{
    public partial class Interpreter
    {
        #region Static Data
        private static string[] ActionQueueCommands = new string[]
        {
            "Visibility = true",			// 0x00
            "Visibility = false",			// 0x01
            "Seq playback = true",			// 0x02
            "Seq playback = false",			// 0x03
            "Infinite seq playback = true",			// 0x04
            "Infinite seq playback = false",			// 0x05
            "Fixed faced direction = true",			// 0x06
            "Fixed faced direction = false",			// 0x07
            "Seq playback, sprite += ",			// 0x08
            "Reset all properties",			// 0x09
            "Solidity properties = ",			// 0x0A
            "Solidity properties, set bits: ",			// 0x0B
            "Solidity properties, clear bits: ",			// 0x0C
            "Palette index, set = ",			// 0x0D
            "Palette index, shift = ",			// 0x0E
            "Palette index, shift x1",			// 0x0F
            			
            "Playback, set speed = ",			// 0x10
            "Obj mem $0D |= ",			// 0x11
            "Obj mem $0B |= ",			// 0x12
            "Sprite priority, set = ",			// 0x13
            "Obj mem $0E |= ",			// 0x14
            "Movement properties |= ",			// 0x15
            "UNKAQCMD 0x16",			// 0x16
            "UNKAQCMD 0x17",			// 0x17
            "UNKAQCMD 0x18",			// 0x18
            "UNKAQCMD 0x19",			// 0x19
            "UNKAQCMD 0x1A",			// 0x1A
            "UNKAQCMD 0x1B",			// 0x1B
            "UNKAQCMD 0x1C",			// 0x1C
            "UNKAQCMD 0x1D",			// 0x1D
            "UNKAQCMD 0x1E",			// 0x1E
            "UNKAQCMD 0x1F",			// 0x1F
            			
            "UNKAQCMD 0x20",			// 0x20
            "UNKAQCMD 0x21",			// 0x21
            "UNKAQCMD 0x22",			// 0x22
            "UNKAQCMD 0x23",			// 0x23
            "UNKAQCMD 0x24",			// 0x24
            "UNKAQCMD 0x25",			// 0x25
            "Animation string A: ",			// 0x26
            "Animation string B: ",			// 0x27
            "Animation string C: ",			// 0x28
            "UNKAQCMD 0x29",			// 0x29
            "UNKAQCMD 0x2A",			// 0x2A
            "UNKAQCMD 0x2B",			// 0x2B
            "UNKAQCMD 0x2C",			// 0x2C
            "UNKAQCMD 0x2D",			// 0x2D
            "UNKAQCMD 0x2E",			// 0x2E
            "UNKAQCMD 0x2F",			// 0x2F
            			
            "UNKAQCMD 0x30",			// 0x30
            "UNKAQCMD 0x31",			// 0x31
            "UNKAQCMD 0x32",			// 0x32
            "UNKAQCMD 0x33",			// 0x33
            "UNKAQCMD 0x34",			// 0x34
            "UNKAQCMD 0x35",			// 0x35
            "UNKAQCMD 0x36",			// 0x36
            "UNKAQCMD 0x37",			// 0x37
            "UNKAQCMD 0x38",			// 0x38
            "UNKAQCMD 0x39",			// 0x39
            "UNKAQCMD 0x3A",			// 0x3A
            "UNKAQCMD 0x3B",			// 0x3B
            "UNKAQCMD 0x3C",			// 0x3C
            "If in air, jump to $",			// 0x3D
            "UNKAQCMD 0x3E",			// 0x3E
            "UNKAQCMD 0x3F",			// 0x3F
            			
            "Shift x1 step east",			// 0x40
            "Shift x1 step southeast",			// 0x41
            "Shift x1 step south",			// 0x42
            "Shift x1 step southwest",			// 0x43
            "Shift x1 step west",			// 0x44
            "Shift x1 step northwest",			// 0x45
            "Shift x1 step north",			// 0x46
            "Shift x1 step northeast",			// 0x47
            "Shift x1 step in facing direction",			// 0x48
            "UNKAQCMD 0x49",			// 0x49
            "Elevate x1 step up",			// 0x4A
            "Elevate x1 step down",			// 0x4B
            "UNKAQCMD 0x4C",			// 0x4C
            "UNKAQCMD 0x4D",			// 0x4D
            "UNKAQCMD 0x4E",			// 0x4E
            "UNKAQCMD 0x4F",			// 0x4F
            			
            "Shift east, isometric units = ",			// 0x50
            "Shift southeast, isometric units = ",			// 0x51
            "Shift south, isometric units = ",			// 0x52
            "Shift southwest, isometric units = ",			// 0x53
            "Shift west, isometric units = ",			// 0x54
            "Shift northwest, isometric units = ",			// 0x55
            "Shift north, isometric units = ",			// 0x56
            "Shift northeast, isometric units = ",			// 0x57
            "Shift in facing direction, isometric units = ",			// 0x58
            "Shift 20 isometric units in facing direction",			// 0x59
            "Elevate up, isometric units = ",			// 0x5A
            "Elevate down, isometric units = ",			// 0x5B
            "Elevate 20 isometric units up",			// 0x5C
            "Elevate 20 isometric units down",			// 0x5D
            "UNKAQCMD 0x5E",			// 0x5E
            "UNKAQCMD 0x5F",			// 0x5F
            			
            "Shift east, pixels = ",			// 0x60
            "Shift southeast, pixels = ",			// 0x61
            "Shift south, pixels = ",			// 0x62
            "Shift southwest, pixels = ",			// 0x63
            "Shift west, pixels = ",			// 0x64
            "Shift northwest, pixels = ",			// 0x65
            "Shift north, pixels = ",			// 0x66
            "Shift northeast, pixels = ",			// 0x67
            "Shift in facing direction, pixels = ",			// 0x68
            "Shift 16px in facing direction",			// 0x69
            "Elevate up, pixels = ",			// 0x6A
            "Elevate down, pixels = ",			// 0x6B
            "UNKAQCMD 0x6C",			// 0x6C
            "UNKAQCMD 0x6D",			// 0x6D
            "UNKAQCMD 0x6E",			// 0x6E
            "UNKAQCMD 0x6F",			// 0x6F
            			
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
            "Turn clockwise 45° x",			// 0x7B
            "Face east",			// 0x7C
            "Face southwest",			// 0x7D
            "Jump, isometric units = ",			// 0x7E
            "Jump, 1px units = ",			// 0x7F
            			
            "Shift to isometric coords (x=",			// 0x80
            "Shift isometric units (x=",			// 0x81
            "Transfer to isometric coords (x=",			// 0x82
            "Transfer isometric units (x=",			// 0x83
            "Transfer isometric pixels (x=",			// 0x84
            "UNKAQCMD 0x85",			// 0x85
            "UNKAQCMD 0x86",			// 0x86
            "Transfer to coords of obj: ",			// 0x87
            "UNKAQCMD 0x88",			// 0x88
            "UNKAQCMD 0x89",			// 0x89
            "UNKAQCMD 0x8A",			// 0x8A
            "UNKAQCMD 0x8B",			// 0x8B
            "UNKAQCMD 0x8C",			// 0x8C
            "UNKAQCMD 0x8D",			// 0x8D
            "UNKAQCMD 0x8E",			// 0x8E
            "UNKAQCMD 0x8F",			// 0x8F
            			
            "Bounce to isometric coords (x=",			// 0x90
            "Bounce isometric units (x=",			// 0x91
            "Transfer to isometric coords (x=",			// 0x92
            "Transfer isometric units (x=",			// 0x93
            "Transfer isometric pixels (x=",			// 0x94
            "Transfer to isometric coords of obj: ",			// 0x95
            "UNKAQCMD 0x96",			// 0x96
            "UNKAQCMD 0x97",			// 0x97
            "UNKAQCMD 0x98",			// 0x98
            "UNKAQCMD 0x99",			// 0x99
            "UNKAQCMD 0x9A",			// 0x9A
            "Playback stop, sound",			// 0x9B
            "Playback start, sound = ",			// 0x9C
            "Playback start, sound = ",			// 0x9D
            "Playback fade-out sound, duration: ",			// 0x9E
            "UNKAQCMD 0x9F",			// 0x9F
            			
            "Set mem 00:",			// 0xA0
            "Set mem 00:",			// 0xA1
            "Set mem 00:",			// 0xA2
            "Set mem @ 00:700C",			// 0xA3
            "Clear mem 00:",			// 0xA4
            "Clear mem 00:",			// 0xA5
            "Clear mem 00:",			// 0xA6
            "Clear mem @ 00:700C",			// 0xA7
            "Mem 00:",			// 0xA8
            "Mem 00:",			// 0xA9
            "Mem 00:",			// 0xAA
            "Mem 00:",			// 0xAB
            "Mem 00:700C = ",			// 0xAC
            "Mem 00:700C += ",			// 0xAD
            "Mem 00:700C increment",			// 0xAE
            "Mem 00:700C decrement",			// 0xAF
            			
            "Mem 00:",			// 0xB0
            "Mem 00:",			// 0xB1
            "Mem 00:",			// 0xB2
            "Mem 00:",			// 0xB3
            "Mem 00:700C = mem 00:",			// 0xB4
            "Mem 00:",			// 0xB5
            "Mem 00:700C = random # less than: ",			// 0xB6
            "Mem 00:", 			// 0xB7
            "Mem 00:700C += mem 00:",			// 0xB8
            "Mem 00:700C -= mem 00:",			// 0xB9
            "Mem 00:700C = mem 00:",			// 0xBA
            "Mem 00:",			// 0xBB
            "Mem 00:",			// 0xBC
            "Mem 00:",			// 0xBD
            "UNKAQCMD 0xBE",			// 0xBE
            "UNKAQCMD 0xBF",			// 0xBF
            			
            "Compare mem 00:700C to ",			// 0xC0
            "Compare mem 00:700C to mem 00:",			// 0xC1
            "Compare mem 00:",			// 0xC2
            "Mem 00:700C = current level",			// 0xC3
            "Mem 00:700C = X coord of obj: ",			// 0xC4
            "Mem 00:700C = Y coord of obj: ",			// 0xC5
            "Mem 00:700C = Z coord of obj: ",			// 0xC6
            "UNKCMD 0xC7",			// 0xC7
            "UNKCMD 0xC8",			// 0xC8
            "UNKCMD 0xC9",			// 0xC9
            "Mem 00:700C = held joypad register",			// 0xCA
            "Mem 00:700C = tapped joypad register",			// 0xCB
            "UNKCMD 0xCC",			// 0xCC
            "UNKCMD 0xCD",			// 0xCD
            "UNKCMD 0xCE",			// 0xCE
            "UNKCMD 0xCF",			// 0xCF
            			
            "Set action script = ",			// 0xD0
            "UNKAQCMD 0xD1",			// 0xD1
            "Jump to $",			// 0xD2
            "Jump to subroutine $",			// 0xD3
            "Loop start, loop count: ",			// 0xD4
            "UNKAQCMD 0xD5",			// 0xD5
            "Load mem 00:",			// 0xD6
            "Loop end",			// 0xD7
            "If set, mem 00:",			// 0xD8
            "If set, mem 00:",			// 0xD9
            "If set, mem 00:",			// 0xDA
            "If mem 00:7000 bit(s) set, jump to $",			// 0xDB
            "If clear, mem 00:",			// 0xDC
            "If clear, mem 00:",			// 0xDD
            "If clear, mem 00:",			// 0xDE
            "If mem 00:7000 bit(s) clear, jump to $",			// 0xDF
            			
            "If mem 00:",			// 0xE0
            "If mem 00:",			// 0xE1
            "If mem 00:700C = ",			// 0xE2
            "If mem 00:700C != ",			// 0xE3
            "If mem 00:",			// 0xE4
            "If mem 00:",			// 0xE5
            "If mem 00:700C set, no bits: ",			// 0xE6
            "If mem 00:700C set, any bits: ",			// 0xE7
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
            "Set obj: mem 00:70A8, presence = true (current level)",			// 0xF4
            "Set obj: mem 00:70A8, presence = false (current level)",			// 0xF4
            "Set obj: mem 00:70A8, event trigger = true",			// 0xF6
            "Set obj: mem 00:70A8, event trigger = false",			// 0xF7
            "If obj: ",			// 0xF8
            "UNKAQCMD 0xF9",			// 0xF9
            "UNKAQCMD 0xFA",			// 0xFA
            "UNKAQCMD 0xFB",			// 0xFB
            "UNKAQCMD 0xFC",			// 0xFC
            "",			// 0xFD
            "Return queue",			// 0xFE
            "Return queue all"			// 0xFF
        };
        private static string[] ActionQueueCommandFDOptions = new string[]
        {
            "Sprite shadow = true",			// 0x00
            "Sprite shadow = false",			// 0x01
            "Floating = false",			// 0x02
            "Floating = true",			// 0x03
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
            "Layer priority = ",			// 0x0F
            			
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
			
            "UNKCMD 0xFD Option 0x30",			// 0x30
            "UNKCMD 0xFD Option 0x31",			// 0x31
            "UNKCMD 0xFD Option 0x32",			// 0x32
            "UNKCMD 0xFD Option 0x33",			// 0x33
            "UNKCMD 0xFD Option 0x34",			// 0x34
            "UNKCMD 0xFD Option 0x35",			// 0x35
            "UNKCMD 0xFD Option 0x36",			// 0x36
            "UNKCMD 0xFD Option 0x37",			// 0x37
            "UNKCMD 0xFD Option 0x38",			// 0x38
            "UNKCMD 0xFD Option 0x39",			// 0x39
            "UNKCMD 0xFD Option 0x3A",			// 0x3A
            "UNKCMD 0xFD Option 0x3B",			// 0x3B
            "UNKCMD 0xFD Option 0x3C",			// 0x3C
            "UNKCMD 0xFD Option 0x3D",			// 0x3D
            "UNKCMD 0xFD Option 0x3E",			// 0x3E
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
            "UNKCMD 0xFD Option 0x4A",			// 0x4A
            "UNKCMD 0xFD Option 0x4B",			// 0x4B
            "UNKCMD 0xFD Option 0x4C",			// 0x4C
            "UNKCMD 0xFD Option 0x4D",			// 0x4D
            "UNKCMD 0xFD Option 0x4E",			// 0x4E
            "UNKCMD 0xFD Option 0x4F",			// 0x4F
			
            "UNKCMD 0xFD Option 0x50",			// 0x50
            "UNKCMD 0xFD Option 0x51",			// 0x51
            "UNKCMD 0xFD Option 0x52",			// 0x52
            "UNKCMD 0xFD Option 0x53",			// 0x53
            "UNKCMD 0xFD Option 0x54",			// 0x54
            "UNKCMD 0xFD Option 0x55",			// 0x55
            "UNKCMD 0xFD Option 0x56",			// 0x56
            "UNKCMD 0xFD Option 0x57",			// 0x57
            "UNKCMD 0xFD Option 0x58",			// 0x58
            "UNKCMD 0xFD Option 0x59",			// 0x59
            "UNKCMD 0xFD Option 0x5A",			// 0x5A
            "UNKCMD 0xFD Option 0x5B",			// 0x5B
            "UNKCMD 0xFD Option 0x5C",			// 0x5C
            "UNKCMD 0xFD Option 0x5D",			// 0x5D
            "UNKCMD 0xFD Option 0x5E",			// 0x5E
            "UNKCMD 0xFD Option 0x5F",			// 0x5F
			
            "UNKCMD 0xFD Option 0x60",			// 0x60
            "UNKCMD 0xFD Option 0x61",			// 0x61
            "UNKCMD 0xFD Option 0x62",			// 0x62
            "UNKCMD 0xFD Option 0x63",			// 0x63
            "UNKCMD 0xFD Option 0x64",			// 0x64
            "UNKCMD 0xFD Option 0x65",			// 0x65
            "UNKCMD 0xFD Option 0x66",			// 0x66
            "UNKCMD 0xFD Option 0x67",			// 0x67
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
            "UNKCMD 0xFD Option 0x94",			// 0x94
            "UNKCMD 0xFD Option 0x95",			// 0x95
            "UNKCMD 0xFD Option 0x96",			// 0x96
            "UNKCMD 0xFD Option 0x97",			// 0x97
            "UNKCMD 0xFD Option 0x98",			// 0x98
            "UNKCMD 0xFD Option 0x99",			// 0x99
            "UNKCMD 0xFD Option 0x9A",			// 0x9A
            "UNKCMD 0xFD Option 0x9B",			// 0x9B
            "UNKCMD 0xFD Option 0x9C",			// 0x9C
            "UNKCMD 0xFD Option 0x9D",			// 0x9D
            "Playback start, sound = ",			// 0x9E
            "UNKCMD 0xFD Option 0x9F",			// 0x9F
			
            "UNKCMD 0xFD Option 0xA0",			// 0xA0
            "UNKCMD 0xFD Option 0xA1",			// 0xA1
            "UNKCMD 0xFD Option 0xA2",			// 0xA2
            "UNKCMD 0xFD Option 0xA3",			// 0xA3
            "UNKCMD 0xFD Option 0xA4",			// 0xA4
            "UNKCMD 0xFD Option 0xA5",			// 0xA5
            "UNKCMD 0xFD Option 0xA6",			// 0xA6
            "UNKCMD 0xFD Option 0xA7",			// 0xA7
            "UNKCMD 0xFD Option 0xA8",			// 0xA8
            "UNKCMD 0xFD Option 0xA9",			// 0xA9
            "UNKCMD 0xFD Option 0xAA",			// 0xAA
            "UNKCMD 0xFD Option 0xAB",			// 0xAB
            "UNKCMD 0xFD Option 0xAC",			// 0xAC
            "UNKCMD 0xFD Option 0xAD",			// 0xAD
            "UNKCMD 0xFD Option 0xAE",			// 0xAE
            "UNKCMD 0xFD Option 0xAF",			// 0xAF
			
            "Mem 00:700C, isolate bits = ",			// 0xB0
            "Mem 00:700C, set bits = ",			// 0xB1
            "Mem 00:700C, xor bits = ",			// 0xB2
            "Mem 00:700C, isolate bits, from mem 00:",			// 0xB3
            "Mem 00:700C, set bits, from mem 00:",			// 0xB4
            "Mem 00:700C, xor bits, from mem 00:",			// 0xB5
            "Shift mem 00:",			// 0xB6
            "UNKCMD 0xFD Option 0xB7",			// 0xB7
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
            "UNKCMD 0xFD Option 0xF8",			// 0xF8
            "UNKCMD 0xFD Option 0xF9",			// 0xF9
            "UNKCMD 0xFD Option 0xFA",			// 0xFA
            "UNKCMD 0xFD Option 0xFB",			// 0xFB
            "UNKCMD 0xFD Option 0xFC",			// 0xFC
            "UNKCMD 0xFD Option 0xFD",			// 0xFD
            "UNKCMD 0xFD Option 0xFE",			// 0xFE
            "UNKCMD 0xFD Option 0xFF"			// 0xFF
        };
        #endregion
        public string InterpretActionQueue(ActionQueueCommand aqc)
        {
            StringBuilder sb = new StringBuilder();
            string a, b, c, d;

            //sb.Append("[" + (aqc.CommandOffset + aqc.QueueOffset).ToString("X4") + "]   ");

            sb.Append(ActionQueueCommands[aqc.Opcode]);

            switch (aqc.Opcode)
            {
                case 0x08:
                    a = (aqc.Option & 0x08) == 0x08 ? ", mold = true" : ", mold = false";
                    b = (aqc.Option & 0x10) == 0x10 ? ", playback once = true" : ", playback once = false";
                    c = (aqc.QueueData[2] & 0x80) == 0x80 ? ", mirror = true" : ", mirror = false";
                    d = (aqc.Option & 0x08) == 0x08 ? ", mold = " : ", seq = ";
                    sb.Append(
                        (aqc.Option & 0x07).ToString() + a + b + d + (aqc.QueueData[2] & 0x7F).ToString() + c);
                    break;
                case 0x0A:
                    sb.Append(aqc.Option.ToString());
                    break;
                case 0x0B:
                case 0x0C:
                case 0x15:
                    sb.Append(GetBits(aqc.Option, BitNames, 8));
                    break;
                case 0x11:
                case 0x12:
                case 0x13:
                case 0x14:
                case 0xD4:
                    sb.Append(aqc.Option.ToString());
                    break;
                case 0x0D:
                case 0x0E:
                    sb.Append((aqc.Option & 0x0F).ToString());
                    break;
                case 0x10:
                    a = (aqc.Option & 0x40) == 0x40 ? ", shift = true" : ", shift = false";
                    b = (aqc.Option & 0x80) == 0x80 ? ", seq = true" : ", seq = false";
                    sb.Append((aqc.Option & 0x07).ToString() + a + b);
                    break;
                case 0x26:
                case 0x27:
                case 0x28:
                    sb.Append("{" + BitConverter.ToString(aqc.QueueData, 1) + "}");
                    break;
                case 0x50:
                case 0x51:
                case 0x52:
                case 0x53:
                case 0x54:
                case 0x55:
                case 0x56:
                case 0x57:
                case 0x58:
                case 0x5A:
                case 0x5B:
                case 0x60:
                case 0x61:
                case 0x62:
                case 0x63:
                case 0x64:
                case 0x65:
                case 0x66:
                case 0x67:
                case 0x68:
                case 0x6A:
                case 0x6B:
                case 0x7B:
                case 0xF0:
                    sb.Append(aqc.Option.ToString());
                    break;
                case 0x9C:
                    sb.Append(Scripts.SoundNames[Math.Min(aqc.Option, (byte)0xA2)]);
                    break;
                case 0x7E:
                case 0x7F:
                    sb.Append(BitManager.GetShort(aqc.QueueData, 1).ToString());
                    break;
                case 0x80:
                case 0x81:
                case 0x82:
                case 0x83:
                case 0x84:
                    if (aqc.Opcode != 0x80 || aqc.Opcode != 0x82)
                        sb.Append(((sbyte)aqc.Option).ToString() + ", y=" + ((sbyte)aqc.QueueData[2]).ToString() + ")");
                    else
                        sb.Append(aqc.Option.ToString() + ", y=" + aqc.QueueData[2].ToString() + ")");
                    break;
                case 0x87:
                    sb.Append(ObjectNames[aqc.Option]);
                    break;
                case 0x90:
                case 0x91:
                    if (aqc.Opcode != 0x90)
                        sb.Append(((sbyte)aqc.Option).ToString() + ", y=" + ((sbyte)aqc.QueueData[2]).ToString());
                    else
                        sb.Append(aqc.Option.ToString() + ", y=" + aqc.QueueData[2].ToString());
                    sb.Append("), archHeight = " + aqc.QueueData[3].ToString());
                    break;
                case 0x92:
                case 0x93:
                case 0x94:
                    if (aqc.Opcode != 0x92)
                        sb.Append(((sbyte)aqc.Option).ToString() + ", y=" + ((sbyte)aqc.QueueData[2]).ToString());
                    else
                        sb.Append(aqc.Option.ToString() + ", y=" + aqc.QueueData[2].ToString());
                    sb.Append(", z=" + aqc.QueueData[3].ToString() + ")");
                    break;
                case 0x95:
                    sb.Append(ObjectNames[aqc.Option]);
                    break;
                case 0x9D:
                    sb.Append(Scripts.SoundNames[aqc.Option] + ", speaker balance: " +
                        aqc.QueueData[2].ToString());
                    break;
                case 0x9E:
                    sb.Append(aqc.Option.ToString() +
                        ", min volume: " +
                        aqc.QueueData[2].ToString());
                    break;
                case 0xA0:
                case 0xA1:
                case 0xA2:
                    sb.Append((((((aqc.Opcode * 0x100) + aqc.Option) - 0xA000) / 8) + 0x7040).ToString("X4") +
                       ", bit: " + (aqc.Option & 0x07).ToString());
                    break;
                case 0xA4:
                case 0xA5:
                case 0xA6:
                    sb.Append((((((aqc.Opcode * 0x100) + aqc.Option) - 0xA400) / 8) + 0x7040).ToString("X4") +
                       ", bit: " + (aqc.Option & 0x07).ToString());
                    break;
                case 0xA8:
                    sb.Append((aqc.Option + 0x70A0).ToString("X4") +
                        " = " + aqc.QueueData[2]);
                    break;
                case 0xA9:
                    sb.Append((aqc.Option + 0x70A0).ToString("X4") +
                         " += " + aqc.QueueData[2]);
                    break;
                case 0xAA:
                    sb.Append((aqc.Option + 0x70A0).ToString("X4") + " increment");
                    break;
                case 0xAB:
                    sb.Append((aqc.Option + 0x70A0).ToString("X4") + " decrement");
                    break;
                case 0xAC:
                case 0xAD:
                    sb.Append(BitManager.GetShort(aqc.QueueData, 1).ToString());
                    break;
                case 0xC0:
                case 0xD0:
                case 0xF1:
                    sb.Append(BitManager.GetShort(aqc.QueueData, 1).ToString());
                    break;
                case 0xB0:
                    sb.Append(((aqc.Option * 2) + 0x7000).ToString("X4") +
                    " = " + BitManager.GetShort(aqc.QueueData, 2).ToString());
                    break;
                case 0xB1:
                    sb.Append(((aqc.Option * 2) + 0x7000).ToString("X4") +
                        " += " + BitManager.GetShort(aqc.QueueData, 2).ToString());
                    break;
                case 0xB2:
                    sb.Append(((aqc.Option * 2) + 0x7000).ToString("X4") + " increment");
                    break;
                case 0xB3:
                    sb.Append(((aqc.Option * 2) + 0x7000).ToString("X4") + " decrement");
                    break;
                case 0xB4:
                    sb.Append((aqc.Option + 0x70A0).ToString("X4"));
                    break;
                case 0xB5:
                    sb.Append((aqc.Option + 0x70A0).ToString("X4") + " = mem 00:7000");
                    break;
                case 0xB6:
                    sb.Append(BitManager.GetShort(aqc.QueueData, 1).ToString());
                    break;
                case 0xB7:
                    sb.Append(((aqc.Option * 2) + 0x7000).ToString("X4") +
                        " = random # less than: " + BitManager.GetShort(aqc.QueueData, 2).ToString());
                    break;
                case 0xB8:
                case 0xB9:
                case 0xBA:
                case 0xC1:
                    sb.Append(((aqc.Option * 2) + 0x7000).ToString("X4"));
                    break;
                case 0xC2:
                    sb.Append(((aqc.Option * 2) + 0x7000).ToString("X4") + " to " +
                        BitManager.GetShort(aqc.QueueData, 2).ToString());
                    break;
                case 0xBB:
                    sb.Append(((aqc.Option * 2) + 0x7000).ToString("X4") + " = mem 00:700C");
                    break;
                case 0xBC:
                    sb.Append(((aqc.Option * 2) + 0x7000).ToString("X4") + " = mem 00:" +
                    ((aqc.QueueData[2] * 2) + 0x7000).ToString("X4"));
                    break;
                case 0xBD:
                    sb.Append(((aqc.Option * 2) + 0x7000).ToString("X4") + " <=> mem 00:" +
                        ((aqc.QueueData[2] * 2) + 0x7000).ToString("X4"));
                    break;
                case 0xC4:
                case 0xC5:
                case 0xC6:
                    sb.Append(ObjectNames[aqc.Option & 0x3F]);
                    break;
                case 0xD6:
                    sb.Append(((aqc.Option * 2) + 0x7000).ToString("X4"));
                    break;
                case 0xD2:
                case 0xD3:
                case 0xDB:
                case 0xDF:
                    sb.Append((BitManager.GetShort(aqc.QueueData, 1)).ToString("X4"));
                    break;
                case 0xD8:
                case 0xD9:
                case 0xDA:
                    sb.Append((((((aqc.Opcode * 0x100) + aqc.Option) - 0xD800) / 8) + 0x7040).ToString("X4") + ", bit: " +
                        (aqc.Option & 0x07).ToString() + ", jump to $" +
                        (BitManager.GetShort(aqc.QueueData, 2)).ToString("X4"));
                    break;
                case 0xDC:
                case 0xDD:
                case 0xDE:
                    sb.Append((((((aqc.Opcode * 0x100) + aqc.Option) - 0xDC00) / 8) + 0x7040).ToString("X4") + ", bit: " +
                        (aqc.Option & 0x07).ToString() + ", jump to $" +
                        (BitManager.GetShort(aqc.QueueData, 2)).ToString("X4"));
                    break;
                case 0xE0:
                    sb.Append((aqc.Option + 0x70A0).ToString("X4") + " = " +
                        aqc.QueueData[2].ToString() + ", jump to $" +
                        (BitManager.GetShort(aqc.QueueData, 3)).ToString("X4"));
                    break;
                case 0xE1:
                    sb.Append((aqc.Option + 0x70A0).ToString("X4") + " != " +
                        aqc.QueueData[2].ToString() + ", jump to $" +
                        (BitManager.GetShort(aqc.QueueData, 3)).ToString("X4"));
                    break;
                case 0xE2:
                case 0xE3:
                    sb.Append((BitManager.GetShort(aqc.QueueData, 1)).ToString() + ", jump to $" +
                    (BitManager.GetShort(aqc.QueueData, 3)).ToString("X4"));
                    break;
                case 0xE4:
                    sb.Append(((aqc.Option * 2) + 0x7000).ToString("X4") + " = " +
                        (BitManager.GetShort(aqc.QueueData, 2)).ToString() + ", jump to $" +
                        (BitManager.GetShort(aqc.QueueData, 4)).ToString("X4"));
                    break;
                case 0xE5:
                    sb.Append(((aqc.Option * 2) + 0x7000).ToString("X4") + " != " +
                    (BitManager.GetShort(aqc.QueueData, 2)).ToString() + ", jump to $" +
                    (BitManager.GetShort(aqc.QueueData, 4)).ToString("X4"));
                    break;
                case 0xE6:
                case 0xE7:
                    sb.Append(BitManager.GetShort(aqc.QueueData, 1).ToString("X4") + ", jump to $" +
                        BitManager.GetShort(aqc.QueueData, 3).ToString("X4"));
                    break;
                case 0x3D:
                case 0xE8:
                case 0xEA:
                case 0xEB:
                case 0xEC:
                case 0xED:
                case 0xEE:
                case 0xEF:
                    sb.Append(BitManager.GetShort(aqc.QueueData, 1).ToString("X4"));
                    break;
                case 0xE9:
                    sb.Append(BitManager.GetShort(aqc.QueueData, 1).ToString("X4") + ", else jump to $" +
                        BitManager.GetShort(aqc.QueueData, 3).ToString("X4"));
                    break;
                case 0xF2:
                    a = (aqc.QueueData[2] & 0x80) == 0x80 ? "true" : "false";
                    sb.Append(ObjectNames[((aqc.QueueData[2] >> 1) & 0x3F)] +
                        ", in level: [" + (BitManager.GetShort(aqc.QueueData, 1) & 0x1FF).ToString("d3") +
                        "], presence = " + a);
                    break;
                case 0xF3:
                    a = (aqc.QueueData[2] & 0x80) == 0x80 ? "true" : "false";
                    sb.Append(ObjectNames[((aqc.QueueData[2] >> 1) & 0x3F)] +
                        ", in level: [" + (BitManager.GetShort(aqc.QueueData, 1) & 0x1FF).ToString("d3") +
                        "], event trigger = " + a);
                    break;
                case 0xF8:
                    a = (aqc.QueueData[2] & 0x80) == 0x80 ? "true" : "false";
                    sb.Append(ObjectNames[((aqc.QueueData[2] >> 1) & 0x3F)] +
                        ", in level: [" + (BitManager.GetShort(aqc.QueueData, 1) & 0x1FF).ToString("d3") +
                        "], presence = " + a +
                        ", jump to $" + BitManager.GetShort(aqc.QueueData, 3).ToString("X4"));
                    break;
                case 0xFD:
                    sb.Append(ESC_FD_Options(aqc));
                    break;
                default:
                    break;
            }
            return sb.ToString();
        }
        private string ESC_FD_Options(ActionQueueCommand aqc)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(ActionQueueCommandFDOptions[aqc.Option]);

            switch (aqc.Option)
            {
                case 0x0F:
                    sb.Append(aqc.QueueData[2].ToString());
                    break;
                case 0x9E:
                    sb.Append(Scripts.SoundNames[aqc.QueueData[2]]);
                    break;
                case 0xB0:
                case 0xB1:
                case 0xB2:
                    sb.Append(BitManager.GetShort(aqc.QueueData, 2).ToString());
                    break;
                case 0xB3:
                case 0xB4:
                case 0xB5:
                    sb.Append(((aqc.QueueData[2] * 2) + 0x7000).ToString("X4"));
                    break;
                case 0xB6:
                    sb.Append(((aqc.QueueData[2] * 2) + 0x7000).ToString("X4") + ", shifts: " +
                        ((aqc.QueueData[3] ^ 0xFF) + 1).ToString());
                    break;
                default:
                    break;
            }

            return sb.ToString();
        }

    }
}