using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace LAZYSHELL
{
    [Serializable()]
    public class LevelSolidMods
    {
        private int index;
        [NonSerialized()]
        private byte[] data;
        public byte[] Data { get { return this.data; } set { this.data = value; } }
        private ArrayList mods = new ArrayList();
        public ArrayList Mods { get { return mods; } set { mods = value; } }
        private int currentMod = 0;
        public int CurrentMod
        {
            get
            {
                return this.currentMod;
            }
            set
            {
                if (this.mods.Count > value)
                {
                    mod = (Mod)mods[value];
                    this.currentMod = value;
                }
            }
        }
        private int selectedMod;
        public int SelectedMod { get { return this.selectedMod; } set { selectedMod = value; } }
        private Mod mod; public Mod Mod_ { get { return mod; } }
        public int X
        {
            get { return mod.X; }
            set
            {
                mod.X = value;
                mod.Image = null;
                mod.Pixels = null;
            }
        }
        public int Y
        {
            get { return mod.Y; }
            set
            {
                mod.Y = value;
                mod.Image = null;
                mod.Pixels = null;
            }
        }
        public int Width
        {
            get { return mod.Width; }
            set
            {
                mod.Width = value;
                mod.Image = null;
                mod.Pixels = null;
            }
        }
        public int Height
        {
            get { return mod.Height; }
            set
            {
                mod.Height = value;
                mod.Image = null;
                mod.Pixels = null;
            }
        }
        public LevelSolidMods(byte[] data, int index)
        {
            this.data = data;
            this.index = index;
            InitializeLevel();
        }
        private void InitializeLevel()
        {
            int offset;
            ushort offsetStart = 0;
            ushort offsetEnd = 0;
            Mod tMod;

            int pointerOffset = (index * 2) + 0x1D8DB0;

            offsetStart = Bits.GetShort(data, pointerOffset); pointerOffset += 2;
            offsetEnd = Bits.GetShort(data, pointerOffset);

            if (index == 0x1FF) offsetEnd = 0;

            if (offsetStart >= offsetEnd) return; // no exit fields for level

            offset = offsetStart + 0x1D0000;
            if (index == 84) index = 84;
            while (offset < offsetEnd + 0x1D0000)
            {
                tMod = new Mod();
                tMod.InitializeMod(data, ref offset);
                mods.Add(tMod);
            }
        }
        public void Assemble(ref int offset)
        {
            int pointerOffset = (index * 2) + 0x1D8DB0;
            Bits.SetShort(data, pointerOffset, (ushort)offset);
            foreach (Mod mod in mods)
                mod.Assemble(data, ref offset);
        }
        public void ClearTilemaps()
        {
            foreach (Mod mod in mods)
            {
                mod.Image = null;
                mod.Pixels = null;
            }
        }
        public void ClearImages()
        {
            foreach (Mod mod in mods)
            {
                mod.Image = null;
            }
        }
        public void ReverseMod(int index)
        {
            mods.Reverse(index, 2);
        }
        public void Insert(int index, Point p)
        {
            Mod m = new Mod();
            m.X = (byte)p.X;
            m.Y = (byte)p.Y;
            m.Pixels = Solidity.Instance.GetTilemapPixels(m);
            if (index < mods.Count)
                mods.Insert(index, m);
            else
                mods.Add(m);
        }
        public void Insert(int index, Mod copy)
        {
            if (index < mods.Count)
                mods.Insert(index, copy);
            else
                mods.Add(copy);
        }
        public void CopyToTiles()
        {
            mod.CopyToTiles();
        }
        [Serializable()]
        public class Mod : Map
        {
            private int x;
            private int y;
            private int width = 1;
            private int height = 1;
            private bool b0b7;
            private byte[] tiles = new byte[2];
            public int X
            {
                get { return x; }
                set
                {
                    x = value;
                    CopyToTilemap();
                }
            }
            public int Y
            {
                get { return y; }
                set
                {
                    y = value;
                    CopyToTilemap();
                }
            }
            public int Width
            {
                get { return width; }
                set
                {
                    width = value;
                    CopyToTilemap();
                }
            }
            public int Height
            {
                get { return height; }
                set
                {
                    height = value;
                    CopyToTilemap();
                }
            }
            public bool B0b7 { get { return b0b7; } set { b0b7 = value; } }
            public byte[] Tiles { get { return tiles; } set { tiles = value; } }
            // drawing
            private byte[] tilemap;
            public override byte[] Tilemap
            {
                get
                {
                    if (tilemap == null)
                        return new byte[0x20C2];
                    return tilemap;
                }
                set
                {
                    tilemap = value;
                    CopyToTiles();
                }
            }
            private int[] pixels;
            public override int[] Pixels { get { return pixels; } set { pixels = value; } }
            private Bitmap image;
            public override Bitmap Image
            {
                get
                {
                    if (image == null && pixels != null)
                        image = Do.PixelsToImage(pixels, 1024, 1024);
                    return image;
                }
                set { image = value; }
            }
            public void InitializeMod(byte[] data, ref int offset)
            {
                b0b7 = (data[offset] & 0x80) == 0x80;
                this.x = data[offset++] & 0x7F;
                bool one = (data[offset] & 0x80) == 0x80;
                this.y = data[offset++] & 0x7F;
                if (one)
                {
                    width = 1;
                    height = 1;
                }
                else
                {
                    width = (data[offset] & 0x0F) + 1;
                    height = (data[offset++] >> 4) + 1;
                }
                tiles = new byte[(width * height) * 2];
                byte upper = 0;
                for (int i = 0, c = 0; c < (width * height) * 2; i++)
                {
                    if (i % 5 == 0)
                        upper = data[offset++];
                    else
                    {
                        tiles[c++] = data[offset++];
                        tiles[c++] = (byte)((upper >> (((i % 5) - 1) * 2)) & 0x03);
                    }
                }
                CopyToTilemap();
            }
            public void CopyToTilemap()
            {
                tilemap = new byte[0x20C2];
                int startOffset = 0x41 * (this.y / 2);
                if (y % 2 != 0)
                    startOffset += 0x21;
                startOffset += x;
                startOffset *= 2;
                for (int i = 0, c = 0; c < tiles.Length; i += 0x42)
                {
                    if (c != 0 && (c / 2) % width == 0)
                        i = ((c / 2) / width) * 0x40;
                    if (c >= tiles.Length || startOffset + i >= tilemap.Length) break;
                    tilemap[startOffset + i] = tiles[c++];
                    tilemap[startOffset + i + 1] = tiles[c++];
                }
            }
            public void CopyToTiles()
            {
                int startOffset = 0x41 * (this.y / 2);
                if (y % 2 != 0)
                    startOffset += 0x21;
                startOffset += x;
                startOffset *= 2;
                for (int i = 0, c = 0; c < tiles.Length; i += 0x42)
                {
                    if (c != 0 && (c / 2) % width == 0)
                        i = ((c / 2) / width) * 0x40;
                    if (c >= tiles.Length || startOffset + i >= tilemap.Length) break;
                    tiles[c++] = tilemap[startOffset + i];
                    tiles[c++] = tilemap[startOffset + i + 1];
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="value">The tile index to change to.</param>
            /// <param name="x">The isometric X coord relative to a full solidity map.</param>
            /// <param name="y">The isometric Y coord relative to a full solidity map.</param>
            public void ChangeTile(int value, int x, int y)
            {
                int offset = 0x41 * (y / 2);
                if (y % 2 != 0)
                    offset += 0x21;
                offset += x;
                offset *= 2;
                Bits.SetShort(tilemap, offset, (ushort)value);
            }
            public ushort GetTileNum(int physTileNum)
            {
                return Bits.GetShort(tilemap, physTileNum * 2);
            }
            public void Assemble(byte[] data, ref int offset)
            {
                data[offset] = (byte)this.x;
                Bits.SetBit(data, offset++, 7, b0b7);
                data[offset] = (byte)this.y;
                Bits.SetBit(data, offset++, 7, width == 1 && height == 1);
                if (!(width == 1 && height == 1))
                {
                    data[offset] = (byte)(width - 1);
                    data[offset++] |= (byte)((height - 1) << 4);
                }
                for (int i = 0, c = 0; c < (width * height) * 2; i++)
                {
                    if (i % 5 == 0)
                        data[offset++] = 0;
                    else
                    {
                        data[offset] = tiles[c++];
                        data[offset++ - (i % 5)] |= (byte)(tiles[c++] << (((i % 5) - 1) * 2));
                    }
                }
            }
            public void Clear()
            {
                Array.Clear(tiles, 0, tiles.Length);
            }
            public int Length
            {
                get
                {
                    int length = 2;
                    if (!(width == 1 && height == 1))
                        length++;
                    length += width * height;
                    length += (width * height) / 4;
                    if ((width * height) % 4 != 0)
                        length++;
                    return length;
                }
            }
            public Mod Copy()
            {
                Mod copy = new Mod();
                copy.Tiles = Bits.Copy(tiles);
                copy.Pixels = Bits.Copy(pixels);
                copy.Tilemap = Bits.Copy(tilemap);
                copy.Width = width;
                copy.Height = height;
                copy.X = x;
                copy.Y = y;
                return copy;
            }
        }
        public void Clear()
        {
            foreach (Mod mod in mods)
                mod.Clear();
        }
    }
}
