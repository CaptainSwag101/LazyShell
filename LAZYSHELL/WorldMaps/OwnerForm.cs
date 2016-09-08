using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace LazyShell.WorldMaps
{
    public partial class OwnerForm : Controls.NewForm
    {
        #region Variables

        public int Index
        {
            get { return WorldMapsForm.Index; }
            set { WorldMapsForm.Index = value; }
        }

        // Forms
        public WorldMapsForm WorldMapsForm { get; set; }
        public LocationsForm LocationsForm { get; set; }
        private PaletteEditor paletteEditor;
        private GraphicEditor graphicEditor;
        private GraphicEditor logoGraphicEditor;
        private PaletteEditor logoPaletteEditor;
        private GraphicEditor spriteGraphicEditor;

        private delegate void UpdateFunction();
        public BattleDialoguePreview DrawName { get; set; }

        // Elements
        private WorldMaps.WorldMap[] worldMaps
        {
            get { return Model.WorldMaps; }
            set { Model.WorldMaps = value; }
        }
        public PaletteSet[] FontPalettes { get; set; }
        public Fonts.Glyph[] FontDialogue { get; set; }
        private PaletteSet PaletteSet
        {
            get { return Model.PaletteSet; }
            set { Model.PaletteSet = value; }
        }
        private Tileset Tileset
        {
            get { return WorldMapsForm.Tileset; }
            set { WorldMapsForm.Tileset = value; }
        }
        private byte[] Tileset_bytes
        {
            get { return WorldMapsForm.Tileset_bytes; }
            set { WorldMapsForm.Tileset_bytes = value; }
        }
        private Tileset LogoTileset
        {
            get { return WorldMapsForm.LogoTileset; }
            set { WorldMapsForm.LogoTileset = value; }
        }
        private PaletteSet logoPalette
        {
            get { return Model.Logos_PaletteSet; }
            set { Model.Logos_PaletteSet = value; }
        }

        // Tiles
        private int mouseDownTile
        {
            get { return WorldMapsForm.MouseDownTile; }
            set { WorldMapsForm.MouseDownTile = value; }
        }

        #endregion

        // Constructor
        public OwnerForm()
        {
            InitializeComponent();
            InitializeListControls();
            InitializeVariables();
            InitializeForms();
            CreateHelperForms();
            CreateShortcuts();
            WorldMapsForm.LoadTileEditor();
        }

        #region Methods

        // Initialization
        private void InitializeListControls()
        {
            this.Updating = true;
            //
            this.music.Items.AddRange(Lists.Numerize(Lists.SPCTracks));
            this.music.SelectedIndex = Model.ROM[0x037DCF];
            //
            this.Updating = false;
        }
        private void InitializeVariables()
        {
            DrawName = new BattleDialoguePreview();
            FontPalettes = new PaletteSet[3];
            FontPalettes[0] = new PaletteSet(Model.ROM, 0, 0x3DFEE0, 2, 16, 32);
            FontPalettes[1] = new PaletteSet(Model.ROM, 0, 0x3E2D55, 2, 16, 32);
            FontPalettes[2] = new PaletteSet(Model.ROM, 0, 0x01EF40, 2, 16, 32);
            FontDialogue = new Fonts.Glyph[128];
            for (int i = 0; i < FontDialogue.Length; i++)
                FontDialogue[i] = new Fonts.Glyph(i, FontType.Dialogue);
        }
        private void InitializeForms()
        {
            LocationsForm = new LocationsForm(this);
			DockPanel = new DockPanel();
			DockPanel = dockPanel;
			DockPanel.Theme = new VS2013BlueTheme();
			dockPanel = DockPanel;
			LocationsForm.Show(dockPanel, DockState.DockRight);
            WorldMapsForm = new WorldMapsForm(this);
            WorldMapsForm.Show(dockPanel, DockState.Document);
        }
        private void CreateHelperForms()
        {
            new ToolTipLabel(this, baseConvertor, helpTips);
        }
        private void CreateShortcuts()
        {
            Do.AddShortcut(toolStrip3, Keys.Control | Keys.S, new EventHandler(save_Click));
            Do.AddShortcut(toolStrip3, Keys.F1, helpTips);
            Do.AddShortcut(toolStrip3, Keys.F2, baseConvertor);
        }

        // Set images
        private void SetWorldMapImage()
        {
            WorldMapsForm.SetWorldMapImage();
        }
        private void SetBannerImage()
        {
            WorldMapsForm.SetBannerImage();
        }

        // Editor loading
        private void LoadPaletteEditor()
        {
            if (paletteEditor == null)
            {
                paletteEditor = new PaletteEditor(new PaletteUpdater(), PaletteSet, 8, 0, 8);
                paletteEditor.Owner = this;
            }
            else
                paletteEditor.Reload(PaletteSet, 8, 0, 8);
        }
        private void LoadGraphicEditor()
        {
            if (graphicEditor == null)
            {
                graphicEditor = new GraphicEditor(new GraphicUpdater(), Model.Logos_Graphics, Model.Logos_Graphics.Length, 0, Model.Logos_PaletteSet, 0, 0x20);
                graphicEditor.Owner = this;
            }
            else
                graphicEditor.Reload(Model.Logos_Graphics, Model.Logos_Graphics.Length, 0, Model.Logos_PaletteSet, 0, 0x20);
        }
        private void LoadLogoPaletteEditor()
        {
            var ownerForm = LazyShell.Model.Program.WorldMaps.WorldMapsForm;
            if (logoPaletteEditor == null)
            {
                logoPaletteEditor = new PaletteEditor(new LogoPaletteUpdater(), Model.Logos_PaletteSet, 1, 0, 1);
                logoPaletteEditor.Owner = ownerForm;
            }
            else
                logoPaletteEditor.Reload(Model.Logos_PaletteSet, 1, 0, 1);
        }
        private void LoadLogoGraphicEditor()
        {
            if (logoGraphicEditor == null)
            {
                logoGraphicEditor = new GraphicEditor(new LogoGraphicUpdater(), Model.Logos_Graphics, Model.Logos_Graphics.Length, 0, Model.Logos_PaletteSet, 0, 0x20);
                logoGraphicEditor.Owner = this;
            }
            else
                logoGraphicEditor.Reload(Model.Logos_Graphics, Model.Logos_Graphics.Length, 0, Model.Logos_PaletteSet, 0, 0x20);
        }
        private void LoadSpriteGraphicEditor()
        {
            if (spriteGraphicEditor == null)
            {
                spriteGraphicEditor = new GraphicEditor(new LogoGraphicUpdater(),
                    Model.Sprites_Graphics, Model.Sprites_Graphics.Length, 0, logoPalette, 0, 0x20);
                spriteGraphicEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
                spriteGraphicEditor.Owner = this;
            }
            else
                spriteGraphicEditor.Reload(Model.Sprites_Graphics, Model.Sprites_Graphics.Length, 0, logoPalette, 0, 0x20);
        }
        private void LoadTileEditor()
        {
            WorldMapsForm.LoadTileEditor();
        }
        public void UpdatePalette()
        {
            Tileset = new Tileset(Tileset_bytes, Model.Graphics, PaletteSet, 16, 16, TilesetType.WorldMap);
            SetWorldMapImage();
            LoadGraphicEditor();
            LoadTileEditor();
            Modified = true;   // b/c switching colors won't modify checksum
        }
        public void UpdateGraphics()
        {
            Tileset = new Tileset(Tileset_bytes, Model.Graphics, PaletteSet, 16, 16, TilesetType.WorldMap);
            SetWorldMapImage();
            LoadTileEditor();
        }
        public void UpdateLogoGraphics()
        {
            LogoTileset = new Tileset(Model.Logos_Tileset, Model.Logos_Graphics, Model.Logos_PaletteSet, 16, 16, TilesetType.WorldMapLogo);
            SetBannerImage();
            Modified = true;
        }
        public void UpdateLogoPalette()
        {
            LogoTileset = new Tileset(Model.Logos_Tileset, Model.Logos_Graphics, Model.Logos_PaletteSet, 16, 16, TilesetType.WorldMapLogo);
            SetBannerImage();
            LoadLogoGraphicEditor();
            Modified = true;
        }
        public void UpdateTile()
        {
            Tileset.ParseTileset(Tileset.Tileset_tiles, Tileset.Tileset_bytes);
            SetWorldMapImage();
        }

        // Editor updating

        // Saving
        public void WriteToROM()
        {
            Model.ROM[0x037DCF] = (byte)this.music.SelectedIndex;
            WorldMapsForm.WriteToROM();
            LocationsForm.WriteToROM();
        }

        #endregion

        #region Event Handlers

        // menu strip
        private void save_Click(object sender, EventArgs e)
        {
            WriteToROM();
        }
        private void import_Click(object sender, EventArgs e)
        {
            new IOElements(worldMaps, IOMode.Import, Index, "IMPORT WORLD MAPS...").ShowDialog();
            WorldMapsForm.LoadProperties();
        }
        private void export_Click(object sender, EventArgs e)
        {
            new IOElements(worldMaps, IOMode.Export, Index, "EXPORT WORLD MAPS...").ShowDialog();
        }
        private void clear_Click(object sender, EventArgs e)
        {
            ClearElements clearElements = new ClearElements(worldMaps, Index, "CLEAR WORLD MAPS...");
            clearElements.ShowDialog();
            if (clearElements.DialogResult == DialogResult.Cancel)
                return;
            WorldMapsForm.LoadProperties();
        }
        private void resetWorldMap_Click(object sender, EventArgs e)
        {
            WorldMapsForm.Reset();
        }
        private void resetLocation_Click(object sender, EventArgs e)
        {
            LocationsForm.Reset();
        }

        // open editors
        private void openPalettesWorldMaps_Click(object sender, EventArgs e)
        {
            if (paletteEditor == null)
                LoadPaletteEditor();
            paletteEditor.Show(this);
        }
        private void openGraphicsWorldMaps_Click(object sender, EventArgs e)
        {
            if (graphicEditor == null)
                LoadGraphicEditor();
            graphicEditor.Show(this);
        }
        private void openGraphicsLogos_Click(object sender, EventArgs e)
        {
            if (logoGraphicEditor == null)
                LoadLogoGraphicEditor();
            logoGraphicEditor.Show(this);
        }
        private void openPalettesLogos_Click(object sender, EventArgs e)
        {
            if (logoPaletteEditor == null)
                LoadLogoPaletteEditor();
            logoPaletteEditor.Show(this);
        }
        private void openGraphicsSprites_Click(object sender, EventArgs e)
        {
            if (spriteGraphicEditor == null)
                LoadSpriteGraphicEditor();
            spriteGraphicEditor.Show(this);
        }
        private void editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.FormOwnerClosing)
            {
                e.Cancel = true;
                (sender as Form).Hide();
            }
        }

        #endregion
    }
}
