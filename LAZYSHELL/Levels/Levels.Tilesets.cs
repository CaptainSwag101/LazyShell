using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public partial class Levels
    {
        #region Variables

        private Tileset tileSet;
        private int[] tileSetPixels;
        private Bitmap tileSetImage;

        private byte[] tsCopy;
        private int tsCopyWidth, tsCopyHeight;

        private bool mouseEnterTileset;

        #endregion

        #region Methods

        // set images
        public void DrawTileSetWithoutUpdate()
        {
            // Get the pixel arrays
            try { tileSetPixels = tileSet.GetTilesetPixelArray(tileSet.TileSetLayers[tabControl2.SelectedIndex], tabControl2.SelectedIndex); }
            catch { /*no layer 3*/ }

            // Create the images
            if (tileSetPixels != null)
                tileSetImage = new Bitmap(DrawImageFromIntArr(tileSetPixels, 256, 512));

            // Set the image
            switch (tabControl2.SelectedIndex)
            {
                case 0: pictureBoxTilesetL1.Invalidate(); break;
                case 1: pictureBoxTilesetL2.Invalidate(); break;
                case 2: pictureBoxTilesetL3.Invalidate(); break;
                default: break;
            }
        }

        // drawing
        private void ZoomTileEditorBuf(int[] arr, int width)
        {
            // i = original pointer
            // z = new pointer
            int newwidth = width * 4;

            for (int i = 0, z = 0; i < arr.Length; i++)
            {
                for (int x = 0; x < 4; x++) // Draw 1 4x4 grid
                {
                    tileEditorBufZoomed[z + x] = arr[i];
                    tileEditorBufZoomed[z + x + newwidth] = arr[i];
                    tileEditorBufZoomed[z + x + newwidth * 2] = arr[i];
                    tileEditorBufZoomed[z + x + newwidth * 3] = arr[i];
                }

                z += 4;

                if (z % newwidth == 0)
                    z += newwidth * 3;


            }
        }
        private void UpdateTileEditor()
        {
            if (tabControl2.SelectedIndex == 4)
                UpdateTileEditorForBattlefield();
        }
        private void UpdateTileEditorForBattlefield()
        {
            int ts = 0, x = overlay.bfX, y = overlay.bfY, temp;

            if (x > 15 && y > 15)
            {
                y -= 16;
                x -= 16;
                ts = y * 16 + (x + 256) + 512;
            }
            else if (y > 15)
            {
                y -= 16;
                ts = y * 16 + x + 512;
            }
            else if (x > 15)
            {
                x -= 16;
                ts = y * 16 + (x + 256);
            }
            else
            {
                ts = y * 16 + x;
            }
            temp = overlay.TileSelected;
            overlay.TileSelected = ts;
        }
        private void TileSetImageClick(MouseEventArgs e)
        {
            if (tabControl2.SelectedIndex < 3)
                drawBufWidth = GetTileSetSelection(ref this.drawBuf[tabControl2.SelectedIndex]);

            overlay.TileSelected = ((e.Y - (e.Y % 16)) + (e.X / 16)); // Calculate tile number

            int ts = overlay.TileSelected;

            if (tabControl2.SelectedIndex == 4) // BF layer
            {
                overlay.bfX = e.X / 16;
                overlay.bfY = e.Y / 16;

                int x = overlay.bfX, y = overlay.bfY;
                if (x > 15 && y > 15)
                {
                    y -= 16;
                    x -= 16;
                    ts = y * 16 + (x + 256) + 512;
                }
                else if (y > 15)
                {
                    y -= 16;
                    ts = y * 16 + x + 512;
                }
                else if (x > 15)
                {
                    x -= 16;
                    ts = y * 16 + (x + 256);
                }
                else
                {
                    ts = y * 16 + x;
                }

                overlay.TileSelected = ts;
            }
        }

        private void ResetTileReplace()
        {
            replaceTile = 0;
            replaceWith = 0;
            replaceChoose = false;
            replaceSet = false;
            labelTilesets.BackColor = SystemColors.ControlDark;
            labelTilesets.ForeColor = SystemColors.Control;
            labelTilesets.Text = "TILESETS";
        }

        #endregion

        #region Event Handlers

        private void pictureBoxTilesetL1_MouseClick(object sender, MouseEventArgs e)
        {
            TileSetImageClick(e);
            editToolStripMenuItem1.Enabled = overlay.TileSelected != 0;
            priority1SetToolStripMenuItem.Enabled = overlay.TileSelected != 0;
            priority1ClearToolStripMenuItem.Enabled = overlay.TileSelected != 0;

            InitializeTileEditor();
        }
        private void pictureBoxTilesetL2_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            TileSetImageClick(e);
            editToolStripMenuItem1.Enabled = overlay.TileSelected != 0;
            priority1SetToolStripMenuItem.Enabled = overlay.TileSelected != 0;
            priority1ClearToolStripMenuItem.Enabled = overlay.TileSelected != 0;

            InitializeTileEditor();
        }
        private void pictureBoxTilesetL3_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (levelMap.GraphicSetL3 != 0xFF)
            {
                TileSetImageClick(e);
                editToolStripMenuItem1.Enabled = overlay.TileSelected != 0;
                priority1SetToolStripMenuItem.Enabled = overlay.TileSelected != 0;
                priority1ClearToolStripMenuItem.Enabled = overlay.TileSelected != 0;
            }

            InitializeTileEditor();
        }
        private void pictureBoxBattlefield_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            TileSetImageClick(e);

            InitializeTileEditor();
        }

        private void pictureBoxTilesetL1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                overlay.TileSetDragStop = new Point(e.X / 16 * 16 + 16, e.Y / 16 * 16 + 16);
                drawBufWidth = GetTileSetSelection(ref this.drawBuf[0]);
            }

            mouse = e.Location;
            pictureBoxTilesetL1.Invalidate();
        }
        private void pictureBoxTilesetL2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                overlay.TileSetDragStop = new Point(e.X / 16 * 16 + 16, e.Y / 16 * 16 + 16);
                drawBufWidth = GetTileSetSelection(ref this.drawBuf[1]);
            }

            mouse = e.Location;
            pictureBoxTilesetL2.Invalidate();
        }
        private void pictureBoxTilesetL3_MouseMove(object sender, MouseEventArgs e)
        {
            if (levelMap.GraphicSetL3 != 0xFF)
            {
                if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
                {
                    overlay.TileSetDragStop = new Point(e.X / 16 * 16 + 16, e.Y / 16 * 16 + 16);
                    drawBufWidth = GetTileSetSelection(ref this.drawBuf[2]);
                }
            }
            else
                overlay.TileSetDragStart = overlay.TileSetDragStop = new Point(0, 0);

            mouse = e.Location;
            pictureBoxTilesetL3.Invalidate();
        }
        private void pictureBoxBattlefield_MouseMove(object sender, MouseEventArgs e)
        {
            // if selecting tile(s), set the coordinates of the selection box
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
                overlay.TileSetDragStop = new Point(e.X / 16 * 16 + 16, e.Y / 16 * 16 + 16);

            // for use with the hover box
            mouse = e.Location;

            // redraw the battlefield image
            pictureBoxBattlefield.Invalidate();
        }

        private void pictureBoxTilesetL1_MouseDown(object sender, MouseEventArgs e)
        {
            if (replaceChoose)
            {
                replaceTile = e.Y / 16 * 16 + (e.X / 16);
                replaceChoose = false;
                replaceSet = true;
                labelTilesets.Text = "SELECT TILE # TO REPLACE TILE #" + replaceTile.ToString() + " WITH";
                return;
            }
            else if (replaceSet)
            {
                replaceWith = e.Y / 16 * 16 + (e.X / 16);

                if (replaceWith != replaceTile)
                {
                    for (int y = 0; y < 128; y++)
                    {
                        for (int x = 0; x < 128; x++)
                        {
                            if (tileMap.GetTileNum(0, x * 16, y * 16) == replaceTile)
                                tileMap.MakeEdit(replaceWith, 0, x * 16, y * 16, false);
                        }
                    }

                    // edit flag
                    model.EditTileMaps[levelMap.TileMapL1 + 0x40] = true;
                }
                ResetTileReplace();

                DrawLevelWithoutUpdate();

                return;
            }

            pictureBoxTilesetL1.Focus();
            TileSetDown(e);

            pictureBoxTilesetL1.Invalidate();
        }
        private void pictureBoxTilesetL2_MouseDown(object sender, MouseEventArgs e)
        {
            if (replaceChoose)
            {
                replaceTile = e.Y / 16 * 16 + (e.X / 16);
                replaceChoose = false;
                replaceSet = true;
                labelTilesets.Text = "SELECT TILE # TO REPLACE TILE #" + replaceTile.ToString() + " WITH";
                return;
            }
            else if (replaceSet)
            {
                replaceWith = e.Y / 16 * 16 + (e.X / 16);

                if (replaceWith != replaceTile)
                {
                    for (int y = 0; y < 128; y++)
                    {
                        for (int x = 0; x < 128; x++)
                        {
                            if (tileMap.GetTileNum(1, x * 16, y * 16) == replaceTile)
                                tileMap.MakeEdit(replaceWith, 1, x * 16, y * 16, false);
                        }
                    }

                    // edit flag
                    model.EditTileMaps[levelMap.TileMapL2 + 0x40] = true;
                }
                ResetTileReplace();

                DrawLevelWithoutUpdate();

                return;
            }

            pictureBoxTilesetL2.Focus();
            TileSetDown(e);

            pictureBoxTilesetL2.Invalidate();
        }
        private void pictureBoxTilesetL3_MouseDown(object sender, MouseEventArgs e)
        {
            if (replaceChoose)
            {
                replaceTile = e.Y / 16 * 16 + (e.X / 16);
                replaceChoose = false;
                replaceSet = true;
                labelTilesets.Text = "SELECT TILE # TO REPLACE TILE #" + replaceTile.ToString() + " WITH";
                return;
            }
            else if (replaceSet)
            {
                replaceWith = e.Y / 16 * 16 + (e.X / 16);

                if (replaceWith != replaceTile)
                {
                    for (int y = 0; y < 128; y++)
                    {
                        for (int x = 0; x < 128; x++)
                        {
                            if (tileMap.GetTileNum(2, x * 16, y * 16) == replaceTile)
                                tileMap.MakeEdit(replaceWith, 2, x * 16, y * 16, false);
                        }
                    }

                    // edit flag
                    model.EditTileMaps[levelMap.TileMapL3] = true;
                }
                ResetTileReplace();

                DrawLevelWithoutUpdate();

                return;
            }

            pictureBoxTilesetL3.Focus();
            if (levelMap.GraphicSetL3 != 0xFF) TileSetDown(e);

            pictureBoxTilesetL3.Invalidate();
        }
        private void pictureBoxBattlefield_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxBattlefield.Focus();
            TileSetDown(e);

            pictureBoxBattlefield.Invalidate();
        }

        private void pictureBoxTilesetL1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (overlay.TileSelected == 0) return;
            buttonToggleTileEditor.Checked = true;
            panelTileEditor.Visible = true;
        }
        private void pictureBoxTilesetL2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (overlay.TileSelected == 0) return;
            buttonToggleTileEditor.Checked = true;
            panelTileEditor.Visible = true;
        }
        private void pictureBoxTilesetL3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (overlay.TileSelected == 0) return;
            if (levelMap.GraphicSetL3 == 0xFF) return;
            buttonToggleTileEditor.Checked = true;
            panelTileEditor.Visible = true;
        }
        private void pictureBoxBattlefield_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            editToolStripMenuItem1_Click(null, null);
        }

        private void pictureBoxTilesetL1_Paint(object sender, PaintEventArgs e)
        {
            if (tileSetImage == null) return;

            Rectangle rdst = new Rectangle(0, 0, 256, 512);

            if (state.BG)
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(paletteSet.GetBGColor())), rdst);

            e.Graphics.DrawImage(tileSetImage, rdst, 0, 0, 256, 512, GraphicsUnit.Pixel);

            float[][] matrixItems ={ 
               new float[] {1, 0, 0, 0, 0},
               new float[] {0, 1, 0, 0, 0},
               new float[] {0, 0, 1, 0, 0},
               new float[] {0, 0, 0, 0.50F, 0}, 
               new float[] {0, 0, 0, 0, 1}};
            ColorMatrix cm = new ColorMatrix(matrixItems);
            ImageAttributes ia = new ImageAttributes();
            ia.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            if (state.Priority1)
                e.Graphics.DrawImage(DrawImageFromIntArr(tileSet.Priority1Tint[0], 256, 512), rdst, 0, 0, 256, 512, GraphicsUnit.Pixel, ia);

            if (mouseEnterTileset)
                TilesetHoverBox(e.Graphics);

            if (state.CartesianGrid)
                overlay.DrawCartographicGrid(e.Graphics, Color.Gray, pictureBoxLevel.Size, new Size(16, 16), 1);

            overlay.DrawSelectionBox(e.Graphics, overlay.TileSetDragStop, overlay.TileSetDragStart, 1);
        }
        private void pictureBoxTilesetL2_Paint(object sender, PaintEventArgs e)
        {
            if (tileSetImage == null) return;

            Rectangle rdst = new Rectangle(0, 0, 256, 512);

            if (state.BG)
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(paletteSet.GetBGColor())), rdst);

            e.Graphics.DrawImage(tileSetImage, rdst, 0, 0, 256, 512, GraphicsUnit.Pixel);

            float[][] matrixItems ={ 
               new float[] {1, 0, 0, 0, 0},
               new float[] {0, 1, 0, 0, 0},
               new float[] {0, 0, 1, 0, 0},
               new float[] {0, 0, 0, 0.50F, 0}, 
               new float[] {0, 0, 0, 0, 1}};
            ColorMatrix cm = new ColorMatrix(matrixItems);
            ImageAttributes ia = new ImageAttributes();
            ia.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            if (state.Priority1)
                e.Graphics.DrawImage(DrawImageFromIntArr(tileSet.Priority1Tint[1], 256, 512), rdst, 0, 0, 256, 512, GraphicsUnit.Pixel, ia);

            if (mouseEnterTileset)
                TilesetHoverBox(e.Graphics);

            if (state.CartesianGrid)
                overlay.DrawCartographicGrid(e.Graphics, Color.Gray, pictureBoxLevel.Size, new Size(16, 16), 1);

            overlay.DrawSelectionBox(e.Graphics, overlay.TileSetDragStop, overlay.TileSetDragStart, 1);
        }
        private void pictureBoxTilesetL3_Paint(object sender, PaintEventArgs e)
        {
            if (tileSetImage == null) return;

            if (levelMap.GraphicSetL3 == 0xFF) return;

            Rectangle rdst = new Rectangle(0, 0, 256, 512);

            if (state.BG)
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(paletteSet.GetBGColor())), rdst);

            e.Graphics.DrawImage(tileSetImage, rdst, 0, 0, 256, 512, GraphicsUnit.Pixel);

            float[][] matrixItems ={ 
               new float[] {1, 0, 0, 0, 0},
               new float[] {0, 1, 0, 0, 0},
               new float[] {0, 0, 1, 0, 0},
               new float[] {0, 0, 0, 0.50F, 0}, 
               new float[] {0, 0, 0, 0, 1}};
            ColorMatrix cm = new ColorMatrix(matrixItems);
            ImageAttributes ia = new ImageAttributes();
            ia.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            if (state.Priority1)
                e.Graphics.DrawImage(DrawImageFromIntArr(tileSet.Priority1Tint[2], 256, 512), rdst, 0, 0, 256, 512, GraphicsUnit.Pixel, ia);

            if (mouseEnterTileset)
                TilesetHoverBox(e.Graphics);

            if (state.CartesianGrid)
                overlay.DrawCartographicGrid(e.Graphics, Color.Gray, pictureBoxLevel.Size, new Size(16, 16), 1);

            overlay.DrawSelectionBox(e.Graphics, overlay.TileSetDragStop, overlay.TileSetDragStart, 1);
        }
        private void pictureBoxBattlefield_Paint(object sender, PaintEventArgs e)
        {
            if (battlefieldImage == null) return;

            Rectangle rdst = new Rectangle(0, 0, 512, 512);

            e.Graphics.DrawImage(battlefieldImage, rdst, 0, 0, 512, 512, GraphicsUnit.Pixel);

            if (mouseEnterTileset)
                TilesetHoverBox(e.Graphics);

            if (state.CartesianGrid)
                overlay.DrawCartographicGrid(e.Graphics, Color.Gray, pictureBoxLevel.Size, new Size(16, 16), 1);

            overlay.DrawSelectionBox(e.Graphics, overlay.TileSetDragStop, overlay.TileSetDragStart, 1);
        }

        private void pictureBoxTilesetL1_MouseEnter(object sender, EventArgs e)
        {
            mouseEnterTileset = true;
            pictureBoxTilesetL1.Invalidate();
        }
        private void pictureBoxTilesetL2_MouseEnter(object sender, EventArgs e)
        {
            mouseEnterTileset = true;
            pictureBoxTilesetL2.Invalidate();
        }
        private void pictureBoxTilesetL3_MouseEnter(object sender, EventArgs e)
        {
            mouseEnterTileset = true;
            pictureBoxTilesetL3.Invalidate();
        }
        private void pictureBoxBattlefield_MouseEnter(object sender, EventArgs e)
        {
            mouseEnterTileset = true;
            pictureBoxBattlefield.Invalidate();
        }

        private void pictureBoxTilesetL1_MouseLeave(object sender, EventArgs e)
        {
            mouseEnterTileset = false;
            pictureBoxTilesetL1.Invalidate();
        }
        private void pictureBoxTilesetL2_MouseLeave(object sender, EventArgs e)
        {
            mouseEnterTileset = false;
            pictureBoxTilesetL2.Invalidate();
        }
        private void pictureBoxTilesetL3_MouseLeave(object sender, EventArgs e)
        {
            mouseEnterTileset = false;
            pictureBoxTilesetL3.Invalidate();
        }
        private void pictureBoxBattlefield_MouseLeave(object sender, EventArgs e)
        {
            mouseEnterTileset = false;
            pictureBoxBattlefield.Invalidate();
        }

        private void pictureBoxTilesetL1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Delete: deleteToolStripMenuItem2_Click(null, null); goto default;
                case Keys.Control | Keys.X: cutToolStripMenuItem2_Click(null, null); goto default;
                case Keys.Control | Keys.C: copyToolStripMenuItem2_Click(null, null); break;
                case Keys.Control | Keys.V: pasteToolStripMenuItem2_Click(null, null); goto default;
                default: model.EditTileSets[levelMap.TileSetL1 + 0x20] = true; break;
            }
        }
        private void pictureBoxTilesetL2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Delete: deleteToolStripMenuItem2_Click(null, null); goto default;
                case Keys.Control | Keys.X: cutToolStripMenuItem2_Click(null, null); goto default;
                case Keys.Control | Keys.C: copyToolStripMenuItem2_Click(null, null); break;
                case Keys.Control | Keys.V: pasteToolStripMenuItem2_Click(null, null); goto default;
                default: model.EditTileSets[levelMap.TileSetL2 + 0x20] = true; break;
            }
        }
        private void pictureBoxTilesetL3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Delete: deleteToolStripMenuItem2_Click(null, null); goto default;
                case Keys.Control | Keys.X: cutToolStripMenuItem2_Click(null, null); goto default;
                case Keys.Control | Keys.C: copyToolStripMenuItem2_Click(null, null); break;
                case Keys.Control | Keys.V: pasteToolStripMenuItem2_Click(null, null); goto default;
                default: model.EditTileSets[levelMap.TileSetL3] = true; break;
            }
        }
        private void pictureBoxBattlefield_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.PageDown:
                    if (pictureBoxBattlefield.Top > -256)
                        pictureBoxBattlefield.Top -= 256; break;
                case Keys.PageUp:
                    if (pictureBoxBattlefield.Top < 0)
                        pictureBoxBattlefield.Top += 256; break;
                case Keys.Down:
                    if (pictureBoxBattlefield.Top > -256)
                        pictureBoxBattlefield.Top -= 16; break;
                case Keys.Up:
                    if (pictureBoxBattlefield.Top < 0)
                        pictureBoxBattlefield.Top += 16; break;
                case Keys.Right:
                    if (pictureBoxBattlefield.Left > -256)
                        pictureBoxBattlefield.Left -= 16; break;
                case Keys.Left:
                    if (pictureBoxBattlefield.Left < 0)
                        pictureBoxBattlefield.Left += 16; break;
                case Keys.Delete: deleteToolStripMenuItem2_Click(null, null); goto default;
                case Keys.Control | Keys.X: cutToolStripMenuItem2_Click(null, null); goto default;
                case Keys.Control | Keys.C: copyToolStripMenuItem2_Click(null, null); break;
                case Keys.Control | Keys.V: pasteToolStripMenuItem2_Click(null, null); goto default;
                default: model.EditTileSetsBF[battlefields[(int)battlefieldNum.Value].TileSet] = true; break;
            }
        }

        private void cutToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int offset, current;
            ushort m, n, o, p;
            tsCopyWidth = overlay.TileSetDragStop.X / 16 - overlay.TileSetDragStart.X / 16;
            tsCopyHeight = overlay.TileSetDragStop.Y / 16 - overlay.TileSetDragStart.Y / 16;
            tsCopy = new byte[0x2000];
            for (int y = overlay.TileSetDragStart.Y / 16, a = 0; y < overlay.TileSetDragStop.Y / 16; y++, a++)
            {
                for (int x = overlay.TileSetDragStart.X / 16, b = 0; x < overlay.TileSetDragStop.X / 16; x++, b++)
                {
                    current = y * 16 + x;
                    offset = current * 4;
                    offset += current / 16 * 64;
                    if (tabControl2.SelectedIndex != 4)
                    {
                        m = BitManager.GetShort(tileSet.TileSets[tabControl2.SelectedIndex], offset);
                        n = BitManager.GetShort(tileSet.TileSets[tabControl2.SelectedIndex], offset + 2);
                        o = BitManager.GetShort(tileSet.TileSets[tabControl2.SelectedIndex], offset + 64);
                        p = BitManager.GetShort(tileSet.TileSets[tabControl2.SelectedIndex], offset + 66);
                    }
                    else
                    {
                        offset += x > 15 ? 0x780 : 0;
                        offset += y > 15 ? 0x800 : 0;
                        m = BitManager.GetShort(bts.TileSet, offset);
                        n = BitManager.GetShort(bts.TileSet, offset + 2);
                        o = BitManager.GetShort(bts.TileSet, offset + 64);
                        p = BitManager.GetShort(bts.TileSet, offset + 66);
                    }

                    current = a * 16 + b;
                    offset = current * 4;
                    offset += current / 16 * 64;

                    if (tabControl2.SelectedIndex == 4)
                    {
                        offset += x > 15 ? 0x780 : 0;
                        offset += y > 15 ? 0x800 : 0;
                    }

                    BitManager.SetShort(tsCopy, offset, m);
                    BitManager.SetShort(tsCopy, offset + 2, n);
                    BitManager.SetShort(tsCopy, offset + 64, o);
                    BitManager.SetShort(tsCopy, offset + 66, p);

                    current = y * 16 + x;
                    offset = current * 4;
                    offset += current / 16 * 64;
                    if (tabControl2.SelectedIndex != 4)
                    {
                        BitManager.SetShort(this.tileSet.TileSets[tabControl2.SelectedIndex], offset, 0);
                        BitManager.SetShort(this.tileSet.TileSets[tabControl2.SelectedIndex], offset + 2, 0);
                        BitManager.SetShort(this.tileSet.TileSets[tabControl2.SelectedIndex], offset + 64, 0);
                        BitManager.SetShort(this.tileSet.TileSets[tabControl2.SelectedIndex], offset + 66, 0);
                    }
                    else
                    {
                        offset += x > 15 ? 0x780 : 0;
                        offset += y > 15 ? 0x800 : 0;
                        BitManager.SetShort(bts.TileSet, offset, 0);
                        BitManager.SetShort(bts.TileSet, offset + 2, 0);
                        BitManager.SetShort(bts.TileSet, offset + 64, 0);
                        BitManager.SetShort(bts.TileSet, offset + 66, 0);
                    }
                }
            }
            switch (tabControl2.SelectedIndex)
            {
                case 0: model.EditTileSets[levelMap.TileSetL1 + 0x20] = true; break;
                case 1: model.EditTileSets[levelMap.TileSetL2 + 0x20] = true; break;
                case 2: model.EditTileSets[levelMap.TileSetL3] = true; break;
            }
            if (tabControl2.SelectedIndex != 4) UpdateLevel();
            else
            {
                RefreshBattlefield();
                pictureBoxBattlefield.Invalidate();
                pictureBoxBattlefield.BackColor = Color.FromArgb(paletteSetBF.GetBGColorBF());
            }
        }
        private void copyToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int current, offset;
            ushort m, n, o, p;
            tsCopyWidth = overlay.TileSetDragStop.X / 16 - overlay.TileSetDragStart.X / 16;
            tsCopyHeight = overlay.TileSetDragStop.Y / 16 - overlay.TileSetDragStart.Y / 16;
            tsCopy = new byte[0x2000];
            for (int y = overlay.TileSetDragStart.Y / 16, a = 0; y < overlay.TileSetDragStop.Y / 16; y++, a++)
            {
                for (int x = overlay.TileSetDragStart.X / 16, b = 0; x < overlay.TileSetDragStop.X / 16; x++, b++)
                {
                    current = y * 16 + x;
                    offset = current * 4;
                    offset += current / 16 * 64;
                    if (tabControl2.SelectedIndex != 4)
                    {
                        m = BitManager.GetShort(tileSet.TileSets[tabControl2.SelectedIndex], offset);
                        n = BitManager.GetShort(tileSet.TileSets[tabControl2.SelectedIndex], offset + 2);
                        o = BitManager.GetShort(tileSet.TileSets[tabControl2.SelectedIndex], offset + 64);
                        p = BitManager.GetShort(tileSet.TileSets[tabControl2.SelectedIndex], offset + 66);
                    }
                    else
                    {
                        offset += x > 15 ? 0x780 : 0;
                        offset += y > 15 ? 0x800 : 0;
                        m = BitManager.GetShort(bts.TileSet, offset);
                        n = BitManager.GetShort(bts.TileSet, offset + 2);
                        o = BitManager.GetShort(bts.TileSet, offset + 64);
                        p = BitManager.GetShort(bts.TileSet, offset + 66);
                    }

                    current = a * 16 + b;
                    offset = current * 4;
                    offset += current / 16 * 64;

                    if (tabControl2.SelectedIndex == 4)
                    {
                        offset += x > 15 ? 0x780 : 0;
                        offset += y > 15 ? 0x800 : 0;
                    }

                    BitManager.SetShort(tsCopy, offset, m);
                    BitManager.SetShort(tsCopy, offset + 2, n);
                    BitManager.SetShort(tsCopy, offset + 64, o);
                    BitManager.SetShort(tsCopy, offset + 66, p);
                }
            }
            switch (tabControl2.SelectedIndex)
            {
                case 0: model.EditTileSets[levelMap.TileSetL1 + 0x20] = true; break;
                case 1: model.EditTileSets[levelMap.TileSetL2 + 0x20] = true; break;
                case 2: model.EditTileSets[levelMap.TileSetL3] = true; break;
            }
        }
        private void pasteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (tsCopy == null) return;
            int current, offset;
            ushort m, n, o, p;
            for (int y = overlay.TileSetDragStart.Y / 16, a = 0; y < overlay.TileSetDragStart.Y / 16 + tsCopyHeight; y++, a++)
            {
                for (int x = overlay.TileSetDragStart.X / 16, b = 0; x < overlay.TileSetDragStart.X / 16 + tsCopyWidth; x++, b++)
                {
                    current = a * 16 + b;
                    offset = current * 4;
                    offset += current / 16 * 64;

                    //if (tabControl2.SelectedIndex == 4)
                    //{
                    //    offset += x > 15 ? 0x780 : 0;
                    //    offset += y > 15 ? 0x800 : 0;
                    //}

                    m = BitManager.GetShort(tsCopy, offset);
                    n = BitManager.GetShort(tsCopy, offset + 2);
                    o = BitManager.GetShort(tsCopy, offset + 64);
                    p = BitManager.GetShort(tsCopy, offset + 66);

                    current = y * 16 + x;
                    offset = current * 4;
                    offset += current / 16 * 64;
                    if (tabControl2.SelectedIndex != 4)
                    {
                        if (offset >= tileSet.TileSets[tabControl2.SelectedIndex].Length) break;
                        BitManager.SetShort(tileSet.TileSets[tabControl2.SelectedIndex], offset, m);
                        BitManager.SetShort(tileSet.TileSets[tabControl2.SelectedIndex], offset + 2, n);
                        BitManager.SetShort(tileSet.TileSets[tabControl2.SelectedIndex], offset + 64, o);
                        BitManager.SetShort(tileSet.TileSets[tabControl2.SelectedIndex], offset + 66, p);
                    }
                    else
                    {
                        offset += x > 15 ? 0x780 : 0;
                        offset += y > 15 ? 0x800 : 0;
                        if (offset >= bts.TileSet.Length) break;
                        BitManager.SetShort(bts.TileSet, offset, m);
                        BitManager.SetShort(bts.TileSet, offset + 2, n);
                        BitManager.SetShort(bts.TileSet, offset + 64, o);
                        BitManager.SetShort(bts.TileSet, offset + 66, p);
                    }
                }
            }
            switch (tabControl2.SelectedIndex)
            {
                case 0: model.EditTileSets[levelMap.TileSetL1 + 0x20] = true; break;
                case 1: model.EditTileSets[levelMap.TileSetL2 + 0x20] = true; break;
                case 2: model.EditTileSets[levelMap.TileSetL3] = true; break;
            }
            if (tabControl2.SelectedIndex != 4) UpdateLevel();
            else
            {
                RefreshBattlefield();
                pictureBoxBattlefield.Invalidate();
                pictureBoxBattlefield.BackColor = Color.FromArgb(paletteSetBF.GetBGColorBF());
            }
        }
        private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int offset, current;
            for (int y = overlay.TileSetDragStart.Y / 16; y < overlay.TileSetDragStop.Y / 16; y++)
            {
                for (int x = overlay.TileSetDragStart.X / 16; x < overlay.TileSetDragStop.X / 16; x++)
                {
                    current = y * 16 + x;
                    offset = current * 4;
                    offset += current / 16 * 64;
                    if (tabControl2.SelectedIndex != 4)
                    {
                        BitManager.SetShort(this.tileSet.TileSets[tabControl2.SelectedIndex], offset, 0);
                        BitManager.SetShort(this.tileSet.TileSets[tabControl2.SelectedIndex], offset + 2, 0);
                        BitManager.SetShort(this.tileSet.TileSets[tabControl2.SelectedIndex], offset + 64, 0);
                        BitManager.SetShort(this.tileSet.TileSets[tabControl2.SelectedIndex], offset + 66, 0);
                    }
                    else
                    {
                        offset += x > 15 ? 0x780 : 0;
                        offset += y > 15 ? 0x800 : 0;
                        BitManager.SetShort(bts.TileSet, offset, 0);
                        BitManager.SetShort(bts.TileSet, offset + 2, 0);
                        BitManager.SetShort(bts.TileSet, offset + 64, 0);
                        BitManager.SetShort(bts.TileSet, offset + 66, 0);
                    }
                }
            }
            switch (tabControl2.SelectedIndex)
            {
                case 0: model.EditTileSets[levelMap.TileSetL1 + 0x20] = true; break;
                case 1: model.EditTileSets[levelMap.TileSetL2 + 0x20] = true; break;
                case 2: model.EditTileSets[levelMap.TileSetL3] = true; break;
            }
            if (tabControl2.SelectedIndex != 4) UpdateLevel();
            else
            {
                RefreshBattlefield();
                pictureBoxBattlefield.Invalidate();
                pictureBoxBattlefield.BackColor = Color.FromArgb(paletteSetBF.GetBGColorBF());
            }
        }
        private void priority1SetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl2.SelectedIndex == 4) return;

            int current, offset;
            for (int y = overlay.TileSetDragStart.Y / 16; y < overlay.TileSetDragStop.Y / 16; y++)
            {
                for (int x = overlay.TileSetDragStart.X / 16; x < overlay.TileSetDragStop.X / 16; x++)
                {
                    current = y * 16 + x;
                    offset = current * 4;
                    offset += current / 16 * 64;

                    if (offset >= tileSet.TileSets[tabControl2.SelectedIndex].Length) break;
                    tileSet.TileSets[tabControl2.SelectedIndex][offset + 1] |= 0x20;
                    tileSet.TileSets[tabControl2.SelectedIndex][offset + 3] |= 0x20;
                    tileSet.TileSets[tabControl2.SelectedIndex][offset + 65] |= 0x20;
                    tileSet.TileSets[tabControl2.SelectedIndex][offset + 67] |= 0x20;
                }
            }
            switch (tabControl2.SelectedIndex)
            {
                case 0: model.EditTileSets[levelMap.TileSetL1 + 0x20] = true; break;
                case 1: model.EditTileSets[levelMap.TileSetL2 + 0x20] = true; break;
                case 2: model.EditTileSets[levelMap.TileSetL3] = true; break;
            }
            UpdateLevel();
        }
        private void priority1ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl2.SelectedIndex == 4) return;

            int current, offset;
            for (int y = overlay.TileSetDragStart.Y / 16; y < overlay.TileSetDragStop.Y / 16; y++)
            {
                for (int x = overlay.TileSetDragStart.X / 16; x < overlay.TileSetDragStop.X / 16; x++)
                {
                    current = y * 16 + x;
                    offset = current * 4;
                    offset += current / 16 * 64;

                    if (offset >= tileSet.TileSets[tabControl2.SelectedIndex].Length) break;
                    tileSet.TileSets[tabControl2.SelectedIndex][offset + 1] &= 0xDF;
                    tileSet.TileSets[tabControl2.SelectedIndex][offset + 3] &= 0xDF;
                    tileSet.TileSets[tabControl2.SelectedIndex][offset + 65] &= 0xDF;
                    tileSet.TileSets[tabControl2.SelectedIndex][offset + 67] &= 0xDF;
                }
            }
            switch (tabControl2.SelectedIndex)
            {
                case 0: model.EditTileSets[levelMap.TileSetL1 + 0x20] = true; break;
                case 1: model.EditTileSets[levelMap.TileSetL2 + 0x20] = true; break;
                case 2: model.EditTileSets[levelMap.TileSetL3] = true; break;
            }
            UpdateLevel();
        }
        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (tabControl2.SelectedIndex == 2 && levelMap.GraphicSetL3 == 0xFF)
                return;

            panelTileEditor.Visible = true;
            buttonToggleTileEditor.Checked = true;
            InitializeTileEditor();
        }

        private void saveImageAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG files (*.png)|*.png|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            switch (tabControl2.SelectedIndex)
            {
                case 0:
                    saveFileDialog.FileName = "tileset." + (levelMap.TileSetL1 + 0x20).ToString("d3") + ".png";
                    break;
                case 1:
                    saveFileDialog.FileName = "tileset." + (levelMap.TileSetL2 + 0x20).ToString("d3") + ".png";
                    break;
                case 2:
                    saveFileDialog.FileName = "tileset." + levelMap.TileSetL3.ToString("d3") + ".png";
                    break;
                case 4:
                    saveFileDialog.FileName = "battlefield." + levelMap.Battlefield.ToString("d3") + ".png";
                    break;
                default: break;
            }
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                tileSetImage.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
        }

        #endregion
    }
}
