using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    public partial class Dialogues : Form
    {
        #region Variables
        
        public long checksum;
        // main
        private delegate void Function(RichTextBox richTextBox, StringComparison stringComparison, bool matchWholeWord, bool replaceAll, string replaceWith);
        // accessors
        private Dialogue[] dialogues { get { return Model.Dialogues; } set { Model.Dialogues = value; } }
        private Dialogue dialogue { get { return dialogues[index]; } set { dialogues[index] = value; } }
        private DialogueTable[] dialogueTables { get { return Model.DialogueTables; } set { Model.DialogueTables = value; } }
        private FontCharacter[] fontDialogue { get { return Model.FontDialogue; } }
        private FontCharacter[] fontTriangle { get { return Model.FontTriangle; } }
        private PaletteSet fontPalette { get { return Model.FontPaletteDialogue; } set { Model.FontPaletteDialogue = value; } }
        // public accessors
        public ToolStripNumericUpDown DialogueNum { get { return dialogueNum; } set { dialogueNum = value; } }
        private State state = State.Instance;
        private DialoguePreview dialoguePreview;
        private TextHelper textHelper;
        private bool textCodeFormat { get { return !byteOrTextView.Checked; } set { byteOrTextView.Checked = !value; } }
        public int index { get { return (int)dialogueNum.Value; } set { dialogueNum.Value = value; } }
        private bool updatingDialogue;
        private bool[] isDialogueChanged = new bool[4096];
        private Bitmap
            dialogueBGImage,
            dialogueTextImage;
        private DialogueTileset dialogueTileset;
        // editors
        private BattleDialogues battleDialogues;
        public BattleDialogues BattleDialogues { get { return battleDialogues; } set { battleDialogues = value; } }
        private Fonts fonts;
        public Fonts Fonts { get { return fonts; } set { fonts = value; } }
        private Search searchWindow;
        #endregion
        #region Functions
        public Dialogues()
        {
            Settings.Default.Keystrokes[0x20] = "\x20";
            Settings.Default.KeystrokesMenu[0x20] = "\x20";
            Settings.Default.KeystrokesDesc[0x20] = "\x20";

            FindDuplicateDialoguePointers();
            FindWithinDialogues();

            InitializeComponent();
            Do.AddShortcut(toolStrip3, Keys.Control | Keys.S, new EventHandler(save_Click));
            Do.AddShortcut(toolStrip3, Keys.F1, helpTips);
            Do.AddShortcut(toolStrip3, Keys.F2, showDecHex);
            SetToolTips(toolTip1);
            searchWindow = new Search(dialogueNum, textBoxSearch, search, new Function(LoadSearch), "richTextBox");
            // tileset
            textHelper = TextHelper.Instance;
            dialoguePreview = new DialoguePreview();
            dialogueTileset = new DialogueTileset(Model.FontPaletteDialogue);
            SetTilesetImage();
            // compression table
            updatingDialogue = true;
            this.dct0E.Text = dialogueTables[0].GetDialogue(textCodeFormat); dct0E.Tag = 0;
            this.dct0F.Text = dialogueTables[1].GetDialogue(textCodeFormat); dct0F.Tag = 1;
            this.dct10.Text = dialogueTables[2].GetDialogue(textCodeFormat); dct10.Tag = 2;
            this.dct11.Text = dialogueTables[3].GetDialogue(textCodeFormat); dct11.Tag = 3;
            this.dct12.Text = dialogueTables[4].GetDialogue(textCodeFormat); dct12.Tag = 4;
            this.dct13.Text = dialogueTables[5].GetDialogue(textCodeFormat); dct13.Tag = 5;
            this.dct14.Text = dialogueTables[6].GetDialogue(textCodeFormat); dct14.Tag = 6;
            this.dct15.Text = dialogueTables[7].GetDialogue(textCodeFormat); dct15.Tag = 7;
            this.dct16.Text = dialogueTables[8].GetDialogue(textCodeFormat); dct16.Tag = 8;
            this.dct17.Text = dialogueTables[9].GetDialogue(textCodeFormat); dct17.Tag = 9;
            updatingDialogue = false;
            // editors
            LoadFontEditor();
            option.Image = new Bitmap(Do.PixelsToImage(fontTriangle[0].GetCharacterPixels(fontPalette.Palettes[1]), 8, 16));
            battleDialogues = new BattleDialogues(this);
            battleDialogues.TopLevel = false;
            battleDialogues.Dock = DockStyle.Bottom;
            battleDialogues.SetToolTips(toolTip1);
            panelDialogues.Controls.Add(battleDialogues);
            battleDialogues.BringToFront();
            battleDialogues.Show();
            fonts.BringToFront();
            // set controls
            updatingDialogue = true;
            index = Settings.Default.LastDialogue;
            variables.SelectedIndex = 0;
            RefreshDialogueEditor();
            CalculateFreeTableSpace();
            SetTextImage();
            updatingDialogue = false;
            new ToolTipLabel(this, toolTip1, showDecHex, helpTips);
            //
            new History(this);
            checksum = Do.GenerateChecksum(dialogues, dialogueTables, Model.BattleDialogues, Model.BattleMessages, battleDialogues.Tileset, 
                fontDialogue, Model.FontMenu, Model.FontDescription, fontTriangle, fontPalette, Model.FontPaletteMenu);
        }
        // tooltips
        private void SetToolTips(ToolTip toolTip1)
        {
            // Dialogues

            this.dialogueNum.ToolTipText =
                "Select the dialogue to edit.\n\n" +
                "Dialogues must be triggered by an event script command to \n" +
                "show. Generally, most dialogues are \"assigned\" to an NPC, \n" +
                "ie. the NPC has an event # assigned to it, wherein there is \n" +
                "a command to display a specific dialogue # in that event \n" +
                "script. The first few dialogues are by default used as the \n" +
                "message / caption that is shown at the top of some levels. \n\n" +
                "To find a dialogue, use the \"SEARCH DIALOGUE...\" panel \n" +
                "below.";

            this.byteOrTextView.ToolTipText =
                "Enable or disable text viewing in the dialogue textbox. This \n" +
                "is for easily identifying what the numerals in [] mean.";

            toolTip1.SetToolTip(this.dialogueTextBox,
                "Edit the current dialogue. Insert symbols and commands \n" +
                "using the buttons below and the list to the right.\n\n" +
                "To insert a character based on its #, just type the # \n" +
                "between []. To find out what a font character's # is, just \n" +
                "move the mouse cursor over the character in the font table \n" +
                "to the right in the \"FONT GRAPHICS\" panel.");
        }
        private void RefreshDialogueEditor()
        {
            updatingDialogue = true;

            this.dialogueTextBox.Text = dialogue.GetDialogue(textCodeFormat);
            this.dialogueTextBox.SelectionStart = dialogue.GetCaretPosition(textCodeFormat);

            int temp = CalculateFreeSpace();
            this.freeBytes.Text = temp.ToString() + " characters left";
            this.freeBytes.BackColor = temp >= 0 ? SystemColors.Control : Color.Red;

            updatingDialogue = false;
        }
        private void SetTilesetImage()
        {
            dialogueBGImage = new Bitmap(Do.PixelsToImage(
                Do.TilesetToPixels(dialogueTileset.TilesetLayer, 16, 4, 0, false), 256, 56));
            pictureBoxDialogue.Invalidate();
        }
        private void SetTextImage()
        {
            char[] text = dialogueTextBox.Text.ToCharArray();
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
                    i++;
                    temp = i;

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
                    int tempSel = dialogueTextBox.SelectionStart;
                    swap = new char[text.Length + 2];
                    for (int x = 0; x < i; x++)
                        swap[x] = text[x];
                    swap[i] = '[';
                    swap[i + 1] = '1';
                    swap[i + 2] = ']';
                    for (int x = i + 3; x < swap.Length; x++)
                        swap[x] = text[x - 2];
                    dialogueTextBox.Text = new string(swap);
                    text = dialogueTextBox.Text.ToCharArray();
                    i += 2;
                    dialogueTextBox.SelectionStart = tempSel + 2;
                }
            }
            if (preview && valid && !fail)
            {
                dialogue.SetDialogue(dialogueTextBox.Text, textCodeFormat);
                int[] pixels = dialoguePreview.GetPreview(fontDialogue, fontTriangle, fontPalette.Palettes[1], fontPalette.Palettes[1], dialogue.RawDialogue, 16);
                dialogueTextImage = new Bitmap(Do.PixelsToImage(pixels, 256, 56));
            }
            pictureBoxDialogue.Invalidate();
        }
        private int CalculateFreeSpace()
        {
            int index = this.index;
            int used = 0;
            int size = 0;
            int end = 0;
            if (index >= 0x0C00)
            {
                size = (0xFFFF - 0xEDE0) + 0x9000;
                index = 0x0C00;
                end = 0x1000;
            }
            else if (index >= 0x0800)
            {
                size = 0xF2D5;
                index = 0x0800;
                end = 0x0C00;
            }
            else
            {
                size = 0xFD18;
                index = 0x0000;
                end = 0x0800;
            }
            for (int i = index; i < end; i++)
            {
                if (i == dialogues[i].DuplicateDialogues && dialogues[i].WithinDialoguesLocation == 0)
                {
                    used += dialogues[i].DialogueLen;
                    if (i < end - 1 && used + dialogues[i + 1].DialogueLen > size && i + 1 == dialogues[i + 1].DuplicateDialogues && dialogues[i + 1].WithinDialoguesLocation == 0)
                    {
                        bool test = false;
                        test = (size >= used + dialogues[i + 1].DialogueLen);
                    }
                }
            }
            return size - used;
        }
        private void CalculateFreeTableSpace()
        {
            int used = 0;
            for (int i = 0; i < 10; i++)
                used += dialogueTables[i].DialogueLen + 1;
            int left = 0x40 - used;
            this.freeTableBytes.Text = "(" + left.ToString() + " characters left)";
            this.freeTableBytes.BackColor = left >= 0 ? SystemColors.Control : Color.Red;
        }
        private bool FreeSpace(int current)
        {
            int used = 0;
            int size = 0;
            int index = 0;
            int end = 0;
            double left = 0;

            if (current >= 0x0C00)
            {
                size = (0xFFFF - 0xEDE0) + 0x9000;
                index = 0x0C00;
                end = 0x1000;
            }
            else if (current >= 0x0800)
            {
                size = 0xF2D5;
                index = 0x0800;
                end = 0x0C00;
            }
            else
            {
                size = 0xFD18;
                index = 0x0000;
                end = 0x0800;
            }

            for (int i = index; i < end; i++)
            {
                if (i == dialogues[i].DuplicateDialogues && dialogues[i].WithinDialoguesLocation == 0)
                {
                    used += dialogues[i].DialogueLen;

                    if (i < end - 1 && used + dialogues[i + 1].DialogueLen > size && i + 1 == dialogues[i + 1].DuplicateDialogues && dialogues[i + 1].WithinDialoguesLocation == 0)
                    {
                        bool test = false;
                        test = (size >= used + dialogues[i + 1].DialogueLen);

                        if (!test)
                        {
                            i++;
                            return false;
                        }
                    }
                }
            }

            left = (double)(size - used);

            return true;
        }
        public void InsertIntoDialogueText(string toInsert)
        {
            char[] newText = new char[dialogueTextBox.Text.Length + toInsert.Length];

            dialogueTextBox.Text.CopyTo(0, newText, 0, dialogueTextBox.SelectionStart);
            toInsert.CopyTo(0, newText, dialogueTextBox.SelectionStart, toInsert.Length);
            dialogueTextBox.Text.CopyTo(dialogueTextBox.SelectionStart, newText, dialogueTextBox.SelectionStart + toInsert.Length, this.dialogueTextBox.Text.Length - this.dialogueTextBox.SelectionStart);

            dialogue.SetCaretPosition(this.dialogueTextBox.SelectionStart + toInsert.Length, textCodeFormat);
            dialogue.SetDialogue(new string(newText), textCodeFormat);
            RefreshDialogueEditor();
            SetTextImage();
        }
        private void SetDialogueTable(TextBox textBox)
        {
            char[] text = textBox.Text.ToCharArray();
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
                    i++;
                    temp = i;

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
                    int tempSel = textBox.SelectionStart;
                    swap = new char[text.Length + 2];
                    for (int x = 0; x < i; x++)
                        swap[x] = text[x];
                    swap[i] = '[';
                    swap[i + 1] = '1';
                    swap[i + 2] = ']';
                    for (int x = i + 3; x < swap.Length; x++)
                        swap[x] = text[x - 2];
                    textBox.Text = new string(swap);
                    text = textBox.Text.ToCharArray();
                    i += 2;
                    textBox.SelectionStart = tempSel + 2;
                }
            }
            if (preview && valid && !fail)
                dialogueTables[(int)textBox.Tag].SetDialogue(textBox.Text, textCodeFormat);
            CalculateFreeTableSpace();
        }
        // duplicate dialogues
        private void FindWithinDialogues()
        {
            int i = 0; int diff = 0;
            for (i = 0; i < 0x800; i++)
            {
                if (i < 0x7FF) diff = dialogues[i + 1].DialoguePtr - dialogues[i].DialoguePtr;
                if (i < 0x7FF && dialogues[i].RawDialogue.Length > diff && diff > 0)
                {
                    dialogues[i + 1].WithinDialogues = i;
                    dialogues[i + 1].WithinDialoguesLocation = diff;
                }
            }
            i = 0; diff = 0;
            for (i = 0x800; i < 0xC00; i++)
            {
                if (i < 0xBFF) diff = dialogues[i + 1].DialoguePtr - dialogues[i].DialoguePtr;
                if (i < 0xBFF && dialogues[i].RawDialogue.Length > diff && diff > 0)
                {
                    dialogues[i + 1].WithinDialogues = i;
                    dialogues[i + 1].WithinDialoguesLocation = diff;
                }
            }
            i = 0; diff = 0;
            for (i = 0xC00; i < 0x1000; i++)
            {
                if (i < 0xFFF) diff = dialogues[i + 1].DialoguePtr - dialogues[i].DialoguePtr;
                if (i < 0xFFF && dialogues[i].RawDialogue.Length > diff && diff > 0)
                {
                    dialogues[i + 1].WithinDialogues = i;
                    dialogues[i + 1].WithinDialoguesLocation = diff;
                }
            }
        }
        private void FindDuplicateDialoguePointers()
        {
            int i, a;
            for (i = 0; i < 0x800; i++)
            {
                a = i;
                if (dialogues[i + 1].DialoguePtr == dialogues[a].DialoguePtr)
                {
                    dialogues[i].DuplicateDialogues = i; i++;
                    while (i < 0x800 && dialogues[i].DialoguePtr == dialogues[a].DialoguePtr)
                    {
                        dialogues[i].DuplicateDialogues = a;
                        i++;
                    }
                    i--;
                }
                else dialogues[i].DuplicateDialogues = i;
            }
            for (i = 0x800; i < 0xC00; i++)
            {
                a = i;
                if (dialogues[i + 1].DialoguePtr == dialogues[a].DialoguePtr)
                {
                    dialogues[i].DuplicateDialogues = i; i++;
                    while (i < 0xC00 && dialogues[i].DialoguePtr == dialogues[a].DialoguePtr)
                    {
                        dialogues[i].DuplicateDialogues = a;
                        i++;
                    }
                    i--;
                }
                else dialogues[i].DuplicateDialogues = i;
            }
            for (i = 0xC00; i < 0x1000; i++)
            {
                a = i;
                if (dialogues[i + 1].DialoguePtr == dialogues[a].DialoguePtr)
                {
                    dialogues[i].DuplicateDialogues = i; i++;
                    while (i < 0x1000 && dialogues[i].DialoguePtr == dialogues[a].DialoguePtr)
                    {
                        dialogues[i].DuplicateDialogues = a;
                        i++;
                    }
                    i--;
                }
                else dialogues[i].DuplicateDialogues = i;
            }
        }
        private void LoadSearch(RichTextBox searchResults, StringComparison stringComparison, bool matchWholeWord, bool replaceAll, string replaceWith)
        {
            string dialogueSearch = "";
            int j = 0;

            for (int i = 0; i < dialogues.Length; i++)
            {
                string dialogue = dialogues[i].GetDialogue(textCodeFormat);
                int index = dialogue.IndexOf(textBoxSearch.Text, stringComparison);
                if (index >= 0)
                {
                    if (matchWholeWord)
                    {
                        if (index + textBoxSearch.Text.Length < dialogue.Length && Char.IsLetter(dialogue, index + textBoxSearch.Text.Length))
                            continue;
                        if (index - 1 >= 0 && Char.IsLetter(dialogue, index - 1))
                            continue;
                    }
                    j++;
                    if (replaceAll)
                    {
                        dialogue = dialogue.Replace(textBoxSearch.Text, replaceWith);
                        dialogues[i].SetDialogue(dialogue, textCodeFormat);
                    }
                    dialogueSearch += "[" + dialogues[i].Index.ToString() + "]\n";
                    dialogueSearch += dialogues[i].GetDialogue(textCodeFormat) + "\n\n";
                }
            }
            searchResults.Text = j.ToString() + " results...\n\n" + dialogueSearch;
            if (replaceAll)
            {
                MessageBox.Show(j.ToString() + " occurrences were replaced.", "LAZYSHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dialogueNum_ValueChanged(null, null);
            }
        }
        // editors
        public void LoadFontEditor()
        {
            if (fonts == null)
            {
                fonts = new Fonts(this);
                fonts.TopLevel = false;
                fonts.Dock = DockStyle.Fill;
                fonts.SetToolTips(toolTip1);
                panelDialogues.Controls.Add(fonts);
                fonts.BringToFront();
                fonts.Show();
            }
            else
                fonts.Reload(this);
        }
        public void RedrawTileset()
        {
            dialogueTileset = new DialogueTileset(fontPalette);
            SetTilesetImage();
        }
        public void RedrawText()
        {
            SetTextImage();
            battleDialogues.SetTextImage();
        }
        // assembler
        public void Assemble()
        {
            fonts.Assemble();
            battleDialogues.Assemble();
            if (!dialogueTextBox.IsDisposed && !dialogueTextBox.Text.EndsWith("[0]") && !dialogueTextBox.Text.EndsWith("[6]"))
            {
                dialogueTextBox.SelectionStart = dialogueTextBox.Text.Length;
                InsertIntoDialogueText("[0]");
            }
            // Assemble the dialogue
            string original, within;
            int temp = index;
            ushort len = 0;
            int i = 0;
            // 000 - 1ff
            if (FreeSpace(0))
            {
                len = 0x0008;
                for (i = 0; i < 0x0800 && (len + dialogues[i].DialogueLen < 0xFD18 || (i != dialogues[i].DuplicateDialogues && !isDialogueChanged[i])); i++)
                {
                    if (i == dialogues[i].DuplicateDialogues && dialogues[i].WithinDialoguesLocation == 0)
                        len += dialogues[i].Assemble(len);
                    else if (dialogues[i].WithinDialoguesLocation != 0)
                    {
                        original = new string(dialogues[dialogues[i].WithinDialogues].RawDialogue);
                        within = new string(dialogues[i].RawDialogue);
                        dialogues[i].Assemble((ushort)(dialogues[dialogues[i].WithinDialogues].DialoguePtr + original.IndexOf(within) + 8));
                    }
                    else
                        dialogues[i].Assemble((ushort)(dialogues[dialogues[i].DuplicateDialogues].DialoguePtr + 8));
                    // if the next dialogue has a smaller pointer or points to a place in the current dialogue, and both the current and next dialogues haven't changed
                }
            }
            else
                MessageBox.Show("The dialogue in bank 1 was not saved. Please delete the necessary number of bytes for space.\n\nLast dialogue saved was #" + i.ToString() + ". It should have been #2047",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (FreeSpace(0x800))
            {
                len = 0x0004;
                for (i = 0x0800; i < 0x0C00 && (len + dialogues[i].DialogueLen < 0xF2D5 || (i != dialogues[i].DuplicateDialogues && !isDialogueChanged[i])); i++)
                {
                    if (i == dialogues[i].DuplicateDialogues && dialogues[i].WithinDialoguesLocation == 0)
                        len += dialogues[i].Assemble(len);
                    else if (dialogues[i].WithinDialoguesLocation != 0)
                    {
                        original = new string(dialogues[dialogues[i].WithinDialogues].RawDialogue);
                        within = new string(dialogues[i].RawDialogue);
                        dialogues[i].Assemble((ushort)(dialogues[dialogues[i].WithinDialogues].DialoguePtr + original.IndexOf(within) + 4));
                    }
                    else
                        dialogues[i].Assemble((ushort)(dialogues[dialogues[i].DuplicateDialogues].DialoguePtr + 4));
                }
            }
            else
                MessageBox.Show("The dialogue in bank 2 was not saved. Please delete the necessary number of bytes for space.\n\nLast dialogue saved was #" + i.ToString() + ". It should have been #2047",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (FreeSpace(0xC00))
            {
                len = 0x0004;
                for (i = 0x0C00; i < 0x1000 && len + dialogues[i].DialogueLen < 0x8FFF; i++)
                {
                    if (i == dialogues[i].DuplicateDialogues && dialogues[i].WithinDialoguesLocation == 0)
                        len += dialogues[i].Assemble(len);
                    else if (dialogues[i].WithinDialoguesLocation != 0)
                    {
                        original = new string(dialogues[dialogues[i].WithinDialogues].RawDialogue);
                        within = new string(dialogues[i].RawDialogue);
                        dialogues[i].Assemble((ushort)(dialogues[dialogues[i].WithinDialogues].DialoguePtr + original.IndexOf(within) + 4));
                    }
                    else
                        dialogues[i].Assemble((ushort)(dialogues[dialogues[i].DuplicateDialogues].DialoguePtr + 4));
                }

                len = 0xEDE0;
                for (; i < 0x1000 && len + dialogues[i].DialogueLen < 0xFFFF; i++)
                {
                    if (i == dialogues[i].DuplicateDialogues && dialogues[i].WithinDialoguesLocation == 0)
                        len += dialogues[i].Assemble(len);
                    else if (dialogues[i].WithinDialoguesLocation != 0)
                    {
                        original = new string(dialogues[dialogues[i].WithinDialogues].RawDialogue);
                        within = new string(dialogues[i].RawDialogue);
                        dialogues[i].Assemble((ushort)(dialogues[dialogues[i].WithinDialogues].DialoguePtr + original.IndexOf(within) + 4));
                    }
                    else
                        dialogues[i].Assemble((ushort)(dialogues[dialogues[i].DuplicateDialogues].DialoguePtr + 4));
                }
            }
            else
                MessageBox.Show("The dialogue in bank 3 was not saved. Please delete the necessary number of bytes for space.\n\nLast dialogue saved was #" + i.ToString() + ". It should have been #2047",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            checksum = Do.GenerateChecksum(dialogues, dialogueTables, Model.BattleDialogues, Model.BattleMessages, battleDialogues.Tileset,
                fontDialogue, Model.FontMenu, Model.FontDescription, fontTriangle, fontPalette, Model.FontPaletteMenu);
        }
        #endregion
        #region Event Handlers
        // main
        private void Dialogues_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Do.GenerateChecksum(dialogues, dialogueTables, Model.BattleDialogues, Model.BattleMessages, battleDialogues.Tileset, 
                fontDialogue, Model.FontMenu, Model.FontDescription, fontTriangle, fontPalette, Model.FontPaletteMenu) == checksum)
                goto Close;
            DialogResult result = MessageBox.Show(
                "Dialogues have not been saved.\n\nWould you like to save changes?", "LAZY SHELL",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                Assemble();
            else if (result == DialogResult.No)
            {
                Model.Dialogues = null;
                Model.BattleDialogues = null;
                Model.BattleMessages = null;
                Model.DialogueGraphics = null;
                Model.BattleDialogueTileSet = null;
                Model.FontDescription = null;
                Model.FontDialogue = null;
                Model.FontMenu = null;
                Model.FontTriangle = null;
                Model.FontPaletteBattle = null;
                Model.FontPaletteDialogue = null;
                Model.FontPaletteMenu = null;
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
        Close:
            searchWindow.Close();
            fonts.NewFontTable.Close();
            battleDialogues.Close();
        }
        private void Dialogues_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
        private void panel60_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder3D(e.Graphics, panel60.ClientRectangle, Border3DStyle.Raised, Border3DSide.All);
        }
        private void dialogueNum_ValueChanged(object sender, System.EventArgs e)
        {
            if (updatingDialogue) return;

            dialoguePreview.Reset();

            RefreshDialogueEditor();
            SetTextImage();
            Settings.Default.LastDialogue = index;
        }
        private void textView_Click(object sender, EventArgs e)
        {
            this.dialogueTextBox.Text = dialogue.GetDialogue(textCodeFormat);
        }
        private void showDialogues_Click(object sender, EventArgs e)
        {
            panel60.Visible = showDialogues.Checked;
        }
        private void showBattleDialogues_Click(object sender, EventArgs e)
        {
            battleDialogues.Visible = showBattleDialogues.Checked;
        }
        private void showFonts_Click(object sender, EventArgs e)
        {
            fonts.Visible = showFonts.Checked;
        }
        private void showDialogueBG_Click(object sender, EventArgs e)
        {

        }
        private void pictureBoxDialogue_Paint(object sender, PaintEventArgs e)
        {
            if (dialogueBGImage != null)
                e.Graphics.DrawImage(dialogueBGImage, 0, 0);
            if (dialogueTextImage != null)
                e.Graphics.DrawImage(dialogueTextImage, 0, 0);
        }
        private void pageUp_Click(object sender, EventArgs e)
        {
            dialoguePreview.PageUp();
            SetTextImage();
        }
        private void pageDown_Click(object sender, EventArgs e)
        {
            dialoguePreview.PageDown(dialogue.RawDialogue.Length);
            SetTextImage();
        }
        private void toolStripButton11_Click(object sender, EventArgs e)
        {

        }
        private void dialogueTextBox_TextChanged(object sender, EventArgs e)
        {
            if (updatingDialogue) return;

            SetTextImage();

            int temp = CalculateFreeSpace();
            this.freeBytes.Text = temp.ToString() + " characters left";
            this.freeBytes.BackColor = temp >= 0 ? SystemColors.Control : Color.Red;
        }
        private void dialogueTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyValue & 0x11) == 0x11) return;    // if ctrl+some other key, cancel
            int temp = dialogue.DuplicateDialogues;
            //DialogResult result;
            if (e.KeyValue >= 0 && e.KeyValue <= 0x9F)
            {
                dialogue.DuplicateDialogues = index;
                if (!isDialogueChanged[index])
                {
                    if (index < 0x800)
                    {
                        for (int i = 0; i < 0x800; i++)
                        {
                            if (dialogues[i].DuplicateDialogues == index)
                            {
                                dialogues[i].DuplicateDialogues = i;
                            }
                            if (dialogues[i].WithinDialogues == index)
                                dialogues[i].WithinDialogues = 0;
                        }
                    }
                    else if (index < 0xC00)
                    {
                        for (int i = 0x800; i < 0xC00; i++)
                        {
                            if (dialogues[i].DuplicateDialogues == index)
                            {
                                dialogues[i].DuplicateDialogues = i;
                            }
                            if (dialogues[i].WithinDialogues == index)
                                dialogues[i].WithinDialogues = 0;
                        }
                    }
                    else if (index < 0x1000)
                    {
                        for (int i = 0xC00; i < 0x1000; i++)
                        {
                            if (dialogues[i].DuplicateDialogues == index)
                            {
                                dialogues[i].DuplicateDialogues = i;
                            }
                            if (dialogues[i].WithinDialogues == index)
                                dialogues[i].WithinDialogues = 0;
                        }
                    }
                }
                isDialogueChanged[index] = true;
            }
        }
        private void dialogueTextBox_Enter(object sender, EventArgs e)
        {
            if (index != dialogue.DuplicateDialogues)
                MessageBox.Show("This dialogue is a duplicate of another.\n\n" +
                    "Modifying it might result in a significant loss of available byte space.",
                    "LAZY SHELL");
            for (int i = 0; i < dialogues.Length; i++)
            {
                if (i != index && index == dialogues[i].DuplicateDialogues)
                {
                    MessageBox.Show("This dialogue is a template for one or more duplicates.\n\n" +
                        "Modifying it might result in a significant loss of available byte space.",
                        "LAZY SHELL");
                    break;
                }
            }
        }
        private void dialogueTextBox_Leave(object sender, EventArgs e)
        {
            if (!dialogueTextBox.Text.EndsWith("[0]") && !dialogueTextBox.Text.EndsWith("[6]"))
            {
                dialogueTextBox.SelectionStart = dialogueTextBox.Text.Length;
                InsertIntoDialogueText("[0]");
            }
        }
        // inserts
        private void newLine_Click(object sender, EventArgs e)
        {
            if (textCodeFormat)
                InsertIntoDialogueText("[1]");
            else
                InsertIntoDialogueText("[newLine]");
        }
        private void newLineA_Click(object sender, EventArgs e)
        {
            if (textCodeFormat)
                InsertIntoDialogueText("[2]");
            else
                InsertIntoDialogueText("[newLineInput]");
        }
        private void newPage_Click(object sender, EventArgs e)
        {
            if (textCodeFormat)
                InsertIntoDialogueText("[4]");
            else
                InsertIntoDialogueText("[newPage]");
        }
        private void newPageA_Click(object sender, EventArgs e)
        {
            if (textCodeFormat)
                InsertIntoDialogueText("[3]");
            else
                InsertIntoDialogueText("[newPageInput]");
        }
        private void endString_Click(object sender, EventArgs e)
        {
            if (textCodeFormat)
                InsertIntoDialogueText("[6]");
            else
                InsertIntoDialogueText("[end]");
        }
        private void endStringA_Click(object sender, EventArgs e)
        {
            if (textCodeFormat)
                InsertIntoDialogueText("[0]");
            else
                InsertIntoDialogueText("[endInput]");
        }
        private void pause60f_Click(object sender, EventArgs e)
        {
            if (textCodeFormat)
                InsertIntoDialogueText("[12]");
            else
                InsertIntoDialogueText("[delay]");
        }
        private void pauseA_Click(object sender, EventArgs e)
        {
            if (textCodeFormat)
                InsertIntoDialogueText("[5]");
            else
                InsertIntoDialogueText("[pauseInput]");
        }
        private void pauseFramesInsert_Click(object sender, EventArgs e)
        {
            if (textCodeFormat)
                InsertIntoDialogueText("[13][" + this.pauseFrameNum.Value.ToString() + "]");
            else
                InsertIntoDialogueText("[FRAME DELAY][ " + this.pauseFrameNum.Value.ToString() + "]");
            dialogueTextBox.Focus();
        }
        private void variablesInsert_Click(object sender, EventArgs e)
        {
            int variable = this.variables.SelectedIndex;
            if (textCodeFormat)
            {
                if (variable > 0)
                {
                    variable--;
                    InsertIntoDialogueText("[28][" + variable.ToString() + "]");
                }
                else
                    InsertIntoDialogueText("[26]");
            }
            else
            {
                if (variable > 0)
                {
                    variable--;
                    InsertIntoDialogueText("[NUMBER FROM EVENT MEMORY][ " + variable.ToString() + "]");
                }
                else
                    InsertIntoDialogueText("[ITEM VARIABLE FROM EVENT Memory $70A7]");
            }
            dialogueTextBox.Focus();
        }
        private void option_Click(object sender, EventArgs e)
        {
            if (textCodeFormat)
                InsertIntoDialogueText("[7]");
            else
                InsertIntoDialogueText("[option]");
        }
        private void allDialoguesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "EXPORT DIALOGUES INTO TEXT FILE...";
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.FileName = "dialogues";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter dialogues = File.CreateText(saveFileDialog.FileName);
                for (int i = 0; i < this.dialogues.Length; i++)
                {
                    dialogues.WriteLine(
                        "{" + i.ToString("d4") + "}\t" +
                        this.dialogues[i].GetDialogue(true));
                }
                dialogues.Close();
            }
        }
        private void allDialoguesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "IMPORT DIALOGUES FROM TEXT FILE...";
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
                    if (!line.EndsWith("[0]") && !line.EndsWith("[6]"))
                        line += "[0]";
                    dialogues[number].SetDialogue(line, true);
                    dialogues[number].Data = Model.Data;
                }
                dialogueNum_ValueChanged(null, null);
            }
            catch
            {
                MessageBox.Show(
                    "There was a problem loading Dialogue data. Verify that the lines in the\n" +
                    "text file are correctly named.\n\n" +
                    "Each line must begin with the 4-digit dialogue number enclosed in {},\n" +
                    "followed by a tab character, then the raw dialogue itself.",
                    "LAZY SHELL");
            }
        }
        // compression table
        private void dctApply_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "You are about to apply the compression table to all dialogues, which involves re-encoding all 4,096 dialogues. This procedure may take up to half a minute to complete.\n\nGo ahead with process?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;
            // reencode all dialogues
            ProgressBar progressBar = new ProgressBar("ENCODING DIALOGUES...", 4096);
            progressBar.Show();
            for (int i = 0; i < dialogues.Length; i++)
            {
                dialogues[i].SetDialogue(dialogues[i].GetDialogue(textCodeFormat), textCodeFormat);
                progressBar.PerformStep("ENCODING DIALOGUE #" + i.ToString("d4"));
            }
            progressBar.Close();
            dialogueNum_ValueChanged(null, null);
        }
        private void dct_TextChanged(object sender, EventArgs e)
        {
            if (updatingDialogue) return;
            SetDialogueTable((TextBox)sender);
        }
        // menu strip
        private void save_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Assemble();
            Cursor.Current = Cursors.Arrow;
        }
        private void importDialoguesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Import Dialogues";
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
                    if (textCodeFormat)
                    {
                        if (!line.EndsWith("[0]") && !line.EndsWith("[6]")) line += "[0]";
                    }
                    else
                        if (!line.EndsWith("[endInput]") && !line.EndsWith("[end]"))
                            line += "[endInput]";
                    dialogues[number].SetDialogue(line, textCodeFormat);
                    dialogues[number].Data = Model.Data;
                }
                dialogueNum_ValueChanged(null, null);
            }
            catch
            {
                MessageBox.Show(
                    "There was a problem loading dialogues. Verify that the lines are correctly named.\n\n" +
                    "Each line must begin with a 4-digit index enclosed in {}, followed by a tab character, then the raw dialogue.",
                    "LAZY SHELL");
            }
        }
        private void importBattleDialoguesToolStripMenuItem_Click(object sender, EventArgs e)
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
                    if (battleDialogues.textCodeFormat)
                    {
                        if (!line.EndsWith("[0]") && !line.EndsWith("[6]")) line += "[0]";
                    }
                    else
                        if (!line.EndsWith("[endInput]") && !line.EndsWith("[end]"))
                            line += "[endInput]";
                    Model.BattleDialogues[number].SetBattleDialogue(line, battleDialogues.textCodeFormat);
                }
                dialogueNum_ValueChanged(null, null);
            }
            catch
            {
                MessageBox.Show(
                    "There was a problem loading dialogues. Verify that the lines are correctly named.\n\n" +
                    "Each line must begin with a 4-digit index enclosed in {}, followed by a tab character, then the raw dialogue.",
                    "LAZY SHELL");
            }
        }
        private void exportDialoguesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export Dialogues";
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.FileName = "dialogues";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter dialogues = File.CreateText(saveFileDialog.FileName);
                for (int i = 0; i < this.dialogues.Length; i++)
                {
                    dialogues.WriteLine(
                        "{" + i.ToString("d4") + "}\t" +
                        this.dialogues[i].GetDialogue(textCodeFormat));
                }
                dialogues.Close();
            }
        }
        private void exportBattleDialoguesToolStripMenuItem_Click(object sender, EventArgs e)
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
                        Model.BattleDialogues[i].GetBattleDialogue(battleDialogues.textCodeFormat));
                }
                dialogues.Close();
            }
        }
        private void clearDialoguesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ClearElements(dialogues, (int)dialogueNum.Value, "CLEAR DIALOGUES...").ShowDialog();
            dialogueNum_ValueChanged(null, null);
        }
        private void clearBattleDialoguesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ClearElements(Model.BattleDialogues, battleDialogues.Index, "CLEAR BATTLE DIALOGUES...").ShowDialog();
            battleDialogues.RefreshBattleDialogue();
        }
        private void reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current dialogue. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            dialogue = new Dialogue(Model.Data, index);
            dialoguePreview.Reset();
            RefreshDialogueEditor();
            SetTextImage();
        }
        #endregion
    }
}
