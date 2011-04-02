using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public partial class LevelsSolidTiles : Form
    {
        private int index { get { return (int)physicalTileNum.Value; } }
        public int Index { get { return (int)physicalTileNum.Value; } set { physicalTileNum.Value = value; } }
        private SolidityTile[] solidityTiles;
        private SolidityTile solidityTile { get { return solidityTiles[index]; } set { solidityTiles[index] = value; } }
        private bool updating = false;
        private Bitmap solidTileImage;
        private Solidity solids;
        public Solidity Solids { get { return solids; } }
        public SearchSolidTile searchSolidTile;

        public LevelsSolidTiles(SolidityTile[] solidityTiles, Solidity solids)
        {
            this.solidityTiles = solidityTiles;
            this.solids = solids;
            DrawPhysicalTiles();
            InitializeComponent();
            RefreshPhysicalTile();
            searchSolidTile = new SearchSolidTile(this, solidityTiles);
        }
        public void DrawPhysicalTiles()
        {
        }
        private void RefreshPhysicalTile()
        {
            updating = true;
            // SIZE/COORDS;
            heightOfBaseTile.Value = solidityTile.BaseTileHeight;
            heightOverhead.Value = solidityTile.OverheadTileHeight;
            zCoordOverhead.Value = solidityTile.OverheadTileCoordZ;
            zCoordWater.Value = solidityTile.WaterTileCoordZ;
            zCoordPlusHalf.SelectedIndex = (int)(solidityTile.BaseTileHeightPlusHalf ? 1 : 0);
            // SOLID QUADRANTS;
            solidTile.SelectedIndex = (int)(solidityTile.SolidTile ? 1 : 0);
            solidQuadrant.SelectedIndex = (int)(solidityTile.SolidQuadrantFlag ? 1 : 0);
            solidQuadrantN.SelectedIndex = (int)(solidityTile.SolidTopQuadrant ? 1 : 0);
            solidQuadrantW.SelectedIndex = (int)(solidityTile.SolidLeftQuadrant ? 1 : 0);
            solidQuadrantS.SelectedIndex = (int)(solidityTile.SolidBottomQuadrant ? 1 : 0);
            solidQuadrantE.SelectedIndex = (int)(solidityTile.SolidRightQuadrant ? 1 : 0);
            // SOLID EDGES;
            solidEdgeNW.SelectedIndex = (int)(solidityTile.SolidUpperLeftEdge ? 1 : 0);
            solidEdgeSW.SelectedIndex = (int)(solidityTile.SolidLowerLeftEdge ? 1 : 0);
            solidEdgeNE.SelectedIndex = (int)(solidityTile.SolidUpperRightEdge ? 1 : 0);
            solidEdgeSE.SelectedIndex = (int)(solidityTile.SolidLowerRightEdge ? 1 : 0);
            // PRIORITY 3;
            p3OnEdge.SelectedIndex = (int)(solidityTile.ObjectOnEdgePriority3 ? 1 : 0);
            p3OverEdge.SelectedIndex = (int)(solidityTile.ObjectAboveEdgePriority3 ? 1 : 0);
            p3OnTile.SelectedIndex = (int)(solidityTile.ObjectOnTilePriority3 ? 1 : 0);
            // CONVEYOR BELT;
            conveyor.SelectedIndex = solidityTile.ConveryorBeltDirection;
            conveyorBeltFast.SelectedIndex = (int)(solidityTile.ConveyorBeltFast ? 1 : 0);
            conveyorBeltNormal.SelectedIndex = (int)(solidityTile.ConveyorBeltNormal ? 1 : 0);
            // OTHER;
            stairs.SelectedIndex = solidityTile.StairsDirection;
            specialTile.SelectedIndex = solidityTile.SpecialTileFormat;
            doorFormat.SelectedIndex = solidityTile.Door;

            int[] physicalTilePixels = solids.GetTilePixels(solidityTile);
            solidTileImage = new Bitmap(Do.PixelsToImage(physicalTilePixels, 32, 784));
            pictureBoxPhysicalTile.Invalidate();

            updating = false;
        }
        private void physicalTileNum_ValueChanged(object sender, EventArgs e)
        {
            RefreshPhysicalTile();
        }
        private void physicalTileSearchButton_Click(object sender, System.EventArgs e)
        {
            searchSolidTile.Show();
            searchSolidTile.BringToFront();
        }

        private void property_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBoxPhysicalTile_MouseDown(object sender, MouseEventArgs e)
        {

        }
        private void pictureBoxPhysicalTile_Paint(object sender, PaintEventArgs e)
        {
            if (solidTileImage != null)
                e.Graphics.DrawImage(solidTileImage, 0, 0);
        }
        private void pictureBoxPhysicalTile_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void LevelsPhysicalTiles_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void heightOfBaseTile_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            solidityTile.BaseTileHeight = (byte)heightOfBaseTile.Value;
        }
        private void zCoordOverhead_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            solidityTile.OverheadTileCoordZ = (byte)zCoordOverhead.Value;
        }
        private void heightOverhead_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            solidityTile.OverheadTileHeight = (byte)heightOverhead.Value;
        }
        private void zCoordWater_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            solidityTile.WaterTileCoordZ = (byte)zCoordWater.Value;
        }
        private void zCoordPlusHalf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            solidityTile.BaseTileHeightPlusHalf = zCoordPlusHalf.SelectedIndex == 1;
        }
        private void solidTile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            solidityTile.SolidTile = solidTile.SelectedIndex == 1;
        }
        private void solidQuadrant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            solidityTile.SolidQuadrantFlag = solidQuadrant.SelectedIndex == 1;
        }
        private void solidQuadrantN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            solidityTile.SolidTopQuadrant = solidQuadrantN.SelectedIndex == 1;
        }
        private void solidQuadrantW_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            solidityTile.SolidLeftQuadrant = solidQuadrantN.SelectedIndex == 1;
        }
        private void solidQuadrantE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            solidityTile.SolidRightQuadrant = solidQuadrantN.SelectedIndex == 1;
        }
        private void solidQuadrantS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            solidityTile.SolidBottomQuadrant = solidQuadrantN.SelectedIndex == 1;
        }
        private void solidEdgeNW_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            solidityTile.SolidUpperLeftEdge = solidEdgeNW.SelectedIndex == 1;
        }
        private void solidEdgeNE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            solidityTile.SolidUpperRightEdge = solidEdgeNE.SelectedIndex == 1;
        }
        private void solidEdgeSW_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            solidityTile.SolidLowerLeftEdge = solidEdgeSW.SelectedIndex == 1;
        }
        private void solidEdgeSE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            solidityTile.SolidLowerRightEdge = solidEdgeSE.SelectedIndex == 1;
        }
        private void p3OnEdge_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            solidityTile.ObjectOnEdgePriority3 = p3OnEdge.SelectedIndex == 1;
        }
        private void p3OverEdge_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            solidityTile.ObjectAboveEdgePriority3 = p3OverEdge.SelectedIndex == 1;
        }
        private void p3OnTile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            solidityTile.ObjectOnTilePriority3 = p3OnTile.SelectedIndex == 1;
        }
        private void conveyor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            solidityTile.ConveryorBeltDirection = (byte)conveyor.SelectedIndex;
        }
        private void conveyorBeltFast_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            solidityTile.ConveyorBeltFast = conveyorBeltFast.SelectedIndex == 1;
        }
        private void conveyorBeltNormal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            solidityTile.ConveyorBeltNormal = conveyorBeltNormal.SelectedIndex == 1;
        }
        private void stairs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            solidityTile.StairsDirection = (byte)stairs.SelectedIndex;
        }
        private void specialTile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            solidityTile.SpecialTileFormat = (byte)specialTile.SelectedIndex;
        }
        private void doorFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            solidityTile.Door = (byte)doorFormat.SelectedIndex;
        }
        private void unknownBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            solidityTile.Byte5b0 = unknownBits.GetItemChecked(0);
            solidityTile.Byte5b1 = unknownBits.GetItemChecked(1);
            solidityTile.Byte5b2 = unknownBits.GetItemChecked(2);
            solidityTile.Byte5b3 = unknownBits.GetItemChecked(3);
            solidityTile.Byte5b4 = unknownBits.GetItemChecked(4);
        }

        private void conditional_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            Color foreColor = e.Index == 1 ? Color.Blue : Color.Red;
            StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic); 
            e.DrawBackground();
            e.Graphics.DrawString(comboBox.Items[e.Index].ToString(), e.Font, new SolidBrush(foreColor), e.Bounds, stringFormat);
            e.DrawFocusRectangle();
        }
    }
}
