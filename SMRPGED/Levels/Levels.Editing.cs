using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using SMRPGED.Undo;

namespace SMRPGED
{
    public partial class Levels
    {
        // Holds all the code and variables related to editing
        private int orthCoordX = 0;
        private int orthCoordY = 0;
        private int overPhysicalTile = 0;
        private int selectPhysicalTile = 0;
        private int selectPhysicalTileNum = 0;

        private int overExitField = 0;
        private int overEventField = 0;
        private int overNPC = 0;
        private int overInstance = 0;
        private int overOverlap = 0;

        private int clickExitField = 0;
        private int clickEventField = 0;
        private int clickNPC = 0;
        private int clickInstance = 0;
        private int clickOverlap = 0;

        private int[][] copyPaste = new int[3][]; // Acts as a storage for the copied/cut/paste features
        private int[][] copyPasteBuf = new int[3][]; // for when moving, this will keep the original copyPaste
        private int copyWidth = 0;
        private int[][] drawBuf = new int[][] { new int[] { 0 }, new int[] { 0 }, new int[] { 0 } };
        private int[][] drawBufBuf = new int[][] { new int[] { 0 }, new int[] { 0 }, new int[] { 0 } };
        private int drawBufWidth = 1;
        private int drawBufWidthBuf = 1;

        private int[] tileEditorBuf = new int[256];
        private int[] tileEditorBufZoomed = new int[4096];

        private Point mouse = new Point(0, 0);
        // END OF VARIABLES

        private void MakeEditTemplate(MouseEventArgs e, Graphics g)
        {
            if (template == null)
            {
                MessageBox.Show("Must select a template to paint to the level.",
                    "WARNING: NO TEMPLATE SELECTED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Point tL = new Point(e.X / 16 * 16, e.Y / 16 * 16);
            Point bR = new Point((e.X / 16 * 16) + template.Size.Width, (e.Y / 16 * 16) + template.Size.Height);

            if (template.Even != (((tL.X / 16) % 2) == 0))
            {
                tL.X += 16;
                bR.X += 16;
            }

            drawBuf[0] = new int[template.Tilemaps[0].Length / 2];
            drawBuf[1] = new int[template.Tilemaps[1].Length / 2];
            drawBuf[2] = new int[template.Tilemaps[2].Length];
            for (int i = 0; i < drawBuf[0].Length; i++)
            {
                drawBuf[0][i] = BitManager.GetShort(template.Tilemaps[0], i * 2);
                drawBuf[1][i] = BitManager.GetShort(template.Tilemaps[1], i * 2);
                drawBuf[2][i] = template.Tilemaps[2][i];
            }
            drawBufWidth = template.Size.Width;

            commandStack.Push(new TileMapEditCommand(this, tileMap, 0, tL, bR, drawBuf, true, true));
            commandStack.Push(new PhysicalMapEditCommand(this, this.physicalMap, tL, bR, template.Start, template.Physical));

            physicalMap.DrawPhysicalMap();
            tileMap.RedrawTileMap();

            DrawLevelWithoutUpdate();
        }
        private void MakeEditDraw(MouseEventArgs e, Graphics g)
        {
            int layer = tabControl2.SelectedIndex > 2 ? 0 : tabControl2.SelectedIndex;

            if (!state.PhysicalLayer)
            {
                if (overlay.TileSetDragStart == overlay.TileSetDragStop) return;

                try
                {
                    if (TilesAreEqual(e, layer))
                        return;
                    //if (tileMap.GetTileNum(layer, e.X, e.Y) == overlay.TileSelected &&
                    //    Math.Abs(overlay.TileSetDragStop.X - overlay.TileSetDragStart.X) == 16 &&
                    //    Math.Abs(overlay.TileSetDragStop.Y - overlay.TileSetDragStart.Y) == 16)
                    //    return; // We are overwriting the same tile over itself, no need to make an edit
                    if (levelMap.GraphicSetL3 == 0xFF && layer == 2)
                        return;

                    priority1Tint = null;

                    Point tL = new Point(e.X, e.Y);
                    Point bR = new Point(e.X + (drawBufWidth * 16), e.Y + ((drawBuf[layer].Length / drawBufWidth) * 16));

                    commandStack.Push(
                        new TileMapEditCommand(this, tileMap, layer, tL, bR, drawBuf, false, editAllLayersToolStripMenuItem.Checked));

                    // draw the tile
                    Point p = new Point(e.X / 16 * 16, e.Y / 16 * 16);
                    Size s = new Size();
                    s.Width = overlay.TileSetDragStop.X - overlay.TileSetDragStart.X;
                    s.Height = overlay.TileSetDragStop.Y - overlay.TileSetDragStart.Y;

                    Bitmap image = DrawImageFromIntArr(tileMap.GetRangePixels(p, s), s.Width, s.Height);
                    p.X *= zoom;
                    p.Y *= zoom;
                    Rectangle rsrc = new Rectangle(0, 0, image.Width, image.Height);
                    Rectangle rdst = new Rectangle(p.X, p.Y, (int)(image.Width * zoom), (int)(image.Height * zoom));

                    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    g.DrawImage(image, rdst, rsrc, GraphicsUnit.Pixel);
                }
                catch
                {
                    // No command
                }
            }
            else if (state.PhysicalLayer)
            {
                try
                {
                    if (physicalMap.GetTileNum(overPhysicalTile) == (int)physicalTileNum.Value)
                        return;

                    Point tL = new Point(e.X, e.Y);
                    Point bR = new Point(e.X + 1, e.Y + 1);

                    byte[] temp = new byte[0x20C2];
                    BitManager.SetShort(temp, overPhysicalTile * 2, (ushort)this.physicalTileNum.Value);
                    commandStack.Push(new PhysicalMapEditCommand(this, this.physicalMap, tL, bR, tL, temp));
                }
                catch
                {
                    MessageBox.Show("Physical Tile Draw Error");
                }

                physicalMap.RedrawPhysicalTile(overPhysicalTile * 2);
                pictureBoxLevel.Invalidate();
            }
        }
        private bool TilesAreEqual(MouseEventArgs e, int layer)
        {
            for (int y = overlay.TileSetDragStart.Y, b = e.Y; y < overlay.TileSetDragStop.Y; y += 16, b += 16)
            {
                for (int x = overlay.TileSetDragStart.X, a = e.X; x < overlay.TileSetDragStop.X; x += 16, a += 16)
                {
                    if (tileMap.GetTileNum(layer, a, b) != tileSet.GetTileNumber(layer, x / 16, y / 16))
                        return false;
                }
            }
            return true;
        }
        private void MakeEditErase(MouseEventArgs e, Graphics g)
        {
            int layer = tabControl2.SelectedIndex > 2 ? 0 : tabControl2.SelectedIndex;

            if (!state.PhysicalLayer)
            {
                try
                {
                    if (tileMap.GetTileNum(layer, e.X, e.Y) == 0)
                        return; // We are overwriting the same tile over itself, no need to make an edit

                    priority1Tint = null;

                    commandStack.Push(new TileMapEditCommand(this, tileMap, layer, new Point(e.X, e.Y), new Point(e.X + 16, e.Y + 16),
                        new int[][] { new int[] { 0 }, new int[] { 0 }, new int[] { 0 }, new int[] { 0 } },
                        false, editAllLayersToolStripMenuItem.Checked));

                    Point p = new Point(e.X / 16 * 16, e.Y / 16 * 16);

                    Bitmap image = DrawImageFromIntArr(tileMap.GetRangePixels(p, new Size(16, 16)), 16, 16);

                    p.X *= zoom;
                    p.Y *= zoom;
                    Rectangle rsrc = new Rectangle(0, 0, image.Width, image.Height);
                    Rectangle rdst = new Rectangle(p.X, p.Y, (int)(image.Width * zoom), (int)(image.Height * zoom));

                    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    g.DrawImage(image, rdst, rsrc, GraphicsUnit.Pixel);
                }
                catch
                {
                    // No layer 3
                }
            }
            else if (state.PhysicalLayer)
            {
                try
                {
                    if (physicalMap.GetTileNum(overPhysicalTile) == 0)
                        return;

                    Point tL = new Point(e.X, e.Y);
                    Point bR = new Point(e.X + 1, e.Y + 1);

                    byte[] temp = new byte[0x20C2];
                    commandStack.Push(new PhysicalMapEditCommand(this, this.physicalMap, tL, bR, tL, temp));
                }
                catch
                {
                    MessageBox.Show("Physical Tile Erase Error");
                }

                physicalMap.RedrawPhysicalTile(overPhysicalTile * 2);
                pictureBoxLevel.Invalidate();
            }
        }
        private void MakeEditDelete()
        {
            if (!state.PhysicalLayer)
            {
                Point tL = overlay.DragStart;
                Point bR = overlay.DragStop;
                int[][] changes = new int[][]{
                    new int[(bR.X - tL.X) * (bR.Y - tL.Y)],
                    new int[(bR.X - tL.X) * (bR.Y - tL.Y)],
                    new int[(bR.X - tL.X) * (bR.Y - tL.Y)],
                    new int[(bR.X - tL.X) * (bR.Y - tL.Y)]};
                int layer = tabControl2.SelectedIndex > 2 ? 0 : tabControl2.SelectedIndex;

                try
                {
                    // Verify layer before creating command
                    commandStack.Push(new TileMapEditCommand(this, tileMap, layer, tL, bR, changes, false, editAllLayersToolStripMenuItem.Checked));

                    priority1Tint = null;
                }
                catch
                {
                    // No layer 3
                }

                DrawLevelWithoutUpdate();
            }
            else
            {
                try
                {
                    if (physicalMap.GetTileNum(selectPhysicalTile) == 0)
                        return;

                    Point tL = new Point(
                        physicalMap.OrthTilePosX[selectPhysicalTile],
                        physicalMap.OrthTilePosY[selectPhysicalTile]);
                    Point bR = new Point(
                        physicalMap.OrthTilePosX[selectPhysicalTile] + 1,
                        physicalMap.OrthTilePosY[selectPhysicalTile] + 1);

                    byte[] temp = new byte[0x20C2];
                    commandStack.Push(new PhysicalMapEditCommand(this, this.physicalMap, tL, bR, tL, temp));
                }
                catch
                {
                    MessageBox.Show("Physical Tile Erase Error");
                }

                physicalMap.RedrawPhysicalTile(selectPhysicalTile * 2);
                pictureBoxLevel.Invalidate();
            }
        }
        private void MakeEditMove(Graphics g)
        {
            Point p = new Point(overlay.DragStart.X * zoom, overlay.DragStart.Y * zoom);
            Size s = overlay.SelectionSize;
            Rectangle rsrc = new Rectangle(0, 0, s.Width, s.Height);
            Rectangle rdst = new Rectangle(p.X, p.Y, zoom * s.Width, zoom * s.Height);

            g.DrawImage(new Bitmap(moveImage), rdst, rsrc, GraphicsUnit.Pixel);
        }
        private void MakeHoverBox(Graphics g)
        {
            Point p;
            Point[] points;
            SolidBrush b = new SolidBrush(Color.FromArgb(96, 0, 0, 0));
            Rectangle r;
            Bitmap image;
            int[] pixels;
            int overPhysicalTileNum;
            int temp;

            Rectangle rsrc, rdst;

            overPhysicalTileNum = BitManager.GetShort(physicalMap.ThePhysicalMap, overPhysicalTile * 2);

            if (state.PhysicalLayer && overPhysicalTileNum != 0)
            {
                pixels = physicalTiles[overPhysicalTileNum].DrawPhysicalTile(quadBasePixels, quadBlockPixels, halfQuadBlockPixels, stairsUpLeftLowPixels, stairsUpLeftHighPixels, stairsUpRightLowPixels, stairsUpRightHighPixels);
                for (int y = 768 - physicalTiles[overPhysicalTileNum].PhysicalTileTotalHeight; y < 784; y++)
                {
                    for (int x = 0; x < 32; x++)
                    {
                        temp = pixels[y * 32 + x];
                        if (overPhysicalTileNum == 0 && temp != 0)
                            temp = Color.FromArgb(96, 0, 0, 0).ToArgb();
                        else
                            temp = temp / 2 | (0xFF << 32);

                        pixels[y * 32 + x] = temp;
                    }
                }
                image = new Bitmap(DrawImageFromIntArr(pixels, 32, 784));

                p = new Point(physicalMap.OrthTilePosX[overPhysicalTile] * zoom, physicalMap.OrthTilePosY[overPhysicalTile] * zoom);
                p.Y -= 768 * zoom;

                rsrc = new Rectangle(0, 0, 32, 784);
                rdst = new Rectangle(p.X, p.Y, zoom * 32, zoom * 784);
                g.DrawImage(image, rdst, rsrc, GraphicsUnit.Pixel);
            }
            else if (state.PhysicalLayer || state.Objects || state.Exits || state.Events || state.Overlaps)
            {
                p = new Point(physicalMap.OrthTilePosX[overPhysicalTile] * zoom, physicalMap.OrthTilePosY[overPhysicalTile] * zoom);
                points = new Point[] { 
                    new Point(p.X + (15 * zoom), p.Y), 
                    new Point(p.X - (1 * zoom), p.Y + (8 * zoom)), 
                    new Point(p.X + (16 * zoom), p.Y + (8 * zoom)), 
                    new Point(p.X + (16 * zoom), p.Y)
                };
                g.FillPolygon(new SolidBrush(Color.FromArgb(96, 0, 0, 0)), points, System.Drawing.Drawing2D.FillMode.Winding);
                points = new Point[] { 
                    new Point(p.X + (17 * zoom), p.Y), 
                    new Point(p.X + (33 * zoom), p.Y + (8 * zoom)), 
                    new Point(p.X + (16 * zoom), p.Y + (8 * zoom)), 
                    new Point(p.X + (16 * zoom), p.Y)
                };
                g.FillPolygon(new SolidBrush(Color.FromArgb(96, 0, 0, 0)), points, System.Drawing.Drawing2D.FillMode.Winding);
                p = new Point(physicalMap.OrthTilePosX[overPhysicalTile] * zoom, physicalMap.OrthTilePosY[overPhysicalTile] * zoom);
                points = new Point[] { 
                    new Point(p.X + (15 * zoom), p.Y + (16 * zoom)), 
                    new Point(p.X - (1 * zoom), p.Y + (8 * zoom)), 
                    new Point(p.X + (16 * zoom), p.Y + (8 * zoom)), 
                    new Point(p.X + (16 * zoom), p.Y + (16 * zoom))
                };
                g.FillPolygon(new SolidBrush(Color.FromArgb(96, 0, 0, 0)), points, System.Drawing.Drawing2D.FillMode.Winding);
                points = new Point[] { 
                    new Point(p.X + (17 * zoom), p.Y + (16 * zoom)), 
                    new Point(p.X + (33 * zoom), p.Y + (8 * zoom)), 
                    new Point(p.X + (16 * zoom), p.Y + (8 * zoom)), 
                    new Point(p.X + (16 * zoom), p.Y + (16 * zoom))
                };
                g.FillPolygon(new SolidBrush(Color.FromArgb(96, 0, 0, 0)), points, System.Drawing.Drawing2D.FillMode.Winding);
            }
            else
            {
                r = new Rectangle(mouse.X / 16 * 16 * zoom, mouse.Y / 16 * 16 * zoom, 16 * zoom, 16 * zoom);
                g.FillRectangle(b, r);
            }
        }

        private void MakeSelectColor(MouseEventArgs e)
        {
            Priorities.SelectedIndex = 1;

            int layer = 0;
            if (levelMap.TopPriorityL3)
            {
                if (tileMap.layer3Priority1[e.Y * 1024 + e.X] != 0)
                    layer = 2;
                else if (tileMap.layer1Priority1[e.Y * 1024 + e.X] != 0)
                    layer = 0;
                else if (tileMap.layer2Priority1[e.Y * 1024 + e.X] != 0)
                    layer = 1;
                else if (tileMap.layer1Priority0[e.Y * 1024 + e.X] != 0)
                    layer = 0;
                else if (tileMap.layer2Priority0[e.Y * 1024 + e.X] != 0)
                    layer = 1;
                else if (tileMap.layer3Priority0[e.Y * 1024 + e.X] != 0)
                    layer = 2;
            }
            else
            {
                if (tileMap.layer1Priority1[e.Y * 1024 + e.X] != 0)
                    layer = 0;
                else if (tileMap.layer2Priority1[e.Y * 1024 + e.X] != 0)
                    layer = 1;
                else if (tileMap.layer1Priority0[e.Y * 1024 + e.X] != 0)
                    layer = 0;
                else if (tileMap.layer2Priority0[e.Y * 1024 + e.X] != 0)
                    layer = 1;
                else if (tileMap.layer3Priority1[e.Y * 1024 + e.X] != 0)
                    layer = 2;
                else if (tileMap.layer3Priority0[e.Y * 1024 + e.X] != 0)
                    layer = 2;
            }
            int x = e.X / 16;
            int y = e.Y / 16;
            int tileNum = y * 64 + x;
            int placement = ((e.X % 16) / 8) + (((e.Y % 16) / 8) * 2);
            Tile16x16 temp16x16 = tileSet.TileSetLayers[layer][tileMap.GetTileNum(layer, e.X, e.Y)];
            Tile8x8 temp8x8 = temp16x16.GetSubtile(placement);

            Point p = new Point();
            p.X = (e.X % 16) % 8;
            p.Y = (e.Y % 16) % 8;
            int color = ((temp8x8.PaletteSetIndex - 1) * 16) + temp8x8.Colors[p.Y * 8 + p.X];
            numericUpDown8.Value = Math.Max(0, color);
        }

        private void Undo()
        {
            commandStack.UndoCommand();

            if (!state.PhysicalLayer)
                DrawLevelWithoutUpdate();
            else
            {
                physicalMap.DrawPhysicalMap();
                pictureBoxLevel.Invalidate();
            }
        }
        private void Redo()
        {
            commandStack.RedoCommand();

            if (!state.PhysicalLayer)
                DrawLevelWithoutUpdate();
            else
            {
                physicalMap.DrawPhysicalMap();
                pictureBoxLevel.Invalidate();
            }
        }
        private void Cut()
        {
            if (state.PhysicalLayer) return;

            Copy();
            MakeEditDelete();
        }
        private void Copy()
        {
            if (state.PhysicalLayer) return;

            int layer = tabControl2.SelectedIndex > 2 ? 0 : tabControl2.SelectedIndex;

            Size s = overlay.SelectionSize;
            if (editAllLayersToolStripMenuItem.Checked)
                moveImage = new Bitmap(DrawImageFromIntArr(tileMap.GetRangePixels(overlay.DragStart, s), s.Width, s.Height));
            else
                moveImage = new Bitmap(DrawImageFromIntArr(tileMap.GetRangePixels(layer, overlay.DragStart, s), s.Width, s.Height));

            try
            {
                GetSelectionIntArr(overlay.DragStart, overlay.DragStop, 0);
                GetSelectionIntArr(overlay.DragStart, overlay.DragStop, 1);
                GetSelectionIntArr(overlay.DragStart, overlay.DragStop, 2);
            }
            catch
            {
                // No layer 3
                return;
            }

            copyPasteBuf = copyPaste;
            drawBufBuf = drawBuf;
            drawBufWidthBuf = drawBufWidth;
        }
        private void Paste(Point p)
        {
            if (state.PhysicalLayer) return;

            int layer = tabControl2.SelectedIndex > 2 ? 0 : tabControl2.SelectedIndex;
            Point tL = p;
            Point bR;
            try
            {
                bR = new Point(p.X + (copyWidth * 16), p.Y + ((copyPaste[layer].Length / copyWidth) * 16));
            }
            catch
            { return; }

            try
            {
                // Check layer before doing this!
                commandStack.Push(new TileMapEditCommand(this, tileMap, layer, tL, bR, copyPaste, true, editAllLayersToolStripMenuItem.Checked));

                priority1Tint = null;
            }
            catch
            {

            }

            this.buttonEditPaste.Checked = false;

            DrawLevelWithoutUpdate();
        }
        private void PasteFinal()
        {
            if (state.PhysicalLayer) return;

            if (state.Move)
            {
                Paste(new Point(overlay.DragStart.X, overlay.DragStart.Y));

                copyPaste = copyPasteBuf;
                drawBuf = drawBufBuf;
                drawBufWidth = drawBufWidthBuf;

                state.Move = false;
            }
        }
        private void ClearCopyBuffers()
        {
            moveImage = null;
            copyPaste = new int[3][];
            drawBuf = new int[3][];
            drawBufWidth = 1;
            copyPasteBuf = new int[3][];
            drawBufBuf = new int[3][];
            drawBufWidthBuf = 1;
        }
        private void GetSelectionIntArr(Point tL, Point bR, int layer)
        {
            int xDiff = (bR.X / 16 - tL.X / 16);
            int yDiff = (bR.Y / 16 - tL.Y / 16);

            int tileX, tileY;

            copyPaste[layer] = new int[xDiff * yDiff];
            copyWidth = xDiff;

            for (int y = 0; y < yDiff; y++)
            {
                for (int x = 0; x < xDiff; x++)
                {
                    tileX = tL.X + (x * 16);
                    tileY = tL.Y + (y * 16);

                    copyPaste[layer][x + y * xDiff] = tileMap.GetTileNum(layer, tileX, tileY);
                }
            }

        }
        private void TilesetHoverBox(Graphics g)
        {
            SolidBrush b = new SolidBrush(Color.FromArgb(96, 0, 0, 0));
            Rectangle r;

            r = new Rectangle(mouse.X / 16 * 16, mouse.Y / 16 * 16, 16, 16);
            g.FillRectangle(b, r);
        }
        private void TileSetDown(MouseEventArgs e)
        {
            int x = e.X / 16 * 16;
            int y = e.Y / 16 * 16;

            overlay.TileSetDragStart = new Point(x, y);
            overlay.TileSetDragStop = new Point(x + 16, y + 16);
        }
        private int GetTileSetSelection(ref int[] dest)
        {
            int dx = (overlay.TileSetDragStop.X - overlay.TileSetDragStart.X) / 16;
            int dy = (overlay.TileSetDragStop.Y - overlay.TileSetDragStart.Y) / 16;

            dest = new int[dx * dy];
            int entry;

            for (int i = 0; i < dest.Length; i++)
            {
                entry = tileSet.GetTileNumber(tabControl2.SelectedIndex, (i % dx) + (overlay.TileSetDragStart.X / 16), (i / dx) + (overlay.TileSetDragStart.Y / 16));
                dest[i] = entry;
            }

            return dx;
        }
    }
}
