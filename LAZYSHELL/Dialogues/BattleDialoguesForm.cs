using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using LazyShell.Properties;

namespace LazyShell.Dialogues
{
    public partial class BattleDialoguesForm : MapEditor
    {
        #region Variables

        // Index
        public int Index
        {
            get { return (int)num.Value; }
            set { num.Value = value; }
        }
        private int type
        {
            get { return typeName.SelectedIndex; }
            set { typeName.SelectedIndex = value; }
        }

        // Functions
        private delegate void UpdateFunction();

        // Forms
        private OwnerForm ownerForm;
        private DialoguesForm dialoguesForm
        {
            get { return ownerForm.DialoguesForm; }
            set { ownerForm.DialoguesForm = value; }
        }
        private TileEditor tileEditor;
        public GraphicEditor graphicEditor;
        public PaletteEditor paletteEditor;
        public PaletteEditor paletteEditorMenu;
        private BattleDialoguePreview textPreview;

        // Helping
        private ParserReduced parser;
        private Search search;
        public bool byteView;

        // Picture
        private Tileset tileset
        {
            get { return Model.Tileset; }
            set { Model.Tileset = value; }
        }
        public new Tileset Tileset
        {
            get { return tileset; }
        }
        private Bitmap tilesetImage
        {
            get { return Model.TilesetImage; }
            set { Model.TilesetImage = value; }
        }
        private Bitmap textImage;
        private Overlay overlay;
        private int mouseDownTile;

        // Elements
        private BattleDialogue[] dialogues
        {
            get
            {
                if (type == 0)
                    return Model.BattleDialogues;
                else
                    return Model.BattleMessages;
            }
        }
        private BattleDialogue dialogue
        {
            get
            {
                if (type == 0)
                    return Model.BattleDialogues[Index];
                else
                    return Model.BattleMessages[Index];
            }
            set
            {
                if (type == 0)
                    Model.BattleDialogues[Index] = value;
                else
                    Model.BattleMessages[Index] = value;
            }
        }
        private byte[] graphics
        {
            get { return Model.Graphics; }
            set { Model.Graphics = value; }
        }
        private Fonts.Glyph[] fontDialogue
        {
            get { return Fonts.Model.Dialogue; }
            set { Fonts.Model.Dialogue = value; }
        }
        public new PaletteSet PaletteSet
        {
            get { return Fonts.Model.Palette_Dialogue; }
            set { Fonts.Model.Palette_Dialogue = value; }
        }

        #endregion

        // Constructor
        public BattleDialoguesForm(OwnerForm ownerForm)
        {
            this.ownerForm = ownerForm;
            this.Owner = ownerForm;

            // Initialize
            InitializeComponent();
            InitializeVariables();
            CreateHelperForms();

            // Load properties
            LoadProperties();
            SetFreeBytesLabel();
            SetTilesetImage();
            SetTextImage();

	        typeName.SelectedIndex = 0;
        }

        #region Methods

        #region Initialization

        private void InitializeVariables()
        {
            this.overlay = new Overlay();
            textPreview = new BattleDialoguePreview();
            parser = ParserReduced.Instance;
            byteView = true;
        }
        private void InitializeNavigators()
        {
            type = 0;
        }
        private void CreateHelperForms()
        {
            search = new Search(num, searchButton, dialogues);
        }

        #endregion

        #region Load properties

        public void LoadProperties()
        {
            LoadProperties(0);
        }
        public void LoadProperties(int selectionStart)
        {
            this.Updating = true;
            //
            this.Index = (int)this.num.Value;
            if (type == 0)
            {
                this.textBox.Text = Model.BattleDialogues[Index].GetText(byteView);
                this.textBox.SelectionStart = selectionStart;
            }
            else if (type == 1)
            {
                this.textBox.Text = Model.BattleMessages[Index].GetText(byteView);
                this.textBox.SelectionStart = selectionStart;
            }
            else if (type == 2)
            {
                this.textBox.Text = Model.BonusMessages[Index].Text;
            }
            SetFreeBytesLabel();
            SetTextImage();
            //
            this.Updating = false;
        }
        private void SetFreeBytesLabel()
        {
            int freeBytes = 0;
            if (type == 0)
                freeBytes = Model.FreeBattleDialogueSpace();
            else if (type == 1)
                freeBytes = Model.FreeBattleMessageSpace();
            availableBytes.Text = freeBytes + " characters left";
        }

        #endregion

        #region Picture

        private void SetTilesetImage()
        {
            tilesetImage = Do.PixelsToImage(
                Do.TilesetToPixels(tileset.Tileset_tiles, 16, 2, 0, false), 256, 32);
            picture.BackColor = Color.FromArgb(PaletteSet.Palette[0]);
            picture.Invalidate();
        }
        public void SetTextImage()
        {
            if (type < 2)
            {
                int[] pixels = textPreview.GetPreview(fontDialogue, PaletteSet.Palettes[1], dialogue.Text, false);
                textImage = Do.PixelsToImage(pixels, 256, 32);
            }
            else
                Model.BonusMessages[Index].Text = textBox.Text.ToUpper();
            picture.Invalidate();
        }

        #endregion

        #region Text modification

        /// <summary>
        /// Inserts a string into the textBox and updates the dialogue text.
        /// </summary>
        /// <param name="value">The string to insert into the dialogue.</param>
        public void InsertIntoText(string value)
        {
            int selectionStart = textBox.SelectionStart;
            textBox.Text = textBox.Text.Insert(selectionStart, value);
            selectionStart += value.Length;
            if (selectionStart < textBox.Text.Length)
                textBox.SelectionStart = selectionStart;
            UpdateDialogueText();
        }
        /// <summary>
        /// Verifies and parses the textBox text and writes to dialogue.
        /// The text image is updated at the end of the operation.
        /// </summary>
        private void UpdateDialogueText()
        {
            if (parser.VerifyText(textBox.Text, byteView))
            {
                dialogue.SetText(textBox.Text, byteView);
                SetTextImage();
            }
        }

        #endregion

        #region Data management

        public void Import()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Import Battle Dialogues";
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            string path = openFileDialog.FileName;
            TextReader tr;
            BinaryFormatter b = new BinaryFormatter();
            try
            {
                tr = new StreamReader(path);
                while (tr.Peek() != -1)
                {
                    string line = tr.ReadLine();
                    int number = Convert.ToInt32(line.Substring(1, 4), 10);
                    line = line.Remove(0, 7);
                    if (byteView)
                    {
                        if (!line.EndsWith("[0]") && !line.EndsWith("[6]"))
                            line += "[0]";
                    }
                    else
                        if (!line.EndsWith("[endInput]") && !line.EndsWith("[end]"))
                            line += "[endInput]";
                    Model.BattleDialogues[number].SetText(line, byteView);
                }
                num_ValueChanged(null, null);
            }
            catch
            {
                MessageBox.Show(
                    "There was a problem loading dialogues. Verify that the lines are correctly named.\n\n" +
                    "Each line must begin with a 4-digit index enclosed in {}, followed by a tab character, then the raw dialogue.",
                    "LAZY SHELL");
            }
        }
        public void Export()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export Battle Dialogues";
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.FileName = "battleDialogues";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter dialogues = File.CreateText(saveFileDialog.FileName);
                for (int i = 0; i < Model.BattleDialogues.Length; i++)
                {
                    dialogues.WriteLine(
                        "{" + i.ToString("d4") + "}\t" +
                        Model.BattleDialogues[i].GetText(byteView));
                }
                dialogues.Close();
            }
        }
        public void Clear()
        {
            new ClearElements(Model.BattleDialogues, Index, "CLEAR BATTLE DIALOGUES...").ShowDialog();
            LoadProperties();
        }

        #endregion

        #region Form loading / updating

        // Form loading
        public void LoadPaletteEditor()
        {
            if (paletteEditor == null)
            {
                paletteEditor = new PaletteEditor(new PaletteUpdater(), PaletteSet, 2, 1, 1);
                paletteEditor.Owner = this;
            }
            else
                ReloadPaletteEditor();
        }
        public void LoadPaletteMenuEditor()
        {
            if (paletteEditorMenu == null)
            {
                paletteEditorMenu = new PaletteEditor(new PaletteMenuUpdater(), Fonts.Model.Palette_Menu, 2, 0, 2);
                paletteEditorMenu.Owner = this;
            }
            else
                ReloadPaletteMenuEditor();
        }
        public void LoadGraphicEditor()
        {
            if (graphicEditor == null)
            {
                graphicEditor = new GraphicEditor(new GraphicUpdater(), graphics, graphics.Length, 0, PaletteSet, 1, 0x20);
                graphicEditor.Owner = this;
            }
            else
                ReloadGraphicEditor();
        }
        private void LoadTileEditor()
        {
            if (tileEditor == null)
            {
                tileEditor = new TileEditor(this, new TileUpdater(), tileset.Tileset_tiles[mouseDownTile], graphics);
                tileEditor.Owner = this;
            }
            else
                tileEditor.Reload(tileset.Tileset_tiles[mouseDownTile], graphics);
        }
        private void ReloadPaletteEditor()
        {
            if (paletteEditor != null)
                paletteEditor.Reload(PaletteSet, 2, 1, 1);
        }
        private void ReloadPaletteMenuEditor()
        {
            if (paletteEditorMenu != null)
                paletteEditorMenu.Reload(Fonts.Model.Palette_Menu, 2, 0, 2);
        }
        private void ReloadGraphicEditor()
        {
            if (graphicEditor != null)
                graphicEditor.Reload(graphics, graphics.Length, 0, PaletteSet, 1, 0x20);
        }
        private void ShowEditorForm(Form form)
        {
            if (!form.Visible)
                form.Location = new Point(Cursor.Position.X + 20, Cursor.Position.Y + 20);
            form.Show();
        }

        // Updating
        public void UpdateTile()
        {
            tileset.ParseTileset(tileset.Tileset_tiles, tileset.Tileset_bytes);
            SetTilesetImage();
        }
        public void UpdateTileset()
        {
            tileset.ParseTileset(tileset.Tileset_tiles, tileset.Tileset_bytes);
            SetTilesetImage();
        }
        public void UpdatePalette()
        {
            dialoguesForm.RedrawTileset();
            dialoguesForm.SetTextImage();
            tileset.RedrawTileset();
            SetTilesetImage();
            SetTextImage();
            ownerForm.Modified = true;   // b/c switching colors won't modify checksum
        }
        public void UpdatePaletteMenu()
        {
        }
        public void UpdateGraphics()
        {
            dialoguesForm.RedrawTileset();
            dialoguesForm.SetTextImage();
            tileset.RedrawTileset();
            SetTilesetImage();
            SetTextImage();
        }

        #endregion

        // Saving
        public void WriteToROM()
        {
            // Assemble the overworld menu palette
            Fonts.Model.Palette_Menu.WriteToBuffer(Menus.Model.Menu_Palette_Bytes, 0);
            byte[] compressed = new byte[0x200];
            int pointerOffset = Bits.GetShort(Model.ROM, 0x3E000C);  // may have changed when menus last saved
            int maxSize = Bits.GetShort(Model.ROM, 0x3E000E) - pointerOffset;  // may have changed when menus last saved
            int totalSize = Comp.Compress(Menus.Model.Menu_Palette_Bytes, compressed);
            if (totalSize > maxSize)
                MessageBox.Show("Not enough space for compressed menu palettes. The total required space (" +
                    totalSize + " bytes) exceeds " + maxSize + " bytes.\n\n" + "The menu palettes were not saved.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                Bits.SetBytes(Model.ROM, pointerOffset + 0x3E0000 + 1, compressed, 0, totalSize - 1);
            
            //
            int i = 0;
            int length = 0x6754;

            // Check free battle dialogue space
            if (Model.FreeBattleDialogueSpace() >= 0)
            {
                for (; i < Model.BattleDialogues.Length && length + Model.BattleDialogues[i].Length < 0x92D1; i++)
                    Model.BattleDialogues[i].WriteToROM(ref length);
                length = 0x260A;
                for (; i < Model.BattleDialogues.Length && length + Model.BattleDialogues[i].Length < 0x2AA9; i++)
                    Model.BattleDialogues[i].WriteToROM(ref length);
                length = 0xBC58;
                for (; i < Model.BattleDialogues.Length && length + Model.BattleDialogues[i].Length < 0xBfff; i++)
                    Model.BattleDialogues[i].WriteToROM(ref length);
            }
            else
                MessageBox.Show("Battle dialogues exceed maximum size. Reduce total size to save correctly.\n\n" +
                    "NOTE: not all text has been saved.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            // Check free battle message space
            if (Model.FreeBattleMessageSpace() >= 0)
            {
                i = 0;
                length = 0x274D;
                for (; i < Model.BattleMessages.Length && length + Model.BattleMessages[i].Length < 0x2A00; i++)
                    Model.BattleMessages[i].WriteToROM(ref length);
            }
            else
                MessageBox.Show("Battle messages exceed maximum size. Reduce total size to save correctly.\n\n" +
                    "NOTE: not all text has been saved.", "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            // Bonus messages
            int offset = 0xF975;
            for (i = 0; i < Model.BonusMessages.Length; i++)
                Model.BonusMessages[i].WriteToROM(ref offset);
        }

        #endregion

        #region Event Handlers

        // Navigators
        private void num_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            textPreview.Reset();
            LoadProperties();
        }
        private void typeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.Updating = true;
            Index = 0;
            if (type == 0)
                num.Maximum = 255;
            else if (type == 1)
                num.Maximum = 45;
            else
                num.Maximum = 6;
            picture.Height = type < 2 ? 32 : 24;
            if (type == 2 && searchButton.Checked)
                searchButton.PerformClick();
            searchButton.Visible = type < 2;
            toolStrip2.Visible = type < 2;
            toolStrip3.Visible = type < 2;
            this.Updating = false;
            if (type < 2)
            {
                search.Names = dialogues;
                search.PerformSearch();
            }
            textPreview.Reset();
            LoadProperties();
        }

        // Data management
        private void import_Click(object sender, EventArgs e)
        {
            Import();
        }
        private void export_Click(object sender, EventArgs e)
        {
            Export();
        }
        private void clear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current battle dialogue. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            if (type == 0)
                dialogue = new BattleDialogue(Index, 0x396554, 0x390000);
            else
                dialogue = new BattleDialogue(Index, 0x3A26F1, 0x3A0000);
            LoadProperties();
        }

        // Toggle
        private void toggleText_Click(object sender, EventArgs e)
        {
            picture.Invalidate();
        }
        private void toggleTileGrid_Click(object sender, EventArgs e)
        {
            picture.Invalidate();
        }

        // Picture
        private void picture_Paint(object sender, PaintEventArgs e)
        {
            if (type < 2)
            {
                if (tilesetImage != null)
                    e.Graphics.DrawImage(tilesetImage, 0, 0, 256, 32);
                if (textImage != null && toggleText.Checked)
                    e.Graphics.DrawImage(textImage, 0, 0, 256, 32);
                if (toggleTileGrid.Checked)
                    overlay.DrawTileGrid(e.Graphics, Color.Black, picture.Size, new Size(16, 16), 1, true);
            }
            else
            {
                int x = 0;
                string text = Model.BonusMessages[this.Index].Text;
                int[] table = Sprites.Model.Sprites[520].GetTilesetPixels();
                foreach (char letter in text)
                {
                    int index = Lists.IndexOf(Lists.KeystrokesBonus, letter.ToString());
                    if (index < 0 || index > 31)
                        continue;
                    int[] pixels = Do.GetPixelRegion(table, 128, 16, 8, 8, index % 16 * 8, index / 16 * 8);
                    e.Graphics.DrawImage(Do.PixelsToImage(pixels, 8, 8), x * 8 + 8, 8);
                    x++;
                }
            }
        }
        private void picture_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownTile = (e.Y / 16 * 16) + (e.X / 16);
            LoadTileEditor();
        }
        private void picture_MouseMove(object sender, MouseEventArgs e)
        {
        }
        private void picture_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
        }

        // TextBox
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            parser.ReplaceLineBreaks(textBox, byteView);
            UpdateDialogueText();
            SetFreeBytesLabel();
        }

        // Text insertion
        private void pageUp_Click(object sender, EventArgs e)
        {
            textPreview.PageUp();
            SetTextImage();
        }
        private void pageDown_Click(object sender, EventArgs e)
        {
            textPreview.PageDown();
            SetTextImage();
        }
        private void textView_Click(object sender, EventArgs e)
        {
            byteView = !textView.Checked;
            textBox.Text = dialogue.GetText(byteView);
        }
        private void newLine_Click(object sender, EventArgs e)
        {
            if (byteView)
                InsertIntoText("[1]");
            else
                InsertIntoText("[newLine]");
        }
        private void endString_Click(object sender, EventArgs e)
        {
            if (byteView)
                InsertIntoText("[0]");
            else
                InsertIntoText("[end]");
        }
        private void pause60f_Click(object sender, EventArgs e)
        {
            if (byteView)
                InsertIntoText("[12]");
            else
                InsertIntoText("[delay]");
        }
        private void pauseA_Click(object sender, EventArgs e)
        {
            if (byteView)
                InsertIntoText("[2]");
            else
                InsertIntoText("[pauseInput]");
        }
        private void pauseFrames_Click(object sender, EventArgs e)
        {
            if (byteView)
                InsertIntoText("[3]");
            else
                InsertIntoText("[delayInput]");
        }

        // Editors
        private void openTileEditor_Click(object sender, EventArgs e)
        {
            tileEditor.Show();
        }
        private void openGraphics_Click(object sender, EventArgs e)
        {
            LoadGraphicEditor();
            ShowEditorForm(graphicEditor);
        }
        private void openPalettes_Click(object sender, EventArgs e)
        {
            LoadPaletteEditor();
            ShowEditorForm(paletteEditor);
        }
        private void openPaletteMenu_Click(object sender, EventArgs e)
        {
            LoadPaletteMenuEditor();
            ShowEditorForm(paletteEditorMenu);
        }

        #endregion
    }

    /// <summary>
    /// Contains the data of a bonus message used in a battle sequence.
    /// </summary>
    [Serializable()]
    public class BonusMessage
    {
        #region Variables

        public string Text { get; set; }
        public int Index { get; set; }

        #endregion

        // Constructor
        public BonusMessage(int index)
        {
            this.Index = index;
            ReadFromROM();
        }

        #region Methods

        // Read/write ROM
        private void ReadFromROM()
        {
            int offset = 0x020000 + Bits.GetShort(Model.ROM, Index * 2 + 0x02F967);
            int length = Model.ROM[offset++];
            this.Text = "";
            for (int i = 0; i < length; i++)
                this.Text += Lists.KeystrokesBonus[Model.ROM[offset++]];
        }
        public void WriteToROM(ref int offset)
        {
            Bits.SetShort(Model.ROM, Index * 2 + 0x02F967, offset);
            Model.ROM[0x020000 + offset++] = (byte)Text.Length;
            foreach (char letter in Text)
            {
                int index = Lists.IndexOf(Lists.KeystrokesBonus, letter.ToString());
                if (index >= 0 || index <= 31)
                    Model.ROM[0x020000 + offset++] = (byte)index;
                else
                    Model.ROM[0x020000 + offset++] = 0x1F;
            }
        }

        #endregion
    }
}
