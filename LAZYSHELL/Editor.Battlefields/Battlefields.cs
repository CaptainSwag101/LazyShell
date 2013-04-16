using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Undo;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    public partial class Battlefields : Form
    {
        #region Variables

        private long checksum;
        private Settings settings = Settings.Default;
        // main
        private delegate void Function();
        private bool updating = false;
        private int index
        {
            get { return (int)battlefieldNum.Value; }
            set { battlefieldNum.Value = value; }
        }
        public int Index { get { return index; } set { index = value; } }
        private int palette
        {
            get { return battlefields[(int)battlefieldNum.Value].PaletteSet; }
        }
        private Battlefield[] battlefields
        {
            get { return Model.Battlefields; }
            set { Model.Battlefields = value; }
        }
        private Battlefield battlefield
        {
            get { return battlefields[index]; }
            set { battlefields[index] = value; }
        }
        private BattlefieldTileset tileset;
        private PaletteSet[] paletteSets
        {
            get { return Model.PaletteSetsBF; }
            set { Model.PaletteSetsBF = value; }
        }
        public PaletteSet[] PaletteSets
        {
            get { return paletteSets; }
            set { paletteSets = value; }
        }
        private Bitmap battlefieldImage;
        private Overlay overlay;
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
        // special controls
        private EditLabel labelWindow;
        #endregion
        #region Functions
        // Main
        public Battlefields()
        {
            this.overlay = new Overlay();
            InitializeComponent();
            Do.AddShortcut(toolStrip3, Keys.Control | Keys.S, new EventHandler(save_Click));
            Do.AddShortcut(toolStrip3, Keys.F1, helpTips);
            Do.AddShortcut(toolStrip3, Keys.F2, baseConvertor);
            toolTip1.InitialDelay = 0;
            labelWindow = new EditLabel(battlefieldName, battlefieldNum, "Battlefields", true);
            this.battlefieldName.Items.AddRange(Lists.Numerize(Lists.BattlefieldNames));
            this.battlefieldGFXSet1Name.Items.AddRange(Lists.Numerize(Lists.GraphicSetNames)); battlefieldGFXSet1Name.Items.Add("{NONE}");
            this.battlefieldGFXSet2Name.Items.AddRange(Lists.Numerize(Lists.GraphicSetNames)); battlefieldGFXSet2Name.Items.Add("{NONE}");
            this.battlefieldGFXSet3Name.Items.AddRange(Lists.Numerize(Lists.GraphicSetNames)); battlefieldGFXSet3Name.Items.Add("{NONE}");
            this.battlefieldGFXSet4Name.Items.AddRange(Lists.Numerize(Lists.GraphicSetNames)); battlefieldGFXSet4Name.Items.Add("{NONE}");
            this.battlefieldGFXSet5Name.Items.AddRange(Lists.Numerize(Lists.GraphicSetNames)); battlefieldGFXSet5Name.Items.Add("{NONE}");
            RefreshBattlefield();
            LoadPaletteEditor();
            LoadGraphicEditor();
            LoadTileEditor();
            new ToolTipLabel(this, baseConvertor, helpTips);
            new History(this);
            if (settings.RememberLastIndex)
                index = settings.LastBattlefield;
            //
            checksum = Do.GenerateChecksum(battlefields, Model.TilesetsBF, paletteSets);
        }
        public void RefreshBattlefield()
        {
            Cursor.Current = Cursors.WaitCursor;
            updating = true;
            tileset = new BattlefieldTileset(battlefield, paletteSets[battlefield.PaletteSet]);
            // Update fields
            battlefieldName.SelectedIndex = index;
            battlefieldGFXSet1Name.SelectedIndex = battlefield.GraphicSetA;
            battlefieldGFXSet1Num.Value = battlefield.GraphicSetA;
            battlefieldGFXSet2Name.SelectedIndex = battlefield.GraphicSetB;
            battlefieldGFXSet2Num.Value = battlefield.GraphicSetB;
            battlefieldGFXSet3Name.SelectedIndex = battlefield.GraphicSetC;
            battlefieldGFXSet3Num.Value = battlefield.GraphicSetC;
            battlefieldGFXSet4Name.SelectedIndex = battlefield.GraphicSetD;
            battlefieldGFXSet4Num.Value = battlefield.GraphicSetD;
            battlefieldGFXSet5Name.SelectedIndex = battlefield.GraphicSetE;
            battlefieldGFXSet5Num.Value = battlefield.GraphicSetE;
            battlefieldTilesetName.SelectedIndex = battlefield.TileSet;
            battlefieldTilesetNum.Value = battlefield.TileSet;
            battlefieldPaletteSetName.SelectedIndex = battlefield.PaletteSet;
            battlefieldPaletteSetNum.Value = battlefield.PaletteSet;
            SetBattlefieldImage();
            // reload editors
            LoadPaletteEditor();
            LoadGraphicEditor();
            LoadTileEditor();
            updating = false;
            Cursor.Current = Cursors.Arrow;
        }
        private void SetBattlefieldImage()
        {
            int[] battlefieldPixelsQ1 = Do.TilesetToPixels(tileset.Tileset_tiles, 16, 16, 0, false);
            int[] battlefieldPixelsQ2 = Do.TilesetToPixels(tileset.Tileset_tiles, 16, 16, 256, false);
            int[] battlefieldPixelsQ3 = Do.TilesetToPixels(tileset.Tileset_tiles, 16, 16, 512, false);
            int[] battlefieldPixelsQ4 = Do.TilesetToPixels(tileset.Tileset_tiles, 16, 16, 768, false);
            int[] battlefieldPixels = new int[512 * 512];
            Do.PixelsToPixels(battlefieldPixelsQ1, battlefieldPixels, 512, new Rectangle(0, 0, 256, 256));
            Do.PixelsToPixels(battlefieldPixelsQ2, battlefieldPixels, 512, new Rectangle(256, 0, 256, 256));
            Do.PixelsToPixels(battlefieldPixelsQ3, battlefieldPixels, 512, new Rectangle(0, 256, 256, 256));
            Do.PixelsToPixels(battlefieldPixelsQ4, battlefieldPixels, 512, new Rectangle(256, 256, 256, 256));
            battlefieldImage = new Bitmap(Do.PixelsToImage(battlefieldPixels, 512, 512));
            pictureBoxBattlefield.Invalidate();
        }
        private void Clear()
        {
            Model.TilesetsBF[battlefield.TileSet] = new byte[0x2000];
            Model.EditTilesetsBF[battlefield.TileSet] = true;
        }
        public void Assemble()
        {
            tileset.Assemble(16, 16);
            foreach (PaletteSet ps in paletteSets)
                ps.Assemble(2);
            foreach (Battlefield bf in battlefields)
                bf.Assemble();
            Model.Compress(Model.TilesetsBF, Model.EditTilesetsBF, 0x150000, 0x15FFFF, "BATTLEFIELD", 0);
            checksum = Do.GenerateChecksum(battlefields, Model.TilesetsBF, paletteSets);
        }
        // Editor loading
        private void LoadPaletteEditor()
        {
            if (paletteEditor == null)
            {
                paletteEditor = new PaletteEditor(new Function(PaletteUpdate), paletteSets[palette], 8, 2, 6);
                paletteEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                paletteEditor.Reload(new Function(PaletteUpdate), paletteSets[palette], 8, 2, 6);
        }
        private void LoadGraphicEditor()
        {
            if (graphicEditor == null)
            {
                graphicEditor = new GraphicEditor(new Function(GraphicUpdate),
                    tileset.Graphics, tileset.Graphics.Length, 0, paletteSets[palette], 1, 0x20);
                graphicEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                graphicEditor.Reload(new Function(GraphicUpdate),
                    tileset.Graphics, tileset.Graphics.Length, 0, paletteSets[palette], 1, 0x20);
        }
        private void LoadTileEditor()
        {
            if (tileEditor == null)
            {
                tileEditor = new TileEditor(new Function(TileUpdate),
                this.tileset.Tileset_tiles[mouseDownTile],
                tileset.Graphics, paletteSets[battlefield.PaletteSet], 0x20);
                tileEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                tileEditor.Reload(new Function(TileUpdate),
                this.tileset.Tileset_tiles[mouseDownTile],
                tileset.Graphics, paletteSets[battlefield.PaletteSet], 0x20);
        }
        // Editor updating
        private void TileUpdate()
        {
            tileset.DrawTileset(tileset.Tileset_tiles, tileset.Tileset_bytes);
            SetBattlefieldImage();
        }
        private void PaletteUpdate()
        {
            this.tileset.RedrawTileset();
            SetBattlefieldImage();
            LoadGraphicEditor();
            LoadTileEditor();
            checksum--;   // b/c switching colors won't modify checksum
        }
        private void GraphicUpdate()
        {
            this.tileset.Assemble(16, 2);
            this.tileset.RedrawTileset();
            SetBattlefieldImage();
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
            pictureBoxBattlefield.Invalidate();
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
                    int x__ = (x + x_) & 15;
                    int y__ = (y + y_) & 15;
                    int index = y__ * 16 + x__;
                    index += ((x + x_) >> 4) * 256;
                    index += ((y + y_) >> 4) * 512;
                    if (index >= tileset.Tileset_tiles.Length || index < 0) continue;
                    if (y < 0 || x < 0) continue;
                    Tile tile = buffer.Tiles[y * (buffer.Width / 16) + x];
                    tileset.Tileset_tiles[index] = tile.Copy();
                    tileset.Tileset_tiles[index].TileIndex = index;
                }
            }
            tileset.DrawTileset(tileset.Tileset_tiles, tileset.Tileset_bytes);
            SetBattlefieldImage();
        }
        private void PasteClear()
        {
            // if copied tiles were pasted and not dragging a non-copied selection
            if (copiedTiles != null && draggedTiles == null)
                PasteFinal(copiedTiles);
            if (draggedTiles != null)
            {
                PasteFinal(draggedTiles);
                draggedTiles = null;
            }
            overlay.SelectTS = null;
            selection = null;
            moving = false;
        }
        private void Delete()
        {
            if (overlay.SelectTS == null) return;
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
            tileset.DrawTileset(tileset.Tileset_tiles, tileset.Tileset_bytes);
            SetBattlefieldImage();
        }
        private void Flip(string type)
        {
            if (draggedTiles != null)
                PasteFinal(draggedTiles);
            if (overlay.SelectTS == null) return;
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
            if (type == "mirror")
                Do.FlipHorizontal(copiedTiles, overlay.SelectTS.Width / 16, overlay.SelectTS.Height / 16);
            else if (type == "invert")
                Do.FlipVertical(copiedTiles, overlay.SelectTS.Width / 16, overlay.SelectTS.Height / 16);
            buffer.Tiles = copiedTiles;
            PasteFinal(buffer);
            tileset.DrawTileset(tileset.Tileset_tiles, tileset.Tileset_bytes);
            SetBattlefieldImage();
        }
        #endregion
        #region Event Handlers
        // main controls
        private void Battlefields_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.S))
                Assemble();
        }
        private void Battlefields_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Do.GenerateChecksum(battlefields, Model.TilesetsBF, paletteSets) == checksum)
                goto Close;
            DialogResult result = MessageBox.Show(
                "Battlefields have not been saved.\n\nWould you like to save changes?", "LAZY SHELL",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                Assemble();
            else if (result == DialogResult.No)
            {
                Model.Battlefields = null;
                Model.TilesetsBF[0] = null;
                Model.PaletteSetsBF = null;
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
            tileEditor.Dispose();
            paletteEditor.Dispose();
            graphicEditor.Dispose();
        }
        private void battlefieldNum_ValueChanged(object sender, EventArgs e)
        {
            battlefieldName.SelectedIndex = (int)battlefieldNum.Value;
            tileset.Assemble(16, 16);
            draggedTiles = null;
            overlay.SelectTS = null;
            selection = null;
            moving = false;
            RefreshBattlefield();
            settings.LastBattlefield = index;
        }
        private void battlefieldName_SelectedIndexChanged(object sender, EventArgs e)
        {
            battlefieldNum.Value = battlefieldName.SelectedIndex;
        }
        private void battlefieldPaletteSetNum_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            battlefield.PaletteSet = (byte)battlefieldPaletteSetNum.Value;
            battlefieldPaletteSetName.SelectedIndex = (int)battlefieldPaletteSetNum.Value;
            tileset = new BattlefieldTileset(battlefield, paletteSets[palette]);
            SetBattlefieldImage();
            // reload editors
            LoadPaletteEditor();
            LoadGraphicEditor();
            LoadTileEditor();
        }
        private void battlefieldPaletteSetName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            battlefieldPaletteSetNum.Value = battlefieldPaletteSetName.SelectedIndex;
        }
        private void battlefieldGFXSet1Num_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            battlefield.GraphicSetA = (byte)battlefieldGFXSet1Num.Value;
            battlefieldGFXSet1Name.SelectedIndex = (int)battlefieldGFXSet1Num.Value;
            tileset = new BattlefieldTileset(battlefield, paletteSets[palette]);
            SetBattlefieldImage();
            // reload editors
            LoadPaletteEditor();
            LoadGraphicEditor();
            LoadTileEditor();
        }
        private void battlefieldGFXSet1Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            battlefieldGFXSet1Num.Value = battlefieldGFXSet1Name.SelectedIndex;
        }
        private void battlefieldGFXSet2Num_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            battlefield.GraphicSetB = (byte)battlefieldGFXSet2Num.Value;
            battlefieldGFXSet2Name.SelectedIndex = (int)battlefieldGFXSet2Num.Value;
            tileset = new BattlefieldTileset(battlefield, paletteSets[palette]);
            SetBattlefieldImage();
            // reload editors
            LoadPaletteEditor();
            LoadGraphicEditor();
            LoadTileEditor();
        }
        private void battlefieldGFXSet2Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            battlefieldGFXSet2Num.Value = battlefieldGFXSet2Name.SelectedIndex;
        }
        private void battlefieldGFXSet3Num_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            battlefield.GraphicSetC = (byte)battlefieldGFXSet3Num.Value;
            battlefieldGFXSet3Name.SelectedIndex = (int)battlefieldGFXSet3Num.Value;
            tileset = new BattlefieldTileset(battlefield, paletteSets[palette]);
            SetBattlefieldImage();
            // reload editors
            LoadPaletteEditor();
            LoadGraphicEditor();
            LoadTileEditor();
        }
        private void battlefieldGFXSet3Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            battlefieldGFXSet3Num.Value = battlefieldGFXSet3Name.SelectedIndex;
        }
        private void battlefieldGFXSet4Num_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            battlefield.GraphicSetD = (byte)battlefieldGFXSet4Num.Value;
            battlefieldGFXSet4Name.SelectedIndex = (int)battlefieldGFXSet4Num.Value;
            tileset = new BattlefieldTileset(battlefield, paletteSets[palette]);
            SetBattlefieldImage();
            // reload editors
            LoadPaletteEditor();
            LoadGraphicEditor();
            LoadTileEditor();
        }
        private void battlefieldGFXSet4Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            battlefieldGFXSet4Num.Value = battlefieldGFXSet4Name.SelectedIndex;
        }
        private void battlefieldGFXSet5Num_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            battlefield.GraphicSetE = (byte)battlefieldGFXSet5Num.Value;
            battlefieldGFXSet5Name.SelectedIndex = (int)battlefieldGFXSet5Num.Value;
            tileset = new BattlefieldTileset(battlefield, paletteSets[palette]);
            SetBattlefieldImage();
            // reload editors
            LoadPaletteEditor();
            LoadGraphicEditor();
            LoadTileEditor();
        }
        private void battlefieldGFXSet5Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            battlefieldGFXSet5Num.Value = battlefieldGFXSet5Name.SelectedIndex;
        }
        private void battlefieldTilesetNum_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            battlefield.TileSet = (byte)battlefieldTilesetNum.Value;
            battlefieldTilesetName.SelectedIndex = (int)battlefieldTilesetNum.Value;
            tileset = new BattlefieldTileset(battlefield, paletteSets[palette]);
            SetBattlefieldImage();
            // reload editors
            LoadPaletteEditor();
            LoadGraphicEditor();
            LoadTileEditor();
        }
        private void battlefieldTilesetName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            battlefieldTilesetNum.Value = battlefieldTilesetName.SelectedIndex;
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
        // image
        private void pictureBoxBattlefield_Paint(object sender, PaintEventArgs e)
        {
            if (battlefieldImage == null) return;

            Rectangle rdst = new Rectangle(0, 0, 512, 512);

            if (buttonToggleBG.Checked)
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
                DrawHoverBox(e.Graphics);

            if (buttonToggleCartGrid.Checked)
                overlay.DrawCartesianGrid(e.Graphics, Color.Gray, pictureBoxBattlefield.Size, new Size(16, 16), 1, true);

            if (overlay.SelectTS != null)
            {
                if (buttonToggleCartGrid.Checked)
                    overlay.DrawSelectionBox(e.Graphics, overlay.SelectTS.Terminal, overlay.SelectTS.Location, 1, Color.Yellow);
                else
                    overlay.DrawSelectionBox(e.Graphics, overlay.SelectTS.Terminal, overlay.SelectTS.Location, 1);
            }
        }
        private void pictureBoxBattlefield_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private void pictureBoxBattlefield_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
        private void pictureBoxBattlefield_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;
            mouseDownObject = null;
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.Focus();
            // set a floor and ceiling for the coordinates
            int x = Math.Max(0, Math.Min(e.X, pictureBox.Width));
            int y = Math.Max(0, Math.Min(e.Y, pictureBox.Height));
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
        private void pictureBoxBattlefield_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter = true;
            pictureBoxBattlefield.Invalidate();
        }
        private void pictureBoxBattlefield_MouseLeave(object sender, EventArgs e)
        {
            mouseEnter = false;
            pictureBoxBattlefield.Invalidate();
        }
        private void pictureBoxBattlefield_MouseMove(object sender, MouseEventArgs e)
        {
            mouseOverObject = null;
            PictureBox pictureBox = (PictureBox)sender;
            // set a floor and ceiling for the coordinates
            int x = Math.Max(0, Math.Min(e.X, pictureBox.Width));
            int y = Math.Max(0, Math.Min(e.Y, pictureBox.Height));
            mousePosition = new Point(x, y);
            if (buttonEditSelect.Checked)
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
                    pictureBoxBattlefield.Cursor = Cursors.SizeAll;
                }
                else
                    pictureBoxBattlefield.Cursor = Cursors.Cross;
            }
            pictureBox.Invalidate();
        }
        private void pictureBoxBattlefield_MouseUp(object sender, MouseEventArgs e)
        {

        }
        private void pictureBoxBattlefield_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Control | Keys.C: Copy(); break;
                case Keys.Control | Keys.X: Cut(); break;
                case Keys.Control | Keys.V:
                    if (draggedTiles != null)
                        PasteFinal(draggedTiles);
                    Paste(new Point(16, 16), copiedTiles);
                    break;
                case Keys.Delete: Delete(); break;
                case Keys.Control | Keys.D:

                    if (draggedTiles != null)
                        PasteFinal(draggedTiles);
                    else
                    {
                        overlay.SelectTS = null;
                        pictureBoxBattlefield.Invalidate();
                    }
                    break;
                case Keys.Control | Keys.A:
                    overlay.Select = new Overlay.Selection(16, 0, 0, 512, 512);
                    pictureBoxBattlefield.Invalidate();
                    break;
            }
        }
        // drawing buttons
        private void buttonToggleCartGrid_Click(object sender, EventArgs e)
        {
            pictureBoxBattlefield.Invalidate();
        }
        private void buttonToggleBG_Click(object sender, EventArgs e)
        {
            pictureBoxBattlefield.Invalidate();
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
                this.pictureBoxBattlefield.Cursor = System.Windows.Forms.Cursors.Cross;
            else
                this.pictureBoxBattlefield.Cursor = System.Windows.Forms.Cursors.Arrow;
            PasteClear();
        }
        // menu strip
        private void save_Click(object sender, EventArgs e)
        {
            Assemble();
        }
        private void import_Click(object sender, EventArgs e)
        {
            new IOElements(this, index, "IMPORT BATTLEFIELDS...").ShowDialog();
            foreach (PaletteSet paletteSet in Model.PaletteSetsBF)
                paletteSet.BUFFER = Model.ROM;
            RefreshBattlefield();
        }
        private void export_Click(object sender, EventArgs e)
        {
            new IOElements(this, index, "EXPORT BATTLEFIELDS...").ShowDialog();
        }
        private void clear_Click(object sender, EventArgs e)
        {
            ClearElements clearElements = new ClearElements(null, index, "CLEAR BATTLEFIELD TILESETS...");
            clearElements.ShowDialog();
            if (clearElements.DialogResult == DialogResult.Cancel)
                return;
            RefreshBattlefield();
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
            Do.Export(battlefieldImage, "battlefield." + index.ToString("d2") + ".png");
        }
        private void exportToBattlefieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tile[] tileset = new Tile[32 * 32];
            tileset = (Tile[])Do.Import(tileset);
            for (int i = 0; i < 32 * 32; i++)
                this.tileset.Tileset_tiles[i] = tileset[i].Copy();
            this.tileset.DrawTileset(this.tileset.Tileset_tiles, this.tileset.Tileset_bytes);
        }
        private void importTilesetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BattlefieldTileset tileset = new BattlefieldTileset();
            tileset = (BattlefieldTileset)Do.Import(tileset);
            if (tileset == null)
                return;
            //
            tileset.Palettes.BUFFER = Model.ROM;
            this.battlefield.GraphicSetA = tileset.Battlefield.GraphicSetA;
            this.battlefield.GraphicSetB = tileset.Battlefield.GraphicSetB;
            this.battlefield.GraphicSetC = tileset.Battlefield.GraphicSetC;
            this.battlefield.GraphicSetD = tileset.Battlefield.GraphicSetD;
            this.battlefield.GraphicSetE = tileset.Battlefield.GraphicSetE;
            this.tileset.Palettes = tileset.Palettes;
            this.tileset.Palettes.CopyTo(Model.PaletteSetsBF[palette]);
            this.tileset.Graphics = tileset.Graphics;
            this.tileset.Tileset_tiles = tileset.Tileset_tiles;
            this.tileset.DrawTileset(this.tileset.Tileset_tiles, this.tileset.Tileset_bytes);

            this.tileset.Assemble(16, 16);

            RefreshBattlefield();
        }
        private void reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current battlefield. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            battlefield = new Battlefield(index);
            Model.Decompress(Model.TilesetsBF, 0x150000, 0x160000, 0x2000, "", index, index + 1, false);
            RefreshBattlefield();
        }
        #endregion
    }
}
