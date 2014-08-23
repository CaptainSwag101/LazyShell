using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL.Areas
{
    public partial class TileSwitchesForm : Controls.DockForm
    {
        #region Variables

        public int Index
        {
            get
            {
                if (treeView.SelectedNode == null)
                    return -1;
                if (treeView.SelectedNode.Parent == null)
                    return treeView.SelectedNode.Index;
                else
                    return treeView.SelectedNode.Parent.Index;
            }
            set
            {
                treeView.SelectedNode = treeView.Nodes[value];
            }
        }
        private TileSwitchCollection tileSwitches
        {
            get { return area.TileSwitches; }
            set { area.TileSwitches = value; }
        }
        public TileSwitch TileSwitch
        {
            get
            {
                if (Index >= 0 && Index < tileSwitches.Count)
                    return tileSwitches[Index];
                return null;
            }
            set
            {
                if (Index >= 0 && Index < tileSwitches.Count)
                    tileSwitches[Index] = value;
            }
        }
        public bool AlternateSelected
        {
            get
            {
                if (treeView.SelectedNode == null)
                    return false;
                return treeView.SelectedNode.Parent != null;
            }
        }
        private TileSwitch copiedTileSwitch;
        public CheckedListBox Layers
        {
            get { return layers; }
            set { layers = value; }
        }
        private Tileset tileset
        {
            get { return ownerForm.Tileset; }
            set { ownerForm.Tileset = value; }
        }
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
        private int zoom
        {
            get { return ownerForm.Zoom; }
        }

        #endregion

        public TileSwitchesForm(OwnerForm ownerForm)
        {
            this.ownerForm = ownerForm;
            InitializeComponent();
        }

        #region Methods

        public void LoadProperties()
        {
            BuildTreeView(0);
            LoadTileSwitchProperties();
        }
        private void LoadTileSwitchProperties()
        {
            this.Updating = true;
            //
            if (TileSwitch != null)
            {
                x.Value = TileSwitch.X;
                y.Value = TileSwitch.Y;
                width.Value = TileSwitch.Width;
                height.Value = TileSwitch.Height;
                layers.SetItemChecked(0, TileSwitch.Layer1);
                layers.SetItemChecked(1, TileSwitch.Layer2);
                layers.SetItemChecked(2, TileSwitch.Layer3);
                layers.SetItemChecked(3, TileSwitch.B0b7);
                // Can insert alternate only if alternate not already present
                insertAlternate.Enabled = TileSwitch.Alternate;
                EnableAllAccessibleControls(!AlternateSelected);
                EnableToolStripButtons(true);
            }
            else
            {
                EnableAllAccessibleControls(false);
                EnableToolStripButtons(false);
                ResetPropertyControls();
            }
            //
            this.Updating = false;
        }
        //
        private void BuildTreeView(int selectedIndex)
        {
            for (int i = 0; i < tileSwitches.Count; i++)
            {
                var node = new TreeNode("SWITCH #" + i.ToString());
                if (tileSwitches[i].Alternate)
                    node.Nodes.Add("ALTERNATE");
                this.treeView.Nodes.Add(node);
            }
            if (selectedIndex >= 0 && selectedIndex < this.treeView.Nodes.Count)
                this.treeView.SelectedNode = this.treeView.Nodes[selectedIndex];
            //
            SetBytesLeftLabel();
        }
        private void EnableToolStripButtons(bool enabled)
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
            layers.Enabled = enabled;
        }
        private void ResetPropertyControls()
        {
            x.Value = 0;
            y.Value = 0;
            width.Value = 1;
            height.Value = 1;
            layers.SetItemChecked(0, false);
            layers.SetItemChecked(1, false);
            layers.SetItemChecked(2, false);
            layers.SetItemChecked(3, false);
        }
        //
        private void SetBytesLeftLabel()
        {
            int freeTileSwitchSpace = Model.FreeTileSwitchSpace();
            bytesLeft.Text = freeTileSwitchSpace + " bytes left";
            bytesLeft.BackColor = freeTileSwitchSpace >= 0 ? SystemColors.Control : Color.Red;
        }
        //
        private bool AddNew()
        {
            Point topLeftVisibleBounds = new Point(Math.Abs(picture.Left) / zoom / 16, Math.Abs(picture.Top) / zoom / 16);
            if (Model.FreeTileSwitchSpace() >= 8)
            {
                this.treeView.Focus();
                if (tileSwitches.TileSwitches.Count < 32)
                {
                    int index = 0;
                    if (treeView.SelectedNode != null)
                        index = treeView.SelectedNode.Parent == null ?
                            treeView.SelectedNode.Index : treeView.SelectedNode.Parent.Index;
                    if (treeView.Nodes.Count > 0)
                        tileSwitches.Insert(index + 1, topLeftVisibleBounds, area, tileset);
                    else
                        tileSwitches.Insert(0, topLeftVisibleBounds, area, tileset);
                    if (treeView.Nodes.Count == 0)
                        index = -1;
                    this.treeView.BeginUpdate();
                    this.treeView.Nodes.Clear();
                    int i = 0;
                    foreach (var var in tileSwitches.TileSwitches)
                    {
                        var node = new TreeNode("TILE SWITCH #" + i++.ToString());
                        if (var.Alternate)
                            node.Nodes.Add("ALTERNATE");
                        this.treeView.Nodes.Add(node);
                    }
                    this.treeView.ExpandAll();
                    this.treeView.SelectedNode = this.treeView.Nodes[index + 1];
                    this.treeView.EndUpdate();
                }
                else
                {
                    MessageBox.Show("Could not insert any more tile switches. The maximum number of tile switches allowed per area is 32.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Could not insert the switch. " + Model.MaximumSpaceExceeded("tile switches"),
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        private void AddNew(TileSwitch tileSwitch)
        {
            if (Model.FreeTileSwitchSpace() >= tileSwitch.Length)
            {
                this.treeView.Focus();
                if (tileSwitches.TileSwitches.Count < 32)
                {
                    if (treeView.Nodes.Count > 0)
                        tileSwitches.Insert(treeView.SelectedNode.Index + 1, tileSwitch);
                    else
                        tileSwitches.Insert(0, tileSwitch);
                    int index;
                    if (treeView.Nodes.Count > 0)
                        index = treeView.SelectedNode.Index;
                    else
                        index = -1;
                    this.treeView.BeginUpdate();
                    this.treeView.Nodes.Clear();
                    int i = 0;
                    foreach (var var in tileSwitches.TileSwitches)
                    {
                        var node = new TreeNode("TILE SWITCH #" + i++.ToString());
                        if (var.Alternate)
                            node.Nodes.Add("ALTERNATE");
                        this.treeView.Nodes.Add(node);
                    }
                    this.treeView.ExpandAll();
                    this.treeView.SelectedNode = this.treeView.Nodes[index + 1];
                    this.treeView.EndUpdate();
                }
                else
                    MessageBox.Show("Could not insert any more tile switches. The maximum number of tile switches allowed per area is 32.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Could not insert the switch. " + Model.MaximumSpaceExceeded("tile switch"),
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private bool AddNewAlternate()
        {
            if (Model.FreeTileSwitchSpace() < 0)
            {
                MessageBox.Show("Could not insert the alternate switch. " + Model.MaximumSpaceExceeded("tile switches"),
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            TileSwitch.Alternate = true;
            if (TileSwitch.Tilemaps_bytesA[0] != null)
            {
                TileSwitch.Tilemaps_bytesB[0] = new byte[TileSwitch.Tilemaps_bytesA[0].Length];
                TileSwitch.Tilemaps_bytesA[0].CopyTo(TileSwitch.Tilemaps_bytesB[0], 0);
            }
            if (TileSwitch.Tilemaps_bytesA[1] != null)
            {
                TileSwitch.Tilemaps_bytesB[1] = new byte[TileSwitch.Tilemaps_bytesA[1].Length];
                TileSwitch.Tilemaps_bytesA[1].CopyTo(TileSwitch.Tilemaps_bytesB[1], 0);
            }
            if (TileSwitch.Tilemaps_bytesA[2] != null)
            {
                TileSwitch.Tilemaps_bytesB[2] = new byte[TileSwitch.Tilemaps_bytesA[2].Length];
                TileSwitch.Tilemaps_bytesA[2].CopyTo(TileSwitch.Tilemaps_bytesB[2], 0);
            }
            TileSwitch.TilemapB = new AreaTilemap(area, tileset, TileSwitch, true);
            this.treeView.BeginUpdate();
            this.treeView.SelectedNode.Nodes.Add("ALTERNATE");
            this.treeView.SelectedNode = this.treeView.SelectedNode.Nodes[0];
            this.treeView.EndUpdate();
            return true;
        }
        /// <summary>
        /// Creates a new tile switch from a selected region in a tilemap and adds it to the collection.
        /// </summary>
        /// <param name="select">The selection in the tilemap.</param>
        /// <param name="tilemap">The tilemap to create the tile switch from.</param>
        public void AddNew(Overlay.Selection select, Tilemap tilemap)
        {
            bool alternate = false;
            if (treeView.SelectedNode != null &&
                treeView.SelectedNode.Nodes.Count == 0 &&
                treeView.SelectedNode.Parent == null)
            {
                var result = MessageBox.Show("Create as an alternate tile switch?",
                    "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                alternate = result == DialogResult.Yes;
            }
            if (!alternate && !AddNew())
                return;
            if (alternate && !AddNewAlternate())
                return;
            if (!alternate)
            {
                this.x.Value = select.X / 16;
                this.y.Value = select.Y / 16;
                this.width.Value = select.Width / 16;
                this.height.Value = select.Height / 16;
            }
            bool[] empty = new bool[3];
            byte[][] tilemaps = new byte[3][];
            int width = alternate ? TileSwitch.Width : select.Width / 16;
            int height = alternate ? TileSwitch.Height : select.Height / 16;
            for (int l = 0; l < 3; l++)
            {
                if (l < 2)
                    tilemaps[l] = new byte[(width * height) * 2];
                else
                    tilemaps[l] = new byte[width * height];
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int tileX = select.Location.X + (x * 16);
                        int tileY = select.Location.Y + (y * 16);
                        int tile = tilemap.GetTileNum(l, tileX, tileY);
                        if (tile != 0)
                            empty[l] = false;
                        int index = y * width + x;
                        if (l < 2)
                            Bits.SetShort(tilemaps[l], index * 2, (ushort)tile);
                        else
                            tilemaps[l][index] = (byte)tile;
                    }
                }
                if (!alternate)
                {
                    layers.SetItemChecked(l, !empty[l]);
                    layers.SelectedIndex = -1;
                    TileSwitch.Tilemaps_bytesA[l] = tilemaps[l];
                }
                else
                    TileSwitch.Tilemaps_bytesB[l] = tilemaps[l];
            }
            if (!alternate)
                TileSwitch.TilemapA = new AreaTilemap(area, tileset, TileSwitch, false);
            else
                TileSwitch.TilemapB = new AreaTilemap(area, tileset, TileSwitch, true);
        }
        //
        public void SetCoords(int x, int y)
        {
            this.x.Value = x;
            this.y.Value = y;
        }

        #endregion

        #region Event handlers

        // ToolStrip
        private void insert_Click(object sender, EventArgs e)
        {
            AddNew();
        }
        private void insertAlternate_Click(object sender, EventArgs e)
        {
            AddNewAlternate();
        }
        private void delete_Click(object sender, EventArgs e)
        {
            if (this.treeView.SelectedNode.Parent == null)
            {
                int index = treeView.SelectedNode.Index;
                tileSwitches.RemoveAt(index);
                this.treeView.Nodes.RemoveAt(index);
                if (index >= this.treeView.Nodes.Count)
                    index--;
                BuildTreeView(index);
                LoadTileSwitchProperties();
            }
            else
            {
                int index = treeView.SelectedNode.Parent.Index;
                TileSwitch.Alternate = false;
                this.treeView.SelectedNode.Remove();
                this.treeView.SelectedNode = this.treeView.Nodes[index];
            }
        }
        private void moveUp_Click(object sender, EventArgs e)
        {
            if (this.treeView.SelectedNode == null)
                return;
            int index = 0;
            if (!AlternateSelected && Index > 0)
            {
                index = treeView.SelectedNode.Index - 1;
                tileSwitches.Reverse(Index - 1, 2);
            }
            else
                return;
            this.Index = index;
        }
        private void moveDown_Click(object sender, EventArgs e)
        {
            if (this.treeView.SelectedNode == null)
                return;
            int index = 0;
            if (!AlternateSelected && Index < treeView.Nodes.Count - 1)
            {
                index = treeView.SelectedNode.Index + 1;
                tileSwitches.Reverse(Index, 2);
            }
            else
                return;
            this.Index = index;
        }
        private void copy_Click(object sender, EventArgs e)
        {
            if (TileSwitch != null)
                copiedTileSwitch = TileSwitch.Copy(area, tileset);
        }
        private void paste_Click(object sender, EventArgs e)
        {
            if (copiedTileSwitch != null)
                AddNew(copiedTileSwitch as TileSwitch);
        }
        private void duplicate_Click(object sender, EventArgs e)
        {
            AddNew(TileSwitch.Copy(area, tileset));
        }

        // TreeView
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LoadTileSwitchProperties();
            if (!this.Updating)
                picture.Invalidate();
        }

        // Coordinates
        private void x_ValueChanged(object sender, EventArgs e)
        {
            if (TileSwitch != null)
                TileSwitch.X = (int)x.Value;
            if (!this.Updating)
                picture.Invalidate();
        }
        private void y_ValueChanged(object sender, EventArgs e)
        {
            if (TileSwitch != null)
                TileSwitch.Y = (int)y.Value;
            if (!this.Updating)
                picture.Invalidate();
        }
        private void width_ValueChanged(object sender, EventArgs e)
        {
            if (TileSwitch != null && !this.Updating)
            {
                int oldWidth = TileSwitch.Width;
                TileSwitch.Width = (int)width.Value;
                if (Model.FreeTileSwitchSpace() < 0)
                {
                    width.Value = oldWidth;
                    MessageBox.Show("Could not change the width. There is not enough free space available.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (oldWidth != TileSwitch.Width)
                    TileSwitch.ResizeTilemaps();
                TileSwitch.TilemapA = new AreaTilemap(area, tileset, TileSwitch, false);
                if (TileSwitch.Alternate)
                    TileSwitch.TilemapB = new AreaTilemap(area, tileset, TileSwitch, true);
                //
                SetBytesLeftLabel();
                picture.Invalidate();
            }
        }
        private void height_ValueChanged(object sender, EventArgs e)
        {
            if (TileSwitch != null && !this.Updating)
            {
                int oldHeight = TileSwitch.Height;
                TileSwitch.Height = (int)height.Value;
                if (Model.FreeTileSwitchSpace() < 0)
                {
                    height.Value = oldHeight;
                    MessageBox.Show("Could not change the height. There is not enough free space available.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (oldHeight != TileSwitch.Height)
                    TileSwitch.ResizeTilemaps();
                TileSwitch.TilemapA = new AreaTilemap(area, tileset, TileSwitch, false);
                if (TileSwitch.Alternate)
                    TileSwitch.TilemapB = new AreaTilemap(area, tileset, TileSwitch, true);
                //
                SetBytesLeftLabel();
                picture.Invalidate();
            }
        }

        // Layers
        private void layers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TileSwitch != null)
            {
                TileSwitch.Layer1 = layers.GetItemChecked(0);
                TileSwitch.Layer2 = layers.GetItemChecked(1);
                TileSwitch.Layer3 = layers.GetItemChecked(2);
                TileSwitch.B0b7 = layers.GetItemChecked(3);
            }
            if (!this.Updating)
                SetBytesLeftLabel();
        }

        #endregion
    }
}
