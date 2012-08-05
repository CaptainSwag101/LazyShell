using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    public partial class Overworld : Form
    {
        #region Variables
        private long checksum { get { return menusEditor.Checksum; } set { menusEditor.Checksum = value; } }
        // main
        private delegate void Function();
        private PaletteSet framePaletteSet { get { return Model.FontPaletteMenu; } set { Model.FontPaletteMenu = value; } }
        private PaletteSet bgPaletteSet { get { return Model.MenuBGPalette; } set { Model.MenuBGPalette = value; } }
        private PaletteSet cursorPaletteSet { get { return Model.CursorPaletteSet; } set { Model.CursorPaletteSet = value; } }
        private Bitmap bgImage;
        private Bitmap frameImage;
        private Bitmap previewImage;
        private Bitmap[] allyImages;
        private Bitmap[] cursorImages;
        private Settings settings = Settings.Default;
        public PictureBox Picture { get { return pictureBoxPreview; } set { pictureBoxPreview = value; } }
        private bool updating;
        // editors
        private MenusEditor menusEditor;
        private PaletteEditor framePaletteEditor;
        private GraphicEditor frameGraphicEditor;
        private PaletteEditor bgPaletteEditor;
        private PaletteEditor shopBGPaletteEditor;
        private GraphicEditor bgGraphicEditor;
        private PaletteEditor cursorsPaletteEditor;
        private GraphicEditor cursorsGraphicEditor;
        #endregion
        public Overworld(MenusEditor menusEditor)
        {
            this.menusEditor = menusEditor;
            InitializeComponent();
            SetAllyImages();
            SetFrameImage();
            SetBackgroundImage();
            SetCursorImages();
            SetPreviewImage();
            updating = true;
            previewType.SelectedIndex = 0;
            updating = false;
            //
            //LoadFramePaletteEditor();
            //LoadFrameGraphicEditor();
            //LoadBGPaletteEditor();
            //LoadShopBGPaletteEditor();
            //LoadBGGraphicEditor();
            //LoadCursorsPaletteEditor();
            //LoadCursorsGraphicEditor();
        }
        public void Reload(MenusEditor menusEditor)
        {
            SetAllyImages();
            SetFrameImage();
            SetBackgroundImage();
            SetCursorImages();
            SetPreviewImage();
            updating = true;
            previewType.SelectedIndex = 0;
            updating = false;
            //
            //LoadFramePaletteEditor();
            //LoadFrameGraphicEditor();
            //LoadBGPaletteEditor();
            //LoadShopBGPaletteEditor();
            //LoadBGGraphicEditor();
            //LoadCursorsPaletteEditor();
            //LoadCursorsGraphicEditor();
            GC.Collect();
        }
        #region Functions
        private void SetCursorImages()
        {
            cursorImages = new Bitmap[5];
            int[] cursor = Do.GetPixelRegion(Model.MenuCursorGraphics, 0x20, cursorPaletteSet.Palette, 16, 0, 0, 3, 2, 0);
            int[] pageRight = Do.GetPixelRegion(Model.MenuCursorGraphics, 0x20, cursorPaletteSet.Palette, 16, 3, 0, 2, 2, 0);
            int[] upArrow = Do.GetPixelRegion(Model.MenuCursorGraphics, 0x20, cursorPaletteSet.Palette, 16, 5, 0, 2, 2, 0);
            int[] downArrow = Do.GetPixelRegion(Model.MenuCursorGraphics, 0x20, cursorPaletteSet.Palette, 16, 7, 0, 2, 2, 0);
            int[] pageDown = Do.GetPixelRegion(Model.MenuCursorGraphics, 0x20, cursorPaletteSet.Palette, 16, 9, 0, 2, 2, 0);
            cursorImages[0] = Do.PixelsToImage(cursor, 24, 16);
            cursorImages[1] = Do.PixelsToImage(pageRight, 16, 16);
            cursorImages[2] = Do.PixelsToImage(upArrow, 16, 16);
            cursorImages[3] = Do.PixelsToImage(downArrow, 16, 16);
            cursorImages[4] = Do.PixelsToImage(pageDown, 16, 16);
            pictureBoxPreview.Invalidate();
        }
        private void SetAllyImages()
        {
            allyImages = new Bitmap[5];
            for (int i = 0; i < allyImages.Length; i++)
            {
                int[] pixels = Model.NPCProperties[i].CreateImage(2, false, i, true);
                int height = Model.NPCProperties[i].ImageHeight;
                int width = Model.NPCProperties[i].ImageWidth;
                allyImages[i] = Do.PixelsToImage(pixels, width, height);
            }
        }
        private void SetFrameImage()
        {
            frameImage = Do.PixelsToImage(
                Do.DrawMenuFrame(new Size(5, 6), Model.MenuFrameGraphics, Model.FontPaletteMenu.Palette), 40, 48);
            pictureBoxFrame.Invalidate();
        }
        private void SetBackgroundImage()
        {
            if (previewType.SelectedIndex < 7)
                bgImage = Model.MenuBG;
            else
                bgImage = Model.ShopBG;
            pictureBoxBG.Invalidate();
        }
        private void SetPreviewImage()
        {
            int[] bgPixels;
            if (previewType.SelectedIndex < 7)
                bgPixels = Do.ImageToPixels(Model.MenuBG);
            else
                bgPixels = Do.ImageToPixels(Model.ShopBG);
            Rectangle[] frames;
            switch (previewType.SelectedIndex)
            {
                default: frames = new Rectangle[] // Overworld
                    {
                        new Rectangle(8, 7, 15, 6),
                        new Rectangle(8, 55, 15, 6),
                        new Rectangle(8, 103, 15, 6),
                        new Rectangle(136, 7, 14, 15),
                        new Rectangle(144, 127, 12, 11)
                    };
                    break;
                case 1: frames = new Rectangle[] // Overworld - Items
                    {
                        new Rectangle(8, 7, 15, 6),
                        new Rectangle(8, 55, 15, 6),
                        new Rectangle(8, 103, 15, 6),
                        new Rectangle(8, 151, 15, 8),
                        new Rectangle(8, 151, 15, 3),
                        new Rectangle(128, 7, 17, 25)
                    };
                    break;
                case 2: frames = new Rectangle[] // Overworld - status
                    {
                        new Rectangle(8, 7, 15, 6),
                        new Rectangle(8, 55, 15, 6),
                        new Rectangle(8, 103, 15, 6),
                        new Rectangle(128, 7, 15, 25)
                    };
                    break;
                case 3: frames = new Rectangle[] // Overworld - special
                    {
                        new Rectangle(8, 7, 15, 6),
                        new Rectangle(8, 55, 15, 6),
                        new Rectangle(8, 103, 15, 6),
                        new Rectangle(128, 7, 15, 11),
                        new Rectangle(128, 103, 15, 3),
                        new Rectangle(128, 127, 15, 11)
                    };
                    break;
                case 4: frames = new Rectangle[] // Overworld - equip
                    {
                        new Rectangle(0, 7, 17, 6),
                        new Rectangle(0, 55, 17, 6),
                        new Rectangle(0, 103, 17, 6),
                        new Rectangle(0, 151, 17, 8),
                        new Rectangle(136, 7, 17, 25)
                    };
                    break;
                case 5: frames = new Rectangle[] // Overworld - special item
                    {
                        new Rectangle(8, 39, 30, 14),
                        new Rectangle(64, 151, 16, 6)
                    };
                    break;
                case 6: frames = new Rectangle[] // Overworld - switch
                    {
                        new Rectangle(8, 7, 15, 6),
                        new Rectangle(8, 55, 15, 6),
                        new Rectangle(8, 103, 15, 6),
                        new Rectangle(128, 55, 15, 6),
                        new Rectangle(128, 103, 15, 6),
                        new Rectangle(136, 159, 13, 6)
                    };
                    break;
                case 7: frames = new Rectangle[] // Shop
                    {
                        new Rectangle(8, 7, 15, 8),
                        new Rectangle(8, 79, 15, 3),
                        new Rectangle(128, 7, 15, 26)
                    };
                    break;
                case 8: frames = new Rectangle[] // Shop - buy
                    {
                        new Rectangle(8, 7, 15, 15),
                        new Rectangle(8, 127, 15, 8),
                        new Rectangle(128, 7, 15, 25)
                    };
                    break;
                case 9: frames = new Rectangle[] // Shop - sell items
                    {
                        new Rectangle(8, 7, 15, 15),
                        new Rectangle(128, 7, 17, 25)
                    };
                    break;
                case 10: frames = new Rectangle[] // Shop - sell weapons
                    {
                        new Rectangle(8, 7, 15, 15),
                        new Rectangle(8, 127, 15, 8),
                        new Rectangle(128, 7, 17, 25)
                    };
                    break;
            }
            foreach (Rectangle frame in frames)
                Do.DrawMenuFrame(bgPixels, 256, frame, Model.MenuFrameGraphics, Model.FontPaletteMenu.Palette);
            previewImage = Do.PixelsToImage(bgPixels, 256, 224);
            pictureBoxPreview.Invalidate();
        }
        private void LoadFramePaletteEditor()
        {
            if (framePaletteEditor == null)
            {
                framePaletteEditor = new PaletteEditor(new Function(FramePaletteUpdate), framePaletteSet, 1, 0, 1);
                framePaletteEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                framePaletteEditor.Reload(new Function(FramePaletteUpdate), framePaletteSet, 1, 0, 1);
        }
        private void LoadFrameGraphicEditor()
        {
            if (frameGraphicEditor == null)
            {
                frameGraphicEditor = new GraphicEditor(new Function(FrameGraphicUpdate),
                    Model.MenuFrameGraphics, Model.MenuFrameGraphics.Length, 0, framePaletteSet, 0, 0x10);
                frameGraphicEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                frameGraphicEditor.Reload(new Function(FrameGraphicUpdate),
                    Model.MenuFrameGraphics, Model.MenuFrameGraphics.Length, 0, framePaletteSet, 0, 0x10);
        }
        private void LoadBGPaletteEditor()
        {
            if (bgPaletteEditor == null)
            {
                bgPaletteEditor = new PaletteEditor(new Function(BGPaletteUpdate), bgPaletteSet, 1, 0, 1);
                bgPaletteEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                bgPaletteEditor.Reload(new Function(BGPaletteUpdate), bgPaletteSet, 1, 0, 1);
        }
        private void LoadShopBGPaletteEditor()
        {
            if (shopBGPaletteEditor == null)
            {
                shopBGPaletteEditor = new PaletteEditor(new Function(ShopBGPaletteUpdate), Model.ShopBGPalette, 1, 0, 1);
                shopBGPaletteEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                shopBGPaletteEditor.Reload(new Function(ShopBGPaletteUpdate), Model.ShopBGPalette, 1, 0, 1);
        }
        private void LoadBGGraphicEditor()
        {
            if (bgGraphicEditor == null)
            {
                bgGraphicEditor = new GraphicEditor(new Function(BGGraphicUpdate),
                    Model.MenuBGGraphics, Model.MenuBGGraphics.Length, 0, bgPaletteSet, 0, 0x20);
                bgGraphicEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                bgGraphicEditor.Reload(new Function(BGGraphicUpdate),
                    Model.MenuBGGraphics, Model.MenuBGGraphics.Length, 0, bgPaletteSet, 0, 0x20);
        }
        private void LoadCursorsPaletteEditor()
        {
            if (cursorsPaletteEditor == null)
            {
                cursorsPaletteEditor = new PaletteEditor(new Function(CursorsPaletteUpdate), cursorPaletteSet, 1, 0, 1);
                cursorsPaletteEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                cursorsPaletteEditor.Reload(new Function(CursorsPaletteUpdate), cursorPaletteSet, 1, 0, 1);
        }
        private void LoadCursorsGraphicEditor()
        {
            if (cursorsGraphicEditor == null)
            {
                cursorsGraphicEditor = new GraphicEditor(new Function(BGGraphicUpdate),
                    Model.MenuCursorGraphics, Model.MenuCursorGraphics.Length, 0, cursorPaletteSet, 0, 0x20);
                cursorsGraphicEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                cursorsGraphicEditor.Reload(new Function(CursorsGraphicUpdate),
                    Model.MenuCursorGraphics, Model.MenuCursorGraphics.Length, 0, cursorPaletteSet, 0, 0x20);
        }
        private void FramePaletteUpdate()
        {
            SetFrameImage();
            SetPreviewImage();
            LoadFrameGraphicEditor();
            checksum--;   // b/c switching colors won't modify checksum
        }
        private void FrameGraphicUpdate()
        {
            SetFrameImage();
            SetPreviewImage();
            checksum--;   // b/c switching colors won't modify checksum
        }
        private void BGPaletteUpdate()
        {
            Model.MenuBG = null;
            if (previewType.SelectedIndex < 7)
            {
                SetBackgroundImage();
                SetPreviewImage();
                LoadBGGraphicEditor();
            }
            checksum--;   // b/c switching colors won't modify checksum
        }
        private void ShopBGPaletteUpdate()
        {
            Model.ShopBG = null;
            if (previewType.SelectedIndex >= 7)
            {
                SetBackgroundImage();
                SetPreviewImage();
                LoadBGGraphicEditor();
            }
            checksum--;   // b/c switching colors won't modify checksum
        }
        private void BGGraphicUpdate()
        {
            Model.MenuBG = null;
            Model.ShopBG = null;
            SetBackgroundImage();
            SetPreviewImage();
            menusEditor.GameSelect.SetBackgroundImage();
            checksum--;   // b/c switching colors won't modify checksum
        }
        private void CursorsPaletteUpdate()
        {
            SetCursorImages();
            SetPreviewImage();
            LoadCursorsGraphicEditor();
            checksum--;   // b/c switching colors won't modify checksum
        }
        private void CursorsGraphicUpdate()
        {
            checksum--;   // b/c switching colors won't modify checksum
        }
        //
        private void ImportBackground(Bitmap import)
        {
            if (import.Width > 256 || import.Height > 256)
            {
                MessageBox.Show(
                    "The dimensions of the imported image must be no larger than 256x256.",
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
            Model.MenuBG = null;
            SetBackgroundImage();
            SetPreviewImage();
            LoadBGGraphicEditor();
            LoadBGPaletteEditor();
            checksum--;
        }
        private void ImportFrame(Bitmap import)
        {
            if (import.Width != 40 || import.Height != 48)
            {
                MessageBox.Show(
                    "The dimensions of the imported image must be exactly 40 x 48.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //
            byte[] graphics = new byte[0x1E0];
            int[] pixels = Do.ImageToPixels(import, new Size(40, 48), new Rectangle(0, 0, 40, 48));
            int[] palette = Do.ReduceColorDepth(pixels, 4, 0);
            Do.PixelsToBPP(pixels, graphics, new Size(5, 6), palette, 0x10);
            for (int i = 0; i < palette.Length; i++)
            {
                Model.FontPaletteMenu.Reds[i] = Color.FromArgb(palette[i]).R;
                Model.FontPaletteMenu.Greens[i] = Color.FromArgb(palette[i]).G;
                Model.FontPaletteMenu.Blues[i] = Color.FromArgb(palette[i]).B;
            }
            // top
            for (int a = 0; a < 0x50; a++)
                Model.MenuFrameGraphics[a] = graphics[a];
            for (int a = 0x100, b = 0x50; a < 0x150 && b < 0xA0; a++, b++)
                Model.MenuFrameGraphics[a] = graphics[b];
            // bottom
            for (int a = 0x170, b = 0x190; a < 0x1C0 && b < 0x1E0; a++, b++)
                Model.MenuFrameGraphics[a] = graphics[b];
            for (int a = 0x70, b = 0x140; a < 0xC0 && b < 0x190; a++, b++)
                Model.MenuFrameGraphics[a] = graphics[b];
            // sides
            for (int a = 0x50, b = 0xA0; a < 0x60 && b < 0xB0; a++, b++)
                Model.MenuFrameGraphics[a] = graphics[b];
            for (int a = 0x60, b = 0xE0; a < 0x70 && b < 0xF0; a++, b++)
                Model.MenuFrameGraphics[a] = graphics[b];
            for (int a = 0x150, b = 0xF0; a < 0x160 && b < 0x100; a++, b++)
                Model.MenuFrameGraphics[a] = graphics[b];
            for (int a = 0x160, b = 0x130; a < 0x160 && b < 0x140; a++, b++)
                Model.MenuFrameGraphics[a] = graphics[b];
            //
            SetFrameImage();
            SetPreviewImage();
            LoadFrameGraphicEditor();
            LoadFramePaletteEditor();
            checksum--;
        }
        //
        public void Assemble()
        {
            Model.FontPaletteMenu.Assemble();
            Model.MenuBGPalette.Assemble();
            Model.ShopBGPalette.Assemble();
            Model.CursorPaletteSet.Assemble(Model.MenuPalettes, 0x100);
            int offset = 0x4C;
            byte[] dst = new byte[0x2E81];
            // copy uncompressed world map logo graphics
            Bits.SetShort(dst, 0x00, 0x4C);
            Buffer.BlockCopy(Model.Data, 0x3E004C, dst, 0x4C, 0xE1C);
            offset += 0xE1C;
            //
            Bits.SetShort(dst, 0x02, offset);
            if (!Model.Compress(Model.MenuBGGraphics, dst, ref offset, 0x2E81, "BG graphics")) return;
            Bits.SetShort(dst, 0x04, offset);
            if (!Model.Compress(Model.MenuFrameGraphics, dst, ref offset, 0x2E81, "Frame graphics")) return;
            Bits.SetShort(dst, 0x06, offset);
            if (!Model.Compress(Model.MenuCursorGraphics, dst, ref offset, 0x2E81, "Cursor graphics")) return;
            Bits.SetShort(dst, 0x08, offset);
            if (!Model.Compress(Model.MenuBGTileset, dst, ref offset, 0x2E81, "BG tileset")) return;
            Bits.SetShort(dst, 0x0A, offset);
            if (!Model.Compress(Model.UNKTileset3E2C80, dst, ref offset, 0x2E81, "UNK tileset")) return;
            Bits.SetShort(dst, 0x0C, offset);
            if (!Model.Compress(Model.MenuPalettes, dst, ref offset, 0x2E81, "Menu palettes")) return;
            // set pointers (just the first 7 for menu data)
            Buffer.BlockCopy(dst, 0, Model.Data, 0x3E0000, 0x0E);
            // store compressed data (starting at start of data)
            Buffer.BlockCopy(dst, 0x4C, Model.Data, 0x3E004C, dst.Length - 0x4C);
            //
            checksum = Do.GenerateChecksum(Model.FontPaletteMenu, Model.MenuFrameGraphics, Model.MenuBGPalette, Model.MenuBGGraphics);
        }
        public new void Close()
        {
            if (framePaletteEditor != null)
                framePaletteEditor.Close();
            if (frameGraphicEditor != null)
                frameGraphicEditor.Close();
            if (bgPaletteEditor != null)
                bgPaletteEditor.Close();
            if (shopBGPaletteEditor != null)
                shopBGPaletteEditor.Close();
            if (bgGraphicEditor != null)
                bgGraphicEditor.Close();
            if (cursorsGraphicEditor != null)
                cursorsGraphicEditor.Close();
            if (cursorsPaletteEditor != null)
                cursorsPaletteEditor.Close();
        }
        #endregion
        #region Event Handlers
        private void pictureBoxFrame_Paint(object sender, PaintEventArgs e)
        {
            if (frameImage == null)
                return;
            e.Graphics.DrawImage(frameImage, 0, 0);
        }
        private void pictureBoxBG_Paint(object sender, PaintEventArgs e)
        {
            if (bgImage == null)
                return;
            e.Graphics.DrawImage(bgImage, 0, 0);
        }
        private void pictureBoxPreview_Paint(object sender, PaintEventArgs e)
        {
            if (previewImage == null)
                return;
            e.Graphics.DrawImage(previewImage, 0, 0);
            //
            int[] pal = Model.FontPaletteMenu.Palette;
            MenuTextPreview pre = new MenuTextPreview();
            //
            switch (previewType.SelectedIndex)
            {
                default:
                    if (allyImages != null)
                    {
                        e.Graphics.DrawImage(allyImages[0], 28 - (allyImages[0].Width / 2), 17);
                        e.Graphics.DrawImage(allyImages[2], 28 - (allyImages[2].Width / 2), 55);
                        e.Graphics.DrawImage(allyImages[4], 28 - (allyImages[4].Width / 2), 111);
                    }
                    //
                    Do.DrawText(Model.Characters[0].ToString(), 39, 12, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText(Model.MenuTexts[31].ToString(), 39, 24, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText(Model.MenuTexts[12].ToString(), 39, 36, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText("30          ", 71, 24, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText("209/209     ", 63, 36, e.Graphics, pre, Model.FontMenu, pal);
                    //
                    Do.DrawText(Model.Characters[2].ToString(), 39, 60, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText(Model.MenuTexts[31].ToString(), 39, 72, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText(Model.MenuTexts[12].ToString(), 39, 84, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText("30          ", 71, 72, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText("240/240     ", 63, 84, e.Graphics, pre, Model.FontMenu, pal);
                    //
                    Do.DrawText(Model.Characters[3].ToString(), 39, 108, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText(Model.MenuTexts[31].ToString(), 39, 120, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText(Model.MenuTexts[12].ToString(), 39, 132, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText("30          ", 71, 120, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText("195/195     ", 63, 132, e.Graphics, pre, Model.FontMenu, pal);
                    //
                    if (previewType.SelectedIndex == 0)
                    {
                        Do.DrawText(Model.MenuTexts[1].ToString(), 143, 12, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText(Model.MenuTexts[3].ToString(), 143, 24, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText(Model.MenuTexts[2].ToString(), 143, 36, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText(Model.MenuTexts[0].ToString(), 143, 48, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText(Model.MenuTexts[4].ToString(), 143, 60, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText(Model.MenuTexts[5].ToString(), 143, 72, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText(Model.MenuTexts[6].ToString(), 143, 84, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText(Model.MenuTexts[7].ToString(), 143, 96, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText(Model.MenuTexts[8].ToString(), 143, 108, e.Graphics, pre, Model.FontMenu, pal);
                        //
                        Do.DrawText(Model.MenuTexts[55].ToString(), 151, 132, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText("99/99       ", 191, 145, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText(Model.MenuTexts[27].ToString(), 151, 156, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText("999         ", 207, 169, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText(Model.MenuTexts[56].ToString(), 151, 180, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText("999         ", 207, 193, e.Graphics, pre, Model.FontMenu, pal);
                        //
                        if (cursorImages != null)
                        {
                            e.Graphics.DrawImage(cursorImages[0], 124, 13);
                            //e.Graphics.DrawImage(cursorImages[1], 32, 160);
                            //e.Graphics.DrawImage(cursorImages[2], 48, 160);
                            //e.Graphics.DrawImage(cursorImages[3], 64, 160);
                            //e.Graphics.DrawImage(cursorImages[4], 80, 160);
                        }
                    }
                    else if (previewType.SelectedIndex == 1) // Overworld - items
                    {
                        Do.DrawText(Model.MenuTexts[55].ToString(), 15, 156, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText("99/99       ", 79, 156, e.Graphics, pre, Model.FontMenu, pal);
                        if (cursorImages != null)
                        {
                            e.Graphics.DrawImage(cursorImages[0], 116, 13);
                            e.Graphics.DrawImage(cursorImages[1], 232, 191);
                        }
                    }
                    else if (previewType.SelectedIndex == 2) // Overworld - status
                    {
                        Do.DrawText(Model.MenuTexts[19].ToString(), 168, 12, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText(Model.MenuTexts[15].ToString(), 160, 48, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText(Model.MenuTexts[16].ToString(), 151, 72, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText(Model.MenuTexts[17].ToString(), 135, 96, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText(Model.MenuTexts[18].ToString(), 135, 120, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText(Model.MenuTexts[14].ToString(), 135, 156, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText("255", 216, 12, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText("255", 216, 24, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText("255", 216, 48, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText("255", 216, 60, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText("255", 216, 72, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText("255", 216, 84, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText("255", 216, 96, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText("255", 216, 108, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText("255", 216, 120, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText("9999", 208, 168, e.Graphics, pre, Model.FontMenu, pal);
                        if (cursorImages != null)
                            e.Graphics.DrawImage(cursorImages[0], 4, 23);
                    }
                    else if (previewType.SelectedIndex == 3) // Overworld - special
                    {
                        Do.DrawText(Model.MenuTexts[55].ToString(), 135, 108, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText("99/99       ", 200, 108, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText(Model.Spells[0].ToString(), 135, 12, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText(Model.Spells[1].ToString(), 135, 24, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText(Model.Spells[2].ToString(), 135, 36, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText(Model.Spells[3].ToString(), 135, 48, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText(Model.Spells[4].ToString(), 135, 60, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText(Model.Spells[5].ToString(), 135, 72, e.Graphics, pre, Model.FontMenu, pal);
                        if (cursorImages != null)
                            e.Graphics.DrawImage(cursorImages[0], 4, 23);
                    }
                    else if (previewType.SelectedIndex == 6) // Overworld - switch
                    {
                        if (allyImages != null)
                        {
                            e.Graphics.DrawImage(allyImages[1], 148 - (allyImages[1].Width / 2), 63);
                            e.Graphics.DrawImage(allyImages[3], 148 - (allyImages[3].Width / 2), 120);
                        }
                        //
                        Do.DrawText(Model.Characters[1].ToString(), 159, 60, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText(Model.MenuTexts[31].ToString(), 159, 72, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText(Model.MenuTexts[12].ToString(), 159, 84, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText("30          ", 191, 72, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText("211/211     ", 183, 84, e.Graphics, pre, Model.FontMenu, pal);
                        //
                        Do.DrawText(Model.Characters[4].ToString(), 159, 108, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText(Model.MenuTexts[31].ToString(), 159, 120, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText(Model.MenuTexts[12].ToString(), 159, 132, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText("30          ", 191, 120, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText("199/199     ", 183, 132, e.Graphics, pre, Model.FontMenu, pal);
                        //
                        Do.DrawText(Model.MenuTexts[14].ToString(), 15, 156, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText("9999", 87, 168, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText(Model.MenuTexts[20].ToString(), 143, 168, e.Graphics, pre, Model.FontMenu, pal);
                        Do.DrawText(Model.MenuTexts[21].ToString(), 151, 180, e.Graphics, pre, Model.FontMenu, pal);
                        if (cursorImages != null)
                            e.Graphics.DrawImage(cursorImages[0], 4, 71);
                    }
                    break;
                case 4: // Overworld - equip
                    if (allyImages != null)
                    {
                        e.Graphics.DrawImage(allyImages[0], 16 - (allyImages[0].Width / 2), 17);
                        e.Graphics.DrawImage(allyImages[2], 16 - (allyImages[2].Width / 2), 55);
                        e.Graphics.DrawImage(allyImages[4], 16 - (allyImages[4].Width / 2), 111);
                    }
                    Do.DrawText(Model.Items[33].ToString(), 23, 12, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText(Model.Items[69].ToString(), 23, 24, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText(Model.Items[81].ToString(), 23, 36, e.Graphics, pre, Model.FontMenu, pal);
                    //
                    Do.DrawText(Model.Items[30].ToString(), 23, 60, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText(Model.Items[67].ToString(), 23, 72, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText(Model.Items[94].ToString(), 23, 84, e.Graphics, pre, Model.FontMenu, pal);
                    //
                    Do.DrawText(Model.Items[31].ToString(), 23, 108, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText(Model.Items[66].ToString(), 23, 120, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText(Model.Items[90].ToString(), 23, 132, e.Graphics, pre, Model.FontMenu, pal);
                    //
                    if (cursorImages != null)
                    {
                        e.Graphics.DrawImage(cursorImages[0], 4, 13);
                        e.Graphics.DrawImage(cursorImages[1], 232, 191);
                        e.Graphics.DrawImage(cursorImages[4], 60, 141);
                    }
                    break;
                case 5: // Overworld - special item
                    if (cursorImages != null)
                        e.Graphics.DrawImage(cursorImages[0], 0, 49);
                    break;
                case 7: // Shop
                    Do.DrawText(Model.MenuTexts[76].ToString(), 23, 12, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText(Model.MenuTexts[77].ToString(), 23, 24, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText(Model.MenuTexts[78].ToString(), 23, 36, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText(Model.MenuTexts[0].ToString(), 23, 48, e.Graphics, pre, Model.FontMenu, pal);
                    //
                    Do.DrawText(Model.MenuTexts[27].ToString(), 23, 84, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText(Model.MenuTexts[32].ToString(), 23, 192, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText("999", 87, 84, e.Graphics, pre, Model.FontMenu, pal);
                    e.Graphics.DrawImage(cursorImages[0], 4, 13);
                    break;
                case 8: // Shop - Buy
                    Do.DrawText(Model.MenuTexts[76].ToString(), 15, 12, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText(Model.MenuTexts[80].ToString(), 15, 72, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText("999", 95, 72, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText(Model.MenuTexts[27].ToString(), 15, 96, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText("999", 95, 96, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText(Model.MenuTexts[79].ToString(), 15, 108, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText("99", 103, 108, e.Graphics, pre, Model.FontMenu, pal);
                    e.Graphics.DrawImage(cursorImages[0], 116, 13);
                    break;
                case 9: // Shop - Sell Items
                    Do.DrawText(Model.MenuTexts[77].ToString(), 15, 12, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText(Model.MenuTexts[80].ToString(), 15, 72, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText("999", 95, 72, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText(Model.MenuTexts[27].ToString(), 15, 96, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText("999", 95, 96, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText(Model.MenuTexts[79].ToString(), 15, 108, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText("99", 103, 108, e.Graphics, pre, Model.FontMenu, pal);
                    e.Graphics.DrawImage(cursorImages[0], 116, 13);
                    break;
                case 10: // Shop - Sell Weapons
                    Do.DrawText(Model.MenuTexts[78].ToString(), 15, 12, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText(Model.MenuTexts[80].ToString(), 15, 72, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText("999", 95, 72, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText(Model.MenuTexts[27].ToString(), 15, 96, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText("999", 95, 96, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText(Model.MenuTexts[79].ToString(), 15, 108, e.Graphics, pre, Model.FontMenu, pal);
                    Do.DrawText("99", 103, 108, e.Graphics, pre, Model.FontMenu, pal);
                    e.Graphics.DrawImage(cursorImages[0], 116, 13);
                    break;
            }
        }
        private void previewType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            SetBackgroundImage();
            SetPreviewImage();
        }
        private void openPalettesFrame_Click(object sender, EventArgs e)
        {
            if (framePaletteEditor == null)
                LoadFramePaletteEditor();
            framePaletteEditor.Show();
        }
        private void openGraphicsFrame_Click(object sender, EventArgs e)
        {
            if (frameGraphicEditor == null)
                LoadFrameGraphicEditor();
            frameGraphicEditor.Show();
        }
        private void openPalettesBG_Click(object sender, EventArgs e)
        {
            if (bgPaletteEditor == null)
                LoadBGPaletteEditor();
            bgPaletteEditor.Show();
        }
        private void shopBGPaletteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (shopBGPaletteEditor == null)
                LoadShopBGPaletteEditor();
            shopBGPaletteEditor.Show();
        }
        private void openGraphicsBG_Click(object sender, EventArgs e)
        {
            if (bgGraphicEditor == null)
                LoadBGGraphicEditor();
            bgGraphicEditor.Show();
        }
        private void openPaletteCursors_Click(object sender, EventArgs e)
        {
            if (cursorsPaletteEditor == null)
                LoadCursorsPaletteEditor();
            cursorsPaletteEditor.Show();
        }
        private void openGraphicsCursors_Click(object sender, EventArgs e)
        {
            if (cursorsGraphicEditor == null)
                LoadCursorsGraphicEditor();
            cursorsGraphicEditor.Show();
        }
        private void editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            ((Form)sender).Hide();
        }
        private void saveImageAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (contextMenuStrip1.SourceControl == pictureBoxFrame)
                Do.Export(frameImage, "menuFrame.png");
            else if (contextMenuStrip1.SourceControl == pictureBoxBG)
                Do.Export(bgImage, "menuBG.png");
            else if (contextMenuStrip1.SourceControl == pictureBoxPreview)
                Do.Export(previewImage, "menuPreview.png");
        }
        private void importImageToolStripMenuItem_Click(object sender, EventArgs e)
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
            if (contextMenuStrip1.SourceControl == pictureBoxBG || sender == importBackgroundToolStripMenuItem)
                ImportBackground(import);
            else if (contextMenuStrip1.SourceControl == pictureBoxFrame || sender == importFrameToolStripMenuItem)
                ImportFrame(import);
        }
        #endregion
    }
}
