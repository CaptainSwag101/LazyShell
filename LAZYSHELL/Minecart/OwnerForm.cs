using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LazyShell.Properties;
using WeifenLuo.WinFormsUI.Docking;

namespace LazyShell.Minecart
{
    public partial class OwnerForm : MapEditor
    {
        #region Variables

        // Index
        public int Index
        {
            get { return minecartAreaName.SelectedIndex; }
            set { minecartAreaName.SelectedIndex = value; }
        }
        private Settings settings = Settings.Default;

        // Forms
        public ScreensForm ScreensForm { get; set; }
        public ObjectsForm ObjectsForm { get; set; }
        private PaletteEditor spritePaletteEditor;
        private GraphicEditor spriteGraphicEditor;
        private PreviewerForm previewerForm;
        private PictureBox picture
        {
            get { return ScreensForm.Picture; }
            set { ScreensForm.Picture = value; }
        }
        private State state = State.Instance2;

        // Elements
        private Tileset bgTileset
        {
            get { return ScreensForm.BGTileset; }
            set { ScreensForm.BGTileset = value; }
        }
        public MinecartData MinecartData { get; set; }

        #endregion

        // Constructor
        public OwnerForm()
        {
            InitializeComponent();
            InitializeVariables();
            InitializeListControls();
            InitializeNavigators();
            InitializeForms();
            CreateShortcuts();
            LoadMinecart();
            //
            this.History = new History(this, minecartAreaName, null);
        }

        #region Methods

        // Initialization
        private void InitializeListControls()
        {
            this.music.Items.AddRange(Lists.Numerize(Lists.SPCTracks));
            this.music.SelectedIndex = Model.ROM[0x0393EF];
        }
        private void InitializeNavigators()
        {
            this.Updating = true;
            //
            if (settings.RememberLastIndex)
                Index = settings.LastMineCart;
            else
                Index = 0;
            //
            this.Updating = false;
        }
        private void InitializeVariables()
        {
            this.Overlay = new Overlay();
            MinecartData = new MinecartData(Model.Objects);
        }
        private void InitializeForms()
        {
            ObjectsForm = new ObjectsForm(this);
            ScreensForm = new ScreensForm(this);

            // Set toggle buttons
            ScreensForm.ToggleButton = toggleScreens;
        }
        private void CreateShortcuts()
        {
            Do.AddShortcut(toolStrip1, Keys.Control | Keys.S, new EventHandler(save_Click));
        }
        public void LoadMinecart()
        {
            // if mode7 map
            if (Index < 2)
            {
                labelStartXY.Visible = true;
                startX.Visible = true;
                startY.Visible = true;
                startX.Value = Bits.GetShort(Model.ROM, 0x039670);
                startY.Value = Bits.GetShort(Model.ROM, 0x039679);

                // Create map elements
                PaletteSet = Model.M7PaletteSet;
                Tileset = new Tileset(Model.M7PaletteSet, TilesetType.Mode7);
                if (Index == 0)
                    Tilemap = new Mode7Tilemap(Model.M7TilemapA, Tileset, PaletteSet);
                else
                    Tilemap = new Mode7Tilemap(Model.M7TilemapB, Tileset, PaletteSet);

                // Load the screens
                toggleScreens.Enabled = false;
                ScreensForm.Hide();
                ObjectsForm.Hide();
            }
            // if side-scrolling map
            else
            {
                labelStartXY.Visible = false;
                startX.Visible = false;
                startY.Visible = false;

                // Create map elements
                PaletteSet = Model.SSPaletteSet;
                Tileset = new Tileset(Model.SSTileset, Model.SSGraphics, PaletteSet, 16, 16, TilesetType.SideScrolling);
                Tilemap = new SideTilemap(Model.SSTilemap, null, Tileset, PaletteSet);
                toggleScreens.Enabled = true;
                ScreensForm.LoadScreens();

                // ObjectsForm
                toggleScreens.Enabled = true;
                ScreensForm.Show(dockPanel, DockState.DockTop);
                ObjectsForm.Left = this.Right + 10;
                ObjectsForm.Top = this.Top;
                ObjectsForm.Show(ScreensForm.Pane, DockAlignment.Right, 0.25);
                ObjectsForm.InitializeObjects();
            }

            // (Re)load editors and forms
            ReloadPaletteEditor();
            ReloadGraphicEditor();
            ReloadSpritePaletteEditor();
            ReloadSpriteGraphicEditor();
            LoadTilesetEditor();
            LoadTilemapEditor();

            // Rails properties
            TilesetForm.Rails = state.Rails && Index < 2;
        }

        // Updating
        public void UpdatePalette()
        {
            bgTileset.RedrawTilesets();
            Tileset.RedrawTilesets();
            Tilemap.RedrawTilemaps();
            LoadTilesetEditor();
            LoadTilemapEditor();
            //
            ScreensForm.ScreenBGImage = null;
            ScreensForm.SetScreenImages();
            //
            this.Modified = true;   // b/c switching colors won't modify checksum
        }
        public void UpdateGraphics()
        {
            Tileset.WriteToModel(16);
            //
            Tileset.RedrawTilesets();
            Tilemap.RedrawTilemaps();
            LoadTilesetEditor();
            LoadTilemapEditor();
            //
            ScreensForm.SetScreenImages();
        }
        public void UpdatePalettesSprites()
        {
            MinecartData.Mushroom = null;
            MinecartData.Coin = null;
            TilemapForm.Picture.Invalidate();
            picture.Invalidate();
        }
        public void UpdateGraphicsSprites()
        {
            MinecartData.Mushroom = null;
            MinecartData.Coin = null;
            TilemapForm.Picture.Invalidate();
            picture.Invalidate();
        }
        public void UpdatePalettesObjects()
        {
            MinecartData.Mushroom = null;
            MinecartData.Coin = null;
            picture.Invalidate();
        }
        public void UpdateGraphicsObjects()
        {
            MinecartData.Mushroom = null;
            MinecartData.Coin = null;
            picture.Invalidate();
        }
        public void UpdateTilemap()
        {
        }
        public void UpdateTileset()
        {
            Tilemap.ParseTilemap();
            Tilemap = new Mode7Tilemap(Model.M7TilemapA, Tileset, Model.M7PaletteSet);
            LoadMinecart();
        }
        public void UpdateTile()
        {

        }

        // Loading
        public void LoadPaletteEditor()
        {
            if (PaletteEditor == null)
            {
                PaletteEditor = new PaletteEditor(new PaletteUpdater(), PaletteSet, 8, 0, 8);
                PaletteEditor.Owner = this;
            }
            else
                ReloadPaletteEditor();
        }
        private void LoadGraphicEditor()
        {
            if (GraphicEditor == null)
            {
                GraphicEditor = new GraphicEditor(new GraphicUpdater(),
                    Tileset.Graphics, Tileset.Graphics.Length, 0, PaletteSet, 0, 0x20);
                GraphicEditor.Owner = this;
            }
            else
                ReloadGraphicEditor();
        }
        private void LoadSpritePaletteEditor()
        {
            if (spritePaletteEditor == null)
            {
                spritePaletteEditor = new PaletteEditor(new PaletteSpritesUpdater(), Model.ObjectPaletteSet, 8, 0, 8);
                spritePaletteEditor.Owner = this;
            }
            else
                ReloadSpritePaletteEditor();
        }
        private void LoadSpriteGraphicEditor()
        {
            if (spriteGraphicEditor == null)
            {
                spriteGraphicEditor = new GraphicEditor(new GraphicSpritesUpdater(),
                    Model.ObjectGraphics, Model.ObjectGraphics.Length, 0, Model.ObjectPaletteSet, 0, 0x20);
                spriteGraphicEditor.Owner = this;
            }
            else
                ReloadSpriteGraphicEditor();
        }
        private void LoadTilemapEditor()
        {
            if (TilemapForm == null)
            {
                this.TilemapForm = new TilemapForm(this);
                this.TilemapForm.ToggleButton = toggleTilemap;
                this.TilemapForm.Show(dockPanel, DockState.Document);
            }
            else
                this.TilemapForm.Reload(this);
        }
        private void LoadTilesetEditor()
        {
            if (TilesetForm == null)
            {
                this.TilesetForm = new TilesetForm(this, 0);
                this.TilesetForm.ToggleButton = toggleTileset;
                this.TilesetForm.Show(dockPanel, DockState.DockRight);
            }
            else
                this.TilesetForm.Reload(this);
        }
        private void LoadPreviewer()
        {
            if (previewerForm == null)
            {
                previewerForm = new PreviewerForm(Index, ElementType.MineCart);
                previewerForm.Owner = this;
            }
            else
                previewerForm.Reload(Index, ElementType.MineCart);
        }

        // Reloading
        private void ReloadPaletteEditor()
        {
            if (PaletteEditor != null)
                PaletteEditor.Reload(PaletteSet, 8, 0, 8);
        }
        private void ReloadGraphicEditor()
        {
            if (GraphicEditor != null)
                GraphicEditor.Reload(Tileset.Graphics, Tileset.Graphics.Length, 0, PaletteSet, 0, 0x20);
        }
        private void ReloadSpritePaletteEditor()
        {
            if (spritePaletteEditor != null)
                spritePaletteEditor.Reload(Model.ObjectPaletteSet, 8, 0, 8);
        }
        private void ReloadSpriteGraphicEditor()
        {
            if (spriteGraphicEditor != null)
                spriteGraphicEditor.Reload(Model.ObjectGraphics, Model.ObjectGraphics.Length, 0, Model.ObjectPaletteSet, 0, 0x20);
        }
        private void ShowEditorForm(Form form)
        {
            if (!form.Visible)
                form.Location = new Point(Cursor.Position.X + 20, Cursor.Position.Y + 20);
            form.Show();
        }

        // Saving
        public void WriteToROM()
        {
            Model.ROM[0x0393EF] = (byte)this.music.SelectedIndex;
            MinecartData.WriteToROM();
            Tilemap.ParseTilemap();
            Model.M7PaletteSet.WriteToBuffer();
            Model.ObjectPaletteSet.WriteToBuffer();
            Model.SSPaletteSet.WriteToBuffer();
            //
            int offset = 0x1E;
            byte[] dst = new byte[0x8000];
            Bits.SetShort(dst, 0x00, offset);
            if (!Comp.Compress(Model.M7Graphics, dst, ref offset, 0x8000 - 0x1E, "stage 1,3 graphics"))
                return;
            Bits.SetShort(dst, 0x02, offset);
            if (!Comp.Compress(Model.M7TilesetSubtiles, dst, ref offset, 0x8000 - 0x1E, "stage 1,3 subtiles"))
                return;
            Bits.SetShort(dst, 0x04, offset);
            if (!Comp.Compress(Model.M7Palettes, dst, ref offset, 0x8000 - 0x1E, "stage 1,3 palettes"))
                return;
            Bits.SetShort(dst, 0x06, offset);
            if (!Comp.Compress(Model.M7TilesetPalettes, dst, ref offset, 0x8000 - 0x1E, "stage 1,3 subtile palettes"))
                return;
            Bits.SetShort(dst, 0x08, offset);
            if (!Comp.Compress(Model.M7TilemapA, dst, ref offset, 0x8000 - 0x1E, "stage 1 tilemap"))
                return;
            Bits.SetShort(dst, 0x0A, offset);
            if (!Comp.Compress(Model.M7TilemapB, dst, ref offset, 0x8000 - 0x1E, "stage 3 tilemap"))
                return;
            Bits.SetShort(dst, 0x0C, offset);
            if (!Comp.Compress(Model.M7TilesetBG, dst, ref offset, 0x8000 - 0x1E, "stage 1,3 background tileset"))
                return;
            Bits.SetShort(dst, 0x0E, offset);
            if (!Comp.Compress(Model.ObjectGraphics, dst, ref offset, 0x8000 - 0x1E, "object graphics"))
                return;
            Bits.SetShort(dst, 0x10, offset);
            if (!Comp.Compress(Model.ObjectPalettes, dst, ref offset, 0x8000 - 0x1E, "object palettes"))
                return;
            Bits.SetShort(dst, 0x12, offset);
            if (!Comp.Compress(Model.SSTilemap, dst, ref offset, 0x8000 - 0x1E, "stage 2,4 tilemap"))
                return;
            Bits.SetShort(dst, 0x14, offset);
            if (!Comp.Compress(Model.SSGraphics, dst, ref offset, 0x8000 - 0x1E, "stage 2,4 graphics"))
                return;
            Bits.SetShort(dst, 0x16, offset);
            if (!Comp.Compress(Model.SSTileset, dst, ref offset, 0x8000 - 0x1E, "stage 2,4 tileset"))
                return;
            Bits.SetShort(dst, 0x18, offset);
            if (!Comp.Compress(Model.SSPalettes, dst, ref offset, 0x8000 - 0x1E, "stage 2,4 palettes"))
                return;
            Bits.SetShort(dst, 0x1A, offset);
            if (!Comp.Compress(Model.SSBGTileset, dst, ref offset, 0x8000 - 0x1E, "stage 4 BG tileset"))
                return;
            Bits.SetShort(dst, 0x1C, offset);
            if (!Comp.Compress(Model.Objects, dst, ref offset, 0x8000 - 0x1E, "object & screen data"))
                return;

            //
            Bits.SetBytes(Model.ROM, 0x388000, dst);
            Bits.SetShort(Model.ROM, 0x039670, (ushort)startX.Value);
            Bits.SetShort(Model.ROM, 0x039679, (ushort)startY.Value);

            // Finished
            this.Modified = false;
        }

        #endregion

        #region Event Handlers

        // OwnerForm
        private void OwnerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.Modified)
            {
                LazyShell.Properties.Settings.Default.Save();
                return;
            }
            var result = MessageBox.Show("Mine-cart areas have not been saved.\n\nWould you like to save changes?",
                "LAZY SHELL", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                WriteToROM();
            else if (result == DialogResult.No)
                Model.ClearAll();
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }

            // Reset drawing state
            state.Draw = false;
            state.Erase = false;
            state.Select = false;
            state.Dropper = false;
            state.Fill = false;
            state.TileGrid = false;
        }

        // Data management
        private void save_Click(object sender, EventArgs e)
        {
            WriteToROM();
        }
        private void importTilesets_Click(object sender, EventArgs e)
        {
            byte[] var = (byte[])Do.Import(Model.M7TilesetSubtiles);
            if (var != null) Model.M7TilesetSubtiles = var;
            var = (byte[])Do.Import(Model.M7TilesetPalettes);
            if (var != null) Model.M7TilesetPalettes = var;
            var = (byte[])Do.Import(Model.SSTileset);
            if (var != null) Model.SSTileset = var;
            LoadMinecart();
        }
        private void importTilemaps_Click(object sender, EventArgs e)
        {
            byte[] var = (byte[])Do.Import(Model.M7TilemapA);
            if (var != null) Model.M7TilemapA = var;
            var = (byte[])Do.Import(Model.M7TilemapB);
            if (var != null) Model.M7TilemapB = var;
            var = (byte[])Do.Import(Model.SSTilemap);
            if (var != null) Model.SSTilemap = var;
            LoadMinecart();
        }
        private void exportTilesets_Click(object sender, EventArgs e)
        {
            Do.Export(Model.M7TilesetSubtiles, "minecartStage1subtiles.bin");
            Do.Export(Model.M7TilesetPalettes, "minecartStage1palettes.bin");
            Do.Export(Model.SSTileset, "minecartStage2tileset.bin");
        }
        private void exportTilemaps_Click(object sender, EventArgs e)
        {
            Do.Export(Model.M7TilemapA, "minecartStage1tilemap.bin");
            Do.Export(Model.M7TilemapB, "minecartStage3tilemap.bin");
            Do.Export(Model.SSTilemap, "minecartStage2tilemap.bin");
        }
        private void resetAllObjects_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doing this will erase all changes to the object data for all stages since the last save, including mushrooms, coins, and screens. Continue?",
                "LAZY SHELL", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            Model.Objects = null;
            MinecartData = new MinecartData(Model.Objects);
            LoadMinecart();
        }
        private void resetCurrentTileset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doing this will erase all changes to the tileset since the last save. Continue?",
                "LAZY SHELL", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            if (Index < 2)
            {
                Model.M7TilesetSubtiles = null;
                Model.M7TilesetPalettes = null;
            }
            else
                Model.SSTileset = null;
            LoadMinecart();
        }
        private void resetCurrentTilemap_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doing this will erase all changes to the tilemap since the last save. Continue?",
                "LAZY SHELL", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            if (Index == 0)
                Model.M7TilemapA = null;
            else if (Index == 1)
                Model.M7TilemapB = null;
            else
                Model.SSTilemap = null;
            LoadMinecart();
        }

        // Navigator
        private void name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            LoadMinecart();
            settings.LastMineCart = minecartAreaName.SelectedIndex;
        }

        // Properties
        private void music_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Modified = true;
        }

        // Forms
        private void openPalettesStage_Click(object sender, EventArgs e)
        {
            LoadPaletteEditor();
            ShowEditorForm(PaletteEditor);
        }
        private void openPalettesSprites_Click(object sender, EventArgs e)
        {
            LoadSpritePaletteEditor();
            ShowEditorForm(spritePaletteEditor);
        }
        private void openGraphicsStage_Click(object sender, EventArgs e)
        {
            LoadGraphicEditor();
            ShowEditorForm(GraphicEditor);
        }
        private void openGraphicsSprites_Click(object sender, EventArgs e)
        {
            LoadSpriteGraphicEditor();
            ShowEditorForm(spriteGraphicEditor);
        }
        private void openPreviewer_Click(object sender, EventArgs e)
        {
            LoadPreviewer();
            previewerForm.Show();
        }

        #endregion
    }
}
