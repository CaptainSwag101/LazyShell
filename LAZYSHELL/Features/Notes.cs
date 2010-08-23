using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    public partial class Notes : Form
    {
        #region Variables
        private Model model = State.Instance.Model;
        private Settings settings = Settings.Default;
        private ArrayList currentIndexes;
        private NotesDB.Index currentIndex;
        private State state = State.Instance;
        private NotesDB notes; public NotesDB ThisNotes { get { return notes; } set { notes = value; } }
        public ComboBox ElementType { get { return elementType; } set { elementType = value; } }
        public ListBox ElementIndexes { get { return elementIndexes; } set { elementIndexes = value; } }
        public NumericUpDown IndexNumber { get { return indexNumber; } set { indexNumber = value; } }
        public TextBox IndexLabel { get { return indexLabel; } set { indexLabel = value; } }
        public RichTextBox IndexDescription { get { return indexDescription; } set { indexDescription = value; } }
        private bool updating = false;
        #endregion
        // constructor
        public Notes()
        {
            this.model.Notes = notes;
            InitializeComponent();
            if (settings.LoadNotes)
            {
                if (!File.Exists(settings.NotePathCustom))
                {
                    MessageBox.Show("Error loading last used database. The file has been moved, renamed, or no longer exists.",
                        "LAZY SHELL");
                    return;
                }
                Stream s = File.OpenRead(settings.NotePathCustom);
                BinaryFormatter b = new BinaryFormatter();
                notes = (NotesDB)b.Deserialize(s);
                s.Close();

                notesFile.Text = settings.NotePathCustom;
                elementType.SelectedIndex = 1;
                generalNotes.Text = notes.GeneralNotes;
                tabControl1.Enabled = true;
                buttonOK.Enabled = true;
                save.Enabled = true;
                saveAs.Enabled = true;
            }
        }
        #region Functions
        private void RefreshElementIndexes()
        {
            updating = true;
            panelAddressBit.Visible = false;
            panelIndexNumber.Visible = true;
            panelIndexNumber.BringToFront();
            elementIndexes.BeginUpdate();
            elementIndexes.Items.Clear();
            switch (elementType.SelectedItem.ToString())
            {
                case "  Levels":
                    currentIndexes = notes.Levels;
                    indexNumber.Maximum = 509;
                    break;
                case "  Event Scripts":
                    currentIndexes = notes.EventScripts;
                    indexNumber.Maximum = 4095;
                    break;
                case "  Action Scripts":
                    currentIndexes = notes.ActionScripts;
                    indexNumber.Maximum = 1023;
                    break;
                case "  Battle Scripts":
                    currentIndexes = notes.BattleScripts;
                    indexNumber.Maximum = 255;
                    break;
                case "  Memory Bits":
                    currentIndexes = notes.MemoryBits;
                    panelIndexNumber.Visible = false;
                    panelAddressBit.Visible = true;
                    panelAddressBit.BringToFront();
                    break;
                case "  Sprites":
                    currentIndexes = notes.Sprites;
                    indexNumber.Maximum = 1023;
                    break;
                case "  Effects":
                    currentIndexes = notes.Effects;
                    indexNumber.Maximum = 127;
                    break;
                case "  Dialogues":
                    currentIndexes = notes.Dialogues;
                    indexNumber.Maximum = 4095;
                    break;
                case "  Monsters":
                    currentIndexes = notes.Monsters;
                    indexNumber.Maximum = 255;
                    break;
                case "  Formations":
                    currentIndexes = notes.Formations;
                    indexNumber.Maximum = 511;
                    break;
                case "  Packs":
                    currentIndexes = notes.Packs;
                    indexNumber.Maximum = 255;
                    break;
                case "  Spells":
                    currentIndexes = notes.Spells;
                    indexNumber.Maximum = 127;
                    break;
                case "  Attacks":
                    currentIndexes = notes.Attacks;
                    indexNumber.Maximum = 128;
                    break;
                case "  Items":
                    currentIndexes = notes.Items;
                    indexNumber.Maximum = 255;
                    break;
                case "  Shops":
                    currentIndexes = notes.Shops;
                    indexNumber.Maximum = 32;
                    break;
                default:
                    panel1.Enabled = false;
                    groupBox1.Enabled = false;
                    indexNumber.Value = 0;
                    indexLabel.Text = "";
                    indexDescription.Text = "";
                    elementIndexes.EndUpdate();
                    updating = false;
                    return;
            }
            panel1.Enabled = true;
            if (currentIndexes.Count == 0)
            {
                buttonDelete.Enabled = false;
                buttonMoveDown.Enabled = false;
                buttonMoveUp.Enabled = false;
                buttonLoad.Enabled = false;
                groupBox1.Enabled = false;
                indexNumber.Value = 0;
                address.Value = 0x7000;
                indexLabel.Text = "";
                indexDescription.Text = "";
            }

            foreach (NotesDB.Index index in currentIndexes)
            {
                if (numerize.Checked)
                    elementIndexes.Items.Add("[" + index.IndexNumber.ToString("d4") + "]  " + index.IndexLabel);
                else
                    elementIndexes.Items.Add(index.IndexLabel);
            }
            elementIndexes.EndUpdate();

            updating = false;
        }
        private void RefreshIndex()
        {
            updating = true;

            buttonDelete.Enabled = true;
            buttonMoveDown.Enabled = true;
            buttonMoveUp.Enabled = true;
            buttonLoad.Enabled = true;
            groupBox1.Enabled = true;
            currentIndex = (NotesDB.Index)currentIndexes[elementIndexes.SelectedIndex];
            indexNumber.Value = currentIndex.IndexNumber;
            indexLabel.Text = currentIndex.IndexLabel;
            indexDescription.Text = currentIndex.IndexDescription;

            updating = false;
        }
        public bool LoadNotes()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = settings.NotePathCustom;
            openFileDialog.Title = "Open existing notes database...";
            openFileDialog.FileName = model.GetFileNameWithoutPath() + " - notes.lsnotes";
            openFileDialog.Filter = "Notes database (*.lsnotes)|*.lsnotes";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.Cancel) return false;

            settings.NotePathCustom = openFileDialog.FileName;

            Stream s = File.OpenRead(openFileDialog.FileName);
            BinaryFormatter b = new BinaryFormatter();
            try
            {
                notes = (NotesDB)b.Deserialize(s);
            }
            catch (Exception ex)
            {
                MessageBox.Show("This is not a valid notes database file.", "LAZY SHELL",
                MessageBoxButtons.OK);
                s.Close();
                return false;
            }
            s.Close();

            notesFile.Text = openFileDialog.FileName;
            if (elementType.SelectedIndex == 1)
                RefreshElementIndexes();
            else
                elementType.SelectedIndex = 1;
            generalNotes.Text = notes.GeneralNotes;
            tabControl1.Enabled = true;
            buttonOK.Enabled = true;
            save.Enabled = true;
            saveAs.Enabled = true;

            return true;
        }
        private bool CreateNewNotes()
        {
            if (notes != null)
            {
                DialogResult result = MessageBox.Show("Save changes to currently loaded notes?",
                    "LAZY SHELL", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                    SaveLoadedNotes();
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = settings.NotePathCustom;
            saveFileDialog.Title = "Create new notes database...";
            saveFileDialog.FileName = model.GetFileNameWithoutPath() + " - notes.lsnotes";
            saveFileDialog.Filter = "Notes database (*.lsnotes)|*.lsnotes";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return false;

            settings.NotePathCustom = saveFileDialog.FileName;

            Stream s = File.Create(saveFileDialog.FileName);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, new NotesDB());
            s.Close();

            // now load the notes
            s = File.OpenRead(saveFileDialog.FileName);
            b = new BinaryFormatter();
            notes = (NotesDB)b.Deserialize(s);
            s.Close();

            notesFile.Text = saveFileDialog.FileName;
            if (elementType.SelectedIndex == 1)
                RefreshElementIndexes();
            else
                elementType.SelectedIndex = 1;
            tabControl1.Enabled = true;
            buttonOK.Enabled = true;
            save.Enabled = true;
            saveAs.Enabled = true;

            return true;
        }
        private void SaveNewNotes(string path)
        {
            model.Notes = notes;

            Stream s = File.Create(path);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, new NotesDB());
            s.Close();
        }
        private void SaveLoadedNotes()
        {
            Stream s = File.Create(notesFile.Text);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, notes);
            s.Close();
        }
        private void AddNewIndex()
        {
            if (elementIndexes.SelectedIndex != -1)
                notes.AddIndex(elementIndexes.SelectedIndex + 1, currentIndexes);
            else
                notes.AddIndex(0, currentIndexes);
            int selectedIndex = elementIndexes.SelectedIndex;
            RefreshElementIndexes();
            elementIndexes.SelectedIndex = selectedIndex + 1;
        }
        public void AddingFromEditor(int type, int number, string label, string description)
        {
            elementType.SelectedIndex = type;
            if (elementIndexes.Items.Count > 0)
                elementIndexes.SelectedIndex = elementIndexes.Items.Count - 1;
            AddNewIndex();
            indexNumber.Value = number;
            indexLabel.Text = label;
            indexDescription.Text = "";
        }
        public void AddingFromEditor(int type, int address, int addressBit, string label, string description)
        {
            elementType.SelectedIndex = type;
            if (elementIndexes.Items.Count > 0)
                elementIndexes.SelectedIndex = elementIndexes.Items.Count - 1;
            AddNewIndex();
            this.address.Value = address;
            this.addressBit.Value = addressBit;
            indexLabel.Text = label;
            indexDescription.Text = "";
        }
        #endregion
        #region Event Handlers
        private void Notes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (notes == null) return;
            DialogResult result = MessageBox.Show("Save changes to notes?", "LAZY SHELL",
            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                SaveLoadedNotes();
            if (result == DialogResult.Cancel)
                e.Cancel = true;
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            SaveLoadedNotes();
            this.Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (notes != null)
            {
                DialogResult result = MessageBox.Show("Save changes to currently loaded notes?", "LAZY SHELL",
                    MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                    SaveLoadedNotes();
                if (result == DialogResult.Cancel)
                    return;
            }
            LoadNotes();
        }
        // loading editors
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (elementType.SelectedIndex == 1)
            {
                if (model.Program.Levels == null || !model.Program.Levels.Visible)
                    model.Program.CreateLevelsWindow();
                model.Program.Levels.LevelNum.Value = indexNumber.Value;
                model.Program.Levels.BringToFront();
            }
            if (elementType.SelectedIndex == 4)
            {
                if (model.Program.EventScripts == null || !model.Program.EventScripts.Visible)
                    model.Program.CreateEventScriptsWindow();
                model.Program.EventScripts.EventName.SelectedIndex = 0;
                model.Program.EventScripts.EventNum.Value = indexNumber.Value;
                model.Program.EventScripts.BringToFront();
            }
            if (elementType.SelectedIndex == 5)
            {
                if (model.Program.EventScripts == null || !model.Program.EventScripts.Visible)
                    model.Program.CreateEventScriptsWindow();
                model.Program.EventScripts.EventName.SelectedIndex = 1;
                model.Program.EventScripts.EventNum.Value = indexNumber.Value;
                model.Program.EventScripts.BringToFront();
            }
            if (elementType.SelectedIndex == 6)
            {
                if (model.Program.BattleScripts == null || !model.Program.BattleScripts.Visible)
                    model.Program.CreateBattleScriptsWindow();
                model.Program.BattleScripts.index = (int)indexNumber.Value;
                model.Program.BattleScripts.BringToFront();
            }
            if (elementType.SelectedIndex == 10)
            {
                if (model.Program.Sprites == null || !model.Program.Sprites.Visible)
                    model.Program.CreateSpritesWindow();
                model.Program.Sprites.index = (int)indexNumber.Value;
                model.Program.Sprites.BringToFront();
            }
            if (elementType.SelectedIndex == 11)
            {
                if (model.Program.Effects == null || !model.Program.Effects.Visible)
                    model.Program.CreateEffectsWindow();
                model.Program.Effects.index = (int)indexNumber.Value;
                model.Program.Effects.BringToFront();
            }
            if (elementType.SelectedIndex == 12)
            {
                if (model.Program.Dialogues == null || !model.Program.Dialogues.Visible)
                    model.Program.CreateDialoguesWindow();
                model.Program.Dialogues.index = (int)indexNumber.Value;
                model.Program.Dialogues.BringToFront();
            }
            if (elementType.SelectedIndex == 15)
            {
                if (model.Program.Monsters == null || !model.Program.Monsters.Visible)
                    model.Program.CreateMonstersWindow();
                model.Program.Monsters.index = (int)indexNumber.Value;
                model.Program.Monsters.BringToFront();
            }
            if (elementType.SelectedIndex == 16)
            {
                if (model.Program.Formations == null || !model.Program.Formations.Visible)
                    model.Program.CreateFormationsWindow();
                model.Program.Formations.FormationIndex = (int)indexNumber.Value;
                model.Program.Formations.BringToFront();
            }
            if (elementType.SelectedIndex == 17)
            {
                if (model.Program.Formations == null || !model.Program.Formations.Visible)
                    model.Program.CreateFormationsWindow();
                model.Program.Formations.PackIndex = (int)indexNumber.Value;
                model.Program.Formations.BringToFront();
            }
            if (elementType.SelectedIndex == 18)
            {
                if (model.Program.Attacks == null || !model.Program.Attacks.Visible)
                    model.Program.CreateAttacksWindow();
                model.Program.Attacks.spellsEditor.Index = (int)indexNumber.Value;
                model.Program.Attacks.BringToFront();
            }
            if (elementType.SelectedIndex == 19)
            {
                if (model.Program.Attacks == null || !model.Program.Attacks.Visible)
                    model.Program.CreateAttacksWindow();
                model.Program.Attacks.attacksEditor.Index = (int)indexNumber.Value;
                model.Program.Attacks.BringToFront();
            }
            if (elementType.SelectedIndex == 20)
            {
                if (model.Program.Items == null || !model.Program.Items.Visible)
                    model.Program.CreateItemsWindow();
                model.Program.Items.itemsEditor.Index = (int)indexNumber.Value;
                model.Program.Items.BringToFront();
            }
            if (elementType.SelectedIndex == 21)
            {
                if (model.Program.Items == null || !model.Program.Items.Visible)
                    model.Program.CreateItemsWindow();
                model.Program.Items.shopsEditor.Index = (int)indexNumber.Value;
                model.Program.Items.BringToFront();
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (elementIndexes.SelectedIndex == -1)
                return;
            notes.DeleteIndex(elementIndexes.SelectedIndex, currentIndexes);
            int selectedIndex = elementIndexes.SelectedIndex;
            RefreshElementIndexes();
            if (currentIndexes.Count > 0)
                elementIndexes.SelectedIndex = Math.Min(selectedIndex, currentIndexes.Count - 1);
        }
        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            if (elementIndexes.SelectedIndex == 0) return;
            notes.SwitchIndex(elementIndexes.SelectedIndex - 1, currentIndexes);
            int selectedIndex = elementIndexes.SelectedIndex;
            RefreshElementIndexes();
            elementIndexes.SelectedIndex = selectedIndex - 1;
        }
        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            if (elementIndexes.SelectedIndex >= elementIndexes.Items.Count - 1) return;
            notes.SwitchIndex(elementIndexes.SelectedIndex, currentIndexes);
            int selectedIndex = elementIndexes.SelectedIndex;
            RefreshElementIndexes();
            elementIndexes.SelectedIndex = selectedIndex + 1;
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddNewIndex();
        }
        // notes properties
        private void elementType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            RefreshElementIndexes();

            if (elementIndexes.Items.Count > 0)
                elementIndexes.SelectedIndex = 0;
        }
        private void elementIndexes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            RefreshIndex();
        }
        private void indexNumber_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            currentIndex.IndexNumber = (int)indexNumber.Value;
        }
        private void indexLabel_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            currentIndex.IndexLabel = indexLabel.Text;
            int selectedIndex = elementIndexes.SelectedIndex;
            RefreshElementIndexes();
            elementIndexes.SelectedIndex = selectedIndex;
        }
        private void indexDescription_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            currentIndex.IndexDescription = indexDescription.Text;
        }
        private void address_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            currentIndex.Address = (int)address.Value;
        }
        private void addressBit_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            currentIndex.AddressBit = (int)addressBit.Value;
        }
        private void generalNotes_TextChanged(object sender, EventArgs e)
        {
            notes.GeneralNotes = generalNotes.Text;
        }
        // toolstrip
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewNotes();
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadNotes();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveLoadedNotes();
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = settings.NotePathCustom;
            saveFileDialog.Title = "Save as new notes database...";
            saveFileDialog.FileName = model.GetFileNameWithoutPath() + " - notes.lsnotes";
            saveFileDialog.Filter = "Notes database (*.lsnotes)|*.lsnotes";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;

            settings.NotePathCustom = saveFileDialog.FileName.Substring(saveFileDialog.FileName.LastIndexOf('\x5c') + 1);

            Stream s = File.Create(saveFileDialog.FileName);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, notes);
            s.Close();
        }
        private void alwaysOnTopToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = alwaysOnTop.Checked;
        }
        private void tagIndexesWithNumbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedIndex = elementIndexes.SelectedIndex;
            RefreshElementIndexes();
            elementIndexes.SelectedIndex = selectedIndex;
        }
        #endregion
    }
}
