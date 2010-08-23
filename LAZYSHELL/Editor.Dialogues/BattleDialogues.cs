using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public partial class BattleDialogues : Form
    {
        #region Variables
        // main
        private delegate void Function();
        private Model model = State.Instance.Model;
        private Dialogues dialoguesEditor;
        private State state = State.Instance;
        private BattleDialoguePreview textPreview = new BattleDialoguePreview();
        private TextHelperReduced textHelper = TextHelperReduced.Instance;
        private BattleDialogueTileset tileset { get { return model.BattleDialogueTileset; } set { model.BattleDialogueTileset = value; } }
        private Bitmap tilesetImage { get { return model.BattleDialogueTilesetImage; } set { model.BattleDialogueTilesetImage = value; } }
        private Bitmap textImage;
        private Overlay overlay;
        private Search search;
        private bool updating = false;
        // accessors
        private BattleDialogue[] dialogues
        {
            get
            {
                if (battleDlgType.SelectedIndex == 0)
                    return model.BattleDialogues;
                else
                    return model.BattleMessages;
            }
        }
        private BattleDialogue dialogue
        {
            get
            {
                if (battleDlgType.SelectedIndex == 0)
                    return model.BattleDialogues[index];
                else
                    return model.BattleMessages[index];
            }
            set
            {
                if (battleDlgType.SelectedIndex == 0)
                    model.BattleDialogues[index] = value;
                else
                    model.BattleMessages[index] = value;
            }
        }
        private byte[] graphics { get { return model.DialogueGraphics; } set { model.DialogueGraphics = value; } }
        private FontCharacter[] fontDialogue { get { return model.FontDialogue; } set { model.FontDialogue = value; } }
        private PaletteSet fontPalette { get { return model.FontPaletteDialogue; } set { model.FontPaletteDialogue = value; } }
        public bool textCodeFormat = true;
        // local variables
        private int index { get { return (int)battleDialogueNum.Value; } set { battleDialogueNum.Value = value; } }
        public int Index { get { return index; } }
        private int mouseDownTile = 0;
        // editors
        private TileEditor tileEditor;
        private GraphicEditor graphicEditor;
        private PaletteEditor paletteEditor;
        private PaletteEditor paletteEditorMenu;
        #endregion
        #region Functions
        public BattleDialogues(Dialogues dialoguesEditor)
        {
            this.dialoguesEditor = dialoguesEditor;
            this.overlay = new Overlay();
            InitializeComponent();
            search = new Search(battleDialogueNum, searchBox, searchButton, dialogues);
            // tileset
            tileset = new BattleDialogueTileset(fontPalette);
            SetTilesetImage();
            // editors
            LoadPaletteEditor();
            LoadPaletteMenuEditor();
            LoadGraphicEditor();
            LoadTileEditor();
            // controls
            updating = true;
            battleDlgType.SelectedIndex = 0;
            RefreshBattleDialogue();
            updating = false;
        }
        public void Close()
        {
            search.Close();
            paletteEditor.Close();
            paletteEditorMenu.Close();
            tileEditor.Close();
            graphicEditor.Close();
        }
        public void SetToolTips(ToolTip toolTip1)
        {
            this.battleDialogueNum.ToolTipText =
                "Select the battle dialogue to edit by #.\n\n" +
                "Battle dialogues only appear in battles and must be \n" +
                "triggered by a battle script command to be shown.";

            toolTip1.SetToolTip(this.battleDialogueTextBox,
                "Edit the current battle dialogue. Insert commands using the \n" +
                "list to the right.\n\n" +
                "To insert symbols, type the character # of the symbol \n" +
                "between []. The character # can be found by moving the \n" +
                "mouse over the font character in the font table image in \n" +
                "the \"FONT GRAPHICS\" panel.");
        }
        public void RefreshBattleDialogue()
        {
            updating = true;
            this.index = (int)this.battleDialogueNum.Value;
            if (battleDlgType.SelectedIndex == 0)
            {
                this.battleDialogueTextBox.Text = this.model.BattleDialogues[index].GetBattleDialogue(textCodeFormat);
                this.battleDialogueTextBox.SelectionStart = this.model.BattleDialogues[index].GetCaretPosition(textCodeFormat);
            }
            else
            {
                this.battleDialogueTextBox.Text = this.model.BattleMessages[index].GetBattleDialogue(textCodeFormat);
                this.battleDialogueTextBox.SelectionStart = this.model.BattleMessages[index].GetCaretPosition(textCodeFormat);
            }
            CalculateFreeSpace();
            SetTextImage();
            updating = false;
        }
        private void SetTilesetImage()
        {
            tilesetImage = new Bitmap(Do.PixelsToImage(
                Do.TilesetToPixels(tileset.TilesetLayer, 16, 2, 0, false), 256, 32));
            pictureBoxBattleDialogue.BackColor = Color.FromArgb(fontPalette.Palette[0]);
            pictureBoxBattleDialogue.Invalidate();
        }
        public void SetTextImage()
        {
            char[] text = battleDialogueTextBox.Text.ToCharArray();
            bool preview = true, valid = true, fail = false;
            char[] swap;
            int temp;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '[' && preview == false) // Open bracket when we have already had an open bracket
                    fail = true;
                if (text[i] == '[') // Open Bracket
                {
                    preview = false;
                    temp = ++i;
                    while (temp < text.Length && text[temp] != ']')
                    {
                        if (textCodeFormat)
                        {
                            if (!(text[temp] >= '0' && text[temp] <= '9'))
                                fail = true;
                        }
                        temp++;
                    }
                }
                else if (preview == false && text[i] == ']') // Close bracket after open bracket
                    preview = true;
                else if (preview == true && valid == true)
                    valid = textHelper.IsValidChar(text[i]);
                if (i < text.Length && text[i] == '\n')
                {
                    int tempSel = battleDialogueTextBox.SelectionStart;
                    swap = new char[text.Length + 2];
                    for (int x = 0; x < i; x++)
                        swap[x] = text[x];
                    swap[i] = '[';
                    swap[i + 1] = '1';
                    swap[i + 2] = ']';
                    for (int x = i + 3; x < swap.Length; x++)
                        swap[x] = text[x - 2];
                    battleDialogueTextBox.Text = new string(swap);
                    text = battleDialogueTextBox.Text.ToCharArray();
                    i += 2;
                    battleDialogueTextBox.SelectionStart = tempSel + 2;
                }
            }
            if (preview && valid && !fail)
            {
                dialogue.SetBattleDialogue(battleDialogueTextBox.Text, textCodeFormat);
                int[] pixels = textPreview.GetPreview(fontDialogue, fontPalette.Palettes[1], dialogue.RawBattleDialogue, false);
                textImage = new Bitmap(Do.PixelsToImage(pixels, 256, 32));
            }
            pictureBoxBattleDialogue.Invalidate();
        }
        private void CalculateFreeSpace()
        {
            int used = 0; int size;
            if (battleDlgType.SelectedIndex == 0)
            {
                size = (0x92d1 - 0x6754) + (0x2aa9 - 0x260a) + (0xbfff - 0xbc58);/*(0xffff - 0xf400) USED FOR BATTLE SCRIPTS NOW*/
                for (int i = 0; i < model.BattleDialogues.Length - 1; i++)
                {
                    used += model.BattleDialogues[i].BattleDialogueLen;
                    if (used + model.BattleDialogues[i].BattleDialogueLen > size)
                    {
                        bool test = size >= used + model.BattleDialogues[i].BattleDialogueLen;
                        if (!test)
                        {
                            availableBytes.Text = "Entry " + i++.ToString() + " Too Long - Cannot Save";
                            return;
                        }
                    }
                }
            }
            else
            {
                size = (0x2A00 - 0x274D);
                for (int i = 0; i < model.BattleMessages.Length; i++)
                    used += model.BattleMessages[i].BattleDialogueLen;
            }
            availableBytes.Text = ((double)(size - used)).ToString() + " characters left";
        }
        private bool FreeSpace(bool message)
        {
            int used = 0;
            int size;
            if (!message)
            {
                size = (0x92d1 - 0x6754) + (0x2aa9 - 0x260a) + (0xbfff - 0xbc58);/*(0xffff - 0xf400) USED FOR BATTLE SCRIPTS NOW*/
                for (int i = 0; i < model.BattleDialogues.Length - 1; i++)
                    used += model.BattleDialogues[i].BattleDialogueLen;
            }
            else
            {
                size = (0x2A00 - 0x274D);
                for (int i = 0; i < model.BattleMessages.Length; i++)
                    used += model.BattleMessages[i].BattleDialogueLen;
            }
            return size - used < 0;
        }
        public void InsertIntoBattleDialogueText(string toInsert)
        {
            char[] newText = new char[battleDialogueTextBox.Text.Length + toInsert.Length];

            battleDialogueTextBox.Text.CopyTo(0, newText, 0, battleDialogueTextBox.SelectionStart);
            toInsert.CopyTo(0, newText, battleDialogueTextBox.SelectionStart, toInsert.Length);
            battleDialogueTextBox.Text.CopyTo(battleDialogueTextBox.SelectionStart, newText, battleDialogueTextBox.SelectionStart + toInsert.Length, this.battleDialogueTextBox.Text.Length - this.battleDialogueTextBox.SelectionStart);

            if (battleDlgType.SelectedIndex == 0)
            {
                model.BattleDialogues[index].SetCaretPosition(this.battleDialogueTextBox.SelectionStart + toInsert.Length, textCodeFormat);
                model.BattleDialogues[index].SetBattleDialogue(new string(newText), textCodeFormat);
            }
            else
            {
                dialogue.SetCaretPosition(this.battleDialogueTextBox.SelectionStart + toInsert.Length, textCodeFormat);
                dialogue.SetBattleDialogue(new string(newText), textCodeFormat);
            }
            RefreshBattleDialogue();
            SetTextImage();
        }
        public void Assemble()
        {
            int i = 0;
            ushort len = 0x6754;
            if (!FreeSpace(false))
            {
                for (; i < model.BattleDialogues.Length && len + model.BattleDialogues[i].BattleDialogueLen < 0x92d1; i++)
                    len += model.BattleDialogues[i].Assemble(len);
                len = 0x260A;// - 0x392AA9
                for (; i < model.BattleDialogues.Length && len + model.BattleDialogues[i].BattleDialogueLen < 0x2aa9; i++)
                    len += model.BattleDialogues[i].Assemble(len);
                len = 0xBC58;// - 0x39BFFF
                for (; i < model.BattleDialogues.Length && len + model.BattleDialogues[i].BattleDialogueLen < 0xbfff; i++)
                    len += model.BattleDialogues[i].Assemble(len);
            }
            else
                MessageBox.Show("Battle Dialogue exceeds max size, decrease total size to save correctly.\nNote: not all text has been saved.");
            if (!FreeSpace(true))
            {
                i = 0;
                len = 0x274D;
                for (; i < model.BattleMessages.Length && len + model.BattleMessages[i].BattleDialogueLen < 0x2A00; i++)
                    len += model.BattleMessages[i].Assemble(len);
            }
            else
                MessageBox.Show("Battle Message exceeds max size, decrease total size to save correctly.\nNote: not all text has been saved.");
        }
        // editors
        public void LoadPaletteEditor()
        {
            if (paletteEditor == null)
            {
                paletteEditor = new PaletteEditor(new Function(PaletteUpdate), fontPalette, 2, 1);
                paletteEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                paletteEditor.Reload(new Function(PaletteUpdate), fontPalette, 2, 1);
        }
        public void LoadPaletteMenuEditor()
        {
            if (paletteEditorMenu == null)
            {
                paletteEditorMenu = new PaletteEditor(new Function(PaletteMenuUpdate), model.FontPaletteMenu, 1, 0);
                paletteEditorMenu.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                paletteEditorMenu.Reload(new Function(PaletteMenuUpdate), model.FontPaletteMenu, 1, 0);
        }
        public void LoadGraphicEditor()
        {
            if (graphicEditor == null)
            {
                graphicEditor = new GraphicEditor(new Function(GraphicUpdate),
                    graphics, graphics.Length, 0, fontPalette, 1, 0x20);
                graphicEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                graphicEditor.Reload(new Function(GraphicUpdate),
                    graphics, graphics.Length, 0, fontPalette, 1, 0x20);
        }
        private void LoadTileEditor()
        {
            if (tileEditor == null)
            {
                tileEditor = new TileEditor(new Function(TileUpdate),
                tileset.TilesetLayer[mouseDownTile], graphics,
                fontPalette, 0x20);
                tileEditor.FormClosing += new FormClosingEventHandler(editor_FormClosing);
            }
            else
                tileEditor.Reload(new Function(TileUpdate),
                tileset.TilesetLayer[mouseDownTile], graphics,
                fontPalette, 0x20);
        }
        private void TileUpdate()
        {
            SetTilesetImage();
        }
        private void PaletteUpdate()
        {
            dialoguesEditor.LoadFontEditor();
            dialoguesEditor.RedrawTileset();
            dialoguesEditor.RedrawText();
            tileset = new BattleDialogueTileset(fontPalette);
            SetTilesetImage();
            SetTextImage();
        }
        private void PaletteMenuUpdate()
        {
            dialoguesEditor.LoadFontEditor();
        }
        private void GraphicUpdate()
        {
            dialoguesEditor.LoadFontEditor();
            dialoguesEditor.RedrawTileset();
            dialoguesEditor.RedrawText();
            tileset = new BattleDialogueTileset(fontPalette);
            SetTilesetImage();
        }
        #endregion
        #region Event Handlers
        // main
        private void battleDialogueNum_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            textPreview.Reset();
            RefreshBattleDialogue();
        }
        private void battleDialogueTextBox_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            SetTextImage();
            CalculateFreeSpace();
        }
        private void battleDialogueTextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void battleDlgType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            index = 0;
            battleDialogueNum.Maximum = battleDlgType.SelectedIndex == 0 ? 255 : 45;
            search.Names = dialogues;
            search.LoadSearch();
            updating = false;
            textPreview.Reset();
            RefreshBattleDialogue();
        }
        private void pictureBoxBattleDialogue_Paint(object sender, PaintEventArgs e)
        {
            if (tilesetImage != null)
                e.Graphics.DrawImage(tilesetImage, 0, 0, 256, 32);
            if (textImage != null)
                e.Graphics.DrawImage(textImage, 0, 0, 256, 32);
        }
        private void pictureBoxBattleDialogue_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownTile = (e.Y / 16 * 16) + (e.X / 16);
            LoadTileEditor();
        }
        private void pictureBoxBattleDialogue_MouseMove(object sender, MouseEventArgs e)
        {

        }
        private void pictureBoxBattleDialogue_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }
        // text insertion
        private void pageUp_Click(object sender, EventArgs e)
        {
            textPreview.PageUp();
            SetTextImage();
        }
        private void pageDown_Click(object sender, EventArgs e)
        {
            textPreview.PageDown(dialogue.RawBattleDialogue.Length);
            SetTextImage();
        }
        private void byteOrTextView_Click(object sender, EventArgs e)
        {
            textCodeFormat = !byteOrTextView.Checked;
            battleDialogueTextBox.Text = dialogue.GetBattleDialogue(textCodeFormat);
        }
        private void newLine_Click(object sender, EventArgs e)
        {
            if (textCodeFormat)
                InsertIntoBattleDialogueText("[1]");
            else
                InsertIntoBattleDialogueText("[newLine]");
        }
        private void endString_Click(object sender, EventArgs e)
        {
            if (textCodeFormat)
                InsertIntoBattleDialogueText("[0]");
            else
                InsertIntoBattleDialogueText("[end]");
        }
        private void pause60f_Click(object sender, EventArgs e)
        {
            if (textCodeFormat)
                InsertIntoBattleDialogueText("[12]");
            else
                InsertIntoBattleDialogueText("[delay]");
        }
        private void pauseA_Click(object sender, EventArgs e)
        {
            if (textCodeFormat)
                InsertIntoBattleDialogueText("[2]");
            else
                InsertIntoBattleDialogueText("[pauseInput]");
        }
        private void pauseFrames_Click(object sender, EventArgs e)
        {
            if (textCodeFormat)
                InsertIntoBattleDialogueText("[3]");
            else
                InsertIntoBattleDialogueText("[delayInput]");
        }
        // editors
        private void openTileEditor_Click(object sender, EventArgs e)
        {
            tileEditor.Show();
        }
        private void openGraphics_Click(object sender, EventArgs e)
        {
            graphicEditor.Show();
        }
        private void openPalettes_Click(object sender, EventArgs e)
        {
            paletteEditor.Show();
        }
        private void openPaletteMenu_Click(object sender, EventArgs e)
        {
            paletteEditorMenu.Show();
        }
        private void editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            ((Form)sender).Hide();
        }
        #endregion
    }
}
