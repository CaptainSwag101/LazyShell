using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using SMRPGED.ScriptsEditor;
using SMRPGED.ScriptsEditor.Commands;

namespace SMRPGED.ScriptsEditor
{
    public partial class Scripts
    {
        ActionQueue[] actionScripts;

        #region Static Code
        private static int[][] actionListBoxOpcodes = new int[][]
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
                    0xB8,0xB9,0xBA,0xC0,0xC1,0xC3,0xC6,0xCA,
                    0xCB,0xDB,0xDF,0xE2,0xE3,0xE6,0xE7,0xEA,
                    0xEB,0xEC,0xED,0xEE,0xEF,0xFD,0xFD,0xFD,
                    0xFD,0xFD,0xFD
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
        private static int[][] actionListBoxFDOpcodes = new int[][]
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
        #endregion

        private string[] ActionListBoxNames(int index)
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
                    "Face south",			// 0x78
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
                    "Transfer isometric pixels...",			// 0x94
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

                    "Halve mem...",			// 0xB6
                    };

                case 11:
                    return new string[] 
                    { 
                    "Set mem @ 00:700C",			// 0xA3
                    "Clear mem @ 00:700C",			// 0xA7
                    "Mem 00:700C =...",			// 0xAC
                    "Mem 00:700C +=...",			// 0xAD
                    "Mem 00:700C increment",			// 0xAE
                    "Mem 00:700C decrement",			// 0xAF
                    "Mem 00:700C = mem...",			// 0xB4
                    "Mem 00:700C = random # less than...",			// 0xB6
                    "Mem 00:700C += mem...",			// 0xB8
                    "Mem 00:700C -= mem...",			// 0xB9
                    "Mem 00:700C = mem...",			// 0xBA
                    "Mem 00:700C compare to...",			// 0xC0
                    "Mem 00:700C compare to mem...",			// 0xC1
                    "Mem 00:700C = current level",			// 0xC3
                    "Mem 00:700C = obj mem...",			// 0xC6
                    "Mem 00:700C = held joypad register",			// 0xCA
                    "Mem 00:700C = tapped joypad register",			// 0xCB
                    "If mem 00:700C bit(s) set, jump to...",			// 0xDB
                    "If mem 00:700C bit(s) clear, jump to...",			// 0xDF
                    "If mem 00:700C =...",			// 0xE2
                    "If mem 00:700C !=...",			// 0xE3
                    "If mem 00:700C set, no bits...",			// 0xE6
                    "If mem 00:700C set, any bits...",			// 0xE7
                    "If equal to zero, jump to...",			// 0xEA
                    "If not equal to zero, jump to...",			// 0xEB
                    "If greater than / equal to, jump to...",			// 0xEC
                    "If less than, jump to...",			// 0xED
                    "If negative, jump to...",			// 0xEE
                    "If positive, jump to...",			// 0xEF

                    /********FD OPTIONS********/

                    "00:700C, isolate bits =...",			// 0xB0
                    "00:700C, set bits =...",			// 0xB1
                    "00:700C, xor bits =...",			// 0xB2
                    "00:700C, isolate bits, from mem...",			// 0xB3
                    "00:700C, set bits, from mem...",			// 0xB4
                    "00:700C, xor bits, from mem...",			// 0xB5
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
                    "Set object presence...",			// 0xF2
                    "Set object engage type...",			// 0xF3
                    "Set object: mem 00:70A8, presence = true (current level)",			// 0xF4
                    "Set object: mem 00:70A8, presence = false (current level)",			// 0xF4
                    "Set object: mem 00:70A8, event trigger = true",			// 0xF6
                    "Set object: mem 00:70A8, event trigger = false",			// 0xF7
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

        private void ControlActionDisasmMethod()
        {
            updatingControls = false;

            switch (aqc.Opcode)
            {
                // Properties
                case 0x0A:
                    labelTitleA.Text = "Solidity properties = ...";
                    labelEvtC.Text = "value";
                    evtNumC.Enabled = true;

                    evtNumC.Value = aqc.Option;
                    break;
                case 0x0B: labelTitleA.Text = "Solidity properties, set bits..."; goto case 0x0C;
                case 0x15: labelTitleA.Text = "Movement properties |=..."; goto case 0x0C;
                case 0x0C:
                    if (aqc.Opcode == 0x0C) labelTitleA.Text = "Solidity properties, clear bits...";
                    labelTitleB.Text = "bits...";
                    evtEffects.Items.AddRange(new string[] 
                        { 
                            "bit 0", "can't walk under", "can't pass walls", "can't jump through", 
                            "bit 4", "can't pass NPCs", "can't walk through", "bit 7", 
                        });
                    evtEffects.Enabled = true;

                    for (int i = 1, j = 0; j < 8; i *= 2, j++)
                        evtEffects.SetItemChecked(j, (aqc.Option & i) == i);
                    break;
                case 0x13:
                    labelTitleA.Text = "Sprite priority, set...";
                    labelEvtC.Text = "priority";
                    evtNumC.Maximum = 3; evtNumC.Enabled = true;

                    evtNumC.Value = aqc.Option;
                    break;
                case 0x3D:
                    labelTitleA.Text = "If in air, jump to...";
                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true; evtNumC.Maximum = 0xFFFF; evtNumC.Enabled = true;

                    evtNumC.Value = BitManager.GetShort(aqc.QueueData, 1);
                    break;

                // Palette
                case 0x0D: labelTitleA.Text = "Palette index, set =..."; evtNumC.Maximum = 15; goto case 0x0E;
                case 0x0E:
                    if (aqc.Opcode == 0x0E) labelTitleA.Text = "Palette index, shift =...";
                    labelEvtC.Text = "value";
                    evtNumC.Enabled = true;

                    evtNumC.Value = aqc.Option;
                    break;

                // Sprite Sequence
                case 0x08:
                    labelTitleA.Text = "Sequence playback, sprite +=...";
                    labelEvtC.Text = "object +=";
                    labelTitleB.Text = "properties";
                    evtNumC.Maximum = 7; evtNumC.Enabled = true;
                    evtNumD.Maximum = 127; evtNumD.Enabled = true;
                    evtEffects.Items.AddRange(new string[]
                    {
                        "read from mold",
                        "playback only once",
                        "bit 6",
                        "mirror sprite"
                    });
                    evtEffects.Enabled = true;

                    evtNumC.Value = aqc.Option & 0x07;
                    evtNumD.Value = aqc.QueueData[2] & 0x7F;
                    evtEffects.SetItemChecked(0, (aqc.Option & 0x08) == 0x08);
                    evtEffects.SetItemChecked(1, (aqc.Option & 0x10) == 0x10);
                    evtEffects.SetItemChecked(2, (aqc.Option & 0x40) == 0x40);
                    evtEffects.SetItemChecked(3, (aqc.QueueData[2] & 0x80) == 0x80);

                    if (evtEffects.GetItemChecked(0)) labelEvtD.Text = "mold";
                    else labelEvtD.Text = "sequence";

                    /*
                     * TODO
                     * set labelEvtD.text based on bit 3 of byte 2
                     * if set, make "frame", else "sequence"
                     */
                    break;
                case 0x10:
                    labelTitleA.Text = "Playback, set speed = ...";
                    labelEvtA.Text = "speed change";
                    labelTitleB.Text = "flags";
                    evtNameA.Items.AddRange(new string[]
                    {
                        "normal",
                        "speed up x2","speed up x2.5",
                        "speed up x4", "speed up x8",
                        "speed down x2", "speed down x4"
                    });
                    evtNameA.Enabled = true;
                    evtEffects.Items.AddRange(new string[] { "shift", "sequence" });
                    evtEffects.Enabled = true;

                    evtNameA.SelectedIndex = aqc.Option & 0x0F;
                    evtEffects.SetItemChecked(0, (aqc.Option & 0x40) == 0x40);
                    evtEffects.SetItemChecked(1, (aqc.Option & 0x80) == 0x80);
                    break;
                case 0xD0:
                    labelTitleA.Text = "Set action script =...";
                    labelEvtC.Text = "action #";
                    evtNumC.Maximum = 0x3FF; evtNumC.Enabled = true;

                    evtNumC.Value = BitManager.GetShort(aqc.QueueData, 1) & 0x3FF;
                    break;

                // Sprite Animation


                // Shift isometric units
                case 0x50: labelTitleA.Text = "Shift east, isometric units =..."; goto case 0x5B;
                case 0x51: labelTitleA.Text = "Shift southeast, isometric units =..."; goto case 0x5B;
                case 0x52: labelTitleA.Text = "Shift south, isometric units =..."; goto case 0x5B;
                case 0x53: labelTitleA.Text = "Shift southwest, isometric units =..."; goto case 0x5B;
                case 0x54: labelTitleA.Text = "Shift west, isometric units =..."; goto case 0x5B;
                case 0x55: labelTitleA.Text = "Shift northwest, isometric units =..."; goto case 0x5B;
                case 0x56: labelTitleA.Text = "Shift north, isometric units =..."; goto case 0x5B;
                case 0x57: labelTitleA.Text = "Shift northeast, isometric units =..."; goto case 0x5B;
                case 0x58: labelTitleA.Text = "Shift in facing direction, isometric units =..."; goto case 0x5B;
                case 0x5A: labelTitleA.Text = "Elevate up, isometric units =..."; goto case 0x5B;
                case 0x5B:
                    if (aqc.Opcode == 0x5B) labelTitleA.Text = "Elevate down, isometric units =...";
                    labelEvtC.Text = "amount";
                    evtNumC.Enabled = true;

                    evtNumC.Value = aqc.Option;
                    break;
                case 0x7E: labelTitleA.Text = "Jump, isometric units =..."; goto case 0x7F;
                case 0x7F:
                    if (aqc.Opcode == 0x7F) labelTitleA.Text = "Jump, 1px units =...";
                    labelEvtC.Text = "amount";
                    evtNumC.Maximum = 65535; evtNumC.Enabled = true;

                    evtNumC.Value = BitManager.GetShort(aqc.QueueData, 1);
                    break;

                // Shift 1px units
                case 0x60: labelTitleA.Text = "Shift east, pixels =..."; goto case 0x6B;
                case 0x61: labelTitleA.Text = "Shift southeast, pixels =..."; goto case 0x6B;
                case 0x62: labelTitleA.Text = "Shift south, pixels =..."; goto case 0x6B;
                case 0x63: labelTitleA.Text = "Shift southwest, pixels =..."; goto case 0x6B;
                case 0x64: labelTitleA.Text = "Shift west, pixels =..."; goto case 0x6B;
                case 0x65: labelTitleA.Text = "Shift northwest, pixels =..."; goto case 0x6B;
                case 0x66: labelTitleA.Text = "Shift north, pixels =..."; goto case 0x6B;
                case 0x67: labelTitleA.Text = "Shift northeast, pixels =..."; goto case 0x6B;
                case 0x68: labelTitleA.Text = "Shift in facing direction, pixels =..."; goto case 0x6B;
                case 0x6A: labelTitleA.Text = "Elevate up, pixels =..."; goto case 0x6B;
                case 0x6B:
                    if (aqc.Opcode == 0x6B) labelTitleA.Text = "Elevate down, pixels =...";
                    labelEvtC.Text = "amount";
                    evtNumC.Enabled = true;

                    evtNumC.Value = aqc.Option;
                    break;

                // Face direction
                case 0x7B:
                    labelTitleA.Text = "Turn clockwise 45° times...";
                    labelEvtC.Text = "amount";
                    evtNumC.Enabled = true;

                    evtNumC.Value = aqc.Option;
                    break;

                // Shift to coords
                case 0x80: labelTitleA.Text = "Shift to isometric coords..."; goto case 0x84;
                case 0x81: labelTitleA.Text = "Shift isometric units..."; goto case 0x84;
                case 0x82: labelTitleA.Text = "Transfer to isometric coords..."; goto case 0x84;
                case 0x83: labelTitleA.Text = "Transfer isometric units..."; goto case 0x84;
                case 0x84:
                    if (aqc.Opcode == 0x84) labelTitleA.Text = "Transfer isometric pixels...";
                    labelEvtC.Text = "X";
                    labelEvtD.Text = "Y";
                    evtNumC.Enabled = true;
                    evtNumD.Enabled = true;

                    evtNumC.Value = aqc.Option;
                    evtNumD.Value = aqc.QueueData[2];
                    break;
                case 0x87:
                case 0x95:
                    labelTitleA.Text = "Transfer to other object's isometric coords...";
                    labelEvtA.Text = "object";
                    evtNameA.Items.AddRange(ObjectNames); evtNameA.Enabled = true;

                    evtNameA.SelectedIndex = aqc.Option;
                    break;
                case 0x90: labelTitleA.Text = "Bounce to isometric coords..."; goto case 0x91;
                case 0x91:
                    if (aqc.Opcode == 0x91) labelTitleA.Text = "Bounce isometric units...";
                    labelEvtA.Text = "bounce arch height";
                    labelEvtC.Text = "X";
                    labelEvtD.Text = "Y";
                    evtNumA.Enabled = true;
                    evtNumC.Enabled = true;
                    evtNumD.Enabled = true;

                    evtNumA.Value = aqc.QueueData[3];
                    evtNumC.Value = aqc.Option;
                    evtNumD.Value = aqc.QueueData[2];
                    break;
                case 0x92: labelTitleA.Text = "Transfer to isometric coords..."; goto case 0x94;
                case 0x93: labelTitleA.Text = "Transfer isometric units..."; goto case 0x94;
                case 0x94:
                    labelTitleA.Text = "Transfer isometric pixels...";
                    labelEvtB.Text = "facing / Z";
                    labelEvtC.Text = "X";
                    labelEvtD.Text = "Y";
                    evtNameB.Items.AddRange(Directions); evtNameB.Enabled = true;
                    evtNumB.Maximum = 0x31; evtNumB.Enabled = true;
                    evtNumC.Enabled = true;
                    evtNumD.Enabled = true;

                    evtNameB.SelectedIndex = (aqc.QueueData[3] & 0xE0) >> 5;
                    evtNumB.Value = aqc.QueueData[3] & 0x1F;
                    evtNumC.Value = aqc.Option;
                    evtNumD.Value = aqc.QueueData[2];
                    break;

                // Audio playback
                case 0x9C:
                    labelTitleA.Text = "Playback start, sound...";
                    labelEvtA.Text = "sound";
                    evtNameA.Items.AddRange(SoundNames); evtNameA.Enabled = true;

                    evtNameA.SelectedIndex = aqc.Option;
                    break;
                case 0x9D:
                    labelTitleA.Text = "Playback start (speaker balance), sound...";
                    labelEvtC.Text = "balance";
                    evtNameA.Items.AddRange(SoundNames); evtNameA.Enabled = true;
                    evtNumC.Enabled = true;

                    evtNameA.SelectedIndex = aqc.Option;
                    evtNumC.Value = aqc.QueueData[2];
                    break;
                case 0x9E:
                    labelTitleA.Text = "Playback fade-out sound, duration...";
                    labelEvtC.Text = "duration";
                    labelEvtD.Text = "min volume";
                    evtNumC.Enabled = true;
                    evtNumD.Enabled = true;

                    evtNumC.Value = aqc.Option;
                    evtNumD.Value = aqc.QueueData[2];
                    break;

                // Memory
                case 0xA0:
                case 0xA1:
                case 0xA2:
                case 0xA4:
                case 0xA5:
                case 0xA6:
                    if (aqc.Opcode < 0xA4) labelTitleA.Text = "Set mem...";
                    else labelTitleA.Text = "Clear mem...";

                    labelEvtC.Text = "address";
                    labelEvtD.Text = "bit";
                    evtNumC.Hexadecimal = true;
                    evtNumC.Maximum = 0x709F; evtNumC.Minimum = 0x7040;
                    evtNumC.Enabled = true;
                    evtNumD.Maximum = 7; evtNumD.Enabled = true;

                    if (aqc.Opcode < 0xA4) evtNumC.Value = ((((aqc.Opcode - 0xA0) * 0x100) + aqc.Option) >> 3) + 0x7040;
                    else evtNumC.Value = ((((aqc.Opcode - 0xA4) * 0x100) + aqc.Option) >> 3) + 0x7040;
                    evtNumD.Value = aqc.Option & 7;
                    break;
                case 0xA8:
                case 0xA9:
                    if (aqc.Opcode == 0xA8) labelTitleA.Text = "Store to mem a value (8-bit)...";
                    else labelTitleA.Text = "Add to mem a value (8-bit)...";
                    labelEvtC.Text = "address";
                    labelEvtD.Text = "value";
                    evtNumC.Hexadecimal = true;
                    evtNumC.Maximum = 0x719F; evtNumC.Minimum = 0x70A0;
                    evtNumC.Enabled = true;
                    evtNumD.Enabled = true;

                    evtNumC.Value = aqc.Option + 0x70A0;
                    evtNumD.Value = aqc.QueueData[2];
                    break;
                case 0xAA:
                case 0xAB:
                    if (aqc.Opcode == 0xAA) labelTitleA.Text = "Increment mem (8-bit)...";
                    else labelTitleA.Text = "Decrement mem (8-bit)...";
                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true;
                    evtNumC.Maximum = 0x719F; evtNumC.Minimum = 0x70A0;
                    evtNumC.Enabled = true;

                    evtNumC.Value = aqc.Option + 0x70A0;
                    break;
                case 0xB0:
                case 0xB1:
                case 0xC2:
                    if (aqc.Opcode == 0xB0) labelTitleA.Text = "Store to mem a value (16-bit)...";
                    else if (aqc.Opcode == 0xB1) labelTitleA.Text = "Add to mem a value (16-bit)...";
                    else labelTitleA.Text = "Compare to mem a value (16-bit)...";
                    labelEvtC.Text = "address";
                    labelEvtD.Text = "value";
                    evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                    evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                    evtNumC.Enabled = true;
                    evtNumD.Maximum = 65535; evtNumD.Enabled = true;

                    evtNumC.Value = (aqc.Option * 2) + 0x7000;
                    evtNumD.Value = BitManager.GetShort(aqc.QueueData, 2);
                    break;
                case 0xB2:
                case 0xB3:
                case 0xD6:
                case 0xBB:
                    if (aqc.Opcode == 0xB2) labelTitleA.Text = "Increment mem (16-bit)...";
                    else if (aqc.Opcode == 0xB3) labelTitleA.Text = "Decrement mem (16-bit)...";
                    else if (aqc.Opcode == 0xB6) labelTitleA.Text = "Store to object mem from mem...";
                    else labelTitleA.Text = "Store to mem from mem 00:700C (16-bit)...";
                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                    evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                    evtNumC.Enabled = true;

                    evtNumC.Value = (aqc.Option * 2) + 0x7000;
                    break;
                case 0xB5:
                    labelTitleA.Text = "Store to mem from mem 00:700C (8-bit)...";
                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true;
                    evtNumC.Maximum = 0x719F; evtNumC.Minimum = 0x70A0;
                    evtNumC.Enabled = true;

                    evtNumC.Value = aqc.Option + 0x70A0;
                    break;
                case 0xB7:
                    labelTitleA.Text = "Store random # less than... to mem...";
                    labelEvtC.Text = "address";
                    labelEvtD.Text = "number <";
                    evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                    evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                    evtNumC.Enabled = true;
                    evtNumD.Maximum = 65535; evtNumD.Enabled = true;

                    evtNumC.Value = (aqc.Option * 2) + 0x7000;
                    evtNumD.Value = BitManager.GetShort(aqc.QueueData, 2);
                    break;
                case 0xBC:
                case 0xBD:
                    if (aqc.Opcode == 0xBC) labelTitleA.Text = "Store to mem A from mem B (choose both, 16-bit)...";
                    else labelTitleA.Text = "Exchange mem A and mem B (16-bit)...";
                    labelEvtC.Text = "address A";
                    labelEvtD.Text = "address B";
                    evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                    evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                    evtNumC.Enabled = true;
                    evtNumD.Hexadecimal = true; evtNumD.Increment = 2;
                    evtNumD.Maximum = 0x71FE; evtNumD.Minimum = 0x7000;
                    evtNumD.Enabled = true;

                    evtNumC.Value = (aqc.Option * 2) + 0x7000;
                    evtNumD.Value = (aqc.QueueData[2] * 2) + 0x7000;
                    break;
                case 0xD8:
                case 0xD9:
                case 0xDA:
                case 0xDC:
                case 0xDD:
                case 0xDE:
                    if (aqc.Opcode < 0xDC) labelTitleA.Text = "If set, mem...";
                    else labelTitleA.Text = "If clear, mem...";

                    labelEvtC.Text = "address";
                    labelEvtD.Text = "bit";
                    labelEvtE.Text = "then jump to...";
                    evtNumC.Hexadecimal = true;
                    evtNumC.Maximum = 0x709F; evtNumC.Minimum = 0x7040;
                    evtNumC.Enabled = true;
                    evtNumD.Maximum = 7; evtNumD.Enabled = true;
                    evtNumE.Hexadecimal = true; evtNumE.Maximum = 0xFFFF; evtNumE.Enabled = true;

                    if (aqc.Opcode < 0xDC) evtNumC.Value = ((((aqc.Opcode - 0xD8) * 0x100) + aqc.Option) >> 3) + 0x7040;
                    else evtNumC.Value = ((((aqc.Opcode - 0xDC) * 0x100) + aqc.Option) >> 3) + 0x7040;
                    evtNumD.Value = aqc.Option & 7;
                    evtNumE.Value = BitManager.GetShort(aqc.QueueData, 2);
                    break;
                case 0xE0:
                case 0xE1:
                    if (aqc.Opcode == 0xE0) labelTitleA.Text = "If mem = (8-bit)...";
                    else labelTitleA.Text = "If mem != (8-bit)...";
                    labelEvtC.Text = "address";
                    labelEvtD.Text = "value";
                    labelEvtE.Text = "then jump to...";
                    evtNumC.Hexadecimal = true;
                    evtNumC.Maximum = 0x719F; evtNumC.Minimum = 0x70A0;
                    evtNumC.Enabled = true;
                    evtNumD.Enabled = true;
                    evtNumE.Hexadecimal = true; evtNumE.Maximum = 0xFFFF; evtNumE.Enabled = true;

                    evtNumC.Value = aqc.Option + 0x70A0;
                    evtNumD.Value = aqc.QueueData[2];
                    evtNumE.Value = BitManager.GetShort(aqc.QueueData, 3);
                    break;
                case 0xE4:
                case 0xE5:
                    if (aqc.Opcode == 0xE4) labelTitleA.Text = "If mem = (16-bit)...";
                    else labelTitleA.Text = "If mem != (16-bit)...";
                    labelEvtC.Text = "address";
                    labelEvtD.Text = "value";
                    labelEvtE.Text = "then jump to...";
                    evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                    evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                    evtNumC.Enabled = true;
                    evtNumD.Maximum = 65535; evtNumD.Enabled = true;
                    evtNumE.Hexadecimal = true; evtNumE.Maximum = 0xFFFF; evtNumE.Enabled = true;

                    evtNumC.Value = (aqc.Option * 2) + 0x7000;
                    evtNumD.Value = BitManager.GetShort(aqc.QueueData, 2);
                    evtNumE.Value = BitManager.GetShort(aqc.QueueData, 4);
                    break;
                case 0xE8:
                    labelTitleA.Text = "If random # > 128, jump to...";
                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true; evtNumC.Maximum = 0xFFFF; evtNumC.Enabled = true;

                    evtNumC.Value = BitManager.GetShort(aqc.QueueData, 1);
                    break;
                case 0xE9:
                    labelTitleA.Text = "If random # > 66, jump to address A, else address B...";
                    labelEvtC.Text = "address A";
                    labelEvtD.Text = "address B";
                    evtNumC.Hexadecimal = true; evtNumC.Maximum = 0xFFFF; evtNumC.Enabled = true;
                    evtNumD.Hexadecimal = true; evtNumD.Maximum = 0xFFFF; evtNumD.Enabled = true;

                    evtNumC.Value = BitManager.GetShort(aqc.QueueData, 1);
                    evtNumD.Value = BitManager.GetShort(aqc.QueueData, 3);
                    break;

                // Memory 00:700C
                case 0xAC: labelTitleA.Text = "Mem 00:700C =..."; goto case 0xC0;
                case 0xAD: labelTitleA.Text = "Mem 00:700C +=..."; goto case 0xC0;
                case 0xB6: labelTitleA.Text = "Mem 00:700C = random # less than..."; goto case 0xC0;
                case 0xC0:
                    if (aqc.Opcode == 0xC0) labelTitleA.Text = "Mem 00:700C compare to...";
                    labelEvtC.Text = "value";
                    evtNumC.Maximum = 65535; evtNumC.Enabled = true;

                    evtNumC.Value = BitManager.GetShort(aqc.QueueData, 1);
                    break;
                case 0xB4:
                    labelTitleA.Text = "Mem 00:700C = mem...";
                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true;
                    evtNumC.Maximum = 0x719F; evtNumC.Minimum = 0x70A0;
                    evtNumC.Enabled = true;

                    evtNumC.Value = aqc.Option + 0x70A0;
                    break;
                case 0xB8: labelTitleA.Text = "Mem 00:700C += mem..."; goto case 0xC1;
                case 0xB9: labelTitleA.Text = "Mem 00:700C -= mem..."; goto case 0xC1;
                case 0xBA: labelTitleA.Text = "Mem 00:700C = mem..."; goto case 0xC1;
                case 0xC1:
                    if (aqc.Opcode == 0xC1) labelTitleA.Text = "Mem 00:700C compare to mem...";
                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                    evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                    evtNumC.Enabled = true;

                    evtNumC.Value = (aqc.Option * 2) + 0x7000;
                    break;
                case 0xC6:
                    labelTitleA.Text = "Mem 00:700C = object Z coord...";
                    labelEvtA.Text = "object";
                    evtNameA.Items.AddRange(ObjectNames); evtNameA.Enabled = true;

                    evtNameA.SelectedIndex = aqc.Option;
                    break;
                case 0xDB: labelTitleA.Text = "If mem 00:700C bit(s) set, jump to..."; goto case 0xDF;
                case 0xDF:
                    if (aqc.Opcode == 0xDF) labelTitleA.Text = "If mem 00:700C bit(s) clear, jump to...";
                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true; evtNumC.Maximum = 0xFFFF; evtNumC.Enabled = true;

                    evtNumC.Value = BitManager.GetShort(aqc.QueueData, 1);
                    break;
                case 0xE2: labelTitleA.Text = "If mem 00:700C = value..."; labelEvtC.Text = "value"; goto case 0xE7;
                case 0xE3: labelTitleA.Text = "If mem 00:700C != value..."; labelEvtC.Text = "value"; goto case 0xE7;
                case 0xE6: labelTitleA.Text = "If mem 00:700C set, no bits..."; goto case 0xE7;
                case 0xE7:
                    if (aqc.Opcode == 0xE7) labelTitleA.Text = "If mem 00:700C set, any bits...";
                    if (aqc.Opcode > 0xE3) labelEvtC.Text = "bits";
                    labelEvtD.Text = "jump to";
                    evtNumC.Maximum = 65535; evtNumC.Enabled = true;
                    evtNumD.Hexadecimal = true; evtNumD.Maximum = 0xFFFF; evtNumD.Enabled = true;

                    evtNumC.Value = BitManager.GetShort(aqc.QueueData, 1);
                    evtNumD.Value = BitManager.GetShort(aqc.QueueData, 3);
                    break;
                case 0xEA: labelTitleA.Text = "If equal to zero, jump to..."; goto case 0xEF;
                case 0xEB: labelTitleA.Text = "If not equal to zero, jump to..."; goto case 0xEF;
                case 0xEC: labelTitleA.Text = "If greater than / equal to, jump to..."; goto case 0xEF;
                case 0xED: labelTitleA.Text = "If less than, jump to..."; goto case 0xEF;
                case 0xEE: labelTitleA.Text = "If negative, jump to..."; goto case 0xEF;
                case 0xEF:
                    if (aqc.Opcode == 0xEF) labelTitleA.Text = "If positive, jump to...";
                    labelEvtC.Text = "jump to";
                    evtNumC.Hexadecimal = true; evtNumC.Maximum = 0xFFFF; evtNumC.Enabled = true;

                    evtNumC.Value = BitManager.GetShort(aqc.QueueData, 1);
                    break;

                // Jump to
                case 0xD2:
                case 0xD3:
                    if (aqc.Opcode == 0xD2) labelTitleA.Text = "Jump to address...";
                    else labelTitleA.Text = "Jump to subroutine...";

                    labelEvtC.Text = "address";
                    evtNumC.Hexadecimal = true; evtNumC.Maximum = 0xFFFF; evtNumC.Enabled = true;

                    evtNumC.Value = BitManager.GetShort(aqc.QueueData, 1);
                    break;
                case 0xD4:
                    labelTitleA.Text = "Loop start, loop count...";
                    labelEvtC.Text = "count";
                    evtNumC.Enabled = true;

                    evtNumC.Value = aqc.Option;
                    break;

                // Object memory
                case 0xF2:         // Set object presence...  
                case 0xF3:         // Set object engage type...
                case 0xF8:         // If object in level ..., presence =...
                    if (aqc.Opcode == 0xF2)
                    {
                        labelTitleA.Text = "Set presence in...";
                        labelTitleB.Text = "presence is...";
                    }
                    else if (aqc.Opcode == 0xF3)
                    {
                        labelTitleA.Text = "Set engage type in...";
                        labelTitleB.Text = "event engage type is...";
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
                    evtNumA.Enabled = true; evtNumA.Maximum = 511; evtNumA.Hexadecimal = true;
                    evtEffects.Items.AddRange(new object[] { "true" }); evtEffects.Enabled = true;
                    if (aqc.Opcode == 0xF8)
                        evtNumE.Enabled = true; evtNumE.Hexadecimal = true; evtNumE.Maximum = 0xFFFF;

                    evtNumA.Value = BitManager.GetShort(aqc.QueueData, 1) & 0x1FF;
                    evtNameA.SelectedIndex = (int)evtNumA.Value;
                    evtNameB.SelectedIndex = (aqc.QueueData[2] >> 1) & 0x3F;
                    evtEffects.SetItemChecked(0, (aqc.QueueData[2] & 0x80) == 0x80);
                    if (aqc.Opcode == 0xF8)
                        evtNumE.Value = BitManager.GetShort(aqc.QueueData, 3);
                    /* 
                     * TODO
                     * synchronize evtNameA with evtNumA
                     */
                    break;

                // Pause script
                case 0xF0:
                    labelTitleA.Text = "Pause script, frame duration (8-bit)...";
                    labelEvtC.Text = "frames";
                    evtNumC.Enabled = true;

                    evtNumC.Value = aqc.Option;
                    break;
                case 0xF1:
                    labelTitleA.Text = "Pause script, frame duration (16-bit)...";
                    labelEvtC.Text = "frames";
                    evtNumC.Maximum = 65535; evtNumC.Enabled = true;

                    evtNumC.Value = BitManager.GetShort(aqc.QueueData, 1);
                    break;

                case 0xFD:
                    switch (aqc.Option)
                    {
                        case 0x0F:
                            labelTitleA.Text = "Layer priority =...";
                            labelEvtC.Text = "priority";
                            evtNumC.Maximum = 3; evtNumC.Enabled = true;

                            evtNumC.Value = aqc.QueueData[2];
                            break;

                        // Memory
                        case 0xB6:
                            labelTitleA.Text = "Halve mem...";
                            labelEvtC.Text = "address";
                            labelEvtD.Text = "halves";
                            evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                            evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                            evtNumC.Enabled = true;
                            evtNumD.Maximum = 256; evtNumD.Minimum = 1; evtNumD.Enabled = true;

                            evtNumC.Value = (aqc.QueueData[2] * 2) + 0x7000;
                            evtNumD.Value = (aqc.QueueData[3] ^ 0xFF) + 1;
                            break;

                        // Memory 00:700C
                        case 0xB0: labelTitleA.Text = "Mem 00:700C isolate bits =..."; goto case 0xB2;
                        case 0xB1: labelTitleA.Text = "Mem 00:700C set bits =..."; goto case 0xB2;
                        case 0xB2:
                            if (aqc.Option == 0xB2) labelTitleA.Text = "Mem 00:700C xor bits =...";
                            labelEvtC.Text = "bits";
                            evtNumC.Maximum = 65535; evtNumC.Enabled = true;

                            evtNumC.Value = BitManager.GetShort(aqc.QueueData, 2);
                            break;
                        case 0xB3: labelTitleA.Text = "Mem 00:700C isolate bits = mem..."; goto case 0xB5;
                        case 0xB4: labelTitleA.Text = "Mem 00:700C set bits = mem..."; goto case 0xB5;
                        case 0xB5:
                            if (aqc.Option == 0xB5) labelTitleA.Text = "Mem 00:700C xor bits = mem...";
                            labelEvtC.Text = "address";
                            evtNumC.Hexadecimal = true; evtNumC.Increment = 2;
                            evtNumC.Maximum = 0x71FE; evtNumC.Minimum = 0x7000;
                            evtNumC.Enabled = true;

                            evtNumC.Value = (aqc.QueueData[2] * 2) + 0x7000;
                            break;
                    }
                    break;
            }

            updatingControls = true;
        }
        private void ControlActionAsmMethod()
        {
            switch (aqc.Opcode)
            {
                // Properties
                case 0x0A:
                    aqc.Option = (byte)evtNumC.Value;
                    break;
                case 0x0B:
                case 0x15:
                case 0x0C:
                    for (int i = 0; i < 8; i++)
                        BitManager.SetBit(aqc.QueueData, 1, i, evtEffects.GetItemChecked(i));
                    break;
                case 0x13:
                    aqc.Option = (byte)evtNumC.Value;
                    break;
                case 0x3D:
                    BitManager.SetShort(aqc.QueueData, 1, (ushort)evtNumC.Value);
                    break;

                // Palette
                case 0x0D:
                case 0x0E:
                    aqc.Option = (byte)evtNumC.Value;
                    break;

                // Sprite Sequence
                case 0x08:
                    aqc.Option = (byte)evtNumC.Value;
                    aqc.QueueData[2] = (byte)evtNumD.Value;
                    BitManager.SetBit(aqc.QueueData, 1, 3, evtEffects.GetItemChecked(0));
                    BitManager.SetBit(aqc.QueueData, 1, 4, evtEffects.GetItemChecked(1));
                    BitManager.SetBit(aqc.QueueData, 1, 6, evtEffects.GetItemChecked(2));
                    BitManager.SetBit(aqc.QueueData, 2, 7, evtEffects.GetItemChecked(3));

                    /*
                     * TODO
                     * set labelEvtD.text based on bit 3 of byte 2
                     * if set, make "frame", else "sequence"
                     */
                    break;
                case 0x10:
                    aqc.Option = (byte)evtNameA.SelectedIndex;
                    BitManager.SetBit(aqc.QueueData, 1, 6, evtEffects.GetItemChecked(0));
                    BitManager.SetBit(aqc.QueueData, 1, 7, evtEffects.GetItemChecked(1));
                    break;
                case 0xD0:
                    BitManager.SetShort(aqc.QueueData, 1, (ushort)evtNumC.Value);
                    break;

                // Sprite Animation


                // Shift isometric units
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
                    aqc.Option = (byte)evtNumC.Value;
                    break;
                case 0x7E:
                case 0x7F:
                    BitManager.SetShort(aqc.QueueData, 1, (ushort)evtNumC.Value);
                    break;

                // Shift 1px units
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
                    aqc.Option = (byte)evtNumC.Value;
                    break;

                // Face direction
                case 0x7B:
                    aqc.Option = (byte)evtNumC.Value;
                    break;

                // Shift to coords
                case 0x80:
                case 0x81:
                case 0x82:
                case 0x83:
                case 0x84:
                    aqc.Option = (byte)evtNumC.Value;
                    aqc.QueueData[2] = (byte)evtNumD.Value;
                    break;
                case 0x87:
                case 0x95:
                    aqc.Option = (byte)evtNameA.SelectedIndex;
                    break;
                case 0x90:
                case 0x91:
                    aqc.QueueData[3] = (byte)evtNumA.Value;
                    aqc.Option = (byte)evtNumC.Value;
                    aqc.QueueData[2] = (byte)evtNumD.Value;
                    break;
                case 0x92:
                case 0x93:
                case 0x94:
                    aqc.QueueData[3] = (byte)(evtNameB.SelectedIndex << 5);
                    aqc.QueueData[3] &= 0xE0; aqc.QueueData[3] |= (byte)evtNumB.Value;
                    aqc.Option = (byte)evtNumC.Value;
                    aqc.QueueData[2] = (byte)evtNumD.Value;
                    break;

                // Audio playback
                case 0x9C:
                    aqc.Option = (byte)evtNameA.SelectedIndex;
                    break;
                case 0x9D:
                    aqc.Option = (byte)evtNameA.SelectedIndex;
                    aqc.QueueData[2] = (byte)evtNumC.Value;
                    break;
                case 0x9E:
                    aqc.Option = (byte)evtNumC.Value;
                    aqc.QueueData[2] = (byte)evtNumD.Value;
                    break;

                // Memory
                case 0xA0:
                case 0xA1:
                case 0xA2:
                    aqc.Opcode = (byte)(((((byte)(evtNumC.Value - 0x7040) << 3) & 0x0F00) >> 8) + 0xA0);
                    aqc.Option = (byte)(((byte)(evtNumC.Value - 0x7040) << 3) & 0xF8);
                    aqc.Option &= 0xF8; aqc.Option |= (byte)evtNumD.Value;
                    break;
                case 0xA4:
                case 0xA5:
                case 0xA6:
                    aqc.Opcode = (byte)(((((byte)(evtNumC.Value - 0x7040) << 3) & 0x0F00) >> 8) + 0xA4);
                    aqc.Option = (byte)(((byte)(evtNumC.Value - 0x7040) << 3) & 0xF8);
                    aqc.Option &= 0xF8; aqc.Option |= (byte)evtNumD.Value;
                    break;
                case 0xA8:
                case 0xA9:
                    aqc.Option = (byte)(evtNumC.Value - 0x70A0);
                    aqc.QueueData[2] = (byte)evtNumD.Value;
                    break;
                case 0xAA:
                case 0xAB:
                    aqc.Option = (byte)(evtNumC.Value - 0x70A0);
                    break;
                case 0xB0:
                case 0xB1:
                case 0xC2:
                    aqc.Option = (byte)((evtNumC.Value - 0x7000) / 2);
                    BitManager.SetShort(aqc.QueueData, 2, (ushort)evtNumD.Value);
                    break;
                case 0xB2:
                case 0xB3:
                case 0xD6:
                case 0xBB:
                    aqc.Option = (byte)((evtNumC.Value - 0x7000) / 2);
                    break;
                case 0xB5:
                    aqc.Option = (byte)(evtNumC.Value - 0x70A0);
                    break;
                case 0xB7:
                    aqc.Option = (byte)((evtNumC.Value - 0x7000) / 2);
                    BitManager.SetShort(aqc.QueueData, 2, (ushort)evtNumD.Value);
                    break;
                case 0xBC:
                case 0xBD:
                    aqc.Option = (byte)((evtNumC.Value - 0x7000) / 2);
                    aqc.QueueData[2] = (byte)((evtNumD.Value - 0x7000) / 2);
                    break;
                case 0xD8:
                case 0xD9:
                case 0xDA:
                    aqc.Opcode = (byte)(((((byte)(evtNumC.Value - 0x7040) << 3) & 0x0F00) >> 8) + 0xD8);
                    aqc.Option = (byte)(((byte)(evtNumC.Value - 0x7040) << 3) & 0xF8);
                    aqc.Option &= 0xF8; aqc.Option |= (byte)evtNumD.Value;
                    BitManager.SetShort(aqc.QueueData, 2, (ushort)evtNumE.Value);
                    break;
                case 0xDC:
                case 0xDD:
                case 0xDE:
                    aqc.Opcode = (byte)(((((byte)(evtNumC.Value - 0x7040) << 3) & 0x0F00) >> 8) + 0xDC);
                    aqc.Option = (byte)(((byte)(evtNumC.Value - 0x7040) << 3) & 0xF8);
                    aqc.Option &= 0xF8; aqc.Option |= (byte)evtNumD.Value;
                    BitManager.SetShort(aqc.QueueData, 2, (ushort)evtNumE.Value);
                    break;
                case 0xE0:
                case 0xE1:
                    aqc.Option = (byte)(evtNumC.Value - 0x70A0);
                    aqc.QueueData[2] = (byte)evtNumD.Value;
                    BitManager.SetShort(aqc.QueueData, 3, (ushort)evtNumE.Value);
                    break;
                case 0xE4:
                case 0xE5:
                    aqc.Option = (byte)((evtNumC.Value - 0x7000) / 2);
                    BitManager.SetShort(aqc.QueueData, 2, (ushort)evtNumD.Value);
                    BitManager.SetShort(aqc.QueueData, 4, (ushort)evtNumE.Value);
                    break;
                case 0xE8:
                    BitManager.SetShort(aqc.QueueData, 1, (ushort)evtNumC.Value);
                    break;
                case 0xE9:
                    BitManager.SetShort(aqc.QueueData, 1, (ushort)evtNumC.Value);
                    BitManager.SetShort(aqc.QueueData, 3, (ushort)evtNumD.Value);
                    break;

                // Memory 00:700C
                case 0xAC:
                case 0xAD:
                case 0xB6:
                case 0xC0:
                    BitManager.SetShort(aqc.QueueData, 1, (ushort)evtNumC.Value);
                    break;
                case 0xB4:
                    aqc.Option = (byte)(evtNumC.Value - 0x70A0);
                    break;
                case 0xB8:
                case 0xB9:
                case 0xBA:
                case 0xC1:
                    aqc.Option = (byte)((evtNumC.Value - 0x7000) / 2);
                    break;
                case 0xC6:
                    aqc.Option = (byte)evtNameA.SelectedIndex;
                    break;
                case 0xDB:
                case 0xDF:
                    BitManager.SetShort(aqc.QueueData, 1, (ushort)evtNumC.Value);
                    break;
                case 0xE2:
                case 0xE3:
                case 0xE6:
                case 0xE7:
                    BitManager.SetShort(aqc.QueueData, 1, (ushort)evtNumC.Value);
                    BitManager.SetShort(aqc.QueueData, 3, (ushort)evtNumD.Value);
                    break;
                case 0xEA:
                case 0xEB:
                case 0xEC:
                case 0xED:
                case 0xEE:
                case 0xEF:
                    BitManager.SetShort(aqc.QueueData, 1, (ushort)evtNumC.Value);
                    break;

                // Jump to
                case 0xD2:
                case 0xD3:
                    BitManager.SetShort(aqc.QueueData, 1, (ushort)evtNumC.Value);
                    break;
                case 0xD4:
                    aqc.Option = (byte)evtNumC.Value;
                    break;

                // Object memory
                case 0xF2:         // Set object presence...  
                case 0xF3:         // Set object engage type...
                case 0xF8:         // If object in level ..., presence =...
                    BitManager.SetShort(aqc.QueueData, 1, (ushort)evtNumA.Value);
                    aqc.QueueData[2] &= 1; aqc.QueueData[2] |= (byte)(evtNameB.SelectedIndex << 1);
                    BitManager.SetBit(aqc.QueueData, 2, 7, evtEffects.GetItemChecked(0));    // set bit 7 if true
                    if (aqc.Opcode == 0xF8)
                        BitManager.SetShort(aqc.QueueData, 3, (ushort)evtNumE.Value);
                    /* 
                     * TODO
                     * synchronize evtNameA with evtNumA
                     */
                    break;

                // Pause script
                case 0xF0:
                    aqc.Option = (byte)evtNumC.Value;
                    break;
                case 0xF1:
                    BitManager.SetShort(aqc.QueueData, 1, (ushort)evtNumC.Value);
                    break;

                case 0xFD:
                    switch (aqc.Option)
                    {
                        case 0x0F:
                            aqc.QueueData[2] = (byte)evtNumC.Value;
                            break;

                        // Memory
                        case 0xB6:
                            aqc.QueueData[2] = (byte)((evtNumC.Value - 0x7000) / 2);
                            aqc.QueueData[3] = (byte)((byte)(evtNumD.Value - 1) ^ 0xFF);
                            break;

                        // Memory 00:700C
                        case 0xB0:
                        case 0xB1:
                        case 0xB2:
                            BitManager.SetShort(aqc.QueueData, 2, (ushort)evtNumC.Value);
                            break;
                        case 0xB3:
                        case 0xB4:
                        case 0xB5:
                            aqc.QueueData[2] = (byte)((evtNumC.Value - 0x7000) / 2);
                            break;
                    }
                    break;
            }
        }

        private void UpdateActionOffsets()
        {
            int delta = treeViewWrapper.ScriptDelta;
            int actionNum = treeViewWrapper.Action.ActionQueueNum;
            int end, start;
            int conditionOffset = 0;

            if (actionNum >= 0 && actionNum <= 1023)
            {
                start = 0;
                end = 1023; // Bank 1E

                if (actionNum < end)
                    conditionOffset = actionScripts[actionNum + 1].Offset;
                else
                    conditionOffset = actionScripts[actionNum].Offset + actionScripts[actionNum].ActionQueueLength; // Dont need to update anything after this event if its the last one                    
            }
            else
                throw new Exception("Invalid action num");

            if (!state.AutoPointerUpdate)
                conditionOffset = 0x7FFFFFFF;

            if (state.AutoPointerUpdate)
            {
                // Update all pointers before eventOffset
                for (int i = start; i < actionNum; i++)
                    actionScripts[i].UpdateAllOffsets(delta, conditionOffset);
            }

            // Update all events and pointers after edited event
            for (int i = actionNum + 1; i <= end; i++)
                actionScripts[i].UpdateAllOffsets(delta, conditionOffset);

            if (state.AutoPointerUpdate)
            {
                // Update all pointers to edited event
                UpdateCurrentActionReferencePointers();
            }
            treeViewWrapper.ScriptDelta = 0;
        }
        private void UpdateCurrentActionReferencePointers()
        {

            ActionQueue aq = treeViewWrapper.Action;

            foreach (ActionQueueCommand aqc in aq.ActionQueueCommands)
            {
                if (aqc.CommandDelta != 0)
                    UpdatePointersToAction(aqc);
            }
        }
        private void UpdatePointersToAction(ActionQueueCommand aqcRef)
        {
            ushort pointer;
            foreach (ActionQueue aq in actionScripts)
            {
                if (aq.ActionQueueNum != treeViewWrapper.Action.ActionQueueNum)
                {
                    foreach (ActionQueueCommand aqcIterator in aq.ActionQueueCommands)
                    {
                        if (aqcIterator.Opcode == 0xE9)
                        {
                            pointer = aqcIterator.ReadPointerSpecial(0);
                            if (pointer == (aqcRef.OriginalOffset & 0xFFFF))
                                aqcIterator.WritePointerSpecial(0, (ushort)(pointer + aqcRef.CommandDelta));
                            pointer = aqcIterator.ReadPointerSpecial(1);
                            if (pointer == (aqcRef.OriginalOffset & 0xFFFF))
                                aqcIterator.WritePointerSpecial(1, (ushort)(pointer + aqcRef.CommandDelta));
                        }
                        else
                        {
                            pointer = aqcIterator.ReadPointer();
                            if (pointer == (aqcRef.OriginalOffset & 0xFFFF))
                                aqcIterator.WritePointer((ushort)(pointer + aqcRef.CommandDelta));
                        }
                    }
                }
            }
        }

        private void UpdateActionScriptsFreeSpace()
        {
            this.EvtScrLabel9.Text = "AVAILABLE BYTES: " + CalculateActionScriptsLength().ToString();
        }
        private int CalculateActionScriptsLength()
        {
            int totalSize = 0xC000 - 0x800;
            int length = 0;

            for (int i = 0; i < actionScripts.Length; i++)
                length += actionScripts[i].ActionQueueData.Length;

            return totalSize - length - 1;
        }

        private void ExportActionScript(int start, int count, string path)
        {
            this.scriptsModel.AssembleAllActionScripts();

            path += "\\" + model.GetFileNameWithoutPath() + " - Action Scripts\\";

            // Create Level Data directory
            if (!CreateDir(path))
                return;

            Stream s;
            BinaryFormatter b = new BinaryFormatter();
            s = File.Create(path + "Do Not Modify This Directory Or Files Contained Within.txt");
            s.Close();

            try
            {
                for (int i = start; i < start + count; i++)
                {
                    // Create the file to store the level data
                    s = File.Create(path + "actionScript." + i.ToString("X3") + ".dat"); // Create data file

                    actionScripts[i].Data = null;

                    // Serialize object
                    b.Serialize(s, actionScripts[i]);
                    s.Close();

                    actionScripts[i].Data = model.Data;
                }
            }
            catch
            {
                MessageBox.Show("There was a problem exporting");
            }


        }
        private void ImportActionScript(int start, int count, string path)
        {
            Stream s;
            BinaryFormatter b = new BinaryFormatter();
            int baseOffset, len;
            EventActionCommand eac;

            if (count == 1)
            {
                try
                {
                    s = File.OpenRead(path);

                    baseOffset = actionScripts[start].Offset;
                    len = actionScripts[start].ActionQueueLength;

                    actionScripts[start] = (ActionQueue)b.Deserialize(s);
                    s.Close();

                    this.treeViewWrapper.ScriptDelta = actionScripts[start].ActionQueueLength - len;
                    actionScripts[start].Data = model.Data;

                    ScriptIterator it = new ScriptIterator(actionScripts[start]);
                    while (!it.IsDone)
                    {
                        eac = it.Next();
                        eac.Offset = (eac.Offset - actionScripts[start].Offset) + baseOffset;
                        eac.OriginalOffset = eac.Offset;
                    }

                    actionScripts[start].Offset = baseOffset;

                    EventNumber_ValueChanged(null, null);
                }
                catch
                {
                    MessageBox.Show("There was a problem loading Event Script data.");
                    return;
                }
            }
            else
            {
                try
                {
                    for (int i = start; i < start + count; i++)
                    {
                        s = File.OpenRead(path + "actionScript." + i.ToString("X3") + ".dat");
                        actionScripts[i] = (ActionQueue)b.Deserialize(s);
                        s.Close();
                        actionScripts[i].Data = model.Data;
                    }
                    this.treeViewWrapper.ScriptDelta = 0;

                    EventNumber_ValueChanged(null, null);
                }
                catch
                {
                    MessageBox.Show("There was a problem loading Event Script data. Verify that the " +
                    "Event Script data files are correctly named and present.");
                }
            }

        }


    }
}
