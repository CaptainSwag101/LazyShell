
namespace LAZYSHELL.Dialogues
{
    partial class BattleDialoguesForm
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
            this.textBox = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.typeName = new System.Windows.Forms.ToolStripComboBox();
            this.num = new LAZYSHELL.Controls.NewToolStripNumericUpDown();
            this.searchButton = new System.Windows.Forms.ToolStripButton();
            this.picture = new System.Windows.Forms.PictureBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.pageUp = new System.Windows.Forms.ToolStripButton();
            this.pageDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.textView = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.availableBytes = new System.Windows.Forms.ToolStripLabel();
            this.newLine = new System.Windows.Forms.ToolStripButton();
            this.endString = new System.Windows.Forms.ToolStripButton();
            this.pause60f = new System.Windows.Forms.ToolStripButton();
            this.pauseA = new System.Windows.Forms.ToolStripButton();
            this.pauseFrames = new System.Windows.Forms.ToolStripButton();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.import = new System.Windows.Forms.ToolStripButton();
            this.export = new System.Windows.Forms.ToolStripButton();
            this.clear = new System.Windows.Forms.ToolStripButton();
            this.reset = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toggleText = new System.Windows.Forms.ToolStripButton();
            this.toggleTileGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.openTileEditor = new System.Windows.Forms.ToolStripButton();
            this.openGraphics = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.openPaletteDialogue = new System.Windows.Forms.ToolStripMenuItem();
            this.openPaletteMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox.Location = new System.Drawing.Point(0, 57);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(232, 126);
            this.textBox.TabIndex = 3;
            this.textBox.Text = "";
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.typeName,
            this.num,
            this.searchButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(256, 25);
            this.toolStrip1.TabIndex = 1;
            // 
            // typeName
            // 
            this.typeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeName.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.typeName.Items.AddRange(new object[] {
            "Battle Dialogues",
            "Battle Messages",
            "Flower Bonus"});
            this.typeName.Name = "typeName";
            this.typeName.Size = new System.Drawing.Size(120, 25);
            this.typeName.SelectedIndexChanged += new System.EventHandler(this.typeName_SelectedIndexChanged);
            // 
            // num
            // 
            this.num.AutoSize = false;
            this.num.ContextMenuStrip = null;
            this.num.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num.Hexadecimal = false;
            this.num.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num.Location = new System.Drawing.Point(131, 2);
            this.num.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.num.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.num.Name = "battleDialogueNum";
            this.num.Size = new System.Drawing.Size(50, 21);
            this.num.Text = "0";
            this.num.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.num.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // searchButton
            // 
            this.searchButton.Image = global::LAZYSHELL.Properties.Resources.search;
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(23, 22);
            this.searchButton.ToolTipText = "Search For Dialogue";
            // 
            // picture
            // 
            this.picture.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.picture.Dock = System.Windows.Forms.DockStyle.Top;
            this.picture.Location = new System.Drawing.Point(0, 0);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(256, 32);
            this.picture.TabIndex = 520;
            this.picture.TabStop = false;
            this.picture.Paint += new System.Windows.Forms.PaintEventHandler(this.picture_Paint);
            this.picture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picture_MouseDown);
            this.picture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picture_MouseMove);
            this.picture.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.picture_PreviewKeyDown);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pageUp,
            this.pageDown,
            this.toolStripSeparator1,
            this.textView,
            this.toolStripSeparator4,
            this.availableBytes});
            this.toolStrip2.Location = new System.Drawing.Point(0, 32);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(256, 25);
            this.toolStrip2.TabIndex = 2;
            // 
            // pageUp
            // 
            this.pageUp.Image = global::LAZYSHELL.Properties.Resources.pageUp;
            this.pageUp.Name = "pageUp";
            this.pageUp.Size = new System.Drawing.Size(23, 22);
            this.pageUp.ToolTipText = "Page Up";
            this.pageUp.Click += new System.EventHandler(this.pageUp_Click);
            // 
            // pageDown
            // 
            this.pageDown.Image = global::LAZYSHELL.Properties.Resources.pageDown;
            this.pageDown.Name = "pageDown";
            this.pageDown.Size = new System.Drawing.Size(23, 22);
            this.pageDown.ToolTipText = "Page Down";
            this.pageDown.Click += new System.EventHandler(this.pageDown_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // textView
            // 
            this.textView.CheckOnClick = true;
            this.textView.Image = global::LAZYSHELL.Properties.Resources.textView;
            this.textView.Name = "textView";
            this.textView.Size = new System.Drawing.Size(23, 22);
            this.textView.ToolTipText = "Text View";
            this.textView.Click += new System.EventHandler(this.textView_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // availableBytes
            // 
            this.availableBytes.Name = "availableBytes";
            this.availableBytes.Size = new System.Drawing.Size(81, 22);
            this.availableBytes.Text = "characters left";
            // 
            // newLine
            // 
            this.newLine.Image = global::LAZYSHELL.Properties.Resources.newLine;
            this.newLine.Name = "newLine";
            this.newLine.Size = new System.Drawing.Size(21, 20);
            this.newLine.ToolTipText = "New Line";
            this.newLine.Click += new System.EventHandler(this.newLine_Click);
            // 
            // endString
            // 
            this.endString.Image = global::LAZYSHELL.Properties.Resources.endString;
            this.endString.Name = "endString";
            this.endString.Size = new System.Drawing.Size(21, 20);
            this.endString.ToolTipText = "End String";
            this.endString.Click += new System.EventHandler(this.endString_Click);
            // 
            // pause60f
            // 
            this.pause60f.Image = global::LAZYSHELL.Properties.Resources.pause60f;
            this.pause60f.Name = "pause60f";
            this.pause60f.Size = new System.Drawing.Size(21, 20);
            this.pause60f.ToolTipText = "Pause 1 second";
            this.pause60f.Click += new System.EventHandler(this.pause60f_Click);
            // 
            // pauseA
            // 
            this.pauseA.Image = global::LAZYSHELL.Properties.Resources.pauseA;
            this.pauseA.Name = "pauseA";
            this.pauseA.Size = new System.Drawing.Size(21, 20);
            this.pauseA.ToolTipText = "Pause, wait for input";
            this.pauseA.Click += new System.EventHandler(this.pauseA_Click);
            // 
            // pauseFrames
            // 
            this.pauseFrames.CheckOnClick = true;
            this.pauseFrames.Image = global::LAZYSHELL.Properties.Resources.pauseFrames;
            this.pauseFrames.Name = "pauseFrames";
            this.pauseFrames.Size = new System.Drawing.Size(21, 20);
            this.pauseFrames.ToolTipText = "Pause for # of frames";
            this.pauseFrames.Click += new System.EventHandler(this.pauseFrames_Click);
            // 
            // toolStrip4
            // 
            this.toolStrip4.CanOverflow = false;
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.import,
            this.export,
            this.clear,
            this.reset,
            this.toolStripSeparator2,
            this.toggleText,
            this.toggleTileGrid,
            this.toolStripSeparator3,
            this.openTileEditor,
            this.openGraphics,
            this.toolStripDropDownButton1});
            this.toolStrip4.Location = new System.Drawing.Point(0, 0);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(256, 25);
            this.toolStrip4.TabIndex = 0;
            // 
            // import
            // 
            this.import.Image = global::LAZYSHELL.Properties.Resources.importText;
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(23, 22);
            this.import.Click += new System.EventHandler(this.import_Click);
            // 
            // export
            // 
            this.export.Image = global::LAZYSHELL.Properties.Resources.exportText;
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(23, 22);
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // clear
            // 
            this.clear.Image = global::LAZYSHELL.Properties.Resources.clear;
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(23, 22);
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // reset
            // 
            this.reset.Image = global::LAZYSHELL.Properties.Resources.reset;
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(23, 22);
            this.reset.ToolTipText = "Reset";
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toggleText
            // 
            this.toggleText.Checked = true;
            this.toggleText.CheckOnClick = true;
            this.toggleText.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toggleText.Name = "toggleText";
            this.toggleText.Size = new System.Drawing.Size(32, 22);
            this.toggleText.Text = "TXT";
            this.toggleText.ToolTipText = "Show/hide Dialogue Text";
            this.toggleText.Click += new System.EventHandler(this.toggleText_Click);
            // 
            // toggleTileGrid
            // 
            this.toggleTileGrid.CheckOnClick = true;
            this.toggleTileGrid.Image = global::LAZYSHELL.Properties.Resources.buttonToggleGrid;
            this.toggleTileGrid.Name = "toggleTileGrid";
            this.toggleTileGrid.Size = new System.Drawing.Size(23, 22);
            this.toggleTileGrid.ToolTipText = "Tile Grid";
            this.toggleTileGrid.Click += new System.EventHandler(this.toggleTileGrid_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // openTileEditor
            // 
            this.openTileEditor.Image = global::LAZYSHELL.Properties.Resources.openTileEditor;
            this.openTileEditor.Name = "openTileEditor";
            this.openTileEditor.Size = new System.Drawing.Size(23, 22);
            this.openTileEditor.ToolTipText = "Tile Editor";
            this.openTileEditor.Click += new System.EventHandler(this.openTileEditor_Click);
            // 
            // openGraphics
            // 
            this.openGraphics.Image = global::LAZYSHELL.Properties.Resources.openGraphics;
            this.openGraphics.Name = "openGraphics";
            this.openGraphics.Size = new System.Drawing.Size(23, 22);
            this.openGraphics.ToolTipText = "BPP Graphics";
            this.openGraphics.Click += new System.EventHandler(this.openGraphics_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openPaletteDialogue,
            this.openPaletteMenu});
            this.toolStripDropDownButton1.Image = global::LAZYSHELL.Properties.Resources.openPalettes;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            // 
            // openPaletteDialogue
            // 
            this.openPaletteDialogue.Name = "openPaletteDialogue";
            this.openPaletteDialogue.Size = new System.Drawing.Size(187, 22);
            this.openPaletteDialogue.Text = "Dialogue Font Palette";
            this.openPaletteDialogue.Click += new System.EventHandler(this.openPalettes_Click);
            // 
            // openPaletteMenu
            // 
            this.openPaletteMenu.Name = "openPaletteMenu";
            this.openPaletteMenu.Size = new System.Drawing.Size(187, 22);
            this.openPaletteMenu.Text = "Menu Font Palette";
            this.openPaletteMenu.Click += new System.EventHandler(this.openPaletteMenu_Click);
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newLine,
            this.endString,
            this.pause60f,
            this.pauseA,
            this.pauseFrames});
            this.toolStrip3.Location = new System.Drawing.Point(232, 57);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(24, 126);
            this.toolStrip3.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox);
            this.panel1.Controls.Add(this.toolStrip3);
            this.panel1.Controls.Add(this.toolStrip2);
            this.panel1.Controls.Add(this.picture);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 183);
            this.panel1.TabIndex = 2;
            // 
            // BattleDialoguesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 233);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.toolStrip4);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "BattleDialoguesForm";
            this.Text = "Battle Dialogues";
            this.TilesetForm = null;
            this.TilesetForms = new LAZYSHELL.TilesetForm[] {
        null};
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.RichTextBox textBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox typeName;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton pageUp;
        private System.Windows.Forms.ToolStripButton pageDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel availableBytes;
        private System.Windows.Forms.ToolStripButton newLine;
        private System.Windows.Forms.ToolStripButton endString;
        private System.Windows.Forms.ToolStripButton pause60f;
        private System.Windows.Forms.ToolStripButton pauseA;
        private System.Windows.Forms.ToolStripButton pauseFrames;
        private Controls.NewToolStripNumericUpDown num;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton openTileEditor;
        private System.Windows.Forms.ToolStripButton openGraphics;
        private System.Windows.Forms.ToolStripButton searchButton;
        private System.Windows.Forms.ToolStripButton textView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton reset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toggleTileGrid;
        private System.Windows.Forms.ToolStripButton toggleText;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem openPaletteDialogue;
        private System.Windows.Forms.ToolStripMenuItem openPaletteMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton import;
        private System.Windows.Forms.ToolStripButton export;
        private System.Windows.Forms.ToolStripButton clear;
    }
}