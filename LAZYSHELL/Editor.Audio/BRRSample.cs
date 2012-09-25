using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LAZYSHELL
{
    [Serializable()]
    public class BRRSample : Element
    {
        [NonSerialized()]
        private byte[] data;
        public override byte[] Data { get { return data; } set { data = value; } }
        private int index;
        public override int Index { get { return index; } set { index = value; } }
        private byte[] sample;
        public byte[] Sample { get { return sample; } set { sample = value; } }
        private int loopStart;
        public int LoopStart { get { return loopStart; } set { loopStart = value; } }
        private short relGain;
        public short RelGain { get { return relGain; } set { relGain = value; } }
        public short relFreq;
        public short RelFreq { get { return relFreq; } set { relFreq = value; } }
        public int Length
        {
            get
            {
                if (sample == null)
                    return 0;
                else return sample.Length;
            }
        }
        public BRRSample(byte[] data, int index)
        {
            this.data = data;
            this.index = index;
            int offset = Bits.Get24Bit(data, index * 3 + 0x042333);
            if (offset == 0) return;
            offset -= 0xC00000;
            int size = Bits.GetShort(data, offset); offset += 2;
            sample = Bits.GetByteArray(data, offset, size);
            loopStart = Bits.GetShort(data, index * 2 + 0x04248F);
            relGain = (short)Bits.GetShort(data, index * 2 + 0x042577);
            relFreq = (short)Bits.GetShort(data, index * 2 + 0x04265F);
        }
        public byte[] GetLoop()
        {
            if (sample == null || loopStart >= sample.Length)
                return sample;
            List<byte> loop = new List<byte>();
            int i = loopStart;
            for (; i < sample.Length; i++)
            {
                loop.Add(sample[i]);
            }
            while (i < sample.Length && loop.Count % 9 != 0)
                loop.Add(sample[i++]);
            return loop.ToArray();
        }
        public override void Clear()
        {
            if (sample != null)
                Array.Clear(sample, 0, sample.Length);
        }
        public void Assemble(ref int offset)
        {
            if (sample == null)
            {
                Bits.Set24Bit(data, index * 3 + 0x042333, 0);
                return;
            }
            Bits.Set24Bit(data, index * 3 + 0x042333, offset + 0xC00000);
            Bits.SetShort(data, offset, sample.Length); offset += 2;
            Bits.SetByteArray(data, offset, sample);
            offset += sample.Length;
            //
            Bits.SetShort(data, index * 2 + 0x04248F, loopStart);
            Bits.SetShort(data, index * 2 + 0x042577, relGain);
            Bits.SetShort(data, index * 2 + 0x04265F, relFreq);
        }
    }
}
