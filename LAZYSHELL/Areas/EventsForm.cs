using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LazyShell.Areas
{
    public partial class EventsForm : Controls.DockForm
    {
        #region Variables

        public int Index
        {
            get { return listBox.SelectedIndex; }
            set { listBox.SelectedIndex = value; }
        }
        private EventTriggerCollection triggers
        {
            get { return area.EventTriggers; }
            set { area.EventTriggers = value; }
        }
        public EventTrigger Trigger
        {
            get
            {
                if (Index >= 0 && Index < triggers.Count)
                    return triggers[Index];
                return null;
            }
            set
            {
                if (Index >= 0 && Index < triggers.Count)
                    triggers[Index] = value;
            }
        }
        private EventTrigger copiedTrigger;
        private Area area
        {
            get { return ownerForm.Area; }
            set { ownerForm.Area = value; }
        }
        private OwnerForm ownerForm;
        private PictureBox picture
        {
            get { return ownerForm.Picture; }
        }
        private Collision collision;
        private int zoom
        {
            get { return ownerForm.Zoom; }
        }

        #endregion

        public EventsForm(OwnerForm ownerForm)
        {
            this.ownerForm = ownerForm;
            //this.MdiParent = ownerForm;

            InitializeComponent();
            InitializeVariables();
        }

        #region Methods

        private void InitializeVariables()
        {
            collision = Collision.Instance;
        }
        //
        public void LoadProperties()
        {
            BuildListBox(0);
            LoadEventProperties();
        }
        private void LoadEventProperties()
        {
            this.Updating = true;
            //
            if (triggers.Count > 0 && Trigger != null)
            {
                this.runEvent.Value = Trigger.RunEvent;
                this.x.Value = Trigger.X;
                this.y.Value = Trigger.Y;
                this.z.Value = Trigger.Z;
                this.f.SelectedIndex = Trigger.F;
                this.width.Value = Trigger.Width + 1;
                this.height.Value = Trigger.Height;
                this.x_half.Checked = Trigger.EnableEdgeX;
                this.y_half.Checked = Trigger.EnableEdgeY;
                //
                EnableToolStripControls(true);
                EnableAllAccessibleControls(true);
            }
            else
            {
                ResetPropertyControls();
                EnableToolStripControls(false);
                EnableAllAccessibleControls(false);
            }
            //
            this.Updating = false;
        }
        //
        private void BuildListBox(int selectedIndex)
        {
            this.Updating = true;
            //
            this.listBox.Items.Clear();
            for (int i = 0; i < triggers.Count; i++)
            {
                this.listBox.Items.Add("EVENT #" + i.ToString());
            }
            if (selectedIndex >= 0 && listBox.Items.Count > selectedIndex)
                this.listBox.SelectedIndex = selectedIndex;
            else if (listBox.Items.Count > 0)
                this.listBox.SelectedIndex = 0;
            //
            SetFreeBytesLabel();
            //
            this.Updating = false;
        }
        //
        private void EnableToolStripControls(bool enabled)
        {
            this.delete.Enabled = enabled;
            this.copy.Enabled = enabled;
            this.paste.Enabled = enabled;
            this.duplicate.Enabled = enabled;
        }
        private void EnableAllAccessibleControls(bool enabled)
        {
            this.runEvent.Enabled = enabled;
            this.x.Enabled = enabled;
            this.y.Enabled = enabled;
            this.z.Enabled = enabled;
            this.f.Enabled = enabled;
            this.width.Enabled = enabled;
            this.height.Enabled = enabled;
            this.x_half.Enabled = enabled;
            this.y_half.Enabled = enabled;
            this.openEventsForm.Enabled = enabled;
        }
        private void ResetPropertyControls()
        {
            this.Updating = true;
            //
            this.runEvent.Enabled = false;
            this.x.Enabled = false;
            this.y.Enabled = false;
            this.z.Enabled = false;
            this.f.Enabled = false;
            this.width.Enabled = false;
            this.height.Enabled = false;
            this.x_half.Enabled = false;
            this.y_half.Enabled = false;
            this.runEvent.Value = 0;
            this.x.Value = 0;
            this.y.Value = 0;
            this.z.Value = 0;
            this.f.SelectedIndex = 0;
            this.width.Value = 1;
            this.height.Value = 0;
            this.x_half.Checked = false;
            this.y_half.Checked = false;
            this.openEventsForm.Enabled = false;
            //
            this.Updating = false;
        }
        private void SetFreeBytesLabel()
        {
            int freeEventSpace = Model.FreeEventSpace();
            bytesLeft.Text = freeEventSpace + " bytes left";
            bytesLeft.BackColor = freeEventSpace >= 0 ? SystemColors.Control : Color.Red;
        }
        //
        private void AddNew(EventTrigger newEvent)
        {
            if (Model.FreeEventSpace() >= 6)
            {
                this.listBox.Focus();
                if (triggers.Count < 28)
                {
                    if (listBox.Items.Count > 0)
                        triggers.Insert(Index + 1, newEvent);
                    else
                        triggers.Insert(0, newEvent);
                    int reselect;
                    if (listBox.Items.Count > 0)
                        reselect = Index;
                    else
                        reselect = -1;
                    BuildListBox(reselect);
                }
                else
                    MessageBox.Show("Could not insert any more event fields. The maximum number of event fields allowed per area is 28.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Could not insert the field. " + Model.MaximumSpaceExceeded("events"),
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //
        public void SetCoords(int x, int y)
        {
            this.x.Value = x;
            this.y.Value = y;
        }

        #endregion

        #region Event Handlers

        // Toolstrip
        private void insert_Click(object sender, EventArgs e)
        {
            Point o = new Point(Math.Abs(picture.Left) / zoom, Math.Abs(picture.Top) / zoom);
            Point p = new Point(collision.PixelCoords[o.Y * 1024 + o.X].X + 2, collision.PixelCoords[o.Y * 1024 + o.X].Y + 4);
            if (Model.FreeEventSpace() >= 6)
            {
                this.listBox.Focus();
                if (triggers.Count < 28)
                {
                    if (listBox.Items.Count > 0)
                        triggers.Insert(Index + 1, p);
                    else
                        triggers.Insert(0, p);
                    int reselect;
                    if (listBox.Items.Count > 0)
                        reselect = Index;
                    else
                        reselect = -1;
                    BuildListBox(reselect);
                }
                else
                    MessageBox.Show("Could not insert any more event fields. The maximum number of event fields allowed per area is 28.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Could not insert the field. " + Model.MaximumSpaceExceeded("events"),
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void delete_Click(object sender, EventArgs e)
        {
            this.listBox.Focus();
            if (Index >= 0)
            {
                triggers.Remove(Trigger);
                int reselect = Index;
                if (reselect == listBox.Items.Count - 1)
                    reselect--;
                BuildListBox(reselect);
                LoadEventProperties();
                picture.Invalidate();
            }
        }
        private void copy_Click(object sender, EventArgs e)
        {
            if (Index >= 0)
                copiedTrigger = Trigger.Copy();
        }
        private void paste_Click(object sender, EventArgs e)
        {
            if (copiedTrigger == null)
                return;
            AddNew(copiedTrigger);
        }
        private void duplicate_Click(object sender, EventArgs e)
        {
            AddNew(Trigger.Copy());
        }
        // List
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                LoadEventProperties();
                picture.Invalidate();
            }
        }
        private void runEvent_ValueChanged(object sender, EventArgs e)
        {
            if (Trigger != null)
                Trigger.RunEvent = (ushort)this.runEvent.Value;
            if (!this.Updating)
                picture.Invalidate();
        }
        private void openEventsForm_Click(object sender, EventArgs e)
        {
            if (LazyShell.Model.Program.EventScripts == null || !LazyShell.Model.Program.EventScripts.Visible)
                LazyShell.Model.Program.CreateEventScriptsWindow();
            LazyShell.Model.Program.EventScripts.Type = 0;
            LazyShell.Model.Program.EventScripts.Index = (int)runEvent.Value;
            LazyShell.Model.Program.EventScripts.BringToFront();
        }
        // Coordinates
        private void width_ValueChanged(object sender, EventArgs e)
        {
            if (Trigger != null)
                Trigger.Width = (byte)(this.width.Value - 1);
            if (!this.Updating)
                picture.Invalidate();
        }
        private void height_ValueChanged(object sender, EventArgs e)
        {
            if (Trigger != null)
                Trigger.Height = (byte)this.height.Value;
            if (!this.Updating)
                picture.Invalidate();
        }
        private void x_ValueChanged(object sender, EventArgs e)
        {
            if (Trigger != null)
                Trigger.X = (byte)this.x.Value;
            if (!this.Updating)
                picture.Invalidate();
        }
        private void y_ValueChanged(object sender, EventArgs e)
        {
            if (Trigger != null)
                Trigger.Y = (byte)this.y.Value;
            if (!this.Updating)
                picture.Invalidate();
        }
        private void z_ValueChanged(object sender, EventArgs e)
        {
            if (Trigger != null)
                Trigger.Z = (byte)this.z.Value;
            if (!this.Updating)
                picture.Invalidate();
        }
        private void f_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Trigger != null)
                Trigger.F = (byte)this.f.SelectedIndex;
            if (!this.Updating)
                picture.Invalidate();
        }
        private void x_half_CheckedChanged(object sender, EventArgs e)
        {
            x_half.ForeColor = x_half.Checked ? Color.Black : Color.Gray;
            if (Trigger != null)
                Trigger.EnableEdgeX = this.x_half.Checked;
            if (!this.Updating)
                LoadEventProperties();
        }
        private void y_half_CheckedChanged(object sender, EventArgs e)
        {
            y_half.ForeColor = y_half.Checked ? Color.Black : Color.Gray;
            if (Trigger != null)
                Trigger.EnableEdgeY = this.y_half.Checked;
            if (!this.Updating)
                LoadEventProperties();
        }

        #endregion
    }
}
