using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LAZYSHELL.Areas
{
    [Serializable()]
    public class TileSwitchCollection : IList<TileSwitch>
    {
        #region Variables

        // ROM buffer
        private byte[] rom
        {
            get { return Model.ROM; }
            set { Model.ROM = value; }
        }
        // Index
        public int Index { get; set; }
        // Tile switch collection
        public List<TileSwitch> TileSwitches { get; set; }

        #endregion

        // Constructor
        public TileSwitchCollection(int index)
        {
            this.Index = index;
            this.TileSwitches = new List<TileSwitch>();
            ReadFromROM();
        }

        #region Methods

        // Read/write ROM
        private void ReadFromROM()
        {
            int pointerOffset = (Index * 2) + 0x1D5EBD;
            int offsetStart = Bits.GetShort(rom, pointerOffset);
            int offsetEnd = Bits.GetShort(rom, pointerOffset + 2);
            if (this.Index == 511)
                offsetEnd = 0;
            if (offsetStart < offsetEnd)
                return;
            int offset = offsetStart + 0x1D0000;
            while (offset < offsetEnd + 0x1D0000)
            {
                var tileSwitch = new TileSwitch();
                tileSwitch.ReadFromROM(ref offset);
                this.TileSwitches.Add(tileSwitch);
            }
        }
        public void WriteToROM(ref int offset)
        {
            int pointerOffset = (Index * 2) + 0x1D5EBD;
            Bits.SetShort(rom, pointerOffset, (ushort)offset);
            foreach (var mod in TileSwitches)
                mod.WriteToROM(ref offset);
        }
        // External modification
        public void UpdateTilemaps()
        {
            foreach (var tileSwitch in TileSwitches)
                tileSwitch.UpdateTilemaps();
        }
        public void ClearTilemaps()
        {
            foreach (var tileSwitch in TileSwitches)
            {
                tileSwitch.ImageA = null;
                tileSwitch.ImageB = null;
                tileSwitch.TilemapA = null;
                tileSwitch.TilemapB = null;
            }
        }
        public void ClearImages()
        {
            foreach (var tileSwitch in TileSwitches)
            {
                tileSwitch.ImageA = null;
                tileSwitch.ImageB = null;
            }
        }
        public void RedrawTilemaps()
        {
            foreach (var tileSwitch in TileSwitches)
            {
                if (tileSwitch.TilemapA != null)
                    tileSwitch.TilemapA.RedrawTilemaps();
                if (tileSwitch.Alternate && tileSwitch.TilemapB != null)
                    tileSwitch.TilemapB.RedrawTilemaps();
            }
            ClearImages();
        }

        #endregion

        #region Enumeration

        // Collection members
        public TileSwitch this[int index]
        {
            get { return this.TileSwitches[index]; }
            set { this.TileSwitches[index] = value; }
        }
        public void Add(TileSwitch value)
        {
            this.TileSwitches.Add(value);
        }
        public void Clear()
        {
            TileSwitches.Clear();
        }
        public bool Contains(TileSwitch value)
        {
            foreach (var tileSwitch in TileSwitches)
            {
                if (tileSwitch == value)
                    return true;
            }
            return false;
        }
        public void CopyTo(TileSwitch[] tileSwitches, int arrayIndex)
        {
            TileSwitches.CopyTo(tileSwitches, arrayIndex);
        }
        public int Count
        {
            get { return TileSwitches.Count; }
        }
        public int IndexOf(TileSwitch value)
        {
            for (int i = 0; i < TileSwitches.Count; i++)
            {
                if (TileSwitches[i] == value)
                    return i;
            }
            return -1;
        }
        public void Insert(int index, TileSwitch value)
        {
            if (index < TileSwitches.Count)
                TileSwitches.Insert(index, value);
            else
                TileSwitches.Add(value);
        }
        public void Insert(int index, Point p)
        {
            var e = new TileSwitch();
            e.X = (byte)p.X;
            e.Y = (byte)p.Y;
            if (index < TileSwitches.Count)
                TileSwitches.Insert(index, e);
            else
                TileSwitches.Add(e);
        }
        public void Insert(int index, Point p, Area area, Tileset tileset)
        {
            TileSwitch tileSwitch = new TileSwitch();
            tileSwitch.X = (byte)p.X;
            tileSwitch.Y = (byte)p.Y;
            tileSwitch.TilemapA = new AreaTilemap(area, tileset, tileSwitch, false);
            if (index < TileSwitches.Count)
                TileSwitches.Insert(index, tileSwitch);
            else
                TileSwitches.Add(tileSwitch);
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public bool Remove(TileSwitch value)
        {
            for (int i = 0; i < TileSwitches.Count; i++)
            {
                if (TileSwitches[i] == value)
                {
                    TileSwitches.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public void RemoveAt(int index)
        {
            TileSwitches.RemoveAt(index);
        }
        public void Reverse(int index, int count)
        {
            TileSwitches.Reverse(index, count);
        }
        // Enumerator
        public IEnumerator<TileSwitch> GetEnumerator()
        {
            return new TileSwitchEnumerator(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new TileSwitchEnumerator(this);
        }

        #endregion
    }
    // classes
    [Serializable()]
    public class TileSwitch
    {
        #region Variables

        // ROM buffer
        private byte[] rom
        {
            get { return Model.ROM; }
            set { Model.ROM = value; }
        }
        // Properties
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        /// <summary>
        /// The total size of the tile switch's binary data.
        /// </summary>
        public int Length
        {
            get
            {
                int length = 3;
                if (!(Width == 1 && Height == 1))
                    length++;
                if (Layer1)
                {
                    length += Width * Height;
                    length += (Width * Height) / 8;
                    if ((Width * Height) % 8 != 0)
                        length++;
                }
                if (Layer2)
                {
                    length += Width * Height;
                    length += (Width * Height) / 8;
                    if ((Width * Height) % 8 != 0)
                        length++;
                }
                if (Layer3)
                {
                    length += Width * Height;
                    length += (Width * Height) / 8;
                    if ((Width * Height) % 8 != 0)
                        length++;
                }
                if (!Alternate) return length;
                if (Layer1)
                {
                    length += Width * Height;
                    length += (Width * Height) / 8;
                    if ((Width * Height) % 8 != 0)
                        length++;
                }
                if (Layer2)
                {
                    length += Width * Height;
                    length += (Width * Height) / 8;
                    if ((Width * Height) % 8 != 0)
                        length++;
                }
                if (Layer3)
                {
                    length += Width * Height;
                    length += (Width * Height) / 8;
                    if ((Width * Height) % 8 != 0)
                        length++;
                }
                return length;
            }
        }
        public bool Layer1 { get; set; }
        public bool Layer2 { get; set; }
        public bool Layer3 { get; set; }
        public bool Alternate { get; set; }
        public bool B0b7 { get; set; }
        // Tilemap
        public byte[][] Tilemaps_bytesA { get; set; }
        public byte[][] Tilemaps_bytesB { get; set; }
        public AreaTilemap TilemapA { get; set; }
        public AreaTilemap TilemapB { get; set; }
        // Drawing
        [NonSerialized()]
        private Bitmap imageA;
        [NonSerialized()]
        private Bitmap imageB;
        public Bitmap ImageA
        {
            get
            {
                if (imageA == null && TilemapA != null)
                    imageA = Do.PixelsToImage(TilemapA.Pixels, Width * 16, Height * 16);
                return imageA;
            }
            set { imageA = value; }
        }
        public Bitmap ImageB
        {
            get
            {
                if (imageB == null && TilemapB != null)
                    imageB = Do.PixelsToImage(TilemapB.Pixels, Width * 16, Height * 16);
                return imageB;
            }
            set { imageB = value; }
        }
        private Rectangle region { get { return new Rectangle(location, size); } }
        private Point location { get { return new Point(X, Y); } }
        private Size size { get { return new Size(Width, Height); } }

        #endregion

        // Constructor
        public TileSwitch()
        {
            this.Width = 1;
            this.Height = 1;
            this.Tilemaps_bytesA = new byte[3][];
            this.Tilemaps_bytesB = new byte[3][];
        }

        #region Methods

        // Read/write
        public void ReadFromROM(ref int offset)
        {
            this.B0b7 = (rom[offset] & 0x80) == 0x80;
            this.X = rom[offset++] & 0x3F;
            bool one = (rom[offset] & 0x80) == 0x80;
            this.Y = rom[offset++] & 0x3F;
            if (one)
                Width = 1;
            else
                Width = (rom[offset] & 0x1F) + 1;
            Layer1 = (rom[offset] & 0x20) == 0x20;
            Layer2 = (rom[offset] & 0x40) == 0x40;
            Layer3 = (rom[offset++] & 0x80) == 0x80;
            if (one)
                Height = 1;
            else
            {
                Height = (rom[offset] & 0x3F) + 1;
                Alternate = (rom[offset++] & 0x80) == 0x80;
            }
            byte upper = 0;
            Tilemaps_bytesA[0] = new byte[(Width * Height) * 2];
            if (Layer1)
            {
                for (int i = 0, c = 0; c < (Width * Height) * 2; i++)
                {
                    if (i % 9 == 0)
                        upper = rom[offset++];
                    else
                    {
                        Tilemaps_bytesA[0][c++] = rom[offset++];
                        Tilemaps_bytesA[0][c++] = (byte)((upper >> ((i % 9) - 1)) & 0x01);
                    }
                }
            }
            Tilemaps_bytesA[1] = new byte[(Width * Height) * 2];
            if (Layer2)
            {
                for (int i = 0, c = 0; c < (Width * Height) * 2; i++)
                {
                    if (i % 9 == 0)
                        upper = rom[offset++];
                    else
                    {
                        Tilemaps_bytesA[1][c++] = rom[offset++];
                        Tilemaps_bytesA[1][c++] = (byte)((upper >> ((i % 9) - 1)) & 0x01);
                    }
                }
            }
            Tilemaps_bytesA[2] = new byte[Width * Height];
            if (Layer3)
            {
                for (int i = 0, c = 0; c < Width * Height; i++)
                {
                    if (i % 9 == 0)
                        upper = rom[offset++];
                    else
                    {
                        Tilemaps_bytesA[2][c++] = rom[offset++];
                    }
                }
            }
            if (!Alternate)
                return;
            Tilemaps_bytesB[0] = new byte[(Width * Height) * 2];
            if (Layer1)
            {
                for (int i = 0, c = 0; c < (Width * Height) * 2; i++)
                {
                    if (i % 9 == 0)
                        upper = rom[offset++];
                    else
                    {
                        Tilemaps_bytesB[0][c++] = rom[offset++];
                        Tilemaps_bytesB[0][c++] = (byte)((upper >> ((i % 9) - 1)) & 0x01);
                    }
                }
            }
            Tilemaps_bytesB[1] = new byte[(Width * Height) * 2];
            if (Layer2)
            {
                for (int i = 0, c = 0; c < (Width * Height) * 2; i++)
                {
                    if (i % 9 == 0)
                        upper = rom[offset++];
                    else
                    {
                        Tilemaps_bytesB[1][c++] = rom[offset++];
                        Tilemaps_bytesB[1][c++] = (byte)((upper >> ((i % 9) - 1)) & 0x01);
                    }
                }
            }
            Tilemaps_bytesB[2] = new byte[Width * Height];
            if (Layer3)
            {
                for (int i = 0, c = 0; c < Width * Height; i++)
                {
                    if (i % 9 == 0)
                        upper = rom[offset++];
                    else
                    {
                        Tilemaps_bytesB[2][c++] = rom[offset++];
                    }
                }
            }
        }
        public void WriteToROM(ref int offset)
        {
            rom[offset] = (byte)this.X;
            Bits.SetBit(rom, offset++, 7, B0b7);
            rom[offset] = (byte)this.Y;
            Bits.SetBit(rom, offset++, 7, this.Width == 1 && this.Height == 1);
            rom[offset] = (byte)(this.Width - 1);
            Bits.SetBit(rom, offset, 5, this.Layer1);
            Bits.SetBit(rom, offset, 6, this.Layer2);
            Bits.SetBit(rom, offset++, 7, this.Layer3);
            if (!(this.Height == 1 && this.Width == 1))
            {
                rom[offset] = (byte)(this.Height - 1);
                Bits.SetBit(rom, offset++, 7, this.Alternate);
            }
            if (Layer1)
            {
                for (int i = 0, c = 0; c < (Width * Height) * 2; i++)
                {
                    if (i % 9 == 0)
                        rom[offset++] = 0;
                    else
                    {
                        rom[offset] = Tilemaps_bytesA[0][c++];
                        rom[offset++ - (i % 9)] |= (byte)(Tilemaps_bytesA[0][c++] << ((i % 9) - 1));
                    }
                }
            }
            if (Layer2)
            {
                for (int i = 0, c = 0; c < (Width * Height) * 2; i++)
                {
                    if (i % 9 == 0)
                        rom[offset++] = 0;
                    else
                    {
                        rom[offset] = Tilemaps_bytesA[1][c++];
                        rom[offset++ - (i % 9)] |= (byte)(Tilemaps_bytesA[1][c++] << ((i % 9) - 1));
                    }
                }
            }
            if (Layer3)
            {
                for (int i = 0, c = 0; c < Width * Height; i++)
                {
                    if (i % 9 == 0)
                        rom[offset++] = 0;
                    else
                    {
                        rom[offset++] = Tilemaps_bytesA[2][c++];
                    }
                }
            }
            if (!Alternate)
                return;
            if (Layer1)
            {
                for (int i = 0, c = 0; c < (Width * Height) * 2; i++)
                {
                    if (i % 9 == 0)
                        rom[offset++] = 0;
                    else
                    {
                        rom[offset] = Tilemaps_bytesB[0][c++];
                        rom[offset++ - (i % 9)] |= (byte)(Tilemaps_bytesB[0][c++] << ((i % 9) - 1));
                    }
                }
            }
            if (Layer2)
            {
                for (int i = 0, c = 0; c < (Width * Height) * 2; i++)
                {
                    if (i % 9 == 0)
                        rom[offset++] = 0;
                    else
                    {
                        rom[offset] = Tilemaps_bytesB[1][c++];
                        rom[offset++ - (i % 9)] |= (byte)(Tilemaps_bytesB[1][c++] << ((i % 9) - 1));
                    }
                }
            }
            if (Layer3)
            {
                for (int i = 0, c = 0; c < Width * Height; i++)
                {
                    if (i % 9 == 0)
                        rom[offset++] = 0;
                    else
                    {
                        rom[offset++] = Tilemaps_bytesB[2][c++];
                    }
                }
            }
        }
        /// <summary>
        /// Returns the location of the mouse inside of this tile switch,
        /// relative to the location of this switch on the tilemap.
        /// </summary>
        /// <param name="x">In 16x16 tile units.</param>
        /// <param name="y">In 16x16 tile units.</param>
        /// <returns></returns>
        public Point MousePosition(int x, int y)
        {
            return new Point(x - this.X, y - this.Y);
        }
        /// <summary>
        /// Returns a value indicating whether a specified coordinate in an 
        /// AreaTilemap is outside of this tile switch's region on the tilemap.
        /// </summary>
        /// <param name="x">The X coordinate in the tilemap.</param>
        /// <param name="y">The Y coordinate in the tilemap.</param>
        public bool WithinBounds(int x, int y)
        {
            if (x >= this.X && x < this.X + this.Width &&
                y >= this.Y && y < this.Y + this.Height)
                return true;
            return false;
        }
        /// <summary>
        /// Updates this tile switch's tilemap data from the data in the Tilemap variables.
        /// </summary>
        public void UpdateTilemaps()
        {
            for (int layer = 0; layer < 3; layer++)
            {
                if (Tilemaps_bytesA[layer] == null) continue;
                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        if (layer < 2)
                        {
                            Tilemaps_bytesA[layer][y * Width + x] = TilemapA.Tilemaps_bytes[layer][y * Width + x];
                            if (Alternate)
                                Tilemaps_bytesB[layer][y * Width + x] = TilemapB.Tilemaps_bytes[layer][y * Width + x];
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Resizes the tile arrays to fit the current width and height of the tile switch.
        /// </summary>
        public void ResizeTilemaps()
        {
            for (int i = 0; i < 3; i++)
            {
                if (i < 2)
                    Array.Resize(ref Tilemaps_bytesA[i], (Width * Height) * 2);
                else
                    Array.Resize(ref Tilemaps_bytesA[i], Width * Height);
                if (Alternate)
                    if (i < 2)
                        Array.Resize(ref Tilemaps_bytesB[i], (Width * Height) * 2);
                    else
                        Array.Resize(ref Tilemaps_bytesB[i], Width * Height);
            }
        }
        // Spawning
        public TileSwitch Copy(Area area, Tileset tileset)
        {
            TileSwitch copy = new TileSwitch();
            copy.B0b7 = B0b7;
            copy.Height = Height;
            copy.Layer1 = Layer1;
            copy.Layer2 = Layer2;
            copy.Layer3 = Layer3;
            copy.Alternate = Alternate;
            copy.Tilemaps_bytesA[0] = Bits.Copy(Tilemaps_bytesA[0]);
            copy.Tilemaps_bytesA[1] = Bits.Copy(Tilemaps_bytesA[1]);
            copy.Tilemaps_bytesA[2] = Bits.Copy(Tilemaps_bytesA[2]);
            copy.TilemapA = new AreaTilemap(area, tileset, this, false);
            if (this.Alternate)
            {
                copy.Tilemaps_bytesB[0] = Bits.Copy(Tilemaps_bytesB[0]);
                copy.Tilemaps_bytesB[1] = Bits.Copy(Tilemaps_bytesB[1]);
                copy.Tilemaps_bytesB[2] = Bits.Copy(Tilemaps_bytesB[2]);
                copy.TilemapB = new AreaTilemap(area, tileset, this, true);
            }
            copy.Width = Width;
            copy.X = X;
            copy.Y = Y;
            return copy;
        }
        // Inherited
        public void Clear()
        {
            if (Tilemaps_bytesA[0] != null)
                Array.Clear(Tilemaps_bytesA[0], 0, Tilemaps_bytesA[0].Length);
            if (Tilemaps_bytesA[1] != null)
                Array.Clear(Tilemaps_bytesA[1], 0, Tilemaps_bytesA[1].Length);
            if (Tilemaps_bytesA[2] != null)
                Array.Clear(Tilemaps_bytesA[2], 0, Tilemaps_bytesA[2].Length);
        }

        #endregion
    }
    public class TileSwitchEnumerator : IEnumerator<TileSwitch>
    {
        private TileSwitchCollection collection;
        private TileSwitch currentTileSwitch;
        private int currentIndex;
        public TileSwitchEnumerator(TileSwitchCollection collection)
        {
            this.collection = collection;
            this.currentTileSwitch = default(TileSwitch);
            this.currentIndex = -1;
        }
        public TileSwitch Current
        {
            get { return currentTileSwitch; }
        }
        object IEnumerator.Current
        {
            get { return Current; }
        }
        void IDisposable.Dispose() { }
        public bool MoveNext()
        {
            //Avoids going beyond the end of the collection. 
            if (++currentIndex >= collection.Count)
            {
                return false;
            }
            else
            {
                // Set current box to next item in collection.
                currentTileSwitch = collection[currentIndex];
            }
            return true;
        }
        public void Reset()
        {
            currentIndex = -1;
        }
    }
}
