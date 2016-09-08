using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using LazyShell.Properties;
using LazyShell.Undo;

namespace LazyShell.Fonts
{
    public partial class OwnerForm : Controls.NewForm
    {
        #region Variables

        // Index
        public FontType FontType
        {
            get { return (FontType)fontType.SelectedIndex; }
            set { fontType.SelectedIndex = (int)value; }
        }

        // ROM buffer
        private byte[] rom
        {
            get { return Model.ROM; }
            set { Model.ROM = value; }
        }

        // Settings
        private Settings settings;

        // Forms
        public NewFontTable NewFontTable { get; set; }
        private Dialogues.OwnerForm dialoguesForm
        {
            get { return LazyShell.Model.Program.Dialogues; }
            set { LazyShell.Model.Program.Dialogues = value; }
        }
        private GraphicEditor numeralGraphicEditor;
        private PaletteEditor numeralPaletteEditor;
        private GraphicEditor menuGraphicEditor;
        private PaletteEditor menuPaletteEditor;
        private GraphicEditor fontGraphicEditor;
        private delegate void UpdateFunction();

        // Elements
        public Glyph[] Glyphs
        {
            get
            {
                switch (FontType)
                {
                    case FontType.Menu: return font_menu;
                    case FontType.Dialogue: return font_dialogue;
                    case FontType.Description: return font_description;
                    case FontType.BattleMenu: return font_battleMenu;
                    default: return font_triangle;
                }
            }
            set
            {
                switch (FontType)
                {
                    case FontType.Menu: font_menu = value; break;
                    case FontType.Dialogue: font_dialogue = value; break;
                    case FontType.Description: font_description = value; break;
                    case FontType.BattleMenu: font_battleMenu = value; break;
                    default: font_triangle = value; break;
                }
            }
        }
        private Glyph[] font_menu
        {
            get { return Model.Menu; }
            set { Model.Menu = value; }
        }
        private Glyph[] font_dialogue
        {
            get { return Model.Dialogue; }
            set { Model.Dialogue = value; }
        }
        private Glyph[] font_description
        {
            get { return Model.Description; }
            set { Model.Description = value; }
        }
        private Glyph[] font_triangle
        {
            get { return Model.Triangle; }
            set { Model.Triangle = value; }
        }
        private Glyph[] font_battleMenu
        {
            get { return Model.BattleMenu; }
            set { Model.BattleMenu = value; }
        }
        private PaletteSet palette_dialogue
        {
            get { return Model.Palette_Dialogue; }
            set { Model.Palette_Dialogue = value; }
        }
        private PaletteSet palette_menu
        {
            get { return Model.Palette_Menu; }
            set { Model.Palette_Menu = value; }
        }
        private PaletteSet palette_battle
        {
            get { return Model.Palette_BattleMenu; }
            set { Model.Palette_BattleMenu = value; }
        }
        public int[] Palette
        {
            get
            {
                switch (FontType)
                {
                    case FontType.Menu:
                    case FontType.Description: return palette_menu.Palettes[0];
                    case FontType.BattleMenu: return palette_battle.Palettes[0];
                    default: return palette_dialogue.Palettes[1];
                }
            }
        }
        private PaletteSet paletteSet
        {
            get
            {
                switch (FontType)
                {
                    case FontType.Menu:
                    case FontType.Description: return palette_menu;
                    case FontType.BattleMenu: return palette_battle;
                    default: return palette_dialogue;
                }
            }
        }
        private int paletteRow
        {
            get
            {
                switch (FontType)
                {
                    case FontType.Dialogue: return 1;
                    case FontType.Menu: return 0;
                    case FontType.Description: return 0;
                    case FontType.Triangles: return 1;
                    default: return 0;
                }
            }
        }
        private int paletteCol
        {
            get
            {
                if (FontType == FontType.Triangles)
                    return 4;
                return 0;
            }
        }
        private byte format
        {
            get
            {
                if (FontType == FontType.Triangles)
                    return 0x20;
                else
                    return 0x10;
            }
        }
        private string[] keystrokes
        {
            get
            {
                switch (FontType)
                {
                    case FontType.Menu: return Lists.KeystrokesMenu;
                    case FontType.Dialogue: return Lists.Keystrokes;
                    case FontType.Description: return Lists.KeystrokesDesc;
                    default: return null;
                }
            }
        }

        // Picture
        private Overlay overlay;
        private Bitmap fontTableImage;
        private int currentGlyph = 0;
        private int overGlyph = 0;
        private int zoom = 1;

        #endregion

        // Constructors
        public OwnerForm()
        {
            InitializeVariables();
            InitializeComponent();
            InitializeNavigators();
            InitializeFont();
            SetFontTableImage();
        }
        public void Reload()
        {
            SetFontTableImage();
            ReloadFontGraphicEditor();
        }

        #region Methods

        // Initialization
        private void InitializeNavigators()
        {
            this.Updating = true;
            //
            FontType = FontType.Dialogue;
            //
            this.Updating = false;
        }
        private void InitializeVariables()
        {
            this.overlay = new Overlay();
            settings = Settings.Default;
        }
        private void InitializeFont()
        {
            this.Updating = true;
            //
            switch (FontType)
            {
                case FontType.Menu:
                    fontWidth.Enabled = true;
                    fontWidth.Maximum = 8;
                    break;
                case FontType.Dialogue:
                    fontWidth.Enabled = true;
                    fontWidth.Maximum = 16;
                    break;
                case FontType.Description:
                    fontWidth.Enabled = true;
                    fontWidth.Maximum = 8;
                    break;
                default:
                    fontWidth.Enabled = false;
                    break;
            }
            InitializeGlyph();
            InitializeKeystrokes();
            //
            this.Updating = false;
        }
        private void InitializeKeystrokes()
        {
            if (FontType >= FontType.Triangles)
                return;
            if (fontTable.Controls.Count > 0)
            {
                LoadKeystrokes();
                return;
            }
            this.Updating = true;
            //
            fontTable.SuspendDrawing();
            fontTable.Controls.Clear();
            TextBox keyBox;
            for (int y = 16; y >= 0; y--)
            {
                for (int x = 0; x < 8; x++)
                {
                    int index = y * 8 + x;
                    keyBox = new TextBox();
                    keyBox.BackColor = Color.FromArgb(Palette[3]);
                    keyBox.BorderStyle = BorderStyle.None;
                    keyBox.ForeColor = Color.FromArgb(Palette[1]);
                    keyBox.Height = 12;
                    keyBox.Left = x * 16;
                    keyBox.MaxLength = 1;
                    keyBox.Size = new Size(16, 12);
                    keyBox.TabIndex = y * 8 + x;
                    keyBox.Tag = index;
                    keyBox.Text = keystrokes[index + 32];
                    keyBox.Top = y * 12;
                    keyBox.Enter += new EventHandler(keyBox_Enter);
                    keyBox.MouseDown += new MouseEventHandler(keyBox_MouseDown);
                    keyBox.MouseMove += new MouseEventHandler(keyBox_MouseMove);
                    keyBox.MouseUp += new MouseEventHandler(keyBox_MouseUp);
                    keyBox.TextChanged += new EventHandler(keyBox_TextChanged);
                    //
                    fontTable.Controls.Add(keyBox);
                    keyBox.BringToFront();
                }
            }
            fontTable.ResumeDrawing();
            //
            this.Updating = false;
        }
        private void InitializeGlyph()
        {
            this.Updating = true;
            //
            if (FontType < FontType.Triangles)
                fontWidth.Value = Glyphs[currentGlyph].Width;
            ReloadFontGraphicEditor();
            //
            this.Updating = false;
        }
        private void LoadKeystrokes()
        {
            this.Updating = true;
            fontTable.SuspendDrawing();
            //
            foreach (TextBox keyBox in fontTable.Controls)
            {
                int index = (int)keyBox.Tag;
                keyBox.BackColor = Color.FromArgb(Palette[3]);
                keyBox.ForeColor = Color.FromArgb(Palette[1]);
                keyBox.Text = keystrokes[index + 32];
            }
            //
            fontTable.ResumeDrawing();
            this.Updating = false;
        }
        public void RedrawText()
        {
            SetFontTableImage();
            LoadFontGraphicEditor();
            if (dialoguesForm != null)
                dialoguesForm.DialoguesForm.SetTextImage();
        }

        // Saving
        public void WriteToROM()
        {
            palette_dialogue.WriteToBuffer();
            palette_menu.WriteToBuffer();
            Bits.SetBit(Model.ROM, 0x3E2D6C, 7, true);
            Bits.SetBit(Model.ROM, 0x3E2D74, 7, true);
            foreach (Glyph f in font_menu) f.WriteToROM();
            foreach (Glyph f in font_dialogue) f.WriteToROM();
            foreach (Glyph f in font_description) f.WriteToROM();
            foreach (Glyph f in font_triangle) f.WriteToROM();
            Bits.SetBytes(rom, 0x3DF000, Dialogues.Model.Graphics, 0, 0x700);
            Bits.SetBytes(rom, 0x015943, Dialogues.Model.Tileset_bytes, 0, 0x100);
            //
            Bits.SetBytes(rom, 0x03F800, Model.Graphics_Numerals, 0, 0x400);
            Model.Palette_Numerals.WriteToBuffer();
            Buffer.BlockCopy(Model.Graphics_BattleMenu, 0, rom, 0x1F200, 0x600);
            Buffer.BlockCopy(Model.Graphics_BattleMenu, 0x600, rom, 0x1ED00, 0x140);
            Model.Palette_BattleMenu.WriteToBuffer();
        }

        // Set images
        private void SetFontTableImage()
        {
            int[] pixels = null;
            int[] palette = this.Palette;
            int width = 0, height = 0;
            switch (FontType)
            {
                case FontType.Menu:
                case FontType.Description:
                case FontType.Dialogue:
                    width = 128; height = 192;
                    pixels = Do.DrawFontTable(Glyphs, palette, 128, 192, 16, 12, 8, 16);
                    break;
                case FontType.Triangles:
                    width = 112; height = 32;
                    pixels = new int[112 * height];
                    palette = palette_dialogue.Palettes[1];
                    for (int x = 0; x < 7; x++) // left-right triangles
                        Do.PixelsToPixels(font_triangle[x].GetPixels(palette), pixels, 112, x * 32, 0, 8, 16, true);
                    for (int x = 0; x < 7; x++) // up-down triangles
                        Do.PixelsToPixels(font_triangle[x + 7].GetPixels(palette), pixels, 112, x * 16, 16, 16, 8, true);
                    break;
            }
            if (toggleFontBorder.Checked)
            {
                if (FontType == FontType.BattleMenu)
                    Do.DrawBorder(pixels, width, palette[1]);
                else if (FontType != FontType.Triangles)
                    Do.DrawBorder(pixels, width, palette[3]);
            }
            picture.Width = width * zoom;
            picture.Height = height * zoom;
            fontTableImage = Do.PixelsToImage(pixels, width, height);
            picture.Invalidate();
        }

        // Loading
        private void LoadNumeralGraphicEditor()
        {
            if (numeralGraphicEditor == null)
            {
                numeralGraphicEditor = new GraphicEditor(new GraphicUpdater(),
                    Model.Graphics_Numerals, Model.Graphics_Numerals.Length, 0, Model.Palette_Numerals, 0, 0x20);
                numeralGraphicEditor.Owner = this;
            }
            else
                ReloadNumeralGraphicEditor();
        }
        private void LoadNumeralPaletteEditor()
        {
            if (numeralPaletteEditor == null)
            {
                numeralPaletteEditor = new PaletteEditor(new PaletteUpdater(), Model.Palette_Numerals, 2, 0, 2);
                numeralPaletteEditor.Owner = this;
            }
            else
                ReloadNumeralPaletteEditor();
        }
        private void LoadMenuGraphicEditor()
        {
            if (menuGraphicEditor == null)
            {
                menuGraphicEditor = new GraphicEditor(new GraphicMenuUpdater(),
                    Model.Graphics_BattleMenu, Model.Graphics_BattleMenu.Length, 0, Model.Palette_BattleMenu, 0, 0x20);
                menuGraphicEditor.Owner = this;
            }
            else
                ReloadMenuGraphicEditor();
        }
        private void LoadMenuPaletteEditor()
        {
            if (menuPaletteEditor == null)
            {
                menuPaletteEditor = new PaletteEditor(new PaletteMenuUpdater(), Model.Palette_BattleMenu, 2, 0, 2);
                menuPaletteEditor.Owner = this;
            }
            else
                ReloadMenuPaletteEditor();
        }
        private void LoadFontGraphicEditor()
        {
            if (fontGraphicEditor == null)
            {
                fontGraphicEditor = new GraphicEditor(new GraphicFontUpdater(),
                    Glyphs[currentGlyph], paletteSet, paletteRow, paletteCol, 0x10);
                fontGraphicEditor.SetControlSizes(Glyphs[currentGlyph].Width, Glyphs[currentGlyph].Height,
                    Glyphs[currentGlyph].MaxWidth / 8, Glyphs[currentGlyph].Height / 8);
                fontGraphicEditor.Owner = this;
                fontGraphicEditor.ZoomIn();
            }
            else
                ReloadFontGraphicEditor();
        }
        private void LoadNewFontTable()
        {
            if (NewFontTable == null)
                NewFontTable = new NewFontTable(this);
            else
                ReloadNewFontTable();
        }
        private void ReloadNumeralGraphicEditor()
        {
            if (numeralGraphicEditor != null)
                numeralGraphicEditor.Reload(Model.Graphics_Numerals, Model.Graphics_Numerals.Length, 0, Model.Palette_Numerals, 0, 0x20);
        }
        private void ReloadNumeralPaletteEditor()
        {
            if (numeralPaletteEditor != null)
                numeralPaletteEditor.Reload(Model.Palette_Numerals, 2, 0, 2);
        }
        private void ReloadMenuGraphicEditor()
        {
            if (menuGraphicEditor != null)
                menuGraphicEditor.Reload(Model.Graphics_BattleMenu, Model.Graphics_BattleMenu.Length, 0, Model.Palette_BattleMenu, 0, 0x20);
        }
        private void ReloadMenuPaletteEditor()
        {
            if (menuPaletteEditor != null)
                menuPaletteEditor.Reload(Model.Palette_BattleMenu, 2, 0, 2);
        }
        private void ReloadFontGraphicEditor()
        {
            if (fontGraphicEditor != null)
            {
                fontGraphicEditor.Reload(Glyphs[currentGlyph], paletteSet, paletteRow, paletteCol, 0x10);
                fontGraphicEditor.SetControlSizes(Glyphs[currentGlyph].Width, Glyphs[currentGlyph].Height,
                    Glyphs[currentGlyph].MaxWidth / 8, Glyphs[currentGlyph].Height / 8);
            }
        }
        private void ReloadNewFontTable()
        {
            if (NewFontTable != null)
                NewFontTable.Reload();
        }
        private void ShowEditorForm(Form form)
        {
            if (!form.Visible)
                form.Location = new Point(Cursor.Position.X + 20, Cursor.Position.Y + 20);
            form.Show();
        }

        // Updating
        public void UpdateGraphics()
        {
        }
        public void UpdatePalettes()
        {
            ReloadNumeralGraphicEditor();
            this.Modified = true;
        }
        public void UpdateGraphicsMenu()
        {
        }
        public void UpdatePalettesMenu()
        {
            ReloadMenuGraphicEditor();
            this.Modified = true;
        }
        public void UpdateGraphicsFont()
        {
            ReloadFontGraphicEditor();
            SetFontTableImage();
            //ownerForm.SetTextImages();
            this.Modified = true;
        }

        #endregion

        #region Event handlers

        // Data management
        private void save_Click(object sender, EventArgs e)
        {
            WriteToROM();
        }
        
        // Navigator
        private void fontType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            currentGlyph = 0;
            this.Updating = true;
            fontWidth.Enabled = FontType < FontType.Triangles;
            toggleKeystrokes.Enabled = FontType < FontType.Triangles;
            if (toggleKeystrokes.Checked)
                toggleKeystrokes.Checked = FontType < FontType.Triangles;
            openNewFontTable.Enabled = FontType < FontType.Triangles;
            this.Updating = false;
            InitializeFont();
            SetFontTableImage();
            if (FontType < FontType.Triangles)
                ReloadNewFontTable();
            else
            {
                NewFontTable.Hide();
                toggleKeystrokes.Checked = false;
                picture.Visible = true;
                fontTable.Visible = false;
                fontTable.SendToBack();
            }
        }

        // Editors
        private void openGraphicsNumerals_Click(object sender, EventArgs e)
        {
            LoadNumeralGraphicEditor();
            ShowEditorForm(numeralGraphicEditor);
        }
        private void openGraphicsBattleMenu_Click(object sender, EventArgs e)
        {
            LoadMenuGraphicEditor();
            ShowEditorForm(menuGraphicEditor);
        }
        private void openPalettesNumerals_Click(object sender, EventArgs e)
        {
            LoadNumeralPaletteEditor();
            ShowEditorForm(numeralPaletteEditor);
        }
        private void openPalettesBattleMenu_Click(object sender, EventArgs e)
        {
            LoadMenuPaletteEditor();
            ShowEditorForm(menuPaletteEditor);
        }

        // Picture
        private void picture_Paint(object sender, PaintEventArgs e)
        {
            if (fontTableImage != null)
            {
                e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
                e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                Rectangle dst = new Rectangle(0, 0, picture.Width, picture.Height);
                Rectangle src = new Rectangle(0, 0, picture.Width / zoom, picture.Height / zoom);
                e.Graphics.DrawImage(fontTableImage, dst, src, GraphicsUnit.Pixel);
            }
            Size unit = new Size(16, 12);
            if (toggleTileGrid.Checked && FontType != FontType.Triangles)
                overlay.DrawTileGrid(e.Graphics, Color.Gray, picture.Size, unit, zoom, true, -1);
        }
        private void picture_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X < 0 || e.Y < 0 ||
                e.X >= picture.Width ||
                e.Y >= picture.Height)
                return;
            picture.Focus();
            int before = currentGlyph;
            int x = e.X / zoom;
            int y = e.Y / zoom;
            switch (FontType)
            {
                case FontType.Menu:
                case FontType.Description:
                case FontType.Dialogue: currentGlyph = y / 12 * 8 + (x / 16); break;
                case FontType.Triangles:
                    if (x > 112)
                        return;
                    currentGlyph = y / 16 * 7 + (x / 16); break;
            }
            if (currentGlyph == 59 || currentGlyph == 61)
            {
                MessageBox.Show("Character #91 and #93 cannot be edited because they are reserved for [ and ], respectively.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                currentGlyph = before;
                return;
            }
            InitializeGlyph();
            LoadFontGraphicEditor();
            ShowEditorForm(fontGraphicEditor);
        }
        private void picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < 0 || e.Y < 0 ||
                e.X >= picture.Width ||
                e.Y >= picture.Height)
                return;
            int x = e.X / zoom;
            int y = e.Y / zoom;
            switch (FontType)
            {
                case FontType.Menu:
                case FontType.Description:
                case FontType.Dialogue: overGlyph = y / 12 * 8 + (x / 16) + 32; break;
                case FontType.Triangles: if (x > 112)
                        return; overGlyph = y / 16 * 7 + (x / 16); break;
            }
            indexLabel.Text = "[" + overGlyph + "]";
            if (e.Button == MouseButtons.Left)
                picture_MouseDown(sender, e);
        }
        private void picture_MouseLeave(object sender, EventArgs e)
        {
            indexLabel.Text = "";
        }

        // Toggle
        private void toggleTileGrid_Click(object sender, EventArgs e)
        {
            picture.Invalidate();
        }
        private void toggleFontBorder_Click(object sender, EventArgs e)
        {
            SetFontTableImage();
        }
        private void toggleBG_Click(object sender, EventArgs e)
        {
            picture.Invalidate();
        }
        private void toggleKeystrokes_CheckedChanged(object sender, EventArgs e)
        {
            if (toggleKeystrokes.Checked && LazyShell.Model.CheckLoadedProject())
            {
                picture.Visible = false;
                fontTable.Visible = true;
                fontTable.BringToFront();
            }
            else
            {
                toggleKeystrokes.Checked = false;
                picture.Visible = true;
                fontTable.Visible = false;
                fontTable.SendToBack();
            }
        }
        private void zoomIn_Click(object sender, EventArgs e)
        {
            if (zoom < 4)
            {
                zoom *= 2;
                picture.Size = new Size(picture.Width * 2, picture.Height * 2);
                picture.Invalidate();
            }
        }
        private void zoomOut_Click(object sender, EventArgs e)
        {
            if (zoom > 1)
            {
                zoom /= 2;
                picture.Size = new Size(picture.Width / 2, picture.Height / 2);
                picture.Invalidate();
            }
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
            for (int i = 32; i < keystrokes.Length && (line = sr.ReadLine()) != null; i++)
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
            InitializeKeystrokes();
        }
        private void saveKeystrokes_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            switch (FontType)
            {
                case FontType.Menu: saveFileDialog.FileName = LazyShell.Model.GetFileNameWithoutPath() + " - keystrokesMenu.txt"; break;
                case FontType.Dialogue: saveFileDialog.FileName = LazyShell.Model.GetFileNameWithoutPath() + " - keystrokesDialogue.txt"; break;
                case FontType.Description: saveFileDialog.FileName = LazyShell.Model.GetFileNameWithoutPath() + " - keystrokesDescriptions.txt"; break;
            }
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "Save keystroke table";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            StreamWriter sr = new StreamWriter(saveFileDialog.FileName);
            for (int i = 32; i < keystrokes.Length; i++)
            {
                string s = keystrokes[i];
                sr.WriteLine(s);
            }
            sr.Close();
        }
        private void keyBox_Enter(object sender, EventArgs e)
        {
            (sender as TextBox).SelectAll();
        }
        private void keyBox_MouseMove(object sender, MouseEventArgs e)
        {
            TextBox rtb = sender as TextBox;
            overGlyph = (int)rtb.Tag + 32;
            indexLabel.Text = "[" + overGlyph + "]";
            if (e.Button == MouseButtons.Left)
                keyBox_MouseDown(sender, e);
        }
        private void keyBox_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox rtb = sender as TextBox;
            currentGlyph = (int)rtb.Tag;
            InitializeGlyph();
        }
        private void keyBox_MouseUp(object sender, MouseEventArgs e)
        {
            (sender as TextBox).SelectAll();
        }
        private void keyBox_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            TextBox textBox = sender as TextBox;
            keystrokes[(int)textBox.Tag + 32] = textBox.Text;
        }

        // New font table
        private void openNewFontTable_Click(object sender, EventArgs e)
        {
            if (FontType < FontType.Triangles)
            {
                LoadNewFontTable();
                ShowEditorForm(NewFontTable);
            }
        }

        // Data management
        private void reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current font character. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            Glyphs[currentGlyph] = new Glyph(currentGlyph, FontType);
            InitializeGlyph();
            SetFontTableImage();
            //ownerForm.SetTextImages();
        }

        // Properties
        private void fontWidth_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            Glyphs[currentGlyph].Width = (byte)fontWidth.Value;
            ReloadFontGraphicEditor();
            SetFontTableImage();
            //ownerForm.SetTextImages();
        }

        // ContextMenuStrip
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            insertIntoText.Enabled = FontType < FontType.Triangles;
        }
        private void import_Click(object sender, EventArgs e)
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
                    palette[i] = this.Palette[i];
                import = new Bitmap(Image.FromFile(openFileDialog1.FileName));
                graphicBlock = new byte[(import.Width * import.Height) / 4];
                Do.PixelsToBPP(
                    Do.ImageToPixels(import, new Size(import.Width, import.Height)),
                    graphicBlock, new Size(import.Width / 8, import.Height / 8), palette, 0x10);
                switch (FontType)
                {
                    case FontType.Menu:
                        Do.CopyOverFontTable(graphicBlock, Glyphs, new Size(import.Width / 8, import.Height / 12), palette);
                        Glyphs[0].Width = 4;
                        break;
                    case FontType.Dialogue:
                        Do.CopyOverFontTable(graphicBlock, Glyphs, new Size(import.Width / 16, import.Height / 12), palette);
                        Glyphs[0].Width = 4;
                        break;
                }
            }
            else
            {
                br = new BinaryReader(fs);
                switch (FontType)
                {
                    case FontType.Menu:
                        graphicBlock = new byte[0xC00];
                        graphicBlock = br.ReadBytes(0xC00);
                        foreach (Glyph f in font_menu)
                            Array.Copy(graphicBlock, f.Index * 0x18, f.Graphics, 0, 0x18);
                        break;
                    case FontType.Dialogue:
                        graphicBlock = new byte[0x1800];
                        graphicBlock = br.ReadBytes(0x1800);
                        foreach (Glyph f in font_dialogue)
                            Array.Copy(graphicBlock, f.Index * 0x30, f.Graphics, 0, 0x30);
                        break;
                    case FontType.Description:
                        graphicBlock = new byte[0x800];
                        graphicBlock = br.ReadBytes(0x800);
                        foreach (Glyph f in font_description)
                            Array.Copy(graphicBlock, f.Index * 0x10, f.Graphics, 0, 0x10);
                        break;
                    case FontType.Triangles:
                        graphicBlock = new byte[0x1C0];
                        graphicBlock = br.ReadBytes(0x1C0);
                        foreach (Glyph f in font_triangle)
                            Array.Copy(graphicBlock, f.Index * 0x20, f.Graphics, 0, 0x20);
                        break;
                }
                br.Close();
            }
            fs.Close();
            InitializeGlyph();
            SetFontTableImage();
            //ownerForm.SetTextImages();
        }
        private void export_Click(object sender, EventArgs e)
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
                switch (FontType)
                {
                    case FontType.Menu:
                        saveFileDialog.FileName = "fontMenuGraphic.bin";
                        if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                            return;
                        fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.ReadWrite);
                        bw = new BinaryWriter(fs);
                        foreach (Glyph f in font_menu)
                            bw.Write(f.Graphics, 0, 0x18);
                        break;
                    case FontType.Dialogue:
                        saveFileDialog.FileName = "fontDialogueGraphic.bin";
                        if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                            return;
                        fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.ReadWrite);
                        bw = new BinaryWriter(fs);
                        foreach (Glyph f in font_dialogue)
                            bw.Write(f.Graphics, 0, 0x30);
                        break;
                    case FontType.Description:
                        saveFileDialog.FileName = "fontDescriptionsGraphic.bin";
                        if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                            return;
                        fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.ReadWrite);
                        bw = new BinaryWriter(fs);
                        foreach (Glyph f in font_description)
                            bw.Write(f.Graphics, 0, 0x10);
                        break;
                    case FontType.BattleMenu:
                        saveFileDialog.FileName = "fontBattleMenuGraphic.bin";
                        if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                            return;
                        fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.ReadWrite);
                        bw = new BinaryWriter(fs);
                        foreach (Glyph f in font_battleMenu)
                            bw.Write(f.Graphics, 0, 0x20);
                        break;
                    default:
                        saveFileDialog.FileName = "fontTrianglesGraphic.bin";
                        if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                            return;
                        fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.ReadWrite);
                        bw = new BinaryWriter(fs);
                        foreach (Glyph f in font_triangle)
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
        private void saveImageAs_Click(object sender, EventArgs e)
        {
            switch (FontType)
            {
                case FontType.Menu: Do.Export(fontTableImage, "fontTableMenu.png"); break;
                case FontType.Dialogue: Do.Export(fontTableImage, "fontTableDialogue.png"); break;
                case FontType.Description: Do.Export(fontTableImage, "fontTableDescription.png"); break;
                case FontType.Triangles: Do.Export(fontTableImage, "fontTableTriangles.png"); break;
                case FontType.BattleMenu: Do.Export(fontTableImage, "fontTableBattleMenu.png"); break;
            }
        }
        private void insertIntoText_Click(object sender, EventArgs e)
        {
            //if (keystrokes == null)
            //    return;
            //if (keystrokes[overGlyph] == "")
            //    dialoguesForm.InsertIntoText("[" + overGlyph + "]");
            //else
            //    dialoguesForm.InsertIntoText(keystrokes[overGlyph]);
        }
        private void insertIntoBattleDialogueText_Click(object sender, EventArgs e)
        {
            //if (keystrokes == null)
            //    return;
            //if (keystrokes[overGlyph] == "")
            //    battleDialoguesForm.InsertIntoText("[" + overGlyph + "]");
            //else
            //    battleDialoguesForm.InsertIntoText(keystrokes[overGlyph]);
        }

        #endregion
    }
}
