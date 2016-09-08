namespace LazyShell.Menus
{
    partial class MenuCursorForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.sequenceNum = new System.Windows.Forms.NumericUpDown();
			this.spriteName = new System.Windows.Forms.ComboBox();
			this.name = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.sequenceNum)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Sequence #";
			// 
			// sequenceNum
			// 
			this.sequenceNum.Location = new System.Drawing.Point(77, 44);
			this.sequenceNum.Name = "sequenceNum";
			this.sequenceNum.Size = new System.Drawing.Size(96, 21);
			this.sequenceNum.TabIndex = 6;
			this.sequenceNum.ValueChanged += new System.EventHandler(this.sequenceNum_ValueChanged);
			// 
			// spriteName
			// 
			this.spriteName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.spriteName.FormattingEnabled = true;
			this.spriteName.Location = new System.Drawing.Point(2, 23);
			this.spriteName.Name = "spriteName";
			this.spriteName.Size = new System.Drawing.Size(171, 21);
			this.spriteName.TabIndex = 5;
			this.spriteName.SelectedIndexChanged += new System.EventHandler(this.spriteName_SelectedIndexChanged);
			// 
			// name
			// 
			this.name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.name.FormattingEnabled = true;
			this.name.Items.AddRange(new object[] {
            "Entering menu",
            "Idol in menu",
            "Leaving menu",
            "Enter name",
            "Saved to slot"});
			this.name.Location = new System.Drawing.Point(2, 2);
			this.name.Name = "name";
			this.name.Size = new System.Drawing.Size(171, 21);
			this.name.TabIndex = 4;
			this.name.SelectedIndexChanged += new System.EventHandler(this.name_SelectedIndexChanged);
			// 
			// MenuCursorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(174, 66);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.sequenceNum);
			this.Controls.Add(this.spriteName);
			this.Controls.Add(this.name);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Location = new System.Drawing.Point(0, 0);
			this.Name = "MenuCursorForm";
			this.ShowInTaskbar = false;
			this.Text = "Menu Cursor";
			this.TopMost = true;
			this.VisibleChanged += new System.EventHandler(this.MenuCursorForm_VisibleChanged);
			((System.ComponentModel.ISupportInitialize)(this.sequenceNum)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown sequenceNum;
        private System.Windows.Forms.ComboBox spriteName;
        private System.Windows.Forms.ComboBox name;
    }
}