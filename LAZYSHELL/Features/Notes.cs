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
        private Settings settings = Settings.Default;
        private ArrayList currentIndexes;
        private NotesDB.Index currentIndex;
        private NotesDB notes; public NotesDB ThisNotes { get { return notes; } set { notes = value; } }
        public ComboBox ElementType { get { return elementType; } set { elementType = value; } }
        public NewListView ElementIndexes { get { return elementIndexes; } set { elementIndexes = value; } }
        public NumericUpDown IndexNumber { get { return indexNumber; } set { indexNumber = value; } }
        public TextBox IndexLabel { get { return indexLabel; } set { indexLabel = value; } }
        public RichTextBox IndexDescription { get { return indexDescription; } set { indexDescription = value; } }
        private ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();
        private long checksum;
        private bool updating = false;
        #endregion
        // constructor
        public Notes()
        {
            Model.Notes = notes;
            InitializeComponent();
            this.elementIndexes.ListViewItemSorter = lvwColumnSorter;
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
                checksum = Do.GenerateChecksum(notes);
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

            int counter = 0;
            List<ListViewItem> listViewItems = new List<ListViewItem>();
            foreach (NotesDB.Index index in currentIndexes)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    (elementType.SelectedItem.ToString() == "  Memory Bits" ? 
                    index.Address.ToString("X4") : index.IndexNumber.ToString()) + 
                    (elementType.SelectedItem.ToString() == "  Memory Bits" ? 
                    ":" + index.AddressBit.ToString() : ""),
                    index.IndexLabel,
                });
                item.Tag = counter++;
                listViewItems.Add(item);
            }
            elementIndexes.Items.AddRange(listViewItems.ToArray());
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
            currentIndex = (NotesDB.Index)currentIndexes[Do.GetSelectedIndex(elementIndexes)];
            indexNumber.Value = currentIndex.IndexNumber;
            indexLabel.Text = currentIndex.IndexLabel;
            indexDescription.Text = currentIndex.IndexDescription;
            address.Value = currentIndex.Address;
            addressBit.Value = currentIndex.AddressBit;

            updating = false;
        }
        public bool LoadNotes()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = settings.NotePathCustom;
            openFileDialog.Title = "Open existing notes database...";
            openFileDialog.FileName = Model.GetFileNameWithoutPath() + " - notes.lsnotes";
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
            catch
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
            checksum = Do.GenerateChecksum(notes);
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
            saveFileDialog.FileName = Model.GetFileNameWithoutPath() + " - notes.lsnotes";
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
            checksum = Do.GenerateChecksum(notes);
            return true;
        }
        private void SaveNewNotes(string path)
        {
            Model.Notes = notes;

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
            checksum = Do.GenerateChecksum(notes);
        }
        private void AddNewIndex()
        {
            if (Do.GetSelectedIndex(elementIndexes) != -1)
                notes.AddIndex(Do.GetSelectedIndex(elementIndexes) + 1, currentIndexes);
            else
                notes.AddIndex(0, currentIndexes);
            int selectedIndex = Do.GetSelectedIndex(elementIndexes);
            RefreshElementIndexes();
            elementIndexes.Items[selectedIndex + 1].Selected = true;
        }
        public void AddingFromEditor(int type, int number, string label, string description)
        {
            elementType.SelectedIndex = type;
            if (elementIndexes.Items.Count > 0)
                elementIndexes.Items[elementIndexes.Items.Count - 1].Selected = true;
            AddNewIndex();
            indexNumber.Value = number;
            indexLabel.Text = label;
            indexDescription.Text = "";
        }
        public void AddingFromEditor(int type, int address, int addressBit, string label, string description)
        {
            elementType.SelectedIndex = type;
            if (elementIndexes.Items.Count > 0)
                elementIndexes.Items[elementIndexes.Items.Count - 1].Selected = true;
            AddNewIndex();
            this.address.Value = address;
            this.addressBit.Value = addressBit;
            indexLabel.Text = label;
            indexDescription.Text = "";
        }
        private void SortIndexes(int column)
        {
            int count = currentIndexes.Count;
            for (int y = 0; y < count - 1; y++)
            {
                for (int x = 0; x < count - 1 - y; x++)
                {
                    NotesDB.Index indexA = (NotesDB.Index)currentIndexes[x];
                    NotesDB.Index indexB = (NotesDB.Index)currentIndexes[x + 1];
                    if (column == 0)
                    {
                        if (elementType.SelectedItem.ToString() == "  Memory Bits")
                        {
                            if ((indexB.Address.ToString() + indexB.AddressBit.ToString()).CompareTo(
                                (indexA.Address.ToString() + indexA.AddressBit.ToString())) < 0)
                                currentIndexes.Reverse(x, 2);
                        }
                        else
                        {
                            if (indexB.IndexNumber.CompareTo(indexA.IndexNumber) < 0)
                                currentIndexes.Reverse(x, 2);
                        }
                    }
                    else if (column == 1)
                    {
                        if (indexB.IndexLabel.CompareTo(indexA.IndexLabel) < 0)
                            currentIndexes.Reverse(x, 2);
                    }
                }
            }
        }
        #endregion
        #region Event Handlers
        private void Notes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (notes == null) return;
            if (Do.GenerateChecksum(notes) == checksum)
            {
                return;
            }
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
                if (Model.Program.Levels == null || !Model.Program.Levels.Visible)
                    Model.Program.CreateLevelsWindow();
                Model.Program.Levels.LevelNum.Value = indexNumber.Value;
                Model.Program.Levels.BringToFront();
            }
            if (elementType.SelectedIndex == 4)
            {
                if (Model.Program.EventScripts == null || !Model.Program.EventScripts.Visible)
                    Model.Program.CreateEventScriptsWindow();
                Model.Program.EventScripts.EventName.SelectedIndex = 0;
                Model.Program.EventScripts.EventNum.Value = indexNumber.Value;
                Model.Program.EventScripts.BringToFront();
            }
            if (elementType.SelectedIndex == 5)
            {
                if (Model.Program.EventScripts == null || !Model.Program.EventScripts.Visible)
                    Model.Program.CreateEventScriptsWindow();
                Model.Program.EventScripts.EventName.SelectedIndex = 1;
                Model.Program.EventScripts.EventNum.Value = indexNumber.Value;
                Model.Program.EventScripts.BringToFront();
            }
            if (elementType.SelectedIndex == 6)
            {
                if (Model.Program.Monsters == null || !Model.Program.Monsters.Visible)
                    Model.Program.CreateMonstersWindow();
                Model.Program.Monsters.Index = (int)indexNumber.Value;
                Model.Program.Monsters.BringToFront();
            }
            if (elementType.SelectedIndex == 10)
            {
                if (Model.Program.Sprites == null || !Model.Program.Sprites.Visible)
                    Model.Program.CreateSpritesWindow();
                Model.Program.Sprites.Index = (int)indexNumber.Value;
                Model.Program.Sprites.BringToFront();
            }
            if (elementType.SelectedIndex == 11)
            {
                if (Model.Program.Effects == null || !Model.Program.Effects.Visible)
                    Model.Program.CreateEffectsWindow();
                Model.Program.Effects.index = (int)indexNumber.Value;
                Model.Program.Effects.BringToFront();
            }
            if (elementType.SelectedIndex == 12)
            {
                if (Model.Program.Dialogues == null || !Model.Program.Dialogues.Visible)
                    Model.Program.CreateDialoguesWindow();
                Model.Program.Dialogues.index = (int)indexNumber.Value;
                Model.Program.Dialogues.BringToFront();
            }
            if (elementType.SelectedIndex == 15)
            {
                if (Model.Program.Monsters == null || !Model.Program.Monsters.Visible)
                    Model.Program.CreateMonstersWindow();
                Model.Program.Monsters.Index = (int)indexNumber.Value;
                Model.Program.Monsters.BringToFront();
            }
            if (elementType.SelectedIndex == 16)
            {
                if (Model.Program.Formations == null || !Model.Program.Formations.Visible)
                    Model.Program.CreateFormationsWindow();
                Model.Program.Formations.FormationIndex = (int)indexNumber.Value;
                Model.Program.Formations.BringToFront();
            }
            if (elementType.SelectedIndex == 17)
            {
                if (Model.Program.Formations == null || !Model.Program.Formations.Visible)
                    Model.Program.CreateFormationsWindow();
                Model.Program.Formations.PackIndex = (int)indexNumber.Value;
                Model.Program.Formations.BringToFront();
            }
            if (elementType.SelectedIndex == 18)
            {
                if (Model.Program.Attacks == null || !Model.Program.Attacks.Visible)
                    Model.Program.CreateAttacksWindow();
                Model.Program.Attacks.spellsEditor.Index = (int)indexNumber.Value;
                Model.Program.Attacks.BringToFront();
            }
            if (elementType.SelectedIndex == 19)
            {
                if (Model.Program.Attacks == null || !Model.Program.Attacks.Visible)
                    Model.Program.CreateAttacksWindow();
                Model.Program.Attacks.attacksEditor.Index = (int)indexNumber.Value;
                Model.Program.Attacks.BringToFront();
            }
            if (elementType.SelectedIndex == 20)
            {
                if (Model.Program.Items == null || !Model.Program.Items.Visible)
                    Model.Program.CreateItemsWindow();
                Model.Program.Items.itemsEditor.Index = (int)indexNumber.Value;
                Model.Program.Items.BringToFront();
            }
            if (elementType.SelectedIndex == 21)
            {
                if (Model.Program.Items == null || !Model.Program.Items.Visible)
                    Model.Program.CreateItemsWindow();
                Model.Program.Items.shopsEditor.Index = (int)indexNumber.Value;
                Model.Program.Items.BringToFront();
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (Do.GetSelectedIndex(elementIndexes) == -1)
                return;
            notes.DeleteIndex(Do.GetSelectedIndex(elementIndexes), currentIndexes);
            int selectedIndex = Do.GetSelectedIndex(elementIndexes);
            RefreshElementIndexes();
            if (currentIndexes.Count > 0)
                elementIndexes.Items[Math.Min(selectedIndex, currentIndexes.Count - 1)].Selected = true;
        }
        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            if (Do.GetSelectedIndex(elementIndexes) == 0) return;
            notes.SwitchIndex(Do.GetSelectedIndex(elementIndexes) - 1, currentIndexes);
            int selectedIndex = Do.GetSelectedIndex(elementIndexes);
            RefreshElementIndexes();
            elementIndexes.Items[selectedIndex - 1].Selected = true;
        }
        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            if (Do.GetSelectedIndex(elementIndexes) >= elementIndexes.Items.Count - 1) return;
            notes.SwitchIndex(Do.GetSelectedIndex(elementIndexes), currentIndexes);
            int selectedIndex = Do.GetSelectedIndex(elementIndexes);
            RefreshElementIndexes();
            elementIndexes.Items[selectedIndex + 1].Selected = true;
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
                elementIndexes.Items[0].Selected = true;
        }
        private void elementIndexes_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SortIndexes(e.Column);
            int selectedIndex = Do.GetSelectedIndex(elementIndexes);
            RefreshElementIndexes();
            elementIndexes.Items[selectedIndex].Selected = true;
        }
        private void elementIndexes_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (!e.IsSelected) return;
            if (updating) return;
            RefreshIndex();
            elementIndexes.BeginUpdate();
            elementIndexes.Items[Do.GetSelectedIndex(elementIndexes)].EnsureVisible();
            elementIndexes.EndUpdate();
        }
        private void indexNumber_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            currentIndex.IndexNumber = (int)indexNumber.Value;
            int selectedIndex = Do.GetSelectedIndex(elementIndexes);
            RefreshElementIndexes();
            elementIndexes.Items[selectedIndex].Selected = true;
        }
        private void indexLabel_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            currentIndex.IndexLabel = indexLabel.Text;
            int selectedIndex = Do.GetSelectedIndex(elementIndexes);
            RefreshElementIndexes();
            elementIndexes.Items[selectedIndex].Selected = true;
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
            int selectedIndex = Do.GetSelectedIndex(elementIndexes);
            RefreshElementIndexes();
            elementIndexes.Items[selectedIndex].Selected = true;
        }
        private void addressBit_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            currentIndex.AddressBit = (int)addressBit.Value;
            int selectedIndex = Do.GetSelectedIndex(elementIndexes);
            RefreshElementIndexes();
            elementIndexes.Items[selectedIndex].Selected = true;
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
            saveFileDialog.FileName = Model.GetFileNameWithoutPath() + " - notes.lsnotes";
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
            int selectedIndex = Do.GetSelectedIndex(elementIndexes);
            RefreshElementIndexes();
            elementIndexes.Items[selectedIndex].Selected = true;
        }
        #endregion
    }
}
