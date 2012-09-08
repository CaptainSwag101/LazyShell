using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    [Serializable()]
    public class Mold
    {
        private byte[] sm;

        // Local
        private List<Tile> tiles = new List<Tile>(); public List<Tile> Tiles { get { return tiles; } set { tiles = value; } }

        private bool gridplane;
        public bool Gridplane
        {
            get { return gridplane; }
            set
            {
                gridplane = value;
                foreach (Tile t in tiles)
                    t.Gridplane = value;
            }
        }

        public void InitializeMold(byte[] sm, int offset, List<Tile> uniqueTiles, int parent, int parentoffset)
        {
            if (Bits.GetShort(sm, offset) == 0xFFFF)
                return;
            this.sm = sm;
            Tile tTile;
            gridplane = (sm[offset + 1] & 0x80) == 0x80;
            ushort tilePacketPointer = (ushort)(Bits.GetShort(sm, offset) & 0x7FFF);
            offset = tilePacketPointer;

            if (gridplane)
            {
                tTile = new Tile();
                tTile.InitializeTile(sm, offset, gridplane, 0);
                tiles.Add(tTile);
            }
            else
            {
                for (int i = 0; sm[offset] != 0; i++)
                {
                    // copy
                    if ((sm[offset] & 0x03) == 2)
                    {
                        int temp = offset;
                        int y = sm[offset + 1];
                        int x = sm[offset + 2];
                        bool mirror = (sm[offset] & 0x04) == 0x04;
                        bool invert = (sm[offset] & 0x08) == 0x08;
                        if (mirror)
                            mirror = true;
                        offset = Bits.GetShort(sm, offset + 3);   // get offset of copy
                        for (int c = 0; c < sm[temp] >> 4; c++)   // keep adding tiles until reach max
                        {
                            tTile = new Tile();
                            if ((sm[offset] & 0x03) == 2)
                            {
                                NewMessage.Show("LAZY SHELL", "Error in animation #" + parent + " @ offset $" + offset.ToString("X4") + ". " +
                                    "Data is corrupt: attempted to read a copy within a copy. " +
                                    "The sprites editor will continue to load anyways.\n\nAnimation Data:",
                                    Do.BitArrayToString(sm, 16, true, true, parentoffset), "Lucida Console");
                                break;
                            }
                            else if ((sm[offset] & 0x03) == 1)
                            {
                                tTile.InitializeTile(sm, offset, gridplane, i + c);
                                offset += tTile.TileSize;
                            }
                            else
                            {
                                tTile.InitializeTile(sm, offset, gridplane, i);
                                offset += tTile.TileSize;
                            }
                            tTile.X = (byte)(x + tTile.X);
                            tTile.Y = (byte)(y + tTile.Y);
                            tiles.Add(tTile);
                        }
                        offset = temp;
                        offset += 5;
                    }
                    // 16-bit
                    else if ((sm[offset] & 0x03) == 1)
                    {
                        tTile = new Tile();
                        tTile.InitializeTile(sm, offset, gridplane, i);
                        offset += tTile.TileSize;
                        tiles.Add(tTile);
                        uniqueTiles.Add(tTile);
                    }
                    else
                    {
                        tTile = new Tile();
                        tTile.InitializeTile(sm, offset, gridplane, i);
                        offset += tTile.TileSize;
                        tiles.Add(tTile);
                        uniqueTiles.Add(tTile);
                    }
                }
            }
        }
        public int MoldSize
        {
            get
            {
                int size = 0;
                foreach (Tile t in tiles)
                {
                    if (t.Gridplane)
                    {
                        if (t.Is16bit) size += 2;
                        switch (t.TileFormat)
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
                            if (t.SubTiles[i] != 0)
                                size += t.TileFormat == 1 ? 2 : 1;
                        }
                    }
                }
                return size;
            }
        }

        // drawing
        /// <summary>
        /// A tile index is assigned to each pixel;
        /// </summary>
        private int[] moldTilesPerPixel;
        public int[] MoldTilesPerPixel { get { return moldTilesPerPixel; } set { moldTilesPerPixel = value; } }
        public int[] MoldPixels()
        {
            moldTilesPerPixel = new int[256 * 256];
            int[] pixels = new int[256 * 256];
            Bits.Fill(moldTilesPerPixel, 0xFF);
            int[] theTile;
            if (tiles.Count == 0) { return pixels; }
            Tile temp = (Tile)tiles[0];
            for (int i = 0; i < tiles.Count; i++)
            {
                temp = (Tile)tiles[i];
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
                                moldTilesPerPixel[p.Y * 256 + p.X] = i;
                        }
                    }
                }
            }
            return pixels;
        }
        public int[] GridplanePixels()
        {
            if (tiles.Count > 0)
                return ((Tile)tiles[0]).GetGridplanePixels();
            else
                return new int[32 * 32];
        }
        public int[] TilesetPixels()
        {
            int height = 16, x, y;
            Tile temp;
            height += (tiles.Count / 8) * 16;
            height += (tiles.Count % 8) != 0 ? 16 : 0;
            int[] pixels = new int[128 * height];
            for (int b = 0; b < height / 16; b++)
            {
                for (int a = 0; a < 8; a++)
                {
                    if ((a + (b * 8)) >= tiles.Count) break;
                    temp = (Tile)tiles[a + (b * 8)];
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

        public void NullMold()
        {
            gridplane = true;
        }
        private bool CompareTiles(Tile tileA, Tile tileB, bool checkIfAtLeastOne)
        {
            if (checkIfAtLeastOne)
            {
                int activeQuadrants = 0;
                if (tileA.SubTiles[0] != 0) activeQuadrants++;
                if (tileA.SubTiles[1] != 0) activeQuadrants++;
                if (tileA.SubTiles[2] != 0) activeQuadrants++;
                if (tileA.SubTiles[3] != 0) activeQuadrants++;
                if (tileA.SubTiles[0] == tileB.SubTiles[0] &&
                    tileA.SubTiles[1] == tileB.SubTiles[1] &&
                    tileA.SubTiles[2] == tileB.SubTiles[2] &&
                    tileA.SubTiles[3] == tileB.SubTiles[3] &&
                    tileA.Mirror == tileB.Mirror &&
                    tileA.Invert == tileB.Invert &&
                    activeQuadrants > 2)
                    return true;
                // if 16-bit and at least 2 active quadrants, make copy since will be saving space
                foreach (ushort subtile in tileA.SubTiles)
                    if (subtile >= 0x100 &&
                        tileA.SubTiles[0] == tileB.SubTiles[0] &&
                        tileA.SubTiles[1] == tileB.SubTiles[1] &&
                        tileA.SubTiles[2] == tileB.SubTiles[2] &&
                        tileA.SubTiles[3] == tileB.SubTiles[3] &&
                        tileA.Mirror == tileB.Mirror &&
                        tileA.Invert == tileB.Invert &&
                        activeQuadrants > 1)
                        return true;
            }
            return false;
        }
        public byte[] Recompress(int baseOffset, List<Mold> molds)
        {
            byte[] mold = new byte[0x10000];
            int offset = 0;
            int thisCounter = 0;    // must be outside loop to avoid resetting
            for (int i = 0; i < tiles.Count; i++)
            {
                Tile tile = (Tile)tiles[i];
                #region first compare to find copies
                int counter = 0;
                int copySize = 0;
                Tile tileA = new Tile();
                Tile thisTileA = new Tile();
                Tile tileB = new Tile();
                Tile thisTileB = new Tile();
                int copyOffset = 0;
                int copyDiffX = 0;
                int copyDiffY = 0;
                // look through each mold for copies
                foreach (Mold m in molds)
                {
                    // cancel if we've reached the same mold
                    if (m == this) break;
                    // skip if gridplane; not copyable
                    if (m.Gridplane) continue;
                    counter = 0;
                    // look through all mold's tiles for copies
                    while (counter + 1 < m.Tiles.Count && thisCounter + 1 < tiles.Count)
                    {
                        copySize = 0;
                        tileA = (Tile)m.Tiles[counter];
                        thisTileA = (Tile)tiles[thisCounter];
                        tileB = (Tile)m.Tiles[counter + 1];
                        thisTileB = (Tile)tiles[thisCounter + 1];
                        copyOffset = tileA.TileOffset;
                        // tile's offset wasn't set, thus not a viable tile to copy from
                        if (copyOffset == 0)
                        {
                            counter++; continue;
                        }
                        copyDiffX = thisTileA.X - tileA.X;
                        copyDiffY = thisTileA.Y - tileA.Y;
                        // first check to see if going to be making a copy of more than one, regardless of active quadrants
                        if (tileB.TileOffset != 0 &&
                            thisTileA.SubTiles[0] == tileA.SubTiles[0] &&
                            thisTileA.SubTiles[1] == tileA.SubTiles[1] &&
                            thisTileA.SubTiles[2] == tileA.SubTiles[2] &&
                            thisTileA.SubTiles[3] == tileA.SubTiles[3] &&
                            thisTileA.Mirror == tileA.Mirror &&
                            thisTileA.Invert == tileA.Invert &&
                            thisTileB.SubTiles[0] == tileB.SubTiles[0] &&
                            thisTileB.SubTiles[1] == tileB.SubTiles[1] &&
                            thisTileB.SubTiles[2] == tileB.SubTiles[2] &&
                            thisTileB.SubTiles[3] == tileB.SubTiles[3] &&
                            thisTileB.Mirror == tileB.Mirror &&
                            thisTileB.Invert == tileB.Invert &&
                            copyDiffX == thisTileB.X - tileB.X &&
                            copyDiffY == thisTileB.Y - tileB.Y)
                        {
                            // v3.8: set TileOffset to 0 to prevent later molds from using as a copy
                            thisTileA.TileOffset = 0;
                            thisTileB.TileOffset = 0;
                            // we will be making a copy of at least 2
                            copySize = 2;
                            // now keep moving to find more copies
                            counter += 2;
                            thisCounter += 2;
                            // cancel if at end of first mold's tiles
                            if (counter >= m.Tiles.Count ||
                                thisCounter >= tiles.Count)
                                break;
                            Tile tileC = (Tile)m.Tiles[counter];
                            Tile thisTileC = (Tile)tiles[thisCounter];
                            while (copySize < 15 &&
                                   thisTileC.SubTiles[0] == tileC.SubTiles[0] &&
                                   thisTileC.SubTiles[1] == tileC.SubTiles[1] &&
                                   thisTileC.SubTiles[2] == tileC.SubTiles[2] &&
                                   thisTileC.SubTiles[3] == tileC.SubTiles[3] &&
                                   thisTileC.Mirror == tileC.Mirror &&
                                   copyDiffX == thisTileC.X - tileC.X &&
                                   copyDiffY == thisTileC.Y - tileC.Y)
                            {
                                // stop adding copies if the tile doesn't have an offset
                                // it is probably a copy itself, so we shouldn't add it
                                if (tileC.TileOffset == 0)
                                    break;
                                // v3.8: set TileOffset to 0 to prevent later molds from using as a copy
                                thisTileC.TileOffset = 0;
                                // adding another copy
                                copySize++;
                                // now set to check next one
                                counter++;
                                thisCounter++;
                                // cancel if at end of first mold's tiles
                                if (counter >= m.Tiles.Count ||
                                    thisCounter >= tiles.Count)
                                    break;
                                tileC = (Tile)m.Tiles[counter];
                                thisTileC = (Tile)tiles[thisCounter];
                            }
                            // must break out of this loop too
                            if (tileC.TileOffset == 0)
                                break;
                        }
                        // otherwise, check to see if going to be making a copy of at least one, 
                        // must have at least 3 quadrants active
                        else if (CompareTiles(thisTileA, tileA, true))
                        {
                            // v3.8: set TileOffset to 0 to prevent later molds from using as a copy
                            thisTileA.TileOffset = 0;
                            // we will be making a copy
                            copyOffset = tileA.TileOffset;
                            copyDiffX = thisTileA.X - tileA.X;
                            copyDiffY = thisTileA.Y - tileA.Y;
                            copySize++;
                            // move for next tile
                            thisCounter++;
                        }
                        // last tile wasn't a copy, so move to check next one
                        else
                            counter++;
                        // we've found a copy, so don't try checking for more
                        if (copySize > 0)
                            break;
                    }
                    // we've found a copy, so don't try checking in any more molds
                    if (copySize > 0)
                        break;
                }
                #endregion
                if (copySize > 0)
                {
                    mold[offset] = 2;
                    mold[offset] |= (byte)(copySize << 4);
                    mold[offset + 1] = (byte)copyDiffY;
                    mold[offset + 2] = (byte)copyDiffX;
                    Bits.SetShort(mold, offset + 3, (ushort)copyOffset);
                    offset += 5;
                    i += copySize - 1;
                    thisCounter--;  // must move back one to synchronize counter (it ++'s later)
                }
                // set normal tile
                else
                {
                    tile.TileOffset = baseOffset + offset;
                    tile.Is16bit = false;
                    for (int s = 0, b = 128; s < 4; s++, b /= 2)
                    {
                        if (tile.SubTiles[s] != 0)
                            mold[offset] |= (byte)b;
                        if (tile.SubTiles[s] >= 0x100)
                        {
                            mold[offset] |= 1;
                            tile.Is16bit = true;
                        }
                    }
                    Bits.SetBit(mold, offset, 2, tile.Mirror);
                    Bits.SetBit(mold, offset, 3, tile.Invert);
                    offset++;
                    mold[offset] = (byte)(tile.Y ^ 0x80); offset++;
                    mold[offset] = (byte)(tile.X ^ 0x80); offset++;
                    for (int s = 0; s < 4; s++)
                    {
                        if (tile.SubTiles[s] != 0)
                        {
                            if (!tile.Is16bit)
                                mold[offset++] = (byte)tile.SubTiles[s];
                            else
                            {
                                Bits.SetShort(mold, offset, tile.SubTiles[s]); offset += 2;
                            }
                        }
                    }
                }
                thisCounter++;
            }
            byte[] temp = new byte[offset];
            Bits.SetByteArray(temp, 0, mold);
            return temp;
        }
        [Serializable()]
        public class Tile
        {
            public object Tag;
            private Point mouseDownPosition;
            public Point MouseDownPosition { get { return mouseDownPosition; } set { mouseDownPosition = value; } }
            private bool addedToBuffer;
            public bool AddedToBuffer { get { return addedToBuffer; } set { addedToBuffer = value; } }
            private bool gridplane; public bool Gridplane { get { return gridplane; } set { gridplane = value; } }
            private Subtile[] subtiles; public Subtile[] Subtiles { get { return this.subtiles; } }
            // used by assembly only
            private int tileOffset; public int TileOffset { get { return tileOffset; } set { tileOffset = value; } }

            private byte[] sm;
            public int Size
            {
                get
                {
                    if (gridplane)
                        return 0;
                    int counter = 3;
                    if (is16bit)
                    {
                        if (subTiles[0] != 0) counter += 2;
                        if (subTiles[1] != 0) counter += 2;
                        if (subTiles[2] != 0) counter += 2;
                        if (subTiles[3] != 0) counter += 2;
                    }
                    else
                    {
                        if (subTiles[0] != 0) counter++;
                        if (subTiles[1] != 0) counter++;
                        if (subTiles[2] != 0) counter++;
                        if (subTiles[3] != 0) counter++;
                    }
                    return counter;
                }
            }
            private int tileNum; public int TileNum { get { return tileNum; } }
            private byte tileFormat; public byte TileFormat { get { return tileFormat; } set { tileFormat = value; } }

            public int Width
            {
                get
                {
                    if (gridplane)
                        return (tileFormat & 2) == 2 ? 32 : 24;
                    else
                        return 16;
                }
                set
                {
                    if (value == 24 && Height == 24) tileFormat = 0;
                    if (value == 24 && Height == 32) tileFormat = 1;
                    if (value == 32 && Height == 24) tileFormat = 2;
                    if (value == 32 && Height == 32) tileFormat = 3;
                    tileSize = 1;
                    if (is16bit)
                        tileSize += 2;
                    switch (tileFormat)
                    {
                        case 0: tileSize += 9; break;
                        case 1: tileSize += 12; break;
                        case 2: tileSize += 12; break;
                        case 3: tileSize += 16; break;
                        default: goto case 0;
                    }
                }
            }
            public int Height
            {
                get
                {
                    if (gridplane)
                        return (tileFormat & 1) == 1 ? 32 : 24;
                    else
                        return 16;
                }
                set
                {
                    if (value == 24 && Width == 24) tileFormat = 0;
                    if (value == 32 && Width == 24) tileFormat = 1;
                    if (value == 24 && Width == 32) tileFormat = 2;
                    if (value == 32 && Width == 32) tileFormat = 3;
                    tileSize = 1;
                    if (is16bit)
                        tileSize += 2;
                    switch (tileFormat)
                    {
                        case 0: tileSize += 9; break;
                        case 1: tileSize += 12; break;
                        case 2: tileSize += 12; break;
                        case 3: tileSize += 16; break;
                        default: goto case 0;
                    }
                }
            }

            private int tileSize; public int TileSize { get { return tileSize; } set { tileSize = value; } }

            private ushort[] subTiles;
            public ushort[] SubTiles { get { return subTiles; } set { subTiles = value; } }
            public void SetTileSize()
            {
                is16bit = false;
                foreach (ushort subTile in subTiles)
                {
                    tileSize = 3;
                    if (subTile != 0)
                        tileSize++;
                    if (subTile >= 0x100)
                        is16bit = true;
                }
                if (gridplane)
                {
                    tileSize = 1;
                    if (is16bit)
                        tileSize += 2;
                    switch (tileFormat)
                    {
                        case 0: tileSize += 9; break;
                        case 1: tileSize += 12; break;
                        case 2: tileSize += 12; break;
                        case 3: tileSize += 16; break;
                        default: goto case 0;
                    }
                }
            }
            public bool[] Quadrants
            {
                get
                {
                    return new bool[]
                    {
                        subTiles[0] != 0,
                        subTiles[1] != 0, 
                        subTiles[2] != 0,
                        subTiles[3] != 0
                    };
                }
            }

            private bool is16bit; public bool Is16bit { get { return is16bit; } set { is16bit = value; } }
            private ushort subtiles16bit;
            private bool mirror; public bool Mirror { get { return mirror; } set { mirror = value; } }
            private bool invert; public bool Invert { get { return invert; } set { invert = value; } }
            private byte yPlusOne; public byte YPlusOne { get { return yPlusOne; } set { yPlusOne = value; } }
            private byte yMinusOne; public byte YMinusOne { get { return yMinusOne; } set { yMinusOne = value; } }

            private byte xCoord; public byte X { get { return xCoord; } set { xCoord = value; } }
            private byte yCoord; public byte Y { get { return yCoord; } set { yCoord = value; } }

            public void InitializeTile(byte[] sm, int offset, bool gridplane, int tileNum)
            {
                this.sm = sm;
                this.tileNum = tileNum;
                this.gridplane = gridplane;

                tileSize = 0;

                if (offset >= sm.Length) return;

                if (gridplane)
                {
                    tileFormat = (byte)sm[offset];

                    is16bit = (tileFormat & 0x08) == 0x08;
                    yPlusOne = (tileFormat & 0x10) == 0x10 ? (byte)1 : (byte)0;
                    yMinusOne = (tileFormat & 0x20) == 0x20 ? (byte)1 : (byte)0;
                    mirror = (tileFormat & 0x40) == 0x40;
                    invert = (tileFormat & 0x80) == 0x80;
                    offset++; tileSize++;

                    tileFormat &= 3;

                    if (is16bit)
                    {
                        subtiles16bit = Bits.GetShort(sm, offset);
                        offset += 2;
                        tileSize += 2;
                    }

                    byte[] temp;
                    switch (tileFormat)
                    {
                        case 0: temp = Bits.GetByteArray(sm, offset, 9); tileSize += 9; break;
                        case 1: temp = Bits.GetByteArray(sm, offset, 12); tileSize += 12; break;
                        case 2: temp = Bits.GetByteArray(sm, offset, 12); tileSize += 12; break;
                        case 3: temp = Bits.GetByteArray(sm, offset, 16); tileSize += 16; break;
                        default: goto case 0;
                    }
                    subTiles = new ushort[16];
                    for (int i = 0; i < 16; i++) subTiles[i] = 1;
                    temp.CopyTo(subTiles, 0);
                    if (is16bit)
                    {
                        for (int i = 0, b = 1; i < temp.Length; i++, b *= 2)
                            if ((subtiles16bit & b) == b)
                                subTiles[i] += 0x100;
                    }
                }
                else
                {
                    tileFormat = (byte)(sm[offset] & 0x0F);
                    mirror = (tileFormat & 0x04) == 0x04;
                    invert = (tileFormat & 0x08) == 0x08;

                    tileFormat &= 3;

                    // Set active quadrants
                    bool[] quadrants = new bool[4];
                    for (int i = 0, b = 128; i < 4; i++, b /= 2)
                        quadrants[i] = (sm[offset] & b) == b;

                    offset++; tileSize++;
                    yCoord = (byte)(sm[offset] ^ 0x80); offset++; tileSize++;
                    xCoord = (byte)(sm[offset] ^ 0x80); offset++; tileSize++;

                    // Set the subtiles
                    subTiles = new ushort[4];
                    for (int i = 0; i < 4; i++)
                    {
                        if (quadrants[i])
                        {
                            if (tileFormat == 1)
                            {
                                subTiles[i] = (ushort)(Bits.GetShort(sm, offset) & 0x1FF);
                                offset++; tileSize++;
                            }
                            else
                                subTiles[i] = (ushort)sm[offset];
                            offset++; tileSize++;
                        }
                    }
                }
            }

            // Must be called manually whenever the quadrant bool or subtile number is changed
            public void Set8x8Tiles(byte[] graphics, int[] palette, bool gridplane)
            {
                int stop = 0;
                if (gridplane)
                {
                    if (subTiles == null)
                    {
                        //MessageBox.Show(BitConverter.ToString(sm, tileOffset - 0xFFF, 10));
                        return;
                    }
                    switch (tileFormat)
                    {
                        case 0: stop = 9; break;
                        case 1:
                        case 2: stop = 12; break;
                        case 3: stop = 16; break;
                    }
                    subtiles = new Subtile[16];
                    for (int i = 0; i < stop; i++)
                    {
                        if (subTiles[i] != 0)
                            subtiles[i] = new Subtile(subTiles[i] - 1, graphics, (subTiles[i] - 1) * 0x20, palette, false, false, false, false);
                        else
                            subtiles[i] = new Subtile(0, new byte[0x20], 0, new int[16], false, false, false, false);
                    }
                }
                else
                {
                    subtiles = new Subtile[4];
                    for (int i = 0; i < 4; i++)
                    {
                        if (subTiles[i] != 0)
                            subtiles[i] = new Subtile(subTiles[i] - 1, graphics, (subTiles[i] - 1) * 0x20, palette, false, false, false, false);
                        else
                            subtiles[i] = new Subtile(0, new byte[0x20], 0, new int[16], false, false, false, false);
                    }
                }
            }
            public int[] Get16x16TilePixels()
            {
                int[] pixels = new int[16 * 16];
                int color = 0;
                if (subtiles == null)
                    color = Color.Red.ToArgb();
                if (Bits.Empty(subTiles))
                    color = Color.Gray.ToArgb();
                if (subtiles == null || Bits.Empty(subTiles))
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
                            pixels[x + a + ((y + b) * 16)] = subtiles[i].Pixels[y * 8 + x];
                    }
                }
                if (mirror)
                    Do.FlipHorizontal(pixels, 16, 16);
                if (invert)
                    Do.FlipVertical(pixels, 16, 16);
                return pixels;
            }
            public int[] GetGridplanePixels()
            {
                int[] pixels = new int[32 * 32];
                if (subtiles == null)
                {
                    //MessageBox.Show(BitConverter.ToString(sm, tileOffset, 10));
                    return pixels;
                }
                int w; int h;
                int r; int c;
                switch (tileFormat)
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
                        if (subtiles[i] == null) break;
                        for (int x = 0; x < 8; x++)
                            pixels[x + c + ((y + r) * 32)] = subtiles[i].Pixels[y * 8 + x];
                    }
                }
                if (mirror)
                    Do.FlipHorizontal(pixels, 32, 0, 0, w, h);
                if (invert)
                    Do.FlipVertical(pixels, 32, 0, 0, w, h);
                return pixels;
            }
            public Tile New(bool gridplane)
            {
                Tile empty = new Tile();
                if (gridplane)
                {
                    empty.TileSize = 10;
                    empty.SubTiles = new ushort[16];
                    for (int i = 0; i < 9; i++)
                        empty.SubTiles[i] = 1;
                }
                else
                {
                    empty.TileSize = 3;
                    empty.SubTiles = new ushort[4];
                    empty.X = 0x80;
                    empty.Y = 0x80;
                }
                return empty;
            }
            public Tile Copy()
            {
                Tile copy = new Tile();
                copy.Gridplane = gridplane;
                copy.Invert = invert;
                copy.Is16bit = is16bit;
                copy.Mirror = mirror;
                copy.SubTiles = Bits.Copy(subTiles);
                copy.TileFormat = tileFormat;
                copy.TileOffset = tileOffset;
                copy.TileSize = tileSize;
                copy.X = xCoord;
                copy.Y = yCoord;
                copy.YMinusOne = yMinusOne;
                copy.YPlusOne = yPlusOne;
                return copy;
            }
            public bool CompareSubtiles(Tile source)
            {
                if (Bits.Compare(subTiles, source.SubTiles)) 
                    return true;
                return false;
            }
        }
        public Mold New(bool gridplane)
        {
            Mold empty = new Mold();
            empty.Tiles.Add(new Mold.Tile().New(gridplane));
            empty.Gridplane = gridplane;
            return empty;
        }
        public Mold Copy()
        {
            Mold copy = new Mold();
            foreach (Tile tile in tiles)
                copy.Tiles.Add(tile.Copy());
            copy.Gridplane = gridplane;
            return copy;
        }
    }
}
