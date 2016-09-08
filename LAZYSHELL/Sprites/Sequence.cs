using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LazyShell.Sprites
{
    [Serializable()]
    public class Sequence
    {
        #region Variables

        // Properties
        public bool Active { get; set; }
        public List<Frame> Frames { get; set; }

        #endregion

        // Read/write buffer
        public void ReadFromBuffer(byte[] buffer, int offset)
        {
            this.Frames = new List<Frame>();
            if (Bits.GetShort(buffer, offset) == 0xFFFF)
                return;
            Active = true;
            offset = (ushort)(Bits.GetShort(buffer, offset) & 0x7FFF);
            while (offset != 0x7FFF && buffer[offset] != 0)
            {
                var tFrame = new Frame();
                tFrame.ReadFromBuffer(buffer, offset);
                Frames.Add(tFrame);
                offset += 2;
            }
        }

        /// <summary>
        /// Creates an image collection from the molds used by this sequence
        /// in the order that they are referenced by the frames.
        /// </summary>
        /// <param name="animation">The animation containing the mold data.</param>
        /// <param name="durations">Will contain the durations of each frame in this sequence.</param>
        /// <returns></returns>
        public Bitmap[] GetSequenceImages(Animation animation, ref List<int> durations)
        {
            durations.Clear();
            List<Bitmap> croppedFrames = new List<Bitmap>();
            List<int[]> frames = new List<int[]>();
            Rectangle thisBounds = new Rectangle();
            //
            Point UL = new Point(256, 256);
            Point BR = new Point(0, 0);
            foreach (Sequence.Frame frame in this.Frames)
            {
                Rectangle bounds = new Rectangle(0, 0, 1, 1);
                if (frame.Mold < animation.Molds.Count)
                {
                    int[] pixels = animation.Molds[frame.Mold].MoldPixels();
                    animation.Molds[frame.Mold].MoldTilesPerPixel = null;
                    frames.Add(pixels);
                    durations.Add(frame.Duration * (1000 / 60));
                    bounds = Do.Crop(pixels, 256, 256);
                }
                // if the mold is empty
                if (bounds.X == 0 &&
                    bounds.Y == 0 &&
                    bounds.Width == 1 &&
                    bounds.Height == 1)
                    continue;
                if (bounds.X < UL.X)
                    UL.X = bounds.X;
                if (bounds.Y < UL.Y)
                    UL.Y = bounds.Y;
                if (bounds.X + bounds.Width > BR.X)
                    BR.X = bounds.X + bounds.Width;
                if (bounds.Y + bounds.Height > BR.Y)
                    BR.Y = bounds.Y + bounds.Height;
            }
            if (UL.X >= BR.X ||
                UL.Y >= BR.Y)
                return croppedFrames.ToArray();
            thisBounds.X = UL.X;
            thisBounds.Y = UL.Y;
            thisBounds.Width = BR.X - UL.X;
            thisBounds.Height = BR.Y - UL.Y;
            foreach (int[] pixels in frames)
            {
                int[] cropped = Do.GetPixelRegion(pixels, thisBounds, 256, 256);
                Bits.Fill(cropped, Color.FromArgb(127, 127, 127).ToArgb(), true);
                Bitmap imageCropped = Do.PixelsToImage(cropped, thisBounds.Width, thisBounds.Height);
                croppedFrames.Add(new Bitmap(imageCropped));
            }
            return croppedFrames.ToArray();
        }

        /// <summary>
        /// Creates a new blank sequence.
        /// </summary>
        /// <returns></returns>
        public Sequence New()
        {
            Sequence empty = new Sequence();
            empty.Frames = new List<Frame>();
            return empty;
        }
        /// <summary>
        /// Creates a deep copy of this instance.
        /// </summary>
        /// <returns></returns>
        public Sequence Copy()
        {
            Sequence copy = new Sequence();
            copy.Frames = new List<Frame>();
            foreach (Frame frame in this.Frames)
                copy.Frames.Add(frame.Copy());
            copy.Active = Active;
            return copy;
        }
        
        /// <summary>
        /// 
        /// </summary>
        [Serializable()]
        public class Frame
        {
            #region Variables

            public byte Duration { get; set; }
            public byte Mold { get; set; }

            #endregion

            // Read/write buffer
            public void ReadFromBuffer(byte[] buffer, int offset)
            {
                Duration = buffer[offset];
                Mold = buffer[offset + 1];
            }

            #region Methods

            /// <summary>
            /// Creates a new blank frame.
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
