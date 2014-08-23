using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Areas;
using WeifenLuo.WinFormsUI.Docking;

namespace LAZYSHELL.Intro
{
    public partial class TitleScreenForm : MapEditor
    {
        #region Variables

        // Forms
        private OwnerForm ownerForm;
        private PaletteEditor spritePaletteEditor;
        private GraphicEditor spriteGraphicEditor;
        private delegate void UpdateFunction();

        // Elements
        public new PaletteSet PaletteSet
        {
            get { return Model.Title_Palettes; }
            set { Model.Title_Palettes = value; }
        }
        private PaletteSet spritePaletteSet
        {
            get { return Model.Title_SpritePalettes; }
            set { Model.Title_SpritePalettes = value; }
        }

        // Picture
        private Bitmap[] tilesetImage;

        #endregion

        // Constructor
        public TitleScreenForm(OwnerForm ownerForm)
        {
            this.ownerForm = ownerForm;
            //
            InitializeComponent();
            InitializeVariables();
            SetTilesetImages();
            //
            this.History = new History(this);
        }

        #region Methods

        private void InitializeVariables()
        {
            this.Overlay = new Overlay();
            this.Tileset = Model.Title_Tileset;
            this.tilesetImage = new Bitmap[3];
        }

        // Set images
        private void SetTilesetImages()
        {
            int[] pixels = Do.TilesetToPixels(Tileset.Tilesets_tiles[0], 16, 32, 0, false);
            tilesetImage[0] = Do.PixelsToImage(pixels, 256, 512);
            pixels = Do.TilesetToPixels(Tileset.Tilesets_tiles[1], 16, 32, 0, false);
            tilesetImage[1] = Do.PixelsToImage(pixels, 256, 512);
            pixels = Do.TilesetToPixels(Tileset.Tilesets_tiles[2], 16, 6, 0, false);
            tilesetImage[2] = Do.PixelsToImage(pixels, 256, 96);
            pictureBoxTitle.Invalidate();
        }

        // Forms
        public void LoadTilesetEditor()
        {
            if (TilesetForm == null)
            {
                for (int i = 0; i < 3; i++)
                {
                    TilesetForms[i] = new TilesetForm(this, i);
                    TilesetForms[i].AutoUpdate = true;
                    if (i == 0)
                        this.TilesetForms[i].ToggleButton = toggleTilesetL1Form;
                    else if (i == 1)
                        this.TilesetForms[i].ToggleButton = toggleTilesetL2Form;
                    else if (i == 2)
                        this.TilesetForms[i].ToggleButton = toggleTilesetL3Form;
                    this.TilesetForms[i].Show(this.ownerForm.DockPanel, DockState.DockLeft);
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                    TilesetForms[i].Reload(this);
            }
        }
        private void LoadPaletteEditor()
        {
            if (PaletteEditor == null)
            {
                PaletteEditor = new PaletteEditor(new PaletteTitleUpdater(), PaletteSet, 8, 0, 8);
                PaletteEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
                PaletteEditor.Owner = this.Owner;
            }
            else
                PaletteEditor.Reload(PaletteSet, 8, 0, 8);
        }
        private void LoadGraphicEditor()
        {
            if (GraphicEditor == null)
            {
                GraphicEditor = new GraphicEditor(new GraphicTitleUpdater(),
                    Layer != 2 ? Tileset.Graphics : Tileset.GraphicsL3,
                    Layer != 2 ? Tileset.Graphics.Length : Tileset.GraphicsL3.Length,
                    0, PaletteSet, 0, 0x20);
                GraphicEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
                GraphicEditor.Owner = this.Owner;
            }
            else
                GraphicEditor.Reload(Layer != 2 ? Tileset.Graphics : Tileset.GraphicsL3,
                    Layer != 2 ? Tileset.Graphics.Length : Tileset.GraphicsL3.Length,
                    0, PaletteSet, 0, 0x20);
        }
        private void LoadSpritePaletteEditor()
        {
            if (spritePaletteEditor == null)
            {
                spritePaletteEditor = new PaletteEditor(new PaletteSpriteUpdater(), spritePaletteSet, 5, 0, 5);
                spritePaletteEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
                spritePaletteEditor.Owner = this.Owner;
            }
            else
                spritePaletteEditor.Reload(spritePaletteSet, 5, 0, 5);
        }
        private void LoadSpriteGraphicEditor()
        {
            if (spriteGraphicEditor == null)
            {
                spriteGraphicEditor = new GraphicEditor(new GraphicSpriteUpdater(),
                    Model.Title_SpriteGraphics, Model.Title_SpriteGraphics.Length, 0, spritePaletteSet, 0, 0x20);
                spriteGraphicEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
                spriteGraphicEditor.Owner = this;
            }
            else
                spriteGraphicEditor.Reload(Model.Title_SpriteGraphics, Model.Title_SpriteGraphics.Length, 0, spritePaletteSet, 0, 0x20);
        }

        // Updating
        public void UpdatePalette()
        {
            Tileset = new Tileset(PaletteSet, TilesetType.Title);
            SetTilesetImages();
            LoadGraphicEditor();
            LoadTilesetEditor();
            this.Modified = true;   // b/c switching colors won't modify checksum
        }
        public void UpdateGraphics()
        {
            Tileset.WriteToModel(16);
            Tileset = new Tileset(PaletteSet, TilesetType.Title);
            if (Layer != 2)
                Tileset.Graphics = GraphicEditor.Graphics;
            else
                Tileset.GraphicsL3 = GraphicEditor.Graphics;
            SetTilesetImages();
            LoadTilesetEditor();
        }
        public void UpdateSpritePalettes()
        {
            LoadSpriteGraphicEditor();
        }
        public void UpdateSpriteGraphics()
        {
        }
        public void UpdateTileset()
        {
            Tileset.WriteToModel(16);
            SetTilesetImages();
        }
        public void UpdateTile()
        {

        }

        // Saving
        public void WriteToROM()
        {
            // Palette set
            PaletteSet.WriteToBuffer();
            spritePaletteSet.WriteToBuffer();
            Tileset.WriteToModel(16);
            // Tilesets
            if (Comp.Compress(Model.Title_Data, 0x3F216E, 0xDA60, 0x7E92, "Main title"))
                this.Modified = false;
        }

        #endregion

        #region Event Handlers

        // Data management
        private void save_Click(object sender, EventArgs e)
        {
            WriteToROM();
        }

        // Picture
        private void picture_Paint(object sender, PaintEventArgs e)
        {
            if (tilesetImage[0] != null && tilesetImage[1] != null && tilesetImage[2] != null)
            {
                var bgcolor = Color.FromArgb(PaletteSet.Palette[0]);
                e.Graphics.FillRectangle(new SolidBrush(bgcolor), new Rectangle(new Point(0, 0), pictureBoxTitle.Size));
                e.Graphics.DrawImage(tilesetImage[1], 0, 0);
                e.Graphics.DrawImage(tilesetImage[0], 0, 0);
                var upperPart = new Rectangle(0, 0, 256, 72);
                var lowerPart = new Rectangle(0, 72, 256, 24);
                e.Graphics.DrawImage(tilesetImage[2].Clone(upperPart, PixelFormat.DontCare), 0, 208);
                e.Graphics.DrawImage(tilesetImage[2].Clone(lowerPart, PixelFormat.DontCare), 0, 368);
            }
        }

        // Forms
        private void openPalettes_Click(object sender, EventArgs e)
        {
            if (PaletteEditor == null)
                LoadPaletteEditor();
            PaletteEditor.Show();
        }
        private void openGraphics_Click(object sender, EventArgs e)
        {
            if (GraphicEditor == null)
                LoadGraphicEditor();
            GraphicEditor.Show();
        }
        private void openSpritePalettes_Click(object sender, EventArgs e)
        {
            if (spritePaletteEditor == null)
                LoadSpritePaletteEditor();
            spritePaletteEditor.Show();
        }
        private void openSpriteGraphics_Click(object sender, EventArgs e)
        {
            if (spriteGraphicEditor == null)
                LoadSpriteGraphicEditor();
            spriteGraphicEditor.Show();
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
