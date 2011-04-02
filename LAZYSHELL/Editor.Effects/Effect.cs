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
        private byte xNegShift; public byte XNegShift { get { return xNegShift; } set { xNegShift = value; } }
        private byte yNegShift; public byte YNegShift { get { return yNegShift; } set { yNegShift = value; } }

        public Effect(byte[] data, int effectNum)
        {
            this.data = data;
            this.index = effectNum;

            InitializeEffect(data);
        }
        private void InitializeEffect(byte[] data)
        {
            int offset = (index * 4) + 0x251000;

            paletteIndex = data[offset]; offset++;
            animationPacket = data[offset]; offset++;
            xNegShift = data[offset]; offset++;
            yNegShift = data[offset]; offset++;
        }
        public void Assemble()
        {
            int offset = (index * 4) + 0x251000;

            data[offset] = paletteIndex; offset++;
            data[offset] = animationPacket; offset++;
            data[offset] = xNegShift; offset++;
            data[offset] = yNegShift; offset++;
        }
    }
}
