using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LAZYSHELL
{
    [Serializable()]
    public class E_Mold
    {
        private ushort moldOffset; public ushort MoldOffset { get { return moldOffset; } set { moldOffset = value; } }

        // Tile properties
        private byte[] sm;
        public ushort TileOffset { get { return tile.TileOffset; } set { tile.TileOffset = value; } }

        public byte TileIndex { get { return tile.TileIndex; } set { tile.TileIndex = value; } }
        public bool Empty { get { return tile.Empty; } set { tile.Empty = value; } }
        public bool Filler { get { return tile.Filler; } set { tile.Filler = value; } }
        public byte FillAmount { get { return tile.FillAmount; } set { tile.FillAmount = value; } }
        public bool Mirrored { get { return tile.Mirrored; } set { tile.Mirrored = value; } }
        public bool Inverted { get { return tile.Inverted; } set { tile.Inverted = value; } }

        // Local
        private ArrayList tiles = new ArrayList(); public ArrayList Tiles { get { return tiles; } set { tiles = value; } }

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
            if (tile != null && tile.Filler)
                tTile.TileOffset += 2;
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
        public void MoveCurrentTile(int index)
        {
            tiles.Reverse(index, 2);
        }

        // Start
        public void InitializeMold(byte[] sm, int offset, ushort end)
        {
            this.sm = sm;
            moldOffset = (ushort)offset;
            Tile tTile;

            tilePacketPointer = BitManager.GetShort(sm, offset);
            offset = tilePacketPointer;

            for (int i = 0; offset < sm.Length && offset < end; i++)
            {
                if (offset >= sm.Length) break;

                tTile = new Tile();
                tTile.InitializeTile(sm, offset, i);
                tiles.Add(tTile);
                if (tTile.Filler)
                    offset += 3;
                else
                    offset++;
            }
        }
        public int MoldSize
        {
            get
            {
                int size = 0;
                foreach (Tile t in tiles)
                    size += t.Filler ? 3 : 1;
                return size;
            }
        }

        [Serializable()]
        public class Tile
        {
            private byte[] sm;

            private int tileNum; public int TileNum { get { return tileNum; } }
            private ushort tileOffset; public ushort TileOffset { get { return tileOffset; } set { tileOffset = value; } }

            private bool filler; public bool Filler { get { return filler; } set { filler = value; } }
            private bool empty; public bool Empty { get { return empty; } set { empty = value; } }

            private byte tileIndex; public byte TileIndex { get { return tileIndex; } set { tileIndex = value; } }

            private byte fillAmount; public byte FillAmount { get { return fillAmount; } set { fillAmount = value; } }
            private bool mirrored; public bool Mirrored { get { return mirrored; } set { mirrored = value; } }
            private bool inverted; public bool Inverted { get { return inverted; } set { inverted = value; } }

            public void InitializeTile(byte[] sm, int offset, int tileNum)
            {
                this.tileNum = tileNum;
                this.tileOffset = (ushort)offset;
                this.sm = sm;

                filler = sm[offset] == 0xFE;
                if (filler)
                {
                    offset++;

                    empty = sm[offset] == 0xFF;
                    if (empty)
                        tileIndex = 0xFF;
                    else
                    {
                        mirrored = (sm[offset] & 0x40) == 0x40;
                        inverted = (sm[offset] & 0x80) == 0x80;
                        tileIndex = (byte)(sm[offset] & 0x3F);
                    }
                    offset++;

                    fillAmount = sm[offset];
                }
                else
                {
                    empty = sm[offset] == 0xFF;
                    if (empty)
                        tileIndex = 0xFF;
                    else
                    {
                        mirrored = (sm[offset] & 0x40) == 0x40;
                        inverted = (sm[offset] & 0x80) == 0x80;
                        tileIndex = (byte)(sm[offset] & 0x3F);
                    }
                }
            }
        }
        public int[] MoldPixels(E_Animation animation, E_Tileset tileset, bool box)
        {
            int[] pixels = new int[256 * 256];
            int[] temp = new int[16 * 16];
            Tile tTile;
            Tile16x16 tTile16x16;
            int x, y, fill;
            Point p;

            for (int i = 0, a = 0; i < tiles.Count; i++, a++)
            {
                tTile = (Tile)tiles[i];

                if (tTile.Filler)
                {
                    fill = tTile.FillAmount == 0 ? 256 : tTile.FillAmount;

                    for (int b = 0; b < fill; b++, a++)
                    {
                        y = a / animation.MoldsWidth;
                        x = a % animation.MoldsWidth;

                        if (x >= animation.MoldsWidth || y >= animation.MoldsHeight)
                            return pixels;

                        if (tTile.TileIndex != 0xFF)
                        {
                            tTile16x16 = (Tile16x16)tileset.Tileset[tTile.TileIndex];
                            temp = tTile16x16.Pixels();

                            if (tTile.Mirrored) Mirror(temp);
                            if (tTile.Inverted) Invert(temp);

                            CopyOverTile16x16(pixels, temp, x, y, 256);
                        }

                        p = new Point(x * 16, y * 16);
                        if (box && i == currentTile)
                        {
                            for (int c = 0; c < 16; c++)
                            {
                                pixels[p.Y * 256 + p.X + c] = Color.Red.ToArgb();
                                pixels[(p.Y + 15) * 256 + p.X + c] = Color.Red.ToArgb();
                            }
                            for (int c = 0; c < 16; c++)
                            {
                                pixels[(p.Y + c) * 256 + p.X] = Color.Red.ToArgb();
                                pixels[(p.Y + c) * 256 + p.X + 15] = Color.Red.ToArgb();
                            }
                        }
                    }
                    a--;
                }
                else
                {
                    y = a / animation.MoldsWidth;
                    x = a % animation.MoldsWidth;

                    if (x >= animation.MoldsWidth || y >= animation.MoldsHeight)
                        return pixels;

                    if (tTile.TileIndex != 0xFF)
                    {
                        tTile16x16 = (Tile16x16)tileset.Tileset[tTile.TileIndex];
                        temp = tTile16x16.Pixels();

                        if (tTile.Mirrored) Mirror(temp);
                        if (tTile.Inverted) Invert(temp);

                        CopyOverTile16x16(pixels, temp, x, y, 256);
                    }

                    p = new Point(x * 16, y * 16);
                    if (box && i == currentTile)
                    {
                        for (int c = 0; c < 16; c++)
                        {
                            pixels[p.Y * 256 + p.X + c] = Color.Red.ToArgb();
                            pixels[(p.Y + 15) * 256 + p.X + c] = Color.Red.ToArgb();
                        }
                        for (int c = 0; c < 16; c++)
                        {
                            pixels[(p.Y + c) * 256 + p.X] = Color.Red.ToArgb();
                            pixels[(p.Y + c) * 256 + p.X + 15] = Color.Red.ToArgb();
                        }
                    }
                }
            }
            return pixels;
        }
        private void CopyOverTile16x16(int[] dest, int[] source, int x, int y, int w)
        {
            x *= 16;
            y *= 16;
            for (int b = 0, d = y; b < 16; b++, d++)
            {
                for (int a = 0, c = x; a < 16; a++, c++)
                {
                    dest[d * w + c] = source[b * 16 + a];
                }
            }
        }
        private void Mirror(int[] pixels)
        {
            int temp = 0;

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
        private void Invert(int[] pixels)
        {
            int temp = 0;

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

        public void UpdateOffsets(int delta, int current)
        {
            if (moldOffset > current)
                moldOffset = (ushort)(moldOffset + delta);
            if (tilePacketPointer != 0xFFFF && tilePacketPointer > current)
                tilePacketPointer = (ushort)(tilePacketPointer + delta);

            foreach (Tile t in tiles)
                if (t.TileOffset != 0xFFFF && t.TileOffset > current)
                    t.TileOffset = (ushort)(t.TileOffset + delta);
        }
    }
}
