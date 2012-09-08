using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace LAZYSHELL
{
    [Serializable()]
    public class SPCTrack : SPC
    {
        [NonSerialized()]
        private byte[] data;
        private int index;
        private byte[] spcData;
        private SampleIndex[] samples;
        private List<Percussives> percussives;
        private byte delayTime;
        private byte decayFactor;
        private byte echo;
        [NonSerialized()]
        private List<SPCCommand>[] channels;
        [NonSerialized()]
        private List<Note>[] notes;
        private bool[] activeChannels;
        public int Length;
        // Accessors
        public override byte[] Data { get { return data; } set { data = value; } }
        public override int Index { get { return index; } set { index = value; } }
        public override SampleIndex[] Samples { get { return samples; } set { samples = value; } }
        public override List<Percussives> Percussives { get { return percussives; } set { percussives = value; } }
        public override List<SPCCommand>[] Channels { get { return channels; } set { channels = value; } }
        public override List<Note>[] Notes { get { return notes; } set { notes = value; } }
        public override bool[] ActiveChannels { get { return activeChannels; } set { activeChannels = value; } }
        public override byte DelayTime { get { return delayTime; } set { delayTime = value; } }
        public override byte DecayFactor { get { return decayFactor; } set { decayFactor = value; } }
        public override byte Echo { get { return echo; } set { echo = value; } }
        public byte[] SPCData { get { return spcData; } }
        //
        public SPCTrack(byte[] data, int index)
        {
            this.data = data;
            this.index = index;
            if (index == 0) // "current" track has nothing
                return;
            //
            int offset = Bits.Get24Bit(data, index * 3 + 0x042748) - 0xC00000;
            DelayTime = data[offset++];
            DecayFactor = data[offset++];
            Echo = data[offset++];
            samples = new SampleIndex[19];
            int i = 0;
            while (data[offset] != 0xFF && i < 19)
                samples[i++] = new SampleIndex(data[offset++], data[offset++]);
            offset++;
            Length = Bits.GetShort(data, offset); offset += 2;
            spcData = Bits.GetByteArray(data, offset, Length);
            //
            CreateCommands();
        }
        public SPCTrack()
        {
        }
        public void CreateCommands()
        {
            int offset = 0;
            percussives = new List<Percussives>();
            while (spcData[offset] != 0xFF)
                percussives.Add(new Percussives(spcData[offset++], spcData[offset++], spcData[offset++], spcData[offset++], spcData[offset++]));
            offset++;
            // now disassemble the scripts for each channel
            activeChannels = new bool[8];
            channels = new List<SPCCommand>[8];
            for (int i = 0; i < 8; i++)
            {
                channels[i] = new List<SPCCommand>();
                int spcOffset = Bits.GetShort(spcData, offset);
                offset += 2;
                if (spcOffset == 0)
                {
                    activeChannels[i] = false;
                    continue;
                }
                activeChannels[i] = true;
                spcOffset -= 0x2000;
                int length = 0;
                do
                {
                    spcOffset += length;
                    int opcode = spcData[spcOffset];
                    length = SPCScriptEnums.SPCScriptLengths[opcode];
                    byte[] commandData = Bits.GetByteArray(spcData, spcOffset, length);
                    channels[i].Add(new SPCCommand(commandData, this, i));
                }
                while (spcData[spcOffset] != 0xD0 && spcData[spcOffset] != 0xCE);
            }
        }
        public override void CreateNotes()
        {
            notes = new List<Note>[8];
            for (int c = 0; c < notes.Length; c++)
            {
                if (channels[c] == null)
                    continue;
                notes[c] = new List<Note>();
                int i = 0;
                int thisOctave = 6;
                int sample = 0;
                bool percussive = false;
                while (i < channels[c].Count)
                {
                    SPCCommand ssc = channels[c][i++];
                    switch (ssc.Opcode)
                    {
                        case 0xC4: thisOctave++; break;
                        case 0xC5: thisOctave--; break;
                        case 0xC6: thisOctave = ssc.Param1; break;
                        case 0xD4:
                            SequenceLoop(c, ref i, i, ssc.Param1, ref thisOctave, ref percussive, ref sample);
                            break;
                        case 0xD5: break;
                        case 0xDE: sample = ssc.Param1; goto default;
                        case 0xEE: percussive = true; goto default;
                        case 0xEF: percussive = false; goto default;
                        default:
                            if (ssc.Opcode < 0xC4 || ssc.Opcode == 0xD7 || ssc.Opcode == 0xDE || ssc.Opcode == 0xEE || ssc.Opcode == 0xEF)
                                notes[c].Add(new Note(ssc, thisOctave, percussive, sample));
                            break;
                    }
                }
            }
        }
        private void SequenceLoop(int c, ref int i, int start, int count, ref int octave, ref bool percussive, ref int sample)
        {
            int end = i;
            int thisOctave = octave;
            while (count > 0 && i < channels[c].Count)
            {
                SPCCommand ssc = channels[c][i++];
                // if at last repeat, and first section begins, skip the rest
                if (ssc.Opcode == 0xD6 && count == 1)
                {
                    while (i < channels[c].Count && i < end)
                        i++;
                    break;
                }
                switch (ssc.Opcode)
                {
                    case 0xC4: thisOctave++; break;
                    case 0xC5: thisOctave--; break;
                    case 0xC6: thisOctave = ssc.Param1; break;
                    case 0xD4:
                        SequenceLoop(c, ref i, i, ssc.Param1, ref thisOctave, ref percussive, ref sample);
                        break;
                    case 0xD5:
                        end = i;
                        count--;
                        if (count > 0)
                        {
                            i = start;
                            thisOctave = octave;
                        }
                        break;
                    case 0xD6: break;
                    case 0xDE: sample = ssc.Param1; goto default;
                    case 0xEE: percussive = true; goto default;
                    case 0xEF: percussive = false; goto default;
                    default:
                        if (ssc.Opcode < 0xC4 || ssc.Opcode == 0xD7 || ssc.Opcode == 0xDE || ssc.Opcode == 0xEE || ssc.Opcode == 0xEF)
                            notes[c].Add(new Note(ssc, thisOctave, percussive, sample));
                        break;
                }
            }
            octave = thisOctave;
        }
        public List<SPCCommand>[] DecompToMML(NativeSPC nativeFormat)
        {
            List<SPCCommand>[] commands = new List<SPCCommand>[8];
            for (int c = 0; c < commands.Length; c++)
            {
                if (channels[c] == null)
                    continue;
                commands[c] = new List<SPCCommand>();
                int i = 0;
                int thisOctave = 6;
                int sample = 0;
                bool percussive = false;
                while (i < channels[c].Count)
                {
                    int maxOctave = 6;
                    if (nativeFormat == NativeSPC.SMWLevel ||
                        nativeFormat == NativeSPC.SMWOverworld)
                        maxOctave = Lists.SMWOctaveLimits[Lists.SMRPGtoSMWSamples[sample]];
                    SPCCommand ssc = channels[c][i++].Copy();
                    switch (ssc.Opcode)
                    {
                        case 0xC4: thisOctave++;
                            if (thisOctave > maxOctave) thisOctave = maxOctave;
                            else goto default;
                            break;
                        case 0xC5: thisOctave--;
                            if (thisOctave < 1) thisOctave = 1;
                            else goto default;
                            break;
                        case 0xC6:
                            if (ssc.Param1 < 1) ssc.Param1 = 1;
                            if (ssc.Param1 > maxOctave) ssc.Param1 = (byte)maxOctave;
                            thisOctave = ssc.Param1;
                            goto default;
                        case 0xD4:
                            //commands[c].Add(ssc);
                            commands[c].Add(new SPCCommand(new byte[] { 0xC6, (byte)thisOctave }, this, c));
                            DecompToMMLLoop(ref commands, nativeFormat, c, ref i, i, ssc.Param1, false, ref thisOctave, ref percussive, ref sample);
                            break;
                        case 0xD5: break;
                        case 0xDE: sample = ssc.Param1; goto default;
                        case 0xEE: percussive = true; goto default;
                        case 0xEF: percussive = false; goto default;
                        default:
                            thisOctave = Math.Max(1, Math.Min(6, thisOctave));
                            commands[c].Add(ssc); break;
                    }
                }
            }
            return commands;
        }
        private void DecompToMMLLoop(ref List<SPCCommand>[] commands, NativeSPC nativeFormat, int c, ref int i,
            int start, int count, bool nested, ref int octave, ref bool percussive, ref int sample)
        {
            int end = i;
            int thisOctave = octave;
            while (count > 0 && i < channels[c].Count)
            {
                int maxOctave = 6;
                if (nativeFormat == NativeSPC.SMWLevel ||
                    nativeFormat == NativeSPC.SMWOverworld)
                    maxOctave = Lists.SMWOctaveLimits[Lists.SMRPGtoSMWSamples[sample]];
                SPCCommand ssc = channels[c][i++].Copy();
                // if at last repeat, and first section begins, skip the rest
                if (ssc.Opcode == 0xD6 && count == 1)
                {
                    while (i < channels[c].Count && i < end)
                        i++;
                    break;
                }
                switch (ssc.Opcode)
                {
                    case 0xC4: thisOctave++;
                        if (thisOctave > maxOctave) thisOctave = maxOctave;
                        else goto default;
                        break;
                    case 0xC5: thisOctave--;
                        if (thisOctave < 1) thisOctave = 1;
                        else goto default;
                        break;
                    case 0xC6:
                        if (ssc.Param1 < 1) ssc.Param1 = 1;
                        if (ssc.Param1 > maxOctave) ssc.Param1 = (byte)maxOctave;
                        thisOctave = ssc.Param1;
                        goto default;
                    case 0xD4:
                        commands[c].Add(new SPCCommand(new byte[] { 0xC6, (byte)thisOctave }, this, c));
                        DecompToMMLLoop(ref commands, nativeFormat, c, ref i, i, ssc.Param1, true, ref thisOctave, ref percussive, ref sample);
                        break;
                    case 0xD5:
                        end = i;
                        count--;
                        if (nested && count > 0)
                        {
                            i = start;
                            thisOctave = octave;
                        }
                        else if (!nested)
                        {
                            commands[c].Add(ssc);
                            octave = thisOctave;
                            return;
                        }
                        break;
                    case 0xD6: break;
                    case 0xDE: sample = ssc.Param1; goto default;
                    case 0xEE: percussive = true; goto default;
                    case 0xEF: percussive = false; goto default;
                    default:
                        thisOctave = Math.Max(1, Math.Min(6, thisOctave));
                        commands[c].Add(ssc); break;
                }
            }
            octave = thisOctave;
        }
        public override void Assemble()
        {

        }
        public void Assemble(ref int offset)
        {
            if (index == 0)
                return;
            //int offset = Bits.Get24Bit(data, index * 3 + 0x042748) - 0xC00000;
            Bits.Set24Bit(data, index * 3 + 0x42748, offset + 0xC00000);
            data[offset++] = DelayTime;
            data[offset++] = DecayFactor;
            data[offset++] = Echo;
            foreach (SampleIndex sample in samples)
            {
                if (sample == null || !sample.Active)
                    continue;
                data[offset++] = (byte)sample.Sample;
                data[offset++] = (byte)sample.Volume;
            }
            data[offset++] = 0xFF;
            Bits.SetShort(data, offset, Length); offset += 2;
            //
            AssembleSPCData();
            Bits.SetByteArray(data, offset, spcData);
            offset += spcData.Length;
        }
        public void AssembleSPCData()
        {
            int offset = 0;
            foreach (Percussives percussive in percussives)
            {
                spcData[offset++] = (byte)percussive.PitchIndex;
                spcData[offset++] = percussive.Sample;
                spcData[offset++] = percussive.Pitch;
                spcData[offset++] = percussive.Volume;
                spcData[offset++] = percussive.Balance;
            }
            spcData[offset++] = 0xFF;
            int spcOffset = offset + 16;
            int length = spcOffset;
            for (int i = 0; i < channels.Length; i++)
                if (activeChannels[i] && channels[i] != null)
                    foreach (SPCCommand ssc in channels[i])
                        length += ssc.Length;
            this.Length = length;
            Array.Resize<byte>(ref spcData, length);
            for (int i = 0; i < 8; i++)
            {
                if (activeChannels[i] && channels[i] != null)
                    Bits.SetShort(spcData, offset, spcOffset + 0x2000);
                else
                    Bits.SetShort(spcData, offset, 0);
                offset += 2;
                if (!activeChannels[i] || channels[i] == null)
                    continue;
                foreach (SPCCommand ssc in channels[i])
                {
                    Bits.SetByteArray(spcData, spcOffset, ssc.CommandData);
                    spcOffset += ssc.Length;
                }
            }
        }
        public override void Clear()
        {
            delayTime = 0;
            decayFactor = 0;
            echo = 0;
            samples = new SampleIndex[19];
            //
            spcData = new byte[17]; // 16 for 8 channel pointers
            spcData[0] = 0xFF; // terminates percussive list
            percussives = new List<Percussives>();
            activeChannels = new bool[8];
            channels = new List<SPCCommand>[8];
            for (int i = 0; i < 8; i++)
                channels[i] = new List<SPCCommand>();
        }
    }
    [Serializable()]
    public class SampleIndex
    {
        public int Sample;
        public int Volume;
        public bool Active;
        public SampleIndex(int sample, int volume)
        {
            this.Sample = sample;
            this.Volume = volume;
            this.Active = true;
        }
    }
    [Serializable()]
    public class Percussives
    {
        public Pitch PitchIndex;
        public byte Sample;
        public byte Pitch;
        public byte Volume;
        public byte Balance;
        public Percussives(byte pitchIndex, byte sample, byte pitch, byte volume, byte balance)
        {
            PitchIndex = (Pitch)pitchIndex;
            Sample = sample;
            Pitch = pitch;
            Volume = volume;
            Balance = balance;
        }
    }
    [Serializable()]
    public class Note
    {
        public SPCCommand Command;
        public Pitch Pitch { get { return (Pitch)(Command.Opcode % 14); } }
        public int Beat { get { return Command.Opcode / 14; } }
        public int Octave; // max is 8 (9 octaves)
        public bool Percussive;
        public int Ticks
        {
            get
            {
                if (Command.Opcode < 0xB6)
                    return Model.Data[Beat + 0x042304];
                else if (Command.Opcode < 0xC4)
                    return Command.Param1;
                else
                    return 0;
            }
        }
        public bool Hold { get { return Pitch == Pitch.Hold; } }
        public bool Rest { get { return Pitch == Pitch.Rest; } }
        public bool Sharp
        {
            get
            {
                switch (Pitch)
                {
                    case Pitch.As: return true;
                    case Pitch.Cs: return true;
                    case Pitch.Ds: return true;
                    case Pitch.Fs: return true;
                    case Pitch.Gs: return true;
                    default: return false;
                }
            }
        }
        public int Y
        {
            get
            {
                int y = 0;
                switch (Pitch)
                {
                    case Pitch.C:  // C
                    case Pitch.Cs: y = -8; break; // C#
                    case Pitch.D:  // D
                    case Pitch.Ds: y = -12; break; // D#
                    case Pitch.E: y = -16; break; // E
                    case Pitch.F: // F
                    case Pitch.Fs: y = -20; break; // F#
                    case Pitch.G: // G
                    case Pitch.Gs: y = -24; break; // G#
                    case Pitch.A: // A
                    case Pitch.As: y = -28; break; // A#
                    case Pitch.B: y = -32; break; // B
                    default: y = 0; break; // silence/pause
                }
                // 4 is the middle octave
                if (!Percussive)
                {
                    int octave = Octave - 5;
                    y = -(octave * 28) + y;
                }
                return y;
            }
        }
        public int Line
        {
            get
            {
                int line = 0;
                switch (Pitch)
                {
                    case Pitch.C:  // C
                    case Pitch.Cs: line = 0; break; // C#
                    case Pitch.D:  // D
                    case Pitch.Ds: line = 1; break; // D#
                    case Pitch.E: line = 2; break; // E
                    case Pitch.F: // F
                    case Pitch.Fs: line = 3; break; // F# (middle line)
                    case Pitch.G: // G
                    case Pitch.Gs: line = 4; break; // G#
                    case Pitch.A: // A
                    case Pitch.As: line = 5; break; // A#
                    case Pitch.B: line = 6; break; // B
                    default: line = 0; break; // silence/pause
                }
                return line;
            }
        }
        /// <summary>
        /// Returns what accidentals need to be SHOWN based on a given key signature. Thus, only non-black keys are checked.
        /// </summary>
        /// <param name="key">The key signature.</param>
        /// <returns></returns>
        public Accidental GetAccidental(Key key)
        {
            switch (Pitch)
            {
                case Pitch.A:
                    if (key >= Key.BMajor && key <= Key.CsMajor) return Accidental.Sharp; // Sharps, major
                    if (key >= Key.GsMinor && key <= Key.AsMinor) return Accidental.Sharp; // Sharps, minor
                    if (key >= Key.EbMajor && key <= Key.CbMajor) return Accidental.Flat; // Flats, major
                    if (key >= Key.CMinor && key <= Key.AbMinor) return Accidental.Flat; // Flats, minor
                    break;
                case Pitch.B:
                    if (key == Key.CsMajor || key == Key.AsMinor) return Accidental.Sharp; // Sharps, major, minor
                    if (key >= Key.FMajor && key <= Key.CbMajor) return Accidental.Flat; // Flats, major
                    if (key >= Key.DMinor && key <= Key.AbMinor) return Accidental.Flat; // Flats, minor
                    break;
                case Pitch.C:
                    if (key >= Key.DMajor && key <= Key.CsMajor) return Accidental.Sharp; // Sharps, major
                    if (key >= Key.BMinor && key <= Key.AsMinor) return Accidental.Sharp; // Sharps, minor
                    if (key >= Key.GbMajor && key <= Key.CbMajor) return Accidental.Flat; // Flats, major
                    if (key >= Key.EbMinor && key <= Key.AbMinor) return Accidental.Flat; // Flats, minor
                    break;
                case Pitch.D:
                    if (key >= Key.EMajor && key <= Key.CsMajor) return Accidental.Sharp; // Sharps, major
                    if (key >= Key.CsMinor && key <= Key.AsMinor) return Accidental.Sharp; // Sharps, minor
                    if (key >= Key.AbMajor && key <= Key.CbMajor) return Accidental.Flat; // Flats, major
                    if (key >= Key.FMinor && key <= Key.AbMinor) return Accidental.Flat; // Flats, minor
                    break;
                case Pitch.E:
                    if (key >= Key.FsMajor && key <= Key.CsMajor) return Accidental.Sharp; // Sharps, major
                    if (key >= Key.DsMinor && key <= Key.AsMinor) return Accidental.Sharp; // Sharps, minor
                    if (key >= Key.BbMajor && key <= Key.CbMajor) return Accidental.Flat; // Flats, major
                    if (key >= Key.DMinor && key <= Key.AbMinor) return Accidental.Flat; // Flats, minor
                    break;
                case Pitch.F:
                    if (key >= Key.GMajor && key <= Key.CsMajor) return Accidental.Sharp; // Sharps, major
                    if (key >= Key.EMinor && key <= Key.AsMinor) return Accidental.Sharp; // Sharps, minor
                    if (key == Key.CbMajor || key == Key.AbMinor) return Accidental.Flat; // Flats, major, minor
                    break;
                case Pitch.G:
                    if (key >= Key.AMajor && key <= Key.CsMajor) return Accidental.Sharp; // Sharps, major
                    if (key >= Key.FsMinor && key <= Key.AsMinor) return Accidental.Sharp; // Sharps, minor
                    if (key >= Key.DbMajor && key <= Key.CbMajor) return Accidental.Flat; // Flats, major
                    if (key >= Key.BbMinor && key <= Key.AbMinor) return Accidental.Flat; // Flats, major
                    break;
            }
            return Accidental.Natural; // Natural
        }
        public int Sample;
        public Note(SPCCommand command, int octave, bool percussive, int sample)
        {
            this.Command = command;
            this.Octave = percussive ? 5 : octave;
            this.Percussive = percussive;
            this.Sample = sample;
        }
        public Note(SPCCommand command)
        {
            this.Command = command;
            this.Octave = 6;
            this.Percussive = false;
            this.Sample = 0;
        }
        public string ToString(bool showOctave)
        {
            string description = "";
            if (Hold)
                description += "Note hold, ";
            else if (Rest)
                description += "Note rest, ";
            else
            {
                description += "Note play: ";
                switch (Pitch)
                {
                    case Pitch.A:
                    case Pitch.As: description += "A"; break;
                    case Pitch.B: description += "B"; break;
                    case Pitch.C:
                    case Pitch.Cs: description += "C"; break;
                    case Pitch.D:
                    case Pitch.Ds: description += "D"; break;
                    case Pitch.E: description += "E"; break;
                    case Pitch.F:
                    case Pitch.Fs: description += "F"; break;
                    case Pitch.G:
                    case Pitch.Gs: description += "G"; break;
                    default: description += "?"; break; // silence/pause
                }
                if (Sharp)
                    description += "#";
                if (showOctave)
                    description += Octave;
                description += ", ";
            }
            switch (Beat)
            {
                case 0: description += "beat: whole"; break;
                case 1: description += "beat: half."; break;
                case 2: description += "beat: half"; break;
                case 3: description += "beat: quarter."; break;
                case 4: description += "beat: quarter"; break;
                case 5: description += "beat: 8th."; break;
                case 6: description += "beat: triplet quarter"; break;
                case 7: description += "beat: 8th"; break;
                case 8: description += "beat: triplet 8th"; break;
                case 9: description += "beat: 16th"; break;
                case 10: description += "beat: triplet 16th"; break;
                case 11: description += "beat: 32nd"; break;
                case 12: description += "beat: 64th"; break;
                default: description += "duration: " + Ticks; break;
            }
            return description;
        }
        public override string ToString()
        {
            return ToString(false);
        }
    }
}
