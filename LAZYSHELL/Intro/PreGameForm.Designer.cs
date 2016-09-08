
namespace LazyShell.Intro
{
    partial class PreGameForm
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
            this.disableGardenLoad = new System.Windows.Forms.CheckBox();
            this.disableGardenNew = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.importImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.openPalettes = new System.Windows.Forms.ToolStripButton();
            this.openGraphics = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.importImage = new System.Windows.Forms.ToolStripButton();
            this.exportImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toggleBG = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // disableGardenLoad
            // 
            this.disableGardenLoad.AutoSize = true;
            this.disableGardenLoad.Location = new System.Drawing.Point(5, 175);
            this.disableGardenLoad.Name = "disableGardenLoad";
            this.disableGardenLoad.Size = new System.Drawing.Size(178, 17);
            this.disableGardenLoad.TabIndex = 0;
            this.disableGardenLoad.Text = "Disable garden intro (load game)";
            this.disableGardenLoad.UseVisualStyleBackColor = true;
            this.disableGardenLoad.CheckedChanged += new System.EventHandler(this.disableGardenLoad_CheckedChanged);
            // 
            // disableGardenNew
            // 
            this.disableGardenNew.AutoSize = true;
            this.disableGardenNew.Location = new System.Drawing.Point(5, 192);
            this.disableGardenNew.Name = "disableGardenNew";
            this.disableGardenNew.Size = new System.Drawing.Size(178, 17);
            this.disableGardenNew.TabIndex = 0;
            this.disableGardenNew.Text = "Disable garden intro (new game)";
            this.disableGardenNew.UseVisualStyleBackColor = true;
            this.disableGardenNew.CheckedChanged += new System.EventHandler(this.disableGardenNew_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::LazyShell.Properties.Resources._transparent;
            this.pictureBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 144);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importImageToolStripMenuItem,
            this.saveImageAsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(158, 48);
            // 
            // importImageToolStripMenuItem
            // 
            this.importImageToolStripMenuItem.Image = global::LazyShell.Properties.Resources.importImage;
            this.importImageToolStripMenuItem.Name = "importImageToolStripMenuItem";
            this.importImageToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.importImageToolStripMenuItem.Text = "Import image...";
            this.importImageToolStripMenuItem.Click += new System.EventHandler(this.importImage_Click);
            // 
            // saveImageAsToolStripMenuItem
            // 
            this.saveImageAsToolStripMenuItem.Image = global::LazyShell.Properties.Resources.exportImage;
            this.saveImageAsToolStripMenuItem.Name = "saveImageAsToolStripMenuItem";
            this.saveImageAsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.saveImageAsToolStripMenuItem.Text = "Save image as...";
            this.saveImageAsToolStripMenuItem.Click += new System.EventHandler(this.exportImage_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(256, 144);
            this.panel2.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openPalettes,
            this.openGraphics,
            this.toolStripSeparator1,
            this.importImage,
            this.exportImage,
            this.toolStripSeparator2,
            this.toggleBG});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(256, 25);
            this.toolStrip1.TabIndex = 2;
            // 
            // openPalettes
            // 
            this.openPalettes.Image = global::LazyShell.Properties.Resources.openPalettes;
            this.openPalettes.Name = "openPalettes";
            this.openPalettes.Size = new System.Drawing.Size(23, 22);
            this.openPalettes.ToolTipText = "Palette";
            this.openPalettes.Click += new System.EventHandler(this.openPalettes_Click);
            // 
            // openGraphics
            // 
            this.openGraphics.Image = global::LazyShell.Properties.Resources.openGraphics;
            this.openGraphics.Name = "openGraphics";
            this.openGraphics.Size = new System.Drawing.Size(23, 22);
            this.openGraphics.ToolTipText = "Graphics";
            this.openGraphics.Click += new System.EventHandler(this.openGraphics_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // importImage
            // 
            this.importImage.Image = global::LazyShell.Properties.Resources.importImage;
            this.importImage.Name = "importImage";
            this.importImage.Size = new System.Drawing.Size(23, 22);
            this.importImage.ToolTipText = "Import Image";
            this.importImage.Click += new System.EventHandler(this.importImage_Click);
            // 
            // exportImage
            // 
            this.exportImage.Image = global::LazyShell.Properties.Resources.exportImage;
            this.exportImage.Name = "exportImage";
            this.exportImage.Size = new System.Drawing.Size(23, 22);
            this.exportImage.ToolTipText = "Export Image";
            this.exportImage.Click += new System.EventHandler(this.exportImage_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toggleBG
            // 
            this.toggleBG.Checked = true;
            this.toggleBG.CheckOnClick = true;
            this.toggleBG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toggleBG.Name = "toggleBG";
            this.toggleBG.Size = new System.Drawing.Size(26, 22);
            this.toggleBG.Text = "BG";
            this.toggleBG.Click += new System.EventHandler(this.toggleBG_Click);
            // 
            // PreGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 214);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.disableGardenNew);
            this.Controls.Add(this.disableGardenLoad);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "PreGameForm";
            this.Text = "Pre-Game Settings";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.CheckBox disableGardenLoad;
        private System.Windows.Forms.CheckBox disableGardenNew;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton openPalettes;
        private System.Windows.Forms.ToolStripButton openGraphics;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton importImage;
        private System.Windows.Forms.ToolStripButton exportImage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem importImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImageAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toggleBG;
    }
}