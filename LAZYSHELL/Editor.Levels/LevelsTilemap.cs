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
        public PictureBox Picture { get { return pictureBoxLevel; } set { pictureBoxLevel = value; } }
        private Levels levels;
        private Level level;
        private TileMap tileMap;
        private LevelSolidMap solidityMap;
        private Solidity solidity = Solidity.Instance;
        private TileSet tileSet;
        private Bitmap tilemapImage, p1Image, p1SolidityImage;
        private Overlay overlay;
        private State state = State.Instance;
        // editors
        private LevelsTileset levelsTileset;
        private LevelsSolidTiles levelsSolidTiles;
        private LevelsTemplate levelsTemplate;
        private PaletteEditor paletteEditor;
        // main classes
        private LevelMap levelMap { get { return levels.LevelMap; } }
        private LevelLayer layer { get { return level.Layer; } }
        private LevelExits exits { get { return level.LevelExits; } set { level.LevelExits = value; } }
        private LevelEvents events { get { return level.LevelEvents; } set { level.LevelEvents = value; } }
        private LevelNPCs npcs { get { return level.LevelNPCs; } set { level.LevelNPCs = value; } }
        private LevelOverlaps overlaps { get { return level.LevelOverlaps; } set { level.LevelOverlaps = value; } }
        private LevelTileMods tileMods { get { return level.LevelTileMods; } set { level.LevelTileMods = value; } }
        private LevelSolidMods solidMods { get { return level.LevelSolidMods; } set { level.LevelSolidMods = value; } }
        private SolidityTile[] physicalTiles { get { return Model.SolidTiles; } }
        private LevelTemplate template { get { return levelsTemplate.Template; } }
        // buffers
        private CopyBuffer draggedTiles;
        private CopyBuffer copiedTiles;
        private CommandStack commandStack;
        private CommandStack commandStack_S;
        private CommandStack commandStack_TM;
        private CommandStack commandStack_SM;
        private Stack<int> pushes;
        private Stack<int> pops;
        private Bitmap selection;
        private Bitmap selsolidt;
        private Point selsolidt_location = new Point(-1, -1);
        private bool pasteFinal = false;
        private bool CTRLPRESSED = false;
        // hover variables
        private string mouseOverObject;
        private int mouseOverTile = 0;
        private int mouseOverSolidTile = 0;
        private int mouseOverNPC = -1;
        private int mouseOverNPCInstance = -1;
        private int mouseOverExitField = -1;
        private int mouseOverEventField = -1;
        private int mouseOverOverlap = -1;
        private int mouseOverTileMod = 0;
        private int mouseOverSolidMod = 0;
        private int mouseOverSolidTileNum
        {
            get
            {
                return Bits.GetShort(solidityMap.Tilemap, mouseOverSolidTile * 2);
            }
        }
        private string mouseDownObject;
        private int mouseDownNPC = -1;
        private int mouseDownNPCInstance = -1;
        private int mouseDownExitField = -1;
        private int mouseDownEventField = -1;
        private int mouseDownOverlap = -1;
        private int mouseDownSolidTile = 0;
        private int mouseDownSolidTileNum
        {
            get
            {
                return Bits.GetShort(solidityMap.Tilemap, mouseDownSolidTile * 2);
            }
        }
        private int mouseDownSolidTileIndex = -1;
        private int mouseDownTileMod = 0;
        private int mouseDownSolidMod = 0;
        private Point mousePosition = new Point(0, 0);
        private Point mouseDownPosition = new Point(0, 0);
        private Point mouseIsometricPosition = new Point(0, 0);
        private Point mouseLastIsometricPosition = new Point(0, 0);
        private Point mouseDownIsometricPosition = new Point(0, 0);
        private Point autoScrollPos = new Point();
        private bool mouseWithinSameBounds = false;
        private bool mouseEnter = false;
        private int zoom = 1; public int Zoom { get { return zoom; } }
        private ZoomPanel zoomPanel;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();
        #endregion
        #region Functions
        // main
        public LevelsTilemap(
            Levels levels, Level level, TileMap tileMap, LevelSolidMap solidityMap, TileSet tileSet, Overlay overlay,
            PaletteEditor paletteEditor, LevelsTileset levelsTileset, LevelsSolidTiles levelsSolidTiles, LevelsTemplate levelsTemplate)
        {
            this.levels = levels;
            this.level = level;
            this.tileMap = tileMap;
            this.solidityMap = solidityMap;
            this.tileSet = tileSet;
            this.overlay = overlay;
            this.levelsTileset = levelsTileset;
            this.levelsSolidTiles = levelsSolidTiles;
            this.paletteEditor = paletteEditor;
            this.levelsTemplate = levelsTemplate;
            this.commandStack = new CommandStack();
            this.commandStack_S = new CommandStack();
            this.commandStack_TM = new CommandStack();
            this.commandStack_SM = new CommandStack();
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
            buttonTogglePhys.Checked = state.SolidityLayer;
            buttonToggleSolidMods.Checked = state.SolidMods;
            buttonToggleTileMods.Checked = state.TileMods;
        }
        public void Reload(
            Levels levels, Level level, TileMap tileMap, LevelSolidMap tilemap, TileSet tileSet, Overlay overlay,
            PaletteEditor paletteEditor, LevelsTileset levelsTileset, LevelsSolidTiles levelsPhysicalTiles, LevelsTemplate levelsTemplate)
        {
            if (this.level != level)
            {
                this.commandStack = new CommandStack();
                this.commandStack_S = new CommandStack();
                this.commandStack_TM = new CommandStack();
                this.commandStack_SM = new CommandStack();
                this.pushes = new Stack<int>();
                this.pops = new Stack<int>();
            }
            else
            {
                this.commandStack.SetTilemaps(tileMap);
                this.commandStack_S.SetSolidityMaps(tilemap);
            }
            this.levels = levels;
            this.level = level;
            this.tileMap = tileMap;
            this.solidityMap = tilemap;
            this.tileSet = tileSet;
            this.overlay = overlay;
            this.levelsTileset = levelsTileset;
            this.levelsSolidTiles = levelsPhysicalTiles;
            this.paletteEditor = paletteEditor;
            this.levelsTemplate = levelsTemplate;

            p1Image = null;
            p1SolidityImage = null;

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
        private Bitmap HightlightedTile(int index)
        {
            int[] pixels = solidity.GetTilePixels(Model.SolidTiles[index]);
            for (int y = 768 - Model.SolidTiles[index].TotalHeight; y < 784; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    if (pixels[y * 32 + x] == 0) continue;
                    Color color = Color.FromArgb(pixels[y * 32 + x]);
                    int r = color.R;
                    int n = 255;
                    int b = 192;
                    if (index == 0)
                        pixels[y * 32 + x] = Color.FromArgb(96, 0, 0, 0).ToArgb();
                    else
                        pixels[y * 32 + x] = Color.FromArgb(255, r, n, b).ToArgb();
                }
            }
            return new Bitmap(Do.PixelsToImage(pixels, 32, 784));
        }
        private void DrawHoverBox(Graphics g)
        {
            int mouseOverSolidTileNum = 0;
            if (state.SolidMods && solidMods.Mods.Count != 0)
                mouseOverSolidTileNum = Bits.GetShort(solidMods.Mod_.Tilemap, mouseOverSolidTile * 2);
            if (state.SolidityLayer && mouseOverSolidTileNum == 0)  // if mod map empty, check if solidity map empty
                mouseOverSolidTileNum = Bits.GetShort(solidityMap.Tilemap, mouseOverSolidTile * 2);
            if ((state.SolidityLayer || state.SolidMods) && mouseOverSolidTileNum != 0)
            {
                Bitmap image = HightlightedTile(mouseOverSolidTileNum);
                Point p = new Point(
                    solidity.TileCoords[mouseOverSolidTile].X * zoom,
                    solidity.TileCoords[mouseOverSolidTile].Y * zoom - 768);
                Rectangle rsrc = new Rectangle(0, 0, 32, 784);
                Rectangle rdst = new Rectangle(p.X, p.Y, zoom * 32, zoom * 784);
                g.DrawImage(image, rdst, rsrc, GraphicsUnit.Pixel);
            }
            else if (state.SolidityLayer || state.SolidMods || state.NPCs || state.Exits || state.Events || state.Overlaps)
            {
                Point p = new Point(
                    solidity.TileCoords[mouseOverSolidTile].X * zoom,
                    solidity.TileCoords[mouseOverSolidTile].Y * zoom);
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
            commandStack_S.Push(new SolidityEditCommand(this.levels, this.solidityMap, tL, bR, template.Start, template.Soliditymap));
            solidityMap.Image = null;
            tileMap.RedrawTileMap();
            tileMods.RedrawTilemaps();
            SetLevelImage();
        }
        private void Draw(Graphics g, int x, int y)
        {
            if (state.TileMods)
            {
                if (!tileMods.WithinBounds(x / 16, y / 16) ||
                    overlay.SelectTS.Width / 16 > tileMods.Width ||
                    overlay.SelectTS.Height / 16 > tileMods.Height)
                    return;
                x -= (tileMods.X * 16);
                y -= (tileMods.Y * 16);
            }
            if (state.SolidMods && !solidMods.WithinBounds(mouseOverSolidTile * 2))
                return;
            TileMap tilemap;
            if (state.TileMods)
                tilemap = levels.TileModsFieldTree.SelectedNode.Parent == null ? tileMods.TilemapA : tileMods.TilemapB;
            else
                tilemap = this.tileMap;
            if (!state.SolidityLayer && !state.SolidMods)
            {
                int layer = levelsTileset.Layer;
                // cancel if no selection in the tileset is made
                if (overlay.SelectTS == null) return;
                // cancel if writing same tile over itself
                if (CompareTiles(x, y, layer)) return;
                // cancel if layer doesn't exist
                if (tileSet.TileSetLayers[layer] == null) return;
                p1Image = null;
                Point location = new Point(x, y);
                Point terminal = new Point(
                    x + overlay.SelectTS.Width,
                    y + overlay.SelectTS.Height);
                CommandStack commandStack = state.TileMods ? this.commandStack_TM : this.commandStack;
                commandStack.Push(
                    new TileMapEditCommand(
                        levels, tilemap, layer, location, terminal,
                        levelsTileset.SelectedTiles.Copies, false, editAllLayers.Checked));
                if (state.TileMods)
                    tileMods.UpdateTilemaps();
                // draw the tile
                Point p = new Point(x / 16 * 16, y / 16 * 16);
                Bitmap image = Do.PixelsToImage(
                    tilemap.GetRangePixels(p, overlay.SelectTS.Size),
                    overlay.SelectTS.Width, overlay.SelectTS.Height);
                if (state.TileMods)
                {
                    p.X += tileMods.X * 16;
                    p.Y += tileMods.Y * 16;
                }
                p.X *= zoom;
                p.Y *= zoom;
                Rectangle rsrc = new Rectangle(0, 0, image.Width, image.Height);
                Rectangle rdst = new Rectangle(p.X, p.Y, (int)(image.Width * zoom), (int)(image.Height * zoom));
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImage(image, rdst, rsrc, GraphicsUnit.Pixel);
            }
            else if (state.SolidityLayer || state.SolidMods)
            {
                // cancel if physical tile editor not open
                if (levelsSolidTiles == null) return;
                // cancel if overwriting the same tile over itself
                if (solidityMap.GetTileNum(mouseOverSolidTile) == (ushort)levelsSolidTiles.Index)
                    return;
                Point initial = new Point(x, y);
                Point final = new Point(x + 1, y + 1);
                byte[] temp = new byte[0x20C2];
                Bits.SetShort(temp, mouseOverSolidTile * 2, (ushort)levelsSolidTiles.Index);
                Map map = state.SolidMods ? (Map)solidMods.Mod_ : solidityMap;
                CommandStack commandStack_S = state.SolidMods ? this.commandStack_SM : this.commandStack_S;
                commandStack_S.Push(new SolidityEditCommand(this.levels, map, initial, final, initial, temp));
                if (state.SolidMods)
                    solidMods.Mod_.CopyToTiles();
                solidity.RefreshTilemapImage(map, mouseOverSolidTile * 2);
                map.Image = null;
                p1SolidityImage = null;
                pictureBoxLevel.Invalidate();
                this.pushes.Push(1);
            }
        }
        private void Erase(Graphics g, int x, int y)
        {
            if (state.TileMods)
            {
                if (!tileMods.WithinBounds(x / 16, y / 16))
                    return;
                x -= (tileMods.X * 16);
                y -= (tileMods.Y * 16);
            }
            if (state.SolidMods && !solidMods.WithinBounds(mouseOverSolidTile * 2))
                return;
            TileMap tilemap;
            if (state.TileMods)
                tilemap = levels.TileModsFieldTree.SelectedNode.Parent == null ? tileMods.TilemapA : tileMods.TilemapB;
            else
                tilemap = this.tileMap;
            if (!state.SolidityLayer && !state.SolidMods)
            {
                int layer = levelsTileset.Layer;
                // cancel if overwriting the same tile over itself
                if (!editAllLayers.Checked && tileSet.TileSetLayers[layer] == null) return;
                if (!editAllLayers.Checked && tilemap.GetTileNum(layer, x, y) == 0) return;
                p1Image = null;
                CommandStack commandStack = state.TileMods ? this.commandStack_TM : this.commandStack;
                commandStack.Push(
                    new TileMapEditCommand(
                        this.levels, tilemap, layer, new Point(x, y), new Point(x + 16, y + 16),
                        new int[][] { new int[] { 0 }, new int[] { 0 }, new int[] { 0 }, new int[] { 0 } },
                        false, editAllLayers.Checked));
                if (state.TileMods)
                    tileMods.UpdateTilemaps();
                Point p = new Point(x / 16 * 16, y / 16 * 16);
                Bitmap image = Do.PixelsToImage(tilemap.GetRangePixels(p, new Size(16, 16)), 16, 16);
                if (state.TileMods)
                {
                    p.X += tileMods.X * 16;
                    p.Y += tileMods.Y * 16;
                }
                p.X *= zoom; p.Y *= zoom;
                Rectangle rsrc = new Rectangle(0, 0, image.Width, image.Height);
                Rectangle rdst = new Rectangle(p.X, p.Y, (int)(image.Width * zoom), (int)(image.Height * zoom));
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImage(image, rdst, rsrc, GraphicsUnit.Pixel);
            }
            else if (state.SolidityLayer || state.SolidMods)
            {
                // cancel if overwriting the same tile over itself
                if (solidityMap.GetTileNum(mouseOverSolidTile) == 0)
                    return;
                Point tL = new Point(x, y);
                Point bR = new Point(x + 1, y + 1);
                Map map = state.SolidMods ? (Map)solidMods.Mod_ : solidityMap;
                CommandStack commandStack_S = state.SolidMods ? this.commandStack_SM : this.commandStack_S;
                commandStack_S.Push(new SolidityEditCommand(this.levels, map, tL, bR, tL, new byte[0x20C2]));
                if (state.SolidMods)
                    solidMods.Mod_.CopyToTiles();
                solidity.RefreshTilemapImage(map, mouseOverSolidTile * 2);
                map.Image = null;
                p1SolidityImage = null;
                pictureBoxLevel.Invalidate();
                this.pushes.Push(1);
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
        private void Fill(Graphics g, int x, int y)
        {
            TileMap tilemap = this.tileMap;
            if (!state.SolidityLayer)
            {
                int layer = levelsTileset.Layer;
                // cancel if no selection in the tileset is made
                if (overlay.SelectTS == null) return;
                // cancel if writing same tile over itself
                if (CompareTiles(x, y, layer)) return;
                // cancel if layer doesn't exist
                if (tileSet.TileSetLayers[layer] == null) return;
                p1Image = null;
                // store changes
                int[][] changes = new int[3][];
                if (tilemap.TileMaps[0] != null) changes[0] = new int[0x1000];
                if (tilemap.TileMaps[1] != null) changes[1] = new int[0x1000];
                if (tilemap.TileMaps[2] != null) changes[2] = new int[0x1000];
                for (int l = 0; l < 3; l++)
                {
                    if (changes[l] == null) continue;
                    if (tilemap.Layers[l] == null) continue;
                    for (int i = 0; i < changes[l].Length && i < tilemap.Layers[l].Length; i++)
                    {
                        if (tilemap.Layers[l][i] == null) continue;
                        changes[l][i] = tilemap.Layers[l][i].TileIndex;
                    }
                }
                // fill up tiles
                Point location = new Point(0, 0);
                Point terminal = new Point(1024, 1024);
                int[] fillTile = levelsTileset.SelectedTiles.Copies[layer];
                int tile = tileMap.GetTileNum(layer, x, y);
                int vwidth = overlay.SelectTS.Width / 16;
                int vheight = overlay.SelectTS.Height / 16;

                if (!CTRLPRESSED)
                    Do.Fill(changes, layer, editAllLayers.Checked, tile, fillTile, x / 16, y / 16, 64, 64, vwidth, vheight, "");
                else
                    // non-contiguous fill
                    for (int d = 0; d < 64; d += vheight)
                    {
                        for (int c = 0; c < 64; c += vwidth)
                        {
                            for (int b = 0; b < vheight; b++)
                            {
                                if (changes[layer][(d + b) * 64 + c] != tile)
                                    break;
                                for (int a = 0; a < vwidth; a++)
                                {
                                    if (changes[layer][(d + b) * 64 + c + a] != tile)
                                        break;
                                    changes[layer][(d + b) * 64 + c + a] = fillTile[b * vwidth + a];
                                }
                            }
                        }
                    }
                commandStack.Push(
                    new TileMapEditCommand(levels, tilemap, layer, location, terminal, changes, false, false));
            }
            else
            {
                if (solidityMap.GetTileNum(mouseOverSolidTile) == (ushort)levelsSolidTiles.Index)
                    return;
                ushort tile = (ushort)solidityMap.GetTileNum(mouseOverSolidTile);
                ushort fillTile = (ushort)levelsSolidTiles.Index;
                byte[] changes = Bits.Copy(solidityMap.Tilemap);
                if (!CTRLPRESSED)
                    Do.Fill(changes, tile, fillTile, (mousePosition.X + 16) / 32 * 32, (mousePosition.Y + 8) / 16 * 16, 1024, 1024, "");
                else
                    for (int i = 0; i < changes.Length; i += 2)
                        if (Bits.GetShort(changes, i) == tile)
                            Bits.SetShort(changes, i, fillTile);
                int index = 0;
                int pushes = 0;
                for (int n = 0; n < 128; n++)
                {
                    for (int m = 0; m < 32; m++)
                    {
                        index = n * 32 + m;
                        Point tL = new Point(
                            solidity.TileCoords[index].X + 16,
                            solidity.TileCoords[index].Y + 8);
                        Point bR = new Point(
                            solidity.TileCoords[index].X + 17,
                            solidity.TileCoords[index].Y + 9);
                        if (state.SolidMods)
                            commandStack_S.Push(new SolidityEditCommand(levels, solidMods.Mod_, tL, bR, tL, changes));
                        else
                            commandStack_S.Push(new SolidityEditCommand(levels, solidityMap, tL, bR, tL, changes));
                        pushes++;
                    }
                }
                this.pushes.Push(pushes);
                solidityMap.Image = null;
                p1SolidityImage = null;
                pictureBoxLevel.Invalidate();
            }
        }
        private void Undo()
        {
            if (!state.SolidityLayer && !state.SolidMods)
            {
                if (!state.TileMods)
                    commandStack.UndoCommand();
                else
                    commandStack_TM.UndoCommand();
                p1Image = null;
                SetLevelImage();
                tileMods.ClearImages();
            }
            else
            {
                if (state.SolidMods)
                {
                    commandStack_SM.UndoCommand();
                    solidMods.Mod_.CopyToTiles();
                    solidMods.Mod_.Pixels = Solidity.Instance.GetTilemapPixels(solidMods.Mod_);
                    solidMods.Mod_.Image = null;
                }
                else if (this.pushes.Count > 0)
                {
                    int pushes = this.pushes.Pop();
                    int pops = 0;
                    for (; pushes > 0; pushes--, pops++)
                        commandStack_S.UndoCommand();
                    this.pops.Push(pops);
                    solidityMap.Image = null;
                    p1SolidityImage = null;
                }
                pictureBoxLevel.Invalidate();
            }
        }
        private void Redo()
        {
            if (!state.SolidityLayer && !state.SolidMods)
            {
                if (!state.TileMods)
                    commandStack.RedoCommand();
                else
                    commandStack_TM.RedoCommand();
                p1Image = null;
                SetLevelImage();
                tileMods.ClearImages();
            }
            else
            {
                if (state.SolidMods)
                {
                    commandStack_SM.RedoCommand();
                    solidMods.Mod_.CopyToTiles();
                    solidMods.Mod_.Pixels = Solidity.Instance.GetTilemapPixels(solidMods.Mod_);
                    solidMods.Mod_.Image = null;
                }
                else if (this.pops.Count > 0)
                {
                    int pops = this.pops.Pop();
                    int pushes = 0;
                    for (; pops > 0; pops--, pushes++)
                        commandStack_S.RedoCommand();
                    this.pushes.Push(pushes);
                    solidityMap.Image = null;
                    p1SolidityImage = null;
                }
                pictureBoxLevel.Invalidate();
            }
        }
        private void Cut()
        {
            if (overlay.Select == null || overlay.Select.Size == new Size(0, 0)) return;
            if (state.SolidityLayer || state.SolidMods) return;
            Copy();
            Delete();
        }
        private void Copy()
        {
            if (overlay.Select == null || overlay.Select.Size == new Size(0, 0)) return;
            if (state.SolidityLayer || state.SolidMods) return;
            if (draggedTiles != null)
            {
                this.copiedTiles = draggedTiles;
                return;
            }
            int layer = levelsTileset.Layer;
            TileMap tilemap;
            Point location = overlay.Select.Location;
            if (state.TileMods)
            {
                if (!tileMods.WithinBounds(location.X / 16, location.Y / 16))
                    return;
                tilemap = levels.TileModsFieldTree.SelectedNode.Parent == null ? tileMods.TilemapA : tileMods.TilemapB;
                location.X -= tileMods.X * 16;
                location.Y -= tileMods.Y * 16;
            }
            else
                tilemap = this.tileMap;
            if (editAllLayers.Checked)
                selection = new Bitmap(
                    Do.PixelsToImage(
                    tilemap.GetRangePixels(location, overlay.Select.Size),
                    overlay.Select.Width, overlay.Select.Height));
            else
                selection = new Bitmap(
                    Do.PixelsToImage(
                    tilemap.GetRangePixels(layer, location, overlay.Select.Size),
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
                        int tileX = location.X + (x * 16);
                        int tileY = location.Y + (y * 16);
                        copiedTiles[l][y * (overlay.Select.Width / 16) + x] = tilemap.GetTileNum(l, tileX, tileY);
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
            if (!state.SolidityLayer && !state.SolidMods)
            {
                int layer = levelsTileset.Layer;
                TileMap tilemap;
                if (state.TileMods)
                    tilemap = levels.TileModsFieldTree.SelectedNode.Parent == null ? tileMods.TilemapA : tileMods.TilemapB;
                else
                    tilemap = this.tileMap;
                if (editAllLayers.Checked)
                    selection = new Bitmap(
                        Do.PixelsToImage(
                        tilemap.GetRangePixels(overlay.Select.Location, overlay.Select.Size),
                        overlay.Select.Width, overlay.Select.Height));
                else
                    selection = new Bitmap(
                        Do.PixelsToImage(
                        tilemap.GetRangePixels(layer, overlay.Select.Location, overlay.Select.Size),
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
            Delete();
        }
        private void Paste(Point location, CopyBuffer buffer)
        {
            if (state.SolidityLayer || state.SolidMods) return;
            if (buffer == null) return;
            if (!buttonEditSelect.Checked)
                buttonEditSelect.PerformClick();
            state.Move = true;
            // now dragging a new selection
            draggedTiles = buffer;
            overlay.Select = new Overlay.Selection(16, location, buffer.Size);
            pictureBoxLevel.Invalidate();
            pasteFinal = false;
        }
        /// <summary>
        /// "Cements" either a dragged selection or a newly pasted selection.
        /// </summary>
        /// <param name="buffer">The dragged selection or the newly pasted selection.</param>
        private void PasteFinal(CopyBuffer buffer)
        {
            if (state.SolidityLayer || state.SolidMods) return;
            if (buffer == null) return;
            if (overlay.Select == null) return;
            Point location = new Point();
            location.X = overlay.Select.X / 16 * 16;
            location.Y = overlay.Select.Y / 16 * 16;
            int layer = levelsTileset.Layer;
            TileMap tilemap;
            if (state.TileMods)
            {
                if (!tileMods.WithinBounds(location.X / 16, location.Y / 16))
                    return;
                location.X -= tileMods.X * 16;
                location.Y -= tileMods.Y * 16;
                tilemap = levels.TileModsFieldTree.SelectedNode.Parent == null ? tileMods.TilemapA : tileMods.TilemapB;
            }
            else
                tilemap = this.tileMap;
            Point terminal = new Point(location.X + buffer.Width, location.Y + buffer.Height);
            CommandStack commandStack = state.TileMods ? this.commandStack_TM : this.commandStack;
            commandStack.Push(
                new TileMapEditCommand(levels, tilemap, layer, location, terminal, buffer.Copies, true, editAllLayers.Checked));
            p1Image = null;
            SetLevelImage();
            tileMods.ClearImages();
            pasteFinal = true;
        }
        /// <summary>
        /// Cements pasted tiles and clears the selection
        /// </summary>
        private void PasteClear()
        {
            if (copiedTiles != null && !pasteFinal)
                PasteFinal(copiedTiles);
            if (draggedTiles != null)
            {
                PasteFinal(draggedTiles);
                draggedTiles = null;
            }
            state.Move = false;
            overlay.Select = null;
        }
        private void Delete()
        {
            if (!state.SolidityLayer && !state.SolidMods)
            {
                int layer = levelsTileset.Layer;
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
                TileMap tilemap;
                if (state.TileMods)
                {
                    tilemap = levels.TileModsFieldTree.SelectedNode.Parent == null ? tileMods.TilemapA : tileMods.TilemapB;
                    location.X -= (tileMods.X * 16);
                    location.Y -= (tileMods.Y * 16);
                }
                else
                    tilemap = this.tileMap;
                CommandStack commandStack = state.TileMods ? this.commandStack_TM : this.commandStack;
                commandStack.Push(
                    new TileMapEditCommand(
                        levels, tilemap, layer, location, terminal,
                        changes, false, editAllLayers.Checked));
                p1Image = null;
                SetLevelImage();
                tileMods.ClearImages();
            }
            else
            {
                if (overlay.Select.Size == new Size(0, 0)) return;
                if (overlay.Select == null) return;
                int index = 0;
                int pushes = 0;
                Map map = state.SolidMods ? (Map)solidMods.Mod_ : solidityMap;
                for (int y = overlay.Select.Y; y < overlay.Select.Y + overlay.Select.Height; y++)
                {
                    for (int x = overlay.Select.X; x < overlay.Select.X + overlay.Select.Width; x++)
                    {
                        if (index == solidity.PixelTiles[y * 1024 + x])
                            continue;
                        index = solidity.PixelTiles[y * 1024 + x];
                        if (map.GetTileNum(index) == 0)
                            continue;
                        Point tL = new Point(
                            solidity.TileCoords[index].X + 16,
                            solidity.TileCoords[index].Y + 8);
                        Point bR = new Point(
                            solidity.TileCoords[index].X + 17,
                            solidity.TileCoords[index].Y + 9);
                        CommandStack commandStack_S = state.SolidMods ? this.commandStack_SM : this.commandStack_S;
                        commandStack_S.Push(new SolidityEditCommand(levels, map, tL, bR, tL, new byte[0x20C2]));
                        if (!state.SolidMods)
                            pushes++;
                    }
                }
                if (!state.SolidMods)
                {
                    this.pushes.Push(pushes);
                    p1SolidityImage = null;
                }
                else
                    map.Pixels = Solidity.Instance.GetTilemapPixels(map);
                map.Image = null;
                pictureBoxLevel.Invalidate();
            }
        }
        //
        private void ResetDrawButtons(ToolStripButton skip)
        {
            foreach (ToolStripItem item in toolStrip2.Items)
                if (item.GetType() == typeof(ToolStripButton))
                    if (item != skip)
                        ((ToolStripButton)item).Checked = false;
        }
        #endregion
        #region Event Handlers
        // main
        private void LevelsTilemap_KeyDown(object sender, KeyEventArgs e)
        {
        }
        private void pictureBoxLevel_Paint(object sender, PaintEventArgs e)
        {
            if (levels.Index == 100 && mouseEnter == true)
                panelLevelPicture.AutoScrollPosition = autoScrollPos;
            else
                panelLevelPicture.AutoScrollPosition = autoScrollPos;
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
            if (state.TileMods)
                overlay.DrawLevelTileMods(tileMods, e.Graphics, ia, zoom);
            if (state.Move && selection != null)
            {
                Rectangle rsrc = new Rectangle(0, 0, overlay.Select.Width, overlay.Select.Height);
                rdst = new Rectangle(
                    overlay.Select.X * zoom, overlay.Select.Y * zoom,
                    rsrc.Width * zoom, rsrc.Height * zoom);
                e.Graphics.DrawImage(new Bitmap(selection), rdst, rsrc, GraphicsUnit.Pixel);
            }
            if (state.Priority1 && !state.SolidityLayer)
            {
                cm.Matrix33 = 0.50F;
                ia.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                if (p1Image == null)
                    p1Image = new Bitmap(Do.PixelsToImage(tileMap.GetPriority1Pixels(), 1024, 1024));
                e.Graphics.DrawImage(p1Image, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel, ia);
            }
            if (state.SolidityLayer)
            {
                if (overlayOpacity.Value < 100)
                    e.Graphics.DrawImage(solidityMap.Image, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel, ia);
                else
                    e.Graphics.DrawImage(solidityMap.Image, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel);
                if (state.Priority1)
                {
                    if (p1SolidityImage == null)
                        p1SolidityImage = new Bitmap(Do.PixelsToImage(solidity.GetPriority1Pixels(solidityMap), 1024, 1024));
                    e.Graphics.DrawImage(p1SolidityImage, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel, ia);
                }
                if (selsolidt != null)
                {
                    Rectangle rsrc = new Rectangle(0, 0, selsolidt.Width, selsolidt.Height);
                    rdst = new Rectangle(
                        selsolidt_location.X * zoom, selsolidt_location.Y * zoom,
                        rsrc.Width * zoom, rsrc.Height * zoom);
                    e.Graphics.DrawImage(selsolidt, rdst, rsrc, GraphicsUnit.Pixel);
                }
            }
            if (state.SolidMods)
            {
                overlay.DrawLevelSolidMods(solidMods, physicalTiles, e.Graphics, rdst, ia, zoom);
                overlay.DrawLevelSolidMods(solidMods, e.Graphics, zoom);
            }
            if (state.Exits)
            {
                if (overlay.ExitsImage == null)
                    overlay.DrawLevelExits(exits);
                if (overlayOpacity.Value < 100)
                    e.Graphics.DrawImage(overlay.ExitsImage, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel, ia);
                else
                    e.Graphics.DrawImage(overlay.ExitsImage, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel);
                if (tags.Checked)
                    overlay.DrawLevelExits(exits, e.Graphics, zoom);
            }
            if (state.Events)
            {
                if (overlay.EventsImage == null)
                    overlay.DrawLevelEvents(events);
                if (overlayOpacity.Value < 100)
                    e.Graphics.DrawImage(overlay.EventsImage, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel, ia);
                else
                    e.Graphics.DrawImage(overlay.EventsImage, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel);
                if (tags.Checked)
                    overlay.DrawLevelEvents(events, e.Graphics, zoom);
            }
            if (state.NPCs)
            {
                if (overlay.NPCsImage == null)
                    overlay.DrawLevelNPCs(npcs, Model.NPCProperties);
                if (overlayOpacity.Value < 100)
                    e.Graphics.DrawImage(overlay.NPCsImage, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel, ia);
                else
                    e.Graphics.DrawImage(overlay.NPCsImage, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel);
                if (tags.Checked)
                    overlay.DrawLevelNPCs(npcs, e.Graphics, zoom);
            }
            if (state.Overlaps)
            {
                if (overlay.OverlapsImage == null)
                    overlay.DrawLevelOverlaps(overlaps, Model.OverlapTileset);
                if (overlayOpacity.Value < 100)
                    e.Graphics.DrawImage(overlay.OverlapsImage, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel, ia);
                else
                    e.Graphics.DrawImage(overlay.OverlapsImage, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel);
            }
            if (!state.Dropper && mouseEnter)
                DrawHoverBox(e.Graphics);
            if (state.CartesianGrid)
                overlay.DrawCartesianGrid(e.Graphics, Color.Gray, pictureBoxLevel.Size, new Size(16, 16), zoom);
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
            panelLevelPicture.AutoScrollPosition = autoScrollPos;
            // in case the tileset selection was dragged
            if (levelsTileset.DraggedTiles != null)
                levelsTileset.PasteFinal(levelsTileset.DraggedTiles);
            // set a floor and ceiling for the coordinates
            int x = Math.Max(0, Math.Min(e.X / zoom, 1024));
            int y = Math.Max(0, Math.Min(e.Y / zoom, 1024));
            mouseDownObject = null;
            #region Zooming
            autoScrollPos.X = Math.Abs(panelLevelPicture.AutoScrollPosition.X);
            autoScrollPos.Y = Math.Abs(panelLevelPicture.AutoScrollPosition.Y);
            if ((buttonZoomIn.Checked && e.Button == MouseButtons.Left) || (buttonZoomOut.Checked && e.Button == MouseButtons.Right))
            {
                if (zoom < 8)
                {
                    zoom *= 2;
                    autoScrollPos = new Point(Math.Abs(pictureBoxLevel.Left), Math.Abs(pictureBoxLevel.Top));
                    autoScrollPos.X += e.X;
                    autoScrollPos.Y += e.Y;
                    pictureBoxLevel.Width = 1024 * zoom;
                    pictureBoxLevel.Height = 1024 * zoom;
                    panelLevelPicture.Focus();
                    panelLevelPicture.AutoScrollPosition = autoScrollPos;
                    panelLevelPicture.VerticalScroll.SmallChange *= 2;
                    panelLevelPicture.HorizontalScroll.SmallChange *= 2;
                    panelLevelPicture.VerticalScroll.LargeChange *= 2;
                    panelLevelPicture.HorizontalScroll.LargeChange *= 2;
                    pictureBoxLevel.Invalidate();
                    pictureBoxLevel.Focus();
                    return;
                }
                return;
            }
            else if ((buttonZoomOut.Checked && e.Button == MouseButtons.Left) || (buttonZoomIn.Checked && e.Button == MouseButtons.Right))
            {
                if (zoom > 1)
                {
                    zoom /= 2;

                    autoScrollPos = new Point(Math.Abs(pictureBoxLevel.Left), Math.Abs(pictureBoxLevel.Top));
                    autoScrollPos.X -= e.X / 2;
                    autoScrollPos.Y -= e.Y / 2;

                    pictureBoxLevel.Width = 1024 * zoom;
                    pictureBoxLevel.Height = 1024 * zoom;
                    panelLevelPicture.Focus();
                    panelLevelPicture.AutoScrollPosition = autoScrollPos;
                    panelLevelPicture.VerticalScroll.SmallChange /= 2;
                    panelLevelPicture.HorizontalScroll.SmallChange /= 2;
                    panelLevelPicture.VerticalScroll.LargeChange /= 2;
                    panelLevelPicture.HorizontalScroll.LargeChange /= 2;
                    pictureBoxLevel.Invalidate();
                    pictureBoxLevel.Focus();
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
                    panelLevelPicture.AutoScrollPosition = autoScrollPos;
                    return;
                }
                if (state.Draw)
                {
                    Draw(pictureBoxLevel.CreateGraphics(), x, y);
                    panelLevelPicture.AutoScrollPosition = autoScrollPos;
                    return;
                }
                if (state.Erase)
                {
                    Erase(pictureBoxLevel.CreateGraphics(), x, y);
                    panelLevelPicture.AutoScrollPosition = autoScrollPos;
                    return;
                }
                if (state.Fill)
                {
                    Fill(pictureBoxLevel.CreateGraphics(), x, y);
                    panelLevelPicture.AutoScrollPosition = autoScrollPos;
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
                    levels.TabControl.SelectedIndex = 3;
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
                    levels.TabControl.SelectedIndex = 4;
                    mouseDownObject = "overlap";
                    mouseDownOverlap = mouseOverOverlap;
                    overlaps.CurrentOverlap = mouseDownOverlap;
                    overlaps.SelectedOverlap = mouseDownOverlap;
                    overlay.OverlapsImage = null;
                    levels.OverlapFieldTree.SelectedNode = levels.OverlapFieldTree.Nodes[overlaps.CurrentOverlap];
                }
                if (state.TileMods && mouseOverObject == "tileMod" && mouseDownObject == null)
                {
                    levels.TabControl.SelectedIndex = 5;
                    mouseDownObject = "tileMod";
                    mouseDownTileMod = mouseOverTileMod;
                    tileMods.CurrentMod = mouseDownTileMod;
                    tileMods.SelectedMod = mouseDownTileMod;
                    levels.TileModsFieldTree.SelectedNode = levels.TileModsFieldTree.Nodes[tileMods.CurrentMod];
                }
                if (state.SolidMods && mouseOverObject == "solidMod" && mouseDownObject == null)
                {
                    levels.TabControl.SelectedIndex = 5;
                    mouseDownObject = "solidMod";
                    mouseDownSolidMod = mouseOverSolidMod;
                    solidMods.CurrentMod = mouseDownSolidMod;
                    solidMods.SelectedMod = mouseDownSolidMod;
                    levels.SolidModsFieldTree.SelectedNode = levels.SolidModsFieldTree.Nodes[solidMods.CurrentMod];
                }
                if (state.SolidityLayer && mouseOverObject == "solid tile" && mouseDownObject == null)
                {
                    mouseDownObject = "solid tile";
                    mouseDownSolidTile = mouseOverSolidTile;
                    mouseDownSolidTileIndex = mouseDownSolidTileNum;
                    selsolidt = HightlightedTile(mouseDownSolidTileNum);
                    selsolidt_location = solidity.TileCoords[mouseDownSolidTile];
                    selsolidt_location.Y -= 768;
                    if (!CTRLPRESSED)
                    {
                        Point tL = new Point(x, y);
                        Point bR = new Point(x + 1, y + 1);
                        Map map;
                        if (state.SolidMods && (Map)solidMods.Mod_ != null)
                            map = (Map)solidMods.Mod_;
                        else
                            map = solidityMap;
                        commandStack_S.Push(new SolidityEditCommand(this.levels, map, tL, bR, tL, new byte[0x20C2]));
                        if (state.SolidMods)
                            solidMods.Mod_.CopyToTiles();
                        solidity.RefreshTilemapImage(map, mouseDownSolidTile * 2);
                        map.Image = null;
                        p1SolidityImage = null;
                        this.pushes.Push(1);
                    }
                }
            }
            #endregion
            panelLevelPicture.AutoScrollPosition = autoScrollPos;
            pictureBoxLevel.Invalidate();
        }
        private void pictureBoxLevel_MouseUp(object sender, MouseEventArgs e)
        {
            int x = Math.Max(0, Math.Min(e.X / zoom, 1024));
            int y = Math.Max(0, Math.Min(e.Y / zoom, 1024));
            if (mouseDownObject == "solid tile")
            {
                selsolidt = null;
                Point initial = new Point(x, y);
                Point final = new Point(x + 1, y + 1);
                byte[] temp = new byte[0x20C2];
                Bits.SetShort(temp, mouseOverSolidTile * 2, mouseDownSolidTileIndex);
                Map map = state.SolidMods ? (Map)solidMods.Mod_ : solidityMap;
                commandStack_S.Push(new SolidityEditCommand(this.levels, map, initial, final, initial, temp));
                if (state.SolidMods)
                    solidMods.Mod_.CopyToTiles();
                solidity.RefreshTilemapImage(map, mouseOverSolidTile * 2);
                map.Image = null;
                p1SolidityImage = null;
                pictureBoxLevel.Invalidate();
                this.pushes.Push(1);
            }
            mouseDownExitField = -1;
            mouseDownEventField = -1;
            mouseDownNPC = -1;
            mouseDownNPCInstance = -1;
            mouseDownOverlap = -1;
            mouseDownSolidTile = 0;
            mouseDownSolidTileIndex = -1;
            mouseDownObject = null;
            if (state.Draw || state.Erase || state.Fill)
            {
                if (!state.SolidityLayer && !state.SolidMods)
                {
                    SetLevelImage();
                    tileMods.ClearImages();
                }
                else
                    pictureBoxLevel.Invalidate();
            }
            pictureBoxLevel.Focus();
        }
        private void pictureBoxLevel_MouseMove(object sender, MouseEventArgs e)
        {
            CTRLPRESSED = false;
            // set a floor and ceiling for the coordinates
            int x = Math.Max(0, Math.Min(e.X / zoom, 1024));
            int y = Math.Max(0, Math.Min(e.Y / zoom, 1024));
            // must first check if within same bounds as last call of MouseMove event
            if (state.SolidityLayer || state.SolidMods)
                mouseWithinSameBounds = mouseOverSolidTile ==
                    solidity.PixelTiles[Math.Min(y * 1024 + x, 1023 * 1023)];
            else
                mouseWithinSameBounds = mouseOverTile == (y / 16 * 64) + (x / 16);
            // now set the properties
            mousePosition = new Point(x, y);
            mouseLastIsometricPosition = new Point(mouseIsometricPosition.X, mouseIsometricPosition.Y);
            mouseIsometricPosition.X = solidity.PixelCoords[Math.Min(y * 1024 + x, 1023 * 1023)].X;
            mouseIsometricPosition.Y = solidity.PixelCoords[Math.Min(y * 1024 + x, 1023 * 1023)].Y;
            mouseOverTile = (y / 16 * 64) + (x / 16);
            mouseOverSolidTile = solidity.PixelTiles[Math.Min(y * 1024 + x, 1023 * 1023)];
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
                else if (!state.SolidityLayer && e.Button == MouseButtons.Left && mouseDownObject == "selection")
                    overlay.Select.Location = new Point(x / 16 * 16 - mouseDownPosition.X, y / 16 * 16 - mouseDownPosition.Y);
                // if mouse not clicked and within the current selection
                else if (!state.SolidityLayer && e.Button == MouseButtons.None && overlay.Select != null && overlay.Select.MouseWithin(x, y))
                {
                    mouseOverObject = "selection";
                    pictureBoxLevel.Cursor = Cursors.SizeAll;
                }
                else
                    pictureBoxLevel.Cursor = Cursors.Cross;
                pictureBoxLevel.Invalidate();
                return;
            }
            if (!state.SolidityLayer && !state.SolidMods)
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
            else if (state.SolidityLayer || state.SolidMods)
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
            if (!state.Template && !state.Draw && !state.Select && !state.Erase && !state.Dropper && !state.Fill)
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
                            levels.UpdatingLevel = true;
                        levels.ExitX.Value = mouseIsometricPosition.X;
                        levels.UpdatingLevel = false;
                        levels.ExitY.Value = mouseIsometricPosition.Y;
                    }
                    if (mouseDownObject == "event")
                    {
                        if (levels.EventX.Value != mouseIsometricPosition.X &&
                            levels.EventY.Value != mouseIsometricPosition.Y)
                            levels.UpdatingLevel = true;
                        levels.EventX.Value = mouseIsometricPosition.X;
                        levels.UpdatingLevel = false;
                        levels.EventY.Value = mouseIsometricPosition.Y;
                    }
                    if (mouseDownObject == "npc" || mouseDownObject == "npc instance")
                    {
                        if (levels.NpcXCoord.Value != mouseIsometricPosition.X &&
                            levels.NpcYCoord.Value != mouseIsometricPosition.Y)
                            levels.UpdatingLevel = true;
                        levels.NpcXCoord.Value = mouseIsometricPosition.X;
                        levels.UpdatingLevel = false;
                        levels.NpcYCoord.Value = mouseIsometricPosition.Y;
                    }
                    if (mouseDownObject == "overlap")
                    {
                        if (levels.OverlapX.Value != mouseIsometricPosition.X &&
                            levels.OverlapY.Value != mouseIsometricPosition.Y)
                            levels.UpdatingLevel = true;
                        levels.OverlapX.Value = mouseIsometricPosition.X;
                        levels.UpdatingLevel = false;
                        levels.OverlapY.Value = mouseIsometricPosition.Y;
                    }
                    if (mouseDownObject == "solid tile")
                    {
                        selsolidt_location = solidity.TileCoords[mouseOverSolidTile];
                        selsolidt_location.Y -= 768;
                    }
                    pictureBoxLevel.Invalidate();
                    return;
                }
                #endregion
                #region Check if over an object
                else
                {
                    pictureBoxLevel.Cursor = Cursors.Arrow;
                    if (state.Exits && exits.Count != 0)
                    {
                        int index_ext = 0;
                        foreach (Exit exit in exits.Exits)
                        {
                            if (exit.X == mouseIsometricPosition.X &&
                                exit.Y == mouseIsometricPosition.Y)
                            {
                                this.pictureBoxLevel.Cursor = Cursors.Hand;
                                mouseOverExitField = index_ext;
                                mouseOverObject = "exit";
                                break;
                            }
                            else
                            {
                                this.pictureBoxLevel.Cursor = Cursors.Arrow;
                                mouseOverExitField = 0;
                                mouseOverObject = null;
                            }
                            index_ext++;
                        }
                    }
                    if (state.Events && events.Count != 0 && mouseOverObject == null)
                    {
                        int index_evt = 0;
                        foreach (Event event_ in events.Events)
                        {
                            if (event_.X == mouseIsometricPosition.X &&
                                event_.Y == mouseIsometricPosition.Y)
                            {
                                this.pictureBoxLevel.Cursor = Cursors.Hand;
                                mouseOverEventField = index_evt;
                                mouseOverObject = "event";
                                break;
                            }
                            else
                            {
                                this.pictureBoxLevel.Cursor = Cursors.Arrow;
                                mouseOverEventField = 0;
                                mouseOverObject = null;
                            }
                            index_evt++;
                        }
                    }
                    if (state.NPCs && npcs.Count != 0 && mouseOverObject == null)
                    {
                        int index_npc = 0;
                        foreach (NPC npc in npcs.Npcs)
                        {
                            if (npc.X == mouseIsometricPosition.X &&
                                npc.Y == mouseIsometricPosition.Y)
                            {
                                this.pictureBoxLevel.Cursor = Cursors.Hand;
                                mouseOverNPC = index_npc;
                                mouseOverNPCInstance = -1;
                                mouseOverObject = "npc";
                                break;
                            }
                            else
                            {
                                this.pictureBoxLevel.Cursor = Cursors.Arrow;
                                mouseOverNPC = -1;
                                mouseOverObject = null;
                            }
                            // for all of the instances
                            int index_ins = 0;
                            foreach (NPC.Instance instance in npc.Instances)
                            {
                                if (instance.X == mouseIsometricPosition.X &&
                                    instance.Y == mouseIsometricPosition.Y)
                                {
                                    this.pictureBoxLevel.Cursor = Cursors.Hand;
                                    mouseOverNPC = index_npc;
                                    mouseOverNPCInstance = index_ins;
                                    mouseOverObject = "npc instance";
                                    goto finish;
                                }
                                else
                                {
                                    this.pictureBoxLevel.Cursor = Cursors.Arrow;
                                    mouseOverNPCInstance = -1;
                                    mouseOverObject = null;
                                }
                                index_ins++;
                            }
                            index_npc++;
                        }
                    }
                finish:
                    if (state.Overlaps && overlaps.Count != 0 && mouseOverObject == null)
                    {
                        int currentOverlap = overlaps.CurrentOverlap;
                        for (int i = 0; i < overlaps.Count; i++)
                        {
                            overlaps.CurrentOverlap = i;
                            if (overlaps.X == mouseIsometricPosition.X &&
                                overlaps.Y == mouseIsometricPosition.Y)
                            {
                                this.pictureBoxLevel.Cursor = Cursors.Hand;
                                mouseOverOverlap = i;
                                mouseOverObject = "overlap";
                                break;
                            }
                            else
                            {
                                this.pictureBoxLevel.Cursor = Cursors.Arrow;
                                mouseOverOverlap = 0;
                                mouseOverObject = null;
                            }
                        }
                        overlaps.CurrentOverlap = currentOverlap;
                    }
                    if (state.SolidityLayer && buttonDragSolidity.Checked)
                    {
                        if (mouseOverSolidTileNum != 0)
                        {
                            this.pictureBoxLevel.Cursor = Cursors.Hand;
                            mouseOverObject = "solid tile";
                        }
                        else
                        {
                            this.pictureBoxLevel.Cursor = Cursors.Arrow;
                            mouseOverObject = null;
                        }
                    }
                }
                #endregion
            }
            #endregion
            if (!state.SolidityLayer && !state.SolidMods &&
                !state.NPCs && !state.Exits && !state.Events && !state.Overlaps && !mouseWithinSameBounds)
                pictureBoxLevel.Invalidate();
            else if (state.SolidityLayer || state.SolidMods ||
                state.NPCs || state.Exits || state.Events || state.Overlaps)
                pictureBoxLevel.Invalidate();
        }
        private void pictureBoxLevel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //toolStripMenuItem5_Click(null, null);
        }
        private void pictureBoxLevel_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter = true;
            if (GetForegroundWindow() == levels.Handle)
                pictureBoxLevel.Focus();
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
                case Keys.LButton | Keys.ShiftKey | Keys.Control:
                    CTRLPRESSED = true;
                    break;
            }
        }
        private void panelLevelPicture_Scroll(object sender, ScrollEventArgs e)
        {
            autoScrollPos.X = Math.Abs(panelLevelPicture.AutoScrollPosition.X);
            autoScrollPos.Y = Math.Abs(panelLevelPicture.AutoScrollPosition.Y);
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
            tileMods.RedrawTilemaps();
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
            tileMods.RedrawTilemaps();
            SetLevelImage();
        }
        private void buttonToggleL2_Click(object sender, EventArgs e)
        {
            state.Layer2 = buttonToggleL2.Checked;
            tileMap.RedrawTileMap();
            tileMods.RedrawTilemaps();
            SetLevelImage();
        }
        private void buttonToggleL3_Click(object sender, EventArgs e)
        {
            state.Layer3 = buttonToggleL3.Checked;
            tileMap.RedrawTileMap();
            tileMods.RedrawTilemaps();
            SetLevelImage();
        }
        private void buttonToggleP1_Click(object sender, EventArgs e)
        {
            state.Priority1 = buttonToggleP1.Checked;
            pictureBoxLevel.Invalidate();
        }
        private void buttonTogglePhys_Click(object sender, EventArgs e)
        {
            PasteClear();
            state.SolidityLayer = buttonTogglePhys.Checked;
            buttonDragSolidity.Enabled = buttonTogglePhys.Checked;
            if (!buttonDragSolidity.Enabled)
                buttonDragSolidity.Checked = false;
            pictureBoxLevel.Invalidate();
        }
        private void buttonToggleTileMods_Click(object sender, EventArgs e)
        {
            PasteClear();
            state.TileMods = buttonToggleTileMods.Checked;
            pictureBoxLevel.Invalidate();
        }
        private void buttonToggleSolidMods_Click(object sender, EventArgs e)
        {
            PasteClear();
            state.SolidMods = buttonToggleSolidMods.Checked;
            pictureBoxLevel.Invalidate();
        }
        private void buttonToggleNPCs_Click(object sender, EventArgs e)
        {
            PasteClear();
            state.NPCs = buttonToggleNPCs.Checked;
            pictureBoxLevel.Invalidate();
        }
        private void buttonToggleExits_Click(object sender, EventArgs e)
        {
            PasteClear();
            state.Exits = buttonToggleExits.Checked;
            pictureBoxLevel.Invalidate();
        }
        private void buttonToggleEvents_Click(object sender, EventArgs e)
        {
            PasteClear();
            state.Events = buttonToggleEvents.Checked;
            pictureBoxLevel.Invalidate();
        }
        private void buttonToggleOverlaps_Click(object sender, EventArgs e)
        {
            PasteClear();
            state.Overlaps = buttonToggleOverlaps.Checked;
            pictureBoxLevel.Invalidate();
        }
        private void tags_Click(object sender, EventArgs e)
        {
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
            ResetDrawButtons((ToolStripButton)sender);
            if (buttonEditDraw.Checked)
                this.pictureBoxLevel.Cursor = new Cursor(GetType(), "CursorDraw.cur");
            else if (!buttonEditDraw.Checked)
                this.pictureBoxLevel.Cursor = Cursors.Arrow;
            PasteClear();
            pictureBoxLevel.Invalidate();
        }
        private void buttonEditSelect_Click(object sender, EventArgs e)
        {
            state.Select = buttonEditSelect.Checked;
            ResetDrawButtons((ToolStripButton)sender);
            if (state.Select)
                this.pictureBoxLevel.Cursor = Cursors.Cross;
            else if (!state.Select)
                this.pictureBoxLevel.Cursor = Cursors.Arrow;
            PasteClear();
            pictureBoxLevel.Invalidate();
        }
        private void selectAll_Click(object sender, EventArgs e)
        {
            if (state.Select)
            {
                PasteClear();
                overlay.Select = new Overlay.Selection(16, 0, 0, 1024, 1024);
                pictureBoxLevel.Invalidate();
            }
        }
        private void buttonEditErase_Click(object sender, EventArgs e)
        {
            state.Erase = buttonEditErase.Checked;
            ResetDrawButtons((ToolStripButton)sender);
            if (state.Erase)
                this.pictureBoxLevel.Cursor = new Cursor(GetType(), "CursorErase.cur");
            else if (!state.Erase)
                this.pictureBoxLevel.Cursor = Cursors.Arrow;

            PasteClear();
            pictureBoxLevel.Invalidate();
        }
        private void buttonEditDropper_Click(object sender, EventArgs e)
        {
            state.Dropper = buttonEditDropper.Checked;
            ResetDrawButtons((ToolStripButton)sender);
            if (state.Dropper)
                this.pictureBoxLevel.Cursor = new Cursor(GetType(), "CursorDropper.cur");
            else if (!state.Dropper)
                this.pictureBoxLevel.Cursor = Cursors.Arrow;

            PasteClear();
            pictureBoxLevel.Invalidate();
        }
        private void buttonEditFill_Click(object sender, EventArgs e)
        {
            state.Fill = buttonEditFill.Checked;
            ResetDrawButtons((ToolStripButton)sender);
            if (state.Fill)
                this.pictureBoxLevel.Cursor = new Cursor(GetType(), "CursorFill.cur");
            else if (!state.Fill)
                this.pictureBoxLevel.Cursor = Cursors.Arrow;

            PasteClear();
            pictureBoxLevel.Invalidate();
        }
        private void buttonEditTemplate_Click(object sender, EventArgs e)
        {
            state.Template = buttonEditTemplate.Checked;
            ResetDrawButtons((ToolStripButton)sender);
            if (buttonEditTemplate.Checked)
                this.pictureBoxLevel.Cursor = new Cursor(GetType(), "CursorTemplate.cur");
            else if (!buttonEditTemplate.Checked)
                this.pictureBoxLevel.Cursor = Cursors.Arrow;

            PasteClear();
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
            buttonEditFill.Checked = false;
            buttonEditSelect.Checked = false;
            buttonZoomOut.Checked = false;
            if (buttonZoomIn.Checked)
                this.pictureBoxLevel.Cursor = new Cursor(GetType(), "CursorZoomIn.cur");
            else if (!buttonZoomIn.Checked)
                this.pictureBoxLevel.Cursor = Cursors.Arrow;
        }
        private void buttonZoomOut_Click(object sender, EventArgs e)
        {
            buttonEditTemplate.Checked = false;
            buttonEditDraw.Checked = false;
            buttonEditErase.Checked = false;
            buttonEditDropper.Checked = false;
            buttonEditFill.Checked = false;
            buttonEditSelect.Checked = false;
            buttonZoomIn.Checked = false;
            if (buttonZoomOut.Checked)
                this.pictureBoxLevel.Cursor = new Cursor(GetType(), "CursorZoomOut.cur");
            else if (!buttonZoomOut.Checked)
                this.pictureBoxLevel.Cursor = Cursors.Arrow;
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
        private void buttonDragSolidity_Click(object sender, EventArgs e)
        {
            state.ClearDrawSelectErase();
            ResetDrawButtons((ToolStripButton)sender);
            PasteClear();
            pictureBoxLevel.Invalidate();
        }
        // context menu
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (buttonZoomIn.Checked || buttonZoomOut.Checked)
                e.Cancel = true;
            else if (mouseOverObject == "exit")
            {
                foreach (ToolStripItem item in contextMenuStrip1.Items)
                    item.Visible = false;
                objectFunctionToolStripMenuItem.Text = "Load destination";
                objectFunctionToolStripMenuItem.Tag = mouseOverExitField;
                objectFunctionToolStripMenuItem.Visible = true;
            }
            else if (mouseOverObject == "event")
            {
                foreach (ToolStripItem item in contextMenuStrip1.Items)
                    item.Visible = false;
                objectFunctionToolStripMenuItem.Text = "Edit event's script";
                objectFunctionToolStripMenuItem.Tag = mouseOverEventField;
                objectFunctionToolStripMenuItem.Visible = true;
            }
            else if (mouseOverObject == "npc" || mouseOverObject == "npc instance")
            {
                foreach (ToolStripItem item in contextMenuStrip1.Items)
                    item.Visible = false;
                if (npcs.Npcs[mouseOverNPC].EngageType == 0 || npcs.Npcs[mouseOverNPC].EngageType == 1)
                    objectFunctionToolStripMenuItem.Text = "Edit npc's script";
                else if (npcs.Npcs[mouseOverNPC].EngageType == 2)
                    objectFunctionToolStripMenuItem.Text = "Edit npc's formation pack";
                objectFunctionToolStripMenuItem.Tag = new List<int> { mouseOverNPC, mouseOverNPCInstance };
                objectFunctionToolStripMenuItem.Visible = true;
            }
            else
            {
                foreach (ToolStripItem item in contextMenuStrip1.Items)
                    item.Visible = true;
                objectFunctionToolStripMenuItem.Visible = false;
            }
        }
        private void findInTileset_Click(object sender, EventArgs e)
        {
            int index;
            if (state.SolidityLayer)
            {
                index = solidityMap.GetTileNum(solidity.PixelTiles[mousePosition.Y * 1024 + mousePosition.X]);
                if (!levels.OpenSolidTileset.Checked)
                    levels.OpenSolidTileset.PerformClick();
                levelsSolidTiles.Index = index;
                return;
            }
            if (state.SolidMods)
            {
                index = solidMods.Mod_.GetTileNum(solidity.PixelTiles[mousePosition.Y * 1024 + mousePosition.X]);
                if (!levels.OpenSolidTileset.Checked)
                    levels.OpenSolidTileset.PerformClick();
                levelsSolidTiles.Index = index;
                return;
            }
            int layer = 0;
            index = tileMap.GetTileNum(0, mousePosition.X, mousePosition.Y);
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
        private void exportToBattlefieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (overlay.Select == null)
            {
                MessageBox.Show("Must make a selection before exporting to battlefield.");
                return;
            }
            Tile16x16[] tileset = new Tile16x16[32 * 32];
            int counter = 0;
            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++, counter++)
                {
                    int tileX = overlay.Select.X + (x * 16);
                    int tileY = overlay.Select.Y + (y * 16);
                    int index = tileMap.GetTileNum(levelsTileset.Layer, tileX, tileY);
                    if (y < overlay.Select.Height / 16 && x < overlay.Select.Width / 16)
                        tileset[counter] = tileSet.TileSetLayers[levelsTileset.Layer][index].Copy();
                    else
                        tileset[counter] = new Tile16x16(counter);
                    tileset[counter].TileIndex = counter;
                }
            }
            counter = 256;
            for (int y = 0; y < 16; y++)
            {
                for (int x = 16; x < 32; x++, counter++)
                {
                    int tileX = overlay.Select.X + (x * 16);
                    int tileY = overlay.Select.Y + (y * 16);
                    int index = tileMap.GetTileNum(levelsTileset.Layer, tileX, tileY);
                    if (y < overlay.Select.Height / 16 && x < overlay.Select.Width / 16)
                        tileset[counter] = tileSet.TileSetLayers[levelsTileset.Layer][index].Copy();
                    else
                        tileset[counter] = new Tile16x16(counter);
                    tileset[counter].TileIndex = counter;
                }
            }
            counter = 512;
            for (int y = 16; y < 32; y++)
            {
                for (int x = 0; x < 16; x++, counter++)
                {
                    int tileX = overlay.Select.X + (x * 16);
                    int tileY = overlay.Select.Y + (y * 16);
                    int index = tileMap.GetTileNum(levelsTileset.Layer, tileX, tileY);
                    if (y < overlay.Select.Height / 16 && x < overlay.Select.Width / 16)
                        tileset[counter] = tileSet.TileSetLayers[levelsTileset.Layer][index].Copy();
                    else
                        tileset[counter] = new Tile16x16(counter);
                    tileset[counter].TileIndex = counter;
                }
            }
            counter = 768;
            for (int y = 16; y < 32; y++)
            {
                for (int x = 16; x < 32; x++, counter++)
                {
                    int tileX = overlay.Select.X + (x * 16);
                    int tileY = overlay.Select.Y + (y * 16);
                    int index = tileMap.GetTileNum(levelsTileset.Layer, tileX, tileY);
                    if (y < overlay.Select.Height / 16 && x < overlay.Select.Width / 16)
                        tileset[counter] = tileSet.TileSetLayers[levelsTileset.Layer][index].Copy();
                    else
                        tileset[counter] = new Tile16x16(counter);
                    tileset[counter].TileIndex = counter;
                }
            }
            Battlefield battlefield = new Battlefield(Model.Data, 0);
            battlefield.GraphicSetA = levelMap.GraphicSetA;
            battlefield.GraphicSetB = levelMap.GraphicSetB;
            battlefield.GraphicSetC = levelMap.GraphicSetC;
            battlefield.GraphicSetD = levelMap.GraphicSetD;
            battlefield.GraphicSetE = levelMap.GraphicSetE;
            PaletteSet paletteset = this.tileSet.paletteSet.Copy();
            BattlefieldTileSet battlefieldTileset = new BattlefieldTileSet(battlefield, paletteset, tileset);
            battlefieldTileset.Battlefield = battlefield;
            battlefieldTileset.PaletteSet = paletteset;
            battlefieldTileset.TileSetLayer = tileset;
            Do.Export(battlefieldTileset, "tilemap_battlefield");
        }
        private void objectFunctionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (objectFunctionToolStripMenuItem.Text == "Load destination")
            {
                Exit exit = exits.Exits[(int)objectFunctionToolStripMenuItem.Tag];
                if (exit.ExitType == 0)
                    levels.Index = exit.Destination;
                else
                {
                    if (Model.Program.WorldMaps == null || !Model.Program.WorldMaps.Visible)
                        Model.Program.CreateWorldMapsWindow();
                    Model.Program.WorldMaps.Index_l = exit.Destination;
                    Model.Program.WorldMaps.BringToFront();
                }
            }
            else if (objectFunctionToolStripMenuItem.Text == "Edit event's script")
            {
                Event event_ = events.Events[(int)objectFunctionToolStripMenuItem.Tag];
                if (Model.Program.EventScripts == null || !Model.Program.EventScripts.Visible)
                    Model.Program.CreateEventScriptsWindow();
                Model.Program.EventScripts.EventName.SelectedIndex = 0;
                Model.Program.EventScripts.EventNum.Value = event_.RunEvent;
                Model.Program.EventScripts.BringToFront();
            }
            else if (objectFunctionToolStripMenuItem.Text == "Edit npc's script")
            {
                List<int> tag = (List<int>)objectFunctionToolStripMenuItem.Tag;
                NPC npc = npcs.Npcs[tag[0]];
                NPC instance = null;
                if (npc.Instances.Count > 0 && tag[1] >= 0)
                    instance = npc.Instances[tag[1]];
                if (Model.Program.EventScripts == null || !Model.Program.EventScripts.Visible)
                    Model.Program.CreateEventScriptsWindow();
                Model.Program.EventScripts.EventName.SelectedIndex = 0;
                if (instance == null)
                    Model.Program.EventScripts.EventNum.Value = npc.EventORpack + npc.PropertyB;
                else
                    Model.Program.EventScripts.EventNum.Value = npc.EventORpack + instance.PropertyB;
                Model.Program.EventScripts.BringToFront();
            }
            else if (objectFunctionToolStripMenuItem.Text == "Edit npc's formation pack")
            {
                List<int> tag = (List<int>)objectFunctionToolStripMenuItem.Tag;
                NPC npc = npcs.Npcs[tag[0]];
                NPC instance = null;
                if (npc.Instances.Count > 0 && tag[1] >= 0)
                    instance = npc.Instances[tag[1]];
                if (Model.Program.Formations == null || !Model.Program.Formations.Visible)
                    Model.Program.CreateFormationsWindow();
                int pack = npc.EventORpack + (instance == null ? npc.PropertyB : instance.PropertyB);
                Model.Program.Formations.PackIndex = pack;
                Model.Program.Formations.FormationIndex = Model.FormationPacks[pack].PackFormations[0];
                Model.Program.Formations.BringToFront();
            }
        }
        #endregion
    }
}
