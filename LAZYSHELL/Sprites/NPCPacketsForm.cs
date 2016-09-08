using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LazyShell.Sprites
{
    public partial class NPCPacketsForm : Controls.NewForm
    {
        #region Variables

        // Index
        private int index
        {
            get { return (int)num.Value; }
            set { num.Value = value; }
        }

        // Elements
        private NPCPacket[] npcPackets
        {
            get { return Model.NPCPackets; }
            set { Model.NPCPackets = value; }
        }
        private NPCPacket npcPacket
        {
            get { return npcPackets[index]; }
            set { npcPackets[index] = value; }
        }
        private Bitmap spriteImage;
        private Sprite sprite
        {
            get { return Model.Sprites[(int)spriteNum.Value]; }
        }

        #endregion

        // Constructor
        public NPCPacketsForm()
        {
            InitializeComponent();
            InitializeListControls();
            LoadProperties();
        }

        #region Methods

        private void InitializeListControls()
        {
            this.Updating = true;
            //
            this.name.Items.AddRange(Lists.Numerize(Lists.NPCPackets));
            this.name.SelectedIndex = 0;
            this.spriteName.Items.AddRange(Lists.Numerize(192, 256, Lists.Sprites));
            //
            this.Updating = false;
        }
        private void LoadProperties()
        {
            this.Updating = true;
            //
            this.spriteName.SelectedIndex = npcPacket.Sprite;
            this.action.Value = npcPacket.Action;
            this.byte0.Value = npcPacket.B0;
            this.byte1a.Value = npcPacket.B1a;
            this.byte1b.Value = npcPacket.B1b;
            this.byte1c.Value = npcPacket.B1c;
            this.byte4.Value = npcPacket.B4;
            this.unknownBits.SetItemChecked(0, npcPacket.B2b2);
            this.unknownBits.SetItemChecked(1, npcPacket.B2b3);
            this.unknownBits.SetItemChecked(2, npcPacket.B2b4);
            this.showShadow.Checked = npcPacket.ShowShadow;
            this.byte2.Value = npcPacket.B2;
            //
            SetSpriteImage();
            //
            this.Updating = false;
        }
        private void SetSpriteImage()
        {
            Size size = new Size(0, 0);
            int[] spritePixels = sprite.GetPixels(false, true, 0, 3, false, true, ref size);
            if (spritePixels.Length == 0)
            {
                spritePixels = new int[2];
                size.Width = 1;
                size.Height = 1;
            }
            spriteImage = Do.PixelsToImage(spritePixels, size.Width, size.Height);
            spritePictureBox.Invalidate();
        }

        #endregion

        #region Event Handlers

        // Navigators
        private void name_SelectedIndexChanged(object sender, EventArgs e)
        {
            num.Value = name.SelectedIndex;
        }
        private void num_ValueChanged(object sender, EventArgs e)
        {
            name.SelectedIndex = (int)num.Value;
            if (!this.Updating)
                LoadProperties();
        }

        // Data management
        private void save_Click(object sender, EventArgs e)
        {
            foreach (var npcPacket in npcPackets)
                npcPacket.WriteToROM();
        }
        private void reset_Click(object sender, EventArgs e)
        {
            this.npcPacket = new NPCPacket(index);
            LoadProperties();
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Picture
        private void spritePictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (spriteImage != null)
                e.Graphics.DrawImage(spriteImage, 128 - (spriteImage.Width / 2), 128 - (spriteImage.Height / 2));
        }

        // Sprite
        private void spriteName_SelectedIndexChanged(object sender, EventArgs e)
        {
            spriteNum.Value = spriteName.SelectedIndex + 192;
            if (!this.Updating)
                SetSpriteImage();
        }
        private void spriteNum_ValueChanged(object sender, EventArgs e)
        {
            spriteName.SelectedIndex = (int)spriteNum.Value - 192;
            npcPacket.Sprite = (byte)spriteNum.Value;
        }
        private void editSprite_Click(object sender, EventArgs e)
        {
            if (LazyShell.Model.Program.Sprites == null || !LazyShell.Model.Program.Sprites.Visible)
                LazyShell.Model.Program.CreateSpritesWindow();
            //
            LazyShell.Model.Program.Sprites.Index = (int)spriteNum.Value;
            LazyShell.Model.Program.Sprites.BringToFront();
        }

        // Action
        private void action_ValueChanged(object sender, EventArgs e)
        {
            npcPacket.Action = (ushort)action.Value;
        }
        private void actionButton_Click(object sender, EventArgs e)
        {
            if (LazyShell.Model.Program.EventScripts == null || !LazyShell.Model.Program.EventScripts.Visible)
                LazyShell.Model.Program.CreateEventScriptsWindow();
            //
            LazyShell.Model.Program.EventScripts.Type = 1;
            LazyShell.Model.Program.EventScripts.Index = (int)action.Value;
            LazyShell.Model.Program.EventScripts.BringToFront();
        }

        // Unknown
        private void byte0_ValueChanged(object sender, EventArgs e)
        {
            npcPacket.B0 = (byte)byte0.Value;
        }
        private void byte1a_ValueChanged(object sender, EventArgs e)
        {
            npcPacket.B1a = (byte)byte1a.Value;
        }
        private void byte1b_ValueChanged(object sender, EventArgs e)
        {
            npcPacket.B1b = (byte)byte1b.Value;
        }
        private void byte1c_ValueChanged(object sender, EventArgs e)
        {
            npcPacket.B1c = (byte)byte1c.Value;
        }
        private void byte4_ValueChanged(object sender, EventArgs e)
        {
            npcPacket.B4 = (byte)byte4.Value;
        }
        private void unknownBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            npcPacket.B2b2 = unknownBits.GetItemChecked(0);
            npcPacket.B2b3 = unknownBits.GetItemChecked(1);
            npcPacket.B2b4 = unknownBits.GetItemChecked(2);
            npcPacket.ShowShadow = unknownBits.GetItemChecked(3);
        }
        private void showShadow_CheckedChanged(object sender, EventArgs e)
        {
            showShadow.ForeColor = showShadow.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            npcPacket.ShowShadow = showShadow.Checked;
        }
        private void byte2_ValueChanged(object sender, EventArgs e)
        {
            npcPacket.B2 = (byte)byte2.Value;
        }

        #endregion
    }
}
