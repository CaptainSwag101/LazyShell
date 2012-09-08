namespace LAZYSHELL
{
    partial class MiniGames
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiniGames));
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.importTilesetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importTilemapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.exportTilesetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportTilemapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1012, 707);
            this.panel1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save,
            this.toolStripSeparator1,
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1012, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // save
            // 
            this.save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.save.Image = global::LAZYSHELL.Properties.Resources.save_small;
            this.save.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(23, 22);
            this.save.Text = "Save";
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importTilesetsToolStripMenuItem,
            this.importTilemapsToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::LAZYSHELL.Properties.Resources.importBinary;
            this.toolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(27, 22);
            // 
            // importTilesetsToolStripMenuItem
            // 
            this.importTilesetsToolStripMenuItem.Image = global::LAZYSHELL.Properties.Resources.importBinary;
            this.importTilesetsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.importTilesetsToolStripMenuItem.Name = "importTilesetsToolStripMenuItem";
            this.importTilesetsToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.importTilesetsToolStripMenuItem.Text = "Import Tileset(s)...";
            this.importTilesetsToolStripMenuItem.Click += new System.EventHandler(this.importTilesetsToolStripMenuItem_Click);
            // 
            // importTilemapsToolStripMenuItem
            // 
            this.importTilemapsToolStripMenuItem.Image = global::LAZYSHELL.Properties.Resources.importBinary;
            this.importTilemapsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.importTilemapsToolStripMenuItem.Name = "importTilemapsToolStripMenuItem";
            this.importTilemapsToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.importTilemapsToolStripMenuItem.Text = "Import Tilemap(s)...";
            this.importTilemapsToolStripMenuItem.Click += new System.EventHandler(this.importTilemapsToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportTilesetsToolStripMenuItem,
            this.exportTilemapsToolStripMenuItem});
            this.toolStripDropDownButton2.Image = global::LAZYSHELL.Properties.Resources.exportBinary;
            this.toolStripDropDownButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(27, 22);
            // 
            // exportTilesetsToolStripMenuItem
            // 
            this.exportTilesetsToolStripMenuItem.Image = global::LAZYSHELL.Properties.Resources.exportBinary;
            this.exportTilesetsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exportTilesetsToolStripMenuItem.Name = "exportTilesetsToolStripMenuItem";
            this.exportTilesetsToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.exportTilesetsToolStripMenuItem.Text = "Export Tileset(s)...";
            this.exportTilesetsToolStripMenuItem.Click += new System.EventHandler(this.exportTilesetsToolStripMenuItem_Click);
            // 
            // exportTilemapsToolStripMenuItem
            // 
            this.exportTilemapsToolStripMenuItem.Image = global::LAZYSHELL.Properties.Resources.exportBinary;
            this.exportTilemapsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exportTilemapsToolStripMenuItem.Name = "exportTilemapsToolStripMenuItem";
            this.exportTilemapsToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.exportTilemapsToolStripMenuItem.Text = "Export Tilemap(s)...";
            this.exportTilemapsToolStripMenuItem.Click += new System.EventHandler(this.exportTilemapsToolStripMenuItem_Click);
            // 
            // MiniGames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 732);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = global::LAZYSHELL.Properties.Resources.LAZYSHELL_icon;
            this.Location = new System.Drawing.Point(5, 5);
            this.Name = "MiniGames";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MINI GAMES - Lazy Shell";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MiniGames_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem importTilesetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importTilemapsToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem exportTilesetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportTilemapsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}