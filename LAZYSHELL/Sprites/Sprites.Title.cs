using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Text;

namespace LAZYSHELL
{
    public partial class Sprites
    {
        private TitlePalettes titlePalettes;
        private TitleTileset titleTileSet;
        private TitlePalettes titleSpritePalettes;

        private Bitmap
            titleL1Image,
            titleL2Image,
            titleLogoImage,
            titleSpriteImage,
            titlePaletteImage,
            titleSpritePaletteImage;
        private int[]
            titleL1Pixels,
            titleL2Pixels,
            titleLogoPixels,
            titleSpritePixels,
            titlePalettePixels,
            titleSpritePalettePixels;

        private void InitializeTitleEditor()
        {
            model.TitleData = model.Decompress(0x3F216F, 0xDA60);

            titlePalettes = new TitlePalettes(BitManager.GetByteArray(model.Data, 0x3F0088, 0x100));
            titleTileSet = new TitleTileset(titlePalettes, model);
            titleSpritePalettes = new TitlePalettes(BitManager.GetByteArray(model.Data, 0x3F0188, 0xA0));

            SetTitleL1Image();
            SetTitleL2Image();
            SetTitleLogoImage();
            SetTitleSpriteImage();
            pictureBoxTitle.Invalidate();
            SetTitlePaletteImage();
            SetTitleSpritePaletteImage();

            GC.Collect();
        }

        // set images
        private void SetTitleL1Image()
        {
            titleL1Pixels = titleTileSet.GetTilesetPixelArray(titleTileSet.TileSetLayers[0]);
            titleL1Image = new Bitmap(Drawing.PixelArrayToImage(titleL1Pixels, 256, 512));
            pictureBoxTitleL1.Invalidate();
        }
        private void SetTitleL2Image()
        {
            titleL2Pixels = titleTileSet.GetTilesetPixelArray(titleTileSet.TileSetLayers[1]);
            titleL2Image = new Bitmap(Drawing.PixelArrayToImage(titleL2Pixels, 256, 512));
            pictureBoxTitleL2.Invalidate();
        }
        private void SetTitleLogoImage()
        {
            titleLogoPixels = titleTileSet.GetTilesetPixelArray(titleTileSet.LogoTileset);
            titleLogoImage = new Bitmap(Drawing.PixelArrayToImage(titleLogoPixels, 256, 96));
            pictureBoxTitleLogo.Invalidate();
        }
        private void SetTitleSpriteImage()
        {
            titleSpritePixels = titleTileSet.GetSpriteGraphics(titleSpritePalettes.GetTitlePalette(0));
            titleSpriteImage = new Bitmap(Drawing.PixelArrayToImage(titleSpritePixels, 128, 304));
            pictureBoxTitleExor.Invalidate();
        }
        private void SetTitlePaletteImage()
        {
            titlePalettePixels = titlePalettes.GetPalettePixels();
            titlePaletteImage = new Bitmap(Drawing.PixelArrayToImage(titlePalettePixels, 256, 128));
            pictureBoxTitlePalettes.Invalidate();
        }
        private void SetTitleSpritePaletteImage()
        {
            titleSpritePalettePixels = titleSpritePalettes.GetPalettePixels();
            titleSpritePaletteImage = new Bitmap(Drawing.PixelArrayToImage(titleSpritePalettePixels, 256, 80));
            pictureBoxTitleSpritePalettes.Invalidate();
        }

        // import/export
        private void ExportTitleLogo()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.FileName = "titleLogo.bin";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            byte[] graphicBlock = BitManager.GetByteArray(model.TitleData, 0xBEA0, 0x1BC0);

            FileStream fs;
            BinaryWriter bw;
            try
            {
                // Create the file to store the level data
                fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.ReadWrite);
                bw = new BinaryWriter(fs);
                bw.Write(graphicBlock);
                bw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem exporting the graphic block.");
            }
        }
        private void ImportTitleLogo(string path)
        {
            if (path == null) return;

            Bitmap import = new Bitmap(Image.FromFile(path));
            if (import.Width != 256 || import.Height != 96)
            {
                MessageBox.Show(
                    "The dimensions of the imported image must be 256 x 96.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            byte[] graphics = new byte[0x3000];
            byte[] gameTitle = new byte[0x1C00];
            byte[] gameCopyright = new byte[0x1400];

            int[] palette = titlePalettes.GetTitlePalette(3);
            Drawing.PixelArrayTo4bpp(
                Drawing.ImageToPixelArray(import, new Size(256, 56), new Rectangle(0, 0, 256, 56)), gameTitle,
                new Size(256 / 8, 56 / 8), palette);
            palette = titlePalettes.GetTitlePalette(6);
            Drawing.PixelArrayTo4bpp(
                Drawing.ImageToPixelArray(import, new Size(256, 56), new Rectangle(0, 56, 256, 40)), gameCopyright,
                new Size(256 / 8, 40 / 8), palette);

            Buffer.BlockCopy(gameTitle, 0, graphics, 0, 0x1C00);
            Buffer.BlockCopy(gameCopyright, 0, graphics, 0x1C00, 0x1400);

            byte[] tileset = new byte[0x300];
            byte[] tilesetTitle = new byte[0x300];
            byte[] tilesetCopyright = new byte[0x300];
            byte[] temp = new byte[graphics.Length]; graphics.CopyTo(temp, 0);
            Drawing.CopyToTileset(graphics, tilesetTitle, palette, 3, true, 0x20, 2, new Size(256, 96), 2);
            Drawing.CopyToTileset(temp, tilesetCopyright, palette, 6, true, 0x20, 2, new Size(256, 96), 2);

            Buffer.BlockCopy(tilesetTitle, 0, tileset, 0, 0x300);
            Buffer.BlockCopy(tilesetCopyright, 0x1C0, tileset, 0x1C0, 0x140);

            Buffer.BlockCopy(tileset, 0, model.TitleData, 0xBBE0, 0x300);
            Buffer.BlockCopy(graphics, 0, model.TitleData, 0xBEE0, 0x1B80);

            titleTileSet = new TitleTileset(titlePalettes, model);

            SetTitleLogoImage();
            pictureBoxTitle.Invalidate();
        }
        private void ImportTitle()
        {
            tabControl2.SelectedIndex = 1;
            string path = SelectFile("Select the image to import into L1", "Image files (*.bmp,*.png,*.gif,*.jpg)|*.bmp;*.png;*.gif;*.jpg|All files (*.*)|*.*", 2);            
            if (path == null) return;
            Bitmap importL1 = new Bitmap(Image.FromFile(path));
            if (importL1.Width != 256 || importL1.Height != 512)
            {
                MessageBox.Show(
                    "The dimensions of the imported image must be 256 x 512.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int[] importL1pixels = Drawing.ImageToPixelArray(importL1, new Size(256, 512), new Rectangle(0, 0, 256, 512));
            path = null;

            tabControl2.SelectedIndex = 2;
            path = SelectFile("Select the image to import into L2", "Image files (*.bmp,*.png,*.gif,*.jpg)|*.bmp;*.png;*.gif;*.jpg|All files (*.*)|*.*", 2);
            if (path == null) return;
            Bitmap importL2 = new Bitmap(Image.FromFile(path));
            if (importL2.Width != 256 || importL2.Height != 512)
            {
                MessageBox.Show(
                    "The dimensions of the imported image must be 256 x 512.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int[] importL2pixels = Drawing.ImageToPixelArray(importL2, new Size(256, 512), new Rectangle(0, 0, 256, 512));

            // now combine the two into one pixel array
            int[] importPixels = new int[256 * 1024];
            for (int y = 0; y < 512; y++)
            {
                for (int x = 0; x < 256; x++)
                {
                    importPixels[y * 256 + x] = importL1pixels[y * 256 + x];
                    importPixels[(y + 512) * 256 + x] = importL2pixels[y * 256 + x];
                }
            }

            byte[] graphics = new byte[0x20000];
            int[][] palettes = new int[8][];
            for (int i = 0; i < 8; i++)
                palettes[i] = titlePalettes.GetTitlePalette(i);
            int[] paletteIndexes = Drawing.PixelArrayTo4bpp(
                importPixels, graphics,
                new Size(256 / 8, 1024 / 8), palettes);

            byte[] tileset = new byte[0x2000];
            Drawing.CopyToTileset(graphics, tileset, palettes, paletteIndexes, false, 0x20, 2, new Size(256, 1024), 0);

            Buffer.BlockCopy(tileset, 0, model.TitleData, 0, 0x2000);
            Buffer.BlockCopy(graphics, 0, model.TitleData, 0x6C00, 0x4FE0);

            titleTileSet = new TitleTileset(titlePalettes, model);

            SetTitleL1Image();
            SetTitleL2Image();
            pictureBoxTitle.Invalidate();
        }
        private Tile8x8 Draw4bppTile8x8(byte tile, byte temp, byte[] gfx, int[] pal, byte palIndex)
        {
            int offset = tile * 0x20;

            Tile8x8 tempTile;

            if (tile != 0xFF)
            {
                if (offset + 0x20 > gfx.Length)
                    tempTile = new Tile8x8(tile, new byte[0x20], 0, pal, false, false, false, false);
                else
                    tempTile = new Tile8x8(tile, gfx, offset, pal, false, false, false, false);
            }
            else
                tempTile = new Tile8x8(tile, new byte[0x20], 0, pal, false, false, false, false);

            tempTile.PaletteSetIndex = palIndex;
            return tempTile;
        }

        // assembly
        private void AssembleTitle()
        {
            // Palette set
            titlePalettes.Assemble();
            BitManager.SetByteArray(data, 0x3F0088, titlePalettes.PaletteSet, 0, 0x100);

            // Tilesets
            byte[] compressed = new byte[0xDA60];
            int totalSize = 0;
            int size = 0;

            size = model.Compress(model.TitleData, compressed);
            totalSize += size + 1;
            if (totalSize > 0x7E91)
            {
                MessageBox.Show(
                    "Recompressed data exceeds allotted ROM space by " + (totalSize - 0x7E91).ToString() + " bytes.\nMain title was not saved.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                BitManager.SetByteArray(data, 0x3F216F, compressed, 0, size - 1);
            }
        }

        private void pictureBoxTitle_Paint(object sender, PaintEventArgs e)
        {
            if (titleL1Image != null && titleL2Image != null && titleLogoImage != null)
            {
                Color bgcolor = Color.FromArgb(titlePalettes.PaletteColorRed[0], titlePalettes.PaletteColorGreen[0], titlePalettes.PaletteColorBlue[0]);
                e.Graphics.FillRectangle(new SolidBrush(bgcolor), new Rectangle(new Point(0, 0), pictureBoxTitle.Size));
                e.Graphics.DrawImage(titleL2Image, 0, 0);
                e.Graphics.DrawImage(titleL1Image, 0, 0);

                Rectangle upperPart = new Rectangle(0, 0, 256, 72);
                Rectangle lowerPart = new Rectangle(0, 72, 256, 24);
                e.Graphics.DrawImage(titleLogoImage.Clone(upperPart, PixelFormat.DontCare), 0, 208);
                e.Graphics.DrawImage(titleLogoImage.Clone(lowerPart, PixelFormat.DontCare), 0, 368);
            }
        }
        private void pictureBoxTitleL1_Paint(object sender, PaintEventArgs e)
        {
            if (titleL1Image != null)
            {
                e.Graphics.DrawImage(titleL1Image, 0, 0);
            }
            overlay.DrawSelectionBox(e.Graphics, overlay.TileSetDragStop, overlay.TileSetDragStart, 1);
        }
        private void pictureBoxTitleL2_Paint(object sender, PaintEventArgs e)
        {
            if (titleL2Image != null)
            {
                e.Graphics.DrawImage(titleL2Image, 0, 0);
            }
            overlay.DrawSelectionBox(e.Graphics, overlay.TileSetDragStop, overlay.TileSetDragStart, 1);
        }
        private void pictureBoxTitleLogo_Paint(object sender, PaintEventArgs e)
        {
            if (titleLogoImage != null)
            {
                e.Graphics.DrawImage(titleLogoImage, 0, 0);
            }
            overlay.DrawSelectionBox(e.Graphics, overlay.TileSetDragStop, overlay.TileSetDragStart, 1);
        }
        private void pictureBoxTitleExor_Paint(object sender, PaintEventArgs e)
        {
            if (titleSpriteImage != null)
            {
                e.Graphics.DrawImage(titleSpriteImage, 0, 0);
            }
        }
        private void pictureBoxTitleSpritePalettes_Paint(object sender, PaintEventArgs e)
        {
            if (titleSpritePaletteImage != null)
            {
                e.Graphics.DrawImage(titleSpritePaletteImage, 0, 0);
            }
        }
        private void pictureBoxTitlePalettes_Paint(object sender, PaintEventArgs e)
        {
            if (titlePaletteImage != null)
            {
                e.Graphics.DrawImage(titlePaletteImage, 0, 0);
            }
        }
    }
}
