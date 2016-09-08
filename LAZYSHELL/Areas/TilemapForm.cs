using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using LazyShell.Areas;
using LazyShell.Minecart;
using LazyShell.Undo;

namespace LazyShell
{
    public partial class TilemapForm : Controls.DockForm
    {
        #region Variables

        #region Forms

        private Areas.OwnerForm areasForm;
        private Minecart.OwnerForm minecartForm;
        private MapEditor ownerForm
        {
            get
            {
                if (areasForm != null)
                    return areasForm;
                else
                    return minecartForm;
            }
        }
        private TilesetForm tilesetForm
        {
            get { return ownerForm.TilesetForm; }
            set { ownerForm.TilesetForm = value; }
        }
        private CollisionTileForm collisionTileForm
        {
            get { return areasForm.CollisionTileForm; }
            set { areasForm.CollisionTileForm = value; }
        }
        private ChunksForm chunksForm
        {
            get { return areasForm.ChunksForm; }
            set { areasForm.ChunksForm = value; }
        }
        private PaletteEditor paletteEditor
        {
            get { return ownerForm.PaletteEditor; }
            set { ownerForm.PaletteEditor = value; }
        }
        private OpacityForm opacityForm;
        private TilemapUpdater updater
        {
            get { return ownerForm.TilemapUpdater; }
            set { ownerForm.TilemapUpdater = value; }
        }

        #endregion

        #region Tilemap

        private Tilemap tilemap
        {
            get { return ownerForm.Tilemap; }
            set { ownerForm.Tilemap = value; }
        }
        private Tileset tileset
        {
            get { return ownerForm.Tileset; }
            set { ownerForm.Tileset = value; }
        }
        private CollisionMap collisionMap
        {
            get
            {
                if (areasForm != null)
                    return areasForm.CollisionMap;
                return null;
            }
            set
            {
                if (areasForm != null)
                    areasForm.CollisionMap = value;
            }
        }
        private Collision collision;
        /// <summary>
        /// The value of an empty tile according to the current tilemap type.
        /// </summary>
        private int emptyTile
        {
            get
            {
                if (minecartForm != null && minecartForm.Index < 2)
                    return 0x4F;
                else
                    return 0;
            }
        }

        // Overlay
        private State state;
        private Overlay overlay
        {
            get { return ownerForm.Overlay; }
            set { ownerForm.Overlay = value; }
        }

        #endregion

        #region Elements

        private Area area
        {
            get { return areasForm.Area; }
            set { areasForm.Area = value; }
        }
        private Map areaMap
        {
            get { return areasForm.Map; }
        }
        private Layering layering
        {
            get { return area.Layering; }
        }
        private ExitTriggerCollection exitTriggers
        {
            get { return area.ExitTriggers; }
            set { area.ExitTriggers = value; }
        }
        private EventTriggerCollection eventTriggers
        {
            get { return area.EventTriggers; }
            set { area.EventTriggers = value; }
        }
        private NPCObjectCollection npcObjects
        {
            get { return area.NPCObjects; }
            set { area.NPCObjects = value; }
        }
        private OverlapCollection overlaps
        {
            get { return area.Overlaps; }
            set { area.Overlaps = value; }
        }
        private TileSwitchCollection tileSwitches
        {
            get { return area.TileSwitches; }
            set { area.TileSwitches = value; }
        }
        private TileSwitch tileSwitch
        {
            get { return areasForm.TileSwitchesForm.TileSwitch; }
            set { areasForm.TileSwitchesForm.TileSwitch = value; }
        }
        private CollisionSwitchCollection collisionSwitches
        {
            get { return area.CollisionSwitches; }
            set { area.CollisionSwitches = value; }
        }
        private CollisionSwitch collisionSwitch
        {
            get { return areasForm.CollisionSwitchesForm.CollisionSwitch; }
            set { areasForm.CollisionSwitchesForm.CollisionSwitch = value; }
        }
        private CollisionTile[] collisionTiles
        {
            get { return Areas.Model.CollisionTiles; }
        }
        private MinecartObject[] mushrooms
        {
            get
            {
                if (minecartForm.Index == 0)
                    return minecartForm.MinecartData.Mode7ObjectsA;
                else if (minecartForm.Index == 1)
                    return minecartForm.MinecartData.Mode7ObjectsB;
                return null;
            }
            set
            {
                if (minecartForm.Index == 0)
                    minecartForm.MinecartData.Mode7ObjectsA = value;
                else if (minecartForm.Index == 1)
                    minecartForm.MinecartData.Mode7ObjectsB = value;
            }
        }
        private Chunk chunk
        {
            get { return chunksForm.Chunk; }
        }

        #endregion

        #region Command stacks

        private UndoStack commandStack;
        private UndoStack commandStack_C;
        private UndoStack commandStack_TM;
        private UndoStack commandStack_CM;
        private int commandCount;

        #endregion

        #region Selection

        private Bitmap selection;
        private Bitmap selcollision;
        private Point selcollision_area;
        private CopyBuffer draggedTiles;
        private CopyBuffer copiedTiles;
        private bool defloating;

        #endregion

        #region Mouse behavior

        private MapObject mouseOverObject;
        private int mouseOverTile;
        private int mouseOverCollisionTile;
        private int mouseOverNPC;
        private int mouseOverNPCReference;
        private int mouseOverExitTrigger;
        private int mouseOverEventField;
        private int mouseOverOverlap;
        private int mouseOverTileSwitch;
        private int mouseOverCollisionSwitch;
        private int mouseOverCollisionTileNum
        {
            get
            {
                return Bits.GetShort(collisionMap.Tilemap_bytes, mouseOverCollisionTile * 2);
            }
        }
        private int mouseOverMushroom;
        private MapObject mouseDownObject;
        private int mouseDownNPC;
        private int mouseDownExitTrigger;
        private int mouseDownEventTrigger;
        private int mouseDownOverlap;
        private int mouseDownCollisionTile;
        private int mouseDownCollisionTileNum
        {
            get
            {
                return Bits.GetShort(collisionMap.Tilemap_bytes, mouseDownCollisionTile * 2);
            }
        }
        private int mouseDownCollisionTileIndex;
        private int mouseDownTileSwitch;
        private int mouseDownCollisionSwitch;
        private int mouseDownMushroom;
        private Point mousePosition;
        private Point mouseDownPosition;
        private Point mouseTilePosition
        {
            get
            {
                return new Point(
                    Math.Min(63, mousePosition.X / 16),
                    Math.Min(63, mousePosition.Y / 16));
            }
        }
        private Point mouseIsometricPosition;
        private Point mouseLastIsometricPosition;
        private Point mouseDownIsometricPosition;
        private Point autoScrollPos;
        private bool mouseWithinSameBounds;
        private bool mouseEnter;

        #endregion

        #region Picture

        private Bitmap tilemapImage;
        private Bitmap p1TilemapImage;
        private Bitmap p1CollisionMapImage;
        //
        public Controls.NewPictureBox Picture
        {
            get { return picture; }
            set { picture = value; }
        }
        private int width
        {
            get { return tilemap.Width_p; }
        }
        private int height
        {
            get { return tilemap.Height_p; }
        }
        public int Zoom
        {
            get { return picture.Zoom; }
            set { picture.Zoom = value; }
        }

        #endregion

        #endregion

        // Areas
        public TilemapForm(Areas.OwnerForm areasForm)
        {
            this.areasForm = areasForm;
            //this.MdiParent = areasForm;
            //
            InitializeComponent();
            //
            InitializeVariables();
            InitializeCommandStacks();
            InitializeForms();
            CheckToolStripButtons();
            HideToolStripButtons();
            SetPictureBoxSize();
            SetTilemapImage();
        }
        public void Reload(Areas.OwnerForm areasForm)
        {
            this.areasForm = areasForm;
            //
            if (this.area != area)
                InitializeCommandStacks();
            else
                RefreshCommandStacks();
            SetPictureBoxSize();
            SetTilemapImage();
        }

        // Minecart
        public TilemapForm(Minecart.OwnerForm minecartForm)
        {
            this.minecartForm = minecartForm;
            //
            InitializeComponent();
            //
            InitializeVariables();
            InitializeForms();
            HideToolStripButtons();
            SetPictureBoxSize();
            SetTilemapImage();
        }
        public void Reload(Minecart.OwnerForm minecartForm)
        {
            this.minecartForm = minecartForm;
            //
            HideToolStripButtons();
            SetPictureBoxSize();
            SetTilemapImage();
        }

        #region Methods

        #region Initialization

        private void InitializeVariables()
        {
            if (this.areasForm != null)
                this.state = State.Instance;
            else
                this.state = State.Instance2;
            this.collision = Collision.Instance;
            //
            defloating = false;
            p1TilemapImage = null;
            p1CollisionMapImage = null;
            draggedTiles = null;
            selection = null;
            overlay.Select.Clear();
            selcollision_area = new Point(-1, -1);

            // Mouse variables
            mouseOverObject = MapObject.None;
            mouseOverTile = 0;
            mouseOverCollisionTile = 0;
            mouseOverNPC = -1;
            mouseOverNPCReference = -1;
            mouseOverExitTrigger = -1;
            mouseOverEventField = -1;
            mouseOverOverlap = -1;
            mouseOverTileSwitch = 0;
            mouseOverCollisionSwitch = 0;
            mouseOverMushroom = -1;
            mouseDownObject = MapObject.None;
            mouseDownNPC = -1;
            mouseDownExitTrigger = -1;
            mouseDownEventTrigger = -1;
            mouseDownOverlap = -1;
            mouseDownCollisionTile = 0;
            mouseDownCollisionTileIndex = -1;
            mouseDownTileSwitch = 0;
            mouseDownCollisionSwitch = 0;
            mouseDownMushroom = -1;
            mousePosition = new Point(0, 0);
            mouseDownPosition = new Point(0, 0);
            mouseIsometricPosition = new Point(0, 0);
            mouseLastIsometricPosition = new Point(0, 0);
            mouseDownIsometricPosition = new Point(0, 0);
            autoScrollPos = new Point();
            mouseWithinSameBounds = false;
            mouseEnter = false;
        }
        private void InitializeCommandStacks()
        {
            this.commandCount = 0;
            this.commandStack = new UndoStack(true);
            if (this.areasForm != null)
            {
                this.commandStack_C = new UndoStack(true);
                this.commandStack_TM = new UndoStack(true);
                this.commandStack_CM = new UndoStack(true);
            }
        }
        private void InitializeForms()
        {
            this.opacityForm = new OpacityForm(picture, overlay);
            this.opacityForm.ToggleButton = toggleOpacityLevel;
            this.opacityForm.Owner = this;
        }
        private void RefreshCommandStacks()
        {
            this.commandStack.SetTilemaps(tilemap);
            this.commandStack_C.SetCollisionMaps(collisionMap);
        }
        private void CheckToolStripButtons()
        {
            // Areas and minecarts
            toggleBG.Checked = state.BG;
            toggleTileGrid.Checked = state.TileGrid;
            toggleEvents.Checked = state.Events;
            toggleExits.Checked = state.Exits;
            toggleL1.Checked = state.Layer1;
            toggleL2.Checked = state.Layer2;
            toggleL3.Checked = state.Layer3;
            toggleMask.Checked = state.Mask;
            toggleNPCs.Checked = state.NPCs;
            toggleIsometricGrid.Checked = state.IsometricGrid;
            toggleOverlaps.Checked = state.Overlaps;
            toggleP1.Checked = state.Priority1;
            toggleCollisionMap.Checked = state.CollisionMap;
            toggleCollisionSwitches.Checked = state.CollisionSwitches;
            toggleTileSwitches.Checked = state.TileSwitches;
            // Minecarts
            toggleMushrooms.Checked = state.Mushrooms;
            toggleRails.Checked = state.Rails;
        }
        /// <summary>
        /// Hides the ToolStrip buttons not relevant to the current tilemap type.
        /// </summary>
        private void HideToolStripButtons()
        {
            if (areasForm != null)
            {
                toggleMushrooms.Visible = false;
                toggleRails.Visible = false;
            }
            if (minecartForm != null)
            {
                toggleBG.Visible = false;
                toggleMushrooms.Visible = minecartForm.Index < 2;
                toggleRails.Visible = minecartForm.Index < 2;
                toggleEvents.Visible = false;
                toggleExits.Visible = false;
                toggleL1.Visible = false;
                toggleL2.Visible = false;
                toggleL3.Visible = false;
                toggleMask.Visible = false;
                toggleNPCs.Visible = false;
                toggleIsometricGrid.Visible = false;
                toggleOverlaps.Visible = false;
                toggleP1.Visible = minecartForm.Index > 1;
                toggleCollisionMap.Visible = false;
                toggleCollisionSwitches.Visible = false;
                toggleTileSwitches.Visible = false;
                toggleTags.Visible = false;
                //
                editAllLayers.Visible = false;
                editDragCollisionTile.Visible = false;
                editChunk.Visible = false;
                toolStripSeparator2.Visible = false;
                toolStripSeparator10.Visible = false;
                toolStripSeparator1.Visible = false;
                toolStripSeparator14.Visible = false;
                toolStripSeparator15.Visible = false;
                toolStripSeparator23.Visible = false;
            }
        }
        private void SetPictureBoxSize()
        {
            this.picture.Size = new Size(tilemap.Width_p * Zoom, tilemap.Height_p * Zoom);
            this.picture.ZoomBoxPosition = new Point(64, 0);
        }
        public void SetTilemapImage()
        {
            int[] pixels = tilemap.Pixels;
            tilemapImage = Do.PixelsToImage(pixels, tilemap.Width_p, tilemap.Height_p);
            picture.Invalidate();
        }

        #endregion

        #region Updating

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
        private void ToggleTilesets()
        {
            if (toggleCollisionSwitches.Checked || toggleCollisionMap.Checked)
                collisionTileForm.Show(this.DockPanel, WeifenLuo.WinFormsUI.Docking.DockState.DockRight);
        }

        #endregion

        /// <summary>
        /// Compares the selected tiles in the tileset to a region in the tilemap.
        /// </summary>
        /// <param name="x">The X coordinate of the region in the tilemap.</param>
        /// <param name="y">The Y coordinate of the region in the tilemap.</param>
        /// <param name="layer">The layer of the region in the tilemap.</param>
        /// <returns></returns>
        private bool CompareTiles(int x, int y, int layer)
        {
            Tilemap tilemap = null;
            if (state.TileSwitches && tileSwitch != null)
                tilemap = !areasForm.TileSwitchesForm.AlternateSelected ? tileSwitch.TilemapA : tileSwitch.TilemapB;
            else
                tilemap = this.tilemap;
            for (int b = overlay.SelectTS.Y; b < overlay.SelectTS.Terminal.Y; b += 16, y += 16)
            {
                for (int a = overlay.SelectTS.X; a < overlay.SelectTS.Terminal.X; a += 16, x += 16)
                {
                    if (tilemap.GetTileNum(layer, x, y) != tileset.GetTileNum(layer, a / 16, b / 16))
                        return false;
                }
            }
            return true;
        }
        private void DrawHoverBox(Graphics g)
        {
            int mouseOverCollisionTileNum = 0;
            if (state.CollisionSwitches && collisionSwitches.CollisionSwitches.Count != 0)
                mouseOverCollisionTileNum = Bits.GetShort(collisionSwitch.Tilemap_bytes, mouseOverCollisionTile * 2);
            if (state.CollisionMap && mouseOverCollisionTileNum == 0)  // if collision switch map empty, check if collision map empty
                mouseOverCollisionTileNum = Bits.GetShort(collisionMap.Tilemap_bytes, mouseOverCollisionTile * 2);
            if ((state.CollisionMap || state.CollisionSwitches) && mouseOverCollisionTileNum != 0)
            {
                var image = collisionTiles[mouseOverCollisionTileNum].GetHighlightedImage();
                var p = new Point(
                    collision.TileCoords[mouseOverCollisionTile].X * Zoom,
                    collision.TileCoords[mouseOverCollisionTile].Y * Zoom - (768 * Zoom));
                var rsrc = new Rectangle(0, 0, 32, 784);
                var rdst = new Rectangle(p.X, p.Y, Zoom * 32, Zoom * 784);
                g.DrawImage(image, rdst, rsrc, GraphicsUnit.Pixel);
            }
            else if (state.CollisionMap || state.CollisionSwitches || state.NPCs || state.Exits || state.Events || state.Overlaps)
            {
                var p = new Point(
                    collision.TileCoords[mouseOverCollisionTile].X * Zoom,
                    collision.TileCoords[mouseOverCollisionTile].Y * Zoom);
                var points = new Point[] { 
                    new Point(p.X + (15 * Zoom), p.Y), 
                    new Point(p.X - (1 * Zoom), p.Y + (8 * Zoom)), 
                    new Point(p.X + (16 * Zoom), p.Y + (8 * Zoom)), 
                    new Point(p.X + (16 * Zoom), p.Y)
                };
                g.FillPolygon(new SolidBrush(Color.FromArgb(96, 0, 0, 0)), points, System.Drawing.Drawing2D.FillMode.Winding);
                points = new Point[] { 
                    new Point(p.X + (17 * Zoom), p.Y), 
                    new Point(p.X + (33 * Zoom), p.Y + (8 * Zoom)), 
                    new Point(p.X + (16 * Zoom), p.Y + (8 * Zoom)), 
                    new Point(p.X + (16 * Zoom), p.Y)
                };
                g.FillPolygon(new SolidBrush(Color.FromArgb(96, 0, 0, 0)), points, System.Drawing.Drawing2D.FillMode.Winding);
                points = new Point[] { 
                    new Point(p.X + (15 * Zoom), p.Y + (16 * Zoom)), 
                    new Point(p.X - (1 * Zoom), p.Y + (8 * Zoom)), 
                    new Point(p.X + (16 * Zoom), p.Y + (8 * Zoom)), 
                    new Point(p.X + (16 * Zoom), p.Y + (16 * Zoom))
                };
                g.FillPolygon(new SolidBrush(Color.FromArgb(96, 0, 0, 0)), points, System.Drawing.Drawing2D.FillMode.Winding);
                points = new Point[] { 
                    new Point(p.X + (17 * Zoom), p.Y + (16 * Zoom)), 
                    new Point(p.X + (33 * Zoom), p.Y + (8 * Zoom)), 
                    new Point(p.X + (16 * Zoom), p.Y + (8 * Zoom)), 
                    new Point(p.X + (16 * Zoom), p.Y + (16 * Zoom))
                };
                g.FillPolygon(new SolidBrush(Color.FromArgb(96, 0, 0, 0)), points, System.Drawing.Drawing2D.FillMode.Winding);
            }
            else
            {
                var r = new Rectangle(mousePosition.X / 16 * 16 * Zoom, mousePosition.Y / 16 * 16 * Zoom, 16 * Zoom, 16 * Zoom);
                g.FillRectangle(new SolidBrush(Color.FromArgb(96, 0, 0, 0)), r);
            }
        }

        #region Tile editing

        private void Draw(Graphics g, int x, int y)
        {
            if (state.TileSwitches && tileSwitch != null)
            {
                int x_ = x - (tileSwitch.X * 16);
                int y_ = y - (tileSwitch.Y * 16);
                if (!tileSwitch.WithinBounds(x / 16, y / 16) ||
                    overlay.SelectTS.Width / 16 + (x_ / 16) > tileSwitch.Width ||
                    overlay.SelectTS.Height / 16 + (y_ / 16) > tileSwitch.Height)
                    return;
                x -= (tileSwitch.X * 16);
                y -= (tileSwitch.Y * 16);
            }
            if (state.CollisionSwitches && !collisionSwitch.WithinBounds(mouseOverCollisionTile * 2))
                return;
            Tilemap tilemap = null;
            if (state.TileSwitches && tileSwitch != null)
                tilemap = !areasForm.TileSwitchesForm.AlternateSelected ? tileSwitch.TilemapA : tileSwitch.TilemapB;
            else
                tilemap = this.tilemap;
            if (!state.CollisionMap && !state.CollisionSwitches)
            {
                int layer = tilesetForm.Layer;

                // cancel if no selection in the tileset is made
                if (overlay.SelectTS.Empty)
                    return;

                // cancel if layer doesn't exist
                if (this.tileset.Tilesets_tiles[layer] == null)
                    return;

                // cancel if writing same tile over itself
                if (CompareTiles(x, y, layer))
                    return;
                p1TilemapImage = null;
                var area = new Point(x, y);
                var terminal = new Point(
                    x + overlay.SelectTS.Width,
                    y + overlay.SelectTS.Height);
                bool transparent = minecartForm == null || minecartForm.Index > 1;

                // push command
                UndoStack commandStack = null;
                if (state.TileSwitches && tileSwitch != null)
                    commandStack = this.commandStack_TM;
                else
                    commandStack = this.commandStack;
                commandStack.Push(
                    new TilemapEdit(areasForm, tilemap, layer, area, terminal,
                        tilesetForm.SelectedTiles.Copies, false, transparent, editAllLayers.Checked));
                commandCount++;
                //
                if (state.TileSwitches && tileSwitch != null)
                    tileSwitches.UpdateTilemaps();

                // draw the tile
                var p = new Point(x / 16 * 16, y / 16 * 16);
                var image = Do.PixelsToImage(
                    tilemap.GetPixels(p, overlay.SelectTS.Size),
                    overlay.SelectTS.Width, overlay.SelectTS.Height);
                if (state.TileSwitches && tileSwitch != null)
                {
                    p.X += tileSwitch.X * 16;
                    p.Y += tileSwitch.Y * 16;
                }
                p.X *= Zoom;
                p.Y *= Zoom;
                var rsrc = new Rectangle(0, 0, image.Width, image.Height);
                var rdst = new Rectangle(p.X, p.Y, (int)(image.Width * Zoom), (int)(image.Height * Zoom));
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                if (!state.BG)
                    picture.Erase(rdst);
                g.DrawImage(image, rdst, rsrc, GraphicsUnit.Pixel);
            }
            else if (state.CollisionMap || state.CollisionSwitches)
            {
                // cancel if physical tile editor not open
                if (collisionTileForm == null)
                    return;

                // cancel if overwriting the same tile over itself
                Tilemap map = null;
                if (state.CollisionSwitches && collisionSwitch != null)
                    map = collisionSwitch;
                else
                    map = collisionMap;
                if (map.GetTileNum(mouseOverCollisionTile) == (ushort)collisionTileForm.Index)
                    return;
                var initial = new Point(x, y);
                var final = new Point(x + 1, y + 1);
                byte[] temp = new byte[0x20C2];
                Bits.SetShort(temp, mouseOverCollisionTile * 2, (ushort)collisionTileForm.Index);
                var commandStack_S = state.CollisionSwitches ? this.commandStack_CM : this.commandStack_C;
                commandStack_S.Push(new CollisionEdit(this.areasForm, map, initial, final, initial, temp));
                commandCount++;
                if (state.CollisionSwitches && collisionSwitch != null)
                    collisionSwitch.TilemapToTiles();
                collision.RefreshTilemapImage(map, mouseOverCollisionTile * 2);
                map.Image = null;
                p1CollisionMapImage = null;
                picture.Invalidate();
            }
        }
        private void Erase(Graphics g, int x, int y)
        {
            if (state.TileSwitches && tileSwitch != null)
            {
                if (!tileSwitch.WithinBounds(x / 16, y / 16))
                    return;
                x -= (tileSwitch.X * 16);
                y -= (tileSwitch.Y * 16);
            }
            if (state.CollisionSwitches && !collisionSwitch.WithinBounds(mouseOverCollisionTile * 2))
                return;
            Tilemap tilemap = null;
            if (state.TileSwitches && tileSwitch != null)
                tilemap = !areasForm.TileSwitchesForm.AlternateSelected ? tileSwitch.TilemapA : tileSwitch.TilemapB;
            else
                tilemap = this.tilemap;
            if (!state.CollisionMap && !state.CollisionSwitches)
            {
                int layer = tilesetForm.Layer;
                // cancel if overwriting the same tile over itself
                if (!editAllLayers.Checked && this.tileset.Tilesets_tiles[layer] == null)
                    return;
                if (!editAllLayers.Checked && tilemap.GetTileNum(layer, x, y) == emptyTile)
                    return;
                if (editAllLayers.Checked &&
                    tilemap.GetTileNum(0, x, y) == emptyTile &&
                    tilemap.GetTileNum(1, x, y) == emptyTile &&
                    tilemap.GetTileNum(2, x, y) == emptyTile)
                    return;
                //
                p1TilemapImage = null;
                bool transparent = minecartForm == null || minecartForm.Index > 1;
                UndoStack commandStack = null;
                if (state.TileSwitches && tileSwitch != null)
                    commandStack = this.commandStack_TM;
                else
                    commandStack = this.commandStack;
                commandStack.Push(
                    new TilemapEdit(
                        this.areasForm, tilemap, layer, new Point(x, y), new Point(x + 16, y + 16),
                        new int[][] { new int[] { emptyTile }, new int[] { emptyTile }, new int[] { emptyTile }, new int[] { emptyTile } },
                        false, transparent, editAllLayers.Checked));
                commandCount++;
                if (state.TileSwitches && tileSwitch != null)
                    tileSwitches.UpdateTilemaps();
                var p = new Point(x / 16 * 16, y / 16 * 16);
                var image = Do.PixelsToImage(tilemap.GetPixels(p, new Size(16, 16)), 16, 16);
                if (state.TileSwitches && tileSwitch != null)
                {
                    p.X += tileSwitch.X * 16;
                    p.Y += tileSwitch.Y * 16;
                }
                p.X *= Zoom; p.Y *= Zoom;
                var rsrc = new Rectangle(0, 0, 16, 16);
                var rdst = new Rectangle(p.X, p.Y, (int)(16 * Zoom), (int)(16 * Zoom));
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                if (!state.BG)
                    picture.Erase(rdst);
                g.DrawImage(image, rdst, rsrc, GraphicsUnit.Pixel);
            }
            else if (state.CollisionMap || state.CollisionSwitches)
            {
                // cancel if overwriting the same tile over itself
                if (collisionMap.GetTileNum(mouseOverCollisionTile) == 0)
                    return;
                var tL = new Point(x, y);
                var bR = new Point(x + 1, y + 1);
                Tilemap map = null;
                if (state.CollisionSwitches && collisionSwitch != null)
                    map = collisionSwitch;
                else
                    map = collisionMap;
                var commandStack_S = state.CollisionSwitches ? this.commandStack_CM : this.commandStack_C;
                commandStack_S.Push(new CollisionEdit(this.areasForm, map, tL, bR, tL, new byte[0x20C2]));
                commandCount++;
                if (state.CollisionSwitches && collisionSwitch != null)
                    collisionSwitch.TilemapToTiles();
                collision.RefreshTilemapImage(map, mouseOverCollisionTile * 2);
                map.Image = null;
                p1CollisionMapImage = null;
                picture.Invalidate();
            }
        }
        private void SelectColor(int x, int y)
        {
            var tilemap = this.tilemap;
            int layer = tilemap.GetPixelLayer(x, y);
            int tileNum = (y / 16) * (width / 16) + (x / 16);
            int placement = ((x % 16) / 8) + (((y % 16) / 8) * 2);
            var tile = this.tileset.Tilesets_tiles[layer][tilemap.GetTileNum(layer, x, y)];
            var subtile = tile.Subtiles[placement];
            int multiplier = layer < 2 ? 16 : 4;
            int index = ((y % 16) % 8) * 8 + ((x % 16) % 8);
            int color = (subtile.Palette * multiplier) + subtile.Colors[index];
            if (areasForm != null)
                areasForm.LoadPaletteEditor();
            else if (minecartForm != null)
                minecartForm.LoadPaletteEditor();
            if (color < paletteEditor.StartRow * 16)
                color = paletteEditor.StartRow * 16;
            paletteEditor.CurrentColor = color;
            paletteEditor.Location = new Point(Cursor.Position.X + 20, 20);
            paletteEditor.Show();
        }
        private void Fill(Graphics g, int x, int y)
        {
            var tilemap = this.tilemap;
            if (!state.CollisionMap)
            {
                int layer = tilesetForm.Layer;
                // cancel if no selection in the tileset is made
                if (overlay.SelectTS.Empty)
                    return;
                // cancel if layer doesn't exist
                if (this.tileset.Tilesets_tiles[layer] == null)
                    return;
                // cancel if writing same tile over itself
                if (CompareTiles(x, y, layer))
                    return;
                p1TilemapImage = null;
                // store changes
                int[][] changes = new int[3][];
                if (tilemap.Tilemaps_bytes[0] != null) changes[0] = new int[(width / 16) * (height / 16)];
                if (tilemap.Tilemaps_bytes[1] != null) changes[1] = new int[(width / 16) * (height / 16)];
                if (tilemap.Tilemaps_bytes[2] != null) changes[2] = new int[(width / 16) * (height / 16)];
                for (int l = 0; l < 3; l++)
                {
                    Tile[] tiles = tilemap.Tilemaps_tiles[l];
                    if (changes[l] == null) continue;
                    if (tiles == null) continue;
                    for (int i = 0; i < changes[l].Length && i < tiles.Length; i++)
                    {
                        if (tiles[i] == null) continue;
                        changes[l][i] = tiles[i].Index;
                    }
                }
                // fill up tiles
                var area = new Point(0, 0);
                var terminal = new Point(width, height);
                int[] fillTile = tilesetForm.SelectedTiles.Copies[layer];
                int tile = tilemap.GetTileNum(layer, x, y);
                int vwidth = overlay.SelectTS.Width / 16;
                int vheight = overlay.SelectTS.Height / 16;
                //
                if ((Control.ModifierKeys & Keys.Control) == 0)
                    Do.Fill(changes, layer, editAllLayers.Checked, tile, fillTile,
                        x / 16, y / 16, width / 16, height / 16, vwidth, vheight, "");
                else
                    // non-contiguous fill
                    for (int d = 0; d < height / 16; d += vheight)
                    {
                        for (int c = 0; c < width / 16; c += vwidth)
                        {
                            for (int b = 0; b < vheight; b++)
                            {
                                if (changes[layer][(d + b) * (width / 16) + c] != tile)
                                    break;
                                for (int a = 0; a < vwidth; a++)
                                {
                                    if (changes[layer][(d + b) * (width / 16) + c + a] != tile)
                                        break;
                                    changes[layer][(d + b) * (width / 16) + c + a] = fillTile[b * vwidth + a];
                                }
                            }
                        }
                    }
                bool transparent = minecartForm == null || minecartForm.Index > 1;
                commandStack.Push(
                    new TilemapEdit(areasForm, tilemap, layer, area, terminal, changes, false, transparent, false));
                commandCount++;
            }
            else
            {
                if (collisionMap.GetTileNum(mouseOverCollisionTile) == (ushort)collisionTileForm.Index)
                    return;
                ushort tile = (ushort)collisionMap.GetTileNum(mouseOverCollisionTile);
                ushort fillTile = (ushort)collisionTileForm.Index;
                byte[] changes = Bits.Copy(collisionMap.Tilemap_bytes);
                if ((Control.ModifierKeys & Keys.Control) == 0)
                    Do.Fill(changes, tile, fillTile, (mousePosition.X + 16) / 32 * 32, (mousePosition.Y + 8) / 16 * 16, width, height, "");
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
                        var tL = new Point(
                            collision.TileCoords[index].X + 16,
                            collision.TileCoords[index].Y + 8);
                        var bR = new Point(
                            collision.TileCoords[index].X + 17,
                            collision.TileCoords[index].Y + 9);
                        if (state.CollisionSwitches && collisionSwitch != null)
                            commandStack_C.Push(new CollisionEdit(areasForm, collisionSwitch, tL, bR, tL, changes));
                        else
                            commandStack_C.Push(new CollisionEdit(areasForm, collisionMap, tL, bR, tL, changes));
                        pushes++;
                    }
                }
                this.commandStack_C.Push(pushes);
                collisionMap.Image = null;
                p1CollisionMapImage = null;
                picture.Invalidate();
            }
        }
        //
        private void DrawChunk(Graphics g, int x, int y)
        {
            if (chunk == null)
            {
                MessageBox.Show("Must select a chunk to paint to the area.", "LAZY SHELL");
                return;
            }
            var tL = new Point(x / 16 * 16, y / 16 * 16);
            var bR = new Point((x / 16 * 16) + chunk.Size.Width, (y / 16 * 16) + chunk.Size.Height);
            if (chunk.IsEven != (((tL.X / 16) % 2) == 0))
            {
                tL.X += 16;
                bR.X += 16;
            }
            int[][] tiles = new int[3][];
            tiles[0] = new int[chunk.Tilemaps_bytes[0].Length / 2];
            tiles[1] = new int[chunk.Tilemaps_bytes[1].Length / 2];
            tiles[2] = new int[chunk.Tilemaps_bytes[2].Length];
            for (int i = 0; i < tiles[0].Length; i++)
            {
                tiles[0][i] = Bits.GetShort(chunk.Tilemaps_bytes[0], i * 2);
                tiles[1][i] = Bits.GetShort(chunk.Tilemaps_bytes[1], i * 2);
                tiles[2][i] = chunk.Tilemaps_bytes[2][i];
            }
            commandStack.Push(new TilemapEdit(this.areasForm, tilemap, 0, tL, bR, tiles, true, true, true));
            commandStack_C.Push(new CollisionEdit(this.areasForm, this.collisionMap, tL, bR, chunk.Start, chunk.CollisionMap_bytes));
            commandCount++;
            collisionMap.Image = null;
            tilemap.RedrawTilemaps();
            tileSwitches.RedrawTilemaps();
            SetTilemapImage();
        }

        #endregion

        #region Selection editing

        private void Cut()
        {
            if (overlay.Select.Empty || overlay.Select.Size == new Size(0, 0))
                return;
            if (state.CollisionMap || state.CollisionSwitches)
                return;
            Copy();
            Delete();
            if (commandCount > 0)
            {
                commandStack.Push(commandCount);
                commandCount = 0;
            }
        }
        private void Copy()
        {
            if (overlay.Select.Empty || overlay.Select.Size == new Size(0, 0))
                return;
            if (state.CollisionMap || state.CollisionSwitches)
                return;
            if (draggedTiles != null)
            {
                this.copiedTiles = draggedTiles;
                return;
            }
            int layer = tilesetForm.Layer;
            Tilemap tilemap = null;
            var area = overlay.Select.Location;
            if (state.TileSwitches && tileSwitch != null)
            {
                if (!tileSwitch.WithinBounds(area.X / 16, area.Y / 16))
                    return;
                tilemap = !areasForm.TileSwitchesForm.AlternateSelected ? tileSwitch.TilemapA : tileSwitch.TilemapB;
                area.X -= tileSwitch.X * 16;
                area.Y -= tileSwitch.Y * 16;
            }
            else
                tilemap = this.tilemap;
            if (editAllLayers.Checked)
                selection = Do.PixelsToImage(
                    tilemap.GetPixels(area, overlay.Select.Size),
                    overlay.Select.Width, overlay.Select.Height);
            else
                selection = Do.PixelsToImage(
                    tilemap.GetPixels(layer, area, overlay.Select.Size),
                    overlay.Select.Width, overlay.Select.Height);
            int[][] copiedTiles = new int[3][];
            this.copiedTiles = new CopyBuffer(overlay.Select.Width, overlay.Select.Height);
            for (int l = 0; l < 3; l++)
            {
                copiedTiles[l] = new int[(overlay.Select.Width / 16) * (overlay.Select.Height / 16)];
                for (int y = 0; y < overlay.Select.Height / 16; y++)
                {
                    for (int x = 0; x < overlay.Select.Width / 16; x++)
                    {
                        int tileX = area.X + (x * 16);
                        int tileY = area.Y + (y * 16);
                        copiedTiles[l][y * (overlay.Select.Width / 16) + x] = tilemap.GetTileNum(l, tileX, tileY);
                    }
                }
            }
            this.copiedTiles.Copies = copiedTiles;
        }
        private void Paste(Point area, CopyBuffer buffer)
        {
            if (state.CollisionMap || state.CollisionSwitches)
                return;
            if (buffer == null)
                return;
            if (!editSelect.Checked)
                editSelect.PerformClick();
            state.Move = true;
            // now dragging a new selection
            draggedTiles = buffer;
            overlay.Select.Set(16, area, buffer.Size, Picture);
            picture.Invalidate();
            defloating = false;
            //areas.AlertLabel();
        }
        private void Delete()
        {
            if (overlay.Select.Empty)
                return;
            if (overlay.Select.Size == new Size(0, 0))
                return;
            if (!state.CollisionMap && !state.CollisionSwitches)
            {
                int layer = tilesetForm.Layer;
                if (this.tileset.Tilesets_tiles[layer] == null)
                    return;
                if (overlay.Select.Empty)
                    return;
                var area = overlay.Select.Location;
                var terminal = overlay.Select.Terminal;
                int[][] changes = new int[][]{
                    new int[overlay.Select.Width * overlay.Select.Height],
                    new int[overlay.Select.Width * overlay.Select.Height],
                    new int[overlay.Select.Width * overlay.Select.Height],
                    new int[overlay.Select.Width * overlay.Select.Height]};
                if (emptyTile != 0)
                    for (int i = 0; i < 4; i++)
                        Bits.Fill(changes[i], emptyTile);
                // Verify layer before creating command
                Tilemap tilemap = null;
                if (state.TileSwitches && tileSwitch != null)
                {
                    if (!tileSwitch.WithinBounds(area.X / 16, area.Y / 16))
                        return;
                    tilemap = !areasForm.TileSwitchesForm.AlternateSelected ? tileSwitch.TilemapA : tileSwitch.TilemapB;
                    area.X -= (tileSwitch.X * 16);
                    area.Y -= (tileSwitch.Y * 16);
                    terminal.X -= (tileSwitch.X * 16);
                    terminal.Y -= (tileSwitch.Y * 16);
                }
                else
                    tilemap = this.tilemap;
                bool transparent = minecartForm == null || minecartForm.Index > 1;
                UndoStack commandStack = null;
                if (state.TileSwitches && tileSwitch != null)
                    commandStack = this.commandStack_TM;
                else
                    commandStack = this.commandStack;
                commandStack.Push(
                    new TilemapEdit(
                        areasForm, tilemap, layer, area, terminal,
                        changes, false, transparent, editAllLayers.Checked));
                commandCount++;
                p1TilemapImage = null;
                SetTilemapImage();
                if (area != null)
                    tileSwitches.ClearImages();
            }
            else
            {
                int index = 0;
                int pushes = 0;
                Tilemap map = null;
                UndoStack commandStack_S = null;
                if (state.CollisionSwitches && collisionSwitch != null)
                {
                    map = collisionSwitch;
                    commandStack_S = this.commandStack_CM;
                }
                else
                {
                    map = collisionMap;
                    commandStack_S = this.commandStack_C;
                }
                for (int y = overlay.Select.Y; y < overlay.Select.Y + overlay.Select.Height; y++)
                {
                    for (int x = overlay.Select.X; x < overlay.Select.X + overlay.Select.Width; x++)
                    {
                        if (index == collision.PixelTiles[y * width + x])
                            continue;
                        index = collision.PixelTiles[y * width + x];
                        if (map.GetTileNum(index) == 0)
                            continue;
                        Point tL = new Point(
                            collision.TileCoords[index].X + 16,
                            collision.TileCoords[index].Y + 8);
                        Point bR = new Point(
                            collision.TileCoords[index].X + 17,
                            collision.TileCoords[index].Y + 9);
                        commandStack_S.Push(new CollisionEdit(areasForm, map, tL, bR, tL, new byte[0x20C2]));
                        pushes++;
                    }
                }
                commandStack_S.Push(pushes);
                if (!state.CollisionSwitches)
                    p1CollisionMapImage = null;
                else
                    map.Pixels = Collision.Instance.GetTilemapPixels(map);
                map.Image = null;
                picture.Invalidate();
            }
        }
        /// <summary>
        /// Start dragging the current selection.
        /// </summary>
        private void Drag()
        {
            if (overlay.Select.Empty || overlay.Select.Size == new Size(0, 0))
                return;
            if (!state.CollisionMap && !state.CollisionSwitches)
            {
                int layer = tilesetForm.Layer;
                var area = overlay.Select.Location;
                Tilemap tilemap = null;
                if (state.TileSwitches && tileSwitch != null)
                {
                    if (!tileSwitch.WithinBounds(area.X / 16, area.Y / 16))
                        return;
                    tilemap = !areasForm.TileSwitchesForm.AlternateSelected ? tileSwitch.TilemapA : tileSwitch.TilemapB;
                    area.X -= (tileSwitch.X * 16);
                    area.Y -= (tileSwitch.Y * 16);
                }
                else
                {
                    area = overlay.Select.Location;
                    tilemap = this.tilemap;
                }
                if (editAllLayers.Checked)
                    selection = Do.PixelsToImage(
                        tilemap.GetPixels(area, overlay.Select.Size),
                        overlay.Select.Width, overlay.Select.Height);
                else
                    selection = Do.PixelsToImage(
                        tilemap.GetPixels(layer, area, overlay.Select.Size),
                        overlay.Select.Width, overlay.Select.Height);
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
                            if (state.TileSwitches && tileSwitch != null)
                            {
                                tileX -= tileSwitch.X * 16;
                                tileY -= tileSwitch.Y * 16;
                            }
                            copiedTiles[l][y * (overlay.Select.Width / 16) + x] = tilemap.GetTileNum(l, tileX, tileY);
                        }
                    }
                }
                this.draggedTiles.Copies = copiedTiles;
            }
            Delete();
        }
        /// <summary>
        /// Defloats either a dragged selection or a newly pasted selection.
        /// </summary>
        /// <param name="buffer">The dragged selection or the newly pasted selection.</param>
        private void Defloat(CopyBuffer buffer)
        {
            if (state.CollisionMap || state.CollisionSwitches)
                return;
            if (buffer == null)
                return;
            if (overlay.Select.Empty)
                return;
            var area = new Point();
            area.X = overlay.Select.X / 16 * 16;
            area.Y = overlay.Select.Y / 16 * 16;
            int layer = tilesetForm.Layer;
            Tilemap tilemap = null;
            if (state.TileSwitches && tileSwitch != null)
            {
                if (!tileSwitch.WithinBounds(area.X / 16, area.Y / 16))
                    return;
                area.X -= tileSwitch.X * 16;
                area.Y -= tileSwitch.Y * 16;
                tilemap = !areasForm.TileSwitchesForm.AlternateSelected ? tileSwitch.TilemapA : tileSwitch.TilemapB;
            }
            else
                tilemap = this.tilemap;
            var terminal = new Point(area.X + buffer.Width, area.Y + buffer.Height);
            bool transparent = minecartForm == null || minecartForm.Index > 1;
            UndoStack commandStack = null;
            if (state.TileSwitches && tileSwitch != null)
                commandStack = this.commandStack_TM;
            else
                commandStack = this.commandStack;
            commandStack.Push(
                new TilemapEdit(areasForm, tilemap, layer, area, terminal, buffer.Copies, true, transparent, editAllLayers.Checked));
            commandStack.Push(commandCount + 1);
            commandCount = 0;
            p1TilemapImage = null;
            SetTilemapImage();
            if (area != null)
                tileSwitches.ClearImages();
            defloating = true;
        }
        /// <summary>
        /// Defloats pasted tiles and clears the selection.
        /// </summary>
        private void Defloat()
        {
            if (copiedTiles != null && !defloating)
                Defloat(copiedTiles);
            if (draggedTiles != null)
            {
                Defloat(draggedTiles);
                draggedTiles = null;
            }
            state.Move = false;
            overlay.Select.Clear();
            Cursor.Position = Cursor.Position;
        }

        #endregion

        #region Undo / Redo

        private void Undo()
        {
            if (!state.CollisionMap && !state.CollisionSwitches)
            {
                if (!state.TileSwitches)
                    commandStack.UndoCommand();
                else if (state.TileSwitches && tileSwitch != null)
                    commandStack_TM.UndoCommand();
                p1TilemapImage = null;
                SetTilemapImage();
                if (area != null)
                    tileSwitches.ClearImages();
            }
            else
            {
                if (!state.CollisionSwitches)
                {
                    commandStack_C.UndoCommand();
                    collisionMap.Image = null;
                    p1CollisionMapImage = null;
                }
                if (state.CollisionSwitches && collisionSwitch != null)
                {
                    commandStack_CM.UndoCommand();
                    collisionSwitch.TilemapToTiles();
                    collisionSwitch.Pixels = Collision.Instance.GetTilemapPixels(collisionSwitch);
                    collisionSwitch.Image = null;
                }
                picture.Invalidate();
            }
        }
        private void Redo()
        {
            if (!state.CollisionMap && !state.CollisionSwitches)
            {
                if (!state.TileSwitches)
                    commandStack.RedoCommand();
                else if (state.TileSwitches && tileSwitch != null)
                    commandStack_TM.RedoCommand();
                p1TilemapImage = null;
                SetTilemapImage();
                if (area != null)
                    tileSwitches.ClearImages();
            }
            else
            {
                if (!state.CollisionSwitches)
                {
                    commandStack_C.RedoCommand();
                    collisionMap.Image = null;
                    p1CollisionMapImage = null;
                }
                else if (state.CollisionSwitches && collisionSwitch != null)
                {
                    commandStack_CM.RedoCommand();
                    collisionSwitch.TilemapToTiles();
                    collisionSwitch.Pixels = Collision.Instance.GetTilemapPixels(collisionSwitch);
                    collisionSwitch.Image = null;
                }
                picture.Invalidate();
            }
        }

        #endregion

        #region Set MouseOver object

        private void SetMouseOverMask()
        {
            if (mouseTilePosition.X == layering.MaskLowX && mouseTilePosition.Y == layering.MaskLowY)
            {
                picture.Cursor = Cursors.SizeNWSE;
                mouseOverObject = MapObject.MaskNW;
            }
            else if (mouseTilePosition.X == layering.MaskLowX && mouseTilePosition.Y == layering.MaskHighY)
            {
                picture.Cursor = Cursors.SizeNESW;
                mouseOverObject = MapObject.MaskSW;
            }
            else if (mouseTilePosition.X == layering.MaskHighX && mouseTilePosition.Y == layering.MaskLowY)
            {
                picture.Cursor = Cursors.SizeNESW;
                mouseOverObject = MapObject.MaskNE;
            }
            else if (mouseTilePosition.X == layering.MaskHighX && mouseTilePosition.Y == layering.MaskHighY)
            {
                picture.Cursor = Cursors.SizeNWSE;
                mouseOverObject = MapObject.MaskSE;
            }
            else if (mouseTilePosition.X == layering.MaskLowX &&
                mouseTilePosition.Y <= layering.MaskHighY && mouseTilePosition.Y >= layering.MaskLowY)
            {
                picture.Cursor = Cursors.SizeWE;
                mouseOverObject = MapObject.MaskW;
            }
            else if (mouseTilePosition.Y == layering.MaskLowY &&
                mouseTilePosition.X <= layering.MaskHighX && mouseTilePosition.X >= layering.MaskLowX)
            {
                picture.Cursor = Cursors.SizeNS;
                mouseOverObject = MapObject.MaskN;
            }
            else if (mouseTilePosition.X == layering.MaskHighX &&
                mouseTilePosition.Y <= layering.MaskHighY && mouseTilePosition.Y >= layering.MaskLowY)
            {
                picture.Cursor = Cursors.SizeWE;
                mouseOverObject = MapObject.MaskE;
            }
            else if (mouseTilePosition.Y == layering.MaskHighY &&
                mouseTilePosition.X <= layering.MaskHighX && mouseTilePosition.X >= layering.MaskLowX)
            {
                picture.Cursor = Cursors.SizeNS;
                mouseOverObject = MapObject.MaskS;
            }
        }
        private void SetMouseOverNPCObject()
        {
            int index_npc = 0;
            foreach (var npcObject in npcObjects.NPCObjects)
            {
                if (npcObject.X == mouseIsometricPosition.X &&
                    npcObject.Y == mouseIsometricPosition.Y)
                {
                    this.picture.Cursor = Cursors.Hand;
                    mouseOverNPC = index_npc;
                    mouseOverNPCReference = -1;
                    mouseOverObject = MapObject.NPCObject;
                    break;
                }
                else
                {
                    this.picture.Cursor = Cursors.Arrow;
                    mouseOverNPC = -1;
                    mouseOverObject = MapObject.None;
                }
                index_npc++;
            }
        }
        private void SetMouseOverExitTrigger()
        {
            int index = 0;
            foreach (var trigger in exitTriggers.Triggers)
            {
                if (trigger.X == mouseIsometricPosition.X &&
                    trigger.Y == mouseIsometricPosition.Y)
                {
                    this.picture.Cursor = Cursors.Hand;
                    mouseOverExitTrigger = index;
                    mouseOverObject = MapObject.ExitTrigger;
                    break;
                }
                else
                {
                    this.picture.Cursor = Cursors.Arrow;
                    mouseOverExitTrigger = 0;
                    mouseOverObject = MapObject.None;
                }
                index++;
            }
        }
        private void SetMouseOverEventTrigger()
        {
            int index = 0;
            foreach (var trigger in eventTriggers.Triggers)
            {
                if (trigger.X == mouseIsometricPosition.X &&
                    trigger.Y == mouseIsometricPosition.Y)
                {
                    this.picture.Cursor = Cursors.Hand;
                    mouseOverEventField = index;
                    mouseOverObject = MapObject.EventTrigger;
                    break;
                }
                else
                {
                    this.picture.Cursor = Cursors.Arrow;
                    mouseOverEventField = 0;
                    mouseOverObject = MapObject.None;
                }
                index++;
            }
        }
        private void SetMouseOverOverlap()
        {
            int index = 0;
            foreach (var overlap in overlaps.Overlaps)
            {
                if (overlap.X == mouseIsometricPosition.X &&
                    overlap.Y == mouseIsometricPosition.Y)
                {
                    this.picture.Cursor = Cursors.Hand;
                    mouseOverOverlap = index;
                    mouseOverObject = MapObject.Overlap;
                    break;
                }
                else
                {
                    this.picture.Cursor = Cursors.Arrow;
                    mouseOverOverlap = 0;
                    mouseOverObject = MapObject.None;
                }
                index++;
            }
        }
        private void SetMouseOverTileSwitch(int x, int y)
        {
            int index = 0;
            foreach (var tileSwitch in tileSwitches)
            {
                if (tileSwitch.WithinBounds(x / 16, y / 16))
                {
                    this.picture.Cursor = Cursors.Hand;
                    mouseOverTileSwitch = index;
                    mouseOverObject = MapObject.TileSwitch;
                    break;
                }
                else
                {
                    this.picture.Cursor = Cursors.Arrow;
                    mouseOverTileSwitch = 0;
                    mouseOverObject = MapObject.None;
                }
                index++;
            }
        }
        private void SetMouseOverCollisionSwitch()
        {
            int index = 0;
            foreach (var collisionSwitch in collisionSwitches)
            {
                if (collisionSwitch.X == mouseIsometricPosition.X &&
                    collisionSwitch.Y == mouseIsometricPosition.Y)
                {
                    this.picture.Cursor = Cursors.Hand;
                    mouseOverCollisionSwitch = index;
                    mouseOverObject = MapObject.CollisionSwitch;
                    break;
                }
                else
                {
                    this.picture.Cursor = Cursors.Arrow;
                    mouseOverCollisionSwitch = 0;
                    mouseOverObject = MapObject.None;
                }
                index++;
            }
        }
        private void SetMouseOverMushroom(int x, int y)
        {
            for (int i = 0; i < mushrooms.Length; i++)
            {
                if (mushrooms[i].X == x / 16 && mushrooms[i].Y == y / 16)
                {
                    this.picture.Cursor = Cursors.Hand;
                    mouseOverObject = MapObject.Mushroom;
                    mouseOverMushroom = i;
                    break;
                }
                else
                {
                    this.picture.Cursor = Cursors.Arrow;
                    mouseOverObject = MapObject.None;
                    mouseOverMushroom = -1;
                }
            }
        }
        private void SetMouseOverCollisionTile()
        {
            if (mouseOverCollisionTileNum != 0)
            {
                this.picture.Cursor = Cursors.Hand;
                mouseOverObject = MapObject.CollisionTile;
            }
            else
            {
                this.picture.Cursor = Cursors.Arrow;
                mouseOverObject = MapObject.None;
            }
        }

        #endregion

        #region Set MouseDown object

        private void SetMouseDownCollisionTile(int x, int y)
        {
            mouseDownObject = MapObject.CollisionTile;
            mouseDownCollisionTile = mouseOverCollisionTile;
            mouseDownCollisionTileIndex = mouseDownCollisionTileNum;
            selcollision = collisionTiles[mouseOverCollisionTileNum].GetHighlightedImage();
            selcollision_area = collision.TileCoords[mouseDownCollisionTile];
            selcollision_area.Y -= 768;
            if ((Control.ModifierKeys & Keys.Control) == 0)
            {
                Point tL = new Point(x, y);
                Point bR = new Point(x + 1, y + 1);
                Tilemap map;
                if (state.CollisionSwitches && collisionSwitch != null)
                    map = collisionSwitch;
                else
                    map = collisionMap;
                commandStack_C.Push(new CollisionEdit(this.areasForm, map, tL, bR, tL, new byte[0x20C2]));
                if (state.CollisionSwitches && collisionSwitch != null)
                    collisionSwitch.TilemapToTiles();
                collision.RefreshTilemapImage(map, mouseDownCollisionTile * 2);
                map.Image = null;
                p1CollisionMapImage = null;
            }
        }

        #endregion

        #endregion

        #region Event Handlers

        // TilemapForm
        private void TilemapForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.overlay.Select.Clear();
        }

        // Picture
        private void picture_Paint(object sender, PaintEventArgs e)
        {
            #region Tilemap image

            RectangleF clone = e.ClipRectangle;
            var remainder = new SizeF((int)(clone.Width % Zoom), (int)(clone.Height % Zoom));
            clone.Location = new PointF((int)(clone.X / Zoom), (int)(clone.Y / Zoom));
            clone.Size = new SizeF((int)(clone.Width / Zoom), (int)(clone.Height / Zoom));
            clone.Width += (int)(remainder.Width * Zoom) + 1;
            clone.Height += (int)(remainder.Height * Zoom) + 1;
            RectangleF source, dest;
            float[][] matrixItems ={ 
               new float[] {1, 0, 0, 0, 0},
               new float[] {0, 1, 0, 0, 0},
               new float[] {0, 0, 1, 0, 0},
               new float[] {0, 0, 0, (float)overlay.Opacity / 100, 0}, 
               new float[] {0, 0, 0, 0, 1}};
            var cm = new ColorMatrix(matrixItems);
            var ia = new ImageAttributes();
            if (overlay.Opacity < 100)
                ia.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            var rdst = new Rectangle(0, 0, Zoom * width, Zoom * height);
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            if (tilemapImage != null)
            {
                clone.Width = Math.Min(tilemapImage.Width, clone.X + clone.Width) - clone.X;
                clone.Height = Math.Min(tilemapImage.Height, clone.Y + clone.Height) - clone.Y;
                source = clone; source.Location = new PointF(0, 0);
                dest = new RectangleF((int)(clone.X * Zoom), (int)(clone.Y * Zoom), (int)(clone.Width * Zoom), (int)(clone.Height * Zoom));
                e.Graphics.DrawImage(tilemapImage.Clone(clone, PixelFormat.DontCare), dest, source, GraphicsUnit.Pixel);
            }

            #endregion

            if (state.TileSwitches && this.tileSwitch != null)
            {
                foreach (var tileSwitch in tileSwitches)
                {
                    if (tileSwitch.TilemapA == null)
                        tileSwitch.TilemapA = new AreaTilemap(area, tileset, tileSwitch, false);
                    if (tileSwitch.Alternate && tileSwitch.TilemapB == null)
                        tileSwitch.TilemapB = new AreaTilemap(area, tileset, tileSwitch, true);
                }
                overlay.DrawTileSwitches(tileSwitches, areasForm.TileSwitchesForm.TileSwitch, areasForm.TileSwitchesForm.AlternateSelected, e.Graphics, ia, Zoom);
            }
            if (state.Move && selection != null)
            {
                var rsrc = new Rectangle(0, 0, overlay.Select.Width, overlay.Select.Height);
                rdst = new Rectangle(
                    overlay.Select.X * Zoom, overlay.Select.Y * Zoom,
                    rsrc.Width * Zoom, rsrc.Height * Zoom);
                e.Graphics.DrawImage(new Bitmap(selection), rdst, rsrc, GraphicsUnit.Pixel);
                Do.DrawString(e.Graphics, new Point(rdst.X, rdst.Y + rdst.Height),
                    "click/drag", Color.White, Color.Black, new Font("Tahoma", 6.75F, FontStyle.Bold));
            }
            if (state.Priority1 && !state.CollisionMap)
            {
                cm.Matrix33 = 0.50F;
                ia.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                if (p1TilemapImage == null)
                    p1TilemapImage = Do.PixelsToImage(tilemap.GetPriority1Pixels(), width, height);
                e.Graphics.DrawImage(p1TilemapImage, rdst, 0, 0, width, height, GraphicsUnit.Pixel, ia);
            }

            #region Collision map

            if (state.CollisionMap)
            {
                if (overlay.Opacity < 100)
                    e.Graphics.DrawImage(collisionMap.Image, rdst, 0, 0, width, height, GraphicsUnit.Pixel, ia);
                else
                    e.Graphics.DrawImage(collisionMap.Image, rdst, 0, 0, width, height, GraphicsUnit.Pixel);
                if (state.Priority1)
                {
                    if (p1CollisionMapImage == null)
                        p1CollisionMapImage = Do.PixelsToImage(collision.GetPriority1Pixels(collisionMap), 1024, 1024);
                    e.Graphics.DrawImage(p1CollisionMapImage, rdst, 0, 0, width, height, GraphicsUnit.Pixel, ia);
                }
                if (selcollision != null)
                {
                    var rsrc = new Rectangle(0, 0, selcollision.Width, selcollision.Height);
                    rdst = new Rectangle(
                        selcollision_area.X * Zoom, selcollision_area.Y * Zoom,
                        rsrc.Width * Zoom, rsrc.Height * Zoom);
                    e.Graphics.DrawImage(selcollision, rdst, rsrc, GraphicsUnit.Pixel);
                }
            }

            #endregion

            #region Map objects

            if (state.CollisionSwitches)
            {
                overlay.DrawCollisionSwitches(collisionSwitches, collisionSwitch, collisionTiles, e.Graphics, rdst, ia, Zoom);
                overlay.DrawCollisionSwitches(collisionSwitches, collisionSwitch, e.Graphics, Zoom);
            }
            if (state.Exits)
            {
                overlay.DrawExitTriggers(exitTriggers, areasForm.ExitsForm.Trigger, e.Graphics, Zoom);
                if (toggleTags.Checked)
                    overlay.DrawExitTriggerTags(exitTriggers, areasForm.ExitsForm.Trigger, e.Graphics, Zoom);
            }
            if (state.Events)
            {
                overlay.DrawEventTriggers(eventTriggers, areasForm.EventsForm.Trigger, e.Graphics, Zoom);
                if (toggleTags.Checked)
                    overlay.DrawEventTriggerTags(eventTriggers, areasForm.EventsForm.Trigger, e.Graphics, Zoom);
            }
            if (state.NPCs)
            {
                if (overlay.NPCImages == null)
                    overlay.DrawNPCObjects(npcObjects, areasForm.NPCsForm.NPCObject, Areas.Model.NPCProperties);
                overlay.DrawNPCObjects(npcObjects, areasForm.NPCsForm.NPCObject, e.Graphics, Zoom);
                if (toggleTags.Checked)
                    overlay.DrawNPCObjectTags(npcObjects, areasForm.NPCsForm.NPCObject, e.Graphics, Zoom);
            }
            if (state.Overlaps)
                overlay.DrawOverlapObjects(overlaps, areasForm.OverlapsForm.Overlap, Areas.Model.OverlapTileset, e.Graphics, Zoom);
            if (state.Mushrooms)
            {
                if (minecartForm.Index == 0)
                    overlay.DrawMushrooms(minecartForm.MinecartData, minecartForm.MinecartData.Mode7ObjectsA, e.Graphics, Zoom);
                else if (minecartForm.Index == 1)
                    overlay.DrawMushrooms(minecartForm.MinecartData, minecartForm.MinecartData.Mode7ObjectsB, e.Graphics, Zoom);
            }
            if (state.Rails && minecartForm.Index < 2)
                overlay.DrawRailProperties(tilemap.Tilemap_bytes, 64, 64, e.Graphics, Zoom);

            #endregion

            #region Common overlay

            if (!state.Dropper && mouseEnter)
                DrawHoverBox(e.Graphics);
            if (state.TileGrid)
                overlay.DrawTileGrid(e.Graphics, Color.Gray, picture.Size, new Size(16, 16), Zoom, true);
            if (state.IsometricGrid)
                overlay.DrawIsometricGrid(e.Graphics, Color.Gray, picture.Size, new Size(16, 16), Zoom);
            if (state.Mask)
            {
                e.Graphics.PixelOffsetMode = PixelOffsetMode.None;
                overlay.DrawAreaMask(e.Graphics, new Point(layering.MaskHighX, layering.MaskHighY), new Point(layering.MaskLowX, layering.MaskLowY), Zoom);
                e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            }
            if (state.ShowBoundaries && mouseEnter)
                overlay.DrawBoundaries(e.Graphics, mousePosition, Zoom);
            if (state.Select && overlay.Select != null)
            {
                e.Graphics.PixelOffsetMode = PixelOffsetMode.Default;
                overlay.Select.DrawSelectionBox(e.Graphics, Zoom);
            }

            #endregion
        }
        private void picture_MouseMove(object sender, MouseEventArgs e)
        {
            // Create truncated mouse coordinates at default zoom level
            int x = Math.Max(0, Math.Min(e.X / Zoom, width));
            int y = Math.Max(0, Math.Min(e.Y / Zoom, height));

            // Check if within same bounds as last call of MouseMove event
            if (state.CollisionMap || state.CollisionSwitches)
                mouseWithinSameBounds = mouseOverCollisionTile ==
                    collision.PixelTiles[Math.Min(y * width + x, (width - 1) * (height - 1))];
            else
                mouseWithinSameBounds = mouseOverTile == (y / 16 * 64) + (x / 16);

            #region Reset mouse properties

            mousePosition = new Point(x, y);
            mouseLastIsometricPosition = new Point(mouseIsometricPosition.X, mouseIsometricPosition.Y);
            mouseIsometricPosition.X = collision.PixelCoords[Math.Min(y * width + x, (width - 1) * (height - 1))].X;
            mouseIsometricPosition.Y = collision.PixelCoords[Math.Min(y * width + x, (width - 1) * (height - 1))].Y;
            mouseOverTile = (y / 16 * 64) + (x / 16);
            mouseOverCollisionTile = collision.PixelTiles[Math.Min(y * width + x, (width - 1) * (height - 1))];
            mouseOverObject = MapObject.None;
            UpdateCoordLabels();

            #endregion

            #region Select in tileset

            if ((Control.ModifierKeys & Keys.Shift) != 0)
            {
                int index = 0;
                if (!state.CollisionMap)
                {
                    int layer = 0;
                    bool ignoreTransparent = minecartForm == null;
                    index = tilemap.GetTileNum(0, mousePosition.X, mousePosition.Y, ignoreTransparent);
                    if (index == 0)
                    {
                        layer++;
                        index = tilemap.GetTileNum(1, mousePosition.X, mousePosition.Y, ignoreTransparent);
                    }
                    if (index == 0)
                    {
                        layer++;
                        index = tilemap.GetTileNum(2, mousePosition.X, mousePosition.Y, ignoreTransparent);
                    }
                    tilesetForm.Layer = layer;
                    tilesetForm.ActivateZoomRegion(index);
                }
                else if (state.CollisionMap)
                {
                    index = collisionMap.GetTileNum(collision.PixelTiles[mousePosition.Y * width + mousePosition.X]);
                    collisionTileForm.Visible = true;
                    collisionTileForm.Index = index;
                }
                else if (state.CollisionSwitches && collisionSwitch != null)
                {
                    index = collisionSwitch.GetTileNum(collision.PixelTiles[mousePosition.Y * width + mousePosition.X]);
                    collisionTileForm.Visible = true;
                    collisionTileForm.Index = index;
                }
            }

            #endregion

            #region Zooming

            // if either zoom button is checked, don't do anything else
            if (editZoomIn.Checked || editZoomOut.Checked)
            {
                picture.Invalidate();
                return;
            }

            #endregion

            #region Color selection

            if (state.Dropper)
                return;

            #endregion

            #region Tile editing

            if (state.Select)
            {
                // if making a new selection
                if (e.Button == MouseButtons.Left && mouseDownObject == MapObject.None && overlay.Select != null)
                {
                    if (!state.TileSwitches)
                    {
                        // cancel if within same bounds as last call
                        if (overlay.Select.Final == new Point(x + 16, y + 16))
                            return;
                        // otherwise, set the lower right edge of the selection
                        overlay.Select.Final = new Point(
                            Math.Min(x + 16, picture.Width),
                            Math.Min(y + 16, picture.Height));
                    }
                    else
                    {
                        // cancel if within same bounds as last call
                        if (overlay.Select.Final == new Point(x + 16, y + 16))
                            return;
                        // otherwise, set the lower right edge of the selection
                        overlay.Select.Final = new Point(
                            Math.Max(tileSwitch.X * 16, Math.Min(x + 16, (tileSwitch.X + tileSwitch.Width) * 16)),
                            Math.Max(tileSwitch.Y * 16, Math.Min(y + 16, (tileSwitch.Y + tileSwitch.Height) * 16)));
                    }
                }
                // if dragging the current selection
                else if (!state.CollisionMap && e.Button == MouseButtons.Left && mouseDownObject == MapObject.Selection)
                {
                    if (!state.TileSwitches)
                        overlay.Select.Location = new Point(x / 16 * 16 - mouseDownPosition.X, y / 16 * 16 - mouseDownPosition.Y);
                    else
                    {
                        // the maximum coordinates, determined both by the selection and tile mod sizes
                        int maxX = (tileSwitch.X + tileSwitch.Width) * 16 - overlay.Select.Width;
                        int maxY = (tileSwitch.Y + tileSwitch.Height) * 16 - overlay.Select.Height;
                        overlay.Select.Location = new Point(
                            Math.Min(maxX, Math.Max(tileSwitch.X * 16, x / 16 * 16 - mouseDownPosition.X)),
                            Math.Min(maxY, Math.Max(tileSwitch.Y * 16, y / 16 * 16 - mouseDownPosition.Y)));
                    }
                }
                // if mouse not clicked and within the current selection
                else if (!state.CollisionMap && e.Button == MouseButtons.None && overlay.Select != null && overlay.Select.MouseWithin(x, y))
                {
                    mouseOverObject = MapObject.Selection;
                    picture.Cursor = Cursors.SizeAll;
                }
                else
                    picture.Cursor = Cursors.Cross;
                picture.Invalidate();
                return;
            }
            if (!state.CollisionMap && !state.CollisionSwitches)
            {
                if (state.Draw && e.Button == MouseButtons.Left)
                {
                    Draw(picture.CreateGraphics(), x, y);
                    return;
                }
                else if (state.Erase && e.Button == MouseButtons.Left)
                {
                    Erase(picture.CreateGraphics(), x, y);
                    return;
                }
            }
            else if (state.CollisionMap || state.CollisionSwitches)
            {
                if (!mouseWithinSameBounds)
                {
                    if (state.Draw && e.Button == MouseButtons.Left)
                        Draw(picture.CreateGraphics(), x, y);
                    if (state.Erase && e.Button == MouseButtons.Left)
                        Erase(picture.CreateGraphics(), x, y);
                }
            }

            #endregion

            #region Object editing

            if (!state.Chunk && !state.Draw && !state.Select && !state.Erase && !state.Dropper && !state.Fill)
            {
                #region Dragging an object

                if (mouseDownObject != MapObject.None && e.Button == MouseButtons.Left)
                {
                    if (mouseDownObject == MapObject.MaskNW)
                    {
                        areasForm.LayeringForm.MaskLowX.Value = Math.Min(mouseTilePosition.X, layering.MaskHighX);
                        areasForm.LayeringForm.MaskLowY.Value = Math.Min(mouseTilePosition.Y, layering.MaskHighY);
                    }
                    if (mouseDownObject == MapObject.MaskNE)
                    {
                        areasForm.LayeringForm.MaskHighX.Value = Math.Max(mouseTilePosition.X, layering.MaskLowX);
                        areasForm.LayeringForm.MaskLowY.Value = Math.Min(mouseTilePosition.Y, layering.MaskHighY);
                    }
                    if (mouseDownObject == MapObject.MaskSW)
                    {
                        areasForm.LayeringForm.MaskLowX.Value = Math.Min(mouseTilePosition.X, layering.MaskHighX);
                        areasForm.LayeringForm.MaskHighY.Value = Math.Max(mouseTilePosition.Y, layering.MaskLowY);
                    }
                    if (mouseDownObject == MapObject.MaskSE)
                    {
                        areasForm.LayeringForm.MaskHighX.Value = Math.Max(mouseTilePosition.X, layering.MaskLowX);
                        areasForm.LayeringForm.MaskHighY.Value = Math.Max(mouseTilePosition.Y, layering.MaskLowY);
                    }
                    if (mouseDownObject == MapObject.MaskW)
                        areasForm.LayeringForm.MaskLowX.Value = Math.Min(mouseTilePosition.X, layering.MaskHighX);
                    if (mouseDownObject == MapObject.MaskE)
                        areasForm.LayeringForm.MaskHighX.Value = Math.Max(mouseTilePosition.X, layering.MaskLowX);
                    if (mouseDownObject == MapObject.MaskN)
                        areasForm.LayeringForm.MaskLowY.Value = Math.Min(mouseTilePosition.Y, layering.MaskHighY);
                    if (mouseDownObject == MapObject.MaskS)
                        areasForm.LayeringForm.MaskHighY.Value = Math.Max(mouseTilePosition.Y, layering.MaskLowY);
                    if (mouseDownObject == MapObject.ExitTrigger)
                        areasForm.ExitsForm.SetCoords(mouseIsometricPosition.X, mouseIsometricPosition.Y);
                    if (mouseDownObject == MapObject.EventTrigger)
                        areasForm.EventsForm.SetCoords(mouseIsometricPosition.X, mouseIsometricPosition.Y);
                    if (mouseDownObject == MapObject.NPCObject)
                        areasForm.NPCsForm.SetCoords(mouseIsometricPosition.X, mouseIsometricPosition.Y);
                    if (mouseDownObject == MapObject.Overlap)
                        areasForm.OverlapsForm.SetCoords(mouseIsometricPosition.X, mouseIsometricPosition.Y);
                    if (mouseDownObject == MapObject.TileSwitch)
                    {
                        int newX = Math.Min(Math.Max(0, mouseTilePosition.X - mouseDownPosition.X), 63);
                        int newY = Math.Min(Math.Max(0, mouseTilePosition.Y - mouseDownPosition.Y), 63);
                        areasForm.TileSwitchesForm.SetCoords(newX, newY);
                    }
                    if (mouseDownObject == MapObject.CollisionSwitch)
                        areasForm.CollisionSwitchesForm.SetCoords(mouseIsometricPosition.X, mouseIsometricPosition.Y);
                    if (mouseDownObject == MapObject.CollisionTile)
                    {
                        selcollision_area = collision.TileCoords[mouseOverCollisionTile];
                        selcollision_area.Y -= 768;
                    }
                    if (mouseDownObject == MapObject.Mushroom)
                    {
                        mushrooms[mouseDownMushroom].X = x / 16;
                        mushrooms[mouseDownMushroom].Y = y / 16;
                    }
                    picture.Invalidate();
                    return;
                }

                #endregion

                #region Mouse over an object

                else
                {
                    picture.Cursor = Cursors.Arrow;
                    //
                    if (state.Mask)
                        SetMouseOverMask();
                    if (state.Exits && exitTriggers.Count != 0 && mouseOverObject == MapObject.None)
                        SetMouseOverExitTrigger();
                    if (state.Events && eventTriggers.Count != 0 && mouseOverObject == MapObject.None)
                        SetMouseOverEventTrigger();
                    if (state.NPCs && npcObjects.Count != 0 && mouseOverObject == MapObject.None)
                        SetMouseOverNPCObject();
                    if (state.Overlaps && overlaps.Count != 0 && mouseOverObject == MapObject.None)
                        SetMouseOverOverlap();
                    if (state.TileSwitches && tileSwitches.Count != 0 && mouseOverObject == MapObject.None)
                        SetMouseOverTileSwitch(x, y);
                    if (state.CollisionSwitches && collisionSwitches.Count != 0 && mouseOverObject == MapObject.None)
                        SetMouseOverCollisionSwitch();
                    if (state.CollisionMap && editDragCollisionTile.Checked)
                        SetMouseOverCollisionTile();
                    if (state.Mushrooms && mouseOverObject == MapObject.None && mushrooms != null)
                        SetMouseOverMushroom(x, y);
                }

                #endregion
            }

            #endregion

            if (!state.CollisionMap && !state.CollisionSwitches &&
                !state.NPCs && !state.Exits && !state.Events && !state.Overlaps && !mouseWithinSameBounds)
                picture.Invalidate();
            else if (state.CollisionMap || state.CollisionSwitches ||
                state.NPCs || state.Exits || state.Events || state.Overlaps)
                picture.Invalidate();
        }
        private void picture_MouseDown(object sender, MouseEventArgs e)
        {
            // In case the tileset selection was dragged
            if (tilesetForm.DraggedTiles != null)
                tilesetForm.Defloat(tilesetForm.DraggedTiles);

            // Create truncated mouse coordinates at default zoom level
            int x = Math.Max(0, Math.Min(e.X / Zoom, width));
            int y = Math.Max(0, Math.Min(e.Y / Zoom, height));

            // Reset the mouseDownObject to None
            mouseDownObject = MapObject.None;

            #region Zooming

            autoScrollPos.X = Math.Abs(panelPicture.AutoScrollPosition.X);
            autoScrollPos.Y = Math.Abs(panelPicture.AutoScrollPosition.Y);
            if ((editZoomIn.Checked && e.Button == MouseButtons.Left) || (editZoomOut.Checked && e.Button == MouseButtons.Right))
            {
                picture.ZoomIn(e.X, e.Y);
                return;
            }
            else if ((editZoomOut.Checked && e.Button == MouseButtons.Left) || (editZoomIn.Checked && e.Button == MouseButtons.Right))
            {
                picture.ZoomOut(e.X, e.Y);
                return;
            }

            #endregion

            if (e.Button == MouseButtons.Right)
                return;

            #region Tile editing

            // If moving an object and outside of it, paste it
            if (state.Move && mouseOverObject != MapObject.Selection)
            {
                // If copied tiles were pasted and not dragging a non-copied selection
                if (copiedTiles != null && draggedTiles == null)
                    Defloat(copiedTiles);
                if (draggedTiles != null)
                {
                    Defloat(draggedTiles);
                    draggedTiles = null;
                }
                state.Move = false;
            }
            if (state.Select)
            {
                // If we're not inside a current selection to move it, create a new selection
                if (mouseOverObject != MapObject.Selection)
                {
                    if (!state.TileSwitches)
                        overlay.Select.Reload(16, x / 16 * 16, y / 16 * 16, 16, 16, Picture);
                    else if (tileSwitch.WithinBounds(x / 16, y / 16))
                        overlay.Select.Reload(16, x / 16 * 16, y / 16 * 16, 16, 16, Picture);
                    else
                        overlay.Select.Clear();
                }
                // Otherwise, start dragging current selection
                else if (mouseOverObject == MapObject.Selection)
                {
                    mouseDownObject = MapObject.Selection;
                    mouseDownPosition = overlay.Select.MousePosition(x, y);
                    if (!state.Move)    // Only do this if the current selection has not been initially moved
                    {
                        state.Move = true;
                        Drag();
                    }
                }
            }
            if (e.Button == MouseButtons.Left)
            {
                if (mouseOverObject != MapObject.CollisionTile && Control.ModifierKeys == Keys.Control)
                {
                    findInTileset.PerformClick();
                    return;
                }
                if (state.Dropper)
                {
                    SelectColor(x, y);
                    return;
                }
                if (state.Chunk)
                {
                    DrawChunk(picture.CreateGraphics(), x, y);
                    panelPicture.AutoScrollPosition = autoScrollPos;
                    return;
                }
                if (state.Draw)
                {
                    Draw(picture.CreateGraphics(), x, y);
                    panelPicture.AutoScrollPosition = autoScrollPos;
                    return;
                }
                if (state.Erase)
                {
                    Erase(picture.CreateGraphics(), x, y);
                    panelPicture.AutoScrollPosition = autoScrollPos;
                    return;
                }
                if (state.Fill)
                {
                    Fill(picture.CreateGraphics(), x, y);
                    panelPicture.AutoScrollPosition = autoScrollPos;
                    return;
                }
            }

            #endregion

            #region Object editing

            if (!state.Chunk && !state.Draw && !state.Select && !state.Erase && e.Button == MouseButtons.Left)
            {
                if (state.Mask && Areas.Model.IsMaskObject(mouseOverObject))
                {
                    mouseDownObject = mouseOverObject;
                }
                if (state.Exits && mouseOverObject == MapObject.ExitTrigger)
                {
                    mouseDownObject = MapObject.ExitTrigger;
                    mouseDownExitTrigger = mouseOverExitTrigger;
                    areasForm.ExitsForm.Index = mouseDownExitTrigger;
                }
                if (state.Events && mouseOverObject == MapObject.EventTrigger && mouseDownObject == MapObject.None)
                {
                    mouseDownObject = MapObject.EventTrigger;
                    mouseDownEventTrigger = mouseOverEventField;
                    areasForm.EventsForm.Index = mouseDownEventTrigger;
                }
                if (state.NPCs && mouseOverObject == MapObject.NPCObject && mouseDownObject == MapObject.None)
                {
                    mouseDownObject = MapObject.NPCObject;
                    mouseDownNPC = mouseOverNPC;
                    areasForm.NPCsForm.SelectNPC(mouseDownNPC);
                }
                if (state.Overlaps && mouseOverObject == MapObject.Overlap && mouseDownObject == MapObject.None)
                {
                    mouseDownObject = MapObject.Overlap;
                    mouseDownOverlap = mouseOverOverlap;
                    areasForm.OverlapsForm.Index = mouseDownOverlap;
                }
                if (state.TileSwitches && mouseOverObject == MapObject.TileSwitch && mouseDownObject == MapObject.None)
                {
                    mouseDownObject = MapObject.TileSwitch;
                    mouseDownTileSwitch = mouseOverTileSwitch;
                    areasForm.TileSwitchesForm.Index = mouseDownTileSwitch;
                    mouseDownPosition = new Point((x / 16) - tileSwitch.X, (y / 16) - tileSwitch.Y);
                }
                if (state.CollisionSwitches && mouseOverObject == MapObject.CollisionSwitch && mouseDownObject == MapObject.None)
                {
                    mouseDownObject = MapObject.CollisionSwitch;
                    mouseDownCollisionSwitch = mouseOverCollisionSwitch;
                    areasForm.CollisionSwitchesForm.Index = mouseDownCollisionSwitch;
                }
                if (state.CollisionMap && mouseOverObject == MapObject.CollisionTile && mouseDownObject == MapObject.None)
                {
                    SetMouseDownCollisionTile(x, y);
                }
                if (state.Mushrooms && mouseOverObject == MapObject.Mushroom && mouseDownObject == MapObject.None)
                {
                    mouseDownObject = MapObject.Mushroom;
                    mouseDownMushroom = mouseOverMushroom;
                }
            }

            #endregion

            panelPicture.AutoScrollPosition = autoScrollPos;
            picture.Invalidate();
        }
        private void picture_MouseUp(object sender, MouseEventArgs e)
        {
            // Create truncated mouse coordinates at default zoom level
            int x = Math.Max(0, Math.Min(e.X / Zoom, width));
            int y = Math.Max(0, Math.Min(e.Y / Zoom, height));

            #region "Defloat" a collision tile

            if (mouseDownObject == MapObject.CollisionTile)
            {
                selcollision = null;
                Point initial = new Point(x, y);
                Point final = new Point(x + 1, y + 1);
                byte[] temp = new byte[0x20C2];
                Bits.SetShort(temp, mouseOverCollisionTile * 2, mouseDownCollisionTileIndex);
                Tilemap map = null;
                if (state.CollisionSwitches && collisionSwitch != null)
                    map = (Tilemap)collisionSwitch;
                else
                    map = collisionMap;
                commandStack_C.Push(new CollisionEdit(this.areasForm, map, initial, final, initial, temp));
                if (state.CollisionSwitches && collisionSwitch != null)
                    collisionSwitch.TilemapToTiles();
                collision.RefreshTilemapImage(map, mouseOverCollisionTile * 2);
                map.Image = null;
                p1CollisionMapImage = null;
                picture.Invalidate();
                this.commandStack_C.Push(2); // two to undo both deletion and drop
            }

            #endregion

            #region Update command stacks

            // drawing 1 or more tiles
            else if (!state.Move && !state.CollisionMap && !state.CollisionSwitches && commandCount > 0)
            {
                if (!state.TileSwitches)
                    this.commandStack.Push(commandCount);
                else
                    this.commandStack_TM.Push(commandCount);
                commandCount = 0;
            }
            // drawing 1 or more collision tiles
            else if (!state.Move && commandCount > 0)
            {
                if (!state.CollisionSwitches)
                    this.commandStack_C.Push(commandCount);
                else
                    this.commandStack_CM.Push(commandCount);
                commandCount = 0;
            }

            #endregion

            #region Reset mouseDown objects and tilemap images

            mouseDownExitTrigger = -1;
            mouseDownEventTrigger = -1;
            mouseDownNPC = -1;
            mouseDownOverlap = -1;
            mouseDownCollisionTile = 0;
            mouseDownCollisionTileIndex = -1;
            mouseDownMushroom = -1;
            mouseDownObject = MapObject.None;

            // Clear 
            if (state.Draw || state.Erase || state.Fill)
            {
                if (!state.CollisionMap && !state.CollisionSwitches)
                {
                    SetTilemapImage();
                    if (area != null)
                        tileSwitches.ClearImages();
                }
                else
                    picture.Invalidate();
            }

            #endregion

            picture.Focus(ownerForm);
            //
            if (areasForm != null)
                areasForm.Modified = true;
            else
                minecartForm.Modified = true;
        }
        private void picture_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter = true;
            picture.Focus(ownerForm);
            picture.Invalidate();
        }
        private void picture_MouseLeave(object sender, EventArgs e)
        {
            mouseEnter = false;
            picture.Invalidate();
        }
        private void picture_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.W: toggleIsometricGrid.PerformClick(); break;
                case Keys.G: toggleTileGrid.PerformClick(); break;
                case Keys.A: editAllLayers.PerformClick(); break;
                case Keys.D: editDraw.PerformClick(); break;
                case Keys.E: editErase.PerformClick(); break;
                case Keys.P: editDropper.PerformClick(); break;
                case Keys.F: editFill.PerformClick(); break;
                case Keys.S: editSelect.PerformClick(); break;
                case Keys.T: editChunk.PerformClick(); break;
                case Keys.Control | Keys.V: editPaste.PerformClick(); break;
                case Keys.Control | Keys.C: editCopy.PerformClick(); break;
                case Keys.Delete: editDelete.PerformClick(); break;
                case Keys.Control | Keys.X: editCut.PerformClick(); break;
                case Keys.Control | Keys.D: Defloat(); break;
                case Keys.Control | Keys.A: buttonSelectAll.PerformClick(); break;
                case Keys.Control | Keys.Z: editUndo.PerformClick(); break;
                case Keys.Control | Keys.Y: editRedo.PerformClick(); break;
                case Keys.Q: editDragCollisionTile.PerformClick(); break;
                case Keys.Control | Keys.D1: tilesetForm.Layer = 0; break;
                case Keys.Control | Keys.D2: tilesetForm.Layer = 1; break;
                case Keys.Control | Keys.D3:
                    if (tileset.Tilesets_tiles[2] != null)
                        tilesetForm.Layer = 2; break;
            }
        }
        private void panelPicture_Scroll(object sender, ScrollEventArgs e)
        {
            autoScrollPos.X = Math.Abs(panelPicture.AutoScrollPosition.X);
            autoScrollPos.Y = Math.Abs(panelPicture.AutoScrollPosition.Y);
            picture.Invalidate();
            panelPicture.Invalidate();
        }

        // ToolStrip - Viewing
        private void toggleTileGrid_Click(object sender, EventArgs e)
        {
            state.TileGrid = toggleTileGrid.Checked;
            state.IsometricGrid = toggleIsometricGrid.Checked = false;
            picture.Invalidate();
        }
        private void toggleIsometricGrid_Click(object sender, EventArgs e)
        {
            state.IsometricGrid = toggleIsometricGrid.Checked;
            state.TileGrid = toggleTileGrid.Checked = false;
            picture.Invalidate();
        }
        private void toggleBG_Click(object sender, EventArgs e)
        {
            state.BG = toggleBG.Checked;
            tilemap.RedrawTilemaps();
            tileSwitches.RedrawTilemaps();
            SetTilemapImage();
        }
        private void toggleMask_Click(object sender, EventArgs e)
        {
            state.Mask = toggleMask.Checked;
            if (state.Mask)
                areasForm.LayeringForm.Show();
            picture.Invalidate();
        }
        private void toggleBoundaries_Click(object sender, EventArgs e)
        {
            toggleBoundaries.Checked = !toggleBoundaries.Checked;
            state.ShowBoundaries = toggleBoundaries.Checked;
            picture.Invalidate();
        }
        private void toggleL1_Click(object sender, EventArgs e)
        {
            state.Layer1 = toggleL1.Checked;
            tilemap.RedrawTilemaps();
            tileSwitches.RedrawTilemaps();
            SetTilemapImage();
        }
        private void toggleL2_Click(object sender, EventArgs e)
        {
            state.Layer2 = toggleL2.Checked;
            tilemap.RedrawTilemaps();
            tileSwitches.RedrawTilemaps();
            SetTilemapImage();
        }
        private void toggleL3_Click(object sender, EventArgs e)
        {
            state.Layer3 = toggleL3.Checked;
            tilemap.RedrawTilemaps();
            tileSwitches.RedrawTilemaps();
            SetTilemapImage();
        }
        private void toggleP1_Click(object sender, EventArgs e)
        {
            state.Priority1 = toggleP1.Checked;
            picture.Invalidate();
        }
        private void toggleCollisionMap_Click(object sender, EventArgs e)
        {
            Defloat();
            state.CollisionMap = toggleCollisionMap.Checked;
            editDragCollisionTile.Enabled = toggleCollisionMap.Checked;
            if (!editDragCollisionTile.Enabled)
                editDragCollisionTile.Checked = false;
            picture.Invalidate();
            ToggleTilesets();
        }
        private void toggleTileSwitches_Click(object sender, EventArgs e)
        {
            Defloat();
            state.TileSwitches = toggleTileSwitches.Checked;
            if (state.TileSwitches)
                areasForm.TileSwitchesForm.Show();
            picture.Invalidate();
        }
        private void toggleCollisionSwitches_Click(object sender, EventArgs e)
        {
            Defloat();
            state.CollisionSwitches = toggleCollisionSwitches.Checked;
            if (state.CollisionSwitches)
                areasForm.CollisionSwitchesForm.Show();
            picture.Invalidate();
            ToggleTilesets();
        }
        private void toggleNPCs_Click(object sender, EventArgs e)
        {
            Defloat();
            state.NPCs = toggleNPCs.Checked;
            if (state.NPCs)
                areasForm.NPCsForm.Show();
            picture.Invalidate();
        }
        private void toggleExits_Click(object sender, EventArgs e)
        {
            Defloat();
            state.Exits = toggleExits.Checked;
            if (state.Exits)
                areasForm.ExitsForm.Show();
            picture.Invalidate();
        }
        private void toggleEvents_Click(object sender, EventArgs e)
        {
            Defloat();
            state.Events = toggleEvents.Checked;
            if (state.Events)
                areasForm.EventsForm.Show();
            picture.Invalidate();
        }
        private void toggleOverlaps_Click(object sender, EventArgs e)
        {
            Defloat();
            state.Overlaps = toggleOverlaps.Checked;
            if (state.Overlaps)
                areasForm.OverlapsForm.Show();
            picture.Invalidate();
        }
        private void toggleMushrooms_Click(object sender, EventArgs e)
        {
            Defloat();
            state.Mushrooms = toggleMushrooms.Checked;
            picture.Invalidate();
        }
        private void toggleRails_Click(object sender, EventArgs e)
        {
            Defloat();
            state.Rails = toggleRails.Checked;
            picture.Invalidate();
            tilesetForm.Rails = state.Rails;
            tilesetForm.Picture.Invalidate();
            minecartForm.ScreensForm.RailColorKey.Visible = state.Rails;
        }
        private void toggleTags_Click(object sender, EventArgs e)
        {
            picture.Invalidate();
        }

        // ToolStrip - Editing
        private void editDraw_Click(object sender, EventArgs e)
        {
            state.Draw = editDraw.Checked;
            Do.ResetToolStripButtons(toolStrip2, sender as ToolStripButton, editAllLayers);
            if (editDraw.Checked)
                this.picture.Cursor = NewCursors.Draw;
            else if (!editDraw.Checked)
                this.picture.Cursor = Cursors.Arrow;
            Defloat();
            picture.Invalidate();
        }
        private void editSelect_Click(object sender, EventArgs e)
        {
            state.Select = editSelect.Checked;
            Do.ResetToolStripButtons(toolStrip2, sender as ToolStripButton, editAllLayers);
            if (state.Select)
                this.picture.Cursor = Cursors.Cross;
            else if (!state.Select)
                this.picture.Cursor = Cursors.Arrow;
            Defloat();
            picture.Invalidate();
        }
        private void editSelectAll_Click(object sender, EventArgs e)
        {
            if (!state.Select)
                editSelect.PerformClick();
            Defloat();
            overlay.Select.Reload(16, 0, 0, width, height, Picture);
            picture.Invalidate();
        }
        private void editErase_Click(object sender, EventArgs e)
        {
            state.Erase = editErase.Checked;
            Do.ResetToolStripButtons(toolStrip2, sender as ToolStripButton, editAllLayers);
            if (state.Erase)
                this.picture.Cursor = NewCursors.Erase;
            else if (!state.Erase)
                this.picture.Cursor = Cursors.Arrow;
            //
            Defloat();
            picture.Invalidate();
        }
        private void editDropper_Click(object sender, EventArgs e)
        {
            state.Dropper = editDropper.Checked;
            picture.ZoomBoxEnabled = state.Dropper;
            Do.ResetToolStripButtons(toolStrip2, sender as ToolStripButton, editAllLayers);
            if (state.Dropper)
                this.picture.Cursor = NewCursors.Dropper;
            else if (!state.Dropper)
                this.picture.Cursor = Cursors.Arrow;
            //
            Defloat();
            picture.Invalidate();
        }
        private void editFill_Click(object sender, EventArgs e)
        {
            state.Fill = editFill.Checked;
            Do.ResetToolStripButtons(toolStrip2, sender as ToolStripButton, editAllLayers);
            if (state.Fill)
                this.picture.Cursor = NewCursors.Fill;
            else if (!state.Fill)
                this.picture.Cursor = Cursors.Arrow;
            //
            Defloat();
            picture.Invalidate();
        }
        private void editChunk_Click(object sender, EventArgs e)
        {
            state.Chunk = editChunk.Checked;
            Do.ResetToolStripButtons(toolStrip2, sender as ToolStripButton, editAllLayers);
            if (editChunk.Checked)
                this.picture.Cursor = NewCursors.Chunk;
            else if (!editChunk.Checked)
                this.picture.Cursor = Cursors.Arrow;
            Defloat();
            picture.Invalidate();
        }
        private void editDelete_Click(object sender, EventArgs e)
        {
            if (!state.Move)
                Delete();
            else
            {
                state.Move = false;
                draggedTiles = null;
                picture.Invalidate();
            }
            if (!state.Move && commandCount > 0)
            {
                commandStack.Push(commandCount);
                commandCount = 0;
            }
        }
        private void editUndo_Click(object sender, EventArgs e)
        {
            Undo();
        }
        private void editRedo_Click(object sender, EventArgs e)
        {
            Redo();
        }
        private void editCut_Click(object sender, EventArgs e)
        {
            Cut();
        }
        private void editCopy_Click(object sender, EventArgs e)
        {
            Copy();
        }
        private void editPaste_Click(object sender, EventArgs e)
        {
            if (copiedTiles == null)
                return;
            // set a floor and ceiling for the coordinates
            int x = Math.Max(0, Math.Min(Math.Abs(panelPicture.AutoScrollPosition.X) / Zoom / 16 * 16, width - 1));
            int y = Math.Max(0, Math.Min(Math.Abs(panelPicture.AutoScrollPosition.Y) / Zoom / 16 * 16, height - 1));
            x += 32; y += 32;
            if (x + copiedTiles.Width >= width)
                x -= x + copiedTiles.Width - width;
            if (y + copiedTiles.Height >= height)
                y -= x + copiedTiles.Height - height;
            //
            if (draggedTiles != null)
            {
                Defloat(draggedTiles);
                draggedTiles = null;
            }
            Paste(new Point(x, y), copiedTiles);
        }
        private void editZoomIn_Click(object sender, EventArgs e)
        {
            Do.ResetToolStripButtons(toolStrip2, sender as ToolStripButton, editAllLayers);
            if (editZoomIn.Checked)
                this.picture.Cursor = NewCursors.ZoomIn;
            else if (!editZoomIn.Checked)
                this.picture.Cursor = Cursors.Arrow;
        }
        private void editZoomOut_Click(object sender, EventArgs e)
        {
            Do.ResetToolStripButtons(toolStrip2, sender as ToolStripButton, editAllLayers);
            if (editZoomOut.Checked)
                this.picture.Cursor = NewCursors.ZoomOut;
            else if (!editZoomOut.Checked)
                this.picture.Cursor = Cursors.Arrow;
        }
        private void editDragCollisionTile_Click(object sender, EventArgs e)
        {
            state.ClearDrawing();
            Do.ResetToolStripButtons(toolStrip2, sender as ToolStripButton, editAllLayers);
            Defloat();
            picture.Invalidate();
        }

        // ContextMenuStrip
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (editZoomIn.Checked || editZoomOut.Checked)
                e.Cancel = true;
            else if (mouseOverObject == MapObject.ExitTrigger)
            {
                foreach (ToolStripItem item in contextMenuStrip1.Items)
                    item.Visible = false;
                objectFunction.Text = "Load destination";
                objectFunction.Tag = mouseOverExitTrigger;
                objectFunction.Visible = true;
            }
            else if (mouseOverObject == MapObject.EventTrigger)
            {
                foreach (ToolStripItem item in contextMenuStrip1.Items)
                    item.Visible = false;
                objectFunction.Text = "Edit event's script";
                objectFunction.Tag = mouseOverEventField;
                objectFunction.Visible = true;
            }
            else if (mouseOverObject == MapObject.NPCObject)
            {
                foreach (ToolStripItem item in contextMenuStrip1.Items)
                    item.Visible = false;
                if (npcObjects.NPCObjects[mouseOverNPC].EngageType == EngageType.Event ||
                    npcObjects.NPCObjects[mouseOverNPC].EngageType == EngageType.Treasure)
                    objectFunction.Text = "Edit npc's script";
                else if (npcObjects.NPCObjects[mouseOverNPC].EngageType == EngageType.Battle)
                    objectFunction.Text = "Edit npc's formation pack";
                objectFunction.Tag = new List<int> { mouseOverNPC, mouseOverNPCReference };
                objectFunction.Visible = true;
            }
            else if (minecartForm != null)
            {
                createTileSwitch.Visible = false;
                exportToBattlefield.Visible = false;
            }
            else
            {
                foreach (ToolStripItem item in contextMenuStrip1.Items)
                    item.Visible = true;
                objectFunction.Visible = false;
            }
        }
        private void findInTileset_Click(object sender, EventArgs e)
        {
            int index = 0;
            if (state.CollisionMap)
            {
                index = collisionMap.GetTileNum(collision.PixelTiles[mousePosition.Y * width + mousePosition.X]);
                collisionTileForm.Visible = true;
                collisionTileForm.Index = index;
                return;
            }
            if (state.CollisionSwitches && collisionSwitch != null)
            {
                index = collisionSwitch.GetTileNum(collision.PixelTiles[mousePosition.Y * width + mousePosition.X]);
                collisionTileForm.Visible = true;
                collisionTileForm.Index = index;
                return;
            }
            // first, use "see-through" approach to look for the exact visible tile clicked on
            int layer = 0;
            bool ignoreTransparent = minecartForm == null;
            if (state.Layer1)
                index = tilemap.GetTileNum(0, mousePosition.X, mousePosition.Y, ignoreTransparent);
            if (index == 0)
            {
                layer++;
                if (state.Layer2)
                    index = tilemap.GetTileNum(1, mousePosition.X, mousePosition.Y, ignoreTransparent);
            }
            if (index == 0)
            {
                layer++;
                if (state.Layer3)
                    index = tilemap.GetTileNum(2, mousePosition.X, mousePosition.Y, ignoreTransparent);
            }
            if (index != 0) // only if not all layers empty
            {
                tilesetForm.Layer = layer;
                tilesetForm.ActivateZoomRegion(index);
                return;
            }
            // if all empty, use raw opaque tile searching approach
            layer = 0;
            if (state.Layer1)
                index = tilemap.GetTileNum(0, mousePosition.X, mousePosition.Y, false);
            if (index == 0)
            {
                layer++;
                if (state.Layer2)
                    index = tilemap.GetTileNum(1, mousePosition.X, mousePosition.Y, false);
            }
            if (index == 0)
            {
                layer++;
                if (state.Layer3)
                    index = tilemap.GetTileNum(2, mousePosition.X, mousePosition.Y, false);
            }
            if (index != 0) // only if not all layers empty
                tilesetForm.Layer = layer;
            tilesetForm.ActivateZoomRegion(index);
        }
        private void createTileSwitch_Click(object sender, EventArgs e)
        {
            if (overlay.Select.Empty)
            {
                MessageBox.Show("Must make a selection before creating a new tile mod.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (overlay.Select.Width / 16 >= 64 || overlay.Select.Height / 16 >= 64)
            {
                MessageBox.Show("Selection must be smaller than 64x64 tiles.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            areasForm.TileSwitchesForm.Show();
            areasForm.TileSwitchesForm.AddNew(overlay.Select, this.tilemap);
            if (!toggleTileSwitches.Checked)
                toggleTileSwitches.PerformClick();
            tileSwitches.UpdateTilemaps();
            picture.Invalidate();
        }
        private void saveImageAs_Click(object sender, EventArgs e)
        {
            if (minecartForm == null)
                Do.Export(tilemapImage, "area-" + area.Index.ToString("d3") + ".png");
            else
                Do.Export(tilemapImage, "minecart-" + minecartForm.Index.ToString("d2") + ".png");
        }
        private void exportToBattlefield_Click(object sender, EventArgs e)
        {
            if (overlay.Select.Empty)
            {
                MessageBox.Show("Must make a selection before exporting to battlefield.", "LAZY SHELL",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Tile[] tiles = new Tile[32 * 32];
            int counter = 0;
            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++, counter++)
                {
                    int tileX = overlay.Select.X + (x * 16);
                    int tileY = overlay.Select.Y + (y * 16);
                    int index = tilemap.GetTileNum(tilesetForm.Layer, tileX, tileY);
                    if (y < overlay.Select.Height / 16 && x < overlay.Select.Width / 16)
                        tiles[counter] = this.tileset.Tilesets_tiles[tilesetForm.Layer][index].Copy();
                    else
                        tiles[counter] = new Tile(counter);
                    tiles[counter].Index = counter;
                }
            }
            counter = 256;
            for (int y = 0; y < 16; y++)
            {
                for (int x = 16; x < 32; x++, counter++)
                {
                    int tileX = overlay.Select.X + (x * 16);
                    int tileY = overlay.Select.Y + (y * 16);
                    int index = tilemap.GetTileNum(tilesetForm.Layer, tileX, tileY);
                    if (y < overlay.Select.Height / 16 && x < overlay.Select.Width / 16)
                        tiles[counter] = this.tileset.Tilesets_tiles[tilesetForm.Layer][index].Copy();
                    else
                        tiles[counter] = new Tile(counter);
                    tiles[counter].Index = counter;
                }
            }
            counter = 512;
            for (int y = 16; y < 32; y++)
            {
                for (int x = 0; x < 16; x++, counter++)
                {
                    int tileX = overlay.Select.X + (x * 16);
                    int tileY = overlay.Select.Y + (y * 16);
                    int index = tilemap.GetTileNum(tilesetForm.Layer, tileX, tileY);
                    if (y < overlay.Select.Height / 16 && x < overlay.Select.Width / 16)
                        tiles[counter] = this.tileset.Tilesets_tiles[tilesetForm.Layer][index].Copy();
                    else
                        tiles[counter] = new Tile(counter);
                    tiles[counter].Index = counter;
                }
            }
            counter = 768;
            for (int y = 16; y < 32; y++)
            {
                for (int x = 16; x < 32; x++, counter++)
                {
                    int tileX = overlay.Select.X + (x * 16);
                    int tileY = overlay.Select.Y + (y * 16);
                    int index = tilemap.GetTileNum(tilesetForm.Layer, tileX, tileY);
                    if (y < overlay.Select.Height / 16 && x < overlay.Select.Width / 16)
                        tiles[counter] = this.tileset.Tilesets_tiles[tilesetForm.Layer][index].Copy();
                    else
                        tiles[counter] = new Tile(counter);
                    tiles[counter].Index = counter;
                }
            }
            var battlefield = new Battlefields.Battlefield(0);
            battlefield.GraphicSetA = areaMap.GraphicSet1;
            battlefield.GraphicSetB = areaMap.GraphicSet2;
            battlefield.GraphicSetC = areaMap.GraphicSet3;
            battlefield.GraphicSetD = areaMap.GraphicSet4;
            battlefield.GraphicSetE = areaMap.GraphicSet5;
            var paletteset = this.areasForm.PaletteSet.Copy();
            var battlefieldTileset = new Battlefields.Tileset(battlefield, paletteset, tiles);
            battlefieldTileset.Battlefield = battlefield;
            battlefieldTileset.Palettes = paletteset;
            battlefieldTileset.Tileset_tiles = tiles;
            Do.Export(battlefieldTileset, "tilemap_battlefield.dat");
        }
        private void objectFunction_Click(object sender, EventArgs e)
        {
            if (objectFunction.Text == "Load destination")
            {
                ExitTrigger exit = exitTriggers.Triggers[(int)objectFunction.Tag];
                if (exit.ExitType == 0)
                    areasForm.Index = exit.Destination;
                else
                {
                    if (Model.Program.WorldMaps == null || !Model.Program.WorldMaps.Visible)
                        LazyShell.Model.Program.CreateWorldMapsWindow();
                    LazyShell.Model.Program.WorldMaps.Index = exit.Destination;
                    LazyShell.Model.Program.WorldMaps.BringToFront();
                }
            }
            else if (objectFunction.Text == "Edit event's script")
            {
                EventTrigger EVENT = eventTriggers.Triggers[(int)objectFunction.Tag];
                if (Model.Program.EventScripts == null || !Model.Program.EventScripts.Visible)
                    LazyShell.Model.Program.CreateEventScriptsWindow();
                LazyShell.Model.Program.EventScripts.Type = 0;
                LazyShell.Model.Program.EventScripts.Index = EVENT.RunEvent;
                LazyShell.Model.Program.EventScripts.BringToFront();
            }
            else if (objectFunction.Text == "Edit npc's script")
            {
                List<int> tag = (List<int>)objectFunction.Tag;
                NPCObject npc = npcObjects.NPCObjects[tag[0]];
                NPCObject reference = null;
                if (Model.Program.EventScripts == null || !Model.Program.EventScripts.Visible)
                    LazyShell.Model.Program.CreateEventScriptsWindow();
                LazyShell.Model.Program.EventScripts.Type = 0;
                if (reference == null)
                    LazyShell.Model.Program.EventScripts.Index = npc.Event;
                LazyShell.Model.Program.EventScripts.BringToFront();
            }
            else if (objectFunction.Text == "Edit npc's formation pack")
            {
                List<int> tag = (List<int>)objectFunction.Tag;
                NPCObject npc = npcObjects.NPCObjects[tag[0]];
                if (Model.Program.Formations == null || !Model.Program.Formations.Visible)
                    LazyShell.Model.Program.CreateFormationsWindow();
                int pack = npc.Pack;
                LazyShell.Model.Program.Formations.PackIndex = pack;
                LazyShell.Model.Program.Formations.FormationIndex = Formations.Model.Packs[pack].Formations[0];
                LazyShell.Model.Program.Formations.BringToFront();
            }
        }

        #endregion
    }
}
