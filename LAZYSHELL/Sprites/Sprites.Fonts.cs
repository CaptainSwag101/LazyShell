using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public partial class Sprites
    {
        #region Variables

        private bool updatingFonts;

        // font palette variables
        private int currentFontColor = 0;
        private int[] paletteRedDialogue = new int[16]; public int[] PaletteRedDialogue { get { return paletteRedDialogue; } set { paletteRedDialogue = value; } }
        private int[] paletteGreenDialogue = new int[16]; public int[] PaletteGreenDialogue { get { return paletteGreenDialogue; } set { paletteGreenDialogue = value; } }
        private int[] paletteBlueDialogue = new int[16]; public int[] PaletteBlueDialogue { get { return paletteBlueDialogue; } set { paletteBlueDialogue = value; } }
        private int[] paletteRedMenu = new int[16]; public int[] PaletteRedMenu { get { return paletteRedMenu; } set { paletteRedMenu = value; } }
        private int[] paletteGreenMenu = new int[16]; public int[] PaletteGreenMenu { get { return paletteGreenMenu; } set { paletteGreenMenu = value; } }
        private int[] paletteBlueMenu = new int[16]; public int[] PaletteBlueMenu { get { return paletteBlueMenu; } set { paletteBlueMenu = value; } }

        // font character variables
        private int currentFontChar = 0;
        private int overFontChar = 0;
        private FontCharacter[] fontMenu;
        private FontCharacter[] fontDialogue;
        private FontCharacter[] fontDescription;
        private FontCharacter[] fontTriangle;
        private byte[] fontBuffer;
        private int zoom = 4;
        private int edit = 0;

        // new font table variables
        private FontFamily[] ff = FontFamily.Families;
        private FontStyle bold;
        private FontStyle italics;
        private FontStyle underline;
        [DllImport("gdi32.dll")]
        private static extern bool BitBlt(
        IntPtr hdcDest, // handle to destination DC
        int nXDest, // x-coord of destination upper-left corner
        int nYDest, // y-coord of destination upper-left corner
        int nWidth, // width of destination rectangle
        int nHeight, // height of destination rectangle
        IntPtr hdcSrc, // handle to source DC
        int nXSrc, // x-coordinate of source upper-left corner
        int nYSrc, // y-coordinate of source upper-left corner
        System.Int32 dwRop // raster operation code
        );
        private const Int32 SRCCOPY = 0xCC0020;
        private char[] textBoxChars = new char[]
            {
                ' ','!','“','”',' ',' ','‘','’',
                '(',')',' ',' ',',','-','.','/',
                '0','1','2','3','4','5','6','7',
                '8','9','~',' ',' ',' ',' ','?',
                '©','A','B','C','D','E','F','G',
                'H','I','J','K','L','M','N','O',
                'P','Q','R','S','T','U','V','W',
                'X','Y','Z',' ',' ',' ',' ',' ',
                ' ','a','b','c','d','e','f','g',
                'h','i','j','k','l','m','n','o',
                'p','q','r','s','t','u','v','w',
                'x','y','z',' ',' ',' ',' ',' ',
                ' ',' ',' ',' ',' ',' ',' ',' ',
                ' ',' ',' ',' ',' ',' ',':',';',
                '<','>',' ','#','+','×','%',' ',
                ' ',' ','*','\'','&',' ',' ',' ',

            };

        private Bitmap
            fontPaletteImage,
            fontTableImage,
            fontCharacterImage;

        private StringCollection currentKS;

        #endregion

        #region Methods

        // initialize properties
        private void InitializeFontEditor()
        {
            updatingFonts = true;

            fontType.SelectedIndex = 1;
            fontPalette.SelectedIndex = 0;

            InitializeFontPaletteColors();

            fontMenu = spriteModel.FontMenu;
            fontDialogue = spriteModel.FontDialogue;
            fontDescription = spriteModel.FontDescription;
            fontTriangle = spriteModel.FontTriangle;

            currentKS = settings.Keystrokes;

            InitializeFontColor();
            InitializeFonts();
            InitializeFontCharacter();
            InitializeNewFontTable();

            SetFontPaletteImage();
            SetFontTableImage();
            SetFontCharacterImage();

            updatingFonts = false;
        }

        private void InitializeFontPaletteColors()
        {
            double multiplier = 8; // 8;
            ushort color = 0;

            for (int i = 0; i < 16; i++) // 16 colors in palette
            {
                color = BitManager.GetShort(data, i * 2 + 0x3DFF00);

                paletteRedDialogue[i] = (byte)((color % 0x20) * multiplier);
                paletteGreenDialogue[i] = (byte)(((color >> 5) % 0x20) * multiplier);
                paletteBlueDialogue[i] = (byte)(((color >> 10) % 0x20) * multiplier);

                color = BitManager.GetShort(data, i * 2 + 0x3E2D55);

                paletteRedMenu[i] = (byte)((color % 0x20) * multiplier);
                paletteGreenMenu[i] = (byte)(((color >> 5) % 0x20) * multiplier);
                paletteBlueMenu[i] = (byte)(((color >> 10) % 0x20) * multiplier);
            }
        }
        private void InitializeFontColor()
        {
            updatingFonts = true;

            if (fontPalette.SelectedIndex == 0)
            {
                fontPaletteRedNum.Value = paletteRedDialogue[currentFontColor];
                fontPaletteGreenNum.Value = paletteGreenDialogue[currentFontColor];
                fontPaletteBlueNum.Value = paletteBlueDialogue[currentFontColor];
                fontPaletteRedBar.Value = paletteRedDialogue[currentFontColor];
                fontPaletteGreenBar.Value = paletteGreenDialogue[currentFontColor];
                fontPaletteBlueBar.Value = paletteBlueDialogue[currentFontColor];
                pictureBoxFontColor.BackColor = Color.FromArgb(
                    paletteRedDialogue[currentFontColor],
                    paletteGreenDialogue[currentFontColor],
                    paletteBlueDialogue[currentFontColor]);
            }
            else
            {
                fontPaletteRedNum.Value = paletteRedMenu[currentFontColor];
                fontPaletteGreenNum.Value = paletteGreenMenu[currentFontColor];
                fontPaletteBlueNum.Value = paletteBlueMenu[currentFontColor];
                fontPaletteRedBar.Value = paletteRedMenu[currentFontColor];
                fontPaletteGreenBar.Value = paletteGreenMenu[currentFontColor];
                fontPaletteBlueBar.Value = paletteBlueMenu[currentFontColor];
                pictureBoxFontColor.BackColor = Color.FromArgb(
                    paletteRedMenu[currentFontColor],
                    paletteGreenMenu[currentFontColor],
                    paletteBlueMenu[currentFontColor]);
            }

            updatingFonts = false;
        }
        private void InitializeFonts()
        {
            updatingFonts = true;

            switch (fontType.SelectedIndex)
            {
                case 0: fontWidth.Enabled = true; fontWidth.Maximum = 8; break;
                case 1: fontWidth.Enabled = true; fontWidth.Maximum = 16; break;
                case 2: fontWidth.Enabled = true; fontWidth.Maximum = 8; break;
                case 3: fontWidth.Enabled = false; break;
            }
            InitializeFontCharacter();

            updatingFonts = false;
        }
        private void InitializeFontCharacter()
        {
            updatingFonts = true;

            switch (fontType.SelectedIndex)
            {
                case 0:
                    charKeystroke.Text = currentKS[currentFontChar + 32];
                    fontWidth.Value = fontMenu[currentFontChar].Width;
                    break;
                case 1:
                    charKeystroke.Text = currentKS[currentFontChar + 32];
                    fontWidth.Value = fontDialogue[currentFontChar].Width;
                    break;
                case 2:
                    charKeystroke.Text = currentKS[currentFontChar + 32];
                    fontWidth.Value = fontDescription[currentFontChar].Width;
                    break;
            }

            updatingFonts = false;
        }
        private void InitializeNewFontTable()
        {
            fontTable.Visible = false;

            updatingFonts = true;

            fontTable.Controls.Clear();

            if (fontFamily.Items.Count == 0)
            {
                for (int x = 0; x < ff.Length; x++)
                {
                    fontFamily.Items.Add(ff[x].Name);
                    if (ff[x].Name == "Tahoma")
                        fontFamily.SelectedIndex = x;
                }
            }

            Size s = new Size(), u = new Size();
            Color bg, fg; ;
            switch (fontType.SelectedIndex)
            {
                case 0:
                    s.Width = 16; s.Height = 8; u.Width = 8; characterHeight.Value = u.Height = 12;
                    bg = Color.FromArgb(paletteRedMenu[3], paletteGreenMenu[3], paletteBlueMenu[3]);
                    fg = Color.FromArgb(paletteRedMenu[1], paletteGreenMenu[1], paletteBlueMenu[1]);
                    break;
                case 1:
                    s.Width = 8; s.Height = 16; u.Width = 16; characterHeight.Value = u.Height = 12;
                    bg = Color.FromArgb(paletteRedDialogue[3], paletteGreenDialogue[3], paletteBlueDialogue[3]);
                    fg = Color.FromArgb(paletteRedDialogue[1], paletteGreenDialogue[1], paletteBlueDialogue[1]);
                    break;
                case 2:
                    s.Width = 16; s.Height = 8; u.Width = 8; characterHeight.Value = u.Height = 8;
                    bg = Color.FromArgb(paletteRedMenu[3], paletteGreenMenu[3], paletteBlueMenu[3]);
                    fg = Color.FromArgb(paletteRedMenu[1], paletteGreenMenu[1], paletteBlueMenu[1]);
                    break;
                case 3:
                    return;
                default: goto case 1;
            }

            fontTable.BackColor = bg;
            fontTable.ForeColor = fg;
            RichTextBox rtb;
            for (int y = s.Height - 1; y >= 0; y--)
            {
                for (int x = 0; x < s.Width; x++)
                {
                    rtb = new RichTextBox();
                    rtb.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    rtb.Height = u.Height;
                    rtb.MaxLength = 1;
                    rtb.Multiline = false;
                    rtb.Size = new System.Drawing.Size(u.Width, u.Height);
                    rtb.TabIndex = y * s.Width + x;
                    rtb.Left = x * u.Width;
                    rtb.Top = y * u.Height - 2;
                    rtb.Text = textBoxChars[y * s.Width + x].ToString();
                    fontTable.Controls.Add(rtb);
                    rtb.BackColor = fontTable.BackColor;
                    rtb.ForeColor = fontTable.ForeColor;
                    rtb.BringToFront();
                    rtb.Enter += new EventHandler(rtb_Enter);
                }
            }
            fontTable.Height = s.Height * u.Height;

            updatingFonts = false;

            fontTable.Visible = true;
        }
        private void rtb_Enter(object sender, EventArgs e)
        {
            ((RichTextBox)sender).SelectAll();
        }

        // set images
        private void SetFontPaletteImage()
        {
            int[] palettePixels = new int[256 * 16];
            int[] paletteColors = GetFontPalette(fontPalette.SelectedIndex);

            for (int i = 0; i < 16; i++) // 16 palette blocks wide
            {
                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 16; x++)
                        palettePixels[x + (i * 16) + (y * 256)] = paletteColors[i];
                }
            }
            for (int y = 0; y < 16; y += 16)  // draw the horizontal gridlines
            {
                for (int x = 0; x < 256; x++)
                    palettePixels[y * 256 + x] = Color.Black.ToArgb();
                if (y == 0) y--;
            }
            for (int x = 0; x < 256; x += 16) // draw the vertical gridlines
            {
                for (int y = 0; y < 16; y++)
                    palettePixels[y * 256 + x] = Color.Black.ToArgb();
                if (x == 0) x--;
            }
            fontPaletteImage = new Bitmap(Drawing.PixelArrayToImage(palettePixels, 256, 16));
            pictureBoxFontPalette.Invalidate();
        }
        private void SetFontTableImage()
        {
            int[] pixels = new int[1], palette = new int[1];
            int width = 0, height = 0, hspan = 0, vspan = 0;
            switch (fontType.SelectedIndex)
            {
                case 0:
                    width = 128; height = 96; hspan = 16; vspan = 8;
                    pixels = new int[128 * height]; goto default;
                case 1:
                    width = 128; height = 192; hspan = 8; vspan = 16;
                    pixels = new int[128 * height]; goto default;
                case 2:
                    width = 128; height = 64; hspan = 16; vspan = 8;
                    pixels = new int[128 * height]; goto default;
                case 3:
                    width = 112; height = 32;
                    pixels = new int[112 * height];
                    palette = GetFontPalette(0);
                    for (int x = 0; x < 7; x++) // left-right triangles
                        CopyOverCharTile(fontTriangle[x].GetCharacterPixels(palette), pixels, 112, x * 2, 0);
                    for (int x = 0; x < 7; x++) // up-down triangles
                        CopyOverCharTile(fontTriangle[x + 7].GetCharacterPixels(palette), pixels, 112, x, 2);
                    break;
                default:
                    palette = GetFontPalette(fontPalette.SelectedIndex);
                    for (int y = 0; y < vspan; y++)
                    {
                        for (int x = 0; x < hspan; x++)
                        {
                            switch (fontType.SelectedIndex)
                            {
                                case 0: CopyOverCharTile(fontMenu[y * hspan + x].GetCharacterPixels(palette), pixels, 128, x, y); break;
                                case 1: CopyOverCharTile(fontDialogue[y * hspan + x].GetCharacterPixels(palette), pixels, 128, x, y); break;
                                case 2: CopyOverCharTile(fontDescription[y * hspan + x].GetCharacterPixels(palette), pixels, 128, x, y); break;
                            }
                        }
                    }
                    break;
            }

            pictureBoxFont.Width = width;
            pictureBoxFont.Height = height;
            fontTableImage = new Bitmap(Drawing.PixelArrayToImage(pixels, width, height));
            if (fontType.SelectedIndex == 3)
                pictureBoxFont.BackColor = Color.FromArgb(palette[0]);
            else
                pictureBoxFont.BackColor = Color.FromArgb(palette[3]);
            pictureBoxFont.Invalidate();
        }
        private void SetFontCharacterImage()
        {
            int width = 0, height = 0;
            int[] temp, pixels;
            int[] palette = GetFontPalette(fontPalette.SelectedIndex);
            switch (fontType.SelectedIndex)
            {
                case 0:
                    width = 8; height = 12;
                    temp = fontMenu[currentFontChar].GetCharacterPixels(palette);
                    break;
                case 1:
                    width = 16; height = 12;
                    temp = fontDialogue[currentFontChar].GetCharacterPixels(palette);
                    break;
                case 2:
                    width = height = 8;
                    temp = fontDescription[currentFontChar].GetCharacterPixels(palette);
                    break;
                default:
                    width = currentFontChar < 7 ? 8 : 16;
                    height = currentFontChar < 7 ? 16 : 8;
                    palette = GetFontPalette(0);
                    temp = fontTriangle[currentFontChar].GetCharacterPixels(palette);
                    break;
            }
            pixels = new int[width * height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                    pixels[y * width + x] = temp[y * width + x];
            }

            if (fontType.SelectedIndex == 3)
                pictureBoxFontEditor.BackColor = Color.FromArgb(palette[0]);
            else
                pictureBoxFontEditor.BackColor = Color.FromArgb(palette[3]);
            fontCharacterImage = new Bitmap(Drawing.PixelArrayToImage(pixels, width, height));
            pictureBoxFontEditor.Width = width * zoom;
            pictureBoxFontEditor.Height = height * zoom;
            pictureBoxFontEditor.Invalidate();
        }

        // drawing
        private int[] GetFontPalette(int type)
        {
            int[] temp = new int[16];

            if (type == 0)
            {
                for (int i = 0; i < 16; i++)
                    temp[i] = Color.FromArgb(255, paletteRedDialogue[i], paletteGreenDialogue[i], paletteBlueDialogue[i]).ToArgb();
            }
            else
            {
                for (int i = 0; i < 16; i++)
                    temp[i] = Color.FromArgb(255, paletteRedMenu[i], paletteGreenMenu[i], paletteBlueMenu[i]).ToArgb();
            }

            return temp;
        }
        private void CopyOverCharTile(int[] source, int[] dest, int destinationWidth, int x, int y)
        {
            int width = 0, height = 0;
            switch (fontType.SelectedIndex)
            {
                case 0: width = 8; height = 12; break;
                case 1: width = 16; height = 12; break;
                case 2: width = 8; height = 8; break;
                case 3:
                    if (y == 0) { width = 8; height = 16; }
                    else { width = 16; height = 8; }
                    break;
            }
            x *= width;
            y *= height;

            int[] src = source;
            int counter = 0;
            for (int i = 0; i < source.Length; i++)
            {
                dest[y * destinationWidth + x + counter] = src[i];
                counter++;
                if (counter % width == 0)
                {
                    y++;
                    counter = 0;
                }
            }
        }

        // export / import
        private void ExportFontGraphic()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;

            FileStream fs;
            BinaryWriter bw;
            try
            {
                // Create the file to store the level data
                switch (fontType.SelectedIndex)
                {
                    case 0:
                        saveFileDialog.FileName = "fontMenuGraphic.bin";
                        if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                            return;
                        fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.ReadWrite);
                        bw = new BinaryWriter(fs);
                        foreach (FontCharacter f in fontMenu)
                            bw.Write(f.Graphics, 0, 0x18);
                        break;
                    case 1:
                        saveFileDialog.FileName = "fontDialogueGraphic.bin";
                        if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                            return;
                        fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.ReadWrite);
                        bw = new BinaryWriter(fs);
                        foreach (FontCharacter f in fontDialogue)
                            bw.Write(f.Graphics, 0, 0x30);
                        break;
                    case 2:
                        saveFileDialog.FileName = "fontDescriptionsGraphic.bin";
                        if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                            return;
                        fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.ReadWrite);
                        bw = new BinaryWriter(fs);
                        foreach (FontCharacter f in fontDescription)
                            bw.Write(f.Graphics, 0, 0x10);
                        break;
                    default:
                        saveFileDialog.FileName = "fontTrianglesGraphic.bin";
                        if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                            return;
                        fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.ReadWrite);
                        bw = new BinaryWriter(fs);
                        foreach (FontCharacter f in fontTriangle)
                            bw.Write(f.Graphics, 0, 0x20);
                        break;
                }
                bw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem exporting the graphic block.");
            }
        }
        private void ImportFontGraphic(string path)
        {
            FileStream fs;
            BinaryReader br;
            Bitmap import;

            byte[] graphicBlock;
            byte[] temp;
            int[] pal, palette = new int[4];

            try
            {
                fs = File.OpenRead(path);
                if (Path.GetExtension(path) == ".jpg" || Path.GetExtension(path) == ".gif" || Path.GetExtension(path) == ".png")
                {
                    import = new Bitmap(Image.FromFile(path));
                    switch (fontType.SelectedIndex)
                    {
                        case 0:
                            pal = GetFontPalette(1); for (int i = 0; i < 4; i++) palette[i] = pal[i];
                            graphicBlock = ArrayTo2bppTile(ImageToArray(import, new Size(128, 112)), import.Width / 8, import.Height / 8, palette);
                            graphicBlock = TileToFont(graphicBlock, 0, new Size(import.Width / 8, import.Height / 12));
                            for (int i = 0; i * 0x18 < graphicBlock.Length && i < fontMenu.Length; i++)
                            {
                                temp = BitManager.GetByteArray(graphicBlock, i * 0x18, 0x18);
                                CopyOverGraphicBlock(
                                    temp, fontMenu[i].Graphics, new Size(import.Width / 8, import.Height / 8), 16, 0x18,
                                    currentFontChar % 8, currentFontChar / 8, 0);
                                fontMenu[i].Width = (byte)(fontMenu[i].GetRightMostPixel(palette) + 1);
                            }
                            break;
                        case 1:
                            pal = GetFontPalette(0); for (int i = 0; i < 4; i++) palette[i] = pal[i];
                            graphicBlock = ArrayTo2bppTile(ImageToArray(import, new Size(128, 192)), import.Width / 8, import.Height / 8, palette);
                            graphicBlock = TileToFont(graphicBlock, 1, new Size(import.Width / 16, import.Height / 12));
                            for (int i = 0; i * 0x30 < graphicBlock.Length && i < fontDialogue.Length; i++)
                            {
                                temp = BitManager.GetByteArray(graphicBlock, i * 0x30, 0x30);
                                CopyOverGraphicBlock(
                                    temp, fontDialogue[i].Graphics, new Size(import.Width / 8, import.Height / 8), 8, 0x30,
                                    currentFontChar % 8, currentFontChar / 8, 0);
                                fontDialogue[i].Width = (byte)(fontDialogue[i].GetRightMostPixel(palette) + 1);
                            }
                            break;
                        case 2:
                            pal = GetFontPalette(1); for (int i = 0; i < 4; i++) palette[i] = pal[i];
                            graphicBlock = ArrayTo2bppTile(ImageToArray(import, new Size(128, 72)), import.Width / 8, import.Height / 8, palette);
                            for (int i = 0; i * 0x10 < graphicBlock.Length && i < fontDescription.Length; i++)
                            {
                                temp = BitManager.GetByteArray(graphicBlock, i * 0x10, 0x10);
                                CopyOverGraphicBlock(
                                    temp, fontDescription[i].Graphics, new Size(import.Width / 8, import.Height / 8), 16, 0x10,
                                    currentFontChar % 8, currentFontChar / 8, 0);
                                fontDescription[i].Width = (byte)(fontDescription[i].GetRightMostPixel(palette) + 1);
                            }
                            break;
                        case 3:
                            graphicBlock = ArrayTo2bppTile(ImageToArray(import, new Size(128, 32)), import.Width / 8, import.Height / 8, GetFontPalette(0));
                            for (int i = 0; i * 0x20 < graphicBlock.Length && i < fontTriangle.Length; i++)
                            {
                                temp = BitManager.GetByteArray(graphicBlock, i * 0x20, 0x20);
                                CopyOverGraphicBlock(
                                    temp, fontTriangle[i].Graphics, new Size(import.Width / 8, import.Height / 8), 7, 0x20,
                                    currentFontChar % 8, currentFontChar / 8, 0);
                            }
                            break;
                    }
                }
                else
                {
                    br = new BinaryReader(fs);
                    switch (fontType.SelectedIndex)
                    {
                        case 0:
                            graphicBlock = new byte[0xC00];
                            graphicBlock = br.ReadBytes(0xC00);
                            foreach (FontCharacter f in fontMenu)
                                Array.Copy(graphicBlock, f.FontNum * 0x18, f.Graphics, 0, 0x18);
                            break;
                        case 1:
                            graphicBlock = new byte[0x1800];
                            graphicBlock = br.ReadBytes(0x1800);
                            foreach (FontCharacter f in fontDialogue)
                                Array.Copy(graphicBlock, f.FontNum * 0x30, f.Graphics, 0, 0x30);
                            break;
                        case 2:
                            graphicBlock = new byte[0x800];
                            graphicBlock = br.ReadBytes(0x800);
                            foreach (FontCharacter f in fontDescription)
                                Array.Copy(graphicBlock, f.FontNum * 0x10, f.Graphics, 0, 0x10);
                            break;
                        case 3:
                            graphicBlock = new byte[0x1C0];
                            graphicBlock = br.ReadBytes(0x1C0);
                            foreach (FontCharacter f in fontTriangle)
                                Array.Copy(graphicBlock, f.FontNum * 0x20, f.Graphics, 0, 0x20);
                            break;
                    }
                    br.Close();
                }
                fs.Close();

                SetFontPaletteImage();
                SetFontTableImage();
                SetFontCharacterImage();
                SetDialogueBGImage();
                SetDialogueTextImage();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem loading the file.", "LAZY SHELL");
                return;
            }
        }
        private byte[] TileToFont(byte[] src, int type, Size s)
        {
            byte[] temp = new byte[src.Length];
            int o = 0;
            switch (type)
            {
                case 0:
                    for (int y = 0; y < s.Height; y++)
                    {
                        if (y != 0 && y % 2 == 0) o += 0x100;
                        for (int x = 0; x < s.Width; x++)
                        {
                            if (y % 2 == 0)
                            {
                                for (int i = 0; i < 0x10; i++)
                                    temp[y * 0x180 + (x * 0x18) + i] = src[y * 0x100 + (x * 0x10) + i + o];
                                for (int i = 0; i < 0x08; i++)
                                    temp[y * 0x180 + (x * 0x18) + 0x10 + i] = src[y * 0x100 + (x * 0x10) + 0x100 + i + o];
                            }
                            else
                            {
                                for (int i = 0; i < 0x08; i++)
                                    temp[y * 0x180 + (x * 0x18) + i] = src[y * 0x100 + (x * 0x10) + i + o];
                                for (int i = 0; i < 0x10; i++)
                                    temp[y * 0x180 + (x * 0x18) + 0x08 + i] = src[y * 0x100 + (x * 0x10) + 0xF8 + i + o];
                            }
                        }
                        o ^= 8;
                    }
                    break;
                case 1:
                    for (int y = 0; y < s.Height; y++)
                    {
                        if (y != 0 && y % 2 == 0) o += 0x100;
                        for (int x = 0; x < s.Width; x++)
                        {
                            if (y % 2 == 0)
                            {
                                for (int i = 0; i < 0x10; i++)
                                    temp[y * 0x180 + (x * 0x30) + i] = src[y * 0x100 + (x * 0x20) + i + o];
                                for (int i = 0; i < 0x08; i++)
                                    temp[y * 0x180 + (x * 0x30) + 0x10 + i] = src[y * 0x100 + (x * 0x20) + 0x100 + i + o];
                                for (int i = 0; i < 0x10; i++)
                                    temp[y * 0x180 + (x * 0x30) + 0x18 + i] = src[y * 0x100 + (x * 0x20) + 0x10 + i + o];
                                for (int i = 0; i < 0x08; i++)
                                    temp[y * 0x180 + (x * 0x30) + 0x28 + i] = src[y * 0x100 + (x * 0x20) + 0x110 + i + o];
                            }
                            else
                            {
                                for (int i = 0; i < 0x08; i++)
                                    temp[y * 0x180 + (x * 0x30) + i] = src[y * 0x100 + (x * 0x20) + i + o];
                                for (int i = 0; i < 0x10; i++)
                                    temp[y * 0x180 + (x * 0x30) + 0x08 + i] = src[y * 0x100 + (x * 0x20) + 0xF8 + i + o];
                                for (int i = 0; i < 0x08; i++)
                                    temp[y * 0x180 + (x * 0x30) + 0x18 + i] = src[y * 0x100 + (x * 0x20) + 0x10 + i + o];
                                for (int i = 0; i < 0x10; i++)
                                    temp[y * 0x180 + (x * 0x30) + 0x20 + i] = src[y * 0x100 + (x * 0x20) + 0x108 + i + o];
                            }
                        }
                        o ^= 8;
                    }
                    break;
            }
            return temp;
        }

        private void AssembleFonts()
        {
            ushort color = 0;
            int r, g, b;
            for (int i = 0; i < 16; i++) // 16 colors in palette
            {
                r = (int)(paletteRedDialogue[i] / 8);
                g = (int)(paletteGreenDialogue[i] / 8);
                b = (int)(paletteBlueDialogue[i] / 8);
                color = (ushort)((b << 10) | (g << 5) | r);
                BitManager.SetShort(data, 0x3DFF00 + (i * 2), color);

                r = (int)(paletteRedMenu[i] / 8);
                g = (int)(paletteGreenMenu[i] / 8);
                b = (int)(paletteBlueMenu[i] / 8);
                color = (ushort)((b << 10) | (g << 5) | r);
                BitManager.SetShort(data, 0x3E2D55 + (i * 2), color);
            }
            BitManager.SetBit(data, 0x3E2D6C, 7, true);
            BitManager.SetBit(data, 0x3E2D74, 7, true);

            foreach (FontCharacter f in fontMenu) f.Assemble();
            foreach (FontCharacter f in fontDialogue) f.Assemble();
            foreach (FontCharacter f in fontDescription) f.Assemble();
            foreach (FontCharacter f in fontTriangle) f.Assemble();

            BitManager.SetByteArray(data, 0x3DF000, model.DialogueGraphics, 0, 0x700);
            BitManager.SetByteArray(data, 0x015943, model.BattleDialogueTileset, 0, 0x100);
        }

        #endregion

        #region Eventhandlers

        private void fontPalette_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingFonts) return;

            InitializeFontColor();

            int[] palette = GetFontPalette(fontPalette.SelectedIndex);
            fontTable.BackColor = Color.FromArgb(palette[3]);
            fontTable.ForeColor = Color.FromArgb(palette[1]);
            foreach (Control c in fontTable.Controls)
            {
                c.ForeColor = fontTable.ForeColor;
                c.BackColor = fontTable.BackColor;
            }
            fontTable.Invalidate();

            SetFontPaletteImage();
            SetFontTableImage();
            SetFontCharacterImage();

            SetDialogueBGImage();
            SetDialogueTextImage();
            SetBattleDialogueTextImage();
        }
        private void fontPaletteRedNum_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFonts) return;

            fontPaletteRedNum.Value = (int)fontPaletteRedNum.Value & 0xF8;

            fontPaletteRedBar.Value = (int)fontPaletteRedNum.Value;
            if (fontPalette.SelectedIndex == 0)
                paletteRedDialogue[currentFontColor] = (int)fontPaletteRedNum.Value;
            else
                paletteRedMenu[currentFontColor] = (int)fontPaletteRedNum.Value;
            Color color = Color.FromArgb((int)fontPaletteRedNum.Value, (int)fontPaletteGreenNum.Value, (int)fontPaletteBlueNum.Value);
            this.pictureBoxFontColor.BackColor = color;
            if (currentFontColor == 1)
            {
                fontTable.ForeColor = color;
                foreach (Control c in fontTable.Controls)
                    c.ForeColor = color;
                fontTable.Refresh();
            }
            else if (currentFontColor == 3)
            {
                fontTable.BackColor = color;
                foreach (Control c in fontTable.Controls)
                    c.BackColor = color;
                fontTable.Refresh();
            }

            if (fontPalette.SelectedIndex == 0)
                RefreshDialogueTilesets();
            SetFontPaletteImage();
            SetFontTableImage();
            SetFontCharacterImage();
            SetDialogueGraphicImage();

            SetBattleDialogueTilesetImage();
            SetDialogueTileImage();
            SetDialogueSubtileImage();
            if (fontType.SelectedIndex != 3)
                SetDialogueTextImage();
            SetDialogueBGImage();
            SetBattleDialogueTextImage();
        }
        private void fontPaletteGreenNum_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFonts) return;

            fontPaletteGreenNum.Value = (int)fontPaletteGreenNum.Value & 0xF8;

            fontPaletteGreenBar.Value = (int)fontPaletteGreenNum.Value;
            if (fontPalette.SelectedIndex == 0)
                paletteGreenDialogue[currentFontColor] = (int)fontPaletteGreenNum.Value;
            else
                paletteGreenMenu[currentFontColor] = (int)fontPaletteGreenNum.Value;
            Color color = Color.FromArgb((int)fontPaletteRedNum.Value, (int)fontPaletteGreenNum.Value, (int)fontPaletteBlueNum.Value);
            this.pictureBoxFontColor.BackColor = color;
            if (currentFontColor == 1)
            {
                fontTable.ForeColor = color;
                foreach (Control c in fontTable.Controls)
                    c.ForeColor = color;
                fontTable.Refresh();
            }
            else if (currentFontColor == 3)
            {
                fontTable.BackColor = color;
                foreach (Control c in fontTable.Controls)
                    c.BackColor = color;
                fontTable.Refresh();
            }

            if (fontPalette.SelectedIndex == 0)
                RefreshDialogueTilesets();
            SetFontPaletteImage();
            SetFontTableImage();
            SetFontCharacterImage();
            SetDialogueGraphicImage();

            SetBattleDialogueTilesetImage();
            SetDialogueTileImage();
            SetDialogueSubtileImage();
            if (fontType.SelectedIndex != 3)

                SetDialogueTextImage();
            SetDialogueBGImage();
            SetBattleDialogueTextImage();
        }
        private void fontPaletteBlueNum_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFonts) return;

            fontPaletteBlueNum.Value = (int)fontPaletteBlueNum.Value & 0xF8;

            fontPaletteBlueBar.Value = (int)fontPaletteBlueNum.Value;
            if (fontPalette.SelectedIndex == 0)
                paletteBlueDialogue[currentFontColor] = (int)fontPaletteBlueNum.Value;
            else
                paletteBlueMenu[currentFontColor] = (int)fontPaletteBlueNum.Value;
            Color color = Color.FromArgb((int)fontPaletteRedNum.Value, (int)fontPaletteGreenNum.Value, (int)fontPaletteBlueNum.Value);
            this.pictureBoxFontColor.BackColor = color;
            if (currentFontColor == 1)
            {
                fontTable.ForeColor = color;
                foreach (Control c in fontTable.Controls)
                    c.ForeColor = color;
                fontTable.Refresh();
            }
            else if (currentFontColor == 3)
            {
                fontTable.BackColor = color;
                foreach (Control c in fontTable.Controls)
                    c.BackColor = color;
                fontTable.Refresh();
            }

            if (fontPalette.SelectedIndex == 0)
                RefreshDialogueTilesets();
            SetFontPaletteImage();
            SetFontTableImage();
            SetFontCharacterImage();
            SetDialogueGraphicImage();

            SetBattleDialogueTilesetImage();
            SetDialogueTileImage();
            SetDialogueSubtileImage();
            if (fontType.SelectedIndex != 3)

                SetDialogueTextImage();
            SetDialogueBGImage();
            SetBattleDialogueTextImage();
        }
        private void fontPaletteRedBar_Scroll(object sender, EventArgs e)
        {
            if (updatingFonts) return;

            fontPaletteRedBar.Value = fontPaletteRedBar.Value & 0xF8;
            fontPaletteRedNum.Value = fontPaletteRedBar.Value;
        }
        private void fontPaletteGreenBar_Scroll(object sender, EventArgs e)
        {
            if (updatingFonts) return;

            fontPaletteGreenBar.Value = fontPaletteGreenBar.Value & 0xF8;
            fontPaletteGreenNum.Value = fontPaletteGreenBar.Value;
        }
        private void fontPaletteBlueBar_Scroll(object sender, EventArgs e)
        {
            if (updatingFonts) return;

            fontPaletteBlueBar.Value = fontPaletteBlueBar.Value & 0xF8;
            fontPaletteBlueNum.Value = fontPaletteBlueBar.Value;
        }
        private void pictureBoxFontPalette_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBoxFontPalette.Focus();

            currentFontColor = (e.Y / 15) * 16 + (e.X / 16);

            InitializeFontColor();
            pictureBoxFontPalette.Invalidate();
        }
        private void pictureBoxFontPalette_Paint(object sender, PaintEventArgs e)
        {
            if (fontPaletteImage != null)
                e.Graphics.DrawImage(fontPaletteImage, 0, 0);

            Point p = new Point(currentFontColor % 16 * 16, currentFontColor / 16 * 16);
            overlay.DrawSelectionBox(e.Graphics, new Point(p.X + 15, p.Y + 15 - (p.Y % 16)), p, 1);
        }
        private void fontType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingFonts) return;

            currentFontChar = 0;

            updatingFonts = true;
            switch (fontType.SelectedIndex)
            {
                case 0:
                    fontPalette.SelectedIndex = 1; charKeystroke.Enabled = true;
                    currentKS = settings.KeystrokesMenu;
                    break;
                case 1:
                    fontPalette.SelectedIndex = 0; charKeystroke.Enabled = true;
                    currentKS = settings.Keystrokes;
                    break;
                case 2:
                    fontPalette.SelectedIndex = 1; charKeystroke.Enabled = true;
                    currentKS = settings.KeystrokesDesc;
                    break;
                case 3:
                    fontPalette.SelectedIndex = 0; charKeystroke.Enabled = false;
                    currentKS = null;
                    charKeystroke.Text = "";
                    break;
            }
            updatingFonts = false;

            InitializeFontColor();
            InitializeFonts();
            SetFontPaletteImage();
            SetFontTableImage();
            SetFontCharacterImage();


            SetDialogueBGImage();
            SetDialogueTextImage();

            if (fontType.SelectedIndex != 3)
            {
                panel66.Enabled = true;
                InitializeNewFontTable();
            }
            else
                panel66.Enabled = false;
        }
        private void pictureBoxFont_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBoxFont.Focus();

            int before = currentFontChar;
            switch (fontType.SelectedIndex)
            {
                case 0: currentFontChar = e.Y / 12 * 16 + (e.X / 8); break;
                case 1: currentFontChar = e.Y / 12 * 8 + (e.X / 16); break;
                case 2: currentFontChar = e.Y / 8 * 16 + (e.X / 8); break;
                case 3:
                    if (e.X > 112) return;
                    currentFontChar = e.Y / 16 * 7 + (e.X / 16); break;
            }
            if (currentFontChar == 59 || currentFontChar == 61)
            {
                MessageBox.Show("Character #91 and #93 cannot be edited because they are reserved for [ and ], respectively.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                currentFontChar = before;
                return;
            }

            InitializeFontCharacter();
            SetFontCharacterImage();
        }
        private void pictureBoxFont_MouseMove(object sender, MouseEventArgs e)
        {
            mouseOverControl = pictureBoxFont.Name;

            characterNumLabel.BringToFront();
            characterNumLabel.Left = 650 + e.X + 25;
            characterNumLabel.Top = 230 + e.Y - 25;
            switch (fontType.SelectedIndex)
            {
                case 0: overFontChar = e.Y / 12 * 16 + (e.X / 8) + 32; break;
                case 1: overFontChar = e.Y / 12 * 8 + (e.X / 16) + 32; break;
                case 2: overFontChar = e.Y / 8 * 16 + (e.X / 8) + 32; break;
                case 3: if (e.X > 112) return; overFontChar = e.Y / 16 * 7 + (e.X / 16); break;
            }
            characterNumLabel.Text = "[" + overFontChar + "]";
            CullLabelWidth(characterNumLabel);
        }
        private void pictureBoxFont_Paint(object sender, PaintEventArgs e)
        {
            if (fontTableImage != null)
                e.Graphics.DrawImage(fontTableImage, 0, 0);
            Size s = new Size();
            switch (fontType.SelectedIndex)
            {
                case 0: s = new Size(8, 12); break;
                case 1: s = new Size(16, 12); break;
                case 2: s = new Size(8, 8); break;
            }
            if (fontShowGrid.Checked && fontType.SelectedIndex != 3)
                overlay.DrawCartographicGrid(e.Graphics, Color.Gray, new Size(fontTableImage.Width, fontTableImage.Height), s, 1);
        }
        private void pictureBoxFont_MouseEnter(object sender, EventArgs e)
        {
            characterNumLabel.Visible = true;
        }
        private void pictureBoxFont_MouseLeave(object sender, EventArgs e)
        {
            characterNumLabel.Visible = false;
        }
        private void fontShowGrid_Click(object sender, EventArgs e)
        {
            fontShowGrid.ForeColor = fontShowGrid.Checked ? SystemColors.ControlText : SystemColors.ControlDark;
            pictureBoxFont.Invalidate();
            pictureBoxFontEditor.Invalidate();
        }

        private void pictureBoxFontEditor_MouseDown(object sender, MouseEventArgs e)
        {
            switch (edit)
            {
                case 1: pictureBoxFontEditor_MouseMove(sender, e); break;
                case 2: pictureBoxFontEditor_MouseMove(sender, e); break;
                case 3: pictureBoxFontEditor_MouseMove(sender, e); break;
            }
        }
        private void pictureBoxFontEditor_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X >= pictureBoxFontEditor.Width || e.Y >= pictureBoxFontEditor.Height || e.X < 0 || e.Y < 0) return;
            if (edit == 0) return;

            currentPixel = (e.X / zoom) + ((e.Y / zoom) * (pictureBoxFontEditor.Width / zoom));

            byte row = (byte)(e.Y / zoom);
            byte col = (byte)(e.X / zoom);
            byte bit = (byte)((col & 7) ^ 7);

            int offset = row * 2;
            if (e.Button == MouseButtons.Left)
            {
                switch (edit)
                {
                    case 1:
                        switch (fontType.SelectedIndex)
                        {
                            case 0:
                                BitManager.SetBit(fontMenu[currentFontChar].Graphics, offset, bit, (currentFontColor & 1) == 1);
                                BitManager.SetBit(fontMenu[currentFontChar].Graphics, offset + 1, bit, (currentFontColor & 2) == 2);
                                break;
                            case 1:
                                offset += col >= 8 ? 24 : 0;
                                BitManager.SetBit(fontDialogue[currentFontChar].Graphics, offset, bit, (currentFontColor & 1) == 1);
                                BitManager.SetBit(fontDialogue[currentFontChar].Graphics, offset + 1, bit, (currentFontColor & 2) == 2);
                                break;
                            case 2:
                                BitManager.SetBit(fontDescription[currentFontChar].Graphics, offset, bit, (currentFontColor & 1) == 1);
                                BitManager.SetBit(fontDescription[currentFontChar].Graphics, offset + 1, bit, (currentFontColor & 2) == 2);
                                break;
                            case 3:
                                offset += col >= 8 ? 16 : 0;
                                BitManager.SetBit(fontTriangle[currentFontChar].Graphics, offset, bit, (currentFontColor & 1) == 1);
                                BitManager.SetBit(fontTriangle[currentFontChar].Graphics, offset + 1, bit, (currentFontColor & 2) == 2);
                                break;
                        }
                        SetFontCharacterImage();
                        break;
                    case 2:
                        switch (fontType.SelectedIndex)
                        {
                            case 0:
                                BitManager.SetBit(fontMenu[currentFontChar].Graphics, offset, bit, false);
                                BitManager.SetBit(fontMenu[currentFontChar].Graphics, offset + 1, bit, false);
                                break;
                            case 1:
                                offset += col >= 8 ? 24 : 0;
                                BitManager.SetBit(fontDialogue[currentFontChar].Graphics, offset, bit, false);
                                BitManager.SetBit(fontDialogue[currentFontChar].Graphics, offset + 1, bit, false);
                                break;
                            case 2:
                                BitManager.SetBit(fontDescription[currentFontChar].Graphics, offset, bit, false);
                                BitManager.SetBit(fontDescription[currentFontChar].Graphics, offset + 1, bit, false);
                                break;
                            case 3:
                                offset += col >= 8 ? 16 : 0;
                                BitManager.SetBit(fontTriangle[currentFontChar].Graphics, offset, bit, false);
                                BitManager.SetBit(fontTriangle[currentFontChar].Graphics, offset + 1, bit, false);
                                break;
                        }
                        SetFontCharacterImage();
                        break;
                    case 3:
                        switch (fontType.SelectedIndex)
                        {
                            case 0:
                                currentFontColor = BitManager.GetBit(fontMenu[currentFontChar].Graphics, offset, bit) ? 1 : 0;
                                currentFontColor |= BitManager.GetBit(fontMenu[currentFontChar].Graphics, offset + 1, bit) ? 2 : 0;
                                break;
                            case 1:
                                offset += col >= 8 ? 24 : 0;
                                currentFontColor = BitManager.GetBit(fontDialogue[currentFontChar].Graphics, offset, bit) ? 1 : 0;
                                currentFontColor |= BitManager.GetBit(fontDialogue[currentFontChar].Graphics, offset + 1, bit) ? 2 : 0;
                                break;
                            case 2:
                                currentFontColor = BitManager.GetBit(fontDescription[currentFontChar].Graphics, offset, bit) ? 1 : 0;
                                currentFontColor |= BitManager.GetBit(fontDescription[currentFontChar].Graphics, offset + 1, bit) ? 2 : 0;
                                break;
                            case 3:
                                offset += col >= 8 ? 16 : 0;
                                currentFontColor = BitManager.GetBit(fontTriangle[currentFontChar].Graphics, offset, bit) ? 1 : 0;
                                currentFontColor |= BitManager.GetBit(fontTriangle[currentFontChar].Graphics, offset + 1, bit) ? 2 : 0;
                                currentFontColor += 4;
                                break;
                        }
                        InitializeFontColor();
                        pictureBoxFontPalette.Invalidate();
                        break;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (fontEditDraw.Checked)
                {
                    switch (fontType.SelectedIndex)
                    {
                        case 0:
                            BitManager.SetBit(fontMenu[currentFontChar].Graphics, offset, bit, false);
                            BitManager.SetBit(fontMenu[currentFontChar].Graphics, offset + 1, bit, false);
                            break;
                        case 1:
                            offset += col >= 8 ? 24 : 0;
                            BitManager.SetBit(fontDialogue[currentFontChar].Graphics, offset, bit, false);
                            BitManager.SetBit(fontDialogue[currentFontChar].Graphics, offset + 1, bit, false);
                            break;
                        case 2:
                            BitManager.SetBit(fontDescription[currentFontChar].Graphics, offset, bit, false);
                            BitManager.SetBit(fontDescription[currentFontChar].Graphics, offset + 1, bit, false);
                            break;
                        case 3:
                            offset += col >= 8 ? 16 : 0;
                            BitManager.SetBit(fontTriangle[currentFontChar].Graphics, offset, bit, false);
                            BitManager.SetBit(fontTriangle[currentFontChar].Graphics, offset + 1, bit, false);
                            break;
                    }

                    SetFontCharacterImage();
                }
            }
        }
        private void pictureBoxFontEditor_MouseUp(object sender, MouseEventArgs e)
        {
            SetFontTableImage();

            SetBattleDialogueTextImage();
            SetDialogueTextImage();
        }
        private void pictureBoxFontEditor_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            Rectangle rsrc = new Rectangle(0, 0, fontCharacterImage.Width, fontCharacterImage.Height);
            Rectangle rdst = new Rectangle(0, 0, fontCharacterImage.Width * zoom, fontCharacterImage.Height * zoom);

            if (fontCharacterImage != null)
                e.Graphics.DrawImage(fontCharacterImage, rdst, rsrc, GraphicsUnit.Pixel);

            if (fontShowGrid.Checked && zoom >= 4)
                overlay.DrawCartographicGrid(e.Graphics, Color.Gray, new Size(fontCharacterImage.Width * zoom, fontCharacterImage.Height * zoom), new Size(1, 1), zoom);
        }
        private void pictureBoxFontEditor_Click(object sender, EventArgs e)
        {
            pictureBoxFontEditor.Focus();
        }
        private void pictureBoxFontEditor_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Control | Keys.C: tsmiCopyCH_Click(null, null); break;
                case Keys.Control | Keys.X: tsmiCutCH_Click(null, null); break;
                case Keys.Control | Keys.V: tsmiPasteCH_Click(null, null); break;
                case Keys.Delete: tsmiDeleteCH_Click(null, null); break;
            }
        }
        private void panel25_Scroll(object sender, ScrollEventArgs e)
        {
            pictureBoxFontEditor.Invalidate();
        }

        private void charKeystroke_TextChanged(object sender, EventArgs e)
        {
            if (updatingFonts) return;

            if (currentKS == null) return;

            foreach (string temp in currentKS)
            {
                if (charKeystroke.Text != "" && temp == charKeystroke.Text)
                {
                    MessageBox.Show(
                        "There is already a character with the assigned keystroke.",
                        "LAZY SHELL");
                    charKeystroke.Text = "";
                    return;
                }
            }
            if (charKeystroke.Text == "\xA0")
                currentKS[currentFontChar + 32] = "\x20";
            else
                currentKS[currentFontChar + 32] = charKeystroke.Text;

            SetDialogueTextImage();
            SetBattleDialogueTextImage();
        }
        private void charKeystroke_Leave(object sender, EventArgs e)
        {
            //settings.Save();
        }
        private void openKeystrokes_Click(object sender, EventArgs e)
        {
            string path = SelectFile("Select keystroke table to use...", "Text files (*.txt)|*.txt|All files (*.*)|*.*", 1);
            if (path == null) return;
            StreamReader sr = new StreamReader(path);
            string line;
            for (int i = 32; i < currentKS.Count && (line = sr.ReadLine()) != null; i++)
            {
                if (line.Length > 1)
                {
                    MessageBox.Show("There was a problem opening the keystroke table.\n" +
                        "One or more of the assigned keystrokes has an invalid length.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                currentKS[i] = line;
            }
            currentKS[0x20] = "\x20";
        }
        private void saveKeystrokes_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            switch (fontType.SelectedIndex)
            {
                case 0: saveFileDialog.FileName = "keystrokesMenu.txt"; break;
                case 1: saveFileDialog.FileName = "keystrokesDialogue.txt"; break;
                case 2: saveFileDialog.FileName = "keystrokesDescriptions.txt"; break;
            }
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "SAVE KEYSTROKE TABLE";

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            StreamWriter sr = new StreamWriter(saveFileDialog.FileName);
            for (int i = 32; i < currentKS.Count; i++)
            {
                string s = currentKS[i];
                sr.WriteLine(s);
            }
            sr.Close();
        }
        private void fontWidth_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFonts) return;

            switch (fontType.SelectedIndex)
            {
                case 0: fontMenu[currentFontChar].Width = (byte)fontWidth.Value; goto default;
                case 1: fontDialogue[currentFontChar].Width = (byte)fontWidth.Value; goto default;
                case 2: fontDescription[currentFontChar].Width = (byte)fontWidth.Value; goto default;
                default:

                    SetDialogueTextImage();
                    SetBattleDialogueTextImage();
                    break;
            }
        }
        private void fontEditDraw_Click(object sender, EventArgs e)
        {
            fontEditErase.Checked = false;
            fontEditChoose.Checked = false;
            fontEditZoomIn.Checked = false;
            fontEditZoomOut.Checked = false;
            edit = fontEditDraw.Checked ? 1 : 0;
            pictureBoxFontEditor.Cursor = edit == 1 ? new Cursor(GetType(), "CursorDraw.cur") : Cursors.Arrow;
        }
        private void fontEditErase_Click(object sender, EventArgs e)
        {
            fontEditDraw.Checked = false;
            fontEditChoose.Checked = false;
            fontEditZoomIn.Checked = false;
            fontEditZoomOut.Checked = false;
            edit = fontEditErase.Checked ? 2 : 0;
            pictureBoxFontEditor.Cursor = edit == 2 ? new Cursor(GetType(), "CursorErase.cur") : Cursors.Arrow;
        }
        private void fontEditChoose_Click(object sender, EventArgs e)
        {
            fontEditDraw.Checked = false;
            fontEditErase.Checked = false;
            fontEditZoomIn.Checked = false;
            fontEditZoomOut.Checked = false;
            edit = fontEditChoose.Checked ? 3 : 0;
            pictureBoxFontEditor.Cursor = edit == 3 ? new Cursor(GetType(), "CursorDropper.cur") : Cursors.Arrow;
        }
        private void fontEditZoomIn_Click(object sender, EventArgs e)
        {
            if (zoom >= 16) return;

            zoom *= 2;
            pictureBoxFontEditor.Width *= 2;
            pictureBoxFontEditor.Height *= 2;
            pictureBoxFontEditor.Invalidate();
        }
        private void fontEditZoomOut_Click(object sender, EventArgs e)
        {
            if (zoom <= 1) return;

            zoom /= 2;
            pictureBoxFontEditor.Width /= 2;
            pictureBoxFontEditor.Height /= 2;
            pictureBoxFontEditor.Invalidate();
        }
        private void fontEditDelete_Click(object sender, EventArgs e)
        {
            tsmiDeleteCH_Click(null, null);
        }
        private void fontEditCopy_Click(object sender, EventArgs e)
        {
            tsmiCopyCH_Click(null, null);
        }
        private void fontEditPaste_Click(object sender, EventArgs e)
        {
            tsmiPasteCH_Click(null, null);
        }
        private void fontEditMirror_Click(object sender, EventArgs e)
        {
            int offsetA = 0, offsetB = 0;
            int maxX = 0, maxY = 0, minX = 0, minY = 0;
            byte rowA, colA, bitA, rowB, colB, bitB;
            bool tempM, tempN;
            FontCharacter chr;
            switch (fontType.SelectedIndex)
            {
                default: chr = fontMenu[currentFontChar]; break;
                case 1: chr = fontDialogue[currentFontChar]; break;
                case 2: chr = fontDescription[currentFontChar]; break;
                case 3: chr = fontTriangle[currentFontChar]; break;
            }
            maxY = chr.GetBottomMostPixel(GetFontPalette(fontPalette.SelectedIndex));
            maxX = chr.GetRightMostPixel(GetFontPalette(fontPalette.SelectedIndex));
            minY = chr.GetTopMostPixel(GetFontPalette(fontPalette.SelectedIndex));
            minX = chr.GetLeftMostPixel(GetFontPalette(fontPalette.SelectedIndex));

            for (int y = minY; y < maxY + 1; y++)
            {
                for (int a = minX, b = maxX; a < b; a++, b--)
                {
                    rowA = (byte)y;
                    colA = (byte)a;
                    bitA = (byte)((colA & 7) ^ 7);
                    offsetA = rowA * 2;

                    rowB = (byte)y;
                    colB = (byte)b;
                    bitB = (byte)((colB & 7) ^ 7);
                    offsetB = rowB * 2;

                    switch (fontType.SelectedIndex)
                    {
                        case 0:
                        case 2:
                            tempM = BitManager.GetBit(chr.Graphics, offsetA, bitA);
                            tempN = BitManager.GetBit(chr.Graphics, offsetA + 1, bitA);
                            BitManager.SetBit(chr.Graphics, offsetA, bitA, BitManager.GetBit(chr.Graphics, offsetB, bitB));
                            BitManager.SetBit(chr.Graphics, offsetA + 1, bitA, BitManager.GetBit(chr.Graphics, offsetB + 1, bitB));
                            BitManager.SetBit(chr.Graphics, offsetB, bitB, tempM);
                            BitManager.SetBit(chr.Graphics, offsetB + 1, bitB, tempN);
                            break;
                        case 1:
                            offsetA += colA >= 8 ? 24 : 0;
                            offsetB += colB >= 8 ? 24 : 0;
                            goto case 0;
                        case 3:
                            offsetA += colA >= 8 ? 16 : 0;
                            offsetB += colB >= 8 ? 16 : 0;
                            goto case 0;
                    }
                }
            }
            SetFontCharacterImage();
            SetFontTableImage();

            SetBattleDialogueTextImage();
            SetDialogueTextImage();
        }
        private void fontEditInvert_Click(object sender, EventArgs e)
        {
            int offsetA = 0, offsetB = 0;
            int maxX = 0, maxY = 0, minX = 0, minY = 0;
            byte rowA, colA, bitA, rowB, colB, bitB;
            bool tempM, tempN;
            FontCharacter chr;
            switch (fontType.SelectedIndex)
            {
                default: chr = fontMenu[currentFontChar]; break;
                case 1: chr = fontDialogue[currentFontChar]; break;
                case 2: chr = fontDescription[currentFontChar]; break;
                case 3: chr = fontTriangle[currentFontChar]; break;
            }
            maxY = chr.GetBottomMostPixel(GetFontPalette(fontPalette.SelectedIndex));
            maxX = chr.GetRightMostPixel(GetFontPalette(fontPalette.SelectedIndex));
            minY = chr.GetTopMostPixel(GetFontPalette(fontPalette.SelectedIndex));
            minX = chr.GetLeftMostPixel(GetFontPalette(fontPalette.SelectedIndex));

            for (int x = minX; x < maxX + 1; x++)
            {
                for (int a = minY, b = maxY; a < b; a++, b--)
                {
                    rowA = (byte)a;
                    colA = (byte)x;
                    bitA = (byte)((colA & 7) ^ 7);
                    offsetA = rowA * 2;

                    rowB = (byte)b;
                    colB = (byte)x;
                    bitB = (byte)((colB & 7) ^ 7);
                    offsetB = rowB * 2;

                    switch (fontType.SelectedIndex)
                    {
                        case 0:
                        case 2:
                            tempM = BitManager.GetBit(chr.Graphics, offsetA, bitA);
                            tempN = BitManager.GetBit(chr.Graphics, offsetA + 1, bitA);
                            BitManager.SetBit(chr.Graphics, offsetA, bitA, BitManager.GetBit(chr.Graphics, offsetB, bitB));
                            BitManager.SetBit(chr.Graphics, offsetA + 1, bitA, BitManager.GetBit(chr.Graphics, offsetB + 1, bitB));
                            BitManager.SetBit(chr.Graphics, offsetB, bitB, tempM);
                            BitManager.SetBit(chr.Graphics, offsetB + 1, bitB, tempN);
                            break;
                        case 1:
                            offsetA += colA >= 8 ? 24 : 0;
                            offsetB += colB >= 8 ? 24 : 0;
                            goto case 0;
                        case 3:
                            offsetA += colA >= 8 ? 16 : 0;
                            offsetB += colB >= 8 ? 16 : 0;
                            goto case 0;
                    }
                }
            }
            SetFontCharacterImage();
            SetFontTableImage();

            SetBattleDialogueTextImage();
            SetDialogueTextImage();
        }

        private void tsmiCopyCH_Click(object sender, EventArgs e)
        {
            switch (fontType.SelectedIndex)
            {
                case 0:
                    fontBuffer = new byte[fontMenu[currentFontChar].Graphics.Length];
                    fontMenu[currentFontChar].Graphics.CopyTo(fontBuffer, 0); break;
                case 1:
                    fontBuffer = new byte[fontDialogue[currentFontChar].Graphics.Length];
                    fontDialogue[currentFontChar].Graphics.CopyTo(fontBuffer, 0); break;
                case 2:
                    fontBuffer = new byte[fontDescription[currentFontChar].Graphics.Length];
                    fontDescription[currentFontChar].Graphics.CopyTo(fontBuffer, 0); break;
                case 3:
                    fontBuffer = new byte[fontTriangle[currentFontChar].Graphics.Length];
                    fontTriangle[currentFontChar].Graphics.CopyTo(fontBuffer, 0); break;
            }
        }
        private void tsmiCutCH_Click(object sender, EventArgs e)
        {
            switch (fontType.SelectedIndex)
            {
                case 0:
                    fontBuffer = new byte[fontMenu[currentFontChar].Graphics.Length];
                    fontMenu[currentFontChar].Graphics.CopyTo(fontBuffer, 0);
                    fontMenu[currentFontChar].Graphics = new byte[0x18]; break;
                case 1:
                    fontBuffer = new byte[fontDialogue[currentFontChar].Graphics.Length];
                    fontDialogue[currentFontChar].Graphics.CopyTo(fontBuffer, 0);
                    fontDialogue[currentFontChar].Graphics = new byte[0x30]; break;
                case 2:
                    fontBuffer = new byte[fontDescription[currentFontChar].Graphics.Length];
                    fontDescription[currentFontChar].Graphics.CopyTo(fontBuffer, 0);
                    fontDescription[currentFontChar].Graphics = new byte[0x10]; break;
                case 3:
                    fontBuffer = new byte[fontTriangle[currentFontChar].Graphics.Length];
                    fontTriangle[currentFontChar].Graphics.CopyTo(fontBuffer, 0);
                    fontTriangle[currentFontChar].Graphics = new byte[0x20]; break;
            }
            SetFontCharacterImage();
            SetFontTableImage();

            SetBattleDialogueTextImage();
            SetDialogueTextImage();
        }
        private void tsmiPasteCH_Click(object sender, EventArgs e)
        {
            if (fontBuffer == null) return;
            switch (fontType.SelectedIndex)
            {
                case 0: fontMenu[currentFontChar].Graphics = fontBuffer; break;
                case 1: fontDialogue[currentFontChar].Graphics = fontBuffer; break;
                case 2: fontDescription[currentFontChar].Graphics = fontBuffer; break;
                case 3: fontTriangle[currentFontChar].Graphics = fontBuffer; break;
            }
            SetFontCharacterImage();
            SetFontTableImage();

            SetBattleDialogueTextImage();
            SetDialogueTextImage();
        }
        private void tsmiDeleteCH_Click(object sender, EventArgs e)
        {
            switch (fontType.SelectedIndex)
            {
                case 0: fontMenu[currentFontChar].Graphics = new byte[0x18]; break;
                case 1: fontDialogue[currentFontChar].Graphics = new byte[0x30]; break;
                case 2: fontDescription[currentFontChar].Graphics = new byte[0x10]; break;
                case 3: fontTriangle[currentFontChar].Graphics = new byte[0x20]; break;
            }
            SetFontCharacterImage();
            SetFontTableImage();

            SetBattleDialogueTextImage();
            SetDialogueTextImage();
        }

        private void fontUnderline_Click(object sender, EventArgs e)
        {
            try
            {
                underline = fontUnderline.Checked ? FontStyle.Underline : FontStyle.Regular;
                fontTable.Font = new Font(ff[fontFamily.SelectedIndex].Name, (float)fontSize.Value, (FontStyle)(bold | italics | underline));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Font does not support the current selected styles.", "LAZY SHELL");
            }
        }
        private void fontItalics_Click(object sender, EventArgs e)
        {
            try
            {
                italics = fontItalics.Checked ? FontStyle.Italic : FontStyle.Regular;
                fontTable.Font = new Font(ff[fontFamily.SelectedIndex].Name, (float)fontSize.Value, (FontStyle)(bold | italics | underline));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Font does not support the current selected styles.", "LAZY SHELL");
            }
        }
        private void fontBold_Click(object sender, EventArgs e)
        {
            try
            {
                bold = fontBold.Checked ? FontStyle.Bold : FontStyle.Regular;
                fontTable.Font = new Font(ff[fontFamily.SelectedIndex].Name, (float)fontSize.Value, (FontStyle)(bold | italics | underline));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Font does not support the current selected styles.", "LAZY SHELL");
            }
        }
        private void fontFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fontBold.Checked && !ff[fontFamily.SelectedIndex].IsStyleAvailable(FontStyle.Bold))
            {
                fontBold.Checked = false;
                bold = FontStyle.Regular;
            }
            if (fontItalics.Checked && !ff[fontFamily.SelectedIndex].IsStyleAvailable(FontStyle.Italic))
            {
                fontItalics.Checked = false;
                italics = FontStyle.Regular;
            }
            if (fontUnderline.Checked && !ff[fontFamily.SelectedIndex].IsStyleAvailable(FontStyle.Underline))
            {
                fontUnderline.Checked = false;
                underline = FontStyle.Regular;
            }
            if (!fontBold.Checked && !fontItalics.Checked && !fontUnderline.Checked && !ff[fontFamily.SelectedIndex].IsStyleAvailable(FontStyle.Regular))
            {
                if (ff[fontFamily.SelectedIndex].IsStyleAvailable(FontStyle.Bold))
                {
                    fontBold.Checked = true;
                    bold = italics = underline = FontStyle.Bold;
                }
                else if (ff[fontFamily.SelectedIndex].IsStyleAvailable(FontStyle.Italic))
                {
                    fontItalics.Checked = true;
                    bold = italics = underline = FontStyle.Italic;
                }
                else if (ff[fontFamily.SelectedIndex].IsStyleAvailable(FontStyle.Underline))
                {
                    fontUnderline.Checked = true;
                    bold = italics = underline = FontStyle.Underline;
                }
            }

            try
            {
                fontTable.Font = new Font(ff[fontFamily.SelectedIndex].Name, (float)fontSize.Value, (FontStyle)(bold | italics | underline));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Font does not support the current selected styles.", "LAZY SHELL");
            }
        }
        private void fontSize_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                fontTable.Font = new Font(ff[fontFamily.SelectedIndex].Name, (float)fontSize.Value, (FontStyle)(bold | italics | underline));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Font does not support the current selected size.", "LAZY SHELL");
            }
        }

        private void shiftTableUp_Click(object sender, EventArgs e)
        {
            foreach (Control c in fontTable.Controls)
                c.Top--;
        }
        private void shiftTableDown_Click(object sender, EventArgs e)
        {
            foreach (Control c in fontTable.Controls)
                c.Top++;
        }
        private void shiftTableRight_Click(object sender, EventArgs e)
        {
            foreach (Control c in fontTable.Controls)
                c.Left++;
        }
        private void shiftTableLeft_Click(object sender, EventArgs e)
        {
            foreach (Control c in fontTable.Controls)
                c.Left--;
        }
        private void resetTable_Click(object sender, EventArgs e)
        {
            InitializeNewFontTable();
        }
        private void characterHeight_ValueChanged(object sender, EventArgs e)
        {
            if (updatingFonts) return;

            foreach (Control c in fontTable.Controls)
                c.Height = (int)characterHeight.Value;
        }
        private void generateFontTableImage_Click(object sender, EventArgs e)
        {
            Graphics graphic = this.fontTable.CreateGraphics();
            Size s = this.fontTable.Size;
            Bitmap import = new Bitmap(s.Width, s.Height, graphic);
            Graphics memGraphic = Graphics.FromImage(import);
            IntPtr dc1 = graphic.GetHdc();
            IntPtr dc2 = memGraphic.GetHdc();
            BitBlt(dc2, 0, 0, this.fontTable.ClientRectangle.Width,
            this.fontTable.ClientRectangle.Height, dc1, 0, 0, SRCCOPY);
            graphic.ReleaseHdc(dc1);
            memGraphic.ReleaseHdc(dc2);

            int[] pal, palette = new int[4];
            byte[] temp, graphicBlock;

            import.MakeTransparent(fontTable.BackColor);

            switch (fontType.SelectedIndex)
            {
                case 0:
                    pal = GetFontPalette(fontPalette.SelectedIndex); for (int i = 0; i < 4; i++) palette[i] = pal[i];
                    graphicBlock = ArrayTo2bppTile(ImageToArray(import, new Size(128, 112)), import.Width / 8, import.Height / 8, palette);
                    graphicBlock = TileToFont(graphicBlock, 0, new Size(import.Width / 8, import.Height / 12));
                    for (int i = 0; i * 0x18 < graphicBlock.Length && i < fontMenu.Length; i++)
                    {
                        temp = BitManager.GetByteArray(graphicBlock, i * 0x18, 0x18);
                        CopyOverGraphicBlock(
                            temp, fontMenu[i].Graphics, new Size(import.Width / 8, import.Height / 8), 16, 0x18,
                            currentFontChar % 8, currentFontChar / 8, 0);
                    }
                    break;
                case 1:
                    pal = GetFontPalette(fontPalette.SelectedIndex); for (int i = 0; i < 4; i++) palette[i] = pal[i];
                    graphicBlock = ArrayTo2bppTile(ImageToArray(import, new Size(128, 192)), import.Width / 8, import.Height / 8, palette);
                    graphicBlock = TileToFont(graphicBlock, 1, new Size(import.Width / 16, import.Height / 12));
                    for (int i = 0; i * 0x30 < graphicBlock.Length && i < fontDialogue.Length; i++)
                    {
                        temp = BitManager.GetByteArray(graphicBlock, i * 0x30, 0x30);
                        CopyOverGraphicBlock(
                            temp, fontDialogue[i].Graphics, new Size(import.Width / 8, import.Height / 8), 8, 0x30,
                            currentFontChar % 8, currentFontChar / 8, 0);
                        if (autoSetWidths.Checked && i != 0)
                            fontDialogue[i].Width = (byte)(fontDialogue[i].GetRightMostPixel(palette) + padding.Value);
                        if (fontDialogue[i].Width > 16) fontDialogue[i].Width = 16;
                    }
                    break;
                case 2:
                    pal = GetFontPalette(fontPalette.SelectedIndex); for (int i = 0; i < 4; i++) palette[i] = pal[i];
                    graphicBlock = ArrayTo2bppTile(ImageToArray(import, new Size(128, 72)), import.Width / 8, import.Height / 8, palette);
                    for (int i = 0; i * 0x10 < graphicBlock.Length && i < fontDescription.Length; i++)
                    {
                        temp = BitManager.GetByteArray(graphicBlock, i * 0x10, 0x10);
                        CopyOverGraphicBlock(
                            temp, fontDescription[i].Graphics, new Size(import.Width / 8, import.Height / 8), 16, 0x10,
                            currentFontChar % 8, currentFontChar / 8, 0);
                        if (autoSetWidths.Checked && i != 0)
                            fontDescription[i].Width = (byte)(fontDescription[i].GetRightMostPixel(palette) + padding.Value);
                        if (fontDescription[i].Width > 8) fontDescription[i].Width = 8;
                    }
                    break;
            }

            // refresh fonts
            currentFontChar = 0;
            InitializeFontCharacter();

            SetFontTableImage();
            SetFontCharacterImage();

            SetDialogueTextImage();
            SetBattleDialogueTextImage();
        }
        private void autoSetWidths_Click(object sender, EventArgs e)
        {
            autoSetWidths.ForeColor = autoSetWidths.Checked ? SystemColors.ControlText : SystemColors.ControlDark;

            padding.Enabled = autoSetWidths.Checked;
        }

        #endregion
    }
}
