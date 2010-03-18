using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using SMRPGED.Properties;

namespace SMRPGED
{
    public partial class Sprites
    {
        #region Variables

        private bool updatingWorldMap;

        private WorldMap[] worldMaps;
        private WorldMapPalettes worldMapPalettes;
        private WorldMapTileset worldMapTileSet;

        private int currentWorldMap;
        private int currentWorldMapColor;
        private int currentWorldMapTile;
        private int currentWorldMapSubtile;

        private ArrayList[] worldMapPoints;
        private int[] pointActivePixels;
        private bool pointMouseOver = false;
        private byte[] wmCopy = new byte[0x800];
        private int wmCopyWidth, wmCopyHeight;
        private int diffX, diffY;

        private Bitmap
            worldMapImage,
            wmPaletteImage,
            mapPointsImage,
            wmTileImage,
            wmSubtileImage,
            graphicSetImage;
        private int[]
            worldMapPixels,
            wmPalettePixels,
            mapPointsPixels,
            wmTilePixels,
            wmSubtilePixels,
            graphicSetPixels;

        #endregion

        #region Methods

        // initialize properties
        private void InitializeWorldMapEditor()
        {
            updatingWorldMap = true;

            this.worldMaps = spriteModel.WorldMaps;

            DecompressWorldMapData();

            worldMapPalettes = new WorldMapPalettes(model.WorldMapPalettes);
            worldMapTileSet = new WorldMapTileset(worldMaps[currentWorldMap], worldMapPalettes, model);

            currentWorldMap = 0;
            this.worldMapNum.Value = 0;

            this.worldMapTileset.Value = worldMaps[currentWorldMap].Tileset;
            this.pointCount.Value = worldMaps[currentWorldMap].PointCount;
            this.worldMapXCoord.Value = worldMaps[currentWorldMap].XCoord;
            this.worldMapYCoord.Value = worldMaps[currentWorldMap].YCoord;

            AddWorldMapPoints();

            MapPoint temp = (MapPoint)worldMapPoints[currentWorldMap][0];
            mapPointNum.Value = temp.MapPointNum;

            InitializeWorldMapPaletteColor();
            InitializeWorldMapSubtileProperties();

            SetWorldMapImage();
            SetWorldMapPointsImage();
            SetWorldMapTileImage();
            SetWorldMapSubtileImage();
            SetWorldMapGraphicSetImage();
            SetWorldMapPaletteImage();

            updatingWorldMap = false;

            GC.Collect();
        }

        private void InitializeWorldMapPaletteColor()
        {
            updatingWorldMap = true;

            wmPaletteRedNum.Value = worldMapPalettes.PaletteColorRed[currentWorldMapColor];
            wmPaletteGreenNum.Value = worldMapPalettes.PaletteColorGreen[currentWorldMapColor];
            wmPaletteBlueNum.Value = worldMapPalettes.PaletteColorBlue[currentWorldMapColor];
            wmPaletteRedBar.Value = worldMapPalettes.PaletteColorRed[currentWorldMapColor];
            wmPaletteGreenBar.Value = worldMapPalettes.PaletteColorGreen[currentWorldMapColor];
            wmPaletteBlueBar.Value = worldMapPalettes.PaletteColorBlue[currentWorldMapColor];

            this.pictureBoxWMPaletteColor.BackColor = Color.FromArgb((int)wmPaletteRedNum.Value, (int)wmPaletteGreenNum.Value, (int)wmPaletteBlueNum.Value);

            updatingWorldMap = false;
        }
        private void InitializeWorldMapSubtileProperties()
        {
            updatingWorldMap = true;

            wmSubtile.Value = worldMapTileSet.TilesetLayer[currentWorldMapTile].GetSubtile(currentWorldMapSubtile).TileNum;
            wmSubtilePalette.Value = worldMapTileSet.TilesetLayer[currentWorldMapTile].GetSubtile(currentWorldMapSubtile).PaletteSetIndex;
            wmGraphicSet.Value = worldMapTileSet.TilesetLayer[currentWorldMapTile].GetSubtile(currentWorldMapSubtile).GfxSetIndex;

            wmSubtileProperties.SetItemChecked(0, worldMapTileSet.TilesetLayer[currentWorldMapTile].GetSubtile(currentWorldMapSubtile).PriorityOne);
            wmSubtileProperties.SetItemChecked(1, worldMapTileSet.TilesetLayer[currentWorldMapTile].GetSubtile(currentWorldMapSubtile).Mirrored);
            wmSubtileProperties.SetItemChecked(2, worldMapTileSet.TilesetLayer[currentWorldMapTile].GetSubtile(currentWorldMapSubtile).Inverted);

            updatingWorldMap = false;
        }

        // refresh properties
        private void RefreshWorldMapEditor()
        {
            updatingWorldMap = true;

            this.worldMapTileset.Value = worldMaps[currentWorldMap].Tileset;
            this.pointCount.Value = worldMaps[currentWorldMap].PointCount;
            this.worldMapXCoord.Value = worldMaps[currentWorldMap].XCoord;
            this.worldMapYCoord.Value = worldMaps[currentWorldMap].YCoord;

            AddWorldMapPoints();
            MapPoint temp;
            if (worldMapPoints[currentWorldMap] != null)
            {
                temp = (MapPoint)worldMapPoints[currentWorldMap][0];
                mapPointNum.Value = temp.MapPointNum;
            }
            else
                MessageBox.Show("There are not enough map points left to add to the current world map.\nTry reducing the amount of points used by earlier world maps.", "WARNING: NOT ENOUGH MAP POINTS", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            worldMapTileSet = new WorldMapTileset(worldMaps[currentWorldMap], worldMapPalettes, model);

            InitializeWorldMapSubtileProperties();

            SetWorldMapImage();
            SetWorldMapPointsImage();
            SetWorldMapTileImage();
            SetWorldMapSubtileImage();
            SetWorldMapGraphicSetImage();

            updatingWorldMap = false;

            GC.Collect();
        }
        private void AddWorldMapPoints()
        {
            worldMapPoints = new ArrayList[worldMaps.Length];
            for (int i = 0, b = 0; i < mapPoints.Length && b < worldMaps.Length; b++)
            {
                worldMapPoints[b] = new ArrayList();
                for (int a = 0; i < mapPoints.Length && a < worldMaps[b].PointCount; a++, i++)
                    worldMapPoints[b].Add(mapPoints[i]);
            }
        }

        // set images
        private void SetWorldMapImage()
        {
            worldMapPixels = worldMapTileSet.GetTilesetPixelArray();
            worldMapImage = new Bitmap(DrawImageFromIntArr(worldMapPixels, 256, 256));
            pictureBoxWorldMap.BackColor = Color.FromArgb(worldMapPalettes.PaletteColorRed[0], worldMapPalettes.PaletteColorGreen[0], worldMapPalettes.PaletteColorBlue[0]);
            pictureBoxWorldMap.Invalidate();
        }
        private void SetWorldMapTileImage()
        {
            int[] temp = new int[16 * 16];
            wmTilePixels = new int[32 * 32];

            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < 2; x++)
                    CopyOverTile8x8(worldMapTileSet.TilesetLayer[currentWorldMapTile].GetSubtile(y * 2 + x), temp, 16, x, y);
            }
            for (int y = 0; y < 32; y++)
            {
                for (int x = 0; x < 32; x++)
                    wmTilePixels[y * 32 + x] = temp[y / 2 * 16 + (x / 2)];
            }
            wmTileImage = new Bitmap(DrawImageFromIntArr(wmTilePixels, 32, 32));
            pictureBoxTile.BackColor = Color.FromArgb(worldMapPalettes.PaletteColorRed[0], worldMapPalettes.PaletteColorGreen[0], worldMapPalettes.PaletteColorBlue[0]);
            pictureBoxTile.Invalidate();
        }
        private void SetWorldMapSubtileImage()
        {
            int[] temp = new int[8 * 8];
            wmSubtilePixels = new int[32 * 32];

            CopyOverTile8x8(worldMapTileSet.TilesetLayer[currentWorldMapTile].GetSubtile(currentWorldMapSubtile), temp, 8, 0, 0);
            for (int y = 0; y < 32; y++)
            {
                for (int x = 0; x < 32; x++)
                    wmSubtilePixels[y * 32 + x] = temp[y / 4 * 8 + (x / 4)];
            }
            wmSubtileImage = new Bitmap(DrawImageFromIntArr(wmSubtilePixels, 32, 32));
            pictureBoxSubtile.BackColor = Color.FromArgb(worldMapPalettes.PaletteColorRed[0], worldMapPalettes.PaletteColorGreen[0], worldMapPalettes.PaletteColorBlue[0]);
            pictureBoxSubtile.Invalidate();
        }
        private void SetWorldMapPaletteImage()
        {
            wmPalettePixels = worldMapPalettes.GetPalettePixels();
            wmPaletteImage = new Bitmap(DrawImageFromIntArr(wmPalettePixels, 256, 128));
            pictureBoxWMPalette.Invalidate();
        }
        private void SetWorldMapGraphicSetImage()
        {
            graphicSetPixels = new int[256 * 256];
            int[] temp = new int[128 * 128];
            Tile8x8 subtile;

            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    subtile = Draw4bppTile8x8(
                        y * 16 + x,
                        (byte)wmGraphicSet.Value,
                        (byte)wmSubtilePalette.Value,
                        false, false, false);
                    CopyOverTile8x8(subtile, temp, 128, x, y);
                }
            }
            for (int y = 0; y < 256; y++)
            {
                for (int x = 0; x < 256; x++)
                    graphicSetPixels[y * 256 + x] = temp[y / 2 * 128 + (x / 2)];
            }

            graphicSetImage = new Bitmap(DrawImageFromIntArr(graphicSetPixels, 256, 256));
            pictureBoxWMGraphics.BackColor = Color.FromArgb(worldMapPalettes.PaletteColorRed[0], worldMapPalettes.PaletteColorGreen[0], worldMapPalettes.PaletteColorBlue[0]);
            pictureBoxWMGraphics.Invalidate();
        }
        private void SetWorldMapPointsImage()
        {
            mapPointsPixels = GetMapPointsPixels();
            mapPointsImage = new Bitmap(DrawImageFromIntArr(mapPointsPixels, 256, 256));
            pictureBoxWorldMap.Invalidate();
        }

        private void DecompressWorldMapData()
        {
            int pointer = 0;
            int offset = 0;

            // graphics/palettes
            model.WorldMapGraphics = model.Decompress(0x3E2E82, 0x8000);
            model.WorldMapPalettes = model.Decompress(0x3E988D, 0x100);
            model.WorldMapSprites = model.Decompress(0x3E90A7, 0x400);

            // tilesets
            for (int i = 0; i < 9; i++)
            {
                pointer = BitManager.GetShort(data, i * 2 + 0x3E0014);
                offset = 0x3E0000 + pointer + 1;
                model.WorldMapTileSets[i] = model.Decompress(offset, 0x800);
            }
        }

        // drawing
        private int[] GetMapPointsPixels()
        {
            pointActivePixels = new int[256 * 256];
            int[] pixels = new int[256 * 256];
            int[] point = GetMapPointPixels();
            MapPoint temp;

            for (int i = 0; i < worldMaps[currentWorldMap].PointCount; i++)
            {
                temp = (MapPoint)worldMapPoints[currentWorldMap][i];
                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        if (point[y * 16 + x] != 0 && (y + temp.YCoord) >= 0 && (y + temp.YCoord) < 256 && (x + temp.XCoord) >= 0 && (x + temp.XCoord) < 256)
                        {
                            if (mapPointNum.Value == temp.MapPointNum)
                                pixels[(y + temp.YCoord) * 256 + x + temp.XCoord] = point[y * 16 + x] / 2 | (0xFF << 32);
                            else
                                pixels[(y + temp.YCoord) * 256 + x + temp.XCoord] = point[y * 16 + x];
                            pointActivePixels[(y + temp.YCoord) * 256 + x + temp.XCoord] = temp.MapPointNum + 1;
                        }
                    }
                }
            }
            return pixels;
        }
        private int[] GetMapPointPixels()
        {
            int[] pixels = new int[8 * 16];

            Tile8x8 tempA = new Tile8x8(16, model.WorldMapSprites, 0x200, GetPointPalette(), false, false, false, false);
            Tile8x8 tempB = new Tile8x8(17, model.WorldMapSprites, 0x220, GetPointPalette(), false, false, false, false);

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    pixels[y * 16 + x] = tempA.Pixels[y * 8 + x];
                    pixels[y * 16 + x + 8] = tempB.Pixels[y * 8 + x];
                }
            }

            return pixels;
        }
        private int[] GetPointPalette()
        {
            double multiplier = 8; // 8;
            ushort color = 0;
            int[] red = new int[16], green = new int[16], blue = new int[16];

            for (int i = 0; i < 16; i++) // 16 colors in palette
            {
                color = BitManager.GetShort(data, i * 2 + 0x3DFF00);

                red[i] = (byte)((color % 0x20) * multiplier);
                green[i] = (byte)(((color >> 5) % 0x20) * multiplier);
                blue[i] = (byte)(((color >> 10) % 0x20) * multiplier);
            }
            int[] temp = new int[16];
            for (int i = 0; i < 16; i++)
                temp[i] = Color.FromArgb(255, red[i], green[i], blue[i]).ToArgb();
            return temp;
        }
        private void CopyOverTile8x8(Tile8x8 source, int[] dest, int destinationWidth, int x, int y)
        {
            x *= 8;
            y *= 8;

            int[] src = source.Pixels;
            int counter = 0;
            for (int i = 0; i < 64; i++)
            {
                dest[y * destinationWidth + x + counter] = src[i];
                counter++;
                if (counter % 8 == 0)
                {
                    y++;
                    counter = 0;
                }
            }
        }
        private Tile8x8 Draw4bppTile8x8(int tile, byte graphicSetIndex, byte paletteSetIndex, bool mirrored, bool inverted, bool priorityOne)
        {
            int offsetChange;
            bool twobpp = false;

            offsetChange = graphicSetIndex * 0x2000;
            int tileDataOffset = (tile * 0x20) + offsetChange;

            if (tileDataOffset >= model.WorldMapGraphics.Length)
                tileDataOffset = 0;

            Tile8x8 temp;
            temp = new Tile8x8(tile, model.WorldMapGraphics, tileDataOffset, worldMapPalettes.GetWorldMapPalette(paletteSetIndex), mirrored, inverted, priorityOne, twobpp);
            return temp;
        }
        private Tile8x8 CreateNewSubtile()
        {
            return Draw4bppTile8x8(
                (byte)wmSubtile.Value,
                (byte)wmGraphicSet.Value,
                (byte)wmSubtilePalette.Value,
                wmSubtileProperties.GetItemChecked(1),
                wmSubtileProperties.GetItemChecked(2),
                wmSubtileProperties.GetItemChecked(0));
        }

        // editing
        private void PasteWorldMap()
        {
            if (wmCopy == null) return;
            int offsetA, offsetB, currentA, currentB;
            for (int y = overlay.TileSetDragStart.Y / 16, b = 0; y < overlay.TileSetDragStop.Y / 16 + wmCopyHeight; y++, b++)
            {
                for (int x = overlay.TileSetDragStart.X / 16, a = 0; x < overlay.TileSetDragStop.X / 16 + wmCopyWidth; x++, a++)
                {
                    currentA = y * 16 + x;
                    offsetA = currentA * 4 + (currentA / 16 * 64);
                    if (offsetA >= model.WorldMapTileSets[(int)worldMapTileset.Value].Length) break;
                    currentB = b * 16 + a;
                    offsetB = currentB * 4 + (currentB / 16 * 64);
                    BitManager.SetShort(model.WorldMapTileSets[(int)worldMapTileset.Value], offsetA, BitManager.GetShort(wmCopy, offsetB));
                    BitManager.SetShort(model.WorldMapTileSets[(int)worldMapTileset.Value], offsetA + 2, BitManager.GetShort(wmCopy, offsetB + 2));
                    BitManager.SetShort(model.WorldMapTileSets[(int)worldMapTileset.Value], offsetA + 64, BitManager.GetShort(wmCopy, offsetB + 64));
                    BitManager.SetShort(model.WorldMapTileSets[(int)worldMapTileset.Value], offsetA + 66, BitManager.GetShort(wmCopy, offsetB + 66));
                }
            }
            worldMapTileSet = new WorldMapTileset(worldMaps[currentWorldMap], worldMapPalettes, model);
            InitializeWorldMapSubtileProperties();
            SetWorldMapImage();
            SetWorldMapTileImage();
            SetWorldMapSubtileImage();
        }
        private void CutWorldMap()
        {
            int offsetA, offsetB, currentA, currentB;
            wmCopyWidth = overlay.TileSetDragStop.X / 16 - overlay.TileSetDragStart.X / 16;
            wmCopyHeight = overlay.TileSetDragStop.Y / 16 - overlay.TileSetDragStart.Y / 16;
            for (int y = overlay.TileSetDragStart.Y / 16, b = 0; y < overlay.TileSetDragStop.Y / 16; y++, b++)
            {
                for (int x = overlay.TileSetDragStart.X / 16, a = 0; x < overlay.TileSetDragStop.X / 16; x++, a++)
                {
                    currentA = y * 16 + x;
                    offsetA = currentA * 4 + (currentA / 16 * 64);
                    currentB = b * 16 + a;
                    offsetB = currentB * 4 + (currentB / 16 * 64);
                    BitManager.SetShort(wmCopy, offsetB, BitManager.GetShort(model.WorldMapTileSets[(int)worldMapTileset.Value], offsetA));
                    BitManager.SetShort(wmCopy, offsetB + 2, BitManager.GetShort(model.WorldMapTileSets[(int)worldMapTileset.Value], offsetA + 2));
                    BitManager.SetShort(wmCopy, offsetB + 64, BitManager.GetShort(model.WorldMapTileSets[(int)worldMapTileset.Value], offsetA + 64));
                    BitManager.SetShort(wmCopy, offsetB + 66, BitManager.GetShort(model.WorldMapTileSets[(int)worldMapTileset.Value], offsetA + 66));
                }
            }
            DeleteWorldMap();
        }
        private void CopyWorldMap()
        {
            int offsetA, offsetB, currentA, currentB;
            wmCopyWidth = overlay.TileSetDragStop.X / 16 - overlay.TileSetDragStart.X / 16;
            wmCopyHeight = overlay.TileSetDragStop.Y / 16 - overlay.TileSetDragStart.Y / 16;
            for (int y = overlay.TileSetDragStart.Y / 16, b = 0; y < overlay.TileSetDragStop.Y / 16; y++, b++)
            {
                for (int x = overlay.TileSetDragStart.X / 16, a = 0; x < overlay.TileSetDragStop.X / 16; x++, a++)
                {
                    currentA = y * 16 + x;
                    offsetA = currentA * 4 + (currentA / 16 * 64);
                    currentB = b * 16 + a;
                    offsetB = currentB * 4 + (currentB / 16 * 64);
                    BitManager.SetShort(wmCopy, offsetB, BitManager.GetShort(model.WorldMapTileSets[(int)worldMapTileset.Value], offsetA));
                    BitManager.SetShort(wmCopy, offsetB + 2, BitManager.GetShort(model.WorldMapTileSets[(int)worldMapTileset.Value], offsetA + 2));
                    BitManager.SetShort(wmCopy, offsetB + 64, BitManager.GetShort(model.WorldMapTileSets[(int)worldMapTileset.Value], offsetA + 64));
                    BitManager.SetShort(wmCopy, offsetB + 66, BitManager.GetShort(model.WorldMapTileSets[(int)worldMapTileset.Value], offsetA + 66));
                }
            }
        }
        private void DeleteWorldMap()
        {
            int offsetA, currentA;
            for (int y = overlay.TileSetDragStart.Y / 16, b = 0; y < overlay.TileSetDragStop.Y / 16; y++, b++)
            {
                for (int x = overlay.TileSetDragStart.X / 16, a = 0; x < overlay.TileSetDragStop.X / 16; x++, a++)
                {
                    currentA = y * 16 + x;
                    offsetA = currentA * 4 + (currentA / 16 * 64);
                    BitManager.SetShort(model.WorldMapTileSets[(int)worldMapTileset.Value], offsetA, 0);
                    BitManager.SetShort(model.WorldMapTileSets[(int)worldMapTileset.Value], offsetA + 2, 0);
                    BitManager.SetShort(model.WorldMapTileSets[(int)worldMapTileset.Value], offsetA + 64, 0);
                    BitManager.SetShort(model.WorldMapTileSets[(int)worldMapTileset.Value], offsetA + 66, 0);
                }
            }
            worldMapTileSet = new WorldMapTileset(worldMaps[currentWorldMap], worldMapPalettes, model);
            InitializeWorldMapSubtileProperties();
            SetWorldMapImage();
            SetWorldMapTileImage();
            SetWorldMapSubtileImage();
        }

        // import / export
        private void ExportWorldMapGraphic()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "worldMapGraphics.bin";
            saveFileDialog.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            byte[] graphicBlock = BitManager.GetByteArray(spriteGraphics, graphicPalettes[currentGraphicPalette].GraphicOffset - 0x280000, 0x8000);

            FileStream fs;
            BinaryWriter bw;
            try
            {
                // Create the file to store the level data
                fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.ReadWrite);
                bw = new BinaryWriter(fs);
                bw.Write(graphicBlock);
            }
            catch
            {
                MessageBox.Show("There was a problem exporting the graphic block.");
            }
        }
        private void ImportWorldMapGraphic(string path)
        {
            FileStream fs;
            BinaryReader br;

            byte[] graphicBlock = new byte[0x8000];

            try
            {
                fs = File.OpenRead(path);
                br = new BinaryReader(fs);
                graphicBlock = br.ReadBytes(0x8000);

                byte[] compressed = new byte[0x8000];
                int totalSize = model.Compress(graphicBlock, compressed);
                if (totalSize > 0x56F5)
                    MessageBox.Show(
                        "Recompressed graphic sets exceed allotted ROM space by " + (totalSize - 0x56F6).ToString() + " bytes.\nPalettes will not save. Change some color values to reduce the size.",
                        "WARNING: RECOMPRESSED GRAPHIC SETS TOO LARGE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    graphicBlock.CopyTo(spriteGraphics, graphicPalettes[currentGraphicPalette].GraphicOffset - 0x280000);
                    graphicOFfset_ValueChanged(null, null);
                }

                br.Close();
                fs.Close();
            }
            catch
            {
                MessageBox.Show("There was a problem loading the file.");
                return;
            }
        }

        // assembly
        private void AssembleAllWorldMaps()
        {
            foreach (WorldMap wm in worldMaps)
                wm.Assemble();

            // Palette set
            worldMapPalettes.Assemble();
            byte[] compressed = new byte[0x100];
            int totalSize = model.Compress(worldMapPalettes.PaletteSet, compressed);
            if (totalSize > 0xD3)
                MessageBox.Show(
                    "Recompressed palette set exceeds allotted ROM space by " + (totalSize - 0xD4).ToString() + " bytes.\nPalettes will not save. Change some color values to reduce the size.",
                    "WARNING: RECOMPRESSED PALETTE SET TOO LARGE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                BitManager.SetByteArray(data, 0x3E988D, compressed, 0, totalSize - 1);

            // Tilesets
            byte[] compress = new byte[0x800];
            totalSize = 0;
            int pOffset = 0x3E0014;
            int dOffset = 0x3E929F;
            int size = 0;
            for (int i = 0; i < model.WorldMapTileSets.Length; i++)
            {
                BitManager.SetShort(data, pOffset, (ushort)dOffset);
                size = model.Compress(model.WorldMapTileSets[i], compress);
                totalSize += size + 1;
                if (totalSize > 0x5ED)
                {
                    MessageBox.Show(
                        "Recompressed tilesets exceed allotted ROM space by " + (totalSize - 0x5ED).ToString() + " bytes.\nSaving has been discontinued for tilesets " + i.ToString() + " and higher.\nChange or delete some tiles to reduce the size.",
                        "WARNING: RECOMPRESSED TILESETS TOO LARGE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                }
                else
                {
                    data[dOffset] = 1; dOffset++;
                    BitManager.SetByteArray(data, dOffset, compress, 0, size - 1);
                    dOffset += size;
                    pOffset += 2;
                }
            }

            // Graphics
            compressed = new byte[0x8000];
            totalSize = model.Compress(model.WorldMapGraphics, compressed);
            if (totalSize > 0x56F5)
                MessageBox.Show(
                    "Recompressed graphic sets exceed allotted ROM space by " + (totalSize - 0x56F6).ToString() + " bytes.\nPalettes will not save. Change some color values to reduce the size.",
                    "WARNING: RECOMPRESSED GRAPHIC SETS TOO LARGE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                BitManager.SetByteArray(data, 0x3E2E82, compressed, 0, totalSize - 1);
        }

        #endregion

        #region Eventhandlers

        private void worldMapNum_ValueChanged(object sender, EventArgs e)
        {
            currentWorldMap = (int)worldMapNum.Value;
            RefreshWorldMapEditor();
        }
        private void showMapPoints_Click(object sender, EventArgs e)
        {
            showMapPoints.ForeColor = showMapPoints.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            SetWorldMapPointsImage();
        }
        private void pointCount_ValueChanged(object sender, EventArgs e)
        {
            if (updatingWorldMap) return;

            worldMaps[currentWorldMap].PointCount = (byte)pointCount.Value;
            AddWorldMapPoints();
            SetWorldMapPointsImage();
        }
        private void worldMapTileset_ValueChanged(object sender, EventArgs e)
        {
            if (updatingWorldMap) return;

            worldMaps[currentWorldMap].Tileset = (byte)worldMapTileset.Value;
            worldMapTileSet = new WorldMapTileset(worldMaps[currentWorldMap], worldMapPalettes, model);

            InitializeWorldMapSubtileProperties();
            SetWorldMapImage();
            SetWorldMapTileImage();
            SetWorldMapSubtileImage();
            SetWorldMapGraphicSetImage();
        }
        private void worldMapXCoord_ValueChanged(object sender, EventArgs e)
        {
            if (updatingWorldMap) return;

            worldMaps[currentWorldMap].XCoord = (byte)worldMapXCoord.Value;
            worldMapTileSet = new WorldMapTileset(worldMaps[currentWorldMap], worldMapPalettes, model);

            SetWorldMapImage();
        }
        private void worldMapYCoord_ValueChanged(object sender, EventArgs e)
        {
            if (updatingWorldMap) return;

            worldMaps[currentWorldMap].YCoord = (byte)worldMapYCoord.Value;
            worldMapTileSet = new WorldMapTileset(worldMaps[currentWorldMap], worldMapPalettes, model);

            SetWorldMapImage();
        }

        private void pictureBoxWorldMap_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X; int y = e.Y;
            x -= diffX; y -= diffY;
            if (x > 255) x = 255; if (x < 0) x = 0;
            if (y > 255) y = 255; if (y < 0) y = 0;
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                if (pointMouseOver)
                {
                    if (mapPointXCoord.Value != x && mapPointYCoord.Value != y)
                        waitBothCoords = true;
                    mapPointXCoord.Value = x;
                    waitBothCoords = false;
                    mapPointYCoord.Value = y;
                }
                else
                {
                    overlay.TileSetDragStop = new Point(e.X / 16 * 16 + 16, e.Y / 16 * 16 + 16);
                    pictureBoxWorldMap.Invalidate();
                }
            }
            else
            {
                if (showMapPoints.Checked && pointActivePixels[e.Y * 256 + e.X] != 0)
                    pictureBoxWorldMap.Cursor = Cursors.Hand;
                else
                    pictureBoxWorldMap.Cursor = Cursors.Cross;
            }
        }
        private void pictureBoxWorldMap_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxWorldMap.Focus();
            if (showMapPoints.Checked && pointActivePixels[e.Y * 256 + e.X] != 0)
            {
                mapPointNum.Value = pointActivePixels[e.Y * 256 + e.X] - 1;
                diffX = (int)(e.X - mapPointXCoord.Value);
                diffY = (int)(e.Y - mapPointYCoord.Value);
                pointMouseOver = true;
                SetWorldMapPointsImage();
            }
            else
            {
                pointMouseOver = false;
                overlay.wmap = true; overlay.bdlg = false;
                TileSetDown(e);
                pictureBoxWorldMap.Invalidate();
            }
        }
        private void pictureBoxWorldMap_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X - (sbyte)(worldMaps[currentWorldMap].XCoord ^ 0xFF);
            int y = e.Y - (sbyte)(worldMaps[currentWorldMap].YCoord ^ 0xFF);
            if (x < 0 || y < 0 || x > 255 || y > 255) return;
            currentWorldMapTile = (y / 16) * 16 + (x / 16);
            currentWorldMapSubtile = 0;
            InitializeWorldMapSubtileProperties();
            SetWorldMapTileImage();
            SetWorldMapSubtileImage();
            SetWorldMapGraphicSetImage();
        }
        private void pictureBoxWorldMap_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Delete: DeleteWorldMap(); break;
                case Keys.Control | Keys.C: CopyWorldMap(); break;
                case Keys.Control | Keys.X: CutWorldMap(); break;
                case Keys.Control | Keys.V: PasteWorldMap(); break;
                case Keys.Control | Keys.D:
                    overlay.TileSetDragStop = new Point(0, 0);
                    overlay.TileSetDragStart = new Point(0, 0);
                    pictureBoxWorldMap.Invalidate();
                    break;
            }
        }
        private void pictureBoxWorldMap_Paint(object sender, PaintEventArgs e)
        {
            if (worldMapImage != null)
                e.Graphics.DrawImage(worldMapImage, 0, 0);

            if (mapPointsImage != null && showMapPoints.Checked)
                e.Graphics.DrawImage(mapPointsImage, 0, 0);

            overlay.DrawSelectionBox(e.Graphics, overlay.TileSetDragStop, overlay.TileSetDragStart, 1);
        }

        // world map palette
        private void pictureBoxWMPalette_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBoxWMPalette.Focus();

            wmPaletteColor.Value = (e.Y / 16) * 16 + (e.X / 16);

            InitializeWorldMapPaletteColor();
        }
        private void pictureBoxWMPalette_Paint(object sender, PaintEventArgs e)
        {
            if (wmPaletteImage != null)
                e.Graphics.DrawImage(wmPaletteImage, 0, 0);

            Point p = new Point(currentWorldMapColor % 16 * 16, currentWorldMapColor / 16 * 16);
            if (p.Y == 0) p.Y++;
            overlay.DrawSelectionBox(e.Graphics, new Point(p.X + 15, p.Y + 15 - (p.Y % 16)), p, 1);
        }
        private void wmPaletteColor_ValueChanged(object sender, EventArgs e)
        {
            if (updatingWorldMap) return;

            currentWorldMapColor = (int)wmPaletteColor.Value;

            InitializeWorldMapPaletteColor();

            pictureBoxWMPalette.Invalidate();
        }
        private void wmPaletteRedNum_ValueChanged(object sender, EventArgs e)
        {
            if (updatingWorldMap) return;

            wmPaletteRedNum.Value -= wmPaletteRedNum.Value % 8;

            wmPaletteRedBar.Value = (int)wmPaletteRedNum.Value;
            worldMapPalettes.PaletteColorRed[currentWorldMapColor] = (int)wmPaletteRedNum.Value;
            Color color = Color.FromArgb((int)wmPaletteRedNum.Value, (int)wmPaletteGreenNum.Value, (int)wmPaletteBlueNum.Value);
            this.pictureBoxWMPaletteColor.BackColor = color;
            this.pictureBoxWMGraphics.BackColor = color;
            this.pictureBoxTile.BackColor = color;
            this.pictureBoxSubtile.BackColor = color;

            worldMapTileSet = new WorldMapTileset(worldMaps[currentWorldMap], worldMapPalettes, model);

            SetWorldMapPaletteImage();
            SetWorldMapImage();
            SetWorldMapTileImage();
            SetWorldMapSubtileImage();
            SetWorldMapGraphicSetImage();

            worldMapPalettes.Assemble();
            byte[] compressed = new byte[0x100];
            int size = model.Compress(worldMapPalettes.PaletteSet, compressed) + 1;
            if (size > 0xD4)
                MessageBox.Show(
                    "Recompressed palette set exceeds allotted ROM space by " + (size - 0xD4).ToString() + " bytes.\nPalettes will not save. Change some color values to reduce the size.",
                    "WARNING: RECOMPRESSED PALETTE SET TOO LARGE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void wmPaletteGreenNum_ValueChanged(object sender, EventArgs e)
        {
            if (updatingWorldMap) return;

            wmPaletteGreenNum.Value -= wmPaletteGreenNum.Value % 8;

            wmPaletteGreenBar.Value = (int)wmPaletteGreenNum.Value;
            worldMapPalettes.PaletteColorGreen[currentWorldMapColor] = (int)wmPaletteGreenNum.Value;
            Color color = Color.FromArgb((int)wmPaletteRedNum.Value, (int)wmPaletteGreenNum.Value, (int)wmPaletteBlueNum.Value);
            this.pictureBoxWMPaletteColor.BackColor = color;
            this.pictureBoxWMGraphics.BackColor = color;
            this.pictureBoxTile.BackColor = color;
            this.pictureBoxSubtile.BackColor = color;

            worldMapTileSet = new WorldMapTileset(worldMaps[currentWorldMap], worldMapPalettes, model);

            SetWorldMapPaletteImage();
            SetWorldMapImage();
            SetWorldMapTileImage();
            SetWorldMapSubtileImage();
            SetWorldMapGraphicSetImage();

            worldMapPalettes.Assemble();
            byte[] compressed = new byte[0x100];
            int size = model.Compress(worldMapPalettes.PaletteSet, compressed) + 1;
            if (size > 0xD4)
                MessageBox.Show(
                    "Recompressed palette set exceeds allotted ROM space by " + (size - 0xD4).ToString() + " bytes.\nPalettes will not save. Change some color values to reduce the size.",
                    "WARNING: RECOMPRESSED PALETTE SET TOO LARGE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void wmPaletteBlueNum_ValueChanged(object sender, EventArgs e)
        {
            if (updatingWorldMap) return;

            wmPaletteBlueNum.Value -= wmPaletteBlueNum.Value % 8;

            wmPaletteBlueBar.Value = (int)wmPaletteBlueNum.Value;
            worldMapPalettes.PaletteColorBlue[currentWorldMapColor] = (int)wmPaletteBlueNum.Value;
            Color color = Color.FromArgb((int)wmPaletteRedNum.Value, (int)wmPaletteGreenNum.Value, (int)wmPaletteBlueNum.Value);
            this.pictureBoxWMPaletteColor.BackColor = color;
            this.pictureBoxWMGraphics.BackColor = color;
            this.pictureBoxTile.BackColor = color;
            this.pictureBoxSubtile.BackColor = color;

            worldMapTileSet = new WorldMapTileset(worldMaps[currentWorldMap], worldMapPalettes, model);

            SetWorldMapPaletteImage();
            SetWorldMapImage();
            SetWorldMapTileImage();
            SetWorldMapSubtileImage();
            SetWorldMapGraphicSetImage();

            worldMapPalettes.Assemble();
            byte[] compressed = new byte[0x100];
            int size = model.Compress(worldMapPalettes.PaletteSet, compressed) + 1;
            if (size > 0xD4)
                MessageBox.Show(
                    "Recompressed palette set exceeds allotted ROM space by " + (size - 0xD4).ToString() + " bytes.\nPalettes will not save. Change some color values to reduce the size.",
                    "WARNING: RECOMPRESSED PALETTE SET TOO LARGE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void wmPaletteRedBar_Scroll(object sender, EventArgs e)
        {
            if (updatingWorldMap) return;

            wmPaletteRedBar.Value -= wmPaletteRedBar.Value % 8;
            wmPaletteRedNum.Value = wmPaletteRedBar.Value;
        }
        private void wmPaletteGreenBar_Scroll(object sender, EventArgs e)
        {
            if (updatingWorldMap) return;

            wmPaletteGreenBar.Value -= wmPaletteGreenBar.Value % 8;
            wmPaletteGreenNum.Value = wmPaletteGreenBar.Value;
        }
        private void wmPaletteBlueBar_Scroll(object sender, EventArgs e)
        {
            if (updatingWorldMap) return;

            wmPaletteBlueBar.Value -= wmPaletteBlueBar.Value % 8;
            wmPaletteBlueNum.Value = wmPaletteBlueBar.Value;
        }

        // World map tile editor
        private void wmShowGrid_CheckedChanged(object sender, EventArgs e)
        {
            wmShowGrid.ForeColor = wmShowGrid.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            SetWorldMapTileImage();
            SetWorldMapGraphicSetImage();
        }
        private void wmSubtile_ValueChanged(object sender, EventArgs e)
        {
            if (updatingWorldMap) return;

            worldMapTileSet.TilesetLayer[currentWorldMapTile].SetSubtile(CreateNewSubtile(), currentWorldMapSubtile);

            int offset = currentWorldMapTile * 4;
            if (currentWorldMapSubtile % 2 == 1) offset += 2;
            if (currentWorldMapSubtile / 2 == 1) offset += 64;
            offset += (currentWorldMapTile / 16) * 64;

            model.WorldMapTileSets[currentWorldMap][offset] = (byte)wmSubtile.Value;

            SetWorldMapImage();
            SetWorldMapTileImage();
            SetWorldMapSubtileImage();
            SetWorldMapGraphicSetImage();

            byte[] compressed = new byte[0x800];
            int size = 0;
            for (int i = 0; i < model.WorldMapTileSets.Length; i++)
                size += model.Compress(model.WorldMapTileSets[i], compressed) + 1;
            if (size > 0x5ED)
                MessageBox.Show(
                    "Recompressed tilesets exceed allotted ROM space by " + (size - 0x5ED).ToString() + " bytes.\nTilesets will not save. Change or delete some tiles to reduce the size.",
                    "WARNING: RECOMPRESSED TILESETS TOO LARGE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void wmGraphicSet_ValueChanged(object sender, EventArgs e)
        {
            if (updatingWorldMap) return;

            worldMapTileSet.TilesetLayer[currentWorldMapTile].SetSubtile(CreateNewSubtile(), currentWorldMapSubtile);

            int offset = currentWorldMapTile * 4;
            if (currentWorldMapSubtile % 2 == 1) offset += 2;
            if (currentWorldMapSubtile / 2 == 1) offset += 64;
            offset += (currentWorldMapTile / 16) * 64;

            model.WorldMapTileSets[currentWorldMap][offset + 1] &= 0xFC;
            model.WorldMapTileSets[currentWorldMap][offset + 1] |= (byte)wmGraphicSet.Value;

            SetWorldMapImage();
            SetWorldMapTileImage();
            SetWorldMapSubtileImage();
            SetWorldMapGraphicSetImage();

            byte[] compressed = new byte[0x800];
            int size = 0;
            for (int i = 0; i < model.WorldMapTileSets.Length; i++)
                size += model.Compress(model.WorldMapTileSets[i], compressed) + 1;
            if (size > 0x5ED)
                MessageBox.Show(
                    "Recompressed tilesets exceed allotted ROM space by " + (size - 0x5ED).ToString() + " bytes.\nTilesets will not save. Change or delete some tiles to reduce the size.",
                    "WARNING: RECOMPRESSED TILESETS TOO LARGE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void wmSubtilePalette_ValueChanged(object sender, EventArgs e)
        {
            if (updatingWorldMap) return;

            worldMapTileSet.TilesetLayer[currentWorldMapTile].SetSubtile(CreateNewSubtile(), currentWorldMapSubtile);

            int offset = currentWorldMapTile * 4;
            if (currentWorldMapSubtile % 2 == 1) offset += 2;
            if (currentWorldMapSubtile / 2 == 1) offset += 64;
            offset += (currentWorldMapTile / 16) * 64;

            model.WorldMapTileSets[currentWorldMap][offset + 1] &= 3;
            model.WorldMapTileSets[currentWorldMap][offset + 1] |= (byte)((int)wmSubtilePalette.Value << 2);

            SetWorldMapImage();
            SetWorldMapTileImage();
            SetWorldMapSubtileImage();
            SetWorldMapGraphicSetImage();

            byte[] compressed = new byte[0x800];
            int size = 0;
            for (int i = 0; i < model.WorldMapTileSets.Length; i++)
                size += model.Compress(model.WorldMapTileSets[i], compressed) + 1;
            if (size > 0x5ED)
                MessageBox.Show(
                    "Recompressed tilesets exceed allotted ROM space by " + (size - 0x5ED).ToString() + " bytes.\nTilesets will not save. Change or delete some tiles to reduce the size.",
                    "WARNING: RECOMPRESSED TILESETS TOO LARGE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void wmSubtileProperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingWorldMap) return;

            worldMapTileSet.TilesetLayer[currentWorldMapTile].SetSubtile(CreateNewSubtile(), currentWorldMapSubtile);

            int offset = currentWorldMapTile * 4;
            if (currentWorldMapSubtile % 2 == 1) offset += 2;
            if (currentWorldMapSubtile / 2 == 1) offset += 64;
            offset += (currentWorldMapTile / 16) * 64;

            BitManager.SetBit(model.WorldMapTileSets[currentWorldMap], offset + 1, 5, wmSubtileProperties.GetItemChecked(0));
            BitManager.SetBit(model.WorldMapTileSets[currentWorldMap], offset + 1, 6, wmSubtileProperties.GetItemChecked(1));
            BitManager.SetBit(model.WorldMapTileSets[currentWorldMap], offset + 1, 7, wmSubtileProperties.GetItemChecked(2));

            SetWorldMapImage();
            SetWorldMapTileImage();
            SetWorldMapSubtileImage();
            SetWorldMapGraphicSetImage();

            byte[] compressed = new byte[0x800];
            int size = 0;
            for (int i = 0; i < model.WorldMapTileSets.Length; i++)
                size += model.Compress(model.WorldMapTileSets[i], compressed) + 1;
            if (size > 0x5ED)
                MessageBox.Show(
                    "Recompressed tilesets exceed allotted ROM space by " + (size - 0x5ED).ToString() + " bytes.\nTilesets will not save. Change or delete some tiles to reduce the size.",
                    "WARNING: RECOMPRESSED TILESETS TOO LARGE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void pictureBoxTile_MouseClick(object sender, MouseEventArgs e)
        {
            currentWorldMapSubtile = e.X / 16 + ((e.Y / 16) * 2);

            InitializeWorldMapSubtileProperties();
            SetWorldMapSubtileImage();
        }
        private void pictureBoxTile_Paint(object sender, PaintEventArgs e)
        {
            if (wmTileImage != null)
                e.Graphics.DrawImage(wmTileImage, 0, 0);

            if (wmShowGrid.Checked)
                overlay.DrawCartographicGrid(e.Graphics, Color.Gray, new Size(32, 32), new Size(16, 16), 1);
        }
        private void pictureBoxSubtile_Paint(object sender, PaintEventArgs e)
        {
            if (wmSubtileImage != null)
                e.Graphics.DrawImage(wmSubtileImage, 0, 0);
        }
        private void pictureBoxWMGraphics_MouseMove(object sender, MouseEventArgs e)
        {
            mouseOverSubtile = e.Y / 16 * 16 + (e.X / 16);
            mouseOverControl = pictureBoxWMGraphics.Name;
        }
        private void pictureBoxWMGraphics_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            setAsSubtileToolStripMenuItem_Click(null, null);
        }
        private void pictureBoxWMGraphics_Paint(object sender, PaintEventArgs e)
        {
            if (graphicSetImage != null)
                e.Graphics.DrawImage(graphicSetImage, 0, 0);

            if (wmShowGrid.Checked)
                overlay.DrawCartographicGrid(e.Graphics, Color.Gray, new Size(256, 256), new Size(16, 16), 1);
        }

        #endregion
    }
}
