using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL
{
    public class Sprite
    {
        private byte[] data;
        private int spriteNum; public int SpriteNum { get { return spriteNum; } set { spriteNum = value; } }

        private ushort graphicPalettePacket; public ushort GraphicPalettePacket { get { return graphicPalettePacket; } set { graphicPalettePacket = value; } }
        private byte graphicPalettePacketShift; public byte GraphicPalettePacketShift { get { return graphicPalettePacketShift; } set { graphicPalettePacketShift = value; } }
        private ushort animationPacket; public ushort AnimationPacket { get { return animationPacket; } set { animationPacket = value; } }

        public Sprite(byte[] data, int spriteNum)
        {
            this.data = data;
            this.spriteNum = spriteNum;

            InitializeSprite(data);
        }
        private void InitializeSprite(byte[] data)
        {
            int offset = (spriteNum * 4) + 0x250000;

            graphicPalettePacket = (ushort)(BitManager.GetShort(data, offset) & 0x1FF); offset++;
            graphicPalettePacketShift = (byte)((BitManager.GetByte(data, offset) & 0x0E) >> 1); offset++;
            animationPacket = BitManager.GetShort(data, offset);
        }
        public void Assemble()
        {
            int offset = (spriteNum * 4) + 0x250000;

            BitManager.SetShort(data, offset, graphicPalettePacket); offset++;
            data[offset] |= (byte)(graphicPalettePacketShift << 1); offset++;
            BitManager.SetShort(data, offset, animationPacket);
        }
    }
}
