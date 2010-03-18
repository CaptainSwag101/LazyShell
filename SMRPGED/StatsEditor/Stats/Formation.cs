using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SMRPGED.StatsEditor.Stats
{
    public class Formation
    {
        private byte[] data; public byte[] Data { get { return this.data; } set { this.data = value; } }
        private Monster[] monsters;

        #region Fomation Stats
        private int formationNum;
        private byte[] formationMonster = new byte[8];
        private byte[] formationCoordX = new byte[8];
        private byte[] formationCoordY = new byte[8];
        private bool[] formationUse = new bool[8];
        private bool[] formationHide = new bool[8];
        private int[][] formationMonstersPixels = new int[8][];
        private byte formationMusic;
        private byte formationBattleEvent;
        private bool formationCantRun;
        private byte formationUnknown;
        private int elevation;
        // ???
        private int[] gridWidth = new int[8];
        private int[] gridHeight = new int[8];
        private int[] pixelAssn;

        #endregion
        #region Accessors
        public int FormationNum { get { return this.formationNum; } set { this.formationNum = value; } }
        public byte[] FormationMonster { get { return this.formationMonster; } set { this.formationMonster = value; } }
        public byte[] FormationCoordX { get { return this.formationCoordX; } set { this.formationCoordX = value; } }
        public byte[] FormationCoordY { get { return this.formationCoordY; } set { this.formationCoordY = value; } }
        public bool[] FormationUse { get { return this.formationUse; } set { this.formationUse = value; } }
        public bool[] FormationHide { get { return this.formationHide; } set { this.formationHide = value; } }
        public int[][] FormationMonstersPixels { get { return this.formationMonstersPixels; } set { this.formationMonstersPixels = value; } }
        public byte FormationMusic { get { return this.formationMusic; } set { this.formationMusic = value; } }
        public byte FormationBattleEvent { get { return this.formationBattleEvent; } set { this.formationBattleEvent = value; } }
        public bool FormationCantRun { get { return this.formationCantRun; } set { this.formationCantRun = value; } }
        public byte FormationUnknown { get { return this.formationUnknown; } set { this.formationUnknown = value; } }
        public int Elevation { get { return this.elevation; } set { this.elevation = value; } }

        // WHY MUST WE HAVE THESE?
        public int[] GridWidth { get { return gridWidth; } }
        public int[] GridHeight { get { return gridHeight; } }
        public int[] PixelAssn { get { return pixelAssn; } }

        public Image FormationImage
        {
            get
            {
                Bitmap image = null;
                int[,] monster = null;
                int[] pixels = new int[256 * 256];
                pixelAssn = new int[256 * 256];

                int[] order = new int[8];
                for (int i = 0; i < 8; i++)
                    order[i] = i;
                byte[] temp = new byte[FormationCoordY.Length]; FormationCoordY.CopyTo(temp, 0);
                Array.Sort(temp, order);

                for (int g = 0; g < 8; g++)
                {
                    int i = order[g];

                    // If monster is used in formation
                    if (formationUse[i])
                    {
                        // Get correct monster image
                        monster = monsters[formationMonster[i]].PixelBuffer;
                        elevation = monsters[formationMonster[i]].Elevation * 16;

                        for (int y = 0; y < 256; y++)
                        {
                            for (int x = 0; x < 256; x++)
                            {

                                if ((monster[x, y] & 0xFF000000) != 0)
                                {
                                    if (formationCoordX[i] + x - 128 > 0 && formationCoordX[i] + x - 128 < 256)
                                    {
                                        if (formationCoordY[i] + y - 96 - elevation > 0 && formationCoordY[i] + y - 96 - elevation < 256)
                                        {
                                            pixels[((((formationCoordY[i] + y - 96 - elevation) - 1) * 256) + formationCoordX[i] + x - 128)] = monster[x, y];
                                            pixelAssn[((((formationCoordY[i] + y - 96 - elevation) - 1) * 256) + formationCoordX[i] + x - 128)] = i + 1;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                unsafe
                {
                    fixed (void* firstPixel = &pixels[0])
                    {
                        IntPtr ip = new IntPtr(firstPixel);
                        if (image != null)
                            image.Dispose();
                        image = new Bitmap(256, 256, 256 * 4, System.Drawing.Imaging.PixelFormat.Format32bppPArgb, ip);
                    }
                }

                return (Image)image;
            }
        }
        public string[] FormationName
        {
            get
            {
                string[] names = new string[8];

                for (int i = 0; i < 8; i++)
                {
                    if (formationUse[i])
                        names[i] = monsters[formationMonster[i]].Name;
                    else
                        names[i] = "{unused}";
                }
                return names;
            }
        }
        public string FormationListSet
        {
            get
            {
                string[] formationName = this.FormationName;
                return formationName[0] + "\n" +
                formationName[1] + "\n" +
                formationName[2] + "\n" +
                formationName[3] + "\n" +
                formationName[4] + "\n" +
                formationName[5] + "\n" +
                formationName[6] + "\n" +
                formationName[7];
            }
        }
        public string FormationNameList
        {
            get
            {
                string formationNameList = "";
                for (int i = 0; i < 8; i++)
                {
                    if (formationUse[i] == true)
                        formationNameList += monsters[formationMonster[i]].Name + ((i < 7) ? "  /  " : "");
                    else
                        formationNameList += "..." + ((i < 7) ? "  /  " : "");
                }
                return formationNameList;
            }
        }
        #endregion

        public Formation(byte[] data, int formationNum, Monster[] monsters)
        {
            this.data = data;
            this.formationNum = formationNum;
            this.monsters = monsters;
            InitializeFormation(data);
        }

        private void InitializeFormation(byte[] data)
        {
            byte temp = 0;

            int formationOffset = (formationNum * 0x1A) + 0x39C000;
            temp = BitManager.GetByte(data, formationOffset); formationOffset++;

            formationUse[0] = (temp & 0x80) == 0x80;
            formationUse[1] = (temp & 0x40) == 0x40;
            formationUse[2] = (temp & 0x20) == 0x20;
            formationUse[3] = (temp & 0x10) == 0x10;
            formationUse[4] = (temp & 0x08) == 0x08;
            formationUse[5] = (temp & 0x04) == 0x04;
            formationUse[6] = (temp & 0x02) == 0x02;
            formationUse[7] = (temp & 0x01) == 0x01;

            temp = BitManager.GetByte(data, formationOffset); formationOffset++;

            formationHide[0] = (temp & 0x80) == 0x80;
            formationHide[1] = (temp & 0x40) == 0x40;
            formationHide[2] = (temp & 0x20) == 0x20;
            formationHide[3] = (temp & 0x10) == 0x10;
            formationHide[4] = (temp & 0x08) == 0x08;
            formationHide[5] = (temp & 0x04) == 0x04;
            formationHide[6] = (temp & 0x02) == 0x02;
            formationHide[7] = (temp & 0x01) == 0x01;

            for (int i = 0; i < 8; i++)
            {
                formationMonster[i] = BitManager.GetByte(data, formationOffset); formationOffset++;
                formationCoordX[i] = BitManager.GetByte(data, formationOffset); formationOffset++;
                formationCoordY[i] = BitManager.GetByte(data, formationOffset); formationOffset++;
            }

            int formationStatsOffset = (formationNum * 3) + 0x392AAA;

            formationUnknown = BitManager.GetByte(data, formationStatsOffset); formationStatsOffset++;

            temp = BitManager.GetByte(data, formationStatsOffset); formationStatsOffset++;
            formationBattleEvent = temp == 0xFF ? (byte)102 : temp;

            temp = BitManager.GetByte(data, formationStatsOffset); formationStatsOffset++;

            formationCantRun = (temp & 0x03) == 0x03;
            if ((temp & 0xC0) == 0xC0)
                formationMusic = 8;
            else
                formationMusic = (byte)(temp >> 2);
        }
        public void Assemble()
        {
            int formationOffset = (formationNum * 0x1A) + 0x39C000;
            BitManager.SetBit(data, formationOffset, 7, formationUse[0]);
            BitManager.SetBit(data, formationOffset, 6, formationUse[1]);
            BitManager.SetBit(data, formationOffset, 5, formationUse[2]);
            BitManager.SetBit(data, formationOffset, 4, formationUse[3]);
            BitManager.SetBit(data, formationOffset, 3, formationUse[4]);
            BitManager.SetBit(data, formationOffset, 2, formationUse[5]);
            BitManager.SetBit(data, formationOffset, 1, formationUse[6]);
            BitManager.SetBit(data, formationOffset, 0, formationUse[7]);
            formationOffset++;

            BitManager.SetBit(data, formationOffset, 7, formationHide[0]);
            BitManager.SetBit(data, formationOffset, 6, formationHide[1]);
            BitManager.SetBit(data, formationOffset, 5, formationHide[2]);
            BitManager.SetBit(data, formationOffset, 4, formationHide[3]);
            BitManager.SetBit(data, formationOffset, 3, formationHide[4]);
            BitManager.SetBit(data, formationOffset, 2, formationHide[5]);
            BitManager.SetBit(data, formationOffset, 1, formationHide[6]);
            BitManager.SetBit(data, formationOffset, 0, formationHide[7]);
            formationOffset++;

            for (int i = 0; i < 8; i++)
            {
                BitManager.SetByte(data, formationOffset, formationMonster[i]); formationOffset++;
                BitManager.SetByte(data, formationOffset, formationCoordX[i]); formationOffset++;
                BitManager.SetByte(data, formationOffset, formationCoordY[i]); formationOffset++;
            }

            int formationStatsOffset = (formationNum * 3) + 0x392AAA;

            BitManager.SetByte(data, formationStatsOffset, formationUnknown); formationStatsOffset++;

            if (formationBattleEvent == 102)
                BitManager.SetByte(data, formationStatsOffset, 0xff);
            else
                BitManager.SetByte(data, formationStatsOffset, formationBattleEvent);
            formationStatsOffset++;

            if (formationMusic == 8)
                data[formationStatsOffset] = 0xC0;
            else
                data[formationStatsOffset] = (byte)(formationMusic << 2);

            BitManager.SetBitsByByte(data, formationStatsOffset, 0x03, formationCantRun); formationStatsOffset++;
        }
        public void Clear()
        {
            formationMonster = new byte[8];
            formationCoordX = new byte[8];
            formationCoordY = new byte[8];
            formationUse = new bool[8];
            formationHide = new bool[8];
            formationMusic = 0;
            formationBattleEvent = 0;
            formationCantRun = false;
            formationUnknown = 0;
        }
        public override string ToString()
        {
            return this.FormationNameList;
        }
    }
}
