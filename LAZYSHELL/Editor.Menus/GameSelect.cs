using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public partial class GameSelect : Form
    {
        #region Variables
        private long checksum;
        // main
        private delegate void Function();
        private PaletteSet gsPaletteSet { get { return Model.GameSelectPaletteSet; } set { Model.GameSelectPaletteSet = value; } }
        private Bitmap bgImage;
        private Bitmap fgImage;
        private Bitmap stereoImage;
        private Bitmap monoImage;
        private bool editTileset;
        // editors
        private MenusEditor menusEditor;
        private PaletteEditor fgPaletteEditor;
        private GraphicEditor fgGraphicEditor;
        private PaletteEditor bgPaletteEditor;
        private PaletteEditor speakersPaletteEditor;
        private GraphicEditor speakersGraphicEditor;
        #endregion
        #region Functions
        public GameSelect(MenusEditor menusEditor)
        {
            this.menusEditor = menusEditor;
            InitializeComponent();
            this.music.Items.AddRange(Lists.Numerize(Lists.MusicNames));
            this.music.SelectedIndex = Model.Data[0x03462D];
            SetBackgroundImage();
            SetForegroundImage();
            SetSpeakersImages();
            //
            LoadFGPaletteEditor();
            LoadFGGraphicEditor();
            LoadBGPaletteEditor();
            LoadSpeakersPaletteEditor();
            LoadSpeakersGraphicEditor();
        }
        public void Reload(MenusEditor menusEditor)
        {
            this.menusEditor = menusEditor;
            SetBackgroundImage();
            SetForegroundImage();
            //
            LoadFGPaletteEditor();
            LoadFGGraphicEditor();
            LoadBGPaletteEditor();
            LoadSpeakersPaletteEditor();
            LoadSpeakersGraphicEditor();
        }
        public void SetBackgroundImage()
        {
            Tile[] tileset = new MenuTileset(Model.GameSelectPaletteSet, Model.MenuBGTileset, Model.MenuBGGraphics).Tileset;
            int[] pixels = Do.TilesetToPixels(tileset, 16, 16, 0, false);
            bgImage = Do.PixelsToImage(pixels, 256, 256);
            pictureBoxPreview.Invalidate();
        }
        private void SetForegroundImage()
        {
            Tile[] tileset = new MenuTileset(gsPaletteSet, Model.GameSelectTileset, Model.GameSelectGraphics).Tileset;
            int[] pixels = Do.TilesetToPixels(tileset, 16, 16, 0, false);
            fgImage = Do.PixelsToImage(pixels, 256, 256);
            pictureBoxFG.Invalidate();
            pictureBoxPreview.Invalidate();
        }
        private void SetSpeakersImages()
        {
            int[] pixels = Do.GetPixelRegion(Model.GameSelectSpeakers, 0x20, Model.GameSelectPaletteSet.Palettes[14], 16, 8, 0, 7, 3, 0);
            stereoImage = Do.PixelsToImage(pixels, 56, 24);
            pixels = Do.GetPixelRegion(Model.GameSelectSpeakers, 0x20, Model.GameSelectPaletteSet.Palettes[15], 16, 0, 0, 7, 3, 0);
            monoImage = Do.PixelsToImage(pixels, 56, 24);
        }
        private void LoadFGPaletteEditor()
        {
            if (fgPaletteEditor == null)
            {
                fgPaletteEditor = new PaletteEditor(new Function(FGPaletteUpdate), gsPaletteSet, 16, 1, 7);
                fgPaletteEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                fgPaletteEditor.Reload(new Function(FGPaletteUpdate), gsPaletteSet, 16, 1, 7);
        }
        private void LoadFGGraphicEditor()
        {
            if (fgGraphicEditor == null)
            {
                fgGraphicEditor = new GraphicEditor(new Function(FGGraphicUpdate),
                    Model.GameSelectGraphics, Model.GameSelectGraphics.Length, 0, gsPaletteSet, 0, 0x20);
                fgGraphicEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                fgGraphicEditor.Reload(new Function(FGGraphicUpdate),
                    Model.GameSelectGraphics, Model.GameSelectGraphics.Length, 0, gsPaletteSet, 0, 0x20);
        }
        private void LoadBGPaletteEditor()
        {
            if (bgPaletteEditor == null)
            {
                bgPaletteEditor = new PaletteEditor(new Function(BGPaletteUpdate), gsPaletteSet, 16, 0, 1);
                bgPaletteEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                bgPaletteEditor.Reload(new Function(BGPaletteUpdate), gsPaletteSet, 16, 0, 1);
        }
        private void LoadSpeakersPaletteEditor()
        {
            if (speakersPaletteEditor == null)
            {
                speakersPaletteEditor = new PaletteEditor(new Function(SpeakersPaletteUpdate), gsPaletteSet, 16, 14, 2);
                speakersPaletteEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                speakersPaletteEditor.Reload(new Function(SpeakersPaletteUpdate), gsPaletteSet, 16, 14, 2);
        }
        private void LoadSpeakersGraphicEditor()
        {
            if (speakersGraphicEditor == null)
            {
                speakersGraphicEditor = new GraphicEditor(new Function(SpeakersGraphicUpdate),
                    Model.GameSelectSpeakers, Model.GameSelectSpeakers.Length, 0, gsPaletteSet, 14, 0x20);
                speakersGraphicEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                speakersGraphicEditor.Reload(new Function(FGGraphicUpdate),
                    Model.GameSelectSpeakers, Model.GameSelectSpeakers.Length, 0, gsPaletteSet, 14, 0x20);
        }
        private void FGPaletteUpdate()
        {
            SetForegroundImage();
            LoadFGGraphicEditor();
            checksum--;   // b/c switching colors won't modify checksum
        }
        private void FGGraphicUpdate()
        {
            SetForegroundImage();
            checksum--;   // b/c switching colors won't modify checksum
        }
        private void BGPaletteUpdate()
        {
            SetBackgroundImage();
            checksum--;   // b/c switching colors won't modify checksum
        }
        private void SpeakersPaletteUpdate()
        {
            pictureBoxPreview.Invalidate();
            LoadSpeakersGraphicEditor();
            checksum--;   // b/c switching colors won't modify checksum
        }
        private void SpeakersGraphicUpdate()
        {
            pictureBoxPreview.Invalidate();
            checksum--;   // b/c switching colors won't modify checksum
        }
        public void Assemble()
        {
            Model.Data[0x03462D] = (byte)this.music.SelectedIndex;
            Model.GameSelectPaletteSet.Assemble();
            Model.Compress(Model.GameSelectGraphics, 0x3E9A4A, 0x2000, 0x3EB2CE - 0x3E9A4A, "Game select graphics");
            if (editTileset)
                Model.Compress(Model.GameSelectTileset, 0x3EB2CE, 0x800, 0x3EB510 - 0x3EB2CE, "Game select tileset");
            Model.Compress(Model.GameSelectPalettes, 0x3EB510, 0x200, 0x3EB625 - 0x3EB510, "Game select palettes");
            Model.Compress(Model.GameSelectSpeakers, 0x3EB625, 0x600, 0x3EB94B - 0x3EB625, "Game select speakers");
        }
        public new void Close()
        {
            fgPaletteEditor.Close();
            fgGraphicEditor.Close();
            bgPaletteEditor.Close();
            speakersGraphicEditor.Close();
            speakersPaletteEditor.Close();
        }
        #endregion
        #region Event Handlers
        private void pictureBoxFG_Paint(object sender, PaintEventArgs e)
        {
            if (fgImage != null)
                e.Graphics.DrawImage(fgImage, 0, 0);
        }
        private void pictureBoxPreview_Paint(object sender, PaintEventArgs e)
        {
            if (bgImage != null)
                e.Graphics.DrawImage(bgImage, 0, 0);
            if (fgImage != null)
                e.Graphics.DrawImage(fgImage, 0, 0);
            if (stereoImage != null)
                e.Graphics.DrawImage(stereoImage, 8, 15);
            if (monoImage != null)
                e.Graphics.DrawImage(monoImage, 192, 17);
        }
        private void openPalettesFG_Click(object sender, EventArgs e)
        {
            fgPaletteEditor.Show();
        }
        private void openPalettesBG_Click(object sender, EventArgs e)
        {
            bgPaletteEditor.Show();
        }
        private void openPaletteSpeakers_Click(object sender, EventArgs e)
        {
            speakersPaletteEditor.Show();
        }
        private void openGraphicsFG_Click(object sender, EventArgs e)
        {
            fgGraphicEditor.Show();
        }
        private void openGraphicsSpeakers_Click(object sender, EventArgs e)
        {
            speakersGraphicEditor.Show();
        }
        private void importFGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = LAZYSHELL.Properties.Settings.Default.LastRomPath;
            openFileDialog1.Title = "Import background image";
            openFileDialog1.Filter = "Image files (*.gif,*.jpg,*.png)|*.gif;*.jpg;*.png";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            if (openFileDialog1.FileName == null)
                return;
            Bitmap import = new Bitmap(Image.FromFile(openFileDialog1.FileName));
            //
            if (import.Width > 256 || import.Height > 256)
            {
                MessageBox.Show(
                    "The dimensions of the imported image must be no larger than 256 x 256.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //
            byte[] graphics = new byte[0x8000];
            int[] pixels = Do.ImageToPixels(import, new Size(256, 256), new Rectangle(0, 0, 256, 256));
            int[] palette = Do.ReduceColorDepth(pixels, 16, 0);
            for (int i = 0; i < palette.Length; i++)
            {
                Model.MenuBGPalette.Reds[i] = Color.FromArgb(palette[i]).R;
                Model.MenuBGPalette.Greens[i] = Color.FromArgb(palette[i]).G;
                Model.MenuBGPalette.Blues[i] = Color.FromArgb(palette[i]).B;
            }
            Do.PixelsToBPP(pixels, graphics, new Size(256 / 8, 256 / 8), palette, 0x20);
            //
            byte[] tileset = new byte[0x800];
            byte[] temp = new byte[graphics.Length]; graphics.CopyTo(temp, 0);
            int size = Do.CopyToTileset(graphics, tileset, palette, 5, true, false, 0x20, 2, new Size(256, 256), 0x100);
            //
            Buffer.BlockCopy(tileset, 0, Model.MenuBGTileset, 0, 0x800);
            Buffer.BlockCopy(graphics, 0, Model.MenuBGGraphics, 0, 0x2000);
            if (size > 8192)
                MessageBox.Show("Not enough space to store the necessary amount of SNES graphics data for the imported images. The total required space (" +
                    size + " bytes) for the new SNES graphics data exceeds 8192 bytes.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //
            SetForegroundImage();
            LoadFGPaletteEditor();
            editTileset = true;
            checksum--;
        }
        private void editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            ((Form)sender).Hide();
        }
        #endregion
    }
}
