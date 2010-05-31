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
        private Model model;
        private Settings settings;
        private ArrayList currentIndexes;
        private NotesDB.Index currentIndex;
        private UniversalVariables universal;
        private State state;
        private NotesDB notes; public NotesDB ThisNotes { get { return notes; } set { notes = value; } }
        public ComboBox ElementType { get { return elementType; } set { elementType = value; } }
        public ListBox ElementIndexes { get { return elementIndexes; } set { elementIndexes = value; } }
        public NumericUpDown IndexNumber { get { return indexNumber; } set { indexNumber = value; } }
        public TextBox IndexLabel { get { return indexLabel; } set { indexLabel = value; } }
        public RichTextBox IndexDescription { get { return indexDescription; } set { indexDescription = value; } }
        private bool updating = false;

        public Notes(Model model)
        {
            this.model = model;
            this.model.Notes = notes;
            this.settings = Settings.Default;
            this.state = State.Instance;
            this.universal = state.Universal;
            InitializeComponent();
            this.autoLoadLastNotesDatabaseToolStripMenuItem.Checked = settings.LoadNotes;
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
                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
            }
        }

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
                if (tagIndexesWithNumbersToolStripMenuItem.Checked)
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
                if (model.Program.Scripts == null || !model.Program.Scripts.Visible)
                    model.Program.CreateScriptsWindow();
                model.Program.Scripts.EventName.SelectedIndex = 0;
                model.Program.Scripts.EventNum.Value = indexNumber.Value;
                model.Program.Scripts.TabControlScripts.SelectedIndex = 0;
                model.Program.Scripts.BringToFront();
            }
            if (elementType.SelectedIndex == 5)
            {
                if (model.Program.Scripts == null || !model.Program.Scripts.Visible)
                    model.Program.CreateScriptsWindow();
                model.Program.Scripts.EventName.SelectedIndex = 1;
                model.Program.Scripts.EventNum.Value = indexNumber.Value;
                model.Program.Scripts.TabControlScripts.SelectedIndex = 0;
                model.Program.Scripts.BringToFront();
            }
            if (elementType.SelectedIndex == 6)
            {
                if (model.Program.Scripts == null || !model.Program.Scripts.Visible)
                    model.Program.CreateScriptsWindow();
                model.Program.Scripts.MonsterNumber.Value = indexNumber.Value;
                model.Program.Scripts.TabControlScripts.SelectedIndex = 1;
                model.Program.Scripts.BringToFront();
            }
            if (elementType.SelectedIndex == 10)
            {
                if (model.Program.Sprites == null || !model.Program.Sprites.Visible)
                    model.Program.CreateSpritesWindow();
                model.Program.Sprites.SpriteNum.Value = indexNumber.Value;
                model.Program.Sprites.TabControl1.SelectedIndex = 0;
                model.Program.Sprites.BringToFront();
            }
            if (elementType.SelectedIndex == 11)
            {
                if (model.Program.Sprites == null || !model.Program.Sprites.Visible)
                    model.Program.CreateSpritesWindow();
                model.Program.Sprites.EffectNum.Value = indexNumber.Value;
                model.Program.Sprites.TabControl1.SelectedIndex = 1;
                model.Program.Sprites.BringToFront();
            }
            if (elementType.SelectedIndex == 12)
            {
                if (model.Program.Sprites == null || !model.Program.Sprites.Visible)
                    model.Program.CreateSpritesWindow();
                model.Program.Sprites.DialogueNum.Value = indexNumber.Value;
                model.Program.Sprites.TabControl1.SelectedIndex = 2;
                model.Program.Sprites.BringToFront();
            }
            if (elementType.SelectedIndex == 15)
            {
                if (model.Program.Stats == null || !model.Program.Stats.Visible)
                    model.Program.CreateStatsWindow();
                model.Program.Stats.MonsterNum.Value = indexNumber.Value;
                model.Program.Stats.TabControl1.SelectedIndex = 0;
                model.Program.Stats.BringToFront();
            }
            if (elementType.SelectedIndex == 16)
            {
                if (model.Program.Stats == null || !model.Program.Stats.Visible)
                    model.Program.CreateStatsWindow();
                model.Program.Stats.FormationNum.Value = indexNumber.Value;
                model.Program.Stats.TabControl1.SelectedIndex = 1;
                model.Program.Stats.BringToFront();
            }
            if (elementType.SelectedIndex == 17)
            {
                if (model.Program.Stats == null || !model.Program.Stats.Visible)
                    model.Program.CreateStatsWindow();
                model.Program.Stats.PackNum.Value = indexNumber.Value;
                model.Program.Stats.TabControl1.SelectedIndex = 1;
                model.Program.Stats.BringToFront();
            }
            if (elementType.SelectedIndex == 18)
            {
                if (model.Program.Stats == null || !model.Program.Stats.Visible)
                    model.Program.CreateStatsWindow();
                model.Program.Stats.SpellNum.Value = indexNumber.Value;
                model.Program.Stats.TabControl1.SelectedIndex = 2;
                model.Program.Stats.BringToFront();
            }
            if (elementType.SelectedIndex == 19)
            {
                if (model.Program.Stats == null || !model.Program.Stats.Visible)
                    model.Program.CreateStatsWindow();
                model.Program.Stats.AttackNum.Value = indexNumber.Value;
                model.Program.Stats.TabControl1.SelectedIndex = 2;
                model.Program.Stats.BringToFront();
            }
            if (elementType.SelectedIndex == 20)
            {
                if (model.Program.Stats == null || !model.Program.Stats.Visible)
                    model.Program.CreateStatsWindow();
                model.Program.Stats.ItemNum.Value = indexNumber.Value;
                model.Program.Stats.TabControl1.SelectedIndex = 3;
                model.Program.Stats.BringToFront();
            }
            if (elementType.SelectedIndex == 21)
            {
                if (model.Program.Stats == null || !model.Program.Stats.Visible)
                    model.Program.CreateStatsWindow();
                model.Program.Stats.ShopNum.Value = indexNumber.Value;
                model.Program.Stats.TabControl1.SelectedIndex = 3;
                model.Program.Stats.BringToFront();
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
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;

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
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;

            return true;
        }
        private void SaveNewNotes(string path)
        {
            universal.Notes = notes;

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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonCancel_Click(null, null);
        }

        private void alwaysOnTopToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = alwaysOnTopToolStripMenuItem.Checked;
        }

        private void autoLoadLastNotesDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.LoadNotes = autoLoadLastNotesDatabaseToolStripMenuItem.Checked;
            settings.Save();
        }

        private void tagIndexesWithNumbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedIndex = elementIndexes.SelectedIndex;
            RefreshElementIndexes();
            elementIndexes.SelectedIndex = selectedIndex;
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
    }
}
