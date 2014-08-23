using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LAZYSHELL.Audio
{
    [Serializable()]
    public class BRRSample : Element
    {
        // ROM buffer
        private byte[] rom
        {
            get { return Model.ROM; }
            set { Model.ROM = value; }
        }

        // Index
        public override int Index { get; set; }

        // Properties
        public byte[] Sample { get; set; }
        public int LoopStart { get; set; }
        public short RelGain { get; set; }
        public short RelFreq { get; set; }
        public int Rate
        {
            get
            {
                double rate = 32000.0;
                double power = (double)RelFreq / 256.0 / 12.0;
                if (power >= 0)
                    rate *= Math.Pow(2.0, power);
                else
                    rate /= Math.Pow(2.0, -power);
                return (int)rate;
            }
        }
        public int Length
        {
            get
            {
                if (Sample == null)
                    return 0;
                else return Sample.Length;
            }
        }

        // Constructor
        public BRRSample(int index)
        {
            this.Index = index;
            ReadFromROM();
        }

        // Read/write ROM
        private void ReadFromROM()
        {
            int offset = Bits.GetInt24(rom, Index * 3 + 0x042333);
            if (offset == 0)
                return;
            offset -= 0xC00000;
            int size = Bits.GetShort(rom, offset); offset += 2;
            Sample = Bits.GetBytes(rom, offset, size);
            LoopStart = Bits.GetShort(rom, Index * 2 + 0x04248F);
            RelGain = (short)Bits.GetShort(rom, Index * 2 + 0x042577);
            RelFreq = (short)Bits.GetShort(rom, Index * 2 + 0x04265F);
        }
        public void WriteToROM(ref int offset)
        {
            if (Sample == null)
            {
                Bits.SetInt24(rom, Index * 3 + 0x042333, 0);
                return;
            }
            Bits.SetInt24(rom, Index * 3 + 0x042333, offset + 0xC00000);
            Bits.SetShort(rom, offset, Sample.Length); offset += 2;
            Bits.SetBytes(rom, offset, Sample);
            offset += Sample.Length;
            //
            Bits.SetShort(rom, Index * 2 + 0x04248F, LoopStart);
            Bits.SetShort(rom, Index * 2 + 0x042577, RelGain);
            Bits.SetShort(rom, Index * 2 + 0x04265F, RelFreq);
        }

        // Inherited
        public override void Clear()
        {
            if (Sample != null)
                Array.Clear(Sample, 0, Sample.Length);
        }
    }
}
