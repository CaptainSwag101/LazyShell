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

        private LevelExits exits; // Exits for the current level
        private Object copyExit;

        #endregion

        #region Methods

        private void InitializeExitFieldProperties()
        {
            updatingProperties = true;

            this.exitsFieldTree.Nodes.Clear();

            for (int i = 0; i < exits.NumberOfExits; i++)
            {
                this.exitsFieldTree.Nodes.Add(new TreeNode("EXIT #" + i.ToString()));
            }

            if (exitsFieldTree.Nodes.Count > 0)
                this.exitsFieldTree.SelectedNode = this.exitsFieldTree.Nodes[0];

            if (exits.NumberOfExits != 0 && this.exitsFieldTree.SelectedNode != null)
            {
                exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
                this.exitType.SelectedIndex = exits.ExitType;
                SetExitDestinationItems();
                this.exitDest.SelectedIndex = exits.Destination;
                this.exitsShowMessage.Checked = exits.ShowMessage;
                this.exitX.Value = exits.X;
                this.exitY.Value = exits.Y;
                this.exitZ.Value = exits.FieldCoordZ;
                this.exitFace.SelectedIndex = exits.Face;
                this.exitLength.Value = exits.Width + 1;
                this.exitHeight.Value = exits.FieldHeight;
                this.exits45LengthPlusHalf.Checked = exits.FieldWidthXPlusHalf;
                this.exits135LengthPlusHalf.Checked = exits.FieldWidthYPlusHalf;
                this.exitDestX.Value = exits.DestX;
                this.exitDestY.Value = exits.DestY;
                this.exitDestZ.Value = exits.DestZ;
                this.exitDestFace.SelectedIndex = exits.DestFace;
                this.marioZCoordPlusHalf.Checked = exits.DestYb7;

                foreach (ToolStripItem item in toolStrip5.Items)
                    item.Enabled = true;
                this.exitDest.Enabled = true;
                this.exitsShowMessage.Enabled = true;
                this.exitType.Enabled = true;
                this.exitX.Enabled = true;
                this.exitY.Enabled = true;
                this.exitZ.Enabled = true;
                this.exitFace.Enabled = true;
                this.exitLength.Enabled = true;
                this.exitHeight.Enabled = true;
                this.exits45LengthPlusHalf.Enabled = true;
                this.exits135LengthPlusHalf.Enabled = true;
                if (this.exitType.SelectedIndex == 0)
                {
                    this.exitDestX.Enabled = true;
                    this.exitDestY.Enabled = true;
                    this.exitDestZ.Enabled = true;
                    this.exitDestFace.Enabled = true;
                    this.marioZCoordPlusHalf.Enabled = true;
                }
                else
                {
                    this.exitDestX.Enabled = false;
                    this.exitDestY.Enabled = false;
                    this.exitDestZ.Enabled = false;
                    this.exitDestFace.Enabled = false;
                    this.marioZCoordPlusHalf.Enabled = false;
                }
            }
            else
            {
                foreach (ToolStripItem item in toolStrip5.Items)
                    if (item != exitsInsertField)
                        item.Enabled = false;
                this.exitDest.Enabled = false;
                this.exitsShowMessage.Enabled = false;
                this.exitType.Enabled = false;
                this.exitX.Enabled = false;
                this.exitY.Enabled = false;
                this.exitZ.Enabled = false;
                this.exitFace.Enabled = false;
                this.exitLength.Enabled = false;
                this.exitHeight.Enabled = false;
                this.exits45LengthPlusHalf.Enabled = false;
                this.exits135LengthPlusHalf.Enabled = false;
                this.exitDestX.Enabled = false;
                this.exitDestY.Enabled = false;
                this.exitDestZ.Enabled = false;
                this.exitDestFace.Enabled = false;
                this.marioZCoordPlusHalf.Enabled = false;

                this.exitType.SelectedIndex = 0;
                this.exitDest.SelectedIndex = 0;
                this.exitsShowMessage.Checked = false;
                this.exitX.Value = 0;
                this.exitY.Value = 0;
                this.exitZ.Value = 0;
                this.exitFace.SelectedIndex = 0;
                this.exitLength.Value = 1;
                this.exitHeight.Value = 0;
                this.exits45LengthPlusHalf.Checked = false;
                this.exits135LengthPlusHalf.Checked = false;
                this.exitDestX.Value = 0;
                this.exitDestY.Value = 0;
                this.exitDestZ.Value = 0;
                this.exitDestFace.SelectedIndex = 0;
                this.marioZCoordPlusHalf.Checked = false;
            }

            overlay.DrawLevelExits(exits);

            updatingProperties = false;

        }
        private void RefreshExitFieldProperties()
        {
            updating = true;

            if (exits.NumberOfExits != 0 && this.exitsFieldTree.SelectedNode != null)
            {
                exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
                this.exitType.SelectedIndex = exits.ExitType;
                SetExitDestinationItems();
                this.exitDest.SelectedIndex = exits.Destination;
                this.exitsShowMessage.Checked = exits.ShowMessage;
                this.exitX.Value = exits.X;
                this.exitY.Value = exits.Y;
                this.exitZ.Value = exits.FieldCoordZ;
                this.exitFace.SelectedIndex = exits.Face;
                this.exitLength.Value = exits.Width + 1;
                this.exitHeight.Value = exits.FieldHeight;
                this.exits45LengthPlusHalf.Checked = exits.FieldWidthXPlusHalf;
                this.exits135LengthPlusHalf.Checked = exits.FieldWidthYPlusHalf;
                this.exitDestX.Value = exits.DestX;
                this.exitDestY.Value = exits.DestY;
                this.exitDestZ.Value = exits.DestZ;
                this.exitDestFace.SelectedIndex = exits.DestFace;
                this.marioZCoordPlusHalf.Checked = exits.DestYb7;

                foreach (ToolStripItem item in toolStrip5.Items)
                    item.Enabled = true;
                this.exitDest.Enabled = true;
                this.exitsShowMessage.Enabled = true;
                this.exitType.Enabled = true;
                this.exitX.Enabled = true;
                this.exitY.Enabled = true;
                this.exitZ.Enabled = true;
                this.exitFace.Enabled = true;
                this.exitLength.Enabled = true;
                this.exitHeight.Enabled = true;
                this.exits45LengthPlusHalf.Enabled = true;
                this.exits135LengthPlusHalf.Enabled = true;
                if (this.exitType.SelectedIndex == 0)
                {
                    this.exitDestX.Enabled = true;
                    this.exitDestY.Enabled = true;
                    this.exitDestZ.Enabled = true;
                    this.exitDestFace.Enabled = true;
                    this.marioZCoordPlusHalf.Enabled = true;
                }
                else
                {
                    this.exitDestX.Enabled = false;
                    this.exitDestY.Enabled = false;
                    this.exitDestZ.Enabled = false;
                    this.exitDestFace.Enabled = false;
                    this.marioZCoordPlusHalf.Enabled = false;
                }
            }
            else
            {
                foreach (ToolStripItem item in toolStrip5.Items)
                    if (item != exitsInsertField)
                        item.Enabled = false;
                this.exitDest.Enabled = false;
                this.exitsShowMessage.Enabled = false;
                this.exitType.Enabled = false;
                this.exitX.Enabled = false;
                this.exitY.Enabled = false;
                this.exitZ.Enabled = false;
                this.exitFace.Enabled = false;
                this.exitLength.Enabled = false;
                this.exitHeight.Enabled = false;
                this.exits45LengthPlusHalf.Enabled = false;
                this.exits135LengthPlusHalf.Enabled = false;
                this.exitDestX.Enabled = false;
                this.exitDestY.Enabled = false;
                this.exitDestZ.Enabled = false;
                this.exitDestFace.Enabled = false;
                this.marioZCoordPlusHalf.Enabled = false;

                this.exitType.SelectedIndex = 0;
                this.exitDest.SelectedIndex = 0;
                this.exitsShowMessage.Checked = false;
                this.exitX.Value = 0;
                this.exitY.Value = 0;
                this.exitZ.Value = 0;
                this.exitFace.SelectedIndex = 0;
                this.exitLength.Value = 1;
                this.exitHeight.Value = 0;
                this.exits45LengthPlusHalf.Checked = false;
                this.exits135LengthPlusHalf.Checked = false;
                this.exitDestX.Value = 0;
                this.exitDestY.Value = 0;
                this.exitDestZ.Value = 0;
                this.exitDestFace.SelectedIndex = 0;
                this.marioZCoordPlusHalf.Checked = false;
            }
            updating = false;
        }

        private void SetExitDestinationItems()
        {
            this.exitDest.Items.Clear();
            if (this.exitType.SelectedIndex == 0)
            {
                this.exitDest.Items.AddRange(Lists.Convert(settings.LevelNames));
            }
            else
            {
                this.exitDest.Items.AddRange(Lists.MapNames);
            }
        }

        public int CalculateFreeExitSpace()
        {
            int used = 0;

            for (int i = 0; i < 512; i++)
            {
                for (int j = 0; j < levels[i].LevelExits.NumberOfExits; j++)
                {
                    levels[i].LevelExits.CurrentExit = j;
                    used += levels[i].LevelExits.GetExitLength();
                }
            }
            return 0x179F - used;
        }

        #endregion

        #region Event Handlers
        public TreeView ExitsFieldTree { get { return exitsFieldTree; } set { exitsFieldTree = value; } }
        private void exitsFieldTree_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
            exits.SelectedExit = this.exitsFieldTree.SelectedNode.Index;

            overlay.DrawLevelExits(exits);


            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
            RefreshExitFieldProperties();
            levelsTilemap.Picture.Invalidate();
        }
        private void exits45LengthPlusHalf_CheckedChanged(object sender, EventArgs e)
        {
            if (exits45LengthPlusHalf.Checked) exits45LengthPlusHalf.ForeColor = Color.Black;
            else exits45LengthPlusHalf.ForeColor = Color.Gray;
            if (updating) return;

            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
            exits.FieldWidthXPlusHalf = this.exits45LengthPlusHalf.Checked;

            overlay.DrawLevelExits(exits);


            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
            RefreshExitFieldProperties();
        }
        private void exits135LengthPlusHalf_CheckedChanged(object sender, EventArgs e)
        {
            if (exits135LengthPlusHalf.Checked) exits135LengthPlusHalf.ForeColor = Color.Black;
            else exits135LengthPlusHalf.ForeColor = Color.Gray;
            if (updating) return;

            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
            exits.FieldWidthYPlusHalf = this.exits135LengthPlusHalf.Checked;

            overlay.DrawLevelExits(exits);


            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
            RefreshExitFieldProperties();
        }
        private void exitsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;

            if (CalculateFreeExitSpace() >= 0)
            {
                exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
                exits.ExitType = (byte)this.exitType.SelectedIndex;

                if (exits.Destination > exitType.Items.Count)
                    exits.Destination = (ushort)(exitType.Items.Count - 1);

                RefreshExitFieldProperties();
            }
            else
            {
                this.exitType.SelectedIndex = 1;
            }
        }
        private void exitsMarioZCoord_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            exits.DestZ = (byte)this.exitDestZ.Value;
        }
        private void exitsMarioYCoord_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            exits.DestY = (byte)this.exitDestY.Value;
        }
        private void exitsMarioXCoord_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            exits.DestX = (byte)this.exitDestX.Value;
        }
        private void marioZCoordPlusHalf_CheckedChanged(object sender, System.EventArgs e)
        {
            if (marioZCoordPlusHalf.Checked) marioZCoordPlusHalf.ForeColor = Color.Black;
            else marioZCoordPlusHalf.ForeColor = Color.Gray;
            if (updating) return;

            exits.DestYb7 = this.marioZCoordPlusHalf.Checked;
        }
        private void exitsFieldHeight_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
            exits.FieldHeight = (byte)this.exitHeight.Value;

            overlay.DrawLevelExits(exits);

            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
            levelsTilemap.Picture.Invalidate();
        }
        private void exitsFieldLength_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
            exits.Width = (byte)(this.exitLength.Value - 1);

            overlay.DrawLevelExits(exits);

            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
            levelsTilemap.Picture.Invalidate();
        }
        private void exitsMarioRadialPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;

            exits.DestFace = (byte)this.exitDestFace.SelectedIndex;
        }
        public NumericUpDown ExitX { get { return exitX; } set { exitX = value; } }
        public NumericUpDown ExitY { get { return exitY; } set { exitY = value; } }
        private void exitsZ_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
            exits.FieldCoordZ = (byte)this.exitZ.Value;

            overlay.DrawLevelExits(exits);

            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
            levelsTilemap.Picture.Invalidate();
        }
        private void exitsY_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
            exits.Y = (byte)this.exitY.Value;

            if (!updatingProperties)
                overlay.DrawLevelExits(exits);

            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
            levelsTilemap.Picture.Invalidate();
        }
        private void exitsX_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
            exits.X = (byte)this.exitX.Value;

            if (!updatingProperties)
                overlay.DrawLevelExits(exits);

            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
            levelsTilemap.Picture.Invalidate();
        }
        private void exitsFace_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;

            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
            exits.Face = (byte)this.exitFace.SelectedIndex;
            overlay.DrawLevelExits(exits);
            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
            levelsTilemap.Picture.Invalidate();
        }
        private void exitsShowMessage_CheckedChanged(object sender, System.EventArgs e)
        {
            if (exitsShowMessage.Checked) exitsShowMessage.ForeColor = Color.Black;
            else exitsShowMessage.ForeColor = Color.Gray;
            if (updating) return;

            exits.ShowMessage = this.exitsShowMessage.Checked;
        }
        private void exitsDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;

            exits.Destination = (ushort)this.exitDest.SelectedIndex;
        }
        private void exitsInsertField_Click(object sender, EventArgs e)
        {
            Point o = new Point(Math.Abs(levelsTilemap.Picture.Left), Math.Abs(levelsTilemap.Picture.Top));
            Point p = new Point(solidity.PixelCoords[o.Y * 1024 + o.X].X + 2, solidity.PixelCoords[o.Y * 1024 + o.X].Y + 4);
            if (CalculateFreeExitSpace() >= 8)
            {
                this.exitsFieldTree.Focus();
                if (exits.NumberOfExits < 28)
                {
                    if (exitsFieldTree.Nodes.Count > 0)
                        exits.AddNewExit(exitsFieldTree.SelectedNode.Index + 1, p);
                    else
                        exits.AddNewExit(0, p);
                    int reselect;
                    if (exitsFieldTree.Nodes.Count > 0)
                        reselect = exitsFieldTree.SelectedNode.Index;
                    else
                        reselect = -1;
                    exitsFieldTree.BeginUpdate();
                    this.exitsFieldTree.Nodes.Clear();
                    for (int i = 0; i < exits.NumberOfExits; i++)
                        this.exitsFieldTree.Nodes.Add(new TreeNode("EXIT #" + i.ToString()));
                    this.exitsFieldTree.SelectedNode = this.exitsFieldTree.Nodes[reselect + 1];
                    exitsFieldTree.EndUpdate();
                }
                else
                    MessageBox.Show("Could not insert any more exit fields. The maximum number of exit fields allowed is 28.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Could not insert the field. The total number of exits for all levels has exceeded the maximum allotted space.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void exitsDeleteField_Click(object sender, EventArgs e)
        {
            this.exitsFieldTree.Focus();
            if (this.exitsFieldTree.SelectedNode != null && exits.CurrentExit == this.exitsFieldTree.SelectedNode.Index)
            {
                exits.RemoveCurrentExit();

                int reselect = exitsFieldTree.SelectedNode.Index;
                if (reselect == exitsFieldTree.Nodes.Count - 1)
                    reselect--;

                exitsFieldTree.BeginUpdate();
                this.exitsFieldTree.Nodes.Clear();

                for (int i = 0; i < exits.NumberOfExits; i++)
                    this.exitsFieldTree.Nodes.Add(new TreeNode("EXIT #" + i.ToString()));

                if (exitsFieldTree.Nodes.Count > 0)
                    this.exitsFieldTree.SelectedNode = this.exitsFieldTree.Nodes[reselect];
                else
                {
                    this.exitsFieldTree.SelectedNode = null;

                    overlay.DrawLevelExits(exits);


                    RefreshExitFieldProperties();
                }
                exitsFieldTree.EndUpdate();
            }
        }
        private void AddNewExit(LevelExits.Exit exit)
        {
            if (CalculateFreeExitSpace() >= 8)
            {
                this.exitsFieldTree.Focus();
                if (exits.NumberOfExits < 28)
                {
                    if (exitsFieldTree.Nodes.Count > 0)
                        exits.AddNewExit(exitsFieldTree.SelectedNode.Index + 1, exit);
                    else
                        exits.AddNewExit(0, exit);
                    int reselect;
                    if (exitsFieldTree.Nodes.Count > 0)
                        reselect = exitsFieldTree.SelectedNode.Index;
                    else
                        reselect = -1;
                    exitsFieldTree.BeginUpdate();
                    this.exitsFieldTree.Nodes.Clear();
                    for (int i = 0; i < exits.NumberOfExits; i++)
                        this.exitsFieldTree.Nodes.Add(new TreeNode("EXIT #" + i.ToString()));
                    this.exitsFieldTree.SelectedNode = this.exitsFieldTree.Nodes[reselect + 1];
                    exitsFieldTree.EndUpdate();
                }
                else
                    MessageBox.Show("Could not insert any more exit fields. The maximum number of exit fields allowed is 28.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Could not insert the field. The total number of exits for all levels has exceeded the maximum allotted space.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void exitsCopyField_Click(object sender, EventArgs e)
        {
            if (exitsFieldTree.SelectedNode != null)
                copyExit = exits.Exit_.Copy();
        }
        private void exitsPasteField_Click(object sender, EventArgs e)
        {
            AddNewExit((LevelExits.Exit)copyExit);
        }
        private void exitsDuplicateField_Click(object sender, EventArgs e)
        {
            AddNewExit(exits.Exit_.Copy());
        }

        #endregion
    }
}
