using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LazyShell.Sprites
{
    [Serializable()]
    public class Mold
    {
        #region Variables

        // Buffer
        private byte[] buffer;

        // Properties
        public List<Tile> Tiles { get; set; }
        private bool gridplane;
        public bool Gridplane
        {
            get { return gridplane; }
            set
            {
                gridplane = value;
                foreach (var t in Tiles)
                    t.Gridplane = value;
            }
        }
        public int Length
        {
            get
            {
                int size = 0;
                foreach (Tile t in Tiles)
                {
                    if (t.Gridplane)
                    {
                        if (t.Is16bit) size += 2;
                        switch (t.Format)
                        {
                            case 0: size += 9; break;
                            case 1: size += 12; break;
                            case 2: size += 12; break;
                            case 3: size += 16; break;
                            default: goto case 0;
                        }
                    }
                    else
                    {
                        size += 3;
                        for (int i = 0; i < 4; i++)
                        {
                            if (t.Subtile_bytes[i] != 0)
                                size += t.Format == 1 ? 2 : 1;
                        }
                    }
                }
                return size;
            }
        }

        // RGB pixels
        /// <summary>
        /// A tile index is assigned to each pixel;
        /// </summary>
        public int[] MoldTilesPerPixel { get; set; }

        #endregion

        #region Methods

        // Read/write buffer
        public void ReadFromBuffer(byte[] buffer, int offset, List<Tile> uniqueTiles, int parent, int parentoffset)
        {
            this.Tiles = new List<Tile>();
            if (Bits.GetShort(buffer, offset) == 0xFFFF)
                return;
            this.buffer = buffer;
            gridplane = (buffer[offset + 1] & 0x80) == 0x80;
            int tilePacketPointer = Bits.GetShort(buffer, offset) & 0x7FFF;
            offset = tilePacketPointer;
            //
            if (gridplane)
            {
                var tTile = new Tile();
                tTile.ReadFromBuffer(buffer, offset, gridplane);
                Tiles.Add(tTile);
            }
            else
            {
                for (int i = 0; buffer[offset] != 0; i++)
                {
                    // copy
                    if ((buffer[offset] & 0x03) == 2)
                    {
                        int temp = offset;
                        int y = buffer[offset + 1];
                        int x = buffer[offset + 2];
                        bool mirror = (buffer[offset] & 0x04) == 0x04;
                        bool invert = (buffer[offset] & 0x08) == 0x08;
                        if (mirror)
                            mirror = true;
                        offset = Bits.GetShort(buffer, offset + 3);   // get offset of copy
                        if (offset > 0x7FFF)
                        {
                            ErrorMessage("attempted to read a gridplane mold as a copy.", parent, offset, parentoffset);
                            break;
                        }
                        for (int c = 0; c < buffer[temp] >> 4; c++)   // keep adding tiles until reach max
                        {
                            var tTile = new Tile();
                            if (offset > buffer.Length)
                            {
                                ErrorMessage("offset was out of bounds of the animation data.", parent, offset, parentoffset);
                                break;
                            }
                            if ((buffer[offset] & 0x03) == 2)
                            {
                                ErrorMessage("attempted to read a copy within a copy.", parent, offset, parentoffset);
                                break;
                            }
                            else if ((buffer[offset] & 0x03) == 1)
                            {
                                tTile.ReadFromBuffer(buffer, offset, gridplane);
                                offset += tTile.Length;
                            }
                            else
                            {
                                tTile.ReadFromBuffer(buffer, offset, gridplane);
                                offset += tTile.Length;
                            }
                            tTile.X = (byte)(x + tTile.X);
                            tTile.Y = (byte)(y + tTile.Y);
                            Tiles.Add(tTile);
                        }
                        offset = temp;
                        offset += 5;
                    }
                    // 16-bit
                    else if ((buffer[offset] & 0x03) == 1)
                    {
                        var tTile = new Tile();
                        tTile.ReadFromBuffer(buffer, offset, gridplane);
                        offset += tTile.Length;
                        Tiles.Add(tTile);
                        uniqueTiles.Add(tTile);
                    }
                    else
                    {
                        var tTile = new Tile();
                        tTile.ReadFromBuffer(buffer, offset, gridplane);
                        offset += tTile.Length;
                        Tiles.Add(tTile);
                        uniqueTiles.Add(tTile);
                    }
                }
            }
        }

        // Read error message
        private void ErrorMessage(string error, int parent, int offset, int parentoffset)
        {
            NewMessage.Show("LAZY SHELL", "Error in animation #" + parent + " @ offset $" + offset.ToString("X4") + ". " +
                "Data is corrupt: " + error + " " + "The sprites editor will continue to load anyways.\n\nAnimation Data:",
                Do.BitArrayToString(buffer, 16, true, true, parentoffset), "Lucida Console");
        }

        #region Compression

        /// <summary>
        /// Analyzes a mold collection for referenced (copied) tiles and creates
        /// the compressed binary output for writing to the main buffer.
        /// </summary>
        /// <param name="baseOffset">The base offset of the mold data in the main buffer.</param>
        /// <param name="molds">The mold collection to analyze.</param>
        /// <returns></returns>
        public byte[] Compress(int baseOffset, List<Mold> molds)
        {
            // Create buffer for mold data at max size
            byte[] buffer = new byte[0x10000];

            // Initialize offsets
            int offset = 0;
            int thisCounter = 0;    // must be outside loop to avoid resetting

            // Start analyzing data
            for (int i = 0; i < Tiles.Count; i++)
            {
                Tile tile = Tiles[i];

                #region Compare to find copies

                // Initialize variables
                int counter = 0;
                int copySize = 0;
                Tile tileA = new Tile();
                Tile thisTileA = new Tile();
                Tile tileB = new Tile();
                Tile thisTileB = new Tile();
                int copyOffset = 0;
                int copyDiffX = 0;
                int copyDiffY = 0;

                // Look through all molds for copies
                foreach (Mold m in molds)
                {
                    // Cancel if we've reached the same mold
                    if (m == this)
                        break;

                    // Skip if gridplane; not copyable
                    if (m.Gridplane)
                        continue;

                    // Look through all mold's tiles for copies
                    counter = 0;
                    while (counter + 1 < m.Tiles.Count && thisCounter + 1 < Tiles.Count)
                    {
                        copySize = 0;
                        tileA = m.Tiles[counter];
                        thisTileA = Tiles[thisCounter];
                        tileB = m.Tiles[counter + 1];
                        thisTileB = Tiles[thisCounter + 1];
                        copyOffset = tileA.TileOffset;

                        // Tile's offset wasn't set, thus not a viable tile to copy from
                        if (copyOffset == 0)
                        {
                            counter++;
                            continue;
                        }

                        // Get coordinate pair difference
                        copyDiffX = thisTileA.X - tileA.X;
                        copyDiffY = thisTileA.Y - tileA.Y;

                        // First check to see if going to be making a copy of more than one, regardless of active quadrants
                        if (tileB.TileOffset != 0 &&
                            thisTileA.Subtile_bytes[0] == tileA.Subtile_bytes[0] &&
                            thisTileA.Subtile_bytes[1] == tileA.Subtile_bytes[1] &&
                            thisTileA.Subtile_bytes[2] == tileA.Subtile_bytes[2] &&
                            thisTileA.Subtile_bytes[3] == tileA.Subtile_bytes[3] &&
                            thisTileA.Mirror == tileA.Mirror &&
                            thisTileA.Invert == tileA.Invert &&
                            thisTileB.Subtile_bytes[0] == tileB.Subtile_bytes[0] &&
                            thisTileB.Subtile_bytes[1] == tileB.Subtile_bytes[1] &&
                            thisTileB.Subtile_bytes[2] == tileB.Subtile_bytes[2] &&
                            thisTileB.Subtile_bytes[3] == tileB.Subtile_bytes[3] &&
                            thisTileB.Mirror == tileB.Mirror &&
                            thisTileB.Invert == tileB.Invert &&
                            copyDiffX == thisTileB.X - tileB.X &&
                            copyDiffY == thisTileB.Y - tileB.Y)
                        {
                            // Set TileOffset to 0 to prevent later molds from using as a copy
                            thisTileA.TileOffset = 0;
                            thisTileB.TileOffset = 0;

                            // We will be making a copy of at least 2
                            copySize = 2;

                            // Now keep moving to find more copies
                            counter += 2;
                            thisCounter += 2;

                            // Cancel if at end of first mold's tiles
                            if (counter >= m.Tiles.Count || thisCounter >= Tiles.Count)
                                break;

                            // Calculate total copy size
                            Tile tileC = m.Tiles[counter];
                            Tile thisTileC = Tiles[thisCounter];
                            while (copySize < 15 &&
                                   thisTileC.Subtile_bytes[0] == tileC.Subtile_bytes[0] &&
                                   thisTileC.Subtile_bytes[1] == tileC.Subtile_bytes[1] &&
                                   thisTileC.Subtile_bytes[2] == tileC.Subtile_bytes[2] &&
                                   thisTileC.Subtile_bytes[3] == tileC.Subtile_bytes[3] &&
                                   thisTileC.Mirror == tileC.Mirror &&
                                   copyDiffX == thisTileC.X - tileC.X &&
                                   copyDiffY == thisTileC.Y - tileC.Y)
                            {
                                // Stop adding copies if the tile doesn't have an offset.
                                // It is probably a copy itself, so we shouldn't add it.
                                if (tileC.TileOffset == 0)
                                    break;

                                // Set TileOffset to 0 to prevent later molds from using as a copy
                                thisTileC.TileOffset = 0;

                                // Adding another copy
                                copySize++;

                                // Now set to check next one
                                counter++;
                                thisCounter++;

                                // Cancel if at end of first mold's tiles
                                if (counter >= m.Tiles.Count ||
                                    thisCounter >= Tiles.Count)
                                    break;

                                // Load next tile
                                tileC = m.Tiles[counter];
                                thisTileC = Tiles[thisCounter];
                            }

                            // Must break out of this loop too
                            if (tileC.TileOffset == 0)
                                break;
                        }
                        // Otherwise, check to see if going to be making a copy of at least one.
                        // Must have at least 3 quadrants active.
                        else if (CompareTiles(thisTileA, tileA, true))
                        {
                            // Since a copy, must set to 0 to prevent later molds from using as a copy
                            thisTileA.TileOffset = 0;

                            // We will be making a copy, so create copy's properties
                            copyOffset = tileA.TileOffset;
                            copyDiffX = thisTileA.X - tileA.X;
                            copyDiffY = thisTileA.Y - tileA.Y;
                            copySize++;

                            // Move for next tile
                            thisCounter++;
                        }
                        // Last tile wasn't a copy, so move to check next one
                        else
                            counter++;

                        // We've found a copy, so don't try checking for more
                        if (copySize > 0)
                            break;
                    }

                    // We've found a copy, so don't try checking in any more molds
                    if (copySize > 0)
                        break;
                }

                #endregion

                #region Write data to buffer

                // If have copies, write copy data
                if (copySize > 0)
                {
                    buffer[offset] = 2;
                    buffer[offset] |= (byte)(copySize << 4);
                    buffer[offset + 1] = (byte)copyDiffY;
                    buffer[offset + 2] = (byte)copyDiffX;
                    Bits.SetShort(buffer, offset + 3, (ushort)copyOffset);
                    offset += 5;
                    i += copySize - 1;
                    thisCounter--;  // must move back one to synchronize counter (it ++'s later)
                }
                // Else, write default tile data
                else
                {
                    tile.TileOffset = baseOffset + offset;
                    tile.Is16bit = false;
                    for (int s = 0, b = 128; s < 4; s++, b /= 2)
                    {
                        if (tile.Subtile_bytes[s] != 0)
                            buffer[offset] |= (byte)b;
                        if (tile.Subtile_bytes[s] >= 0x100)
                        {
                            buffer[offset] |= 1;
                            tile.Is16bit = true;
                        }
                    }
                    Bits.SetBit(buffer, offset, 2, tile.Mirror);
                    Bits.SetBit(buffer, offset, 3, tile.Invert);
                    offset++;
                    buffer[offset] = (byte)(tile.Y ^ 0x80); offset++;
                    buffer[offset] = (byte)(tile.X ^ 0x80); offset++;
                    for (int s = 0; s < 4; s++)
                    {
                        if (tile.Subtile_bytes[s] != 0)
                        {
                            if (!tile.Is16bit)
                                buffer[offset++] = (byte)tile.Subtile_bytes[s];
                            else
                            {
                                Bits.SetShort(buffer, offset, tile.Subtile_bytes[s]); offset += 2;
                            }
                        }
                    }
                }

                #endregion

                thisCounter++;
            }
            byte[] temp = new byte[offset];
            Bits.SetBytes(temp, 0, buffer);
            return temp;
        }
        /// <summary>
        /// Compares two mold tiles and returns a value indicating whether the first
        /// tile can be a copy/reference of the second tile.
        /// </summary>
        /// <param name="tileA">The first tile.</param>
        /// <param name="tileB">The second tile.</param>
        /// <param name="checkIfAtLeastOne"></param>
        /// <returns></returns>
        private bool CompareTiles(Tile tileA, Tile tileB, bool checkIfAtLeastOne)
        {
            if (checkIfAtLeastOne)
            {
                // Get active quadrants in first tile
                int activeQuadrants = 0;
                if (tileA.Subtile_bytes[0] != 0) activeQuadrants++;
                if (tileA.Subtile_bytes[1] != 0) activeQuadrants++;
                if (tileA.Subtile_bytes[2] != 0) activeQuadrants++;
                if (tileA.Subtile_bytes[3] != 0) activeQuadrants++;

                // Compare subtiles and flipped status of both tiles
                if (tileA.Subtile_bytes[0] == tileB.Subtile_bytes[0] &&
                    tileA.Subtile_bytes[1] == tileB.Subtile_bytes[1] &&
                    tileA.Subtile_bytes[2] == tileB.Subtile_bytes[2] &&
                    tileA.Subtile_bytes[3] == tileB.Subtile_bytes[3] &&
                    tileA.Mirror == tileB.Mirror &&
                    tileA.Invert == tileB.Invert &&
                    activeQuadrants > 2) // Must have at least two active quadrants to be copy
                    return true;

                // If 16-bit and at least 2 active quadrants, make copy since will be saving space
                foreach (ushort subtile in tileA.Subtile_bytes)
                {
                    if (subtile >= 0x100 &&
                        tileA.Subtile_bytes[0] == tileB.Subtile_bytes[0] &&
                        tileA.Subtile_bytes[1] == tileB.Subtile_bytes[1] &&
                        tileA.Subtile_bytes[2] == tileB.Subtile_bytes[2] &&
                        tileA.Subtile_bytes[3] == tileB.Subtile_bytes[3] &&
                        tileA.Mirror == tileB.Mirror &&
                        tileA.Invert == tileB.Invert &&
                        activeQuadrants > 1)
                        return true;
                }
            }
            return false;
        }

        #endregion

        // RGB pixel retrieval
        public int[] MoldPixels()
        {
            MoldTilesPerPixel = new int[256 * 256];
            int[] pixels = new int[256 * 256];
            Bits.Fill(MoldTilesPerPixel, 0xFF);
            if (Tiles.Count == 0)
                return pixels;
            //
            int[] theTile;
            for (int i = 0; i < Tiles.Count; i++)
            {
                Tile temp = Tiles[i];
                int yc, xc, w, h;
                Point p;
                if (gridplane)
                {
                    theTile = temp.GetGridplanePixels();
                    yc = 132 - temp.Height + temp.YPlusOne - temp.YMinusOne;
                    xc = 128 - (temp.Width / 2);
                    w = h = 32;
                }
                else
                {
                    theTile = temp.Get16x16TilePixels();
                    yc = temp.Y; xc = temp.X; w = h = 16;
                }
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        p = new Point(x + xc, y + yc);
                        if (p.Y < 256 && p.X < 256 && pixels[p.Y * 256 + p.X] == 0)
                        {
                            pixels[p.Y * 256 + p.X] = theTile[(y * w) + x];
                            if (theTile[(y * w) + x] != 0)
                                MoldTilesPerPixel[p.Y * 256 + p.X] = i;
                        }
                    }
                }
            }
            return pixels;
        }
        public int[] GridplanePixels()
        {
            if (Tiles.Count > 0)
                return (Tiles[0]).GetGridplanePixels();
            else
                return new int[32 * 32];
        }
        public int[] TilesetPixels()
        {
            int height = 16, x, y;
            Tile temp;
            height += (Tiles.Count / 8) * 16;
            height += (Tiles.Count % 8) != 0 ? 16 : 0;
            int[] pixels = new int[128 * height];
            for (int b = 0; b < height / 16; b++)
            {
                for (int a = 0; a < 8; a++)
                {
                    if ((a + (b * 8)) >= Tiles.Count) break;
                    temp = Tiles[a + (b * 8)];
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

        /// <summary>
        /// Creates a new sprite mold.
        /// </summary>
        /// <param name="gridplane">The mold will be in gridplane format.</param>
        /// <returns></returns>
        public Mold New(bool gridplane)
        {
            Mold empty = new Mold();
            empty.Tiles.Add(new Mold.Tile().New(gridplane));
            empty.Gridplane = gridplane;
            return empty;
        }
        /// <summary>
        /// Creates a deep copy of this instance.
        /// </summary>
        /// <returns></returns>
        public Mold Copy()
        {
            Mold copy = new Mold();
            copy.Tiles = new List<Tile>();
            foreach (Tile tile in Tiles)
                copy.Tiles.Add(tile.Copy());
            copy.Gridplane = gridplane;
            return copy;
        }

        // Universal functions
        public void Clear()
        {
            gridplane = true;
        }

        #endregion

        /// <summary>
        /// Class containing the data and properties of a mold's tile.
        /// </summary>
        [Serializable()]
        public class Tile
        {
            #region Variables

            // Buffer
            private byte[] buffer;

            // public managers
            public object Tag;
            /// <summary>
            /// Gets or sets the position of the mouse relative to the 
            /// tile's location on the mold's tilemap. This is never
            /// modified internally.
            /// </summary>
            public Point MouseDownPosition { get; set; }
            /// <summary>
            /// Gets or sets the modified status of the tile for external
            /// operations. This is never modified internally.
            /// </summary>
            public bool Modified { get; set; }

            /// <summary>
            /// Size of the tile's data.
            /// </summary>
            public int Size
            {
                get
                {
                    if (Gridplane)
                        return 0;
                    int counter = 3;
                    if (Is16bit)
                    {
                        if (Subtile_bytes[0] != 0) counter += 2;
                        if (Subtile_bytes[1] != 0) counter += 2;
                        if (Subtile_bytes[2] != 0) counter += 2;
                        if (Subtile_bytes[3] != 0) counter += 2;
                    }
                    else
                    {
                        if (Subtile_bytes[0] != 0) counter++;
                        if (Subtile_bytes[1] != 0) counter++;
                        if (Subtile_bytes[2] != 0) counter++;
                        if (Subtile_bytes[3] != 0) counter++;
                    }
                    return counter;
                }
            }

            // Dimensions
            public int Width
            {
                get
                {
                    if (Gridplane)
                        return (Format & 2) == 2 ? 32 : 24;
                    else
                        return 16;
                }
                set
                {
                    if (value == 24 && Height == 24) Format = 0;
                    if (value == 24 && Height == 32) Format = 1;
                    if (value == 32 && Height == 24) Format = 2;
                    if (value == 32 && Height == 32) Format = 3;
                    Length = 1;
                    if (Is16bit)
                        Length += 2;
                    switch (Format)
                    {
                        case 0: Length += 9; break;
                        case 1: Length += 12; break;
                        case 2: Length += 12; break;
                        case 3: Length += 16; break;
                        default: goto case 0;
                    }
                }
            }
            public int Height
            {
                get
                {
                    if (Gridplane)
                        return (Format & 1) == 1 ? 32 : 24;
                    else
                        return 16;
                }
                set
                {
                    if (value == 24 && Width == 24) Format = 0;
                    if (value == 32 && Width == 24) Format = 1;
                    if (value == 24 && Width == 32) Format = 2;
                    if (value == 32 && Width == 32) Format = 3;
                    Length = 1;
                    if (Is16bit)
                        Length += 2;
                    switch (Format)
                    {
                        case 0: Length += 9; break;
                        case 1: Length += 12; break;
                        case 2: Length += 12; break;
                        case 3: Length += 16; break;
                        default: goto case 0;
                    }
                }
            }

            // Properties
            public ushort[] Subtile_bytes { get; set; }
            public Subtile[] Subtile_tiles { get; set; }
            public int Length { get; set; }
            public bool Gridplane { get; set; }
            public byte Format { get; set; }
            public bool Is16bit { get; set; }
            public bool Mirror { get; set; }
            public bool Invert { get; set; }
            public byte YPlusOne { get; set; }
            public byte YMinusOne { get; set; }
            public byte X { get; set; }
            public byte Y { get; set; }

            // Only used when writing to buffer
            public int TileOffset { get; set; }

            #endregion

            #region Methods

            // Read/write buffer
            public void ReadFromBuffer(byte[] buffer, int offset, bool gridplane)
            {
                this.buffer = buffer;
                this.Gridplane = gridplane;
                Length = 0;
                if (offset >= buffer.Length)
                    return;
                //
                if (gridplane)
                {
                    Format = (byte)buffer[offset++];
                    //
                    Is16bit = (Format & 0x08) == 0x08;
                    YPlusOne = (Format & 0x10) == 0x10 ? (byte)1 : (byte)0;
                    YMinusOne = (Format & 0x20) == 0x20 ? (byte)1 : (byte)0;
                    Mirror = (Format & 0x40) == 0x40;
                    Invert = (Format & 0x80) == 0x80;
                    Length++;
                    //
                    Format &= 3;
                    //
                    int subtiles16bit = 0;
                    if (Is16bit)
                    {
                        subtiles16bit = Bits.GetShort(buffer, offset);
                        offset += 2;
                        Length += 2;
                    }
                    //
                    byte[] temp;
                    switch (Format)
                    {
                        case 0: temp = Bits.GetBytes(buffer, offset, 9); Length += 9; break;
                        case 1: temp = Bits.GetBytes(buffer, offset, 12); Length += 12; break;
                        case 2: temp = Bits.GetBytes(buffer, offset, 12); Length += 12; break;
                        case 3: temp = Bits.GetBytes(buffer, offset, 16); Length += 16; break;
                        default: goto case 0;
                    }
                    Subtile_bytes = new ushort[16];
                    for (int i = 0; i < 16; i++)
                        Subtile_bytes[i] = 1;
                    temp.CopyTo(Subtile_bytes, 0);
                    if (Is16bit)
                    {
                        for (int i = 0, b = 1; i < temp.Length; i++, b *= 2)
                            if ((subtiles16bit & b) == b)
                                Subtile_bytes[i] += 0x100;
                    }
                }
                else
                {
                    Format = (byte)(buffer[offset] & 0x0F);
                    Mirror = (Format & 0x04) == 0x04;
                    Invert = (Format & 0x08) == 0x08;
                    Format &= 3;
                    // Set active quadrants
                    bool[] quadrants = new bool[4];
                    for (int i = 0, b = 128; i < 4; i++, b /= 2)
                        quadrants[i] = (buffer[offset] & b) == b;
                    //
                    offset++; Length++;
                    Y = (byte)(buffer[offset] ^ 0x80); offset++; Length++;
                    X = (byte)(buffer[offset] ^ 0x80); offset++; Length++;
                    // Set the subtiles
                    Subtile_bytes = new ushort[4];
                    for (int i = 0; i < 4; i++)
                    {
                        if (quadrants[i])
                        {
                            if (Format == 1)
                            {
                                Subtile_bytes[i] = (ushort)(Bits.GetShort(buffer, offset) & 0x1FF);
                                offset++; Length++;
                            }
                            else
                                Subtile_bytes[i] = (ushort)buffer[offset];
                            offset++; Length++;
                        }
                    }
                }
            }

            // Subtiles
            public void DrawSubtiles(byte[] graphics, int[] palette, bool gridplane)
            {
                int stop = 0;
                if (gridplane)
                {
                    if (Subtile_bytes == null)
                        return;
                    switch (Format)
                    {
                        case 0: stop = 9; break;
                        case 1:
                        case 2: stop = 12; break;
                        case 3: stop = 16; break;
                    }
                    Subtile_tiles = new Subtile[16];
                    for (int i = 0; i < stop; i++)
                    {
                        if (Subtile_bytes[i] != 0)
                            Subtile_tiles[i] = new Subtile(Subtile_bytes[i] - 1, graphics, (Subtile_bytes[i] - 1) * 0x20, palette, false, false, false, false);
                        else
                            Subtile_tiles[i] = new Subtile(0, new byte[0x20], 0, new int[16], false, false, false, false);
                    }
                }
                else
                {
                    Subtile_tiles = new Subtile[4];
                    for (int i = 0; i < 4; i++)
                    {
                        if (Subtile_bytes[i] != 0)
                            Subtile_tiles[i] = new Subtile(Subtile_bytes[i] - 1, graphics, (Subtile_bytes[i] - 1) * 0x20, palette, false, false, false, false);
                        else
                            Subtile_tiles[i] = new Subtile(0, new byte[0x20], 0, new int[16], false, false, false, false);
                    }
                }
            }
            public bool CompareSubtiles(Tile source)
            {
                if (Bits.Compare(Subtile_bytes, source.Subtile_bytes))
                    return true;
                return false;
            }

            // RGB pixel retrieval
            public int[] Get16x16TilePixels()
            {
                int[] pixels = new int[16 * 16];
                int color = 0;
                if (Subtile_tiles == null)
                    color = Color.Red.ToArgb();
                if (Bits.Empty(Subtile_bytes))
                    color = Color.Gray.ToArgb();
                if (Subtile_tiles == null || Bits.Empty(Subtile_bytes))
                {
                    for (int i = 0; i < 16; i++)
                    {
                        pixels[i * 16 + i] = color; // UL to LR
                        pixels[i * 16 + 15 - i] = color; // UR to LL
                        pixels[i] = color; // top line
                        pixels[i * 16] = color; // left line
                        pixels[i * 16 + 15] = color; // right line
                        pixels[15 * 16 + i] = color; // bottom line
                    }
                    return pixels;
                }
                for (int i = 0, a = 0, b = 0; i < 4; i++)
                {
                    a = (i == 0) || (i == 2) ? 0 : 8;
                    b = (i == 0) || (i == 1) ? 0 : 8;
                    for (int y = 0; y < 8; y++)
                    {
                        for (int x = 0; x < 8; x++)
                            pixels[x + a + ((y + b) * 16)] = Subtile_tiles[i].Pixels[y * 8 + x];
                    }
                }
                if (Mirror)
                    Do.FlipHorizontal(pixels, 16, 16);
                if (Invert)
                    Do.FlipVertical(pixels, 16, 16);
                return pixels;
            }
            public int[] GetGridplanePixels()
            {
                int[] pixels = new int[32 * 32];
                if (Subtile_tiles == null)
                    return pixels;
                //
                int w; int h;
                int r; int c;
                switch (Format)
                {
                    case 0: w = h = 24; break;
                    case 1: w = 24; h = 32; break;
                    case 2: w = 32; h = 24; break;
                    case 3: w = 32; h = 32; break;
                    default: goto case 0;
                }
                for (int i = 0; i < ((h / 8) * (w / 8)); i++)
                {
                    r = (i / (w / 8)) * 8; c = (i % (w / 8)) * 8;
                    for (int y = 0; y < 8; y++)
                    {
                        if (Subtile_tiles[i] == null) break;
                        for (int x = 0; x < 8; x++)
                            pixels[x + c + ((y + r) * 32)] = Subtile_tiles[i].Pixels[y * 8 + x];
                    }
                }
                if (Mirror)
                    Do.FlipHorizontal(pixels, 32, 0, 0, w, h);
                if (Invert)
                    Do.FlipVertical(pixels, 32, 0, 0, w, h);
                return pixels;
            }

            /// <summary>
            /// Updates the Length property based on the tile's current properties.
            /// </summary>
            public void UpdateTileLength()
            {
                Is16bit = false;
                foreach (ushort subtile in Subtile_bytes)
                {
                    Length = 3;
                    if (subtile != 0)
                        Length++;
                    if (subtile >= 0x100)
                        Is16bit = true;
                }
                if (Gridplane)
                {
                    Length = 1;
                    if (Is16bit)
                        Length += 2;
                    switch (Format)
                    {
                        case 0: Length += 9; break;
                        case 1: Length += 12; break;
                        case 2: Length += 12; break;
                        case 3: Length += 16; break;
                        default: goto case 0;
                    }
                }
            }

            /// <summary>
            /// Creates a new mold tile.
            /// </summary>
            /// <param name="gridplane">The mold tile will be in gridplane format.</param>
            /// <returns></returns>
            public Tile New(bool gridplane)
            {
                Tile empty = new Tile();
                if (gridplane)
                {
                    empty.Length = 10;
                    empty.Subtile_bytes = new ushort[16];
                    for (int i = 0; i < 9; i++)
                        empty.Subtile_bytes[i] = 1;
                }
                else
                {
                    empty.Length = 3;
                    empty.Subtile_bytes = new ushort[4];
                    empty.X = 0x80;
                    empty.Y = 0x80;
                }
                return empty;
            }
            /// <summary>
            /// Creates a deep copy of this instance.
            /// </summary>
            /// <returns></returns>
            public Tile Copy()
            {
                Tile copy = new Tile();
                copy.Gridplane = Gridplane;
                copy.Invert = Invert;
                copy.Is16bit = Is16bit;
                copy.Mirror = Mirror;
                copy.Subtile_bytes = Bits.Copy(Subtile_bytes);
                copy.Format = Format;
                copy.TileOffset = TileOffset;
                copy.Length = Length;
                copy.X = X;
                copy.Y = Y;
                copy.YMinusOne = YMinusOne;
                copy.YPlusOne = YPlusOne;
                return copy;
            }

            #endregion
        }
    }
}
