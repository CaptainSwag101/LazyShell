using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL.Sprites
{
    public partial class PropertiesForm : Controls.DockForm
    {
        #region Variables

        // Forms
        private OwnerForm ownerForm;
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
        private Sprite sprite
        {
            get { return ownerForm.Sprite; }
            set { ownerForm.Sprite = value; }
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
        private ImagePacket image
        {
            get { return ownerForm.Image; }
            set { ownerForm.Image = value; }
        }
        private byte[] graphics
        {
            get { return ownerForm.Graphics; }
            set { ownerForm.Graphics = value; }
        }
        private byte[] spriteGraphics
        {
            get { return Model.Graphics; }
        }
        private PaletteSet paletteSet
        {
            get { return ownerForm.PaletteSet; }
            set { ownerForm.PaletteSet = value; }
        }
        public int AvailableBytes { get; set; }

        // Find references
        private FindReferences findReferencesImageForm;
        private FindReferences findReferencesAnimationForm;
        private delegate void FindReferencesFunction(TreeView treeView);

        #endregion

        // Constructor
        public PropertiesForm(OwnerForm ownerForm)
        {
            this.ownerForm = ownerForm;
            InitializeComponent();
            InitializeProperties();
        }

        #region Methods

        public void InitializeProperties()
        {
            this.Updating = true;
            paletteIndex.Value = sprite.PaletteIndex;
            imageNum.Value = sprite.ImageNum;
            paletteOffset.Value = image.PaletteNum;
            graphicOffset.Value = image.GraphicOffset;
            animationPacket.Value = sprite.AnimationPacket;
            animationVRAM.Value = animation.VramAllocation;
            this.Updating = false;
        }
        public void SetFreeBytesLabel()
        {
            int freeBytes = Model.FreeAnimationBytes(sprite.AnimationPacket);
            animationAvailableBytes.BackColor = freeBytes > 0 ? Color.Lime : Color.Red;
            animationAvailableBytes.Text = freeBytes.ToString() + " bytes free (animations)";
        }
        private void FindReferencesImage(TreeView treeView)
        {
            var results = new TreeNode();
            foreach (var sprite in Model.Sprites)
            {
                if (sprite.ImageNum == this.sprite.ImageNum)
                {
                    var result = new TreeNode(sprite.ToString());
                    result.Tag = sprite;
                    results.Nodes.Add(result);
                }
            }
            if (results.Nodes.Count > 0)
            {
                results.Text = "SPRITES — found " + results.Nodes.Count + " results";
                treeView.Nodes.Add(results);
            }
        }
        private void FindReferencesAnimation(TreeView treeView)
        {
            var results = new TreeNode();
            foreach (var sprite in Model.Sprites)
            {
                if (sprite.AnimationPacket == this.sprite.AnimationPacket)
                {
                    var result = new TreeNode(sprite.ToString());
                    result.Tag = sprite;
                    results.Nodes.Add(result);
                }
            }
            if (results.Nodes.Count > 0)
            {
                results.Text = "SPRITES — found " + results.Nodes.Count + " results";
                treeView.Nodes.Add(results);
            }
        }

        #endregion

        #region Event Handlers

        private void paletteIndex_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            sprite.PaletteIndex = (byte)paletteIndex.Value;
            foreach (var mold in animation.Molds)
            {
                foreach (var tile in mold.Tiles)
                    tile.DrawSubtiles(graphics, paletteSet.Palette, tile.Gridplane);
            }
            moldsForm.SetTilesetImage();
            moldsForm.SetTilemapImage();
            sequencesForm.SetFrameImages();
            ownerForm.LoadPaletteEditor();
            ownerForm.LoadGraphicEditor();
        }
        private void imageNum_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            sprite.ImageNum = (ushort)imageNum.Value;
            paletteOffset.Value = image.PaletteNum;
            graphicOffset.Value = image.GraphicOffset;
            foreach (var mold in animation.Molds)
            {
                foreach (var tile in mold.Tiles)
                    tile.DrawSubtiles(graphics, paletteSet.Palette, tile.Gridplane);
            }
            moldsForm.SetTilesetImage();
            moldsForm.SetTilemapImage();
            sequencesForm.SetFrameImages();
            ownerForm.LoadPaletteEditor();
            ownerForm.LoadGraphicEditor();
        }
        private void paletteOffset_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            image.PaletteNum = (int)paletteOffset.Value;
            foreach (var mold in animation.Molds)
            {
                foreach (var tile in mold.Tiles)
                    tile.DrawSubtiles(graphics, paletteSet.Palette, tile.Gridplane);
            }
            moldsForm.SetTilesetImage();
            moldsForm.SetTilemapImage();
            sequencesForm.SetFrameImages();
            ownerForm.LoadPaletteEditor();
            ownerForm.LoadGraphicEditor();
        }
        private void graphicOffset_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            graphicOffset.Value = (int)graphicOffset.Value & 0xFFFFE0;
            image.GraphicOffset = (int)graphicOffset.Value;
            graphics = image.Graphics(spriteGraphics);
            foreach (var mold in animation.Molds)
            {
                foreach (var tile in mold.Tiles)
                    tile.DrawSubtiles(graphics, paletteSet.Palette, tile.Gridplane);
            }
            moldsForm.SetTilesetImage();
            moldsForm.SetTilemapImage();
            sequencesForm.SetFrameImages();
            ownerForm.LoadGraphicEditor();
        }
        private void animationPacket_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            sprite.AnimationPacket = (ushort)animationPacket.Value;
            animationVRAM.Value = animation.VramAllocation;
            moldsForm.Reload();
            sequencesForm.Reload();
            ownerForm.SetFreeBytesLabel();
        }
        private void animationVRAM_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            animation.VramAllocation = (ushort)animationVRAM.Value;
            moldsForm.SetFreeVRAMLabel();
        }

        // Find references
        private void findReferencesImage_Click(object sender, EventArgs e)
        {
            if (findReferencesImageForm == null)
            {
                findReferencesImageForm = new FindReferences(new FindReferencesFunction(FindReferencesImage), null);
                findReferencesImageForm.Owner = this;
            }
            else
                findReferencesImageForm.Reload();
            findReferencesImageForm.Show();
        }
        private void findReferencesAnimation_Click(object sender, EventArgs e)
        {
            if (findReferencesAnimationForm == null)
            {
                findReferencesAnimationForm = new FindReferences(new FindReferencesFunction(FindReferencesAnimation), null);
                findReferencesAnimationForm.Owner = this;
            }
            else
                findReferencesAnimationForm.Reload();
            findReferencesAnimationForm.Show();
        }

        #endregion
    }
}
