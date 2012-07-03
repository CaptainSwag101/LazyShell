namespace LAZYSHELL
{
    partial class GameSelect
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameSelect));
            this.importImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxFG = new System.Windows.Forms.PictureBox();
            this.importFGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.openGraphicsSpeakers = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.openPalettesFG = new System.Windows.Forms.ToolStripMenuItem();
            this.openPalettesBG = new System.Windows.Forms.ToolStripMenuItem();
            this.openPaletteSpeakers = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.openGraphicsFG = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.music = new System.Windows.Forms.ToolStripComboBox();
            this.contextMenuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFG)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // importImageToolStripMenuItem
            // 
            this.importImageToolStripMenuItem.Name = "importImageToolStripMenuItem";
            this.importImageToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.importImageToolStripMenuItem.Text = "Import image...";
            // 
            // saveImageAsToolStripMenuItem
            // 
            this.saveImageAsToolStripMenuItem.Name = "saveImageAsToolStripMenuItem";
            this.saveImageAsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.saveImageAsToolStripMenuItem.Text = "Save image as...";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveImageAsToolStripMenuItem,
            this.importImageToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(131, 48);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(520, 260);
            this.panel3.TabIndex = 563;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.pictureBoxPreview);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(260, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(260, 260);
            this.panel4.TabIndex = 561;
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.pictureBoxPreview.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(256, 224);
            this.pictureBoxPreview.TabIndex = 3;
            this.pictureBoxPreview.TabStop = false;
            this.pictureBoxPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxPreview_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBoxFG);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 260);
            this.panel1.TabIndex = 561;
            // 
            // pictureBoxFG
            // 
            this.pictureBoxFG.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.pictureBoxFG.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBoxFG.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxFG.Name = "pictureBoxFG";
            this.pictureBoxFG.Size = new System.Drawing.Size(256, 256);
            this.pictureBoxFG.TabIndex = 559;
            this.pictureBoxFG.TabStop = false;
            this.pictureBoxFG.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxFG_Paint);
            // 
            // importFGToolStripMenuItem
            // 
            this.importFGToolStripMenuItem.Image = global::LAZYSHELL.Properties.Resources.import_small;
            this.importFGToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.importFGToolStripMenuItem.Name = "importFGToolStripMenuItem";
            this.importFGToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.importFGToolStripMenuItem.Text = "Import Foreground";
            this.importFGToolStripMenuItem.Click += new System.EventHandler(this.importFGToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importFGToolStripMenuItem});
            this.toolStripDropDownButton2.Image = global::LAZYSHELL.Properties.Resources.import_small;
            this.toolStripDropDownButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(26, 22);
            // 
            // openGraphicsSpeakers
            // 
            this.openGraphicsSpeakers.Image = global::LAZYSHELL.Properties.Resources.openGraphics;
            this.openGraphicsSpeakers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openGraphicsSpeakers.Name = "openGraphicsSpeakers";
            this.openGraphicsSpeakers.Size = new System.Drawing.Size(183, 24);
            this.openGraphicsSpeakers.Text = "Mono/Stereo Graphics";
            this.openGraphicsSpeakers.Click += new System.EventHandler(this.openGraphicsSpeakers_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openPalettesFG,
            this.openPalettesBG,
            this.openPaletteSpeakers});
            this.toolStripDropDownButton1.Image = global::LAZYSHELL.Properties.Resources.openPalettes;
            this.toolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(31, 22);
            // 
            // openPalettesFG
            // 
            this.openPalettesFG.Image = global::LAZYSHELL.Properties.Resources.openPalettes;
            this.openPalettesFG.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openPalettesFG.Name = "openPalettesFG";
            this.openPalettesFG.Size = new System.Drawing.Size(176, 24);
            this.openPalettesFG.Text = "Foreground Palette";
            this.openPalettesFG.Click += new System.EventHandler(this.openPalettesFG_Click);
            // 
            // openPalettesBG
            // 
            this.openPalettesBG.Image = global::LAZYSHELL.Properties.Resources.openPalettes;
            this.openPalettesBG.Name = "openPalettesBG";
            this.openPalettesBG.Size = new System.Drawing.Size(176, 24);
            this.openPalettesBG.Text = "Background Palette";
            this.openPalettesBG.Click += new System.EventHandler(this.openPalettesBG_Click);
            // 
            // openPaletteSpeakers
            // 
            this.openPaletteSpeakers.Image = global::LAZYSHELL.Properties.Resources.openPalettes;
            this.openPaletteSpeakers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openPaletteSpeakers.Name = "openPaletteSpeakers";
            this.openPaletteSpeakers.Size = new System.Drawing.Size(176, 24);
            this.openPaletteSpeakers.Text = "Mono/Stereo Palette";
            this.openPaletteSpeakers.Click += new System.EventHandler(this.openPaletteSpeakers_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton3,
            this.toolStripDropDownButton2,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.music});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(520, 25);
            this.toolStrip1.TabIndex = 562;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openGraphicsFG,
            this.openGraphicsSpeakers});
            this.toolStripDropDownButton3.Image = global::LAZYSHELL.Properties.Resources.openGraphics;
            this.toolStripDropDownButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(31, 22);
            // 
            // openGraphicsFG
            // 
            this.openGraphicsFG.Image = ((System.Drawing.Image)(resources.GetObject("openGraphicsFG.Image")));
            this.openGraphicsFG.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openGraphicsFG.Name = "openGraphicsFG";
            this.openGraphicsFG.Size = new System.Drawing.Size(183, 24);
            this.openGraphicsFG.Text = "Foreground Graphics";
            this.openGraphicsFG.Click += new System.EventHandler(this.openGraphicsFG_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(45, 22);
            this.toolStripLabel1.Text = " MUSIC ";
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
            this.music.Size = new System.Drawing.Size(214, 25);
            // 
            // GameSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 285);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "GameSelect";
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFG)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem importImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImageAsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxFG;
        private System.Windows.Forms.ToolStripMenuItem importFGToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem openGraphicsSpeakers;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem openPalettesFG;
        private System.Windows.Forms.ToolStripMenuItem openPalettesBG;
        private System.Windows.Forms.ToolStripMenuItem openPaletteSpeakers;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem openGraphicsFG;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox music;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}