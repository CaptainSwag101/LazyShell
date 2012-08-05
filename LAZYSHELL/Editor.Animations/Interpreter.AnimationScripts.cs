using System;
using System.Collections.Generic;
using System.Text;
using LAZYSHELL.Properties;

namespace LAZYSHELL.ScriptsEditor.Commands
{
    public partial class Interpreter
    {
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
            "Enable ",			// 0x1A
            "Disable ",			// 0x1B
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
            "Timed attack timer begins",			// 0x3A
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
            "Run synchronous queue @ $",			// 0x64
            "",			// 0x65
            "",			// 0x66
            "",			// 0x67
            "Run synchronous queue @ $",			// 0x68
            "OMEM $60 = mem $072C",			// 0x69
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
            "Shake object: ",			// 0x86
            "Stop shaking object",			// 0x87
            "",			// 0x88
            "",			// 0x89
            "",			// 0x8A
            "",			// 0x8B
            "",			// 0x8C
            "",			// 0x8D
            "Screen flash color: ",			// 0x8E
            "Screen flash color: ",			// 0x8F
			
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
            "Screen effect: ",			// 0xA3
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
        private static string[] ScreenEffects = new string[]
        {
            "Geno Flash",
            "Snowy",
            "Terrorize",
            "Shocker",
            "{unknown}",
            "slash (instant death)",
            "screen flashes white",
            "change battlefield",
            "Come Back",
            "Geno Beam",
            "Geno Blast",
            "Howl",
            "win battle window",
            "set battlefield coords",
            "squash big star",
            "{unknown}",
            "{unknown}",
            "Corona",
            "Mega-Drain",
            "{unknown}",
            "{unknown}"
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
                    sb.Append("X=" + (short)Bits.GetShort(asc.AnimationData, 2) + ",");
                    sb.Append("Y=" + (short)Bits.GetShort(asc.AnimationData, 4) + ",");
                    sb.Append("Z=" + (short)Bits.GetShort(asc.AnimationData, 6) + ", offset @ ");
                    switch ((asc.AnimationData[1] & 0xF0) >> 4)
                    {
                        case 0: sb.Append("absolute coords"); break;
                        case 1: sb.Append("caster's initial coords"); break;
                        case 2: sb.Append("target's current coords"); break;
                        case 3: sb.Append("caster's current coords"); break;
                    }
                    break;
                case 0x08:
                    sb.Append("acceleration = " + Bits.GetShort(asc.AnimationData, 6) + ", ");
                    sb.Append("start val = " + Bits.GetShort(asc.AnimationData, 2) + ", ");
                    sb.Append("end val = " + Bits.GetShort(asc.AnimationData, 4) + ", ");
                    sb.Append("apply to axis: ");
                    sb.Append(GetBits((byte)(asc.Option & 0x07), new string[] { "Z", "Y", "X" }, 3));
                    break;
                case 0x0C:
                    switch (asc.Option)
                    {
                        case 0x02: sb.Append("shift, "); break;
                        case 0x04: sb.Append("transfer, "); break;
                    }
                    sb.Append("speed=" + Bits.GetShort(asc.AnimationData, 2) + ", ");
                    sb.Append("archHeight=" + Bits.GetShort(asc.AnimationData, 4));
                    break;
                case 0x00:
                case 0x03:
                    ushort temp = (ushort)(Bits.GetShort(asc.AnimationData, 3) & 0x3FF);
                    sb.Append(Lists.Numerize(Lists.SpriteNames, temp) + "\"");
                    sb.Append(", playback seq = " + (asc.AnimationData[5] & 15).ToString());
                    sb.Append(", coords = AMEM $32");
                    break;
                case 0x04:
                    switch (asc.Option)
                    {
                        case 0x06: sb.Append("sprite shift is complete");
                            break;
                        case 0x10: sb.Append(Bits.GetShort(asc.AnimationData, 2) + " frames");
                            break;
                    }
                    break;
                case 0x09:
                case 0x10:
                case 0x51:
                    sb.Append(((asc.InternalOffset & 0xFF0000) >> 16).ToString("X2"));
                    sb.Append(Bits.GetShort(asc.AnimationData, 1).ToString("X4"));
                    break;
                case 0x1A:
                case 0x1B:
                    if (asc.Option == 0)
                        sb.Append("{nothing}");
                    else if (asc.Option == 1)
                        sb.Append("sprite visibility");
                    else
                        sb.Append("{unknown}");
                    break;
                case 0x20:
                case 0x21:
                    sb.Append(((asc.Option & 0x0F) + 0x60).ToString("X2") + " = ");
                    switch ((asc.Option & 0xF0) >> 4)
                    {
                        case 0: sb.Append("");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString()); break;
                        case 1: sb.Append("mem $7E:");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 2: sb.Append("mem $7F:");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 3: sb.Append("AMEM $");
                            sb.Append((asc.AnimationData[2] + 0x60).ToString("X2")); break;
                        case 5: sb.Append("mem $7E:");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
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
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 2: sb.Append("Mem $7F:");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 3: sb.Append("AMEM $");
                            sb.Append((asc.AnimationData[2] + 0x60).ToString("X2")); break;
                        case 5: sb.Append("Mem $7E:");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
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
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString()); break;
                        case 1: sb.Append("mem $7E:");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 2: sb.Append("mem $7F:");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 3: sb.Append("AMEM $");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 5: sb.Append("mem $7E:");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 6: sb.Append("OMEM $");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                    }
                    sb.Append(", jump to $" + ((asc.InternalOffset & 0xFF0000) >> 16).ToString("X2"));
                    sb.Append(Bits.GetShort(asc.AnimationData, 4).ToString("X4"));
                    break;
                case 0x26:
                case 0x27:
                    sb.Append(((asc.Option & 0x0F) + 0x60).ToString("X2") + " != ");
                    switch ((asc.Option & 0xF0) >> 4)
                    {
                        case 0: sb.Append("");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString()); break;
                        case 1: sb.Append("mem $7E:");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 2: sb.Append("mem $7F:");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 3: sb.Append("AMEM $");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 5: sb.Append("mem $7E:");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 6: sb.Append("OMEM $40");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                    }
                    sb.Append(", jump to $" + ((asc.InternalOffset & 0xFF0000) >> 16).ToString("X2"));
                    sb.Append(Bits.GetShort(asc.AnimationData, 4).ToString("X4"));
                    break;
                case 0x28:
                case 0x29:
                    sb.Append(((asc.Option & 0x0F) + 0x60).ToString("X2") + " < ");
                    switch ((asc.Option & 0xF0) >> 4)
                    {
                        case 0: sb.Append("");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString()); break;
                        case 1: sb.Append("mem $7E:");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 2: sb.Append("mem $7F:");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 3: sb.Append("AMEM $");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 5: sb.Append("mem $7E:");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 6: sb.Append("OMEM $40");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                    }
                    sb.Append(", jump to $" + ((asc.InternalOffset & 0xFF0000) >> 16).ToString("X2"));
                    sb.Append(Bits.GetShort(asc.AnimationData, 4).ToString("X4"));
                    break;
                case 0x2A:
                case 0x2B:
                    sb.Append(((asc.Option & 0x0F) + 0x60).ToString("X2") + " >= ");
                    switch ((asc.Option & 0xF0) >> 4)
                    {
                        case 0: sb.Append("");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString()); break;
                        case 1: sb.Append("mem $7E:");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 2: sb.Append("mem $7F:");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 3: sb.Append("AMEM $");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 5: sb.Append("mem $7E:");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 6: sb.Append("OMEM $40");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                    }
                    sb.Append(", jump to $" + ((asc.InternalOffset & 0xFF0000) >> 16).ToString("X2"));
                    sb.Append(Bits.GetShort(asc.AnimationData, 4).ToString("X4"));
                    break;
                case 0x2C:
                case 0x2D:
                    sb.Append(((asc.Option & 0x0F) + 0x60).ToString("X2") + " += ");
                    switch ((asc.Option & 0xF0) >> 4)
                    {
                        case 0: sb.Append("");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString()); break;
                        case 1: sb.Append("mem $7E:");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 2: sb.Append("mem $7F:");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 3: sb.Append("AMEM $");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 5: sb.Append("mem $7E:");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 6: sb.Append("OMEM $40");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                    }
                    break;
                case 0x2E:
                case 0x2F:
                    sb.Append(((asc.Option & 0x0F) + 0x60).ToString("X2") + " -= ");
                    switch ((asc.Option & 0xF0) >> 4)
                    {
                        case 0: sb.Append("");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString()); break;
                        case 1: sb.Append("mem $7E:");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 2: sb.Append("mem $7F:");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 3: sb.Append("AMEM $");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 5: sb.Append("mem $7E:");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
                        case 6: sb.Append("OMEM $40");
                            sb.Append((Bits.GetShort(asc.AnimationData, 2)).ToString("X4")); break;
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
                    sb.Append(Bits.GetShort(asc.AnimationData, 3).ToString("X4"));
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
                    sb.Append(Bits.GetShort(asc.AnimationData, 3).ToString("X4"));
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
                case 0x64:
                case 0x68:
                    sb.Append(((asc.InternalOffset & 0xFF0000) >> 16).ToString("X2"));
                    sb.Append(Bits.GetShort(asc.AnimationData, 1).ToString("X4"));
                    sb.Append(", packet = AMEM $60");
                    if (asc.Opcode == 0x68)
                    {
                        sb.Append(", animation = ");
                        sb.Append(asc.AnimationData[3].ToString());
                    }
                    break;
                case 0x6A:
                    sb.Append(asc.AnimationData[2] + " to AMEM $");
                    sb.Append(((asc.Option & 0x0F) + 0x60).ToString("X2"));
                    break;
                case 0x6B:
                    sb.Append(Bits.GetShort(asc.AnimationData, 2) + " to AMEM $");
                    sb.Append(((asc.Option & 0x0F) + 0x60).ToString("X2"));
                    break;
                case 0x72:
                    sb.Append("\"" + Lists.Numerize(Lists.EffectNames, asc.AnimationData[2]) + "\"");
                    break;
                case 0x7A:
                    switch (asc.Option & 3)
                    {
                        case 0x00:
                            sb.Append("[" + asc.AnimationData[2].ToString("X2") + "] \"" +
                                Model.BattleDialogues[asc.AnimationData[2]].GetStub() + "\", type = ");
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
                    if (asc.Option < Lists.BattleSoundNames.Length)
                        sb.Append(Lists.Numerize(Lists.BattleSoundNames, asc.Option));
                    else
                        sb.Append("{NOTHING}");
                    break;
                case 0xB0:
                    sb.Append(asc.Option); break;
                case 0xB1:
                    sb.Append(asc.Option + ", volume: " + Bits.GetShort(asc.AnimationData, 2)); break;
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
                            sb.Append("bits " + Bits.GetShort(asc.AnimationData, 1).ToString("X4") + " set"); break;
                    }
                    break;
                case 0x75:
                    sb.Append("bits " + Bits.GetShort(asc.AnimationData, 1).ToString("X4") + " clear"); break;
                case 0x77:
                    sb.Append((asc.Option >> 4) + ", ");
                    if ((asc.Option & 0x02) == 0x02) sb.Append("4bpp = true  ");
                    if ((asc.Option & 0x04) == 0x04) sb.Append("2bpp = true");
                    break;
                case 0x78:
                    sb.Append((asc.Option & 0x0F) + ", upper bits: " + (asc.Option >> 4));
                    break;
                case 0xBB:
                    sb.Append(Lists.Numerize(Lists.TargetNames, asc.Option));
                    break;
                case 0xBC:
                case 0xBD:
                    if (asc.AnimationData[2] == 0xFF)
                    {
                        sb.Append("Remove item from" + (asc.Opcode == 0xBD ? " special" : "") + " item inventory: ");
                        sb.Append(
                            Model.ItemNames.GetNameByNum(Math.Abs((short)Bits.GetShort(asc.AnimationData, 1))));
                    }
                    else
                    {
                        sb.Append("Store item to" + (asc.Opcode == 0xBD ? " special" : "") + " item inventory: ");
                        sb.Append(Model.ItemNames.GetNameByNum(Bits.GetShort(asc.AnimationData, 1)));
                    }
                    break;
                case 0xBE:
                    sb.Append(Bits.GetShort(asc.AnimationData, 1));
                    break;
                case 0xB6:
                    sb.Append(asc.Option + ", volume: " + asc.AnimationData[2]);
                    break;
                case 0x86:
                    ushort value = Bits.GetShort(asc.AnimationData, 1);
                    if (value == 1)
                        sb.Append("screen, ");
                    else if (value == 2)
                        sb.Append("current object, ");
                    else if (value == 4)
                        sb.Append("screen and all objects, ");
                    sb.Append("direction: " + asc.AnimationData[3] + ", ");
                    sb.Append("intensity: " + asc.AnimationData[4] + ", ");
                    sb.Append("amount: " + Bits.GetShort(asc.AnimationData, 5));
                    break;
                case 0x8E:
                case 0x8F:
                    switch (asc.Option & 0x07)
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
                    if (asc.Opcode == 0x8E)
                        sb.Append(", duration: " + asc.AnimationData[2]);
                    break;
                case 0xE1:
                    sb.Append(Bits.GetShort(asc.AnimationData, 1) + ", offset: " + asc.AnimationData[3]);
                    break;
                case 0xA3:
                    sb.Append(ScreenEffects[asc.Option]);
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
                    if (names != null)
                        bit[j] += names[j];
                    else
                        bit[j] += j;
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
