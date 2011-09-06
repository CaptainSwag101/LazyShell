using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL
{
    [Serializable()]
    public class Effect
    {
        [NonSerialized()]
        private byte[] data;
        private int index; public int Index { get { return index; } set { index = value; } }

        private byte paletteIndex; public byte PaletteIndex { get { return paletteIndex; } set { paletteIndex = value; } }
        private byte animationPacket; public byte AnimationPacket { get { return animationPacket; } set { animationPacket = value; } }
        private byte x; public byte X { get { return x; } set { x = value; } }
        private byte y; public byte Y { get { return y; } set { y = value; } }

        public Effect(byte[] data, int effectNum)
        {
            this.data = data;
            this.index = effectNum;

            InitializeEffect(data);
        }
        private void InitializeEffect(byte[] data)
        {
            int offset = (index * 4) + 0x251000;

            paletteIndex = (byte)(data[offset] & 7); offset++;
            animationPacket = data[offset]; offset++;
            x = (byte)(data[offset] - 1 ^ 255); offset++;
            y = (byte)(data[offset] - 1 ^ 255); offset++;
        }
        public void Assemble()
        {
            int offset = (index * 4) + 0x251000;

            data[offset] = paletteIndex; offset++;
            data[offset] = animationPacket; offset++;
            data[offset] = (byte)(x - 1 ^ 255); offset++;
            data[offset] = (byte)(y - 1 ^ 255); offset++;
        }
    }
}
