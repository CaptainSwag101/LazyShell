using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace LazyShell.Sprites
{
    [Serializable()]
    public class Animation : Element
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

        // Properties
        public byte[] Buffer { get; set; }
        public int AnimationOffset { get; set; }
        public ushort VramAllocation { get; set; }
        public ushort Unknown { get; set; }

        // Collections
        public List<Sequence> Sequences { get; set; }
        public List<Mold> Molds { get; set; }
        public List<Mold.Tile> UniqueTiles { get; set; }

        #endregion

        // Constructor
        public Animation(int index)
        {
            this.Index = index;
            ReadFromBuffer();
        }

        #region Methods

        // Read/write ROM
        private void ReadFromBuffer()
        {
            AnimationOffset = Bits.GetInt24(rom, 0x252000 + (Index * 3)) - 0xC00000;

            // Create source buffer for following properties
            int animationLength = Bits.GetShort(rom, AnimationOffset);
            Buffer = Bits.GetBytes(rom, AnimationOffset, animationLength);

            // Get pointers of data types
            int offset = 2;
            ushort sequencePacketPointer = Bits.GetShort(Buffer, offset); offset += 2;
            ushort moldPacketPointer = Bits.GetShort(Buffer, offset); offset += 2;
            byte sequenceCount = Buffer[offset++];
            byte moldCount = Buffer[offset++];
            VramAllocation = (ushort)(Buffer[offset] << 8); offset += 2;
            Unknown = Bits.GetShort(Buffer, offset);

            // Build sequence collection
            offset = sequencePacketPointer;
            this.Sequences = new List<Sequence>();
            for (int i = 0; i < sequenceCount; i++)
            {
                var tSequence = new Sequence();
                tSequence.ReadFromBuffer(Buffer, offset);
                Sequences.Add(tSequence);
                offset += 2;
            }

            // Build mold collection
            offset = moldPacketPointer;
            this.Molds = new List<Mold>();
            this.UniqueTiles = new List<Mold.Tile>();
            for (int i = 0; i < moldCount; i++)
            {
                var tMold = new Mold();
                tMold.ReadFromBuffer(Buffer, offset, UniqueTiles, Index, AnimationOffset);
                Molds.Add(tMold);
                offset += 2;
            }
        }
        public void WriteToBuffer()
        {
            // Create temporary buffer with max bank size
            byte[] temp = new byte[0x10000];

            // Write formatting properties
            temp[6] = (byte)Sequences.Count;
            temp[7] = (byte)Molds.Count;
            temp[8] = (byte)(VramAllocation >> 8);

            #region Sequences

            // Start of sequence data in buffer
            int offset = 12;

            // Write sequence collection pointer
            Bits.SetShort(temp, 2, (ushort)0x0C);

            // Write sequences
            int fOffset = Sequences.Count * 2 + 2;  // offset of first frame packet
            foreach (var s in Sequences)
            {
                if (s.Frames.Count != 0 && s.Active)
                {
                    Bits.SetShort(temp, offset, (ushort)(fOffset + offset));
                    fOffset += s.Frames.Count * 2 - 1;
                }
                else if (s.Active)
                {
                    Bits.SetShort(temp, offset, (ushort)(fOffset + offset));
                    fOffset -= 1;
                }
                else
                {
                    Bits.SetShort(temp, offset, 0xFFFF);
                    fOffset -= 2;
                }
                offset += 2;
            }

            // Write frames
            Bits.SetShort(temp, offset, 0); offset += 2;
            foreach (var s in Sequences)
            {
                foreach (var f in s.Frames)
                {
                    Bits.SetByte(temp, offset++, f.Duration);
                    Bits.SetByte(temp, offset++, f.Mold);
                }
                if (s.Active)
                    Bits.SetByte(temp, offset++, 0);
            }

            #endregion

            #region Molds

            // Write mold pointers
            Bits.SetShort(temp, 4, (ushort)offset);
            int mOffset = Molds.Count * 2 + 2;    // offset of first mold tilemap
            foreach (var m in Molds)
            {
                if (Index == 162 && mOffset == 0x132)
                    Index = 162;
                if (m.Tiles.Count != 0)
                {
                    if (m.Gridplane)
                    {
                        Bits.SetShort(temp, offset, (ushort)(mOffset + offset + 0x8000));
                        var tile = m.Tiles[0];
                        if (tile.Subtile_bytes != null)
                            mOffset += tile.Length - 2;
                    }
                    else
                    {
                        Bits.SetShort(temp, offset, (ushort)(mOffset + offset));
                        mOffset += m.Compress(mOffset + offset, Molds).Length - 1;
                    }
                }
                else
                {
                    Bits.SetShort(temp, offset, (ushort)0xFFFF);
                    mOffset -= 2;
                }
                offset += 2;
            }

            // Write mold data
            Bits.SetShort(temp, offset += 2, 0);
            foreach (var m in Molds)
            {
                if (m.Tiles.Count == 0) 
                    continue;
                if (m.Gridplane)
                {
                    var tile = m.Tiles[0];
                    if (tile.Subtile_bytes == null)
                        continue;
                    temp[offset] = (byte)(tile.Format & 3);
                    Bits.SetBit(temp, offset, 3, tile.Is16bit);
                    Bits.SetBit(temp, offset, 4, tile.YPlusOne == 1);
                    Bits.SetBit(temp, offset, 5, tile.YMinusOne == 1);
                    Bits.SetBit(temp, offset, 6, tile.Mirror);
                    Bits.SetBit(temp, offset++, 7, tile.Invert);
                    int size = tile.Is16bit ? tile.Length - 3 : tile.Length - 1;

                    // Set bits for tiles that are 2 bytes long
                    if (tile.Is16bit)
                    {
                        for (int i = 0; i < size; i++)
                            Bits.SetBit(temp, offset, i, tile.Subtile_bytes[i] >= 0x100);
                        offset += 2;
                    }
                    for (int i = 0; i < size; i++)
                        temp[offset++] = (byte)tile.Subtile_bytes[i];
                }
                else
                {
                    byte[] mold = m.Compress(offset, Molds);
                    mold.CopyTo(temp, offset);
                    offset += mold.Length;
                    temp[offset++] = 0;
                }
            }

            #endregion

            // Set animation length
            Bits.SetShort(temp, 0, (ushort)offset);

            // Finally, write local data to this.Buffer
            this.Buffer = new byte[offset];
            Bits.SetBytes(Buffer, 0, temp);
        }

        /// <summary>
        /// Converts the unique tile collection to an RGB pixel array organized as a tileset.
        /// </summary>
        /// <returns></returns>
        public int[] TilesetPixels()
        {
            int height = 16, x, y;
            Mold.Tile temp;
            height += (UniqueTiles.Count / 8) * 16;
            height += (UniqueTiles.Count % 8) != 0 ? 16 : 0;
            int[] pixels = new int[128 * height];
            for (int b = 0; b < height / 16; b++)
            {
                for (int a = 0; a < 8; a++)
                {
                    if ((a + (b * 8)) >= UniqueTiles.Count) break;
                    temp = UniqueTiles[a + (b * 8)];
                    int[] theTile = temp.Get16x16TilePixels();
                    for (y = 0; y < 16; y++)
                    {
                        for (x = 0; x < 16; x++)
                            pixels[(((b * 16) + y) * 128) + ((a * 16) + x)] = theTile[(y * 16) + x];
                    }
                }
            }
            return pixels;
        }

        // Inherited
        public override void Clear()
        {
            VramAllocation = 2048;
            int moldCount = Molds.Count;
            for (int i = 1; i < moldCount; i++)
                Molds.RemoveAt(1);
            int tileCount = Molds[0].Tiles.Count;
            for (int i = 1; i < tileCount; i++)
                Molds[0].Tiles.RemoveAt(1);
            Molds[0].Gridplane = false;
            UniqueTiles = new List<Mold.Tile>();
            if (Molds[0].Tiles.Count > 0)
            {
                Molds[0].Tiles[0] = Molds[0].Tiles[0].New(false);
                UniqueTiles.Add(Molds[0].Tiles[0]);
            }
            int sequenceCount = Sequences.Count;
            for (int i = 1; i < sequenceCount; i++)
                Sequences.RemoveAt(1);
            Sequences[0].Frames = new List<Sequence.Frame>();
        }

        #endregion
    }
}
