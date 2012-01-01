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
    public class E_Animation : Element
    {
        #region Variables
        [NonSerialized()]
        private byte[] data;
        public override byte[] Data { get { return this.data; } set { this.data = value; } }
        public override int Index { get { return index; } set { index = value; } }
        private byte[] sm; public byte[] SM { get { return sm; } set { sm = value; } }    // sequence mold data
        private int index;
        private int animationOffset; public int AnimationOffset { get { return animationOffset; } set { index = value; } }
        private byte width; public byte Width { get { return width; } set { width = value; } }
        private byte height; public byte Height { get { return height; } set { height = value; } }
        private ushort codec; public ushort Codec { get { return codec; } set { codec = value; } }
        private List<E_Sequence> sequences = new List<E_Sequence>();
        public List<E_Sequence> Sequences { get { return sequences; } set { sequences = value; } }
        private List<E_Mold> molds = new List<E_Mold>();
        public List<E_Mold> Molds { get { return molds; } set { molds = value; } }
        // Tileset
        private int tileSetLength; public int TileSetLength { get { return tileSetLength; } set { tileSetLength = value; } }
        private byte[] tileSet; public byte[] TileSet { get { return tileSet; } set { tileSet = value; } }
        private E_Tileset tileset; public E_Tileset Tileset { get { return tileset; } set { tileset = value; } }
        // Graphics
        private byte[] graphicSet; public byte[] GraphicSet { get { return graphicSet; } set { graphicSet = value; } }
        private int graphicSetLength;
        public int GraphicSetLength { get { return graphicSetLength; } set { graphicSetLength = value; } }
        // Palettes
        private PaletteSet paletteSet; public PaletteSet PaletteSet { get { return paletteSet; } set { paletteSet = value; } }
        private ushort paletteSetLength;
        public ushort PaletteSetLength { get { return paletteSetLength; } set { paletteSetLength = value; } }
        #endregion
        #region Functions
        public E_Animation(byte[] data, int animationNum)
        {
            this.data = data;
            this.index = animationNum;

            InitializeAnimation(data);
        }
        private void InitializeAnimation(byte[] data)
        {
            E_Sequence tSequence;
            E_Mold tMold;

            animationOffset = Bits.Get24Bit(data, 0x252C00 + (index * 3)) - 0xC00000;
            ushort animationLength = Bits.GetShort(data, animationOffset);

            sm = Bits.GetByteArray(data, animationOffset, Bits.GetShort(data, animationOffset));

            int offset = 2;
            ushort graphicSetPointer = Bits.GetShort(sm, offset); offset += 2;
            ushort paletteSetPointer = Bits.GetShort(sm, offset); offset += 2;
            ushort sequencePacketPointer = Bits.GetShort(sm, offset); offset += 2;
            ushort moldPacketPointer = Bits.GetShort(sm, offset); offset += 2;

            /** here are two unknown bytes, we'll just skip them **/
            offset += 2;

            width = sm[offset]; offset++;
            height = sm[offset]; offset++;

            codec = Bits.GetShort(sm, offset); offset += 2;

            int tileSetPointer = Bits.GetShort(sm, offset);

            graphicSetLength = paletteSetPointer - graphicSetPointer;
            graphicSet = new byte[0x2000];
            Buffer.BlockCopy(sm, graphicSetPointer, graphicSet, 0, graphicSetLength);
            paletteSetLength = (ushort)(tileSetPointer - paletteSetPointer);
            paletteSet = new PaletteSet(sm, 0, paletteSetPointer, 8, 16, 32);
            tileSetLength = sequencePacketPointer - tileSetPointer - 2;
            tileSet = new byte[64 * 4 * 2 * 4];
            Buffer.BlockCopy(sm, tileSetPointer, tileSet, 0, tileSetLength);

            offset = sequencePacketPointer;
            for (int i = 0; Bits.GetShort(sm, offset) != 0x0000; i++)
            {
                tSequence = new E_Sequence();
                tSequence.InitializeSequence(sm, offset);
                sequences.Add(tSequence);
                offset += 2;
            }
            offset = moldPacketPointer;
            ushort end = 0;
            for (int i = 0; Bits.GetShort(sm, offset) != 0x0000; i++)
            {
                if (Bits.GetShort(sm, offset + 2) == 0x0000)
                    end = animationLength;
                else
                    end = Bits.GetShort(sm, offset + 2);
                tMold = new E_Mold();
                tMold.InitializeMold(sm, offset, end);
                molds.Add(tMold);
                offset += 2;
            }
        }
        public int Assemble()
        {
            int size = sm.Length;
            // set sm to new byte with largest possible size
            byte[] temp = new byte[0x10000];
            // not dynamic, can set before others
            temp[12] = width;
            temp[13] = height;
            Bits.SetShort(temp, 14, codec);
            // now start writing dynamic data
            int offset = 18;
            // Graphics
            Bits.SetShort(temp, 2, 0x12);
            Buffer.BlockCopy(graphicSet, 0, temp, 18, graphicSetLength);
            offset += graphicSetLength;
            // Palettes
            Bits.SetShort(temp, 4, (ushort)offset);
            paletteSet.Assemble(temp, offset);
            offset += paletteSetLength;
            // Tileset
            Bits.SetShort(temp, 16, (ushort)offset);
            int tilesetoffset = offset;
            foreach (Tile16x16 t in tileset.Tileset)
            {
                if (t.TileIndex >= tileSetLength / 8)
                    break;

                if (t.TileIndex > 0 && t.TileIndex % 8 == 0)
                    offset += 32;

                for (int i = 0; i < 4; i++)
                {
                    Bits.SetShort(temp, offset, (byte)t.Subtiles[i].TileIndex); offset++;
                    Bits.SetBit(temp, offset, 5, t.Subtiles[i].PriorityOne);
                    Bits.SetBit(temp, offset, 6, t.Subtiles[i].Mirror);
                    Bits.SetBit(temp, offset, 7, t.Subtiles[i].Invert);
                    if (i % 2 == 0) 
                        offset++;
                    else if (i == 1)
                        offset += 29;
                    else if (i == 3)
                        offset -= 31;
                }
            }
            Buffer.BlockCopy(temp, tilesetoffset, tileSet, 0, tileSet.Length);
            //
            offset += 32;
            Bits.SetShort(temp, offset, 0xFFFF); offset += 2;
            // Sequences
            Bits.SetShort(temp, 6, (ushort)offset);
            int fOffset = sequences.Count * 2 + 2;  // offset of first frame packet
            foreach (E_Sequence s in sequences)
            {
                if (s.Frames.Count != 0)
                {
                    Bits.SetShort(temp, offset, (ushort)(fOffset + offset));
                    fOffset += s.Frames.Count * 2 + 1;
                }
                else
                    Bits.SetShort(temp, offset, 0xFFFF);
                offset += 2;
            }
            Bits.SetShort(temp, offset, 0); offset += 2;
            foreach (E_Sequence s in sequences)
            {
                foreach (E_Sequence.Frame f in s.Frames)
                {
                    Bits.SetByte(temp, offset, f.Duration); offset++;
                    Bits.SetByte(temp, offset, f.Mold); offset++;
                }
                Bits.SetByte(temp, offset, 0); offset++;
            }
            // Molds
            Bits.SetShort(temp, 8, (ushort)offset);
            int mOffset = molds.Count * 2 + 2;    // offset of first mold tilemap
            foreach (E_Mold m in molds)
            {
                if (!m.Empty)
                {
                    Bits.SetShort(temp, offset, (ushort)(mOffset + offset));
                    mOffset += m.Recompress(m.Mold, width, height).Length - 2;
                }
                else
                    Bits.SetShort(temp, offset, 0xFFFF);
                offset += 2;
            }
            Bits.SetShort(temp, offset, 0); offset += 2;
            foreach (E_Mold m in molds)
            {
                if (!m.Empty)
                {
                    byte[] mold = m.Recompress(m.Mold, width, height);
                    Buffer.BlockCopy(mold, 0, temp, offset, mold.Length);
                    offset += mold.Length;
                }
            }
            // finally, set the animation length
            Bits.SetShort(temp, 0, (ushort)offset);
            sm = new byte[offset];
            Bits.SetByteArray(sm, 0, temp);
            //Do.Export(sm, "test.bin");
            return size - sm.Length;
        }
        public override void Clear()
        {
            foreach (E_Sequence s in sequences)
                s.Frames = new List<E_Sequence.Frame>();
            int moldCount = molds.Count;
            for (int i = 1; i < moldCount; i++)
                molds.RemoveAt(1);
            tileSet = new byte[tileSet.Length];
            paletteSetLength = 32;
            graphicSetLength = 32;
            tileSetLength = 64;
            graphicSet = new byte[graphicSet.Length];
            paletteSet = new PaletteSet(new byte[256], 0, 0, 8, 16, 32);
            codec = 0;
            width = 1;
            height = 1;
            foreach (Tile16x16 tile in tileset.Tileset)
                for (int i = 0; i < 4; i++)
                    tile.Subtiles[i] = new Tile8x8(0, new byte[0x20], 0, new int[16], false, false, false, codec == 1);
        }
        #endregion
    }
}
