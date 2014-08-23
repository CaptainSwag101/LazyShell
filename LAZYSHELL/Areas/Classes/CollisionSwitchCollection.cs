using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace LAZYSHELL.Areas
{
    [Serializable()]
    public class CollisionSwitchCollection : IList<CollisionSwitch>
    {
        #region Variables

        // ROM buffer
        private byte[] rom
        {
            get { return Model.ROM; }
            set { Model.ROM = value; }
        }
        // Properties
        public int AreaIndex { get; set; }
        public List<CollisionSwitch> CollisionSwitches { get; set; }

        #endregion

        // Constructor
        public CollisionSwitchCollection(int index)
        {
            this.AreaIndex = index;
            this.CollisionSwitches = new List<CollisionSwitch>();
            ReadFromROM();
        }

        #region Methods

        // Read/write
        private void ReadFromROM()
        {
            int pointerOffset = (AreaIndex * 2) + 0x1D8DB0;
            int offsetStart = Bits.GetShort(rom, pointerOffset);
            int offsetEnd = Bits.GetShort(rom, pointerOffset + 2);
            if (this.AreaIndex == 511)
                offsetEnd = 0;
            if (offsetStart >= offsetEnd)
                return;
            int offset = offsetStart + 0x1D0000;
            if (AreaIndex == 84) AreaIndex = 84;
            while (offset < offsetEnd + 0x1D0000)
            {
                var collisionSwitch = new CollisionSwitch();
                collisionSwitch.ReadFromROM(ref offset);
                CollisionSwitches.Add(collisionSwitch);
            }
        }
        /// <summary>
        /// Writes the data in the collision switch collection to the ROM buffer.
        /// </summary>
        /// <param name="offset">The offset in the ROM buffer to begin writing the data to.</param>
        /// <returns></returns>
        public void WriteToROM(ref int offset)
        {
            int pointerOffset = (AreaIndex * 2) + 0x1D8DB0;
            Bits.SetShort(rom, pointerOffset, (ushort)offset);
            foreach (var collisionSwitch in CollisionSwitches)
                collisionSwitch.WriteToROM(ref offset);
        }

        #endregion

        #region Enumeration

        public CollisionSwitch this[int index]
        {
            get { return this.CollisionSwitches[index]; }
            set { this.CollisionSwitches[index] = value; }
        }
        public void Add(CollisionSwitch value)
        {
            this.CollisionSwitches.Add(value);
        }
        public void Clear()
        {
            foreach (var collisionSwitch in CollisionSwitches)
                collisionSwitch.Clear();
        }
        public void ClearTilemaps()
        {
            foreach (var collisionSwitch in CollisionSwitches)
            {
                collisionSwitch.Image = null;
                collisionSwitch.Pixels = null;
            }
        }
        public void ClearImages()
        {
            foreach (var collisionSwitch in CollisionSwitches)
            {
                collisionSwitch.Image = null;
            }
        }
        public bool Contains(CollisionSwitch value)
        {
            foreach (var collisionSwitch in CollisionSwitches)
            {
                if (collisionSwitch == value)
                    return true;
            }
            return false;
        }
        public void CopyTo(CollisionSwitch[] collisionSwitchs, int arrayIndex)
        {
            CollisionSwitches.CopyTo(collisionSwitchs, arrayIndex);
        }
        public int Count
        {
            get { return CollisionSwitches.Count; }
        }
        public int IndexOf(CollisionSwitch value)
        {
            for (int i = 0; i < CollisionSwitches.Count; i++)
            {
                if (CollisionSwitches[i] == value)
                    return i;
            }
            return -1;
        }
        public void Insert(int index, CollisionSwitch value)
        {
            if (index < CollisionSwitches.Count)
                CollisionSwitches.Insert(index, value);
            else
                CollisionSwitches.Add(value);
        }
        public void Insert(int index, Point p)
        {
            var collisionSwitch = new CollisionSwitch();
            collisionSwitch.X = (byte)p.X;
            collisionSwitch.Y = (byte)p.Y;
            collisionSwitch.Pixels = Collision.Instance.GetTilemapPixels(collisionSwitch);
            if (index < CollisionSwitches.Count)
                CollisionSwitches.Insert(index, collisionSwitch);
            else
                CollisionSwitches.Add(collisionSwitch);
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public bool Remove(CollisionSwitch value)
        {
            for (int i = 0; i < CollisionSwitches.Count; i++)
            {
                if (CollisionSwitches[i] == value)
                {
                    CollisionSwitches.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public void RemoveAt(int index)
        {
            CollisionSwitches.RemoveAt(index);
        }
        public void Reverse(int index, int count)
        {
            CollisionSwitches.Reverse(index, count);
        }
        // Enumerator
        public IEnumerator<CollisionSwitch> GetEnumerator()
        {
            return new CollisionSwitchEnumerator(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new CollisionSwitchEnumerator(this);
        }

        #endregion
    }
    // classes
    [Serializable()]
    public class CollisionSwitch : Tilemap
    {
        #region Variables

        // ROM buffer
        private byte[] rom
        {
            get { return Model.ROM; }
            set { Model.ROM = value; }
        }
        // Properties
        private int x;
        private int y;
        private bool B0b7 { get; set; }
        // Coordinates
        public int X
        {
            get { return x; }
            set
            {
                x = value;
                ParseTilemap();
            }
        }
        public int Y
        {
            get { return y; }
            set
            {
                y = value;
                ParseTilemap();
            }
        }
        public int Width { get; set; }
        public int Height { get; set; }
        /// <summary>
        /// The total size of the collision switch's binary data.
        /// </summary>
        public int Length
        {
            get
            {
                int length = 2;
                if (!(Width == 1 && Height == 1))
                    length++;
                length += Width * Height;
                length += (Width * Height) / 4;
                if ((Width * Height) % 4 != 0)
                    length++;
                return length;
            }
        }
        public override int Width_p { get { return Width * 16; } set { Width = value / 16; } }
        public override int Height_p { get { return Height * 16; } set { Height = value / 16; } }
        // Tile data
        private byte[] tiles;
        public byte[] Tiles
        {
            get { return tiles; }
            set { tiles = value; }
        }
        public override Tileset Tileset
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        private byte[] tilemap_Bytes;
        public override byte[] Tilemap_bytes
        {
            get
            {
                if (tilemap_Bytes == null)
                    return new byte[0x20C2];
                return tilemap_Bytes;
            }
            set
            {
                tilemap_Bytes = value;
                TilemapToTiles();
            }
        }
        public override byte[][] Tilemaps_bytes
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public override Tile[] Tilemap_tiles
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public override Tile[][] Tilemaps_tiles
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public override int[] Pixels { get; set; }
        private Bitmap image;
        public override Bitmap Image
        {
            get
            {
                if (image == null && Pixels != null)
                    image = Do.PixelsToImage(Pixels, 1024, 1024);
                return image;
            }
            set { image = value; }
        }

        #endregion

        // Constructor
        public CollisionSwitch()
        {
            InitializeVariables();
        }

        #region Methods

        private void InitializeVariables()
        {
            this.Tiles = new byte[2];
            this.Width = 1;
            this.Height = 1;
        }
        // Read/write
        public void ReadFromROM(ref int offset)
        {
            B0b7 = (rom[offset] & 0x80) == 0x80;
            this.x = rom[offset++] & 0x7F;
            bool one = (rom[offset] & 0x80) == 0x80;
            this.y = rom[offset++] & 0x7F;
            if (one)
            {
                Width = 1;
                Height = 1;
            }
            else
            {
                Width = (rom[offset] & 0x0F) + 1;
                Height = (rom[offset++] >> 4) + 1;
            }
            Tiles = new byte[(Width * Height) * 2];
            byte upper = 0;
            for (int i = 0, c = 0; c < (Width * Height) * 2; i++)
            {
                if (i % 5 == 0)
                    upper = rom[offset++];
                else
                {
                    Tiles[c++] = rom[offset++];
                    Tiles[c++] = (byte)((upper >> (((i % 5) - 1) * 2)) & 0x03);
                }
            }
            ParseTilemap();
        }
        public void WriteToROM(ref int offset)
        {
            rom[offset] = (byte)this.x;
            Bits.SetBit(rom, offset++, 7, B0b7);
            rom[offset] = (byte)this.y;
            Bits.SetBit(rom, offset++, 7, Width == 1 && Height == 1);
            if (!(Width == 1 && Height == 1))
            {
                rom[offset] = (byte)(Width - 1);
                rom[offset++] |= (byte)((Height - 1) << 4);
            }
            for (int i = 0, c = 0; c < (Width * Height) * 2; i++)
            {
                if (i % 5 == 0)
                    rom[offset++] = 0;
                else
                {
                    rom[offset] = Tiles[c++];
                    rom[offset++ - (i % 5)] |= (byte)(Tiles[c++] << (((i % 5) - 1) * 2));
                }
            }
        }
        /// <summary>
        /// Resizes the tile array to fit the current width and height of the tile switch.
        /// </summary>
        public void ResizeTilemaps()
        {
            Array.Resize(ref tiles, (Width * Height) * 2);
            ParseTilemap();
        }

        #region External Modification

        public override int[] GetPixels(int layer, Point location, Size size)
        {
            throw new NotImplementedException();
        }
        public override int[] GetPixels(Point location, Size size)
        {
            throw new NotImplementedException();
        }
        public override int[] GetPriority1Pixels()
        {
            throw new NotImplementedException();
        }
        public override int GetPixelLayer(int x, int y)
        {
            return 0;
        }
        public override int GetTileNum(int index)
        {
            return Bits.GetShort(tilemap_Bytes, index * 2);
        }
        public override int GetTileNum(int layer, int x, int y)
        {
            throw new NotImplementedException();
        }
        public override int GetTileNum(int layer, int x, int y, bool ignoretransparent)
        {
            throw new NotImplementedException();
        }
        public override void SetTileNum()
        {
        }
        public override void SetTileNum(int tilenum, int layer, int x, int y)
        {
            int offset = 0x41 * (y / 2);
            if (y % 2 != 0)
                offset += 0x21;
            offset += x;
            offset *= 2;
            Bits.SetShort(tilemap_Bytes, offset, (ushort)tilenum);
        }

        #endregion

        /// <summary>
        /// Creates the tilemap data from the collision switch's tile data and properties.
        /// </summary>
        public override void ParseTilemap()
        {
            tilemap_Bytes = new byte[0x20C2];
            int startOffset = 0x41 * (this.y / 2);
            if (y % 2 != 0)
                startOffset += 0x21;
            startOffset += x;
            startOffset *= 2;
            for (int i = 0, c = 0; c < Tiles.Length; i += 0x42)
            {
                if (c != 0 && (c / 2) % Width == 0)
                    i = ((c / 2) / Width) * 0x40;
                if (c >= Tiles.Length || startOffset + i >= tilemap_Bytes.Length) break;
                tilemap_Bytes[startOffset + i] = Tiles[c++];
                tilemap_Bytes[startOffset + i + 1] = Tiles[c++];
            }
        }
        public override void RedrawTilemaps()
        {
            ParseTilemap();
        }
        /// <summary>
        /// Transfers the tilemap data to the collision switch's tile data.
        /// </summary>
        public void TilemapToTiles()
        {
            int startOffset = 0x41 * (this.y / 2);
            if (y % 2 != 0)
                startOffset += 0x21;
            startOffset += x;
            startOffset *= 2;
            for (int i = 0, c = 0; c < Tiles.Length; i += 0x42)
            {
                if (c != 0 && (c / 2) % Width == 0)
                    i = ((c / 2) / Width) * 0x40;
                if (c >= Tiles.Length || startOffset + i >= tilemap_Bytes.Length) break;
                Tiles[c++] = tilemap_Bytes[startOffset + i];
                Tiles[c++] = tilemap_Bytes[startOffset + i + 1];
            }
        }
        /// <summary>
        /// Returns a value indicating whether a specified offset in an AreaTilemap is
        /// outside of this collision switch's region on the tilemap.
        /// </summary>
        /// <param name="offset">The offset in the AreaTilemap.</param>
        /// <returns></returns>
        public bool WithinBounds(int offset)
        {
            int startOffset = 0x41 * (this.y / 2);
            if (y % 2 != 0)
                startOffset += 0x21;
            startOffset += x;
            startOffset *= 2;
            // check all offsets to see if parameter is one of them
            for (int i = 0, c = 0; c < Tiles.Length; i += 0x42)
            {
                if (c != 0 && (c / 2) % Width == 0)
                    i = ((c / 2) / Width) * 0x40;
                if (c >= Tiles.Length || startOffset + i >= tilemap_Bytes.Length)
                    return false;
                if (startOffset + i == offset)
                    return true;
                c += 2;
            }
            return false;
        }
        // Inherited
        public void Clear()
        {
            Array.Clear(Tiles, 0, Tiles.Length);
        }
        /// <summary>
        /// Creates a deep copy of this instance.
        /// </summary>
        /// <returns></returns>
        public CollisionSwitch Copy()
        {
            CollisionSwitch copy = new CollisionSwitch();
            copy.Tiles = Bits.Copy(Tiles);
            copy.Pixels = Bits.Copy(Pixels);
            copy.Tilemap_bytes = Bits.Copy(tilemap_Bytes);
            copy.Width = Width;
            copy.Height = Height;
            copy.X = x;
            copy.Y = y;
            return copy;
        }

        #endregion
    }
    public class CollisionSwitchEnumerator : IEnumerator<CollisionSwitch>
    {
        private CollisionSwitchCollection collection;
        private CollisionSwitch currentCollisionSwitch;
        private int currentIndex;
        public CollisionSwitchEnumerator(CollisionSwitchCollection collection)
        {
            this.collection = collection;
            this.currentCollisionSwitch = default(CollisionSwitch);
            this.currentIndex = -1;
        }
        public CollisionSwitch Current
        {
            get { return currentCollisionSwitch; }
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
                currentCollisionSwitch = collection[currentIndex];
            }
            return true;
        }
        public void Reset()
        {
            currentIndex = -1;
        }
    }
}
