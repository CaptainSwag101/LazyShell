using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LAZYSHELL
{
    [Serializable()]
    public class LevelTileMods
    {
        private int index;
        [NonSerialized()]
        private byte[] data;
        public byte[] Data { get { return this.data; } set { this.data = value; } }
        private List<Mod> mods = new List<Mod>();
        public List<Mod> Mods { get { return mods; } set { mods = value; } }
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
        private bool selectedB;
        public bool SelectedB { get { return this.selectedB; } set { selectedB = value; } }
        private Mod mod; public Mod Mod_ { get { return mod; } }
        public int X { get { return mod.X; } set { mod.X = value; } }
        public int Y { get { return mod.Y; } set { mod.Y = value; } }
        public int Width
        {
            get { return mod.Width; }
            set
            {
                mod.Width = value;
                mod.ImageA = null;
                mod.ImageB = null;
                mod.TilemapA = null;
                mod.TilemapB = null;
            }
        }
        public int Height
        {
            get { return mod.Height; }
            set
            {
                mod.Height = value;
                mod.ImageA = null;
                mod.ImageB = null;
                mod.TilemapA = null;
                mod.TilemapB = null;
            }
        }
        public bool Layer1 { get { return mod.Layer1; } set { mod.Layer1 = value; } }
        public bool Layer2 { get { return mod.Layer2; } set { mod.Layer2 = value; } }
        public bool Layer3 { get { return mod.Layer3; } set { mod.Layer3 = value; } }
        public bool B0b7 { get { return mod.B0b7; } set { mod.B0b7 = value; } }
        public bool Set { get { return mod.Set; } set { mod.Set = value; } }
        public byte[][] TilemapsA { get { return mod.TilemapsA; } set { mod.TilemapsA = value; } }
        public byte[][] TilemapsB { get { return mod.TilemapsB; } set { mod.TilemapsB = value; } }
        public TileMap TilemapA { get { return mod.TilemapA; } set { mod.TilemapA = value; } }
        public TileMap TilemapB { get { return mod.TilemapB; } set { mod.TilemapB = value; } }
        public void UpdateTilemaps()
        {
            foreach (Mod mod in mods)
                mod.UpdateTilemaps();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x">In 16x16 tile units.</param>
        /// <param name="y">In 16x16 tile units.</param>
        /// <returns></returns>
        public bool WithinBounds(int x, int y)
        {
            if (mod != null)
                return mod.WithinBounds(x, y);
            else
                return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x">In 16x16 tile units.</param>
        /// <param name="y">In 16x16 tile units.</param>
        /// <returns></returns>
        public Point MousePosition(int x, int y)
        {
            return new Point(x - this.X, y - this.Y);
        }
        public LevelTileMods(byte[] data, int index)
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

            int pointerOffset = (index * 2) + 0x1D5EBD;

            offsetStart = Bits.GetShort(data, pointerOffset); pointerOffset += 2;
            offsetEnd = Bits.GetShort(data, pointerOffset);

            if (index == 0x1FF) offsetEnd = 0;

            if (offsetStart >= offsetEnd) return; // no exit fields for level

            offset = offsetStart + 0x1D0000;
            while (offset < offsetEnd + 0x1D0000)
            {
                tMod = new Mod();
                tMod.InitializeMod(data, ref offset);
                mods.Add(tMod);
            }
        }
        public void Assemble(ref int offset)
        {
            int pointerOffset = (index * 2) + 0x1D5EBD;
            Bits.SetShort(data, pointerOffset, (ushort)offset);
            foreach (Mod mod in mods)
                mod.Assemble(data, ref offset);
        }
        public void ClearTilemaps()
        {
            foreach (Mod mod in mods)
            {
                mod.ImageA = null;
                mod.ImageB = null;
                mod.TilemapA = null;
                mod.TilemapB = null;
            }
        }
        public void ClearImages()
        {
            foreach (Mod mod in mods)
            {
                mod.ImageA = null;
                mod.ImageB = null;
            }
        }
        public void RedrawTilemaps()
        {
            foreach (Mod mod in mods)
            {
                mod.TilemapA.RedrawTileMap();
                if (mod.Set)
                    mod.TilemapB.RedrawTileMap();
            }
            ClearImages();
        }
        public void ReverseMod(int index)
        {
            mods.Reverse(index, 2);
        }
        public void Insert(int index, Point p, Level level, TileSet tileset)
        {
            Mod m = new Mod();
            m.X = (byte)p.X;
            m.Y = (byte)p.Y;
            m.TilemapA = new TileMap(level, tileset, m, false);
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
        [Serializable()]
        public class Mod
        {
            [NonSerialized()]
            private TileMap tilemapA;
            public TileMap TilemapA { get { return tilemapA; } set { tilemapA = value; } }
            [NonSerialized()]
            private TileMap tilemapB;
            public TileMap TilemapB { get { return tilemapB; } set { tilemapB = value; } }
            [NonSerialized()]
            private Bitmap imageA;
            public Bitmap ImageA
            {
                get
                {
                    if (imageA == null && tilemapA != null)
                        imageA = Do.PixelsToImage(tilemapA.Mainscreen, width * 16, height * 16);
                    return imageA;
                }
                set { imageA = value; }
            }
            [NonSerialized()]
            private Bitmap imageB;
            public Bitmap ImageB
            {
                get
                {
                    if (imageB == null && tilemapB != null)
                        imageB = Do.PixelsToImage(tilemapB.Mainscreen, width * 16, height * 16);
                    return imageB;
                }
                set { imageB = value; }
            }
            private Rectangle region { get { return new Rectangle(location, size); } }
            private Point location { get { return new Point(x, y); } }
            private Size size { get { return new Size(width, height); } }
            private int x;
            private int y;
            private int width = 1;
            private int height = 1;
            private bool layer1;
            private bool layer2;
            private bool layer3;
            private bool set;
            private byte[][] tilemapsA = new byte[3][];
            private byte[][] tilemapsB = new byte[3][];
            private bool b0b7;
            public int X { get { return x; } set { x = value; } }
            public int Y { get { return y; } set { y = value; } }
            public int Width
            {
                get { return width; }
                set
                {
                    width = value;
                    for (int i = 0; i < 3; i++)
                    {
                        if (i < 2)
                            Array.Resize(ref tilemapsA[i], (width * height) * 2);
                        else
                            Array.Resize(ref tilemapsA[i], width * height);
                        if (set)
                            if (i < 2)
                                Array.Resize(ref tilemapsB[i], (width * height) * 2);
                            else
                                Array.Resize(ref tilemapsB[i], width * height);
                    }
                }
            }
            public int Height
            {
                get { return height; }
                set
                {
                    height = value;
                    for (int i = 0; i < 3; i++)
                    {
                        if (i < 2)
                            Array.Resize(ref tilemapsA[i], (width * height) * 2);
                        else
                            Array.Resize(ref tilemapsA[i], width * height);
                        if (set)
                            if (i < 2)
                                Array.Resize(ref tilemapsB[i], (width * height) * 2);
                            else
                                Array.Resize(ref tilemapsB[i], width * height);
                    }
                }
            }
            public bool Layer1 { get { return layer1; } set { layer1 = value; } }
            public bool Layer2 { get { return layer2; } set { layer2 = value; } }
            public bool Layer3 { get { return layer3; } set { layer3 = value; } }
            public bool Set { get { return set; } set { set = value; } }
            public byte[][] TilemapsA { get { return tilemapsA; } set { tilemapsA = value; } }
            public byte[][] TilemapsB { get { return tilemapsB; } set { tilemapsB = value; } }
            public bool B0b7 { get { return b0b7; } set { b0b7 = value; } }
            public Mod()
            {

            }
            public void InitializeMod(byte[] data, ref int offset)
            {
                if (offset == 0x1D6468)
                    offset = 0x1D6468;
                this.b0b7 = (data[offset] & 0x80) == 0x80;
                this.x = data[offset++] & 0x3F;
                bool one = (data[offset] & 0x80) == 0x80;
                this.y = data[offset++] & 0x3F;
                if (one)
                    width = 1;
                else
                    width = (data[offset] & 0x1F) + 1;
                layer1 = (data[offset] & 0x20) == 0x20;
                layer2 = (data[offset] & 0x40) == 0x40;
                layer3 = (data[offset++] & 0x80) == 0x80;
                if (one)
                    height = 1;
                else
                {
                    height = (data[offset] & 0x3F) + 1;
                    set = (data[offset++] & 0x80) == 0x80;
                }
                byte upper = 0;
                tilemapsA[0] = new byte[(width * height) * 2];
                if (layer1)
                {
                    for (int i = 0, c = 0; c < (width * height) * 2; i++)
                    {
                        if (i % 9 == 0)
                            upper = data[offset++];
                        else
                        {
                            tilemapsA[0][c++] = data[offset++];
                            tilemapsA[0][c++] = (byte)((upper >> ((i % 9) - 1)) & 0x01);
                        }
                    }
                }
                tilemapsA[1] = new byte[(width * height) * 2];
                if (layer2)
                {
                    for (int i = 0, c = 0; c < (width * height) * 2; i++)
                    {
                        if (i % 9 == 0)
                            upper = data[offset++];
                        else
                        {
                            tilemapsA[1][c++] = data[offset++];
                            tilemapsA[1][c++] = (byte)((upper >> ((i % 9) - 1)) & 0x01);
                        }
                    }
                }
                tilemapsA[2] = new byte[width * height];
                if (layer3)
                {
                    for (int i = 0, c = 0; c < width * height; i++)
                    {
                        if (i % 9 == 0)
                            upper = data[offset++];
                        else
                        {
                            tilemapsA[2][c++] = data[offset++];
                        }
                    }
                }
                if (!set) return;
                tilemapsB[0] = new byte[(width * height) * 2];
                if (layer1)
                {
                    for (int i = 0, c = 0; c < (width * height) * 2; i++)
                    {
                        if (i % 9 == 0)
                            upper = data[offset++];
                        else
                        {
                            tilemapsB[0][c++] = data[offset++];
                            tilemapsB[0][c++] = (byte)((upper >> ((i % 9) - 1)) & 0x01);
                        }
                    }
                }
                tilemapsB[1] = new byte[(width * height) * 2];
                if (layer2)
                {
                    for (int i = 0, c = 0; c < (width * height) * 2; i++)
                    {
                        if (i % 9 == 0)
                            upper = data[offset++];
                        else
                        {
                            tilemapsB[1][c++] = data[offset++];
                            tilemapsB[1][c++] = (byte)((upper >> ((i % 9) - 1)) & 0x01);
                        }
                    }
                }
                tilemapsB[2] = new byte[width * height];
                if (layer3)
                {
                    for (int i = 0, c = 0; c < width * height; i++)
                    {
                        if (i % 9 == 0)
                            upper = data[offset++];
                        else
                        {
                            tilemapsB[2][c++] = data[offset++];
                        }
                    }
                }
            }
            public void Assemble(byte[] data, ref int offset)
            {
                if (offset == 0x1D6468)
                    offset = 0x1D6468;
                data[offset] = (byte)this.x;
                Bits.SetBit(data, offset++, 7, b0b7);
                data[offset] = (byte)this.y;
                Bits.SetBit(data, offset++, 7, this.width == 1 && this.height == 1);
                data[offset] = (byte)(this.width - 1);
                Bits.SetBit(data, offset, 5, this.layer1);
                Bits.SetBit(data, offset, 6, this.layer2);
                Bits.SetBit(data, offset++, 7, this.layer3);
                if (!(this.height == 1 && this.width == 1))
                {
                    data[offset] = (byte)(this.height - 1);
                    Bits.SetBit(data, offset++, 7, this.set);
                }
                if (layer1)
                {
                    for (int i = 0, c = 0; c < (width * height) * 2; i++)
                    {
                        if (i % 9 == 0)
                            data[offset++] = 0;
                        else
                        {
                            data[offset] = tilemapsA[0][c++];
                            data[offset++ - (i % 9)] |= (byte)(tilemapsA[0][c++] << ((i % 9) - 1));
                        }
                    }
                }
                if (layer2)
                {
                    for (int i = 0, c = 0; c < (width * height) * 2; i++)
                    {
                        if (i % 9 == 0)
                            data[offset++] = 0;
                        else
                        {
                            data[offset] = tilemapsA[1][c++];
                            data[offset++ - (i % 9)] |= (byte)(tilemapsA[1][c++] << ((i % 9) - 1));
                        }
                    }
                }
                if (layer3)
                {
                    for (int i = 0, c = 0; c < width * height; i++)
                    {
                        if (i % 9 == 0)
                            data[offset++] = 0;
                        else
                        {
                            data[offset++] = tilemapsA[2][c++];
                        }
                    }
                }
                if (!set) return;
                if (layer1)
                {
                    for (int i = 0, c = 0; c < (width * height) * 2; i++)
                    {
                        if (i % 9 == 0)
                            data[offset++] = 0;
                        else
                        {
                            data[offset] = tilemapsB[0][c++];
                            data[offset++ - (i % 9)] |= (byte)(tilemapsB[0][c++] << ((i % 9) - 1));
                        }
                    }
                }
                if (layer2)
                {
                    for (int i = 0, c = 0; c < (width * height) * 2; i++)
                    {
                        if (i % 9 == 0)
                            data[offset++] = 0;
                        else
                        {
                            data[offset] = tilemapsB[1][c++];
                            data[offset++ - (i % 9)] |= (byte)(tilemapsB[1][c++] << ((i % 9) - 1));
                        }
                    }
                }
                if (layer3)
                {
                    for (int i = 0, c = 0; c < width * height; i++)
                    {
                        if (i % 9 == 0)
                            data[offset++] = 0;
                        else
                        {
                            data[offset++] = tilemapsB[2][c++];
                        }
                    }
                }
            }
            public void Clear()
            {
                if (tilemapsA[0] != null)
                    Array.Clear(tilemapsA[0], 0, tilemapsA[0].Length);
                if (tilemapsA[1] != null)
                    Array.Clear(tilemapsA[1], 0, tilemapsA[1].Length);
                if (tilemapsA[2] != null)
                    Array.Clear(tilemapsA[2], 0, tilemapsA[2].Length);
            }
            public bool WithinBounds(int x, int y)
            {
                if (x >= this.x && x < this.x + this.width &&
                    y >= this.y && y < this.y + this.height)
                    return true;
                return false;
            }
            public void UpdateTilemaps()
            {
                for (int layer = 0; layer < 3; layer++)
                {
                    if (tilemapsA[layer] == null) continue;
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            if (layer < 2)
                            {
                                tilemapsA[layer][y * width + x] = tilemapA.TileMaps[layer][y * width + x];
                                if (set)
                                    tilemapsB[layer][y * width + x] = tilemapB.TileMaps[layer][y * width + x];
                            }
                        }
                    }
                }
            }
            public int Length
            {
                get
                {
                    int length = 3;
                    if (!(width == 1 && height == 1))
                        length++;
                    if (layer1)
                    {
                        length += width * height;
                        length += (width * height) / 8;
                        if ((width * height) % 8 != 0)
                            length++;
                    }
                    if (layer2)
                    {
                        length += width * height;
                        length += (width * height) / 8;
                        if ((width * height) % 8 != 0)
                            length++;
                    }
                    if (layer3)
                    {
                        length += width * height;
                        length += (width * height) / 8;
                        if ((width * height) % 8 != 0)
                            length++;
                    }
                    if (!set) return length;
                    if (layer1)
                    {
                        length += width * height;
                        length += (width * height) / 8;
                        if ((width * height) % 8 != 0)
                            length++;
                    }
                    if (layer2)
                    {
                        length += width * height;
                        length += (width * height) / 8;
                        if ((width * height) % 8 != 0)
                            length++;
                    }
                    if (layer3)
                    {
                        length += width * height;
                        length += (width * height) / 8;
                        if ((width * height) % 8 != 0)
                            length++;
                    }
                    return length;
                }
            }
            public Mod Copy(Level level, TileSet tileset)
            {
                Mod copy = new Mod();
                copy.B0b7 = b0b7;
                copy.Height = height;
                copy.Layer1 = layer1;
                copy.Layer2 = layer2;
                copy.Layer3 = layer3;
                copy.Set = set;
                copy.TilemapsA[0] = Bits.Copy(tilemapsA[0]);
                copy.TilemapsA[1] = Bits.Copy(tilemapsA[1]);
                copy.TilemapsA[2] = Bits.Copy(tilemapsA[2]);
                copy.TilemapA = new TileMap(level, tileset, this, false);
                if (this.set)
                {
                    copy.TilemapsB[0] = Bits.Copy(tilemapsB[0]);
                    copy.TilemapsB[1] = Bits.Copy(tilemapsB[1]);
                    copy.TilemapsB[2] = Bits.Copy(tilemapsB[2]);
                    copy.TilemapB = new TileMap(level, tileset, this, true);
                }
                copy.Width = width;
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
