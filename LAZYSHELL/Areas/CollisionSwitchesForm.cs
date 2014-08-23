using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL.Areas
{
    public partial class CollisionSwitchesForm : Controls.DockForm
    {
        #region Variables

        public int Index
        {
            get { return listBox.SelectedIndex; }
            set { listBox.SelectedIndex = value; }
        }
        private CollisionSwitchCollection collisionSwitches
        {
            get { return area.CollisionSwitches; }
            set { area.CollisionSwitches = value; }
        }
        public CollisionSwitch CollisionSwitch
        {
            get
            {
                if (Index >= 0 && Index < collisionSwitches.Count)
                    return collisionSwitches[Index];
                return null;
            }
            set
            {
                if (Index >= 0 && Index < collisionSwitches.Count)
                    collisionSwitches[Index] = value;
            }
        }
        private CollisionSwitch copiedCollisionSwitch;
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
        private Collision collision = Collision.Instance;
        private int zoom
        {
            get { return ownerForm.Zoom; }
        }

        #endregion

        public CollisionSwitchesForm(OwnerForm ownerForm)
        {
            this.ownerForm = ownerForm;
            InitializeComponent();
        }

        #region Methods

        public void LoadProperties()
        {
            BuildListBox(0);
            LoadCollisionSwitchProperties();
        }
        private void LoadCollisionSwitchProperties()
        {
            this.Updating = true;
            //
            if (CollisionSwitch != null)
            {
                x.Value = CollisionSwitch.X;
                y.Value = CollisionSwitch.Y;
                width.Value = CollisionSwitch.Width;
                height.Value = CollisionSwitch.Height;
                //
                EnableToolStripControls(true);
                EnableAllAccessibleControls(true);
            }
            else
            {
                EnableToolStripControls(false);
                EnableAllAccessibleControls(false);
                ResetPropertyControls();
            }
            //
            this.Updating = false;
        }
        //
        private void BuildListBox(int selectedIndex)
        {
            this.Updating = true;
            //
            this.listBox.BeginUpdate();
            this.listBox.Items.Clear();
            for (int i = 0; i < collisionSwitches.Count; i++)
                this.listBox.Items.Add("SWITCH #" + i.ToString());
            if (selectedIndex >= 0 && selectedIndex < this.listBox.Items.Count)
                this.listBox.SelectedIndex = selectedIndex;
            this.listBox.EndUpdate();
            //
            SetBytesLeftLabel();
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
            this.moveUp.Enabled = enabled;
            this.moveDown.Enabled = enabled;
        }
        private void EnableAllAccessibleControls(bool enabled)
        {
            x.Enabled = enabled;
            y.Enabled = enabled;
            width.Enabled = enabled;
            height.Enabled = enabled;
        }
        private void ResetPropertyControls()
        {
            x.Value = 0;
            y.Value = 0;
            width.Value = 1;
            height.Value = 1;
        }
        //
        private void SetBytesLeftLabel()
        {
            int freeCollisionSwitchSpace = Model.FreeCollisionSwitchSpace();
            bytesLeft.Text = freeCollisionSwitchSpace + " bytes left";
            bytesLeft.BackColor = freeCollisionSwitchSpace >= 0 ? SystemColors.Control : Color.Red;
        }
        public void SetCoords(int x, int y)
        {
            this.x.Value = x;
            this.y.Value = y;
        }
        //
        private void AddNew(CollisionSwitch collisionSwitch)
        {
            if (Model.FreeCollisionSwitchSpace() >= collisionSwitch.Length)
            {
                this.listBox.Focus();
                if (collisionSwitches.CollisionSwitches.Count < 32)
                {
                    if (listBox.Items.Count > 0)
                        collisionSwitches.Insert(Index + 1, collisionSwitch);
                    else
                        collisionSwitches.Insert(0, collisionSwitch);
                    int index;
                    if (listBox.Items.Count > 0)
                        index = Index;
                    else
                        index = -1;
                    BuildListBox(index + 1);
                }
                else
                    MessageBox.Show("Could not insert any more collision switches. The maximum number of collision switches allowed per area is 32.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Could not insert the switch. " + Model.MaximumSpaceExceeded("collision switch"),
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //

        #endregion

        #region Event handlers

        // ToolStrip
        private void insert_Click(object sender, EventArgs e)
        {
            Point o = new Point(Math.Abs(picture.Left) / zoom, Math.Abs(picture.Top) / zoom);
            Point p = new Point(collision.PixelCoords[o.Y * 1024 + o.X].X + 2, collision.PixelCoords[o.Y * 1024 + o.X].Y + 4);
            if (Model.FreeCollisionSwitchSpace() >= 4)
            {
                this.listBox.Focus();
                if (collisionSwitches.CollisionSwitches.Count < 32)
                {
                    int index = this.Index;
                    if (listBox.Items.Count > 0)
                        collisionSwitches.Insert(index + 1, p);
                    else
                        collisionSwitches.Insert(0, p);
                    if (listBox.Items.Count == 0)
                        index = -1;
                    BuildListBox(index + 1);
                    LoadCollisionSwitchProperties();
                }
                else
                    MessageBox.Show("Could not insert any more collision switches. The maximum number of collision switches allowed per area is 32.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Could not insert the collision switch. " + Model.MaximumSpaceExceeded("collision switches"),
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void delete_Click(object sender, EventArgs e)
        {
            int index = this.Index;
            collisionSwitches.CollisionSwitches.RemoveAt(index);
            this.listBox.Items.RemoveAt(index);
            if (index >= this.listBox.Items.Count)
                index--;
            BuildListBox(index);
            LoadCollisionSwitchProperties();
        }
        private void copy_Click(object sender, EventArgs e)
        {
            if (CollisionSwitch != null)
                copiedCollisionSwitch = CollisionSwitch.Copy();
        }
        private void paste_Click(object sender, EventArgs e)
        {
            if (copiedCollisionSwitch != null)
                AddNew(copiedCollisionSwitch);
        }
        private void duplicate_Click(object sender, EventArgs e)
        {
            if (CollisionSwitch != null)
                AddNew(CollisionSwitch.Copy());
        }
        private void moveUp_Click(object sender, EventArgs e)
        {
            if (this.Index > 0)
            {
                int index = this.Index - 1;
                collisionSwitches.Reverse(Index - 1, 2);
                BuildListBox(index);
            }
        }
        private void moveDown_Click(object sender, EventArgs e)
        {
            if (Index < collisionSwitches.Count - 1)
            {
                int index = this.Index + 1;
                collisionSwitches.Reverse(Index, 2);
                BuildListBox(index);
            }
        }
        // ListBox
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                LoadCollisionSwitchProperties();
                picture.Invalidate();
            }
        }
        // Coordinates
        private void x_ValueChanged(object sender, EventArgs e)
        {
            if (CollisionSwitch != null)
            {
                CollisionSwitch.X = (int)x.Value;
                CollisionSwitch.Pixels = collision.GetTilemapPixels(CollisionSwitch);
            }
            if (!this.Updating)
                picture.Invalidate();
        }
        private void y_ValueChanged(object sender, EventArgs e)
        {
            if (CollisionSwitch != null)
            {
                CollisionSwitch.Y = (int)y.Value;
                CollisionSwitch.Pixels = collision.GetTilemapPixels(CollisionSwitch);
            }
            if (!this.Updating)
                picture.Invalidate();
        }
        private void width_ValueChanged(object sender, EventArgs e)
        {
            if (CollisionSwitch != null && !this.Updating)
            {
                int oldWidth = CollisionSwitch.Width;
                CollisionSwitch.Width = (int)width.Value;
                if (Model.FreeCollisionSwitchSpace() < 0)
                {
                    CollisionSwitch.Width = oldWidth;
                    MessageBox.Show("Could not change the width. There is not enough free space available.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (oldWidth != CollisionSwitch.Width)
                    CollisionSwitch.ResizeTilemaps();
                CollisionSwitch.Pixels = collision.GetTilemapPixels(CollisionSwitch);
                SetBytesLeftLabel();
                picture.Invalidate();
            }
        }
        private void height_ValueChanged(object sender, EventArgs e)
        {
            if (CollisionSwitch != null && !this.Updating)
            {
                int oldHeight = CollisionSwitch.Height;
                CollisionSwitch.Height = (int)height.Value;
                if (Model.FreeCollisionSwitchSpace() < 0)
                {
                    CollisionSwitch.Height = oldHeight;
                    MessageBox.Show("Could not change the height. There is not enough free space available.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (oldHeight != CollisionSwitch.Height)
                    CollisionSwitch.ResizeTilemaps();
                CollisionSwitch.Pixels = collision.GetTilemapPixels(CollisionSwitch);
                SetBytesLeftLabel();
                picture.Invalidate();
            }
        }

        #endregion
    }
}
