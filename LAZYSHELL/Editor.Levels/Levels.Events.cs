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

        private LevelEvents events; // Events for the current level
        private Object copyEvent;

        #endregion

        #region Methods

        private void InitializeEventFieldProperties()
        {
            updatingProperties = true;

            this.eventMusic.SelectedIndex = events.Music;
            this.eventExit.Value = events.ExitEvent;

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
                this.eventEvent.Value = events.RunEvent;
                this.eventX.Value = events.X;
                this.eventY.Value = events.Y;
                this.eventZ.Value = events.FieldCoordZ;
                this.eventFace.SelectedIndex = events.FieldRadialPosition;
                this.eventLength.Value = events.FieldWidth + 1;
                this.eventHeight.Value = events.FieldHeight;
                this.eventsWidthXPlusHalf.Checked = events.FieldWidthXPlusHalf;
                this.eventsWidthYPlusHalf.Checked = events.FieldWidthYPlusHalf;

                foreach (ToolStripItem item in toolStrip6.Items)
                    item.Enabled = true;
                this.eventEvent.Enabled = true;
                this.eventX.Enabled = true;
                this.eventY.Enabled = true;
                this.eventZ.Enabled = true;
                this.eventFace.Enabled = true;
                this.eventLength.Enabled = true;
                this.eventHeight.Enabled = true;
                this.eventsWidthXPlusHalf.Enabled = true;
                this.eventsWidthYPlusHalf.Enabled = true;

                this.buttonGotoD.Enabled = true;
            }
            else
            {
                foreach (ToolStripItem item in toolStrip6.Items)
                    if (item != eventsInsertField)
                        item.Enabled = false;
                this.eventEvent.Enabled = false;
                this.eventX.Enabled = false;
                this.eventY.Enabled = false;
                this.eventZ.Enabled = false;
                this.eventFace.Enabled = false;
                this.eventLength.Enabled = false;
                this.eventHeight.Enabled = false;
                this.eventsWidthXPlusHalf.Enabled = false;
                this.eventsWidthYPlusHalf.Enabled = false;

                this.eventEvent.Value = 0;
                this.eventX.Value = 0;
                this.eventY.Value = 0;
                this.eventZ.Value = 0;
                this.eventFace.SelectedIndex = 0;
                this.eventLength.Value = 1;
                this.eventHeight.Value = 0;
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
            updating = true;

            if (events.NumberOfEvents != 0 && this.eventsFieldTree.SelectedNode != null)
            {
                events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
                this.eventEvent.Value = events.RunEvent;
                this.eventX.Value = events.X;
                this.eventY.Value = events.Y;
                this.eventZ.Value = events.FieldCoordZ;
                this.eventFace.SelectedIndex = events.FieldRadialPosition;
                this.eventLength.Value = events.FieldWidth + 1;
                this.eventHeight.Value = events.FieldHeight;
                this.eventsWidthXPlusHalf.Checked = events.FieldWidthXPlusHalf;
                this.eventsWidthYPlusHalf.Checked = events.FieldWidthYPlusHalf;

                foreach (ToolStripItem item in toolStrip6.Items)
                    item.Enabled = true;
                this.eventEvent.Enabled = true;
                this.eventX.Enabled = true;
                this.eventY.Enabled = true;
                this.eventZ.Enabled = true;
                this.eventFace.Enabled = true;
                this.eventLength.Enabled = true;
                this.eventHeight.Enabled = true;
                this.eventsWidthXPlusHalf.Enabled = true;
                this.eventsWidthYPlusHalf.Enabled = true;

                this.buttonGotoD.Enabled = true;
            }
            else
            {
                foreach (ToolStripItem item in toolStrip6.Items)
                    if (item != eventsInsertField)
                        item.Enabled = false;
                this.eventEvent.Enabled = false;
                this.eventX.Enabled = false;
                this.eventY.Enabled = false;
                this.eventZ.Enabled = false;
                this.eventFace.Enabled = false;
                this.eventLength.Enabled = false;
                this.eventHeight.Enabled = false;
                this.eventsWidthXPlusHalf.Enabled = false;
                this.eventsWidthYPlusHalf.Enabled = false;

                this.eventEvent.Value = 0;
                this.eventX.Value = 0;
                this.eventY.Value = 0;
                this.eventZ.Value = 0;
                this.eventFace.SelectedIndex = 0;
                this.eventLength.Value = 1;
                this.eventHeight.Value = 0;
                this.eventsWidthXPlusHalf.Checked = false;
                this.eventsWidthYPlusHalf.Checked = false;

                this.buttonGotoD.Enabled = false;
            }
            updating = false;
        }

        public int CalculateFreeEventSpace()
        {
            int used = 0;

            for (int i = 0; i < 512; i++)
            {
                used += 3; // for the music and initial event
                for (int j = 0; j < levels[i].LevelEvents.NumberOfEvents; j++)
                {
                    levels[i].LevelEvents.CurrentEvent = j;
                    used += levels[i].LevelEvents.GetEventLength();
                }
            }
            return 0x1BFF - used;
        }

        #endregion

        #region Event Handlers

        public TreeView EventsFieldTree { get { return eventsFieldTree; } set { eventsFieldTree = value; } }
        private void eventsFieldTree_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
            events.SelectedEvent = this.eventsFieldTree.SelectedNode.Index;

            overlay.DrawLevelEvents(events);

            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
            RefreshEventFieldProperties();
            levelsTilemap.Picture.Invalidate();
        }
        private void eventsExitEvent_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            events.ExitEvent = (ushort)this.eventExit.Value;
        }
        private void eventsAreaMusic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;

            events.Music = (byte)this.eventMusic.SelectedIndex;
        }
        private void eventsRunEvent_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            events.RunEvent = (ushort)this.eventEvent.Value;
        }
        private void eventsFieldHeight_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
            events.FieldHeight = (byte)this.eventHeight.Value;

            overlay.DrawLevelEvents(events);


            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
            levelsTilemap.Picture.Invalidate();
        }
        private void eventsFieldLength_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
            events.FieldWidth = (byte)(this.eventLength.Value - 1);

            overlay.DrawLevelEvents(events);


            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
            levelsTilemap.Picture.Invalidate();
        }
        public NumericUpDown EventX { get { return eventX; } set { eventX = value; } }
        public NumericUpDown EventY { get { return eventY; } set { eventY = value; } }
        private void eventsFieldZCoord_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
            events.FieldCoordZ = (byte)this.eventZ.Value;

            overlay.DrawLevelEvents(events);


            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
            levelsTilemap.Picture.Invalidate();
        }
        private void eventsFieldYCoord_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
            events.Y = (byte)this.eventY.Value;

            if (!updatingProperties)
                overlay.DrawLevelEvents(events);

            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
            levelsTilemap.Picture.Invalidate();
        }
        private void eventsFieldXCoord_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
            events.X = (byte)this.eventX.Value;

            if (!updatingProperties)
                overlay.DrawLevelEvents(events);

            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
            levelsTilemap.Picture.Invalidate();
        }
        private void eventsFieldRadialPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;

            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
            events.FieldRadialPosition = (byte)this.eventFace.SelectedIndex;

            overlay.DrawLevelEvents(events);

            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
            levelsTilemap.Picture.Invalidate();
        }
        private void eventsInsertField_Click(object sender, EventArgs e)
        {
            Point o = new Point(Math.Abs(levelsTilemap.Picture.Left), Math.Abs(levelsTilemap.Picture.Top));
            Point p = new Point(physicalMap.PixelCoords[o.Y * 1024 + o.X].X + 2, physicalMap.PixelCoords[o.Y * 1024 + o.X].Y + 4);
            if (CalculateFreeEventSpace() >= 6)
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
                    MessageBox.Show("Could not insert any more event fields. The maximum number of event fields allowed is 28.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Could not insert the field. The total number of events for all levels has exceeded the maximum allotted space.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


                    RefreshEventFieldProperties();
                    levelsTilemap.Picture.Invalidate();
                }
                eventsFieldTree.EndUpdate();
            }
        }
        private void eventsWidthXPlusHalf_CheckedChanged(object sender, EventArgs e)
        {
            if (eventsWidthXPlusHalf.Checked) eventsWidthXPlusHalf.ForeColor = Color.Black;
            else eventsWidthXPlusHalf.ForeColor = Color.Gray;
            if (updating) return;

            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
            events.FieldWidthXPlusHalf = this.eventsWidthXPlusHalf.Checked;

            overlay.DrawLevelEvents(events);


            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
            RefreshEventFieldProperties();
        }
        private void eventsWidthYPlusHalf_CheckedChanged(object sender, EventArgs e)
        {
            if (eventsWidthYPlusHalf.Checked) eventsWidthYPlusHalf.ForeColor = Color.Black;
            else eventsWidthYPlusHalf.ForeColor = Color.Gray;
            if (updating) return;

            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
            events.FieldWidthYPlusHalf = this.eventsWidthYPlusHalf.Checked;

            overlay.DrawLevelEvents(events);


            events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
            RefreshExitFieldProperties();
        }

        private void buttonGotoC_Click(object sender, EventArgs e)
        {
            if (model.Program.EventScripts == null || !model.Program.EventScripts.Visible)
                model.Program.CreateEventScriptsWindow();

            model.Program.EventScripts.EventName.SelectedIndex = 0;
            model.Program.EventScripts.EventNum.Value = eventExit.Value;
            model.Program.EventScripts.BringToFront();
        }
        private void buttonGotoD_Click(object sender, EventArgs e)
        {
            if (model.Program.EventScripts == null || !model.Program.EventScripts.Visible)
                model.Program.CreateEventScriptsWindow();

            model.Program.EventScripts.EventName.SelectedIndex = 0;
            model.Program.EventScripts.EventNum.Value = eventEvent.Value;
            model.Program.EventScripts.BringToFront();
        }

        #endregion
    }
}
