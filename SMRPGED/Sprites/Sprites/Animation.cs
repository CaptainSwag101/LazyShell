using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace SMRPGED
{
    [Serializable()]
    public class Animation
    {
        private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }
        private byte[] sm; public byte[] SM { get { return sm; } set { sm = value; } }    // sequence mold data
        private int animationNum; public int AnimationNum { get { return animationNum; } set { animationNum = value; } }

        private int animationOffset; public int AnimationOffset { get { return animationOffset; } set { animationNum = value; } }

        private int animationLength; public int AnimationLength { get { return animationLength; } set { animationLength = value; } }
        private ushort sequencePacketPointer; public ushort SequencePacketPointer { get { return sequencePacketPointer; } set { sequencePacketPointer = value; } }
        private ushort moldPacketPointer; public ushort MoldPacketPointer { get { return moldPacketPointer; } set { moldPacketPointer = value; } }
        private byte sequenceCount = 0;
        private byte moldCount = 0;
        private ushort vramAllocation; public ushort VramAllocation { get { return vramAllocation; } set { vramAllocation = value; } }
        private ushort unknown;

        private ArrayList sequences = new ArrayList(); public ArrayList Sequences { get { return sequences; } set { sequences = value; } }
        private ArrayList molds = new ArrayList(); public ArrayList Molds { get { return molds; } set { molds = value; } }

        public ArrayList Frames { get { return sequence.Frames; } set { sequence.Frames = value; } }
        public ArrayList Tiles { get { return mold.Tiles; } set { mold.Tiles = value; } }
        public ArrayList Copies { get { return mold.Copies; } set { mold.Copies = value; } }

        // Sequences...
        private Sequence sequence;
        private int currentSequence;
        public int CurrentSequence
        {
            get
            {
                return this.currentSequence;
            }
            set
            {
                sequence = (Sequence)sequences[value];
                this.currentSequence = value;
            }
        }
        public int CurrentFrame { get { return sequence.CurrentFrame; } set { sequence.CurrentFrame = value; } }
        public void AddNewSequence(int index, ushort newOffset)
        {
            Sequence tSequence = new Sequence();
            Sequence zSequence = (Sequence)sequences[index - 1];    // for setting an initial framePacketPointer
            tSequence.SequenceOffset = newOffset;
            tSequence.FramePacketPointer = (ushort)(zSequence.FramePacketPointer + (zSequence.Frames.Count * 2) + 1);
            sequences.Insert(index, tSequence);
        }
        public void RemoveCurrentSequence()
        {
            if (currentSequence < sequences.Count)
            {
                sequences.Remove(sequences[currentSequence]);
                this.currentSequence = 0;
            }
        }
        public void AddNewFrame(int index, ushort newOffset)
        {
            sequence.AddNewFrame(index, newOffset);
        }
        public void RemoveCurrentFrame()
        {
            sequence.RemoveCurrentFrame();
        }
        public void MoveCurrentFrame(int index)
        {
            sequence.MoveCurrentFrame(index);
        }

        public ushort SequenceOffset { get { return sequence.SequenceOffset; } set { sequence.SequenceOffset = value; } }
        public ushort FramePacketPointer { get { return sequence.FramePacketPointer; } set { sequence.FramePacketPointer = value; } }

        // Frame properties
        public ushort FrameOffset { get { return sequence.FrameOffset; } set { sequence.FrameOffset = value; } }

        public byte Duration { get { return sequence.Duration; } set { sequence.Duration = value; } }
        public byte FrameMold { get { return sequence.Mold; } set { sequence.Mold = value; } }

        // Molds...
        private Mold mold;
        private int currentMold;
        public int CurrentMold
        {
            get
            {
                return this.currentMold;
            }
            set
            {
                mold = (Mold)molds[value];
                this.currentMold = value;
            }
        }
        public int CurrentTile { get { return mold.CurrentTile; } set { mold.CurrentTile = value; } }
        public int CurrentCopy { get { return mold.CurrentCopy; } set { mold.CurrentCopy = value; } }
        public void AddNewMold(int index, ushort newOffset)
        {
            Mold tMold = new Mold();
            Mold zMold = (Mold)molds[index - 1];
            tMold.MoldOffset = newOffset;
            tMold.TilePacketPointer = (ushort)(zMold.TilePacketPointer + zMold.MoldSize + 1);
            molds.Insert(index, tMold);
        }
        public void RemoveCurrentMold()
        {
            if (currentMold < molds.Count)
            {
                molds.Remove(molds[currentMold]);
                this.currentMold = 0;
            }
        }
        public void AddNewTile(int index, ushort newOffset)
        {
            mold.AddNewTile(index, newOffset);
        }
        public void RemoveCurrentTile()
        {
            mold.RemoveCurrentTile();
        }
        public void AddNewCopies(int offset)
        {
            mold.AddNewCopies(sm, offset);
        }
        public void RemoveCurrentCopy()
        {
            mold.RemoveCurrentCopy();
        }

        // Mold Properties
        public ushort MoldOffset { get { return mold.MoldOffset; } set { mold.MoldOffset = value; } }
        public bool Gridplane { get { return mold.Gridplane; } set { mold.Gridplane = value; } }
        public ushort TilePacketPointer { get { return mold.TilePacketPointer; } set { mold.TilePacketPointer = value; } }
        public int MoldSize { get { return mold.MoldSize; } }

        // Tile properties
        public ushort TileOffset { get { return mold.TileOffset; } set { mold.TileOffset = value; } }
        public int TileSize { get { return mold.TileSize; } set { mold.TileSize = value; } }

        public byte TileFormat { get { return mold.TileFormat; } set { mold.TileFormat = value; } }
        public bool[] Quadrants { get { return mold.Quadrants; } set { mold.Quadrants = value; } }
        public Tile8x8[] Subtiles { get { return mold.Subtiles; } }
        public ushort[] SubTiles { get { return mold.SubTiles; } set { mold.SubTiles = value; } }

        public byte XCoord { get { return mold.XCoord; } set { mold.XCoord = value; } }
        public byte YCoord { get { return mold.YCoord; } set { mold.YCoord = value; } }
        public byte XCoordChange { get { return mold.XCoordChange; } set { mold.XCoordChange = value; } }
        public byte YCoordChange { get { return mold.YCoordChange; } set { mold.YCoordChange = value; } }
        public byte CopyAmount { get { return mold.CopyAmount; } set { mold.CopyAmount = value; } }
        public ushort CopyPacketOffset { get { return mold.CopyPacketOffset; } set { mold.CopyPacketOffset = value; } }

        public bool Is16bit { get { return mold.Is16bit; } set { mold.Is16bit = value; } }
        public ushort Subtile16bit { get { return mold.Subtiles16bit; } set { mold.Subtiles16bit = value; } }
        public bool Mirror { get { return mold.Mirror; } set { mold.Mirror = value; } }
        public bool Invert { get { return mold.Invert; } set { mold.Invert = value; } }
        public byte YPlusOne { get { return mold.YPlusOne; } set { mold.YPlusOne = value; } }
        public byte YMinusOne { get { return mold.YMinusOne; } set { mold.YMinusOne = value; } }

        public void Set8x8Tiles(byte[] graphics, int[] palette, bool gridplane)
        {
            mold.Set8x8Tiles(graphics, palette, gridplane);
        }
        public int[] MoldPixels(bool box) { return mold.MoldPixels(box); }
        public int[] TilesetPixels { get { return mold.TilesetPixels(); } }
        public int[] TilePixels { get { return mold.TilePixels; } }
        public int[] SubtilePixels(int num) { return mold.SubtilePixels(num); }

        // Start
        public Animation(byte[] data, int animationNum)
        {
            this.data = data;
            this.animationNum = animationNum;

            InitializeAnimationOffset(data);
        }
        public void Refresh()
        {
            animationLength = sm.Length;

            sequences = new ArrayList();
            molds = new ArrayList();
            
            Sequence tSequence;
            Mold tMold;
            
            int offset = 2;
            sequencePacketPointer = BitManager.GetShort(sm, offset); offset += 2;
            moldPacketPointer = BitManager.GetShort(sm, offset); offset += 2;
            sequenceCount = BitManager.GetByte(sm, offset); offset++;
            moldCount = BitManager.GetByte(sm, offset); offset++;
            vramAllocation = (ushort)(BitManager.GetByte(sm, offset) << 8); offset += 2;
            unknown = BitManager.GetShort(sm, offset);

            offset = sequencePacketPointer;
            for (int i = 0; i < sequenceCount; i++)
            {
                tSequence = new Sequence();
                tSequence.InitializeSequence(sm, offset);
                sequences.Add(tSequence);
                offset += 2;
            }

            offset = moldPacketPointer;
            for (int i = 0; i < moldCount; i++)
            {
                tMold = new Mold();
                tMold.InitializeMold(sm, offset);
                molds.Add(tMold);
                offset += 2;
            }
        }
        private void InitializeAnimationOffset(byte[] data)
        {
            Sequence tSequence;
            Mold tMold;

            animationOffset = BitManager.Get24Bit(data, 0x252000 + (animationNum * 3)) - 0xC00000;
            animationLength = BitManager.GetShort(data, animationOffset);

            sm = BitManager.GetByteArray(data, animationOffset, animationLength);

            int offset = 2;
            sequencePacketPointer = BitManager.GetShort(sm, offset); offset += 2;
            moldPacketPointer = BitManager.GetShort(sm, offset); offset += 2;
            sequenceCount = BitManager.GetByte(sm, offset); offset++;
            moldCount = BitManager.GetByte(sm, offset); offset++;
            vramAllocation = (ushort)(BitManager.GetByte(sm, offset) << 8); offset += 2;
            unknown = BitManager.GetShort(sm, offset);

            offset = sequencePacketPointer;
            for (int i = 0; i < sequenceCount; i++)
            {
                tSequence = new Sequence();
                tSequence.InitializeSequence(sm, offset);
                sequences.Add(tSequence);
                offset += 2;
            }

            offset = moldPacketPointer;
            for (int i = 0; i < moldCount; i++)
            {
                tMold = new Mold();
                tMold.InitializeMold(sm, offset);
                molds.Add(tMold);
                offset += 2;
            }
        }
        public void UpdateOffsets(short delta, int current)
        {
            // write to files to compare when debugging
            //Stream smOld = File.Create("smOld.dat");
            //smOld.Write(sm, 0, sm.Length);
            //smOld.Close();

            animationLength += delta;

            foreach (Sequence s in sequences)
                s.UpdateOffsets(delta, current);

            if (moldPacketPointer >= current)
                moldPacketPointer = (ushort)(moldPacketPointer + delta);

            foreach (Mold m in molds)
                m.UpdateOffsets(delta, current);
        }
        public void Assemble() // assemble data to byte[] sm
        {
            // reset the length
            byte[] temp = new byte[animationLength];
            for (int i = 0; i < temp.Length && i < sm.Length; i++)
                temp[i] = sm[i];
            sm = new byte[animationLength];
            for (int i = 0; i < temp.Length && i < sm.Length; i++)
                sm[i] = temp[i];

            // Start assembly
            int offset = 0;
            BitManager.SetShort(sm, offset, (ushort)animationLength); offset += 2;
            BitManager.SetShort(sm, offset, sequencePacketPointer); offset += 2;
            BitManager.SetShort(sm, offset, moldPacketPointer); offset += 2;
            sequenceCount = 0;
            moldCount = 0;
            int sOffset = sequencePacketPointer;
            foreach (Sequence s in sequences)
            {
                sequenceCount++;

                if (s.FramePacketPointer != 0x7FFF)
                {
                    BitManager.SetShort(sm, sOffset, s.FramePacketPointer); sOffset += 2;

                    int fOffset = s.FramePacketPointer;
                    foreach (Sequence.Frame f in s.Frames)
                    {
                        BitManager.SetByte(sm, fOffset, f.Duration); fOffset++;
                        BitManager.SetByte(sm, fOffset, f.Mold); fOffset++;
                    }
                    BitManager.SetByte(sm, fOffset, 0);
                }
                else
                {
                    BitManager.SetShort(sm, sOffset, 0xFFFF);
                    sOffset += 2;
                }
            }
            // make sure the last sequence is normally followed by 0x0000
            if (((Sequence)sequences[0]).FramePacketPointer != sOffset)
                BitManager.SetShort(sm, sOffset, 0);

            int mOffset = moldPacketPointer;
            foreach (Mold m in molds)
            {
                moldCount++;

                if (m.TilePacketPointer != 0x7FFF)
                {
                    BitManager.SetShort(sm, mOffset, m.TilePacketPointer); mOffset++;
                    BitManager.SetBit(sm, mOffset, 7, m.Gridplane); mOffset++;

                    int tOffset = m.TilePacketPointer & 0x7FFF;
                    foreach (Mold.Tile t in m.Tiles)
                    {
                        if (m.Gridplane)
                        {
                            BitManager.SetByte(sm, tOffset, t.TileFormat);
                            BitManager.SetBit(sm, tOffset, 3, t.Is16bit);
                            BitManager.SetBit(sm, tOffset, 4, t.YPlusOne == 1);
                            BitManager.SetBit(sm, tOffset, 5, t.YMinusOne == 1);
                            BitManager.SetBit(sm, tOffset, 6, t.Mirror);
                            BitManager.SetBit(sm, tOffset, 7, t.Invert);
                            tOffset++;
                            if (t.Is16bit)
                            {
                                for (int i = 0; i < 8; i++)
                                {
                                    if (t.SubTiles[i] > 255)
                                        BitManager.SetBit(sm, tOffset, i, true);
                                    else
                                        BitManager.SetBit(sm, tOffset, i, false);
                                }
                                tOffset++;
                                for (int i = 0; i < 8; i++)
                                {
                                    if (t.SubTiles[i + 8] > 255)
                                        BitManager.SetBit(sm, tOffset, i, true);
                                    else
                                        BitManager.SetBit(sm, tOffset, i, false);
                                }
                                tOffset++;

                                for (int i = 0; i < t.TileSize - 3; i++)
                                {
                                    BitManager.SetByte(sm, tOffset, (byte)t.SubTiles[i]);
                                    tOffset++;
                                }
                            }
                            else
                            {
                                for (int i = 0; i < t.TileSize - 1; i++)
                                {
                                    BitManager.SetByte(sm, tOffset, (byte)t.SubTiles[i]);
                                    tOffset++;
                                }
                            }
                        }
                        else
                        {
                            BitManager.SetByte(sm, tOffset, t.TileFormat);
                            if (t.TileFormat == 2)
                            {
                                sm[tOffset] &= 0x0F;
                                sm[tOffset] |= (byte)(t.CopyAmount << 4);
                                BitManager.SetBit(sm, tOffset, 2, t.Mirror);
                                BitManager.SetBit(sm, tOffset, 3, t.Invert);
                                tOffset++;
                                BitManager.SetByte(sm, tOffset, t.YCoordChange); tOffset++;
                                BitManager.SetByte(sm, tOffset, t.XCoordChange); tOffset++;
                                BitManager.SetShort(sm, tOffset, t.CopyPacketOffset); tOffset += 2;
                            }
                            else
                            {
                                for (int i = 0, b = 7; i < 4; i++, b--)
                                    BitManager.SetBit(sm, tOffset, b, t.Quadrants[i]);
                                BitManager.SetBit(sm, tOffset, 2, t.Mirror);
                                BitManager.SetBit(sm, tOffset, 3, t.Invert);
                                tOffset++;

                                BitManager.SetByte(sm, tOffset, (byte)(t.YCoord ^ 0x80)); tOffset++;
                                BitManager.SetByte(sm, tOffset, (byte)(t.XCoord ^ 0x80)); tOffset++;

                                if (t.TileFormat == 1)
                                {
                                    for (int i = 0; i < 4; i++)
                                    {
                                        if (t.Quadrants[i])
                                        {
                                            BitManager.SetShort(sm, tOffset, t.SubTiles[i]);
                                            tOffset += 2;
                                        }
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < 4; i++)
                                    {
                                        if (t.Quadrants[i])
                                        {
                                            BitManager.SetByte(sm, tOffset, (byte)t.SubTiles[i]);
                                            tOffset++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (!m.Gridplane)
                    {
                        if (tOffset < sm.Length)
                            BitManager.SetByte(sm, tOffset, 0);
                    }
                }
                else
                {
                    BitManager.SetShort(sm, mOffset, 0xFFFF);
                    mOffset += 2;
                }

                if (mOffset < sm.Length)
                    BitManager.SetByte(sm, mOffset, 0);
            }
            // make sure the last sequence is normally followed by 0x0000
            if (((Mold)molds[0]).TilePacketPointer != mOffset)
                BitManager.SetShort(sm, mOffset, 0);

            BitManager.SetShort(sm, offset, sequenceCount); offset++;
            BitManager.SetShort(sm, offset, moldCount); offset++;
            BitManager.SetShort(sm, offset, (ushort)(vramAllocation >> 8)); offset += 2;
            BitManager.SetShort(sm, offset, 2); offset += 2;

            // write to files to compare when debugging
            //Stream smNew = File.Create("smNew.dat");
            //smNew.Write(sm, 0, sm.Length);
            //smNew.Close();
        }
        public void ResetCopies()   // reset tiles with copies when other tile modified
        {
            foreach (Mold m in molds)
            {
                foreach (Mold.Tile t in m.Tiles)
                {
                    if (t.TileFormat == 2)
                    {
                        t.Copies = new ArrayList();
                        int offset = t.CopyPacketOffset;
                        for (int i = 0; i < t.CopyAmount; i++)
                        {
                            Mold.Tile tTile = new Mold.Tile();
                            tTile.InitializeTile(sm, offset, m.Gridplane, i, t.Mirror, t.Invert);
                            t.Copies.Add(tTile);
                            offset += 3;
                            if (tTile.TileFormat == 2)
                                offset += 2;
                            else if (tTile.TileFormat == 1)
                            {
                                for (int j = 0; j < 4; j++)
                                    if (tTile.Quadrants[j]) offset += 2;
                            }
                            else
                            {
                                for (int j = 0; j < 4; j++)
                                    if (tTile.Quadrants[j]) offset++;
                            }
                        }
                    }
                }
            }
        }

        public void Clear()
        {
            ushort currentSequenceOffset;
            ushort currentFrameOffset;
            ushort currentMoldOffset;
            ushort currentTileOffset;
            short delta = 0;
            for (int i = sequences.Count - 1; i >= 0; i--)
            {
                CurrentSequence = i;
                currentSequenceOffset = SequenceOffset;
                for (int a = Frames.Count - 1; a > 0; a--)
                {
                    CurrentFrame = a;
                    currentFrameOffset = FrameOffset;
                    delta = -2;
                    RemoveCurrentFrame();
                    UpdateOffsets(delta, currentFrameOffset);
                }
                if (i == 0) break;
                delta = -2;
                RemoveCurrentSequence();
                UpdateOffsets(delta, currentSequenceOffset);
            }
            for (int i = molds.Count - 1; i >= 0; i--)
            {
                CurrentMold = i;
                currentMoldOffset = MoldOffset;
                for (int a = Tiles.Count - 1; a > 0; a--)
                {
                    CurrentTile = a;
                    currentTileOffset = TileOffset;
                    delta = 0;
                    delta -= (short)TileSize;
                    RemoveCurrentTile();
                    UpdateOffsets(delta, currentTileOffset);
                }
                if (i == 0) break;
                delta = -2;
                RemoveCurrentMold();
                UpdateOffsets(delta, currentMoldOffset);
            }
        }
    }
}
