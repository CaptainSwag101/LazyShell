using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Undo;

namespace LAZYSHELL
{
    public partial class LevelsTilemap : Form
    {
        #region Variables
        // main
        private delegate void Function();
        public PictureBox Picture { get { return pictureBoxLevel; } }
        private Model model;
        private Levels levels;
        private Level level;
        private TileMap tileMap;
        private PhysicalMap physicalMap;
        private TileSet tileSet;
        private Bitmap tilemapImage, priority1;
        private Overlay overlay;
        private State state;
        // editors
        private LevelsTileset levelsTileset;
        private LevelsPhysicalTiles levelsPhysicalTiles;
        private LevelsTemplate levelsTemplate;
        private PaletteEditor paletteEditor;
        // main classes
        private LevelMap levelMap { get { return levels.LevelMap; } }
        private LevelLayer layer { get { return level.Layer; } }
        private LevelExits exits { get { return level.LevelExits; } set { level.LevelExits = value; } }
        private LevelEvents events { get { return level.LevelEvents; } set { level.LevelEvents = value; } }
        private LevelNPCs npcs { get { return level.LevelNPCs; } set { level.LevelNPCs = value; } }
        private LevelOverlaps overlaps { get { return level.LevelOverlaps; } set { level.LevelOverlaps = value; } }
        private PhysicalTile[] physicalTiles { get { return model.PhysicalTiles; } }
        private LevelTemplate template { get { return levelsTemplate.Template; } }
        // buffers
        private CopyBuffer draggedTiles;
        private CopyBuffer copiedTiles;
        private CommandStack commandStack;
        private Stack<int> pushes;
        private Stack<int> pops;
        private Bitmap selection;
        // hover variables
        private string mouseOverObject;
        private int mouseOverTile = 0;
        private int mouseOverPhysicalTile = 0;
        private int mouseOverNPC = 0;
        private int mouseOverNPCInstance = 0;
        private int mouseOverExitField = 0;
        private int mouseOverEventField = 0;
        private int mouseOverOverlap = 0;
        private string mouseDownObject;
        private int mouseDownNPC = 0;
        private int mouseDownNPCInstance = 0;
        private int mouseDownExitField = 0;
        private int mouseDownEventField = 0;
        private int mouseDownOverlap = 0;
        private Point mousePosition = new Point(0, 0);
        private Point mouseDownPosition = new Point(0, 0);
        private Point mouseIsometricPosition = new Point(0, 0);
        private Point mouseLastIsometricPosition = new Point(0, 0);
        private Point mouseDownIsometricPosition = new Point(0, 0);
        private bool mouseWithinSameBounds = false;
        private bool mouseEnter = false;
        private int zoom = 1;
        private ZoomPanel zoomPanel;
        #endregion
        #region Functions
        // main
        public LevelsTilemap(
            Model model, Levels levels, Level level,
            TileMap tileMap, PhysicalMap physicalMap, TileSet tileSet, Overlay overlay, State state,
            PaletteEditor paletteEditor, LevelsTileset levelsTileset, LevelsPhysicalTiles levelsPhysicalTiles, LevelsTemplate levelsTemplate)
        {
            this.model = model;
            this.levels = levels;
            this.level = level;
            this.tileMap = tileMap;
            this.physicalMap = physicalMap;
            this.tileSet = tileSet;
            this.overlay = overlay;
            this.state = state;
            this.levelsTileset = levelsTileset;
            this.levelsPhysicalTiles = levelsPhysicalTiles;
            this.paletteEditor = paletteEditor;
            this.levelsTemplate = levelsTemplate;
            this.commandStack = new CommandStack();
            this.pushes = new Stack<int>();
            this.pops = new Stack<int>();
            InitializeComponent();
            this.zoomPanel = new ZoomPanel();
            this.zoomPanel.PictureBox = this.pictureBoxZoom;
            SetLevelImage();
            // toggle
            buttonToggleBG.Checked = state.BG;
            buttonToggleCartGrid.Checked = state.CartesianGrid;
            buttonToggleEvents.Checked = state.Events;
            buttonToggleExits.Checked = state.Exits;
            buttonToggleL1.Checked = state.Layer1;
            buttonToggleL2.Checked = state.Layer2;
            buttonToggleL3.Checked = state.Layer3;
            buttonToggleMask.Checked = state.Mask;
            buttonToggleNPCs.Checked = state.NPCs;
            buttonToggleOrthGrid.Checked = state.IsometricGrid;
            buttonToggleOverlaps.Checked = state.Overlaps;
            buttonToggleP1.Checked = state.Priority1;
            buttonTogglePhys.Checked = state.PhysicalLayer;
        }
        public void Reload(
            Model model, Levels levels, Level level,
            TileMap tileMap, PhysicalMap physicalMap, TileSet tileSet, Overlay overlay, State state,
            PaletteEditor paletteEditor, LevelsTileset levelsTileset, LevelsPhysicalTiles levelsPhysicalTiles, LevelsTemplate levelsTemplate)
        {
            this.model = model;
            this.levels = levels;
            this.level = level;
            this.tileMap = tileMap;
            this.physicalMap = physicalMap;
            this.tileSet = tileSet;
            this.overlay = overlay;
            this.state = state;
            this.levelsTileset = levelsTileset;
            this.levelsPhysicalTiles = levelsPhysicalTiles;
            this.paletteEditor = paletteEditor;
            this.levelsTemplate = levelsTemplate;
            this.commandStack = new CommandStack();
            this.pushes = new Stack<int>();
            this.pops = new Stack<int>();

            priority1 = null;

            SetLevelImage();
        }
        private void SetLevelImage()
        {
            int[] levelPixels = tileMap.Mainscreen;
            tilemapImage = new Bitmap(Do.PixelsToImage(levelPixels, 1024, 1024));

            pictureBoxLevel.Invalidate();
        }
        private void UpdateCoordLabels()
        {
            int x = mousePosition.X;
            int y = mousePosition.Y;

            this.labelTileCoords.Text = "(x: " + (x / 16) + ", y: " + (y / 16) + ") Tile  |  ";
            this.labelTileCoords.Text += "(x: " +
                System.Convert.ToString(mouseIsometricPosition.X) + ", y: " +
                System.Convert.ToString(mouseIsometricPosition.Y) + ") Isometric  |  ";
            this.labelTileCoords.Text += "(x: " + x + ", y: " + y + ") Pixel";
        }
        // editing
        private bool CompareTiles(int x_, int y_, int layer)
        {
            for (int y = overlay.SelectTS.Y, b = y_; y < overlay.SelectTS.Terminal.Y; y += 16, b += 16)
            {
                for (int x = overlay.SelectTS.X, a = x_; x < overlay.SelectTS.Terminal.X; x += 16, a += 16)
                {
                    if (tileMap.GetTileNum(layer, a, b) != tileSet.GetTileNum(layer, x / 16, y / 16))
                        return false;
                }
            }
            return true;
        }
        private void DrawBoundaries(Graphics g)
        {
            Rectangle r = new Rectangle(
                mousePosition.X / 16 * 16 * zoom, mousePosition.Y / 16 * 16 * zoom, 256 * zoom, 224 * zoom);
            Pen insideBorder = new Pen(Color.LightGray, 16);
            Pen edgeBorder = new Pen(Color.Black, 2);
            g.DrawRectangle(insideBorder, r.X - 8, r.Y - 8, r.Width + 16, r.Height + 16);
            g.DrawRectangle(edgeBorder, r.X - 16, r.Y - 16, r.Width + 32, r.Height + 32);
            g.DrawRectangle(edgeBorder, r);
        }
        private void DrawHoverBox(Graphics g)
        {
            int mouseOverPhysicalTileNum = Bits.GetShort(physicalMap.ThePhysicalMap, mouseOverPhysicalTile * 2);

            if (state.PhysicalLayer && mouseOverPhysicalTileNum != 0)
            {
                int[] pixels = model.PhysicalTiles[mouseOverPhysicalTileNum].DrawPhysicalTile(levelsPhysicalTiles.Solids);
                for (int y = 768 - model.PhysicalTiles[mouseOverPhysicalTileNum].TotalHeight; y < 784; y++)
                {
                    for (int x = 0; x < 32; x++)
                    {
                        int temp = pixels[y * 32 + x];
                        if (mouseOverPhysicalTileNum == 0 && temp != 0)
                            temp = Color.FromArgb(96, 0, 0, 0).ToArgb();
                        else
                            temp = temp / 2 | (0xFF << 32);

                        pixels[y * 32 + x] = temp;
                    }
                }
                Bitmap image = new Bitmap(Do.PixelsToImage(pixels, 32, 784));

                Point p = new Point(
                    physicalMap.TileCoords[mouseOverPhysicalTile].X * zoom,
                    physicalMap.TileCoords[mouseOverPhysicalTile].Y * zoom - 768);

                Rectangle rsrc = new Rectangle(0, 0, 32, 784);
                Rectangle rdst = new Rectangle(p.X, p.Y, zoom * 32, zoom * 784);
                g.DrawImage(image, rdst, rsrc, GraphicsUnit.Pixel);
            }
            else if (state.PhysicalLayer || state.NPCs || state.Exits || state.Events || state.Overlaps)
            {
                Point p = new Point(
                    physicalMap.TileCoords[mouseOverPhysicalTile].X * zoom,
                    physicalMap.TileCoords[mouseOverPhysicalTile].Y * zoom);
                Point[] points = new Point[] { 
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
                Rectangle r = new Rectangle(mousePosition.X / 16 * 16 * zoom, mousePosition.Y / 16 * 16 * zoom, 16 * zoom, 16 * zoom);
                g.FillRectangle(new SolidBrush(Color.FromArgb(96, 0, 0, 0)), r);
            }
        }
        private void DrawTemplate(Graphics g, int x, int y)
        {
            if (template == null)
            {
                MessageBox.Show("Must select a template to paint to the level.", "LAZY SHELL");
                return;
            }
            Point tL = new Point(x / 16 * 16, y / 16 * 16);
            Point bR = new Point((x / 16 * 16) + template.Size.Width, (y / 16 * 16) + template.Size.Height);
            if (template.Even != (((tL.X / 16) % 2) == 0))
            {
                tL.X += 16;
                bR.X += 16;
            }
            int[][] tiles = new int[3][];
            tiles[0] = new int[template.Tilemaps[0].Length / 2];
            tiles[1] = new int[template.Tilemaps[1].Length / 2];
            tiles[2] = new int[template.Tilemaps[2].Length];
            for (int i = 0; i < tiles[0].Length; i++)
            {
                tiles[0][i] = Bits.GetShort(template.Tilemaps[0], i * 2);
                tiles[1][i] = Bits.GetShort(template.Tilemaps[1], i * 2);
                tiles[2][i] = template.Tilemaps[2][i];
            }
            commandStack.Push(new TileMapEditCommand(this.levels, tileMap, 0, tL, bR, tiles, true, true));
            commandStack.Push(new PhysicalMapEditCommand(this.levels, this.physicalMap, tL, bR, template.Start, template.Physical));
            physicalMap.DrawPhysicalMap();
            tileMap.RedrawTileMap();
            SetLevelImage();
        }
        private void Draw(Graphics g, int x, int y)
        {
            int layer = levelsTileset.Layer;
            if (!state.PhysicalLayer)
            {
                // cancel if no selection in the tileset is made
                if (overlay.SelectTS == null) return;
                // cancel if writing same tile over itself
                if (CompareTiles(x, y, layer)) return;
                // cancel if layer doesn't exist
                if (tileSet.TileSetLayers[layer] == null) return;
                priority1 = null;
                Point location = new Point(x, y);
                Point terminal = new Point(
                    x + overlay.SelectTS.Width,
                    y + overlay.SelectTS.Height);
                commandStack.Push(
                    new TileMapEditCommand(levels, tileMap, layer, location, terminal, levelsTileset.SelectedTiles.Copies, false, editAllLayers.Checked));
                // draw the tile
                Point p = new Point(x / 16 * 16, y / 16 * 16);
                Bitmap image = Do.PixelsToImage(
                    tileMap.GetRangePixels(p, overlay.SelectTS.Size),
                    overlay.SelectTS.Width, overlay.SelectTS.Height);
                p.X *= zoom;
                p.Y *= zoom;
                Rectangle rsrc = new Rectangle(0, 0, image.Width, image.Height);
                Rectangle rdst = new Rectangle(p.X, p.Y, (int)(image.Width * zoom), (int)(image.Height * zoom));
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImage(image, rdst, rsrc, GraphicsUnit.Pixel);
            }
            else if (state.PhysicalLayer)
            {
                // cancel if physical tile editor not open
                if (levelsPhysicalTiles == null) return;
                // cancel if overwriting the same tile over itself
                if (physicalMap.GetTileNum(mouseOverPhysicalTile) == (ushort)levelsPhysicalTiles.Index)
                    return;
                Point initial = new Point(x, y);
                Point final = new Point(x + 1, y + 1);
                byte[] temp = new byte[0x20C2];
                Bits.SetShort(temp, mouseOverPhysicalTile * 2, (ushort)levelsPhysicalTiles.Index);
                commandStack.Push(new PhysicalMapEditCommand(this.levels, this.physicalMap, initial, final, initial, temp));
                physicalMap.RedrawPhysicalTile(mouseOverPhysicalTile * 2);
                pictureBoxLevel.Invalidate();
            }
        }
        private void Erase(Graphics g, int x, int y)
        {
            int layer = levelsTileset.Layer;
            if (!state.PhysicalLayer)
            {
                // cancel if overwriting the same tile over itself
                if (tileMap.GetTileNum(layer, x, y) == 0) return;
                // cancel if layer doesn't exist
                if (tileSet.TileSetLayers[layer] == null) return;
                priority1 = null;
                commandStack.Push(
                    new TileMapEditCommand(
                        this.levels, this.tileMap, layer, new Point(x, y), new Point(x + 16, y + 16),
                        new int[][] { new int[] { 0 }, new int[] { 0 }, new int[] { 0 }, new int[] { 0 } },
                        false, editAllLayers.Checked));
                Point p = new Point(x / 16 * 16, y / 16 * 16);
                Bitmap image = Do.PixelsToImage(tileMap.GetRangePixels(p, new Size(16, 16)), 16, 16);
                p.X *= zoom; p.Y *= zoom;
                Rectangle rsrc = new Rectangle(0, 0, image.Width, image.Height);
                Rectangle rdst = new Rectangle(p.X, p.Y, (int)(image.Width * zoom), (int)(image.Height * zoom));
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImage(image, rdst, rsrc, GraphicsUnit.Pixel);
            }
            else if (state.PhysicalLayer)
            {
                // cancel if overwriting the same tile over itself
                if (physicalMap.GetTileNum(mouseOverPhysicalTile) == 0)
                    return;
                Point tL = new Point(x, y);
                Point bR = new Point(x + 1, y + 1);
                commandStack.Push(new PhysicalMapEditCommand(this.levels, this.physicalMap, tL, bR, tL, new byte[0x20C2]));
                physicalMap.RedrawPhysicalTile(mouseOverPhysicalTile * 2);
                pictureBoxLevel.Invalidate();
            }
        }
        private void SelectColor(int x, int y)
        {
            int layer = 0;
            if (levelMap.TopPriorityL3)
            {
                if (tileMap.layer3Priority1[y * 1024 + x] != 0) layer = 2;
                else if (tileMap.layer1Priority1[y * 1024 + x] != 0) layer = 0;
                else if (tileMap.layer2Priority1[y * 1024 + x] != 0) layer = 1;
                else if (tileMap.layer1Priority0[y * 1024 + x] != 0) layer = 0;
                else if (tileMap.layer2Priority0[y * 1024 + x] != 0) layer = 1;
                else if (tileMap.layer3Priority0[y * 1024 + x] != 0) layer = 2;
            }
            else
            {
                if (tileMap.layer1Priority1[y * 1024 + x] != 0) layer = 0;
                else if (tileMap.layer2Priority1[y * 1024 + x] != 0) layer = 1;
                else if (tileMap.layer1Priority0[y * 1024 + x] != 0) layer = 0;
                else if (tileMap.layer2Priority0[y * 1024 + x] != 0) layer = 1;
                else if (tileMap.layer3Priority1[y * 1024 + x] != 0) layer = 2;
                else if (tileMap.layer3Priority0[y * 1024 + x] != 0) layer = 2;
            }
            int tileNum = (y / 16) * 64 + (x / 16);
            int placement = ((x % 16) / 8) + (((y % 16) / 8) * 2);
            Tile16x16 tile = tileSet.TileSetLayers[layer][tileMap.GetTileNum(layer, x, y)];
            Tile8x8 subtile = tile.Subtiles[placement];
            paletteEditor.CurrentColor =
                (subtile.PaletteIndex * 16) + subtile.Colors[((y % 16) % 8) * 8 + ((x % 16) % 8)];
            paletteEditor.Show();
        }
        private void Undo()
        {
            if (!state.PhysicalLayer)
            {
                commandStack.UndoCommand();
                SetLevelImage();
            }
            else if (this.pushes.Count > 0)
            {
                int pushes = this.pushes.Pop();
                int pops = 0;
                for (; pushes > 0; pushes--, pops++)
                    commandStack.UndoCommand();
                this.pops.Push(pops);
                physicalMap.DrawPhysicalMap();
                pictureBoxLevel.Invalidate();
            }
        }
        private void Redo()
        {
            if (!state.PhysicalLayer)
            {
                commandStack.RedoCommand();
                SetLevelImage();
            }
            else if (this.pops.Count > 0)
            {
                int pops = this.pops.Pop();
                int pushes = 0;
                for (; pops > 0; pops--, pushes++)
                    commandStack.RedoCommand();
                this.pushes.Push(pushes);
                physicalMap.DrawPhysicalMap();
                pictureBoxLevel.Invalidate();
            }
        }
        private void Cut()
        {
            if (overlay.Select == null || overlay.Select.Size == new Size(0, 0)) return;
            if (state.PhysicalLayer) return;
            Copy();
            Delete();
        }
        private void Copy()
        {
            if (overlay.Select == null || overlay.Select.Size == new Size(0, 0)) return;
            if (state.PhysicalLayer) return;
            if (draggedTiles != null)
            {
                this.copiedTiles = draggedTiles;
                return;
            }
            int layer = levelsTileset.Layer;
            if (editAllLayers.Checked)
                selection = new Bitmap(
                    Do.PixelsToImage(
                    tileMap.GetRangePixels(overlay.Select.Location, overlay.Select.Size),
                    overlay.Select.Width, overlay.Select.Height));
            else
                selection = new Bitmap(
                    Do.PixelsToImage(
                    tileMap.GetRangePixels(layer, overlay.Select.Location, overlay.Select.Size),
                    overlay.Select.Width, overlay.Select.Height));

            int[][] copiedTiles = new int[3][];
            this.copiedTiles = new CopyBuffer(overlay.Select.Width, overlay.Select.Height);
            for (int l = 0; l < 3; l++)
            {
                copiedTiles[l] = new int[(overlay.Select.Width / 16) * (overlay.Select.Height / 16)];
                for (int y = 0; y < overlay.Select.Height / 16; y++)
                {
                    for (int x = 0; x < overlay.Select.Width / 16; x++)
                    {
                        int tileX = overlay.Select.X + (x * 16);
                        int tileY = overlay.Select.Y + (y * 16);
                        copiedTiles[l][y * (overlay.Select.Width / 16) + x] = tileMap.GetTileNum(l, tileX, tileY);
                    }
                }
            }
            this.copiedTiles.Copies = copiedTiles;
        }
        /// <summary>
        /// Start dragging a current selection.
        /// </summary>
        private void Drag()
        {
            if (overlay.Select == null || overlay.Select.Size == new Size(0, 0)) return;
            if (!state.PhysicalLayer)
            {
                int layer = levelsTileset.Layer;
                if (editAllLayers.Checked)
                    selection = new Bitmap(
                        Do.PixelsToImage(
                        tileMap.GetRangePixels(overlay.Select.Location, overlay.Select.Size),
                        overlay.Select.Width, overlay.Select.Height));
                else
                    selection = new Bitmap(
                        Do.PixelsToImage(
                        tileMap.GetRangePixels(layer, overlay.Select.Location, overlay.Select.Size),
                        overlay.Select.Width, overlay.Select.Height));

                int[][] copiedTiles = new int[3][];
                this.draggedTiles = new CopyBuffer(overlay.Select.Width, overlay.Select.Height);
                for (int l = 0; l < 3; l++)
                {
                    copiedTiles[l] = new int[(overlay.Select.Width / 16) * (overlay.Select.Height / 16)];
                    for (int y = 0; y < overlay.Select.Height / 16; y++)
                    {
                        for (int x = 0; x < overlay.Select.Width / 16; x++)
                        {
                            int tileX = overlay.Select.X + (x * 16);
                            int tileY = overlay.Select.Y + (y * 16);
                            copiedTiles[l][y * (overlay.Select.Width / 16) + x] = tileMap.GetTileNum(l, tileX, tileY);
                        }
                    }
                }
                this.draggedTiles.Copies = copiedTiles;
            }
            else
            {
                selection = new Bitmap(
                    Do.PixelsToImage(
                    physicalMap.GetRangePixels(overlay.Select.Location, overlay.Select.Size),
                    overlay.Select.Width, overlay.Select.Height));
            }
            Delete();
        }
        private void Paste(Point location, CopyBuffer buffer)
        {
            if (state.PhysicalLayer) return;
            if (buffer == null) return;
            state.Move = true;
            // now dragging a new selection
            draggedTiles = buffer;
            overlay.Select = new Overlay.Selection(16, location, buffer.Size);
            pictureBoxLevel.Invalidate();
        }
        /// <summary>
        /// "Cements" either a dragged selection or a newly pasted selection.
        /// </summary>
        /// <param name="buffer">The dragged selection or the newly pasted selection.</param>
        private void PasteFinal(CopyBuffer buffer)
        {
            if (state.PhysicalLayer) return;
            if (buffer == null) return;
            Point location = new Point();
            location.X = overlay.Select.X / 16 * 16;
            location.Y = overlay.Select.Y / 16 * 16;
            int layer = levelsTileset.Layer;
            Point terminal = new Point(location.X + buffer.Width, location.Y + buffer.Height);
            commandStack.Push(
                new TileMapEditCommand(levels, tileMap, layer, location, terminal, buffer.Copies, true, editAllLayers.Checked));
            priority1 = null;
            SetLevelImage();
        }
        private void Delete()
        {
            int layer = levelsTileset.Layer;
            if (!state.PhysicalLayer)
            {
                if (tileSet.TileSetLayers[layer] == null || overlay.Select.Size == new Size(0, 0)) return;
                if (overlay.Select == null) return;
                Point location = overlay.Select.Location;
                Point terminal = overlay.Select.Terminal;
                int[][] changes = new int[][]{
                    new int[overlay.Select.Width * overlay.Select.Height],
                    new int[overlay.Select.Width * overlay.Select.Height],
                    new int[overlay.Select.Width * overlay.Select.Height],
                    new int[overlay.Select.Width * overlay.Select.Height]};
                // Verify layer before creating command
                commandStack.Push(
                    new TileMapEditCommand(levels, tileMap, layer, location, terminal, changes, false, editAllLayers.Checked));
                priority1 = null;
                SetLevelImage();
            }
            else
            {
                if (overlay.Select.Size == new Size(0, 0)) return;
                if (overlay.Select == null) return;
                int index = 0;
                int pushes = 0;
                for (int y = overlay.Select.Y; y < overlay.Select.Y + overlay.Select.Height; y++)
                {
                    for (int x = overlay.Select.X; x < overlay.Select.X + overlay.Select.Width; x++)
                    {
                        if (index == physicalMap.PixelTiles[y * 1024 + x])
                            continue;
                        index = physicalMap.PixelTiles[y * 1024 + x];
                        if (physicalMap.GetTileNum(index) == 0)
                            continue;
                        Point tL = new Point(
                            physicalMap.TileCoords[index].X + 16,
                            physicalMap.TileCoords[index].Y + 8);
                        Point bR = new Point(
                            physicalMap.TileCoords[index].X + 17,
                            physicalMap.TileCoords[index].Y + 9);
                        commandStack.Push(new PhysicalMapEditCommand(levels, physicalMap, tL, bR, tL, new byte[0x20C2]));
                        pushes++;
                    }
                }
                this.pushes.Push(pushes);
                physicalMap.DrawPhysicalMap();//physicalMap.RedrawPhysicalTile(mouseDownSolidTile * 2);
                pictureBoxLevel.Invalidate();
            }
        }
        #endregion
        #region Event Handlers
        // main
        private void LevelsTilemap_KeyDown(object sender, KeyEventArgs e)
        {
        }
        private void pictureBoxLevel_Paint(object sender, PaintEventArgs e)
        {
            RectangleF clone = e.ClipRectangle;
            SizeF remainder = new SizeF((int)(clone.Width % zoom), (int)(clone.Height % zoom));
            clone.Location = new PointF((int)(clone.X / zoom), (int)(clone.Y / zoom));
            clone.Size = new SizeF((int)(clone.Width / zoom), (int)(clone.Height / zoom));
            clone.Width += (int)(remainder.Width * zoom) + 1;
            clone.Height += (int)(remainder.Height * zoom) + 1;
            RectangleF source, dest;
            float[][] matrixItems ={ 
               new float[] {1, 0, 0, 0, 0},
               new float[] {0, 1, 0, 0, 0},
               new float[] {0, 0, 1, 0, 0},
               new float[] {0, 0, 0, (float)overlayOpacity.Value / 100, 0}, 
               new float[] {0, 0, 0, 0, 1}};
            ColorMatrix cm = new ColorMatrix(matrixItems);
            ImageAttributes ia = new ImageAttributes();
            if (overlayOpacity.Value < 100)
                ia.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            Rectangle rdst = new Rectangle(0, 0, zoom * 1024, zoom * 1024);
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            if (tilemapImage != null)
            {
                clone.Width = Math.Min(tilemapImage.Width, clone.X + clone.Width) - clone.X;
                clone.Height = Math.Min(tilemapImage.Height, clone.Y + clone.Height) - clone.Y;

                source = clone; source.Location = new PointF(0, 0);
                dest = new RectangleF((int)(clone.X * zoom), (int)(clone.Y * zoom), (int)(clone.Width * zoom), (int)(clone.Height * zoom));

                e.Graphics.DrawImage(tilemapImage.Clone(clone, PixelFormat.DontCare), dest, source, GraphicsUnit.Pixel);
            }
            if (state.Move && selection != null)
            {
                Rectangle rsrc = new Rectangle(0, 0, overlay.Select.Width, overlay.Select.Height);
                rdst = new Rectangle(
                    overlay.Select.X * zoom, overlay.Select.Y * zoom,
                    rsrc.Width * zoom, rsrc.Height * zoom);
                e.Graphics.DrawImage(new Bitmap(selection), rdst, rsrc, GraphicsUnit.Pixel);
            }
            if (state.Priority1)
            {
                cm.Matrix33 = 0.50F;
                ia.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                if (priority1 == null)
                    priority1 = new Bitmap(Do.PixelsToImage(tileMap.GetPriority1Pixels(), 1024, 1024));
                e.Graphics.DrawImage(priority1, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel, ia);
            }
            if (state.PhysicalLayer)
            {
                if (physicalMap.PhysicalMapImage == null)
                    physicalMap.DrawPhysicalMap();
                if (overlayOpacity.Value < 100)
                    e.Graphics.DrawImage(physicalMap.PhysicalMapImage, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel, ia);
                else
                    e.Graphics.DrawImage(physicalMap.PhysicalMapImage, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel);
            }
            if (state.Exits)
            {
                if (overlay.ExitsImage == null)
                    overlay.DrawLevelExits(exits);
                if (overlayOpacity.Value < 100)
                    e.Graphics.DrawImage(overlay.ExitsImage, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel, ia);
                else
                    e.Graphics.DrawImage(overlay.ExitsImage, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel);
            }
            if (state.Events)
            {
                if (overlay.EventsImage == null)
                    overlay.DrawLevelEvents(events);
                if (overlayOpacity.Value < 100)
                    e.Graphics.DrawImage(overlay.EventsImage, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel, ia);
                else
                    e.Graphics.DrawImage(overlay.EventsImage, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel);
            }
            if (state.NPCs)
            {
                if (overlay.NPCsImage == null)
                    overlay.DrawLevelNPCs(npcs, model.NPCProperties);
                if (overlayOpacity.Value < 100)
                    e.Graphics.DrawImage(overlay.NPCsImage, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel, ia);
                else
                    e.Graphics.DrawImage(overlay.NPCsImage, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel);
            }
            if (state.Overlaps)
            {
                if (overlay.OverlapsImage == null)
                    overlay.DrawLevelOverlaps(overlaps, model.OverlapTileset);
                if (overlayOpacity.Value < 100)
                    e.Graphics.DrawImage(overlay.OverlapsImage, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel, ia);
                else
                    e.Graphics.DrawImage(overlay.OverlapsImage, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel);
            }
            if (!state.Dropper && mouseEnter)
                DrawHoverBox(e.Graphics);
            if (state.CartesianGrid)
                overlay.DrawCartographicGrid(e.Graphics, Color.Gray, pictureBoxLevel.Size, new Size(16, 16), zoom);
            if (state.IsometricGrid)
                overlay.DrawIsometricGrid(e.Graphics, Color.Gray, pictureBoxLevel.Size, new Size(16, 16), zoom);
            if (state.Mask)
                overlay.DrawLevelMask(e.Graphics, new Point(layer.MaskHighX, layer.MaskHighY), new Point(layer.MaskLowX, layer.MaskLowY), zoom);
            if (state.ShowBoundaries && mouseEnter)
                overlay.DrawBoundaries(e.Graphics, mousePosition, zoom);
            if (state.Select)
            {
                if (overlay.Select != null)
                    overlay.DrawSelectionBox(e.Graphics, overlay.Select.Terminal, overlay.Select.Location, zoom);
            }
        }
        private void pictureBoxLevel_MouseDown(object sender, MouseEventArgs e)
        {
            // in case the tileset selection was dragged
            if (levelsTileset.DraggedTiles != null)
                levelsTileset.PasteFinal(levelsTileset.DraggedTiles);
            // set a floor and ceiling for the coordinates
            int x = Math.Max(0, Math.Min(e.X / zoom, 1024));
            int y = Math.Max(0, Math.Min(e.Y / zoom, 1024));
            mouseDownObject = null;
            #region Zooming
            Point p = new Point();
            p.X = Math.Abs(panelLevelPicture.AutoScrollPosition.X);
            p.Y = Math.Abs(panelLevelPicture.AutoScrollPosition.Y);
            if ((buttonZoomIn.Checked && e.Button == MouseButtons.Left) || (buttonZoomOut.Checked && e.Button == MouseButtons.Right))
            {
                if (zoom < 8)
                {
                    zoom *= 2;
                    p = new Point(Math.Abs(pictureBoxLevel.Left), Math.Abs(pictureBoxLevel.Top));
                    p.X += e.X;
                    p.Y += e.Y;
                    pictureBoxLevel.Width = 1024 * zoom;
                    pictureBoxLevel.Height = 1024 * zoom;
                    panelLevelPicture.Focus();
                    panelLevelPicture.AutoScrollPosition = p;
                    panelLevelPicture.VerticalScroll.SmallChange *= 2;
                    panelLevelPicture.HorizontalScroll.SmallChange *= 2;
                    panelLevelPicture.VerticalScroll.LargeChange *= 2;
                    panelLevelPicture.HorizontalScroll.LargeChange *= 2;
                    pictureBoxLevel.Invalidate();
                    return;
                }
                return;
            }
            else if ((buttonZoomOut.Checked && e.Button == MouseButtons.Left) || (buttonZoomIn.Checked && e.Button == MouseButtons.Right))
            {
                if (zoom > 1)
                {
                    zoom /= 2;

                    p = new Point(Math.Abs(pictureBoxLevel.Left), Math.Abs(pictureBoxLevel.Top));
                    p.X -= e.X / 2;
                    p.Y -= e.Y / 2;

                    pictureBoxLevel.Width = 1024 * zoom;
                    pictureBoxLevel.Height = 1024 * zoom;
                    panelLevelPicture.Focus();
                    panelLevelPicture.AutoScrollPosition = p;
                    panelLevelPicture.VerticalScroll.SmallChange /= 2;
                    panelLevelPicture.HorizontalScroll.SmallChange /= 2;
                    panelLevelPicture.VerticalScroll.LargeChange /= 2;
                    panelLevelPicture.HorizontalScroll.LargeChange /= 2;
                    pictureBoxLevel.Invalidate();
                    return;
                }
                return;
            }
            #endregion
            if (e.Button == MouseButtons.Right) return;
            #region Drawing, Erasing, Selecting
            // if moving an object and outside of it, paste it
            if (state.Move && mouseOverObject != "selection")
            {
                // if copied tiles were pasted and not dragging a non-copied selection
                if (copiedTiles != null && draggedTiles == null)
                    PasteFinal(copiedTiles);
                if (draggedTiles != null)
                {
                    PasteFinal(draggedTiles);
                    draggedTiles = null;
                }
                state.Move = false;
            }
            if (state.Select)
            {
                //panelLevelPicture.Focus();
                // if we're not inside a current selection to move it, create a new selection
                if (mouseOverObject != "selection")
                    overlay.Select = new Overlay.Selection(16, x / 16 * 16, y / 16 * 16, 16, 16);
                // otherwise, start dragging current selection
                else if (mouseOverObject == "selection")
                {
                    mouseDownObject = "selection";
                    mouseDownPosition = overlay.Select.MousePosition(x, y);
                    if (!state.Move)    // only do this if the current selection has not been initially moved
                    {
                        state.Move = true;
                        Drag();
                    }
                }
            }
            if (e.Button == MouseButtons.Left)
            {
                if (state.Dropper)
                {
                    SelectColor(x, y);
                    return;
                }
                if (state.Template)
                {
                    DrawTemplate(pictureBoxLevel.CreateGraphics(), x, y);
                    panelLevelPicture.AutoScrollPosition = p;
                    return;
                }
                if (state.Draw)
                {
                    Draw(pictureBoxLevel.CreateGraphics(), x, y);
                    panelLevelPicture.AutoScrollPosition = p;
                    return;
                }
                if (state.Erase)
                {
                    Erase(pictureBoxLevel.CreateGraphics(), x, y);
                    panelLevelPicture.AutoScrollPosition = p;
                    return;
                }
            }
            #endregion
            #region Object Selection
            if (!state.Template && !state.Draw && !state.Select && !state.Erase && e.Button == MouseButtons.Left)
            {
                if (state.Exits && mouseOverObject == "exit")
                {
                    levels.TabControl.SelectedIndex = 3;
                    mouseDownObject = "exit";
                    mouseDownExitField = mouseOverExitField;
                    exits.CurrentExit = mouseDownExitField;
                    exits.SelectedExit = mouseDownExitField;
                    levels.ExitsFieldTree.SelectedNode = levels.ExitsFieldTree.Nodes[exits.CurrentExit];
                }
                if (state.Events && mouseOverObject == "event" && mouseDownObject == null)
                {
                    levels.TabControl.SelectedIndex = 4;
                    mouseDownObject = "event";
                    mouseDownEventField = mouseOverEventField;
                    events.CurrentEvent = mouseDownEventField;
                    events.SelectedEvent = mouseDownEventField;
                    levels.EventsFieldTree.SelectedNode = levels.EventsFieldTree.Nodes[events.CurrentEvent];
                }
                if (state.NPCs && mouseOverObject == "npc" && mouseDownObject == null)
                {
                    levels.TabControl.SelectedIndex = 2;
                    mouseDownObject = "npc";
                    mouseDownNPC = mouseOverNPC;
                    npcs.CurrentNPC = mouseDownNPC;
                    npcs.SelectedNPC = mouseDownNPC;
                    npcs.IsInstanceSelected = false;
                    levels.NpcObjectTree.SelectedNode = levels.NpcObjectTree.Nodes[npcs.CurrentNPC];
                }
                if (state.NPCs && mouseOverObject == "npc instance" && mouseDownObject == null)
                {
                    levels.TabControl.SelectedIndex = 2;
                    mouseDownObject = "npc instance";
                    mouseDownNPC = mouseOverNPC;
                    mouseDownNPCInstance = mouseOverNPCInstance;
                    npcs.CurrentNPC = mouseDownNPC;
                    npcs.SelectedNPC = mouseDownNPC;
                    npcs.CurrentInstance = mouseDownNPCInstance;
                    npcs.SelectedInstance = mouseDownNPCInstance;
                    npcs.IsInstanceSelected = true;
                    levels.NpcObjectTree.SelectedNode = levels.NpcObjectTree.Nodes[npcs.CurrentNPC].Nodes[npcs.CurrentInstance];
                }
                if (state.Overlaps && mouseOverObject == "overlap" && mouseDownObject == null)
                {
                    levels.TabControl.SelectedIndex = 5;
                    mouseDownObject = "overlap";
                    mouseDownOverlap = mouseOverOverlap;
                    overlaps.CurrentOverlap = mouseDownOverlap;
                    overlaps.SelectedOverlap = mouseDownOverlap;
                    overlay.OverlapsImage = null;
                    levels.OverlapFieldTree.SelectedNode = levels.OverlapFieldTree.Nodes[overlaps.CurrentOverlap];
                }
            }
            #endregion
            panelLevelPicture.AutoScrollPosition = p;
            pictureBoxLevel.Invalidate();
        }
        private void pictureBoxLevel_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            mouseDownExitField = 0;
            mouseDownEventField = 0;
            mouseDownNPC = 0;
            mouseDownNPCInstance = 0;
            mouseDownOverlap = 0;
            mouseDownObject = null;
            if (state.Draw || state.Erase)
            {
                if (!state.PhysicalLayer)
                    SetLevelImage();
                else
                    pictureBoxLevel.Invalidate();
            }
            Point p = new Point(Math.Abs(pictureBoxLevel.Left), Math.Abs(pictureBoxLevel.Top));
            pictureBoxLevel.Focus();
            panelLevelPicture.AutoScrollPosition = p;
        }
        private void pictureBoxLevel_MouseMove(object sender, MouseEventArgs e)
        {
            // set a floor and ceiling for the coordinates
            int x = Math.Max(0, Math.Min(e.X / zoom, 1024));
            int y = Math.Max(0, Math.Min(e.Y / zoom, 1024));
            // must first check if within same bounds as last call of MouseMove event
            if (state.PhysicalLayer)
                mouseWithinSameBounds = mouseOverPhysicalTile ==
                    physicalMap.PixelTiles[Math.Min(y * 1024 + x, 1023 * 1023)];
            else
                mouseWithinSameBounds = mouseOverTile == (y / 16 * 64) + (x / 16);
            // now set the properties
            mousePosition = new Point(x, y);
            mouseLastIsometricPosition = new Point(mouseIsometricPosition.X, mouseIsometricPosition.Y);
            mouseIsometricPosition.X = physicalMap.PixelCoords[Math.Min(y * 1024 + x, 1023 * 1023)].X;
            mouseIsometricPosition.Y = physicalMap.PixelCoords[Math.Min(y * 1024 + x, 1023 * 1023)].Y;
            mouseOverTile = (y / 16 * 64) + (x / 16);
            mouseOverPhysicalTile = physicalMap.PixelTiles[Math.Min(y * 1024 + x, 1023 * 1023)];
            mouseOverObject = null;
            UpdateCoordLabels();
            #region Zooming
            // if either zoom button is checked, don't do anything else
            if (buttonZoomIn.Checked || buttonZoomOut.Checked)
            {
                pictureBoxLevel.Invalidate();
                return;
            }
            #endregion
            #region Dropper
            // show zoom box for selecting colors
            if (state.Dropper)
            {
                zoomPanel.Location = new Point(MousePosition.X + 64, MousePosition.Y);
                zoomPanel.Visible = true;
                pictureBoxZoom.Invalidate();
                pictureBoxLevel.Invalidate();
                return;
            }
            #endregion
            #region Drawing, erasing, selecting
            if (state.Select)
            {
                // if making a new selection
                if (e.Button == MouseButtons.Left && mouseDownObject == null && overlay.Select != null)
                {
                    // cancel if within same bounds as last call
                    if (overlay.Select.Final == new Point(x + 16, y + 16))
                        return;
                    // otherwise, set the lower right edge of the selection
                    overlay.Select.Final = new Point(
                        Math.Min(x + 16, pictureBoxLevel.Width),
                        Math.Min(y + 16, pictureBoxLevel.Height));
                }
                // if dragging the current selection
                else if (e.Button == MouseButtons.Left && mouseDownObject == "selection")
                    overlay.Select.Location = new Point(
                        x / 16 * 16 - mouseDownPosition.X,
                        y / 16 * 16 - mouseDownPosition.Y);
                // if mouse not clicked and within the current selection
                else if (e.Button == MouseButtons.None && overlay.Select != null && overlay.Select.MouseWithin(x, y))
                {
                    mouseOverObject = "selection";
                    pictureBoxLevel.Cursor = Cursors.SizeAll;
                }
                else
                    pictureBoxLevel.Cursor = Cursors.Cross;
                pictureBoxLevel.Invalidate();
                return;
            }
            if (!state.PhysicalLayer)
            {
                if (state.Draw && e.Button == MouseButtons.Left)
                {
                    Draw(pictureBoxLevel.CreateGraphics(), x, y);
                    return;
                }
                else if (state.Erase && e.Button == MouseButtons.Left)
                {
                    Erase(pictureBoxLevel.CreateGraphics(), x, y);
                    return;
                }
            }
            else if (state.PhysicalLayer)
            {
                if (!mouseWithinSameBounds)
                {
                    if (state.Draw && e.Button == MouseButtons.Left)
                        Draw(pictureBoxLevel.CreateGraphics(), x, y);
                    if (state.Erase && e.Button == MouseButtons.Left)
                        Erase(pictureBoxLevel.CreateGraphics(), x, y);
                }
            }
            #endregion
            #region Objects
            if (!state.Template && !state.Draw && !state.Select && !state.Erase && !state.Dropper)
            {
                #region Check if dragging a field
                if (mouseDownObject != null && e.Button == MouseButtons.Left)  // if dragging a field
                {
                    if (Math.Abs(mouseIsometricPosition.X - mouseLastIsometricPosition.X) > 0 ||
                        Math.Abs(mouseIsometricPosition.Y - mouseLastIsometricPosition.Y) > 0)
                        return;
                    if (mouseDownObject == "exit")
                    {
                        if (levels.ExitX.Value != mouseIsometricPosition.X &&
                            levels.ExitY.Value != mouseIsometricPosition.Y)
                            levels.UpdatingProperties = true;
                        levels.ExitX.Value = mouseIsometricPosition.X;
                        levels.UpdatingProperties = false;
                        levels.ExitY.Value = mouseIsometricPosition.Y;
                    }
                    if (mouseDownObject == "event")
                    {
                        if (levels.EventX.Value != mouseIsometricPosition.X &&
                            levels.EventY.Value != mouseIsometricPosition.Y)
                            levels.UpdatingProperties = true;
                        levels.EventX.Value = mouseIsometricPosition.X;
                        levels.UpdatingProperties = false;
                        levels.EventY.Value = mouseIsometricPosition.Y;
                    }
                    if (mouseDownObject == "npc" || mouseDownObject == "npc instance")
                    {
                        if (levels.NpcXCoord.Value != mouseIsometricPosition.X &&
                            levels.NpcYCoord.Value != mouseIsometricPosition.Y)
                            levels.UpdatingProperties = true;
                        levels.NpcXCoord.Value = mouseIsometricPosition.X;
                        levels.UpdatingProperties = false;
                        levels.NpcYCoord.Value = mouseIsometricPosition.Y;
                    }
                    if (mouseDownObject == "overlap")
                    {
                        if (levels.OverlapX.Value != mouseIsometricPosition.X &&
                            levels.OverlapY.Value != mouseIsometricPosition.Y)
                            levels.UpdatingProperties = true;
                        levels.OverlapX.Value = mouseIsometricPosition.X;
                        levels.UpdatingProperties = false;
                        levels.OverlapY.Value = mouseIsometricPosition.Y;
                    }
                    pictureBoxLevel.Invalidate();
                    return;
                }
                #endregion
                #region Check if over an object
                else
                {
                    pictureBoxLevel.Cursor = Cursors.Arrow;
                    if (state.Exits && exits.NumberOfExits != 0)
                    {
                        int currentExit = exits.CurrentExit;
                        for (int i = 0; i < exits.NumberOfExits; i++)
                        {
                            exits.CurrentExit = i;
                            if (exits.X == mouseIsometricPosition.X &&
                                exits.Y == mouseIsometricPosition.Y)
                            {
                                this.pictureBoxLevel.Cursor = Cursors.Hand;
                                mouseOverExitField = i;
                                mouseOverObject = "exit";
                                break;
                            }
                            else
                            {
                                this.pictureBoxLevel.Cursor = Cursors.Arrow;
                                mouseOverExitField = 0;
                                mouseOverObject = null;
                            }
                        }
                        exits.CurrentExit = currentExit;
                    }
                    if (state.Events && events.NumberOfEvents != 0 && mouseOverObject == null)
                    {
                        int currentEvent = events.CurrentEvent;
                        for (int i = 0; i < events.NumberOfEvents; i++)
                        {
                            events.CurrentEvent = i;
                            if (events.X == mouseIsometricPosition.X &&
                                events.Y == mouseIsometricPosition.Y)
                            {
                                this.pictureBoxLevel.Cursor = Cursors.Hand;
                                mouseOverEventField = i;
                                mouseOverObject = "event";
                                break;
                            }
                            else
                            {
                                this.pictureBoxLevel.Cursor = Cursors.Arrow;
                                mouseOverEventField = 0;
                                mouseOverObject = null;
                            }
                        }
                        events.CurrentEvent = currentEvent;
                    }
                    if (state.NPCs && npcs.NumberOfNPCs != 0 && mouseOverObject == null)
                    {
                        int currentNPC = npcs.CurrentNPC;
                        int currentInstance = 0;
                        for (int a = 0; a < npcs.NumberOfNPCs; a++)
                        {
                            npcs.CurrentNPC = a;
                            if (npcs.X == mouseIsometricPosition.X &&
                                npcs.Y == mouseIsometricPosition.Y)
                            {
                                this.pictureBoxLevel.Cursor = System.Windows.Forms.Cursors.Hand;
                                mouseOverNPC = a;
                                mouseOverNPCInstance = 0;
                                mouseOverObject = "npc";
                                break;
                            }
                            else
                            {
                                this.pictureBoxLevel.Cursor = System.Windows.Forms.Cursors.Arrow;
                                mouseOverNPC = 0;
                                mouseOverObject = null;
                            }

                            // for all of the instances
                            if (npcs.NumberOfInstances != 0)
                                currentInstance = npcs.CurrentInstance;
                            for (int b = 0; b < npcs.NumberOfInstances; b++)
                            {
                                npcs.CurrentInstance = b;
                                if (npcs.InstanceCoordX == mouseIsometricPosition.X &&
                                    npcs.InstanceCoordY == mouseIsometricPosition.Y)
                                {
                                    this.pictureBoxLevel.Cursor = System.Windows.Forms.Cursors.Hand;
                                    mouseOverNPC = a;
                                    mouseOverNPCInstance = b;
                                    mouseOverObject = "npc instance";
                                    goto finish;
                                }
                                else
                                {
                                    this.pictureBoxLevel.Cursor = System.Windows.Forms.Cursors.Arrow;
                                    mouseOverNPCInstance = 0;
                                    mouseOverObject = null;
                                }
                            }
                            if (npcs.NumberOfInstances != 0)
                                npcs.CurrentInstance = currentInstance;
                        }
                    finish:
                        npcs.CurrentNPC = currentNPC;
                    }
                    if (state.Overlaps && overlaps.NumberOfOverlaps != 0 && mouseOverObject == null)
                    {
                        int currentOverlap = overlaps.CurrentOverlap;
                        for (int i = 0; i < overlaps.NumberOfOverlaps; i++)
                        {
                            overlaps.CurrentOverlap = i;
                            if (overlaps.X == mouseIsometricPosition.X &&
                                overlaps.Y == mouseIsometricPosition.Y)
                            {
                                this.pictureBoxLevel.Cursor = System.Windows.Forms.Cursors.Hand;
                                mouseOverOverlap = i;
                                mouseOverObject = "overlap";
                                break;
                            }
                            else
                            {
                                this.pictureBoxLevel.Cursor = System.Windows.Forms.Cursors.Arrow;
                                mouseOverOverlap = 0;
                                mouseOverObject = null;
                            }
                        }
                        overlaps.CurrentOverlap = currentOverlap;
                    }
                }
                #endregion
            }
            #endregion
            if (!state.PhysicalLayer && !state.NPCs && !state.Exits && !state.Events && !state.Overlaps && !mouseWithinSameBounds)
                pictureBoxLevel.Invalidate();
            else if (state.PhysicalLayer || state.NPCs || state.Exits || state.Events || state.Overlaps)
                pictureBoxLevel.Invalidate();
        }
        private void pictureBoxLevel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //toolStripMenuItem5_Click(null, null);
        }
        private void pictureBoxLevel_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter = true;
            pictureBoxLevel.Invalidate();
        }
        private void pictureBoxLevel_MouseLeave(object sender, EventArgs e)
        {
            mouseEnter = false;
            zoomPanel.Hide();
            pictureBoxLevel.Invalidate();
        }
        private void pictureBoxLevel_MouseHover(object sender, EventArgs e)
        {
            pictureBoxLevel.Invalidate();
        }
        private void pictureBoxLevel_LostFocus(object sender, EventArgs e)
        {
            //clearSelectionToolStripMenuItem_Click(null, null);
        }
        private void pictureBoxLevel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Control | Keys.V:
                    buttonEditPaste_Click(null, null); break;
                case Keys.Control | Keys.C:
                    buttonEditCopy_Click(null, null); break;
                case Keys.Delete:
                    buttonEditDelete_Click(null, null); break;
                case Keys.Control | Keys.X:
                    buttonEditCut_Click(null, null); break;
                case Keys.Control | Keys.D:
                    if (draggedTiles != null)
                        PasteFinal(draggedTiles);
                    else
                    {
                        overlay.Select = null;
                        pictureBoxLevel.Invalidate();
                    }
                    break;
                case Keys.Control | Keys.A:
                    if (!state.Select) break;
                    if (draggedTiles != null)
                        PasteFinal(draggedTiles);
                    overlay.Select = new Overlay.Selection(16, 0, 0, 1024, 1024);
                    pictureBoxLevel.Invalidate();
                    break;
                case Keys.Control | Keys.Z:
                    buttonEditUndo_Click(null, null); break;
                case Keys.Control | Keys.Y:
                    buttonEditRedo_Click(null, null); break;
            }
        }
        private void panelLevelPicture_Scroll(object sender, ScrollEventArgs e)
        {
            pictureBoxLevel.Invalidate();
            panelLevelPicture.Invalidate();
        }
        private void pictureBoxLevelZoom_Paint(object sender, PaintEventArgs e)
        {
            if (tilemapImage != null)
            {
                int z = 4;
                RectangleF source, dest, clone;
                source = new RectangleF(0, 0, pictureBoxZoom.Width / 4, pictureBoxZoom.Height / 4);
                dest = new RectangleF(0, 0, pictureBoxZoom.Width / 4 * z, pictureBoxZoom.Height / 4 * z);
                clone = new RectangleF(
                    Math.Min(976, Math.Max(0, mousePosition.X - (pictureBoxZoom.Width / 8))),
                    Math.Min(976, Math.Max(0, mousePosition.Y - (pictureBoxZoom.Height / 8))),
                    pictureBoxZoom.Width / 4, pictureBoxZoom.Height / 4);
                e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                e.Graphics.DrawImage(
                    new Bitmap(tilemapImage.Clone(clone, PixelFormat.DontCare)),
                    dest, source, GraphicsUnit.Pixel);
                if (state.CartesianGrid)
                {
                    Pen p = new Pen(new SolidBrush(Color.Gray));
                    Point h = new Point(0, (int)(z * 16 - (z * (clone.Y % 16))));
                    Point v = new Point((int)(z * 16 - (z * (clone.X % 16))), 0);
                    for (; h.Y < 128; h.Y += z * 16)
                        e.Graphics.DrawLine(p, h, new Point(h.X + 128, h.Y));
                    for (; v.X < 128; v.X += z * 16)
                        e.Graphics.DrawLine(p, v, new Point(v.X, v.Y + 128));
                }
                if (state.IsometricGrid)
                {
                    Pen p = new Pen(new SolidBrush(Color.Gray));
                    Point n = new Point();

                    n.Y = (int)(z * 16 - (8 * z) - (z * (clone.Y % 16)));
                    n.Y -= (int)(2 * (clone.X % 32));
                    for (; n.Y < 128 * 2; n.Y += z * 16)
                        e.Graphics.DrawLine(p, n, new Point(n.Y * 2, 0));

                    n.Y = (int)(z * 16 - (8 * z) - (z * (clone.Y % 16)));
                    n.Y += (int)(2 * (clone.X % 32));
                    n.X = 128;
                    for (; n.Y < 128 * 2; n.Y += z * 16)
                        e.Graphics.DrawLine(p, n, new Point(128 - (n.Y * 2), 0));
                }
                Rectangle cursorBounds;
                int size =
                    Cursor.Current == Cursors.Arrow ||
                    Cursor.Current == Cursors.Cross ||
                    Cursor.Current == Cursors.Hand ? 32 : 16;
                cursorBounds = new Rectangle(
                        (24 - Cursor.Current.HotSpot.X) * z,
                        (24 - Cursor.Current.HotSpot.Y) * z,
                        size * z, size * z);
                if (Cursor.Current != null)
                    Cursor.Current.DrawStretched(e.Graphics, cursorBounds);
            }
        }
        //toolstrip buttons
        private void buttonToggleCartGrid_Click(object sender, EventArgs e)
        {
            state.CartesianGrid = buttonToggleCartGrid.Checked;
            state.IsometricGrid = buttonToggleOrthGrid.Checked = false;
            pictureBoxLevel.Invalidate();
        }
        private void buttonToggleOrthGrid_Click(object sender, EventArgs e)
        {
            state.IsometricGrid = buttonToggleOrthGrid.Checked;
            state.CartesianGrid = buttonToggleCartGrid.Checked = false;
            pictureBoxLevel.Invalidate();
        }
        private void buttonToggleBG_Click(object sender, EventArgs e)
        {
            state.BG = buttonToggleBG.Checked;
            tileMap.RedrawTileMap();
            SetLevelImage();
        }
        private void buttonToggleMask_Click(object sender, EventArgs e)
        {
            state.Mask = buttonToggleMask.Checked;
            pictureBoxLevel.Invalidate();
        }
        private void buttonToggleBoundaries_Click(object sender, EventArgs e)
        {
            buttonToggleBoundaries.Checked = !buttonToggleBoundaries.Checked;
            state.ShowBoundaries = buttonToggleBoundaries.Checked;
            pictureBoxLevel.Invalidate();
        }
        private void buttonToggleL1_Click(object sender, EventArgs e)
        {
            state.Layer1 = buttonToggleL1.Checked;
            tileMap.RedrawTileMap();
            SetLevelImage();
        }
        private void buttonToggleL2_Click(object sender, EventArgs e)
        {
            state.Layer2 = buttonToggleL2.Checked;
            tileMap.RedrawTileMap();
            SetLevelImage();
        }
        private void buttonToggleL3_Click(object sender, EventArgs e)
        {
            state.Layer3 = buttonToggleL3.Checked;
            tileMap.RedrawTileMap();
            SetLevelImage();
        }
        private void buttonToggleP1_Click(object sender, EventArgs e)
        {
            state.Priority1 = buttonToggleP1.Checked;
            pictureBoxLevel.Invalidate();
        }
        private void buttonTogglePhys_Click(object sender, EventArgs e)
        {
            state.PhysicalLayer = buttonTogglePhys.Checked;
            pictureBoxLevel.Invalidate();
        }
        private void buttonToggleNPCs_Click(object sender, EventArgs e)
        {
            state.NPCs = buttonToggleNPCs.Checked;
            pictureBoxLevel.Invalidate();

            //if (npcs.NumberOfNPCs > 0)
            //{
            //    if (npcObjectTree.SelectedNode != null && npcObjectTree.SelectedNode.Parent != null)
            //    {
            //        npcs.CurrentNPC = npcObjectTree.SelectedNode.Parent.Index;
            //        npcs.CurrentInstance = npcObjectTree.SelectedNode.Index;
            //        npcs.SelectedInstance = npcs.CurrentInstance;
            //    }
            //    else if (npcObjectTree.SelectedNode != null)
            //    {
            //        npcs.CurrentNPC = npcObjectTree.SelectedNode.Index;
            //        npcs.SelectedNPC = npcs.CurrentNPC;
            //    }
            //}
        }
        private void buttonToggleExits_Click(object sender, EventArgs e)
        {
            state.Exits = buttonToggleExits.Checked;
            pictureBoxLevel.Invalidate();

            //if (exits.NumberOfExits > 0 && this.exitsFieldTree.SelectedNode != null)
            //    exits.CurrentExit = this.exitsFieldTree.SelectedNode.Index;
        }
        private void buttonToggleEvents_Click(object sender, EventArgs e)
        {
            state.Events = buttonToggleEvents.Checked;
            pictureBoxLevel.Invalidate();

            //if (events.NumberOfEvents > 0 && eventsFieldTree.SelectedNode != null)
            //    events.CurrentEvent = this.eventsFieldTree.SelectedNode.Index;
        }
        private void buttonToggleOverlaps_Click(object sender, EventArgs e)
        {
            state.Overlaps = buttonToggleOverlaps.Checked;
            pictureBoxLevel.Invalidate();

            //if (overlaps.NumberOfOverlaps > 0 & overlapFieldTree.SelectedNode != null)
            //    overlaps.CurrentOverlap = this.overlapFieldTree.SelectedNode.Index;
        }
        private void buttonEditTemplate_Click(object sender, EventArgs e)
        {
            state.Template = buttonEditTemplate.Checked;
            buttonEditDraw.Checked = false;
            buttonEditSelect.Checked = false;
            buttonEditErase.Checked = false;
            buttonEditDropper.Checked = false;
            buttonZoomIn.Checked = false;
            buttonZoomOut.Checked = false;
            if (buttonEditTemplate.Checked)
                this.pictureBoxLevel.Cursor = new System.Windows.Forms.Cursor(GetType(), "CursorTemplate.cur");
            else if (!buttonEditTemplate.Checked)
                this.pictureBoxLevel.Cursor = System.Windows.Forms.Cursors.Arrow;

            overlay.Select = null;
            pictureBoxLevel.Invalidate();
        }
        private void opacityToolStripButton_Click(object sender, EventArgs e)
        {
            panelOpacity.Visible = !panelOpacity.Visible;
        }
        private void overlayOpacity_ValueChanged(object sender, EventArgs e)
        {
            labelOverlayOpacity.Text = overlayOpacity.Value.ToString() + "%";
            pictureBoxLevel.Invalidate();
        }
        // drawing
        private void buttonEditDraw_Click(object sender, EventArgs e)
        {
            state.Draw = buttonEditDraw.Checked;
            buttonEditTemplate.Checked = false;
            buttonEditSelect.Checked = false;
            buttonEditErase.Checked = false;
            buttonEditDropper.Checked = false;
            buttonZoomIn.Checked = false;
            buttonZoomOut.Checked = false;
            if (buttonEditDraw.Checked)
                this.pictureBoxLevel.Cursor = new System.Windows.Forms.Cursor(GetType(), "CursorDraw.cur");
            else if (!buttonEditDraw.Checked)
                this.pictureBoxLevel.Cursor = System.Windows.Forms.Cursors.Arrow;
            overlay.Select = null;
            pictureBoxLevel.Invalidate();
        }
        private void buttonEditSelect_Click(object sender, EventArgs e)
        {
            state.Select = buttonEditSelect.Checked;
            buttonEditTemplate.Checked = false;
            buttonEditDraw.Checked = false;
            buttonEditErase.Checked = false;
            buttonEditDropper.Checked = false;
            buttonZoomIn.Checked = false;
            buttonZoomOut.Checked = false;
            if (state.Select)
                this.pictureBoxLevel.Cursor = System.Windows.Forms.Cursors.Cross;
            else if (!state.Select)
                this.pictureBoxLevel.Cursor = System.Windows.Forms.Cursors.Arrow;
            if (copiedTiles != null)
                PasteFinal(copiedTiles);
            if (draggedTiles != null)
            {
                PasteFinal(draggedTiles);
                draggedTiles = null;
            }
            overlay.Select = null;
            pictureBoxLevel.Invalidate();
        }
        private void selectAll_Click(object sender, EventArgs e)
        {
            if (state.Select)
            {
                if (draggedTiles != null)
                    PasteFinal(draggedTiles);
                overlay.Select = new Overlay.Selection(16, 0, 0, 1024, 1024);
                pictureBoxLevel.Invalidate();
            }
        }
        private void buttonEditErase_Click(object sender, EventArgs e)
        {
            state.Erase = buttonEditErase.Checked;
            buttonEditTemplate.Checked = false;
            buttonEditDraw.Checked = false;
            buttonEditSelect.Checked = false;
            buttonEditDropper.Checked = false;
            buttonZoomIn.Checked = false;
            buttonZoomOut.Checked = false;
            if (state.Erase)
                this.pictureBoxLevel.Cursor = new System.Windows.Forms.Cursor(GetType(), "CursorErase.cur");
            else if (!state.Erase)
                this.pictureBoxLevel.Cursor = System.Windows.Forms.Cursors.Arrow;

            overlay.Select = null;
            pictureBoxLevel.Invalidate();
        }
        private void buttonEditDropper_Click(object sender, EventArgs e)
        {
            state.Dropper = buttonEditDropper.Checked;
            buttonEditTemplate.Checked = false;
            buttonEditDraw.Checked = false;
            buttonEditSelect.Checked = false;
            buttonEditErase.Checked = false;
            buttonZoomIn.Checked = false;
            buttonZoomOut.Checked = false;

            if (state.Dropper)
                this.pictureBoxLevel.Cursor = new System.Windows.Forms.Cursor(GetType(), "CursorDropper.cur");
            else if (!state.Dropper)
                this.pictureBoxLevel.Cursor = System.Windows.Forms.Cursors.Arrow;

            overlay.Select = null;
            pictureBoxLevel.Invalidate();
        }
        private void buttonEditDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void buttonEditUndo_Click(object sender, EventArgs e)
        {
            Undo();
        }
        private void buttonEditRedo_Click(object sender, EventArgs e)
        {
            Redo();
        }
        private void buttonEditCut_Click(object sender, EventArgs e)
        {
            Cut();
        }
        private void buttonEditCopy_Click(object sender, EventArgs e)
        {
            Copy();
        }
        private void buttonEditPaste_Click(object sender, EventArgs e)
        {
            if (copiedTiles == null) return;
            // set a floor and ceiling for the coordinates
            int x = Math.Max(0, Math.Min(Math.Abs(panelLevelPicture.AutoScrollPosition.X) / zoom / 16 * 16, 1023));
            int y = Math.Max(0, Math.Min(Math.Abs(panelLevelPicture.AutoScrollPosition.Y) / zoom / 16 * 16, 1023));
            x += 32; y += 32;
            if (x + copiedTiles.Width >= 1024)
                x -= x + copiedTiles.Width - 1024;
            if (y + copiedTiles.Height >= 1024)
                y -= x + copiedTiles.Height - 1024;
            if (draggedTiles != null)
                PasteFinal(draggedTiles);
            Paste(new Point(x, y), copiedTiles);
        }
        private void buttonZoomIn_Click(object sender, EventArgs e)
        {
            buttonEditTemplate.Checked = false;
            buttonEditDraw.Checked = false;
            buttonEditErase.Checked = false;
            buttonEditDropper.Checked = false;
            buttonEditSelect.Checked = false;
            buttonZoomOut.Checked = false;
            if (buttonZoomIn.Checked)
                this.pictureBoxLevel.Cursor = new System.Windows.Forms.Cursor(GetType(), "CursorZoomIn.cur");
            else if (!buttonZoomIn.Checked)
                this.pictureBoxLevel.Cursor = System.Windows.Forms.Cursors.Arrow;
        }
        private void buttonZoomOut_Click(object sender, EventArgs e)
        {
            buttonEditTemplate.Checked = false;
            buttonEditDraw.Checked = false;
            buttonEditErase.Checked = false;
            buttonEditDropper.Checked = false;
            buttonEditSelect.Checked = false;
            buttonZoomIn.Checked = false;
            if (buttonZoomOut.Checked)
                this.pictureBoxLevel.Cursor = new System.Windows.Forms.Cursor(GetType(), "CursorZoomOut.cur");
            else if (!buttonZoomOut.Checked)
                this.pictureBoxLevel.Cursor = System.Windows.Forms.Cursors.Arrow;
        }
        private void buttonZoomIn_CheckedChanged(object sender, EventArgs e)
        {
            //if (buttonZoomIn.Checked)
            //    pictureBoxLevel.ContextMenuStrip = null;
            //else
            //    pictureBoxLevel.ContextMenuStrip = contextMenuStrip1;
        }
        private void buttonZoomOut_CheckedChanged(object sender, EventArgs e)
        {
            //if (buttonZoomOut.Checked)
            //    pictureBoxLevel.ContextMenuStrip = null;
            //else
            //    pictureBoxLevel.ContextMenuStrip = contextMenuStrip1;
        }
        // context menu
        private void findInTileset_Click(object sender, EventArgs e)
        {
            int layer = 0;
            int index = tileMap.GetTileNum(0, mousePosition.X, mousePosition.Y);
            if (index == 0)
            {
                layer++;
                index = tileMap.GetTileNum(1, mousePosition.X, mousePosition.Y);
            }
            if (index == 0)
            {
                layer++;
                index = tileMap.GetTileNum(2, mousePosition.X, mousePosition.Y);
            }
            if (index != 0) // only if not all layers empty, otherwise stay at current layer tab
                levelsTileset.Layer = layer;
            levelsTileset.MouseDownTile = index;
        }
        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Do.Export(tilemapImage, "level." + level.Index.ToString("d3") + ".png");
        }
        #endregion
    }
}
