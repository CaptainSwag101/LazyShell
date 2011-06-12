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

        private LevelEvents events { get { return level.LevelEvents; } set { level.LevelEvents = value; } } // Events for the current level
        private Object copyEvent;
        public TreeView EventsFieldTree { get { return eventsList; } set { eventsList = value; } }
        public NumericUpDown EventX { get { return eventX; } set { eventX = value; } }
        public NumericUpDown EventY { get { return eventY; } set { eventY = value; } }

        #endregion
        #region Methods

        private void InitializeEventFieldProperties()
        {
            updatingProperties = true;

            this.eventMusic.SelectedIndex = events.Music;
            this.eventExit.Value = events.ExitEvent;

            this.eventsList.Nodes.Clear();

            for (int i = 0; i < events.Count; i++)
            {
                this.eventsList.Nodes.Add(new TreeNode("EVENT #" + i.ToString()));
            }

            if (eventsList.Nodes.Count > 0)
                this.eventsList.SelectedNode = this.eventsList.Nodes[0];

            if (events.Count != 0 && this.eventsList.SelectedNode != null)
            {
                events.CurrentEvent = this.eventsList.SelectedNode.Index;
                this.eventEvent.Value = events.RunEvent;
                this.eventX.Value = events.X;
                this.eventY.Value = events.Y;
                this.eventZ.Value = events.Z;
                this.eventFace.SelectedIndex = events.Facing;
                this.eventLength.Value = events.Width + 1;
                this.eventHeight.Value = events.Height;
                this.eventsWidthXPlusHalf.Checked = events.WidthXPlusHalf;
                this.eventsWidthYPlusHalf.Checked = events.WidthYPlusHalf;

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

            eventsBytesLeft.Text = CalculateFreeEventSpace() + " bytes left";
            eventsBytesLeft.BackColor = CalculateFreeEventSpace() >= 0 ? SystemColors.Control : Color.Red;
            updatingProperties = false;

        }
        private void RefreshEventFieldProperties()
        {
            updatingProperties = true;

            if (events.Count != 0 && this.eventsList.SelectedNode != null)
            {
                events.CurrentEvent = this.eventsList.SelectedNode.Index;
                this.eventEvent.Value = events.RunEvent;
                this.eventX.Value = events.X;
                this.eventY.Value = events.Y;
                this.eventZ.Value = events.Z;
                this.eventFace.SelectedIndex = events.Facing;
                this.eventLength.Value = events.Width + 1;
                this.eventHeight.Value = events.Height;
                this.eventsWidthXPlusHalf.Checked = events.WidthXPlusHalf;
                this.eventsWidthYPlusHalf.Checked = events.WidthYPlusHalf;

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
            eventsBytesLeft.Text = CalculateFreeEventSpace() + " bytes left";
            eventsBytesLeft.BackColor = CalculateFreeEventSpace() >= 0 ? SystemColors.Control : Color.Red;

            updatingProperties = false;
        }
        public int CalculateFreeEventSpace()
        {
            int used = 0;

            foreach (Level level in levels)
            {
                used += 3; // for the music and initial event
                foreach (Event EVENT in level.LevelEvents.Events)
                    used += EVENT.GetEventLength();
            }
            return 0x1BFF - used;
        }
        private void AddNewEvent(Event newEvent)
        {
            if (CalculateFreeEventSpace() >= 6)
            {
                this.eventsList.Focus();
                if (events.Count < 28)
                {
                    if (eventsList.Nodes.Count > 0)
                        events.AddNewEvent(eventsList.SelectedNode.Index + 1, newEvent);
                    else
                        events.AddNewEvent(0, newEvent);

                    int reselect;

                    if (eventsList.Nodes.Count > 0)
                        reselect = eventsList.SelectedNode.Index;
                    else
                        reselect = -1;

                    eventsList.BeginUpdate();
                    this.eventsList.Nodes.Clear();

                    for (int i = 0; i < events.Count; i++)
                        this.eventsList.Nodes.Add(new TreeNode("EVENT #" + i.ToString()));

                    this.eventsList.SelectedNode = this.eventsList.Nodes[reselect + 1];
                    eventsList.EndUpdate();
                }
                else
                    MessageBox.Show("Could not insert any more event fields. The maximum number of event fields allowed is 28.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Could not insert the field. The total number of events for all levels has exceeded the maximum allotted space.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
        #region Event Handlers

        private void eventsFieldTree_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            events.CurrentEvent = this.eventsList.SelectedNode.Index;
            events.SelectedEvent = this.eventsList.SelectedNode.Index;

            overlay.DrawLevelEvents(events);

            events.CurrentEvent = this.eventsList.SelectedNode.Index;
            RefreshEventFieldProperties();
            picture.Invalidate();
        }
        private void eventsExitEvent_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;

            events.ExitEvent = (ushort)this.eventExit.Value;
        }
        private void eventsAreaMusic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;

            events.Music = (byte)this.eventMusic.SelectedIndex;
        }
        private void eventsRunEvent_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;

            events.RunEvent = (ushort)this.eventEvent.Value;
            picture.Invalidate();
        }
        private void eventsFieldHeight_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;

            events.CurrentEvent = this.eventsList.SelectedNode.Index;
            events.Height = (byte)this.eventHeight.Value;

            overlay.DrawLevelEvents(events);


            events.CurrentEvent = this.eventsList.SelectedNode.Index;
            picture.Invalidate();
        }
        private void eventsFieldLength_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;

            events.CurrentEvent = this.eventsList.SelectedNode.Index;
            events.Width = (byte)(this.eventLength.Value - 1);

            overlay.DrawLevelEvents(events);


            events.CurrentEvent = this.eventsList.SelectedNode.Index;
            picture.Invalidate();
        }
        private void eventsFieldZCoord_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;

            events.CurrentEvent = this.eventsList.SelectedNode.Index;
            events.Z = (byte)this.eventZ.Value;

            overlay.DrawLevelEvents(events);


            events.CurrentEvent = this.eventsList.SelectedNode.Index;
            picture.Invalidate();
        }
        private void eventsFieldYCoord_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;

            events.CurrentEvent = this.eventsList.SelectedNode.Index;
            events.Y = (byte)this.eventY.Value;

            if (!updatingLevel)
                overlay.DrawLevelEvents(events);

            events.CurrentEvent = this.eventsList.SelectedNode.Index;
            picture.Invalidate();
        }
        private void eventsFieldXCoord_ValueChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;

            events.CurrentEvent = this.eventsList.SelectedNode.Index;
            events.X = (byte)this.eventX.Value;

            if (!updatingLevel)
                overlay.DrawLevelEvents(events);

            events.CurrentEvent = this.eventsList.SelectedNode.Index;
            picture.Invalidate();
        }
        private void eventsFieldRadialPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingProperties) return;

            events.CurrentEvent = this.eventsList.SelectedNode.Index;
            events.Facing = (byte)this.eventFace.SelectedIndex;

            overlay.DrawLevelEvents(events);

            events.CurrentEvent = this.eventsList.SelectedNode.Index;
            picture.Invalidate();
        }
        private void eventsInsertField_Click(object sender, EventArgs e)
        {
            Point o = new Point(Math.Abs(picture.Left) / zoom, Math.Abs(picture.Top) / zoom);
            Point p = new Point(solidity.PixelCoords[o.Y * 1024 + o.X].X + 2, solidity.PixelCoords[o.Y * 1024 + o.X].Y + 4);
            if (CalculateFreeEventSpace() >= 6)
            {
                this.eventsList.Focus();
                if (events.Count < 28)
                {
                    if (eventsList.Nodes.Count > 0)
                        events.AddNewEvent(eventsList.SelectedNode.Index + 1, p);
                    else
                        events.AddNewEvent(0, p);

                    int reselect;

                    if (eventsList.Nodes.Count > 0)
                        reselect = eventsList.SelectedNode.Index;
                    else
                        reselect = -1;

                    eventsList.BeginUpdate();
                    this.eventsList.Nodes.Clear();

                    for (int i = 0; i < events.Count; i++)
                        this.eventsList.Nodes.Add(new TreeNode("EVENT #" + i.ToString()));

                    this.eventsList.SelectedNode = this.eventsList.Nodes[reselect + 1];
                    eventsList.EndUpdate();
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
            this.eventsList.Focus();
            if (this.eventsList.SelectedNode != null && events.CurrentEvent == this.eventsList.SelectedNode.Index)
            {
                events.RemoveCurrentEvent();

                int reselect = eventsList.SelectedNode.Index;
                if (reselect == eventsList.Nodes.Count - 1)
                    reselect--;

                eventsList.BeginUpdate();
                this.eventsList.Nodes.Clear();

                for (int i = 0; i < events.Count; i++)
                    this.eventsList.Nodes.Add(new TreeNode("EVENT #" + i.ToString()));

                if (eventsList.Nodes.Count > 0)
                    this.eventsList.SelectedNode = this.eventsList.Nodes[reselect];
                else
                {
                    this.eventsList.SelectedNode = null;

                    overlay.DrawLevelEvents(events);


                    RefreshEventFieldProperties();
                    picture.Invalidate();
                }
                eventsList.EndUpdate();
            }
        }
        private void eventsWidthXPlusHalf_CheckedChanged(object sender, EventArgs e)
        {
            if (eventsWidthXPlusHalf.Checked) eventsWidthXPlusHalf.ForeColor = Color.Black;
            else eventsWidthXPlusHalf.ForeColor = Color.Gray;
            if (updatingProperties) return;

            events.CurrentEvent = this.eventsList.SelectedNode.Index;
            events.WidthXPlusHalf = this.eventsWidthXPlusHalf.Checked;

            overlay.DrawLevelEvents(events);


            events.CurrentEvent = this.eventsList.SelectedNode.Index;
            RefreshEventFieldProperties();
        }
        private void eventsWidthYPlusHalf_CheckedChanged(object sender, EventArgs e)
        {
            if (eventsWidthYPlusHalf.Checked) eventsWidthYPlusHalf.ForeColor = Color.Black;
            else eventsWidthYPlusHalf.ForeColor = Color.Gray;
            if (updatingProperties) return;

            events.CurrentEvent = this.eventsList.SelectedNode.Index;
            events.WidthYPlusHalf = this.eventsWidthYPlusHalf.Checked;

            overlay.DrawLevelEvents(events);


            events.CurrentEvent = this.eventsList.SelectedNode.Index;
            RefreshExitFieldProperties();
        }
        //
        private void buttonGotoC_Click(object sender, EventArgs e)
        {
            if (Model.Program.EventScripts == null || !Model.Program.EventScripts.Visible)
                Model.Program.CreateEventScriptsWindow();

            Model.Program.EventScripts.EventName.SelectedIndex = 0;
            Model.Program.EventScripts.EventNum.Value = eventExit.Value;
            Model.Program.EventScripts.BringToFront();
        }
        private void buttonGotoD_Click(object sender, EventArgs e)
        {
            if (Model.Program.EventScripts == null || !Model.Program.EventScripts.Visible)
                Model.Program.CreateEventScriptsWindow();

            Model.Program.EventScripts.EventName.SelectedIndex = 0;
            Model.Program.EventScripts.EventNum.Value = eventEvent.Value;
            Model.Program.EventScripts.BringToFront();
        }
        //
        private void eventsCopyField_Click(object sender, EventArgs e)
        {
            if (eventsList.SelectedNode != null)
                copyEvent = events.Event_.Copy();
        }
        private void eventsPasteField_Click(object sender, EventArgs e)
        {
            AddNewEvent((Event)copyEvent);
        }
        private void eventsDuplicateField_Click(object sender, EventArgs e)
        {
            AddNewEvent(events.Event_.Copy());
        }
        #endregion
    }
}
