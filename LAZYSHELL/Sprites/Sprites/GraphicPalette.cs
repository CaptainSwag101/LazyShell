using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LAZYSHELL
{
    public class GraphicPalette
    {
        private byte[] data;
        private int graphicPaletteNum; public int GraphicPaletteNum { get { return graphicPaletteNum; } set { graphicPaletteNum = value; } }

        private int paletteOffset; public int PaletteOffset { get { return paletteOffset; } set { paletteOffset = value; } }
        private int graphicOffset; public int GraphicOffset { get { return graphicOffset; } set { graphicOffset = value; } }

        private int paletteNum; public int PaletteNum { get { return paletteNum; } set { paletteNum = value; } }

        public GraphicPalette(byte[] data, int graphicPaletteNum)
        {
            this.data = data;
            this.graphicPaletteNum = graphicPaletteNum;

            InitializeSpriteGraphicPalette(data);
        }
        private void InitializeSpriteGraphicPalette(byte[] data)
        {
            int offset = (graphicPaletteNum * 4) + 0x251800;

            int bank = (int)(((BitManager.GetByte(data, offset) & 0x0F) << 16) + 0x280000);

            graphicOffset = (int)((BitManager.GetShort(data, offset) & 0xFFF0) + bank); offset += 2;
            paletteOffset = (int)(BitManager.GetShort(data, offset) + 0x250000);

            if (paletteOffset < 0x253000) paletteOffset = 0x253000;

            paletteNum = (paletteOffset - 0x253000) / 30;
        }
        public void Assemble()
        {
            int offset = (graphicPaletteNum * 4) + 0x251800;

            byte bank = (byte)((graphicOffset - 0x280000) >> 16);
            ushort pointer = (ushort)(graphicOffset & 0xFFF0);
            BitManager.SetShort(data, offset, pointer);
            data[offset] |= bank; offset += 2;

            BitManager.SetShort(data, offset, (ushort)(paletteNum * 30 + 0x3000));
        }
        public int[] GetGraphicPixels(byte[] graphicData, int[] palette)
        {
            Tile8x8 temp;
            int[] pixels = new int[128 * 256];
            for (int y = 0; y < 32; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    temp = new Tile8x8(y * 16 + x, graphicData, (y * 16 + x) * 0x20, palette, false, false, false, false);
                    CopyOverTile8x8(temp, pixels, 128, x, y);
                }
            }
            return pixels;
        }
        private void CopyOverTile8x8(Tile8x8 source, int[] dest, int destinationWidth, int x, int y)
        {
            x *= 8;
            y *= 8;

            int[] src = source.Pixels;
            int counter = 0;
            for (int i = 0; i < 64; i++)
            {
                dest[y * destinationWidth + x + counter] = src[i];
                counter++;
                if (counter % 8 == 0)
                {
                    y++;
                    counter = 0;
                }
            }
        }
    }
}
