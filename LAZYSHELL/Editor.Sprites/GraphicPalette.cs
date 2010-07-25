using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LAZYSHELL
{
    public class GraphicPalette
    {
        private byte[] data;
        private int index; public int Index { get { return index; } set { index = value; } }
        private int paletteOffset; public int PaletteOffset { get { return paletteOffset; } set { paletteOffset = value; } }
        private int graphicOffset; public int GraphicOffset { get { return graphicOffset; } set { graphicOffset = value; } }
        private int paletteNum; public int PaletteNum { get { return paletteNum; } set { paletteNum = value; } }
        public GraphicPalette(byte[] data, int index)
        {
            this.data = data;
            this.index = index;

            InitializeSpriteGraphicPalette(data);
        }
        private void InitializeSpriteGraphicPalette(byte[] data)
        {
            int offset = (index * 4) + 0x251800;

            int bank = (int)(((data[offset] & 0x0F) << 16) + 0x280000);

            graphicOffset = (int)((Bits.GetShort(data, offset) & 0xFFF0) + bank); offset += 2;
            paletteOffset = (int)(Bits.GetShort(data, offset) + 0x250000);

            if (paletteOffset < 0x253000) paletteOffset = 0x253000;

            paletteNum = (paletteOffset - 0x253000) / 30;
        }
        public byte[] Graphics(byte[] spriteGraphics)
        {
            return Bits.GetByteArray(spriteGraphics, graphicOffset - 0x280000, 0x4000);
        }
        public void Assemble()
        {
            int offset = (index * 4) + 0x251800;

            byte bank = (byte)((graphicOffset - 0x280000) >> 16);
            ushort pointer = (ushort)(graphicOffset & 0xFFF0);
            Bits.SetShort(data, offset, pointer);
            data[offset] |= bank; offset += 2;

            Bits.SetShort(data, offset, (ushort)(paletteNum * 30 + 0x3000));
        }
    }
}
