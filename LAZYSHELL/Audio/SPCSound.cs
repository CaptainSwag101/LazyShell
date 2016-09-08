using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LazyShell.Audio
{
    [Serializable()]
    public class SPCSound : SPC
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
        public ElementType Type { get; set; }

        // Collections
        public override List<Command>[] Channels { get; set; }
        public override bool[] ActiveChannels { get; set; }

        // Inherited (not used in this class)
        public override SampleIndex[] Samples
        {
            get { return null; }
            set { }
        }
        public override List<Percussive> Percussives
        {
            get { return null; }
            set { }
        }
        public override List<Note>[] Notes { get; set; }
        public override byte DelayTime { get; set; }
        public override byte DecayFactor { get; set; }
        public override byte Echo { get; set; }

        #endregion

        // Constructor
        public SPCSound(int index, ElementType type)
        {
            this.Index = index;
            this.Type = type;
            ReadFromROM();
        }

        #region Methods

        // Read/write ROM
        private void ReadFromROM()
        {
            // Calculate pointer offset
            int pointerOffset;
            if (Type == 0)
                pointerOffset = Index * 4 + 0x042826;
            else
                pointerOffset = Index * 4 + 0x043E26;

            // Initialize collections
            ActiveChannels = new bool[2];
            Channels = new List<Command>[2];

            // Iterate through both channels
            for (int i = 0; i < 2; i++)
            {
                // Initialize channel's commands
                Channels[i] = new List<Command>();

                // Get offset of SPC data
                int dataOffset = Bits.GetShort(rom, pointerOffset);
                pointerOffset += 2;

                // Channels not active if pointer is empty
                if (dataOffset == 0)
                {
                    ActiveChannels[i] = false;
                    continue;
                }
                ActiveChannels[i] = true;

                // Calculate data offset from base offset of SPC collection data
                if (Type == 0)
                    dataOffset = dataOffset - 0x3400 + 0x042C26;
                else
                    dataOffset = dataOffset - 0x3400 + 0x044226;

                // Finally, start building command collection
                int length = 0;
                do
                {
                    dataOffset += length;
                    int opcode = rom[dataOffset];
                    length = ScriptEnums.CommandLengths[opcode];
                    byte[] commandData = Bits.GetBytes(rom, dataOffset, length);
                    Channels[i].Add(new Command(commandData, this, i));
                }
                while (rom[dataOffset] != 0xD0 && rom[dataOffset] != 0xCD && rom[dataOffset] != 0xCE);
            }
        }
        public void WriteToROM(ref int offset)
        {
            // First, make sure each channel ends with a termination command
            for (int i = 0; i < 2; i++)
            {
                if (Channels[i] != null && Channels[i].Count > 0)
                {
                    var lastSSC = Channels[i][Channels[i].Count - 1];
                    if (lastSSC.Opcode != 0xD0 && lastSSC.Opcode != 0xCD && lastSSC.Opcode != 0xCE)
                        Channels[i].Add(new Command(new byte[] { 0xD0 }, this, 0));
                }
            }

            // Second, calculate total size of channels' binary data
            int channelSize1 = 0;
            int channelSize2 = 0;
            if (Channels[0] != null && ActiveChannels[0])
            {
                foreach (var ssc in Channels[0])
                    channelSize1 += ssc.Length;
            }
            if (Channels[1] != null && ActiveChannels[1])
            {
                foreach (var ssc in Channels[1])
                    channelSize2 += ssc.Length;
            }

            // Set starting offsets to write 
            int offsetStart1 = offset;
            int offsetStart2 = offset + channelSize1;
            if (Channels[0] == null || !ActiveChannels[0])
                offsetStart1 = 0;
            if (Channels[1] == null || !ActiveChannels[1])
                offsetStart2 = 0;

            // Iterate through commands of channels 1 and 2 and check if they are identical
            bool channel2in1 = true;
            if (offsetStart1 != 0 && offsetStart2 != 0 && channelSize2 <= channelSize1)
            {
                for (int a = Channels[0].Count - 1, b = Channels[1].Count - 1; a >= 0 && b >= 0; a--, b--)
                {
                    if (!Bits.Compare(Channels[0][a].Data, Channels[1][b].Data))
                        channel2in1 = false;
                }
            }
            else
                channel2in1 = false;

            // If channels 1 and 2 identical, change offset to start writing for channel 2
            if (channel2in1)
                offsetStart2 -= channelSize2;

            // Set pointers
            if (Type == 0)
            {
                if (offsetStart1 == 0)
                    Bits.SetShort(rom, Index * 4 + 0x042826, 0);
                else
                    Bits.SetShort(rom, Index * 4 + 0x042826, offsetStart1 - 0x042C26 + 0x3400);
                if (offsetStart2 == 0)
                    Bits.SetShort(rom, Index * 4 + 0x042826 + 2, 0);
                else
                    Bits.SetShort(rom, Index * 4 + 0x042826 + 2, offsetStart2 - 0x042C26 + 0x3400);
            }
            else
            {
                if (offsetStart1 == 0)
                    Bits.SetShort(rom, Index * 4 + 0x043E26, 0);
                else
                    Bits.SetShort(rom, Index * 4 + 0x043E26, offsetStart1 - 0x044226 + 0x3400);
                if (offsetStart2 == 0)
                    Bits.SetShort(rom, Index * 4 + 0x043E26 + 2, 0);
                else
                    Bits.SetShort(rom, Index * 4 + 0x043E26 + 2, offsetStart2 - 0x044226 + 0x3400);
            }

            // Finally, begin writing SPC's commands to ROM
            if (Channels[0] != null && ActiveChannels[0])
            {
                foreach (var ssc in Channels[0])
                {
                    Bits.SetBytes(rom, offsetStart1, ssc.Data);
                    offsetStart1 += ssc.Length;
                }
            }
            if (Channels[1] != null && ActiveChannels[1])
            {
                foreach (var ssc in Channels[1])
                {
                    Bits.SetBytes(rom, offsetStart2, ssc.Data);
                    offsetStart2 += ssc.Length;
                }
            }

            // Increase referenced offset parameter by size of binary data
            if (channel2in1)
                offset += channelSize1;
            else
                offset += channelSize1 + channelSize2;
        }

        // Inherited
        public override void WriteToROM()
        {
        }
        public override void CreateNotes()
        {
        }
        public override void Clear()
        {
            ActiveChannels = new bool[2];
            Channels = new List<Command>[2];
            Channels[0] = new List<Command>();
            Channels[1] = new List<Command>();
        }

        /// <summary>
        /// Returns the total size of the SPC's binary data.
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {
            int length = 0;
            // first make sure each channel ends with a termination command
            for (int i = 0; i < 2; i++)
            {
                if (Channels[i] != null && Channels[i].Count > 0)
                {
                    Command lastSSC = Channels[i][Channels[i].Count - 1];
                    if (lastSSC.Opcode != 0xD0 && lastSSC.Opcode != 0xCD && lastSSC.Opcode != 0xCE)
                        length++;
                }
            }
            //
            int channelSize1 = 0;
            int channelSize2 = 0;
            if (Channels[0] != null && ActiveChannels[0])
                foreach (var ssc in Channels[0])
                    channelSize1 += ssc.Length;
            if (Channels[1] != null && ActiveChannels[1])
                foreach (var ssc in Channels[1])
                    channelSize2 += ssc.Length;
            //
            bool channel2in1 = true;
            if (Channels[0] != null && Channels[1] != null &&
                ActiveChannels[0] && ActiveChannels[1] &&
                channelSize2 <= channelSize1)
            {
                for (int a = Channels[0].Count - 1, b = Channels[1].Count - 1; a >= 0 && b >= 0; a--, b--)
                {
                    if (!Bits.Compare(Channels[0][a].Data, Channels[1][b].Data))
                        channel2in1 = false;
                }
            }
            else
                channel2in1 = false;
            //
            if (channel2in1)
                length += channelSize1;
            else
                length += channelSize1 + channelSize2;
            return length;
        }

        #endregion
    }
}
