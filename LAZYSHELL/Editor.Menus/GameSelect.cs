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
        private PaletteSet fgPaletteSet { get { return Model.GameSelectPaletteSet; } set { Model.GameSelectPaletteSet = value; } }
        private Bitmap bgImage;
        private Bitmap fgImage;
        private Bitmap stereoImage;
        private Bitmap monoImage;
        private bool editTileset;
        public PictureBox Picture { get { return pictureBoxPreview; } set { pictureBoxPreview = value; } }
        private bool updating;
        private CursorSprite[] cursorSprites;
        private CursorSprite cursorSprite
        {
            get
            { return cursorSprites[cursorName.SelectedIndex]; }
            set
            { cursorSprites[cursorName.SelectedIndex] = value; }
        }
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
            cursorSpriteNum.Items.AddRange(Lists.Numerize(Lists.SpriteNames));
            cursorSprites = new CursorSprite[5];
            for (int i = 0; i < cursorSprites.Length; i++)
                cursorSprites[i] = new CursorSprite(i);
            cursorName.SelectedIndex = 0;
            //
            //LoadFGPaletteEditor();
            //LoadFGGraphicEditor();
            //LoadBGPaletteEditor();
            //LoadSpeakersPaletteEditor();
            //LoadSpeakersGraphicEditor();
        }
        public void Reload(MenusEditor menusEditor)
        {
            this.menusEditor = menusEditor;
            SetBackgroundImage();
            SetForegroundImage();
            //
            //LoadFGPaletteEditor();
            //LoadFGGraphicEditor();
            //LoadBGPaletteEditor();
            //LoadSpeakersPaletteEditor();
            //LoadSpeakersGraphicEditor();
        }
        public void SetBackgroundImage()
        {
            Tile[] tileset = new MenuTileset(Model.GameSelectBGPalette, Model.MenuBGTileset, Model.MenuBGGraphics).Tileset;
            int[] pixels = Do.TilesetToPixels(tileset, 16, 16, 0, false);
            bgImage = Do.PixelsToImage(pixels, 256, 256);
            pictureBoxPreview.Invalidate();
        }
        private void SetForegroundImage()
        {
            Tile[] tileset = new MenuTileset(fgPaletteSet, Model.GameSelectTileset, Model.GameSelectGraphics).Tileset;
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
            pictureBoxPreview.Invalidate();
        }
        private void LoadFGPaletteEditor()
        {
            if (fgPaletteEditor == null)
            {
                fgPaletteEditor = new PaletteEditor(new Function(FGPaletteUpdate), fgPaletteSet, 16, 1, 7);
                fgPaletteEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                fgPaletteEditor.Reload(new Function(FGPaletteUpdate), fgPaletteSet, 16, 1, 7);
        }
        private void LoadFGGraphicEditor()
        {
            if (fgGraphicEditor == null)
            {
                fgGraphicEditor = new GraphicEditor(new Function(FGGraphicUpdate),
                    Model.GameSelectGraphics, Model.GameSelectGraphics.Length, 0, fgPaletteSet, 0, 0x20);
                fgGraphicEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                fgGraphicEditor.Reload(new Function(FGGraphicUpdate),
                    Model.GameSelectGraphics, Model.GameSelectGraphics.Length, 0, fgPaletteSet, 0, 0x20);
        }
        private void LoadBGPaletteEditor()
        {
            if (bgPaletteEditor == null)
            {
                bgPaletteEditor = new PaletteEditor(new Function(BGPaletteUpdate), Model.GameSelectBGPalette, 16, 0, 1);
                bgPaletteEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                bgPaletteEditor.Reload(new Function(BGPaletteUpdate), Model.GameSelectBGPalette, 16, 0, 1);
        }
        private void LoadSpeakersPaletteEditor()
        {
            if (speakersPaletteEditor == null)
            {
                speakersPaletteEditor = new PaletteEditor(new Function(SpeakersPaletteUpdate), fgPaletteSet, 16, 14, 2);
                speakersPaletteEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                speakersPaletteEditor.Reload(new Function(SpeakersPaletteUpdate), fgPaletteSet, 16, 14, 2);
        }
        private void LoadSpeakersGraphicEditor()
        {
            if (speakersGraphicEditor == null)
            {
                speakersGraphicEditor = new GraphicEditor(new Function(SpeakersGraphicUpdate),
                    Model.GameSelectSpeakers, Model.GameSelectSpeakers.Length, 0, fgPaletteSet, 14, 0x20);
                speakersGraphicEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                speakersGraphicEditor.Reload(new Function(FGGraphicUpdate),
                    Model.GameSelectSpeakers, Model.GameSelectSpeakers.Length, 0, fgPaletteSet, 14, 0x20);
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
            SetSpeakersImages();
            LoadSpeakersGraphicEditor();
            checksum--;   // b/c switching colors won't modify checksum
        }
        private void SpeakersGraphicUpdate()
        {
            SetSpeakersImages();
            checksum--;   // b/c switching colors won't modify checksum
        }
        public void Assemble()
        {
            Model.Data[0x03462D] = (byte)this.music.SelectedIndex;
            Model.GameSelectPaletteSet.Assemble();
            Model.GameSelectBGPalette.Assemble();
            Model.Compress(Model.GameSelectGraphics, 0x3E9A49, 0x2000, 0x3EB2CD - 0x3E9A49, "Game select graphics");
            if (editTileset)
                Model.Compress(Model.GameSelectTileset, 0x3EB2CD, 0x800, 0x3EB50F - 0x3EB2CD, "Game select tileset");
            Model.Compress(Model.GameSelectPalettes, 0x3EB50F, 0x200, 0x3EB624 - 0x3EB50F, "Game select palettes");
            Model.Compress(Model.GameSelectSpeakers, 0x3EB624, 0x600, 0x3EB94A - 0x3EB624, "Game select speakers");
            //
            for (int i = 0; i < cursorSprites.Length; i++)
                cursorSprites[i].Assemble();
        }
        public new void Close()
        {
            if (fgPaletteEditor != null)
                fgPaletteEditor.Close();
            if (fgGraphicEditor != null)
                fgGraphicEditor.Close();
            if (bgPaletteEditor != null)
                bgPaletteEditor.Close();
            if (speakersGraphicEditor != null)
                speakersGraphicEditor.Close();
            if (speakersPaletteEditor != null)
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
            //
            int[] pal = Model.FontPaletteMenu.Palette;
            MenuTextPreview pre = new MenuTextPreview();
            Do.DrawText(Model.MenuTexts[43].ToString(), 95, 24, e.Graphics, pre, Model.FontMenu, pal);
            Do.DrawText(Model.MenuTexts[109].ToString(), 47, 56, e.Graphics, pre, Model.FontMenu, pal);
            Do.DrawText(Model.MenuTexts[110].ToString(), 47, 96, e.Graphics, pre, Model.FontMenu, pal);
            Do.DrawText(Model.MenuTexts[111].ToString(), 47, 136, e.Graphics, pre, Model.FontMenu, pal);
            Do.DrawText(Model.MenuTexts[112].ToString(), 47, 176, e.Graphics, pre, Model.FontMenu, pal);
        }
        private void openPalettesFG_Click(object sender, EventArgs e)
        {
            if (fgPaletteEditor == null)
                LoadFGPaletteEditor();
            fgPaletteEditor.Show();
        }
        private void openPalettesBG_Click(object sender, EventArgs e)
        {
            if (bgPaletteEditor == null)
                LoadBGPaletteEditor();
            bgPaletteEditor.Show();
        }
        private void openPaletteSpeakers_Click(object sender, EventArgs e)
        {
            if (speakersPaletteEditor == null)
                LoadSpeakersPaletteEditor();
            speakersPaletteEditor.Show();
        }
        private void openGraphicsFG_Click(object sender, EventArgs e)
        {
            if (fgGraphicEditor == null)
                LoadFGGraphicEditor();
            fgGraphicEditor.Show();
        }
        private void openGraphicsSpeakers_Click(object sender, EventArgs e)
        {
            if (speakersGraphicEditor == null)
                LoadSpeakersGraphicEditor();
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
                fgPaletteSet.Reds[16 * 4 + i] = Color.FromArgb(palette[i]).R;
                fgPaletteSet.Greens[16 * 4 + i] = Color.FromArgb(palette[i]).G;
                fgPaletteSet.Blues[16 * 4 + i] = Color.FromArgb(palette[i]).B;
            }
            Do.PixelsToBPP(pixels, graphics, new Size(256 / 8, 256 / 8), palette, 0x20);
            //
            byte[] tileset = new byte[0x800];
            byte[] temp = new byte[graphics.Length]; graphics.CopyTo(temp, 0);
            int size = Do.CopyToTileset(graphics, tileset, palette, 4, true, false, 0x20, 2, new Size(256, 256), 0);
            //
            Buffer.BlockCopy(tileset, 0, Model.GameSelectTileset, 0, 0x800);
            Buffer.BlockCopy(graphics, 0, Model.GameSelectGraphics, 0, 0x2000);
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
        private void saveImageAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Do.Export(fgImage, "gameSelectFG.png");
        }
        private void cursorName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cursorSpriteNum.SelectedIndex = cursorSprite.Sprite;
            cursorSequence.Value = cursorSprite.Sequence;
        }
        private void cursorSpriteNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            cursorSprite.Sprite = cursorSpriteNum.SelectedIndex;
        }
        private void cursorSequence_ValueChanged(object sender, EventArgs e)
        {
            cursorSprite.Sequence = (int)cursorSequence.Value;
        }
        #endregion
        private class CursorSprite
        {
            private int index;
            public int Sprite;
            public int Sequence;
            public CursorSprite(int index)
            {
                this.index = index;
                switch (index)
                {
                    case 0:
                        Sprite = Bits.GetShort(Model.Data, 0x034757);
                        Sequence = Bits.GetShort(Model.Data, 0x03475C);
                        break;
                    case 1:
                        Sprite = Bits.GetShort(Model.Data, 0x03489A);
                        Sequence = Bits.GetShort(Model.Data, 0x03489F);
                        break;
                    case 2:
                        Sprite = Bits.GetShort(Model.Data, 0x034EE7);
                        Sequence = Bits.GetShort(Model.Data, 0x034EEC);
                        break;
                    case 3:
                        Sprite = Bits.GetShort(Model.Data, 0x0340AA);
                        Sequence = Bits.GetShort(Model.Data, 0x0340AF);
                        break;
                    case 4:
                        Sprite = Bits.GetShort(Model.Data, 0x03501E);
                        Sequence = Bits.GetShort(Model.Data, 0x035021);
                        break;
                }
            }
            public void Assemble()
            {
                switch (index)
                {
                    case 0:
                        Bits.SetShort(Model.Data, 0x034757, Sprite);
                        Bits.SetShort(Model.Data, 0x03475C, Sequence);
                        break;
                    case 1:
                        Bits.SetShort(Model.Data, 0x03489A, Sprite);
                        Bits.SetShort(Model.Data, 0x03489F, Sequence);
                        break;
                    case 2:
                        Bits.SetShort(Model.Data, 0x034EE7, Sprite);
                        Bits.SetShort(Model.Data, 0x034EEC, Sequence);
                        break;
                    case 3:
                        Bits.SetShort(Model.Data, 0x0340AA, Sprite);
                        Bits.SetShort(Model.Data, 0x0340AF, Sequence);
                        break;
                    case 4:
                        Bits.SetShort(Model.Data, 0x03501E, Sprite);
                        Bits.SetShort(Model.Data, 0x035021, Sequence);
                        break;
                }
            }
        }
    }
}
