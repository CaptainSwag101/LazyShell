﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LAZYSHELL
{
    /// <summary>
    /// A buffer of copied 16x16 tiles.
    /// </summary>
    public class CopyBuffer
    {
        public Size Size { get { return new Size(width, height); } }
        private int width; public int Width { get { return width; } }
        private int height; public int Height { get { return height; } }
        private int[] copy; public int[] Copy { get { return copy; } set { copy = value; } }
        private int[][] copies; public int[][] Copies { get { return copies; } set { copies = value; } }
        public byte[] BYTE_copy
        {
            get
            {
                byte[] arr = new byte[copy.Length];
                for (int i = 0; i < arr.Length; i++)
                    arr[i] = (byte)copy[i];
                return arr;
            }
        }
        private Tile[] tiles; public Tile[] Tiles { get { return tiles; } set { tiles = value; } }
        private int[] pixels; public int[] Pixels { get { return pixels; } set { pixels = value; } }
        private List<Mold.Tile> mold_tiles = new List<Mold.Tile>();
        public List<Mold.Tile> Mold_tiles { get { return mold_tiles; } set { mold_tiles = value; } }
        public CopyBuffer(List<Mold.Tile> mold_tiles, int width, int height)
        {
            this.mold_tiles = mold_tiles;
            this.width = width;
            this.height = height;
        }
        public CopyBuffer(List<Mold.Tile> mold_tiles)
        {
            this.mold_tiles = mold_tiles;
        }
        public CopyBuffer(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        public CopyBuffer(int width, int height, int[] copy)
        {
            this.width = width;
            this.height = height;
            this.copy = copy;
        }
        public CopyBuffer(int width, int height, int[][] copies)
        {
            this.width = width;
            this.height = height;
            this.copies = copies;
        }
        public CopyBuffer(int width, int height, Tile[] tiles)
        {
            this.width = width;
            this.height = height;
            this.tiles = tiles;
        }
        /// <summary>
        /// A bitmap of the copied tiles.
        /// </summary>
        public Bitmap Image
        {
            get
            {
                {
                    if (tiles != null && pixels == null)
                        return new Bitmap(
                            Do.PixelsToImage(Do.TilesetToPixels(tiles, width / 16, height / 16, 0, false), width, height));
                    if (tiles == null && pixels != null)
                        return new Bitmap(Do.PixelsToImage(pixels, width, height));
                    return null;
                }
            }
        }
    }
}
