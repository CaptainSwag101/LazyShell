using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL.Areas
{
    public partial class CollisionTileForm : Controls.DockForm
    {
        #region Variables

        public int Index
        {
            get { return (int)collisionTileNum.Value; }
            set { collisionTileNum.Value = value; }
        }
        // Elements
        private CollisionTile[] collisionTiles
        {
            get { return Model.CollisionTiles; }
            set { Model.CollisionTiles = value; }
        }
        private CollisionTile collisionTile
        {
            get { return collisionTiles[Index]; }
            set { collisionTiles[Index] = value; }
        }
        private Collision collision;
        private Bitmap collisionTileImage;
        // Forms
        private SearchCollisionTileForm searchCollisionTileForm;
        // Updating
        private delegate void Function();
        private Delegate update;

        #endregion

        // Constructor
        public CollisionTileForm(Collision collision, Delegate update)
        {
            this.collision = collision;
            this.update = update;
            InitializeComponent();
            InitializeForms();
            LoadCollisionTile();
        }

        #region Methods

        private void InitializeForms()
        {
            searchCollisionTileForm = new SearchCollisionTileForm(this, collisionTiles);
        }
        //
        private void LoadCollisionTile()
        {
            this.Updating = true;
            // SIZE/COORDS;
            heightOfBaseTile.Value = collisionTile.BaseTileHeight;
            heightOverhead.Value = collisionTile.OverheadTileHeight;
            zCoordOverhead.Value = collisionTile.OverheadTileZ;
            zCoordWater.Value = collisionTile.WaterTileZ;
            zCoordPlusHalf.Checked = collisionTile.BaseTileHeight_Half;
            // SOLID QUADRANTS;
            solidTile.Checked = collisionTile.SolidTile;
            solidQuadrant.Checked = collisionTile.SolidQuadrantFlag;
            solidQuadrantN.Checked = collisionTile.SolidQuadN;
            solidQuadrantW.Checked = collisionTile.SolidQuadW;
            solidQuadrantS.Checked = collisionTile.SolidQuadS;
            solidQuadrantE.Checked = collisionTile.SolidQuadE;
            // SOLID EDGES;
            solidEdgeNW.Checked = collisionTile.SolidEdgeNW;
            solidEdgeSW.Checked = collisionTile.SolidEdgeSW;
            solidEdgeNE.Checked = collisionTile.SolidEdgeNE;
            solidEdgeSE.Checked = collisionTile.SolidEdgeSE;
            // PRIORITY 3;
            p3OnEdge.Checked = collisionTile.P3ObjectOnEdge;
            p3OverEdge.Checked = collisionTile.P3ObjectAboveEdge;
            p3OnTile.Checked = collisionTile.P3ObjectOnTile;
            // CONVEYOR BELT;
            conveyor.SelectedIndex = collisionTile.ConveyorBeltDirection;
            conveyorBeltFast.Checked = collisionTile.ConveyorBeltFast;
            conveyorBeltNormal.Checked = collisionTile.ConveyorBeltNormal;
            // OTHER;
            stairs.SelectedIndex = collisionTile.StairsDirection;
            specialTile.SelectedIndex = collisionTile.SpecialTileFormat;
            doorFormat.SelectedIndex = collisionTile.Door;
            //
            SetCollisionTileImage();
            //
            this.Updating = false;
        }
        private void SetCollisionTileImage()
        {
            int[] pixels = collision.GetTilePixels(collisionTile);
            collisionTileImage = Do.PixelsToImage(pixels, 32, 784);
            pictureBox.Invalidate();
        }

        #endregion

        #region Event handlers

        private void collisionTileNum_ValueChanged(object sender, EventArgs e)
        {
            LoadCollisionTile();
        }
        private void search_Click(object sender, System.EventArgs e)
        {
            searchCollisionTileForm.Show(this);
            searchCollisionTileForm.Left = this.Left - searchCollisionTileForm.Width - 10;
            searchCollisionTileForm.Top = this.Top;
            searchCollisionTileForm.BringToFront();
        }
        private void reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current collision tile. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            collisionTile = new CollisionTile(Index);
            collisionTileNum_ValueChanged(null, null);
        }
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (collisionTileImage != null)
                e.Graphics.DrawImage(collisionTileImage, 0, 0);
        }
        private void CollisionTileForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
        //
        private void heightOfBaseTile_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            collisionTile.BaseTileHeight = (byte)heightOfBaseTile.Value;
            SetCollisionTileImage();
            update.DynamicInvoke();
        }
        private void zCoordOverhead_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            collisionTile.OverheadTileZ = (byte)zCoordOverhead.Value;
            SetCollisionTileImage();
            update.DynamicInvoke();
        }
        private void heightOverhead_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            collisionTile.OverheadTileHeight = (byte)heightOverhead.Value;
            SetCollisionTileImage();
            update.DynamicInvoke();
        }
        private void zCoordWater_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            collisionTile.WaterTileZ = (byte)zCoordWater.Value;
            SetCollisionTileImage();
            update.DynamicInvoke();
        }
        private void zCoordPlusHalf_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            collisionTile.BaseTileHeight_Half = zCoordPlusHalf.Checked;
            SetCollisionTileImage();
            update.DynamicInvoke();
        }
        private void solidQuadrant_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            collisionTile.SolidQuadrantFlag = solidQuadrant.Checked;
            SetCollisionTileImage();
            update.DynamicInvoke();
        }
        private void solidTile_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            collisionTile.SolidTile = solidTile.Checked;
            SetCollisionTileImage();
            update.DynamicInvoke();
        }
        private void solidQuadrantN_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            collisionTile.SolidQuadN = solidQuadrantN.Checked;
            SetCollisionTileImage();
            update.DynamicInvoke();
        }
        private void solidQuadrantW_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            collisionTile.SolidQuadW = solidQuadrantW.Checked;
            SetCollisionTileImage();
            update.DynamicInvoke();
        }
        private void solidQuadrantE_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            collisionTile.SolidQuadE = solidQuadrantE.Checked;
            SetCollisionTileImage();
            update.DynamicInvoke();
        }
        private void solidQuadrantS_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            collisionTile.SolidQuadS = solidQuadrantS.Checked;
            SetCollisionTileImage();
            update.DynamicInvoke();
        }
        private void solidEdgeNW_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            collisionTile.SolidEdgeNW = solidEdgeNW.Checked;
        }
        private void solidEdgeNE_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            collisionTile.SolidEdgeNE = solidEdgeNE.Checked;
        }
        private void solidEdgeSW_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            collisionTile.SolidEdgeSW = solidEdgeSW.Checked;
        }
        private void solidEdgeSE_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            collisionTile.SolidEdgeSE = solidEdgeSE.Checked;
        }
        private void p3OnEdge_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            collisionTile.P3ObjectOnEdge = p3OnEdge.Checked;
        }
        private void p3OverEdge_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            collisionTile.P3ObjectAboveEdge = p3OverEdge.Checked;
        }
        private void p3OnTile_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            collisionTile.P3ObjectOnTile = p3OnTile.Checked;
        }
        private void conveyor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            collisionTile.ConveyorBeltDirection = (byte)conveyor.SelectedIndex;
        }
        private void conveyorBeltFast_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            collisionTile.ConveyorBeltFast = conveyorBeltFast.Checked;
        }
        private void conveyorBeltNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            collisionTile.ConveyorBeltNormal = conveyorBeltNormal.Checked;
        }
        private void stairs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            collisionTile.StairsDirection = (byte)stairs.SelectedIndex;
            SetCollisionTileImage();
            update.DynamicInvoke();
        }
        private void specialTile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            collisionTile.SpecialTileFormat = (byte)specialTile.SelectedIndex;
            SetCollisionTileImage();
            update.DynamicInvoke();
        }
        private void doorFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            collisionTile.Door = (byte)doorFormat.SelectedIndex;
        }
        private void unknownBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            collisionTile.B5b0 = unknownBits.GetItemChecked(0);
            collisionTile.B5b1 = unknownBits.GetItemChecked(1);
            collisionTile.B5b2 = unknownBits.GetItemChecked(2);
            collisionTile.B5b3 = unknownBits.GetItemChecked(3);
            collisionTile.B5b4 = unknownBits.GetItemChecked(4);
        }

        #endregion
    }
}
