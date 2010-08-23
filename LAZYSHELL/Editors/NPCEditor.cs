using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    public partial class NPCEditor : Form
    {
        private Settings settings = Settings.Default;
        private NPCProperties[] npcProperties;
        private NPCProperties npcProperty { get { return npcProperties[index]; } set { npcProperties[index] = value; } }
        private Bitmap spriteImage;
        private int[] spritePixels;
        private int imageWidth;
        private int imageHeight;
        private Levels level;
        private int index { get { return (int)npcNum.Value; } set { npcNum.Value = value; } }

        private bool updating = false;

        public NPCEditor(NPCProperties[] npcProperties, Levels level, decimal npcID)
        {
            this.npcProperties = npcProperties;
            this.level = level;
            InitializeComponent();
            spriteName.Items.AddRange(Lists.Numerize(Lists.SpriteNames));
            npcNum.Value = npcID;
            InitializeNPCs();
            new Search(spriteName, spriteNameTextBox, searchSpriteNames, spriteName.Items);
        }
        private void InitializeNPCs()
        {
            updating = true;

            this.spriteName.SelectedIndex = npcProperty.Sprite;
            this.layerPriority.SetItemChecked(0, npcProperty.Priority0);
            this.layerPriority.SetItemChecked(1, npcProperty.Priority1);
            this.layerPriority.SetItemChecked(2, npcProperty.Priority2);
            this.yPixelShift.Value = npcProperty.YPixelShiftUp + (npcProperty.Shift16pxDown ? -16 : 0);
            this.axisAcute.Value = npcProperty.AcuteAxis;
            this.axisObtuse.Value = npcProperty.ObtuseAxis;
            this.height.Value = npcProperty.Height;

            this.shadow.SelectedIndex = npcProperty.Shadow;

            this.unknownBits.SetItemChecked(0, npcProperty.B1b2);
            this.unknownBits.SetItemChecked(1, npcProperty.B1b3);
            this.unknownBits.SetItemChecked(2, npcProperty.B1b4);
            this.unknownBits.SetItemChecked(3, npcProperty.B1b5);
            this.unknownBits.SetItemChecked(4, npcProperty.B1b6);
            this.unknownBits.SetItemChecked(5, npcProperty.B1b7);
            this.unknownBits.SetItemChecked(6, npcProperty.B2b0);
            this.unknownBits.SetItemChecked(7, npcProperty.B2b1);
            this.unknownBits.SetItemChecked(8, npcProperty.B2b2);
            this.unknownBits.SetItemChecked(9, npcProperty.B2b3);
            this.unknownBits.SetItemChecked(10, npcProperty.B2b4);
            this.unknownBits.SetItemChecked(11, npcProperty.B3b7);
            this.unknownBits.SetItemChecked(12, npcProperty.B5b5);
            this.unknownBits.SetItemChecked(13, npcProperty.B5b6);
            this.unknownBits.SetItemChecked(14, npcProperty.B5b7);
            this.unknownBits.SetItemChecked(15, npcProperty.B6b2);

            SetSpriteImage();

            updating = false;
        }

        private void LoadSearch()
        {
            searchResults.Items.Clear();

            bool notFound;
            int val = (int)spriteName.SelectedIndex;
            for (int i = 0; i < npcProperties.Length; i++)
            {
                notFound = false;
                if (spriteName.SelectedIndex != npcProperties[i].Sprite) notFound = true;
                if (!notFound)
                    searchResults.Items.Add("NPC #" + i.ToString() + "\n");
            }
        }

        private void SetSpriteImage()
        {
            spritePixels = npcProperties[0].CreateImage(3, true, (int)spriteName.SelectedIndex);
            imageWidth = npcProperties[0].ImageWidth;
            imageHeight = npcProperties[0].ImageHeight;
            if (spritePixels.Length == 0) { spritePixels = new int[2]; imageWidth = 1; imageHeight = 1; }
            spriteImage = new Bitmap(Do.PixelsToImage(spritePixels, imageWidth, imageHeight));
            spritePictureBox.Invalidate();
        }

        private void npcNum_ValueChanged(object sender, EventArgs e)
        {
            InitializeNPCs();
        }
        private void spriteName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            SetSpriteImage();
        }
        private void layerPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
        }
        private void yPixelShift_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
        }
        private void axisAcute_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
        }
        private void axisObtuse_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
        }
        private void height_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
        }
        private void shadow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
        }
        private void unknownBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            LoadSearch();
        }
        private void spritePictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (spriteImage != null)
                e.Graphics.DrawImage(spriteImage, 128 - (spriteImage.Width / 2), 128 - (spriteImage.Height / 2));
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            level.npcID_ValueChanged(null, null);

            npcProperty.Sprite = (ushort)spriteName.SelectedIndex;
            npcProperty.Priority0 = layerPriority.GetItemChecked(0);
            npcProperty.Priority1 = layerPriority.GetItemChecked(1);
            npcProperty.Priority2 = layerPriority.GetItemChecked(2);
            if (yPixelShift.Value >= 0)
            {
                npcProperty.YPixelShiftUp = (byte)yPixelShift.Value;
                npcProperty.Shift16pxDown = false;
            }
            else
            {
                npcProperty.YPixelShiftUp = (byte)(16 + yPixelShift.Value);
                npcProperty.Shift16pxDown = true;
            }
            npcProperty.AcuteAxis = (byte)axisAcute.Value;
            npcProperty.ObtuseAxis = (byte)axisObtuse.Value;
            npcProperty.Height = (byte)height.Value;
            npcProperty.Shadow = (byte)shadow.SelectedIndex;
            npcProperty.B1b2 = unknownBits.GetItemChecked(0);
            npcProperty.B1b3 = unknownBits.GetItemChecked(1);
            npcProperty.B1b4 = unknownBits.GetItemChecked(2);
            npcProperty.B1b5 = unknownBits.GetItemChecked(3);
            npcProperty.B1b6 = unknownBits.GetItemChecked(4);
            npcProperty.B1b7 = unknownBits.GetItemChecked(5);
            npcProperty.B2b0 = unknownBits.GetItemChecked(6);
            npcProperty.B2b1 = unknownBits.GetItemChecked(7);
            npcProperty.B2b2 = unknownBits.GetItemChecked(8);
            npcProperty.B2b3 = unknownBits.GetItemChecked(9);
            npcProperty.B2b4 = unknownBits.GetItemChecked(10);
            npcProperty.B3b7 = unknownBits.GetItemChecked(11);
            npcProperty.B5b5 = unknownBits.GetItemChecked(12);
            npcProperty.B5b6 = unknownBits.GetItemChecked(13);
            npcProperty.B5b7 = unknownBits.GetItemChecked(14);
            npcProperty.B6b2 = unknownBits.GetItemChecked(15);

            this.Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            level.NPCID.Value = Convert.ToInt32(searchResults.SelectedItem.ToString().Substring(5));
        }
    }
}