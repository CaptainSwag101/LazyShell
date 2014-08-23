using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Areas;
using LAZYSHELL.Properties;
using LAZYSHELL.Sprites;

namespace LAZYSHELL.Areas
{
    public partial class NPCEditor : Controls.NewForm
    {
        #region Variables

        public int Index
        {
            get { return (int)npcNum.Value; }
            set { npcNum.Value = value; }
        }
        private NPCProperties npcProperty_old;
        private Settings settings = Settings.Default;
        private NPCProperties[] npcProperties
        {
            get { return Model.NPCProperties; }
            set { Model.NPCProperties = value; }
        }
        private NPCProperties npcProperty
        {
            get { return npcProperties[Index]; }
            set { npcProperties[Index] = value; }
        }
        private Bitmap spriteImage;
        private Sprite sprite
        {
            get { return Sprites.Model.Sprites[(int)spriteName.SelectedIndex]; }
        }
        private int[] spritePixels;
        private OwnerForm ownerForm;

        // Searching
        private SearchNPCForm searchNPCForm;
        private FindReferences findReferencesForm;
        private delegate void FindReferencesFunction(TreeView treeView);

        #endregion

        // Constructor
        public NPCEditor(OwnerForm ownerForm)
        {
            this.ownerForm = ownerForm;
            InitializeComponent();
            InitializeListControls();
            InitializeForms();
            LoadProperties();
            //
            this.History = new History(this, null, npcNum);
        }

        #region Methods

        private void InitializeListControls()
        {
            spriteName.Items.AddRange(Lists.Numerize(Lists.Sprites));
        }
        private void InitializeForms()
        {
            searchNPCForm = new SearchNPCForm(this);
            searchNPCForm.Location = Do.GetControlLocation(search);
            searchNPCForm.ToggleButton = search;
        }
        //
        public void LoadProperties()
        {
            this.Updating = true;
            //
            this.spriteName.SelectedIndex = npcProperty.Sprite;
            this.layerPriority.SetItemChecked(0, npcProperty.Priority0);
            this.layerPriority.SetItemChecked(1, npcProperty.Priority1);
            this.layerPriority.SetItemChecked(2, npcProperty.Priority2);
            this.yPixelShift.Value = npcProperty.YPixelShiftUp + (npcProperty.Shift16pxDown ? -16 : 0);
            this.axisAcute.Value = npcProperty.AcuteAxis;
            this.axisObtuse.Value = npcProperty.ObtuseAxis;
            this.height.Value = npcProperty.Height;
            this.showShadow.Checked = npcProperty.ShowShadow;
            this.shadow.SelectedIndex = npcProperty.Shadow;
            this.cannotClone.Checked = npcProperty.ActiveVRAM;
            this.vramStore.SelectedIndex = npcProperty.Byte1a;
            this.vramSize.Value = npcProperty.Byte1b;
            this.unknownBits.SetItemChecked(0, npcProperty.B2b0);
            this.unknownBits.SetItemChecked(1, npcProperty.B2b1);
            this.unknownBits.SetItemChecked(2, npcProperty.B2b2);
            this.unknownBits.SetItemChecked(3, npcProperty.B2b3);
            this.unknownBits.SetItemChecked(4, npcProperty.B2b4);
            this.unknownBits.SetItemChecked(5, npcProperty.B5b6);
            this.unknownBits.SetItemChecked(6, npcProperty.B5b7);
            this.unknownBits.SetItemChecked(7, npcProperty.B6b2);
            //
            SetSpriteImage();
            //
            this.Updating = false;
        }
        //
        private void SetSpriteImage()
        {
            var size = new Size(0, 0);
            spritePixels = sprite.GetPixels(false, true, 0, 3, false, true, ref size);
            if (spritePixels.Length == 0)
            {
                spritePixels = new int[2];
                size.Width = 1;
                size.Height = 1;
            }
            spriteImage = Do.PixelsToImage(spritePixels, size.Width, size.Height);
            spritePictureBox.Invalidate();
        }
        private void FindReferences(TreeView treeView)
        {
            // look through areas
            var areaEventResults = new TreeNode();
            var areaNPCResults = new TreeNode();
            foreach (var area in Areas.Model.Areas)
            {
                foreach (var npc in area.NPCObjects)
                {
                    if (npc.NPCID == this.Index)
                    {
                        var result = new TreeNode(Lists.Numerize(Lists.Areas, area.Index));
                        result.Tag = area;
                        areaNPCResults.Nodes.Add(result);
                    }
                }
            }
            if (areaNPCResults.Nodes.Count > 0)
            {
                areaNPCResults.Text = "AREAS — found " + areaNPCResults.Nodes.Count + " results";
                treeView.Nodes.Add(areaNPCResults);
            }
        }

        #endregion

        #region Event handlers

        // Navigator
        private void npcNum_ValueChanged(object sender, EventArgs e)
        {
            npcProperty_old = npcProperty.Copy();
            LoadProperties();
        }
        private void findReferences_Click(object sender, EventArgs e)
        {
            if (findReferencesForm == null)
            {
                findReferencesForm = new FindReferences(new FindReferencesFunction(FindReferences), null);
                findReferencesForm.Owner = this;
            }
            else
                findReferencesForm.Reload();
            findReferencesForm.Show();
        }

        // Sprite
        private void spritePictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (spriteImage != null)
                e.Graphics.DrawImage(spriteImage, 128 - (spriteImage.Width / 2), 128 - (spriteImage.Height / 2));
        }
        private void spriteNum_ValueChanged(object sender, EventArgs e)
        {
            spriteName.SelectedIndex = (int)spriteNum.Value;
        }
        private void spriteName_SelectedIndexChanged(object sender, EventArgs e)
        {
            spriteNum.Value = spriteName.SelectedIndex;
            if (this.Updating)
                return;
            SetSpriteImage();
        }
        private void editSprite_Click(object sender, EventArgs e)
        {
            if (LAZYSHELL.Model.Program.Sprites == null || !LAZYSHELL.Model.Program.Sprites.Visible)
                LAZYSHELL.Model.Program.CreateSpritesWindow();
            LAZYSHELL.Model.Program.Sprites.Index = (int)spriteNum.Value;
            LAZYSHELL.Model.Program.Sprites.BringToFront();
        }

        // Properties
        private void layerPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
        }
        private void showShadow_CheckedChanged(object sender, EventArgs e)
        {
            showShadow.ForeColor = showShadow.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
        }
        private void yPixelShift_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
        }
        private void axisAcute_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
        }
        private void axisObtuse_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
        }
        private void height_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
        }
        private void shadow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
        }
        private void cannotClone_CheckedChanged(object sender, EventArgs e)
        {
            cannotClone.ForeColor = cannotClone.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
        }
        private void unknownBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
        }

        // Buttons
        private void buttonReset_Click(object sender, EventArgs e)
        {
            npcProperty = npcProperty_old.Copy();
            LoadProperties();
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
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
            npcProperty.ShowShadow = showShadow.Checked;
            npcProperty.Shadow = (byte)shadow.SelectedIndex;
            npcProperty.ActiveVRAM = cannotClone.Checked;
            npcProperty.Byte1a = (byte)vramStore.SelectedIndex;
            npcProperty.Byte1b = (byte)vramSize.Value;
            npcProperty.B2b0 = unknownBits.GetItemChecked(0);
            npcProperty.B2b1 = unknownBits.GetItemChecked(1);
            npcProperty.B2b2 = unknownBits.GetItemChecked(2);
            npcProperty.B2b3 = unknownBits.GetItemChecked(3);
            npcProperty.B2b4 = unknownBits.GetItemChecked(4);
            npcProperty.B5b6 = unknownBits.GetItemChecked(5);
            npcProperty.B5b7 = unknownBits.GetItemChecked(6);
            npcProperty.B6b2 = unknownBits.GetItemChecked(7);
            ownerForm.Overlay.NPCImages = null;
            ownerForm.Picture.Invalidate();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}