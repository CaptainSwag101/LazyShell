using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LazyShell.Effects
{
    [Serializable()]
    public class Mold
    {
        #region Variables

        /// <summary>
        /// The buffer data referencing the parent effect animation's data.
        /// </summary>
        private byte[] buffer;
        /// <summary>
        /// The offset of this mold's data in the buffer.
        /// </summary>
        public ushort Offset { get; set; }
        /// <summary>
        /// The tilemap data.
        /// </summary>
        public byte[] Tiles { get; set; }
        /// <summary>
        /// The tilemap data is empty, ie. flooded with 0xFF's.
        /// </summary>
        public bool Empty
        {
            get
            {
                for (int i = 0; i < Tiles.Length; i += 2)
                    if (Bits.GetShort(Tiles, i) != 0xFF)
                        return false;
                return true;
            }
        }
        
        #endregion

        #region Methods

        /// <summary>
        /// Reads this mold's properties from the parent effect animation's buffer data
        /// and decompresses the mold's tilemap data to the Tiles variable.
        /// </summary>
        /// <param name="buffer">The source buffer data referenced from the animation.</param>
        /// <param name="offset">The offset of this mold's data in the source buffer.</param>
        /// <param name="end">The size of this mold's data in the source buffer.</param>
        public void ReadFromBuffer(byte[] buffer, int offset, ushort end)
        {
            this.buffer = buffer;
            this.Offset = (ushort)offset;
            offset = Bits.GetShort(buffer, offset);
            Tiles = new byte[256];

            // Create temporary compressed tilemap buffer
            byte[] compressed = new byte[end - offset];
            Buffer.BlockCopy(buffer, offset, compressed, 0, end - offset);

            // Finally, decompress tilemap to Tiles
            Decompress(compressed, Tiles);
        }
        /// <summary>
        /// Decompresses a mold's tilemap data and stores the decompressed output to a destination array.
        /// </summary>
        /// <param name="src">The source tilemap data to decompress.</param>
        /// <param name="dst">The destination array to store the decompressed output to.</param>
        public void Decompress(byte[] src, byte[] dst)
        {
            int srcOffset = 0;
            int dstOffset = 0;
            while (srcOffset < src.Length)
            {
                if (src[srcOffset] == 0xFE) // "Fill" tile = compressed tile data
                {
                    if (srcOffset + 2 >= src.Length) // Cancel operation if at boundary of data
                        break;
                    srcOffset++;    // skip the type

                    // Fill with tile
                    for (int counter = 0; counter < src[srcOffset + 1]; counter++, dstOffset++)
                        dst[dstOffset] = src[srcOffset];

                    srcOffset++;    // Skip fill size value
                    dstOffset--;    // Move back one to keep from filling one extra byte
                }
                else
                    dst[dstOffset] = src[srcOffset]; // Uncompressed tile data
                dstOffset++;
                srcOffset++;
            }
        }
        /// <summary>
        /// Compresses a mold's tilemap data and returns the resulting output array.
        /// </summary>
        /// <param name="src">The tilemap data to compress.</param>
        /// <param name="width">The width, in 16x16 tile units, of the tilemap.</param>
        /// <param name="height">The height, in 16x16 tile units, of the tilemap.</param>
        /// <returns></returns>
        public byte[] Compress(byte[] src, int width, int height)
        {
            // 256 max size for compressed
            byte[] dst = new byte[256]; 
            int srcOffset = 0;
            int dstOffset = 0;

            // Start writing to buffer
            while (srcOffset < width * height)
            {
                dst[dstOffset] = src[srcOffset];

                // Minimum size of filler tile is 2 bytes
                if (srcOffset < 0xFE &&
                    srcOffset + 1 < src.Length &&
                    srcOffset + 2 < src.Length &&
                    src[srcOffset] == src[srcOffset + 1] &&
                    src[srcOffset] == src[srcOffset + 2])
                {
                    dst[dstOffset] = 0xFE;
                    dstOffset++;
                    dst[dstOffset] = src[srcOffset];    // the tile to fill with

                    // Get required fill size with loop operation
                    byte counter = 1;
                    while (srcOffset < 0xFF &&
                        srcOffset < src.Length &&
                        srcOffset + 1 < src.Length &&
                        src[srcOffset] == src[srcOffset + 1])
                    {
                        counter++;
                        srcOffset++;
                    }
                    dstOffset++;

                    // Write fill size to buffer
                    dst[dstOffset] = counter;
                }
                srcOffset++;
                dstOffset++;
            }

            // Create truncated buffer based on last offset value
            byte[] temp = new byte[dstOffset];
            Bits.SetBytes(temp, 0, dst);

            // Finished
            return temp;
        }
        /// <summary>
        /// Returns an array of RGB pixel data of this mold's tilemap 
        /// using the specified tileset and animation data.
        /// </summary>
        /// <param name="animation">The effect animation containing the data needed for this operation.</param>
        /// <param name="tileset">The tileset containing the tiles to draw the tilemap with.</param>
        /// <returns></returns>
        public int[] GetPixels(Animation animation, Tileset tileset)
        {
            int[] pixels = new int[(animation.Width * 16) * (animation.Height * 16)];
            for (int y = 0; y < animation.Height; y++)
            {
                for (int x = 0; x < animation.Width; x++)
                {
                    if (y * animation.Width + x >= Tiles.Length)
                        continue;
                    if (Tiles[y * animation.Width + x] == 0xFF)
                        continue;
                    int[] tile = new int[16 * 16];
                    ((Tile)tileset.Tiles[Tiles[y * animation.Width + x] & 0x3F]).Pixels.CopyTo(tile, 0);
                    if ((Tiles[y * animation.Width + x] & 0x40) == 0x40)
                        Do.FlipHorizontal(tile, 16, 16);
                    if ((Tiles[y * animation.Width + x] & 0x80) == 0x80)
                        Do.FlipVertical(tile, 16, 16);
                    Do.PixelsToPixels(tile, pixels, animation.Width * 16, new Rectangle(x * 16, y * 16, 16, 16));
                }
            }
            return pixels;
        }
        /// <summary>
        /// Creates a new mold instance.
        /// </summary>
        /// <returns></returns>
        public Mold New()
        {
            Mold empty = new Mold();
            empty.Tiles = new byte[Tiles.Length];
            return empty;
        }
        /// <summary>
        /// Creates a deep copy of this instance.
        /// </summary>
        /// <returns></returns>
        public Mold Copy()
        {
            Mold copy = new Mold();
            copy.Tiles = new byte[Tiles.Length];
            Tiles.CopyTo(copy.Tiles, 0);
            copy.Offset = Offset;
            return copy;
        }
        
        #endregion
    }
}
