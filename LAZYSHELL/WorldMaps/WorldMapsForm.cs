using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using LazyShell.Properties;
using LazyShell.Undo;

namespace LazyShell.WorldMaps
{
    public partial class WorldMapsForm : MapEditor
    {
        #region Variables

        // Index
        public int Index
        {
            get { return (int)name.SelectedIndex; }
            set { name.SelectedIndex = value; }
        }

        // Forms
        private OwnerForm ownerForm;
        private LocationsForm locationsForm
        {
            get { return ownerForm.LocationsForm; }
            set { ownerForm.LocationsForm = value; }
        }
        private TileEditor tileEditor;

        // Picture
        public PictureBox Picture
        {
            get { return this.picture; }
            set { this.picture = value; }
        }
        private Overlay overlay = new Overlay();
        private int zoom = 1;
        private Bitmap tilesetImage;
        private Bitmap locationImage;
        private Bitmap locationImage_S;
        private Bitmap marioImage;
        private Bitmap logoImage;
        private Bitmap locationText;
        private Settings settings = Settings.Default;
        private EditLabel labelWindow;

        // Elements
        private WorldMaps.WorldMap[] worldMaps
        {
            get { return Model.WorldMaps; }
            set { Model.WorldMaps = value; }
        }
        private WorldMaps.WorldMap worldMap
        {
            get { return worldMaps[Index]; }
            set { worldMaps[Index] = value; }
        }
        private PaletteSet[] fontPalettes
        {
            get { return ownerForm.FontPalettes; }
            set { ownerForm.FontPalettes = value; }
        }
        private Fonts.Glyph[] fontDialogue
        {
            get { return ownerForm.FontDialogue; }
            set { ownerForm.FontDialogue = value; }
        }
        private BattleDialoguePreview drawName
        {
            get { return ownerForm.DrawName; }
            set { ownerForm.DrawName = value; }
        }
        private Location location
        {
            get { return locationsForm.location; }
            set { locationsForm.location = value; }
        }
        private Location[] locations
        {
            get { return Model.Locations; }
            set { Model.Locations = value; }
        }
        public new PaletteSet PaletteSet
        {
            get { return Model.PaletteSet; }
            set { Model.PaletteSet = value; }
        }
        private PaletteSet logoPalette
        {
            get { return Model.Logos_PaletteSet; }
            set { Model.Logos_PaletteSet = value; }
        }
        public byte[] Tileset_bytes
        {
            get { return Model.Tilesets_Bytes[worldMap.Tileset]; }
            set { Model.Tilesets_Bytes[worldMap.Tileset] = value; }
        }
        public Tileset LogoTileset { get; set; }

        // Mouse behavior
        private bool mouseEnter = false;
        public int MouseDownTile { get; set; }
        private string mouseOverObject;
        private string mouseDownObject;
        private Point mouseDownPosition;
        private Point mousePosition;
        private bool moving = false;

        // Tile editing
        private delegate void UpdateFunction();
        private bool defloating = false;
        private Bitmap selection;
        private CopyBuffer draggedTiles;
        private CopyBuffer copiedTiles;
        private UndoStack commandStack = new UndoStack(true);
        private int commandCount = 0;

        // Old
        private ArrayList[] worldMapLocations;
        private int[] pointActivePixels;
        private int diffX, diffY;

        #endregion

        #region Methods

        // Constructor
        public WorldMapsForm(OwnerForm ownerForm)
        {
            this.ownerForm = ownerForm;
            this.Owner = ownerForm;
            InitializeComponent();
            InitializeListControls();
            CreateHelperForms();
            //
            this.History = new History(this, name, null);
        }

        // Initialization
        private void InitializeListControls()
        {
            this.Updating = true;
            //
            this.name.Items.AddRange(Lists.Numerize(Lists.WorldMaps));
            name.SelectedIndex = 0;
            //
            this.Updating = false;
        }
        private void CreateHelperForms()
        {
            toolTip1.InitialDelay = 0;
            labelWindow = new EditLabel(name, null, "World Maps", true);
        }

        // Load properties
        public void LoadProperties()
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Updating = true;
            this.worldMapTileset.Value = worldMap.Tileset;
            this.pointCount.Value = worldMap.Locations;
            this.worldMapXCoord.Value = worldMap.X;
            this.worldMapYCoord.Value = worldMap.Y;
            AddLocations();
            Location temp;
            if (worldMapLocations[Index] != null &&
                worldMapLocations[Index].Count > 0)
            {
                temp = (Location)worldMapLocations[Index][0];
                locationsForm.Index = temp.Index;
            }
            else
                MessageBox.Show("There are not enough locations left to add to the current world map.\nTry reducing the location count used by earlier world maps.", "LAZY SHELL");
            Tileset = new Tileset(Tileset_bytes, Model.Graphics, PaletteSet, 16, 16, TilesetType.WorldMap);
            LogoTileset = new Tileset(Model.Logos_Tileset, Model.Logos_Graphics, logoPalette, 16, 16, TilesetType.WorldMapLogo);
            SetWorldMapImage();
            SetLocationsImage();
            SetBannerImage();
            this.Updating = false;
            GC.Collect();
            Cursor.Current = Cursors.Arrow;
        }
        public void LoadTileEditor()
        {
            if (tileEditor == null)
            {
                tileEditor = new TileEditor(this, new TileUpdater(), Tileset.Tileset_tiles[MouseDownTile], Tileset.Graphics, true);
                tileEditor.Owner = this;
            }
            else
                tileEditor.Reload(Tileset.Tileset_tiles[MouseDownTile], Tileset.Graphics);
        }

        // Saving
        public void WriteToROM()
        {
            Comp.Compress(Model.Logos_Graphics, 0x3E004C, 0x2000, 0xE1C, "World map logos, banners");

            // World maps
            foreach (var worldMap in worldMaps)
                worldMap.WriteToROM();

            // Graphics
            Model.Logos_PaletteSet.WriteToBuffer(Menus.Model.Menu_Palette_Bytes, 0xE0);
            int offset = Bits.GetShort(Model.ROM, 0x3E000C) + 0x3E0000;
            int maxComp = Bits.GetShort(Model.ROM, 0x3E000E) - Bits.GetShort(Model.ROM, 0x3E000C);
            Comp.Compress(Menus.Model.Menu_Palette_Bytes, offset, 0x200, maxComp, "World map logo palettes");
            Comp.Compress(Model.Graphics, 0x3E2E81, 0x8000, 0x56F6, "Graphics");

            // Tilesets
            byte[] compress = new byte[0x800];
            int totalSize = 0;
            int pOffset = 0x3E0014;
            int dOffset = 0x3E929F;
            int size = 0;
            for (int i = 0; i < Model.Tilesets_Bytes.Length; i++)
            {
                Bits.SetShort(Model.ROM, pOffset, (ushort)dOffset);
                size = Comp.Compress(Model.Tilesets_Bytes[i], compress);
                totalSize += size + 1;
                if (totalSize > 0x4D8)
                {
                    MessageBox.Show(
                        "Recompressed tilesets exceed allotted ROM space by " + (totalSize - 0x4D6).ToString() + " bytes.\nSaving has been discontinued for tilesets " + i.ToString() + " and higher.\nChange or delete some tiles to reduce the size.",
                        "LAZY SHELL");
                    break;
                }
                else
                {
                    Model.ROM[dOffset] = 1; dOffset++;
                    Bits.SetBytes(Model.ROM, dOffset, compress, 0, size - 1);
                    dOffset += size;
                    pOffset += 2;
                }
            }
            Bits.SetShort(Model.ROM, pOffset, (ushort)dOffset);
            Comp.Compress(Model.Logos_Tileset, dOffset, 0x800, 0xC1, "World map logo tileset");

            // Palettes
            PaletteSet.WriteToBuffer(Model.Palettes, 0);
            Comp.Compress(Model.Palettes, 0x3E988C, 0x100, 0xD4, "Palette set");
            this.Modified = false;
        }

        // Add locations
        public void AddLocations()
        {
            worldMapLocations = new ArrayList[worldMaps.Length];
            for (int i = 0, b = 0; i < locations.Length && b < worldMaps.Length; b++)
            {
                worldMapLocations[b] = new ArrayList();
                for (int a = 0; i < locations.Length && a < worldMaps[b].Locations; a++, i++)
                    worldMapLocations[b].Add(locations[i]);
            }
        }

        // Set images
        public void SetWorldMapImage()
        {
            int[] pixels = Do.TilesetToPixels(Tileset.Tileset_tiles, 16, 16, 0, false);
            tilesetImage = Do.PixelsToImage(pixels, 256, 256);
            picture.BackColor = Color.FromArgb(PaletteSet.Reds[0], PaletteSet.Greens[0], PaletteSet.Blues[0]);
            picture.Invalidate();
        }
        public void SetLocationsImage()
        {
            SetActiveLocations();
            SetBannerTextImage();
        }
        public void SetBannerImage()
        {
            int[] pixels = Do.TilesetToPixels(LogoTileset.Tileset_tiles, 16, 16, 0, false);
            logoImage = Do.PixelsToImage(pixels, 256, 256);
            picture.Invalidate();
        }
        public void SetBannerTextImage()
        {
            int[] pixels = drawName.GetPreview(fontDialogue, Fonts.Model.Palette_Dialogue.Palettes[1], locationsForm.location.Name, false);
            int[] cropped;
            Rectangle region = Do.Crop(pixels, out cropped, 256, 32, true, false, true, false);
            locationText = Do.PixelsToImage(cropped, region.Width, region.Height);
            picture.Invalidate();
        }

        // Drawing
        private void SetActiveLocations()
        {
            pointActivePixels = new int[256 * 256];
            int[] point = Do.GetPixelRegion(Model.Sprites_Graphics, 0x20, GetPointPalette(), 16, 0, 1, 2, 1, 0);
            Location temp;
            for (int i = 0; i < worldMap.Locations; i++)
            {
                temp = (Location)worldMapLocations[Index][i];
                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        if (point[y * 16 + x] != 0 &&
                            (y + temp.Y) >= 0 &&
                            (y + temp.Y) < 256 &&
                            (x + temp.X) >= 0 &&
                            (x + temp.X) < 256)
                            pointActivePixels[(y + temp.Y) * 256 + x + temp.X] = temp.Index + 1;
                    }
                }
            }
        }
        private int[] GetLocationPixels(bool hilite)
        {
            int[] pixels = Do.GetPixelRegion(Model.Sprites_Graphics, 0x20, GetPointPalette(), 16, 0, 1, 2, 1, 0);
            if (hilite)
                return Do.Hilite(pixels, 16, 8);
            else
                return pixels;
        }
        private int[] GetMarioPixels()
        {
            int[] pixels = new int[16 * 32];
            int[] bottom = Do.GetPixelRegion(Model.Sprites_Graphics, 0x20, GetPointPalette(), 16, 10, 0, 2, 2, 0);
            int[] top = Do.GetPixelRegion(Model.Sprites_Graphics, 0x20, GetPointPalette(), 16, 4, 0, 2, 2, 0);
            Rectangle r = new Rectangle(0, 0, 16, 16);
            Do.PixelsToPixels(bottom, pixels, 16, 16, r, r);
            Do.PixelsToPixels(top, pixels, 16, 16, r, new Rectangle(0, 16, 16, 16));
            return pixels;
        }
        private int[] GetPointPalette()
        {
            double multiplier = 8; // 8;
            ushort color = 0;
            int[] red = new int[16], green = new int[16], blue = new int[16];
            for (int i = 0; i < 16; i++) // 16 colors in palette
            {
                color = Bits.GetShort(Model.ROM, i * 2 + 0x3DFF00);
                red[i] = (byte)((color % 0x20) * multiplier);
                green[i] = (byte)(((color >> 5) % 0x20) * multiplier);
                blue[i] = (byte)(((color >> 10) % 0x20) * multiplier);
            }
            int[] temp = new int[16];
            for (int i = 0; i < 16; i++)
                temp[i] = Color.FromArgb(255, red[i], green[i], blue[i]).ToArgb();
            return temp;
        }

        #region Selection editing

        private void Cut()
        {
            if (overlay.SelectTS.Empty || overlay.SelectTS.Size == new Size(0, 0))
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
            if (overlay.SelectTS.Empty)
                return;
            if (draggedTiles != null)
            {
                this.copiedTiles = draggedTiles;
                return;
            }
            // make the copy
            int x_ = overlay.SelectTS.Location.X / 16;
            int y_ = overlay.SelectTS.Location.Y / 16;
            this.copiedTiles = new CopyBuffer(overlay.SelectTS.Width, overlay.SelectTS.Height);
            Tile[] copiedTiles = new Tile[(overlay.SelectTS.Width / 16) * (overlay.SelectTS.Height / 16)];
            for (int y = 0; y < overlay.SelectTS.Height / 16; y++)
            {
                for (int x = 0; x < overlay.SelectTS.Width / 16; x++)
                {
                    copiedTiles[y * (overlay.SelectTS.Width / 16) + x] =
                        Tileset.Tileset_tiles[(y + y_) * 16 + x + x_].Copy();
                }
            }
            this.copiedTiles.Tiles = copiedTiles;
        }
        private void Paste(Point location, CopyBuffer buffer)
        {
            if (buffer == null)
                return;
            moving = true;
            // now dragging a new selection
            draggedTiles = buffer;
            selection = buffer.GetImage();
            overlay.SelectTS.Set(16, location, buffer.Size, picture);
            picture.Invalidate();
            defloating = false;
        }
        private void Delete()
        {
            if (overlay.SelectTS.Empty)
                return;
            byte[] oldTileset = Bits.Copy(Tileset.Tileset_bytes);
            //
            int x_ = overlay.SelectTS.Location.X / 16;
            int y_ = overlay.SelectTS.Location.Y / 16;
            for (int y = 0; y < overlay.SelectTS.Height / 16 && y + y_ < 0x100; y++)
            {
                for (int x = 0; x < overlay.SelectTS.Width / 16 && x + x_ < 0x100; x++)
                    Tileset.Tileset_tiles[(y + y_) * 16 + x + x_].Clear();
            }
            Tileset.ParseTileset(Tileset.Tileset_tiles, Tileset.Tileset_bytes);
            SetWorldMapImage();
            //
            commandStack.Push(new TilesetEdit(Tileset, oldTileset, Model.Graphics, 0x20, name));
            commandCount++;
        }
        private void Flip(FlipType flipType)
        {
            if (draggedTiles != null)
                Defloat(draggedTiles);
            if (overlay.SelectTS.Empty)
                return;
            int x_ = overlay.SelectTS.Location.X / 16;
            int y_ = overlay.SelectTS.Location.Y / 16;
            CopyBuffer buffer = new CopyBuffer(overlay.SelectTS.Width, overlay.SelectTS.Height);
            Tile[] copiedTiles = new Tile[(overlay.SelectTS.Width / 16) * (overlay.SelectTS.Height / 16)];
            for (int y = 0; y < overlay.SelectTS.Height / 16; y++)
            {
                for (int x = 0; x < overlay.SelectTS.Width / 16; x++)
                {
                    copiedTiles[y * (overlay.SelectTS.Width / 16) + x] =
                        Tileset.Tileset_tiles[(y + y_) * 16 + x + x_].Copy();
                }
            }
            if (flipType == FlipType.Horizontal)
                Do.FlipHorizontal(copiedTiles, overlay.SelectTS.Width / 16, overlay.SelectTS.Height / 16);
            else if (flipType == FlipType.Vertical)
                Do.FlipVertical(copiedTiles, overlay.SelectTS.Width / 16, overlay.SelectTS.Height / 16);
            buffer.Tiles = copiedTiles;
            Defloat(buffer);
            Tileset.ParseTileset(Tileset.Tileset_tiles, Tileset.Tileset_bytes);
            SetWorldMapImage();
        }
        /// <summary>
        /// Start dragging a selection.
        /// </summary>
        private void Drag()
        {
            if (overlay.SelectTS.Empty)
                return;
            // make the copy
            int x_ = overlay.SelectTS.Location.X / 16;
            int y_ = overlay.SelectTS.Location.Y / 16;
            this.draggedTiles = new CopyBuffer(overlay.SelectTS.Width, overlay.SelectTS.Height);
            Tile[] draggedTiles = new Tile[(overlay.SelectTS.Width / 16) * (overlay.SelectTS.Height / 16)];
            for (int y = 0; y < overlay.SelectTS.Height / 16; y++)
            {
                for (int x = 0; x < overlay.SelectTS.Width / 16; x++)
                {
                    draggedTiles[y * (overlay.SelectTS.Width / 16) + x] =
                        Tileset.Tileset_tiles[(y + y_) * 16 + x + x_].Copy();
                }
            }
            this.draggedTiles.Tiles = draggedTiles;
            selection = new Bitmap(this.draggedTiles.GetImage());
            Delete();
        }
        /// <summary>
        /// "Cements" either a dragged selection or a newly pasted selection.
        /// </summary>
        /// <param name="buffer">The dragged selection or the newly pasted selection.</param>
        private void Defloat(CopyBuffer buffer)
        {
            byte[] oldTileset = Bits.Copy(Tileset.Tileset_bytes);
            //
            selection = null;
            int x_ = overlay.SelectTS.X / 16;
            int y_ = overlay.SelectTS.Y / 16;
            for (int y = 0; y < buffer.Height / 16; y++)
            {
                for (int x = 0; x < buffer.Width / 16; x++)
                {
                    if (y + y_ < 0 || y + y_ >= 16 ||
                        x + x_ < 0 || x + x_ >= 16)
                        continue;
                    Tile tile = buffer.Tiles[y * (buffer.Width / 16) + x];
                    Tileset.Tileset_tiles[(y + y_) * 16 + x + x_] = tile.Copy();
                    Tileset.Tileset_tiles[(y + y_) * 16 + x + x_].Index = (y + y_) * 16 + x + x_;
                }
            }
            Tileset.ParseTileset(Tileset.Tileset_tiles, Tileset.Tileset_bytes);
            commandStack.Push(commandCount + 1);
            commandCount = 0;
            SetWorldMapImage();
            defloating = true;
            //
            commandStack.Push(new TilesetEdit(Tileset, oldTileset, Model.Graphics, 0x20, name));
        }
        private void Defloat()
        {
            if (copiedTiles != null && !defloating)
                Defloat(copiedTiles);
            if (draggedTiles != null)
            {
                Defloat(draggedTiles);
                draggedTiles = null;
            }
            moving = false;
            overlay.SelectTS.Clear();
            Cursor.Position = Cursor.Position;
        }

        #endregion

        // Reset
        public void Reset()
        {
            if (MessageBox.Show("You're about to undo all changes to the current world map. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            int pointer = Bits.GetShort(Model.ROM, worldMap.Tileset * 2 + 0x3E0014);
            int offset = 0x3E0000 + pointer + 1;
            Model.Tilesets_Bytes[worldMap.Tileset] = Comp.Decompress(Model.ROM, offset, 0x800);
            worldMap = new WorldMap(Index);
            LoadProperties();
        }

        #endregion

        #region Event Handlers

        // WorldMaps
        private void WorldMaps_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.S))
                WriteToROM();
        }
        private void WorldMaps_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.Modified)
                return;
            var result = MessageBox.Show(
                "World Maps have not been saved.\n\nWould you like to save changes?", "LAZY SHELL",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                WriteToROM();
            else if (result == DialogResult.No)
            {
                Model.Locations = null;
                Model.Graphics = null;
                Model.Palettes = null;
                Model.WorldMaps = null;
                Model.Sprites_Graphics = null;
                Model.Tilesets_Bytes[0] = null;
                Model.PaletteSet = null;
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
        }

        // Navigator
        private void name_SelectedIndexChanged(object sender, EventArgs e)
        {
            Defloat();
            LoadProperties();
        }

        // Toggle
        private void toggleLocations_Click(object sender, EventArgs e)
        {
            toolStrip2.Enabled = !toggleLocations.Checked || !toggleBanner.Checked;
            if (toggleLocations.Checked)
            {
                editSelect.Checked = false;
                if (draggedTiles != null)
                    Defloat(draggedTiles);
                overlay.SelectTS.Clear();
                picture.Cursor = Cursors.SizeAll;
            }
            else
                picture.Cursor = Cursors.Arrow;
            picture.Invalidate();
        }
        private void toggleBanner_Click(object sender, EventArgs e)
        {
            toolStrip2.Enabled = !toggleLocations.Checked || !toggleBanner.Checked;
            if (toggleLocations.Checked)
            {
                editSelect.Checked = false;
                if (draggedTiles != null)
                    Defloat(draggedTiles);
                overlay.SelectTS.Clear();
                picture.Cursor = Cursors.SizeAll;
            }
            else
                picture.Cursor = Cursors.Arrow;
            picture.Invalidate();
        }
        private void toggleTileGrid_Click(object sender, EventArgs e)
        {
            picture.Invalidate();
        }
        private void toggleBG_Click(object sender, EventArgs e)
        {
            picture.Invalidate();
        }
        private void openTileEditor_Click(object sender, EventArgs e)
        {
            tileEditor.Show(this);
        }

        // Properties
        private void pointCount_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            worldMap.Locations = (byte)pointCount.Value;
            AddLocations();
            SetLocationsImage();
        }
        private void worldMapTileset_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            worldMap.Tileset = (byte)worldMapTileset.Value;
            Tileset = new Tileset(Tileset_bytes, Model.Graphics, PaletteSet, 16, 16, TilesetType.WorldMap);
            SetWorldMapImage();
        }
        private void worldMapXCoord_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            worldMap.X = (sbyte)worldMapXCoord.Value;
            picture.Invalidate();
        }
        private void worldMapYCoord_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            worldMap.Y = (sbyte)worldMapYCoord.Value;
            picture.Invalidate();
        }

        // Picture
        private void picture_Paint(object sender, PaintEventArgs e)
        {
            if (tilesetImage == null)
                return;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            Rectangle rdst = new Rectangle(0, 0, 256, 256);
            if (toggleLocations.Checked || toggleBanner.Checked)
            {
                double third = 100.0 / 3.0;
                rdst.Y -= 8;
                rdst.Width = (int)Do.PercentIncrease(third, 256.0);
                rdst.Height = (int)Do.PercentIncrease(third, 256.0);
                double x = worldMap.X;
                double y = worldMap.Y;
                x = (int)Do.PercentIncrease(third, x);
                y = (int)Do.PercentIncrease(third, y);
                x -= Do.PercentDecrease(third, 256) / 4.0;
                y -= Do.PercentDecrease(third, 256) / 4.0;
                rdst.Offset((int)x, (int)y);
            }
            if (toggleBG.Checked)
                e.Graphics.Clear(Color.FromArgb(PaletteSet.Palette[0]));
            if (tilesetImage != null)
                e.Graphics.DrawImage(tilesetImage, rdst, 0, 0, 256, 256, GraphicsUnit.Pixel);
            if (toggleLocations.Checked)
            {
                foreach (Location location in worldMapLocations[Index])
                {
                    if (locationImage == null)
                        locationImage = Do.PixelsToImage(GetLocationPixels(false), 16, 8);
                    if (locationImage_S == null)
                        locationImage_S = Do.PixelsToImage(GetLocationPixels(true), 16, 8);
                    if (marioImage == null)
                        marioImage = Do.PixelsToImage(GetMarioPixels(), 16, 32);
                    if (location.Index == locationsForm.Index)
                    {
                        e.Graphics.DrawImage(locationImage_S, location.X, location.Y);
                    }
                    else
                        e.Graphics.DrawImage(locationImage, location.X, location.Y);
                }
            }
            if (toggleBanner.Checked)
            {
                if (logoImage != null)
                    e.Graphics.DrawImage(logoImage, 0, -8);
                if (locationText != null)
                    e.Graphics.DrawImage(locationText, 128 - (locationText.Width / 2), 182);
            }
            if (moving && selection != null)
            {
                Rectangle rsrc = new Rectangle(0, 0, overlay.SelectTS.Width, overlay.SelectTS.Height);
                rdst = new Rectangle(
                    overlay.SelectTS.X * zoom, overlay.SelectTS.Y * zoom,
                    rsrc.Width * zoom, rsrc.Height * zoom);
                e.Graphics.DrawImage(new Bitmap(selection), rdst, rsrc, GraphicsUnit.Pixel);
                Do.DrawString(e.Graphics, new Point(rdst.X, rdst.Y + rdst.Height),
                    "click/drag", Color.White, Color.Black, new Font("Tahoma", 6.75F, FontStyle.Bold));
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
            if (mouseEnter && !toggleLocations.Checked && !toggleBanner.Checked)
            {
                Point location = new Point(mousePosition.X / 16 * 16 * zoom, mousePosition.Y / 16 * 16 * zoom);
                overlay.DrawHoverBox(e.Graphics, location, new Size(16 * zoom, 16 * zoom), zoom, true);
            }
            if (toggleTileGrid.Checked)
                overlay.DrawTileGrid(e.Graphics, Color.Gray, picture.Size, new Size(16, 16), 1, true);
            if (overlay.SelectTS != null)
                overlay.SelectTS.DrawSelectionBox(e.Graphics, 1);
        }
        private void picture_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                return;
            mouseDownObject = null;
            // set a floor and ceiling for the coordinates
            int x = Math.Max(0, Math.Min(e.X, picture.Width));
            int y = Math.Max(0, Math.Min(e.Y, picture.Height));
            picture.Focus();
            if (editSelect.Checked)
            {
                // if moving an object and outside of it, paste it
                if (moving && mouseOverObject != "selection")
                {
                    // if copied tiles were pasted and not dragging a non-copied selection
                    if (copiedTiles != null && draggedTiles == null)
                        Defloat(copiedTiles);
                    if (draggedTiles != null)
                    {
                        Defloat(draggedTiles);
                        draggedTiles = null;
                    }
                    selection = null;
                    moving = false;
                }
                // if making a new selection
                if (e.Button == MouseButtons.Left && mouseOverObject == null)
                    overlay.SelectTS.Reload(16, x / 16 * 16, y / 16 * 16, 16, 16, picture);
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
            else if (toggleLocations.Checked)
            {
                if (pointActivePixels[y * 256 + x] != 0)
                {
                    locationsForm.Index = pointActivePixels[y * 256 + x] - 1;
                    diffX = (int)(x - locationsForm.X.Value);
                    diffY = (int)(y - locationsForm.Y.Value);
                    mouseDownObject = "location";
                    SetLocationsImage();
                }
                else
                {
                    diffX = (int)(x - worldMapXCoord.Value);
                    diffY = (int)(y - worldMapYCoord.Value);
                    mouseDownObject = "tileset";
                }
            }
            MouseDownTile = y / 16 * 16 + (x / 16);
            LoadTileEditor();
        }
        private void picture_MouseMove(object sender, MouseEventArgs e)
        {
            // set a floor and ceiling for the coordinates
            int x = Math.Max(0, Math.Min(e.X, picture.Width));
            int y = Math.Max(0, Math.Min(e.Y, picture.Height));
            mouseOverObject = null;
            mousePosition = new Point(x, y);
            if (editSelect.Checked)
            {
                // if making a new selection
                if (e.Button == MouseButtons.Left && mouseDownObject == null && overlay.SelectTS != null)
                    overlay.SelectTS.Final = new Point(
                        Math.Min(x + 16, picture.Width),
                        Math.Min(y + 16, picture.Height));
                // if dragging the current selection
                if (e.Button == MouseButtons.Left && mouseDownObject == "selection")
                    overlay.SelectTS.Location = new Point(
                        x / 16 * 16 - mouseDownPosition.X,
                        y / 16 * 16 - mouseDownPosition.Y);
                // check if over selection
                if (e.Button == MouseButtons.None && overlay.SelectTS != null && overlay.SelectTS.MouseWithin(x, y))
                {
                    mouseOverObject = "selection";
                    picture.Cursor = Cursors.SizeAll;
                }
                else
                    picture.Cursor = Cursors.Cross;
            }
            else if (toggleLocations.Checked)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (mouseDownObject == "location")
                    {
                        x = Math.Max(0, Math.Min(e.X - diffX, picture.Width));
                        y = Math.Max(0, Math.Min(e.Y - diffY, picture.Height));
                        locationsForm.X.Value = Math.Min(255, x);
                        locationsForm.Y.Value = Math.Min(255, y);
                    }
                    if (mouseDownObject == "tileset")
                    {
                        x = Math.Max(-128, Math.Min(e.X - diffX, picture.Width));
                        y = Math.Max(-128, Math.Min(e.Y - diffY, picture.Height));
                        worldMapXCoord.Value = Math.Min(127, x);
                        worldMapYCoord.Value = Math.Min(127, y);
                    }
                }
                else
                {
                    if (pointActivePixels[e.Y * 256 + e.X] != 0)
                        picture.Cursor = Cursors.Hand;
                    else
                        picture.Cursor = Cursors.SizeAll;
                }
            }
            picture.Invalidate();
        }
        private void picture_MouseUp(object sender, MouseEventArgs e)
        {
            SetLocationsImage();
        }
        private void picture_MouseClick(object sender, MouseEventArgs e)
        {
        }
        private void picture_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }
        private void picture_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter = true;
            picture.Focus();
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
                case Keys.B: toggleBG.PerformClick(); break;
                case Keys.G: toggleTileGrid.PerformClick(); break;
                case Keys.S: editSelect.PerformClick(); break;
                case Keys.Control | Keys.V: editPaste.PerformClick(); break;
                case Keys.Control | Keys.C: editCopy.PerformClick(); break;
                case Keys.Delete: editDelete.PerformClick(); break;
                case Keys.Control | Keys.X: editCut.PerformClick(); break;
                case Keys.Control | Keys.D:
                    if (draggedTiles != null)
                        Defloat(draggedTiles);
                    else
                    {
                        overlay.SelectTS.Clear();
                        picture.Invalidate();
                    }
                    break;
                case Keys.Control | Keys.A:
                    overlay.SelectTS.Reload(16, 0, 0, 256, 256, picture);
                    picture.Invalidate();
                    break;
                case Keys.Control | Keys.Z: editUndo.PerformClick(); break;
                case Keys.Control | Keys.Y: editRedo.PerformClick(); break;
            }
        }

        // Tile editing
        private void editDelete_Click(object sender, EventArgs e)
        {
            if (!moving)
                Delete();
            else
            {
                moving = false;
                draggedTiles = null;
                picture.Invalidate();
            }
            if (!moving && commandCount > 0)
            {
                commandStack.Push(commandCount);
                commandCount = 0;
            }
        }
        private void editCopy_Click(object sender, EventArgs e)
        {
            Copy();
        }
        private void editCut_Click(object sender, EventArgs e)
        {
            Cut();
        }
        private void editPaste_Click(object sender, EventArgs e)
        {
            if (draggedTiles != null)
                Defloat(draggedTiles);
            Paste(new Point(16, 16), copiedTiles);
        }
        private void editUndo_Click(object sender, EventArgs e)
        {
            commandStack.UndoCommand();
            SetWorldMapImage();
        }
        private void editRedo_Click(object sender, EventArgs e)
        {
            commandStack.RedoCommand();
            SetWorldMapImage();
        }
        private void editSelect_Click(object sender, EventArgs e)
        {
            if (editSelect.Checked)
                this.picture.Cursor = System.Windows.Forms.Cursors.Cross;
            else
                this.picture.Cursor = System.Windows.Forms.Cursors.Arrow;
            Defloat();
            this.picture.Invalidate();
        }
        private void editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.FormOwnerClosing)
            {
                e.Cancel = true;
                (sender as Form).Hide();
            }
        }

        // ContextMenuStrip
        private void mirror_Click(object sender, EventArgs e)
        {
            Flip(FlipType.Horizontal);
        }
        private void invert_Click(object sender, EventArgs e)
        {
            Flip(FlipType.Vertical);
        }
        private void saveImage_Click(object sender, EventArgs e)
        {
            Do.Export(tilesetImage, "world-map-" + Index.ToString("d2") + ".png");
        }

        #endregion
    }
}
