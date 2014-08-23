using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL.Areas
{
    public partial class ExitsForm : Controls.DockForm
    {
        #region Variables

        public int Index
        {
            get { return listBox.SelectedIndex; }
            set { listBox.SelectedIndex = value; }
        }
        private ExitTriggerCollection triggers
        {
            get { return area.ExitTriggers; }
            set { area.ExitTriggers = value; }
        }
        public ExitTrigger Trigger
        {
            get
            {
                if (Index >= 0)
                    return triggers[Index];
                return null;
            }
            set
            {
                if (Index >= 0)
                    triggers[Index] = value;
            }
        }
        private ExitTrigger copiedExit;
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

        // Constructor
        public ExitsForm(OwnerForm ownerForm)
        {
            this.ownerForm = ownerForm;
            //this.MdiParent = ownerForm;

            InitializeComponent();
        }

        #region Methods

        private void InitializeVariables()
        {
            this.collision = Collision.Instance;
        }
        //
        public void LoadProperties()
        {
            BuildListBox(0);
            LoadExitProperties();
        }
        private void LoadExitProperties()
        {
            SetDestinationList();
            //
            this.Updating = true;
            //
            if (triggers.Count > 0 && Index >= 0)
            {
                this.type.SelectedIndex = Trigger.ExitType;
                this.destination.SelectedIndex = Trigger.Destination;
                this.showBanner.Checked = Trigger.ShowBanner;
                this.x.Value = Trigger.X;
                this.y.Value = Trigger.Y;
                this.z.Value = Trigger.Z;
                this.f.SelectedIndex = Trigger.F;
                this.width.Value = Trigger.Width + 1;
                this.height.Value = Trigger.Height;
                this.x_half.Checked = Trigger.EnableEdgeX;
                this.y_half.Checked = Trigger.EnableEdgeX;
                this.destX.Value = Trigger.DstX;
                this.destY.Value = Trigger.DstY;
                this.destZ.Value = Trigger.DstZ;
                this.destF.SelectedIndex = Trigger.DstF;
                this.destZ_Half.Checked = Trigger.DstYb7;
                //
                EnableToolStripControls(true);
                EnableAllAccessibleControls(true);
                EnableDestinationControls(Trigger.ExitType == 0);
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
        private void SetDestinationList()
        {
            this.Updating = true;
            //
            this.destination.Items.Clear();
            if (Trigger != null)
            {
                if (Trigger.ExitType == 0)
                {
                    this.destination.DropDownWidth = 490;
                    this.destination.Items.AddRange(Lists.Numerize(Lists.Areas));
                }
                else
                {
                    this.destination.DropDownWidth = 200;
                    this.destination.Items.AddRange(Lists.Numerize(WorldMaps.Model.Locations));
                }
                this.destination.SelectedIndex = 0;
            }
            //
            this.Updating = false;
        }
        private void BuildListBox(int selectedIndex)
        {
            this.Updating = true;
            //
            this.listBox.Items.Clear();
            for (int i = 0; i < triggers.Count; i++)
                this.listBox.Items.Add("EXIT #" + i.ToString());
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
            this.destination.Enabled = enabled;
            this.showBanner.Enabled = enabled;
            this.type.Enabled = enabled;
            this.x.Enabled = enabled;
            this.y.Enabled = enabled;
            this.z.Enabled = enabled;
            this.f.Enabled = enabled;
            this.width.Enabled = enabled;
            this.height.Enabled = enabled;
            this.x_half.Enabled = enabled;
            this.y_half.Enabled = enabled;
        }
        private void EnableDestinationControls(bool enabled)
        {
            this.destX.Enabled = enabled;
            this.destY.Enabled = enabled;
            this.destZ.Enabled = enabled;
            this.destF.Enabled = enabled;
            this.destZ_Half.Enabled = enabled;
        }
        private void ResetPropertyControls()
        {
            this.Updating = true;
            //
            this.type.SelectedIndex = 0;
            this.destination.Items.Clear();
            this.showBanner.Checked = false;
            this.x.Value = 0;
            this.y.Value = 0;
            this.z.Value = 0;
            this.f.SelectedIndex = 0;
            this.width.Value = 1;
            this.height.Value = 0;
            this.x_half.Checked = false;
            this.y_half.Checked = false;
            this.destX.Value = 0;
            this.destY.Value = 0;
            this.destZ.Value = 0;
            this.destF.SelectedIndex = 0;
            this.destZ_Half.Checked = false;
            //
            this.Updating = false;
        }
        private void SetFreeBytesLabel()
        {
            int freeExitSpace = Model.FreeExitSpace();
            bytesLeft.Text = freeExitSpace + " bytes left";
            bytesLeft.BackColor = freeExitSpace >= 0 ? SystemColors.Control : Color.Red;
        }
        //
        private void AddNew(ExitTrigger exit)
        {
            if (Model.FreeExitSpace() >= 8)
            {
                this.listBox.Focus();
                if (triggers.Count < 28)
                {
                    if (listBox.Items.Count > 0)
                        triggers.Insert(Index + 1, exit);
                    else
                        triggers.Insert(0, exit);
                    int reselect;
                    if (listBox.Items.Count > 0)
                        reselect = Index;
                    else
                        reselect = -1;
                    BuildListBox(reselect);
                }
                else
                    MessageBox.Show("Could not insert any more exit triggers. The maximum number of exit triggers allowed per area is 28.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Could not insert the trigger. " + Model.MaximumSpaceExceeded("exits"),
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
            if (Model.FreeExitSpace() >= 8)
            {
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
                    MessageBox.Show("Could not insert any more exit triggers. The maximum number of exit triggers allowed per area is 28.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Could not insert the exit trigger. " + Model.MaximumSpaceExceeded("exits"),
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void delete_Click(object sender, EventArgs e)
        {
            if (Trigger != null)
            {
                triggers.Remove(Trigger);
                int reselect = Index;
                if (reselect == listBox.Items.Count - 1)
                    reselect--;
                BuildListBox(reselect);
                LoadExitProperties();
            }
        }
        private void copy_Click(object sender, EventArgs e)
        {
            if (Index >= 0)
                copiedExit = Trigger.Copy();
        }
        private void paste_Click(object sender, EventArgs e)
        {
            if (copiedExit == null)
                return;
            AddNew(copiedExit);
        }
        private void duplicate_Click(object sender, EventArgs e)
        {
            AddNew(Trigger.Copy());
        }
        private void reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current exits. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            triggers = new ExitTriggerCollection(ownerForm.Index);
            LoadProperties();
        }

        // List
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                LoadExitProperties();
                picture.Invalidate();
            }
        }

        // Coordinates
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
        private void x_half_CheckedChanged(object sender, EventArgs e)
        {
            x_half.ForeColor = x_half.Checked ? Color.Black : Color.Gray;
            if (Trigger != null)
                Trigger.EnableEdgeX = this.x_half.Checked;
        }
        private void y_half_CheckedChanged(object sender, EventArgs e)
        {
            y_half.ForeColor = y_half.Checked ? Color.Black : Color.Gray;
            if (Trigger != null)
                Trigger.EnableEdgeY = this.y_half.Checked;
        }

        // Destination
        private void type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Trigger != null)
                Trigger.ExitType = (byte)this.type.SelectedIndex;
            if (!this.Updating && Model.FreeExitSpace() >= 0)
            {
                SetDestinationList();
                EnableDestinationControls(Trigger.ExitType == 0);
                picture.Invalidate();
            }
        }
        private void destination_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                if (Trigger != null)
                    Trigger.Destination = (ushort)this.destination.SelectedIndex;
                picture.Invalidate();
            }
        }
        private void showBanner_CheckedChanged(object sender, System.EventArgs e)
        {
            showBanner.ForeColor = showBanner.Checked ? Color.Black : Color.Gray;
            if (Trigger != null)
                Trigger.ShowBanner = this.showBanner.Checked;
        }
        private void destX_ValueChanged(object sender, EventArgs e)
        {
            if (Trigger != null)
                Trigger.DstX = (byte)this.destX.Value;
        }
        private void destY_ValueChanged(object sender, EventArgs e)
        {
            if (Trigger != null)
                Trigger.DstY = (byte)this.destY.Value;
        }
        private void destZ_ValueChanged(object sender, EventArgs e)
        {
            if (Trigger != null)
                Trigger.DstZ = (byte)this.destZ.Value;
        }
        private void dest_F_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Trigger != null)
                Trigger.DstF = (byte)this.destF.SelectedIndex;
        }
        private void destZ_Half_CheckedChanged(object sender, System.EventArgs e)
        {
            destZ_Half.ForeColor = destZ_Half.Checked ? Color.Black : Color.Gray;
            if (Trigger != null)
                Trigger.DstYb7 = this.destZ_Half.Checked;
        }

        #endregion
    }
}
