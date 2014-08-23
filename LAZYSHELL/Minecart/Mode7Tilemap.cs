using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LAZYSHELL.Minecart
{
    public class Mode7Tilemap : Tilemap
    {
        #region Variables

        private PaletteSet paletteSet;
        private State state = State.Instance2;
        private int Width = 64;
        private int Height = 64;

        // public accessors
        public override int Width_p
        {
            get { return Width * 16; }
            set { Width = value / 16; }
        }
        public override int Height_p
        {
            get { return Height * 16; }
            set { Height = value / 16; }
        }
        public Size Size
        {
            get { return new Size(Width, Height); }
        }
        public Size Size_p
        {
            get { return new Size(Width_p, Height_p); }
        }
        public override Tileset Tileset { get; set; }
        public override byte[] Tilemap_bytes { get; set; }
        public override byte[][] Tilemaps_bytes
        {
            get { return new byte[][] { Tilemap_bytes, null, null }; }
            set { Tilemap_bytes = value[0]; }
        }
        public override Tile[] Tilemap_tiles { get; set; }
        public override Tile[][] Tilemaps_tiles
        {
            get { return new Tile[][] { Tilemap_tiles, null, null }; }
            set { Tilemap_tiles = value[0]; }
        }
        public override int[] Pixels { get; set; }
        public override Bitmap Image
        {
            get { return null; }
            set { }
        }

        #endregion

        // Constructor
        public Mode7Tilemap(byte[] tilemap, Tileset tileset, PaletteSet paletteSet)
        {
            this.Tileset = tileset;
            this.paletteSet = paletteSet;
            this.Tilemap_bytes = tilemap;
            this.Pixels = new int[1024 * 1024];
            CreateLayer(); // Create any required layers
            DrawMainscreen();
        }

        #region Methods

        // Assemblers
        public override void ParseTilemap()
        {
            if (Tilemap_tiles == null)
                return;
            for (int i = 0; i < Tilemap_tiles.Length; i++)
                Tilemap_bytes[i] = (byte)Tilemap_tiles[i].Index;
        }

        // Drawing
        private void ChangeSingleTile(int placement, int tile, int x, int y)
        {
            this.Tilemap_tiles[placement] = Tileset.Tileset_tiles[tile]; // Change the tile in the layer map
            Tile source = this.Tilemap_tiles[placement]; // Grab the new tile
            // Draw all 4 subtiles to the appropriate array based on priority
            Do.PixelsToPixels(source.Subtiles[0].Pixels, this.Pixels, Width_p, new Rectangle(x, y, 8, 8));
            Do.PixelsToPixels(source.Subtiles[1].Pixels, this.Pixels, Width_p, new Rectangle((x + 8), y, 8, 8));
            Do.PixelsToPixels(source.Subtiles[2].Pixels, this.Pixels, Width_p, new Rectangle(x, (y + 8), 8, 8));
            Do.PixelsToPixels(source.Subtiles[3].Pixels, this.Pixels, Width_p, new Rectangle((x + 8), (y + 8), 8, 8));
            DrawSingleMainscreenTile(x, y);
        }
        public void Clear()
        {
            Model.M7TilemapA = new byte[0x2000];
            Model.M7TilemapB = new byte[0x2000];
            RedrawTilemaps();
        }
        private void ClearSingleTile(int[] pixels, int x, int y)
        {
            int counter = 0;
            for (int i = 0; i < 256; i++)
            {
                pixels[y * Width_p + x + counter] = 0;
                counter++;
                if (counter % 16 == 0)
                {
                    y++;
                    counter = 0;
                }
            }
        }
        private void CopySingleTileToArray(int[] dst, int[] src, int width, int x, int y)
        {
            int counter = 0;
            for (int i = 0; i < 256; i++)
            {
                if (src[i] != 0)
                    dst[y * width + x + counter] = src[i];
                counter++;
                if (counter % 16 == 0)
                {
                    y++;
                    counter = 0;
                }
            }
        }
        private void CopyToPixelArray(int[] dst, int[] src)
        {
            try
            {
                for (int i = 0; i < src.Length; i++)
                    if (src[i] != 0)
                        dst[i] = src[i];
            }
            catch
            {
                // overflow
            }
        }
        private void CreateLayer()
        {
            if (Tilemap_bytes == null)
                return;
            if (Tileset.Tileset_tiles == null)
                return;
            Tilemap_tiles = new Tile[Width * Height]; // Create our layer here
            int offset = 0;
            for (int i = 0; i < Width * Height && i < Tilemap_bytes.Length; i++)
            {
                byte tilenum = Tilemap_bytes[offset++];
                Tilemap_tiles[i] = Tileset.Tileset_tiles[tilenum];
            }
        }
        private void DrawMainscreen()
        {
            if (Tilemap_tiles == null)
                return;
            for (int i = 0; i < Tilemap_tiles.Length; i++)
            {
                for (int z = 0; z < 4; z++)
                {
                    switch (z)
                    {
                        case 0:
                            Do.PixelsToPixels(Tilemap_tiles[i].Subtiles[z].Pixels, Pixels, Width_p, new Rectangle((i % Width) * 16, (i / Width) * 16, 8, 8));
                            break;
                        case 1:
                            Do.PixelsToPixels(Tilemap_tiles[i].Subtiles[z].Pixels, Pixels, Width_p, new Rectangle((i % Width) * 16 + 8, (i / Width) * 16, 8, 8));
                            break;
                        case 2:
                            Do.PixelsToPixels(Tilemap_tiles[i].Subtiles[z].Pixels, Pixels, Width_p, new Rectangle((i % Width) * 16, (i / Width) * 16 + 8, 8, 8));
                            break;
                        case 3:
                            Do.PixelsToPixels(Tilemap_tiles[i].Subtiles[z].Pixels, Pixels, Width_p, new Rectangle((i % Width) * 16 + 8, (i / Width) * 16 + 8, 8, 8));
                            break;
                        default:
                            break;
                    }
                }
            }
            int bgcolor = paletteSet.Palette[16];
            // Apply BG color
            if (state.BG)
            {
                for (int i = 0; i < Width_p * Height_p; i++)
                {
                    if (Pixels[i] == 0)
                        Pixels[i] = bgcolor;
                }
            }
        }
        private void DrawSingleMainscreenTile(int x, int y)
        {
            int bgcolor = paletteSet.Palette[16];
            CopySingleTileToArray(Pixels, Do.GetPixelRegion(Pixels, 1024, 1024, 16, 16, x, y), Width_p, x, y);
            // Apply BG color
            for (int b = y; b < y + 16; b++)
            {
                for (int a = x; a < x + 16; a++)
                {
                    if (Pixels[b * Width_p + a] == 0)
                        Pixels[b * Width_p + a] = bgcolor;
                }
            }
        }
        public override void RedrawTilemaps()
        {
            Array.Clear(Pixels, 0, Pixels.Length);
            CreateLayer();
            DrawMainscreen();
        }

        // accessor functions
        public override int GetTileNum(int layer, int x, int y, bool ignoretransparent)
        {
            if (x < 0) x = 0;
            if (y < 0) y = 0;
            if (x >= Width_p) x = Width_p - 1;
            if (y >= Height_p) y = Height_p - 1;
            Point p = new Point(x % 16, y % 16);
            y /= 16;
            x /= 16;
            int placement = y * Width + x;
            if (Tilemap_tiles != null)
            {
                if (!ignoretransparent)
                    return Tilemap_tiles[placement].Index;
                else if (Tilemap_tiles[placement].Pixels[p.Y * 16 + p.X] != 0)
                    return Tilemap_tiles[placement].Index;
                else
                    return 0;
            }
            else
                return 0;
        }
        public override int GetTileNum(int layer, int x, int y)
        {
            return GetTileNum(0, x, y, false);
        }
        public override int GetTileNum(int index)
        {
            throw new NotImplementedException();
        }
        public override int[] GetPixels(int layer, Point p, Size s)
        {
            int[] pixels = new int[s.Width * s.Height];
            int bgcolor = paletteSet.Palette[16];
            for (int b = 0, y = p.Y; b < s.Height; b++, y++)
            {
                for (int a = 0, x = p.X; a < s.Width; a++, x++)
                {
                    int srcIndex = y * Width_p + x;
                    int dstIndex = b * s.Width + a;
                    if (srcIndex >= this.Pixels.Length || dstIndex >= pixels.Length)
                        continue;
                    if (this.Pixels[srcIndex] != 0)
                        pixels[dstIndex] = this.Pixels[srcIndex];
                    else
                        pixels[dstIndex] = bgcolor;
                }
            }
            return pixels;
        }
        public override int[] GetPixels(Point location, Size size)
        {
            return GetPixels(0, location, size);
        }
        public override int GetPixelLayer(int x, int y)
        {
            return 0;
        }
        public override int[] GetPriority1Pixels()
        {
            return new int[1024 * 1024];
        }
        public override void SetTileNum()
        {
            throw new NotImplementedException();
        }
        public override void SetTileNum(int tilenum, int layer, int x, int y)
        {
            if (x < 0 || y < 0 || x >= Width_p || y >= Height_p)
                return;
            y /= 16;
            x /= 16;
            int index = y * Width + x;
            if (index < 0x1000)
                ChangeSingleTile(index, tilenum, x * 16, y * 16);
            Tilemap_bytes[y * Width + x] = (byte)tilenum;
        }

        #endregion
    }
}
