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
        private ushort sequenceOffset; public ushort SequenceOffset { get { return sequenceOffset; } set { sequenceOffset = value; } }

        // Frame properties
        public ushort FrameOffset { get { return frame.FrameOffset; } set { frame.FrameOffset = value; } }

        public byte Duration { get { return frame.Duration; } set { frame.Duration = value; } }
        public byte Mold { get { return frame.Mold; } set { frame.Mold = value; } }

        // Local
        private ArrayList frames = new ArrayList(); public ArrayList Frames { get { return this.frames; } set { this.frames = value; } }
        private ushort framePacketPointer; public ushort FramePacketPointer { get { return framePacketPointer; } set { framePacketPointer = value; } }

        private Frame frame;
        private int currentFrame;
        public int CurrentFrame
        {
            get
            {
                return this.currentFrame;
            }
            set
            {
                frame = (Frame)frames[value];
                this.currentFrame = value;
            }
        }
        public void AddNewFrame(int index, ushort newOffset)
        {
            Frame tFrame = new Frame();
            tFrame.FrameOffset = newOffset;
            tFrame.NullFrame();
            frames.Insert(index, tFrame);
        }
        public void RemoveCurrentFrame()
        {
            if (currentFrame < frames.Count)
            {
                frames.Remove(frames[currentFrame]);
                this.currentFrame = 0;
            }
        }
        public void MoveCurrentFrame(int index)
        {
            frames.Reverse(index, 2);
        }

        public void InitializeSequence(byte[] sm, int offset)
        {
            sequenceOffset = (ushort)offset;

            Frame tFrame;

            framePacketPointer = (ushort)(BitManager.GetShort(sm, offset) & 0x7FFF);

            offset = framePacketPointer;
            while (framePacketPointer != 0x7FFF && BitManager.GetByte(sm, offset) != 0)
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
            private ushort frameOffset; public ushort FrameOffset { get { return frameOffset; } set { frameOffset = value; } }

            private byte duration; public byte Duration { get { return duration; } set { duration = value; } }
            private byte mold; public byte Mold { get { return mold; } set { mold = value; } }

            public void InitializeFrame(byte[] sm, int offset)
            {
                frameOffset = (ushort)offset;

                duration = BitManager.GetByte(sm, offset);
                mold = BitManager.GetByte(sm, offset + 1);
            }

            public void NullFrame()
            {
                duration = 1;
                mold = 0;
            }
        }

        public void UpdateOffsets(short delta, int current)
        {
            if (framePacketPointer != 0x7FFF && framePacketPointer >= current)
                framePacketPointer = (ushort)(framePacketPointer + delta);

            foreach (Frame f in frames)
                if (f.FrameOffset >= current)
                    f.FrameOffset = (ushort)(f.FrameOffset + delta);
        }
    }
}
