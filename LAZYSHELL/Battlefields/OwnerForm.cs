using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using LazyShell.Undo;
using LazyShell.Properties;

namespace LazyShell.Battlefields
{
    public partial class OwnerForm : MapEditor
    {
        #region Variables

        private Settings settings;
        // main
        private delegate void UpdateFunction();
        // Index
        public int Index
        {
            get { return (int)num.Value; }
            set { num.Value = value; }
        }

        #region Elements

        private Battlefield[] battlefields
        {
            get { return Model.Battlefields; }
            set { Model.Battlefields = value; }
        }
        private Battlefield battlefield
        {
            get { return battlefields[Index]; }
            set { battlefields[Index] = value; }
        }

        #endregion

        private Tileset tileset;
        private PaletteSet[] paletteSets
        {
            get { return Model.PaletteSets; }
            set { Model.PaletteSets = value; }
        }
        public new PaletteSet PaletteSet
        {
            get { return paletteSets[battlefield.PaletteSet]; }
            set { paletteSets[battlefield.PaletteSet] = value; }
        }
        private int palette
        {
            get { return battlefields[Index].PaletteSet; }
        }
        private Bitmap battlefieldImage;
        private Overlay overlay;
        private int zoom = 1;
        // Mouse behavior
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
        private UndoStack commandStack;
        private int commandCount = 0;
        // special controls
        private EditLabel labelWindow;

        #endregion

        // Constructor
        public OwnerForm()
        {
            InitializeComponent();
            InitializeVariables();
            InitializeListControls();
            InitializeNavigators();
            CreateShortcuts();
            LoadProperties();
            LoadPaletteEditor();
            LoadGraphicEditor();
            LoadTileEditor();
            //
            this.History = new History(this, name, num);
        }

        #region Methods

        #region Initialization

        private void InitializeVariables()
        {
            this.overlay = new Overlay();
            this.settings = Settings.Default;
            this.commandStack = new UndoStack(true);
        }
        private void InitializeListControls()
        {
            this.name.Items.AddRange(Lists.Numerize(Lists.Battlefields));
            this.gfxSet1Name.Items.AddRange(Lists.Numerize(Lists.GraphicSets)); gfxSet1Name.Items.Add("{NONE}");
            this.gfxSet2Name.Items.AddRange(Lists.Numerize(Lists.GraphicSets)); gfxSet2Name.Items.Add("{NONE}");
            this.gfxSet3Name.Items.AddRange(Lists.Numerize(Lists.GraphicSets)); gfxSet3Name.Items.Add("{NONE}");
            this.gfxSet4Name.Items.AddRange(Lists.Numerize(Lists.GraphicSets)); gfxSet4Name.Items.Add("{NONE}");
            this.gfxSet5Name.Items.AddRange(Lists.Numerize(Lists.GraphicSets)); gfxSet5Name.Items.Add("{NONE}");
        }
        private void InitializeNavigators()
        {
            this.Updating = true;
            //
            if (settings.RememberLastIndex)
                Index = settings.LastBattlefield;
            //
            this.Updating = false;
        }
        private void CreateHelperForms()
        {
            toolTip1.InitialDelay = 0;
            labelWindow = new EditLabel(name, num, "Battlefields", true);
            new ToolTipLabel(this, baseConvertor, helpTips);
        }
        private void CreateShortcuts()
        {
            Do.AddShortcut(toolStrip3, Keys.Control | Keys.S, new EventHandler(save_Click));
            Do.AddShortcut(toolStrip3, Keys.F1, helpTips);
            Do.AddShortcut(toolStrip3, Keys.F2, baseConvertor);
        }
        //
        public void LoadProperties()
        {
            this.Updating = true;
            Cursor.Current = Cursors.WaitCursor;
            //
            tileset = new Tileset(battlefield, paletteSets[battlefield.PaletteSet]);
            // Update controls
            name.SelectedIndex = Index;
            gfxSet1Name.SelectedIndex = battlefield.GraphicSetA;
            gfxSet1Num.Value = battlefield.GraphicSetA;
            gfxSet2Name.SelectedIndex = battlefield.GraphicSetB;
            gfxSet2Num.Value = battlefield.GraphicSetB;
            gfxSet3Name.SelectedIndex = battlefield.GraphicSetC;
            gfxSet3Num.Value = battlefield.GraphicSetC;
            gfxSet4Name.SelectedIndex = battlefield.GraphicSetD;
            gfxSet4Num.Value = battlefield.GraphicSetD;
            gfxSet5Name.SelectedIndex = battlefield.GraphicSetE;
            gfxSet5Num.Value = battlefield.GraphicSetE;
            tilesetName.SelectedIndex = battlefield.Tileset;
            tilesetNum.Value = battlefield.Tileset;
            paletteSetName.SelectedIndex = battlefield.PaletteSet;
            paletteSetNum.Value = battlefield.PaletteSet;
            SetBattlefieldImage();
            // reload editors
            LoadPaletteEditor();
            LoadGraphicEditor();
            LoadTileEditor();
            //
            Cursor.Current = Cursors.Arrow;
            this.Updating = false;
        }
        //
        private void SetBattlefieldImage()
        {
            int[] quadrant1 = Do.TilesetToPixels(tileset.Tileset_tiles, 16, 16, 0, false);
            int[] quadrant2 = Do.TilesetToPixels(tileset.Tileset_tiles, 16, 16, 256, false);
            int[] quadrant3 = Do.TilesetToPixels(tileset.Tileset_tiles, 16, 16, 512, false);
            int[] quadrant4 = Do.TilesetToPixels(tileset.Tileset_tiles, 16, 16, 768, false);
            int[] pixels = new int[512 * 512];
            Do.PixelsToPixels(quadrant1, pixels, 512, new Rectangle(0, 0, 256, 256));
            Do.PixelsToPixels(quadrant2, pixels, 512, new Rectangle(256, 0, 256, 256));
            Do.PixelsToPixels(quadrant3, pixels, 512, new Rectangle(0, 256, 256, 256));
            Do.PixelsToPixels(quadrant4, pixels, 512, new Rectangle(256, 256, 256, 256));
            battlefieldImage = Do.PixelsToImage(pixels, 512, 512);
            picture.Invalidate();
        }

        #endregion

        #region Form Management

        // Form loading
        private void LoadPaletteEditor()
        {
            if (paletteEditor == null)
            {
                paletteEditor = new PaletteEditor(new PaletteUpdater(), paletteSets[palette], 8, 2, 6);
                paletteEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                paletteEditor.Reload(paletteSets[palette], 8, 2, 6);
        }
        private void LoadGraphicEditor()
        {
            if (graphicEditor == null)
            {
                graphicEditor = new GraphicEditor(new GraphicUpdater(),
                    tileset.Graphics, tileset.Graphics.Length, 0, paletteSets[palette], 1, 0x20);
                graphicEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                graphicEditor.Reload(tileset.Graphics, tileset.Graphics.Length, 0, paletteSets[palette], 1, 0x20);
        }
        private void LoadTileEditor()
        {
            if (tileEditor == null)
            {
                tileEditor = new TileEditor(this, new TileUpdater(), this.tileset.Tileset_tiles[mouseDownTile], tileset.Graphics);
                tileEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                tileEditor.Reload(this.tileset.Tileset_tiles[mouseDownTile], tileset.Graphics);
        }

        // Updating
        public void UpdatePalette()
        {
            this.tileset.RefreshTileset();
            SetBattlefieldImage();
            LoadGraphicEditor();
            LoadTileEditor();
            this.Modified = true;   // b/c switching colors won't modify checksum
        }
        public void UpdateGraphics()
        {
            this.tileset.WriteToModel(16, 2);
            this.tileset.RefreshTileset();
            SetBattlefieldImage();
            LoadTileEditor();
        }
        public void UpdateTile()
        {
            tileset.ParseTileset(tileset.Tileset_tiles, tileset.Tileset_bytes);
            SetBattlefieldImage();
        }

        #endregion

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
                    int x__ = (x + x_) & 15;
                    int y__ = (y + y_) & 15;
                    int index = y__ * 16 + x__;
                    index += ((x + x_) >> 4) * 256;
                    index += ((y + y_) >> 4) * 512;
                    if (index >= tileset.Tileset_tiles.Length) continue;
                    copiedTiles[y * (overlay.SelectTS.Width / 16) + x] =
                        tileset.Tileset_tiles[index].Copy();
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
        }
        private void Delete()
        {
            if (overlay.SelectTS.Empty)
                return;
            byte[] oldTileset = Bits.Copy(tileset.Tileset_bytes);
            //
            int x_ = overlay.SelectTS.Location.X / 16;
            int y_ = overlay.SelectTS.Location.Y / 16;
            for (int y = 0; y < overlay.SelectTS.Height / 16; y++)
            {
                for (int x = 0; x < overlay.SelectTS.Width / 16; x++)
                {
                    int x__ = (x + x_) & 15;
                    int y__ = (y + y_) & 15;
                    int index = y__ * 16 + x__;
                    index += ((x + x_) >> 4) * 256;
                    index += ((y + y_) >> 4) * 512;
                    if (index >= tileset.Tileset_tiles.Length) continue;
                    tileset.Tileset_tiles[index].Clear();
                    tileset.Tileset_bytes[index * 2] = 0;
                }
            }
            tileset.ParseTileset(tileset.Tileset_tiles, tileset.Tileset_bytes);
            SetBattlefieldImage();
            //
            commandStack.Push(new TilesetEdit(tileset, oldTileset, this));
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
                    int x__ = (x + x_) & 15;
                    int y__ = (y + y_) & 15;
                    int index = y__ * 16 + x__;
                    index += ((x + x_) >> 4) * 256;
                    index += ((y + y_) >> 4) * 512;
                    if (index >= tileset.Tileset_tiles.Length) continue;
                    copiedTiles[y * (overlay.SelectTS.Width / 16) + x] =
                        tileset.Tileset_tiles[index].Copy();
                }
            }
            if (flipType == FlipType.Horizontal)
                Do.FlipHorizontal(copiedTiles, overlay.SelectTS.Width / 16, overlay.SelectTS.Height / 16);
            else if (flipType == FlipType.Vertical)
                Do.FlipVertical(copiedTiles, overlay.SelectTS.Width / 16, overlay.SelectTS.Height / 16);
            buffer.Tiles = copiedTiles;
            Defloat(buffer);
            tileset.ParseTileset(tileset.Tileset_tiles, tileset.Tileset_bytes);
            SetBattlefieldImage();
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
                    int x__ = (x + x_) & 15;
                    int y__ = (y + y_) & 15;
                    int index = y__ * 16 + x__;
                    index += ((x + x_) >> 4) * 256;
                    index += ((y + y_) >> 4) * 512;
                    if (index >= tileset.Tileset_tiles.Length) continue;
                    draggedTiles[y * (overlay.SelectTS.Width / 16) + x] =
                        tileset.Tileset_tiles[index].Copy();
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
            byte[] oldTileset = Bits.Copy(tileset.Tileset_bytes);
            //
            selection = null;
            int x_ = overlay.SelectTS.X / 16;
            int y_ = overlay.SelectTS.Y / 16;
            for (int y = 0; y < buffer.Height / 16; y++)
            {
                for (int x = 0; x < buffer.Width / 16; x++)
                {
                    int x__ = (x + x_) & 15;
                    int y__ = (y + y_) & 15;
                    int index = y__ * 16 + x__;
                    index += ((x + x_) >> 4) * 256;
                    index += ((y + y_) >> 4) * 512;
                    if (index >= tileset.Tileset_tiles.Length || index < 0) continue;
                    if (y < 0 || x < 0) continue;
                    Tile tile = buffer.Tiles[y * (buffer.Width / 16) + x];
                    tileset.Tileset_tiles[index] = tile.Copy();
                    tileset.Tileset_tiles[index].Index = index;
                }
            }
            tileset.ParseTileset(tileset.Tileset_tiles, tileset.Tileset_bytes);
            commandStack.Push(commandCount + 1);
            commandCount = 0;
            SetBattlefieldImage();
            //
            commandStack.Push(new TilesetEdit(tileset, oldTileset, this));
        }
        private void Defloat()
        {
            // if copied tiles were pasted and not dragging a non-copied selection
            if (copiedTiles != null && draggedTiles == null)
                Defloat(copiedTiles);
            if (draggedTiles != null)
            {
                Defloat(draggedTiles);
                draggedTiles = null;
            }
            moving = false;
            selection = null;
            overlay.SelectTS.Clear();
            Cursor.Position = Cursor.Position;
        }

        #endregion

        // Saving
        public void WriteToROM()
        {
            tileset.WriteToModel(16, 16);
            //
            foreach (var paletteSet in paletteSets)
                paletteSet.WriteToBuffer(2);
            foreach (var battlefield in battlefields)
                battlefield.WriteToROM();
            //
            Comp.Compress(Model.Tilesets, Model.EditTilesets, 0x150000, 0x15FFFF, "BATTLEFIELD", 0);
            //
            this.Modified = false;
        }

        #endregion

        #region Event Handlers

        // OwnerForm
        private void OwnerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.S))
                WriteToROM();
        }
        private void OwnerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.Modified)
                return;
            var result = MessageBox.Show(
                "Battlefields have not been saved.\n\nWould you like to save changes?",
                "LAZY SHELL", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                WriteToROM();
            else if (result == DialogResult.No)
                Model.ClearAll();
            else if (result == DialogResult.Cancel)
                e.Cancel = true;
        }

        // MenuStrip
        private void save_Click(object sender, EventArgs e)
        {
            WriteToROM();
        }
        private void import_Click(object sender, EventArgs e)
        {
            new IOElements(battlefields, IOMode.Import, Index, "IMPORT BATTLEFIELDS...").ShowDialog();
            foreach (var paletteSet in Model.PaletteSets)
                paletteSet.Buffer = Model.ROM;
            LoadProperties();
            commandStack.Clear();
            commandCount = 0;
        }
        private void export_Click(object sender, EventArgs e)
        {
            new IOElements(battlefields, IOMode.Export, Index, "EXPORT BATTLEFIELDS...").ShowDialog();
        }
        private void reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current battlefield. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            battlefield = new Battlefield(Index);
            Comp.Decompress(Model.Tilesets, 0x150000, 0x160000, 0x2000, "", Index, Index + 1, false);
            LoadProperties();
        }
        private void clear_Click(object sender, EventArgs e)
        {
            byte[] oldTileset = Bits.Copy(tileset.Tileset_bytes);
            //
            var clearElements = new ClearElements(null, Index, "CLEAR BATTLEFIELD TILESETS...");
            clearElements.ShowDialog();
            if (clearElements.DialogResult == DialogResult.Cancel)
                return;
            LoadProperties();
            //
            if (!Bits.Compare(oldTileset, tileset.Tileset_bytes))
            {
                commandStack.Push(new TilesetEdit(tileset, oldTileset, this));
                commandStack.Push(1);
            }
        }

        // Navigators
        private void num_ValueChanged(object sender, EventArgs e)
        {
            name.SelectedIndex = (int)num.Value;
            if (!this.Updating)
            {
                Defloat();
                tileset.WriteToModel(16, 16);
                LoadProperties();
                //
                settings.LastBattlefield = Index;
            }
        }
        private void name_SelectedIndexChanged(object sender, EventArgs e)
        {
            num.Value = name.SelectedIndex;
        }

        // Properties : Palette Set
        private void paletteSetNum_ValueChanged(object sender, EventArgs e)
        {
            battlefield.PaletteSet = (byte)paletteSetNum.Value;
            paletteSetName.SelectedIndex = (int)paletteSetNum.Value;
            if (!this.Updating)
            {
                tileset = new Tileset(battlefield, paletteSets[palette]);
                SetBattlefieldImage();
                // reload editors
                LoadPaletteEditor();
                LoadGraphicEditor();
                LoadTileEditor();
            }
        }
        private void paletteSetName_SelectedIndexChanged(object sender, EventArgs e)
        {
            paletteSetNum.Value = paletteSetName.SelectedIndex;
        }

        // Properties : Graphic Sets
        private void gfxSet1Num_ValueChanged(object sender, EventArgs e)
        {
            battlefield.GraphicSetA = (byte)gfxSet1Num.Value;
            gfxSet1Name.SelectedIndex = (int)gfxSet1Num.Value;
            if (!this.Updating)
            {
                tileset = new Tileset(battlefield, paletteSets[palette]);
                SetBattlefieldImage();
                // reload editors
                LoadPaletteEditor();
                LoadGraphicEditor();
                LoadTileEditor();
            }
        }
        private void gfxSet2Num_ValueChanged(object sender, EventArgs e)
        {
            battlefield.GraphicSetB = (byte)gfxSet2Num.Value;
            gfxSet2Name.SelectedIndex = (int)gfxSet2Num.Value;
            if (!this.Updating)
            {
                tileset = new Tileset(battlefield, paletteSets[palette]);
                SetBattlefieldImage();
                // reload editors
                LoadPaletteEditor();
                LoadGraphicEditor();
                LoadTileEditor();
            }
        }
        private void gfxSet3Num_ValueChanged(object sender, EventArgs e)
        {
            battlefield.GraphicSetC = (byte)gfxSet3Num.Value;
            gfxSet3Name.SelectedIndex = (int)gfxSet3Num.Value;
            if (!this.Updating)
            {
                tileset = new Tileset(battlefield, paletteSets[palette]);
                SetBattlefieldImage();
                // reload editors
                LoadPaletteEditor();
                LoadGraphicEditor();
                LoadTileEditor();
            }
        }
        private void gfxSet4Num_ValueChanged(object sender, EventArgs e)
        {
            battlefield.GraphicSetD = (byte)gfxSet4Num.Value;
            gfxSet4Name.SelectedIndex = (int)gfxSet4Num.Value;
            if (!this.Updating)
            {
                tileset = new Tileset(battlefield, paletteSets[palette]);
                SetBattlefieldImage();
                // reload editors
                LoadPaletteEditor();
                LoadGraphicEditor();
                LoadTileEditor();
            }
        }
        private void gfxSet5Num_ValueChanged(object sender, EventArgs e)
        {
            battlefield.GraphicSetE = (byte)gfxSet5Num.Value;
            gfxSet5Name.SelectedIndex = (int)gfxSet5Num.Value;
            if (!this.Updating)
            {
                tileset = new Tileset(battlefield, paletteSets[palette]);
                SetBattlefieldImage();
                // reload editors
                LoadPaletteEditor();
                LoadGraphicEditor();
                LoadTileEditor();
            }
        }
        private void gfxSet1Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            gfxSet1Num.Value = gfxSet1Name.SelectedIndex;
        }
        private void gfxSet2Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            gfxSet2Num.Value = gfxSet2Name.SelectedIndex;
        }
        private void gfxSet3Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            gfxSet3Num.Value = gfxSet3Name.SelectedIndex;
        }
        private void gfxSet4Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            gfxSet4Num.Value = gfxSet4Name.SelectedIndex;
        }
        private void gfxSet5Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            gfxSet5Num.Value = gfxSet5Name.SelectedIndex;
        }

        // Properties : Tileset
        private void tilesetNum_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            battlefield.Tileset = (byte)tilesetNum.Value;
            tilesetName.SelectedIndex = (int)tilesetNum.Value;
            tileset = new Tileset(battlefield, paletteSets[palette]);
            SetBattlefieldImage();
            // reload editors
            LoadPaletteEditor();
            LoadGraphicEditor();
            LoadTileEditor();
        }
        private void tilesetName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            tilesetNum.Value = tilesetName.SelectedIndex;
        }

        // Opening forms
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
            (sender as Form).Hide();
        }

        // Picture
        private void picture_Paint(object sender, PaintEventArgs e)
        {
            if (battlefieldImage == null)
                return;
            Rectangle rdst = new Rectangle(0, 0, 512, 512);
            if (toggleBG.Checked)
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(paletteSets[palette].Palette[0])), rdst);
            e.Graphics.DrawImage(battlefieldImage, rdst, 0, 0, 512, 512, GraphicsUnit.Pixel);
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
            if (mouseEnter)
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
            PictureBox pictureBox = sender as PictureBox;
            pictureBox.Focus();
            // set a floor and ceiling for the coordinates
            int x = Math.Max(0, Math.Min(e.X, pictureBox.Width));
            int y = Math.Max(0, Math.Min(e.Y, pictureBox.Height));
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
            int x_ = (x / 16) & 15;
            int y_ = (y / 16) & 15;
            if (x < 256 && y < 256) // 1st quad
                mouseDownTile = y_ * 16 + x_;
            if (x > 256 && y < 256) // 2nd quad
                mouseDownTile = y_ * 16 + x_ + 256;
            if (x < 256 && y > 256) // 3rd quad
                mouseDownTile = y_ * 16 + x_ + 512;
            if (x > 256 && y > 256) // 4th quad
                mouseDownTile = y_ * 16 + x_ + 768;
            LoadTileEditor();
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
        private void picture_MouseMove(object sender, MouseEventArgs e)
        {
            mouseOverObject = null;
            PictureBox pictureBox = sender as PictureBox;
            // set a floor and ceiling for the coordinates
            int x = Math.Max(0, Math.Min(e.X, pictureBox.Width));
            int y = Math.Max(0, Math.Min(e.Y, pictureBox.Height));
            mousePosition = new Point(x, y);
            if (editSelect.Checked)
            {
                // if making a new selection
                if (e.Button == MouseButtons.Left && mouseDownObject == null && overlay.SelectTS != null)
                {
                    // cancel if within same bounds as last call
                    if (overlay.SelectTS.Final == new Point(x + 16, y + 16))
                        return;
                    // otherwise, set the lower right edge of the selection
                    overlay.SelectTS.Final = new Point(
                        Math.Min(x + 16, pictureBox.Width),
                        Math.Min(y + 16, pictureBox.Height));
                }
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
            pictureBox.Invalidate();
        }
        private void picture_MouseUp(object sender, MouseEventArgs e)
        {
        }
        private void picture_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.G: toggleTileGrid.PerformClick(); break;
                case Keys.B: toggleBG.PerformClick(); break;
                case Keys.S: editSelect.PerformClick(); break;
                case Keys.Control | Keys.C: editCopy.PerformClick(); break;
                case Keys.Control | Keys.X: editCut.PerformClick(); break;
                case Keys.Control | Keys.V:
                    if (draggedTiles != null)
                        Defloat(draggedTiles);
                    Paste(new Point(16, 16), copiedTiles);
                    break;
                case Keys.Delete: Delete(); break;
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
                    overlay.Select.Reload(16, 0, 0, 512, 512, picture);
                    picture.Invalidate();
                    break;
                case Keys.Control | Keys.Z: editUndo.PerformClick(); break;
                case Keys.Control | Keys.Y: editRedo.PerformClick(); break;
            }
        }

        // ToolStrip : Toggle
        private void toggleTileGrid_Click(object sender, EventArgs e)
        {
            picture.Invalidate();
        }
        private void toggleBG_Click(object sender, EventArgs e)
        {
            picture.Invalidate();
        }

        // ToolStrip : Editing
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
            {
                Defloat(draggedTiles);
                draggedTiles = null;
            }
            Paste(new Point(0, 0), copiedTiles);
        }
        private void editUndo_Click(object sender, EventArgs e)
        {
            commandStack.UndoCommand();
            SetBattlefieldImage();
        }
        private void editRedo_Click(object sender, EventArgs e)
        {
            commandStack.RedoCommand();
            SetBattlefieldImage();
        }
        private void editSelect_Click(object sender, EventArgs e)
        {
            if (editSelect.Checked)
                this.picture.Cursor = System.Windows.Forms.Cursors.Cross;
            else
                this.picture.Cursor = System.Windows.Forms.Cursors.Arrow;
            Defloat();
        }

        // ContextMenuStrip
        private void menuMirror_Click(object sender, EventArgs e)
        {
            Flip(FlipType.Horizontal);
        }
        private void menuInvert_Click(object sender, EventArgs e)
        {
            Flip(FlipType.Vertical);
        }
        private void menuSaveImageAs_Click(object sender, EventArgs e)
        {
            Do.Export(battlefieldImage, "battlefield-" + Index.ToString("d2") + ".png");
        }
        private void menuImportTileset_Click(object sender, EventArgs e)
        {
            Tileset tileset = new Tileset();
            tileset = Do.Import(tileset) as Tileset;
            if (tileset == null)
                return;
            //
            byte[] oldTileset = Bits.Copy(tileset.Tileset_bytes);
            //
            tileset.Palettes.Buffer = Model.ROM;
            this.battlefield.GraphicSetA = tileset.Battlefield.GraphicSetA;
            this.battlefield.GraphicSetB = tileset.Battlefield.GraphicSetB;
            this.battlefield.GraphicSetC = tileset.Battlefield.GraphicSetC;
            this.battlefield.GraphicSetD = tileset.Battlefield.GraphicSetD;
            this.battlefield.GraphicSetE = tileset.Battlefield.GraphicSetE;
            this.tileset.Palettes = tileset.Palettes;
            this.tileset.Palettes.CopyTo(Model.PaletteSets[palette]);
            this.tileset.Graphics = tileset.Graphics;
            this.tileset.Tileset_tiles = tileset.Tileset_tiles;
            this.tileset.ParseTileset(this.tileset.Tileset_tiles, this.tileset.Tileset_bytes);
            this.tileset.WriteToModel(16, 16);
            //
            LoadProperties();
            //
            if (!Bits.Compare(oldTileset, tileset.Tileset_bytes))
            {
                commandStack.Push(new TilesetEdit(tileset, oldTileset, this));
                commandStack.Push(1);
            }
        }

        #endregion
    }
}
