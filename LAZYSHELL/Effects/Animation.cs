using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace LazyShell.Effects
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
        public byte Width { get; set; }
        public byte Height { get; set; }
        public ushort Codec { get; set; }

        // Collections
        public List<Sequence> Sequences { get; set; }
        public List<Mold> Molds { get; set; }
        public byte[] Tileset_bytes { get; set; }
        public Tileset Tileset_tiles { get; set; }
        /// <summary>
        /// The original size of the tileset's binary data.
        /// This value is not updated automatically.
        /// </summary>
        public int TilesetLength { get; set; }

        // Graphics
        public byte[] GraphicSet { get; set; }
        /// <summary>
        /// The original size of the graphic set's binary data.
        /// This value is not updated automatically.
        /// </summary>
        public int GraphicSetLength { get; set; }

        // Palettes
        public PaletteSet PaletteSet { get; set; }
        /// <summary>
        /// The original size of the palette set's binary data.
        /// This value is not updated automatically.
        /// </summary>
        public int PaletteSetLength { get; set; }

        #endregion

        // Constructor
        public Animation(int index)
        {
            this.Index = index;
            ReadFromBuffer();
        }

        #region Methods

        // Read/write buffer
        private void ReadFromBuffer()
        {
            AnimationOffset = Bits.GetInt24(rom, 0x252C00 + (Index * 3)) - 0xC00000;

            // Create source buffer for following properties
            ushort animationLength = Bits.GetShort(rom, AnimationOffset);
            Buffer = Bits.GetBytes(rom, AnimationOffset, Bits.GetShort(rom, AnimationOffset));

            // Get pointers of data types
            int offset = 2;
            ushort graphicSetPointer = Bits.GetShort(Buffer, offset); offset += 2;
            ushort paletteSetPointer = Bits.GetShort(Buffer, offset); offset += 2;
            ushort sequencePacketPointer = Bits.GetShort(Buffer, offset); offset += 2;
            ushort moldPacketPointer = Bits.GetShort(Buffer, offset); offset += 2;

            // Skip 2 unknown bytes
            offset += 2;

            // Get formatting properties
            Width = Buffer[offset++];
            Height = Buffer[offset++];
            Codec = Bits.GetShort(Buffer, offset); offset += 2;

            // Get graphics, palette, tileset data
            int tileSetPointer = Bits.GetShort(Buffer, offset);
            GraphicSetLength = paletteSetPointer - graphicSetPointer;
            GraphicSet = new byte[0x2000];
            System.Buffer.BlockCopy(Buffer, graphicSetPointer, GraphicSet, 0, GraphicSetLength);
            PaletteSetLength = (ushort)(tileSetPointer - paletteSetPointer);
            PaletteSet = new PaletteSet(Buffer, 0, paletteSetPointer, 8, 16, 32);
            TilesetLength = sequencePacketPointer - tileSetPointer - 2;
            Tileset_bytes = new byte[64 * 4 * 2 * 4];
            System.Buffer.BlockCopy(Buffer, tileSetPointer, Tileset_bytes, 0, TilesetLength);

            // Build sequence collection
            this.Sequences = new List<Sequence>();
            offset = sequencePacketPointer;
            for (int i = 0; Bits.GetShort(Buffer, offset) != 0x0000; i++)
            {
                Sequence tSequence = new Sequence();
                tSequence.ReadFromBuffer(Buffer, offset);
                Sequences.Add(tSequence);
                offset += 2;
            }

            // Build mold collection
            this.Molds = new List<Mold>();
            offset = moldPacketPointer;
            ushort end = 0;
            for (int i = 0; Bits.GetShort(Buffer, offset) != 0x0000; i++)
            {
                if (Bits.GetShort(Buffer, offset + 2) == 0x0000)
                    end = animationLength;
                else
                    end = Bits.GetShort(Buffer, offset + 2);
                Mold tMold = new Mold();
                tMold.ReadFromBuffer(Buffer, offset, end);
                Molds.Add(tMold);
                offset += 2;
            }
        }
        /// <summary>
        /// Converts this effect animation's object data to binary format and sets the 
        /// buffer's value to the new output. After the operation is complete, a value 
        /// indicating the change in size of the new ouptut data is returned.
        /// </summary>
        /// <returns></returns>
        public int WriteToBuffer()
        {
            int size = this.Buffer.Length;

            // Create temporary buffer with max bank size
            byte[] temp = new byte[0x10000];

            // Write formatting properties
            temp[12] = Width;
            temp[13] = Height;
            Bits.SetShort(temp, 14, Codec);

            #region Dynamic data

            // Start of dynamic data in buffer
            int offset = 18;

            // Write graphics
            Bits.SetShort(temp, 2, 0x12);
            System.Buffer.BlockCopy(GraphicSet, 0, temp, 18, GraphicSetLength);
            offset += GraphicSetLength;

            // Write palettes
            Bits.SetShort(temp, 4, (ushort)offset);
            PaletteSet.WriteToBuffer(temp, offset);
            offset += PaletteSetLength;

            // Write tileset
            Bits.SetShort(temp, 16, (ushort)offset);
            int tilesetoffset = offset;
            foreach (var t in Tileset_tiles.Tiles)
            {
                if (t.Index >= TilesetLength / 8)
                    break;
                if (t.Index > 0 && t.Index % 8 == 0)
                    offset += 32;
                for (int i = 0; i < 4; i++)
                {
                    Bits.SetShort(temp, offset, (byte)t.Subtiles[i].Index); offset++;
                    Bits.SetBit(temp, offset, 5, t.Subtiles[i].Priority1);
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

            // Copy updated tileset data to tileset bytes buffer
            System.Buffer.BlockCopy(temp, tilesetoffset, Tileset_bytes, 0, Tileset_bytes.Length);

            // Add 32 because last loop operation subtracted 31
            offset += 32;

            // 0xFFFF sets boundary of tileset data
            Bits.SetShort(temp, offset, 0xFFFF); offset += 2;

            // Write sequences
            Bits.SetShort(temp, 6, (ushort)offset);
            int fOffset = Sequences.Count * 2 + 2;  // offset of first frame packet
            foreach (var s in Sequences)
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

            // Write frames
            Bits.SetShort(temp, offset, 0); offset += 2;
            foreach (var s in Sequences)
            {
                foreach (var f in s.Frames)
                {
                    Bits.SetByte(temp, offset, f.Duration); offset++;
                    Bits.SetByte(temp, offset, f.Mold); offset++;
                }
                Bits.SetByte(temp, offset, 0); offset++;
            }

            // Write mold pointers
            Bits.SetShort(temp, 8, (ushort)offset);
            int mOffset = Molds.Count * 2 + 2;    // offset of first mold tilemap
            foreach (var m in Molds)
            {
                if (!m.Empty)
                {
                    Bits.SetShort(temp, offset, (ushort)(mOffset + offset));
                    mOffset += m.Compress(m.Tiles, Width, Height).Length - 2;
                }
                else
                    Bits.SetShort(temp, offset, 0xFFFF);
                offset += 2;
            }

            // Write mold data
            Bits.SetShort(temp, offset, 0); offset += 2;
            foreach (var m in Molds)
            {
                if (!m.Empty)
                {
                    byte[] mold = m.Compress(m.Tiles, Width, Height);
                    System.Buffer.BlockCopy(mold, 0, temp, offset, mold.Length);
                    offset += mold.Length;
                }
            }

            #endregion

            // Set animation length
            Bits.SetShort(temp, 0, (ushort)offset);

            // Finally, write local data to this.Buffer
            this.Buffer = new byte[offset];
            Bits.SetBytes(this.Buffer, 0, temp);

            // Return size difference of old and new buffer data
            return size - this.Buffer.Length;
        }

        /// <summary>
        /// Resizes the tilemaps to fit a specified width.
        /// </summary>
        public void ResizeTilemaps(int width)
        {
            for (int i = 0; i < Molds.Count; i++)
            {
                byte[] temp = Bits.Copy(Molds[i].Tiles);
                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        if (x >= width)
                            Molds[i].Tiles[y * Width + x] = 0xFF;
                        else
                            Molds[i].Tiles[y * Width + x] = temp[y * width + x];
                    }
                }
            }
        }

        // Inherited
        public override void Clear()
        {
            // Clear sequences
            foreach (var s in Sequences)
                s.Frames = new List<Sequence.Frame>();

            // Clear molds
            int moldCount = Molds.Count;
            for (int i = 1; i < moldCount; i++)
                Molds.RemoveAt(1);

            // Clear tileset, palette, graphics data
            Tileset_bytes = new byte[Tileset_bytes.Length];
            PaletteSetLength = 32;
            GraphicSetLength = 32;
            TilesetLength = 64;
            GraphicSet = new byte[GraphicSet.Length];
            PaletteSet = new PaletteSet(new byte[256], 0, 0, 8, 16, 32);

            // Clear formatting properties
            Codec = 0;
            Width = 1;
            Height = 1;

            // Clear tile data
            foreach (var tile in Tileset_tiles.Tiles)
                for (int i = 0; i < 4; i++)
                    tile.Subtiles[i] = new Subtile(0, new byte[0x20], 0, new int[16], false, false, false, Codec == 1);
        }

        #endregion
    }
}
