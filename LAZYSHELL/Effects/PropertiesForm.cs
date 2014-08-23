using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL.Effects
{
    public partial class PropertiesForm : Controls.DockForm
    {
        #region Variables

        private OwnerForm ownerForm;
        private Effect effect
        {
            get { return ownerForm.Effect; }
            set { ownerForm.Effect = value; }
        }
        private Animation[] animations
        {
            get { return Model.Animations; }
            set { Model.Animations = value; }
        }
        private Animation animation
        {
            get { return ownerForm.Animation; }
            set { ownerForm.Animation = value; }
        }
        private MoldsForm moldsForm
        {
            get { return ownerForm.MoldsForm; }
            set { ownerForm.MoldsForm = value; }
        }
        private SequencesForm sequencesForm
        {
            get { return ownerForm.SequencesForm; }
            set { ownerForm.SequencesForm = value; }
        }
        public NumericUpDown GraphicSetSize
        {
            get { return graphicSetSize; }
            set { graphicSetSize = value; }
        }
        public int FreeBytes { get; set; }

        #endregion

        // Constructor
        public PropertiesForm(OwnerForm ownerForm)
        {
            this.ownerForm = ownerForm;
            this.Owner = ownerForm;
            InitializeComponent();
            LoadProperties();
        }

        #region Methods

        public void LoadProperties()
        {
            this.Updating = true;

            // Main properties
            imageNum.Value = effect.ImageNum;
            e_paletteIndex.Value = effect.PaletteIndex;
            xNegShift.Value = effect.X;
            yNegShift.Value = effect.Y;

            // Finished
            this.Updating = false;

            LoadImageProperties();
            SetFreeBytesLabel();
        }
        private void LoadImageProperties()
        {
            this.Updating = true;

            // Image properties
            e_paletteSetSize.Value = animation.PaletteSetLength;
            graphicSetSize.Minimum = animation.Codec == 1 ? 16 : 32;
            graphicSetSize.Value = animation.GraphicSetLength;
            e_codec.SelectedIndex = animation.Codec;

            // Create tileset
            animation.Tileset_tiles = new Tileset(animation, effect.PaletteIndex);

            // Finished
            this.Updating = false;
        }
        public void SetFreeBytesLabel()
        {
            int freeBytes = Model.FreeAnimationBytes(animation.Index);
            e_availableBytes.BackColor = freeBytes > 0 ? Color.Lime : Color.Red;
            e_availableBytes.Text = freeBytes + " bytes free";
        }

        #endregion

        #region Event Handlers

        private void e_paletteIndex_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            effect.PaletteIndex = (byte)e_paletteIndex.Value;
            animation.Tileset_tiles = new Tileset(animation, effect.PaletteIndex);
            moldsForm.SetTilesetImage();
            moldsForm.SetTilemapImage();
            sequencesForm.SetFrameImages();
        }
        private void xNegShift_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            effect.X = (byte)xNegShift.Value;
        }
        private void yNegShift_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            effect.Y = (byte)yNegShift.Value;
        }
        private void imageNum_ValueChanged(object sender, EventArgs e)
        {
            effect.ImageNum = (byte)imageNum.Value;
            if (!this.Updating)
            {
                LoadImageProperties();
                SetFreeBytesLabel();
                ownerForm.LoadMoldEditor();
                ownerForm.LoadSequenceEditor();
            }
        }
        private void e_paletteSetSize_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            animation.PaletteSetLength = (ushort)e_paletteSetSize.Value;
            // update free space
            animation.WriteToBuffer();
            SetFreeBytesLabel();
        }
        private void e_graphicSetSize_ValueChanged(object sender, EventArgs e)
        {
            graphicSetSize.Value = (int)graphicSetSize.Value & (animation.Codec == 1 ? 0xFFFFF0 : 0xFFFFE0);
            if (this.Updating)
                return;
            animation.GraphicSetLength = (int)graphicSetSize.Value;
            // update free space
            animation.WriteToBuffer();
            SetFreeBytesLabel();
            ownerForm.LoadGraphicEditor();
        }
        private void e_codec_SelectedIndexChanged(object sender, EventArgs e)
        {
            graphicSetSize.Minimum = e_codec.SelectedIndex == 1 ? 16 : 32;
            if (this.Updating)
                return;
            animation.Codec = (ushort)e_codec.SelectedIndex;
            animation.Tileset_tiles = new Tileset(animation, effect.PaletteIndex);
            moldsForm.SetTilesetImage();
            moldsForm.SetTilemapImage();
            sequencesForm.SetFrameImages();
            sequencesForm.DrawFrames();
        }

        #endregion
    }
}
