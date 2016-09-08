using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LazyShell.Areas
{
    public partial class PriorityForm : Controls.DockForm
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
        private PrioritySet[] prioritySets
        {
            get { return Model.PrioritySets; }
            set { Model.PrioritySets = value; }
        }
        private PrioritySet prioritySet
        {
            get { return prioritySets[layering.PrioritySet]; }
            set { prioritySets[layering.PrioritySet] = value; }
        }
        private Tilemap tilemap
        {
            get { return ownerForm.Tilemap; }
            set { ownerForm.Tilemap = value; }
        }
        private TilemapForm tilemapForm
        {
            get { return ownerForm.TilemapForm; }
            set { ownerForm.TilemapForm = value; }
        }

        #endregion

        // Constructor
        public PriorityForm(OwnerForm owner)
        {
            this.ownerForm = owner;
            InitializeComponent();
        }

        #region Methods

        public void LoadProperties()
        {
            this.Updating = true;
            //
            this.mainscreenL1.Checked = prioritySets[layering.PrioritySet].MainscreenL1;
            this.mainscreenL2.Checked = prioritySets[layering.PrioritySet].MainscreenL2;
            this.mainscreenL3.Checked = prioritySets[layering.PrioritySet].MainscreenL3;
            this.mainscreenNPC.Checked = prioritySets[layering.PrioritySet].MainscreenOBJ;
            this.subscreenL1.Checked = prioritySets[layering.PrioritySet].SubscreenL1;
            this.subscreenL2.Checked = prioritySets[layering.PrioritySet].SubscreenL2;
            this.subscreenL3.Checked = prioritySets[layering.PrioritySet].SubscreenL3;
            this.subscreenNPC.Checked = prioritySets[layering.PrioritySet].SubscreenOBJ;
            this.colorMathL1.Checked = prioritySets[layering.PrioritySet].ColorMathL1;
            this.colorMathL2.Checked = prioritySets[layering.PrioritySet].ColorMathL2;
            this.colorMathL3.Checked = prioritySets[layering.PrioritySet].ColorMathL3;
            this.colorMathNPC.Checked = prioritySets[layering.PrioritySet].ColorMathOBJ;
            this.colorMathBG.Checked = prioritySets[layering.PrioritySet].ColorMathBG;
            this.colorMathHalfIntensity.Checked = prioritySets[layering.PrioritySet].ColorMathHalfIntensity;
            this.colorMathMinusSubscreen.Checked = prioritySets[layering.PrioritySet].ColorMathMinusSubscreen;
            //
            this.Updating = false;
        }

        #endregion

        #region Event Handlers

        private void mainscreenL1_CheckedChanged(object sender, EventArgs e)
        {
            mainscreenL1.ForeColor = mainscreenL1.Checked ? Color.Black : Color.Gray;
            this.prioritySet.MainscreenL1 = mainscreenL1.Checked;
            if (!this.Updating)
            {
                tilemap.RedrawTilemaps();
                tilemapForm.SetTilemapImage();
            }
        }
        private void mainscreenL2_CheckedChanged(object sender, EventArgs e)
        {
            mainscreenL2.ForeColor = mainscreenL2.Checked ? Color.Black : Color.Gray;
            this.prioritySet.MainscreenL2 = mainscreenL2.Checked;
            if (!this.Updating)
            {
                tilemap.RedrawTilemaps();
                tilemapForm.SetTilemapImage();
            }
        }
        private void mainscreenL3_CheckedChanged(object sender, EventArgs e)
        {
            mainscreenL3.ForeColor = mainscreenL3.Checked ? Color.Black : Color.Gray;
            this.prioritySet.MainscreenL3 = mainscreenL3.Checked;
            if (!this.Updating)
            {
                tilemap.RedrawTilemaps();
                tilemapForm.SetTilemapImage();
            }
        }
        private void mainscreenNPC_CheckedChanged(object sender, EventArgs e)
        {
            mainscreenNPC.ForeColor = mainscreenNPC.Checked ? Color.Black : Color.Gray;
            this.prioritySet.MainscreenOBJ = mainscreenNPC.Checked;
            if (!this.Updating)
            {
                tilemap.RedrawTilemaps();
                tilemapForm.SetTilemapImage();
            }
        }
        private void subscreenL1_CheckedChanged(object sender, EventArgs e)
        {
            subscreenL1.ForeColor = subscreenL1.Checked ? Color.Black : Color.Gray;
            this.prioritySet.SubscreenL1 = subscreenL1.Checked;
            if (!this.Updating)
            {
                tilemap.RedrawTilemaps();
                tilemapForm.SetTilemapImage();
            }
        }
        private void subscreenL2_CheckedChanged(object sender, EventArgs e)
        {
            subscreenL2.ForeColor = subscreenL2.Checked ? Color.Black : Color.Gray;
            this.prioritySet.SubscreenL2 = subscreenL2.Checked;
            if (!this.Updating)
            {
                tilemap.RedrawTilemaps();
                tilemapForm.SetTilemapImage();
            }
        }
        private void subscreenL3_CheckedChanged(object sender, EventArgs e)
        {
            subscreenL3.ForeColor = subscreenL3.Checked ? Color.Black : Color.Gray;
            this.prioritySet.SubscreenL3 = subscreenL3.Checked;
            if (!this.Updating)
            {
                tilemap.RedrawTilemaps();
                tilemapForm.SetTilemapImage();
            }
        }
        private void subscreenNPC_CheckedChanged(object sender, EventArgs e)
        {
            subscreenNPC.ForeColor = subscreenNPC.Checked ? Color.Black : Color.Gray;
            this.prioritySet.SubscreenOBJ = subscreenNPC.Checked;
            if (!this.Updating)
            {
                tilemap.RedrawTilemaps();
                tilemapForm.SetTilemapImage();
            }
        }
        private void colorMathL1_CheckedChanged(object sender, EventArgs e)
        {
            colorMathL1.ForeColor = colorMathL1.Checked ? Color.Black : Color.Gray;
            this.prioritySet.ColorMathL1 = colorMathL1.Checked;
            if (!this.Updating)
            {
                tilemap.RedrawTilemaps();
                tilemapForm.SetTilemapImage();
            }
        }
        private void colorMathL2_CheckedChanged(object sender, EventArgs e)
        {
            colorMathL2.ForeColor = colorMathL2.Checked ? Color.Black : Color.Gray;
            this.prioritySet.ColorMathL2 = colorMathL2.Checked;
            if (!this.Updating)
            {
                tilemap.RedrawTilemaps();
                tilemapForm.SetTilemapImage();
            }
        }
        private void colorMathL3_CheckedChanged(object sender, EventArgs e)
        {
            colorMathL3.ForeColor = colorMathL3.Checked ? Color.Black : Color.Gray;
            this.prioritySet.ColorMathL3 = colorMathL3.Checked;
            if (!this.Updating)
            {
                tilemap.RedrawTilemaps();
                tilemapForm.SetTilemapImage();
            }
        }
        private void colorMathNPC_CheckedChanged(object sender, EventArgs e)
        {
            colorMathNPC.ForeColor = colorMathNPC.Checked ? Color.Black : Color.Gray;
            this.prioritySet.ColorMathOBJ = colorMathNPC.Checked;
            if (!this.Updating)
            {
                tilemap.RedrawTilemaps();
                tilemapForm.SetTilemapImage();
            }
        }
        private void colorMathBG_CheckedChanged(object sender, EventArgs e)
        {
            colorMathBG.ForeColor = colorMathBG.Checked ? Color.Black : Color.Gray;
            this.prioritySet.ColorMathBG = colorMathBG.Checked;
            if (!this.Updating)
            {
                tilemap.RedrawTilemaps();
                tilemapForm.SetTilemapImage();
            }
        }
        private void colorMathHalfIntensity_CheckedChanged(object sender, EventArgs e)
        {
            this.prioritySet.ColorMathHalfIntensity = colorMathHalfIntensity.Checked;
            if (!this.Updating)
            {
                tilemap.RedrawTilemaps();
                tilemapForm.SetTilemapImage();
            }
        }
        private void colorMathMinusSubscreen_CheckedChanged(object sender, EventArgs e)
        {
            this.prioritySet.ColorMathMinusSubscreen = colorMathMinusSubscreen.Checked;
            if (!this.Updating)
            {
                tilemap.RedrawTilemaps();
                tilemapForm.SetTilemapImage();
            }
        }

        #endregion
    }
}
