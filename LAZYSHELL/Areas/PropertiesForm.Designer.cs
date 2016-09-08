namespace LazyShell.Areas
{
    partial class PropertiesForm
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
            this.mapNum = new System.Windows.Forms.NumericUpDown();
            this.label33 = new System.Windows.Forms.Label();
            this.spritePartition = new System.Windows.Forms.NumericUpDown();
            this.label32 = new System.Windows.Forms.Label();
            this.prioritySetNum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.startMusic = new System.Windows.Forms.ComboBox();
            this.banner = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.startEvent = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.mapName = new System.Windows.Forms.ComboBox();
            this.headerLabel1 = new LazyShell.Controls.HeaderLabel();
            this.headerLabel2 = new LazyShell.Controls.HeaderLabel();
            ((System.ComponentModel.ISupportInitialize)(this.mapNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spritePartition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prioritySetNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startEvent)).BeginInit();
            this.SuspendLayout();
            // 
            // mapNum
            // 
            this.mapNum.Location = new System.Drawing.Point(86, 21);
            this.mapNum.Maximum = new decimal(new int[] {
            155,
            0,
            0,
            0});
            this.mapNum.Name = "mapNum";
            this.mapNum.Size = new System.Drawing.Size(48, 21);
            this.mapNum.TabIndex = 3;
            this.mapNum.ValueChanged += new System.EventHandler(this.mapNum_ValueChanged);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(2, 23);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(53, 13);
            this.label33.TabIndex = 2;
            this.label33.Text = "Area Map";
            // 
            // spritePartition
            // 
            this.spritePartition.Location = new System.Drawing.Point(86, 63);
            this.spritePartition.Maximum = new decimal(new int[] {
            119,
            0,
            0,
            0});
            this.spritePartition.Name = "spritePartition";
            this.spritePartition.Size = new System.Drawing.Size(48, 21);
            this.spritePartition.TabIndex = 19;
            this.spritePartition.ValueChanged += new System.EventHandler(this.spritePartition_ValueChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(2, 44);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(60, 13);
            this.label32.TabIndex = 16;
            this.label32.Text = "Priority Set";
            // 
            // prioritySetNum
            // 
            this.prioritySetNum.Location = new System.Drawing.Point(86, 42);
            this.prioritySetNum.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.prioritySetNum.Name = "prioritySetNum";
            this.prioritySetNum.Size = new System.Drawing.Size(48, 21);
            this.prioritySetNum.TabIndex = 17;
            this.prioritySetNum.ValueChanged += new System.EventHandler(this.prioritySetNum_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Music";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(2, 149);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(41, 13);
            this.label53.TabIndex = 23;
            this.label53.Text = "Banner";
            // 
            // startMusic
            // 
            this.startMusic.BackColor = System.Drawing.SystemColors.Window;
            this.startMusic.DropDownHeight = 301;
            this.startMusic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startMusic.DropDownWidth = 250;
            this.startMusic.IntegralHeight = false;
            this.startMusic.Location = new System.Drawing.Point(86, 125);
            this.startMusic.Name = "startMusic";
            this.startMusic.Size = new System.Drawing.Size(173, 21);
            this.startMusic.TabIndex = 24;
            this.startMusic.SelectedIndexChanged += new System.EventHandler(this.startMusic_SelectedIndexChanged);
            // 
            // banner
            // 
            this.banner.BackColor = System.Drawing.SystemColors.Window;
            this.banner.DropDownHeight = 301;
            this.banner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.banner.DropDownWidth = 250;
            this.banner.IntegralHeight = false;
            this.banner.Location = new System.Drawing.Point(86, 146);
            this.banner.Name = "banner";
            this.banner.Size = new System.Drawing.Size(173, 21);
            this.banner.TabIndex = 25;
            this.banner.SelectedIndexChanged += new System.EventHandler(this.banner_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Start Event";
            // 
            // startEvent
            // 
            this.startEvent.Location = new System.Drawing.Point(86, 104);
            this.startEvent.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.startEvent.Name = "startEvent";
            this.startEvent.Size = new System.Drawing.Size(71, 21);
            this.startEvent.TabIndex = 21;
            this.startEvent.ValueChanged += new System.EventHandler(this.startEvent_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Sprite Partition";
            // 
            // mapName
            // 
            this.mapName.BackColor = System.Drawing.SystemColors.Window;
            this.mapName.DropDownHeight = 301;
            this.mapName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapName.DropDownWidth = 250;
            this.mapName.IntegralHeight = false;
            this.mapName.Location = new System.Drawing.Point(134, 20);
            this.mapName.Name = "mapName";
            this.mapName.Size = new System.Drawing.Size(125, 21);
            this.mapName.TabIndex = 24;
            this.mapName.SelectedIndexChanged += new System.EventHandler(this.mapName_SelectedIndexChanged);
            // 
            // headerLabel1
            // 
            this.headerLabel1.Location = new System.Drawing.Point(-1, 3);
            this.headerLabel1.Name = "headerLabel1";
            this.headerLabel1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel1.Size = new System.Drawing.Size(263, 14);
            this.headerLabel1.TabIndex = 28;
            this.headerLabel1.Text = "Map Settings";
            // 
            // headerLabel2
            // 
            this.headerLabel2.Location = new System.Drawing.Point(-1, 87);
            this.headerLabel2.Name = "headerLabel2";
            this.headerLabel2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel2.Size = new System.Drawing.Size(263, 14);
            this.headerLabel2.TabIndex = 28;
            this.headerLabel2.Text = "Entrance Settings";
            // 
            // PropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 170);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.startEvent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.headerLabel2);
            this.Controls.Add(this.banner);
            this.Controls.Add(this.headerLabel1);
            this.Controls.Add(this.label53);
            this.Controls.Add(this.mapNum);
            this.Controls.Add(this.startMusic);
            this.Controls.Add(this.prioritySetNum);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.mapName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.spritePartition);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "PropertiesForm";
            this.Text = "Area Properties";
            ((System.ComponentModel.ISupportInitialize)(this.mapNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spritePartition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prioritySetNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startEvent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown mapNum;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.NumericUpDown spritePartition;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.NumericUpDown prioritySetNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.ComboBox startMusic;
        private System.Windows.Forms.ComboBox banner;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown startEvent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox mapName;
        private Controls.HeaderLabel headerLabel1;
        private Controls.HeaderLabel headerLabel2;
    }
}