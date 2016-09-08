using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LazyShell.Sprites
{
    [Serializable()]
    public class Sprite
    {
        #region Variables

        // ROM buffer
        private byte[] rom
        {
            get { return Model.ROM; }
            set { Model.ROM = value; }
        }

        // Index
        public int Index { get; set; }

        // Properties
        public ushort ImageNum { get; set; }
        public byte PaletteIndex { get; set; }
        public ushort AnimationPacket { get; set; }
        public int GraphicOffset
        {
            get
            {
                int offset = ImageNum * 4 + 0x251800;
                int bank = (int)(((rom[offset] & 0x0F) << 16) + 0x280000);
                return (int)((Bits.GetShort(rom, offset) & 0xFFF0) + bank);
            }
        }
        public byte[] Graphics
        {
            get { return Bits.GetBytes(rom, GraphicOffset, 0x4000); }
        }
        public int[] Palette
        {
            get
            {
                int index = Math.Min(Model.PaletteSets.Length, Model.ImagePackets[ImageNum].PaletteNum + PaletteIndex);
                return Model.PaletteSets[index].Palettes[0];
            }
        }

        #endregion

        // Constructor
        public Sprite(int index)
        {
            this.Index = index;
            ReadFromROM();
        }

        #region Methods

        // Read/write ROM
        private void ReadFromROM()
        {
            int offset = (Index * 4) + 0x250000;
            ImageNum = (ushort)(Bits.GetShort(rom, offset) & 0x1FF); offset++;
            PaletteIndex = (byte)((rom[offset] & 0x0E) >> 1); offset++;
            AnimationPacket = Bits.GetShort(rom, offset);
        }
        public void WriteToROM()
        {
            int offset = (Index * 4) + 0x250000;
            Bits.SetShort(rom, offset, ImageNum); offset++;
            rom[offset] |= (byte)(PaletteIndex << 1); offset++;
            Bits.SetShort(rom, offset, AnimationPacket);
        }

        /// <summary>
        /// Creates a pixel array of the sprite.
        /// </summary>
        /// <param name="byMold">Create the pixels by mold index.</param>
        /// <param name="byFacing">Create the pixels by facing index.</param>
        /// <param name="moldIndex">The index of the mold (ignored if byMold == false).</param>
        /// <param name="fCoord">The index of the facing (ignored if byFacing == false)</param>
        /// <param name="palette">If want to use a particular palette.</param>
        /// <param name="mirror">Mirror the sprite pixels.</param>
        /// <param name="crop">Crop the sprite pixels to their edges.</param>
        /// <returns></returns>
        public int[] GetPixels(bool byMold, bool byFacing, int moldIndex, int fCoord, int[] palette, bool mirror, bool crop, ref Size size)
        {
            #region Create pixels

            // Set palette to use
            if (palette == null)
                palette = Palette;

            // Get offsets
            int animationNum = Bits.GetShort(rom, this.Index * 4 + 0x250002);
            int animationOffset = Bits.GetInt24(rom, 0x252000 + (animationNum * 3)) - 0xC00000;
            int animationLength = Bits.GetShort(rom, animationOffset);

            // Get mold binary data
            byte[] buffer = Bits.GetBytes(rom, animationOffset, animationLength);
            int offset = Bits.GetShort(buffer, 2);
            if (byFacing)
            {
                switch (fCoord)
                {
                    case 0: mirror = !mirror; if (buffer[6] < 13) break; offset += 24; break;
                    case 1: mirror = !mirror; break;
                    case 2: if (buffer[6] < 11) break; offset += 20; break;
                    case 4: if (buffer[6] < 13) break; offset += 24; break;
                    case 5: if (buffer[6] < 2) break; offset += 2; break;
                    case 6: if (buffer[6] < 12) break; offset += 22; break;
                    case 7: mirror = !mirror; if (buffer[6] < 2) break; offset += 2; break;
                    default: break;
                }
            }
            offset = Bits.GetShort(buffer, offset);
            if (!byMold)
                moldIndex = offset != 0xFFFF && buffer[offset + 1] != 0 && buffer[offset + 1] < buffer[7] ? (int)buffer[offset + 1] : 0;
            offset = Bits.GetShort(buffer, 4);
            offset += moldIndex * 2;

            // Create mold from data
            Mold mold = new Mold();
            mold.ReadFromBuffer(buffer, offset, new List<Mold.Tile>(), animationNum, animationOffset);

            // Generate subtiles in mold, then grab pixel array
            foreach (var t in mold.Tiles)
                t.DrawSubtiles(Graphics, palette, mold.Gridplane);
            int[] pixels = mold.MoldPixels();

            #endregion

            #region Crop image

            int lowY = 0, highY = 0, lowX = 0, highX = 0;
            if (crop)
            {
                bool stop = false;
                for (int y = 0; y < 256 && !stop; y++)
                {
                    for (int x = 0; x < 256; x++)
                        if (pixels[y * 256 + x] != 0) { lowY = y; lowX = x; stop = true; break; }
                }
                stop = false;
                for (int y = 255; y >= 0 && !stop; y--)
                {
                    for (int x = 255; x >= 0; x--)
                        if (pixels[y * 256 + x] != 0) { highY = y; highX = x; stop = true; break; }
                }
                stop = false;
                for (int y = 0; y < 256; y++)
                {
                    for (int x = 0; x < 256; x++)
                        if (pixels[y * 256 + x] != 0 && x < lowX) { lowX = x; break; }
                }
                stop = false;
                for (int y = 255; y >= 0; y--)
                {
                    for (int x = 255; x >= 0; x--)
                        if (pixels[y * 256 + x] != 0 && x > highX) { highX = x; break; }
                }
                stop = false;
                highY++; highX++;
            }
            else
            {
                highY = 256;
                highX = 256;
            }
            int imageHeight = highY - lowY;
            int imageWidth = highX - lowX;
            if (crop)
            {
                int[] tempPixels = new int[imageWidth * imageHeight];
                for (int y = 0; y < imageHeight; y++)
                {
                    for (int x = 0; x < imageWidth; x++)
                    {
                        tempPixels[y * imageWidth + x] = pixels[(y + lowY) * 256 + x + lowX];
                    }
                }
                pixels = tempPixels;
            }
            int temp;
            if (mirror)
            {
                for (int y = 0; y < imageHeight; y++)
                {
                    for (int a = 0, c = imageWidth - 1; a < imageWidth / 2; a++, c--)
                    {
                        temp = pixels[(y * imageWidth) + a];
                        pixels[(y * imageWidth) + a] = pixels[(y * imageWidth) + c];
                        pixels[(y * imageWidth) + c] = temp;
                    }
                }
            }
            size = new Size(imageWidth, imageHeight);

            #endregion

            return pixels;
        }
        public int[] GetPixels(bool byMold, bool byFacing, int moldIndex, int facingIndex, bool mirror, bool crop, ref Size size)
        {
            return GetPixels(byMold, byFacing, moldIndex, facingIndex, null, mirror, crop, ref size);
        }
        public int[] GetPixels(bool byMold, bool byFacing, int moldIndex, int facingIndex, bool mirror, bool crop)
        {
            Size size = new Size(0, 0);
            return GetPixels(byMold, byFacing, moldIndex, facingIndex, null, mirror, crop, ref size);
        }
        public int[] GetPixels()
        {
            Size size = new Size(0, 0);
            return GetPixels(false, false, 0, 0, null, false, false, ref size);
        }
        public int[] GetTilesetPixels()
        {
            int offset = ImageNum * 4 + 0x251800;
            int bank = (int)(((rom[offset] & 0x0F) << 16) + 0x280000);
            int graphicOffset = (int)((Bits.GetShort(rom, offset) & 0xFFF0) + bank); offset += 2;
            //
            byte[] graphics = Bits.GetBytes(rom, graphicOffset, 0x4000);
            int[] palette = Palette;
            Animation animation = Model.Animations[AnimationPacket];
            Mold mold = animation.Molds[0];
            foreach (Mold.Tile tile in mold.Tiles)
                tile.DrawSubtiles(graphics, palette, mold.Gridplane);
            //
            return animation.TilesetPixels();
        }

        // ToString
        public override string ToString()
        {
            return Lists.Numerize(Lists.Sprites, this.Index);
        }

        #endregion
    }
}
