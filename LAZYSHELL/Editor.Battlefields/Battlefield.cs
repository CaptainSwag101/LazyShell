using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace LAZYSHELL
{
    [Serializable()]
    public class Battlefield
    {
        [NonSerialized()]
        private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }

        private int index; public int Index { get { return index; } set { index = value; } }

        private byte graphicSetA; public byte GraphicSetA { get { return graphicSetA; } set { graphicSetA = value; } }
        private byte graphicSetB; public byte GraphicSetB { get { return graphicSetB; } set { graphicSetB = value; } }
        private byte graphicSetC; public byte GraphicSetC { get { return graphicSetC; } set { graphicSetC = value; } }
        private byte graphicSetD; public byte GraphicSetD { get { return graphicSetD; } set { graphicSetD = value; } }
        private byte graphicSetE; public byte GraphicSetE { get { return graphicSetE; } set { graphicSetE = value; } }

        private byte tileSet; public byte TileSet { get { return tileSet; } set { tileSet = value; } }

        private byte paletteSet; public byte PaletteSet { get { return paletteSet; } set { paletteSet = value; } }

        public int PaletteSetOffset { get { return GetPaletteSetOffset(); } }

        public Battlefield(byte[] data, int battlefieldNum)
        {
            this.data = data;
            this.index = battlefieldNum;
            InitializeBattlefield(data);
        }
        private void InitializeBattlefield(byte[] data)
        {
            int offset = (index * 8) + 0x39B644;

            graphicSetA = data[offset]; offset++;
            graphicSetB = data[offset]; offset++;
            graphicSetC = data[offset]; offset++;
            graphicSetD = data[offset]; offset++;
            graphicSetE = data[offset]; offset += 2;

            if (graphicSetA > 0xC7) graphicSetA = 0xC8;
            if (graphicSetB > 0xC7) graphicSetB = 0xC8;
            if (graphicSetC > 0xC7) graphicSetC = 0xC8;
            if (graphicSetD > 0xC7) graphicSetD = 0xC8;
            if (graphicSetE > 0xC7) graphicSetE = 0xC8;

            tileSet = data[offset]; offset++;
            paletteSet = data[offset]; offset++;
        }
        public void Assemble()
        {
            int offset = (index * 8) + 0x39B644;

            if (graphicSetA == 0xC8) Bits.SetByte(data, offset, 0xFF);
            else Bits.SetByte(data, offset, graphicSetA); offset++;
            if (graphicSetB == 0xC8) Bits.SetByte(data, offset, 0xFF);
            else Bits.SetByte(data, offset, graphicSetB); offset++;
            if (graphicSetC == 0xC8) Bits.SetByte(data, offset, 0xFF);
            else Bits.SetByte(data, offset, graphicSetC); offset++;
            if (graphicSetD == 0xC8) Bits.SetByte(data, offset, 0xFF);
            else Bits.SetByte(data, offset, graphicSetD); offset++;
            if (graphicSetE == 0xC8) Bits.SetByte(data, offset, 0xFF);
            else Bits.SetByte(data, offset, graphicSetE); offset += 2;

            Bits.SetByte(data, offset, tileSet); offset++;
            Bits.SetByte(data, offset, paletteSet); offset++;
        }

        private int GetPaletteSetOffset()
        {
            return (paletteSet * 0xB6) + 0x34D000 - 30;
        }
        public int GetBGColor()
        {
            ushort bgColor = Bits.GetShort(data, GetPaletteSetOffset());

            // Set the background color for the level
            double multiplier = 8; // 8;

            byte bgColorRed = (byte)((bgColor % 0x20) * multiplier); if (bgColorRed != 0) bgColorRed++;
            byte bgColorGreen = (byte)(((bgColor >> 5) % 0x20) * multiplier); if (bgColorGreen != 0) bgColorGreen++;
            byte bgColorBlue = (byte)(((bgColor >> 10) % 0x20) * multiplier); if (bgColorBlue != 0) bgColorBlue++;

            return Color.FromArgb(255, bgColorRed, bgColorGreen, bgColorBlue).ToArgb();
        }
        public byte[] GetPalette(int paletteNum)
        {
            return Bits.GetByteArray(data, GetPaletteSetOffset() + (paletteNum * 30), 32);
        }

    }
}
