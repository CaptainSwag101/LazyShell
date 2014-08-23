using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL.Areas
{
    public partial class SpritePartitionsForm : Controls.NewForm
    {
        #region Variables

        private OwnerForm ownerForm;
        public int Index
        {
            get { return (int)partitionNum.Value; }
            set { partitionNum.Value = value; }
        }
        //
        private SpritePartitioning[] partitions;
        private SpritePartitioning partition
        {
            get { return partitions[Index]; }
            set { partitions[Index] = value; }
        }

        #endregion

        // Constructor
        public SpritePartitionsForm(OwnerForm ownerForm, SpritePartitioning[] partitions, int index)
        {
            this.ownerForm = ownerForm;
            this.partitions = partitions;
            this.Index = index;
            //
            InitializeComponent();
            //
            LoadProperties();
            //
            this.History = new History(this);
        }

        #region Methods

        private void LoadProperties()
        {
            this.Updating = true;
            //
            extraSpriteBuffer.Value = partition.ExtraSpriteBuffer;
            allyCount.Value = partition.AllySpriteBuffer;
            extraSprites.Checked = partition.ExtraSprites;
            noWaterPalettes.Checked = partition.FullPaletteBuffer;
            byte2a.SelectedIndex = partition.CloneASprite;
            byte2b.SelectedIndex = partition.CloneAMain;
            byte2.Checked = partition.CloneAIndexing;
            byte3a.SelectedIndex = partition.CloneBSprite;
            byte3b.SelectedIndex = partition.CloneBMain;
            byte3.Checked = partition.CloneBIndexing;
            byte4a.SelectedIndex = partition.CloneCSprite;
            byte4b.SelectedIndex = partition.CloneCMain;
            byte4.Checked = partition.CloneCIndexing;
            //
            SetPreviewImage();
            //
            this.Updating = false;
        }
        //
        private void SetPreviewImage()
        {

        }
        private void SetPreviewImage(int[] dst, ref int x, ref int y, int spriteIndex, int moldIndex, bool dynamic)
        {
            var sprite = Sprites.Model.Sprites[spriteIndex];
            var animation = Sprites.Model.Animations[sprite.AnimationPacket];
            var image = Sprites.Model.ImagePackets[sprite.ImageNum];
            byte[] graphics = image.Graphics(Sprites.Model.Graphics);
            int[] palette = Sprites.Model.PaletteSets[image.PaletteNum + sprite.PaletteIndex].Palette;
            //
            for (int i = 0; i < animation.Molds.Count; i++)
            {
                if (dynamic && i > 0)
                    break;
                Sprites.Mold mold;
                if (dynamic)
                    mold = animation.Molds[moldIndex];
                else
                    mold = animation.Molds[i];
                int counter = 3;
                foreach (var tile in mold.Tiles)
                {
                    tile.DrawSubtiles(graphics, palette, mold.Gridplane);
                    Rectangle srcRegion;
                    Rectangle dstRegion;
                    int[] src = mold.Gridplane ? tile.GetGridplanePixels() : tile.Get16x16TilePixels();
                    if (dynamic)
                    {
                        if (x + tile.Width > 128)
                        {
                            x = 0;
                            y += 16;
                        }
                        srcRegion = new Rectangle(0, 0, tile.Width, 16);
                        dstRegion = new Rectangle(x, y, tile.Width, 16);
                        Do.PixelsToPixels(src, dst, mold.Gridplane ? 32 : 16, 128, srcRegion, dstRegion);
                        if (mold.Gridplane) // Draw bottom half of sprite
                        {
                            srcRegion.Y += 16;
                            dstRegion.X += tile.Width;
                            Do.PixelsToPixels(src, dst, 32, 128, srcRegion, dstRegion);
                            x += 64;
                        }
                        else
                            x += tile.Width;
                    }
                    else
                    {
                        if (x + tile.Width > 128)
                        {
                            x = 32;
                            y += 32;
                        }
                        if (mold.Gridplane)
                        {
                            srcRegion = new Rectangle(0, 0, tile.Width, 32);
                            dstRegion = new Rectangle(x, y, tile.Width, 32);
                            Do.PixelsToPixels(src, dst, 32, 128, srcRegion, dstRegion);
                            x += tile.Width;
                        }
                        else
                        {
                            srcRegion = new Rectangle(0, 0, tile.Width, 16);
                            if (counter == 3)
                                dstRegion = new Rectangle(x + 16, y + 16, 16, 16);
                            else if (counter == 2)
                                dstRegion = new Rectangle(x, y + 16, 16, 16);
                            else if (counter == 1)
                                dstRegion = new Rectangle(x + 16, y, 16, 16);
                            else
                                dstRegion = new Rectangle(x, y, 16, 16);
                            Do.PixelsToPixels(src, dst, 16, 128, srcRegion, dstRegion);
                            counter--;
                            if (counter < 0)
                                x += 32;
                        }
                    }
                }
            }
        }
        //
        private void FindIdentical(SpritePartitioning partition, StreamWriter total)
        {
            foreach (var p in partitions)
            {
                if (p.Index <= partition.Index)
                    continue;
                if (p.AllySpriteBuffer == partition.AllySpriteBuffer &&
                    p.B1b0 == partition.B1b0 &&
                    p.B1b1 == partition.B1b1 &&
                    p.B1b2 == partition.B1b2 &&
                    p.B1b3 == partition.B1b3 &&
                    p.CloneASprite == partition.CloneASprite &&
                    p.CloneAMain == partition.CloneAMain &&
                    p.CloneAIndexing == partition.CloneAIndexing &&
                    p.CloneBSprite == partition.CloneBSprite &&
                    p.CloneBMain == partition.CloneBMain &&
                    p.CloneBIndexing == partition.CloneBIndexing &&
                    p.CloneCSprite == partition.CloneCSprite &&
                    p.CloneCMain == partition.CloneCMain &&
                    p.CloneCIndexing == partition.CloneCIndexing &&
                    p.ExtraSprites != partition.ExtraSprites &&
                    p.Index != partition.Index &&
                    p.FullPaletteBuffer == partition.FullPaletteBuffer &&
                    p.ExtraSpriteBuffer == partition.ExtraSpriteBuffer)
                {
                    total.WriteLine(partition.Index + " (" + partition.ExtraSprites + ") and " + p.Index + " (" + p.ExtraSprites + ")");
                }
            }
        }

        #endregion

        #region Event Handlers

        private void partitionNum_ValueChanged(object sender, EventArgs e)
        {
            LoadProperties();
        }
        //
        private void extraSpriteBuffer_ValueChanged(object sender, EventArgs e)
        {
            partition.ExtraSpriteBuffer = (byte)extraSpriteBuffer.Value;
        }
        private void allyCount_ValueChanged(object sender, EventArgs e)
        {
            partition.AllySpriteBuffer = (byte)allyCount.Value;
            if (!this.Updating)
                SetPreviewImage();
        }
        private void extraSprites_CheckedChanged(object sender, EventArgs e)
        {
            extraSpriteBuffer.Enabled = extraSprites.Checked;
            partition.ExtraSprites = extraSprites.Checked;
            if (!this.Updating)
                SetPreviewImage();
        }
        private void noWaterPalettes_CheckedChanged(object sender, EventArgs e)
        {
            partition.FullPaletteBuffer = noWaterPalettes.Checked;
        }
        private void byte2a_SelectedIndexChanged(object sender, EventArgs e)
        {
            partition.CloneASprite = (byte)byte2a.SelectedIndex;
            if (!this.Updating)
                SetPreviewImage();
        }
        private void byte2b_SelectedIndexChanged(object sender, EventArgs e)
        {
            partition.CloneAMain = (byte)byte2b.SelectedIndex;
            if (!this.Updating)
                SetPreviewImage();
        }
        private void byte2_CheckedChanged(object sender, EventArgs e)
        {
            partition.CloneAIndexing = byte2.Checked;
            if (!this.Updating)
                SetPreviewImage();
        }
        private void byte3a_SelectedIndexChanged(object sender, EventArgs e)
        {
            partition.CloneBSprite = (byte)byte3a.SelectedIndex;
            if (!this.Updating)
                SetPreviewImage();
        }
        private void byte3b_SelectedIndexChanged(object sender, EventArgs e)
        {
            partition.CloneBMain = (byte)byte3b.SelectedIndex;
            if (!this.Updating)
                SetPreviewImage();
        }
        private void byte3_CheckedChanged(object sender, EventArgs e)
        {
            partition.CloneBIndexing = byte3.Checked;
            if (!this.Updating)
                SetPreviewImage();
        }
        private void byte4a_SelectedIndexChanged(object sender, EventArgs e)
        {
            partition.CloneCSprite = (byte)byte4a.SelectedIndex;
            if (!this.Updating)
                SetPreviewImage();
        }
        private void byte4b_SelectedIndexChanged(object sender, EventArgs e)
        {
            partition.CloneCMain = (byte)byte4b.SelectedIndex;
            if (!this.Updating)
                SetPreviewImage();
        }
        private void byte4_CheckedChanged(object sender, EventArgs e)
        {
            partition.CloneCIndexing = byte4.Checked;
            if (!this.Updating)
                SetPreviewImage();
        }
        //
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }
        // Buttons
        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}