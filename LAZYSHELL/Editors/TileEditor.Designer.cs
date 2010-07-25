namespace LAZYSHELL
{
    partial class TileEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TileEditor));
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonInvertTile = new System.Windows.Forms.Button();
            this.buttonMirrorTile = new System.Windows.Forms.Button();
            this.panel113 = new System.Windows.Forms.Panel();
            this.label141 = new System.Windows.Forms.Label();
            this.label142 = new System.Windows.Forms.Label();
            this.subtileStatus = new System.Windows.Forms.CheckedListBox();
            this.subtileIndex = new System.Windows.Forms.NumericUpDown();
            this.subtilePalette = new System.Windows.Forms.NumericUpDown();
            this.panel111 = new System.Windows.Forms.Panel();
            this.pictureBoxTile = new System.Windows.Forms.PictureBox();
            this.pictureBoxSubtile = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel113.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subtileIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subtilePalette)).BeginInit();
            this.panel111.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSubtile)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.FlatAppearance.BorderSize = 0;
            this.buttonOK.Location = new System.Drawing.Point(12, 180);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "OK";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.Location = new System.Drawing.Point(93, 180);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.FlatAppearance.BorderSize = 0;
            this.buttonReset.Location = new System.Drawing.Point(174, 180);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 6;
            this.buttonReset.Text = "Reset";
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonInvertTile
            // 
            this.buttonInvertTile.FlatAppearance.BorderSize = 2;
            this.buttonInvertTile.Location = new System.Drawing.Point(174, 40);
            this.buttonInvertTile.Name = "buttonInvertTile";
            this.buttonInvertTile.Size = new System.Drawing.Size(75, 23);
            this.buttonInvertTile.TabIndex = 500;
            this.buttonInvertTile.Text = "Invert";
            this.buttonInvertTile.Click += new System.EventHandler(this.buttonInvertTile_Click);
            // 
            // buttonMirrorTile
            // 
            this.buttonMirrorTile.FlatAppearance.BorderSize = 2;
            this.buttonMirrorTile.Location = new System.Drawing.Point(174, 12);
            this.buttonMirrorTile.Name = "buttonMirrorTile";
            this.buttonMirrorTile.Size = new System.Drawing.Size(75, 23);
            this.buttonMirrorTile.TabIndex = 499;
            this.buttonMirrorTile.Text = "Mirror";
            this.buttonMirrorTile.Click += new System.EventHandler(this.buttonMirrorTile_Click);
            // 
            // panel113
            // 
            this.panel113.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel113.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel113.Controls.Add(this.label141);
            this.panel113.Controls.Add(this.label142);
            this.panel113.Controls.Add(this.subtileStatus);
            this.panel113.Controls.Add(this.subtileIndex);
            this.panel113.Controls.Add(this.subtilePalette);
            this.panel113.Location = new System.Drawing.Point(12, 86);
            this.panel113.Name = "panel113";
            this.panel113.Size = new System.Drawing.Size(142, 88);
            this.panel113.TabIndex = 496;
            // 
            // label141
            // 
            this.label141.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label141.Location = new System.Drawing.Point(0, 0);
            this.label141.Name = "label141";
            this.label141.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label141.Size = new System.Drawing.Size(65, 17);
            this.label141.TabIndex = 442;
            this.label141.Text = "Tile Index";
            // 
            // label142
            // 
            this.label142.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(224)))));
            this.label142.Location = new System.Drawing.Point(0, 18);
            this.label142.Name = "label142";
            this.label142.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.label142.Size = new System.Drawing.Size(65, 17);
            this.label142.TabIndex = 444;
            this.label142.Text = "Palette";
            // 
            // subtileStatus
            // 
            this.subtileStatus.BackColor = System.Drawing.SystemColors.Window;
            this.subtileStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.subtileStatus.CheckOnClick = true;
            this.subtileStatus.ColumnWidth = 60;
            this.subtileStatus.Items.AddRange(new object[] {
            "Priority 1",
            "Mirror",
            "Invert"});
            this.subtileStatus.Location = new System.Drawing.Point(0, 36);
            this.subtileStatus.Name = "subtileStatus";
            this.subtileStatus.Size = new System.Drawing.Size(138, 48);
            this.subtileStatus.TabIndex = 4;
            this.subtileStatus.SelectedIndexChanged += new System.EventHandler(this.tileAttributes_SelectedIndexChanged);
            // 
            // subtileIndex
            // 
            this.subtileIndex.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.subtileIndex.Location = new System.Drawing.Point(66, 0);
            this.subtileIndex.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.subtileIndex.Name = "subtileIndex";
            this.subtileIndex.Size = new System.Drawing.Size(72, 17);
            this.subtileIndex.TabIndex = 2;
            this.subtileIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.subtileIndex.ValueChanged += new System.EventHandler(this.tile8x8Tile_ValueChanged);
            // 
            // subtilePalette
            // 
            this.subtilePalette.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.subtilePalette.Location = new System.Drawing.Point(66, 18);
            this.subtilePalette.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.subtilePalette.Name = "subtilePalette";
            this.subtilePalette.Size = new System.Drawing.Size(72, 17);
            this.subtilePalette.TabIndex = 441;
            this.subtilePalette.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.subtilePalette.ValueChanged += new System.EventHandler(this.tilePalette_ValueChanged);
            // 
            // panel111
            // 
            this.panel111.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel111.Controls.Add(this.pictureBoxTile);
            this.panel111.Location = new System.Drawing.Point(12, 12);
            this.panel111.Name = "panel111";
            this.panel111.Size = new System.Drawing.Size(68, 68);
            this.panel111.TabIndex = 497;
            // 
            // pictureBoxTile
            // 
            this.pictureBoxTile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxTile.BackgroundImage")));
            this.pictureBoxTile.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxTile.Name = "pictureBoxTile";
            this.pictureBoxTile.Size = new System.Drawing.Size(64, 64);
            this.pictureBoxTile.TabIndex = 446;
            this.pictureBoxTile.TabStop = false;
            this.pictureBoxTile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTile_MouseClick);
            this.pictureBoxTile.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxTile_Paint);
            // 
            // pictureBoxSubtile
            // 
            this.pictureBoxSubtile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxSubtile.BackgroundImage")));
            this.pictureBoxSubtile.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxSubtile.Name = "pictureBoxSubtile";
            this.pictureBoxSubtile.Size = new System.Drawing.Size(64, 64);
            this.pictureBoxSubtile.TabIndex = 446;
            this.pictureBoxSubtile.TabStop = false;
            this.pictureBoxSubtile.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxSubtile_Paint);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBoxSubtile);
            this.panel1.Location = new System.Drawing.Point(86, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(68, 68);
            this.panel1.TabIndex = 498;
            // 
            // TileEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 215);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonInvertTile);
            this.Controls.Add(this.buttonMirrorTile);
            this.Controls.Add(this.panel113);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.panel111);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TileEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "TILE EDITOR";
            this.TopMost = true;
            this.panel113.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.subtileIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subtilePalette)).EndInit();
            this.panel111.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSubtile)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel panel111;
        private System.Windows.Forms.PictureBox pictureBoxSubtile;
        private System.Windows.Forms.PictureBox pictureBoxTile;
        private System.Windows.Forms.Panel panel113;
        private System.Windows.Forms.Label label141;
        private System.Windows.Forms.NumericUpDown subtilePalette;
        private System.Windows.Forms.NumericUpDown subtileIndex;
        private System.Windows.Forms.Label label142;
        private System.Windows.Forms.CheckedListBox subtileStatus;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonInvertTile;
        private System.Windows.Forms.Button buttonMirrorTile;
        private System.Windows.Forms.Panel panel1;
    }
}