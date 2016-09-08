﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LazyShell.Minecart
{
    public class SideTilemap : Tilemap
    {
        #region Variables

        private PaletteSet paletteSet;
        private State state = State.Instance2;
        public int Width { get; set; }
        public int Height { get; set; }
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
        private int[] pixels = new int[256 * 256];
        private int[]
            L1Priority0 = new int[256 * 256],
            L1Priority1 = new int[256 * 256],
            L2Priority0 = new int[256 * 256],
            L2Priority1 = new int[256 * 256];

        // accessors
        public Size Size
        {
            get { return new Size(Width, Height); }
        }
        public Size Size_p
        {
            get { return new Size(Width_p, Height_p); }
        }
        public override Tileset Tileset { get; set; }
        public override byte[] Tilemap_bytes
        {
            get { return Tilemaps_bytes[0]; }
            set { Tilemaps_bytes[0] = value; }
        }
        public override byte[][] Tilemaps_bytes { get; set; }
        public override Tile[] Tilemap_tiles
        {
            get { return Tilemaps_tiles[0]; }
            set { Tilemaps_tiles[0] = value; }
        }
        public override Tile[][] Tilemaps_tiles { get; set; }
        public override int[] Pixels
        {
            get { return pixels; }
            set { pixels = value; }
        }
        public override Bitmap Image
        {
            get { return null; }
            set { }
        }

        #endregion

        // Constructor
        public SideTilemap(byte[] tilemapL1, byte[] tilemapL2, Tileset tileset, PaletteSet paletteSet)
        {
            this.Tileset = tileset;
            this.paletteSet = paletteSet;
            this.Width = 16;
            this.Height = 16;
            this.Tilemaps_bytes = new byte[3][];
            this.Tilemaps_bytes[0] = tilemapL1;
            this.Tilemaps_bytes[1] = tilemapL2;
            this.Tilemaps_tiles = new Tile[3][];
            if (tilemapL2 == null)  // if the editable map
            {
                Width = 256;
                pixels = new int[Width_p * Height_p];
                L1Priority0 = new int[Width_p * Height_p];
                L1Priority1 = new int[Width_p * Height_p];
                L2Priority0 = new int[Width_p * Height_p];
                L2Priority1 = new int[Width_p * Height_p];
            }
            CreateLayer(0); // Create any required layers
            CreateLayer(1); // Create any required layers
            DrawAllLayers();
            CreateMainscreen();
        }

        #region Methods

        // Assemblers
        public override void ParseTilemap()
        {
            for (int a = 0; a < Width / 16; a++)
            {
                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        int offset = (y * 16 + x) + (a * 256);
                        Tilemaps_bytes[0][offset] = (byte)Tilemaps_tiles[0][y * Width + x + (a * 16)].Index;
                    }
                }
            }
        }

        // Drawing
        private void ChangeSingleTile(int placement, int tile, int x, int y)
        {
            this.Tilemaps_tiles[0][placement] = Tileset.Tileset_tiles[tile]; // Change the tile in the layer map
            Tile source = this.Tilemaps_tiles[0][placement]; // Grab the new tile
            // Draw all 4 subtiles to the appropriate array based on priority
            Do.PixelsToPixels(source.Subtiles[0].Pixels, this.pixels, Width_p, new Rectangle(x, y, 8, 8));
            Do.PixelsToPixels(source.Subtiles[1].Pixels, this.pixels, Width_p, new Rectangle((x + 8), y, 8, 8));
            Do.PixelsToPixels(source.Subtiles[2].Pixels, this.pixels, Width_p, new Rectangle(x, (y + 8), 8, 8));
            Do.PixelsToPixels(source.Subtiles[3].Pixels, this.pixels, Width_p, new Rectangle((x + 8), (y + 8), 8, 8));
        }
        public void Clear(int count)
        {
            Model.SSTilemap = new byte[0x1000];
            RedrawTilemaps();
        }
        private void ClearSingleTile(int[] arr, int x, int y)
        {
            int counter = 0;
            for (int i = 0; i < 256; i++)
            {
                arr[y * Width_p + x + counter] = 0;
                counter++;
                if (counter % 16 == 0)
                {
                    y++;
                    counter = 0;
                }
            }
        }
        private void CopySingleTileToArray(int[] dest, int[] source, int width, int x, int y)
        {
            int counter = 0;
            for (int i = 0; i < 256; i++)
            {
                if (source[i] != 0)
                    dest[y * width + x + counter] = source[i];
                counter++;
                if (counter % 16 == 0)
                {
                    y++;
                    counter = 0;
                }
            }
        }
        private void CopyToPixelArray(int[] dest, int[] source)
        {
            try
            {
                for (int i = 0; i < source.Length; i++)
                    if (source[i] != 0)
                        dest[i] = source[i];
            }
            catch
            {
                // overflow
            }
        }
        private void CreateLayer(int layer)
        {
            if (Tilemaps_bytes[layer] == null)
                return;
            if (Tileset.Tileset_tiles == null)
                return;
            Tilemaps_tiles[layer] = new Tile[Width * Height]; // Create our layer here
            for (int a = 0; a < Width / 16; a++)
            {
                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        int offset = (y * 16 + x) + (a * 256);
                        byte tilenum = Tilemaps_bytes[layer][offset];
                        Tilemaps_tiles[layer][y * Width + x + (a * 16)] = Tileset.Tileset_tiles[tilenum];
                    }
                }
            }
        }
        private void CreateMainscreen()
        {
            CopyToPixelArray(pixels, L2Priority0);
            CopyToPixelArray(pixels, L1Priority0);
            CopyToPixelArray(pixels, L2Priority1);
            CopyToPixelArray(pixels, L1Priority1);
        }
        private void DrawAllLayers()
        {
            DrawLayerByPriorityOne(L1Priority0, 0, false);
            DrawLayerByPriorityOne(L1Priority1, 0, true);
            DrawLayerByPriorityOne(L2Priority0, 1, false);
            DrawLayerByPriorityOne(L2Priority1, 1, true);
        }
        private int[] DrawLayerByPriorityOne(int[] dest, int layer, bool priority1)
        {
            if (dest.Length != Width_p * Height_p || Tilemaps_tiles[layer] == null)
                return null;
            for (int i = 0; i < Tilemaps_tiles[layer].Length; i++)
            {
                for (int z = 0; z < 4; z++)
                {
                    if (Tilemaps_tiles[layer][i].Subtiles[z].Priority1 == priority1)
                    {
                        switch (z)
                        {
                            case 0:
                                Do.PixelsToPixels(Tilemaps_tiles[layer][i].Subtiles[z].Pixels, dest, Width_p, new Rectangle((i % Width) * 16, (i / Width) * 16, 8, 8));
                                break;
                            case 1:
                                Do.PixelsToPixels(Tilemaps_tiles[layer][i].Subtiles[z].Pixels, dest, Width_p, new Rectangle((i % Width) * 16 + 8, (i / Width) * 16, 8, 8));
                                break;
                            case 2:
                                Do.PixelsToPixels(Tilemaps_tiles[layer][i].Subtiles[z].Pixels, dest, Width_p, new Rectangle((i % Width) * 16, (i / Width) * 16 + 8, 8, 8));
                                break;
                            case 3:
                                Do.PixelsToPixels(Tilemaps_tiles[layer][i].Subtiles[z].Pixels, dest, Width_p, new Rectangle((i % Width) * 16 + 8, (i / Width) * 16 + 8, 8, 8));
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            return dest;
        }
        private void DrawSingleMainscreenTile(int x, int y)
        {
            int bgcolor = paletteSet.Palette[16];
            CopySingleTileToArray(pixels, Do.GetPixelRegion(pixels, 1024, 1024, 16, 16, x, y), Width_p, x, y);
            // Apply BG color
            if (state.BG)
            {
                for (int b = y; b < y + 16; b++)
                {
                    for (int a = x; a < x + 16; a++)
                    {
                        if (pixels[b * Width_p + a] == 0)
                            pixels[b * Width_p + a] = bgcolor;
                    }
                }
            }
        }
        public override void RedrawTilemaps()
        {
            Array.Clear(pixels, 0, pixels.Length);
            DrawAllLayers();
            CreateMainscreen();
        }

        // accessor functions
        public override int[] GetPriority1Pixels()
        {
            int[] pixels = new int[Width_p * Height_p];
            for (int y = 0; y < Height_p; y++)
            {
                for (int x = 0; x < Width_p; x++)
                {
                    if (L1Priority1[y * Width_p + x] != 0 ||
                        L2Priority1[y * Width_p + x] != 0)
                        pixels[y * Width_p + x] = Color.Blue.ToArgb();
                }
            }
            return pixels;
        }
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
            if (Tilemaps_tiles[0] != null)
            {
                if (!ignoretransparent)
                    return Tilemaps_tiles[0][placement].Index;
                else if (Tilemaps_tiles[0][placement].Pixels[p.Y * 16 + p.X] != 0)
                    return Tilemaps_tiles[0][placement].Index;
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
        public override int[] GetPixels(int layer, Point location, Size size)
        {
            int[] pixels = new int[size.Width * size.Height];
            for (int b = 0, y = location.Y; b < size.Height; b++, y++)
            {
                for (int a = 0, x = location.X; a < size.Width; a++, x++)
                    pixels[b * size.Width + a] = this.pixels[y * Width_p + x];
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
        public override void SetTileNum()
        {
            throw new NotImplementedException();
        }
        public override void SetTileNum(int tilenum, int layer, int x, int y)
        {
            if (x < 0) x = 0;
            if (y < 0) y = 0;
            if (x >= Width_p) x = Width_p - 1;
            if (y >= Height_p) y = Height_p - 1;
            y /= 16;
            x /= 16;
            int index = y * Width + x;
            if (index < 0x1000)
                ChangeSingleTile(index, tilenum, x * 16, y * 16);
        }

        #endregion
    }
}
