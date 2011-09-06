using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    public partial class Fonts : Form
    {
        #region Variables
        // main
        
        private Dialogues dialoguesEditor;
        private bool updating;
        private Overlay overlay;
        // accessors
        private byte[] data { get { return Model.Data; } set { Model.Data = value; } }
        private BattleDialogues battleDialogues { get { return dialoguesEditor.BattleDialogues; } set { dialoguesEditor.BattleDialogues = value; } }
        private FontCharacter[] font
        {
            get
            {
                switch (fontType.SelectedIndex)
                {
                    case 0: return fontMenu;
                    case 1: return fontDialogue;
                    case 2: return fontDescription;
                    default: return fontTriangle;
                }
            }
            set
            {
                switch (fontType.SelectedIndex)
                {
                    case 0: fontMenu = value; break;
                    case 1: fontDialogue = value; break;
                    case 2: fontDescription = value; break;
                    default: fontTriangle = value; break;
                }
            }
        }
        private FontCharacter[] fontMenu { get { return Model.FontMenu; } set { Model.FontMenu = value; } }
        private FontCharacter[] fontDialogue { get { return Model.FontDialogue; } set { Model.FontDialogue = value; } }
        private FontCharacter[] fontDescription { get { return Model.FontDescription; } set { Model.FontDescription = value; } }
        private FontCharacter[] fontTriangle { get { return Model.FontTriangle; } set { Model.FontTriangle = value; } }
        private PaletteSet fontPalettesDialogue { get { return Model.FontPaletteDialogue; } set { Model.FontPaletteDialogue = value; } }
        private PaletteSet fontPalettesMenu { get { return Model.FontPaletteMenu; } set { Model.FontPaletteMenu = value; } }
        // font palette variables
        private int currentColor = 0;
        private int currentColorBack = 0;
        private int currentPixel = 0;
        public FontCharacter[] FontCharacters { get { return font; } set { font = value; } }
        public int FontType { get { return fontType.SelectedIndex; } set { fontType.SelectedIndex = value; } }
        // font character variables
        private int currentFontChar = 0;
        private int overFontChar = 0;
        private byte[] fontBuffer;
        private int zoom = 16;
        private int edit = 0;
        private Bitmap
            fontPaletteImage,
            fontTableImage,
            fontCharacterImage;
        private NewFontTable newFontTable;
        public NewFontTable NewFontTable { get { return newFontTable; } set { newFontTable = value; } }
        private StringCollection keystrokes
        {
            get
            {
                switch (fontType.SelectedIndex)
                {
                    case 0: return Settings.Default.KeystrokesMenu;
                    case 1: return Settings.Default.Keystrokes;
                    case 2: return Settings.Default.KeystrokesDesc;
                    default: return null;
                }
            }
        }
        private Settings settings = Settings.Default;
        private int[] palette
        {
            get
            {
                switch (fontType.SelectedIndex)
                {
                    case 0:
                    case 2: return fontPalettesMenu.Palettes[0];
                    default: return fontPalettesDialogue.Palettes[1];
                }
            }
        }
        public int[] Palette { get { return palette; } }
        // special controls
        #endregion
        #region Functions
        public Fonts(Dialogues dialoguesEditor)
        {
            this.overlay = new Overlay();
            this.dialoguesEditor = dialoguesEditor;

            InitializeComponent();

            updating = true;
            fontType.SelectedIndex = 1;
            InitializeFonts();
            InitializeFontCharacter();
            SetFontPaletteImage();
            SetFontTableImage();
            SetFontCharacterImage();
            updating = false;

            newFontTable = new NewFontTable(this);
            newFontTable.FormClosing += new FormClosingEventHandler(newFontTable_FormClosing);
        }

        public void Reload(Dialogues dialoguesEditor)
        {
            SetFontPaletteImage();
            SetFontTableImage();
            SetFontCharacterImage();
        }
        public void SetToolTips(ToolTip toolTip1)
        {
            // Fonts
            this.fontType.ToolTipText =
                "Select the font type to edit.\n\n" +
                "\"Menu\" font is used in the overworld menu.\n" +
                "\"Dialogue\" font is used in overworld and battle dialogue.\n" +
                "\"Description\" font is used in item and spell descriptions in \n" +
                "the overworld menu.\n" +
                "\"Triangles\" are the option triangles used in overworld \n" +
                "dialogue (as seen in button in the dialogue editor).";

            this.fontWidth.ToolTipText =
                "The width of the character, in pixels, as drawn in-game.";

            toolTip1.SetToolTip(this.pictureBoxFontTable,
                "Click character to edit.");

            newFontTable.SetToolTips(toolTip1);
        }
        private void InitializeFonts()
        {
            updating = true;

            switch (fontType.SelectedIndex)
            {
                case 0: fontWidth.Enabled = true; fontWidth.Maximum = 8; break;
                case 1: fontWidth.Enabled = true; fontWidth.Maximum = 16; break;
                case 2: fontWidth.Enabled = true; fontWidth.Maximum = 8; break;
                case 3: fontWidth.Enabled = false; break;
            }
            InitializeFontCharacter();

            updating = false;
        }
        private void InitializeFontCharacter()
        {
            updating = true;
            if (fontType.SelectedIndex < 3)
            {
                charKeystroke.Text = keystrokes[currentFontChar + 32];
                fontWidth.Value = font[currentFontChar].Width;
            }
            updating = false;
        }
        public void RedrawText()
        {
            SetFontTableImage();
            SetFontCharacterImage();
            dialoguesEditor.RedrawText();
        }
        public void Assemble()
        {
            fontPalettesDialogue.Assemble();
            fontPalettesMenu.Assemble();
            Bits.SetBit(Model.Data, 0x3E2D6C, 7, true);
            Bits.SetBit(Model.Data, 0x3E2D74, 7, true);

            foreach (FontCharacter f in fontMenu) f.Assemble();
            foreach (FontCharacter f in fontDialogue) f.Assemble();
            foreach (FontCharacter f in fontDescription) f.Assemble();
            foreach (FontCharacter f in fontTriangle) f.Assemble();

            Bits.SetByteArray(data, 0x3DF000, Model.DialogueGraphics, 0, 0x700);
            Bits.SetByteArray(data, 0x015943, Model.BattleDialogueTileSet, 0, 0x100);
        }
        // set images
        private void SetFontPaletteImage()
        {
            fontPaletteImage = new Bitmap(Do.PixelsToImage(Do.PaletteToPixels(palette, 16, 16, 16, 1), 256, 16));
            colors.Invalidate();
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
                    palette = fontPalettesDialogue.Palettes[1];
                    for (int x = 0; x < 7; x++) // left-right triangles
                        CopyOverCharTile(fontTriangle[x].GetCharacterPixels(palette), pixels, 112, x * 2, 0);
                    for (int x = 0; x < 7; x++) // up-down triangles
                        CopyOverCharTile(fontTriangle[x + 7].GetCharacterPixels(palette), pixels, 112, x, 2);
                    break;
                default:
                    palette = this.palette;
                    for (int y = 0; y < vspan; y++)
                    {
                        for (int x = 0; x < hspan; x++)
                            CopyOverCharTile(font[y * hspan + x].GetCharacterPixels(palette), pixels, 128, x, y);
                    }
                    break;
            }

            pictureBoxFontTable.Width = width;
            pictureBoxFontTable.Height = height;
            fontTableImage = new Bitmap(Do.PixelsToImage(pixels, width, height));
            if (fontType.SelectedIndex == 3)
                pictureBoxFontTable.BackColor = Color.FromArgb(palette[0]);
            else
                pictureBoxFontTable.BackColor = Color.FromArgb(palette[3]);
            pictureBoxFontTable.Invalidate();
        }
        private void SetFontCharacterImage()
        {
            int width = 0, height = 0, maxWidth = 0;
            int[] temp, pixels;
            int[] palette = this.palette;
            switch (fontType.SelectedIndex)
            {
                case 0:
                    width = fontMenu[currentFontChar].Width; height = 12;
                    maxWidth = 8;
                    temp = fontMenu[currentFontChar].GetCharacterPixels(palette);
                    break;
                case 1:
                    width = fontDialogue[currentFontChar].Width; height = 12;
                    maxWidth = 16;
                    temp = fontDialogue[currentFontChar].GetCharacterPixels(palette);
                    break;
                case 2:
                    width = fontDescription[currentFontChar].Width; height = 8;
                    maxWidth = 8;
                    temp = fontDescription[currentFontChar].GetCharacterPixels(palette);
                    break;
                default:
                    maxWidth = width = currentFontChar < 7 ? 8 : 16;
                    height = currentFontChar < 7 ? 16 : 8;
                    palette = fontPalettesDialogue.Palettes[1];
                    temp = fontTriangle[currentFontChar].GetCharacterPixels(palette);
                    break;
            }
            pixels = new int[width * height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                    pixels[y * width + x] = temp[y * maxWidth + x];
            }

            if (fontType.SelectedIndex == 3)
                pictureBoxFontCharacter.BackColor = Color.FromArgb(palette[0]);
            else
                pictureBoxFontCharacter.BackColor = Color.FromArgb(palette[3]);
            if (width == 0)
                fontCharacterImage = null;
            else
                fontCharacterImage = new Bitmap(Do.PixelsToImage(pixels, width, height));
            pictureBoxFontCharacter.Width = width * zoom;
            pictureBoxFontCharacter.Height = height * zoom;
            pictureBoxFontCharacter.Invalidate();
        }
        // drawing
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
        private void Delete()
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
            dialoguesEditor.RedrawText();
        }
        private void Copy()
        {
            fontBuffer = new byte[font[currentFontChar].Graphics.Length];
            font[currentFontChar].Graphics.CopyTo(fontBuffer, 0);
        }
        private void Paste()
        {
            if (fontBuffer == null) return;
            font[currentFontChar].Graphics = fontBuffer;
            SetFontCharacterImage();
            SetFontTableImage();
            dialoguesEditor.RedrawText();
        }
        #endregion
        #region Event handlers
        private void fontType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;

            currentFontChar = 0;

            updating = true;
            fontWidth.Enabled = fontType.SelectedIndex != 3;
            charKeystroke.Enabled = fontType.SelectedIndex != 3;
            openKeystrokes.Enabled = fontType.SelectedIndex != 3;
            saveKeystrokes.Enabled = fontType.SelectedIndex != 3;
            openNewFontTable.Enabled = fontType.SelectedIndex != 3;
            if (fontType.SelectedIndex == 3)
                charKeystroke.Text = "";
            updating = false;

            InitializeFonts();
            SetFontPaletteImage();
            SetFontTableImage();
            SetFontCharacterImage();
            if (fontType.SelectedIndex < 3)
                newFontTable.Reload();
            else
                newFontTable.Hide();
        }
        private void pictureBoxFontTable_Paint(object sender, PaintEventArgs e)
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
            if (showGrid.Checked && fontType.SelectedIndex != 3)
                overlay.DrawCartesianGrid(e.Graphics, Color.Gray, new Size(fontTableImage.Width, fontTableImage.Height), s, 1);
        }
        private void pictureBoxFontTable_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBoxFontTable.Focus();

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
        private void pictureBoxFontTable_MouseMove(object sender, MouseEventArgs e)
        {
            indexLabel.BringToFront();
            indexLabel.Left = e.X + 30;
            indexLabel.Top = e.Y + 35;
            switch (fontType.SelectedIndex)
            {
                case 0: overFontChar = e.Y / 12 * 16 + (e.X / 8) + 32; break;
                case 1: overFontChar = e.Y / 12 * 8 + (e.X / 16) + 32; break;
                case 2: overFontChar = e.Y / 8 * 16 + (e.X / 8) + 32; break;
                case 3: if (e.X > 112) return; overFontChar = e.Y / 16 * 7 + (e.X / 16); break;
            }
            indexLabel.Text = "[" + overFontChar + "]";
            Do.AutoSizeLabel(indexLabel);
        }
        private void pictureBoxFontTable_MouseEnter(object sender, EventArgs e)
        {
            indexLabel.Show();
        }
        private void pictureBoxFontTable_MouseLeave(object sender, EventArgs e)
        {
            indexLabel.Hide();
        }
        private void pictureBoxFontCharacter_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            Rectangle rsrc = new Rectangle(0, 0, fontCharacterImage.Width, fontCharacterImage.Height);
            Rectangle rdst = new Rectangle(0, 0, fontCharacterImage.Width * zoom, fontCharacterImage.Height * zoom);

            if (showBG.Checked)
                e.Graphics.Clear(Color.FromArgb(palette[0]));
            if (e.ClipRectangle.Size != new Size(1 * zoom, 1 * zoom))
                if (fontCharacterImage != null)
                    e.Graphics.DrawImage(fontCharacterImage, rdst, rsrc, GraphicsUnit.Pixel);

            if (showGrid.Checked && zoom >= 4)
                overlay.DrawCartesianGrid(e.Graphics, Color.Gray, new Size(fontCharacterImage.Width * zoom, fontCharacterImage.Height * zoom), new Size(1, 1), zoom);
        }
        private void pictureBoxFontCharacter_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxFontCharacter_MouseMove(sender, e);
        }
        private void pictureBoxFontCharacter_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.None) return;
            int x = e.X; int y = e.Y;
            if (x >= pictureBoxFontCharacter.Width ||
                y >= pictureBoxFontCharacter.Height ||
                x < 0 || y < 0)
                return;
            string action = "";
            if ((e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) && fontEditDraw.Checked)
                action = "draw";
            else if ((e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) && fontEditErase.Checked)
                action = "erase";
            else if ((e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) && fontEditChoose.Checked)
                action = "select";
            else if ((e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) && fontEditFill.Checked)
                action = "fill";
            int color = currentColor;
            if (e.Button == MouseButtons.Right)
                color = currentColorBack;

            int index = y / (8 * zoom);
            int srcOffset = (x / (8 * zoom)) * 24;
            color = Do.EditPixelBPP(
                font[currentFontChar].Graphics, srcOffset, palette,
                pictureBoxFontCharacter.CreateGraphics(), zoom, action,
                ((x / zoom) & 7) * zoom, ((y / zoom) & 7) * zoom, index, color,
                font[currentFontChar].MaxWidth, font[currentFontChar].Height, 0x10,
                ((x / zoom) & 8) * zoom, ((y / zoom) & 8) * zoom);
            if (action == "erase")
                pictureBoxFontCharacter.Invalidate(new Rectangle(x / zoom * zoom, y / zoom * zoom, 1 * zoom, 1 * zoom));

            currentPixel = (x / zoom) + (y / zoom);
            if (e.Button == MouseButtons.Left)
                currentColor = color;
            else if (e.Button == MouseButtons.Right)
                currentColorBack = color;
            colors.Invalidate();
        }
        private void pictureBoxFontCharacter_MouseUp(object sender, MouseEventArgs e)
        {
            SetFontCharacterImage();
            SetFontTableImage();
            dialoguesEditor.RedrawText();
        }
        private void openKeystrokes_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = settings.LastRomPath;
            openFileDialog1.Title = "Load keystroke table";
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            string path = openFileDialog1.FileName;
            StreamReader sr = new StreamReader(path);
            string line;
            for (int i = 32; i < keystrokes.Count && (line = sr.ReadLine()) != null; i++)
            {
                if (line.Length > 1)
                {
                    MessageBox.Show("There was a problem opening the keystroke table.\n" +
                        "One or more of the assigned keystrokes has an invalid length.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                keystrokes[i] = line;
            }
            keystrokes[0x20] = "\x20";
        }
        private void saveKeystrokes_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            switch (fontType.SelectedIndex)
            {
                case 0: saveFileDialog.FileName = Model.GetFileNameWithoutPath() + " - keystrokesMenu.txt"; break;
                case 1: saveFileDialog.FileName = Model.GetFileNameWithoutPath() + " - keystrokesDialogue.txt"; break;
                case 2: saveFileDialog.FileName = Model.GetFileNameWithoutPath() + " - keystrokesDescriptions.txt"; break;
            }
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "Save keystroke table";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            StreamWriter sr = new StreamWriter(saveFileDialog.FileName);
            for (int i = 32; i < keystrokes.Count; i++)
            {
                string s = keystrokes[i];
                sr.WriteLine(s);
            }
            sr.Close();
        }
        private void openNewFontTable_Click(object sender, EventArgs e)
        {
            if (fontType.SelectedIndex < 3)
                newFontTable.Show();
        }
        private void newFontTable_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            newFontTable.Hide();
        }
        private void reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current font character. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            font[currentFontChar] = new FontCharacter(Model.Data, currentFontChar, fontType.SelectedIndex);
            InitializeFontCharacter();
            SetFontCharacterImage();
            SetFontTableImage();
            dialoguesEditor.RedrawText();
        }
        private void fontWidth_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            font[currentFontChar].Width = (byte)fontWidth.Value;
            SetFontCharacterImage();
            SetFontTableImage();
            dialoguesEditor.RedrawText();
        }
        private void showGrid_Click(object sender, EventArgs e)
        {
            pictureBoxFontTable.Invalidate();
            pictureBoxFontCharacter.Invalidate();
        }
        private void colors_Paint(object sender, PaintEventArgs e)
        {
            if (fontPaletteImage != null)
                e.Graphics.DrawImage(fontPaletteImage, 0, 0);
            e.Graphics.DrawRectangle(new Pen(Color.Red), currentColor * 16, 0, 15, 15);
        }
        private void colors_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X >= 64) return;
            currentColor = e.X / 16;
            colors.Invalidate();
        }
        private void showBG_Click(object sender, EventArgs e)
        {
            pictureBoxFontCharacter.Invalidate();
        }
        private void fontEditDraw_Click(object sender, EventArgs e)
        {
            fontEditErase.Checked = false;
            fontEditChoose.Checked = false;
            fontEditFill.Checked = false;
            fontEditZoomIn.Checked = false;
            fontEditZoomOut.Checked = false;
            edit = fontEditDraw.Checked ? 1 : 0;
            pictureBoxFontCharacter.Cursor = edit == 1 ? new Cursor(GetType(), "CursorDraw.cur") : Cursors.Arrow;
        }
        private void fontEditErase_Click(object sender, EventArgs e)
        {
            fontEditDraw.Checked = false;
            fontEditChoose.Checked = false;
            fontEditFill.Checked = false;
            fontEditZoomIn.Checked = false;
            fontEditZoomOut.Checked = false;
            edit = fontEditErase.Checked ? 2 : 0;
            pictureBoxFontCharacter.Cursor = edit == 2 ? new Cursor(GetType(), "CursorErase.cur") : Cursors.Arrow;
        }
        private void fontEditChoose_Click(object sender, EventArgs e)
        {
            fontEditDraw.Checked = false;
            fontEditErase.Checked = false;
            fontEditFill.Checked = false;
            fontEditZoomIn.Checked = false;
            fontEditZoomOut.Checked = false;
            edit = fontEditChoose.Checked ? 3 : 0;
            pictureBoxFontCharacter.Cursor = edit == 3 ? new Cursor(GetType(), "CursorDropper.cur") : Cursors.Arrow;
        }
        private void fontEditFill_Click(object sender, EventArgs e)
        {
            fontEditDraw.Checked = false;
            fontEditErase.Checked = false;
            fontEditChoose.Checked = false;
            fontEditZoomIn.Checked = false;
            fontEditZoomOut.Checked = false;
            edit = fontEditFill.Checked ? 4 : 0;
            pictureBoxFontCharacter.Cursor = edit == 4 ? new Cursor(GetType(), "CursorFill.cur") : Cursors.Arrow;
        }
        private void fontEditZoomIn_Click(object sender, EventArgs e)
        {
            if (zoom >= 16) return;
            zoom *= 2;
            pictureBoxFontCharacter.Width *= 2;
            pictureBoxFontCharacter.Height *= 2;
            pictureBoxFontCharacter.Invalidate();
        }
        private void fontEditZoomOut_Click(object sender, EventArgs e)
        {
            if (zoom <= 1) return;
            zoom /= 2;
            pictureBoxFontCharacter.Width /= 2;
            pictureBoxFontCharacter.Height /= 2;
            pictureBoxFontCharacter.Invalidate();
        }
        private void fontEditDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void fontEditCopy_Click(object sender, EventArgs e)
        {
            Copy();
        }
        private void fontEditPaste_Click(object sender, EventArgs e)
        {
            Paste();
        }
        private void fontEditMirror_Click(object sender, EventArgs e)
        {
            FontCharacter chr = font[currentFontChar];
            int maxY = chr.GetBottomMostPixel(palette);
            int maxX = chr.GetRightMostPixel(palette);
            int minY = chr.GetTopMostPixel(palette);
            int minX = chr.GetLeftMostPixel(palette);
            for (int y = minY; y < maxY + 1; y++)
            {
                for (int a = minX, b = maxX; a < b; a++, b--)
                {
                    byte rowA = (byte)y;
                    byte colA = (byte)a;
                    byte bitA = (byte)((colA & 7) ^ 7);
                    int offsetA = rowA * 2;
                    byte rowB = (byte)y;
                    byte colB = (byte)b;
                    byte bitB = (byte)((colB & 7) ^ 7);
                    int offsetB = rowB * 2;
                    switch (fontType.SelectedIndex)
                    {
                        case 0:
                        case 2:
                            bool tempM = Bits.GetBit(chr.Graphics, offsetA, bitA);
                            bool tempN = Bits.GetBit(chr.Graphics, offsetA + 1, bitA);
                            Bits.SetBit(chr.Graphics, offsetA, bitA, Bits.GetBit(chr.Graphics, offsetB, bitB));
                            Bits.SetBit(chr.Graphics, offsetA + 1, bitA, Bits.GetBit(chr.Graphics, offsetB + 1, bitB));
                            Bits.SetBit(chr.Graphics, offsetB, bitB, tempM);
                            Bits.SetBit(chr.Graphics, offsetB + 1, bitB, tempN);
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
            dialoguesEditor.RedrawText();
        }
        private void fontEditInvert_Click(object sender, EventArgs e)
        {
            FontCharacter chr = font[currentFontChar];
            int maxY = chr.GetBottomMostPixel(palette);
            int maxX = chr.GetRightMostPixel(palette);
            int minY = chr.GetTopMostPixel(palette);
            int minX = chr.GetLeftMostPixel(palette);
            for (int x = minX; x < maxX + 1; x++)
            {
                for (int a = minY, b = maxY; a < b; a++, b--)
                {
                    byte rowA = (byte)a;
                    byte colA = (byte)x;
                    byte bitA = (byte)((colA & 7) ^ 7);
                    int offsetA = rowA * 2;
                    byte rowB = (byte)b;
                    byte colB = (byte)x;
                    byte bitB = (byte)((colB & 7) ^ 7);
                    int offsetB = rowB * 2;
                    switch (fontType.SelectedIndex)
                    {
                        case 0:
                        case 2:
                            bool tempM = Bits.GetBit(chr.Graphics, offsetA, bitA);
                            bool tempN = Bits.GetBit(chr.Graphics, offsetA + 1, bitA);
                            Bits.SetBit(chr.Graphics, offsetA, bitA, Bits.GetBit(chr.Graphics, offsetB, bitB));
                            Bits.SetBit(chr.Graphics, offsetA + 1, bitA, Bits.GetBit(chr.Graphics, offsetB + 1, bitB));
                            Bits.SetBit(chr.Graphics, offsetB, bitB, tempM);
                            Bits.SetBit(chr.Graphics, offsetB + 1, bitB, tempN);
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
            dialoguesEditor.RedrawText();
        }
        // contextmenustrip1
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = settings.LastRomPath;
            openFileDialog1.Title = "Import font graphics";
            openFileDialog1.Filter = "Image files (*.bmp,*.png,*.gif,*.jpg)|*.bmp;*.png;*.gif;*.jpg|Binary files (*.bin)|*.bin|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            FileStream fs;
            BinaryReader br;
            Bitmap import;
            byte[] graphicBlock;
            int[] palette = new int[4];
            fs = File.OpenRead(openFileDialog1.FileName);
            if (Path.GetExtension(openFileDialog1.FileName) == ".jpg" ||
                Path.GetExtension(openFileDialog1.FileName) == ".gif" ||
                Path.GetExtension(openFileDialog1.FileName) == ".png")
            {
                for (int i = 0; i < 4; i++)
                    palette[i] = this.palette[i];
                import = new Bitmap(Image.FromFile(openFileDialog1.FileName));
                graphicBlock = new byte[(import.Width * import.Height) / 4];
                Do.PixelsToBPP(
                    Do.ImageToPixels(import, new Size(import.Width, import.Height)),
                    graphicBlock, new Size(import.Width / 8, import.Height / 8), palette, 0x10);
                switch (fontType.SelectedIndex)
                {
                    case 0:
                        Do.CopyOverFontTable(graphicBlock, font, new Size(import.Width / 8, import.Height / 12), palette);
                        break;
                    case 1:
                        Do.CopyOverFontTable(graphicBlock, font, new Size(import.Width / 16, import.Height / 12), palette);
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
                            Array.Copy(graphicBlock, f.Index * 0x18, f.Graphics, 0, 0x18);
                        break;
                    case 1:
                        graphicBlock = new byte[0x1800];
                        graphicBlock = br.ReadBytes(0x1800);
                        foreach (FontCharacter f in fontDialogue)
                            Array.Copy(graphicBlock, f.Index * 0x30, f.Graphics, 0, 0x30);
                        break;
                    case 2:
                        graphicBlock = new byte[0x800];
                        graphicBlock = br.ReadBytes(0x800);
                        foreach (FontCharacter f in fontDescription)
                            Array.Copy(graphicBlock, f.Index * 0x10, f.Graphics, 0, 0x10);
                        break;
                    case 3:
                        graphicBlock = new byte[0x1C0];
                        graphicBlock = br.ReadBytes(0x1C0);
                        foreach (FontCharacter f in fontTriangle)
                            Array.Copy(graphicBlock, f.Index * 0x20, f.Graphics, 0, 0x20);
                        break;
                }
                br.Close();
            }
            fs.Close();
            SetFontPaletteImage();
            SetFontTableImage();
            SetFontCharacterImage();
            dialoguesEditor.RedrawText();
        }
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
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
            catch
            {
                MessageBox.Show("There was a problem exporting the font graphics.");
            }
        }
        private void saveImageAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (fontType.SelectedIndex)
            {
                case 0: Do.Export(fontTableImage, "fontTableMenu.png"); break;
                case 1: Do.Export(fontTableImage, "fontTableDialogue.png"); break;
                case 2: Do.Export(fontTableImage, "fontTableDescription.png"); break;
                case 3: Do.Export(fontTableImage, "fontTableTriangles.png"); break;
            }
        }
        private void insertIntoTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (keystrokes == null) return;
            if (keystrokes[overFontChar] == "")
                dialoguesEditor.InsertIntoDialogueText("[" + overFontChar + "]");
            else
                dialoguesEditor.InsertIntoDialogueText(keystrokes[overFontChar]);
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            insertIntoTextToolStripMenuItem.Enabled = fontType.SelectedIndex != 3;
        }
        #endregion
    }
}
