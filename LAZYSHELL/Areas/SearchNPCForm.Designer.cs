namespace LazyShell.Areas
{
    partial class SearchNPCForm
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
			this.searchResults = new System.Windows.Forms.ListBox();
			this.toolStrip3 = new System.Windows.Forms.ToolStrip();
			this.spriteName = new System.Windows.Forms.ToolStripComboBox();
			this.search = new System.Windows.Forms.ToolStripButton();
			this.toolStrip3.SuspendLayout();
			this.SuspendLayout();
			// 
			// searchResults
			// 
			this.searchResults.Dock = System.Windows.Forms.DockStyle.Fill;
			this.searchResults.FormattingEnabled = true;
			this.searchResults.IntegralHeight = false;
			this.searchResults.Location = new System.Drawing.Point(0, 25);
			this.searchResults.Name = "searchResults";
			this.searchResults.Size = new System.Drawing.Size(428, 476);
			this.searchResults.TabIndex = 4;
			this.searchResults.SelectedIndexChanged += new System.EventHandler(this.searchResults_SelectedIndexChanged);
			// 
			// toolStrip3
			// 
			this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spriteName,
            this.search});
			this.toolStrip3.Location = new System.Drawing.Point(0, 0);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.Size = new System.Drawing.Size(428, 25);
			this.toolStrip3.TabIndex = 3;
			// 
			// spriteName
			// 
			this.spriteName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.spriteName.DropDownWidth = 400;
			this.spriteName.Name = "spriteName";
			this.spriteName.Size = new System.Drawing.Size(200, 25);
			this.spriteName.SelectedIndexChanged += new System.EventHandler(this.spriteName_SelectedIndexChanged);
			// 
			// search
			// 
			this.search.Image = global::LazyShell.Properties.Resources.search;
			this.search.Name = "search";
			this.search.Size = new System.Drawing.Size(23, 22);
			this.search.ToolTipText = "Find sprite by name";
			// 
			// SearchNPCForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(428, 501);
			this.Controls.Add(this.searchResults);
			this.Controls.Add(this.toolStrip3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Location = new System.Drawing.Point(0, 0);
			this.Name = "SearchNPCForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Search NPCs";
			this.TopMost = true;
			this.toolStrip3.ResumeLayout(false);
			this.toolStrip3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox searchResults;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripComboBox spriteName;
        private System.Windows.Forms.ToolStripButton search;
    }
}