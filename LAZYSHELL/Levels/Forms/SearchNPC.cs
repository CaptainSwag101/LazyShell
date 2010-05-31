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
    public partial class SearchNPC : Form
    {
        private Settings settings;
        private NPCProperties[] npcProperties;
        private Bitmap spriteImage;
        private int[] spritePixels;
        private int imageWidth;
        private int imageHeight;
        private Levels level;

        private bool updating = false;

        public SearchNPC(NPCProperties[] npcProperties, Levels level, decimal npcID)
        {
            this.settings = Settings.Default;
            this.npcProperties = npcProperties;
            this.level = level;
            InitializeComponent();

            for (int i = 0; i < settings.SpriteNames.Count; i++)
                spriteName.Items.Add("[" + i.ToString("d4") + "]  " + settings.SpriteNames[i]);

            npcNum.Value = npcID;
            InitializeNPCs();
        }
        private void InitializeNPCs()
        {
            updating = true;

            this.spriteName.SelectedIndex = npcProperties[(int)npcNum.Value].Sprite;
            this.layerPriority.SetItemChecked(0, npcProperties[(int)npcNum.Value].Priority0);
            this.layerPriority.SetItemChecked(1, npcProperties[(int)npcNum.Value].Priority1);
            this.layerPriority.SetItemChecked(2, npcProperties[(int)npcNum.Value].Priority2);
            this.yPixelShift.Value = npcProperties[(int)npcNum.Value].YPixelShiftUp;
            this.shift16pxDown.Checked = npcProperties[(int)npcNum.Value].Shift16pxDown;
            this.axisAcute.Value = npcProperties[(int)npcNum.Value].AcuteAxis;
            this.axisObtuse.Value = npcProperties[(int)npcNum.Value].ObtuseAxis;
            this.height.Value = npcProperties[(int)npcNum.Value].Height;

            this.shadow.SelectedIndex = npcProperties[(int)npcNum.Value].Shadow;

            this.unknownBits.SetItemChecked(0, npcProperties[(int)npcNum.Value].B1b2);
            this.unknownBits.SetItemChecked(1, npcProperties[(int)npcNum.Value].B1b3);
            this.unknownBits.SetItemChecked(2, npcProperties[(int)npcNum.Value].B1b4);
            this.unknownBits.SetItemChecked(3, npcProperties[(int)npcNum.Value].B1b5);
            this.unknownBits.SetItemChecked(4, npcProperties[(int)npcNum.Value].B1b6);
            this.unknownBits.SetItemChecked(5, npcProperties[(int)npcNum.Value].B1b7);
            this.unknownBits.SetItemChecked(6, npcProperties[(int)npcNum.Value].B2b0);
            this.unknownBits.SetItemChecked(7, npcProperties[(int)npcNum.Value].B2b1);
            this.unknownBits.SetItemChecked(8, npcProperties[(int)npcNum.Value].B2b2);
            this.unknownBits.SetItemChecked(9, npcProperties[(int)npcNum.Value].B2b3);
            this.unknownBits.SetItemChecked(10, npcProperties[(int)npcNum.Value].B2b4);
            this.unknownBits.SetItemChecked(11, npcProperties[(int)npcNum.Value].B3b7);
            this.unknownBits.SetItemChecked(12, npcProperties[(int)npcNum.Value].B5b5);
            this.unknownBits.SetItemChecked(13, npcProperties[(int)npcNum.Value].B5b6);
            this.unknownBits.SetItemChecked(14, npcProperties[(int)npcNum.Value].B5b7);
            this.unknownBits.SetItemChecked(15, npcProperties[(int)npcNum.Value].B6b2);

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
            spriteImage = new Bitmap(DrawImageFromIntArr(spritePixels, imageWidth, imageHeight));
            spritePictureBox.Invalidate();
        }

        private Bitmap DrawImageFromIntArr(int[] arr, int width, int height)
        {
            Bitmap image = null;

            unsafe
            {
                fixed (void* firstPixel = &arr[0])
                {
                    IntPtr ip = new IntPtr(firstPixel);
                    if (image != null)
                        image.Dispose();
                    image = new Bitmap(width, height, width * 4, System.Drawing.Imaging.PixelFormat.Format32bppPArgb, ip);

                }
            }

            return image;

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
        private void shift16pxDown_CheckedChanged(object sender, EventArgs e)
        {
            shift16pxDown.ForeColor = shift16pxDown.Checked ? Color.Black : Color.Gray;

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

        private void searchSpriteNames_Click(object sender, EventArgs e)
        {
            panelSearchSpriteNames.Visible = !panelSearchSpriteNames.Visible;
            if (panelSearchSpriteNames.Visible)
            {
                panelSearchSpriteNames.BringToFront();
                nameTextBox.Focus();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadSpriteNameSearch();
        }
        private void listBoxSpriteNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                spriteName.SelectedItem = listBoxSpriteNames.SelectedItem;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem loading the search item. Try doing another search.", "LAZY SHELL");
            }
        }
        private void nameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                panelSearchSpriteNames.Visible = false;
        }
        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            LoadSpriteNameSearch();
        }
        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                panelSearchSpriteNames.Visible = false;
        }
        private void listBoxSpriteNames_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                panelSearchSpriteNames.Visible = false;
        }

        private void LoadSpriteNameSearch()
        {
            listBoxSpriteNames.BeginUpdate();
            listBoxSpriteNames.Items.Clear();

            for (int i = 0; i < spriteName.Items.Count; i++)
            {
                if (Contains(spriteName.Items[i].ToString(), nameTextBox.Text, StringComparison.CurrentCultureIgnoreCase))
                    listBoxSpriteNames.Items.Add(spriteName.Items[i]);
            }
            listBoxSpriteNames.EndUpdate();
        }
        public static bool Contains(string original, string value, StringComparison comparisionType)
        {
            return original.IndexOf(value, comparisionType) >= 0;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            level.npcID_ValueChanged(null, null);

            npcProperties[(int)npcNum.Value].Sprite = (ushort)spriteName.SelectedIndex;
            npcProperties[(int)npcNum.Value].Priority0 = layerPriority.GetItemChecked(0);
            npcProperties[(int)npcNum.Value].Priority1 = layerPriority.GetItemChecked(1);
            npcProperties[(int)npcNum.Value].Priority2 = layerPriority.GetItemChecked(2);
            npcProperties[(int)npcNum.Value].Shift16pxDown = shift16pxDown.Checked;
            npcProperties[(int)npcNum.Value].YPixelShiftUp = (byte)yPixelShift.Value;
            npcProperties[(int)npcNum.Value].AcuteAxis = (byte)axisAcute.Value;
            npcProperties[(int)npcNum.Value].ObtuseAxis = (byte)axisObtuse.Value;
            npcProperties[(int)npcNum.Value].Height = (byte)height.Value;
            npcProperties[(int)npcNum.Value].Shadow = (byte)shadow.SelectedIndex;
            npcProperties[(int)npcNum.Value].B1b2 = unknownBits.GetItemChecked(0);
            npcProperties[(int)npcNum.Value].B1b3 = unknownBits.GetItemChecked(1);
            npcProperties[(int)npcNum.Value].B1b4 = unknownBits.GetItemChecked(2);
            npcProperties[(int)npcNum.Value].B1b5 = unknownBits.GetItemChecked(3);
            npcProperties[(int)npcNum.Value].B1b6 = unknownBits.GetItemChecked(4);
            npcProperties[(int)npcNum.Value].B1b7 = unknownBits.GetItemChecked(5);
            npcProperties[(int)npcNum.Value].B2b0 = unknownBits.GetItemChecked(6);
            npcProperties[(int)npcNum.Value].B2b1 = unknownBits.GetItemChecked(7);
            npcProperties[(int)npcNum.Value].B2b2 = unknownBits.GetItemChecked(8);
            npcProperties[(int)npcNum.Value].B2b3 = unknownBits.GetItemChecked(9);
            npcProperties[(int)npcNum.Value].B2b4 = unknownBits.GetItemChecked(10);
            npcProperties[(int)npcNum.Value].B3b7 = unknownBits.GetItemChecked(11);
            npcProperties[(int)npcNum.Value].B5b5 = unknownBits.GetItemChecked(12);
            npcProperties[(int)npcNum.Value].B5b6 = unknownBits.GetItemChecked(13);
            npcProperties[(int)npcNum.Value].B5b7 = unknownBits.GetItemChecked(14);
            npcProperties[(int)npcNum.Value].B6b2 = unknownBits.GetItemChecked(15);

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