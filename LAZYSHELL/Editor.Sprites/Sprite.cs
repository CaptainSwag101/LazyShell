using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LAZYSHELL
{
    [Serializable()]
    public class Sprite
    {
        [NonSerialized()]
        private byte[] data;
        private int index; public int Index { get { return index; } set { index = value; } }

        private ushort graphicPalettePacket; public ushort GraphicPalettePacket { get { return graphicPalettePacket; } set { graphicPalettePacket = value; } }
        private byte paletteIndex; public byte PaletteIndex { get { return paletteIndex; } set { paletteIndex = value; } }
        private ushort animationPacket; public ushort AnimationPacket { get { return animationPacket; } set { animationPacket = value; } }

        public Sprite(byte[] data, int index)
        {
            this.data = data;
            this.index = index;

            InitializeSprite(data);
        }
        private void InitializeSprite(byte[] data)
        {
            int offset = (index * 4) + 0x250000;

            graphicPalettePacket = (ushort)(Bits.GetShort(data, offset) & 0x1FF); offset++;
            paletteIndex = (byte)((data[offset] & 0x0E) >> 1); offset++;
            animationPacket = Bits.GetShort(data, offset);
        }
        public int GraphicOffset
        {
            get
            {
                int offset = graphicPalettePacket * 4 + 0x251800;
                int bank = (int)(((data[offset] & 0x0F) << 16) + 0x280000);
                return (int)((Bits.GetShort(data, offset) & 0xFFF0) + bank);
            }
        }
        public byte[] Graphics
        {
            get { return Bits.GetByteArray(data, GraphicOffset, 0x4000); }
        }
        /// <summary>
        /// Creates a pixel array of the sprite.
        /// </summary>
        /// <param name="byMold">Create the pixels by mold index.</param>
        /// <param name="byFacing">Create the pixels by facing index.</param>
        /// <param name="moldIndex">The index of the mold (ignored if byMold == false).</param>
        /// <param name="facingIndex">The index of the facing (ignored if byFacing == false)</param>
        /// <param name="palette">If want to use a particular palette.</param>
        /// <param name="mirror">Mirror the sprite pixels.</param>
        /// <param name="crop">Crop the sprite pixels to their edges.</param>
        /// <returns></returns>
        public int[] GetPixels(bool byMold, bool byFacing, int moldIndex, int facingIndex, int[] palette, bool mirror, bool crop, ref Size size)
        {
            Mold tMold;

            // set palette to use
            if (palette == null)
                palette = Palette;
            //
            int animationNum = Bits.GetShort(data, this.index * 4 + 0x250002);
            int animationOffset = Bits.Get24Bit(data, 0x252000 + (animationNum * 3)) - 0xC00000;
            int animationLength = Bits.GetShort(data, animationOffset);

            byte[] sm = Bits.GetByteArray(data, animationOffset, animationLength);
            int offset = Bits.GetShort(sm, 2);
            if (byFacing)
                switch (facingIndex)
                {
                    case 0: mirror = !mirror; if (sm[6] < 13) break; offset += 24; break;
                    case 1: mirror = !mirror; break;
                    case 2: if (sm[6] < 11) break; offset += 20; break;
                    case 4: if (sm[6] < 13) break; offset += 24; break;
                    case 5: if (sm[6] < 2) break; offset += 2; break;
                    case 6: if (sm[6] < 12) break; offset += 22; break;
                    case 7: mirror = !mirror; if (sm[6] < 2) break; offset += 2; break;
                    default: break;
                }
            offset = Bits.GetShort(sm, offset);
            if (!byMold)
                moldIndex = offset != 0xFFFF && sm[offset + 1] != 0 && sm[offset + 1] < sm[7] ? (int)sm[offset + 1] : 0;
            offset = Bits.GetShort(sm, 4);
            offset += moldIndex * 2;

            tMold = new Mold();
            tMold.InitializeMold(sm, offset, new List<Mold.Tile>(), animationNum, animationOffset);

            foreach (Mold.Tile t in tMold.Tiles)
            {
                t.Set8x8Tiles(Graphics, palette, tMold.Gridplane);
            }

            int[] pixels = tMold.MoldPixels();

            // crop image
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
            int offset = graphicPalettePacket * 4 + 0x251800;
            int bank = (int)(((data[offset] & 0x0F) << 16) + 0x280000);
            int graphicOffset = (int)((Bits.GetShort(data, offset) & 0xFFF0) + bank); offset += 2;
            //
            byte[] graphics = Bits.GetByteArray(data, graphicOffset, 0x4000);
            int[] palette = Palette;
            Animation animation = Model.Animations[animationPacket];
            Mold mold = animation.Molds[0];
            foreach (Mold.Tile tile in mold.Tiles)
                tile.Set8x8Tiles(graphics, palette, mold.Gridplane);
            //
            return animation.TilesetPixels();
        }
        public int[] Palette
        {
            get
            {
                int index = Math.Min(Model.SpritePalettes.Length, Model.GraphicPalettes[graphicPalettePacket].PaletteNum + paletteIndex);
                return Model.SpritePalettes[index].Palettes[0];
            }
        }
        public void Assemble()
        {
            int offset = (index * 4) + 0x250000;

            Bits.SetShort(data, offset, graphicPalettePacket); offset++;
            data[offset] |= (byte)(paletteIndex << 1); offset++;
            Bits.SetShort(data, offset, animationPacket);
        }
    }
}
