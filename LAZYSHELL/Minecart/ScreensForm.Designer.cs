
namespace LazyShell.Minecart
{
    partial class ScreensForm
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
            this.railColorKey = new System.Windows.Forms.Label();
            this.panelScreens = new LazyShell.Controls.NewPanel();
            this.screensPanel = new System.Windows.Forms.Panel();
            this.picture = new System.Windows.Forms.PictureBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toggleObjects = new LazyShell.Controls.NewToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.screenWidth = new LazyShell.Controls.NewToolStripNumericUpDown();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.screenL1Number = new LazyShell.Controls.NewToolStripNumericUpDown();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.screenL2Number = new LazyShell.Controls.NewToolStripNumericUpDown();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.newScreen = new System.Windows.Forms.ToolStripButton();
            this.deleteScreen = new System.Windows.Forms.ToolStripButton();
            this.duplicateScreen = new System.Windows.Forms.ToolStripButton();
            this.moveScreenBack = new System.Windows.Forms.ToolStripButton();
            this.moveScreenFoward = new System.Windows.Forms.ToolStripButton();
            this.panelScreens.SuspendLayout();
            this.screensPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // railColorKey
            // 
            this.railColorKey.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.railColorKey.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.railColorKey.Location = new System.Drawing.Point(0, 281);
            this.railColorKey.Name = "railColorKey";
            this.railColorKey.Size = new System.Drawing.Size(712, 21);
            this.railColorKey.TabIndex = 3;
            this.railColorKey.Text = "[RAIL COLOR KEY]  GREEN = normal speed | RED = must slow down | BLUE = enter next" +
    " stage | AQUA = unused, same as blue";
            this.railColorKey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.railColorKey.Visible = false;
            // 
            // panelScreens
            // 
            this.panelScreens.Controls.Add(this.screensPanel);
            this.panelScreens.Controls.Add(this.toolStrip2);
            this.panelScreens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelScreens.Location = new System.Drawing.Point(0, 0);
            this.panelScreens.Name = "panelScreens";
            this.panelScreens.Size = new System.Drawing.Size(712, 281);
            this.panelScreens.TabIndex = 1;
            // 
            // screensPanel
            // 
            this.screensPanel.AutoScroll = true;
            this.screensPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.screensPanel.Controls.Add(this.picture);
            this.screensPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screensPanel.Location = new System.Drawing.Point(0, 0);
            this.screensPanel.Name = "screensPanel";
            this.screensPanel.Size = new System.Drawing.Size(712, 256);
            this.screensPanel.TabIndex = 1;
            this.screensPanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.screens_Scroll);
            // 
            // picture
            // 
            this.picture.BackgroundImage = global::LazyShell.Properties.Resources._transparent;
            this.picture.Location = new System.Drawing.Point(0, 0);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(256, 256);
            this.picture.TabIndex = 0;
            this.picture.TabStop = false;
            this.picture.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxScreens_Paint);
            this.picture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxScreens_MouseDown);
            this.picture.MouseEnter += new System.EventHandler(this.pictureBoxScreens_MouseEnter);
            this.picture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxScreens_MouseMove);
            this.picture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxScreens_MouseUp);
            this.picture.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pictureBoxScreens_PreviewKeyDown);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toggleObjects,
            this.toolStripSeparator3,
            this.toolStripLabel2,
            this.screenWidth,
            this.toolStripLabel3,
            this.screenL1Number,
            this.toolStripLabel4,
            this.screenL2Number,
            this.toolStripSeparator4,
            this.newScreen,
            this.deleteScreen,
            this.duplicateScreen,
            this.moveScreenBack,
            this.moveScreenFoward});
            this.toolStrip2.Location = new System.Drawing.Point(0, 256);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(712, 25);
            this.toolStrip2.TabIndex = 0;
            // 
            // toggleObjects
            // 
            this.toggleObjects.CheckOnClick = true;
            this.toggleObjects.Form = null;
            this.toggleObjects.Image = global::LazyShell.Properties.Resources.buttonSSObjects;
            this.toggleObjects.Name = "toggleObjects";
            this.toggleObjects.Size = new System.Drawing.Size(23, 22);
            this.toggleObjects.ToolTipText = "Show/hide objects";
            this.toggleObjects.Click += new System.EventHandler(this.toggleObjects_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(45, 22);
            this.toolStripLabel2.Text = " Width ";
            // 
            // screenWidth
            // 
            this.screenWidth.AutoSize = false;
            this.screenWidth.ContextMenuStrip = null;
            this.screenWidth.Hexadecimal = false;
            this.screenWidth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.screenWidth.Location = new System.Drawing.Point(83, 1);
            this.screenWidth.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.screenWidth.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.screenWidth.Name = "screenWidth";
            this.screenWidth.Size = new System.Drawing.Size(60, 21);
            this.screenWidth.Text = "0";
            this.screenWidth.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.screenWidth.ValueChanged += new System.EventHandler(this.screenWidth_ValueChanged);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(63, 22);
            this.toolStripLabel3.Text = " L1 Screen ";
            // 
            // screenL1Number
            // 
            this.screenL1Number.AutoSize = false;
            this.screenL1Number.ContextMenuStrip = null;
            this.screenL1Number.Hexadecimal = false;
            this.screenL1Number.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.screenL1Number.Location = new System.Drawing.Point(206, 1);
            this.screenL1Number.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.screenL1Number.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.screenL1Number.Name = "screenL1Number";
            this.screenL1Number.Size = new System.Drawing.Size(60, 21);
            this.screenL1Number.Text = "0";
            this.screenL1Number.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.screenL1Number.ValueChanged += new System.EventHandler(this.screenL1Number_ValueChanged);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(63, 22);
            this.toolStripLabel4.Text = " L2 Screen ";
            // 
            // screenL2Number
            // 
            this.screenL2Number.AutoSize = false;
            this.screenL2Number.ContextMenuStrip = null;
            this.screenL2Number.Hexadecimal = false;
            this.screenL2Number.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.screenL2Number.Location = new System.Drawing.Point(329, 1);
            this.screenL2Number.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.screenL2Number.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.screenL2Number.Name = "screenL2Number";
            this.screenL2Number.Size = new System.Drawing.Size(60, 21);
            this.screenL2Number.Text = "0";
            this.screenL2Number.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.screenL2Number.ValueChanged += new System.EventHandler(this.screenL2Number_ValueChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // newScreen
            // 
            this.newScreen.Image = global::LazyShell.Properties.Resources.new_file;
            this.newScreen.Name = "newScreen";
            this.newScreen.Size = new System.Drawing.Size(23, 22);
            this.newScreen.ToolTipText = "New Screen";
            this.newScreen.Click += new System.EventHandler(this.newScreen_Click);
            // 
            // deleteScreen
            // 
            this.deleteScreen.Image = global::LazyShell.Properties.Resources.delete;
            this.deleteScreen.Name = "deleteScreen";
            this.deleteScreen.Size = new System.Drawing.Size(23, 22);
            this.deleteScreen.ToolTipText = "Delete Screen";
            this.deleteScreen.Click += new System.EventHandler(this.deleteScreen_Click);
            // 
            // duplicateScreen
            // 
            this.duplicateScreen.Image = global::LazyShell.Properties.Resources.duplicate;
            this.duplicateScreen.Name = "duplicateScreen";
            this.duplicateScreen.Size = new System.Drawing.Size(23, 22);
            this.duplicateScreen.ToolTipText = "Duplicate Screen";
            this.duplicateScreen.Click += new System.EventHandler(this.duplicateScreen_Click);
            // 
            // moveScreenBack
            // 
            this.moveScreenBack.Image = global::LazyShell.Properties.Resources.back;
            this.moveScreenBack.Name = "moveScreenBack";
            this.moveScreenBack.Size = new System.Drawing.Size(23, 22);
            this.moveScreenBack.ToolTipText = "Move Screen Back";
            this.moveScreenBack.Click += new System.EventHandler(this.moveScreenBack_Click);
            // 
            // moveScreenFoward
            // 
            this.moveScreenFoward.Image = global::LazyShell.Properties.Resources.foward;
            this.moveScreenFoward.Name = "moveScreenFoward";
            this.moveScreenFoward.Size = new System.Drawing.Size(23, 22);
            this.moveScreenFoward.ToolTipText = "Move Screen Forward";
            this.moveScreenFoward.Click += new System.EventHandler(this.moveScreenFoward_Click);
            // 
            // ScreensForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 302);
            this.Controls.Add(this.panelScreens);
            this.Controls.Add(this.railColorKey);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ScreensForm";
            this.Text = "Screens";
            this.panelScreens.ResumeLayout(false);
            this.panelScreens.PerformLayout();
            this.screensPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private Controls.NewPanel panelScreens;
        private System.Windows.Forms.Panel screensPanel;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private Controls.NewToolStripNumericUpDown screenWidth;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private Controls.NewToolStripNumericUpDown screenL1Number;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton newScreen;
        private System.Windows.Forms.ToolStripButton deleteScreen;
        private System.Windows.Forms.ToolStripButton duplicateScreen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton moveScreenBack;
        private System.Windows.Forms.ToolStripButton moveScreenFoward;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private Controls.NewToolStripNumericUpDown screenL2Number;
        private Controls.NewToolStripButton toggleObjects;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Label railColorKey;
    }
}