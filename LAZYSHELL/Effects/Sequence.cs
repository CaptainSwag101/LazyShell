using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LazyShell.Effects
{
    [Serializable()]
    public class Sequence
    {
        /// <summary>
        /// The sequence's frame collection.
        /// </summary>
        public List<Frame> Frames { get; set; }

        /// <summary>
        /// Builds this sequence's frame collection from the source buffer data of the animation.
        /// </summary>
        /// <param name="buffer">The source buffer data referenced from the animation.</param>
        /// <param name="offset">The offset of this sequence's data in the source buffer.</param>
        public void ReadFromBuffer(byte[] buffer, int offset)
        {
            this.Frames = new List<Frame>();
            offset = Bits.GetShort(buffer, offset);
            while (offset != 0xFFFF && buffer[offset] != 0)
            {
                var frame = new Frame();
                frame.ReadFromBuffer(buffer, offset);
                this.Frames.Add(frame);
                offset += 2;
            }
        }

        [Serializable()]
        public class Frame
        {
            #region Variables

            // Properties
            public byte Duration { get; set; }
            public byte Mold { get; set; }
            
            #endregion

            #region Methods

            /// <summary>
            /// Reads this frame's properties from the parent effect animation's binary data.
            /// </summary>
            /// <param name="buffer">The parent effect animation's binary data referenced by this instance.</param>
            /// <param name="offset">The offset of this frame's data in the parent effect animation's binary data.</param>
            public void ReadFromBuffer(byte[] buffer, int offset)
            {
                Duration = buffer[offset];
                Mold = buffer[offset + 1];
            }
            /// <summary>
            /// Creates a new frame instance.
            /// </summary>
            /// <returns></returns>
            public Frame New()
            {
                Frame empty = new Frame();
                empty.Duration = 2;
                empty.Mold = 0;
                return empty;
            }
            /// <summary>
            /// Creates a deep copy of this instance.
            /// </summary>
            /// <returns></returns>
            public Frame Copy()
            {
                Frame copy = new Frame();
                copy.Duration = Duration;
                copy.Mold = Mold;
                return copy;
            }
            
            #endregion
        }
    }
}
