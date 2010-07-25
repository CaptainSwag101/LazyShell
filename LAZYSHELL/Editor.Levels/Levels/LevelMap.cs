using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LAZYSHELL
{
    [Serializable()]
    public class LevelMap
    {
        // Local Variables
        // All properties of this class should be private
        [NonSerialized()]
        private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }

        //tag
        //private int[] cartesianGrid = new int[1024 * 1024]; public int[] CartesianGrid { get { return cartesianGrid; } set { cartesianGrid = value; } }
        //private int[] orthographicGrid = new int[1024 * 1024]; public int[] IsometricGrid { get { return orthographicGrid; } set { orthographicGrid = value; } }

        //private int levelNum; public int LevelNum { get { return levelNum; } set { levelNum = value; } }
        private int index; public int Index { get { return index; } set { index = value; } }

        private byte graphicSetA; public byte GraphicSetA { get { return graphicSetA; } set { graphicSetA = value; } }
        private byte graphicSetB; public byte GraphicSetB { get { return graphicSetB; } set { graphicSetB = value; } }
        private byte graphicSetC; public byte GraphicSetC { get { return graphicSetC; } set { graphicSetC = value; } }
        private byte graphicSetD; public byte GraphicSetD { get { return graphicSetD; } set { graphicSetD = value; } }
        private byte graphicSetE; public byte GraphicSetE { get { return graphicSetE; } set { graphicSetE = value; } }

        private byte tileSetL1; public byte TileSetL1 { get { return tileSetL1; } set { tileSetL1 = value; } }
        private byte tileSetL2; public byte TileSetL2 { get { return tileSetL2; } set { tileSetL2 = value; } }

        private bool topPriorityL3; public bool TopPriorityL3 { get { return topPriorityL3; } set { topPriorityL3 = value; } }

        private byte tileMapL1; public byte TileMapL1 { get { return tileMapL1; } set { tileMapL1 = value; } }
        private byte tileMapL2; public byte TileMapL2 { get { return tileMapL2; } set { tileMapL2 = value; } }
        private byte physicalMap; public byte PhysicalMap { get { return physicalMap; } set { physicalMap = value; } }

        private byte paletteSet; public byte PaletteSet { get { return paletteSet; } set { paletteSet = value; } }

        // every map has a palette set with 112 (ie. 7 * 16) colors, a red green and blue for each
        private int[] paletteColorRed = new int[7 * 16]; public int[] PaletteColorRed { get { return paletteColorRed; } set { paletteColorRed = value; } }
        private int[] paletteColorGreen = new int[7 * 16]; public int[] PaletteColorGreen { get { return paletteColorGreen; } set { paletteColorGreen = value; } }
        private int[] paletteColorBlue = new int[7 * 16]; public int[] PaletteColorBlue { get { return paletteColorBlue; } set { paletteColorBlue = value; } }

        private byte graphicSetL3; public byte GraphicSetL3 { get { return graphicSetL3; } set { graphicSetL3 = value; } }
        private byte tileSetL3; public byte TileSetL3 { get { return tileSetL3; } set { tileSetL3 = value; } }
        private byte tileMapL3; public byte TileMapL3 { get { return tileMapL3; } set { tileMapL3 = value; } }

        private byte battlefield; public byte Battlefield { get { return battlefield; } set { battlefield = value; } }
        public int PaletteSetOffset { get { return GetPaletteSetOffset(); } }

        //private int bgColorRed; public int BgColorRed { get { GetBGColors(); return bgColorRed; } }
        //private int bgColorGreen; public int BgColorGreen { get { GetBGColors(); return bgColorGreen; } }
        //private int bgColorBlue; public int BgColorBlue { get { GetBGColors(); return bgColorBlue; } }


        public LevelMap(byte[] data, int index)
        {
            this.data = data;
            this.index = index;
            InitializeLevelMap(data);
        }

        // Dissasembler goes here
        // Initializes all local properties for this class
        private void InitializeLevelMap(byte[] data)
        {
            byte temp = 0;

            int offset = (index * 15) + 0x1D2440;

            graphicSetA = data[offset]; offset++;
            graphicSetB = data[offset]; offset++;
            graphicSetC = data[offset]; offset++;
            graphicSetD = data[offset]; offset++;
            graphicSetE = data[offset]; offset++;
            tileSetL1 = data[offset]; offset++;

            temp = data[offset]; offset++;

            if ((temp & 0x80) == 0x80) topPriorityL3 = true;

            tileSetL2 = (byte)(temp & 0x7F);

            tileMapL1 = data[offset]; offset++;
            tileMapL2 = data[offset]; offset++;
            physicalMap = data[offset]; offset++;
            paletteSet = data[offset]; offset++;
            graphicSetL3 = data[offset]; offset++;
            tileSetL3 = data[offset]; offset++;

            temp = data[offset]; offset++;

            tileMapL3 = (byte)(temp & 0x3F);

            battlefield = data[offset]; offset++;

        }

        private int GetPaletteSetOffset()
        {
            return (paletteSet * 0xD4) + 0x24A000;
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
        public byte[] Get2bppPalette(int paletteNum)
        {
            return Bits.GetByteArray(data, GetPaletteSetOffset() + (paletteNum * 8), 8);
        }

        public void Assemble()
        {
            int offset = (index * 15) + 0x1D2440;

            Bits.SetByte(data, offset, graphicSetA); offset++;
            Bits.SetByte(data, offset, graphicSetB); offset++;
            Bits.SetByte(data, offset, graphicSetC); offset++;
            Bits.SetByte(data, offset, graphicSetD); offset++;
            Bits.SetByte(data, offset, graphicSetE); offset++;
            Bits.SetByte(data, offset, tileSetL1); offset++;

            Bits.SetByte(data, offset, tileSetL2);
            Bits.SetBit(data, offset, 7, topPriorityL3); offset++;

            Bits.SetByte(data, offset, tileMapL1); offset++;
            Bits.SetByte(data, offset, tileMapL2); offset++;
            Bits.SetByte(data, offset, physicalMap); offset++;
            Bits.SetByte(data, offset, paletteSet); offset++;
            Bits.SetByte(data, offset, graphicSetL3); offset++;
            Bits.SetByte(data, offset, tileSetL3); offset++;
            Bits.SetByte(data, offset, (byte)(tileMapL3 + 0x40)); offset++;
            Bits.SetByte(data, offset, battlefield); offset++;
        }
        public void Clear()
        {
            this.graphicSetA = 0;
            this.graphicSetB = 0;
            this.graphicSetC = 0;
            this.graphicSetD = 0;
            this.graphicSetE = 0;
            this.tileSetL1 = 0;
            this.tileSetL2 = 0;
            this.topPriorityL3 = false;
            this.tileMapL1 = 0;
            this.tileMapL2 = 0;
            this.physicalMap = 0;
            this.paletteSet = 0;
            this.graphicSetL3 = 0;
            this.tileSetL3 = 0;
            this.tileMapL3 = 0;
            this.battlefield = 0;

        }
    }
}
