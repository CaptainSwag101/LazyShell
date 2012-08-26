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
        private List<SPCScriptCommand>[] channels;
        [NonSerialized()]
        private List<Note>[] notes;
        private bool[] activeChannels;
        public int Length;
        // Accessors
        public override byte[] Data { get { return data; } set { data = value; } }
        public override int Index { get { return index; } set { index = value; } }
        public override SampleIndex[] Samples { get { return samples; } set { samples = value; } }
        public override List<Percussives> Percussives { get { return percussives; } set { percussives = value; } }
        public override List<SPCScriptCommand>[] Channels { get { return channels; } set { channels = value; } }
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
            channels = new List<SPCScriptCommand>[8];
            for (int i = 0; i < 8; i++)
            {
                int spcOffset = Bits.GetShort(spcData, offset);
                if (spcOffset == 0)
                {
                    activeChannels[i] = false;
                    continue;
                }
                activeChannels[i] = true;
                spcOffset -= 0x2000;
                offset += 2;
                channels[i] = new List<SPCScriptCommand>();
                int length = 0;
                do
                {
                    spcOffset += length;
                    int opcode = spcData[spcOffset];
                    length = SPCScriptEnums.SPCScriptLengths[opcode];
                    byte[] commandData = Bits.GetByteArray(spcData, spcOffset, length);
                    channels[i].Add(new SPCScriptCommand(commandData, this, i));
                    if (commandData[0] == 0xD6)
                        commandData[0] = 0xD6;
                }
                while (spcData[spcOffset] != 0xD0 && spcData[spcOffset] != 0xCE);
            }
        }
        public override void CreateNotes()
        {
            notes = new List<Note>[8];
            for (int i = 0; i < notes.Length; i++)
            {
                if (channels[i] == null)
                    continue;
                notes[i] = new List<Note>();
                int index = 0;
                int octave = 0;
                bool percussive = false;
                while (index < channels[i].Count)
                {
                    SPCScriptCommand ssc = channels[i][index++];
                    switch (ssc.Opcode)
                    {
                        case 0xC4: octave++; break;
                        case 0xC5: octave--; break;
                        case 0xC6: octave = ssc.Option; break;
                        case 0xD4:
                            SequenceLoop(i, ref index, index, ssc.Option, ref octave, ref percussive);
                            break;
                        case 0xD5:
                            break;
                        case 0xEE: percussive = true; break;
                        case 0xEF: percussive = false; break;
                        default:
                            if (ssc.Opcode < 0xC4)
                                notes[i].Add(new Note(ssc, octave, percussive));
                            if (octave > Model.HighestOctave)
                                Model.HighestOctave = octave;
                            break;
                    }
                }
            }
        }
        private void SequenceLoop(int channel, ref int index, int start, int count, ref int octave_, ref bool percussive)
        {
            int octave = octave_;
            while (count > 0 && index < channels[channel].Count)
            {
                SPCScriptCommand ssc = channels[channel][index++];
                // if at last repeat, and first section begins, skip the rest
                if (ssc.Opcode == 0xD6 && count == 1)
                {
                    while (index < channels[channel].Count && channels[channel][index].Opcode != 0xD5)
                        index++;
                    break;
                }
                switch (ssc.Opcode)
                {
                    case 0xC4: octave++; break;
                    case 0xC5: octave--; break;
                    case 0xC6: octave = ssc.Option; break;
                    case 0xD4:
                        SequenceLoop(channel, ref index, index, ssc.Option, ref octave, ref percussive);
                        break;
                    case 0xD5:
                        count--;
                        if (count > 0)
                        {
                            index = start;
                            octave = octave_;
                        }
                        break;
                    case 0xD6:
                        break;
                    case 0xEE: percussive = true; break;
                    case 0xFA: percussive = false; break;
                    default:
                        if (ssc.Opcode < 0xC4)
                            notes[channel].Add(new Note(ssc, octave, percussive));
                        if (octave > Model.HighestOctave)
                            Model.HighestOctave = octave;
                        break;
                }
            }
            octave_ = octave;
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
                spcData[offset++] = percussive.PitchIndex;
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
                    foreach (SPCScriptCommand ssc in channels[i])
                        length += ssc.Length;
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
                foreach (SPCScriptCommand ssc in channels[i])
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
            channels = new List<SPCScriptCommand>[8];
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
        public byte PitchIndex;
        public byte Sample;
        public byte Pitch;
        public byte Volume;
        public byte Balance;
        public Percussives(byte pitchIndex, byte sample, byte pitch, byte volume, byte balance)
        {
            PitchIndex = pitchIndex;
            Sample = sample;
            Pitch = pitch;
            Volume = volume;
            Balance = balance;
        }
    }
    [Serializable()]
    public class Note
    {
        public bool Hold { get { return Pitch == 12; } }
        public bool Stop { get { return Pitch == 13; } }
        public bool Sharp
        {
            get
            {
                switch (Pitch)
                {
                    case 1: return true;
                    case 4: return true;
                    case 6: return true;
                    case 9: return true;
                    case 11: return true;
                    default: return false;
                }
            }
        }
        public int Pitch;
        public int Octave; // max is 8 (9 octaves)
        public bool Percussive;
        public int Y
        {
            get
            {
                int y = 0;
                switch (Pitch)
                {
                    case 0: // C
                    case 1: y = 12; break; // C#
                    case 2: // D
                    case 3: y = 8; break; // D#
                    case 4: y = 4; break; // E
                    case 5: // F
                    case 6: y = 0; break; // F# (middle line)
                    case 7: // G
                    case 8: y = -4; break; // G
                    case 9: // A
                    case 10: y = -8; break; // A#
                    case 11: y = -12; break; // B
                    default: y = 0; break; // silence/pause
                }
                // 4 is the middle octave
                int octave = Octave - 5;
                y = -(octave * 28) + y;
                return y;
            }
        }
        public int Beat;
        public int Duration;
        public Note(SPCScriptCommand ssc, int octave, bool percussive)
        {
            this.Pitch = ssc.Opcode % 14;
            this.Beat = ssc.Opcode / 14;
            if (ssc.Opcode < 0xB6)
                this.Duration = Model.Data[this.Beat + 0x042304];
            else
                this.Duration = ssc.Option;
            this.Octave = octave;
            this.Percussive = percussive;
        }
        public override string ToString()
        {
            string description = "";
            if (Hold)
                description += "Note stop, ";
            else if (Stop)
                description += "Note hold, ";
            else
            {
                description += "Note play: ";
                switch (Pitch)
                {
                    case 0:
                    case 1: description += "A"; break;
                    case 2: description += "B"; break;
                    case 3:
                    case 4: description += "C"; break;
                    case 5:
                    case 6: description += "D"; break;
                    case 7: description += "E"; break;
                    case 8:
                    case 9: description += "F"; break;
                    case 10:
                    case 11: description += "G"; break;
                    default: description += "?"; break; // silence/pause
                }
                if (Sharp)
                    description += "#";
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
                case 6: description += "beat: 8th+32nd"; break;
                case 7: description += "beat: 8th"; break;
                case 8: description += "beat: 16th."; break;
                case 9: description += "beat: 16th"; break;
                case 10: description += "beat: 32nd."; break;
                case 11: description += "beat: 32nd"; break;
                case 12: description += "beat: 64th"; break;
                default: description += "duration: " + Duration; break;
            }
            return description;
        }
    }
}
