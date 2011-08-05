﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public partial class TileEditor : Form
    {
        private Delegate update;
        private Tile16x16 tile;
        private Tile16x16 tileBackup;
        private byte[] graphics;
        private PaletteSet paletteSet;
        private byte format;
        private bool updatingThis;
        private bool updatingSubtile;
        private int currentSubtile;
        private Bitmap tileImage, subtileImage;
        // constructor
        /// <summary>
        /// View and edit the properties of a single 16x16 tile.
        /// </summary>
        /// <param name="update">The update function to invoke when "APPLY" is clicked.</param>
        /// <param name="tile">The 16x16 tile to analyze.</param>
        /// <param name="graphics">The graphics used by the tile.</param>
        /// <param name="paletteSet">The palette set used by the tile.</param>
        /// <param name="format">Either 0x10 or 0x20 for 2bpp or 4bpp format, respectively.</param>
        /// <param name="sender">The control that was double-clicked to open the tile editor.</param>
        public TileEditor(Delegate update, Tile16x16 tile, byte[] graphics, PaletteSet paletteSet, byte format)
        {
            this.update = update;
            this.tile = tile;
            this.tileBackup = tile.Copy();
            this.graphics = graphics;
            this.paletteSet = paletteSet;
            this.format = format;

            currentSubtile = 0;

            InitializeComponent();

            InitializeSubtile();
            SetTileImage();
            SetSubtileImage();
            this.BringToFront();
        }
        public void Reload(Delegate update, Tile16x16 tile, byte[] graphics, PaletteSet paletteSet, byte format)
        {
            this.update = update;
            this.tile = tile;
            if (updatingThis) return;
            this.tileBackup = tile.Copy();
            this.graphics = graphics;
            this.paletteSet = paletteSet;
            this.format = format;

            InitializeSubtile();
            SetTileImage();
            SetSubtileImage();
            this.BringToFront();
        }
        // functions
        private void InitializeSubtile()
        {
            updatingSubtile = true;

            subtileIndex.Value = tile.Subtiles[currentSubtile].TileIndex;
            subtilePalette.Value = tile.Subtiles[currentSubtile].PaletteIndex;
            subtileStatus.SetItemChecked(0, tile.Subtiles[currentSubtile].PriorityOne);
            subtileStatus.SetItemChecked(1, tile.Subtiles[currentSubtile].Mirror);
            subtileStatus.SetItemChecked(2, tile.Subtiles[currentSubtile].Invert);

            updatingSubtile = false;
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
            tileImage = new Bitmap(Do.PixelsToImage(pixels, 64, 64));
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
            subtileImage = new Bitmap(Do.PixelsToImage(pixels, 64, 64));
            pictureBoxSubtile.Invalidate();
        }
        private Tile8x8 CreateNewSubtile()
        {
            return Do.DrawTile8x8((ushort)this.subtileIndex.Value,
                (byte)this.subtilePalette.Value,
                this.subtileStatus.GetItemChecked(0),
                this.subtileStatus.GetItemChecked(1),
                this.subtileStatus.GetItemChecked(2),
                graphics, paletteSet.Palettes, format);
        }
        #region Event Handlers

        private void TileEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            buttonReset_Click(null, null);
        }

        private void tilePalette_ValueChanged(object sender, EventArgs e)
        {
            if (updatingSubtile) return;
            if (subtilePalette.Value >= paletteSet.Palettes.Length)
                subtilePalette.Value = paletteSet.Palettes.Length - 1;

            tile.Subtiles[currentSubtile] = CreateNewSubtile();

            SetTileImage();
            SetSubtileImage();
            updatingThis = true;
            if (autoUpdate.Checked)
                update.DynamicInvoke();
            updatingThis = false;
        }
        private void tileAttributes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingSubtile) return;
            tile.Subtiles[currentSubtile] = CreateNewSubtile();

            SetTileImage();
            SetSubtileImage();
            updatingThis = true;
            if (autoUpdate.Checked)
                update.DynamicInvoke();
            updatingThis = false;
        }
        private void tile8x8Tile_ValueChanged(object sender, EventArgs e)
        {
            if (updatingSubtile) return;
            if (subtileIndex.Value * format >= graphics.Length)
                subtileIndex.Value = (graphics.Length / format) - 1;

            tile.Subtiles[currentSubtile] = CreateNewSubtile();

            SetTileImage();
            SetSubtileImage();
            updatingThis = true;
            if (autoUpdate.Checked)
                update.DynamicInvoke();
            updatingThis = false;
        }

        private void pictureBoxSubtile_Paint(object sender, PaintEventArgs e)
        {
            if (subtileImage != null)
                e.Graphics.DrawImage(subtileImage, 0, 0);
        }
        private void pictureBoxTile_MouseClick(object sender, MouseEventArgs e)
        {
            currentSubtile = e.X / 32 + ((e.Y / 32) * 2);

            InitializeSubtile();
            SetSubtileImage();
        }
        private void pictureBoxTile_Paint(object sender, PaintEventArgs e)
        {
            if (tileImage != null)
                e.Graphics.DrawImage(tileImage, 0, 0);
        }

        private void buttonMirrorTile_Click(object sender, EventArgs e)
        {
            Do.FlipHorizontal(tile);
            InitializeSubtile();
            SetTileImage();
            SetSubtileImage();
            if (autoUpdate.Checked)
                update.DynamicInvoke();
        }
        private void buttonInvertTile_Click(object sender, EventArgs e)
        {
            Do.FlipVertical(tile);
            InitializeSubtile();
            SetTileImage();
            SetSubtileImage();
            if (autoUpdate.Checked)
                update.DynamicInvoke();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            update.DynamicInvoke();
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
                this.tileBackup.Subtiles[i] = this.tile.Subtiles[i];
            this.Close();
            if (!autoUpdate.Checked)
                update.DynamicInvoke();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonReset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
                this.tile.Subtiles[i] = this.tileBackup.Subtiles[i];
            updatingThis = true;
            if (autoUpdate.Checked)
                update.DynamicInvoke();
            updatingThis = false;
            InitializeSubtile();
            SetTileImage();
            SetSubtileImage();
        }

        #endregion
    }
}