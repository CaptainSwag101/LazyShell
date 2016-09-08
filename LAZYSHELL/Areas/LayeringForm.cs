using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LazyShell.Areas
{
    public partial class LayeringForm : Controls.DockForm
    {
        #region Variables

        private OwnerForm ownerForm;
        private Area area
        {
            get { return ownerForm.Area; }
            set { ownerForm.Area = value; }
        }
        private Layering layering
        {
            get { return area.Layering; }
            set { area.Layering = value; }
        }
        private PictureBox picture
        {
            get { return ownerForm.Picture; }
        }
        //
        public NumericUpDown MaskHighX
        {
            get { return maskHighX; }
            set { maskHighX = value; }
        }
        public NumericUpDown MaskHighY
        {
            get { return maskHighY; }
            set { maskHighY = value; }
        }
        public NumericUpDown MaskLowX
        {
            get { return maskLowX; }
            set { maskLowX = value; }
        }
        public NumericUpDown MaskLowY
        {
            get { return maskLowY; }
            set { maskLowY = value; }
        }

        #endregion

        #region Methods

        public LayeringForm(OwnerForm ownerForm)
        {
            this.ownerForm = ownerForm;
            InitializeComponent();
        }
        //
        public void LoadProperties()
        {
            this.Updating = true;
            //
            this.maskHighX.Value = layering.MaskHighX;
            this.maskHighY.Value = layering.MaskHighY;
            this.maskLowX.Value = layering.MaskLowX;
            this.maskLowY.Value = layering.MaskLowY;
            this.yNegL2.Value = layering.YNegL2;
            this.xNegL2.Value = layering.XNegL2;
            this.yNegL3.Value = layering.YNegL3;
            this.xNegL3.Value = layering.XNegL3;
            this.infiniteScrolling.Checked = layering.InfiniteScrolling;
            this.maskLock.Checked = layering.MaskLock;
            this.scrollWrap.SetItemChecked(0, layering.ScrollWrapL1_HZ);
            this.scrollWrap.SetItemChecked(1, layering.ScrollWrapL1_VT);
            this.scrollWrap.SetItemChecked(2, layering.ScrollWrapL2_HZ);
            this.scrollWrap.SetItemChecked(3, layering.ScrollWrapL2_VT);
            this.scrollWrap.SetItemChecked(4, layering.ScrollWrapL3_HZ);
            this.scrollWrap.SetItemChecked(5, layering.ScrollWrapL3_VT);
            this.scrollWrap.SetItemChecked(6, layering.CulexA);
            this.scrollWrap.SetItemChecked(7, layering.CulexB);
            this.syncL2_HZ.SelectedIndex = layering.SyncL2_HZ;
            this.syncL3_HZ.SelectedIndex = layering.SyncL3_HZ;
            this.syncL2_VT.SelectedIndex = layering.SyncL2_VT;
            this.syncL3_VT.SelectedIndex = layering.SyncL3_VT;
            this.scrollDirectionL2.SelectedIndex = layering.ScrollDirectionL2;
            this.scrollDirectionL3.SelectedIndex = layering.ScrollDirectionL3;
            this.scrollSpeedL2.SelectedIndex = layering.ScrollSpeedL2;
            this.scrollSpeedL3.SelectedIndex = layering.ScrollSpeedL3;
            this.scrollL2Bit7.Checked = layering.ScrollL2Bit7;
            this.scrollL3Bit7.Checked = layering.ScrollL3Bit7;
            this.effectsL3.SelectedIndex = layering.EffectsL3;
            this.effectsNPC.SelectedIndex = layering.EffectsNPC;
            this.ripplingWater.Checked = layering.RipplingWater;
            //
            this.Updating = false;
        }

        #endregion

        #region Event Handlers

        // Mask
        private void maskHighX_ValueChanged(object sender, EventArgs e)
        {
            layering.MaskHighX = (byte)maskHighX.Value;
            if (!this.Updating)
                picture.Invalidate();
        }
        private void maskLowX_ValueChanged(object sender, EventArgs e)
        {
            layering.MaskLowX = (byte)maskLowX.Value;
            if (!this.Updating)
                picture.Invalidate();
        }
        private void maskHighY_ValueChanged(object sender, EventArgs e)
        {
            layering.MaskHighY = (byte)maskHighY.Value;
            if (!this.Updating)
                picture.Invalidate();
        }
        private void maskLowY_ValueChanged(object sender, EventArgs e)
        {
            layering.MaskLowY = (byte)maskLowY.Value;
            if (!this.Updating)
                picture.Invalidate();
        }
        private void maskLock_CheckedChanged(object sender, EventArgs e)
        {
            maskLock.ForeColor = maskLock.Checked ? Color.Black : Color.Gray;
            layering.MaskLock = maskLock.Checked;
        }
        // Layer shifting
        private void xNegL2_ValueChanged(object sender, EventArgs e)
        {
            layering.XNegL2 = (byte)xNegL2.Value;
        }
        private void xNegL3_ValueChanged(object sender, EventArgs e)
        {
            layering.XNegL3 = (byte)xNegL3.Value;
        }
        private void yNegL2_ValueChanged(object sender, EventArgs e)
        {
            layering.YNegL2 = (byte)yNegL2.Value;
        }
        private void yNegL3_ValueChanged(object sender, EventArgs e)
        {
            layering.YNegL3 = (byte)yNegL3.Value;
        }
        // Synchronization
        private void syncL2_VT_SelectedIndexChanged(object sender, EventArgs e)
        {
            layering.SyncL2_VT = (byte)syncL2_VT.SelectedIndex;
        }
        private void syncL3_VT_SelectedIndexChanged(object sender, EventArgs e)
        {
            layering.SyncL3_VT = (byte)syncL3_VT.SelectedIndex;
        }
        private void syncL2_HZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            layering.SyncL2_HZ = (byte)syncL2_HZ.SelectedIndex;
        }
        private void syncL3_HZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            layering.SyncL3_HZ = (byte)syncL3_HZ.SelectedIndex;
        }
        // Scrolling
        private void scrollWrap_SelectedIndexChanged(object sender, EventArgs e)
        {
            layering.ScrollWrapL1_HZ = scrollWrap.GetItemChecked(0);
            layering.ScrollWrapL1_VT = scrollWrap.GetItemChecked(1);
            layering.ScrollWrapL2_HZ = scrollWrap.GetItemChecked(2);
            layering.ScrollWrapL2_VT = scrollWrap.GetItemChecked(3);
            layering.ScrollWrapL3_HZ = scrollWrap.GetItemChecked(4);
            layering.ScrollWrapL3_VT = scrollWrap.GetItemChecked(5);
            layering.CulexA = scrollWrap.GetItemChecked(6);
            layering.CulexB = scrollWrap.GetItemChecked(7);
        }
        private void scrollL2Bit7_CheckedChanged(object sender, EventArgs e)
        {
            scrollL2Bit7.ForeColor = scrollL2Bit7.Checked ? Color.Black : Color.Gray;
            layering.ScrollL2Bit7 = scrollL2Bit7.Checked;
        }
        private void scrollL3Bit7_CheckedChanged(object sender, EventArgs e)
        {
            scrollL3Bit7.ForeColor = scrollL3Bit7.Checked ? Color.Black : Color.Gray;
            layering.ScrollL3Bit7 = scrollL3Bit7.Checked;
        }
        private void scrollDirectionL2_SelectedIndexChanged(object sender, EventArgs e)
        {
            layering.ScrollDirectionL2 = (byte)scrollDirectionL2.SelectedIndex;
        }
        private void scrollSpeedL2_SelectedIndexChanged(object sender, EventArgs e)
        {
            layering.ScrollSpeedL2 = (byte)scrollSpeedL2.SelectedIndex;
        }
        private void scrollDirectionL3_SelectedIndexChanged(object sender, EventArgs e)
        {
            layering.ScrollDirectionL3 = (byte)scrollDirectionL3.SelectedIndex;
        }
        private void scrollSpeedL3_SelectedIndexChanged(object sender, EventArgs e)
        {
            layering.ScrollSpeedL3 = (byte)scrollSpeedL3.SelectedIndex;
        }
        private void infiniteScrolling_CheckedChanged(object sender, EventArgs e)
        {
            infiniteScrolling.ForeColor = infiniteScrolling.Checked ? Color.Black : Color.Gray;
            layering.InfiniteScrolling = infiniteScrolling.Checked;
        }
        // Effects
        private void effectsL3_SelectedIndexChanged(object sender, EventArgs e)
        {
            layering.EffectsL3 = (byte)effectsL3.SelectedIndex;
        }
        private void effectsNPC_SelectedIndexChanged(object sender, EventArgs e)
        {
            layering.EffectsNPC = (byte)effectsNPC.SelectedIndex;
        }
        private void ripplingWater_CheckedChanged(object sender, EventArgs e)
        {
            ripplingWater.ForeColor = ripplingWater.Checked ? Color.Black : Color.Gray;
            layering.RipplingWater = ripplingWater.Checked;
        }

        #endregion
    }
}
