using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Properties;

namespace LAZYSHELL.Dialogues
{
    public partial class DialoguesForm : Controls.DockForm
    {
        #region Variables

        // Forms
        private FindReferences findReferencesForm;

        // Index
        public int Index
        {
            get { return (int)num.Value; }
            set { num.Value = value; }
        }

        // Misc
        private Settings settings = Settings.Default;
        private BackgroundWorker setFreeBytes;
        private bool setFreeBytesPending;

        // Functions
        private delegate void PerformSearchFunction(string searchFor, TextBox textBox, StringComparison stringComparison, bool matchWholeWord, bool replaceAll, string replaceWith);

        // Elements
        private Dialogue[] dialogues
        {
            get { return Model.Dialogues; }
            set { Model.Dialogues = value; }
        }
        private Dialogue dialogue
        {
            get { return dialogues[Index]; }
            set { dialogues[Index] = value; }
        }

        // Fonts
        private Fonts.Glyph[] fontDialogue
        {
            get { return Fonts.Model.Dialogue; }
        }
        private Fonts.Glyph[] fontTriangle
        {
            get { return Fonts.Model.Triangle; }
        }
        private PaletteSet fontPalette
        {
            get { return Fonts.Model.Palette_Dialogue; }
            set { Fonts.Model.Palette_Dialogue = value; }
        }

        // Picture
        private Bitmap bgImage;
        private Bitmap textImage;
        public DialoguePreview DialoguePreview { get; set; }
        private DialogueTileset dialogueTileset;

        // Text managing
        private ParserMain parser;
        public bool ByteView
        {
            get { return !textView.Checked; }
            set { textView.Checked = !value; }
        }
        private DTE[] dte
        {
            get { return Model.DTE; }
            set { Model.DTE = value; }
        }
        public string[] DTEStrByte { get; set; }
        public string[] DTEStrText { get; set; }
        private string[] dteStr
        {
            get
            {
                if (ByteView)
                    return DTEStrByte;
                else
                    return DTEStrText;
            }
            set
            {
                if (ByteView)
                    DTEStrByte = value;
                else
                    DTEStrText = value;
            }
        }

        // Helping forms
        private Search searchWindow;
        private EditLabel labelWindow;
        private delegate void FindReferencesFunction(TreeView treeView);

        #endregion

        // Constructor
        public DialoguesForm(OwnerForm ownerForm)
        {
            // Initialization
            InitializeComponent();
            InitializeVariables();
            InitializeNavigators();
            InitializeListControls();
            CreateHelperForms();

            // Load properties
            LoadProperties();
            SetFreeBytesLabel();
            SetTilesetImage();
            SetOptionImage();
            SetTextImage();

            // History logging
            this.History = new History(this, null, num);
        }

        #region Methods

        #region Initialization

        // Initialization
        private void CreateHelperForms()
        {
            searchWindow = new Search(num, search, new PerformSearchFunction(PerformSearch), typeof(TextBox));
            labelWindow = new EditLabel(null, num, "Dialogues", false);
        }
        private void InitializeVariables()
        {
            // BackgroundWorker
            setFreeBytes = new BackgroundWorker();
            setFreeBytes.WorkerSupportsCancellation = true;
            setFreeBytes.DoWork += new DoWorkEventHandler(setFreeBytes_DoWork);
            setFreeBytes.RunWorkerCompleted += new RunWorkerCompletedEventHandler(setFreeBytes_RunWorkerCompleted);

            // Variables
            parser = ParserMain.Instance;
            DTEStrByte = Model.DTEStr(true);
            DTEStrText = Model.DTEStr(false);
            DialoguePreview = new DialoguePreview();
            dialogueTileset = new DialogueTileset(Fonts.Model.Palette_Dialogue);

            // Set option triangle image
            int[] optionPixels = fontTriangle[0].GetPixels(fontPalette.Palettes[1]);
            option.Image = Do.PixelsToImage(optionPixels, 8, 16);
        }
        private void InitializeNavigators()
        {
            this.Updating = true;
            //
            if (settings.RememberLastIndex)
                Index = settings.LastDialogue;
            //
            this.Updating = false;
        }
        private void InitializeListControls()
        {
            this.Updating = true;
            //
            variables.SelectedIndex = 0;
            //
            this.Updating = false;
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
            this.textBox.Text = dialogue.GetText(ByteView, dteStr);
            this.textBox.SelectionStart = selectionStart;
            //
            this.Updating = false;
        }
        private void SetFreeBytesLabel()
        {
            if (setFreeBytes.IsBusy)
            {
                setFreeBytes.CancelAsync();
                setFreeBytesPending = true;
            }
            else
                setFreeBytes.RunWorkerAsync(this.Index);
        }
        /// <summary>
        /// Determines if the bank of a previous index is different from the current index.
        /// </summary>
        /// <param name="prevIndex">Previous index.</param>
        /// <param name="currIndex">Current index.</param>
        /// <returns></returns>
        private bool BankChanged(int prevIndex, int currIndex)
        {
            int prevBank = 0x220000;
            int currBank = 0x220000;
            if (prevIndex >= 3072)
                prevBank = 0x240000;
            else if (prevIndex >= 0x2048)
                prevBank = 0x230000;
            if (currIndex >= 3072)
                currBank = 0x240000;
            else if (currIndex >= 2048)
                currBank = 0x230000;
            if (currBank != prevBank)
                return true;
            return false;
        }

        #endregion

        #region Picture

        public void SetTextImage()
        {
            int[] pixels = DialoguePreview.GetPreview(fontDialogue, fontTriangle, fontPalette.Palettes[1], fontPalette.Palettes[1], dialogue.Text, 16);
            textImage = Do.PixelsToImage(pixels, 256, 56);
            picture.Invalidate();
        }
        public void SetOptionImage()
        {
            option.Image = Do.PixelsToImage(fontTriangle[0].GetPixels(fontPalette.Palettes[1]), 8, 16, 16, 16);
        }
        private void SetTilesetImage()
        {
            bgImage = Do.PixelsToImage(
                Do.TilesetToPixels(dialogueTileset.Tileset_tiles, 16, 4, 0, false), 256, 56);
            picture.Invalidate();
        }
        public void RedrawTileset()
        {
            dialogueTileset.RedrawTileset();
            SetTilesetImage();
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
            if (parser.VerifyText(textBox.Text, ByteView))
            {
                dialogue.SetText(textBox.Text, ByteView, dteStr);
                SetTextImage();
            }
        }

        #endregion

        #region Data management

        public void Reset()
        {
            if (MessageBox.Show("You're about to undo all changes to the current dialogue. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            dialogue = new Dialogue(Index);
            DialoguePreview.Reset();
            LoadProperties();
            SetTextImage();
        }
        public void Import()
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
            this.Enabled = false;
            this.Text = "***IMPORTING DIALOGUES***";
            try
            {
                var tables = dteStr;
                tr = new StreamReader(path);
                while (tr.Peek() != -1)
                {
                    string line = tr.ReadLine();
                    int index = Convert.ToInt32(line.Substring(1, 4), 10);
                    line = line.Remove(0, 7);
                    if (this.ByteView)
                    {
                        if (!line.EndsWith("[0]") && !line.EndsWith("[6]"))
                            line += "[0]";
                    }
                    else
                        if (!line.EndsWith("[endInput]") && !line.EndsWith("[end]"))
                            line += "[endInput]";
                    dialogues[index].SetText(line, line.EndsWith("[0]") || line.EndsWith("[6]"), tables);
                    if (index % 16 == 0)
                        progressBar1.PerformStep();
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
            this.Enabled = true;
            this.Text = "DIALOGUES - Lazy Shell";
            progressBar1.Value = 0;
        }
        public void Export()
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
                        this.dialogues[i].GetText(ByteView, dteStr));
                }
                dialogues.Close();
            }
        }
        public void Clear()
        {
            new ClearElements(dialogues, (int)Index, "CLEAR DIALOGUES...").ShowDialog();
            num_ValueChanged(null, null);
        }

        #endregion

        // Saving
        public void WriteToROM()
        {
            if (!textBox.IsDisposed && !textBox.Text.EndsWith("[0]") && !textBox.Text.EndsWith("[6]"))
            {
                textBox.SelectionStart = textBox.Text.Length;
                InsertIntoText("[0]");
            }

            // Assemble the dialogue
            int offset = 0;
            int i = 0;

            // Assemble table
            if (Model.FreeDTESpace() >= 0)
            {
                for (i = 0; i < dte.Length && offset + dte[i].Length < 0x40; i++)
                    dte[i].WriteToROM(ref offset);
            }
            else
                MessageBox.Show("The dialogue table was not saved. Please delete the necessary number of bytes for space.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 0 - 2047
            if (Model.FreeDialogueSpace(0) >= 0)
            {
                offset = 0x220008; // Dialogues start right after end of pointer table
                for (i = 0; i < 2048 && offset + dialogues[i].Length < 0x22FD18; i++)
                    WriteToROM(0, i, ref offset);
            }
            else
                MessageBox.Show("The dialogue in bank 0x22 was not saved. Please delete the necessary number of bytes for space.\n\n" +
                    "Last dialogue saved was #" + i.ToString() + ". It should have been #2047",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 2048 - 3071
            if (Model.FreeDialogueSpace(0x800) >= 0)
            {
                offset = 0x230004; // Dialogues start right after end of pointer table
                for (i = 2048; i < 3072 && offset + dialogues[i].Length < 0x23F2D5; i++)
                    WriteToROM(2048, i, ref offset);
            }
            else
                MessageBox.Show("The dialogue in bank 0x23 was not saved. Please delete the necessary number of bytes for space.\n\n" +
                    "Last dialogue saved was #" + i.ToString() + ". It should have been #3091",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 3072 - 4095
            if (Model.FreeDialogueSpace(0xC00) >= 0)
            {
                offset = 0x240004; // Dialogues start right after end of pointer table
                for (i = 3072; i < 4096 && offset + dialogues[i].Length < 0x248FFF; i++)
                    WriteToROM(3072, i, ref offset);

                // Write to extra space if necessary
                offset = 0x24EDE0;
                int start = i; // Need to retain first index of dialogue using extra space
                for (; i < 4096 && offset + dialogues[i].Length < 0x24FFFF; i++)
                    WriteToROM(start, i, ref offset);
            }
            else
                MessageBox.Show("The dialogue in bank 0x24 was not saved. Please delete the necessary number of bytes for space.\n\n" +
                    "Last dialogue saved was #" + i.ToString() + ". It should have been #4095",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void WriteToROM(int start, int index, ref int offset)
        {
            // First check if current dialogue can reference another or another's substring
            for (int i = start; i < index; i++)
            {
                // Write to ROM at offset of reference
                if (Bits.Compare(dialogues[index].Text, dialogues[i].Text))
                {
                    dialogues[index].WriteToROM(dialogues[i].Offset);
                    return;
                }
                else if (Bits.EndsWith(dialogues[i].Text, dialogues[index].Text))
                {
                    // Write to ROM at offset of substring
                    int lengthDiff = dialogues[i].Text.Length - dialogues[index].Text.Length;
                    dialogues[index].WriteToROM(dialogues[i].Offset + lengthDiff);
                    return;
                }
            }
            dialogues[index].WriteToROM(ref offset);
        }

        // Search
        private void PerformSearch(string searchFor, TextBox searchResults, StringComparison stringComparison, bool matchWholeWord, bool replaceAll, string replaceWith)
        {
            string dialogueSearch = "";
            int j = 0;
            for (int i = 0; i < dialogues.Length; i++)
            {
                string dialogue = dialogues[i].GetText(ByteView, dteStr);
                int index = dialogue.IndexOf(searchFor, stringComparison);
                if (index >= 0)
                {
                    if (matchWholeWord)
                    {
                        if (index + searchFor.Length < dialogue.Length && Char.IsLetter(dialogue, index + searchFor.Length))
                            continue;
                        if (index - 1 >= 0 && Char.IsLetter(dialogue, index - 1))
                            continue;
                    }
                    j++;
                    if (replaceAll)
                    {
                        dialogue = dialogue.Replace(searchFor, replaceWith);
                        dialogues[i].SetText(dialogue, ByteView, dteStr);
                    }
                    dialogueSearch += "[" + dialogues[i].Index.ToString() + "]\n";
                    dialogueSearch += dialogues[i].GetText(ByteView, dteStr) + "\n\n";
                }
            }
            searchResults.Text = j.ToString() + " results...\n\n" + dialogueSearch;
            if (replaceAll)
            {
                MessageBox.Show(j.ToString() + " occurrences were replaced.",
                    "LAZYSHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                num_ValueChanged(null, null);
            }
        }
        private void FindReferences(TreeView treeView)
        {
            // look through event scripts
            var eventScriptResults = new TreeNode();
            foreach (var eventScript in EventScripts.Model.EventScripts)
            {
                foreach (var command in eventScript.Commands)
                {
                    byte opcode = command.Opcode;
                    byte param1 = command.Param1;
                    if (opcode == 0x60 || opcode == 0x62)
                    {
                        int runDialogue = Bits.GetShort(command.Data, 1) & 0xFFF;

                        // if points to this dialogue, create a node from result and add to the parent node
                        if (runDialogue == this.Index)
                        {
                            var result = command.Node;
                            result.Tag = command;
                            eventScriptResults.Nodes.Add(result);
                        }
                    }
                }
            }
            if (eventScriptResults.Nodes.Count > 0)
            {
                eventScriptResults.Text = "EVENT SCRIPTS — found " + eventScriptResults.Nodes.Count + " results";
                treeView.Nodes.Add(eventScriptResults);
            }
        }

        #endregion

        #region Event Handlers

        // MenuStrip
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
            Reset();
        }

        // Navigators
        private void num_ValueChanged(object sender, System.EventArgs e)
        {
            if (this.Updating)
                return;
            DialoguePreview.Reset();
            LoadProperties();
            SetTextImage();
            SetFreeBytesLabel();

            // Finished
            settings.LastDialogue = Index;
        }
        private void findReferences_Click(object sender, EventArgs e)
        {
            if (findReferencesForm == null)
            {
                findReferencesForm = new FindReferences(new FindReferencesFunction(FindReferences), null);
                findReferencesForm.Owner = this;
            }
            else
                findReferencesForm.Reload();
            findReferencesForm.Show();
        }
        private void setFreeBytes_DoWork(object sender, DoWorkEventArgs e)
        {
            int used = 0;
            int size = 0;
            int end = 0;
            int start = (int)e.Argument;
            if (start >= 3072)
            {
                size = (0xFFFF - 0xEDE0) + 0x9000;
                start = 3072;
                end = 4096;
            }
            else if (start >= 2048)
            {
                size = 0xF2D5;
                start = 2048;
                end = 3072;
            }
            else
            {
                size = 0xFD18;
                start = 0;
                end = 2048;
            }
            for (int i = start; i < end; i++)
            {
                if (setFreeBytes.CancellationPending)
                    break;
                used += setFreeBytes_DoWork(start, i);
            }

            // Finished
            e.Result = size - used;
        }
        private int setFreeBytes_DoWork(int start, int index)
        {
            // First check if current dialogue can reference another or another's substring
            for (int i = start; i < index; i++)
            {
                if (setFreeBytes.CancellationPending)
                    break;

                // Write to ROM at offset of reference
                if (Bits.Compare(dialogues[index].Text, dialogues[i].Text))
                    return 0;
                else if (Bits.EndsWith(dialogues[i].Text, dialogues[index].Text))
                    return 0;
            }
            return dialogues[index].Length;
        }
        private void setFreeBytes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (setFreeBytesPending)
            {
                setFreeBytesPending = false;
                SetFreeBytesLabel();
            }
            else if (!e.Cancelled)
            {
                int freeBytes = (int)e.Result;
                this.freeBytes.Text = freeBytes + " characters left";
                this.freeBytes.BackColor = freeBytes >= 0 ? SystemColors.Control : Color.Red;
            }
        }

        // Picture
        private void picture_Paint(object sender, PaintEventArgs e)
        {
            if (bgImage != null)
                e.Graphics.DrawImage(bgImage, 0, 0);
            if (textImage != null)
                e.Graphics.DrawImage(textImage, 0, 0);
        }

        // Page navigators
        private void pageUp_Click(object sender, EventArgs e)
        {
            DialoguePreview.PageUp();
            SetTextImage();
        }
        private void pageDown_Click(object sender, EventArgs e)
        {
            DialoguePreview.PageDown();
            SetTextImage();
        }

        // TextBox
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            parser.ReplaceLineBreaks(textBox, ByteView);
            UpdateDialogueText();
            SetFreeBytesLabel();
        }
        private void textBox_Enter(object sender, EventArgs e)
        {
        }
        private void textBox_Leave(object sender, EventArgs e)
        {
            if (!textBox.Text.EndsWith("[0]") && !textBox.Text.EndsWith("[6]"))
            {
                textBox.SelectionStart = textBox.Text.Length;
                InsertIntoText("[0]");
            }
        }

        // Insert text
        private void newLine_Click(object sender, EventArgs e)
        {
            if (ByteView)
                InsertIntoText("[1]");
            else
                InsertIntoText("[newLine]");
        }
        private void newLineA_Click(object sender, EventArgs e)
        {
            if (ByteView)
                InsertIntoText("[2]");
            else
                InsertIntoText("[newLineInput]");
        }
        private void newPage_Click(object sender, EventArgs e)
        {
            if (ByteView)
                InsertIntoText("[4]");
            else
                InsertIntoText("[newPage]");
        }
        private void newPageA_Click(object sender, EventArgs e)
        {
            if (ByteView)
                InsertIntoText("[3]");
            else
                InsertIntoText("[newPageInput]");
        }
        private void endString_Click(object sender, EventArgs e)
        {
            if (ByteView)
                InsertIntoText("[6]");
            else
                InsertIntoText("[end]");
        }
        private void endStringA_Click(object sender, EventArgs e)
        {
            if (ByteView)
                InsertIntoText("[0]");
            else
                InsertIntoText("[endInput]");
        }
        private void pause60f_Click(object sender, EventArgs e)
        {
            if (ByteView)
                InsertIntoText("[12]");
            else
                InsertIntoText("[delay]");
        }
        private void pauseA_Click(object sender, EventArgs e)
        {
            if (ByteView)
                InsertIntoText("[5]");
            else
                InsertIntoText("[pauseInput]");
        }
        private void option_Click(object sender, EventArgs e)
        {
            if (ByteView)
                InsertIntoText("[7]");
            else
                InsertIntoText("[option]");
        }

        // Insert text : Parameters
        private void pauseFramesInsert_Click(object sender, EventArgs e)
        {
            if (ByteView)
                InsertIntoText("[13][" + this.pauseFrameNum.Value.ToString() + "]");
            else
                InsertIntoText("[FRAME DELAY][ " + this.pauseFrameNum.Value.ToString() + "]");
            textBox.Focus();
        }
        private void variablesInsert_Click(object sender, EventArgs e)
        {
            int variable = this.variables.SelectedIndex;
            if (ByteView)
            {
                if (variable > 0)
                {
                    variable--;
                    InsertIntoText("[28][" + variable.ToString() + "]");
                }
                else
                    InsertIntoText("[26]");
            }
            else
            {
                if (variable > 0)
                {
                    variable--;
                    InsertIntoText("[NUMBER FROM EVENT MEMORY][ " + variable.ToString() + "]");
                }
                else
                    InsertIntoText("[ITEM VARIABLE FROM EVENT Memory $70A7]");
            }
            textBox.Focus();
        }

        #endregion
    }
}
