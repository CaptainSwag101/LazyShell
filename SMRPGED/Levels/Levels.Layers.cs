using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SMRPGED
{
    public partial class Levels
    {
        #region Variables

        private LevelLayer layer; // Layer for the current level
        private PrioritySet[] prioritySets;

        #endregion

        #region Methods

        private void InitializeLayerProperties()
        {
            this.layerMessageBox.SelectedIndex = layer.MessageBox;
            this.layerPrioritySet.Value = layer.LayerPrioritySet;
            this.layerMainscreenL1.Checked = prioritySets[layer.LayerPrioritySet].MainscreenL1;
            this.layerMainscreenL2.Checked = prioritySets[layer.LayerPrioritySet].MainscreenL2;
            this.layerMainscreenL3.Checked = prioritySets[layer.LayerPrioritySet].MainscreenL3;
            this.layerMainscreenNPC.Checked = prioritySets[layer.LayerPrioritySet].MainscreenOBJ;
            this.layerSubscreenL1.Checked = prioritySets[layer.LayerPrioritySet].SubscreenL1;
            this.layerSubscreenL2.Checked = prioritySets[layer.LayerPrioritySet].SubscreenL2;
            this.layerSubscreenL3.Checked = prioritySets[layer.LayerPrioritySet].SubscreenL3;
            this.layerSubscreenNPC.Checked = prioritySets[layer.LayerPrioritySet].SubscreenOBJ;
            this.layerColorMathL1.Checked = prioritySets[layer.LayerPrioritySet].ColorMathL1;
            this.layerColorMathL2.Checked = prioritySets[layer.LayerPrioritySet].ColorMathL2;
            this.layerColorMathL3.Checked = prioritySets[layer.LayerPrioritySet].ColorMathL3;
            this.layerColorMathNPC.Checked = prioritySets[layer.LayerPrioritySet].ColorMathOBJ;
            this.layerColorMathBG.Checked = prioritySets[layer.LayerPrioritySet].ColorMathBG;

            this.layerColorMathIntensity.SelectedIndex = prioritySets[layer.LayerPrioritySet].ColorMathHalfIntensity;
            this.layerColorMathMode.SelectedIndex = prioritySets[layer.LayerPrioritySet].ColorMathMinusSubscreen;

            this.layerMaskHighX.Value = layer.MaskHighX;
            this.layerMaskHighY.Value = layer.MaskHighY;
            this.layerMaskLowX.Value = layer.MaskLowX;
            this.layerMaskLowY.Value = layer.MaskLowY;
            this.layerL2UpShift.Value = layer.UpShiftL2;
            this.layerL2LeftShift.Value = layer.LeftShiftL2;
            this.layerL3UpShift.Value = layer.UpShiftL3;
            this.layerL3LeftShift.Value = layer.LeftShiftL3;

            this.layerInfiniteAutoscroll.Checked = layer.InfiniteAutoscroll;
            this.layerLockMask.Checked = layer.MaskLock;

            this.layerScrollWrapping.SetItemChecked(0, layer.HorizontalScrollWrapL1);
            this.layerScrollWrapping.SetItemChecked(1, layer.VerticalScrollWrapL1);
            this.layerScrollWrapping.SetItemChecked(2, layer.HorizontalScrollWrapL2);
            this.layerScrollWrapping.SetItemChecked(3, layer.VerticalScrollWrapL2);
            this.layerScrollWrapping.SetItemChecked(4, layer.HorizontalScrollWrapL3);
            this.layerScrollWrapping.SetItemChecked(5, layer.VerticalScrollWrapL3);
            this.layerScrollWrapping.SetItemChecked(6, layer.CulexA);
            this.layerScrollWrapping.SetItemChecked(7, layer.CulexB);

            this.layerL2HSync.SelectedIndex = layer.HorizontalSyncL2;
            this.layerL3HSync.SelectedIndex = layer.HorizontalSyncL3;
            this.layerL2VSync.SelectedIndex = layer.VerticalSyncL2;
            this.layerL3VSync.SelectedIndex = layer.VerticalSyncL3;

            this.layerL2ScrollDirection.SelectedIndex = layer.ScrollDirectionL2;
            this.layerL3ScrollDirection.SelectedIndex = layer.ScrollDirectionL3;
            this.layerL2ScrollSpeed.SelectedIndex = layer.ScrollSpeedL2;
            this.layerL3ScrollSpeed.SelectedIndex = layer.ScrollSpeedL3;
            this.layerL2ScrollShift.Checked = layer.ScrollL2Bit7;
            this.layerL3ScrollShift.Checked = layer.ScrollL3Bit7;

            this.layerL3Effects.SelectedIndex = layer.AnimationEffectL3;
            this.layerOBJEffects.SelectedIndex = layer.ExtraEffects;

            this.layerWaveEffect.Checked = layer.WaveEffectL3;
        }

        #endregion

        #region Event Handlers

        private void layerMessageBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            layer.MessageBox = (byte)layerMessageBox.SelectedIndex;
        }
        private void layerPrioritySet_ValueChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
                layer.LayerPrioritySet = (byte)layerPrioritySet.Value;

            updatingProperties = true;
            this.layerMainscreenL1.Checked = prioritySets[layer.LayerPrioritySet].MainscreenL1;
            this.layerMainscreenL2.Checked = prioritySets[layer.LayerPrioritySet].MainscreenL2;
            this.layerMainscreenL3.Checked = prioritySets[layer.LayerPrioritySet].MainscreenL3;
            this.layerMainscreenNPC.Checked = prioritySets[layer.LayerPrioritySet].MainscreenOBJ;
            this.layerSubscreenL1.Checked = prioritySets[layer.LayerPrioritySet].SubscreenL1;
            this.layerSubscreenL2.Checked = prioritySets[layer.LayerPrioritySet].SubscreenL2;
            this.layerSubscreenL3.Checked = prioritySets[layer.LayerPrioritySet].SubscreenL3;
            this.layerSubscreenNPC.Checked = prioritySets[layer.LayerPrioritySet].SubscreenOBJ;
            this.layerColorMathL1.Checked = prioritySets[layer.LayerPrioritySet].ColorMathL1;
            this.layerColorMathL2.Checked = prioritySets[layer.LayerPrioritySet].ColorMathL2;
            this.layerColorMathL3.Checked = prioritySets[layer.LayerPrioritySet].ColorMathL3;
            this.layerColorMathNPC.Checked = prioritySets[layer.LayerPrioritySet].ColorMathOBJ;
            this.layerColorMathBG.Checked = prioritySets[layer.LayerPrioritySet].ColorMathBG;
            this.layerColorMathIntensity.SelectedIndex = prioritySets[layer.LayerPrioritySet].ColorMathHalfIntensity;
            this.layerColorMathMode.SelectedIndex = prioritySets[layer.LayerPrioritySet].ColorMathMinusSubscreen;
            updatingProperties = false;

            if (!updatingLevel)
            {
                UpdateLevel();
            }
        }
        private void layerMainscreenL1_CheckedChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
            {
                this.prioritySets[layer.LayerPrioritySet].MainscreenL1 = layerMainscreenL1.Checked;
                if (!updatingLevel)
                    UpdateLevel();
            }
            if (layerMainscreenL1.Checked) layerMainscreenL1.ForeColor = Color.Black;
            else layerMainscreenL1.ForeColor = Color.Gray;
        }
        private void layerMainscreenL2_CheckedChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
            {
                this.prioritySets[layer.LayerPrioritySet].MainscreenL2 = layerMainscreenL2.Checked;
                if (!updatingLevel)
                    UpdateLevel();
            }
            if (layerMainscreenL2.Checked) layerMainscreenL2.ForeColor = Color.Black;
            else layerMainscreenL2.ForeColor = Color.Gray;
        }
        private void layerMainscreenL3_CheckedChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
            {
                this.prioritySets[layer.LayerPrioritySet].MainscreenL3 = layerMainscreenL3.Checked;
                if (!updatingLevel)
                    UpdateLevel();
            }
            if (layerMainscreenL3.Checked) layerMainscreenL3.ForeColor = Color.Black;
            else layerMainscreenL3.ForeColor = Color.Gray;
        }
        private void layerMainscreenNPC_CheckedChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
            {
                this.prioritySets[layer.LayerPrioritySet].MainscreenOBJ = layerMainscreenNPC.Checked;
                if (!updatingLevel)
                    UpdateLevel();
            }
            if (layerMainscreenNPC.Checked) layerMainscreenNPC.ForeColor = Color.Black;
            else layerMainscreenNPC.ForeColor = Color.Gray;
        }
        private void layerSubscreenL1_CheckedChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
            {
                this.prioritySets[layer.LayerPrioritySet].SubscreenL1 = layerSubscreenL1.Checked;
                if (!updatingLevel)
                    UpdateLevel();
            }
            if (layerSubscreenL1.Checked) layerSubscreenL1.ForeColor = Color.Black;
            else layerSubscreenL1.ForeColor = Color.Gray;
        }
        private void layerSubscreenL2_CheckedChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
            {
                this.prioritySets[layer.LayerPrioritySet].SubscreenL2 = layerSubscreenL2.Checked;
                if (!updatingLevel)
                    UpdateLevel();
            }
            if (layerSubscreenL2.Checked) layerSubscreenL2.ForeColor = Color.Black;
            else layerSubscreenL2.ForeColor = Color.Gray;
        }
        private void layerSubscreenL3_CheckedChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
            {
                this.prioritySets[layer.LayerPrioritySet].SubscreenL3 = layerSubscreenL3.Checked;
                if (!updatingLevel)
                    UpdateLevel();
            }
            if (layerSubscreenL3.Checked) layerSubscreenL3.ForeColor = Color.Black;
            else layerSubscreenL3.ForeColor = Color.Gray;
        }
        private void layerSubscreenNPC_CheckedChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
            {
                this.prioritySets[layer.LayerPrioritySet].SubscreenOBJ = layerSubscreenNPC.Checked;
                if (!updatingLevel)
                    UpdateLevel();
            }
            if (layerSubscreenNPC.Checked) layerSubscreenNPC.ForeColor = Color.Black;
            else layerSubscreenNPC.ForeColor = Color.Gray;
        }
        private void layerColorMathL1_CheckedChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
            {
                this.prioritySets[layer.LayerPrioritySet].ColorMathL1 = layerColorMathL1.Checked;
                if (!updatingLevel)
                    UpdateLevel();
            }
            if (layerColorMathL1.Checked) layerColorMathL1.ForeColor = Color.Black;
            else layerColorMathL1.ForeColor = Color.Gray;
        }
        private void layerColorMathL2_CheckedChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
            {
                this.prioritySets[layer.LayerPrioritySet].ColorMathL2 = layerColorMathL2.Checked;
                if (!updatingLevel)
                    UpdateLevel();
            }
            if (layerColorMathL2.Checked) layerColorMathL2.ForeColor = Color.Black;
            else layerColorMathL2.ForeColor = Color.Gray;
        }
        private void layerColorMathL3_CheckedChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
            {
                this.prioritySets[layer.LayerPrioritySet].ColorMathL3 = layerColorMathL3.Checked;
                if (!updatingLevel)
                    UpdateLevel();
            }
            if (layerColorMathL3.Checked) layerColorMathL3.ForeColor = Color.Black;
            else layerColorMathL3.ForeColor = Color.Gray;
        }
        private void layerColorMathNPC_CheckedChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
            {
                this.prioritySets[layer.LayerPrioritySet].ColorMathOBJ = layerColorMathNPC.Checked;
                if (!updatingLevel)
                    UpdateLevel();
            }
            if (layerColorMathNPC.Checked) layerColorMathNPC.ForeColor = Color.Black;
            else layerColorMathNPC.ForeColor = Color.Gray;
        }
        private void layerColorMathBG_CheckedChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
            {
                this.prioritySets[layer.LayerPrioritySet].ColorMathBG = layerColorMathBG.Checked;
                if (!updatingLevel)
                    UpdateLevel();
            }
            if (layerColorMathBG.Checked) layerColorMathBG.ForeColor = Color.Black;
            else layerColorMathBG.ForeColor = Color.Gray;
        }
        private void layerColorMathIntensity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
            {
                if (layerColorMathIntensity.SelectedIndex == 0)
                    this.prioritySets[layer.LayerPrioritySet].ColorMathHalfIntensity = 0;//false;
                else if (layerColorMathIntensity.SelectedIndex == 1)
                    this.prioritySets[layer.LayerPrioritySet].ColorMathHalfIntensity = 1;//true;

                if (!updatingLevel)
                    UpdateLevel();
            }

        }
        private void layerColorMathMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingProperties)
            {
                if (layerColorMathMode.SelectedIndex == 0)
                    this.prioritySets[layer.LayerPrioritySet].ColorMathMinusSubscreen = 0;//false;
                else if (layerColorMathMode.SelectedIndex == 1)
                    this.prioritySets[layer.LayerPrioritySet].ColorMathMinusSubscreen = 1;// true;

                if (!updatingLevel)
                    UpdateLevel();
            }

        }
        private void layerMaskHighX_ValueChanged(object sender, EventArgs e)
        {
            layer.MaskHighX = (byte)layerMaskHighX.Value;
            pictureBoxLevel.Invalidate();
        }
        private void layerMaskLowX_ValueChanged(object sender, EventArgs e)
        {
            layer.MaskLowX = (byte)layerMaskLowX.Value;
            pictureBoxLevel.Invalidate();
        }
        private void layerMaskHighY_ValueChanged(object sender, EventArgs e)
        {
            layer.MaskHighY = (byte)layerMaskHighY.Value;
            pictureBoxLevel.Invalidate();
        }
        private void layerMaskLowY_ValueChanged(object sender, EventArgs e)
        {
            layer.MaskLowY = (byte)layerMaskLowY.Value;
            pictureBoxLevel.Invalidate();
        }
        private void layerLockMask_CheckedChanged(object sender, EventArgs e)
        {
            layer.MaskLock = layerLockMask.Checked;
            if (layerLockMask.Checked) layerLockMask.ForeColor = Color.Black;
            else layerLockMask.ForeColor = Color.Gray;
        }
        private void layerL2LeftShift_ValueChanged(object sender, EventArgs e)
        {
            layer.LeftShiftL2 = (byte)layerL2LeftShift.Value;
        }
        private void layerL3LeftShift_ValueChanged(object sender, EventArgs e)
        {
            layer.LeftShiftL3 = (byte)layerL3LeftShift.Value;
        }
        private void layerL2UpShift_ValueChanged(object sender, EventArgs e)
        {
            layer.UpShiftL2 = (byte)layerL2UpShift.Value;
        }
        private void layerL3UpShift_ValueChanged(object sender, EventArgs e)
        {
            layer.UpShiftL3 = (byte)layerL3UpShift.Value;
        }
        private void layerScrollWrapping_SelectedIndexChanged(object sender, EventArgs e)
        {
            layer.HorizontalScrollWrapL1 = layerScrollWrapping.GetItemChecked(0);
            layer.VerticalScrollWrapL1 = layerScrollWrapping.GetItemChecked(1);
            layer.HorizontalScrollWrapL2 = layerScrollWrapping.GetItemChecked(2);
            layer.VerticalScrollWrapL2 = layerScrollWrapping.GetItemChecked(3);
            layer.HorizontalScrollWrapL3 = layerScrollWrapping.GetItemChecked(4);
            layer.VerticalScrollWrapL3 = layerScrollWrapping.GetItemChecked(5);
            layer.CulexA = layerScrollWrapping.GetItemChecked(6);
            layer.CulexB = layerScrollWrapping.GetItemChecked(7);

        }
        private void layerL2VSync_SelectedIndexChanged(object sender, EventArgs e)
        {
            layer.VerticalSyncL2 = (byte)layerL2VSync.SelectedIndex;
        }
        private void layerL3VSync_SelectedIndexChanged(object sender, EventArgs e)
        {
            layer.VerticalSyncL3 = (byte)layerL3VSync.SelectedIndex;
        }
        private void layerL2HSync_SelectedIndexChanged(object sender, EventArgs e)
        {
            layer.HorizontalSyncL2 = (byte)layerL2HSync.SelectedIndex;
        }
        private void layerL3HSync_SelectedIndexChanged(object sender, EventArgs e)
        {
            layer.HorizontalSyncL3 = (byte)layerL3HSync.SelectedIndex;
        }
        private void layerL2ScrollShift_CheckedChanged(object sender, EventArgs e)
        {
            layer.ScrollL2Bit7 = layerL2ScrollShift.Checked;
            if (layerL2ScrollShift.Checked) layerL2ScrollShift.ForeColor = Color.Black;
            else layerL2ScrollShift.ForeColor = Color.Gray;
        }
        private void layerL3ScrollShift_CheckedChanged(object sender, EventArgs e)
        {
            layer.ScrollL3Bit7 = layerL3ScrollShift.Checked;
            if (layerL3ScrollShift.Checked) layerL3ScrollShift.ForeColor = Color.Black;
            else layerL3ScrollShift.ForeColor = Color.Gray;
        }
        private void layerL2ScrollDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            layer.ScrollDirectionL2 = (byte)layerL2ScrollDirection.SelectedIndex;
        }
        private void layerL2ScrollSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            layer.ScrollSpeedL2 = (byte)layerL2ScrollSpeed.SelectedIndex;
        }
        private void layerL3ScrollDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            layer.ScrollDirectionL3 = (byte)layerL3ScrollDirection.SelectedIndex;
        }
        private void layerL3ScrollSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            layer.ScrollSpeedL3 = (byte)layerL3ScrollSpeed.SelectedIndex;
        }
        private void layerInfiniteAutoscroll_CheckedChanged(object sender, EventArgs e)
        {
            layer.InfiniteAutoscroll = layerInfiniteAutoscroll.Checked;
            if (layerInfiniteAutoscroll.Checked) layerInfiniteAutoscroll.ForeColor = Color.Black;
            else layerInfiniteAutoscroll.ForeColor = Color.Gray;
        }
        private void layerL3Effects_SelectedIndexChanged(object sender, EventArgs e)
        {
            layer.AnimationEffectL3 = (byte)layerL3Effects.SelectedIndex;
        }
        private void layerOBJEffects_SelectedIndexChanged(object sender, EventArgs e)
        {
            layer.ExtraEffects = (byte)layerOBJEffects.SelectedIndex;
        }
        private void layerWaveEffect_CheckedChanged(object sender, EventArgs e)
        {
            layer.WaveEffectL3 = layerWaveEffect.Checked;
            if (layerWaveEffect.Checked) layerWaveEffect.ForeColor = Color.Black;
            else layerWaveEffect.ForeColor = Color.Gray;
        }

        #endregion
    }
}
