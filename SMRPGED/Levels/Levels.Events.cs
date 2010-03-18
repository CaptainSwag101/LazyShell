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

        private LevelEvents events; // Events for the current level

        #endregion

        #region Methods

        private void InitializeEventFieldProperties()
        {
            updatingProperties = true;

            this.eventsAreaMusic.SelectedIndex = events.Music;
            this.eventsExitEvent.Value = events.ExitEvent;

            this.eventsFieldTree.Nodes.Clear();

            for (int i = 0; i < events.NumberOfEvents; i++)
            {
                this.eventsFieldTree.Nodes.Add(new TreeNode("EVENT #" + i.ToString()));
            }

            if (eventsFieldTree.Nodes.Count > 0)
                this.eventsFieldTree.SelectedNode = this.eventsFieldTree.Nodes[0];

            if (events.NumberOfEvents != 0 && this.eventsFieldTree.SelectedNode != null)
            {
                events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
                this.eventsRunEvent.Value = events.RunEvent;
                this.eventsLengthOverOne.Checked = events.LengthOverOne;
                this.eventsFieldXCoord.Value = events.FieldCoordX;
                this.eventsFieldYCoord.Value = events.FieldCoordY;
                this.eventsFieldZCoord.Value = events.FieldCoordZ;
                this.eventsFieldRadialPosition.SelectedIndex = events.FieldRadialPosition;
                this.eventsFieldLength.Value = events.FieldWidth;
                this.eventsFieldHeight.Value = events.FieldHeight;
                this.eventsWidthXPlusHalf.Checked = events.FieldWidthXPlusHalf;
                this.eventsWidthYPlusHalf.Checked = events.FieldWidthYPlusHalf;

                this.eventsDeleteField.Enabled = true;
                this.eventsRunEvent.Enabled = true;
                this.eventsLengthOverOne.Enabled = true;
                this.eventsFieldXCoord.Enabled = true;
                this.eventsFieldYCoord.Enabled = true;
                this.eventsFieldZCoord.Enabled = true;
                this.eventsFieldRadialPosition.Enabled = true;
                if (this.eventsLengthOverOne.Checked)
                    this.eventsFieldLength.Enabled = true;
                else
                    this.eventsFieldLength.Enabled = false;
                this.eventsFieldHeight.Enabled = true;
                this.eventsWidthXPlusHalf.Enabled = true;
                this.eventsWidthYPlusHalf.Enabled = true;

                this.buttonGotoD.Enabled = true;
            }
            else
            {
                this.eventsDeleteField.Enabled = false;
                this.eventsRunEvent.Enabled = false;
                this.eventsLengthOverOne.Enabled = false;
                this.eventsFieldXCoord.Enabled = false;
                this.eventsFieldYCoord.Enabled = false;
                this.eventsFieldZCoord.Enabled = false;
                this.eventsFieldRadialPosition.Enabled = false;
                this.eventsFieldLength.Enabled = false;
                this.eventsFieldHeight.Enabled = false;
                this.eventsWidthXPlusHalf.Enabled = false;
                this.eventsWidthYPlusHalf.Enabled = false;

                this.eventsRunEvent.Value = 0;
                this.eventsLengthOverOne.Checked = false;
                this.eventsFieldXCoord.Value = 0;
                this.eventsFieldYCoord.Value = 0;
                this.eventsFieldZCoord.Value = 0;
                this.eventsFieldRadialPosition.SelectedIndex = 0;
                this.eventsFieldLength.Value = 0;
                this.eventsFieldHeight.Value = 0;
                this.eventsWidthXPlusHalf.Checked = false;
                this.eventsWidthYPlusHalf.Checked = false;

                this.buttonGotoD.Enabled = false;
            }

            for (int i = 0; i < events.NumberOfEvents; i++)
            {
            }
            updatingProperties = false;

        }
        private void RefreshEventFieldProperties()
        {
            updatingLevel = true;

            if (events.NumberOfEvents != 0 && this.eventsFieldTree.SelectedNode != null)
            {
                events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
                this.eventsRunEvent.Value = events.RunEvent;
                this.eventsLengthOverOne.Checked = events.LengthOverOne;
                this.eventsFieldXCoord.Value = events.FieldCoordX;
                this.eventsFieldYCoord.Value = events.FieldCoordY;
                this.eventsFieldZCoord.Value = events.FieldCoordZ;
                this.eventsFieldRadialPosition.SelectedIndex = events.FieldRadialPosition;
                this.eventsFieldLength.Value = events.FieldWidth;
                this.eventsFieldHeight.Value = events.FieldHeight;
                this.eventsWidthXPlusHalf.Checked = events.FieldWidthXPlusHalf;
                this.eventsWidthYPlusHalf.Checked = events.FieldWidthYPlusHalf;

                this.eventsDeleteField.Enabled = true;
                this.eventsRunEvent.Enabled = true;
                this.eventsLengthOverOne.Enabled = true;
                this.eventsFieldXCoord.Enabled = true;
                this.eventsFieldYCoord.Enabled = true;
                this.eventsFieldZCoord.Enabled = true;
                this.eventsFieldRadialPosition.Enabled = true;
                if (this.eventsLengthOverOne.Checked)
                    this.eventsFieldLength.Enabled = true;
                else
                    this.eventsFieldLength.Enabled = false;
                this.eventsFieldHeight.Enabled = true;
                this.eventsWidthXPlusHalf.Enabled = true;
                this.eventsWidthYPlusHalf.Enabled = true;

                this.buttonGotoD.Enabled = true;
            }
            else
            {
                this.eventsDeleteField.Enabled = false;
                this.eventsRunEvent.Enabled = false;
                this.eventsLengthOverOne.Enabled = false;
                this.eventsFieldXCoord.Enabled = false;
                this.eventsFieldYCoord.Enabled = false;
                this.eventsFieldZCoord.Enabled = false;
                this.eventsFieldRadialPosition.Enabled = false;
                this.eventsFieldLength.Enabled = false;
                this.eventsFieldHeight.Enabled = false;
                this.eventsWidthXPlusHalf.Enabled = false;
                this.eventsWidthYPlusHalf.Enabled = false;

                this.eventsRunEvent.Value = 0;
                this.eventsLengthOverOne.Checked = false;
                this.eventsFieldXCoord.Value = 0;
                this.eventsFieldYCoord.Value = 0;
                this.eventsFieldZCoord.Value = 0;
                this.eventsFieldRadialPosition.SelectedIndex = 0;
                this.eventsFieldLength.Value = 0;
                this.eventsFieldHeight.Value = 0;
                this.eventsWidthXPlusHalf.Checked = false;
                this.eventsWidthYPlusHalf.Checked = false;

                this.buttonGotoD.Enabled = false;
            }
            updatingLevel = false;
        }

        public bool CalculateFreeEventSpace()
        {
            int used = 0;

            for (int i = 0; i < 512; i++)
            {
                used += 3; // for the music and initial event
                for (int j = 0; j < levels[i].LevelEvents.NumberOfEvents; j++)
                {
                    levels[i].LevelEvents.CurrentEvent = j;
                    used += levels[i].LevelEvents.GetEventLength();

                    if ((used + 6) > 0x1BFF)
                    {
                        MessageBox.Show("WARNING: Cannot insert the field. The total number of events for all levels has exceeded the maximum allotted space.", "TOTAL EVENTS LENGTH EXCEEDED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return true;
                    }
                }
            }

            return false;
        }
        private void SetOverEvent()
        {
            int currentEvent = events.CurrentEvent;
            for (int i = 0; i < eventsFieldTree.Nodes.Count; i++)
            {
                events.CurrentEvent = i;
                if (events.FieldCoordX == orthCoordX && events.FieldCoordY == orthCoordY)
                {
                    this.pictureBoxLevel.Cursor = System.Windows.Forms.Cursors.Hand;
                    overEventField = i + 1;
                    isOverSomething = true;
                    break;
                }
                else
                {
                    this.pictureBoxLevel.Cursor = System.Windows.Forms.Cursors.Arrow;
                    overEventField = 0;
                    isOverSomething = false;
                }
            }
            events.CurrentEvent = currentEvent;
        }

        #endregion

        #region Event Handlers

        private void eventsFieldTree_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
            events.SelectedEvent = this.eventsFieldTree.SelectedNode.Index;

            overlay.DrawLevelEvents(events);
            pictureBoxLevel.Invalidate();

            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
            RefreshEventFieldProperties();
        }
        private void eventsExitEvent_ValueChanged(object sender, EventArgs e)
        {
            if (updatingLevel) return;

            events.ExitEvent = (ushort)this.eventsExitEvent.Value;
        }
        private void eventsAreaMusic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingLevel) return;

            events.Music = (byte)this.eventsAreaMusic.SelectedIndex;
        }
        private void eventsRunEvent_ValueChanged(object sender, EventArgs e)
        {
            if (updatingLevel) return;

            events.RunEvent = (ushort)this.eventsRunEvent.Value;
        }
        private void eventsLengthOverOne_CheckedChanged(object sender, EventArgs e)
        {
            if (eventsLengthOverOne.Checked) eventsLengthOverOne.ForeColor = Color.Black;
            else eventsLengthOverOne.ForeColor = Color.Gray;

            if (updatingLevel) return;

            if (!CalculateFreeEventSpace())
            {
                events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
                events.LengthOverOne = this.eventsLengthOverOne.Checked;

                overlay.DrawLevelEvents(events);
                pictureBoxLevel.Invalidate();

                events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
                RefreshEventFieldProperties();
            }
            else
            {
                eventsLengthOverOne.ForeColor = Color.Gray;
                eventsLengthOverOne.Checked = false;
            }
        }
        private void eventsFieldHeight_ValueChanged(object sender, EventArgs e)
        {
            if (updatingLevel) return;

            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
            events.FieldHeight = (byte)this.eventsFieldHeight.Value;

            overlay.DrawLevelEvents(events);
            pictureBoxLevel.Invalidate();

            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
        }
        private void eventsFieldLength_ValueChanged(object sender, EventArgs e)
        {
            if (updatingLevel) return;

            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
            events.FieldWidth = (byte)this.eventsFieldLength.Value;

            overlay.DrawLevelEvents(events);
            pictureBoxLevel.Invalidate();

            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
        }
        private void eventsFieldZCoord_ValueChanged(object sender, EventArgs e)
        {
            if (updatingLevel) return;

            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
            events.FieldCoordZ = (byte)this.eventsFieldZCoord.Value;

            overlay.DrawLevelEvents(events);
            pictureBoxLevel.Invalidate();

            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
        }
        private void eventsFieldYCoord_ValueChanged(object sender, EventArgs e)
        {
            if (updatingLevel) return;

            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
            events.FieldCoordY = (byte)this.eventsFieldYCoord.Value;

            if (!waitBothCoords)
            {
                overlay.DrawLevelEvents(events);
                pictureBoxLevel.Invalidate();
            }

            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
        }
        private void eventsFieldXCoord_ValueChanged(object sender, EventArgs e)
        {
            if (updatingLevel) return;

            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
            events.FieldCoordX = (byte)this.eventsFieldXCoord.Value;

            if (!waitBothCoords)
            {
                overlay.DrawLevelEvents(events);
                pictureBoxLevel.Invalidate();
            }

            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
        }
        private void eventsFieldRadialPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingLevel) return;

            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
            events.FieldRadialPosition = (byte)this.eventsFieldRadialPosition.SelectedIndex;

            overlay.DrawLevelEvents(events);
            pictureBoxLevel.Invalidate();

            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
        }
        private void eventsInsertField_Click(object sender, EventArgs e)
        {
            Point o = new Point(Math.Abs(pictureBoxLevel.Left), Math.Abs(pictureBoxLevel.Top));
            Point p = new Point(physicalMap.OrthCoordsX[o.Y * 1024 + o.X] + 2, physicalMap.OrthCoordsY[o.Y * 1024 + o.X] + 4);
            if (!CalculateFreeEventSpace())
            {
                this.eventsFieldTree.Focus();
                if (events.NumberOfEvents < 28)
                {
                    if (eventsFieldTree.Nodes.Count > 0)
                        events.AddNewEvent(eventsFieldTree.SelectedNode.Index + 1, p);
                    else
                        events.AddNewEvent(0, p);

                    int reselect;

                    if (eventsFieldTree.Nodes.Count > 0)
                        reselect = eventsFieldTree.SelectedNode.Index;
                    else
                        reselect = -1;

                    eventsFieldTree.BeginUpdate();
                    this.eventsFieldTree.Nodes.Clear();

                    for (int i = 0; i < events.NumberOfEvents; i++)
                        this.eventsFieldTree.Nodes.Add(new TreeNode("EVENT #" + i.ToString()));

                    this.eventsFieldTree.SelectedNode = this.eventsFieldTree.Nodes[reselect + 1];
                    eventsFieldTree.EndUpdate();
                }
                else
                    MessageBox.Show("WARNING: Cannot insert anymore event fields. The maximum number of event fields allowed is 28.", "WARNING: Cannot insert any more event fields", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void eventsDeleteField_Click(object sender, EventArgs e)
        {
            this.eventsFieldTree.Focus();
            if (this.eventsFieldTree.SelectedNode != null && events.CurrentEvent == this.eventsFieldTree.SelectedNode.Index)
            {
                events.RemoveCurrentEvent();

                int reselect = eventsFieldTree.SelectedNode.Index;
                if (reselect == eventsFieldTree.Nodes.Count - 1)
                    reselect--;

                eventsFieldTree.BeginUpdate();
                this.eventsFieldTree.Nodes.Clear();

                for (int i = 0; i < events.NumberOfEvents; i++)
                    this.eventsFieldTree.Nodes.Add(new TreeNode("EVENT #" + i.ToString()));

                if (eventsFieldTree.Nodes.Count > 0)
                    this.eventsFieldTree.SelectedNode = this.eventsFieldTree.Nodes[reselect];
                else
                {
                    this.eventsFieldTree.SelectedNode = null;

                    overlay.DrawLevelEvents(events);
                    pictureBoxLevel.Invalidate();

                    RefreshEventFieldProperties();
                }
                eventsFieldTree.EndUpdate();
            }
        }
        private void eventsWidthXPlusHalf_CheckedChanged(object sender, EventArgs e)
        {
            if (eventsWidthXPlusHalf.Checked) eventsWidthXPlusHalf.ForeColor = Color.Black;
            else eventsWidthXPlusHalf.ForeColor = Color.Gray;
            if (updatingLevel) return;

            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
            events.FieldWidthXPlusHalf = this.eventsWidthXPlusHalf.Checked;

            overlay.DrawLevelEvents(events);
            pictureBoxLevel.Invalidate();

            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
            RefreshEventFieldProperties();
        }
        private void eventsWidthYPlusHalf_CheckedChanged(object sender, EventArgs e)
        {
            if (eventsWidthYPlusHalf.Checked) eventsWidthYPlusHalf.ForeColor = Color.Black;
            else eventsWidthYPlusHalf.ForeColor = Color.Gray;
            if (updatingLevel) return;

            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
            events.FieldWidthYPlusHalf = this.eventsWidthYPlusHalf.Checked;

            overlay.DrawLevelEvents(events);
            pictureBoxLevel.Invalidate();

            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
            RefreshExitFieldProperties();
        }

        private void buttonGotoC_Click(object sender, EventArgs e)
        {
            if (model.Program.Scripts == null || !model.Program.Scripts.Visible)
                model.Program.CreateScriptsWindow();

            model.Program.Scripts.TabControlScripts.SelectedIndex = 0;
            model.Program.Scripts.EventName.SelectedIndex = 0;
            model.Program.Scripts.EventNum.Value = eventsExitEvent.Value;
            model.Program.Scripts.BringToFront();
        }
        private void buttonGotoD_Click(object sender, EventArgs e)
        {
            if (model.Program.Scripts == null || !model.Program.Scripts.Visible)
                model.Program.CreateScriptsWindow();

            model.Program.Scripts.TabControlScripts.SelectedIndex = 0;
            model.Program.Scripts.EventName.SelectedIndex = 0;
            model.Program.Scripts.EventNum.Value = eventsRunEvent.Value;
            model.Program.Scripts.BringToFront();
        }

        #endregion
    }
}
