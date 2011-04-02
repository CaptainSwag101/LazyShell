using System;
using System.Collections.Generic;
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
        public void Assemble()
        {
            int offset = (index * 4) + 0x250000;

            Bits.SetShort(data, offset, graphicPalettePacket); offset++;
            data[offset] |= (byte)(paletteIndex << 1); offset++;
            Bits.SetShort(data, offset, animationPacket);
        }
    }
}
