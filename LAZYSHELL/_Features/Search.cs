using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LazyShell
{
    public partial class Search : Controls.NewForm
    {
        #region Variables

        // Functions
        private Delegate performSearch;
        private Delegate loadResult;
        private delegate void SearchFunction();
        private StringComparison stringComparison
        {
            get
            {
                if (matchCase.Checked)
                    return StringComparison.CurrentCulture;
                else
                    return StringComparison.CurrentCultureIgnoreCase;
            }
        }
        private Timer timer = new Timer();

        // Controls
        private ToolStripComboBox indexName;
        private Controls.NewToolStripNumericUpDown indexNum;
        private ToolStripButton searchButton;
        private Point searchButtonLocation
        {
            get { return Do.GetControlLocation(searchButton); }
        }

        // Element list
        public IList Names { get; set; }

        // Miscellaneous
        private bool searchFieldEnter = false;
        private bool initialized = false;

        #endregion

        // Constructors
        /// <summary>
        /// Loads a search form containing the results of a search query.
        /// </summary>
        /// <param name="indexNum">The search index control to update when a search result is selected.</param>
        /// <param name="searchField">The search field control containing the search query text.</param>
        /// <param name="searchButton">The search button control that invokes the search.</param>
        /// <param name="names">The data list to search for a specified query in.</param>
        public Search(Controls.NewToolStripNumericUpDown indexNum, ToolStripButton searchButton, IList names)
        {
            InitializeComponent();
            this.listBox.Enabled = true;
            this.listBox.Show();
            this.listBox.BringToFront();
            this.Names = names;
            this.indexNum = indexNum;
            this.searchButton = searchButton;
            InitializeControls();
            PerformSearch();
            this.performSearch = new SearchFunction(PerformSearch);
            this.performSearch.DynamicInvoke();
            this.Location = searchButtonLocation;
            StartTimer();
        }
        /// <summary>
        /// Loads a search form containing the results of a search query.
        /// </summary>
        /// <param name="indexName">The search index control to update when a search result is selected.</param>
        /// <param name="searchField">The search field control containing the search query text.</param>
        /// <param name="searchButton">The search button control that invokes the search.</param>
        /// <param name="names">The data list to search for a specified query in.</param>
        public Search(ToolStripComboBox indexName, ToolStripButton searchButton, IList names)
        {
            InitializeComponent();
            this.listBox.Enabled = true;
            this.listBox.Show();
            this.listBox.BringToFront();
            this.Names = names;
            this.indexName = indexName;
            this.searchButton = searchButton;
            InitializeControls();
            this.performSearch = new SearchFunction(PerformSearch);
            this.performSearch.DynamicInvoke();
            this.Location = searchButtonLocation;
            StartTimer();
        }
        /// <summary>
        /// Loads a search form containing the results of a search query.
        /// </summary>
        /// <param name="indexNum">The search index control to update when a search result is selected.</param>
        /// <param name="searchField">The search field control containing the search query text.</param>
        /// <param name="searchButton">The search button control that invokes the search.</param>
        /// <param name="performSearch">The function to execute when a search is invoked.</param>
        /// <param name="resultWindow">The type of control that contains the search results.
        /// Options include: ListBox, TreeView, TextBox</param>
        public Search(Controls.NewToolStripNumericUpDown indexNum, ToolStripButton searchButton, Delegate performSearch, Type resultWindow)
        {
            InitializeComponent();
            this.indexNum = indexNum;
            this.searchButton = searchButton;
            InitializeControls();
            this.performSearch = performSearch;
            this.replaceWithSeparator.Visible = resultWindow == typeof(TextBox);
            this.replaceWithLabel.Visible = resultWindow == typeof(TextBox);
            this.replaceAllButton.Visible = resultWindow == typeof(TextBox);
            this.replaceWithText.Visible = resultWindow == typeof(TextBox);
            if (resultWindow == typeof(ListBox))
            {
                this.listBox.Enabled = true;
                this.listBox.Show();
                this.listBox.BringToFront();
                this.performSearch.DynamicInvoke(searchForText.Text, listBox, stringComparison, matchWholeWord.Checked);
            }
            else if (resultWindow == typeof(TreeView))
            {
                this.treeView.Enabled = true;
                this.treeView.Show();
                this.treeView.BringToFront();
                this.performSearch.DynamicInvoke(searchForText.Text, treeView, stringComparison, matchWholeWord.Checked);
            }
            else if (resultWindow == typeof(TextBoxBase))
            {
                this.searchTextBox.Enabled = true;
                this.searchTextBox.Show();
                this.searchTextBox.BringToFront();
                this.performSearch.DynamicInvoke(searchForText.Text, searchTextBox, stringComparison, matchWholeWord.Checked, false, "");
            }
            this.Location = searchButtonLocation;
            StartTimer();
        }
        public Search(ToolStripButton searchButton, Delegate performSearch, Delegate loadResult)
        {
            InitializeComponent();
            this.listBox.Enabled = true;
            this.listBox.Show();
            this.listBox.BringToFront();
            this.searchButton = searchButton;
            InitializeControls();
            this.performSearch = performSearch;
            this.loadResult = loadResult;
            this.performSearch.DynamicInvoke(searchForText.Text, listBox, stringComparison, matchWholeWord.Checked);
            this.Location = searchButtonLocation;
            StartTimer();
        }

        #region Methods

        private void InitializeControls()
        {
            this.searchForText.ForeColor = SystemColors.ControlDark;
            this.searchForText.Text = "Find...";
            this.searchForText.KeyDown += new KeyEventHandler(searchField_KeyDown);
            this.searchForText.KeyUp += new KeyEventHandler(searchField_KeyUp);
            this.searchForText.MouseDown += new MouseEventHandler(searchField_MouseDown);
            this.searchForText.Leave += new EventHandler(searchField_Leave);
            this.searchButton.CheckOnClick = true;
            this.searchButton.Click += new EventHandler(searchButton_Click);
        }
        public void PerformSearch()
        {
            listBox.BeginUpdate();
            listBox.Items.Clear();
            if (searchForText.Text == "")
            {
                listBox.EndUpdate();
                this.Height = 32 + toolStrip1.Height;
                return;
            }
            for (int i = 0; i < Names.Count; i++)
            {
                if (Names[i] == null)
                    continue;
                string name = Names[i].ToString();
                int index = name.IndexOf(searchForText.Text, stringComparison);
                if (index >= 0)
                {
                    if (matchWholeWord.Checked)
                    {
                        if (index + searchForText.Text.Length < name.Length && Char.IsLetter(name, index + searchForText.Text.Length))
                            continue;
                        if (index - 1 >= 0 && Char.IsLetter(name, index - 1))
                            continue;
                    }
                    var searchItem = new SearchItem(i, name);
                    listBox.Items.Add(searchItem);
                }
            }
            this.Height = Math.Min(
                listBox.Items.Count * listBox.ItemHeight + 40 + toolStrip1.Height,
                Screen.PrimaryScreen.WorkingArea.Height - this.Top - 16);
            listBox.EndUpdate();
        }
        private void StartTimer()
        {
            timer.Tick += new EventHandler(delegate
            {
                timer.Stop(); this.Location = searchButtonLocation;
            });
            timer.Start();
        }

        #endregion

        #region Event Handlers

        // Search
        private void Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.searchButton.Checked = false;
                this.Hide();
            }
        }
        private void Search_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.searchButton.Checked = false;
            this.Hide();
        }

        // Match options
        private void matchCase_CheckedChanged(object sender, EventArgs e)
        {
            if (this.performSearch == null)
                return;
            //
            if (this.performSearch.Target is Formations.PacksForm)
                this.performSearch.DynamicInvoke(treeView, stringComparison, matchWholeWord.Checked);
            else if (this.performSearch.Target is Dialogues.DialoguesForm)
                this.performSearch.DynamicInvoke(searchForText.Text, searchTextBox, stringComparison, matchWholeWord.Checked, false, "");
            else if (this.performSearch.Target is EventScripts.OwnerForm)
                this.performSearch.DynamicInvoke(searchForText.Text, listBox, stringComparison, matchWholeWord.Checked);
            else
                this.performSearch.DynamicInvoke();
            //
            searchForText.Focus();
        }
        private void matchWholeWord_CheckedChanged(object sender, EventArgs e)
        {
            if (this.performSearch == null)
                return;
            //
            if (this.performSearch.Target is Formations.PacksForm)
                this.performSearch.DynamicInvoke(treeView, stringComparison, matchWholeWord.Checked);
            else if (this.performSearch.Target is Dialogues.DialoguesForm)
                this.performSearch.DynamicInvoke(searchForText.Text, searchTextBox, stringComparison, matchWholeWord.Checked, false, "");
            else
                this.performSearch.DynamicInvoke();
            //
            searchForText.Focus();
        }
        private void replaceAllButton_Click(object sender, EventArgs e)
        {
            if (this.performSearch == null)
                return;
            //
            if (MessageBox.Show("You are about to replace all occurrences of the specified text in all 4096 dialogues.\n\n" +
                "Are you sure you want to do this?", "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;
            //
            if (this.performSearch.Target is Dialogues.DialoguesForm)
                this.performSearch.DynamicInvoke(searchForText.Text, searchTextBox, stringComparison, matchWholeWord.Checked, true, replaceWithText.Text);
            searchForText.Focus();
        }

        // Results
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedItem == null)
                return;
            // perform function from target form
            if (loadResult != null)
            {
                if (loadResult.Target is EventScripts.OwnerForm)
                    loadResult.DynamicInvoke(listBox.SelectedItem as Command);
            }
            // otherwise set value of referenced numeric or list control by default
            else
            {
                int index = (listBox.SelectedItem as SearchItem).Index;
                if (indexNum != null && index < indexNum.Maximum)
                    indexNum.Value = index;
                else if (indexName != null && index < indexName.Items.Count)
                    indexName.SelectedIndex = index;
            }
        }
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // set value of referenced numeric or list control by default
            if (indexNum != null)
                indexNum.Value = (int)treeView.SelectedNode.Tag;
            else if (indexName != null)
                indexName.SelectedIndex = (int)treeView.SelectedNode.Tag;
        }

        // Search field
        private void searchField_MouseDown(object sender, MouseEventArgs e)
        {
            if (!searchFieldEnter)
            {
                searchForText.Text = "";
                searchForText.ForeColor = SystemColors.ControlText;
            }
            searchFieldEnter = true;
        }
        private void searchField_KeyDown(object sender, KeyEventArgs e)
        {
            if (!searchFieldEnter)
                searchForText.ForeColor = SystemColors.ControlText;
            searchFieldEnter = true;
            if (e.KeyData == Keys.Enter)
            {
                searchButton.Checked = true;
                searchButton_Click(null, null);
                if (this.performSearch.Target is Dialogues.DialoguesForm)
                    performSearch.DynamicInvoke(searchForText.Text, searchTextBox, stringComparison, matchWholeWord.Checked, false, "");
            }
        }
        private void searchField_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.performSearch.Target is Formations.PacksForm)
                this.performSearch.DynamicInvoke(treeView, stringComparison, matchWholeWord.Checked);
            else if (this.performSearch.Target is EventScripts.OwnerForm)
                this.performSearch.DynamicInvoke(searchForText.Text, listBox, stringComparison, matchWholeWord.Checked);
            else if (this.performSearch.Target is Dialogues.DialoguesForm)
                this.performSearch.DynamicInvoke(searchForText.Text, searchTextBox, stringComparison, matchWholeWord.Checked, false, "");
            else
                this.performSearch.DynamicInvoke();
            searchForText.Focus();
        }
        private void searchField_Leave(object sender, EventArgs e)
        {
            if (searchForText.Text == "")
            {
                searchForText.Text = "Find...";
                searchForText.ForeColor = SystemColors.ControlDark;
                searchFieldEnter = false;
            }
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            this.Visible = searchButton.Checked;
            if (this.Visible && !initialized)
            {
                this.Location = searchButtonLocation;
                initialized = true;
            }
        }
        #endregion

        /// <summary>
        /// Class containing the information of a search item in a search results list.
        /// </summary>
        private class SearchItem
        {
            #region Variables

            public int Index;
            public string Text;

            #endregion

            // Constructor
            public SearchItem(int index, string text)
            {
                this.Index = index;
                this.Text = text;
            }

            // Override
            public override string ToString()
            {
                return this.Text;
            }
        }
    }
}
