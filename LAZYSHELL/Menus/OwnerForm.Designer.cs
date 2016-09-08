
namespace LazyShell.Menus
{
    partial class OwnerForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager Resources = new System.ComponentModel.ComponentResourceManager(typeof(OwnerForm));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.menuName = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.labelMusic = new System.Windows.Forms.ToolStripLabel();
			this.music = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.openPalettesBG = new System.Windows.Forms.ToolStripMenuItem();
			this.openPalettesFG = new System.Windows.Forms.ToolStripMenuItem();
			this.openPaletteSpeakers = new System.Windows.Forms.ToolStripMenuItem();
			this.openPaletteCursors = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
			this.openGraphicsBG = new System.Windows.Forms.ToolStripMenuItem();
			this.openGraphicsFG = new System.Windows.Forms.ToolStripMenuItem();
			this.openGraphicsSpeakers = new System.Windows.Forms.ToolStripMenuItem();
			this.openGraphicsCursors = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
			this.importBGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importFGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.saveImageAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.pictureBoxFG = new System.Windows.Forms.PictureBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBoxBG = new System.Windows.Forms.PictureBox();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.save = new System.Windows.Forms.ToolStripButton();
			this.helpTips = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toggleMenuText = new LazyShell.Controls.NewToolStripButton();
			this.toggleCursor = new LazyShell.Controls.NewToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStrip1.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxFG)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxBG)).BeginInit();
			this.toolStrip2.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.menuName,
            this.toolStripSeparator1,
            this.labelMusic,
            this.music});
			this.toolStrip1.Location = new System.Drawing.Point(0, 25);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(768, 25);
			this.toolStrip1.TabIndex = 0;
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(38, 22);
			this.toolStripLabel1.Text = "Menu";
			// 
			// menuName
			// 
			this.menuName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.menuName.DropDownWidth = 200;
			this.menuName.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.menuName.Items.AddRange(new object[] {
            "Game Select",
            "Overworld Menu - Main",
            "Overworld Menu - Item",
            "Overworld Menu - Status",
            "Overworld Menu - Special",
            "Overworld Menu - Equip",
            "Overworld Menu - Special Item",
            "Overworld Menu - Switch",
            "Shop Menu",
            "Shop Menu - Buy",
            "Shop Menu - Sell Items",
            "Shop Menu - Sell Weapons"});
			this.menuName.Name = "menuName";
			this.menuName.Size = new System.Drawing.Size(210, 25);
			this.menuName.SelectedIndexChanged += new System.EventHandler(this.menuName_SelectedIndexChanged);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// labelMusic
			// 
			this.labelMusic.Name = "labelMusic";
			this.labelMusic.Size = new System.Drawing.Size(39, 22);
			this.labelMusic.Text = "Music";
			// 
			// music
			// 
			this.music.DropDownHeight = 400;
			this.music.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.music.DropDownWidth = 300;
			this.music.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.music.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.music.IntegralHeight = false;
			this.music.Name = "music";
			this.music.Size = new System.Drawing.Size(210, 25);
			// 
			// toolStripDropDownButton1
			// 
			this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openPalettesBG,
            this.openPalettesFG,
            this.openPaletteSpeakers,
            this.openPaletteCursors});
			this.toolStripDropDownButton1.Image = global::LazyShell.Properties.Resources.openPalettes;
			this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
			// 
			// openPalettesBG
			// 
			this.openPalettesBG.Name = "openPalettesBG";
			this.openPalettesBG.Size = new System.Drawing.Size(183, 22);
			this.openPalettesBG.Text = "Background Palette";
			this.openPalettesBG.Click += new System.EventHandler(this.openPalettesBG_Click);
			// 
			// openPalettesFG
			// 
			this.openPalettesFG.Name = "openPalettesFG";
			this.openPalettesFG.Size = new System.Drawing.Size(183, 22);
			this.openPalettesFG.Text = "Foreground Palette";
			this.openPalettesFG.Click += new System.EventHandler(this.openPalettesFG_Click);
			// 
			// openPaletteSpeakers
			// 
			this.openPaletteSpeakers.Name = "openPaletteSpeakers";
			this.openPaletteSpeakers.Size = new System.Drawing.Size(183, 22);
			this.openPaletteSpeakers.Text = "Mono/Stereo Palette";
			this.openPaletteSpeakers.Click += new System.EventHandler(this.openPaletteSpeakers_Click);
			// 
			// openPaletteCursors
			// 
			this.openPaletteCursors.Name = "openPaletteCursors";
			this.openPaletteCursors.Size = new System.Drawing.Size(183, 22);
			this.openPaletteCursors.Text = "Cursors Palette";
			this.openPaletteCursors.Click += new System.EventHandler(this.openPaletteCursors_Click);
			// 
			// toolStripDropDownButton3
			// 
			this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openGraphicsBG,
            this.openGraphicsFG,
            this.openGraphicsSpeakers,
            this.openGraphicsCursors});
			this.toolStripDropDownButton3.Image = global::LazyShell.Properties.Resources.openGraphics;
			this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
			this.toolStripDropDownButton3.Size = new System.Drawing.Size(29, 22);
			// 
			// openGraphicsBG
			// 
			this.openGraphicsBG.Name = "openGraphicsBG";
			this.openGraphicsBG.Size = new System.Drawing.Size(193, 22);
			this.openGraphicsBG.Text = "Background Graphics";
			this.openGraphicsBG.Click += new System.EventHandler(this.openGraphicsBG_Click);
			// 
			// openGraphicsFG
			// 
			this.openGraphicsFG.Name = "openGraphicsFG";
			this.openGraphicsFG.Size = new System.Drawing.Size(193, 22);
			this.openGraphicsFG.Text = "Foreground Graphics";
			this.openGraphicsFG.Click += new System.EventHandler(this.openGraphicsFG_Click);
			// 
			// openGraphicsSpeakers
			// 
			this.openGraphicsSpeakers.Name = "openGraphicsSpeakers";
			this.openGraphicsSpeakers.Size = new System.Drawing.Size(193, 22);
			this.openGraphicsSpeakers.Text = "Mono/Stereo Graphics";
			this.openGraphicsSpeakers.Click += new System.EventHandler(this.openGraphicsSpeakers_Click);
			// 
			// openGraphicsCursors
			// 
			this.openGraphicsCursors.Name = "openGraphicsCursors";
			this.openGraphicsCursors.Size = new System.Drawing.Size(193, 22);
			this.openGraphicsCursors.Text = "Cursor Graphics";
			this.openGraphicsCursors.Click += new System.EventHandler(this.openGraphicsCursors_Click);
			// 
			// toolStripDropDownButton2
			// 
			this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importBGToolStripMenuItem,
            this.importFGToolStripMenuItem});
			this.toolStripDropDownButton2.Image = global::LazyShell.Properties.Resources.importImage;
			this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
			this.toolStripDropDownButton2.Size = new System.Drawing.Size(29, 22);
			// 
			// importBGToolStripMenuItem
			// 
			this.importBGToolStripMenuItem.Name = "importBGToolStripMenuItem";
			this.importBGToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.importBGToolStripMenuItem.Text = "Import Background";
			this.importBGToolStripMenuItem.Click += new System.EventHandler(this.importImage);
			// 
			// importFGToolStripMenuItem
			// 
			this.importFGToolStripMenuItem.Name = "importFGToolStripMenuItem";
			this.importFGToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.importFGToolStripMenuItem.Text = "Import Foreground";
			this.importFGToolStripMenuItem.Click += new System.EventHandler(this.importImage);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveImageAsToolStripMenuItem,
            this.importImageToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.contextMenuStrip1.Size = new System.Drawing.Size(158, 48);
			// 
			// saveImageAsToolStripMenuItem
			// 
			this.saveImageAsToolStripMenuItem.Image = global::LazyShell.Properties.Resources.exportImage;
			this.saveImageAsToolStripMenuItem.Name = "saveImageAsToolStripMenuItem";
			this.saveImageAsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.saveImageAsToolStripMenuItem.Text = "Save image as...";
			this.saveImageAsToolStripMenuItem.Click += new System.EventHandler(this.saveImageAs);
			// 
			// importImageToolStripMenuItem
			// 
			this.importImageToolStripMenuItem.Image = global::LazyShell.Properties.Resources.importImage;
			this.importImageToolStripMenuItem.Name = "importImageToolStripMenuItem";
			this.importImageToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.importImageToolStripMenuItem.Text = "Import image...";
			this.importImageToolStripMenuItem.Click += new System.EventHandler(this.importImage);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.panel4);
			this.panel3.Controls.Add(this.panel2);
			this.panel3.Controls.Add(this.panel1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 50);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(768, 256);
			this.panel3.TabIndex = 1;
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panel4.Controls.Add(this.pictureBoxPreview);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel4.Location = new System.Drawing.Point(512, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(256, 256);
			this.panel4.TabIndex = 2;
			// 
			// pictureBoxPreview
			// 
			this.pictureBoxPreview.BackgroundImage = global::LazyShell.Properties.Resources._transparent;
			this.pictureBoxPreview.Location = new System.Drawing.Point(0, 0);
			this.pictureBoxPreview.Name = "pictureBoxPreview";
			this.pictureBoxPreview.Size = new System.Drawing.Size(256, 224);
			this.pictureBoxPreview.TabIndex = 3;
			this.pictureBoxPreview.TabStop = false;
			this.pictureBoxPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxPreview_Paint);
			this.pictureBoxPreview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxPreview_MouseDown);
			this.pictureBoxPreview.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxPreview_MouseMove);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panel2.Controls.Add(this.pictureBoxFG);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point(256, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(256, 256);
			this.panel2.TabIndex = 1;
			// 
			// pictureBoxFG
			// 
			this.pictureBoxFG.BackgroundImage = global::LazyShell.Properties.Resources._transparent;
			this.pictureBoxFG.ContextMenuStrip = this.contextMenuStrip1;
			this.pictureBoxFG.Location = new System.Drawing.Point(0, 0);
			this.pictureBoxFG.Name = "pictureBoxFG";
			this.pictureBoxFG.Size = new System.Drawing.Size(256, 256);
			this.pictureBoxFG.TabIndex = 560;
			this.pictureBoxFG.TabStop = false;
			this.pictureBoxFG.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxFG_Paint);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panel1.Controls.Add(this.pictureBoxBG);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(256, 256);
			this.panel1.TabIndex = 0;
			// 
			// pictureBoxBG
			// 
			this.pictureBoxBG.BackgroundImage = global::LazyShell.Properties.Resources._transparent;
			this.pictureBoxBG.ContextMenuStrip = this.contextMenuStrip1;
			this.pictureBoxBG.Location = new System.Drawing.Point(0, 0);
			this.pictureBoxBG.Name = "pictureBoxBG";
			this.pictureBoxBG.Size = new System.Drawing.Size(256, 256);
			this.pictureBoxBG.TabIndex = 559;
			this.pictureBoxBG.TabStop = false;
			this.pictureBoxBG.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxBG_Paint);
			// 
			// toolStrip2
			// 
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save,
            this.helpTips,
            this.toolStripSeparator2,
            this.toggleMenuText,
            this.toggleCursor,
            this.toolStripSeparator3,
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton3,
            this.toolStripDropDownButton2});
			this.toolStrip2.Location = new System.Drawing.Point(0, 0);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(768, 25);
			this.toolStrip2.TabIndex = 2;
			this.toolStrip2.Text = "toolStrip2";
			// 
			// save
			// 
			this.save.Image = global::LazyShell.Properties.Resources.save;
			this.save.Name = "save";
			this.save.Size = new System.Drawing.Size(23, 22);
			this.save.ToolTipText = "Save";
			this.save.Click += new System.EventHandler(this.save_Click);
			// 
			// helpTips
			// 
			this.helpTips.CheckOnClick = true;
			this.helpTips.Image = global::LazyShell.Properties.Resources.help;
			this.helpTips.Name = "helpTips";
			this.helpTips.Size = new System.Drawing.Size(23, 22);
			this.helpTips.ToolTipText = "Help Tips";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// toggleMenuText
			// 
			this.toggleMenuText.CheckOnClick = true;
			this.toggleMenuText.Form = null;
			this.toggleMenuText.Image = ((System.Drawing.Image)(Resources.GetObject("toggleMenuText.Image")));
			this.toggleMenuText.Name = "toggleMenuText";
			this.toggleMenuText.Size = new System.Drawing.Size(23, 22);
			this.toggleMenuText.ToolTipText = "Show/hide menu text";
			// 
			// toggleCursor
			// 
			this.toggleCursor.CheckOnClick = true;
			this.toggleCursor.Form = null;
			this.toggleCursor.Image = ((System.Drawing.Image)(Resources.GetObject("toggleCursor.Image")));
			this.toggleCursor.Name = "toggleCursor";
			this.toggleCursor.Size = new System.Drawing.Size(23, 22);
			this.toggleCursor.ToolTipText = "Show/hide menu cursor";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// OwnerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(768, 306);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.toolStrip2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Location = new System.Drawing.Point(0, 0);
			this.Name = "OwnerForm";
			this.Text = "Menus - Lazy Shell";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OwnerForm_FormClosing);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxFG)).EndInit();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxBG)).EndInit();
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveImageAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem openPalettesBG;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem openGraphicsBG;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem importBGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPaletteCursors;
        private System.Windows.Forms.ToolStripMenuItem openGraphicsCursors;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxBG;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBoxFG;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox menuName;
        private System.Windows.Forms.ToolStripMenuItem openPalettesFG;
        private System.Windows.Forms.ToolStripMenuItem openPaletteSpeakers;
        private System.Windows.Forms.ToolStripMenuItem openGraphicsFG;
        private System.Windows.Forms.ToolStripMenuItem openGraphicsSpeakers;
        private System.Windows.Forms.ToolStripMenuItem importFGToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox music;
        private System.Windows.Forms.ToolStripLabel labelMusic;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.ToolStripButton helpTips;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private Controls.NewToolStripButton toggleMenuText;
        private Controls.NewToolStripButton toggleCursor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}