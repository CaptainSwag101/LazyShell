using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Properties;
using LAZYSHELL.Undo;

namespace LAZYSHELL
{
    public partial class WorldMaps : Form
    {
        #region Variables
        private long checksum;
        // main
        private delegate void Function();
        private bool updating = false;
        private int index { get { return (int)worldMapName.SelectedIndex; } }
        private WorldMap[] worldMaps { get { return Model.WorldMaps; } set { Model.WorldMaps = value; } }
        private PaletteSet palettes { get { return Model.Palettes; } set { Model.Palettes = value; } }
        private WorldMap worldMap { get { return worldMaps[index]; } set { worldMaps[index] = value; } }
        private WorldMapTileSet tileSet;
        private Overlay overlay = new Overlay();
        private Bitmap tileSetImage, mapPointsImage;
        private Settings settings = Settings.Default;
        // mouse
        private int zoom = 1;
        private bool mouseEnter = false;
        private int mouseDownTile = 0;
        private string mouseOverObject;
        private string mouseDownObject;
        private Point mouseDownPosition;
        private Point mousePosition;
        private bool moving = false;
        // editors
        private TileEditor tileEditor;
        private PaletteEditor paletteEditor;
        private GraphicEditor graphicEditor;
        // buffers and stacks
        private Bitmap selection;
        private CopyBuffer draggedTiles;
        private CopyBuffer copiedTiles;
        private CommandStack commandStack = new CommandStack();

        // old
        private ArrayList[] worldMapPoints;
        private int[] pointActivePixels;
        private int diffX, diffY;
        #endregion
        #region Methods
        // main
        public WorldMaps()
        {
            checksum = Do.GenerateChecksum(worldMaps, Model.WorldMapGraphics, Model.WorldMapPalettes,
                Model.WorldMapSprites, Model.WorldMapTileSets, Model.MapPoints);
            settings.Keystrokes[0x20] = "\x20";
            fontPalettes[0] = new PaletteSet(Model.Data, 0, 0x3DFEE0, 2, 16, 32);
            fontPalettes[1] = new PaletteSet(Model.Data, 0, 0x3E2D55, 2, 16, 32);
            fontPalettes[2] = new PaletteSet(Model.Data, 0, 0x01EF40, 2, 16, 32);
            for (int i = 0; i < fontDialogue.Length; i++)
                fontDialogue[i] = new FontCharacter(Model.Data, i, 1);
            InitializeComponent();
            Do.AddShortcut(toolStrip3, Keys.Control | Keys.S, new EventHandler(save_Click));
            Do.AddShortcut(toolStrip3, Keys.F1, helpTips);
            Do.AddShortcut(toolStrip3, Keys.F2, baseConversion);
            toolTip1.InitialDelay = 0;
            SetToolTips(toolTip1);
            InitializeMapPointEditor();
            worldMapName.SelectedIndex = 0;
            LoadPaletteEditor();
            LoadGraphicEditor();
            LoadTileEditor();
            new ToolTipLabel(this, toolTip1, baseConversion, helpTips);
        }
        private void RefreshWorldMap()
        {
            Cursor.Current = Cursors.WaitCursor;
            updating = true;

            this.worldMapTileset.Value = worldMap.Tileset;
            this.pointCount.Value = worldMap.PointCount;
            this.worldMapXCoord.Value = worldMap.XCoord;
            this.worldMapYCoord.Value = worldMap.YCoord;

            AddWorldMapPoints();
            MapPoint temp;
            if (worldMapPoints[index] != null &&
                worldMapPoints[index].Count > 0)
            {
                temp = (MapPoint)worldMapPoints[index][0];
                mapPointNum.Value = temp.Index;
            }
            else
                MessageBox.Show("There are not enough map points left to add to the current world map.\nTry reducing the amount of points used by earlier world maps.", "LAZY SHELL");

            tileSet = new WorldMapTileSet(worldMap, palettes);

            SetWorldMapImage();
            SetWorldMapPointsImage();

            updating = false;

            GC.Collect();
            Cursor.Current = Cursors.Arrow;
        }
        // tooltips
        private void SetToolTips(ToolTip toolTip1)
        {
            // World maps

            this.worldMapName.ToolTipText =
                "Select the world map to edit. There are 8 maps total.\n\n" +
                "The map may appear disoriented in correlation with the map \n" +
                "points, because the game engine stretches the map.";

            this.showMapPoints.ToolTipText =
                "Show or hide the locations in the image below. If the lo- \n" +
                "cations are shown, they can be clicked to edit them in the \n" +
                "\"LOCATIONS\" panel below.";

            toolTip1.SetToolTip(this.pointCount,
                "The total # of locations that the current map uses. The \n" +
                "collection of locations used by the map is based on the \n" +
                "locations used by the earlier maps.\n\n" +
                "Map #0, for example, by default uses 7 locations total, and \n" +
                "since it is the first map that means it will use locations #0 - 6 \n" +
                "(as seen in the \"LOCATIONS\" editor panel). Map #1 uses 6 \n" +
                "locations, and because the last location in Map #0 is location #6, \n" +
                "then Map #1's locations will be locations #7 - 12 (ie. 6 total, \n" +
                "starting at #7).");

            toolTip1.SetToolTip(this.worldMapTileset,
                "The tileset, or the actual image used by the map.\n\n" +
                "To edit a tile in the tileset, click on the tile in the image \n" +
                "above to edit it in the \"WORLD MAP TILE EDITOR\" panel to \n" +
                "the right.");

            toolTip1.SetToolTip(this.worldMapXCoord,
                "The negative X coordinate shift of the map.");

            toolTip1.SetToolTip(this.worldMapYCoord,
                "The negative Y coordinate shift of the map.");


            // Map points

            this.mapPointNum.ToolTipText =
                "Select the location to edit by #. If the location is in the \n" +
                "currently selected world map, then it will be highlighted in \n" +
                "the map.";

            this.mapPointName.ToolTipText =
                "Select the location to edit by name. If the location is in \n" +
                "the currently selected world map, then it will be highlighted \n" +
                "in the map.";

            this.textBoxMapPoint.ToolTipText =
                "Edit the location's name, as it appears at the bottom of \n" +
                "the screen when the Mario sprite is over the location.";

            toolTip1.SetToolTip(this.mapPointXCoord,
                "The absolute X coordinate of the location.");

            toolTip1.SetToolTip(this.mapPointYCoord,
                "The absolute Y coordinate of the location.");

            toolTip1.SetToolTip(this.showCheckAddress,
                "If the bit (under \"BIT SET\") of this memory address is set, \n" +
                "then the location is enabled / visible in-game.\n\n" +
                "Example: by default location #9 (Mushroom Way) is not \n" +
                "enabled or visible until bit 2 of memory address $7065 is \n" +
                "set. This bit is set at the end of event script #1396.\n\n" +
                "These bits are always set in an event script.");

            toolTip1.SetToolTip(this.showCheckBit,
                "If this bit of a memory address (under \"IF MEMORY\") is set, \n" +
                "then the location is enabled / visible in-game.\n\n" +
                "Example: by default location #9 (Mushroom Way) is not \n" +
                "enabled or visible until bit 2 of memory address $7065 is \n" +
                "set. This bit is set at the end of event script #1396.\n\n" +
                "These bits are always set in an event script.");

            toolTip1.SetToolTip(this.leadToMapPoint,
                "If this is enabled, the destination will be another location \n" +
                "(typically a location in different one of the 8 maps). If not \n" +
                "enabled, then an event (Run Event) will be triggered.");

            toolTip1.SetToolTip(this.whichPointCheckAddress,
                "If the bit (at the right) of this memory address is set, then \n" +
                "the location will lead to the first destination (next to \"lead to \n" +
                "destionation\"), otherwise it will lead to the second one.\n" +
                "This is ignored if \"LOCATION\" is disabled.");

            toolTip1.SetToolTip(this.whichPointCheckBit,
                "If this bit of the memory address (at the left) is set, then \n" +
                "the location will lead to the first destination (next to \"lead to \n" +
                "destionation\"), otherwise it will lead to the second one.\n" +
                "This is ignored if \"LOCATION\" is disabled.");

            toolTip1.SetToolTip(this.runEvent,
                "The event to run when entering the map point.\n" +
                "This is ignored if \"LOCATION\" is disabled.");

            toolTip1.SetToolTip(this.runEventEdit,
                "Edit the assigned event # in the Events editor.");

            toolTip1.SetToolTip(this.goMapPointA,
                "The destination the location leads to.");

            toolTip1.SetToolTip(this.goMapPointB,
                "The alternate destination the location leads to, if a \n" +
                "memory's bit is not set.\n" +
                "This is ignored if \"LOCATION\" is disabled.");

            toolTip1.SetToolTip(this.enableEastPath,
                "Enable the eastern path of the location, or the path to \n" +
                "the location the Mario sprite moves to when RIGHT is pressed \n" +
                "on the d-pad.");

            toolTip1.SetToolTip(this.enableSouthPath,
                "Enable the southern path of the location, or the path to \n" +
                "the location the Mario sprite moves to when DOWN is pressed \n" +
                "on the d-pad.");

            toolTip1.SetToolTip(this.enableWestPath,
                "Enable the western path of the location, or the path to \n" +
                "the location the Mario sprite moves to when LEFT is pressed \n" +
                "on the d-pad.");

            toolTip1.SetToolTip(this.enableNorthPath,
                "Enable the northern path of the location, or the path to \n" +
                "the location the Mario sprite moves to when UP is pressed on \n" +
                "the d-pad.");

            toolTip1.SetToolTip(this.toEastPoint,
                "The location the eastern path leads to, or the location the \n" +
                "Mario sprite moves to when RIGHT is pressed on the d-pad.");

            toolTip1.SetToolTip(this.toSouthPoint,
                "The location the southern path leads to, or the location the \n" +
                "Mario sprite moves to when DOWN is pressed on the d-pad.");

            toolTip1.SetToolTip(this.toWestPoint,
                "The location the western path leads to, or the location the \n" +
                "Mario sprite moves to when LEFT is pressed on the d-pad.");

            toolTip1.SetToolTip(this.toNorthPoint,
                "The location the northern path leads to, or the location the \n" +
                "Mario sprite moves to when UP is pressed on the d-pad.");

            toolTip1.SetToolTip(this.toEastCheckAddress,
                "If the bit (at the right) of this memory address is set, then \n" +
                "the eastern path will be open.");

            toolTip1.SetToolTip(this.toSouthCheckAddress,
                "If the bit (at the right) of this memory address is set, then \n" +
                "the southern path will be open.");

            toolTip1.SetToolTip(this.toWestCheckAddress,
                "If the bit (at the right) of this memory address is set, then \n" +
                "the western path will be open.");

            toolTip1.SetToolTip(this.toNorthCheckAddress,
                "If the bit (at the right) of this memory address is set, then \n" +
                "the northern path will be open.");

            toolTip1.SetToolTip(this.toEastCheckBit,
                "If this bit of the memory address (to the left) is set, then \n" +
                "the eastern path will be open.");

            toolTip1.SetToolTip(this.toSouthCheckBit,
                "If this bit of the memory address (to the left) is set, then \n" +
                "the southern path will be open.");

            toolTip1.SetToolTip(this.toWestCheckBit,
                "If this bit of the memory address (to the left) is set, then \n" +
                "the western path will be open.");

            toolTip1.SetToolTip(this.toNorthCheckBit,
                "If this bit of the memory address (to the left) is set, then \n" +
                "the northern path will be open.");
        }
        public void Assemble()
        {
            foreach (WorldMap wm in worldMaps)
                wm.Assemble();

            // Palette set
            palettes.Assemble(Model.WorldMapPalettes, 0);
            byte[] compressed = new byte[0x100];
            int totalSize = Comp.Compress(Model.WorldMapPalettes, compressed);
            if (totalSize > 0xD3)
                MessageBox.Show(
                    "Recompressed palette set exceeds allotted ROM space by " + (totalSize - 0xD4).ToString() + " bytes.\nPalettes will not save. Change some color values to reduce the size.",
                    "LAZY SHELL");
            else
                Bits.SetByteArray(Model.Data, 0x3E988D, compressed, 0, totalSize - 1);

            // Tilesets
            byte[] compress = new byte[0x800];
            totalSize = 0;
            int pOffset = 0x3E0014;
            int dOffset = 0x3E929F;
            int size = 0;
            for (int i = 0; i < Model.WorldMapTileSets.Length; i++)
            {
                Bits.SetShort(Model.Data, pOffset, (ushort)dOffset);
                size = Comp.Compress(Model.WorldMapTileSets[i], compress);
                totalSize += size + 1;
                if (totalSize > 0x5ED)
                {
                    MessageBox.Show(
                        "Recompressed tilesets exceed allotted ROM space by " + (totalSize - 0x5ED).ToString() + " bytes.\nSaving has been discontinued for tilesets " + i.ToString() + " and higher.\nChange or delete some tiles to reduce the size.",
                        "LAZY SHELL");
                    break;
                }
                else
                {
                    Model.Data[dOffset] = 1; dOffset++;
                    Bits.SetByteArray(Model.Data, dOffset, compress, 0, size - 1);
                    dOffset += size;
                    pOffset += 2;
                }
            }

            // Graphics
            compressed = new byte[0x8000];
            totalSize = Comp.Compress(Model.WorldMapGraphics, compressed);
            if (totalSize > 0x56F5)
                MessageBox.Show(
                    "Recompressed graphic sets exceed allotted ROM space by " + (totalSize - 0x56F6).ToString() + " bytes.\nPalettes will not save. Change some color values to reduce the size.",
                    "LAZY SHELL");
            else
                Bits.SetByteArray(Model.Data, 0x3E2E82, compressed, 0, totalSize - 1);

            foreach (MapPoint mp in mapPoints)
                mp.Assemble();
            AssembleAllMapPointTexts();
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
        private void SetWorldMapImage()
        {
            int[] worldMapPixels = Do.TilesetToPixels(tileSet.TileSetLayer, 16, 16, 0, false);
            tileSetImage = new Bitmap(Do.PixelsToImage(worldMapPixels, 256, 256));
            pictureBoxTileset.BackColor = Color.FromArgb(palettes.Reds[0], palettes.Greens[0], palettes.Blues[0]);
            pictureBoxTileset.Invalidate();
        }
        private void SetWorldMapPointsImage()
        {
            int[] mapPointsPixels = GetMapPointsPixels();
            mapPointsImage = new Bitmap(Do.PixelsToImage(mapPointsPixels, 256, 256));
            pictureBoxTileset.Invalidate();
        }
        // drawing
        private int[] GetMapPointsPixels()
        {
            pointActivePixels = new int[256 * 256];
            int[] pixels = new int[256 * 256];
            int[] point = GetMapPointPixels();
            MapPoint temp;

            for (int i = 0; i < worldMap.PointCount; i++)
            {
                temp = (MapPoint)worldMapPoints[index][i];
                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        if (point[y * 16 + x] != 0 && (y + temp.Y) >= 0 && (y + temp.Y) < 256 && (x + temp.X) >= 0 && (x + temp.X) < 256)
                        {
                            if (mapPointNum.Value == temp.Index)
                                pixels[(y + temp.Y) * 256 + x + temp.X] = point[y * 16 + x] / 2 | (0xFF << 32);
                            else
                                pixels[(y + temp.Y) * 256 + x + temp.X] = point[y * 16 + x];
                            pointActivePixels[(y + temp.Y) * 256 + x + temp.X] = temp.Index + 1;
                        }
                    }
                }
            }
            return pixels;
        }
        private int[] GetMapPointPixels()
        {
            int[] pixels = new int[8 * 16];

            Tile8x8 tempA = new Tile8x8(16, Model.WorldMapSprites, 0x200, GetPointPalette(), false, false, false, false);
            Tile8x8 tempB = new Tile8x8(17, Model.WorldMapSprites, 0x220, GetPointPalette(), false, false, false, false);

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
                color = Bits.GetShort(Model.Data, i * 2 + 0x3DFF00);

                red[i] = (byte)((color % 0x20) * multiplier);
                green[i] = (byte)(((color >> 5) % 0x20) * multiplier);
                blue[i] = (byte)(((color >> 10) % 0x20) * multiplier);
            }
            int[] temp = new int[16];
            for (int i = 0; i < 16; i++)
                temp[i] = Color.FromArgb(255, red[i], green[i], blue[i]).ToArgb();
            return temp;
        }
        // Editor loading
        private void LoadPaletteEditor()
        {
            if (paletteEditor == null)
            {
                paletteEditor = new PaletteEditor(new Function(PaletteUpdate), palettes, 8, 0);
                paletteEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                paletteEditor.Reload(new Function(PaletteUpdate), palettes, 8, 0);
        }
        private void LoadGraphicEditor()
        {
            if (graphicEditor == null)
            {
                graphicEditor = new GraphicEditor(new Function(GraphicUpdate),
                    tileSet.Graphics, tileSet.Graphics.Length, 0, palettes, 0, 0x20);
                graphicEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                graphicEditor.Reload(new Function(GraphicUpdate),
                    tileSet.Graphics, tileSet.Graphics.Length, 0, palettes, 0, 0x20);
        }
        private void LoadTileEditor()
        {
            if (tileEditor == null)
            {
                tileEditor = new TileEditor(new Function(TileUpdate),
                this.tileSet.TileSetLayer[mouseDownTile],
                tileSet.Graphics, palettes, 0x20);
                tileEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                tileEditor.Reload(new Function(TileUpdate),
                this.tileSet.TileSetLayer[mouseDownTile],
                tileSet.Graphics, palettes, 0x20);
        }
        // Editor updating
        private void TileUpdate()
        {
            tileSet.DrawTileset(tileSet.TileSetLayer, tileSet.TileSet);
            SetWorldMapImage();
        }
        private void PaletteUpdate()
        {
            this.tileSet = new WorldMapTileSet(worldMap, palettes);
            SetWorldMapImage();
            LoadGraphicEditor();
            LoadTileEditor();
            checksum--;   // b/c switching colors won't modify checksum
        }
        private void GraphicUpdate()
        {
            this.tileSet.AssembleIntoModel(16, 16);
            this.tileSet = new WorldMapTileSet(worldMap, palettes);
            SetWorldMapImage();
            LoadTileEditor();
        }
        // Editing
        private void DrawHoverBox(Graphics g)
        {
            Rectangle r = new Rectangle(mousePosition.X / 16 * 16 * zoom, mousePosition.Y / 16 * 16 * zoom, 16 * zoom, 16 * zoom);
            g.FillRectangle(new SolidBrush(Color.FromArgb(96, 0, 0, 0)), r);
        }
        private void Copy()
        {
            if (overlay.SelectTS == null) return;
            if (draggedTiles != null)
            {
                this.copiedTiles = draggedTiles;
                return;
            }
            // make the copy
            int x_ = overlay.SelectTS.Location.X / 16;
            int y_ = overlay.SelectTS.Location.Y / 16;
            this.copiedTiles = new CopyBuffer(overlay.SelectTS.Width, overlay.SelectTS.Height);
            Tile16x16[] copiedTiles = new Tile16x16[(overlay.SelectTS.Width / 16) * (overlay.SelectTS.Height / 16)];
            for (int y = 0; y < overlay.SelectTS.Height / 16; y++)
            {
                for (int x = 0; x < overlay.SelectTS.Width / 16; x++)
                {
                    copiedTiles[y * (overlay.SelectTS.Width / 16) + x] =
                        tileSet.TileSetLayer[(y + y_) * 16 + x + x_].Copy();
                }
            }
            this.copiedTiles.Tiles = copiedTiles;
        }
        /// <summary>
        /// Start dragging a selection.
        /// </summary>
        private void Drag()
        {
            if (overlay.SelectTS == null) return;
            // make the copy
            int x_ = overlay.SelectTS.Location.X / 16;
            int y_ = overlay.SelectTS.Location.Y / 16;
            this.draggedTiles = new CopyBuffer(overlay.SelectTS.Width, overlay.SelectTS.Height);
            Tile16x16[] draggedTiles = new Tile16x16[(overlay.SelectTS.Width / 16) * (overlay.SelectTS.Height / 16)];
            for (int y = 0; y < overlay.SelectTS.Height / 16; y++)
            {
                for (int x = 0; x < overlay.SelectTS.Width / 16; x++)
                {
                    draggedTiles[y * (overlay.SelectTS.Width / 16) + x] =
                        tileSet.TileSetLayer[(y + y_) * 16 + x + x_].Copy();
                }
            }
            this.draggedTiles.Tiles = draggedTiles;
            selection = new Bitmap(this.draggedTiles.Image);
            Delete();
        }
        private void Cut()
        {
            Copy();
            Delete();
        }
        private void Paste(Point location, CopyBuffer buffer)
        {
            if (buffer == null) return;
            moving = true;
            // now dragging a new selection
            draggedTiles = buffer;
            selection = buffer.Image;
            overlay.SelectTS = new Overlay.Selection(16, location, buffer.Size);
            pictureBoxTileset.Invalidate();
        }
        /// <summary>
        /// "Cements" either a dragged selection or a newly pasted selection.
        /// </summary>
        /// <param name="buffer">The dragged selection or the newly pasted selection.</param>
        private void PasteFinal(CopyBuffer buffer)
        {
            selection = null;
            int x_ = overlay.SelectTS.X / 16;
            int y_ = overlay.SelectTS.Y / 16;
            for (int y = 0; y < buffer.Height / 16; y++)
            {
                for (int x = 0; x < buffer.Width / 16; x++)
                {
                    if (y + y_ < 0 || x + x_ < 0) continue;
                    Tile16x16 tile = buffer.Tiles[y * (buffer.Width / 16) + x];
                    tileSet.TileSetLayer[(y + y_) * 16 + x + x_] = tile.Copy();
                    tileSet.TileSetLayer[(y + y_) * 16 + x + x_].TileIndex = (y + y_) * 16 + x + x_;
                }
            }
            tileSet.DrawTileset(tileSet.TileSetLayer, tileSet.TileSet);
            SetWorldMapImage();
        }
        private void Delete()
        {
            if (overlay.SelectTS == null) return;
            int x_ = overlay.SelectTS.Location.X / 16;
            int y_ = overlay.SelectTS.Location.Y / 16;
            for (int y = 0; y < overlay.SelectTS.Height / 16; y++)
            {
                for (int x = 0; x < overlay.SelectTS.Width / 16; x++)
                    tileSet.TileSetLayer[(y + y_) * 16 + x + x_].Clear();
            }
            tileSet.DrawTileset(tileSet.TileSetLayer, tileSet.TileSet);
            SetWorldMapImage();
        }
        private void Flip(string type)
        {
            if (draggedTiles != null)
                PasteFinal(draggedTiles);
            if (overlay.SelectTS == null) return;
            int x_ = overlay.SelectTS.Location.X / 16;
            int y_ = overlay.SelectTS.Location.Y / 16;
            CopyBuffer buffer = new CopyBuffer(overlay.SelectTS.Width, overlay.SelectTS.Height);
            Tile16x16[] copiedTiles = new Tile16x16[(overlay.SelectTS.Width / 16) * (overlay.SelectTS.Height / 16)];
            for (int y = 0; y < overlay.SelectTS.Height / 16; y++)
            {
                for (int x = 0; x < overlay.SelectTS.Width / 16; x++)
                {
                    copiedTiles[y * (overlay.SelectTS.Width / 16) + x] =
                        tileSet.TileSetLayer[(y + y_) * 16 + x + x_].Copy();
                }
            }
            if (type == "mirror")
                Do.FlipHorizontal(copiedTiles, overlay.SelectTS.Width / 16, overlay.SelectTS.Height / 16);
            else if (type == "invert")
                Do.FlipVertical(copiedTiles, overlay.SelectTS.Width / 16, overlay.SelectTS.Height / 16);
            buffer.Tiles = copiedTiles;
            PasteFinal(buffer);
            tileSet.DrawTileset(tileSet.TileSetLayer, tileSet.TileSet);
            SetWorldMapImage();
        }
        #endregion
        #region Eventhandlers
        // main
        private void WorldMaps_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.S))
                Assemble();
        }
        private void WorldMaps_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Do.GenerateChecksum(worldMaps, Model.WorldMapGraphics, Model.WorldMapPalettes,
                Model.WorldMapSprites, Model.WorldMapTileSets, Model.MapPoints) == checksum)
                goto Close;
            DialogResult result = MessageBox.Show(
                "World Maps have not been saved.\n\nWould you like to save changes?", "LAZY SHELL",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                Assemble();
            else if (result == DialogResult.No)
            {
                Model.MapPoints = null;
                Model.WorldMapGraphics = null;
                Model.WorldMapPalettes = null;
                Model.WorldMaps = null;
                Model.WorldMapSprites = null;
                Model.WorldMapTileSets[0] = null;
                Model.Palettes = null;
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
        Close:
            tileEditor.Close();
            paletteEditor.Close();
            graphicEditor.Close();
        }
        private void worldMapName_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshWorldMap();
        }
        private void showMapPoints_Click(object sender, EventArgs e)
        {
            toolStrip2.Enabled = !showMapPoints.Checked;
            if (showMapPoints.Checked)
            {
                buttonEditSelect.Checked = false;
                if (draggedTiles != null)
                    PasteFinal(draggedTiles);
                overlay.SelectTS = null;
                pictureBoxTileset.Cursor = Cursors.Arrow;
            }
            pictureBoxTileset.Invalidate();
        }
        private void pointCount_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            worldMap.PointCount = (byte)pointCount.Value;
            AddWorldMapPoints();
            SetWorldMapPointsImage();
        }
        private void worldMapTileset_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;

            worldMap.Tileset = (byte)worldMapTileset.Value;
            tileSet = new WorldMapTileSet(worldMap, palettes);

            SetWorldMapImage();
        }
        private void worldMapXCoord_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            worldMap.XCoord = (byte)worldMapXCoord.Value;
            pictureBoxTileset.Invalidate();
        }
        private void worldMapYCoord_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            worldMap.YCoord = (byte)worldMapYCoord.Value;
            pictureBoxTileset.Invalidate();
        }
        // image
        private void pictureBoxTileset_Paint(object sender, PaintEventArgs e)
        {
            if (tileSetImage == null) return;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            Rectangle rdst = new Rectangle(0, 0, 256, 256);
            if (showMapPoints.Checked)
            {
                double third = 100.0 / 3.0;
                rdst.Y -= 8;
                rdst.Width = (int)Do.PercentIncrease(third, 256.0);
                rdst.Height = (int)Do.PercentIncrease(third, 256.0);
                double x = (sbyte)((worldMap.XCoord ^ 0xFF) + 1);
                double y = (sbyte)((worldMap.YCoord ^ 0xFF) + 1);
                x = (int)Do.PercentIncrease(third, x);
                y = (int)Do.PercentIncrease(third, y);
                x -= Do.PercentDecrease(third, 256) / 4.0;
                y -= Do.PercentDecrease(third, 256) / 4.0;
                rdst.Offset((int)x, (int)y);
            }

            if (buttonToggleBG.Checked)
                e.Graphics.Clear(Color.FromArgb(palettes.Palette[0]));

            if (tileSetImage != null)
                e.Graphics.DrawImage(tileSetImage, rdst, 0, 0, 256, 256, GraphicsUnit.Pixel);
            if (mapPointsImage != null && showMapPoints.Checked)
                e.Graphics.DrawImage(mapPointsImage, 0, 0);
            if (moving && selection != null)
            {
                Rectangle rsrc = new Rectangle(0, 0, overlay.SelectTS.Width, overlay.SelectTS.Height);
                rdst = new Rectangle(
                    overlay.SelectTS.X * zoom, overlay.SelectTS.Y * zoom,
                    rsrc.Width * zoom, rsrc.Height * zoom);
                e.Graphics.DrawImage(new Bitmap(selection), rdst, rsrc, GraphicsUnit.Pixel);
            }

            float[][] matrixItems ={ 
               new float[] {1, 0, 0, 0, 0},
               new float[] {0, 1, 0, 0, 0},
               new float[] {0, 0, 1, 0, 0},
               new float[] {0, 0, 0, 0.50F, 0}, 
               new float[] {0, 0, 0, 0, 1}};
            ColorMatrix cm = new ColorMatrix(matrixItems);
            ImageAttributes ia = new ImageAttributes();
            ia.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            if (mouseEnter && !showMapPoints.Checked)
                DrawHoverBox(e.Graphics);

            if (buttonToggleCartGrid.Checked)
                overlay.DrawCartesianGrid(e.Graphics, Color.Gray, pictureBoxTileset.Size, new Size(16, 16), 1);

            if (overlay.SelectTS != null)
                overlay.DrawSelectionBox(e.Graphics, overlay.SelectTS.Terminal, overlay.SelectTS.Location, 1);
        }
        private void pictureBoxTileset_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;
            mouseDownObject = null;
            // set a floor and ceiling for the coordinates
            int x = Math.Max(0, Math.Min(e.X, pictureBoxTileset.Width));
            int y = Math.Max(0, Math.Min(e.Y, pictureBoxTileset.Height));
            pictureBoxTileset.Focus();
            if (buttonEditSelect.Checked)
            {
                // if moving an object and outside of it, paste it
                if (moving && mouseOverObject != "selection")
                {
                    // if copied tiles were pasted and not dragging a non-copied selection
                    if (copiedTiles != null && draggedTiles == null)
                        PasteFinal(copiedTiles);
                    if (draggedTiles != null)
                    {
                        PasteFinal(draggedTiles);
                        draggedTiles = null;
                    }
                    selection = null;
                    moving = false;
                }
                // if making a new selection
                if (e.Button == MouseButtons.Left && mouseOverObject == null)
                    overlay.SelectTS = new Overlay.Selection(16, x / 16 * 16, y / 16 * 16, 16, 16);
                // if moving a current selection
                if (e.Button == MouseButtons.Left && mouseOverObject == "selection")
                {
                    mouseDownObject = "selection";
                    mouseDownPosition = overlay.SelectTS.MousePosition(x, y);
                    if (!moving)    // only do this if the current selection has not been initially moved
                    {
                        moving = true;
                        Drag();
                    }
                }
            }
            else if (showMapPoints.Checked)
            {
                if (pointActivePixels[y * 256 + x] != 0)
                {
                    mapPointNum.Value = pointActivePixels[y * 256 + x] - 1;
                    diffX = (int)(x - mapPointXCoord.Value);
                    diffY = (int)(y - mapPointYCoord.Value);
                    mouseDownObject = "location";
                    SetWorldMapPointsImage();
                }
            }
            mouseDownTile = y / 16 * 16 + (x / 16);
            LoadTileEditor();
        }
        private void pictureBoxTileset_MouseMove(object sender, MouseEventArgs e)
        {
            // set a floor and ceiling for the coordinates
            int x = Math.Max(0, Math.Min(e.X, pictureBoxTileset.Width));
            int y = Math.Max(0, Math.Min(e.Y, pictureBoxTileset.Height));
            mouseOverObject = null;
            mousePosition = new Point(x, y);
            if (buttonEditSelect.Checked)
            {
                // if making a new selection
                if (e.Button == MouseButtons.Left && mouseDownObject == null && overlay.SelectTS != null)
                    overlay.SelectTS.Final = new Point(
                        Math.Min(x + 16, pictureBoxTileset.Width),
                        Math.Min(y + 16, pictureBoxTileset.Height));
                // if dragging the current selection
                if (e.Button == MouseButtons.Left && mouseDownObject == "selection")
                    overlay.SelectTS.Location = new Point(
                        x / 16 * 16 - mouseDownPosition.X,
                        y / 16 * 16 - mouseDownPosition.Y);
                // check if over selection
                if (e.Button == MouseButtons.None && overlay.SelectTS != null && overlay.SelectTS.MouseWithin(x, y))
                {
                    mouseOverObject = "selection";
                    pictureBoxTileset.Cursor = Cursors.SizeAll;
                }
                else
                    pictureBoxTileset.Cursor = Cursors.Cross;
            }
            else if (showMapPoints.Checked)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (mouseDownObject == "location")
                    {
                        x = Math.Max(0, Math.Min(e.X - diffX, pictureBoxTileset.Width));
                        y = Math.Max(0, Math.Min(e.Y - diffY, pictureBoxTileset.Height));
                        if (mapPointXCoord.Value != x && mapPointYCoord.Value != y)
                            updating = true;
                        mapPointXCoord.Value = x;
                        updating = false;
                        mapPointYCoord.Value = y;
                    }
                }
                else
                {
                    if (pointActivePixels[e.Y * 256 + e.X] != 0)
                        pictureBoxTileset.Cursor = Cursors.Hand;
                    else
                        pictureBoxTileset.Cursor = Cursors.Arrow;
                }
            }
            pictureBoxTileset.Invalidate();
        }
        private void pictureBoxTileset_MouseUp(object sender, MouseEventArgs e)
        {

        }
        private void pictureBoxTileset_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private void pictureBoxTileset_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
        private void pictureBoxTileset_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter = true;
            pictureBoxTileset.Invalidate();
        }
        private void pictureBoxTileset_MouseLeave(object sender, EventArgs e)
        {
            mouseEnter = false;
            pictureBoxTileset.Invalidate();
        }
        private void pictureBoxTileset_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.V))
                buttonEditPaste_Click(null, null);
            if (e.KeyData == (Keys.Control | Keys.C))
                buttonEditCopy_Click(null, null);
            if (e.KeyData == Keys.Delete)
                buttonEditDelete_Click(null, null);
            if (e.KeyData == (Keys.Control | Keys.X))
                buttonEditCut_Click(null, null);
            if (e.KeyData == (Keys.Control | Keys.D))
            {
                if (draggedTiles != null)
                    PasteFinal(draggedTiles);
                else
                {
                    overlay.SelectTS = null;
                    pictureBoxTileset.Invalidate();
                }
            }
            if (e.KeyData == (Keys.Control | Keys.A))
            {
                overlay.SelectTS = new Overlay.Selection(16, 0, 0, 256, 256);
                pictureBoxTileset.Invalidate();
            }
        }
        // drawing buttons
        private void buttonToggleCartGrid_Click(object sender, EventArgs e)
        {
            pictureBoxTileset.Invalidate();
        }
        private void buttonToggleBG_Click(object sender, EventArgs e)
        {
            pictureBoxTileset.Invalidate();
        }
        private void buttonEditDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void buttonEditCopy_Click(object sender, EventArgs e)
        {
            Copy();
        }
        private void buttonEditCut_Click(object sender, EventArgs e)
        {
            Cut();
        }
        private void buttonEditPaste_Click(object sender, EventArgs e)
        {
            if (draggedTiles != null)
                PasteFinal(draggedTiles);
            Paste(new Point(16, 16), copiedTiles);
        }
        private void buttonEditUndo_Click(object sender, EventArgs e)
        {

        }
        private void buttonEditRedo_Click(object sender, EventArgs e)
        {

        }
        private void buttonEditSelect_Click(object sender, EventArgs e)
        {
            if (buttonEditSelect.Checked)
                this.pictureBoxTileset.Cursor = System.Windows.Forms.Cursors.Cross;
            else
                this.pictureBoxTileset.Cursor = System.Windows.Forms.Cursors.Arrow;
        }
        // open editors
        private void openPalettes_Click(object sender, EventArgs e)
        {
            paletteEditor.Visible = true;
        }
        private void openGraphics_Click(object sender, EventArgs e)
        {
            graphicEditor.Visible = true;
        }
        private void openTileEditor_Click(object sender, EventArgs e)
        {
            tileEditor.Visible = true;
        }
        private void editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            ((Form)sender).Hide();
        }
        // menu strip
        private void save_Click(object sender, EventArgs e)
        {
            Assemble();
        }
        private void import_Click(object sender, EventArgs e)
        {
            new IOElements(worldMaps, index, "IMPORT WORLD MAPS...").ShowDialog();
            RefreshWorldMap();
        }
        private void export_Click(object sender, EventArgs e)
        {
            new IOElements(worldMaps, index, "EXPORT WORLD MAPS...").ShowDialog();
        }
        private void clear_Click(object sender, EventArgs e)
        {
            ClearElements clearElements = new ClearElements(worldMaps, index, "CLEAR WORLD MAPS...");
            clearElements.ShowDialog();
            if (clearElements.DialogResult == DialogResult.Cancel)
                return;
            RefreshWorldMap();
        }
        private void resetWorldMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current world map. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            int pointer = Bits.GetShort(Model.Data, worldMap.Tileset * 2 + 0x3E0014);
            int offset = 0x3E0000 + pointer + 1;
            Model.WorldMapTileSets[worldMap.Tileset] = Comp.Decompress(Model.Data, offset, 0x800);
            worldMap = new WorldMap(Model.Data, index);
            RefreshWorldMap();
        }
        private void resetMapPointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current map point. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            mapPoint = new MapPoint(Model.Data, index_l);
            RefreshMapPointEditor();
        }
        // context menu strip
        private void mirrorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Flip("mirror");
        }
        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Flip("invert");
        }
        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Do.Export(tileSetImage, "worldMap." + index.ToString("d2") + ".png");
        }
        #endregion
    }
}
