using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using LazyShell.Properties;
using LazyShell.Undo;
using WeifenLuo.WinFormsUI.Docking;

namespace LazyShell.Areas
{
    public partial class OwnerForm : MapEditor
    {
        #region Variables

        // Index
        public int Index
        {
            get { return (int)areaNum.Value; }
            set { areaNum.Value = value; }
        }

        // Miscellaneous
        private State state;
        private Settings settings;
        private Collision collision;

        // Navigation
        private Stack<int> navigateBackward;
        private Stack<int> navigateForward;
        private int lastNavigate = 0;
        private bool disableNavigate = false;

        // Element forms
        public PropertiesForm PropertiesForm { get; set; }
        public MapForm MapForm { get; set; }
        public LayeringForm LayeringForm { get; set; }
        public PriorityForm PriorityForm { get; set; }
        public NPCsForm NPCsForm { get; set; }
        public ExitsForm ExitsForm { get; set; }
        public EventsForm EventsForm { get; set; }
        public OverlapsForm OverlapsForm { get; set; }
        public TileSwitchesForm TileSwitchesForm { get; set; }
        public CollisionSwitchesForm CollisionSwitchesForm { get; set; }

        // Map forms
        public CollisionTileForm CollisionTileForm { get; set; }
        public ChunksForm ChunksForm { get; set; }

        // Elements
        private Area[] areas
        {
            get { return Model.Areas; }
            set { Model.Areas = value; }
        }
        private Map[] maps
        {
            get { return Model.Maps; }
            set { Model.Maps = value; }
        }
        private Layering layering
        {
            get { return Area.Layering; }
            set { Area.Layering = value; }
        }
        private PaletteSet[] paletteSets
        {
            get { return Model.PaletteSets; }
            set { Model.PaletteSets = value; }
        }
        private PrioritySet[] prioritySets
        {
            get { return Model.PrioritySets; }
            set { Model.PrioritySets = value; }
        }
        private CollisionTile[] collisionTiles
        {
            get { return Model.CollisionTiles; }
            set { Model.CollisionTiles = value; }
        }
        private SpritePartitioning[] spritePartitions
        {
            get { return Model.SpritePartitions; }
        }
        private NPCProperties[] npcProperties
        {
            get { return Model.NPCProperties; }
            set { Model.NPCProperties = value; }
        }
        private NPCObjectCollection npcObjects
        {
            get { return Area.NPCObjects; }
            set { Area.NPCObjects = value; }
        }
        private EventTriggerCollection eventTriggers
        {
            get { return Area.EventTriggers; }
            set { Area.EventTriggers = value; }
        }
        private ExitTriggerCollection exitTriggers
        {
            get { return Area.ExitTriggers; }
            set { Area.ExitTriggers = value; }
        }
        private OverlapCollection overlaps
        {
            get { return Area.Overlaps; }
            set { Area.Overlaps = value; }
        }
        private TileSwitchCollection tileSwitches
        {
            get { return Area.TileSwitches; }
            set { Area.TileSwitches = value; }
        }
        private CollisionSwitchCollection collisionSwitches
        {
            get { return Area.CollisionSwitches; }
            set { Area.CollisionSwitches = value; }
        }
        public Area Area
        {
            get { return areas[Index]; }
            set { areas[Index] = value; }
        }
        public Map Map
        {
            get { return maps[Area.Map]; }
            set { maps[Area.Map] = value; }
        }
        public new PaletteSet PaletteSet
        {
            get { return paletteSets[Map.PaletteSet]; }
            set { paletteSets[Map.PaletteSet] = value; }
        }

        // Maps
        public CollisionMap CollisionMap { get; set; }

        // Updating
        private Area lastArea;
        private delegate void UpdateFunction();

        // Picture
        public Controls.NewPictureBox Picture
        {
            get { return TilemapForm.Picture; }
            set { TilemapForm.Picture = value; }
        }
        public int Zoom
        {
            get { return TilemapForm.Zoom; }
        }

        // Helper forms
        private Search searchWindow;
        private EditLabel labelWindow;
        private PreviewerForm previewerForm;
        private SpaceAnalyzer spaceAnalyzerForm;
        private FindReferences findReferencesForm;
        private delegate void FindReferencesFunction(TreeView treeView);

        #endregion

        // Constructor
        public OwnerForm()
        {
            InitializeComponent();
            //
            CreateShortcuts();
            CreateHelperForms();
            InitializeVariables();
            InitializeListControls();
            InitializeNavigators();
            InitializeForms();
            LoadArea();
            //
            LoadCollisionTileForm();
            //
            this.History = new History(this, areaName, areaNum);
        }

        #region Methods

        #region Initialization

        private void CreateShortcuts()
        {
            Do.AddShortcut(toolStripToggle, Keys.Control | Keys.S, new EventHandler(save_Click));
            Do.AddShortcut(toolStripToggle, Keys.F1, helpTips);
            Do.AddShortcut(toolStripToggle, Keys.F2, baseConvertor);
        }
        private void CreateHelperForms()
        {
            searchWindow = new Search(areaNum, searchLocationNames, areaName.Items);
            labelWindow = new EditLabel(areaName, areaNum, "Areas", true);
            new ToolTipLabel(this, baseConvertor, helpTips);
        }
        private void InitializeListControls()
        {
            this.Updating = true;
            //
            this.areaInfo.Columns.AddRange(new ColumnHeader[] 
            { 
                new ColumnHeader(), new ColumnHeader() 
            });
            this.areaName.Items.Clear();
            this.areaName.Items.AddRange(Lists.Numerize(Lists.Areas));
            //
            this.Updating = false;
        }
        private void InitializeNavigators()
        {
            this.Updating = true;
            //
            if (settings.RememberLastIndex)
            {
                areaNum.Value = settings.LastArea;
                areaName.SelectedIndex = settings.LastArea;
            }
            else
                areaName.SelectedIndex = 0;
            //
            this.Updating = false;
        }
        private void InitializeVariables()
        {
            state = State.Instance;
            Overlay = new Overlay();
            settings = Settings.Default;
            collision = Collision.Instance;

            // Navigation
            navigateBackward = new Stack<int>();
            navigateForward = new Stack<int>();

            //
            lastArea = new Area();
        }
        private void InitializeForms()
        {
            // Element forms
            PropertiesForm = new PropertiesForm(this);
            LayeringForm = new LayeringForm(this);
            PriorityForm = new PriorityForm(this);
            MapForm = new MapForm(this);
            NPCsForm = new NPCsForm(this);
            ExitsForm = new ExitsForm(this);
            EventsForm = new EventsForm(this);
            OverlapsForm = new OverlapsForm(this);
            TileSwitchesForm = new TileSwitchesForm(this);
            CollisionSwitchesForm = new CollisionSwitchesForm(this);

            // Assign toggle buttons to forms
            PropertiesForm.ToggleButton = togglePropertiesForm;
            LayeringForm.ToggleButton = toggleLayeringForm;
            PriorityForm.ToggleButton = togglePriorityForm;
            MapForm.ToggleButton = toggleMapForm;
            NPCsForm.ToggleButton = toggleNPCsForm;
            ExitsForm.ToggleButton = toggleExitsForm;
            EventsForm.ToggleButton = toggleEventsForm;
            OverlapsForm.ToggleButton = toggleOverlapsForm;
            TileSwitchesForm.ToggleButton = toggleTileSwitchesForm;
            CollisionSwitchesForm.ToggleButton = toggleCollisionSwitchesForm;

            // Assign VisibleChanged event handlers
            PropertiesForm.VisibleChanged += new EventHandler(OwnedForm_VisibleChanged);
            LayeringForm.VisibleChanged += new EventHandler(OwnedForm_VisibleChanged);
            PriorityForm.VisibleChanged += new EventHandler(OwnedForm_VisibleChanged);
            MapForm.VisibleChanged += new EventHandler(OwnedForm_VisibleChanged);
            NPCsForm.VisibleChanged += new EventHandler(OwnedForm_VisibleChanged);
            ExitsForm.VisibleChanged += new EventHandler(OwnedForm_VisibleChanged);
            EventsForm.VisibleChanged += new EventHandler(OwnedForm_VisibleChanged);
            OverlapsForm.VisibleChanged += new EventHandler(OwnedForm_VisibleChanged);
            TileSwitchesForm.VisibleChanged += new EventHandler(OwnedForm_VisibleChanged);
            CollisionSwitchesForm.VisibleChanged += new EventHandler(OwnedForm_VisibleChanged);

            //
            PropertiesForm.Show(dockPanel, DockState.DockLeft);
            PriorityForm.Show(dockPanel, DockState.DockLeft);
            LayeringForm.Show(dockPanel, DockState.DockLeft);
            MapForm.Show(dockPanel, DockState.DockLeft);
            NPCsForm.Show(dockPanel, DockState.DockLeft);
            ExitsForm.Show(dockPanel, DockState.DockLeft);
            EventsForm.Show(dockPanel, DockState.DockLeft);
            OverlapsForm.Show(dockPanel, DockState.DockLeft);
            TileSwitchesForm.Show(dockPanel, DockState.DockLeft);
            CollisionSwitchesForm.Show(dockPanel, DockState.DockLeft);
            PropertiesForm.Hide();
            PriorityForm.Hide();
            LayeringForm.Hide();
            MapForm.Hide();
            NPCsForm.Hide();
            ExitsForm.Hide();
            EventsForm.Hide();
            OverlapsForm.Hide();
            TileSwitchesForm.Hide();
            CollisionSwitchesForm.Hide();
        }

        //
        private void LoadArea()
        {
            this.Updating = true;

            // Load the properties forms
            PropertiesForm.LoadProperties();
            LayeringForm.LoadProperties();
            PriorityForm.LoadProperties();
            MapForm.LoadProperties();
            NPCsForm.LoadProperties();
            ExitsForm.LoadProperties();
            EventsForm.LoadProperties();
            OverlapsForm.LoadProperties();
            TileSwitchesForm.LoadProperties();
            CollisionSwitchesForm.LoadProperties();

            // Don't refresh tile editing components if map and priority same as previous index
            if (lastArea.Map != Area.Map || lastArea.PrioritySet != Area.PrioritySet)
            {
                Tileset = new Tileset(Map, PaletteSet);
                Tilemap = new AreaTilemap(Area, Tileset);
                CollisionMap = new CollisionMap(Map);

                // Load the editor forms
                LoadTilesetForm();
                LoadTilemapForm();
                LoadChunksForm();
            }
            ReloadPreviewerForm();

            // Reset overlay
            Overlay.NPCImages = null;
            Picture.Invalidate();

            // Clear tilemap and pixel data for switch collections
            foreach (var area in areas)
            {
                area.TileSwitches.ClearTilemaps();
                area.CollisionSwitches.ClearTilemaps();
            }
            foreach (var collisionSwitch in collisionSwitches)
                collisionSwitch.Pixels = collision.GetTilemapPixels(collisionSwitch);

            // Set text for cells in area info listView
            SetAreaInfo();

            // Finished
            lastArea = Area;
            this.Updating = false;
        }
        //
        private void SetAreaInfo()
        {
            var items = new List<string[]>();
            items.Add(new string[] { "Layer", ((Index * 18) + 0x1D0040).ToString("X6") });
            items.Add(new string[] { "Map", ((Index * 2) + 0x148000).ToString("X6") });
            int pointer = Bits.GetShort(Model.ROM, (Index * 2) + 0x148000);
            int offset = Bits.GetShort(Model.ROM, pointer);
            items.Add(new string[] { "NPC", (offset + 0x140000).ToString("X6") });
            pointer = (Index * 2) + 0x1D2D64;
            offset = Bits.GetShort(Model.ROM, pointer);
            items.Add(new string[] { "Exit", (offset + 0x1D0000).ToString("X6") });
            pointer = (Index * 2) + 0x20E000;
            offset = Bits.GetShort(Model.ROM, pointer);
            items.Add(new string[] { "Event", (offset + 0x200000).ToString("X6") });
            pointer = (Index * 2) + 0x1D4905;
            offset = Bits.GetShort(Model.ROM, pointer);
            items.Add(new string[] { "Overlap", (offset + 0x1D0000).ToString("X6") });
            pointer = (Index * 2) + 0x1D5EBD;
            offset = Bits.GetShort(Model.ROM, pointer);
            items.Add(new string[] { "Tile switch", (offset + 0x1D0000).ToString("X6") });
            pointer = (Index * 2) + 0x1D8DB0;
            offset = Bits.GetShort(Model.ROM, pointer);
            items.Add(new string[] { "Collision switch", (offset + 0x1D0000).ToString("X6") });
            var listViewItems = new ListViewItem[items.Count];
            for (int i = 0; i < items.Count; i++)
                listViewItems[i] = new ListViewItem(items[i]);
            areaInfo.Columns[0].Text = "Element";
            areaInfo.Columns[1].Text = "Offset";
            areaInfo.Items.Clear();
            areaInfo.Items.AddRange(listViewItems);
        }
        private void SaveLastLoadedIndex()
        {
            settings.LastArea = (int)areaNum.Value;
        }

        #endregion

        #region Form Management

        // Loading
        public void LoadGraphicEditor()
        {
            if (GraphicEditor == null)
            {
                GraphicEditor = new GraphicEditor(new GraphicUpdater(), Tileset.Graphics, Tileset.Graphics.Length, 0, PaletteSet, 1, 0x20);
                GraphicEditor.Owner = this;
            }
            else
                ReloadGraphicEditor();
        }
        public void LoadPaletteEditor()
        {
            if (PaletteEditor == null)
            {
                PaletteEditor = new PaletteEditor(new PaletteUpdater(), PaletteSet, 8, 1, 7);
                PaletteEditor.Owner = this;
            }
            else
                ReloadPaletteEditor();
        }
        public void LoadTilemapForm()
        {
            if (TilemapForm == null)
            {
                this.TilemapForm = new TilemapForm(this);
                this.TilemapForm.ToggleButton = toggleTilemapForm;
                this.TilemapForm.Show(dockPanel, DockState.Document);
            }
            else
                TilemapForm.Reload(this);
        }
        public void LoadTilesetForm()
        {
            if (TilesetForms[0] == null)
            {
                for (int i = 0; i < 3; i++)
                {
                    this.TilesetForms[i] = new TilesetForm(this, i);
                    if (i == 0)
                        this.TilesetForms[i].ToggleButton = toggleTilesetL1Form;
                    else if (i == 1)
                        this.TilesetForms[i].ToggleButton = toggleTilesetL2Form;
                    else if (i == 2)
                        this.TilesetForms[i].ToggleButton = toggleTilesetL3Form;
                    this.TilesetForms[i].Show(dockPanel, DockState.DockRight);
                }
                this.TilesetForms[0].Show();
            }
            else
            {
                for (int i = 0; i < 3; i++)
                    TilesetForms[i].Reload(this);
            }
        }
        private void LoadCollisionTileForm()
        {
            if (CollisionTileForm == null)
            {
                CollisionTileForm = new CollisionTileForm(collision, new UpdateFunction(UpdateCollisionMap));
                if (!TilesetForm.Visible)
                    CollisionTileForm.Left = TilemapForm.Right + 10;
                else
                    CollisionTileForm.Left = TilesetForm.Right + 10;
                CollisionTileForm.Top = this.Bottom + 10;
                CollisionTileForm.ToggleButton = toggleCollisionTileForm;
                CollisionTileForm.DockPanel = dockPanel;
            }
        }
        private void LoadChunksForm()
        {
            if (ChunksForm == null)
            {
                ChunksForm = new ChunksForm(this, this.Overlay);
                if (!TilesetForm.Visible)
                    ChunksForm.Left = TilemapForm.Right + 10;
                else
                    ChunksForm.Left = TilesetForm.Right + 10;
                ChunksForm.Top = this.Bottom + 10;
                ChunksForm.ToggleButton = toggleChunksForm;
                ChunksForm.DockPanel = dockPanel;
            }
            else
                ChunksForm.SetChunkImage();
        }
        private void LoadPreviewerForm()
        {
            if (previewerForm == null)
            {
                previewerForm = new PreviewerForm(Index, ElementType.Area);
                previewerForm.Owner = this;
            }
            else
                ReloadPreviewerForm();
        }

        // Updating
        public void UpdateGraphics()
        {
            if (this.IsClosing)
                return;
            Tileset.WriteToModel(16, this.Layer);
            Tileset.BuildTilesetTiles();
            foreach (var tilesetForm in TilesetForms)
                tilesetForm.SetTilesetImage();
            Tilemap.RedrawTilemaps();
            TilemapForm.SetTilemapImage();
        }
        public void UpdatePalette()
        {
            if (this.IsClosing)
                return;
            Tileset.BuildTilesetTiles();
            foreach (var tilesetForm in TilesetForms)
                tilesetForm.SetTilesetImage();
            Tilemap.RedrawTilemaps();
            TilemapForm.SetTilemapImage();
            Modified = true;   // b/c switching colors won't modify checksum
        }
        public void UpdateTileset()
        {
            if (this.IsClosing)
                return;
            Tileset.BuildTilesetTiles();
            foreach (var tilesetForm in TilesetForms)
                tilesetForm.SetTilesetImage();
            Tilemap.RedrawTilemaps();
            TilemapForm.SetTilemapImage();
        }

        // Reloading
        public void ReloadGraphicEditor()
        {
            if (GraphicEditor != null)
                GraphicEditor.Reload(Tileset.Graphics, Tileset.Graphics.Length, 0, PaletteSet, 1, 0x20);
        }
        public void ReloadPaletteEditor()
        {
            if (PaletteEditor != null)
                PaletteEditor.Reload(PaletteSet, 8, 1, 7);
            ReloadGraphicEditor();
        }
        private void ReloadCollisionTileForm()
        {
        }
        private void ReloadPreviewerForm()
        {
            if (previewerForm != null)
                previewerForm.Reload((int)this.areaNum.Value, ElementType.Area);
        }
        private void ShowEditorForm(Form form)
        {
            if (!form.Visible)
                form.Location = new Point(Cursor.Position.X + 20, Cursor.Position.Y + 20);
            form.Show();
        }

        // Updating
        public void UpdateCollisionMap()
        {
            if (this.IsClosing)
                return;
            CollisionMap = new CollisionMap(this.Map);
            CollisionMap.Image = null;
            LoadTilemapForm();
        }

        #endregion

        // Search
        private void FindReferences(TreeView treeView)
        {
            // look through event scripts
            var eventScriptResults = new TreeNode();
            foreach (var eventScript in EventScripts.Model.EventScripts)
            {
                foreach (var command in eventScript.Commands)
                {
                    byte opcode = command.Opcode;
                    byte param1 = command.Param1;
                    if (opcode == 0x68 || opcode == 0x6A || opcode == 0x6B ||
                        opcode == 0xF2 || opcode == 0xF3 || opcode == 0xF8 ||
                        (opcode == 0xFD && param1 == 0xF0))
                    {
                        int referenceArea = 0;
                        if (opcode != 0xFD)
                            referenceArea = Bits.GetShort(command.Data, 1) & 0x1FF;
                        else
                            referenceArea = Bits.GetShort(command.Data, 2) & 0x1FF;
                        // if references this index, create a node from result and add to the parent node
                        if (referenceArea == this.Index)
                        {
                            var result = command.Node;
                            result.Tag = command;
                            eventScriptResults.Nodes.Add(result);
                        }
                    }
                    // Check commands in action queue
                    else if (command.QueueTrigger && command.Queue != null)
                    {
                        foreach (var actionCommand in command.Queue.Commands)
                        {
                            opcode = actionCommand.Opcode;
                            param1 = actionCommand.Param1;
                            if (opcode == 0xF2 || opcode == 0xF3 || opcode == 0xF8)
                            {
                                int referenceArea = Bits.GetShort(command.Data, 1) & 0x1FF;
                                // if references this index, create a node from result and add to the parent node
                                if (referenceArea == this.Index)
                                {
                                    var result = command.Node;
                                    result.Tag = command;
                                    eventScriptResults.Nodes.Add(result);
                                }
                            }
                        }
                    }
                }
            }
            if (eventScriptResults.Nodes.Count > 0)
            {
                eventScriptResults.Text = "EVENT SCRIPTS — found " + eventScriptResults.Nodes.Count + " results";
                treeView.Nodes.Add(eventScriptResults);
            }
        }

        // Saving
        public void WriteToROM()
        {
            if (!this.Modified)
                return;
            settings.Save();
            foreach (var l in areas)
                l.WriteToROM();
            foreach (var ps in prioritySets)
                ps.WriteToROM();
            foreach (var mp in maps)
                mp.WriteToROM();
            foreach (var ps in paletteSets)
                ps.WriteToBuffer(1);
            foreach (var np in npcProperties)
                np.WriteToROM();
            foreach (var st in collisionTiles)
                st.WriteToROM();
            foreach (var sp in spritePartitions)
                sp.WriteToROM();
            int offsetStart = 0x3166;
            if (Model.FreeExitSpace() >= 0)
            {
                for (int i = 0; i < 512; i++)
                    areas[i].ExitTriggers.WriteToROM(ref offsetStart);
            }
            else
                MessageBox.Show("Exit fields were not saved because they exceed the maximum alotted space.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            offsetStart = 0xE400;
            if (Model.FreeEventSpace() >= 6)
            {
                for (int i = 0; i < 512; i++)
                    areas[i].EventTriggers.WriteToROM(ref offsetStart);
            }
            else
                MessageBox.Show("Event fields were not saved because they exceed the maximum alotted space.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            offsetStart = 0x8400;
            if (Model.FreeNPCSpace() >= 4)
            {
                for (int i = 0; i < 512; i++)
                    areas[i].NPCObjects.WriteToROM(ref offsetStart);
            }
            else
                MessageBox.Show("NPCs were not saved because they exceed the maximum alotted space.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            offsetStart = 0x4D05;
            if (Model.FreeOverlapSpace() >= 0)
            {
                for (int i = 0; i < 512; i++)
                    areas[i].Overlaps.WriteToROM(ref offsetStart);
            }
            else
                MessageBox.Show("Overlaps were not saved because they exceed the maximum alotted space.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            int offset = 0x1D62BD;
            if (Model.FreeTileSwitchSpace() >= 0)
            {
                for (int i = 0; i < 512; i++)
                    areas[i].TileSwitches.WriteToROM(ref offset);
            }
            else
                MessageBox.Show("Tile switches were not saved because they exceed the maximum alotted space.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            offset = 0x1D91B0;
            if (Model.FreeCollisionSwitchSpace() >= 0)
            {
                for (int i = 0; i < 512; i++)
                    areas[i].CollisionSwitches.WriteToROM(ref offset);
            }
            else
                MessageBox.Show("Collision switches were not saved because they exceed the maximum alotted space.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Comp.Compress(Model.GraphicSets, Model.Modify_GraphicSets, 0x0A0000, 0x146000, "GRAPHIC SET", 0, 78, 94, 111, 129, 147, 167, 184, 204, 236, 261);
            Tilemap.ParseTilemap();
            Comp.Compress(Model.Tilemaps, Model.Modify_Tilemaps, 0x160000, 0x1A8000, "TILE MAP", 0, 109, 163, 219, 275);
            Comp.Compress(Model.CollisionMaps, Model.Modify_CollisionMaps, 0x1B0000, 0x1C8000, "COLLISION MAP", 0, 80);
            Comp.Compress(Model.Tilesets, Model.Modify_Tilesets, 0x3B0000, 0x3DC000, "TILE SET", 0, 58, 91);
            LazyShell.Model.HexEditor.HighlightChanges();
            this.Modified = false;
        }

        #endregion

        #region Event Handlers

        // OwnerForm
        private void OwnerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.IsClosing = true;
            if (!this.Modified && !TilemapForm.Modified && !TilesetForm.Modified)
            {
                settings.Save();
                return;
            }
            state.ClearDrawing();
            state.TileGrid = false;
            state.IsometricGrid = false;
            var result = MessageBox.Show("Areas have not been saved.\n\nWould you like to save changes?",
                "LAZY SHELL", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                WriteToROM();
            else if (result == DialogResult.No)
                Model.ClearAll();
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
                this.IsClosing = false;
            }
        }
        private void OwnerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
        }
        private void OwnedForm_VisibleChanged(object sender, EventArgs e)
        {
            var ownedForm = sender as Controls.DockForm;
            if (ownedForm.Visible && ownedForm.Location.X == 0 && ownedForm.Location.Y == 0)
                ownedForm.Location = new Point(Cursor.Position.X + 10, Cursor.Position.Y + 10);
        }

        // Navigating
        private void areaNum_ValueChanged(object sender, EventArgs e)
        {
            areaName.SelectedIndex = (int)areaNum.Value;
            if (!this.Updating)
            {
                LoadArea();
                SaveLastLoadedIndex();
                //
                if (!disableNavigate)
                {
                    navigateBackward.Push(lastNavigate);
                    navigateBck.Enabled = true;
                    lastNavigate = Index;
                }
            }
        }
        private void areaName_SelectedIndexChanged(object sender, EventArgs e)
        {
            areaNum.Value = areaName.SelectedIndex;
        }
        private void navigateBck_Click(object sender, EventArgs e)
        {
            if (navigateBackward.Count < 1)
                return;
            navigateForward.Push(Index);
            Index = navigateBackward.Peek();
            //
            lastNavigate = Index;
            navigateBackward.Pop();
            navigateBck.Enabled = navigateBackward.Count > 0;
            navigateFwd.Enabled = true;
        }
        private void navigateFwd_Click(object sender, EventArgs e)
        {
            if (navigateForward.Count < 1)
                return;
            navigateBackward.Push(Index);
            Index = navigateForward.Peek();
            //
            lastNavigate = Index;
            navigateForward.Pop();
            navigateFwd.Enabled = navigateForward.Count > 0;
            navigateBck.Enabled = true;
        }
        private void findReferences_Click(object sender, EventArgs e)
        {
            if (findReferencesForm == null)
            {
                findReferencesForm = new FindReferences(new FindReferencesFunction(FindReferences), null);
                findReferencesForm.Owner = this;
            }
            else
                findReferencesForm.Reload();
            findReferencesForm.Show();
        }

        #region ToolStrip

        // ToolStrip : File management
        private void save_Click(object sender, EventArgs e)
        {
            WriteToROM();
        }
        private void statistics_Click(object sender, EventArgs e)
        {
            new StatsForm().Show();
        }
        private void import_ButtonClick(object sender, EventArgs e)
        {
        }
        private void export_ButtonClick(object sender, EventArgs e)
        {
        }
        private void clear_ButtonClick(object sender, EventArgs e)
        {
        }
        private void importArchitecture_Click(object sender, EventArgs e)
        {
            if (new IOArchitecture("import", Index, Map, PaletteSet, Tileset, Tilemap, prioritySets[layering.PrioritySet]).ShowDialog() == DialogResult.Cancel)
                return;
            LoadArea();
        }
        private void exportArchitecture_Click(object sender, EventArgs e)
        {
            new IOArchitecture("export", Index, Map, PaletteSet, Tileset, Tilemap, prioritySets[layering.PrioritySet]).ShowDialog();
        }
        private void importAreaData_Click(object sender, EventArgs e)
        {
            IOElements ioElements = new IOElements(areas, IOMode.Import, Index, "IMPORT AREA DATA...");
            if (ioElements.ShowDialog() == DialogResult.Cancel)
                return;
            LoadArea();
            if (Model.FreeNPCSpace() < 0)
                MessageBox.Show(Model.MaximumSpaceExceeded("npcs"), "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (Model.FreeExitSpace() < 0)
                MessageBox.Show(Model.MaximumSpaceExceeded("exits"), "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (Model.FreeEventSpace() < 0)
                MessageBox.Show(Model.MaximumSpaceExceeded("events"), "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (Model.FreeOverlapSpace() < 0)
                MessageBox.Show(Model.MaximumSpaceExceeded("overlaps"), "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void exportAreaData_Click(object sender, EventArgs e)
        {
            new IOElements(areas, IOMode.Export, Index, "EXPORT AREA DATA...").ShowDialog();
        }
        private void exportImages_Click(object sender, EventArgs e)
        {
            ExportImages exportImages = new ExportImages(Index, ElementType.Area);
            exportImages.ShowDialog();
        }

        // ToolStrip : Clear
        private void clearAllAreaData_Click(object sender, EventArgs e)
        {
            if (new ClearElements(null, Index, "CLEAR AREA DATA...").ShowDialog() == DialogResult.Cancel)
                return;
            LoadArea();
        }
        private void clearAllTilesets_Click(object sender, EventArgs e)
        {
            if (new ClearElements(null, (int)(Map.TilesetL1 + 0x20), "CLEAR TILESETS...").ShowDialog() == DialogResult.Cancel)
                return;
            new ClearElements(null, (int)(Map.TilesetL2 + 0x20), "CLEAR TILESETS...").AcceptButton.PerformClick();
            if (Map.GraphicSetL3 != 0xFF)
                new ClearElements(null, (int)(Map.TilesetL3), "CLEAR TILESETS...").AcceptButton.PerformClick();
            LoadArea();
        }
        private void clearAllTilemaps_Click(object sender, EventArgs e)
        {
            if (new ClearElements(null, (int)(Map.TilemapL1 + 0x40), "CLEAR TILEMAPS...").ShowDialog() == DialogResult.Cancel)
                return;
            new ClearElements(null, (int)(Map.TilemapL2 + 0x40), "CLEAR TILEMAPS...").AcceptButton.PerformClick();
            if (Map.GraphicSetL3 != 0xFF)
                new ClearElements(null, (int)(Map.TilemapL3), "CLEAR TILEMAPS...").AcceptButton.PerformClick();
            LoadArea();
        }
        private void clearAllCollisionMaps_Click(object sender, EventArgs e)
        {
        }
        private void clearAllComponentsAll_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "You are about to clear all area data, tilesets, tilemaps, physical maps and battlefields.\n" +
                "This will essentially wipe the slate clean for anything having to do with areas.\n\n" +
                "Are you sure you want to do this?", "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes)
                return;
            for (int i = 0; i < 510; i++)
            {
                areas[i].Layering.Clear();
                areas[i].EventTriggers.Clear();
                areas[i].ExitTriggers.Clear();
                areas[i].NPCObjects.Clear();
                areas[i].Overlaps.Clear();
            }
            for (int i = 0; i < Model.Tilesets.Length; i++)
            {
                if (i < 0x20)
                    Model.Tilesets[i] = new byte[0x1000];
                else
                    Model.Tilesets[i] = new byte[0x2000];
                Model.Modify_Tilesets[i] = true;
            }
            for (int i = 0; i < Model.Tilemaps.Length; i++)
            {
                if (i < 0x40)
                    Model.Tilemaps[i] = new byte[0x1000];
                else
                    Model.Tilemaps[i] = new byte[0x2000];
                Model.Modify_Tilemaps[i] = true;
            }
            for (int i = 0; i < Model.CollisionMaps.Length; i++)
            {
                Model.CollisionMaps[i] = new byte[0x20C2];
                Model.Modify_CollisionMaps[i] = true;
            }
            for (int i = 0; i < Battlefields.Model.Tilesets.Length; i++)
            {
                Battlefields.Model.Tilesets[i] = new byte[0x2000];
                Battlefields.Model.EditTilesets[i] = true;
            }
            CollisionMap.Image = null;
            LoadArea();
        }
        private void clearAllComponentsCurrent_Click(object sender, EventArgs e)
        {
            Area.Layering.Clear();
            Area.EventTriggers.Clear();
            Area.ExitTriggers.Clear();
            Area.NPCObjects.Clear();
            Area.Overlaps.Clear();
            Model.Tilesets[Map.TilesetL1 + 0x20] = new byte[0x2000];
            Model.Tilesets[Map.TilesetL2 + 0x20] = new byte[0x2000];
            Model.Tilesets[Map.TilesetL3] = new byte[0x1000];
            Model.Modify_Tilesets[Map.TilesetL1 + 0x20] = true;
            Model.Modify_Tilesets[Map.TilesetL2 + 0x20] = true;
            Model.Modify_Tilesets[Map.TilesetL3] = true;
            Model.Tilemaps[Map.TilemapL1 + 0x40] = new byte[0x2000];
            Model.Tilemaps[Map.TilemapL2 + 0x40] = new byte[0x2000];
            Model.Tilemaps[Map.TilemapL3] = new byte[0x1000];
            Model.Modify_Tilemaps[Map.TilemapL1 + 0x40] = true;
            Model.Modify_Tilemaps[Map.TilemapL2 + 0x40] = true;
            Model.Modify_Tilemaps[Map.TilemapL3] = true;
            CollisionMap.Clear(1);
            CollisionMap.Image = null;
            LoadArea();
        }
        private void clearUnusedGraphicSets_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "You are about to clear all UNUSED graphic sets.\n\n" +
                "Do you wish to continue?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
                return;
            // Clear unused tilesets
            bool[] used = new bool[Model.GraphicSets.Length];
            foreach (var area in areas)
            {
                var map = maps[area.Map];
                used[map.GraphicSet1 + 0x48] = true;
                used[map.GraphicSet2 + 0x48] = true;
                used[map.GraphicSet3 + 0x48] = true;
                used[map.GraphicSet4 + 0x48] = true;
                used[map.GraphicSet5 + 0x48] = true;
                used[map.GraphicSetL3] = true;
            }
            for (int i = 0; i < Model.Tilesets.Length; i++)
            {
                if (!used[i])
                {
                    Model.GraphicSets[i] = new byte[Model.GraphicSets[i].Length];
                    Model.Modify_GraphicSets[i] = true;
                }
            }
            LoadArea();
        }
        private void clearUnusedTilesets_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "You are about to clear all UNUSED tilesets.\n\n" +
                "Do you wish to continue?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
                return;
            // Clear unused tilesets
            bool[] used = new bool[Model.Tilesets.Length];
            foreach (var area in areas)
            {
                var map = maps[area.Map];
                used[map.TilesetL1 + 0x20] = true;
                used[map.TilesetL2 + 0x20] = true;
                used[map.TilesetL3] = true;
            }
            for (int i = 0; i < Model.Tilesets.Length; i++)
            {
                if (!used[i])
                {
                    Model.Tilesets[i] = new byte[i < 0x20 ? 0x1000 : 0x2000];
                    Model.Modify_Tilesets[i] = true;
                }
            }
            LoadArea();
        }
        private void clearUnusedTilemaps_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
              "You are about to clear all UNUSED tilemaps.\n\n" +
              "Do you wish to continue?",
              "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
                return;
            // Clear unused tilemaps
            bool[] used = new bool[Model.Tilemaps.Length];
            foreach (var area in areas)
            {
                var map = maps[area.Map];
                used[map.TilemapL1 + 0x40] = true;
                used[map.TilemapL2 + 0x40] = true;
                used[map.TilemapL3] = true;
            }
            for (int i = 0; i < Model.Tilemaps.Length; i++)
            {
                if (!used[i])
                {
                    Model.Tilemaps[i] = new byte[i < 0x40 ? 0x1000 : 0x2000];
                    Model.Modify_Tilemaps[i] = true;
                }
            }
            LoadArea();
        }
        private void clearUnusedCollisionMaps_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
              "You are about to clear all UNUSED collision maps.\n\n" +
              "Do you wish to continue?",
              "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
                return;
            // Clear unused physical maps
            bool[] used = new bool[Model.CollisionMaps.Length];
            foreach (Area area in areas)
            {
                var map = maps[area.Map];
                used[map.CollisionMap] = true;
            }
            for (int i = 0; i < Model.CollisionMaps.Length; i++)
            {
                if (!used[i])
                {
                    Model.CollisionMaps[i] = new byte[0x20C2];
                    Model.Modify_CollisionMaps[i] = true;
                }
            }
            LoadArea();
        }
        private void clearUnusedAll_Click(object sender, EventArgs e)
        {
            // Clear all unused components
            clearUnusedGraphicSets.PerformClick();
            clearUnusedTilesets.PerformClick();
            clearUnusedTilemaps.PerformClick();
            clearUnusedCollisionMaps.PerformClick();
        }
        private void exportArrays_Click(object sender, EventArgs e)
        {
            string fullPath = Do.GetDirectoryPath("Select directory to export arrays to...");
            fullPath += "\\" + LazyShell.Model.GetFileNameWithoutPath() + " - Arrays\\";
            // Create Area Data directory
            if (!Do.CreateDirectory(fullPath))
                return;
            //
            FileStream fs;
            BinaryWriter bw;
            for (int i = 0; i < Model.GraphicSets.Length; i++)
            {
                Do.CreateDirectory(fullPath + "Graphic Sets\\");
                fs = new FileStream(fullPath + "Graphic Sets\\graphic-set-" + i.ToString("d3") + ".bin", FileMode.Create, FileAccess.ReadWrite);
                bw = new BinaryWriter(fs);
                bw.Write(Model.GraphicSets[i], 0, Model.GraphicSets[i].Length);
                bw.Close();
                fs.Close();
            }
            for (int i = 0; i < Model.CollisionMaps.Length; i++)
            {
                Do.CreateDirectory(fullPath + "Collision Maps\\");
                fs = new FileStream(fullPath + "Collision Maps\\collision-map-" + i.ToString("d3") + ".bin", FileMode.Create, FileAccess.ReadWrite);
                bw = new BinaryWriter(fs);
                bw.Write(Model.CollisionMaps[i], 0, Model.CollisionMaps[i].Length);
                bw.Close();
                fs.Close();
            }
            for (int i = 0; i < Model.Tilemaps.Length; i++)
            {
                Do.CreateDirectory(fullPath + "Tilemaps\\");
                fs = new FileStream(fullPath + "Tilemaps\\tilemap-" + i.ToString("d3") + ".bin", FileMode.Create, FileAccess.ReadWrite);
                bw = new BinaryWriter(fs);
                bw.Write(Model.Tilemaps[i], 0, Model.Tilemaps[i].Length);
                bw.Close();
                fs.Close();
            }
            for (int i = 0; i < Model.Tilesets.Length; i++)
            {
                Do.CreateDirectory(fullPath + "Tilesets\\");
                fs = new FileStream(fullPath + "Tilesets\\tileset-" + i.ToString("d3") + ".bin", FileMode.Create, FileAccess.ReadWrite);
                bw = new BinaryWriter(fs);
                bw.Write(Model.Tilesets[i], 0, Model.Tilesets[i].Length);
                bw.Close();
                fs.Close();
            }
            for (int i = 0; i < Battlefields.Model.Tilesets.Length; i++)
            {
                Do.CreateDirectory(fullPath + "Battlefield Tilesets\\");
                fs = new FileStream(fullPath + "Battlefield Tilesets\\battlefield-tileset-" + i.ToString("d3") + ".bin", FileMode.Create, FileAccess.ReadWrite);
                bw = new BinaryWriter(fs);
                bw.Write(Battlefields.Model.Tilesets[i], 0, Battlefields.Model.Tilesets[i].Length);
                bw.Close();
                fs.Close();
            }
        }
        private void importArrays_Click(object sender, EventArgs e)
        {
            string fullPath = Do.GetDirectoryPath("Select directory to import arrays from...");
            fullPath += "\\";
            //
            FileStream fs;
            BinaryReader br;
            try
            {
                // Create the file to store the area data
                for (int i = 0; i < Model.GraphicSets.Length; i++)
                {
                    if (!File.Exists(fullPath + "Graphic Sets\\graphic-set-" + i.ToString("d3") + ".bin"))
                        continue;
                    fs = File.OpenRead(fullPath + "Graphic Sets\\graphic-set-" + i.ToString("d3") + ".bin");
                    br = new BinaryReader(fs);
                    Model.GraphicSets[i] = br.ReadBytes(Model.GraphicSets[i].Length);
                    br.Close();
                    fs.Close();
                    Model.Modify_GraphicSets[i] = true;
                }
                for (int i = 0; i < Model.CollisionMaps.Length; i++)
                {
                    if (!File.Exists(fullPath + "Collision Maps\\collision-map-" + i.ToString("d3") + ".bin"))
                        continue;
                    fs = File.OpenRead(fullPath + "Collision Maps\\collision-map-" + i.ToString("d3") + ".bin");
                    br = new BinaryReader(fs);
                    Model.CollisionMaps[i] = br.ReadBytes(Model.CollisionMaps[i].Length);
                    br.Close();
                    fs.Close();
                    Model.Modify_CollisionMaps[i] = true;
                }
                for (int i = 0; i < Model.Tilemaps.Length; i++)
                {
                    if (!File.Exists(fullPath + "Tilemaps\\tilemap-" + i.ToString("d3") + ".bin"))
                        continue;
                    fs = File.OpenRead(fullPath + "Tilemaps\\tilemap-" + i.ToString("d3") + ".bin");
                    br = new BinaryReader(fs);
                    Model.Tilemaps[i] = br.ReadBytes(Model.Tilemaps[i].Length);
                    br.Close();
                    fs.Close();
                    Model.Modify_Tilemaps[i] = true;
                }
                for (int i = 0; i < Model.Tilesets.Length; i++)
                {
                    if (!File.Exists(fullPath + "Tilesets\\tileset-" + i.ToString("d3") + ".bin"))
                        continue;
                    fs = File.OpenRead(fullPath + "Tilesets\\tileset-" + i.ToString("d3") + ".bin");
                    br = new BinaryReader(fs);
                    Model.Tilesets[i] = br.ReadBytes(Model.Tilesets[i].Length);
                    br.Close();
                    fs.Close();
                    Model.Modify_Tilesets[i] = true;
                }
                for (int i = 0; i < Battlefields.Model.Tilesets.Length; i++)
                {
                    if (!File.Exists(fullPath + "Battlefield Tilesets\\battlefield-tileset-" + i.ToString("d3") + ".bin"))
                        continue;
                    fs = File.OpenRead(fullPath + "Battlefield Tilesets\\battlefield-tileset-" + i.ToString("d3") + ".bin");
                    br = new BinaryReader(fs);
                    Battlefields.Model.Tilesets[i] = br.ReadBytes(Battlefields.Model.Tilesets[i].Length);
                    br.Close();
                    fs.Close();
                    Battlefields.Model.EditTilesets[i] = true;
                }
                LoadArea();
            }
            catch
            {
                MessageBox.Show("There was a problem importing the arrays.", "LAZY SHELL");
            }
        }
        private void exportGraphicSets_Click(object sender, EventArgs e)
        {
            BinaryWriter binWriter;
            string path = Do.GetDirectoryPath("Where do you want to save the graphic sets?");
            path += "\\" + LazyShell.Model.GetFileNameWithoutPath() + " - Graphic Sets\\";
            if (!Do.CreateDirectory(path))
                return;
            if (path == null)
                return;
            try
            {
                for (int i = 0; i < Model.GraphicSets.Length; i++)
                {
                    binWriter = new BinaryWriter(File.Open(path + "graphic-set-" + i.ToString("d3") + ".bin", FileMode.Create));
                    binWriter.Write(Model.GraphicSets[i]);
                    binWriter.Close();
                }
            }
            catch (Exception ioexc)
            {
                MessageBox.Show("Lazy Shell was unable to save the graphic sets.\n\n" + ioexc.Message, "LAZY SHELL");
            }
        }
        private void importGraphicSet_Click(object sender, EventArgs e)
        {
            string filename;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = settings.LastRomPath;
            openFileDialog1.Title = "Import graphic set";
            openFileDialog1.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
                filename = openFileDialog1.FileName;
            else
                return;
            string num = filename.Substring(filename.LastIndexOf('.') - 2, 2);
            int index = Int32.Parse(num, System.Globalization.NumberStyles.HexNumber);
            try
            {
                FileInfo fileInfo = new FileInfo(filename);
                if (fileInfo.Length != 8192)
                {
                    MessageBox.Show("File is incorrect size, Graphic Sets are 8192 bytes", "LAZY SHELL");
                    return;
                }
                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                Model.GraphicSets[index] = br.ReadBytes((int)fileInfo.Length);
                Model.Modify_GraphicSets[index] = true;
                br.Close();
                fs.Close();
                LoadArea();
                return;
            }
            catch (Exception ioexc)
            {
                MessageBox.Show("Lazy Shell was unable to Import the Graphic Set.\n\n" + ioexc.Message, "LAZY SHELL");
                return;
            }
        }
        private void dumpText_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.FileName = LazyShell.Model.GetFileNameWithoutPath() + " - NPCS.txt";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            var textWriter = File.CreateText(saveFileDialog.FileName);
            string temp;
            for (int a = 0; a < areas.Length; a++)
            {
                var area = areas[a];
                textWriter.WriteLine("[" + a.ToString("d3") + "]" +
                    "------------------------------------------------------------>");
                for (int i = 0, n = 0; n < area.NPCObjects.Count; n++, i++)
                {
                    var npcObject = area.NPCObjects[n];
                    if (npcObject.EngageType == EngageType.Event)
                        temp = npcObject.Event.ToString("d4");
                    else
                        temp = "N/A";
                    textWriter.WriteLine("NPC #" + i.ToString("d2") + ", event: " + temp +
                        ", action: " + npcObject.Action.ToString("d4"));
                }
                textWriter.WriteLine();
            }
            textWriter.Close();
        }

        // ToolStrip : Hex editor
        private void hexEditor_Click(object sender, EventArgs e)
        {
            LazyShell.Model.HexEditor.SetOffset((Index * 18) + 0x1D0040);
            LazyShell.Model.HexEditor.HighlightChanges();
            LazyShell.Model.HexEditor.Show();
        }

        // ToolStrip : Reset
        private void resetMap_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current area map. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            Map = new Map(Area.Map);
            MapForm.LoadProperties();
            MapForm.MapChanged();
        }
        private void resetLayering_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current layer data. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            layering = new Layering(Index);
            areaNum_ValueChanged(null, null);
        }
        private void resetNPCs_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current NPCs. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            npcObjects = new NPCObjectCollection(Index);
            Overlay.NPCImages = null;
            NPCsForm.LoadProperties();
        }
        private void resetEvents_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current events. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            eventTriggers = new EventTriggerCollection(Index);
            EventsForm.LoadProperties();
        }
        private void resetOverlaps_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current overlaps. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            overlaps = new OverlapCollection(Index);
            OverlapsForm.LoadProperties();
        }
        private void resetTileSwitches_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current tilemap switches. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            tileSwitches = new TileSwitchCollection(Index);
            foreach (var area in areas)
                area.TileSwitches.ClearTilemaps();
            foreach (var tileSwitch in tileSwitches.TileSwitches)
            {
                tileSwitch.TilemapA = new AreaTilemap(Area, Tileset, tileSwitch, false);
                if (tileSwitch.Alternate)
                    tileSwitch.TilemapB = new AreaTilemap(Area, Tileset, tileSwitch, true);
            }
            TileSwitchesForm.LoadProperties();
        }
        private void resetCollisionSwitches_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current collision switches. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            collisionSwitches = new CollisionSwitchCollection(Index);
            foreach (var a in areas)
                a.CollisionSwitches.ClearTilemaps();
            foreach (var collisionSwitch in collisionSwitches.CollisionSwitches)
                collisionSwitch.Pixels = collision.GetTilemapPixels(collisionSwitch);
            CollisionSwitchesForm.LoadProperties();
        }
        private void resetGraphicSet_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current graphic sets. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            Comp.Decompress(Model.GraphicSets, 0x0A0000, 0x150000, 0x2000, "", Map.GraphicSet1 + 0x48, Map.GraphicSet1 + 0x49, false);
            Comp.Decompress(Model.GraphicSets, 0x0A0000, 0x150000, 0x2000, "", Map.GraphicSet2 + 0x48, Map.GraphicSet2 + 0x49, false);
            Comp.Decompress(Model.GraphicSets, 0x0A0000, 0x150000, 0x2000, "", Map.GraphicSet3 + 0x48, Map.GraphicSet3 + 0x49, false);
            Comp.Decompress(Model.GraphicSets, 0x0A0000, 0x150000, 0x2000, "", Map.GraphicSet4 + 0x48, Map.GraphicSet4 + 0x49, false);
            Comp.Decompress(Model.GraphicSets, 0x0A0000, 0x150000, 0x2000, "", Map.GraphicSet5 + 0x48, Map.GraphicSet5 + 0x49, false);
            LoadArea();
        }
        private void resetPaletteSet_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current palette set. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            int palette = Map.PaletteSet;
            PaletteSet = new PaletteSet(Model.ROM, palette, (palette * 0xD4) + 0x249FE2, 8, 16, 30);
            LoadArea();
        }
        private void resetTilesets_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current tilesets. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            Comp.Decompress(Model.Tilesets, 0x3B0000, 0x3E0000, 0x1000, "", Map.TilesetL1 + 0x20, Map.TilesetL1 + 0x21, false);
            Comp.Decompress(Model.Tilesets, 0x3B0000, 0x3E0000, 0x1000, "", Map.TilesetL2 + 0x20, Map.TilesetL2 + 0x21, false);
            Comp.Decompress(Model.Tilesets, 0x3B0000, 0x3E0000, 0x1000, "", Map.TilesetL3, Map.TilesetL2 + 1, false);
            LoadArea();
        }
        private void resetTilemaps_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current tilemaps. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            Comp.Decompress(Model.Tilemaps, 0x160000, 0x1B0000, 0x1000, 0x2000, "", 0x40, Map.TilemapL1 + 0x40, Map.TilemapL1 + 0x41, false);
            Comp.Decompress(Model.Tilemaps, 0x160000, 0x1B0000, 0x1000, 0x2000, "", 0x40, Map.TilemapL2 + 0x40, Map.TilemapL2 + 0x41, false);
            Comp.Decompress(Model.Tilemaps, 0x160000, 0x1B0000, 0x1000, 0x2000, "", 0x40, Map.TilemapL3, Map.TilemapL3 + 1, false);
            LoadArea();
        }
        private void resetCollisionMap_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current collision map. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            Comp.Decompress(Model.CollisionMaps, 0x1B0000, 0x1D0000, 0x20C2, "", Map.CollisionMap, Map.CollisionMap + 1, false);
            CollisionMap = new CollisionMap(Map);
            CollisionMap.Image = null;
            LoadTilemapForm();
        }
        private void resetAllElements_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to all components. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            Map = new Map(Area.Map);
            layering = new Layering(Index);
            npcObjects = new NPCObjectCollection(Index);
            Overlay.NPCImages = null;
            eventTriggers = new EventTriggerCollection(Index);
            exitTriggers = new ExitTriggerCollection(Index);
            overlaps = new OverlapCollection(Index);
            tileSwitches = new TileSwitchCollection(Index);
            collisionSwitches = new CollisionSwitchCollection(Index);
            int palette = Map.PaletteSet;
            PaletteSet = new PaletteSet(Model.ROM, palette, (palette * 0xD4) + 0x249FE2, 8, 16, 30);
            Comp.Decompress(Model.GraphicSets, 0x0A0000, 0x150000, 0x2000, "", Map.GraphicSet1 + 0x48, Map.GraphicSet1 + 0x49, false);
            Comp.Decompress(Model.GraphicSets, 0x0A0000, 0x150000, 0x2000, "", Map.GraphicSet2 + 0x48, Map.GraphicSet2 + 0x49, false);
            Comp.Decompress(Model.GraphicSets, 0x0A0000, 0x150000, 0x2000, "", Map.GraphicSet3 + 0x48, Map.GraphicSet3 + 0x49, false);
            Comp.Decompress(Model.GraphicSets, 0x0A0000, 0x150000, 0x2000, "", Map.GraphicSet4 + 0x48, Map.GraphicSet4 + 0x49, false);
            Comp.Decompress(Model.GraphicSets, 0x0A0000, 0x150000, 0x2000, "", Map.GraphicSet5 + 0x48, Map.GraphicSet5 + 0x49, false);
            Comp.Decompress(Model.Tilesets, 0x3B0000, 0x3E0000, 0x1000, "", Map.TilesetL1 + 0x20, Map.TilesetL1 + 0x21, false);
            Comp.Decompress(Model.Tilesets, 0x3B0000, 0x3E0000, 0x1000, "", Map.TilesetL2 + 0x20, Map.TilesetL2 + 0x21, false);
            Comp.Decompress(Model.Tilesets, 0x3B0000, 0x3E0000, 0x1000, "", Map.TilesetL3, Map.TilesetL2 + 1, false);
            Comp.Decompress(Model.Tilemaps, 0x160000, 0x1B0000, 0x1000, 0x2000, "", 0x40, Map.TilemapL1 + 0x40, Map.TilemapL1 + 0x41, false);
            Comp.Decompress(Model.Tilemaps, 0x160000, 0x1B0000, 0x1000, 0x2000, "", 0x40, Map.TilemapL2 + 0x40, Map.TilemapL2 + 0x41, false);
            Comp.Decompress(Model.Tilemaps, 0x160000, 0x1B0000, 0x1000, 0x2000, "", 0x40, Map.TilemapL3, Map.TilemapL3 + 1, false);
            Comp.Decompress(Model.CollisionMaps, 0x1B0000, 0x1D0000, 0x20C2, "", Map.CollisionMap, Map.CollisionMap + 1, false);
            LoadArea();
        }

        // ToolStrip : Editors
        private void openPaletteEditor_Click(object sender, EventArgs e)
        {
            LoadPaletteEditor();
            ShowEditorForm(PaletteEditor);
        }
        private void openGraphicEditor_Click(object sender, EventArgs e)
        {
            LoadGraphicEditor();
            ShowEditorForm(GraphicEditor);
        }

        // ToolStrip : Misc
        private void openPreviewerForm_Click(object sender, EventArgs e)
        {
            LoadPreviewerForm();
            ShowEditorForm(previewerForm);
        }
        private void openSpaceAnalyzer_Click(object sender, EventArgs e)
        {
            spaceAnalyzerForm = new SpaceAnalyzer();
            spaceAnalyzerForm.Show(this);
            new ToolTipLabel(spaceAnalyzerForm, baseConvertor, helpTips);
        }

        #endregion

        #endregion
    }
}
