namespace LAZYSHELL.Monsters
{
    partial class SpriteForm
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label119 = new System.Windows.Forms.Label();
            this.targetArrowY = new System.Windows.Forms.NumericUpDown();
            this.targetArrowX = new System.Windows.Forms.NumericUpDown();
            this.spriteBehavior = new System.Windows.Forms.ComboBox();
            this.entranceStyle = new System.Windows.Forms.ComboBox();
            this.coinSize = new System.Windows.Forms.ComboBox();
            this.label211 = new System.Windows.Forms.Label();
            this.label191 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.elevation = new System.Windows.Forms.NumericUpDown();
            this.label210 = new System.Windows.Forms.Label();
            this.headerLabel1 = new LAZYSHELL.Controls.HeaderLabel();
            this.headerLabel2 = new LAZYSHELL.Controls.HeaderLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetArrowY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetArrowX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elevation)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackgroundImage = global::LAZYSHELL.Properties.Resources._transparent;
            this.pictureBox.Location = new System.Drawing.Point(3, 20);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(256, 256);
            this.pictureBox.TabIndex = 220;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // label119
            // 
            this.label119.AutoSize = true;
            this.label119.Location = new System.Drawing.Point(6, 282);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(69, 13);
            this.label119.TabIndex = 0;
            this.label119.Text = "Target (X, Y)";
            // 
            // targetArrowY
            // 
            this.targetArrowY.Location = new System.Drawing.Point(194, 280);
            this.targetArrowY.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.targetArrowY.Name = "targetArrowY";
            this.targetArrowY.Size = new System.Drawing.Size(65, 21);
            this.targetArrowY.TabIndex = 2;
            this.targetArrowY.ValueChanged += new System.EventHandler(this.targetArrowY_ValueChanged);
            // 
            // targetArrowX
            // 
            this.targetArrowX.Location = new System.Drawing.Point(129, 280);
            this.targetArrowX.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.targetArrowX.Name = "targetArrowX";
            this.targetArrowX.Size = new System.Drawing.Size(65, 21);
            this.targetArrowX.TabIndex = 1;
            this.targetArrowX.ValueChanged += new System.EventHandler(this.targetArrowX_ValueChanged);
            // 
            // spriteBehavior
            // 
            this.spriteBehavior.DropDownHeight = 236;
            this.spriteBehavior.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.spriteBehavior.DropDownWidth = 200;
            this.spriteBehavior.IntegralHeight = false;
            this.spriteBehavior.Items.AddRange(new object[] {
            "no movement for \"Escape\"",
            "slide backward when hit",
            "Bowser Clone sprite",
            "Mario Clone sprite",
            "no reaction when hit",
            "sprite shadow",
            "floating, sprite shadow",
            "floating",
            "floating, slide backward when hit",
            "floating, slide backward when hit",
            "fade out death, floating",
            "fade out death",
            "fade out death",
            "fade out death, Smithy spell cast",
            "fade out death, no \"Escape\" movement",
            "fade out death, no \"Escape\" transition",
            "(normal)",
            "no reaction when hit"});
            this.spriteBehavior.Location = new System.Drawing.Point(129, 363);
            this.spriteBehavior.Name = "spriteBehavior";
            this.spriteBehavior.Size = new System.Drawing.Size(130, 21);
            this.spriteBehavior.TabIndex = 27;
            this.spriteBehavior.SelectedIndexChanged += new System.EventHandler(this.spriteBehavior_SelectedIndexChanged);
            // 
            // entranceStyle
            // 
            this.entranceStyle.DropDownHeight = 250;
            this.entranceStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.entranceStyle.DropDownWidth = 150;
            this.entranceStyle.IntegralHeight = false;
            this.entranceStyle.Location = new System.Drawing.Point(129, 342);
            this.entranceStyle.Name = "entranceStyle";
            this.entranceStyle.Size = new System.Drawing.Size(130, 21);
            this.entranceStyle.TabIndex = 25;
            this.entranceStyle.SelectedIndexChanged += new System.EventHandler(this.entranceStyle_SelectedIndexChanged);
            // 
            // coinSize
            // 
            this.coinSize.DropDownHeight = 200;
            this.coinSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.coinSize.IntegralHeight = false;
            this.coinSize.Items.AddRange(new object[] {
            "No Coin",
            "Small Coin",
            "Big Coin"});
            this.coinSize.Location = new System.Drawing.Point(129, 321);
            this.coinSize.Name = "coinSize";
            this.coinSize.Size = new System.Drawing.Size(130, 21);
            this.coinSize.TabIndex = 23;
            this.coinSize.SelectedIndexChanged += new System.EventHandler(this.coinSize_SelectedIndexChanged);
            // 
            // label211
            // 
            this.label211.AutoSize = true;
            this.label211.Location = new System.Drawing.Point(6, 366);
            this.label211.Name = "label211";
            this.label211.Size = new System.Drawing.Size(80, 13);
            this.label211.TabIndex = 26;
            this.label211.Text = "Sprite Behavior";
            // 
            // label191
            // 
            this.label191.AutoSize = true;
            this.label191.Location = new System.Drawing.Point(6, 345);
            this.label191.Name = "label191";
            this.label191.Size = new System.Drawing.Size(77, 13);
            this.label191.TabIndex = 24;
            this.label191.Text = "Entrance Style";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(6, 324);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(59, 13);
            this.label26.TabIndex = 22;
            this.label26.Text = "Coin Sprite";
            // 
            // elevation
            // 
            this.elevation.Location = new System.Drawing.Point(129, 384);
            this.elevation.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.elevation.Name = "elevation";
            this.elevation.Size = new System.Drawing.Size(130, 21);
            this.elevation.TabIndex = 29;
            this.elevation.ValueChanged += new System.EventHandler(this.elevation_ValueChanged);
            // 
            // label210
            // 
            this.label210.AutoSize = true;
            this.label210.Location = new System.Drawing.Point(6, 387);
            this.label210.Name = "label210";
            this.label210.Size = new System.Drawing.Size(68, 13);
            this.label210.TabIndex = 28;
            this.label210.Text = "Elevation (Z)";
            // 
            // headerLabel1
            // 
            this.headerLabel1.Location = new System.Drawing.Point(0, 3);
            this.headerLabel1.Name = "headerLabel1";
            this.headerLabel1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel1.Size = new System.Drawing.Size(262, 14);
            this.headerLabel1.TabIndex = 31;
            this.headerLabel1.Text = "Monster Image";
            // 
            // headerLabel2
            // 
            this.headerLabel2.Location = new System.Drawing.Point(0, 304);
            this.headerLabel2.Name = "headerLabel2";
            this.headerLabel2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel2.Size = new System.Drawing.Size(262, 14);
            this.headerLabel2.TabIndex = 31;
            this.headerLabel2.Text = "Sprite Behavior";
            // 
            // SpriteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 408);
            this.Controls.Add(this.coinSize);
            this.Controls.Add(this.label210);
            this.Controls.Add(this.label119);
            this.Controls.Add(this.elevation);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.label211);
            this.Controls.Add(this.targetArrowY);
            this.Controls.Add(this.entranceStyle);
            this.Controls.Add(this.targetArrowX);
            this.Controls.Add(this.label191);
            this.Controls.Add(this.headerLabel2);
            this.Controls.Add(this.spriteBehavior);
            this.Controls.Add(this.headerLabel1);
            this.Controls.Add(this.label26);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "SpriteForm";
            this.Text = "Sprite Settings";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetArrowY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetArrowX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elevation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label119;
        private System.Windows.Forms.NumericUpDown targetArrowY;
        private System.Windows.Forms.NumericUpDown targetArrowX;
        private System.Windows.Forms.ComboBox spriteBehavior;
        private System.Windows.Forms.ComboBox entranceStyle;
        private System.Windows.Forms.ComboBox coinSize;
        private System.Windows.Forms.Label label211;
        private System.Windows.Forms.Label label191;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.NumericUpDown elevation;
        private System.Windows.Forms.Label label210;
        private Controls.HeaderLabel headerLabel1;
        private Controls.HeaderLabel headerLabel2;
    }
}