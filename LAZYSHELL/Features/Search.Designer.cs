namespace LAZYSHELL
{
    partial class Search
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.Enabled = false;
            this.listBox.FormattingEnabled = true;
            this.listBox.IntegralHeight = false;
            this.listBox.Location = new System.Drawing.Point(0, 0);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(507, 472);
            this.listBox.TabIndex = 0;
            this.listBox.Visible = false;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            this.listBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Search_KeyDown);
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Enabled = false;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(507, 472);
            this.treeView.TabIndex = 1;
            this.treeView.Visible = false;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            this.treeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Search_KeyDown);
            // 
            // richTextBox
            // 
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox.Enabled = false;
            this.richTextBox.Location = new System.Drawing.Point(0, 0);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(507, 472);
            this.richTextBox.TabIndex = 2;
            this.richTextBox.Text = "";
            this.richTextBox.Visible = false;
            this.richTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Search_KeyDown);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 472);
            this.ControlBox = false;
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.treeView);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Search";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "SEARCH";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Search_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.RichTextBox richTextBox;
    }
}