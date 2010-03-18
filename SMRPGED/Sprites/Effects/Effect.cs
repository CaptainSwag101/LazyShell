using System;
using System.Collections.Generic;
using System.Text;

namespace SMRPGED
{
    public class Effect
    {
        private byte[] data;
        private int effectNum; public int EffectNum { get { return effectNum; } set { effectNum = value; } }

        private byte paletteIndex; public byte PaletteIndex { get { return paletteIndex; } set { paletteIndex = value; } }
        private byte animationPacket; public byte AnimationPacket { get { return animationPacket; } set { animationPacket = value; } }
        private byte xNegShift; public byte XNegShift { get { return xNegShift; } set { xNegShift = value; } }
        private byte yNegShift; public byte YNegShift { get { return yNegShift; } set { yNegShift = value; } }

        public Effect(byte[] data, int effectNum)
        {
            this.data = data;
            this.effectNum = effectNum;

            InitializeEffect(data);
        }
        private void InitializeEffect(byte[] data)
        {
            int offset = (effectNum * 4) + 0x251000;

            paletteIndex = data[offset]; offset++;
            animationPacket = data[offset]; offset++;
            xNegShift = data[offset]; offset++;
            yNegShift = data[offset]; offset++;
        }
        public void Assemble()
        {
            int offset = (effectNum * 4) + 0x251000;

            data[offset] = paletteIndex; offset++;
            data[offset] = animationPacket; offset++;
            data[offset] = xNegShift; offset++;
            data[offset] = yNegShift; offset++;
        }
    }
}
