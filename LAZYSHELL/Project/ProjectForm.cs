﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using LazyShell.Properties;

namespace LazyShell
{
    public partial class ProjectForm : Controls.NewForm
    {
        #region Variables

        // Project
        private ProjectDB project
        {
            get { return Model.Project; }
            set { Model.Project = value; }
        }
        private Settings settings = Settings.Default;

        // Indexes
        private List<EIndex> currentIndexes;
        private EIndex currentIndex;
        private EList elist
        {
            get
            {
                EList elist = (EList)listBoxLists.SelectedItem;
                elist = project.ELists.Find(delegate(EList ELIST)
                {
                    return ELIST.Name == elist.Name;
                });
                return elist;
            }
            set
            {
                EList elist = (EList)listBoxLists.SelectedItem;
                elist = project.ELists.Find(delegate(EList ELIST)
                {
                    return ELIST.Name == elist.Name;
                });
                elist = value;
            }
        }
        public Controls.NewListView ElementIndexes
        {
            get { return elementIndexes; }
            set { elementIndexes = value; }
        }
        public NumericUpDown IndexNumber
        {
            get { return indexNumber; }
            set { indexNumber = value; }
        }
        public TextBox IndexLabel
        {
            get { return indexLabel; }
            set { indexLabel = value; }
        }
        public TextBox IndexDescription
        {
            get { return indexDescription; }
            set { indexDescription = value; }
        }
        private ListViewColumnSorter elementsColumnSorter;
        private ListViewColumnSorter listsColumnSorter;
        private int listIndex
        {
            get
            {
                if (listViewList.SelectedItems.Count == 0)
                    return -1;
                return Bits.GetInt32(listViewList.SelectedItems[0].SubItems[0].Text);
            }
        }

        // Fonts
        private Fonts.Glyph[] font
        {
            get
            {
                switch (FontType)
                {
                    case FontType.Menu: return fontMenu;
                    case FontType.Dialogue: return fontDialogue;
                    case FontType.Description: return fontDescription;
                    case FontType.BattleMenu: return fontBattleMenu;
                    default: return fontDialogue;
                }
            }
            set
            {
                switch (FontType)
                {
                    case FontType.Menu: fontMenu = value; break;
                    case FontType.Dialogue: fontDialogue = value; break;
                    case FontType.Description: fontDescription = value; break;
                    case FontType.BattleMenu: fontBattleMenu = value; break;
                }
            }
        }
        private Fonts.Glyph[] fontMenu
        {
            get { return Fonts.Model.Menu; }
            set { Fonts.Model.Menu = value; }
        }
        private Fonts.Glyph[] fontDialogue
        {
            get { return Fonts.Model.Dialogue; }
            set { Fonts.Model.Dialogue = value; }
        }
        private Fonts.Glyph[] fontDescription
        {
            get { return Fonts.Model.Description; }
            set { Fonts.Model.Description = value; }
        }
        private Fonts.Glyph[] fontBattleMenu
        {
            get { return Fonts.Model.BattleMenu; }
            set { Fonts.Model.BattleMenu = value; }
        }
        private Bitmap fontTableImage;
        public FontType FontType
        {
            get
            {
                return (FontType)fontType.SelectedIndex;
            }
            set
            {
                fontType.SelectedIndex = (int)value;
            }
        }
        private PaletteSet fontPalettesDialogue
        {
            get { return Fonts.Model.Palette_Dialogue; }
            set { Fonts.Model.Palette_Dialogue = value; }
        }
        private PaletteSet fontPalettesMenu
        {
            get { return Fonts.Model.Palette_Menu; }
            set { Fonts.Model.Palette_Menu = value; }
        }
        private PaletteSet fontPalettesBattle
        {
            get { return Fonts.Model.Palette_BattleMenu; }
            set { Fonts.Model.Palette_BattleMenu = value; }
        }
        private int[] palette
        {
            get
            {
                switch (FontType)
                {
                    case FontType.Menu:
                    case FontType.Description: return fontPalettesMenu.Palettes[0];
                    case FontType.BattleMenu: return fontPalettesBattle.Palettes[0];
                    default: return fontPalettesDialogue.Palettes[1];
                }
            }
        }
        private string[] keystrokes
        {
            get
            {
                switch (FontType)
                {
                    case FontType.Menu: return project.KeystrokesMenu;
                    case FontType.Dialogue: return project.Keystrokes;
                    case FontType.Description: return project.KeystrokesDesc;
                    default: return null;
                }
            }
        }
        private Overlay overlay;

        #endregion

        // Constructor
        public ProjectForm()
        {
            InitializeComponent();
            InitializeVariables();
            LoadProperties();
        }

        #region Methods

        // Initialization
        private void InitializeVariables()
        {
            this.overlay = new Overlay();
            this.elementsColumnSorter = new ListViewColumnSorter();
            this.listsColumnSorter = new ListViewColumnSorter();
            this.elementIndexes.ListViewItemSorter = elementsColumnSorter;
            this.listViewList.ListViewItemSorter = listsColumnSorter;
            if (project != null)
                projectFile.Text = settings.ProjectPathCustom;
        }
        private void LoadProperties()
        {
            if (project == null)
                return;

            //
            projectTitle.Text = project.Title;
            projectAuthor.Text = project.Author;
            projectDate.Text = project.Date;
            projectWebpage.Text = project.Webpage;
            projectDescription.Text = project.Description;
            projectOtherInfo.Text = project.OtherInfo;

            //
            if (elementType.SelectedIndex == 0)
                RefreshElementIndexes();
            else
                elementType.SelectedIndex = 0;

            BuildListBoxLists();

            projectOtherInfo.Text = project.OtherInfo;

            //
            fontType.SelectedIndex = 0;
            InitializeKeystrokes();
            tabControl1.Enabled = true;
            closeButton.Enabled = true;
            save.Enabled = true;
            saveAs.Enabled = true;
        }
        private void BuildListBoxLists()
        {
            listBoxLists.BeginUpdate();
            listBoxLists.Items.Clear();
            foreach (var elist in Model.ELists)
                listBoxLists.Items.Add(elist);
            listBoxLists.EndUpdate();
            listBoxLists.SelectedIndex = 0;
        }
        private void RefreshElementIndexes()
        {
            this.Updating = true;
            panelAddressBit.Visible = false;
            panelIndexNumber.Visible = true;
            panelIndexNumber.BringToFront();
            elementIndexes.BeginUpdate();
            elementIndexes.Items.Clear();
            switch ((string)elementType.SelectedItem)
            {
                case "Action Scripts":
                    currentIndexes = project.ActionScripts;
                    indexNumber.Maximum = 1023;
                    break;
                case "Attacks":
                    currentIndexes = project.Attacks;
                    indexNumber.Maximum = 128;
                    break;
                case "Battlefields":
                    currentIndexes = project.Battlefields;
                    indexNumber.Maximum = 63;
                    break;
                case "Dialogues":
                    currentIndexes = project.Dialogues;
                    indexNumber.Maximum = 4095;
                    break;
                case "Effects":
                    currentIndexes = project.Effects;
                    indexNumber.Maximum = 127;
                    break;
                case "Event Scripts":
                    currentIndexes = project.EventScripts;
                    indexNumber.Maximum = 4095;
                    break;
                case "Formations":
                    currentIndexes = project.Formations;
                    indexNumber.Maximum = 511;
                    break;
                case "Items":
                    currentIndexes = project.Items;
                    indexNumber.Maximum = 255;
                    break;
                case "Levels":
                    currentIndexes = project.Areas;
                    indexNumber.Maximum = 509;
                    break;
                case "Memory Bits":
                    currentIndexes = project.MemoryBits;
                    panelIndexNumber.Visible = false;
                    panelAddressBit.Visible = true;
                    panelAddressBit.BringToFront();
                    break;
                case "Monsters":
                    currentIndexes = project.Monsters;
                    indexNumber.Maximum = 255;
                    break;
                case "Packs":
                    currentIndexes = project.Packs;
                    indexNumber.Maximum = 255;
                    break;
                case "Shops":
                    currentIndexes = project.Shops;
                    indexNumber.Maximum = 32;
                    break;
                case "Spells":
                    currentIndexes = project.Spells;
                    indexNumber.Maximum = 127;
                    break;
                case "Sprites":
                    currentIndexes = project.Sprites;
                    indexNumber.Maximum = 1023;
                    break;
                default:
                    panel1.Enabled = false;
                    groupBox1.Enabled = false;
                    indexNumber.Value = 0;
                    indexLabel.Text = "";
                    indexDescription.Text = "";
                    elementIndexes.EndUpdate();
                    elementIndexes.EndUpdate();
                    this.Updating = false;
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
            var listViewItems = new List<ListViewItem>();
            foreach (var index in currentIndexes)
            {
                var lvitem = new ListViewItem(new string[]
                {
                    ((string)elementType.SelectedItem == "Memory Bits" ? 
                    index.Address.ToString("X4") : index.Index.ToString()) + 
                    ((string)elementType.SelectedItem == "Memory Bits" ? 
                    ":" + index.AddressBit.ToString() : ""),
                    index.Label
                });
                lvitem.Tag = counter++;
                listViewItems.Add(lvitem);
            }
            elementIndexes.Items.AddRange(listViewItems.ToArray());
            elementIndexes.EndUpdate();
            this.Updating = false;
        }
        private void RefreshIndex()
        {
            this.Updating = true;
            buttonDelete.Enabled = true;
            buttonMoveDown.Enabled = true;
            buttonMoveUp.Enabled = true;
            buttonLoad.Enabled = true;
            groupBox1.Enabled = true;
            currentIndex = (EIndex)currentIndexes[Do.GetSelectedIndex(elementIndexes)];
            indexNumber.Value = currentIndex.Index;
            indexLabel.Text = currentIndex.Label;
            indexDescription.Text = currentIndex.Description;
            address.Value = currentIndex.Address;
            addressBit.Value = currentIndex.AddressBit;
            this.Updating = false;
        }

        // Open / Save project
        public bool OpenProjectFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = settings.ProjectPathCustom;
            openFileDialog.Title = "Open existing project...";
            openFileDialog.FileName = Model.GetFileNameWithoutPath() + ".lsproj";
            openFileDialog.Filter = "Lazy Shell Project/Notes (*.lsproj; *.lsnotes)|*.lsproj;*.lsnotes";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return false;
            //
            Stream s = File.OpenRead(openFileDialog.FileName);
            BinaryFormatter b = new BinaryFormatter();
            try
            {
                string extension = Path.GetExtension(openFileDialog.FileName);
                if (extension == ".lsproj")
                {
                    project = (ProjectDB)b.Deserialize(s);
                }
                else if (extension == ".lsnotes")
                {
                    if (MessageBox.Show("This is a notes file -- in order to load this file it must be converted into a project.\n\n" +
                        "Continue loading file?", "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        s.Close();
                        return false;
                    }
                    NotesDB notes = (NotesDB)b.Deserialize(s);
                    project = ConvertProject(notes);
                    openFileDialog.FileName = Path.ChangeExtension(openFileDialog.FileName, "lsproj");
                }
                if (project == null)
                {
                    MessageBox.Show("This is not a valid project file.", "LAZY SHELL", MessageBoxButtons.OK);
                    s.Close();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("This is not a valid project file.", "LAZY SHELL", MessageBoxButtons.OK);
                s.Close();
                return false;
            }
            Model.RefreshListCollections();
            //
            settings.ProjectPathCustom = openFileDialog.FileName;
            projectFile.Text = openFileDialog.FileName;
            LoadProperties();
            return true;
        }
        private bool NewProjectFile()
        {
            if (project != null)
            {
                var result = MessageBox.Show("Save changes to currently loaded project?",
                    "LAZY SHELL", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                    SaveLoadedProject();
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = settings.ProjectPathCustom;
            saveFileDialog.Title = "Create new project...";
            saveFileDialog.FileName = Model.GetFileNameWithoutPath() + ".lsproj";
            saveFileDialog.Filter = "Lazy Shell Project (*.lsproj)|*.lsproj";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return false;
            //
            settings.ProjectPathCustom = saveFileDialog.FileName;
            Stream s = File.Create(saveFileDialog.FileName);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, new ProjectDB());
            s.Close();
            // now load the notes
            s = File.OpenRead(saveFileDialog.FileName);
            b = new BinaryFormatter();
            project = (ProjectDB)b.Deserialize(s);
            s.Close();
            projectFile.Text = saveFileDialog.FileName;
            LoadProperties();
            return true;
        }
        private void SaveNewProject(string path)
        {
            Model.ResetListCollections();
            Stream s = File.Create(path);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, new ProjectDB());
            s.Close();
        }
        private void SaveLoadedProject()
        {
            if (projectFile.Text == "")
            {
                SaveAsNewProject();
                return;
            }
            Model.RefreshListCollections();
            Stream s = File.Create(projectFile.Text);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, project);
            s.Close();
        }
        private void SaveAsNewProject()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = settings.ProjectPathCustom;
            saveFileDialog.Title = "Save as new project...";
            saveFileDialog.FileName = Model.GetFileNameWithoutPath() + ".lsproj";
            saveFileDialog.Filter = "Project DB (*.lsproj)|*.lsproj";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            settings.ProjectPathCustom = saveFileDialog.FileName;
            projectFile.Text = saveFileDialog.FileName;
            //
            Model.RefreshListCollections();
            Stream s = File.Create(saveFileDialog.FileName);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, project);
            s.Close();
        }

        // Add new index
        private void AddNewIndex()
        {
            if (Do.GetSelectedIndex(elementIndexes) != -1)
                project.AddIndex(Do.GetSelectedIndex(elementIndexes) + 1, currentIndexes);
            else
                project.AddIndex(0, currentIndexes);
            int selectedIndex = Do.GetSelectedIndex(elementIndexes);
            RefreshElementIndexes();
            elementIndexes.Items[selectedIndex + 1].Selected = true;
        }
        public void AddingFromEditor(string type, int number, string label, string description)
        {
            string selectedItem = null;
            foreach (string item in elementType.Items)
                if (item.Trim() == type)
                    selectedItem = item;
            if (selectedItem == null)
                return;
            else
            {
                tabControl1.SelectedIndex = 2;
                elementType.SelectedItem = selectedItem;
            }
            if (elementIndexes.Items.Count > 0)
                elementIndexes.Items[elementIndexes.Items.Count - 1].Selected = true;
            AddNewIndex();
            indexNumber.Value = number;
            indexLabel.Text = label;
            indexDescription.Text = "";
        }
        public void AddingFromEditor(string type, int address, int addressBit, string label, string description)
        {
            string selectedItem = null;
            foreach (string item in elementType.Items)
                if (item.Trim() == type)
                    selectedItem = item;
            if (selectedItem == null)
                return;
            else
            {
                tabControl1.SelectedIndex = 2;
                elementType.SelectedItem = selectedItem;
            }
            if (elementIndexes.Items.Count > 0)
                elementIndexes.Items[elementIndexes.Items.Count - 1].Selected = true;
            AddNewIndex();
            this.address.Value = address;
            this.addressBit.Value = addressBit;
            indexLabel.Text = label;
            indexDescription.Text = "";
        }

        // Sort indexes
        private void SortIndexes(int column)
        {
            int count = currentIndexes.Count;
            for (int y = 0; y < count - 1; y++)
            {
                for (int x = 0; x < count - 1 - y; x++)
                {
                    EIndex indexA = (EIndex)currentIndexes[x];
                    EIndex indexB = (EIndex)currentIndexes[x + 1];
                    if (column == 0)
                    {
                        if (elementType.SelectedItem.ToString() == "Memory Bits")
                        {
                            if ((indexB.Address.ToString() + indexB.AddressBit.ToString()).CompareTo(
                                (indexA.Address.ToString() + indexA.AddressBit.ToString())) < 0)
                                currentIndexes.Reverse(x, 2);
                        }
                        else
                        {
                            if (indexB.Index.CompareTo(indexA.Index) < 0)
                                currentIndexes.Reverse(x, 2);
                        }
                    }
                    else if (column == 1)
                    {
                        if (indexB.Label.CompareTo(indexA.Label) < 0)
                            currentIndexes.Reverse(x, 2);
                    }
                }
            }
        }

        // Element lists
        private void RefreshElementList()
        {
            int index = listBoxLists.SelectedIndex;
            string[] list = elist.Labels;
            listViewList.BeginUpdate();
            listViewList.Items.Clear();
            List<ListViewItem> listViewItems = new List<ListViewItem>();
            int digits = list.Length.ToString().Length;
            for (int i = 0; i < list.Length; i++)
            {
                ListViewItem lvitem = new ListViewItem(new string[]
                {
                    i.ToString(), list[i]
                });
                listViewItems.Add(lvitem);
            }
            listViewList.Items.AddRange(listViewItems.ToArray());
            listViewList.EndUpdate();
            //
            listLabel.Text = "";
            listDescription.Text = "";
        }
        private void ExportList(bool exportAll)
        {
            if (listBoxLists.SelectedItem == null)
                return;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            if (exportAll)
                saveFileDialog.FileName = "listCollections";
            else
                saveFileDialog.FileName = "list" + (listBoxLists.SelectedItem.ToString()).Replace(" ", "");
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            //
            List<EList> listsToSave = new List<EList>();
            if (exportAll)
                foreach (EList item in listBoxLists.Items)
                    listsToSave.Add(item);
            else
                listsToSave.Add((EList)listBoxLists.SelectedItem);
            if (listsToSave.Count == 0)
                return;
            StreamWriter writer = File.CreateText(saveFileDialog.FileName);
            for (int a = 0; a < listsToSave.Count; a++)
            {
                string[] list = listsToSave[a].Labels;
                writer.WriteLine("[" + listsToSave[a].Name + "]");
                for (int i = 0; i < list.Length; i++)
                    writer.WriteLine("{" + i.ToString("d" + list.Length.ToString().Length) + "}  " + list[i]);
                writer.WriteLine();
            }
            writer.Close();
        }
        private void ImportList(bool importAll)
        {
            if (listBoxLists.SelectedItem == null)
                return;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 0;
            if (importAll)
                openFileDialog.FileName = "listCollections";
            else
                openFileDialog.FileName = listBoxLists.SelectedItem.ToString();
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            //
            TextReader reader = new StreamReader(openFileDialog.FileName);
            string[] listToRead = null;
            while (reader.Peek() != -1)
            {
                string line = reader.ReadLine();
                // skip line if empty
                if (line == "")
                    continue;
                // if beginning of another list, set current list
                if (line.StartsWith("[") && line.EndsWith("]"))
                {
                    line = line.Substring(1, line.Length - 2);
                    EList elist = project.ELists.Find(delegate(EList list)
                    {
                        return list.Name == line;
                    });
                    if (elist != null)
                        listToRead = elist.Labels;
                    line = reader.ReadLine();
                }
                // if current list not set, continue
                if (listToRead == null)
                    continue;
                // get tagged index of line
                string tag = Regex.Match(line, "^[^ ]+").Value;
                // skip line completely if not tagged with index
                if (!tag.StartsWith("{") || !tag.EndsWith("}"))
                {
                    line = reader.ReadLine();
                    continue;
                }
                // remove tag from line
                line = line.Substring(tag.Length).Trim();
                int indexNumber = Bits.GetInt32(ref tag);
                string indexLabel = line.Trim();
                // skip line if index is out of bounds of list
                if (indexNumber >= listToRead.Length)
                    continue;
                listToRead[indexNumber] = indexLabel;
            }
            reader.Close();
        }

        /// <summary>
        /// Converts a project in the old format to a new one.
        /// </summary>
        /// <param name="notes">The project to convert.</param>
        /// <returns></returns>
        private ProjectDB ConvertProject(NotesDB notes)
        {
            ProjectDB project = new ProjectDB();
            project.OtherInfo = notes.GeneralNotes;
            foreach (NotesDB.Index index in notes.ActionScripts) project.ActionScripts.Add(new EIndex(index));
            foreach (NotesDB.Index index in notes.Attacks) project.Attacks.Add(new EIndex(index));
            foreach (NotesDB.Index index in notes.Dialogues) project.Dialogues.Add(new EIndex(index));
            foreach (NotesDB.Index index in notes.Effects) project.Effects.Add(new EIndex(index));
            foreach (NotesDB.Index index in notes.EventScripts) project.EventScripts.Add(new EIndex(index));
            foreach (NotesDB.Index index in notes.Formations) project.Formations.Add(new EIndex(index));
            foreach (NotesDB.Index index in notes.Items) project.Items.Add(new EIndex(index));
            foreach (NotesDB.Index index in notes.Levels) project.Areas.Add(new EIndex(index));
            foreach (NotesDB.Index index in notes.MemoryBits) project.MemoryBits.Add(new EIndex(index));
            foreach (NotesDB.Index index in notes.Monsters) project.Monsters.Add(new EIndex(index));
            foreach (NotesDB.Index index in notes.Packs) project.Packs.Add(new EIndex(index));
            foreach (NotesDB.Index index in notes.Shops) project.Shops.Add(new EIndex(index));
            foreach (NotesDB.Index index in notes.Spells) project.Spells.Add(new EIndex(index));
            foreach (NotesDB.Index index in notes.Sprites) project.Sprites.Add(new EIndex(index));
            return project;
        }

        // Fonts
        private void SetFontTableImage()
        {
            int[] palette = this.palette;
            int[] pixels = Do.DrawFontTable(font, palette, 8, 256, 384, 32, 24, 8, 16);
            fontTableImage = Do.PixelsToImage(pixels, 256, 384);
            pictureBox1.BackColor = Color.FromArgb(palette[3]);
            pictureBox1.Invalidate();
        }
        private void InitializeKeystrokes()
        {
            this.Updating = true;
            panelFontTable.SuspendDrawing();
            panelFontTable.Controls.Clear();
            TextBox keyBox;
            for (int y = 16; y >= 0; y--)
            {
                for (int x = 0; x < 8; x++)
                {
                    int index = y * 8 + x;
                    keyBox = new TextBox();
                    keyBox.BackColor = Color.FromArgb(palette[3]);
                    keyBox.BorderStyle = BorderStyle.None;
                    keyBox.Font = new Font("Arial", 12F);
                    keyBox.ForeColor = Color.FromArgb(palette[1]);
                    keyBox.Left = x * 32;
                    keyBox.MaxLength = 1;
                    if (index == 0)
                        keyBox.ReadOnly = true;
                    keyBox.Size = new Size(31, 23);
                    keyBox.TabIndex = y * 8 + x;
                    keyBox.Tag = index;
                    keyBox.Text = keystrokes[index + 32];
                    keyBox.TextAlign = HorizontalAlignment.Center;
                    keyBox.Top = y * 24;
                    keyBox.Enter += new EventHandler(keyBox_Enter);
                    keyBox.MouseUp += new MouseEventHandler(keyBox_MouseUp);
                    keyBox.TextChanged += new EventHandler(keyBox_TextChanged);
                    //
                    panelFontTable.Controls.Add(keyBox);
                    keyBox.BringToFront();
                }
            }
            panelFontTable.ResumeDrawing();
            this.Updating = false;
        }
        private void RefreshKeystrokes()
        {
            this.Updating = true;
            panelFontTable.SuspendDrawing();
            foreach (TextBox keyBox in panelFontTable.Controls)
            {
                int index = (int)keyBox.Tag;
                keyBox.BackColor = Color.FromArgb(palette[3]);
                keyBox.ForeColor = Color.FromArgb(palette[1]);
                keyBox.Text = keystrokes[index + 32];
            }
            panelFontTable.ResumeDrawing();
            this.Updating = false;
        }

        #endregion

        #region Event Handlers

        // ProjectForm
        private void ProjectForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (project == null)
                return;
            if (!this.Modified)
            {
                return;
            }
            var result = MessageBox.Show("Save changes to project?", "LAZY SHELL",
            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                SaveLoadedProject();
            else if (result == DialogResult.Cancel)
                e.Cancel = true;
            else if (result == DialogResult.No && projectFile.Text != "")
            {
                // reload notes file
                try
                {
                    Stream s = File.OpenRead(projectFile.Text);
                    BinaryFormatter b = new BinaryFormatter();
                    project = (ProjectDB)b.Deserialize(s);
                    s.Close();
                }
                catch
                {
                    return;
                }
            }
        }

        // Buttons
        private void buttonOK_Click(object sender, EventArgs e)
        {
            SaveLoadedProject();
            this.Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (project != null)
            {
                var result = MessageBox.Show("Save changes to currently loaded notes?", "LAZY SHELL",
                    MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                    SaveLoadedProject();
                if (result == DialogResult.Cancel)
                    return;
            }
            OpenProjectFile();
        }

        // ToolStrip
        private void new_Click(object sender, EventArgs e)
        {
            NewProjectFile();
        }
        private void load_Click(object sender, EventArgs e)
        {
            OpenProjectFile();
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            Model.Project = null;
            Model.ResetListCollections();
            LazyShell.Model.Program.Project.Close();
            if (Model.Program.Project == null || !Model.Program.Project.Visible)
                LazyShell.Model.Program.CreateProjectWindow();
        }
        private void save_Click(object sender, EventArgs e)
        {
            SaveLoadedProject();
        }
        private void saveAs_Click(object sender, EventArgs e)
        {
            SaveAsNewProject();
        }
        private void alwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = alwaysOnTop.Checked;
        }
        private void tagIndexesWithNumbers_Click(object sender, EventArgs e)
        {
            int selectedIndex = Do.GetSelectedIndex(elementIndexes);
            RefreshElementIndexes();
            elementIndexes.Items[selectedIndex].Selected = true;
        }

        // Information
        private void projectTitle_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            project.Title = projectTitle.Text;
        }
        private void projectAuthor_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            project.Author = projectAuthor.Text;
        }
        private void projectDate_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            project.Date = projectDate.Text;
        }
        private void projectWebpage_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            project.Webpage = projectWebpage.Text;
        }
        private void projectDescription_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            project.Description = projectDescription.Text;
        }

        // Element lists
        private void listBoxLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshElementList();
        }
        private void listViewList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewList.SelectedItems.Count == 0)
                return;
            listLabel.Text = elist.Indexes[listIndex].Label;
            listDescription.Text = elist.Indexes[listIndex].Description;
        }
        private void listViewList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Do.SortListView(listViewList, listsColumnSorter, e.Column);
        }
        private void addToElements_Click(object sender, EventArgs e)
        {
            if (listIndex < 0)
            {
                MessageBox.Show("Must select an item in the list before adding it to the notes.",
                    "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int number = elist.Indexes[listIndex].Index;
            string label = elist.Indexes[listIndex].Label;
            string description = elist.Indexes[listIndex].Description;
            tabControl1.SelectedIndex = 2;
            AddingFromEditor(elist.Name, number, label, description);
        }
        private void listLabel_TextChanged(object sender, EventArgs e)
        {
            if (listViewList.SelectedItems.Count == 0)
                return;
            if (elist == null)
                return;
            elist.Indexes[listIndex].Label = listLabel.Text;
            listViewList.SelectedItems[0].SubItems[1].Text = listLabel.Text;
        }
        private void listDescription_TextChanged(object sender, EventArgs e)
        {
            if (listViewList.SelectedItems.Count == 0)
                return;
            if (elist == null)
                return;
            elist.Indexes[listIndex].Description = listDescription.Text;
        }
        private void importCollection_Click(object sender, EventArgs e)
        {
            ImportList(true);
        }
        private void importList_Click(object sender, EventArgs e)
        {
            ImportList(false);
        }
        private void exportCollection_Click(object sender, EventArgs e)
        {
            ExportList(true);
        }
        private void exportList_Click(object sender, EventArgs e)
        {
            ExportList(false);
        }
        private void resetAllLists_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You are about to reset all lists in the current project to their default labels.\n\n" +
                "Continue with process?", "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            foreach (EList elist in project.ELists)
                elist.Reset();
            RefreshElementList();
        }
        private void resetCurrentList_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You are about to reset the current list to it's default labels.\n\n" +
                "Continue with process?", "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            elist.Reset();
            RefreshElementList();
        }

        // Element notes
        private void transferToLists_Click(object sender, EventArgs e)
        {
            string item = (string)elementType.SelectedItem;
            EList elist = project.ELists.Find(delegate(EList list)
            {
                return list.Name == item;
            });
            if (elist == null)
                return;
            List<EIndex> eindexes = null;
            switch (item)
            {
                case "Action Scripts": eindexes = project.ActionScripts; break;
                case "Attacks": eindexes = project.Attacks; break;
                case "Battlefields": eindexes = project.Battlefields; break;
                case "Dialogues": eindexes = project.Dialogues; break;
                case "Effects": eindexes = project.Effects; break;
                case "Event Scripts": eindexes = project.EventScripts; break;
                case "Formations": eindexes = project.Formations; break;
                case "Items": eindexes = project.Items; break;
                case "Levels": eindexes = project.Areas; break;
                case "Monsters": eindexes = project.Monsters; break;
                case "Packs": eindexes = project.Packs; break;
                case "Shops": eindexes = project.Shops; break;
                case "Spells": eindexes = project.Spells; break;
                case "Sprites": eindexes = project.Sprites; break;
                default: break;
            }
            if (eindexes == null)
                return;
            foreach (EIndex eindex in eindexes)
            {
                elist.Indexes[eindex.Index].Label = eindex.Label;
            }
            RefreshElementList();
        }
        private void elementType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
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
            if (!e.IsSelected)
                return;
            if (this.Updating)
                return;
            RefreshIndex();
            elementIndexes.BeginUpdate();
            elementIndexes.Items[Do.GetSelectedIndex(elementIndexes)].EnsureVisible();
            elementIndexes.EndUpdate();
        }
        private void indexNumber_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            currentIndex.Index = (int)indexNumber.Value;
            int selectedIndex = Do.GetSelectedIndex(elementIndexes);
            RefreshElementIndexes();
            elementIndexes.Items[selectedIndex].Selected = true;
        }
        private void indexLabel_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            currentIndex.Label = indexLabel.Text;
            int selectedIndex = Do.GetSelectedIndex(elementIndexes);
            RefreshElementIndexes();
            elementIndexes.Items[selectedIndex].Selected = true;
        }
        private void indexDescription_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            currentIndex.Description = indexDescription.Text;
        }
        private void address_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            currentIndex.Address = (int)address.Value;
            int selectedIndex = Do.GetSelectedIndex(elementIndexes);
            RefreshElementIndexes();
            elementIndexes.Items[selectedIndex].Selected = true;
        }
        private void addressBit_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            currentIndex.AddressBit = (int)addressBit.Value;
            int selectedIndex = Do.GetSelectedIndex(elementIndexes);
            RefreshElementIndexes();
            elementIndexes.Items[selectedIndex].Selected = true;
        }
        private void generalNotes_TextChanged(object sender, EventArgs e)
        {
            project.OtherInfo = projectOtherInfo.Text;
        }
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            switch ((string)elementType.SelectedItem)
            {
                case "Action Scripts":
                    if (Model.Program.EventScripts == null || !Model.Program.EventScripts.Visible)
                        LazyShell.Model.Program.CreateEventScriptsWindow();
                    LazyShell.Model.Program.EventScripts.Type = 1;
                    LazyShell.Model.Program.EventScripts.Index = (int)indexNumber.Value;
                    LazyShell.Model.Program.EventScripts.BringToFront();
                    break;
                case "Attacks":
                    if (Model.Program.Attacks == null || !Model.Program.Attacks.Visible)
                        LazyShell.Model.Program.CreateAttacksWindow();
                    LazyShell.Model.Program.Attacks.Index = (int)indexNumber.Value;
                    LazyShell.Model.Program.Attacks.BringToFront();
                    break;
                case "Battlefields":
                    if (Model.Program.Battlefields == null || !Model.Program.Battlefields.Visible)
                        LazyShell.Model.Program.CreateBattlefieldsWindow();
                    LazyShell.Model.Program.Battlefields.Index = (int)indexNumber.Value;
                    LazyShell.Model.Program.Battlefields.BringToFront();
                    break;
                case "Dialogues":
                    if (Model.Program.Dialogues == null || !Model.Program.Dialogues.Visible)
                        LazyShell.Model.Program.CreateDialoguesWindow();
                    LazyShell.Model.Program.Dialogues.DialoguesForm.Index = (int)indexNumber.Value;
                    LazyShell.Model.Program.Dialogues.BringToFront();
                    break;
                case "Effects":
                    if (Model.Program.Effects == null || !Model.Program.Effects.Visible)
                        LazyShell.Model.Program.CreateEffectsWindow();
                    LazyShell.Model.Program.Effects.index = (int)indexNumber.Value;
                    LazyShell.Model.Program.Effects.BringToFront();
                    break;
                case "Event Scripts":
                    if (Model.Program.EventScripts == null || !Model.Program.EventScripts.Visible)
                        LazyShell.Model.Program.CreateEventScriptsWindow();
                    LazyShell.Model.Program.EventScripts.Type = 0;
                    LazyShell.Model.Program.EventScripts.Index = (int)indexNumber.Value;
                    LazyShell.Model.Program.EventScripts.BringToFront();
                    break;
                case "Formations":
                    if (Model.Program.Formations == null || !Model.Program.Formations.Visible)
                        LazyShell.Model.Program.CreateFormationsWindow();
                    LazyShell.Model.Program.Formations.FormationIndex = (int)indexNumber.Value;
                    LazyShell.Model.Program.Formations.BringToFront();
                    break;
                case "Items":
                    if (Model.Program.Items == null || !Model.Program.Items.Visible)
                        LazyShell.Model.Program.CreateItemsWindow();
                    LazyShell.Model.Program.Items.Index = (int)indexNumber.Value;
                    LazyShell.Model.Program.Items.BringToFront();
                    break;
                case "Levels":
                    if (Model.Program.Areas == null || !Model.Program.Areas.Visible)
                        LazyShell.Model.Program.CreateAreasWindow();
                    LazyShell.Model.Program.Areas.Index = (int)indexNumber.Value;
                    LazyShell.Model.Program.Areas.BringToFront();
                    break;
                case "Memory Bits":
                    break;
                case "Monsters":
                    if (Model.Program.Monsters == null || !Model.Program.Monsters.Visible)
                        LazyShell.Model.Program.CreateMonstersWindow();
                    LazyShell.Model.Program.Monsters.Index = (int)indexNumber.Value;
                    LazyShell.Model.Program.Monsters.BringToFront();
                    break;
                case "Packs":
                    if (Model.Program.Formations == null || !Model.Program.Formations.Visible)
                        LazyShell.Model.Program.CreateFormationsWindow();
                    LazyShell.Model.Program.Formations.PackIndex = (int)indexNumber.Value;
                    LazyShell.Model.Program.Formations.BringToFront();
                    break;
                case "Shops":
                    if (Model.Program.Shops == null || !Model.Program.Shops.Visible)
                        LazyShell.Model.Program.CreateItemsWindow();
                    LazyShell.Model.Program.Shops.Index = (int)indexNumber.Value;
                    LazyShell.Model.Program.Items.BringToFront();
                    break;
                case "Spells":
                    if (Model.Program.Magic == null || !Model.Program.Magic.Visible)
                        LazyShell.Model.Program.CreateMagicWindow();
                    LazyShell.Model.Program.Magic.Index = (int)indexNumber.Value;
                    LazyShell.Model.Program.Magic.BringToFront();
                    break;
                case "Sprites":
                    if (Model.Program.Sprites == null || !Model.Program.Sprites.Visible)
                        LazyShell.Model.Program.CreateSpritesWindow();
                    LazyShell.Model.Program.Sprites.Index = (int)indexNumber.Value;
                    LazyShell.Model.Program.Sprites.BringToFront();
                    break;
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (Do.GetSelectedIndex(elementIndexes) == -1)
                return;
            project.DeleteIndex(Do.GetSelectedIndex(elementIndexes), currentIndexes);
            int selectedIndex = Do.GetSelectedIndex(elementIndexes);
            RefreshElementIndexes();
            if (currentIndexes.Count > 0)
                elementIndexes.Items[Math.Min(selectedIndex, currentIndexes.Count - 1)].Selected = true;
        }
        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            if (Do.GetSelectedIndex(elementIndexes) == 0)
                return;
            project.SwitchIndex(Do.GetSelectedIndex(elementIndexes) - 1, currentIndexes);
            int selectedIndex = Do.GetSelectedIndex(elementIndexes);
            RefreshElementIndexes();
            elementIndexes.Items[selectedIndex - 1].Selected = true;
        }
        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            if (Do.GetSelectedIndex(elementIndexes) >= elementIndexes.Items.Count - 1)
                return;
            project.SwitchIndex(Do.GetSelectedIndex(elementIndexes), currentIndexes);
            int selectedIndex = Do.GetSelectedIndex(elementIndexes);
            RefreshElementIndexes();
            elementIndexes.Items[selectedIndex + 1].Selected = true;
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddNewIndex();
        }

        // Keystrokes
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (fontTableImage == null)
                SetFontTableImage();
            e.Graphics.DrawImage(fontTableImage, 0, 0, 256, 384);
            overlay.DrawTileGrid(e.Graphics, Color.Gray, fontTableImage.Size, new Size(32, 24), false, -1);
        }
        private void keyBox_Enter(object sender, EventArgs e)
        {
            (sender as TextBox).SelectAll();
        }
        private void keyBox_MouseUp(object sender, MouseEventArgs e)
        {
            (sender as TextBox).SelectAll();
        }
        private void keyBox_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            TextBox rtb = sender as TextBox;
            keystrokes[(int)rtb.Tag + 32] = rtb.Text;
        }
        private void fontType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshKeystrokes();
            SetFontTableImage();
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
            keystrokes[32] = " ";
            RefreshKeystrokes();
        }
        private void saveKeystrokes_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            switch (FontType)
            {
                case FontType.Menu: saveFileDialog.FileName = Model.GetFileNameWithoutPath() + " - keystrokesMenu.txt"; break;
                case FontType.Dialogue: saveFileDialog.FileName = Model.GetFileNameWithoutPath() + " - keystrokesDialogue.txt"; break;
                case FontType.Description: saveFileDialog.FileName = Model.GetFileNameWithoutPath() + " - keystrokesDescriptions.txt"; break;
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
        private void resetKeystrokes_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset all keystroke tables to their default values?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            switch (FontType)
            {
                case FontType.Menu: Model.KeystrokesMenu.CopyTo(project.KeystrokesMenu, 0); break;
                case FontType.Dialogue: Model.Keystrokes.CopyTo(project.Keystrokes, 0); break;
                case FontType.Description: Model.KeystrokesDesc.CopyTo(project.KeystrokesDesc, 0); break;
            }
            RefreshKeystrokes();
        }

        #endregion
    }
}
