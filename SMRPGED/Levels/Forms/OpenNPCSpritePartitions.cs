using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMRPGED
{
    public partial class OpenNPCSpritePartitions : Form
    {
        private NPCSpritePartitions[] npcSpritePartitions;

        public OpenNPCSpritePartitions(NPCSpritePartitions[] npcSpritePartitions, byte thing)
        {
            this.npcSpritePartitions = npcSpritePartitions;
            InitializeComponent();

            byte2a.SelectedIndex = 0;
            byte2b.SelectedIndex = 0;
            byte3a.SelectedIndex = 0;
            byte3b.SelectedIndex = 0;
            byte4a.SelectedIndex = 0;
            byte4b.SelectedIndex = 0;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            LoadSearch();
        }
        private void LoadSearch()
        {
            string partitionSearch = "";
            bool notFound;

            for (int i = 0; i < npcSpritePartitions.Length; i++)
            {
                notFound = false;
                if (checkVramIndex.GetItemChecked(0)) { if (vramIndex.Value != npcSpritePartitions[i].VramIndex)notFound = true; }
                if (checkPaletteIndex.GetItemChecked(0)) { if (paletteIndex.Value != npcSpritePartitions[i].PalIndexPlus)notFound = true; }
                if (byte1.GetItemChecked(0)) { if (!npcSpritePartitions[i].Byte1bit4)notFound = true; }
                if (byte1.GetItemChecked(1)) { if (!npcSpritePartitions[i].Byte1bit7)notFound = true; }
                if (checkByte2a.GetItemChecked(0)) { if (byte2a.SelectedIndex != npcSpritePartitions[i].Byte2a)notFound = true; }
                if (checkByte2b.GetItemChecked(0)) { if (byte2b.SelectedIndex != npcSpritePartitions[i].Byte2b)notFound = true; }
                if (byte2.GetItemChecked(0)) { if (!npcSpritePartitions[i].Byte2bit7)notFound = true; }
                if (checkByte3a.GetItemChecked(0)) { if (byte3a.SelectedIndex != npcSpritePartitions[i].Byte3a)notFound = true; }
                if (checkByte3b.GetItemChecked(0)) { if (byte3b.SelectedIndex != npcSpritePartitions[i].Byte3b)notFound = true; }
                if (byte3.GetItemChecked(0)) { if (!npcSpritePartitions[i].Byte3bit7)notFound = true; }
                if (checkByte4a.GetItemChecked(0)) { if (byte4a.SelectedIndex != npcSpritePartitions[i].Byte4a)notFound = true; }
                if (checkByte4b.GetItemChecked(0)) { if (byte4b.SelectedIndex != npcSpritePartitions[i].Byte4b)notFound = true; }
                if (byte4.GetItemChecked(0)) { if (!npcSpritePartitions[i].Byte4bit7)notFound = true; }

                if (!notFound) partitionSearch += "#" + i.ToString() + "\n";
            }
            searchResults.Text = "Found the following sprite partitions with above properties...\n\n" + partitionSearch;
        }
    }
}