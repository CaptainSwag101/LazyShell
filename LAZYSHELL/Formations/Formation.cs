using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using LazyShell.Properties;

namespace LazyShell.Formations
{
    [Serializable()]
    public class Formation : Element
    {
        #region Variables

        // ROM buffer
        private byte[] rom
        {
            get { return Model.ROM; }
            set { Model.ROM = value; }
        }

        // Index
        public override int Index { get; set; }

        // Properties
        public byte[] Monsters { get; set; }
        public byte[] X { get; set; }
        public byte[] Y { get; set; }
        public bool[] Active { get; set; }
        public bool[] Hide { get; set; }
        public byte MusicTheme { get; set; }
        public byte StartEvent { get; set; }
        public bool CantRun { get; set; }
        public byte Unknown { get; set; }
        public int Elevation { get; set; }

        // Drawing
        private int[] pixelIndexes;
        /// <summary>
        /// Retrieves a pixel map of indexes referencing the monsters in this formation. 
        /// Each pixel in the map is assigned an index which references the monster whose 
        /// image occupies the pixel in the formation image. 
        /// This value is not automatically updated.
        /// </summary>
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
            Bits.Fill(pixelIndexes, -1);
            int[] order = new int[8];
            for (int i = 0; i < 8; i++)
                order[i] = i;
            byte[] temp = Bits.Copy(this.Y);
            Array.Sort(temp, order);
            for (int g = 0; g < 8; g++)
            {
                int i = order[g];
                // If monster is used in formation
                if (Active[i])
                {
                    // Get correct monster image
                    int[] pixels = LazyShell.Monsters.Model.Monsters[Monsters[i]].Pixels;
                    int elevation = LazyShell.Monsters.Model.Monsters[Monsters[i]].Elevation * 16;
                    for (int y = 0; y < 256; y++)
                    {
                        for (int x = 0; x < 256; x++)
                        {
                            int x_ = this.X[i] + x - 128;
                            int y_ = this.Y[i] + y - 96 - elevation;
                            if ((pixels[y * 256 + x] & 0xFF000000) != 0)
                            {
                                if (x_ > 0 && x_ < 256 && y_ > 0 && y_ < 256)
                                    pixelIndexes[(y_ - 1) * 256 + x_] = i;
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Retrieves a list of the monster names, separated by a specified value, of this formation's monsters.
        /// </summary>
        /// <param name="separator">The string to insert between each name.</param>
        /// <param name="empty">The string to use for inactive monsters.</param>
        public string GetMonsterNames(string separator, string empty)
        {
            string output = "";
            for (int i = 0; i < 8; i++)
            {
                var name = LazyShell.Monsters.Model.Monsters[Monsters[i]].Name;
                if (Active[i])
                    output += Do.RawToASCII(name, Lists.KeystrokesMenu).Trim() + separator;
                else
                    output += empty + separator;
            }
            return output.Trim(separator.ToCharArray());
        }
        /// <summary>
        /// Retrieves a list of the monster names of this formation's monsters.
        /// </summary>
        /// <param name="empty">The string to use for inactive monsters.</param>
        public string[] GetMonsterNames(string empty)
        {
            string[] output = new string[8];
            for (int i = 0; i < 8; i++)
            {
                var name = LazyShell.Monsters.Model.Monsters[Monsters[i]].Name;
                if (Active[i])
                    output[i] = Do.RawToASCII(name, Lists.KeystrokesMenu).Trim();
                else
                    output[i] = empty;
            }
            return output;
        }

        #endregion

        // Constructor
        public Formation(int index)
        {
            this.Index = index;
            ReadFromROM();
        }

        #region Methods

        // Read/write ROM
        private void ReadFromROM()
        {
            byte temp = 0;
            int offset = (Index * 0x1A) + 0x39C000;
            temp = rom[offset++];
            Active = new bool[8];
            Active[0] = (temp & 0x80) == 0x80;
            Active[1] = (temp & 0x40) == 0x40;
            Active[2] = (temp & 0x20) == 0x20;
            Active[3] = (temp & 0x10) == 0x10;
            Active[4] = (temp & 0x08) == 0x08;
            Active[5] = (temp & 0x04) == 0x04;
            Active[6] = (temp & 0x02) == 0x02;
            Active[7] = (temp & 0x01) == 0x01;
            //
            temp = rom[offset++];
            Hide = new bool[8];
            Hide[0] = (temp & 0x80) == 0x80;
            Hide[1] = (temp & 0x40) == 0x40;
            Hide[2] = (temp & 0x20) == 0x20;
            Hide[3] = (temp & 0x10) == 0x10;
            Hide[4] = (temp & 0x08) == 0x08;
            Hide[5] = (temp & 0x04) == 0x04;
            Hide[6] = (temp & 0x02) == 0x02;
            Hide[7] = (temp & 0x01) == 0x01;
            Monsters = new byte[8];
            X = new byte[8];
            Y = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                Monsters[i] = rom[offset++];
                X[i] = rom[offset++];
                Y[i] = rom[offset++];
            }
            //
            offset = (Index * 3) + 0x392AAA;
            Unknown = rom[offset++];
            temp = rom[offset++];
            StartEvent = temp == 0xFF ? (byte)102 : temp;
            temp = rom[offset++];
            CantRun = (temp & 0x03) == 0x03;
            if ((temp & 0xC0) == 0xC0)
                MusicTheme = 8;
            else
                MusicTheme = (byte)(temp >> 2);
        }
        public void WriteToROM()
        {
            int offset = (Index * 0x1A) + 0x39C000;
            Bits.SetBit(rom, offset, 7, Active[0]);
            Bits.SetBit(rom, offset, 6, Active[1]);
            Bits.SetBit(rom, offset, 5, Active[2]);
            Bits.SetBit(rom, offset, 4, Active[3]);
            Bits.SetBit(rom, offset, 3, Active[4]);
            Bits.SetBit(rom, offset, 2, Active[5]);
            Bits.SetBit(rom, offset, 1, Active[6]);
            Bits.SetBit(rom, offset++, 0, Active[7]);
            //
            Bits.SetBit(rom, offset, 7, Hide[0]);
            Bits.SetBit(rom, offset, 6, Hide[1]);
            Bits.SetBit(rom, offset, 5, Hide[2]);
            Bits.SetBit(rom, offset, 4, Hide[3]);
            Bits.SetBit(rom, offset, 3, Hide[4]);
            Bits.SetBit(rom, offset, 2, Hide[5]);
            Bits.SetBit(rom, offset, 1, Hide[6]);
            Bits.SetBit(rom, offset++, 0, Hide[7]);
            //
            for (int i = 0; i < 8; i++)
            {
                rom[offset++] = Monsters[i];
                rom[offset++] = X[i];
                rom[offset++] = Y[i];
            }
            //
            offset = (Index * 3) + 0x392AAA;
            rom[offset++] = Unknown;
            if (StartEvent == 102)
                rom[offset++] = 0xff;
            else
                rom[offset++] = StartEvent;
            if (MusicTheme == 8)
                rom[offset] = 0xC0;
            else
                rom[offset] = (byte)(MusicTheme << 2);
            Bits.SetBitsByByte(rom, offset++, 0x03, CantRun);
        }

        // Inherited
        public override void Clear()
        {
            Monsters = new byte[8];
            X = new byte[8];
            Y = new byte[8];
            Active = new bool[8];
            Hide = new bool[8];
            MusicTheme = 0;
            StartEvent = 0;
            CantRun = false;
            Unknown = 0;
        }

        // Override
        public override string ToString()
        {
            return this.GetMonsterNames("  /  ", "");
        }

        #endregion
    }
}
