using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LAZYSHELL
{
    [Serializable()]
    public class NPCProperties
    {
        [NonSerialized()]
        private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }
        [NonSerialized()]
        private int[] pixels = null;

        private int imageHeight; public int ImageHeight { get { return imageHeight; } set { imageHeight = value; } }
        private int imageWidth; public int ImageWidth { get { return imageWidth; } set { imageWidth = value; } }
        private byte moldX; public byte MoldX { get { return moldX; } set { moldX = value; } }
        private byte moldY; public byte MoldY { get { return moldY; } set { moldY = value; } }
        private bool moldGridPlane; public bool MoldGridPlane { get { return moldGridPlane; } set { moldGridPlane = value; } }

        private int index; public int Index { get { return index; } set { index = value; } }

        private ushort sprite; public ushort Sprite { get { return sprite; } set { sprite = value; } }
        private bool priority0; public bool Priority0 { get { return priority0; } set { priority0 = value; } }
        private bool priority1; public bool Priority1 { get { return priority1; } set { priority1 = value; } }
        private bool priority2; public bool Priority2 { get { return priority2; } set { priority2 = value; } }
        private byte yPixelShiftUp; public byte YPixelShiftUp { get { return yPixelShiftUp; } set { yPixelShiftUp = value; } }
        private bool shift16pxDown; public bool Shift16pxDown { get { return shift16pxDown; } set { shift16pxDown = value; } }
        private byte acuteAxis; public byte AcuteAxis { get { return acuteAxis; } set { acuteAxis = value; } }
        private byte obtuseAxis; public byte ObtuseAxis { get { return obtuseAxis; } set { obtuseAxis = value; } }
        private byte height; public byte Height { get { return height; } set { height = value; } }
        private byte shadow; public byte Shadow { get { return shadow; } set { shadow = value; } }
        private bool b1b2; public bool B1b2 { get { return b1b2; } set { b1b2 = value; } }
        private bool b1b3; public bool B1b3 { get { return b1b3; } set { b1b3 = value; } }
        private bool b1b4; public bool B1b4 { get { return b1b4; } set { b1b4 = value; } }
        private bool b1b5; public bool B1b5 { get { return b1b5; } set { b1b5 = value; } }
        private bool b1b6; public bool B1b6 { get { return b1b6; } set { b1b6 = value; } }
        private bool b1b7; public bool B1b7 { get { return b1b7; } set { b1b7 = value; } }
        private bool b2b0; public bool B2b0 { get { return b2b0; } set { b2b0 = value; } }
        private bool b2b1; public bool B2b1 { get { return b2b1; } set { b2b1 = value; } }
        private bool b2b2; public bool B2b2 { get { return b2b2; } set { b2b2 = value; } }
        private bool b2b3; public bool B2b3 { get { return b2b3; } set { b2b3 = value; } }
        private bool b2b4; public bool B2b4 { get { return b2b4; } set { b2b4 = value; } }
        private bool b3b7; public bool B3b7 { get { return b3b7; } set { b3b7 = value; } }
        private bool b5b5; public bool B5b5 { get { return b5b5; } set { b5b5 = value; } }
        private bool b5b6; public bool B5b6 { get { return b5b6; } set { b5b6 = value; } }
        private bool b5b7; public bool B5b7 { get { return b5b7; } set { b5b7 = value; } }
        private bool b6b2; public bool B6b2 { get { return b6b2; } set { b6b2 = value; } }

        public NPCProperties(byte[] data, int index)
        {
            this.data = data;
            this.index = index;
            InitializeNPC(data);
        }

        private void InitializeNPC(byte[] data)
        {
            int offset = index * 7 + 0x1DB800;

            ushort temp = 0;

            temp = Bits.GetShort(data, offset);
            offset++;

            sprite = (ushort)(temp & 0x03FF);
            b1b2 = (data[offset] & 0x04) == 0x04;
            b1b3 = (data[offset] & 0x08) == 0x08;
            b1b4 = (data[offset] & 0x10) == 0x10;
            b1b5 = (data[offset] & 0x20) == 0x20;
            b1b6 = (data[offset] & 0x40) == 0x40;
            b1b7 = (data[offset] & 0x80) == 0x80;
            offset++;

            priority0 = (data[offset] & 0x20) == 0x20;
            priority1 = (data[offset] & 0x40) == 0x40;
            priority2 = (data[offset] & 0x80) == 0x80;
            b2b0 = (data[offset] & 0x01) == 0x01;
            b2b1 = (data[offset] & 0x02) == 0x02;
            b2b2 = (data[offset] & 0x04) == 0x04;
            b2b3 = (data[offset] & 0x08) == 0x08;
            b2b4 = (data[offset] & 0x10) == 0x10;
            offset++;

            yPixelShiftUp = (byte)(data[offset] & 0x0F);
            shift16pxDown = (data[offset] & 0x10) == 0x10;
            shadow = (byte)((data[offset] & 0x60) >> 5);
            b3b7 = (data[offset] & 0x80) == 0x80;
            offset++;

            acuteAxis = (byte)(data[offset] & 0x0F);
            obtuseAxis = (byte)((data[offset] & 0xF0) >> 4);
            offset++;

            height = (byte)(data[offset] & 0x1F);
            b5b5 = (data[offset] & 0x20) == 0x20;
            b5b6 = (data[offset] & 0x40) == 0x40;
            b5b7 = (data[offset] & 0x80) == 0x80;
            offset++;

            b6b2 = (data[offset] & 0x04) == 0x04;
        }
        public void Assemble()
        {
            int offset = index * 7 + 0x1DB800;

            Bits.SetShort(data, offset, sprite); offset++;
            Bits.SetBit(data, offset, 2, b1b2);
            Bits.SetBit(data, offset, 3, b1b3);
            Bits.SetBit(data, offset, 4, b1b4);
            Bits.SetBit(data, offset, 5, b1b5);
            Bits.SetBit(data, offset, 6, b1b6);
            Bits.SetBit(data, offset, 7, b1b7);
            offset++;

            Bits.SetBit(data, offset, 5, priority0);
            Bits.SetBit(data, offset, 6, priority1);
            Bits.SetBit(data, offset, 7, priority2);
            Bits.SetBit(data, offset, 0, b2b0);
            Bits.SetBit(data, offset, 1, b2b1);
            Bits.SetBit(data, offset, 2, b2b2);
            Bits.SetBit(data, offset, 3, b2b3);
            Bits.SetBit(data, offset, 4, b2b4);
            offset++;

            data[offset] = yPixelShiftUp;
            Bits.SetBit(data, offset, 4, shift16pxDown);
            data[offset] &= 0x9F;
            data[offset] |= (byte)(shadow << 5);
            Bits.SetBit(data, offset, 7, b3b7);
            offset++;

            data[offset] = acuteAxis;
            data[offset] |= (byte)(obtuseAxis << 4);
            offset++;

            data[offset] = height;
            Bits.SetBit(data, offset, 5, b5b5);
            Bits.SetBit(data, offset, 6, b5b6);
            Bits.SetBit(data, offset, 7, b5b7);
            offset++;

            Bits.SetBit(data, offset, 2, b6b2);
        }
        public int[] CreateImage(int radialPosition, bool fromSprite, int fromSpriteNum)
        {
            Mold tMold;
            int num = fromSprite ? fromSpriteNum : sprite;
            int offset = num * 4 + 0x250000;
            int graphicPalettePacket = Bits.GetShort(data, offset) & 0x1FF; offset++;
            int graphicPalettePacketShift = (data[offset] & 0x0E) >> 1;

            // set graphics
            offset = graphicPalettePacket * 4 + 0x251800;
            int bank = (int)(((data[offset] & 0x0F) << 16) + 0x280000);
            int graphicOffset = (int)((Bits.GetShort(data, offset) & 0xFFF0) + bank); offset += 2;

            // set palette to use
            int paletteOffset = (int)(Bits.GetShort(data, offset) + 0x250000);
            paletteOffset += graphicPalettePacketShift * 30;
            int[] palette = new int[16];
            int r, g, b;
            double multiplier = 8; // 8;
            ushort color = 0;
            for (int i = 0; i < 16; i++) // 16 colors in palette
            {
                color = i == 0 ? (ushort)0 : (ushort)Bits.GetShort(data, i * 2 + paletteOffset - 2);
                r = (byte)((color % 0x20) * multiplier);
                g = (byte)(((color >> 5) % 0x20) * multiplier);
                b = (byte)(((color >> 10) % 0x20) * multiplier);
                palette[i] = Color.FromArgb(255, r, g, b).ToArgb();
            }

            //
            int animationNum = Bits.GetShort(data, num * 4 + 0x250002);
            int animationOffset = Bits.Get24Bit(data, 0x252000 + (animationNum * 3)) - 0xC00000;
            int animationLength = Bits.GetShort(data, animationOffset);

            int moldNum;
            bool mirror;
            byte[] sm = Bits.GetByteArray(data, animationOffset, animationLength);
            offset = Bits.GetShort(sm, 2);
            switch (radialPosition)
            {
                case 0: mirror = true; if (sm[6] < 13) break; offset += 24; break;
                case 1: mirror = true; break;
                case 2: mirror = true; if (sm[6] < 11) break; offset += 20; break;
                case 4: mirror = false; if (sm[6] < 13) break; offset += 24; break;
                case 5: mirror = false; if (sm[6] < 2) break; offset += 2; break;
                case 6: mirror = false; if (sm[6] < 12) break; offset += 22; break;
                case 7: mirror = true; if (sm[6] < 2) break; offset += 2; break;
                default: mirror = false; break;
            }
            offset = Bits.GetShort(sm, offset);
            moldNum = offset != 0xFFFF && sm[offset + 1] != 0 && sm[offset + 1] < sm[7] ? (int)sm[offset + 1] : 0;
            offset = Bits.GetShort(sm, 4);
            offset += moldNum * 2;

            tMold = new Mold();
            tMold.InitializeMold(sm, offset, new List<Mold.Tile>());

            foreach (Mold.Tile t in tMold.Tiles)
            {
                t.Set8x8Tiles(Bits.GetByteArray(data, graphicOffset, 0x4000), palette, tMold.Gridplane);
            }

            pixels = tMold.MoldPixels();

            // crop image
            int lowY = 0, highY = 0, lowX = 0, highX = 0;
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
            imageHeight = highY - lowY;
            imageWidth = highX - lowX;

            int[] tempPixels = new int[imageWidth * imageHeight];

            for (int y = 0; y < imageHeight; y++)
            {
                for (int x = 0; x < imageWidth; x++)
                {
                    tempPixels[y * imageWidth + x] = pixels[(y + lowY) * 256 + x + lowX];
                }
            }

            pixels = tempPixels;

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
            return pixels;
        }
        public NPCProperties Copy()
        {
            return new NPCProperties(this.data, this.index);
        }
    }
}
