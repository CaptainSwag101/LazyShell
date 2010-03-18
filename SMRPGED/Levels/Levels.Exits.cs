using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMRPGED
{
    public partial class Levels
    {
        #region Variables

        private LevelExits exits; // Exits for the current level

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
                this.exitsType.SelectedIndex = exits.ExitType;
                SetExitDestinationItems();
                this.exitsDestination.SelectedIndex = exits.Destination;
                this.exitsShowMessage.Checked = exits.ShowMessage;
                this.exitsLengthOverOne.Checked = exits.LengthOverOne;
                this.exitsFieldXCoord.Value = exits.FieldCoordX;
                this.exitsFieldYCoord.Value = exits.FieldCoordY;
                this.exitsFieldZCoord.Value = exits.FieldCoordZ;
                this.exitsFieldRadialPosition.SelectedIndex = exits.FieldRadialPosition;
                this.exitsFieldLength.Value = exits.FieldWidth;
                this.exitsFieldHeight.Value = exits.FieldHeight;
                this.exits45LengthPlusHalf.Checked = exits.FieldWidthXPlusHalf;
                this.exits135LengthPlusHalf.Checked = exits.FieldWidthYPlusHalf;
                this.exitsMarioXCoord.Value = exits.MarioCoordX;
                this.exitsMarioYCoord.Value = exits.MarioCoordY;
                this.exitsMarioZCoord.Value = exits.MarioCoordZ;
                this.exitsMarioRadialPosition.SelectedIndex = exits.MarioRadialPosition;
                this.marioZCoordPlusHalf.Checked = exits.MarioCoordYBit7;

                this.exitsDeleteField.Enabled = true;
                this.exitsDestination.Enabled = true;
                this.exitsShowMessage.Enabled = true;
                this.exitsType.Enabled = true;
                this.exitsLengthOverOne.Enabled = true;
                this.exitsFieldXCoord.Enabled = true;
                this.exitsFieldYCoord.Enabled = true;
                this.exitsFieldZCoord.Enabled = true;
                this.exitsFieldRadialPosition.Enabled = true;
                if (this.exitsLengthOverOne.Checked)
                    this.exitsFieldLength.Enabled = true;
                else
                    this.exitsFieldLength.Enabled = false;
                this.exitsFieldHeight.Enabled = true;
                this.exits45LengthPlusHalf.Enabled = true;
                this.exits135LengthPlusHalf.Enabled = true;
                if (this.exitsType.SelectedIndex == 0)
                {
                    this.exitsMarioXCoord.Enabled = true;
                    this.exitsMarioYCoord.Enabled = true;
                    this.exitsMarioZCoord.Enabled = true;
                    this.exitsMarioRadialPosition.Enabled = true;
                    this.marioZCoordPlusHalf.Enabled = true;
                }
                else
                {
                    this.exitsMarioXCoord.Enabled = false;
                    this.exitsMarioYCoord.Enabled = false;
                    this.exitsMarioZCoord.Enabled = false;
                    this.exitsMarioRadialPosition.Enabled = false;
                    this.marioZCoordPlusHalf.Enabled = false;
                }
            }
            else
            {
                this.exitsDeleteField.Enabled = false;
                this.exitsDestination.Enabled = false;
                this.exitsShowMessage.Enabled = false;
                this.exitsType.Enabled = false;
                this.exitsLengthOverOne.Enabled = false;
                this.exitsFieldXCoord.Enabled = false;
                this.exitsFieldYCoord.Enabled = false;
                this.exitsFieldZCoord.Enabled = false;
                this.exitsFieldRadialPosition.Enabled = false;
                this.exitsFieldLength.Enabled = false;
                this.exitsFieldHeight.Enabled = false;
                this.exits45LengthPlusHalf.Enabled = false;
                this.exits135LengthPlusHalf.Enabled = false;
                this.exitsMarioXCoord.Enabled = false;
                this.exitsMarioYCoord.Enabled = false;
                this.exitsMarioZCoord.Enabled = false;
                this.exitsMarioRadialPosition.Enabled = false;
                this.marioZCoordPlusHalf.Enabled = false;

                this.exitsType.SelectedIndex = 0;
                this.exitsDestination.SelectedIndex = 0;
                this.exitsShowMessage.Checked = false;
                this.exitsLengthOverOne.Checked = false;
                this.exitsFieldXCoord.Value = 0;
                this.exitsFieldYCoord.Value = 0;
                this.exitsFieldZCoord.Value = 0;
                this.exitsFieldRadialPosition.SelectedIndex = 0;
                this.exitsFieldLength.Value = 0;
                this.exitsFieldHeight.Value = 0;
                this.exits45LengthPlusHalf.Checked = false;
                this.exits135LengthPlusHalf.Checked = false;
                this.exitsMarioXCoord.Value = 0;
                this.exitsMarioYCoord.Value = 0;
                this.exitsMarioZCoord.Value = 0;
                this.exitsMarioRadialPosition.SelectedIndex = 0;
                this.marioZCoordPlusHalf.Checked = false;
            }

            overlay.DrawLevelExits(exits);

            updatingProperties = false;

        }
        private void RefreshExitFieldProperties()
        {
            updatingLevel = true;

            if (exits.NumberOfExits != 0 && this.exitsFieldTree.SelectedNode != null)
            {
                exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
                this.exitsType.SelectedIndex = exits.ExitType;
                SetExitDestinationItems();
                this.exitsDestination.SelectedIndex = exits.Destination;
                this.exitsShowMessage.Checked = exits.ShowMessage;
                this.exitsLengthOverOne.Checked = exits.LengthOverOne;
                this.exitsFieldXCoord.Value = exits.FieldCoordX;
                this.exitsFieldYCoord.Value = exits.FieldCoordY;
                this.exitsFieldZCoord.Value = exits.FieldCoordZ;
                this.exitsFieldRadialPosition.SelectedIndex = exits.FieldRadialPosition;
                this.exitsFieldLength.Value = exits.FieldWidth;
                this.exitsFieldHeight.Value = exits.FieldHeight;
                this.exits45LengthPlusHalf.Checked = exits.FieldWidthXPlusHalf;
                this.exits135LengthPlusHalf.Checked = exits.FieldWidthYPlusHalf;
                this.exitsMarioXCoord.Value = exits.MarioCoordX;
                this.exitsMarioYCoord.Value = exits.MarioCoordY;
                this.exitsMarioZCoord.Value = exits.MarioCoordZ;
                this.exitsMarioRadialPosition.SelectedIndex = exits.MarioRadialPosition;
                this.marioZCoordPlusHalf.Checked = exits.MarioCoordYBit7;

                this.exitsDeleteField.Enabled = true;
                this.exitsDestination.Enabled = true;
                this.exitsShowMessage.Enabled = true;
                this.exitsType.Enabled = true;
                this.exitsLengthOverOne.Enabled = true;
                this.exitsFieldXCoord.Enabled = true;
                this.exitsFieldYCoord.Enabled = true;
                this.exitsFieldZCoord.Enabled = true;
                this.exitsFieldRadialPosition.Enabled = true;
                if (this.exitsLengthOverOne.Checked)
                    this.exitsFieldLength.Enabled = true;
                else
                    this.exitsFieldLength.Enabled = false;
                this.exitsFieldHeight.Enabled = true;
                this.exits45LengthPlusHalf.Enabled = true;
                this.exits135LengthPlusHalf.Enabled = true;
                if (this.exitsType.SelectedIndex == 0)
                {
                    this.exitsMarioXCoord.Enabled = true;
                    this.exitsMarioYCoord.Enabled = true;
                    this.exitsMarioZCoord.Enabled = true;
                    this.exitsMarioRadialPosition.Enabled = true;
                    this.marioZCoordPlusHalf.Enabled = true;
                }
                else
                {
                    this.exitsMarioXCoord.Enabled = false;
                    this.exitsMarioYCoord.Enabled = false;
                    this.exitsMarioZCoord.Enabled = false;
                    this.exitsMarioRadialPosition.Enabled = false;
                    this.marioZCoordPlusHalf.Enabled = false;
                }
            }
            else
            {
                this.exitsDeleteField.Enabled = false;
                this.exitsDestination.Enabled = false;
                this.exitsShowMessage.Enabled = false;
                this.exitsType.Enabled = false;
                this.exitsLengthOverOne.Enabled = false;
                this.exitsFieldXCoord.Enabled = false;
                this.exitsFieldYCoord.Enabled = false;
                this.exitsFieldZCoord.Enabled = false;
                this.exitsFieldRadialPosition.Enabled = false;
                this.exitsFieldLength.Enabled = false;
                this.exitsFieldHeight.Enabled = false;
                this.exits45LengthPlusHalf.Enabled = false;
                this.exits135LengthPlusHalf.Enabled = false;
                this.exitsMarioXCoord.Enabled = false;
                this.exitsMarioYCoord.Enabled = false;
                this.exitsMarioZCoord.Enabled = false;
                this.exitsMarioRadialPosition.Enabled = false;
                this.marioZCoordPlusHalf.Enabled = false;

                this.exitsType.SelectedIndex = 0;
                this.exitsDestination.SelectedIndex = 0;
                this.exitsShowMessage.Checked = false;
                this.exitsLengthOverOne.Checked = false;
                this.exitsFieldXCoord.Value = 0;
                this.exitsFieldYCoord.Value = 0;
                this.exitsFieldZCoord.Value = 0;
                this.exitsFieldRadialPosition.SelectedIndex = 0;
                this.exitsFieldLength.Value = 0;
                this.exitsFieldHeight.Value = 0;
                this.exits45LengthPlusHalf.Checked = false;
                this.exits135LengthPlusHalf.Checked = false;
                this.exitsMarioXCoord.Value = 0;
                this.exitsMarioYCoord.Value = 0;
                this.exitsMarioZCoord.Value = 0;
                this.exitsMarioRadialPosition.SelectedIndex = 0;
                this.marioZCoordPlusHalf.Checked = false;
            }
            updatingLevel = false;
        }

        private void SetExitDestinationItems()
        {
            this.exitsDestination.Items.Clear();
            if (this.exitsType.SelectedIndex == 0)
            {
                this.exitsDestination.Items.AddRange(universal.LevelNames);
            }
            else
            {
                this.exitsDestination.Items.AddRange(new object[] {
            "[00]  To Mario's Pad (before)",
            "[01]  Bowser's Keep (before)",
            "[02]  To Mario's Pad",
            "[03]  Vista Hill",
            "[04]  Bowser's Keep",
            "[05]  Gate",
            "[06]  To Nimbus Land",
            "[07]  To Bowser's Keep",
            "[08]  Mario's Pad",
            "[09]  Mushroom Way",
            "[0A]  Mushroom Kingdom",
            "[0B]  Bandit's Way",
            "[0C]  Kero Sewers",
            "[0D]  To Mushroom Kingdom",
            "[0E]  Kero Sewers",
            "[0F]  Midas River",
            "[10]  Tadpole Pond",
            "[11]  Rose Way",
            "[12]  Rose Town",
            "[13]  Forest Maze",
            "[14]  Pipe Vault",
            "[15]  To Yo'ster Isle",
            "[16]  To Moleville",
            "[17]  To Pipe Vault",
            "[18]  Moleville",
            "[19]  Booster Pass",
            "[1A]  Booster Tower",
            "[1B]  Booster Hill",
            "[1C]  Marrymore",
            "[1D]  To Star Hill",
            "[1E]  To Marrymore",
            "[1F]  Star Hill",
            "[20]  Seaside Town",
            "[21]  Sea",
            "[22]  Sunken Ship",
            "[23]  To Land's End",
            "[24]  To Seaside Town",
            "[25]  Land's End",
            "[26]  Monstro Town",
            "[27]  Bean Valley",
            "[28]  Grate Guy's Casino",
            "[29]  To Nimbus Land",
            "[2A]  To Seaside Town",
            "[2B]  Land's End",
            "[2C]  Monstro Town",
            "[2D]  Bean Valley",
            "[2E]  Grate Guy's Casino",
            "[2F]  To Nimbus Land",
            "[30]  To Bean Valley",
            "[31]  Nimbus Land",
            "[32]  Barrel Volcano",
            "[33]  To Bowser's Keep",
            "[34]  Yo'ster Isle",
            "[35]  To Pipe Vault",
            "[36]  Coal Mines (Bowser's Keep)",
            "[37]  Factory (Bowser's Keep)"});
            }
        }
        private void SetOverExit()
        {
            int currentExit = exits.CurrentExit;
            for (int i = 0; i < exitsFieldTree.Nodes.Count; i++)
            {
                exits.CurrentExit = i;
                if (exits.FieldCoordX == orthCoordX && exits.FieldCoordY == orthCoordY)
                {
                    this.pictureBoxLevel.Cursor = System.Windows.Forms.Cursors.Hand;
                    overExitField = i + 1;
                    isOverSomething = true;
                    break;
                }
                else
                {
                    this.pictureBoxLevel.Cursor = System.Windows.Forms.Cursors.Arrow;
                    overExitField = 0;
                    isOverSomething = false;
                }
            }
            exits.CurrentExit = currentExit;
        }

        public bool CalculateFreeExitSpace()
        {
            int used = 0;

            for (int i = 0; i < 512; i++)
            {
                for (int j = 0; j < levels[i].LevelExits.NumberOfExits; j++)
                {
                    levels[i].LevelExits.CurrentExit = j;
                    used += levels[i].LevelExits.GetExitLength();

                    if ((used + 8) > 0x179F)
                    {
                        MessageBox.Show("WARNING: Cannot insert the field. The total number of exits for all levels has exceeded the maximum allotted space.", "TOTAL EXITS LENGTH EXCEEDED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return true;
                    }
                }
            }

            return false;
        }

        #endregion

        #region Event Handlers

        private void exitsFieldTree_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
            exits.SelectedExit = this.exitsFieldTree.SelectedNode.Index;

            overlay.DrawLevelExits(exits);
            pictureBoxLevel.Invalidate();

            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
            RefreshExitFieldProperties();
        }
        private void exitsLengthOverOne_CheckedChanged(object sender, System.EventArgs e)
        {
            if (exitsLengthOverOne.Checked) exitsLengthOverOne.ForeColor = Color.Black;
            else exitsLengthOverOne.ForeColor = Color.Gray;

            if (updatingLevel) return;

            if (!CalculateFreeExitSpace())
            {
                exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
                exits.LengthOverOne = this.exitsLengthOverOne.Checked;

                overlay.DrawLevelExits(exits);
                pictureBoxLevel.Invalidate();

                exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
                RefreshExitFieldProperties();
            }
            else
            {
                exitsLengthOverOne.Checked = false;
                exitsLengthOverOne.ForeColor = Color.Gray;
            }
        }
        private void exits45LengthPlusHalf_CheckedChanged(object sender, EventArgs e)
        {
            if (exits45LengthPlusHalf.Checked) exits45LengthPlusHalf.ForeColor = Color.Black;
            else exits45LengthPlusHalf.ForeColor = Color.Gray;
            if (updatingLevel) return;

            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
            exits.FieldWidthXPlusHalf = this.exits45LengthPlusHalf.Checked;

            overlay.DrawLevelExits(exits);
            pictureBoxLevel.Invalidate();

            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
            RefreshExitFieldProperties();
        }
        private void exits135LengthPlusHalf_CheckedChanged(object sender, EventArgs e)
        {
            if (exits135LengthPlusHalf.Checked) exits135LengthPlusHalf.ForeColor = Color.Black;
            else exits135LengthPlusHalf.ForeColor = Color.Gray;
            if (updatingLevel) return;

            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
            exits.FieldWidthYPlusHalf = this.exits135LengthPlusHalf.Checked;

            overlay.DrawLevelExits(exits);
            pictureBoxLevel.Invalidate();

            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
            RefreshExitFieldProperties();
        }
        private void exitsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingLevel) return;

            if (!CalculateFreeExitSpace())
            {
                exits.ExitType = (byte)this.exitsType.SelectedIndex;

                if (exits.Destination > exitsType.Items.Count)
                    exits.Destination = (ushort)(exitsType.Items.Count - 1);

                RefreshExitFieldProperties();
            }
            else
            {
                this.exitsType.SelectedIndex = 1;
            }
        }
        private void exitsMarioZCoord_ValueChanged(object sender, EventArgs e)
        {
            if (updatingLevel) return;

            exits.MarioCoordZ = (byte)this.exitsMarioZCoord.Value;
        }
        private void exitsMarioYCoord_ValueChanged(object sender, EventArgs e)
        {
            if (updatingLevel) return;

            exits.MarioCoordY = (byte)this.exitsMarioYCoord.Value;
        }
        private void exitsMarioXCoord_ValueChanged(object sender, EventArgs e)
        {
            if (updatingLevel) return;

            exits.MarioCoordX = (byte)this.exitsMarioXCoord.Value;
        }
        private void marioZCoordPlusHalf_CheckedChanged(object sender, System.EventArgs e)
        {
            if (marioZCoordPlusHalf.Checked) marioZCoordPlusHalf.ForeColor = Color.Black;
            else marioZCoordPlusHalf.ForeColor = Color.Gray;
            if (updatingLevel) return;

            exits.MarioCoordYBit7 = this.marioZCoordPlusHalf.Checked;
        }
        private void exitsFieldHeight_ValueChanged(object sender, EventArgs e)
        {
            if (updatingLevel) return;

            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
            exits.FieldHeight = (byte)this.exitsFieldHeight.Value;

            overlay.DrawLevelExits(exits);
            pictureBoxLevel.Invalidate();

            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
        }
        private void exitsFieldLength_ValueChanged(object sender, EventArgs e)
        {
            if (updatingLevel) return;

            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
            exits.FieldWidth = (byte)this.exitsFieldLength.Value;

            overlay.DrawLevelExits(exits);
            pictureBoxLevel.Invalidate();

            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
        }
        private void exitsMarioRadialPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingLevel) return;

            exits.MarioRadialPosition = (byte)this.exitsMarioRadialPosition.SelectedIndex;
        }
        private void exitsFieldZCoord_ValueChanged(object sender, EventArgs e)
        {
            if (updatingLevel) return;

            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
            exits.FieldCoordZ = (byte)this.exitsFieldZCoord.Value;

            overlay.DrawLevelExits(exits);
            pictureBoxLevel.Invalidate();

            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
        }
        private void exitsFieldYCoord_ValueChanged(object sender, EventArgs e)
        {
            if (updatingLevel) return;

            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
            exits.FieldCoordY = (byte)this.exitsFieldYCoord.Value;

            if (!waitBothCoords)
            {
                overlay.DrawLevelExits(exits);
                pictureBoxLevel.Invalidate();
            }

            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
        }
        private void exitsFieldXCoord_ValueChanged(object sender, EventArgs e)
        {
            if (updatingLevel) return;

            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
            exits.FieldCoordX = (byte)this.exitsFieldXCoord.Value;

            if (!waitBothCoords)
            {
                overlay.DrawLevelExits(exits);
                pictureBoxLevel.Invalidate();
            }

            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
        }
        private void exitsFieldRadialPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingLevel) return;

            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
            exits.FieldRadialPosition = (byte)this.exitsFieldRadialPosition.SelectedIndex;

            overlay.DrawLevelExits(exits);
            pictureBoxLevel.Invalidate();

            exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
        }
        private void exitsShowMessage_CheckedChanged(object sender, System.EventArgs e)
        {
            if (exitsShowMessage.Checked) exitsShowMessage.ForeColor = Color.Black;
            else exitsShowMessage.ForeColor = Color.Gray;
            if (updatingLevel) return;

            exits.ShowMessage = this.exitsShowMessage.Checked;
        }
        private void exitsDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingLevel) return;

            exits.Destination = (ushort)this.exitsDestination.SelectedIndex;
        }
        private void exitsInsertField_Click(object sender, EventArgs e)
        {
            Point o = new Point(Math.Abs(pictureBoxLevel.Left), Math.Abs(pictureBoxLevel.Top));
            Point p = new Point(physicalMap.OrthCoordsX[o.Y * 1024 + o.X] + 2, physicalMap.OrthCoordsY[o.Y * 1024 + o.X] + 4);
            if (!CalculateFreeExitSpace())
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
                    MessageBox.Show("WARNING: Cannot insert anymore exit fields. The maximum number of exit fields allowed is 28.", "WARNING: Cannot insert any more exit fields", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
                    pictureBoxLevel.Invalidate();

                    RefreshExitFieldProperties();
                }
                exitsFieldTree.EndUpdate();
            }
        }

        #endregion
    }
}
