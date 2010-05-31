using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public partial class Levels
    {
        #region Variables

        private PhysicalTile[] physicalTiles;

        private int[] physicalTilePixels;
        private Bitmap physicalTileImage;

        private int[] quadBasePixels = new int[16 * 8];
        private int[] quadBlockPixels = new int[16 * 24];
        private int[] halfQuadBlockPixels = new int[16 * 16];
        private int[] stairsUpRightLowPixels = new int[16 * 24];
        private int[] stairsUpRightHighPixels = new int[16 * 24];
        private int[] stairsUpLeftLowPixels = new int[16 * 24];
        private int[] stairsUpLeftHighPixels = new int[16 * 24];
        private int[] fieldBasePixels = new int[32 * 16];
        private int[] fieldBlockPixels = new int[32 * 32];

        #endregion

        #region Methods

        public void DrawPhysicalTiles()
        {
            Bitmap quadBase = global::LAZYSHELL.Properties.Resources.quadBase;
            Bitmap quadBlock = global::LAZYSHELL.Properties.Resources.quadBlock;
            Bitmap halfQuadBlock = global::LAZYSHELL.Properties.Resources.halfQuadBlock;
            Bitmap stairsUpLeftLow = global::LAZYSHELL.Properties.Resources.stairsUpLeftLow;
            Bitmap stairsUpLeftHigh = global::LAZYSHELL.Properties.Resources.stairsUpLeftHigh;
            Bitmap stairsUpRightLow = global::LAZYSHELL.Properties.Resources.stairsUpRightLow;
            Bitmap stairsUpRightHigh = global::LAZYSHELL.Properties.Resources.stairsUpRightHigh;
            Bitmap fieldBase = global::LAZYSHELL.Properties.Resources.fieldBase;
            Bitmap fieldBlock = global::LAZYSHELL.Properties.Resources.fieldBlock;

            for (int y = 0; y < 32; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    if (y < 8) quadBasePixels[y * 16 + x] = quadBase.GetPixel(x, y).ToArgb();
                    if (y < 16) halfQuadBlockPixels[y * 16 + x] = halfQuadBlock.GetPixel(x, y).ToArgb();
                    if (y < 24) quadBlockPixels[y * 16 + x] = quadBlock.GetPixel(x, y).ToArgb();
                    if (y < 24) stairsUpLeftLowPixels[y * 16 + x] = stairsUpLeftLow.GetPixel(x, y).ToArgb();
                    if (y < 24) stairsUpLeftHighPixels[y * 16 + x] = stairsUpLeftHigh.GetPixel(x, y).ToArgb();
                    if (y < 24) stairsUpRightLowPixels[y * 16 + x] = stairsUpRightLow.GetPixel(x, y).ToArgb();
                    if (y < 24) stairsUpRightHighPixels[y * 16 + x] = stairsUpRightHigh.GetPixel(x, y).ToArgb();
                    if (y < 16) fieldBasePixels[y * 16 + x] = fieldBase.GetPixel(x, y).ToArgb();
                    fieldBlockPixels[y * 16 + x] = fieldBlock.GetPixel(x, y).ToArgb();

                    if (y < 8 && quadBasePixels[y * 16 + x] == Color.White.ToArgb()) quadBasePixels[y * 16 + x] = 0;
                    if (y < 16 && halfQuadBlockPixels[y * 16 + x] == Color.White.ToArgb()) halfQuadBlockPixels[y * 16 + x] = 0;
                    if (y < 24 && quadBlockPixels[y * 16 + x] == Color.White.ToArgb()) quadBlockPixels[y * 16 + x] = 0;
                    if (y < 24 && stairsUpLeftLowPixels[y * 16 + x] == Color.White.ToArgb()) stairsUpLeftLowPixels[y * 16 + x] = 0;
                    if (y < 24 && stairsUpLeftHighPixels[y * 16 + x] == Color.White.ToArgb()) stairsUpLeftHighPixels[y * 16 + x] = 0;
                    if (y < 24 && stairsUpRightLowPixels[y * 16 + x] == Color.White.ToArgb()) stairsUpRightLowPixels[y * 16 + x] = 0;
                    if (y < 24 && stairsUpRightHighPixels[y * 16 + x] == Color.White.ToArgb()) stairsUpRightHighPixels[y * 16 + x] = 0;
                    if (y < 16 && fieldBasePixels[y * 16 + x] == Color.White.ToArgb()) fieldBasePixels[y * 16 + x] = 0;
                    if (fieldBlockPixels[y * 16 + x] == Color.White.ToArgb()) fieldBlockPixels[y * 16 + x] = 0;
                }
            }
        }
        private void UpdatePhysicalTile()
        {
            int currentPhysicalTile = (int)physicalTileNum.Value;

            physicalTileBaseHeight.Value = physicalTiles[currentPhysicalTile].BaseTileHeight;
            physicalTileOverHeight.Value = physicalTiles[currentPhysicalTile].OverheadTileHeight;
            physicalTileOverZCoord.Value = physicalTiles[currentPhysicalTile].OverheadTileCoordZ;
            physicalTileWaterZCoord.Value = physicalTiles[currentPhysicalTile].WaterTileCoordZ;
            physicalTileProperties.SetItemChecked(0, physicalTiles[currentPhysicalTile].ConveyorBeltFast);
            physicalTileProperties.SetItemChecked(1, physicalTiles[currentPhysicalTile].ConveyorBeltNormal);
            physicalTileProperties.SetItemChecked(2, physicalTiles[currentPhysicalTile].BaseTileHeightPlusHalf);
            physicalTileProperties.SetItemChecked(3, physicalTiles[currentPhysicalTile].SolidTile);
            physicalTileConveyor.SelectedIndex = physicalTiles[currentPhysicalTile].ConveryorBeltDirection;
            physicalTileEdges.SetItemChecked(0, physicalTiles[currentPhysicalTile].SolidUpperLeftEdge);
            physicalTileEdges.SetItemChecked(1, physicalTiles[currentPhysicalTile].SolidUpperRightEdge);
            physicalTileEdges.SetItemChecked(2, physicalTiles[currentPhysicalTile].SolidLowerLeftEdge);
            physicalTileEdges.SetItemChecked(3, physicalTiles[currentPhysicalTile].SolidLowerRightEdge);
            physicalTileStairs.SelectedIndex = physicalTiles[currentPhysicalTile].StairsDirection;
            physicalTileQuadrant.SetItemChecked(0, physicalTiles[currentPhysicalTile].SolidTopQuadrant);
            physicalTileQuadrant.SetItemChecked(1, physicalTiles[currentPhysicalTile].SolidLeftQuadrant);
            physicalTileQuadrant.SetItemChecked(2, physicalTiles[currentPhysicalTile].SolidRightQuadrant);
            physicalTileQuadrant.SetItemChecked(3, physicalTiles[currentPhysicalTile].SolidBottomQuadrant);
            physicalTilePriority3.SetItemChecked(0, physicalTiles[currentPhysicalTile].ObjectOnEdgePriority3);
            physicalTilePriority3.SetItemChecked(1, physicalTiles[currentPhysicalTile].ObjectAboveEdgePriority3);
            physicalTilePriority3.SetItemChecked(2, physicalTiles[currentPhysicalTile].ObjectOnTilePriority3);
            physicalTilePriority3.SetItemChecked(3, physicalTiles[currentPhysicalTile].SolidQuadrantFlag);
            physicalTileSpecialTile.SelectedIndex = physicalTiles[currentPhysicalTile].SpecialTileFormat;
            physicalTileUnknownBits.SetItemChecked(0, physicalTiles[currentPhysicalTile].Byte5b0);
            physicalTileUnknownBits.SetItemChecked(1, physicalTiles[currentPhysicalTile].Byte5b1);
            physicalTileUnknownBits.SetItemChecked(2, physicalTiles[currentPhysicalTile].Byte5b2);
            physicalTileUnknownBits.SetItemChecked(3, physicalTiles[currentPhysicalTile].Byte5b3);
            physicalTileUnknownBits.SetItemChecked(4, physicalTiles[currentPhysicalTile].Byte5b4);
            physicalTileDoorFormat.SelectedIndex = physicalTiles[currentPhysicalTile].Door;

            physicalTilePixels = physicalTiles[currentPhysicalTile].DrawPhysicalTile(quadBasePixels, quadBlockPixels, halfQuadBlockPixels, stairsUpLeftLowPixels, stairsUpLeftHighPixels, stairsUpRightLowPixels, stairsUpRightHighPixels);
            physicalTileImage = new Bitmap(DrawImageFromIntArr(physicalTilePixels, 32, 784));
            pictureBoxPhysicalTile.Invalidate();
        }

        #endregion

        #region Event Handlers

        private void physicalTileNum_ValueChanged(object sender, EventArgs e)
        {
            UpdatePhysicalTile();
        }
        private void physicalTileQuadrant_SelectedIndexChanged(object sender, EventArgs e)
        {
            int physTile = (int)physicalTileNum.Value;
            physicalTiles[physTile].SolidTopQuadrant = physicalTileQuadrant.GetItemChecked(0);
            physicalTiles[physTile].SolidLeftQuadrant = physicalTileQuadrant.GetItemChecked(1);
            physicalTiles[physTile].SolidRightQuadrant = physicalTileQuadrant.GetItemChecked(2);
            physicalTiles[physTile].SolidBottomQuadrant = physicalTileQuadrant.GetItemChecked(3);
            UpdatePhysicalTile();
        }
        private void physicalTileSpecialTile_SelectedIndexChanged(object sender, EventArgs e)
        {
            int physTile = (int)physicalTileNum.Value;
            physicalTiles[physTile].SpecialTileFormat = (byte)physicalTileSpecialTile.SelectedIndex;
            UpdatePhysicalTile();
        }
        private void physicalTileStairs_SelectedIndexChanged(object sender, EventArgs e)
        {
            int physTile = (int)physicalTileNum.Value;
            physicalTiles[physTile].StairsDirection = (byte)physicalTileStairs.SelectedIndex;
            UpdatePhysicalTile();
        }
        private void physicalTileConveyor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int physTile = (int)physicalTileNum.Value;
            physicalTiles[physTile].ConveryorBeltDirection = (byte)physicalTileConveyor.SelectedIndex;
            UpdatePhysicalTile();
        }
        private void physicalTilePriority3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int physTile = (int)physicalTileNum.Value;
            physicalTiles[physTile].ObjectOnEdgePriority3 = physicalTilePriority3.GetItemChecked(0);
            physicalTiles[physTile].ObjectAboveEdgePriority3 = physicalTilePriority3.GetItemChecked(1);
            physicalTiles[physTile].ObjectOnTilePriority3 = physicalTilePriority3.GetItemChecked(2);
            physicalTiles[physTile].SolidQuadrantFlag = physicalTilePriority3.GetItemChecked(3);
            UpdatePhysicalTile();
        }
        private void physicalTileEdges_SelectedIndexChanged(object sender, EventArgs e)
        {
            int physTile = (int)physicalTileNum.Value;
            physicalTiles[physTile].SolidUpperLeftEdge = physicalTileEdges.GetItemChecked(0);
            physicalTiles[physTile].SolidUpperRightEdge = physicalTileEdges.GetItemChecked(1);
            physicalTiles[physTile].SolidLowerLeftEdge = physicalTileEdges.GetItemChecked(2);
            physicalTiles[physTile].SolidLowerRightEdge = physicalTileEdges.GetItemChecked(3);
            UpdatePhysicalTile();
        }
        private void physicalTileProperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            int physTile = (int)physicalTileNum.Value;
            physicalTiles[physTile].ConveyorBeltFast = physicalTileProperties.GetItemChecked(0);
            physicalTiles[physTile].ConveyorBeltNormal = physicalTileProperties.GetItemChecked(1);
            physicalTiles[physTile].BaseTileHeightPlusHalf = physicalTileProperties.GetItemChecked(2);
            physicalTiles[physTile].SolidTile = physicalTileProperties.GetItemChecked(3);
            if (!physicalTileProperties.GetItemChecked(2))
                physicalTiles[physTile].PhysicalTileTotalHeight = (int)((physicalTileBaseHeight.Value + physicalTileOverZCoord.Value + physicalTileOverHeight.Value) * 16);
            else if (physicalTileProperties.GetItemChecked(2))
                physicalTiles[physTile].PhysicalTileTotalHeight = (int)((physicalTileBaseHeight.Value + physicalTileOverZCoord.Value + physicalTileOverHeight.Value) * 16 + 8);
            UpdatePhysicalTile();
        }
        private void physicalTileWaterZCoord_ValueChanged(object sender, EventArgs e)
        {
            int physTile = (int)physicalTileNum.Value;
            physicalTiles[physTile].WaterTileCoordZ = (byte)physicalTileWaterZCoord.Value;
            UpdatePhysicalTile();
        }
        private void physicalTileOverHeight_ValueChanged(object sender, EventArgs e)
        {
            int physTile = (int)physicalTileNum.Value;
            physicalTiles[physTile].OverheadTileHeight = (byte)physicalTileOverHeight.Value;
            if (!physicalTileProperties.GetItemChecked(2))
                physicalTiles[physTile].PhysicalTileTotalHeight = (int)((physicalTileBaseHeight.Value + physicalTileOverZCoord.Value + physicalTileOverHeight.Value) * 16);
            else if (physicalTileProperties.GetItemChecked(2))
                physicalTiles[physTile].PhysicalTileTotalHeight = (int)((physicalTileBaseHeight.Value + physicalTileOverZCoord.Value + physicalTileOverHeight.Value) * 16 + 8);
            UpdatePhysicalTile();
        }
        private void physicalTileOverZCoord_ValueChanged(object sender, EventArgs e)
        {
            int physTile = (int)physicalTileNum.Value;
            physicalTiles[physTile].OverheadTileCoordZ = (byte)physicalTileOverZCoord.Value;
            if (!physicalTileProperties.GetItemChecked(2))
                physicalTiles[physTile].PhysicalTileTotalHeight = (int)((physicalTileBaseHeight.Value + physicalTileOverZCoord.Value + physicalTileOverHeight.Value) * 16);
            else if (physicalTileProperties.GetItemChecked(2))
                physicalTiles[physTile].PhysicalTileTotalHeight = (int)((physicalTileBaseHeight.Value + physicalTileOverZCoord.Value + physicalTileOverHeight.Value) * 16 + 8);
            UpdatePhysicalTile();
        }
        private void physicalTileBaseHeight_ValueChanged(object sender, EventArgs e)
        {
            int physTile = (int)physicalTileNum.Value;
            physicalTiles[physTile].BaseTileHeight = (byte)physicalTileBaseHeight.Value;
            if (!physicalTileProperties.GetItemChecked(2))
                physicalTiles[physTile].PhysicalTileTotalHeight = (int)((physicalTileBaseHeight.Value + physicalTileOverZCoord.Value + physicalTileOverHeight.Value) * 16);
            else if (physicalTileProperties.GetItemChecked(2))
                physicalTiles[physTile].PhysicalTileTotalHeight = (int)((physicalTileBaseHeight.Value + physicalTileOverZCoord.Value + physicalTileOverHeight.Value) * 16 + 8);
            UpdatePhysicalTile();
        }
        private void physicalTileSearchButton_Click(object sender, System.EventArgs e)
        {
            // Open search physical tile
            Form searchPhysTile = new SearchPhysicalTile(this, physicalTiles);
            searchPhysTile.Show();
        }

        private void pictureBoxPhysicalTile_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxPhysicalTile.Focus();
        }
        private void pictureBoxPhysicalTile_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(physicalTileImage, 0, 0);
        }
        private void pictureBoxPhysicalTile_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //switch (e.KeyData)
            //{
            //    case Keys.PageDown: pictureBoxPhysicalTile.Top = -159; break;
            //    case Keys.PageUp: pictureBoxPhysicalTile.Top = 0; break;
            //    case Keys.Down:
            //        if (pictureBoxPhysicalTile.Bottom < -16)
            //            pictureBoxPhysicalTile.Top -= 16;
            //        else
            //            pictureBoxPhysicalTile.Top += pictureBoxPhysicalTile.Bottom;
            //        break;
            //    case Keys.Up:
            //        if (pictureBoxPhysicalTile.Top < -16)
            //            pictureBoxPhysicalTile.Top += 16;
            //        else
            //            pictureBoxPhysicalTile.Top = 0;
            //        break;
            //}
        }

        #endregion
    }
}
