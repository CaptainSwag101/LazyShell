namespace LazyShell.Menus
{
    partial class MenuTextForm
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
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.textView = new System.Windows.Forms.ToolStripButton();
			this.charactersLeft = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.xCoord = new LazyShell.Controls.NewToolStripNumericUpDown();
			this.textBox = new System.Windows.Forms.RichTextBox();
			this.num = new System.Windows.Forms.NumericUpDown();
			this.name = new System.Windows.Forms.ComboBox();
			this.toolStrip2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.num)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip2
			// 
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textView,
            this.charactersLeft,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.xCoord});
			this.toolStrip2.Location = new System.Drawing.Point(0, 0);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(260, 25);
			this.toolStrip2.TabIndex = 9;
			this.toolStrip2.Text = "toolStrip2";
			// 
			// textView
			// 
			this.textView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.textView.Image = global::LazyShell.Properties.Resources.textView;
			this.textView.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.textView.Name = "textView";
			this.textView.Size = new System.Drawing.Size(23, 22);
			this.textView.Text = "toolStripButton1";
			this.textView.CheckedChanged += new System.EventHandler(this.textView_CheckedChanged);
			// 
			// charactersLeft
			// 
			this.charactersLeft.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.charactersLeft.Name = "charactersLeft";
			this.charactersLeft.Size = new System.Drawing.Size(81, 22);
			this.charactersLeft.Text = "characters left";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(23, 22);
			this.toolStripLabel1.Text = " X: ";
			// 
			// xCoord
			// 
			this.xCoord.AutoSize = false;
			this.xCoord.ContextMenuStrip = null;
			this.xCoord.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.xCoord.Hexadecimal = false;
			this.xCoord.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.xCoord.Location = new System.Drawing.Point(61, 1);
			this.xCoord.Maximum = new decimal(new int[] {
            117,
            0,
            0,
            0});
			this.xCoord.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.xCoord.Name = "menuTextNum";
			this.xCoord.Size = new System.Drawing.Size(50, 22);
			this.xCoord.Text = "0";
			this.xCoord.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.xCoord.ValueChanged += new System.EventHandler(this.xCoord_ValueChanged);
			// 
			// textBox
			// 
			this.textBox.Location = new System.Drawing.Point(0, 49);
			this.textBox.Name = "textBox";
			this.textBox.Size = new System.Drawing.Size(261, 49);
			this.textBox.TabIndex = 7;
			this.textBox.Text = "";
			this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
			// 
			// num
			// 
			this.num.Location = new System.Drawing.Point(211, 28);
			this.num.Maximum = new decimal(new int[] {
            117,
            0,
            0,
            0});
			this.num.Name = "num";
			this.num.Size = new System.Drawing.Size(50, 21);
			this.num.TabIndex = 6;
			this.num.ValueChanged += new System.EventHandler(this.num_ValueChanged);
			// 
			// name
			// 
			this.name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.name.FormattingEnabled = true;
			this.name.Location = new System.Drawing.Point(0, 28);
			this.name.Name = "name";
			this.name.Size = new System.Drawing.Size(211, 21);
			this.name.TabIndex = 4;
			this.name.SelectedIndexChanged += new System.EventHandler(this.name_SelectedIndexChanged);
			// 
			// MenuTextForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(260, 98);
			this.Controls.Add(this.toolStrip2);
			this.Controls.Add(this.textBox);
			this.Controls.Add(this.num);
			this.Controls.Add(this.name);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Location = new System.Drawing.Point(0, 0);
			this.Name = "MenuTextForm";
			this.ShowInTaskbar = false;
			this.Text = "Menu Text";
			this.TopMost = true;
			this.VisibleChanged += new System.EventHandler(this.MenuTextForm_VisibleChanged);
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.num)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton textView;
        private System.Windows.Forms.ToolStripLabel charactersLeft;
        private System.Windows.Forms.RichTextBox textBox;
        private System.Windows.Forms.NumericUpDown num;
        private System.Windows.Forms.ComboBox name;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private Controls.NewToolStripNumericUpDown xCoord;
    }
}