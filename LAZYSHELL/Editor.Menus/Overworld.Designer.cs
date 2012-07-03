namespace LAZYSHELL
{
    partial class Overworld
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Overworld));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.openPalettesFrame = new System.Windows.Forms.ToolStripMenuItem();
            this.openPalettesBG = new System.Windows.Forms.ToolStripMenuItem();
            this.openPaletteCursors = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.openGraphicsFrame = new System.Windows.Forms.ToolStripMenuItem();
            this.openGraphicsBG = new System.Windows.Forms.ToolStripMenuItem();
            this.openGraphicsCursors = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.importFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importBackgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveImageAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxBG = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBoxFrame = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBG)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton3,
            this.toolStripDropDownButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(564, 25);
            this.toolStrip1.TabIndex = 556;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openPalettesFrame,
            this.openPalettesBG,
            this.openPaletteCursors});
            this.toolStripDropDownButton1.Image = global::LAZYSHELL.Properties.Resources.openPalettes;
            this.toolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(31, 22);
            // 
            // openPalettesFrame
            // 
            this.openPalettesFrame.Image = global::LAZYSHELL.Properties.Resources.openPalettes;
            this.openPalettesFrame.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openPalettesFrame.Name = "openPalettesFrame";
            this.openPalettesFrame.Size = new System.Drawing.Size(170, 24);
            this.openPalettesFrame.Text = "Frame Palette";
            this.openPalettesFrame.Click += new System.EventHandler(this.openPalettesFrame_Click);
            // 
            // openPalettesBG
            // 
            this.openPalettesBG.Image = global::LAZYSHELL.Properties.Resources.openPalettes;
            this.openPalettesBG.Name = "openPalettesBG";
            this.openPalettesBG.Size = new System.Drawing.Size(170, 24);
            this.openPalettesBG.Text = "Background Palette";
            this.openPalettesBG.Click += new System.EventHandler(this.openPalettesBG_Click);
            // 
            // openPaletteCursors
            // 
            this.openPaletteCursors.Image = global::LAZYSHELL.Properties.Resources.openPalettes;
            this.openPaletteCursors.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openPaletteCursors.Name = "openPaletteCursors";
            this.openPaletteCursors.Size = new System.Drawing.Size(170, 24);
            this.openPaletteCursors.Text = "Cursors Palette";
            this.openPaletteCursors.Click += new System.EventHandler(this.openPaletteCursors_Click);
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openGraphicsFrame,
            this.openGraphicsBG,
            this.openGraphicsCursors});
            this.toolStripDropDownButton3.Image = global::LAZYSHELL.Properties.Resources.openGraphics;
            this.toolStripDropDownButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(31, 22);
            // 
            // openGraphicsFrame
            // 
            this.openGraphicsFrame.Image = ((System.Drawing.Image)(resources.GetObject("openGraphicsFrame.Image")));
            this.openGraphicsFrame.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openGraphicsFrame.Name = "openGraphicsFrame";
            this.openGraphicsFrame.Size = new System.Drawing.Size(177, 24);
            this.openGraphicsFrame.Text = "Frame Graphics";
            this.openGraphicsFrame.Click += new System.EventHandler(this.openGraphicsFrame_Click);
            // 
            // openGraphicsBG
            // 
            this.openGraphicsBG.Image = ((System.Drawing.Image)(resources.GetObject("openGraphicsBG.Image")));
            this.openGraphicsBG.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openGraphicsBG.Name = "openGraphicsBG";
            this.openGraphicsBG.Size = new System.Drawing.Size(177, 24);
            this.openGraphicsBG.Text = "Background Graphics";
            this.openGraphicsBG.Click += new System.EventHandler(this.openGraphicsBG_Click);
            // 
            // openGraphicsCursors
            // 
            this.openGraphicsCursors.Image = global::LAZYSHELL.Properties.Resources.openGraphics;
            this.openGraphicsCursors.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openGraphicsCursors.Name = "openGraphicsCursors";
            this.openGraphicsCursors.Size = new System.Drawing.Size(177, 24);
            this.openGraphicsCursors.Text = "Cursor Graphics";
            this.openGraphicsCursors.Click += new System.EventHandler(this.openGraphicsCursors_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importFrameToolStripMenuItem,
            this.importBackgroundToolStripMenuItem});
            this.toolStripDropDownButton2.Image = global::LAZYSHELL.Properties.Resources.import_small;
            this.toolStripDropDownButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(26, 22);
            // 
            // importFrameToolStripMenuItem
            // 
            this.importFrameToolStripMenuItem.Image = global::LAZYSHELL.Properties.Resources.import_small;
            this.importFrameToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.importFrameToolStripMenuItem.Name = "importFrameToolStripMenuItem";
            this.importFrameToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.importFrameToolStripMenuItem.Text = "Import Frame";
            this.importFrameToolStripMenuItem.Click += new System.EventHandler(this.importImageToolStripMenuItem_Click);
            // 
            // importBackgroundToolStripMenuItem
            // 
            this.importBackgroundToolStripMenuItem.Image = global::LAZYSHELL.Properties.Resources.import_small;
            this.importBackgroundToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.importBackgroundToolStripMenuItem.Name = "importBackgroundToolStripMenuItem";
            this.importBackgroundToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.importBackgroundToolStripMenuItem.Text = "Import Background";
            this.importBackgroundToolStripMenuItem.Click += new System.EventHandler(this.importImageToolStripMenuItem_Click);
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
            // saveImageAsToolStripMenuItem
            // 
            this.saveImageAsToolStripMenuItem.Name = "saveImageAsToolStripMenuItem";
            this.saveImageAsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.saveImageAsToolStripMenuItem.Text = "Save image as...";
            this.saveImageAsToolStripMenuItem.Click += new System.EventHandler(this.saveImageAsToolStripMenuItem_Click);
            // 
            // importImageToolStripMenuItem
            // 
            this.importImageToolStripMenuItem.Name = "importImageToolStripMenuItem";
            this.importImageToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.importImageToolStripMenuItem.Text = "Import image...";
            this.importImageToolStripMenuItem.Click += new System.EventHandler(this.importImageToolStripMenuItem_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(564, 260);
            this.panel3.TabIndex = 560;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.pictureBoxPreview);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(304, 0);
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
            this.panel1.Controls.Add(this.pictureBoxBG);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(44, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 260);
            this.panel1.TabIndex = 561;
            // 
            // pictureBoxBG
            // 
            this.pictureBoxBG.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.pictureBoxBG.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBoxBG.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxBG.Name = "pictureBoxBG";
            this.pictureBoxBG.Size = new System.Drawing.Size(256, 256);
            this.pictureBoxBG.TabIndex = 559;
            this.pictureBoxBG.TabStop = false;
            this.pictureBoxBG.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxBG_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.pictureBoxFrame);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(44, 260);
            this.panel2.TabIndex = 560;
            // 
            // pictureBoxFrame
            // 
            this.pictureBoxFrame.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.pictureBoxFrame.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBoxFrame.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxFrame.Name = "pictureBoxFrame";
            this.pictureBoxFrame.Size = new System.Drawing.Size(40, 48);
            this.pictureBoxFrame.TabIndex = 560;
            this.pictureBoxFrame.TabStop = false;
            this.pictureBoxFrame.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxFrame_Paint);
            // 
            // Overworld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 285);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Overworld";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBG)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFrame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveImageAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem openPalettesFrame;
        private System.Windows.Forms.ToolStripMenuItem openPalettesBG;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem openGraphicsFrame;
        private System.Windows.Forms.ToolStripMenuItem openGraphicsBG;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem importFrameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importBackgroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPaletteCursors;
        private System.Windows.Forms.ToolStripMenuItem openGraphicsCursors;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxBG;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBoxFrame;

    }
}