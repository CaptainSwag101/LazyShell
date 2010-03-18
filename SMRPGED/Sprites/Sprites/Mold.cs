using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMRPGED
{
    [Serializable()]
    public class Mold
    {
        private ushort moldOffset; public ushort MoldOffset { get { return moldOffset; } set { moldOffset = value; } }

        // Tile properties
        private byte[] sm;

        public ushort TileOffset { get { return tile.TileOffset; } set { tile.TileOffset = value; } }
        public int TileSize { get { return tile.TileSize; } set { tile.TileSize = value; } }

        public byte TileFormat { get { return tile.TileFormat; } set { tile.TileFormat = value; } }
        public bool[] Quadrants { get { return tile.Quadrants; } set { tile.Quadrants = value; } }
        public Tile8x8[] Subtiles { get { return tile.Subtiles; } }
        public ushort[] SubTiles { get { return tile.SubTiles; } set { tile.SubTiles = value; } }

        public bool Is16bit { get { return tile.Is16bit; } set { tile.Is16bit = value; } }
        public ushort Subtiles16bit { get { return tile.Subtiles16bit; } set { tile.Subtiles16bit = value; } }
        public byte XCoord { get { return tile.XCoord; } set { tile.XCoord = value; } }
        public byte YCoord { get { return tile.YCoord; } set { tile.YCoord = value; } }
        public byte XCoordChange { get { return tile.XCoordChange; } set { tile.XCoordChange = value; } }
        public byte YCoordChange { get { return tile.YCoordChange; } set { tile.YCoordChange = value; } }
        public byte CopyAmount { get { return tile.CopyAmount; } set { tile.CopyAmount = value; } }
        public ushort CopyPacketOffset { get { return tile.CopyPacketOffset; } set { tile.CopyPacketOffset = value; } }

        public bool Mirror { get { return tile.Mirror; } set { tile.Mirror = value; } }
        public bool Invert { get { return tile.Invert; } set { tile.Invert = value; } }
        public byte YPlusOne { get { return tile.YPlusOne; } set { tile.YPlusOne = value; } }
        public byte YMinusOne { get { return tile.YMinusOne; } set { tile.YMinusOne = value; } }

        public void Set8x8Tiles(byte[] graphics, int[] palette, bool gridplane)
        {
            tile.Set8x8Tiles(graphics, palette, gridplane);
        }
        public int[] SubtilePixels(int num) { return tile.SubtilePixels(num); }

        // Local
        private ArrayList tiles = new ArrayList(); public ArrayList Tiles { get { return tiles; } set { tiles = value; } }
        public ArrayList Copies { get { return tile.Copies; } set { tile.Copies = value; } }

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
        private ushort tilePacketPointer; public ushort TilePacketPointer { get { return tilePacketPointer; } set { tilePacketPointer = value; } }

        private Tile tile;
        private int currentTile;
        public int CurrentTile
        {
            get
            {
                return this.currentTile;
            }
            set
            {
                tile = (Tile)tiles[value];
                this.currentTile = value;
            }
        }
        public void AddNewTile(int index, ushort newOffset)
        {
            Tile tTile = new Tile();
            tTile.TileOffset = newOffset;
            tTile.Gridplane = gridplane;
            tTile.NullTile();
            tiles.Insert(index, tTile);
        }
        public void RemoveCurrentTile()
        {
            if (currentTile < tiles.Count)
            {
                tiles.Remove(tiles[currentTile]);
                this.currentTile = 0;
            }
        }

        public int CurrentCopy { get { return tile.CurrentCopy; } set { tile.CurrentCopy = value; } }
        public void AddNewCopies(byte[] sm, int offset)
        {
            tile.AddNewCopies(sm, offset);
        }
        public void RemoveCurrentCopy()
        {
            tile.RemoveCurrentCopy();
        }

        public void InitializeMold(byte[] sm, int offset)
        {
            this.sm = sm;
            moldOffset = (ushort)offset;

            Tile tTile;

            gridplane = (BitManager.GetByte(sm, offset + 1) & 0x80) == 0x80;
            tilePacketPointer = (ushort)(BitManager.GetShort(sm, offset) & 0x7FFF);

            offset = tilePacketPointer;

            if (gridplane)
            {
                tTile = new Tile();
                tTile.InitializeTile(sm, offset, gridplane, 0, false, false);
                tiles.Add(tTile);
            }
            else
            {
                for (int i = 0; BitManager.GetByte(sm, offset) != 0; i++)
                {
                    tTile = new Tile();
                    tTile.InitializeTile(sm, offset, gridplane, i, false, false);
                    tiles.Add(tTile);
                    if (tTile.TileFormat == 2)
                        offset += 5;
                    else if (tTile.TileFormat == 1)
                    {
                        offset += 3;
                        if (tTile.Quadrants[0]) offset += 2;
                        if (tTile.Quadrants[1]) offset += 2;
                        if (tTile.Quadrants[2]) offset += 2;
                        if (tTile.Quadrants[3]) offset += 2;
                    }
                    else
                    {
                        offset += 3;
                        if (tTile.Quadrants[0]) offset++;
                        if (tTile.Quadrants[1]) offset++;
                        if (tTile.Quadrants[2]) offset++;
                        if (tTile.Quadrants[3]) offset++;
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
                        if (t.TileFormat == 2) size += 4;
                        else
                        {
                            size += 3;
                            for (int i = 0; i < 4; i++)
                            {
                                if (t.Quadrants[i])
                                    size += t.TileFormat == 1 ? 2 : 1;
                            }
                        }
                    }
                }
                return size;
            }
        }

        // drawing
        public int[] MoldPixels(bool box)
        {
            int[] pixels = new int[256 * 256];
            int[] cpixls;
            int[] theTile;
            if (tiles.Count == 0) { return pixels; }
            Tile temp = (Tile)tiles[0];
            for (int i = 0; i < tiles.Count; i++)
            {
                temp = (Tile)tiles[i];
                if (!gridplane && temp.TileFormat == 2)
                {
                    cpixls = new int[256 * 256];
                    cpixls = temp.GetCopyPixels(i, box, currentTile);
                    for (int y = 0; y < 256; y++)
                    {
                        for (int x = 0; x < 256; x++)
                        {
                            if (pixels[y * 256 + x] == 0)
                                pixels[y * 256 + x] = cpixls[y * 256 + x];
                        }
                    }
                }
                else
                {
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
                        yc = temp.YCoord; xc = temp.XCoord; w = h = 16;
                    }

                    for (int y = 0; y < h; y++)
                    {
                        for (int x = 0; x < w; x++)
                        {
                            p = new Point(x + xc, y + yc);
                            if (p.Y < 256 && p.X < 256 && pixels[p.Y * 256 + p.X] == 0)
                            {
                                pixels[p.Y * 256 + p.X] = theTile[(y * w) + x];

                                if (!gridplane && i == currentTile && box && (y == 0 || y == 15 || x == 0 || x == 15))
                                    pixels[p.Y * 256 + p.X] = Color.Gray.ToArgb();
                            }
                        }
                    }
                }
            }
            return pixels;
        }
        public int[] TilesetPixels()
        {
            int[] pixels, theTile;
            int height = 16, x, y;
            Tile temp;

            height += (tiles.Count / 8) * 16;
            height += (tiles.Count % 8) != 0 ? 16 : 0;

            pixels = new int[128 * 64];

            for (int b = 0; b < height / 16; b++)
            {
                for (int a = 0; a < 8; a++)
                {
                    if ((a + (b * 8)) >= tiles.Count) break;
                    temp = (Tile)tiles[a + (b * 8)];
                    if (temp.TileFormat == 2)
                    {
                        for (y = 0; y < 16; y++)
                        {
                            for (x = 0; x < 16; x++)
                            {
                                if (y == x || y == (x ^ 15) || x == (y ^ 15))
                                    pixels[(((b * 16) + y) * 128) + ((a * 16) + x)] = Color.Gray.ToArgb();
                            }
                        }
                    }
                    else
                    {
                        theTile = temp.Get16x16TilePixels();
                        for (y = 0; y < 16; y++)
                        {
                            for (x = 0; x < 16; x++)
                                pixels[(((b * 16) + y) * 128) + ((a * 16) + x)] = theTile[(y * 16) + x];
                        }
                    }
                }
            }

            return pixels;
        }
        public int[] TilePixels { get { if (gridplane) return tile.GetGridplanePixels(); else return tile.Get16x16TileGridPixels(); } }

        public void NullMold()
        {
            gridplane = true;
        }

        [Serializable()]
        public class Tile
        {
            private bool copyChild; public bool CopyChild { get { return copyChild; } set { copyChild = value; } }
            private bool gridplane; public bool Gridplane { get { return gridplane; } set { gridplane = value; } }
            private Tile8x8[] subtiles; public Tile8x8[] Subtiles { get { return this.subtiles; } }

            private byte[] sm;

            private int tileNum; public int TileNum { get { return tileNum; } }
            private byte tileFormat; public byte TileFormat { get { return tileFormat; } set { tileFormat = value; } }

            public int Height { get { return (tileFormat & 1) == 1 ? 32 : 24; } }
            public int Width { get { return (tileFormat & 2) == 2 ? 32 : 24; } }

            private ushort tileOffset; public ushort TileOffset { get { return tileOffset; } set { tileOffset = value; } }
            private int tileSize; public int TileSize { get { return tileSize; } set { tileSize = value; } }

            private bool[] quadrants = new bool[4]; public bool[] Quadrants { get { return quadrants; } set { quadrants = value; } }
            private ushort[] subTiles; public ushort[] SubTiles { get { return subTiles; } set { subTiles = value; } }

            private bool is16bit; public bool Is16bit { get { return is16bit; } set { is16bit = value; } }
            private ushort subtiles16bit; public ushort Subtiles16bit { get { return subtiles16bit; } set { subtiles16bit = value; } }
            private bool mirror; public bool Mirror { get { return mirror; } set { mirror = value; } }
            private bool invert; public bool Invert { get { return invert; } set { invert = value; } }
            private bool copyMirror; public bool CopyMirror { get { return copyMirror; } set { copyMirror = value; } }
            private bool copyInvert; public bool CopyInvert { get { return copyInvert; } set { copyInvert = value; } }
            private byte yPlusOne; public byte YPlusOne { get { return yPlusOne; } set { yPlusOne = value; } }
            private byte yMinusOne; public byte YMinusOne { get { return yMinusOne; } set { yMinusOne = value; } }

            private byte xCoord; public byte XCoord { get { return xCoord; } set { xCoord = value; } }
            private byte yCoord; public byte YCoord { get { return yCoord; } set { yCoord = value; } }

            // copies only
            private byte xCoordChange; public byte XCoordChange { get { return xCoordChange; } set { xCoordChange = value; } }
            private byte yCoordChange; public byte YCoordChange { get { return yCoordChange; } set { yCoordChange = value; } }
            private byte copyAmount; public byte CopyAmount { get { return copyAmount; } set { copyAmount = value; } }
            private ushort copyPacketOffset; public ushort CopyPacketOffset { get { return copyPacketOffset; } set { copyPacketOffset = value; } }
            private ArrayList copies = new ArrayList(); public ArrayList Copies { get { return this.copies; } set { copies = value; } }
            private Tile copy;
            private int currentCopy;
            public int CurrentCopy
            {
                get
                {
                    return this.currentCopy;
                }
                set
                {
                    copy = (Tile)copies[value];
                    this.currentCopy = value;
                }
            }
            public void AddNewCopies(byte[] sm, int offset)
            {
                if (tileFormat == 2)
                {
                    copies = new ArrayList();
                    for (int i = 0; i < copyAmount; i++)
                    {
                        Tile tCopy = new Tile();
                        tCopy.InitializeTile(sm, offset, gridplane, i, mirror, invert);
                        copies.Add(tCopy);
                        offset += 3;
                        if (tCopy.TileFormat == 2)
                            offset += 2;
                        else if (tCopy.TileFormat == 1)
                        {
                            for (int j = 0; j < 4; j++)
                                if (tCopy.Quadrants[j]) offset += 2;
                        }
                        else
                        {
                            for (int j = 0; j < 4; j++)
                                if (tCopy.Quadrants[j]) offset++;
                        }
                    }
                }
            }
            public void RemoveCurrentCopy()
            {
                if (currentCopy < copies.Count)
                {
                    copies.Remove(copies[currentCopy]);
                    this.currentCopy--;
                }
            }

            public void InitializeTile(byte[] sm, int offset, bool gridplane, int tileNum, bool copyMirror, bool copyInvert)
            {
                this.sm = sm;
                this.tileNum = tileNum;
                this.tileOffset = (ushort)offset;
                this.gridplane = gridplane;
                this.copyMirror = copyMirror;
                this.copyInvert = copyInvert;

                tileSize = 0;

                if (offset >= sm.Length) return;

                if (gridplane)
                {
                    tileFormat = (byte)BitManager.GetByte(sm, offset);

                    is16bit = (tileFormat & 0x08) == 0x08;
                    yPlusOne = (tileFormat & 0x10) == 0x10 ? (byte)1 : (byte)0;
                    yMinusOne = (tileFormat & 0x20) == 0x20 ? (byte)1 : (byte)0;
                    mirror = (tileFormat & 0x40) == 0x40;
                    invert = (tileFormat & 0x80) == 0x80;
                    offset++; tileSize++;

                    tileFormat &= 3;

                    if (is16bit)
                    {
                        subtiles16bit = BitManager.GetShort(sm, offset);
                        offset += 2;
                        tileSize += 2;
                    }

                    byte[] temp;
                    switch (tileFormat)
                    {
                        case 0: temp = BitManager.GetByteArray(sm, offset, 9); tileSize += 9; break;
                        case 1: temp = BitManager.GetByteArray(sm, offset, 12); tileSize += 12; break;
                        case 2: temp = BitManager.GetByteArray(sm, offset, 12); tileSize += 12; break;
                        case 3: temp = BitManager.GetByteArray(sm, offset, 16); tileSize += 16; break;
                        default: goto case 0;
                    }
                    subTiles = new ushort[16];
                    for (int i = 0; i < 16; i++) subTiles[i] = 1;
                    temp.CopyTo(subTiles, 0);
                    if (is16bit)
                    {
                        for (int i = 0, b = 1; i < temp.Length; i++, b *= 2)
                        { if ((subtiles16bit & b) == b)subTiles[i] += 0x100; }
                    }
                }
                else
                {
                    tileFormat = (byte)(BitManager.GetByte(sm, offset) & 0x0F);
                    mirror = (tileFormat & 0x04) == 0x04;
                    invert = (tileFormat & 0x08) == 0x08;

                    tileFormat &= 3;
                    if (tileFormat == 2)    // if copy
                    {
                        copyAmount = (byte)(BitManager.GetByte(sm, offset) >> 4); offset++; tileSize++;
                        yCoordChange = BitManager.GetByte(sm, offset); offset++; tileSize++;
                        xCoordChange = BitManager.GetByte(sm, offset); offset++; tileSize++;
                        copyPacketOffset = BitManager.GetShort(sm, offset); tileSize++;

                        offset = copyPacketOffset;
                        for (int i = 0; i < copyAmount; i++)
                        {
                            Tile tTile = new Tile();
                            tTile.InitializeTile(sm, offset, gridplane, i, mirror, invert);

                            if (tTile.TileFormat == 2)
                            {
                                MessageBox.Show("There was a tile copy overflow: tile copying has been canceled.\nThis is most likely due to a bad copy offset.", "WARNING: TILE COPY OVERFLOW", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            tTile.CopyChild = true;
                            copies.Add(tTile);
                            offset += 3;
                            if (tTile.TileFormat == 2)
                                offset += 2;
                            else if (tTile.TileFormat == 1)
                            {
                                for (int j = 0; j < 4; j++)
                                    if (tTile.Quadrants[j]) offset += 2;
                            }
                            else
                            {
                                for (int j = 0; j < 4; j++)
                                    if (tTile.Quadrants[j]) offset++;
                            }
                        }
                        return;
                    }

                    // Set active quadrants
                    for (int i = 0, b = 128; i < 4; i++, b /= 2)
                        quadrants[i] = (BitManager.GetByte(sm, offset) & b) == b;

                    offset++; tileSize++;
                    yCoord = (byte)(BitManager.GetByte(sm, offset) ^ 0x80); offset++; tileSize++;
                    xCoord = (byte)(BitManager.GetByte(sm, offset) ^ 0x80); offset++; tileSize++;

                    // Set the subtiles
                    subTiles = new ushort[4];
                    for (int i = 0; i < 4; i++)
                    {
                        if (quadrants[i])
                        {
                            if (tileFormat == 1)
                            {
                                subTiles[i] = (ushort)(BitManager.GetShort(sm, offset) & 0x1FF);
                                offset++; tileSize++;
                            }
                            else
                                subTiles[i] = (ushort)BitManager.GetByte(sm, offset);
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
                    subtiles = new Tile8x8[16];
                    for (int i = 0; i < stop; i++)
                    {
                        if (subTiles[i] != 0)
                            subtiles[i] = new Tile8x8(subTiles[i] - 1, graphics, (subTiles[i] - 1) * 0x20, palette, false, false, false, false);
                    }
                }
                else
                {
                    if (tileFormat == 2)
                    {
                        if (copy == null)
                        {
                            //MessageBox.Show("The last tile in this copy set is invalid.", "WARNING: INVALID TILE");
                            return;
                        }
                        copy.Set8x8Tiles(graphics, palette, gridplane);
                        return;
                    }
                    subtiles = new Tile8x8[4];
                    for (int i = 0; i < 4; i++)
                    {
                        if (quadrants[i])
                        {
                            if (subTiles[i] != 0)
                                subtiles[i] = new Tile8x8(subTiles[i] - 1, graphics, (subTiles[i] - 1) * 0x20, palette, false, false, false, false);
                        }
                    }
                }
            }
            public int[] Get16x16TilePixels()
            {
                int[] pixels = new int[16 * 16];

                if (subtiles == null) return pixels;

                for (int i = 0, a = 0, b = 0; i < 4; i++)
                {
                    a = (i == 0) || (i == 2) ? 0 : 8;
                    b = (i == 0) || (i == 1) ? 0 : 8;
                    for (int y = 0; y < 8; y++)
                    {
                        if (subtiles[i] == null) break;
                        for (int x = 0; x < 8; x++)
                            pixels[x + a + ((y + b) * 16)] = subtiles[i].Pixels[y * 8 + x];
                    }
                }
                int temp;
                if (mirror)
                {
                    for (int y = 0; y < 16; y++)
                    {
                        for (int a = 0, b = 15; a < 8; a++, b--)
                        {
                            temp = pixels[(y * 16) + a];
                            pixels[(y * 16) + a] = pixels[(y * 16) + b];
                            pixels[(y * 16) + b] = temp;
                        }
                    }
                }
                if (invert)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        for (int a = 0, b = 15; a < 8; a++, b--)
                        {
                            temp = pixels[(a * 16) + x];
                            pixels[(a * 16) + x] = pixels[(b * 16) + x];
                            pixels[(b * 16) + x] = temp;
                        }
                    }
                }
                return pixels;
            }
            public int[] Get16x16TileGridPixels()
            {
                int[] pixels = Get16x16TilePixels();
                int[] zoomed = new int[32 * 32];

                for (int y = 0; y < 32; y++)
                {
                    for (int x = 0; x < 32; x++)
                        zoomed[y * 32 + x] = pixels[y / 2 * 16 + (x / 2)];
                }

                return zoomed;
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
                int temp;
                if (mirror)
                {
                    for (int y = 0; y < h; y++)
                    {
                        for (int a = 0, b = w - 1; a < (w / 2); a++, b--)
                        {
                            temp = pixels[(y * 32) + a];
                            pixels[(y * 32) + a] = pixels[(y * 32) + b];
                            pixels[(y * 32) + b] = temp;
                        }
                    }
                }
                if (invert)
                {
                    for (int x = 0; x < w; x++)
                    {
                        for (int a = 0, b = h - 1; a < (h / 2); a++, b--)
                        {
                            temp = pixels[(a * 32) + x];
                            pixels[(a * 32) + x] = pixels[(b * 32) + x];
                            pixels[(b * 32) + x] = temp;
                        }
                    }
                }
                return pixels;
            }
            public int[] GetCopyPixels(int i, bool box, int currentTile)
            {
                int[] pixels = new int[256 * 256];
                int[] theTile;
                Tile tcpy;
                Color temp;
                int lx, ly, hx, hy;
                hy = hx = 0;
                ly = lx = 255;
                for (int j = 0; j < copies.Count; j++)
                {
                    tcpy = (Tile)copies[j];
                    theTile = tcpy.Get16x16TilePixels();
                    for (int y = 0; y < 16; y++)
                    {
                        for (int x = 0; x < 16; x++)
                        {
                            if (y + (byte)(yCoordChange + tcpy.YCoord) < ly) ly = y + (byte)(yCoordChange + tcpy.YCoord);
                            if (y + (byte)(yCoordChange + tcpy.YCoord) > hy) hy = y + (byte)(yCoordChange + tcpy.YCoord);
                            if (x + (byte)(xCoordChange + tcpy.XCoord) < lx) lx = x + (byte)(xCoordChange + tcpy.XCoord);
                            if (x + (byte)(xCoordChange + tcpy.XCoord) > hx) hx = x + (byte)(xCoordChange + tcpy.XCoord);

                            temp = Color.FromArgb(theTile[(y * 16) + x]);
                            if ((y + (byte)(yCoordChange + tcpy.YCoord)) < 256 &&
                                (x + (byte)(xCoordChange + tcpy.XCoord)) < 256)
                            {
                                if (pixels[((y + (byte)(yCoordChange + tcpy.YCoord)) * 256) + (x + (byte)(xCoordChange + tcpy.XCoord))] == 0)
                                    pixels[((y + (byte)(yCoordChange + tcpy.YCoord)) * 256) + (x + (byte)(xCoordChange + tcpy.XCoord))] = temp.ToArgb();
                            }
                        }
                    }
                }
                if (i == currentTile && box)
                {
                    for (int y = ly; y < hy + 1 && y < 256 && lx < 256; y++)
                    {
                        pixels[y * 256 + lx] = Color.Gray.ToArgb();
                        if (hx < 256) pixels[y * 256 + hx] = Color.Gray.ToArgb();
                    }
                    for (int x = lx; x < hx + 1 && x < 256 && ly < 256; x++)
                    {
                        pixels[ly * 256 + x] = Color.Gray.ToArgb();
                        if (hy < 256) pixels[hy * 256 + x] = Color.Gray.ToArgb();
                    }
                }
                return pixels;
            }
            public int[] SubtilePixels(int num)
            {
                int[] pixels = subtiles[num].Pixels;
                int[] zoomed = new int[32 * 32];

                for (int y = 0; y < 32; y++)
                {
                    for (int x = 0; x < 32; x++)
                        zoomed[y * 32 + x] = pixels[y / 4 * 8 + (x / 4)];
                }
                return zoomed;
            }

            public void NullTile()
            {
                if (gridplane)
                {
                    tileSize = 10;
                    subTiles = new ushort[16];
                    for (int i = 0; i < 9; i++)
                        subTiles[i] = 1;
                }
                else
                {
                    tileSize = 4;
                    subTiles = new ushort[4];
                    subTiles[0] = 1;
                    quadrants[0] = true;
                    xCoord = 0x80;
                    yCoord = 0x80;
                }
            }

            public void UpdateOffsets(short delta, int current)
            {
                if (tileOffset != 0x7FFF && tileOffset > current)
                    tileOffset = (ushort)(tileOffset + delta);
                if (!gridplane && tileFormat == 2 && copyPacketOffset > current)
                    copyPacketOffset = (ushort)(copyPacketOffset + delta);

                foreach (Tile c in copies)
                    c.UpdateOffsets(delta, current);
            }
        }

        public void UpdateOffsets(short delta, int current)
        {
            if (moldOffset > current)
                moldOffset = (ushort)(moldOffset + delta);
            if (tilePacketPointer != 0xFFFF && tilePacketPointer != 0x7FFF & tilePacketPointer > current)
                tilePacketPointer = (ushort)(tilePacketPointer + delta);

            foreach (Tile t in tiles)
                t.UpdateOffsets(delta, current);
        }
    }
}
