using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    [Serializable()]
    public class E_Animation
    {
        private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }
        private byte[] sm; public byte[] SM { get { return sm; } set { sm = value; } }    // sequence mold data
        private int animationNum; public int AnimationNum { get { return animationNum; } set { animationNum = value; } }

        private int animationOffset; public int AnimationOffset { get { return animationOffset; } set { animationNum = value; } }

        private ushort animationLength; public ushort AnimationLength { get { return animationLength; } set { animationLength = value; } }
        private ushort graphicSetPointer; public ushort GraphicSetPointer { get { return graphicSetPointer; } }
        private ushort paletteSetPointer; public ushort PaletteSetPointer { get { return paletteSetPointer; } }
        private ushort sequencePacketPointer; public ushort SequencePacketPointer { get { return sequencePacketPointer; } set { sequencePacketPointer = value; } }  // top pointer to the set of sequences
        private ushort moldPacketPointer; public ushort MoldPacketPointer { get { return moldPacketPointer; } set { moldPacketPointer = value; } } // top pointer to the set of molds

        private byte moldsWidth; public byte MoldsWidth { get { return moldsWidth; } set { moldsWidth = value; } }
        private byte moldsHeight; public byte MoldsHeight { get { return moldsHeight; } set { moldsHeight = value; } }

        private ushort codec; public ushort Codec { get { return codec; } set { codec = value; } }

        private ushort tileSetPointer; public ushort TileSetPointer { get { return tileSetPointer; } }

        private ArrayList sequences = new ArrayList(); public ArrayList Sequences { get { return sequences; } set { sequences = value; } }
        private ArrayList molds = new ArrayList(); public ArrayList Molds { get { return molds; } set { molds = value; } }

        public ArrayList Frames { get { return sequence.Frames; } set { sequence.Frames = value; } }
        public ArrayList Tiles { get { return mold.Tiles; } set { mold.Tiles = value; } }

        // Tileset
        private int tileSetLength; public int TileSetLength { get { return tileSetLength; } set { tileSetLength = value; } }
        private E_Tileset tileset; public E_Tileset Tileset { get { return tileset; } set { tileset = value; } }

        // Graphics
        private byte[] graphicSet;
        public byte[] GraphicSet
        {
            get { return graphicSet; }
            set
            {
                graphicSet = value;
                for (int i = 0; i < graphicSet.Length && i < graphicSetBuffer.Length; i++)
                    graphicSetBuffer[i] = graphicSet[i];
            }
        }
        private byte[] graphicSetBuffer; public byte[] GraphicSetBuffer { get { return graphicSetBuffer; } }

        private int graphicSetLength;
        public int GraphicSetLength
        {
            get { return graphicSetLength; }
            set
            {
                int delta = value - graphicSet.Length;
                byte[] temp = new byte[graphicSet.Length + delta];
                for (int i = 0; i < temp.Length && i < graphicSetBuffer.Length; i++)
                    temp[i] = graphicSetBuffer[i];
                graphicSet = temp;

                graphicSetLength = value;
            }
        }

        // Palettes
        private ushort paletteSetLength; public ushort PaletteSetLength { get { return paletteSetLength; } set { paletteSetLength = value; } }
        private int[] paletteColorRed = new int[16 * 8]; public int[] PaletteColorRed { get { return paletteColorRed; } set { paletteColorRed = value; } }
        private int[] paletteColorGreen = new int[16 * 8]; public int[] PaletteColorGreen { get { return paletteColorGreen; } set { paletteColorGreen = value; } }
        private int[] paletteColorBlue = new int[16 * 8]; public int[] PaletteColorBlue { get { return paletteColorBlue; } set { paletteColorBlue = value; } }

        // Sequences
        private E_Sequence sequence;
        private int currentSequence;
        public int CurrentSequence
        {
            get
            {
                return this.currentSequence;
            }
            set
            {
                sequence = (E_Sequence)sequences[value];
                this.currentSequence = value;
            }
        }
        public int CurrentFrame { get { return sequence.CurrentFrame; } set { sequence.CurrentFrame = value; } }
        public void AddNewSequence(int index, ushort newOffset)
        {
            E_Sequence tSequence = new E_Sequence();
            E_Sequence zSequence = (E_Sequence)sequences[0];    // for setting an initial framePacketPointer
            tSequence.SequenceOffset = newOffset;
            tSequence.FramePacketPointer = zSequence.FramePacketPointer;
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
        private E_Mold mold;
        private int currentMold;
        public int CurrentMold
        {
            get
            {
                return this.currentMold;
            }
            set
            {
                mold = (E_Mold)molds[value];
                this.currentMold = value;
            }
        }
        public int CurrentTile { get { return mold.CurrentTile; } set { mold.CurrentTile = value; } }
        public void AddNewMold(int index, ushort newOffset)
        {
            E_Mold tMold = new E_Mold();
            E_Mold zMold = (E_Mold)molds[index - 1];
            tMold.MoldOffset = newOffset;
            tMold.TilePacketPointer = (ushort)(zMold.TilePacketPointer + zMold.MoldSize);
            molds.Insert(index, tMold);

            //mold = (E_Mold)molds[index];
            //currentMold = index;

            //AddNewTile(0, tMold.TilePacketPointer);
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
        public void MoveCurrentTile(int index)
        {
            mold.MoveCurrentTile(index);
        }

        // Mold Properties
        public ushort MoldOffset { get { return mold.MoldOffset; } set { mold.MoldOffset = value; } }
        public ushort TilePacketPointer { get { return mold.TilePacketPointer; } set { mold.TilePacketPointer = value; } }
        public int MoldSize { get { return mold.MoldSize; } }

        // Tile properties
        public ushort TileOffset { get { return mold.TileOffset; } set { mold.TileOffset = value; } }

        public byte TileIndex { get { return mold.TileIndex; } set { mold.TileIndex = value; } }
        public bool Filler { get { return mold.Filler; } set { mold.Filler = value; } }
        public byte FillAmount { get { return mold.FillAmount; } set { mold.FillAmount = value; } }
        public bool Empty { get { return mold.Empty; } set { mold.Empty = value; } }
        public bool Mirrored { get { return mold.Mirrored; } set { mold.Mirrored = value; } }
        public bool Inverted { get { return mold.Inverted; } set { mold.Inverted = value; } }

        public int[] MoldPixels(E_Animation animation, E_Tileset tileset, bool box)
        {
            return mold.MoldPixels(animation, tileset, box);
        }

        // Start
        public E_Animation(byte[] data, int animationNum)
        {
            this.data = data;
            this.animationNum = animationNum;

            InitializeAnimationOffset(data);
        }
        public void Refresh()
        {
            sequences = new ArrayList();
            molds = new ArrayList();

            E_Sequence tSequence;
            E_Mold tMold;

            animationLength = (ushort)sm.Length;

            sm = BitManager.GetByteArray(data, animationOffset, animationLength);

            int offset = 2;
            graphicSetPointer = BitManager.GetShort(sm, offset); offset += 2;
            paletteSetPointer = BitManager.GetShort(sm, offset); offset += 2;
            sequencePacketPointer = BitManager.GetShort(sm, offset); offset += 2;
            moldPacketPointer = BitManager.GetShort(sm, offset); offset += 2;

            /** here are two unknown bytes, we'll just skip them **/
            offset += 2;

            moldsWidth = sm[offset]; offset++;
            moldsHeight = sm[offset]; offset++;

            codec = BitManager.GetShort(sm, offset); offset += 2;

            tileSetPointer = BitManager.GetShort(sm, offset);

            graphicSet = new byte[paletteSetPointer - graphicSetPointer];
            graphicSetBuffer = new byte[0x2000];
            Buffer.BlockCopy(sm, graphicSetPointer, graphicSetBuffer, 0, graphicSet.Length);
            Buffer.BlockCopy(sm, graphicSetPointer, graphicSet, 0, graphicSet.Length);

            graphicSetLength = graphicSet.Length;
            paletteSetLength = (ushort)(tileSetPointer - paletteSetPointer);

            InitializePaletteSet(sm, paletteSetPointer);

            tileSetLength = sequencePacketPointer - tileSetPointer - 2;

            offset = sequencePacketPointer;
            for (int i = 0; BitManager.GetShort(sm, offset) != 0x0000; i++)
            {
                tSequence = new E_Sequence();
                tSequence.InitializeSequence(sm, offset);
                sequences.Add(tSequence);
                offset += 2;
            }

            offset = moldPacketPointer;
            ushort end = 0;
            for (int i = 0; BitManager.GetShort(sm, offset) != 0x0000; i++)
            {
                if (BitManager.GetShort(sm, offset + 2) == 0x0000)
                    end = animationLength;
                else
                    end = BitManager.GetShort(sm, offset + 2);

                tMold = new E_Mold();
                tMold.InitializeMold(sm, offset, end);
                molds.Add(tMold);
                offset += 2;
            }
        }
        private void InitializeAnimationOffset(byte[] data)
        {
            E_Sequence tSequence;
            E_Mold tMold;

            animationOffset = BitManager.Get24Bit(data, 0x252C00 + (animationNum * 3)) - 0xC00000;
            animationLength = BitManager.GetShort(data, animationOffset);

            sm = BitManager.GetByteArray(data, animationOffset, animationLength);

            int offset = 2;
            graphicSetPointer = BitManager.GetShort(sm, offset); offset += 2;
            paletteSetPointer = BitManager.GetShort(sm, offset); offset += 2;
            sequencePacketPointer = BitManager.GetShort(sm, offset); offset += 2;
            moldPacketPointer = BitManager.GetShort(sm, offset); offset += 2;

            /** here are two unknown bytes, we'll just skip them **/
            offset += 2;

            moldsWidth = sm[offset]; offset++;
            moldsHeight = sm[offset]; offset++;

            codec = BitManager.GetShort(sm, offset); offset += 2;

            tileSetPointer = BitManager.GetShort(sm, offset);

            graphicSet = new byte[paletteSetPointer - graphicSetPointer];
            graphicSetBuffer = new byte[0x2000];
            Buffer.BlockCopy(sm, graphicSetPointer, graphicSetBuffer, 0, graphicSet.Length);
            Buffer.BlockCopy(sm, graphicSetPointer, graphicSet, 0, graphicSet.Length);

            graphicSetLength = graphicSet.Length;
            paletteSetLength = (ushort)(tileSetPointer - paletteSetPointer);

            InitializePaletteSet(sm, paletteSetPointer);

            tileSetLength = sequencePacketPointer - tileSetPointer - 2;

            offset = sequencePacketPointer;
            for (int i = 0; BitManager.GetShort(sm, offset) != 0x0000; i++)
            {
                tSequence = new E_Sequence();
                tSequence.InitializeSequence(sm, offset);
                sequences.Add(tSequence);
                offset += 2;
            }

            offset = moldPacketPointer;
            ushort end = 0;
            for (int i = 0; BitManager.GetShort(sm, offset) != 0x0000; i++)
            {
                if (BitManager.GetShort(sm, offset + 2) == 0x0000)
                    end = animationLength;
                else
                    end = BitManager.GetShort(sm, offset + 2);

                tMold = new E_Mold();
                tMold.InitializeMold(sm, offset, end);
                molds.Add(tMold);
                offset += 2;
            }
        }
        private void InitializePaletteSet(byte[] sm, int offset)
        {
            ushort color = 0;

            for (int y = 0; y < paletteSetLength / 32; y++)
            {
                for (int x = 0; x < 16; x++) // 16 colors in palette
                {
                    color = BitManager.GetShort(sm, (x * 2) + (y * 32) + paletteSetPointer);

                    paletteColorRed[(y * 16) + x] = (byte)((color % 0x20) * 8);
                    paletteColorGreen[(y * 16) + x] = (byte)(((color >> 5) % 0x20) * 8);
                    paletteColorBlue[(y * 16) + x] = (byte)(((color >> 10) % 0x20) * 8);
                }
            }
        }

        // drawing
        public int[] GetPaletteSet(int paletteIndex)
        {
            int[] temp = new int[16];
            int o = paletteIndex * 16;

            // read the 16 colors
            for (int i = 0; i < 16; i++)
                temp[i] = Color.FromArgb(255, paletteColorRed[i + o], paletteColorGreen[i + o], paletteColorBlue[i + o]).ToArgb();

            return temp;
        }
        public int[] GetPaletteSetPixels()
        {
            int[] paletteSetPixels = new int[256 * 128];

            for (int i = 0; i < paletteSetLength / 32; i++)
            {
                for (int j = 0; j < 16; j++) // 16 palette blocks wide
                {
                    for (int y = 0; y < 16; y++)
                    {
                        for (int x = 0; x < 16; x++)
                            paletteSetPixels[x + (j * 16) + ((y + (i * 16)) * 256)] = Color.FromArgb(255, paletteColorRed[j + (i * 16)], paletteColorGreen[j + (i * 16)], paletteColorBlue[j + (i * 16)]).ToArgb();
                    }
                }
            }
            for (int y = 0; y < paletteSetLength / 2; y += 16)  // draw the horizontal gridlines
            {
                for (int x = 0; x < 256; x++)
                    paletteSetPixels[y * 256 + x] = Color.Black.ToArgb();
                if (y == 0) y--;
            }
            for (int x = 0; x < 256; x += 16) // draw the vertical gridlines
            {
                for (int y = 0; y < paletteSetLength / 2; y++)
                    paletteSetPixels[y * 256 + x] = Color.Black.ToArgb();
                if (x == 0) x--;
            }

            return paletteSetPixels;
        }
        public int[] GetGraphicPixels(int paletteIndex)
        {
            int tileSize = codec == 1 ? 0x10 : 0x20;

            Tile8x8 temp;
            int[] pixels = new int[128 * 128];
            int offset;
            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    offset = (y * 16 + x) * tileSize;
                    if (offset + tileSize > graphicSetLength)
                        return pixels;

                    temp = new Tile8x8(y * 16 + x, graphicSet, offset, GetPaletteSet(paletteIndex), false, false, false, codec == 1);
                    CopyOverTile8x8(temp, pixels, 128, x, y);
                }
            }
            return pixels;
        }
        private void CopyOverTile8x8(Tile8x8 source, int[] dest, int destinationWidth, int x, int y)
        {
            x *= 8;
            y *= 8;

            int[] src = source.Pixels;
            int counter = 0;
            for (int i = 0; i < 64; i++)
            {
                dest[y * destinationWidth + x + counter] = src[i];
                counter++;
                if (counter % 8 == 0)
                {
                    y++;
                    counter = 0;
                }
            }
        }

        // updating / assembling
        public void UpdateOffsets(int delta, int current)
        {
            animationLength += (ushort)delta;

            if (paletteSetPointer > current)
                paletteSetPointer = (ushort)(paletteSetPointer + delta);

            if (tileSetPointer > current)
                tileSetPointer = (ushort)(tileSetPointer + delta);

            if (sequencePacketPointer > current)
                sequencePacketPointer = (ushort)(sequencePacketPointer + delta);

            foreach (E_Sequence s in sequences)
                s.UpdateOffsets(delta, current);

            if (moldPacketPointer > current)
                moldPacketPointer = (ushort)(moldPacketPointer + delta);

            foreach (E_Mold m in molds)
                m.UpdateOffsets(delta, current);
        }
        public void Assemble(E_Tileset tileset)
        {
            this.tileset = tileset;

            // reset the length
            byte[] temp = new byte[animationLength];
            for (int i = 0; i < temp.Length && i < sm.Length; i++)
                temp[i] = sm[i];
            sm = new byte[animationLength];
            for (int i = 0; i < temp.Length && i < sm.Length; i++)
                sm[i] = temp[i];

            // Start assembly
            int offset = 0;
            BitManager.SetShort(sm, offset, animationLength); offset += 2;
            BitManager.SetShort(sm, offset, graphicSetPointer); offset += 2;
            BitManager.SetShort(sm, offset, paletteSetPointer); offset += 2;
            BitManager.SetShort(sm, offset, sequencePacketPointer); offset += 2;
            BitManager.SetShort(sm, offset, moldPacketPointer); offset += 2;

            /** the two unknown bytes **/
            offset += 2;

            sm[offset] = moldsWidth; offset++;
            sm[offset] = moldsHeight; offset++;

            BitManager.SetShort(sm, offset, codec); offset += 2;
            BitManager.SetShort(sm, offset, tileSetPointer); offset += 2;

            BitManager.SetByteArray(sm, graphicSetPointer, graphicSet);
            offset += graphicSet.Length;

            // assemble the palette set
            ushort color = 0;
            int r, g, b;

            for (int i = 0; i < paletteSetLength / 32; i++)
            {
                for (int j = 0; j < 16; j++) // 16 colors in palette
                {
                    r = (int)(paletteColorRed[(i * 16) + j] / 8);
                    g = (int)(paletteColorGreen[(i * 16) + j] / 8);
                    b = (int)(paletteColorBlue[(i * 16) + j] / 8);
                    color = (ushort)((b << 10) | (g << 5) | r);
                    BitManager.SetShort(sm, paletteSetPointer + (i * 32) + (j * 2), color);
                }
            }

            int tsOffset = tileSetPointer;
            foreach (Tile16x16 t in tileset.Tileset)
            {
                if (t.TileNumber >= tileSetLength / 8)
                    break;

                if (t.TileNumber > 0 && t.TileNumber % 8 == 0)
                    tsOffset += 32;

                BitManager.SetShort(sm, tsOffset, (byte)t.GetSubtile(0).TileNum); tsOffset += 2;
                BitManager.SetShort(sm, tsOffset, (byte)t.GetSubtile(1).TileNum); tsOffset += 30;
                BitManager.SetShort(sm, tsOffset, (byte)t.GetSubtile(2).TileNum); tsOffset += 2;
                BitManager.SetShort(sm, tsOffset, (byte)t.GetSubtile(3).TileNum); tsOffset -= 30;
            }
            BitManager.SetShort(sm, tsOffset + 32, 0xFFFF);

            int sOffset = sequencePacketPointer;
            foreach (E_Sequence s in sequences)
            {
                BitManager.SetShort(sm, sOffset, s.FramePacketPointer); sOffset += 2;

                int fOffset = s.FramePacketPointer;
                foreach (E_Sequence.Frame f in s.Frames)
                {
                    BitManager.SetByte(sm, fOffset, f.Duration); fOffset++;
                    BitManager.SetByte(sm, fOffset, f.Mold); fOffset++;
                }
                BitManager.SetByte(sm, fOffset, 0);
            }
            BitManager.SetShort(sm, sOffset, 0);

            int mOffset = moldPacketPointer;
            foreach (E_Mold m in molds)
            {
                if (m.TilePacketPointer != 0xFFFF)
                {
                    BitManager.SetShort(sm, mOffset, m.TilePacketPointer); mOffset += 2;

                    int tOffset = m.TilePacketPointer;
                    foreach (E_Mold.Tile t in m.Tiles)
                    {
                        if (t.Filler)
                        {
                            sm[tOffset] = 0xFE; tOffset++;
                            sm[tOffset] = t.Empty ? (byte)0xFF : t.TileIndex; tOffset++;
                            sm[tOffset] = t.FillAmount; tOffset++;
                        }
                        else
                        {
                            sm[tOffset] = t.Empty ? (byte)0xFF : t.TileIndex;
                            if (!t.Empty)
                            {
                                BitManager.SetBit(sm, tOffset, 6, t.Mirrored);
                                BitManager.SetBit(sm, tOffset, 7, t.Inverted);
                            }
                            tOffset++;
                        }
                    }
                }
                else
                {
                    BitManager.SetShort(sm, mOffset, 0xFFFF);
                    mOffset += 2;
                }

                if (mOffset < sm.Length)
                    BitManager.SetShort(sm, mOffset, 0);
            }
        }

        public void Clear()
        {
            sm = new byte[0xA0];
            animationLength = 0xA0;
            BitManager.SetShort(sm, 0, 0xA0);

            graphicSetLength = 0x20;
            graphicSet = new byte[0x20];
            BitManager.SetByteArray(sm, 0x12, graphicSet);

            paletteSetPointer = 0x32;
            paletteSetLength = 0x20;
            paletteColorRed = new int[16 * 8];
            paletteColorGreen = new int[16 * 8];
            paletteColorBlue = new int[16 * 8];
            BitManager.SetByteArray(sm, paletteSetPointer, new byte[0x20]);

            tileSetPointer = (ushort)(paletteSetPointer + 0x20);
            BitManager.SetByteArray(sm, tileSetPointer, new byte[0x40]);
            BitManager.SetShort(sm, tileSetPointer + 0x40, 0xFFFF);

            sequencePacketPointer = (ushort)(tileSetPointer + 0x42);
            BitManager.SetShort(sm, sequencePacketPointer, (ushort)(sequencePacketPointer + 4));
            BitManager.SetShort(sm, sequencePacketPointer + 2, 0);
            sm[sequencePacketPointer + 4] = 1;
            sm[sequencePacketPointer + 5] = 0;
            sm[sequencePacketPointer + 6] = 0;

            CurrentSequence = 0;
            FramePacketPointer = (ushort)(sequencePacketPointer + 4);
            for (int a = Frames.Count - 1; a > 0; a--)
            {
                CurrentFrame = a;
                RemoveCurrentFrame();
            }
            CurrentFrame = 0;
            Duration = 1;
            FrameMold = 0;

            FrameOffset = FramePacketPointer;

            moldPacketPointer = (ushort)(sequencePacketPointer + 7);
            BitManager.SetShort(sm, moldPacketPointer, (ushort)(moldPacketPointer + 4));
            BitManager.SetShort(sm, moldPacketPointer + 2, 0);
            sm[moldPacketPointer + 4] = 0;

            for (int i = molds.Count - 1; i >= 0; i--)
            {
                CurrentMold = i;
                MoldOffset = (ushort)(moldPacketPointer + 4);
                TilePacketPointer = (ushort)(moldPacketPointer + 4);
                for (int a = Tiles.Count - 1; a > 0; a--)
                {
                    CurrentTile = a;
                    RemoveCurrentTile();
                }
                CurrentTile = 0;
                Filler = false;
                Empty = false;
                FillAmount = 0;
                TileIndex = 0;

                TileOffset = (ushort)(moldPacketPointer + 4);

                if (i == 0)
                    break;

                RemoveCurrentMold();
            }
        }
    }
}
