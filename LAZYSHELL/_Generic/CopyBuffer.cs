using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LazyShell
{
    /// <summary>
    /// A buffer of copied 16x16 tiles.
    /// </summary>
    public class CopyBuffer
    {
        #region Variables

        // Properties
        public int Width { get; set; }
        public int Height { get; set; }
        public byte Format { get; set; }
        public byte[] Buffer { get; set; }
        public int[] Copy { get; set; }
        public int[][] Copies { get; set; }
        public Tile[] Tiles { get; set; }
        public int[] Pixels { get; set; }
        public List<Sprites.Mold.Tile> Mold_tiles { get; set; }
        public Size Size
        {
            get { return new Size(Width, Height); }
        }

        #endregion

        #region Constructors

        public CopyBuffer(List<Sprites.Mold.Tile> mold_tiles, int width, int height)
        {
            this.Mold_tiles = mold_tiles;
            this.Width = width;
            this.Height = height;
        }
        public CopyBuffer(List<Sprites.Mold.Tile> mold_tiles)
        {
            this.Mold_tiles = mold_tiles;
        }
        public CopyBuffer(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
        public CopyBuffer(int width, int height, int[] copy)
        {
            this.Width = width;
            this.Height = height;
            this.Copy = copy;
        }
        public CopyBuffer(int width, int height, byte[] buffer, byte format)
        {
            this.Width = width;
            this.Height = height;
            this.Buffer = buffer;
            this.Format = format;
        }
        public CopyBuffer(int width, int height, int[][] copies)
        {
            this.Width = width;
            this.Height = height;
            this.Copies = copies;
        }
        public CopyBuffer(int width, int height, Tile[] tiles)
        {
            this.Width = width;
            this.Height = height;
            this.Tiles = tiles;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates a bitmap of the copied tiles.
        /// </summary>
        public Bitmap GetImage()
        {
            if (Tiles != null && Pixels == null)
                return Do.PixelsToImage(Do.TilesetToPixels(Tiles, Width / 16, Height / 16, 0, false), Width, Height);
            if (Tiles == null && Pixels != null)
                return Do.PixelsToImage(Pixels, Width, Height);
            return null;
        }
        /// <summary>
        /// Creates a deep copy of the copied tile data.
        /// </summary>
        /// <returns></returns>
        public byte[] CopyBytes()
        {
            byte[] arr = new byte[Copy.Length];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = (byte)Copy[i];
            return arr;
        }

        #endregion
    }
}
