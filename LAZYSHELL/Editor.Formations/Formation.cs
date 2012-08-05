using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    [Serializable()]
    public class Formation : Element
    {
        [NonSerialized()]
        private byte[] data;
        public override byte[] Data { get { return this.data; } set { this.data = value; } }
        public override int Index { get { return index; } set { index = value; } }

        #region Fomation Stats
        private int index;
        private byte[] formationMonster = new byte[8];
        private byte[] formationCoordX = new byte[8];
        private byte[] formationCoordY = new byte[8];
        private bool[] formationUse = new bool[8];
        private bool[] formationHide = new bool[8];
        [NonSerialized()]
        private int[][] formationMonstersPixels = new int[8][];
        private byte formationMusic;
        private byte formationBattleEvent;
        private bool formationCantRun;
        private byte formationUnknown;
        private int elevation;
        private int[] pixelIndexes;

        #endregion
        #region Accessors
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

        public int[] PixelIndexes
        {
            get
            {
                if (pixelIndexes == null)
                    SetPixelIndexes();
                return pixelIndexes;
            }
            set { pixelIndexes = value; }
        }
        private void SetPixelIndexes()
        {
            pixelIndexes = new int[256 * 256];
            int[] order = new int[8];
            for (int i = 0; i < 8; i++)
                order[i] = i;
            byte[] temp = Bits.Copy(formationCoordY);
            Array.Sort(temp, order);
            for (int g = 0; g < 8; g++)
            {
                int i = order[g];
                // If monster is used in formation
                if (formationUse[i])
                {
                    // Get correct monster image
                    int[] monster = Model.Monsters[formationMonster[i]].Pixels();
                    int elevation = Model.Monsters[formationMonster[i]].Elevation * 16;
                    for (int y = 0; y < 256; y++)
                    {
                        for (int x = 0; x < 256; x++)
                        {
                            int x_ = formationCoordX[i] + x - 128;
                            int y_ = formationCoordY[i] + y - 96 - elevation;
                            if ((monster[y * 256 + x] & 0xFF000000) != 0)
                            {
                                if (x_ > 0 && x_ < 256 && y_ > 0 && y_ < 256)
                                    pixelIndexes[(y_ - 1) * 256 + x_] = i + 1;
                            }
                        }
                    }
                }
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
                        names[i] = Do.RawToASCII(Model.Monsters[formationMonster[i]].Name, Settings.Default.KeystrokesMenu);
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
                        formationNameList +=
                            Do.RawToASCII(Model.Monsters[formationMonster[i]].Name, Settings.Default.KeystrokesMenu).Trim() +
                            ((i < 7) ? "  /  " : "");
                    else
                        formationNameList += "..." + ((i < 7) ? "  /  " : "");
                }
                return formationNameList;
            }
        }
        #endregion

        public Formation(byte[] data, int index)
        {
            this.data = data;
            this.index = index;
            InitializeFormation(data);
        }

        private void InitializeFormation(byte[] data)
        {
            byte temp = 0;

            int formationOffset = (index * 0x1A) + 0x39C000;
            temp = data[formationOffset]; formationOffset++;

            formationUse[0] = (temp & 0x80) == 0x80;
            formationUse[1] = (temp & 0x40) == 0x40;
            formationUse[2] = (temp & 0x20) == 0x20;
            formationUse[3] = (temp & 0x10) == 0x10;
            formationUse[4] = (temp & 0x08) == 0x08;
            formationUse[5] = (temp & 0x04) == 0x04;
            formationUse[6] = (temp & 0x02) == 0x02;
            formationUse[7] = (temp & 0x01) == 0x01;

            temp = data[formationOffset]; formationOffset++;

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
                formationMonster[i] = data[formationOffset]; formationOffset++;
                formationCoordX[i] = data[formationOffset]; formationOffset++;
                formationCoordY[i] = data[formationOffset]; formationOffset++;
            }

            int formationStatsOffset = (index * 3) + 0x392AAA;

            formationUnknown = data[formationStatsOffset]; formationStatsOffset++;

            temp = data[formationStatsOffset]; formationStatsOffset++;
            formationBattleEvent = temp == 0xFF ? (byte)102 : temp;

            temp = data[formationStatsOffset]; formationStatsOffset++;

            formationCantRun = (temp & 0x03) == 0x03;
            if ((temp & 0xC0) == 0xC0)
                formationMusic = 8;
            else
                formationMusic = (byte)(temp >> 2);
        }
        public void Assemble()
        {
            int formationOffset = (index * 0x1A) + 0x39C000;
            Bits.SetBit(data, formationOffset, 7, formationUse[0]);
            Bits.SetBit(data, formationOffset, 6, formationUse[1]);
            Bits.SetBit(data, formationOffset, 5, formationUse[2]);
            Bits.SetBit(data, formationOffset, 4, formationUse[3]);
            Bits.SetBit(data, formationOffset, 3, formationUse[4]);
            Bits.SetBit(data, formationOffset, 2, formationUse[5]);
            Bits.SetBit(data, formationOffset, 1, formationUse[6]);
            Bits.SetBit(data, formationOffset, 0, formationUse[7]);
            formationOffset++;

            Bits.SetBit(data, formationOffset, 7, formationHide[0]);
            Bits.SetBit(data, formationOffset, 6, formationHide[1]);
            Bits.SetBit(data, formationOffset, 5, formationHide[2]);
            Bits.SetBit(data, formationOffset, 4, formationHide[3]);
            Bits.SetBit(data, formationOffset, 3, formationHide[4]);
            Bits.SetBit(data, formationOffset, 2, formationHide[5]);
            Bits.SetBit(data, formationOffset, 1, formationHide[6]);
            Bits.SetBit(data, formationOffset, 0, formationHide[7]);
            formationOffset++;

            for (int i = 0; i < 8; i++)
            {
                Bits.SetByte(data, formationOffset, formationMonster[i]); formationOffset++;
                Bits.SetByte(data, formationOffset, formationCoordX[i]); formationOffset++;
                Bits.SetByte(data, formationOffset, formationCoordY[i]); formationOffset++;
            }

            int formationStatsOffset = (index * 3) + 0x392AAA;

            Bits.SetByte(data, formationStatsOffset, formationUnknown); formationStatsOffset++;

            if (formationBattleEvent == 102)
                Bits.SetByte(data, formationStatsOffset, 0xff);
            else
                Bits.SetByte(data, formationStatsOffset, formationBattleEvent);
            formationStatsOffset++;

            if (formationMusic == 8)
                data[formationStatsOffset] = 0xC0;
            else
                data[formationStatsOffset] = (byte)(formationMusic << 2);

            Bits.SetBitsByByte(data, formationStatsOffset, 0x03, formationCantRun); formationStatsOffset++;
        }
        public override void Clear()
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
            Settings.Default.KeystrokesMenu[0x20] = "\x20";
            return this.FormationNameList;
        }
    }
}
