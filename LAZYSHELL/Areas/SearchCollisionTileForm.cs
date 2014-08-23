using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL.Areas
{
    public partial class SearchCollisionTileForm : Controls.NewForm
    {
        #region Variables

        private CollisionTileForm collisionTileForm;
        private CollisionTile[] collisionTiles;

        #endregion

        // Constructor
        public SearchCollisionTileForm(CollisionTileForm collisionTilesForm, CollisionTile[] collisionTiles)
        {
            this.collisionTileForm = collisionTilesForm;
            this.collisionTiles = collisionTiles;
            //
            InitializeComponent();
            ResetPropertyControls();
        }
        
        #region Methods

        private void PerformSearch()
        {
            bool notFound;
            int results = 0;
            string withProp = "";
            if (checkHeightOfBaseTile.Checked)
                withProp += "Height of base tile = " + heightOfBaseTile.Value.ToString() + "\n";
            if (checkHeightOverhead.Checked)
                withProp += "Height overhead tile = " + heightOverhead.Value.ToString() + "\n";
            if (checkZCoordOverhead.Checked)
                withProp += "Z Coord of overhead tile = " + zCoordOverhead.Value.ToString() + "\n";
            if (checkZCoordWater.Checked)
                withProp += "Z Coord of water tile = " + zCoordWater.Value.ToString() + "\n";
            if (checkZCoordPlusHalf.Checked)
                withProp += "Z Coord + 1/2 = " + (zCoordPlusHalf.SelectedIndex == 0 ? "TRUE" : "FALSE") + "\n";
            if (checkSolidTile.Checked)
                withProp += "Solid tile = " + (solidTile.SelectedIndex == 0 ? "TRUE" : "FALSE") + "\n";
            if (checkSolidQuadrant.Checked)
                withProp += "Solid quadrants = " + (solidQuadrant.SelectedIndex == 0 ? "TRUE" : "FALSE") + "\n";
            if (checkSolidQuadrantN.Checked)
                withProp += "N quadrant active = " + (solidQuadrantN.Checked ? "TRUE" : "FALSE") + "\n";
            if (checkSolidQuadrantW.Checked)
                withProp += "W quadrant active = " + (solidQuadrantW.Checked ? "TRUE" : "FALSE") + "\n";
            if (checkSolidQuadrantE.Checked)
                withProp += "E quadrant active = " + (solidQuadrantE.Checked ? "TRUE" : "FALSE") + "\n";
            if (checkSolidQuadrantS.Checked)
                withProp += "S quadrant active = " + (solidQuadrantS.Checked ? "TRUE" : "FALSE") + "\n";
            if (checkSolidEdgeNW.Checked)
                withProp += "NW edge is solid = " + (solidEdgeNW.Checked ? "TRUE" : "FALSE") + "\n";
            if (checkSolidEdgeNE.Checked)
                withProp += "NE edge is solid = " + (solidEdgeNE.Checked ? "TRUE" : "FALSE") + "\n";
            if (checkSolidEdgeSW.Checked)
                withProp += "SW edge is solid = " + (solidEdgeSW.Checked ? "TRUE" : "FALSE") + "\n";
            if (checkSolidEdgeSE.Checked)
                withProp += "SE edge is solid = " + (solidEdgeSE.Checked ? "TRUE" : "FALSE") + "\n";
            if (checkP3OnEdge.Checked)
                withProp += "Priority 3 for objects on tile edge = " + (p3OnEdge.SelectedIndex == 0 ? "TRUE" : "FALSE") + "\n";
            if (checkP3OverEdge.Checked)
                withProp += "Priority 3 for objects above tile edge = " + (p3OverEdge.SelectedIndex == 0 ? "TRUE" : "FALSE") + "\n";
            if (checkP3OnTile.Checked)
                withProp += "Priority 3 for objects on tile = " + (p3OnTile.SelectedIndex == 0 ? "TRUE" : "FALSE") + "\n";
            if (checkConveyor.Checked)
                withProp += "Conveyor belt runs..." + conveyor.SelectedItem.ToString() + "\n";
            if (checkConveyorBeltFast.Checked)
                withProp += "Conveyor belt, fast = " + (conveyorBeltFast.SelectedIndex == 0 ? "TRUE" : "FALSE") + "\n";
            if (checkConveyorBeltNormal.Checked)
                withProp += "Conveyor belt, normal = " + (conveyorBeltNormal.SelectedIndex == 0 ? "TRUE" : "FALSE") + "\n";
            if (checkStairs.Checked)
                withProp += "Stairs lead..." + stairs.SelectedItem.ToString() + "\n";
            if (checkSpecialTile.Checked)
                withProp += "Special tile format..." + specialTile.SelectedItem.ToString() + "\n";
            if (checkDoorFormat.Checked)
                withProp += "Door format..." + doorFormat.SelectedItem.ToString() + "\n";
            if (unknownBits.GetItemChecked(0))
                withProp += "Byte 5, bit 0 set\n";
            if (unknownBits.GetItemChecked(1))
                withProp += "Byte 5, bit 1 set\n";
            if (unknownBits.GetItemChecked(2))
                withProp += "Byte 5, bit 2 set\n";
            if (unknownBits.GetItemChecked(3))
                withProp += "Byte 5, bit 3 set\n";
            if (unknownBits.GetItemChecked(4))
                withProp += "Byte 5, bit 4 set\n";
            //
            searchResults.Items.Clear();
            for (int i = 0; i < collisionTiles.Length; i++)
            {
                notFound = false;
                // SIZE/COORDS
                if (checkHeightOfBaseTile.Checked)
                {
                    if (heightOfBaseTile.Value != collisionTiles[i].BaseTileHeight) notFound = true;
                }
                if (checkHeightOverhead.Checked)
                {
                    if (heightOverhead.Value != collisionTiles[i].OverheadTileHeight) notFound = true;
                }
                if (checkZCoordOverhead.Checked)
                {
                    if (zCoordOverhead.Value != collisionTiles[i].OverheadTileZ) notFound = true;
                }
                if (checkZCoordWater.Checked)
                {
                    if (zCoordWater.Value != collisionTiles[i].WaterTileZ) notFound = true;
                }
                if (checkZCoordPlusHalf.Checked)
                {
                    if (zCoordPlusHalf.SelectedIndex != (int)(collisionTiles[i].BaseTileHeight_Half ? 1 : 0))
                        notFound = true;
                }
                // SOLID QUADRANTS
                if (checkSolidTile.Checked)
                {
                    if (solidTile.SelectedIndex != (int)(collisionTiles[i].SolidTile ? 1 : 0)) notFound = true;
                }
                if (checkSolidQuadrant.Checked)
                {
                    if (solidQuadrant.SelectedIndex != (int)(collisionTiles[i].SolidQuadrantFlag ? 1 : 0)) notFound = true;
                }
                if (checkSolidQuadrantN.Checked)
                {
                    if (solidQuadrantN.Checked != collisionTiles[i].SolidQuadN) notFound = true;
                }
                if (checkSolidQuadrantW.Checked)
                {
                    if (solidQuadrantW.Checked != collisionTiles[i].SolidQuadW) notFound = true;
                }
                if (checkSolidQuadrantS.Checked)
                {
                    if (solidQuadrantS.Checked != collisionTiles[i].SolidQuadS) notFound = true;
                }
                if (checkSolidQuadrantE.Checked)
                {
                    if (solidQuadrantE.Checked != collisionTiles[i].SolidQuadE) notFound = true;
                }
                // SOLID EDGES
                if (checkSolidEdgeNW.Checked)
                {
                    if (solidEdgeNW.Checked != collisionTiles[i].SolidEdgeNW) notFound = true;
                }
                if (checkSolidEdgeSW.Checked)
                {
                    if (solidEdgeSW.Checked != collisionTiles[i].SolidEdgeSW) notFound = true;
                }
                if (checkSolidEdgeNE.Checked)
                {
                    if (solidEdgeNE.Checked != collisionTiles[i].SolidEdgeNE) notFound = true;
                }
                if (checkSolidEdgeSE.Checked)
                {
                    if (solidEdgeSE.Checked != collisionTiles[i].SolidEdgeSE) notFound = true;
                }
                // PRIORITY 3
                if (checkP3OnEdge.Checked)
                {
                    if (p3OnEdge.SelectedIndex != (int)(collisionTiles[i].P3ObjectOnEdge ? 1 : 0)) notFound = true;
                }
                if (checkP3OverEdge.Checked)
                {
                    if (p3OverEdge.SelectedIndex != (int)(collisionTiles[i].P3ObjectAboveEdge ? 1 : 0)) notFound = true;
                }
                if (checkP3OnTile.Checked)
                {
                    if (p3OnTile.SelectedIndex != (int)(collisionTiles[i].P3ObjectOnTile ? 1 : 0)) notFound = true;
                }
                // CONVEYOR BELT
                if (checkConveyor.Checked)
                {
                    if (collisionTiles[i].ConveyorBeltDirection != conveyor.SelectedIndex) notFound = true;
                }
                if (checkConveyorBeltFast.Checked)
                {
                    if (conveyorBeltFast.SelectedIndex != (int)(collisionTiles[i].ConveyorBeltFast ? 1 : 0)) notFound = true;
                }
                if (checkConveyorBeltNormal.Checked)
                {
                    if (conveyorBeltNormal.SelectedIndex != (int)(collisionTiles[i].ConveyorBeltNormal ? 1 : 0)) notFound = true;
                }
                // OTHER
                if (checkStairs.Checked)
                {
                    if (collisionTiles[i].StairsDirection != stairs.SelectedIndex) notFound = true;
                }
                if (checkSpecialTile.Checked)
                {
                    if (collisionTiles[i].SpecialTileFormat != specialTile.SelectedIndex) notFound = true;
                }
                if (checkDoorFormat.Checked)
                {
                    if (doorFormat.SelectedIndex != collisionTiles[i].Door) notFound = true;
                }
                if (!notFound)
                {
                    searchResults.Items.Add(collisionTiles[i]);
                    results++;
                }
            }
            if (withProp.Length > 0)
                withProp += "\n";
            withProp += results.ToString() + " results";
            withProperties.Text = withProp;
        }
        //
        private void ResetPropertyControls()
        {
            conveyor.SelectedIndex = 0;
            conveyorBeltFast.SelectedIndex = 0;
            conveyorBeltNormal.SelectedIndex = 0;
            doorFormat.SelectedIndex = 0;
            p3OnEdge.SelectedIndex = 0;
            p3OnTile.SelectedIndex = 0;
            p3OverEdge.SelectedIndex = 0;
            solidQuadrant.SelectedIndex = 0;
            solidTile.SelectedIndex = 0;
            specialTile.SelectedIndex = 0;
            stairs.SelectedIndex = 0;
            zCoordPlusHalf.SelectedIndex = 0;
            solidEdgeNE.Checked = false;
            solidEdgeNW.Checked = false;
            solidEdgeSE.Checked = false;
            solidEdgeSW.Checked = false;
            solidQuadrantE.Checked = false;
            solidQuadrantN.Checked = false;
            solidQuadrantS.Checked = false;
            solidQuadrantW.Checked = false;
        }

        #endregion

        #region Event Handlers

        private void SearchCollisionTileForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        //
        private void selectAll_Click(object sender, EventArgs e)
        {
            Do.SelectAll(panel1, true);
        }
        private void deselectAll_Click(object sender, EventArgs e)
        {
            Do.SelectAll(panel1, false);
        }
        private void search_Click(object sender, System.EventArgs e)
        {
            PerformSearch();
        }
        //
        private void checkControl_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            string name = checkBox.Name.Substring(5, 1).ToLower() + checkBox.Name.Substring(6);
            Control control = this.Controls.Find(name, true)[0];
            control.Enabled = checkBox.Checked;
        }
        //
        private void searchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchResults.SelectedItem == null)
                return;
            var collisionTile = searchResults.SelectedItem as CollisionTile;
            collisionTileForm.Index = collisionTile.Index;
        }

        #endregion
    }
}