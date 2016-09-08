using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace LazyShell.Audio
{
    /// <summary>
    /// Contains all of the data, collections, and methods  
    /// for managing an SPC music track's data.
    /// </summary>
    [Serializable()]
    public class SPCTrack : SPC
    {
        #region Variables

        // ROM buffer
        private byte[] rom
        {
            get { return Model.ROM; }
            set { Model.ROM = value; }
        }

        // Index
        public override int Index { get; set; }

        // SPC binary data
        public byte[] Data { get; set; }
        public int Length { get; set; }

        // Collections
        public override SampleIndex[] Samples { get; set; }
        public override List<Percussive> Percussives { get; set; }
        public override List<Command>[] Channels { get; set; }
        public override List<Note>[] Notes { get; set; }
        public override bool[] ActiveChannels { get; set; }

        // Reverberation
        public override byte DelayTime { get; set; }
        public override byte DecayFactor { get; set; }
        public override byte Echo { get; set; }

        #endregion

        // Constructors
        public SPCTrack(int index)
        {
            this.Index = index;
            if (index == 0) // "current" track has nothing
                return;
            ReadFromROM();
        }
        public SPCTrack()
        {
        }

        #region Methods

        // Read from ROM
        private void ReadFromROM()
        {
            int offset = Bits.GetInt24(rom, Index * 3 + 0x042748) - 0xC00000;
            DelayTime = rom[offset++];
            DecayFactor = rom[offset++];
            Echo = rom[offset++];
            Samples = new SampleIndex[20];
            int i = 0;
            while (rom[offset] != 0xFF && i < 20)
                Samples[i++] = new SampleIndex(rom[offset++], rom[offset++]);
            offset++;
            Length = Bits.GetShort(rom, offset); offset += 2;
            Data = Bits.GetBytes(rom, offset, Length);
            //
            ParseScript();
        }
        /// <summary>
        /// Builds the command collections of the SPC's 8 channels from the ROM data.
        /// </summary>
        public void ParseScript()
        {
            int offset = 0;
            Percussives = new List<Percussive>();
            while (Data[offset] != 0xFF)
                Percussives.Add(new Percussive(Data[offset++], Data[offset++], Data[offset++], Data[offset++], Data[offset++]));
            offset++;
            // now disassemble the scripts for each channel
            ActiveChannels = new bool[8];
            Channels = new List<Command>[8];
            for (int i = 0; i < 8; i++)
            {
                Channels[i] = new List<Command>();
                int spcOffset = Bits.GetShort(Data, offset);
                offset += 2;
                if (spcOffset == 0)
                {
                    ActiveChannels[i] = false;
                    continue;
                }
                ActiveChannels[i] = true;
                spcOffset -= 0x2000;
                int length = 0;
                do
                {
                    spcOffset += length;
                    int opcode = Data[spcOffset];
                    length = ScriptEnums.CommandLengths[opcode];
                    byte[] commandData = Bits.GetBytes(Data, spcOffset, length);
                    Channels[i].Add(new Command(commandData, this, i));
                }
                while (Data[spcOffset] != 0xD0 && Data[spcOffset] != 0xCE);
            }
        }
        public void WriteToROM(ref int offset)
        {
            if (Index == 0)
                return;
            //int offset = Bits.Get24Bit(data, index * 3 + 0x042748) - 0xC00000;
            Bits.SetInt24(rom, Index * 3 + 0x42748, offset + 0xC00000);
            rom[offset++] = DelayTime;
            rom[offset++] = DecayFactor;
            rom[offset++] = Echo;
            foreach (var sample in Samples)
            {
                if (sample == null || !sample.Active)
                    continue;
                rom[offset++] = (byte)sample.Sample;
                rom[offset++] = (byte)sample.Volume;
            }
            rom[offset++] = 0xFF;
            Bits.SetShort(rom, offset, Length); offset += 2;
            //
            WriteToBuffer();
            Bits.SetBytes(rom, offset, Data);
            offset += Data.Length;
        }
        /// <summary>
        /// Writes this instance's command data to its binary data buffer.
        /// </summary>
        public void WriteToBuffer()
        {
            int offset = 0;
            Data = new byte[Percussives.Count * 5 + 1];
            foreach (var percussive in Percussives)
            {
                Data[offset++] = (byte)percussive.PitchIndex;
                Data[offset++] = percussive.Sample;
                Data[offset++] = percussive.Pitch;
                Data[offset++] = percussive.Volume;
                Data[offset++] = percussive.Balance;
            }
            Data[offset++] = 0xFF;
            int spcOffset = offset + 16;
            int length = spcOffset;
            for (int i = 0; i < Channels.Length; i++)
                if (ActiveChannels[i] && Channels[i] != null)
                    foreach (var ssc in Channels[i])
                        length += ssc.Length;
            this.Length = length;
            Data = Bits.Resize(Data, length);
            for (int i = 0; i < 8; i++)
            {
                if (ActiveChannels[i] && Channels[i] != null)
                    Bits.SetShort(Data, offset, spcOffset + 0x2000);
                else
                    Bits.SetShort(Data, offset, 0);
                offset += 2;
                if (!ActiveChannels[i] || Channels[i] == null)
                    continue;
                foreach (var ssc in Channels[i])
                {
                    Bits.SetBytes(Data, spcOffset, ssc.Data);
                    spcOffset += ssc.Length;
                }
            }
        }

        /// <summary>
        /// Creates a note collection from the command data of the 8 channels
        /// for drawing and editing the data in a notation user interface.
        /// </summary>
        public override void CreateNotes()
        {
            Notes = new List<Note>[8];
            for (int c = 0; c < Notes.Length; c++)
            {
                if (Channels[c] == null)
                    continue;
                Notes[c] = new List<Note>();
                int i = 0;
                int thisOctave = 6;
                int sample = 0;
                bool percussive = false;
                while (i < Channels[c].Count)
                {
                    var ssc = Channels[c][i++];
                    switch (ssc.Opcode)
                    {
                        case 0xC4: thisOctave++; break;
                        case 0xC5: thisOctave--; break;
                        case 0xC6: thisOctave = ssc.Param1; break;
                        case 0xD4:
                            RepeatLoop(c, ref i, i, ssc.Param1, ref thisOctave, ref percussive, ref sample);
                            break;
                        case 0xD5: break;
                        case 0xDE: sample = ssc.Param1; goto default;
                        case 0xEE: percussive = true; goto default;
                        case 0xEF: percussive = false; goto default;
                        default:
                            if (ssc.Opcode < 0xC4 || ssc.Opcode == 0xD7 || ssc.Opcode == 0xDE || ssc.Opcode == 0xEE || ssc.Opcode == 0xEF)
                                Notes[c].Add(new Note(ssc, thisOctave, percussive, sample));
                            break;
                    }
                }
            }
        }
        /// <summary>
        /// Navigates through a repeat block in order to "decompress" the
        /// command data to a note collection.
        /// </summary>
        /// <param name="c">The current channel being built.</param>
        /// <param name="i">The current index in the channel's note collection.</param>
        private void RepeatLoop(int c, ref int i, int start, int count, ref int octave, ref bool percussive, ref int sample)
        {
            int end = i;
            int thisOctave = octave;
            while (count > 0 && i < Channels[c].Count)
            {
                Command ssc = Channels[c][i++];
                // if at last repeat, and first section begins, skip the rest
                if (ssc.Opcode == 0xD6 && count == 1)
                {
                    while (i < Channels[c].Count && i < end)
                        i++;
                    break;
                }
                switch (ssc.Opcode)
                {
                    case 0xC4: thisOctave++; break;
                    case 0xC5: thisOctave--; break;
                    case 0xC6: thisOctave = ssc.Param1; break;
                    case 0xD4:
                        RepeatLoop(c, ref i, i, ssc.Param1, ref thisOctave, ref percussive, ref sample);
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
                            Notes[c].Add(new Note(ssc, thisOctave, percussive, sample));
                        break;
                }
            }
            octave = thisOctave;
        }

        /// <summary>
        /// Creates a command collection from this instance's command data
        /// having greater compatibility with the universal MML format.
        /// </summary>
        /// <param name="nativeFormat"></param>
        /// <returns></returns>
        public List<Command>[] CompatibilizeMML(NativeSPC nativeFormat)
        {
            List<Command>[] commands = new List<Command>[8];
            for (int c = 0; c < commands.Length; c++)
            {
                if (Channels[c] == null)
                    continue;
                commands[c] = new List<Command>();
                int i = 0;
                int thisOctave = 6;
                int sample = 0;
                bool percussive = false;
                while (i < Channels[c].Count)
                {
                    int maxOctave = 6;
                    if (nativeFormat == NativeSPC.SMWLevel ||
                        nativeFormat == NativeSPC.SMWOverworld)
                        maxOctave = Lists.SMWOctaveLimits[Lists.SMRPGtoSMWSamples[sample]];
                    Command ssc = Channels[c][i++].Copy();
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
                            commands[c].Add(new Command(new byte[] { 0xC6, (byte)thisOctave }, this, c));
                            CompatibilizeMMLLoop(ref commands, nativeFormat, c, ref i, i, ssc.Param1, false, ref thisOctave, ref percussive, ref sample);
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
        private void CompatibilizeMMLLoop(ref List<Command>[] commands, NativeSPC nativeFormat, int c, ref int i,
            int start, int count, bool nested, ref int octave, ref bool percussive, ref int sample)
        {
            int end = i;
            int thisOctave = octave;
            while (count > 0 && i < Channels[c].Count)
            {
                int maxOctave = 6;
                if (nativeFormat == NativeSPC.SMWLevel ||
                    nativeFormat == NativeSPC.SMWOverworld)
                    maxOctave = Lists.SMWOctaveLimits[Lists.SMRPGtoSMWSamples[sample]];
                Command ssc = Channels[c][i++].Copy();
                // if at last repeat, and first section begins, skip the rest
                if (ssc.Opcode == 0xD6 && count == 1)
                {
                    while (i < Channels[c].Count && i < end)
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
                        commands[c].Add(new Command(new byte[] { 0xC6, (byte)thisOctave }, this, c));
                        CompatibilizeMMLLoop(ref commands, nativeFormat, c, ref i, i, ssc.Param1, true, ref thisOctave, ref percussive, ref sample);
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

        // Inherited
        public override void Clear()
        {
            DelayTime = 0;
            DecayFactor = 0;
            Echo = 0;
            Samples = new SampleIndex[20];
            //
            Data = new byte[17]; // 16 for 8 channel pointers
            Data[0] = 0xFF; // terminates percussive list
            Percussives = new List<Percussive>();
            ActiveChannels = new bool[8];
            Channels = new List<Command>[8];
            for (int i = 0; i < 8; i++)
                Channels[i] = new List<Command>();
        }
        public override void WriteToROM()
        {
        }

        #endregion
    }
    
    /// <summary>
    /// Contains the information of a sample, including its
    /// instrument index and its volume level.
    /// </summary>
    [Serializable()]
    public class SampleIndex
    {
        #region Variables

        public int Sample;
        public int Volume;
        public bool Active;

        #endregion

        /// <summary>
        /// Each SPC can have between 0 and 20 sample indexes/instruments
        /// </summary>
        /// <param name="sample">The instrument/sample.</param>
        /// <param name="volume">The volume of the sample.</param>
        public SampleIndex(int sample, int volume)
        {
            this.Sample = sample;
            this.Volume = volume;
            this.Active = true;
        }
    }

    /// <summary>
    /// Class containing the data of a percussive instrument used by an
    /// SPC's data when the percussive mode is currently active.
    /// </summary>
    [Serializable()]
    public class Percussive
    {
        #region Variables

        public Pitch PitchIndex;
        public byte Sample;
        public byte Pitch;
        public byte Volume;
        public byte Balance;

        #endregion

        // Constructor
        public Percussive(byte pitchIndex, byte sample, byte pitch, byte volume, byte balance)
        {
            PitchIndex = (Pitch)pitchIndex;
            Sample = sample;
            Pitch = pitch;
            Volume = volume;
            Balance = balance;
        }
    }

    /// <summary>
    /// Class for converting a command's data to a type that is 
    /// manageable in a score viewing and editing interface.
    /// </summary>
    [Serializable()]
    public class Note
    {
        #region Variables

        /// <summary>
        /// Command associated with this instance.
        /// </summary>
        public Command Command;
        /// <summary>
        /// Index of note's command in collection
        /// </summary>
        public int Index
        {
            get
            {
                return Command.Index;
            }
        }
        public Note PrevSibling(List<Note> notes)
        {
            int index = notes.IndexOf(this);
            if (index - 1 >= 0 && index - 1 < notes.Count)
                return notes[index - 1];
            return null;
        }
        public Note NextSibling(List<Note> notes)
        {
            int index = notes.IndexOf(this);
            if (index + 1 >= 0 && index + 1 < notes.Count)
                return notes[index + 1];
            return null;
        }
        /// <summary>
        /// Sample/instrument associated with this instance.
        /// </summary>
        public int Sample;
        /// <summary>
        /// Indicates whether to treat the note as a percussive or an instrument.
        /// </summary>
        public bool Percussive;
        /// <summary>
        /// Gets the pitch value from the command data.
        /// </summary>
        public Pitch Pitch
        {
            get { return (Pitch)(Command.Opcode % 14); }
        }
        public Beat Beat
        {
            get { return (Beat)(Command.Opcode / 14); }
        }
        /// <summary>
        /// Indicates whether this instance is actually a note
        /// or merely a non-note command.
        /// </summary>
        public bool IsNote
        {
            get { return Command.Opcode < 0xC4; }
        }
        public int Octave; // max is 8 (9 octaves)
        public int Ticks
        {
            get
            {
                if (Command.Opcode < 0xB6)
                    return Model.ROM[(int)Beat + 0x042304];
                else if (Command.Opcode < 0xC4)
                    return Command.Param1;
                else
                    return 0;
            }
        }
        public bool Tie
        {
            get { return Pitch == Pitch.Tie; }
        }
        public bool Rest
        {
            get { return Pitch == Pitch.Rest; }
        }
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
        /// <summary>
        /// Gets the staff's line number where the note would appear in a score.
        /// </summary>
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
        /// Gets the Y coordinate of the note as it would appear in a score's staff.
        /// The value is relative to the staff -- a channel index is not figured in.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int Y(Key key)
        {
            int y = 0;
            if ((key >= Key.CMajor && key <= Key.CsMajor) ||
                (key >= Key.AMinor && key <= Key.AsMinor)) // sharps
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
            else if ((key >= Key.FMajor && key <= Key.CbMajor) ||
                (key >= Key.DMinor && key <= Key.AbMinor)) // flats
                switch (Pitch)
                {
                    case Pitch.C: y = -8; break; // C
                    case Pitch.Cs: y = -12; break; // Db
                    case Pitch.D: y = -12; break; // D
                    case Pitch.Ds: y = -16; break; // Eb
                    case Pitch.E: y = -16; break; // E
                    case Pitch.F: y = -20; break; // F
                    case Pitch.Fs: y = -24; break; // Gb
                    case Pitch.G: y = -24; break; // G
                    case Pitch.Gs: y = -28; break; // Ab
                    case Pitch.A: y = -28; break; // A
                    case Pitch.As: y = -32; break; // Bb
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

        #endregion

        // Constructors
        public Note(Command command, int octave, bool percussive, int sample)
        {
            this.Command = command;
            this.Octave = percussive ? 5 : octave;
            this.Percussive = percussive;
            this.Sample = sample;
        }
        public Note(Command command)
        {
            this.Command = command;
            this.Octave = 6;
            this.Percussive = false;
            this.Sample = 0;
        }

        #region Methods

        /// <summary>
        /// Creates a deep copy of this instance.
        /// </summary>
        /// <returns></returns>
        public Note Copy()
        {
            return new Note(this.Command.Copy(), this.Octave, this.Percussive, this.Sample);
        }
        public string ToString(bool showOctave)
        {
            if (Command.Opcode >= 0xC4)
                return Command.ToString();
            //
            string description = "";
            if (Tie)
                description += "Note tie, ";
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
                case Beat.Whole: description += "beat: whole"; break;
                case Beat.HalfDotted: description += "beat: half."; break;
                case Beat.Half: description += "beat: half"; break;
                case Beat.QuarterDotted: description += "beat: quarter."; break;
                case Beat.Quarter: description += "beat: quarter"; break;
                case Beat.EighthDotted: description += "beat: 8th."; break;
                case Beat.QuarterTriplet: description += "beat: triplet quarter"; break;
                case Beat.Eighth: description += "beat: 8th"; break;
                case Beat.EighthTriplet: description += "beat: triplet 8th"; break;
                case Beat.Sixteenth: description += "beat: 16th"; break;
                case Beat.SixteenthTriplet: description += "beat: triplet 16th"; break;
                case Beat.ThirtySecond: description += "beat: 32nd"; break;
                case Beat.SixtyFourth: description += "beat: 64th"; break;
                default: description += "duration: " + Ticks; break;
            }
            return description;
        }
        public override string ToString()
        {
            return ToString(false);
        }

        #endregion
    }
}
