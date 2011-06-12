using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public partial class SpritePartitions : Form
    {
        private Levels level;
        private NPCSpritePartitions[] npcSpritePartitions;
        // constructor
        public SpritePartitions(Levels level, NPCSpritePartitions[] npcSpritePartitions)
        {
            this.level = level;
            this.npcSpritePartitions = npcSpritePartitions;
            InitializeComponent();

            byte2a.SelectedIndex = 0;
            byte2b.SelectedIndex = 0;
            byte3a.SelectedIndex = 0;
            byte3b.SelectedIndex = 0;
            byte4a.SelectedIndex = 0;
            byte4b.SelectedIndex = 0;
        }
        // functions
        private void LoadSearch()
        {
            listBox1.Items.Clear();

            bool
                notFound,
                notFoundInByte1, notFoundInByte2, notFoundInByte3, notFoundInByte4,
                notFoundBlockAinByte2, notFoundBlockAinByte3, notFoundBlockAinByte4,
                notFoundBlockBinByte2, notFoundBlockBinByte3, notFoundBlockBinByte4,
                notFoundBlockCinByte2, notFoundBlockCinByte3, notFoundBlockCinByte4;

            for (int i = 0; i < npcSpritePartitions.Length; i++)
            {
                notFound = false;

                notFoundInByte1 = false;
                notFoundInByte2 = false;
                notFoundInByte3 = false;
                notFoundInByte4 = false;
                notFoundBlockAinByte2 = false;
                notFoundBlockAinByte3 = false;
                notFoundBlockAinByte4 = false;
                notFoundBlockBinByte2 = false;
                notFoundBlockBinByte3 = false;
                notFoundBlockBinByte4 = false;
                notFoundBlockCinByte2 = false;
                notFoundBlockCinByte3 = false;
                notFoundBlockCinByte4 = false;

                if (checkVramIndex.GetItemChecked(0))
                {
                    if (vramIndex.Value != npcSpritePartitions[i].VramIndex) notFoundInByte1 = true;
                }
                if (checkPaletteIndex.GetItemChecked(0))
                {
                    if (paletteIndex.Value != npcSpritePartitions[i].PalIndexPlus) notFoundInByte1 = true;
                }
                if (byte1.GetItemChecked(0))
                {
                    if (!npcSpritePartitions[i].Byte1bit4) notFoundInByte1 = true;
                }
                if (byte1.GetItemChecked(1))
                {
                    if (!npcSpritePartitions[i].Byte1bit7) notFoundInByte1 = true;
                }

                // search byte 2 for VRAM block A's properties
                if (checkByte2a.GetItemChecked(0))
                    notFoundInByte2 = byte2a.SelectedIndex != npcSpritePartitions[i].Byte2a;
                if (!notFoundInByte2 && checkByte2b.GetItemChecked(0))
                    notFoundInByte2 = byte2b.SelectedIndex != npcSpritePartitions[i].Byte2b;
                if (!notFoundInByte2 && byte2.GetItemChecked(0))
                    notFoundInByte2 = !npcSpritePartitions[i].Byte2bit7;
                notFoundBlockAinByte2 = notFoundInByte2;
                notFoundInByte2 = false;

                // search byte 3 for VRAM block A's properties
                if (checkByte2a.GetItemChecked(0))
                    notFoundInByte3 = byte2a.SelectedIndex != npcSpritePartitions[i].Byte3a;
                if (!notFoundInByte3 && checkByte2b.GetItemChecked(0))
                    notFoundInByte3 = byte2b.SelectedIndex != npcSpritePartitions[i].Byte3b;
                if (!notFoundInByte3 && byte2.GetItemChecked(0))
                    notFoundInByte3 = !npcSpritePartitions[i].Byte3bit7;
                notFoundBlockAinByte3 = notFoundInByte3;
                notFoundInByte3 = false;

                // search byte 4 for VRAM block A's properties
                if (checkByte2a.GetItemChecked(0))
                    notFoundInByte4 = byte2a.SelectedIndex != npcSpritePartitions[i].Byte4a;
                if (!notFoundInByte4 && checkByte2b.GetItemChecked(0))
                    notFoundInByte4 = byte2b.SelectedIndex != npcSpritePartitions[i].Byte4b;
                if (!notFoundInByte4 && byte2.GetItemChecked(0))
                    notFoundInByte4 = !npcSpritePartitions[i].Byte4bit7;
                notFoundBlockAinByte4 = notFoundInByte4;
                notFoundInByte4 = false;


                // search byte 2 for VRAM block B's properties
                if (checkByte3a.GetItemChecked(0))
                    notFoundInByte2 = byte3a.SelectedIndex != npcSpritePartitions[i].Byte2a;
                if (!notFoundInByte2 && checkByte3b.GetItemChecked(0))
                    notFoundInByte2 = byte3b.SelectedIndex != npcSpritePartitions[i].Byte2b;
                if (!notFoundInByte2 && byte3.GetItemChecked(0))
                    notFoundInByte2 = !npcSpritePartitions[i].Byte2bit7;
                notFoundBlockBinByte2 = notFoundInByte2;
                notFoundInByte2 = false;

                // search byte 3 for VRAM block B's properties
                if (checkByte3a.GetItemChecked(0))
                    notFoundInByte3 = byte3a.SelectedIndex != npcSpritePartitions[i].Byte3a;
                if (!notFoundInByte3 && checkByte3b.GetItemChecked(0))
                    notFoundInByte3 = byte3b.SelectedIndex != npcSpritePartitions[i].Byte3b;
                if (!notFoundInByte3 && byte3.GetItemChecked(0))
                    notFoundInByte3 = !npcSpritePartitions[i].Byte3bit7;
                notFoundBlockBinByte3 = notFoundInByte3;
                notFoundInByte3 = false;

                // search byte 4 for VRAM block B's properties
                if (checkByte3a.GetItemChecked(0))
                    notFoundInByte4 = byte3a.SelectedIndex != npcSpritePartitions[i].Byte4a;
                if (!notFoundInByte4 && checkByte3b.GetItemChecked(0))
                    notFoundInByte4 = byte3b.SelectedIndex != npcSpritePartitions[i].Byte4b;
                if (!notFoundInByte4 && byte3.GetItemChecked(0))
                    notFoundInByte4 = !npcSpritePartitions[i].Byte4bit7;
                notFoundBlockBinByte4 = notFoundInByte4;
                notFoundInByte4 = false;


                // search byte 2 for VRAM block C's properties
                if (checkByte4a.GetItemChecked(0))
                    notFoundInByte2 = byte4a.SelectedIndex != npcSpritePartitions[i].Byte2a;
                if (!notFoundInByte2 && checkByte4b.GetItemChecked(0))
                    notFoundInByte2 = byte4b.SelectedIndex != npcSpritePartitions[i].Byte2b;
                if (!notFoundInByte2 && byte4.GetItemChecked(0))
                    notFoundInByte2 = !npcSpritePartitions[i].Byte2bit7;
                notFoundBlockCinByte2 = notFoundInByte2;
                notFoundInByte2 = false;

                // search byte 3 for VRAM block C's properties
                if (checkByte4a.GetItemChecked(0))
                    notFoundInByte3 = byte4a.SelectedIndex != npcSpritePartitions[i].Byte3a;
                if (!notFoundInByte3 && checkByte4b.GetItemChecked(0))
                    notFoundInByte3 = byte4b.SelectedIndex != npcSpritePartitions[i].Byte3b;
                if (!notFoundInByte3 && byte4.GetItemChecked(0))
                    notFoundInByte3 = !npcSpritePartitions[i].Byte3bit7;
                notFoundBlockCinByte3 = notFoundInByte3;
                notFoundInByte3 = false;

                // search byte 4 for VRAM block C's properties
                if (checkByte4a.GetItemChecked(0))
                    notFoundInByte4 = byte4a.SelectedIndex != npcSpritePartitions[i].Byte4a;
                if (!notFoundInByte4 && checkByte4b.GetItemChecked(0))
                    notFoundInByte4 = byte4b.SelectedIndex != npcSpritePartitions[i].Byte4b;
                if (!notFoundInByte4 && byte4.GetItemChecked(0))
                    notFoundInByte4 = !npcSpritePartitions[i].Byte4bit7;
                notFoundBlockCinByte4 = notFoundInByte4;
                notFoundInByte4 = false;

                // A2,B3,C4
                // A2,B4,C3
                // A3,B2,C4
                // A3,B4,C2
                // A4,B2,C3
                // A4,B3,C2
                notFound = !(!notFoundInByte1 && !notFoundBlockAinByte2 && !notFoundBlockBinByte3 && !notFoundBlockCinByte4);
                if (notFound)
                    notFound = !(!notFoundInByte1 && !notFoundBlockAinByte2 && !notFoundBlockBinByte4 && !notFoundBlockCinByte3);
                if (notFound)
                    notFound = !(!notFoundInByte1 && !notFoundBlockAinByte3 && !notFoundBlockBinByte2 && !notFoundBlockCinByte4);
                if (notFound)
                    notFound = !(!notFoundInByte1 && !notFoundBlockAinByte3 && !notFoundBlockBinByte4 && !notFoundBlockCinByte2);
                if (notFound)
                    notFound = !(!notFoundInByte1 && !notFoundBlockAinByte4 && !notFoundBlockBinByte2 && !notFoundBlockCinByte3);
                if (notFound)
                    notFound = !(!notFoundInByte1 && !notFoundBlockAinByte4 && !notFoundBlockBinByte3 && !notFoundBlockCinByte2);
                
                if (!notFound) listBox1.Items.Add("Partition #" + i.ToString());
            }
        }
        // event handlers
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            level.NPCMapHeader.Value = Convert.ToInt32(listBox1.SelectedItem.ToString().Substring(11));
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            LoadSearch();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}