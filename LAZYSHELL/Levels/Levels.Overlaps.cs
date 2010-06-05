using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public partial class Levels
    {
        #region Variables

        private LevelOverlaps overlaps; // Overlaps for the current level
        private OverlapTileset overlapTileset;
        private Bitmap overlapsImage;
        private int[] overlapsPixels;

        #endregion

        #region Methods

        private void InitializeOverlapProperties()
        {
            updatingProperties = true;

            this.overlapFieldTree.Nodes.Clear();

            for (int i = 0; i < overlaps.NumberOfOverlaps; i++)
            {
                this.overlapFieldTree.Nodes.Add(new TreeNode("OVERLAP #" + i.ToString()));
            }

            if (overlapFieldTree.Nodes.Count > 0)
                this.overlapFieldTree.SelectedNode = this.overlapFieldTree.Nodes[0];

            if (overlaps.NumberOfOverlaps != 0 && this.overlapFieldTree.SelectedNode != null)
            {
                overlaps.CurrentOverlap = this.overlapFieldTree.SelectedNode.Index;
                this.overlapCoordX.Value = overlaps.CoordX;
                this.overlapCoordY.Value = overlaps.CoordY;
                this.overlapCoordZ.Value = overlaps.CoordZ;
                this.overlapCoordZPlusHalf.Checked = overlaps.B1b7;
                this.overlapType.Value = overlaps.Type;
                this.overlapUnknownBits.SetItemChecked(0, overlaps.B0b7);
                this.overlapUnknownBits.SetItemChecked(1, overlaps.B2b5);
                this.overlapUnknownBits.SetItemChecked(2, overlaps.B2b6);
                this.overlapUnknownBits.SetItemChecked(3, overlaps.B2b7);

                this.overlapCoordX.Enabled = true;
                this.overlapCoordY.Enabled = true;
                this.overlapCoordZ.Enabled = true;
                this.overlapCoordZPlusHalf.Enabled = true;
                this.overlapType.Enabled = true;
                this.overlapUnknownBits.Enabled = true;
                this.overlapShowTileset.Enabled = true;
            }
            else
            {
                this.overlapCoordX.Enabled = false;
                this.overlapCoordY.Enabled = false;
                this.overlapCoordZ.Enabled = false;
                this.overlapCoordZPlusHalf.Enabled = false;
                this.overlapType.Enabled = false;
                this.overlapUnknownBits.Enabled = false;
                this.overlapShowTileset.Enabled = false;

                this.overlapCoordX.Value = 0;
                this.overlapCoordY.Value = 0;
                this.overlapCoordZ.Value = 0;
                this.overlapCoordZPlusHalf.Checked = false;
                this.overlapType.Value = 0;
                this.overlapUnknownBits.SetItemChecked(0, false);
                this.overlapUnknownBits.SetItemChecked(1, false);
                this.overlapUnknownBits.SetItemChecked(2, false);
                this.overlapUnknownBits.SetItemChecked(3, false);
            }

            pictureBoxOverlaps.Invalidate();

            updatingProperties = false;
        }
        private void RefreshOverlapProperties()
        {
            updatingLevel = true;

            if (overlaps.NumberOfOverlaps != 0 && this.overlapFieldTree.SelectedNode != null)
            {
                overlaps.CurrentOverlap = this.overlapFieldTree.SelectedNode.Index;
                this.overlapCoordX.Value = overlaps.CoordX;
                this.overlapCoordY.Value = overlaps.CoordY;
                this.overlapCoordZ.Value = overlaps.CoordZ;
                this.overlapCoordZPlusHalf.Checked = overlaps.B1b7;
                this.overlapType.Value = overlaps.Type;
                this.overlapUnknownBits.SetItemChecked(0, overlaps.B0b7);
                this.overlapUnknownBits.SetItemChecked(1, overlaps.B2b5);
                this.overlapUnknownBits.SetItemChecked(2, overlaps.B2b6);
                this.overlapUnknownBits.SetItemChecked(3, overlaps.B2b7);

                this.overlapCoordX.Enabled = true;
                this.overlapCoordY.Enabled = true;
                this.overlapCoordZ.Enabled = true;
                this.overlapCoordZPlusHalf.Enabled = true;
                this.overlapType.Enabled = true;
                this.overlapUnknownBits.Enabled = true;
                this.overlapShowTileset.Enabled = true;
            }
            else
            {
                this.overlapCoordX.Enabled = false;
                this.overlapCoordY.Enabled = false;
                this.overlapCoordZ.Enabled = false;
                this.overlapCoordZPlusHalf.Enabled = false;
                this.overlapType.Enabled = false;
                this.overlapUnknownBits.Enabled = false;
                this.overlapShowTileset.Enabled = false;

                this.overlapCoordX.Value = 0;
                this.overlapCoordY.Value = 0;
                this.overlapCoordZ.Value = 0;
                this.overlapCoordZPlusHalf.Checked = false;
                this.overlapType.Value = 0;
                this.overlapUnknownBits.SetItemChecked(0, false);
                this.overlapUnknownBits.SetItemChecked(1, false);
                this.overlapUnknownBits.SetItemChecked(2, false);
                this.overlapUnknownBits.SetItemChecked(3, false);
            }

            pictureBoxOverlaps.Invalidate();

            updatingLevel = false;
        }

        public bool CalculateFreeOverlapSpace(bool showMessageBox)
        {
            int used = 0;

            for (int i = 0; i < 512; i++)
            {
                for (int j = 0; j < levels[i].LevelOverlaps.NumberOfOverlaps; j++)
                {
                    used += 4;

                    if ((used + 4) > 0x11B8)
                    {
                        if (showMessageBox)
                            MessageBox.Show("Could not insert the field. The total number of overlaps for all levels has exceeded the maximum allotted space.",
                                "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                }
            }

            return false;
        }
        private void SetOverOverlap()
        {
            int currentOverlap = overlaps.CurrentOverlap;
            for (int i = 0; i < overlapFieldTree.Nodes.Count; i++)
            {
                overlaps.CurrentOverlap = i;
                if (overlaps.CoordX == orthCoordX && overlaps.CoordY == orthCoordY)
                {
                    this.pictureBoxLevel.Cursor = System.Windows.Forms.Cursors.Hand;
                    overOverlap = i + 1;
                    isOverSomething = true;
                    break;
                }
                else
                {
                    this.pictureBoxLevel.Cursor = System.Windows.Forms.Cursors.Arrow;
                    overOverlap = 0;
                    isOverSomething = false;
                }
            }
            overlaps.CurrentOverlap = currentOverlap;
        }

        #endregion

        #region Event Handlers

        private void overlapFieldTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            overlaps.CurrentOverlap = this.overlapFieldTree.SelectedNode.Index;
            overlaps.SelectedOverlap = this.overlapFieldTree.SelectedNode.Index;

            overlay.DrawLevelOverlaps(overlaps, overlapTileset);
            pictureBoxLevel.Invalidate();

            overlaps.CurrentOverlap = this.overlapFieldTree.SelectedNode.Index;
            RefreshOverlapProperties();
        }
        private void overlapFieldInsert_Click(object sender, EventArgs e)
        {
            Point o = new Point(Math.Abs(pictureBoxLevel.Left), Math.Abs(pictureBoxLevel.Top));
            Point p = new Point(physicalMap.OrthCoordsX[o.Y * 1024 + o.X] + 2, physicalMap.OrthCoordsY[o.Y * 1024 + o.X] + 4);
            if (!CalculateFreeOverlapSpace(true))
            {
                this.overlapFieldTree.Focus();
                if (overlaps.NumberOfOverlaps < 28)
                {
                    if (overlapFieldTree.Nodes.Count > 0)
                        overlaps.AddNewOverlap(overlapFieldTree.SelectedNode.Index + 1, p);
                    else
                        overlaps.AddNewOverlap(0, p);

                    int reselect;

                    if (overlapFieldTree.Nodes.Count > 0)
                        reselect = overlapFieldTree.SelectedNode.Index;
                    else
                        reselect = -1;

                    overlapFieldTree.BeginUpdate();
                    this.overlapFieldTree.Nodes.Clear();

                    for (int i = 0; i < overlaps.NumberOfOverlaps; i++)
                        this.overlapFieldTree.Nodes.Add(new TreeNode("OVERLAP #" + i.ToString()));

                    this.overlapFieldTree.SelectedNode = this.overlapFieldTree.Nodes[reselect + 1];
                    overlapFieldTree.EndUpdate();
                }
                else
                    MessageBox.Show("Could not insert any more overlaps. The maximum number of overlaps allowed is 28.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void overlapFieldDelete_Click(object sender, EventArgs e)
        {
            this.overlapFieldTree.Focus();
            if (this.overlapFieldTree.SelectedNode != null && overlaps.CurrentOverlap == this.overlapFieldTree.SelectedNode.Index)
            {
                overlaps.RemoveCurrentOverlap();

                int reselect = overlapFieldTree.SelectedNode.Index;
                if (reselect == overlapFieldTree.Nodes.Count - 1)
                    reselect--;

                overlapFieldTree.BeginUpdate();
                this.overlapFieldTree.Nodes.Clear();

                for (int i = 0; i < overlaps.NumberOfOverlaps; i++)
                    this.overlapFieldTree.Nodes.Add(new TreeNode("OVERLAP #" + i.ToString()));

                if (overlapFieldTree.Nodes.Count > 0)
                    this.overlapFieldTree.SelectedNode = this.overlapFieldTree.Nodes[reselect];
                else
                {
                    this.overlapFieldTree.SelectedNode = null;

                    overlay.DrawLevelOverlaps(overlaps, overlapTileset);
                    pictureBoxLevel.Invalidate();

                    RefreshOverlapProperties();
                }
                overlapFieldTree.EndUpdate();
            }
        }
        private void overlapCoordX_ValueChanged(object sender, EventArgs e)
        {
            if (updatingLevel) return;

            overlaps.CurrentOverlap = this.overlapFieldTree.SelectedNode.Index;
            overlaps.CoordX = (byte)this.overlapCoordX.Value;

            if (!waitBothCoords)
            {
                overlay.DrawLevelOverlaps(overlaps, overlapTileset);
                pictureBoxLevel.Invalidate();
            }

            overlaps.CurrentOverlap = this.overlapFieldTree.SelectedNode.Index;
        }
        private void overlapCoordY_ValueChanged(object sender, EventArgs e)
        {
            if (updatingLevel) return;

            overlaps.CurrentOverlap = this.overlapFieldTree.SelectedNode.Index;
            overlaps.CoordY = (byte)this.overlapCoordY.Value;

            if (!waitBothCoords)
            {
                overlay.DrawLevelOverlaps(overlaps, overlapTileset);
                pictureBoxLevel.Invalidate();
            }

            overlaps.CurrentOverlap = this.overlapFieldTree.SelectedNode.Index;
        }
        private void overlapCoordZ_ValueChanged(object sender, EventArgs e)
        {
            if (updatingLevel) return;

            overlaps.CurrentOverlap = this.overlapFieldTree.SelectedNode.Index;
            overlaps.CoordZ = (byte)this.overlapCoordZ.Value;

            overlay.DrawLevelOverlaps(overlaps, overlapTileset);
            pictureBoxLevel.Invalidate();

            overlaps.CurrentOverlap = this.overlapFieldTree.SelectedNode.Index;
        }
        private void overlapCoordZPlusHalf_CheckedChanged(object sender, EventArgs e)
        {
            overlapCoordZPlusHalf.ForeColor = overlapCoordZPlusHalf.Checked ? Color.Black : Color.Gray;
            
            if (updatingLevel) return;

            overlaps.CurrentOverlap = this.overlapFieldTree.SelectedNode.Index;
            overlaps.B1b7 = this.overlapCoordZPlusHalf.Checked;

            overlay.DrawLevelOverlaps(overlaps, overlapTileset);
            pictureBoxLevel.Invalidate();

            overlaps.CurrentOverlap = this.overlapFieldTree.SelectedNode.Index;
        }
        private void overlapType_ValueChanged(object sender, EventArgs e)
        {
            if (updatingLevel) return;

            overlaps.CurrentOverlap = this.overlapFieldTree.SelectedNode.Index;
            overlaps.Type = (byte)this.overlapType.Value;

            overlay.DrawLevelOverlaps(overlaps, overlapTileset);
            pictureBoxLevel.Invalidate();

            overlaps.CurrentOverlap = this.overlapFieldTree.SelectedNode.Index;

            pictureBoxOverlaps.Invalidate();
        }
        private void overlapUnknownBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingLevel) return;

            overlaps.B0b7 = overlapUnknownBits.GetItemChecked(0);
            overlaps.B2b5 = overlapUnknownBits.GetItemChecked(1);
            overlaps.B2b6 = overlapUnknownBits.GetItemChecked(2);
            overlaps.B2b7 = overlapUnknownBits.GetItemChecked(3);
        }

        private void overlapShowTileset_Click(object sender, EventArgs e)
        {
            panelOverlapTileset.Visible = !panelOverlapTileset.Visible;
        }
        private void pictureBoxOverlaps_MouseClick(object sender, MouseEventArgs e)
        {
            overlapType.Value = (e.Y / 32) * 8 + (e.X / 32);
        }
        private void pictureBoxOverlaps_Paint(object sender, PaintEventArgs e)
        {
            if (overlapsImage == null)
            {
                overlapsPixels = overlapTileset.GetTilesetPixelArray(overlapTileset.OverlapTiles);
                overlapsImage = Drawing.PixelArrayToImage(overlapsPixels, 256, 416);
            }

            e.Graphics.DrawImage(overlapsImage, 0, 0);

            if (state.CartesianGrid)
                overlay.DrawCartographicGrid(e.Graphics, Color.Gray, new Size(256, 416), new Size(32, 32), 1);

            int x = (int)overlapType.Value % 8 * 32;
            int y = (int)overlapType.Value / 8 * 32;
            overlay.DrawSelectionBox(e.Graphics, new Point(x + 32, y + 32), new Point(x, y), 1);
        }

        #endregion
    }
}
