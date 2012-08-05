using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    [Serializable()]
    public class Sequence
    {
        // Local
        private List<Frame> frames = new List<Frame>(); public List<Frame> Frames { get { return this.frames; } set { this.frames = value; } }
        private bool active; public bool Active { get { return this.active; } set { this.active = value; } }

        public void InitializeSequence(byte[] sm, int offset)
        {
            Frame tFrame;
            if (Bits.GetShort(sm, offset) == 0xFFFF)
                return;
            active = true;  //
            offset = (ushort)(Bits.GetShort(sm, offset) & 0x7FFF);
            while (offset != 0x7FFF && sm[offset] != 0)
            {
                tFrame = new Frame();
                tFrame.InitializeFrame(sm, offset);
                frames.Add(tFrame);
                offset += 2;
            }
        }

        [Serializable()]
        public class Frame
        {
            private byte duration; public byte Duration { get { return duration; } set { duration = value; } }
            private byte mold; public byte Mold { get { return mold; } set { mold = value; } }

            public void InitializeFrame(byte[] sm, int offset)
            {
                duration = sm[offset];
                mold = sm[offset + 1];
            }
            public Frame New()
            {
                Frame empty = new Frame();
                empty.Duration = 2;
                empty.Mold = 0;
                return empty;
            }
            public Frame Copy()
            {
                Frame copy = new Frame();
                copy.Duration = duration;
                copy.Mold = mold;
                return copy;
            }
        }
        public Sequence New()
        {
            Sequence empty = new Sequence();
            empty.Frames = new List<Frame>();
            return empty;
        }
        public Sequence Copy()
        {
            Sequence copy = new Sequence();
            copy.Frames = new List<Frame>();
            foreach (Frame frame in this.Frames)
                copy.Frames.Add(frame.Copy());
            copy.Active = active;
            return copy;
        }
    }
}
