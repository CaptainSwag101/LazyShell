
namespace LazyShell
{
    partial class Search
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Clean up any global::LazyShell.Properties.Resources being used.
        /// </summary>
        /// <param name="disposing">true if managed global::LazyShell.Properties.Resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.listBox = new System.Windows.Forms.ListBox();
			this.treeView = new System.Windows.Forms.TreeView();
			this.searchTextBox = new System.Windows.Forms.RichTextBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.searchForLabel = new System.Windows.Forms.ToolStripLabel();
			this.searchForText = new System.Windows.Forms.ToolStripTextBox();
			this.searchForSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.replaceWithLabel = new System.Windows.Forms.ToolStripLabel();
			this.replaceWithText = new System.Windows.Forms.ToolStripTextBox();
			this.replaceWithSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.matchCase = new LazyShell.Controls.NewToolStripCheckBox();
			this.matchWholeWord = new LazyShell.Controls.NewToolStripCheckBox();
			this.replaceAllButton = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// listBox
			// 
			this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBox.Enabled = false;
			this.listBox.FormattingEnabled = true;
			this.listBox.IntegralHeight = false;
			this.listBox.Location = new System.Drawing.Point(0, 26);
			this.listBox.Name = "listBox";
			this.listBox.Size = new System.Drawing.Size(500, 446);
			this.listBox.TabIndex = 0;
			this.listBox.Visible = false;
			this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
			this.listBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Search_KeyDown);
			// 
			// treeView
			// 
			this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView.Enabled = false;
			this.treeView.Location = new System.Drawing.Point(0, 26);
			this.treeView.Name = "treeView";
			this.treeView.Size = new System.Drawing.Size(500, 446);
			this.treeView.TabIndex = 1;
			this.treeView.Visible = false;
			this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
			this.treeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Search_KeyDown);
			// 
			// searchTextBox
			// 
			this.searchTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.searchTextBox.Enabled = false;
			this.searchTextBox.Location = new System.Drawing.Point(0, 26);
			this.searchTextBox.Name = "searchTextBox";
			this.searchTextBox.Size = new System.Drawing.Size(500, 446);
			this.searchTextBox.TabIndex = 1;
			this.searchTextBox.Text = "";
			this.searchTextBox.Visible = false;
			this.searchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Search_KeyDown);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchForLabel,
            this.searchForText,
            this.searchForSeparator,
            this.replaceWithLabel,
            this.replaceWithText,
            this.replaceWithSeparator,
            this.matchCase,
            this.matchWholeWord,
            this.replaceAllButton});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(500, 26);
			this.toolStrip1.TabIndex = 0;
			// 
			// searchForLabel
			// 
			this.searchForLabel.Name = "searchForLabel";
			this.searchForLabel.Size = new System.Drawing.Size(60, 23);
			this.searchForLabel.Text = "Search for";
			// 
			// searchForText
			// 
			this.searchForText.Name = "searchForText";
			this.searchForText.Size = new System.Drawing.Size(150, 26);
			// 
			// searchForSeparator
			// 
			this.searchForSeparator.Name = "searchForSeparator";
			this.searchForSeparator.Size = new System.Drawing.Size(6, 26);
			// 
			// replaceWithLabel
			// 
			this.replaceWithLabel.Name = "replaceWithLabel";
			this.replaceWithLabel.Size = new System.Drawing.Size(74, 23);
			this.replaceWithLabel.Text = "Replace with";
			this.replaceWithLabel.Visible = false;
			// 
			// replaceWithText
			// 
			this.replaceWithText.Name = "replaceWithText";
			this.replaceWithText.Size = new System.Drawing.Size(150, 26);
			this.replaceWithText.Visible = false;
			// 
			// replaceWithSeparator
			// 
			this.replaceWithSeparator.Name = "replaceWithSeparator";
			this.replaceWithSeparator.Size = new System.Drawing.Size(6, 26);
			this.replaceWithSeparator.Visible = false;
			// 
			// matchCase
			// 
			this.matchCase.BackColor = System.Drawing.Color.Transparent;
			this.matchCase.Checked = false;
			this.matchCase.Name = "matchCase";
			this.matchCase.Padding = new System.Windows.Forms.Padding(4, 0, 0, 4);
			this.matchCase.Size = new System.Drawing.Size(90, 23);
			this.matchCase.Text = "Match case";
			this.matchCase.CheckedChanged += new System.EventHandler(this.matchCase_CheckedChanged);
			// 
			// matchWholeWord
			// 
			this.matchWholeWord.BackColor = System.Drawing.Color.Transparent;
			this.matchWholeWord.Checked = false;
			this.matchWholeWord.Name = "matchWholeWord";
			this.matchWholeWord.Padding = new System.Windows.Forms.Padding(4, 0, 0, 4);
			this.matchWholeWord.Size = new System.Drawing.Size(129, 23);
			this.matchWholeWord.Text = "Match whole word";
			this.matchWholeWord.CheckedChanged += new System.EventHandler(this.matchWholeWord_CheckedChanged);
			// 
			// replaceAllButton
			// 
			this.replaceAllButton.Image = global::LazyShell.Properties.Resources.apply;
			this.replaceAllButton.Name = "replaceAllButton";
			this.replaceAllButton.Size = new System.Drawing.Size(83, 20);
			this.replaceAllButton.Text = "Replace all";
			this.replaceAllButton.Visible = false;
			this.replaceAllButton.Click += new System.EventHandler(this.replaceAllButton_Click);
			// 
			// Search
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(500, 472);
			this.Controls.Add(this.searchTextBox);
			this.Controls.Add(this.listBox);
			this.Controls.Add(this.treeView);
			this.Controls.Add(this.toolStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Location = new System.Drawing.Point(0, 0);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Search";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Search";
			this.TopMost = true;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Search_FormClosing);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Search_KeyDown);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator replaceWithSeparator;
        private System.Windows.Forms.ToolStripLabel replaceWithLabel;
        private System.Windows.Forms.ToolStripTextBox replaceWithText;
        private Controls.NewToolStripCheckBox matchCase;
        private Controls.NewToolStripCheckBox matchWholeWord;
        private System.Windows.Forms.ToolStripButton replaceAllButton;
        private System.Windows.Forms.ToolStripLabel searchForLabel;
        private System.Windows.Forms.ToolStripTextBox searchForText;
        private System.Windows.Forms.ToolStripSeparator searchForSeparator;
		private System.Windows.Forms.RichTextBox searchTextBox;
	}
}