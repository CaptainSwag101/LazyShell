using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public partial class SearchPhysicalTile : Form
    {
        private LevelsPhysicalTiles levelsPhysicalTiles;
        private PhysicalTile[] physicalTiles;

        public SearchPhysicalTile(LevelsPhysicalTiles levelsPhysicalTiles, PhysicalTile[] physicalTiles)
        {
            this.levelsPhysicalTiles = levelsPhysicalTiles;
            this.physicalTiles = physicalTiles;

            InitializeComponent();

            searchOptions.SelectedIndex = 1;
            conveyor.SelectedIndex = 0;
            stairs.SelectedIndex = 0;
            specialTile.SelectedIndex = 0;
            doorFormat.SelectedIndex = 0;

            checkHeightOfBaseTile.SetItemChecked(0, true); heighOfBaseTile.Enabled = true;
            checkHeightOverhead.SetItemChecked(0, true); heightOverhead.Enabled = true;
            checkZCoordOverhead.SetItemChecked(0, true); zCoordOverhead.Enabled = true;
            checkZCoordWater.SetItemChecked(0, true); zCoordWater.Enabled = true;
            checkConveyor.SetItemChecked(0, true); conveyor.Enabled = true;
            checkStairs.SetItemChecked(0, true); stairs.Enabled = true;
            checkSpecialTile.SetItemChecked(0, true); specialTile.Enabled = true;
            checkDoorFormat.SetItemChecked(0, true); doorFormat.Enabled = true;
        }

        private void searchButton_Click(object sender, System.EventArgs e)
        {
            LoadSearch();
        }
        private void LoadSearch()
        {
            searchResults.Items.Clear();

            string withProp = "";
            bool notFound;

            if (searchOptions.SelectedIndex == 0)
                withProp = "Search for physical tiles with ONLY the following properties...\n\n";
            else
                withProp = "Search for physical tiles with ANY of the following properties...\n\n";

            if (checkHeightOfBaseTile.GetItemChecked(0)) withProp += "Height of base tile = " + heighOfBaseTile.Value.ToString() + "\n";
            if (checkHeightOverhead.GetItemChecked(0)) withProp += "Height overhead tile = " + heightOverhead.Value.ToString() + "\n";
            if (checkZCoordOverhead.GetItemChecked(0)) withProp += "Z Coord of overhead tile = " + zCoordOverhead.Value.ToString() + "\n";
            if (checkZCoordWater.GetItemChecked(0)) withProp += "Z Coord of water tile = " + zCoordWater.Value.ToString() + "\n";
            if (physicalTileProperties.GetItemChecked(0)) withProp += "Conveyor belt, fast\n";
            if (physicalTileProperties.GetItemChecked(1)) withProp += "Conveyor belt, normal\n";
            if (physicalTileProperties.GetItemChecked(2)) withProp += "Z Coord + 0.5\n";
            if (physicalTileProperties.GetItemChecked(3)) withProp += "Solid tile\n";
            if (checkConveyor.GetItemChecked(0)) withProp += "Conveyor belt runs..." + conveyor.SelectedItem.ToString() + "\n";
            if (physicalTileEdges.GetItemChecked(0)) withProp += "Upper left edge is solid\n";
            if (physicalTileEdges.GetItemChecked(1)) withProp += "Upper right edge is solid\n";
            if (physicalTileEdges.GetItemChecked(2)) withProp += "Lower left edge is solid\n";
            if (physicalTileEdges.GetItemChecked(3)) withProp += "Lower right edge is solid\n";
            if (checkStairs.GetItemChecked(0)) withProp += "Stairs lead..." + stairs.SelectedItem.ToString() + "\n";
            if (physicalTileQuadrant.GetItemChecked(0)) withProp += "Top quadrant is solid\n";
            if (physicalTileQuadrant.GetItemChecked(1)) withProp += "Left quadrant is solid\n";
            if (physicalTileQuadrant.GetItemChecked(2)) withProp += "Right quadrant is solid\n";
            if (physicalTileQuadrant.GetItemChecked(3)) withProp += "Bottom quadrant is solid\n";
            if (physicalTilePriority3.GetItemChecked(0)) withProp += "Priority 3 for objects on tile edge\n";
            if (physicalTilePriority3.GetItemChecked(1)) withProp += "Priority 3 for objects above tile edge\n";
            if (physicalTilePriority3.GetItemChecked(2)) withProp += "Priority 3 for objects on tile\n";
            if (physicalTilePriority3.GetItemChecked(3)) withProp += "Solid quadrant flag\n";
            if (checkSpecialTile.GetItemChecked(0)) withProp += "Special tile format..." + specialTile.SelectedItem.ToString() + "\n";
            if (unknownBits.GetItemChecked(0)) withProp += "Byte 5, bit 0 set\n";
            if (unknownBits.GetItemChecked(1)) withProp += "Byte 5, bit 1 set\n";
            if (unknownBits.GetItemChecked(2)) withProp += "Byte 5, bit 2 set\n";
            if (unknownBits.GetItemChecked(3)) withProp += "Byte 5, bit 3 set\n";
            if (unknownBits.GetItemChecked(4)) withProp += "Byte 5, bit 4 set\n";
            if (checkDoorFormat.GetItemChecked(0)) withProp += "Door format..." + doorFormat.SelectedItem.ToString() + "\n";

            withProperties.Text = withProp;

            for (int i = 0; i < physicalTiles.Length; i++)
            {
                notFound = false;

                if (checkHeightOfBaseTile.GetItemChecked(0)) { if (heighOfBaseTile.Value != physicalTiles[i].BaseTileHeight) notFound = true; }
                if (checkHeightOverhead.GetItemChecked(0)) { if (heightOverhead.Value != physicalTiles[i].OverheadTileHeight) notFound = true; }
                if (checkZCoordOverhead.GetItemChecked(0)) { if (zCoordOverhead.Value != physicalTiles[i].OverheadTileCoordZ) notFound = true; }
                if (checkZCoordWater.GetItemChecked(0)) { if (zCoordWater.Value != physicalTiles[i].WaterTileCoordZ) notFound = true; }

                if (searchOptions.SelectedIndex == 0)
                {
                    if (physicalTileProperties.GetItemChecked(0) != physicalTiles[i].ConveyorBeltFast) notFound = true;
                    if (physicalTileProperties.GetItemChecked(1) != physicalTiles[i].ConveyorBeltNormal) notFound = true;
                    if (physicalTileProperties.GetItemChecked(2) != physicalTiles[i].BaseTileHeightPlusHalf) notFound = true;
                    if (physicalTileProperties.GetItemChecked(3) != physicalTiles[i].SolidTile) notFound = true;
                }
                else
                {
                    if (physicalTileProperties.GetItemChecked(0)) { if (!physicalTiles[i].ConveyorBeltFast) notFound = true; }
                    if (physicalTileProperties.GetItemChecked(1)) { if (!physicalTiles[i].ConveyorBeltNormal) notFound = true; }
                    if (physicalTileProperties.GetItemChecked(2)) { if (!physicalTiles[i].BaseTileHeightPlusHalf) notFound = true; }
                    if (physicalTileProperties.GetItemChecked(3)) { if (!physicalTiles[i].SolidTile) notFound = true; }
                }

                if (checkConveyor.GetItemChecked(0)) { if (physicalTiles[i].ConveryorBeltDirection != conveyor.SelectedIndex) notFound = true; }

                if (searchOptions.SelectedIndex == 0)
                {
                    if (physicalTileEdges.GetItemChecked(0) != physicalTiles[i].SolidUpperLeftEdge) notFound = true;
                    if (physicalTileEdges.GetItemChecked(1) != physicalTiles[i].SolidUpperRightEdge) notFound = true;
                    if (physicalTileEdges.GetItemChecked(2) != physicalTiles[i].SolidLowerLeftEdge) notFound = true;
                    if (physicalTileEdges.GetItemChecked(3) != physicalTiles[i].SolidLowerRightEdge) notFound = true;
                }
                else
                {
                    if (physicalTileEdges.GetItemChecked(0)) { if (!physicalTiles[i].SolidUpperLeftEdge) notFound = true; }
                    if (physicalTileEdges.GetItemChecked(1)) { if (!physicalTiles[i].SolidUpperRightEdge) notFound = true; }
                    if (physicalTileEdges.GetItemChecked(2)) { if (!physicalTiles[i].SolidLowerLeftEdge) notFound = true; }
                    if (physicalTileEdges.GetItemChecked(3)) { if (!physicalTiles[i].SolidLowerRightEdge) notFound = true; }
                }

                if (checkStairs.GetItemChecked(0)) { if (physicalTiles[i].StairsDirection != stairs.SelectedIndex) notFound = true; }

                if (searchOptions.SelectedIndex == 0)
                {
                    if (physicalTileQuadrant.GetItemChecked(0) != physicalTiles[i].SolidTopQuadrant) notFound = true;
                    if (physicalTileQuadrant.GetItemChecked(1) != physicalTiles[i].SolidLeftQuadrant) notFound = true;
                    if (physicalTileQuadrant.GetItemChecked(2) != physicalTiles[i].SolidRightQuadrant) notFound = true;
                    if (physicalTileQuadrant.GetItemChecked(3) != physicalTiles[i].SolidBottomQuadrant) notFound = true;

                    if (physicalTilePriority3.GetItemChecked(0) != physicalTiles[i].ObjectOnEdgePriority3) notFound = true;
                    if (physicalTilePriority3.GetItemChecked(1) != physicalTiles[i].ObjectAboveEdgePriority3) notFound = true;
                    if (physicalTilePriority3.GetItemChecked(2) != physicalTiles[i].ObjectOnTilePriority3) notFound = true;
                    if (physicalTilePriority3.GetItemChecked(3) != physicalTiles[i].SolidQuadrantFlag) notFound = true;
                }
                else
                {
                    if (physicalTileQuadrant.GetItemChecked(0)) { if (!physicalTiles[i].SolidTopQuadrant) notFound = true; }
                    if (physicalTileQuadrant.GetItemChecked(1)) { if (!physicalTiles[i].SolidLeftQuadrant) notFound = true; }
                    if (physicalTileQuadrant.GetItemChecked(2)) { if (!physicalTiles[i].SolidRightQuadrant) notFound = true; }
                    if (physicalTileQuadrant.GetItemChecked(3)) { if (!physicalTiles[i].SolidBottomQuadrant) notFound = true; }

                    if (physicalTilePriority3.GetItemChecked(0)) { if (!physicalTiles[i].ObjectOnEdgePriority3) notFound = true; }
                    if (physicalTilePriority3.GetItemChecked(1)) { if (!physicalTiles[i].ObjectAboveEdgePriority3) notFound = true; }
                    if (physicalTilePriority3.GetItemChecked(2)) { if (!physicalTiles[i].ObjectOnTilePriority3) notFound = true; }
                    if (physicalTilePriority3.GetItemChecked(3)) { if (!physicalTiles[i].SolidQuadrantFlag) notFound = true; }
                }

                if (checkSpecialTile.GetItemChecked(0)) { if (physicalTiles[i].SpecialTileFormat != specialTile.SelectedIndex) notFound = true; }

                if (searchOptions.SelectedIndex == 0)
                {
                    if (unknownBits.GetItemChecked(0) != physicalTiles[i].Byte5b0) notFound = true;
                    if (unknownBits.GetItemChecked(1) != physicalTiles[i].Byte5b1) notFound = true;
                    if (unknownBits.GetItemChecked(2) != physicalTiles[i].Byte5b2) notFound = true;
                    if (unknownBits.GetItemChecked(3) != physicalTiles[i].Byte5b3) notFound = true;
                    if (unknownBits.GetItemChecked(4) != physicalTiles[i].Byte5b4) notFound = true;
                }
                else
                {
                    if (unknownBits.GetItemChecked(0)) { if (!physicalTiles[i].Byte5b0) notFound = true; }
                    if (unknownBits.GetItemChecked(1)) { if (!physicalTiles[i].Byte5b1) notFound = true; }
                    if (unknownBits.GetItemChecked(2)) { if (!physicalTiles[i].Byte5b2) notFound = true; }
                    if (unknownBits.GetItemChecked(3)) { if (!physicalTiles[i].Byte5b3) notFound = true; }
                    if (unknownBits.GetItemChecked(4)) { if (!physicalTiles[i].Byte5b4) notFound = true; }
                }

                if (checkDoorFormat.GetItemChecked(0)) { if (doorFormat.SelectedIndex != physicalTiles[i].Door) notFound = true; }

                if (!notFound)
                    searchResults.Items.Add("Physical Tile #" + i.ToString());
            }
        }
        private void checkHeightOfBaseTile_SelectedIndexChanged(object sender, EventArgs e)
        {
            heighOfBaseTile.Enabled = checkHeightOfBaseTile.GetItemChecked(0);
        }
        private void checkHeightOverhead_SelectedIndexChanged(object sender, EventArgs e)
        {
            heightOverhead.Enabled = checkHeightOverhead.GetItemChecked(0);
        }
        private void checkZCoordOverhead_SelectedIndexChanged(object sender, EventArgs e)
        {
            zCoordOverhead.Enabled = checkZCoordOverhead.GetItemChecked(0);
        }
        private void checkZCoordWater_SelectedIndexChanged(object sender, EventArgs e)
        {
            zCoordWater.Enabled = checkZCoordWater.GetItemChecked(0);
        }
        private void checkConveyor_SelectedIndexChanged(object sender, EventArgs e)
        {
            conveyor.Enabled = checkConveyor.GetItemChecked(0);
        }
        private void checkStairs_SelectedIndexChanged(object sender, EventArgs e)
        {
            stairs.Enabled = checkStairs.GetItemChecked(0);
        }
        private void checkSpecialTile_SelectedIndexChanged(object sender, EventArgs e)
        {
            specialTile.Enabled = checkSpecialTile.GetItemChecked(0);
        }
        private void checkDoorFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            doorFormat.Enabled = checkDoorFormat.GetItemChecked(0);
        }

        private void searchOptions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void searchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            levelsPhysicalTiles.Index = Convert.ToInt32(searchResults.SelectedItem.ToString().Substring(15));
        }
    }
}