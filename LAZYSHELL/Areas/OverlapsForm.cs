using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL.Areas
{
    public partial class OverlapsForm : Controls.DockForm
    {
        #region Variables

        public int Index
        {
            get { return listBox.SelectedIndex; }
            set { listBox.SelectedIndex = value; }
        }
        // Elements
        private OverlapCollection overlaps
        {
            get { return area.Overlaps; }
            set { area.Overlaps = value; }
        }
        public Overlap Overlap
        {
            get
            {
                if (Index >= 0 && Index < overlaps.Count)
                    return overlaps[Index];
                return null;
            }
            set
            {
                if (Index >= 0 && Index < overlaps.Count)
                    overlaps[Index] = value;
            }
        }
        private Overlap copiedOverlap;
        private Area area
        {
            get { return ownerForm.Area; }
            set { ownerForm.Area = value; }
        }
        private Overlay overlay
        {
            get { return ownerForm.Overlay; }
            set { ownerForm.Overlay = value; }
        }
        private OwnerForm ownerForm;
        // Tileset
        private Overlay.Selection selection;
        private OverlapTileset tileset;
        private Bitmap tilesetImage;
        private int[] tilesetPixels;
        // Picture
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
        public OverlapsForm(OwnerForm ownerForm)
        {
            this.ownerForm = ownerForm;
            InitializeComponent();
            InitializeVariables();
        }

        #region Methods

        private void InitializeVariables()
        {
            selection = new Overlay.Selection();
            collision = Collision.Instance;
            tileset = new OverlapTileset();
        }
        //
        public void LoadProperties()
        {
            BuildListBox(0);
            LoadOverlapProperties();
        }
        private void LoadOverlapProperties()
        {
            this.Updating = true;
            //
            if (overlaps.Count != 0 && Index >= 0)
            {
                this.x.Value = Overlap.X;
                this.y.Value = Overlap.Y;
                this.z.Value = Overlap.Z;
                this.z_half.Checked = Overlap.B1b7;
                this.type.Value = Overlap.Type;
                this.unknownBits.SetItemChecked(0, Overlap.B0b7);
                this.unknownBits.SetItemChecked(1, Overlap.B2b5);
                this.unknownBits.SetItemChecked(2, Overlap.B2b6);
                this.unknownBits.SetItemChecked(3, Overlap.B2b7);
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
            RefreshSelection();
            SetFreeBytesLabel();
            //
            this.Updating = false;
        }
        private void BuildListBox(int selectedIndex)
        {
            this.Updating = true;
            //
            listBox.BeginUpdate();
            this.listBox.Items.Clear();
            for (int i = 0; i < overlaps.Count; i++)
                this.listBox.Items.Add("OVERLAP #" + i);
            if (selectedIndex >= 0 && selectedIndex < this.listBox.Items.Count)
                this.listBox.SelectedIndex = selectedIndex;
            else if (this.listBox.Items.Count > 0)
                this.listBox.SelectedIndex = 0;
            listBox.EndUpdate();
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
            this.x.Enabled = enabled;
            this.y.Enabled = enabled;
            this.z.Enabled = enabled;
            this.z_half.Enabled = enabled;
            this.type.Enabled = enabled;
            this.unknownBits.Enabled = enabled;
            this.panelTileset.Enabled = enabled;
            this.panelTileset.Visible = enabled;
        }
        private void ResetPropertyControls()
        {
            this.x.Value = 0;
            this.y.Value = 0;
            this.z.Value = 0;
            this.z_half.Checked = false;
            this.type.Value = 0;
            this.unknownBits.SetItemChecked(0, false);
            this.unknownBits.SetItemChecked(1, false);
            this.unknownBits.SetItemChecked(2, false);
            this.unknownBits.SetItemChecked(3, false);
        }
        private void SetFreeBytesLabel()
        {
            int freeOverlapSpace = Model.FreeOverlapSpace();
            bytesLeft.Text = freeOverlapSpace + " bytes left";
            bytesLeft.BackColor = freeOverlapSpace >= 0 ? SystemColors.Control : Color.Red;
        }
        //
        private void RefreshSelection()
        {
            int x = (int)type.Value % 8 * 32;
            int y = (int)type.Value / 8 * 32;
            selection.Reload(32, x, y, 32, 32, pictureBoxTileset);
            pictureBoxTileset.Invalidate();
        }
        private void AddNew(Overlap overlap)
        {
            if (Model.FreeOverlapSpace() >= 4)
            {
                this.listBox.Focus();
                if (overlaps.Count < 28)
                {
                    if (listBox.Items.Count > 0)
                        overlaps.Insert(Index + 1, overlap);
                    else
                        overlaps.Insert(0, overlap);
                    int reselect;
                    if (listBox.Items.Count > 0)
                        reselect = Index;
                    else
                        reselect = -1;
                    BuildListBox(reselect);
                }
                else
                    MessageBox.Show("Could not insert any more overlaps. The maximum number of overlaps allowed per area is 28.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Could not insert the field. " + Model.MaximumSpaceExceeded("overlaps"),
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

        // ToolStrip
        private void insert_Click(object sender, EventArgs e)
        {
            Point o = new Point(Math.Abs(picture.Left) / zoom, Math.Abs(picture.Top) / zoom);
            Point p = new Point(collision.PixelCoords[o.Y * 1024 + o.X].X + 2, collision.PixelCoords[o.Y * 1024 + o.X].Y + 4);
            if (Model.FreeOverlapSpace() >= 4)
            {
                this.listBox.Focus();
                if (overlaps.Count < 28)
                {
                    if (listBox.Items.Count > 0)
                        overlaps.Insert(Index + 1, p);
                    else
                        overlaps.Insert(0, p);
                    int reselect;
                    if (listBox.Items.Count > 0)
                        reselect = Index;
                    else
                        reselect = -1;
                    BuildListBox(reselect + 1);
                }
                else
                    MessageBox.Show("Could not insert any more overlaps. The maximum number of overlaps allowed per area is 28.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Could not insert the field. " + Model.MaximumSpaceExceeded("overlaps"),
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void delete_Click(object sender, EventArgs e)
        {
            if (Overlap != null)
            {
                overlaps.Remove(Overlap);
                int reselect = Index;
                if (reselect == listBox.Items.Count - 1)
                    reselect--;
                BuildListBox(reselect);
                LoadOverlapProperties();
            }
        }
        private void copy_Click(object sender, EventArgs e)
        {
            if (Overlap != null)
                copiedOverlap = Overlap.Copy();
        }
        private void paste_Click(object sender, EventArgs e)
        {
            if (copiedOverlap == null)
                return;
            AddNew(copiedOverlap);
        }
        private void duplicate_Click(object sender, EventArgs e)
        {
            AddNew(Overlap.Copy());
        }

        // ListBox
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                LoadOverlapProperties();
                picture.Invalidate();
            }
        }

        // Coordinates
        private void x_ValueChanged(object sender, EventArgs e)
        {
            if (Overlap != null)
                Overlap.X = (byte)this.x.Value;
            if (!this.Updating)
                picture.Invalidate();
        }
        private void y_ValueChanged(object sender, EventArgs e)
        {
            if (Overlap != null)
                Overlap.Y = (byte)this.y.Value;
            if (!this.Updating)
                picture.Invalidate();
        }
        private void z_ValueChanged(object sender, EventArgs e)
        {
            if (Overlap != null)
                Overlap.Z = (byte)this.z.Value;
            if (!this.Updating)
                picture.Invalidate();
        }
        private void z_half_CheckedChanged(object sender, EventArgs e)
        {
            z_half.ForeColor = z_half.Checked ? Color.Black : Color.Gray;
            if (Overlap != null)
                Overlap.B1b7 = this.z_half.Checked;
            if (!this.Updating)
                picture.Invalidate();
        }

        // Properties
        private void type_ValueChanged(object sender, EventArgs e)
        {
            if (Overlap != null)
                Overlap.Type = (byte)this.type.Value;
            if (!this.Updating)
            {
                RefreshSelection();
                picture.Invalidate();
            }
        }
        private void unknownBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Overlap != null)
            {
                Overlap.B0b7 = unknownBits.GetItemChecked(0);
                Overlap.B2b5 = unknownBits.GetItemChecked(1);
                Overlap.B2b6 = unknownBits.GetItemChecked(2);
                Overlap.B2b7 = unknownBits.GetItemChecked(3);
            }
        }

        // Picture
        private void pictureBoxTileset_MouseDown(object sender, MouseEventArgs e)
        {
            type.Value = (e.Y / 32) * 8 + (e.X / 32);
        }
        private void pictureBoxTileset_Paint(object sender, PaintEventArgs e)
        {
            if (tilesetImage == null)
            {
                tilesetPixels = Do.TilesetToPixels(tileset.Tileset, 8, 13, 0);
                tilesetImage = Do.PixelsToImage(tilesetPixels, 256, 416);
            }
            e.Graphics.DrawImage(tilesetImage, 0, 0);
            overlay.DrawTileGrid(e.Graphics, Color.Gray, new Size(256, 416), new Size(32, 32), 1, true);
            if (selection != null)
                selection.DrawSelectionBox(e.Graphics, 1);
        }

        // IO image
        private void saveOverlapsImage_Click(object sender, EventArgs e)
        {
            Do.Export(tilesetImage, "overlaps-tileset.png");
        }
        private void importOverlapsImage_Click(object sender, EventArgs e)
        {

        }

        #endregion

    }
}
