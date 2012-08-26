using System;
using System.Collections.Generic;
using System.Text;
using LAZYSHELL.Properties;

namespace LAZYSHELL.ScriptsEditor.Commands
{
    public partial class Interpreter
    {
        #region Static Data
        public static string[] SPCScriptCommands = new string[]
        {
            "",			// 0x00
            "",			// 0x01
            "",			// 0x02
            "",			// 0x03
            "",			// 0x04
            "",			// 0x05
            "",			// 0x06
            "",			// 0x07
            "",			// 0x08
            "",			// 0x09
            "",			// 0x0A
            "",			// 0x0B
            "",			// 0x0C
            "",			// 0x0D
            "",			// 0x0E
            "",			// 0x0F
			
            "",			// 0x10
            "",			// 0x11
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
			
            "",			// 0x20
            "",			// 0x21
            "",			// 0x22
            "",			// 0x23
            "",			// 0x24
            "",			// 0x25
            "",			// 0x26
            "",			// 0x27
            "",			// 0x28
            "",			// 0x29
            "",			// 0x2A
            "",			// 0x2B
            "",			// 0x2C
            "",			// 0x2D
            "",			// 0x2E
            "",			// 0x2F
			
            "",			// 0x30
            "",			// 0x31
            "",			// 0x32
            "",			// 0x33
            "",			// 0x34
            "",			// 0x35
            "",			// 0x36
            "",			// 0x37
            "",			// 0x38
            "",			// 0x39
            "",			// 0x3A
            "",			// 0x3B
            "",			// 0x3C
            "",			// 0x3D
            "",			// 0x3E
            "",			// 0x3F
			
            "",			// 0x40
            "",			// 0x41
            "",			// 0x42
            "",			// 0x43
            "",			// 0x44
            "",			// 0x45
            "",			// 0x46
            "",			// 0x47
            "",			// 0x48
            "",			// 0x49
            "",			// 0x4A
            "",			// 0x4B
            "",			// 0x4C
            "",			// 0x4D
            "",			// 0x4E
            "",			// 0x4F
			
            "",			// 0x50
            "",			// 0x51
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
            "",			// 0x5D
            "",			// 0x5E
            "",			// 0x5F
			
            "",			// 0x60
            "",			// 0x61
            "",			// 0x62
            "",			// 0x63
            "",			// 0x64
            "",			// 0x65
            "",			// 0x66
            "",			// 0x67
            "",			// 0x68
            "",			// 0x69
            "",			// 0x6A
            "",			// 0x6B
            "",			// 0x6C
            "",			// 0x6D
            "",			// 0x6E
            "",			// 0x6F
			
            "",			// 0x70
            "",			// 0x71
            "",			// 0x72
            "",			// 0x73
            "",			// 0x74
            "",			// 0x75
            "",			// 0x76
            "",			// 0x77
            "",			// 0x78
            "",			// 0x79
            "",			// 0x7A
            "",			// 0x7B
            "",			// 0x7C
            "",			// 0x7D
            "",			// 0x7E
            "",			// 0x7F
			
            "",			// 0x80
            "",			// 0x81
            "",			// 0x82
            "",			// 0x83
            "",			// 0x84
            "",			// 0x85
            "",			// 0x86
            "",			// 0x87
            "",			// 0x88
            "",			// 0x89
            "",			// 0x8A
            "",			// 0x8B
            "",			// 0x8C
            "",			// 0x8D
            "",			// 0x8E
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
            "",			// 0xAB
            "",			// 0xAC
            "",			// 0xAD
            "",			// 0xAE
            "",			// 0xAF
			
            "",			// 0xB0
            "",			// 0xB1
            "",			// 0xB2
            "",			// 0xB3
            "",			// 0xB4
            "",			// 0xB5
            "",			// 0xB6
            "",			// 0xB7
            "",			// 0xB8
            "",			// 0xB9
            "",			// 0xBA
            "",			// 0xBB
            "",			// 0xBC
            "",			// 0xBD
            "",			// 0xBE
            "",			// 0xBF
			
            "",			// 0xC0
            "",			// 0xC1
            "",			// 0xC2
            "",			// 0xC3
            "Octave up",			// 0xC4
            "Octave down",			// 0xC5
            "Octave = ",			// 0xC6
            "Slur next note",			// 0xC7
            "Noise on, channels = ",			// 0xC8
            "Noise on, all channels",			// 0xC9
            "Noise off",			// 0xCA
            "Noise on",			// 0xCB
            "",			// 0xCC
            "Play sound (new channel) = ",			// 0xCD
            "Play sound (this channel) = ",			// 0xCE
            "Transpose 1/16 pitch = ",			// 0xCF
			
            "Terminate script",			// 0xD0
            "Beat duration = ",			// 0xD1
            "",			// 0xD2
            "",			// 0xD3
            "Begin repeat, count = ",			// 0xD4
            "End repeat (reset octave)",			// 0xD5
            "Repeat ending start",			// 0xD6
            "Begin infinite repeat",			// 0xD7
            "",			// 0xD8
            "",			// 0xD9
            "",			// 0xDA
            "",			// 0xDB
            "Echo, decay ratio : 24 = ",			// 0xDC
            "",			// 0xDD
            "Instrument = ",			// 0xDE
            "",			// 0xDF
			
            "Staccato = ",			// 0xE0
            "",			// 0xE1
            "Volume = ",			// 0xE2
            "",			// 0xE3
            "Volume slide, duration = ",			// 0xE4
            "Portamento, duration = ",			// 0xE5
            "",			// 0xE6
            "Speaker balance = ",			// 0xE7
            "Speaker balance shift, duration = ",			// 0xE8
            "Speaker balance pansweep, duration = ",			// 0xE9
            "",			// 0xEA
            "",			// 0xEB
            "Transpose 1/4 pitch 1 = ",			// 0xEC
            "Transpose 1/4 pitch 2 = ",			// 0xED
            "Drum mode on",			// 0xEE
            "Drum mode off",			// 0xEF
			
            "Tremolo, rate = ",			// 0xF0
            "Vibrato, rate = ",			// 0xF1
            "Beat duration, change = ",			// 0xF2
            "Vibrato off",			// 0xF3
            "",			// 0xF4
            "",			// 0xF5
            "Portamento on, length = ",			// 0xF6
            "",			// 0xF7
            "Dizziness on",			// 0xF8
            "Dizziness off",			// 0xF9
            "Reverb on",			// 0xFA
            "Reverb off",			// 0xFB
            "Reverb, delay time = ",			// 0xFC
            "",			// 0xFD
            "",			// 0xFE
            ""				// 0xFF
        };
        #endregion
        public string InterpretSPCCommand(SPCScriptCommand ssc)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(SPCScriptCommands[ssc.Opcode]);
            switch (ssc.Opcode)
            {
                case 0xCD:
                case 0xCE:
                    sb.Append(Lists.Numerize(Lists.SoundNames[ssc.Option], ssc.Option, 3));
                    break;
                case 0xC6:
                case 0xC8:
                case 0xCF:
                case 0xD1:
                case 0xD4:
                case 0xDC:
                case 0xE0:
                case 0xE2:
                case 0xEC:
                case 0xED:
                case 0xF6:
                    sb.Append(ssc.Option);
                    break;
                case 0xDE:
                    sb.Append(Lists.Numerize(Lists.SampleNames[ssc.Option], ssc.Option, 3));
                    break;
                case 0xE4:
                case 0xE5:
                    sb.Append(ssc.Option + ", level = ");
                    sb.Append((sbyte)ssc.CommandData[2]);
                    break;
                case 0xE8:
                    sb.Append(ssc.Option + ", balance = " + ssc.CommandData[2]);
                    break;
                case 0xE9:
                    sb.Append(ssc.Option + ", speed = " + ssc.CommandData[2]);
                    break;
                case 0xF0:
                case 0xF1:
                    sb.Append(ssc.Option + ", extent = ");
                    if (ssc.Opcode == 0xF1)
                    {
                        sb.Append(ssc.CommandData[2] + ", start time = ");
                        sb.Append(ssc.CommandData[3]);
                    }
                    else
                        sb.Append(ssc.CommandData[2]);
                    break;
                case 0xE7:
                case 0xF2:
                    sb.Append((sbyte)ssc.Option);
                    break;
                case 0xFC:
                    sb.Append(ssc.Option + ", decay ratio = ");
                    sb.Append(ssc.CommandData[2] + ", echo volume = ");
                    sb.Append(ssc.CommandData[3]);
                    break;
                default:
                    if (ssc.Opcode < 0xC4)
                    {
                        Note note = new Note(ssc, 0, false);
                        sb.Append(note.ToString());
                    }
                    else if (sb.Length == 0)
                        sb.Append("{" + BitConverter.ToString(ssc.CommandData) + "}");
                    break;
            }
            return sb.ToString();
        }
    }
}
