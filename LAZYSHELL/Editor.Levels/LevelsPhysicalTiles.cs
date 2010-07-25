using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public partial class LevelsPhysicalTiles : Form
    {
        private int index { get { return (int)physicalTileNum.Value; } }
        public int Index { get { return (int)physicalTileNum.Value; } set { physicalTileNum.Value = value; } }
        private PhysicalTile[] physicalTiles;
        private PhysicalTile physicalTile { get { return physicalTiles[index]; } set { physicalTiles[index] = value; } }

        private Bitmap physicalTileImage;
        private SolidTilePixels solids;
        public SolidTilePixels Solids { get { return solids; } }
        
        public LevelsPhysicalTiles(PhysicalTile[] physicalTiles, SolidTilePixels solids)
        {
            this.physicalTiles = physicalTiles;
            this.solids = solids;
            DrawPhysicalTiles();
            InitializeComponent();
            RefreshPhysicalTile();
        }
        public void DrawPhysicalTiles()
        {
        }
        private void RefreshPhysicalTile()
        {
            physicalTileBaseHeight.Value = physicalTile.BaseTileHeight;
            physicalTileOverHeight.Value = physicalTile.OverheadTileHeight;
            physicalTileOverZCoord.Value = physicalTile.OverheadTileCoordZ;
            physicalTileWaterZCoord.Value = physicalTile.WaterTileCoordZ;
            physicalTileProperties.SetItemChecked(0, physicalTile.ConveyorBeltFast);
            physicalTileProperties.SetItemChecked(1, physicalTile.ConveyorBeltNormal);
            physicalTileProperties.SetItemChecked(2, physicalTile.BaseTileHeightPlusHalf);
            physicalTileProperties.SetItemChecked(3, physicalTile.SolidTile);
            physicalTileConveyor.SelectedIndex = physicalTile.ConveryorBeltDirection;
            physicalTileEdges.SetItemChecked(0, physicalTile.SolidUpperLeftEdge);
            physicalTileEdges.SetItemChecked(1, physicalTile.SolidUpperRightEdge);
            physicalTileEdges.SetItemChecked(2, physicalTile.SolidLowerLeftEdge);
            physicalTileEdges.SetItemChecked(3, physicalTile.SolidLowerRightEdge);
            physicalTileStairs.SelectedIndex = physicalTile.StairsDirection;
            physicalTileQuadrant.SetItemChecked(0, physicalTile.SolidTopQuadrant);
            physicalTileQuadrant.SetItemChecked(1, physicalTile.SolidLeftQuadrant);
            physicalTileQuadrant.SetItemChecked(2, physicalTile.SolidRightQuadrant);
            physicalTileQuadrant.SetItemChecked(3, physicalTile.SolidBottomQuadrant);
            physicalTilePriority3.SetItemChecked(0, physicalTile.ObjectOnEdgePriority3);
            physicalTilePriority3.SetItemChecked(1, physicalTile.ObjectAboveEdgePriority3);
            physicalTilePriority3.SetItemChecked(2, physicalTile.ObjectOnTilePriority3);
            physicalTilePriority3.SetItemChecked(3, physicalTile.SolidQuadrantFlag);
            physicalTileSpecialTile.SelectedIndex = physicalTile.SpecialTileFormat;
            physicalTileUnknownBits.SetItemChecked(0, physicalTile.Byte5b0);
            physicalTileUnknownBits.SetItemChecked(1, physicalTile.Byte5b1);
            physicalTileUnknownBits.SetItemChecked(2, physicalTile.Byte5b2);
            physicalTileUnknownBits.SetItemChecked(3, physicalTile.Byte5b3);
            physicalTileUnknownBits.SetItemChecked(4, physicalTile.Byte5b4);
            physicalTileDoorFormat.SelectedIndex = physicalTile.Door;

            int[] physicalTilePixels = physicalTile.DrawPhysicalTile(solids);
            physicalTileImage = new Bitmap(Do.PixelsToImage(physicalTilePixels, 32, 784));
            pictureBoxPhysicalTile.Invalidate();
        }
        private void physicalTileNum_ValueChanged(object sender, EventArgs e)
        {
            RefreshPhysicalTile();
        }
        private void physicalTilequadrant_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void physicalTileSpecialTile_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void physicalTilestairs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void physicalTileConveyor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void physicalTilePriority3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void physicalTileEdges_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void physicalTileProperties_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void physicalTileWaterZCoord_ValueChanged(object sender, EventArgs e)
        {

        }
        private void physicalTileOverHeight_ValueChanged(object sender, EventArgs e)
        {

        }
        private void physicalTileOverZCoord_ValueChanged(object sender, EventArgs e)
        {

        }
        private void physicalTileBaseHeight_ValueChanged(object sender, EventArgs e)
        {

        }
        private void physicalTileSearchButton_Click(object sender, System.EventArgs e)
        {
            // Open search physical tile
            Form searchPhysTile = new SearchPhysicalTile(this, physicalTiles);
            searchPhysTile.Show();
        }

        private void pictureBoxPhysicalTile_MouseDown(object sender, MouseEventArgs e)
        {

        }
        private void pictureBoxPhysicalTile_Paint(object sender, PaintEventArgs e)
        {
            if (physicalTileImage != null)
                e.Graphics.DrawImage(physicalTileImage, 0, 0);
        }
        private void pictureBoxPhysicalTile_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }
    }
}
