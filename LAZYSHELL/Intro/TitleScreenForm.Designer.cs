
namespace LAZYSHELL.Intro
{
    partial class TitleScreenForm
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
            this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toggleTilesetL1Form = new LAZYSHELL.Controls.NewToolStripButton();
            this.toggleTilesetL2Form = new LAZYSHELL.Controls.NewToolStripButton();
            this.toggleTilesetL3Form = new LAZYSHELL.Controls.NewToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.openPalettes = new System.Windows.Forms.ToolStripMenuItem();
            this.openSpritePalettes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.openGraphics = new System.Windows.Forms.ToolStripMenuItem();
            this.openSpriteGraphics = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxTitle
            // 
            this.pictureBoxTitle.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.pictureBoxTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxTitle.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxTitle.Name = "pictureBoxTitle";
            this.pictureBoxTitle.Size = new System.Drawing.Size(256, 588);
            this.pictureBoxTitle.TabIndex = 546;
            this.pictureBoxTitle.TabStop = false;
            this.pictureBoxTitle.Paint += new System.Windows.Forms.PaintEventHandler(this.picture_Paint);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toggleTilesetL1Form,
            this.toggleTilesetL2Form,
            this.toggleTilesetL3Form,
            this.toolStripSeparator1,
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(256, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toggleTilesetL1Form
            // 
            this.toggleTilesetL1Form.CheckOnClick = true;
            this.toggleTilesetL1Form.Form = null;
            this.toggleTilesetL1Form.Image = global::LAZYSHELL.Properties.Resources.toggleTilesetL1;
            this.toggleTilesetL1Form.Name = "toggleTilesetL1Form";
            this.toggleTilesetL1Form.Size = new System.Drawing.Size(23, 22);
            this.toggleTilesetL1Form.ToolTipText = "Tileset L1 Window";
            // 
            // toggleTilesetL2Form
            // 
            this.toggleTilesetL2Form.CheckOnClick = true;
            this.toggleTilesetL2Form.Form = null;
            this.toggleTilesetL2Form.Image = global::LAZYSHELL.Properties.Resources.toggleTilesetL2;
            this.toggleTilesetL2Form.Name = "toggleTilesetL2Form";
            this.toggleTilesetL2Form.Size = new System.Drawing.Size(23, 22);
            this.toggleTilesetL2Form.ToolTipText = "Tileset L2 Window";
            // 
            // toggleTilesetL3Form
            // 
            this.toggleTilesetL3Form.CheckOnClick = true;
            this.toggleTilesetL3Form.Form = null;
            this.toggleTilesetL3Form.Image = global::LAZYSHELL.Properties.Resources.toggleTilesetL3;
            this.toggleTilesetL3Form.Name = "toggleTilesetL3Form";
            this.toggleTilesetL3Form.Size = new System.Drawing.Size(23, 22);
            this.toggleTilesetL3Form.ToolTipText = "Tileset L3 Window";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openPalettes,
            this.openSpritePalettes});
            this.toolStripDropDownButton1.Image = global::LAZYSHELL.Properties.Resources.openPalettes;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            // 
            // openPalettes
            // 
            this.openPalettes.Name = "openPalettes";
            this.openPalettes.Size = new System.Drawing.Size(148, 22);
            this.openPalettes.Text = "Title Palettes";
            this.openPalettes.Click += new System.EventHandler(this.openPalettes_Click);
            // 
            // openSpritePalettes
            // 
            this.openSpritePalettes.Name = "openSpritePalettes";
            this.openSpritePalettes.Size = new System.Drawing.Size(148, 22);
            this.openSpritePalettes.Text = "Sprite Palettes";
            this.openSpritePalettes.Click += new System.EventHandler(this.openSpritePalettes_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openGraphics,
            this.openSpriteGraphics});
            this.toolStripDropDownButton2.Image = global::LAZYSHELL.Properties.Resources.openGraphics;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(29, 22);
            // 
            // openGraphics
            // 
            this.openGraphics.Name = "openGraphics";
            this.openGraphics.Size = new System.Drawing.Size(153, 22);
            this.openGraphics.Text = "Title Graphics";
            this.openGraphics.Click += new System.EventHandler(this.openGraphics_Click);
            // 
            // openSpriteGraphics
            // 
            this.openSpriteGraphics.Name = "openSpriteGraphics";
            this.openSpriteGraphics.Size = new System.Drawing.Size(153, 22);
            this.openSpriteGraphics.Text = "Sprite Graphics";
            this.openSpriteGraphics.Click += new System.EventHandler(this.openSpriteGraphics_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBoxTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 588);
            this.panel1.TabIndex = 2;
            // 
            // TitleScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 613);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "TitleScreenForm";
            this.Text = "Title Screen Preview";
            this.TilesetForm = null;
            this.TilesetForms = new LAZYSHELL.TilesetForm[] {
        null,
        null,
        null};
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.PictureBox pictureBoxTitle;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem openPalettes;
        private System.Windows.Forms.ToolStripMenuItem openSpritePalettes;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem openGraphics;
        private System.Windows.Forms.ToolStripMenuItem openSpriteGraphics;
        private System.Windows.Forms.Panel panel1;
        private Controls.NewToolStripButton toggleTilesetL1Form;
        private Controls.NewToolStripButton toggleTilesetL2Form;
        private Controls.NewToolStripButton toggleTilesetL3Form;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}