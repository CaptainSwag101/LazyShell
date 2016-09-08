using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LazyShell
{
    public partial class TileEditor : Controls.NewForm
    {
        #region Variables

        private MapEditor ownerForm;
        private TileUpdater updater;
        private Tile tile;
        private Tile tileBackup;
        private byte[] graphics;
        private byte format
        {
            get
            {
                if (tile.TwoBPP)
                    return 0x20;
                else
                    return 0x40;
            }
        }
        private PaletteSet paletteSet
        {
            get { return ownerForm.PaletteSet; }
        }
        private int currentSubtile;
        private Bitmap tileImage, subtileImage;

        #endregion

        // Constructors
        /// <summary>
        /// View and edit the properties of a single 16x16 tile.
        /// </summary>
        /// <param name="updateFunction">The update function to invoke when "APPLY" is clicked.</param>
        /// <param name="tile">The 16x16 tile to analyze.</param>
        /// <param name="graphics">The graphics used by the tile.</param>
        /// <param name="paletteSet">The palette set used by the tile.</param>
        /// <param name="format">Either 0x10 or 0x20 for 2bpp or 4bpp format, respectively.</param>
        /// <param name="sender">The control that was double-clicked to open the tile editor.</param>
        public TileEditor(MapEditor ownerForm, TileUpdater updater, Tile tile, byte[] graphics, bool disableattr)
        {
            this.ownerForm = ownerForm;
            this.updater = updater;
            this.tile = tile;
            this.tileBackup = tile.Copy();
            this.graphics = graphics;

            // Initialization
            InitializeComponent();
            CreateHelperForms();
            CreateShortcuts();
            LoadTileProperties();

            // Enable/disable status editing
            subtileStatus.Enabled = !disableattr;

            // Initialize history logging
            this.History = new History(this);
        }
        public TileEditor(MapEditor ownerForm, TileUpdater updater, Tile tile, byte[] graphics)
        {
            this.ownerForm = ownerForm;
            this.updater = updater;
            this.tile = tile;
            this.tileBackup = tile.Copy();
            this.graphics = graphics;

            // Initialization
            InitializeComponent();
            CreateHelperForms();
            CreateShortcuts();
            LoadTileProperties();

            // Initialize history logging
            this.History = new History(this);
        }
        public void Reload(Tile tile, byte[] graphics)
        {
            if (this.Updating)
                return;
            this.tile = tile;
            this.tileBackup = tile.Copy();
            this.graphics = graphics;

            // Initialization
            LoadSubtileProperties();
            SetTileImage();
            SetSubtileImage();

            // BringToFront
            this.BringToFront();
        }

        #region Methods

        private void CreateShortcuts()
        {
            Do.AddShortcut(toolStrip1, Keys.F1, helpTips);
            Do.AddShortcut(toolStrip1, Keys.F2, baseConvertor);
        }
        private void CreateHelperForms()
        {
            new ToolTipLabel(this, baseConvertor, helpTips);
        }
        private void LoadTileProperties()
        {
            currentSubtile = 0;

            // Load subtile
            LoadSubtileProperties();
            SetTileImage();
            SetSubtileImage();

            // BringToFront
            this.BringToFront();
        }
        private void LoadSubtileProperties()
        {
            this.Updating = true;
            //
            subtileIndex.Value = tile.Subtiles[currentSubtile].Index;
            subtilePalette.Value = tile.Subtiles[currentSubtile].Palette;
            subtileStatus.SetItemChecked(0, tile.Subtiles[currentSubtile].Priority1);
            subtileStatus.SetItemChecked(1, tile.Subtiles[currentSubtile].Mirror);
            subtileStatus.SetItemChecked(2, tile.Subtiles[currentSubtile].Invert);
            //
            this.Updating = false;
        }
        private void SetTileImage()
        {
            int[] temp = new int[16 * 16];
            int[] pixels = new int[64 * 64];
            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < 2; x++)
                {
                    Do.PixelsToPixels(
                        tile.Subtiles[y * 2 + x].Pixels,
                        temp, 16, new Rectangle(x * 8, y * 8, 8, 8));
                }
            }
            for (int y = 0; y < 64; y++)
            {
                for (int x = 0; x < 64; x++)
                    pixels[y * 64 + x] = temp[y / 4 * 16 + (x / 4)];
            }
            tileImage = Do.PixelsToImage(pixels, 64, 64);
            pictureBoxTile.Invalidate();
        }
        private void SetSubtileImage()
        {
            int[] temp = new int[8 * 8];
            int[] pixels = new int[64 * 64];
            Do.PixelsToPixels(
                tile.Subtiles[currentSubtile].Pixels,
                temp, 8, new Rectangle(0, 0, 8, 8));
            for (int y = 0; y < 64; y++)
            {
                for (int x = 0; x < 64; x++)
                    pixels[y * 64 + x] = temp[y / 8 * 8 + (x / 8)];
            }
            subtileImage = Do.PixelsToImage(pixels, 64, 64);
            pictureBoxSubtile.Invalidate();
        }
        /// <summary>
        /// Creates a new subtile from the current properties of the loaded subtile.
        /// </summary>
        /// <returns></returns>
        private Subtile CreateNewSubtile()
        {
            return Do.DrawSubtile((ushort)this.subtileIndex.Value,
                (byte)this.subtilePalette.Value,
                this.subtileStatus.GetItemChecked(0),
                this.subtileStatus.GetItemChecked(1),
                this.subtileStatus.GetItemChecked(2),
                graphics, paletteSet.Palettes, format);
        }

        #endregion

        #region Event Handlers

        // TileEditor
        private void TileEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            buttonReset.PerformClick();
        }

        // Properties
        private void tilePalette_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            if (subtilePalette.Value >= paletteSet.Palettes.Length)
                subtilePalette.Value = paletteSet.Palettes.Length - 1;
            tile.Subtiles[currentSubtile] = CreateNewSubtile();

            // Set images
            SetTileImage();
            SetSubtileImage();

            // Update in source form
            this.Updating = true;
            if (autoUpdate.Checked)
                updater.UpdateTile();
            this.Updating = false;
        }
        private void tileAttributes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            tile.Subtiles[currentSubtile] = CreateNewSubtile();

            // Set images
            SetTileImage();
            SetSubtileImage();

            // Update in source form
            this.Updating = true;
            if (autoUpdate.Checked)
                updater.UpdateTile();
            this.Updating = false;
        }
        private void tile8x8Tile_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            if (subtileIndex.Value * format >= graphics.Length)
                subtileIndex.Value = (graphics.Length / format) - 1;
            tile.Subtiles[currentSubtile] = CreateNewSubtile();

            // Set images
            SetTileImage();
            SetSubtileImage();

            // Update in source form
            this.Updating = true;
            if (autoUpdate.Checked)
                updater.UpdateTile();
            this.Updating = false;
        }

        // Picture
        private void pictureBoxSubtile_Paint(object sender, PaintEventArgs e)
        {
            if (subtileImage != null)
                e.Graphics.DrawImage(subtileImage, 0, 0);
        }
        private void pictureBoxTile_MouseClick(object sender, MouseEventArgs e)
        {
            currentSubtile = e.X / 32 + ((e.Y / 32) * 2);
            LoadSubtileProperties();
            SetSubtileImage();
        }
        private void pictureBoxTile_Paint(object sender, PaintEventArgs e)
        {
            if (tileImage != null)
                e.Graphics.DrawImage(tileImage, 0, 0);
        }

        // Editing
        private void buttonMirrorTile_Click(object sender, EventArgs e)
        {
            Do.FlipHorizontal(tile);
            LoadSubtileProperties();
            SetTileImage();
            SetSubtileImage();
            if (autoUpdate.Checked)
                updater.UpdateTile();
        }
        private void buttonInvertTile_Click(object sender, EventArgs e)
        {
            Do.FlipVertical(tile);
            LoadSubtileProperties();
            SetTileImage();
            SetSubtileImage();
            if (autoUpdate.Checked)
                updater.UpdateTile();
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            updater.UpdateTile();
        }

        // Buttons
        private void buttonOK_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
                this.tileBackup.Subtiles[i] = this.tile.Subtiles[i];
            this.Close();
            if (!autoUpdate.Checked)
                updater.UpdateTile();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonReset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
                this.tile.Subtiles[i] = this.tileBackup.Subtiles[i];

            // Update in source form
            this.Updating = true;
            if (autoUpdate.Checked)
                updater.UpdateTile();
            this.Updating = false;
            LoadSubtileProperties();
            SetTileImage();
            SetSubtileImage();
        }

        #endregion
    }
}
