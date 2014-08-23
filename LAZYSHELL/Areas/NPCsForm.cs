using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace LAZYSHELL.Areas
{
    public partial class NPCsForm : Controls.DockForm
    {
        #region Variables

        // Forms
        private OwnerForm ownerForm;

        // Elements
        private Area area
        {
            get { return ownerForm.Area; }
            set { ownerForm.Area = value; }
        }
        private Area[] areas
        {
            get { return Model.Areas; }
            set { Model.Areas = value; }
        }
        private NPCObjectCollection npcObjects
        {
            get { return area.NPCObjects; }
            set { area.NPCObjects = value; }
        }
        private NPCEditor npcEditorForm;
        private Collision collision;

        // Selected
        /// <summary>
        /// Retrieves the currently selected NPC in the TreeView.
        /// </summary>
        public NPCObject NPCObject
        {
            get
            {
                if (SelectedNPC >= 0)
                    return npcObjects[SelectedNPC];
                return null;
            }
            set
            {
                if (SelectedNPC >= 0)
                    npcObjects[SelectedNPC] = value;
            }
        }
        /// <summary>
        /// Retrieves the index of the currently selected NPC in the TreeView.
        /// </summary>
        public int SelectedNPC
        {
            get { return listBox.SelectedIndex; }
            set { listBox.SelectedIndex = value; }
        }
        private EngageType EngageType
        {
            get { return NPCObject.EngageType; }
        }

        // Miscellaneous
        private Object copiedNPCObject;

        // Picture
        private PictureBox picture
        {
            get { return ownerForm.Picture; }
        }
        private Overlay overlay
        {
            get { return ownerForm.Overlay; }
            set { ownerForm.Overlay = value; }
        }
        private int zoom
        {
            get { return ownerForm.Zoom; }
        }

        #endregion

        // Constructor
        public NPCsForm(OwnerForm ownerForm)
        {
            this.ownerForm = ownerForm;
            //
            InitializeComponent();
            InitializeHelperForms();
            InitializeForms();
        }

        #region Methods

        private void InitializeVariables()
        {
            this.collision = Collision.Instance;
        }
        private void InitializeHelperForms()
        {
            new ToolTipLabel(this, ownerForm.baseConvertor, ownerForm.helpTips);
        }
        private void InitializeForms()
        {
            npcEditorForm = new NPCEditor(ownerForm);
            npcEditorForm.LoadProperties();
        }
        //
        public void LoadProperties()
        {
            BuildListBox(0);
            LoadNPCProperties();
        }
        private void LoadNPCProperties()
        {
            this.Updating = true;
            //
            if (npcObjects.Count > 0)
            {
                SetEngageTypeControls();
                EnableToolStripButtons(true);
                EnableAllAccessibleControls(true);

                //
                this.engageType.SelectedIndex = (int)NPCObject.EngageType;
                this.engageTrigger.SelectedIndex = NPCObject.EngageTrigger;
                this.action.Value = NPCObject.Action;
                this.npcID.Value = NPCObject.NPCID;
                if (EngageType != EngageType.Battle)
                    this.eventOrPack.Value = NPCObject.Event;
                else
                    this.eventOrPack.Value = NPCObject.Pack;
                this.speedPlus.Value = NPCObject.SpeedPlus;
                this.mem70A7.Value = NPCObject.Mem70A7;
                this.afterBattle.SelectedIndex = NPCObject.AfterBattle;
                this.attributes.SetItemChecked(0, NPCObject.B2b3);
                this.attributes.SetItemChecked(1, NPCObject.B2b4);
                this.attributes.SetItemChecked(2, NPCObject.B2b5);
                this.attributes.SetItemChecked(3, NPCObject.B2b6);
                this.attributes.SetItemChecked(4, NPCObject.B2b7);
                this.attributes.SetItemChecked(5, NPCObject.B3b0);
                this.attributes.SetItemChecked(6, NPCObject.B3b1);
                this.attributes.SetItemChecked(7, NPCObject.B3b2);
                this.attributes.SetItemChecked(8, NPCObject.B3b3);
                this.attributes.SetItemChecked(9, NPCObject.B3b4);
                this.attributes.SetItemChecked(10, NPCObject.B3b5);
                this.attributes.SetItemChecked(11, NPCObject.B3b6);
                this.attributes.SetItemChecked(12, NPCObject.B3b7);
                this.attributes.SetItemChecked(13, NPCObject.B4b0);
                this.attributes.SetItemChecked(14, NPCObject.B4b1);

                // Properties accessible by all NPCObjects
                this.visible.Checked = NPCObject.ShowNPC;
                this.x.Value = NPCObject.X;
                this.y.Value = NPCObject.Y;
                this.z.Value = NPCObject.Z;
                this.f.SelectedIndex = NPCObject.F;
                this.z_half.Checked = NPCObject.ZHalf;
            }
            else // NPC collection is empty
            {
                EnableToolStripButtons(false);
                EnableAllAccessibleControls(false);
                ResetPropertyControls();
            }
            //
            this.Updating = false;
        }
        private void BuildListBox(int selectedIndex)
        {
            this.Updating = true;
            //
            this.listBox.Items.Clear();
            for (int i = 0; i < npcObjects.Count; i++)
                this.listBox.Items.Add("NPC #" + i);
            if (selectedIndex >= 0 && this.listBox.Items.Count > selectedIndex)
                this.listBox.SelectedIndex = selectedIndex;
            else if (this.listBox.Items.Count > 0)
                this.listBox.SelectedIndex = 0;
            //
            SetFreeBytesLabel();
            //
            this.Updating = false;
        }
        /// <summary>
        /// Sets the labels and properties of the controls based on the NPCObject's engage type.
        /// </summary>
        private void SetEngageTypeControls()
        {
            if (EngageType == EngageType.Event)
            {
                // Labels
                this.labelPropertyA.Text = "...";

                // Controls
                this.mem70A7.Enabled = false;
                this.eventOrPack.Maximum = 4095;

                // Buttons
                this.openEventOrPackForm.Text = "Event #";
            }
            else if (EngageType == EngageType.Treasure)
            {
                // Labels
                this.labelPropertyA.Text = "$70A7 = ";

                // Controls
                this.mem70A7.Enabled = true;
                this.eventOrPack.Maximum = 4095;

                // Buttons
                this.openEventOrPackForm.Text = "Event #";
            }
            else if (EngageType == EngageType.Battle)
            {
                // Labels
                this.labelPropertyA.Text = "...";

                // Controls
                this.mem70A7.Enabled = false;
                this.eventOrPack.Maximum = 255;

                // Buttons
                this.openEventOrPackForm.Text = "Pack #";
            }
        }
        /// <summary>
        /// Enables or disables the ToolStrip buttons accessible only if an NPCObject is selected.
        /// </summary>
        private void EnableToolStripButtons(bool enabled)
        {
            this.delete.Enabled = enabled;
            this.insert.Enabled = enabled;
            this.copy.Enabled = enabled;
            this.duplicate.Enabled = enabled;
            this.moveDown.Enabled = enabled;
            this.moveUp.Enabled = enabled;
        }
        /// <summary>
        /// Enables or disables controls accessible to all NPCObjects.
        /// </summary>
        private void EnableAllAccessibleControls(bool enabled)
        {
            this.engageType.Enabled = enabled;
            this.engageTrigger.Enabled = enabled;
            this.npcID.Enabled = enabled;
            this.eventOrPack.Enabled = enabled;
            this.action.Enabled = enabled;
            this.speedPlus.Enabled = enabled;
            this.afterBattle.Enabled = enabled;
            this.attributes.Enabled = enabled;
            this.visible.Enabled = enabled;
            this.x.Enabled = enabled;
            this.y.Enabled = enabled;
            this.z.Enabled = enabled;
            this.f.Enabled = enabled;
            this.z_half.Enabled = enabled;
        }
        /// <summary>
        /// Resets the values of all property controls.
        /// </summary>
        private void ResetPropertyControls()
        {
            this.Updating = true;
            //
            this.engageType.SelectedIndex = 0;
            this.engageTrigger.SelectedIndex = 0;
            this.npcID.Value = 0;
            this.eventOrPack.Value = 0;
            this.action.Value = 0;
            this.speedPlus.Value = 0;
            this.mem70A7.Value = 0;
            this.visible.Checked = false;
            this.x.Value = 0;
            this.y.Value = 0;
            this.z.Value = 0;
            this.f.SelectedIndex = 0;
            this.z_half.Checked = false;
            this.afterBattle.SelectedIndex = 0;
            for (int i = 0; i < attributes.Items.Count; i++)
                attributes.SetItemChecked(i, false);
            // Labels
            this.openEventOrPackForm.Text = "";
            this.labelPropertyA.Text = "";
            //
            this.Updating = true;
        }
        private void SetFreeBytesLabel()
        {
            int freeNPCSpace = Model.FreeNPCSpace();
            bytesLeft.Text = freeNPCSpace + " bytes left";
            bytesLeft.BackColor = freeNPCSpace >= 0 ? Color.LightGreen : Color.Red;
        }
        private void RedrawNPCImages()
        {
            overlay.NPCImages = null;
            picture.Invalidate();
        }

        // Add to collection
        private void AddNew()
        {
            // Insert the new object at the current top-left visible bounds of the tilemap PictureBox
            Point topLeftVisibleBounds = new Point(Math.Abs(picture.Left) / zoom, Math.Abs(picture.Top) / zoom);
            int x = collision.PixelCoords[topLeftVisibleBounds.Y * 1024 + topLeftVisibleBounds.X].X + 2;
            int y = collision.PixelCoords[topLeftVisibleBounds.Y * 1024 + topLeftVisibleBounds.X].Y + 4;
            Point isometricLocation = new Point(x, y);
            if (Model.FreeNPCSpace() >= 12)
            {
                if (listBox.Items.Count < 28)
                {
                    if (listBox.Items.Count > 0)
                        npcObjects.Insert(listBox.SelectedIndex + 1, isometricLocation);
                    else
                        npcObjects.Insert(0, isometricLocation);
                    int reselect;
                    if (listBox.Items.Count > 0)
                        reselect = listBox.SelectedIndex;
                    else
                        reselect = -1;
                    BuildListBox(reselect);
                }
                else
                    MessageBox.Show("Could not insert any more NPCs. The maximum number of NPCs plus NPC clones allowed per area is 28.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Could not insert the NPC. " + Model.MaximumSpaceExceeded("NPCs"),
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void AddNew(NPCObject newNPCObject)
        {
            // Insert the new object at the current top-left visible bounds of the tilemap PictureBox
            Point topLeftVisibleBounds = new Point(Math.Abs(picture.Left) / zoom, Math.Abs(picture.Top) / zoom);
            int x = collision.PixelCoords[topLeftVisibleBounds.Y * 1024 + topLeftVisibleBounds.X].X + 2;
            int y = collision.PixelCoords[topLeftVisibleBounds.Y * 1024 + topLeftVisibleBounds.X].Y + 4;
            Point isometricLocation = new Point(x, y);
            if (Model.FreeNPCSpace() >= 12)
            {
                if (npcObjects.Count < 28)
                {
                    int selectedIndex = -1;
                    if (npcObjects.Count > 0)
                    {
                        npcObjects.Insert(SelectedNPC + 1, newNPCObject);
                        selectedIndex = listBox.SelectedIndex;
                    }
                    else
                        npcObjects.Insert(0, newNPCObject);
                    //
                    BuildListBox(selectedIndex);
                }
                else
                    MessageBox.Show("Could not insert any more NPCs. The maximum number of NPCs plus NPC clones allowed is 28.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Could not insert the NPC. " + Model.MaximumSpaceExceeded("NPCs"),
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Coordinates
        public void SetCoords(int x, int y)
        {
            this.x.Value = x;
            this.y.Value = y;
        }

        // Selecting
        public void SelectNPC(int npcIndex)
        {
            if (npcIndex >= 0 && npcIndex < this.listBox.Items.Count)
                this.listBox.SelectedIndex = npcIndex;
        }

        #endregion

        #region Event Handlers

        // Toolstrip
        private void insert_Click(object sender, System.EventArgs e)
        {
            AddNew();
            overlay.NPCImages = null;
        }
        private void delete_Click(object sender, System.EventArgs e)
        {
            if (NPCObject == null)
                return;
            //
            npcObjects.Remove(NPCObject);
            int selectedIndex = SelectedNPC;
            if (selectedIndex == npcObjects.Count - 1)
                selectedIndex--;
            LoadProperties();
            RedrawNPCImages();
        }
        private void moveUp_Click(object sender, EventArgs e)
        {
            if (NPCObject == null)
                return;
            //
            int selectedIndex = SelectedNPC - 1;
            //
            if (selectedIndex >= 0)
                npcObjects.Reverse(selectedIndex - 1, 2);
            else
                return;
            //
            BuildListBox(selectedIndex);
            SetFreeBytesLabel();
            RedrawNPCImages();
        }
        private void moveDown_Click(object sender, EventArgs e)
        {
            if (NPCObject == null)
                return;
            //
            int selectedIndex = SelectedNPC - 1;
            //
            if (selectedIndex >= 0)
                npcObjects.Reverse(selectedIndex - 1, 2);
            else
                return;
            //
            BuildListBox(selectedIndex);
            SetFreeBytesLabel();
            RedrawNPCImages();
        }
        private void copy_Click(object sender, EventArgs e)
        {
            if (NPCObject != null)
                copiedNPCObject = NPCObject;
        }
        private void paste_Click(object sender, EventArgs e)
        {
            if (copiedNPCObject == null)
                return;
            try
            {
                AddNew(copiedNPCObject as NPCObject);
                RedrawNPCImages();
            }
            catch
            {
                MessageBox.Show("Cannot paste an NPC into another NPC's reference collection.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void duplicate_Click(object sender, EventArgs e)
        {
            AddNew(NPCObject);
            RedrawNPCImages();
        }

        // ListBox
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                LoadNPCProperties();
                picture.Invalidate();
            }
        }

        // Engage Trigger
        private void engageType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (NPCObject != null)
                NPCObject.EngageType = (EngageType)this.engageType.SelectedIndex;
            //
            if (!this.Updating)
            {
                SetEngageTypeControls();
                RedrawNPCImages();
            }
        }
        private void engageTrigger_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (NPCObject != null)
                NPCObject.EngageTrigger = (byte)this.engageTrigger.SelectedIndex;
        }

        // Referenced properties
        private void npcID_ValueChanged(object sender, System.EventArgs e)
        {
            if (NPCObject != null)
                NPCObject.NPCID = (ushort)this.npcID.Value;
            //
            if (!this.Updating)
            {
                SetFreeBytesLabel();
                RedrawNPCImages();
            }
        }
        private void eventOrPack_ValueChanged(object sender, System.EventArgs e)
        {
            if (NPCObject != null)
            {
                if (EngageType != EngageType.Battle)
                    NPCObject.Event = (ushort)this.eventOrPack.Value;
                else
                    NPCObject.Pack = (byte)this.eventOrPack.Value;
            }
            //
            if (!this.Updating)
            {
                SetFreeBytesLabel();
                picture.Invalidate();
            }
        }
        private void speedPlus_ValueChanged(object sender, System.EventArgs e)
        {
            if (NPCObject != null)
                NPCObject.SpeedPlus = (byte)this.speedPlus.Value;
        }
        private void action_ValueChanged(object sender, System.EventArgs e)
        {
            if (NPCObject != null)
                NPCObject.Action = (ushort)this.action.Value;
            if (!this.Updating)
                SetFreeBytesLabel();
        }

        // Reference properties
        private void mem70A7_ValueChanged(object sender, System.EventArgs e)
        {
            if (NPCObject != null)
            {
                if (EngageType == EngageType.Treasure)
                    NPCObject.Mem70A7 = (byte)this.mem70A7.Value;
            }
            //
            if (!this.Updating)
                RedrawNPCImages();
        }
        private void afterBattle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NPCObject != null)
                NPCObject.AfterBattle = (byte)afterBattle.SelectedIndex;
        }

        // Coordinates
        private void x_ValueChanged(object sender, System.EventArgs e)
        {
            if (NPCObject != null)
                NPCObject.X = (byte)this.x.Value;
            if (!this.Updating)
                picture.Invalidate();
        }
        private void y_ValueChanged(object sender, System.EventArgs e)
        {
            if (NPCObject != null)
                NPCObject.Y = (byte)this.y.Value;
            if (!this.Updating)
                picture.Invalidate();
        }
        private void z_ValueChanged(object sender, System.EventArgs e)
        {
            if (NPCObject != null)
                NPCObject.Z = (byte)this.z.Value;
            if (!this.Updating)
                picture.Invalidate();
        }
        private void f_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (NPCObject != null)
                NPCObject.F = (byte)this.f.SelectedIndex;
            if (!this.Updating)
                RedrawNPCImages();
        }
        private void visible_CheckedChanged(object sender, System.EventArgs e)
        {
            visible.ForeColor = visible.Checked ? Color.Black : Color.Gray;
            if (NPCObject != null)
                NPCObject.ShowNPC = this.visible.Checked;
            if (!this.Updating)
                picture.Invalidate();
        }
        private void z_half_CheckedChanged(object sender, System.EventArgs e)
        {
            z_half.ForeColor = z_half.Checked ? Color.Black : Color.Gray;
            if (NPCObject != null)
                NPCObject.ZHalf = this.z_half.Checked;
            if (!this.Updating)
                picture.Invalidate();
        }

        // Attributes
        private void attributes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NPCObject != null)
            {
                NPCObject.B2b3 = this.attributes.GetItemChecked(0);
                NPCObject.B2b4 = this.attributes.GetItemChecked(1);
                NPCObject.B2b5 = this.attributes.GetItemChecked(2);
                NPCObject.B2b6 = this.attributes.GetItemChecked(3);
                NPCObject.B2b7 = this.attributes.GetItemChecked(4);
                NPCObject.B3b0 = this.attributes.GetItemChecked(5);
                NPCObject.B3b1 = this.attributes.GetItemChecked(6);
                NPCObject.B3b2 = this.attributes.GetItemChecked(7);
                NPCObject.B3b3 = this.attributes.GetItemChecked(8);
                NPCObject.B3b4 = this.attributes.GetItemChecked(9);
                NPCObject.B3b5 = this.attributes.GetItemChecked(10);
                NPCObject.B3b6 = this.attributes.GetItemChecked(11);
                NPCObject.B3b7 = this.attributes.GetItemChecked(12);
                NPCObject.B4b0 = this.attributes.GetItemChecked(13);
                NPCObject.B4b1 = this.attributes.GetItemChecked(14);
            }
        }

        // Forms
        private void openNPCEditor_Click(object sender, EventArgs e)
        {
            npcEditorForm.Index = (int)npcID.Value;
            npcEditorForm.Show();
            npcEditorForm.BringToFront();
        }
        private void openForm_Click(object sender, EventArgs e)
        {
            if (EngageType == EngageType.Battle)
                return;
            if (LAZYSHELL.Model.Program.EventScripts == null || !LAZYSHELL.Model.Program.EventScripts.Visible)
                LAZYSHELL.Model.Program.CreateEventScriptsWindow();
            LAZYSHELL.Model.Program.EventScripts.Type = 0;
            LAZYSHELL.Model.Program.EventScripts.Index = (int)eventOrPack.Value;
            LAZYSHELL.Model.Program.EventScripts.BringToFront();
        }
        private void openEventsForm_Click(object sender, EventArgs e)
        {
            if (LAZYSHELL.Model.Program.EventScripts == null || !LAZYSHELL.Model.Program.EventScripts.Visible)
                LAZYSHELL.Model.Program.CreateEventScriptsWindow();
            LAZYSHELL.Model.Program.EventScripts.Type = 1;
            LAZYSHELL.Model.Program.EventScripts.Index = (int)action.Value;
            LAZYSHELL.Model.Program.EventScripts.BringToFront();
        }

        #endregion
    }
}
