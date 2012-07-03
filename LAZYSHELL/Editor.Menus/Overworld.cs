using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public partial class Overworld : Form
    {
        #region Variables
        private long checksum { get { return menusEditor.Checksum; } set { menusEditor.Checksum = value; } }
        // main
        private delegate void Function();
        private PaletteSet framePaletteSet { get { return Model.MenuFramePalette; } set { Model.MenuFramePalette = value; } }
        private PaletteSet bgPaletteSet { get { return Model.MenuBGPalette; } set { Model.MenuBGPalette = value; } }
        private PaletteSet cursorPaletteSet { get { return Model.CursorPaletteSet; } set { Model.CursorPaletteSet = value; } }
        private Bitmap bgImage;
        private Bitmap frameImage;
        private Bitmap previewImage;
        private Bitmap[] allyImages;
        private Bitmap[] cursorImages;
        // editors
        private MenusEditor menusEditor;
        private PaletteEditor framePaletteEditor;
        private GraphicEditor frameGraphicEditor;
        private PaletteEditor bgPaletteEditor;
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
            //
            LoadFramePaletteEditor();
            LoadFrameGraphicEditor();
            LoadBGPaletteEditor();
            LoadBGGraphicEditor();
            LoadCursorsPaletteEditor();
            LoadCursorsGraphicEditor();
        }
        public void Reload(MenusEditor menusEditor)
        {
            SetAllyImages();
            SetFrameImage();
            SetBackgroundImage();
            SetCursorImages();
            SetPreviewImage();
            //
            LoadFramePaletteEditor();
            LoadFrameGraphicEditor();
            LoadBGPaletteEditor();
            LoadBGGraphicEditor();
            LoadCursorsPaletteEditor();
            LoadCursorsGraphicEditor();
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
                int[] pixels = Model.NPCProperties[i].CreateImage(2, false, i);
                int height = Model.NPCProperties[i].ImageHeight;
                int width = Model.NPCProperties[i].ImageWidth;
                allyImages[i] = Do.PixelsToImage(pixels, width, height);
            }
        }
        private void SetFrameImage()
        {
            frameImage = Do.PixelsToImage(
                Do.DrawMenuFrame(new Size(5, 6), Model.MenuFrameGraphics, Model.MenuFramePalette.Palette), 40, 48);
            pictureBoxFrame.Invalidate();
        }
        private void SetBackgroundImage()
        {
            bgImage = Model.MenuBG;
            pictureBoxBG.Invalidate();
        }
        private void SetPreviewImage()
        {
            int[] bgPixels = Do.ImageToPixels(Model.MenuBG);
            int[] frameAllyPixels = Do.DrawMenuFrame(new Size(15, 6), Model.MenuFrameGraphics, Model.MenuFramePalette.Palette);
            int[] frameMenuPixels = Do.DrawMenuFrame(new Size(14, 15), Model.MenuFrameGraphics, Model.MenuFramePalette.Palette);
            int[] frameCoinsPixels = Do.DrawMenuFrame(new Size(12, 11), Model.MenuFrameGraphics, Model.MenuFramePalette.Palette);
            Do.PixelsToPixels(frameAllyPixels, bgPixels, 256, new Rectangle(8, 7, 15 * 8, 6 * 8), true, true);
            Do.PixelsToPixels(frameAllyPixels, bgPixels, 256, new Rectangle(8, 55, 15 * 8, 6 * 8), true, true);
            Do.PixelsToPixels(frameAllyPixels, bgPixels, 256, new Rectangle(8, 103, 15 * 8, 6 * 8), true, true);
            Do.PixelsToPixels(frameMenuPixels, bgPixels, 256, new Rectangle(136, 7, 14 * 8, 15 * 8), true, true);
            Do.PixelsToPixels(frameCoinsPixels, bgPixels, 256, new Rectangle(144, 127, 12 * 8, 11 * 8), true, true);
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
            SetBackgroundImage();
            SetPreviewImage();
            LoadBGGraphicEditor();
            checksum--;   // b/c switching colors won't modify checksum
        }
        private void BGGraphicUpdate()
        {
            SetBackgroundImage();
            SetPreviewImage();
            checksum--;   // b/c switching colors won't modify checksum
        }
        private void CursorsPaletteUpdate()
        {
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
                Model.MenuFramePalette.Reds[i] = Color.FromArgb(palette[i]).R;
                Model.MenuFramePalette.Greens[i] = Color.FromArgb(palette[i]).G;
                Model.MenuFramePalette.Blues[i] = Color.FromArgb(palette[i]).B;
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
            Model.MenuFramePalette.Assemble();
            Model.MenuBGPalette.Assemble();
            Model.CursorPaletteSet.Assemble(Model.MenuPalettes, 0x100);
            byte[] compressed = new byte[0x200];
            int totalSize = Comp.Compress(Model.MenuPalettes, compressed);
            if (totalSize > 0x12E)
                MessageBox.Show("Not enough space for compressed menu palettes. The total required space (" +
                    totalSize + " bytes) exceeds 302 bytes.\n\n" + "The menu palettes were not saved.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                Bits.SetByteArray(Model.Data, 0x3E2D54, compressed, 0, totalSize - 1);
            //
            compressed = new byte[0x2000];
            int size = Comp.Compress(Model.MenuBGGraphics, compressed);
            totalSize = size + 1;
            if (totalSize > 0x179E)
                MessageBox.Show("Not enough space for compressed background graphics. The total required space (" +
                    totalSize + " bytes) exceeds 6046 bytes.\n\n" + "The background graphics were not saved.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                Bits.SetByteArray(Model.Data, 0x3E0E69, compressed, 0, size - 1);
                Bits.SetByte(Model.Data, 0x3E0E69 - 1, 0x01);
            }
            //
            compressed = new byte[0x800];
            size = Comp.Compress(Model.MenuBGTileset, compressed);
            totalSize = size + 1;
            if (totalSize > 0x417)
                MessageBox.Show("Not enough space for compressed background tileset. The total required space (" +
                    totalSize + " bytes) exceeds 1047 bytes.\n\n" + "The background tileset was not saved.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                Bits.SetByteArray(Model.Data, 0x3E286A, compressed, 0, size - 1);
                Bits.SetByte(Model.Data, 0x3E286A - 1, 0x01);
            }
            //
            compressed = new byte[0x200];
            size = Comp.Compress(Model.MenuFrameGraphics, compressed);
            totalSize = size + 1;
            if (totalSize > 0x97)
                MessageBox.Show("Not enough space for compressed frame graphics. The total required space (" +
                    totalSize + " bytes) exceeds 151 bytes.\n\n" + "The background graphics were not saved.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                Bits.SetByteArray(Model.Data, 0x3E2607, compressed, 0, size - 1);
                Bits.SetByte(Model.Data, 0x3E2607 - 1, 0x01);
            }
            //
            checksum = Do.GenerateChecksum(Model.MenuFramePalette, Model.MenuFrameGraphics, Model.MenuBGPalette, Model.MenuBGGraphics);
        }
        public new void Close()
        {
            framePaletteEditor.Close();
            frameGraphicEditor.Close();
            bgPaletteEditor.Close();
            bgGraphicEditor.Close();
            cursorsGraphicEditor.Close();
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
            if (allyImages != null)
            {
                e.Graphics.DrawImage(allyImages[0], 28 - (allyImages[0].Width / 2), 17);
                e.Graphics.DrawImage(allyImages[2], 28 - (allyImages[2].Width / 2), 55);
                e.Graphics.DrawImage(allyImages[4], 28 - (allyImages[4].Width / 2), 111);
                //e.Graphics.DrawImage(allyImages[1], 28 - (allyImages[1].Width / 2), 0);
                //e.Graphics.DrawImage(allyImages[3], 28 - (allyImages[3].Width / 2), 0);
            }
            //
            int[] pal = Model.FontPaletteMenu.Palette;
            MenuTextPreview pre = new MenuTextPreview();
            //
            Do.DrawText("Mario       ", 39, 12, e.Graphics, pre, Model.FontMenu, pal);
            Do.DrawText("LV          ", 39, 24, e.Graphics, pre, Model.FontMenu, pal);
            Do.DrawText("HP          ", 39, 36, e.Graphics, pre, Model.FontMenu, pal);
            Do.DrawText("30          ", 71, 24, e.Graphics, pre, Model.FontMenu, pal);
            Do.DrawText("212/212     ", 63, 36, e.Graphics, pre, Model.FontMenu, pal);
            //
            Do.DrawText("Bowser      ", 39, 60, e.Graphics, pre, Model.FontMenu, pal);
            Do.DrawText("LV          ", 39, 72, e.Graphics, pre, Model.FontMenu, pal);
            Do.DrawText("HP          ", 39, 84, e.Graphics, pre, Model.FontMenu, pal);
            Do.DrawText("30          ", 71, 72, e.Graphics, pre, Model.FontMenu, pal);
            Do.DrawText("240/240     ", 63, 84, e.Graphics, pre, Model.FontMenu, pal);
            //
            Do.DrawText("Geno        ", 39, 108, e.Graphics, pre, Model.FontMenu, pal);
            Do.DrawText("LV          ", 39, 120, e.Graphics, pre, Model.FontMenu, pal);
            Do.DrawText("HP          ", 39, 132, e.Graphics, pre, Model.FontMenu, pal);
            Do.DrawText("30          ", 71, 120, e.Graphics, pre, Model.FontMenu, pal);
            Do.DrawText("195/195     ", 63, 132, e.Graphics, pre, Model.FontMenu, pal);
            //
            Do.DrawText("Item        ", 143, 12, e.Graphics, pre, Model.FontMenu, pal);
            Do.DrawText("Status      ", 143, 24, e.Graphics, pre, Model.FontMenu, pal);
            Do.DrawText("Special     ", 143, 36, e.Graphics, pre, Model.FontMenu, pal);
            Do.DrawText("Equip       ", 143, 48, e.Graphics, pre, Model.FontMenu, pal);
            Do.DrawText("Special Item", 143, 60, e.Graphics, pre, Model.FontMenu, pal);
            Do.DrawText("Map         ", 143, 72, e.Graphics, pre, Model.FontMenu, pal);
            Do.DrawText("Star Pieces ", 143, 84, e.Graphics, pre, Model.FontMenu, pal);
            Do.DrawText("Switch      ", 143, 96, e.Graphics, pre, Model.FontMenu, pal);
            Do.DrawText("Game        ", 143, 108, e.Graphics, pre, Model.FontMenu, pal);
            //
            Do.DrawText("Flowers     ", 151, 132, e.Graphics, pre, Model.FontMenu, pal);
            Do.DrawText("99/99       ", 191, 145, e.Graphics, pre, Model.FontMenu, pal);
            Do.DrawText("Coins       ", 151, 156, e.Graphics, pre, Model.FontMenu, pal);
            Do.DrawText("999         ", 207, 169, e.Graphics, pre, Model.FontMenu, pal);
            Do.DrawText("Frog Coins  ", 151, 180, e.Graphics, pre, Model.FontMenu, pal);
            Do.DrawText("999         ", 207, 193, e.Graphics, pre, Model.FontMenu, pal);
            //
            if (cursorImages != null)
            {
                e.Graphics.DrawImage(cursorImages[0], 124, 13);
                e.Graphics.DrawImage(cursorImages[1], 32, 160);
                e.Graphics.DrawImage(cursorImages[2], 48, 160);
                e.Graphics.DrawImage(cursorImages[3], 64, 160);
                e.Graphics.DrawImage(cursorImages[4], 80, 160);
            }
        }
        private void openPalettesFrame_Click(object sender, EventArgs e)
        {
            framePaletteEditor.Show();
        }
        private void openGraphicsFrame_Click(object sender, EventArgs e)
        {
            frameGraphicEditor.Show();
        }
        private void openPalettesBG_Click(object sender, EventArgs e)
        {
            bgPaletteEditor.Show();
        }
        private void openGraphicsBG_Click(object sender, EventArgs e)
        {
            bgGraphicEditor.Show();
        }
        private void openPaletteCursors_Click(object sender, EventArgs e)
        {
            cursorsPaletteEditor.Show();
        }
        private void openGraphicsCursors_Click(object sender, EventArgs e)
        {
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
