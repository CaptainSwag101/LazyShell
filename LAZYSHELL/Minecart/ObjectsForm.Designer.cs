namespace LazyShell.Minecart
{
    partial class ObjectsForm
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
			this.type = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.y = new System.Windows.Forms.NumericUpDown();
			this.x = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.count = new System.Windows.Forms.NumericUpDown();
			this.listBoxObjects = new System.Windows.Forms.ListBox();
			this.toolStrip3 = new System.Windows.Forms.ToolStrip();
			this.newObject = new System.Windows.Forms.ToolStripButton();
			this.deleteObject = new System.Windows.Forms.ToolStripButton();
			this.duplicateObject = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.moveObjectBack = new System.Windows.Forms.ToolStripButton();
			this.moveObjectForward = new System.Windows.Forms.ToolStripButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.y)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.x)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.count)).BeginInit();
			this.toolStrip3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// type
			// 
			this.type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.type.FormattingEnabled = true;
			this.type.Items.AddRange(new object[] {
            "(none)",
            "coin",
            "mushroom"});
			this.type.Location = new System.Drawing.Point(48, 20);
			this.type.Name = "type";
			this.type.Size = new System.Drawing.Size(99, 21);
			this.type.TabIndex = 12;
			this.type.SelectedIndexChanged += new System.EventHandler(this.objectType_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(5, 22);
			this.label2.Name = "label2";
			this.label2.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
			this.label2.Size = new System.Drawing.Size(33, 16);
			this.label2.TabIndex = 11;
			this.label2.Text = "Type";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(5, 64);
			this.label3.Name = "label3";
			this.label3.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
			this.label3.Size = new System.Drawing.Size(25, 16);
			this.label3.TabIndex = 15;
			this.label3.Text = "X,Y";
			// 
			// y
			// 
			this.y.Location = new System.Drawing.Point(98, 62);
			this.y.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.y.Name = "y";
			this.y.Size = new System.Drawing.Size(49, 21);
			this.y.TabIndex = 17;
			this.y.ValueChanged += new System.EventHandler(this.objectY_ValueChanged);
			// 
			// x
			// 
			this.x.Location = new System.Drawing.Point(48, 62);
			this.x.Maximum = new decimal(new int[] {
            16383,
            0,
            0,
            0});
			this.x.Minimum = new decimal(new int[] {
            256,
            0,
            0,
            0});
			this.x.Name = "x";
			this.x.Size = new System.Drawing.Size(50, 21);
			this.x.TabIndex = 16;
			this.x.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
			this.x.ValueChanged += new System.EventHandler(this.objectX_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 43);
			this.label1.Name = "label1";
			this.label1.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
			this.label1.Size = new System.Drawing.Size(38, 16);
			this.label1.TabIndex = 13;
			this.label1.Text = "Count";
			// 
			// count
			// 
			this.count.Location = new System.Drawing.Point(48, 41);
			this.count.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
			this.count.Name = "count";
			this.count.Size = new System.Drawing.Size(99, 21);
			this.count.TabIndex = 14;
			this.count.ValueChanged += new System.EventHandler(this.rowSize_ValueChanged);
			// 
			// listBoxObjects
			// 
			this.listBoxObjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxObjects.FormattingEnabled = true;
			this.listBoxObjects.IntegralHeight = false;
			this.listBoxObjects.Location = new System.Drawing.Point(0, 25);
			this.listBoxObjects.Name = "listBoxObjects";
			this.listBoxObjects.Size = new System.Drawing.Size(154, 215);
			this.listBoxObjects.TabIndex = 10;
			this.listBoxObjects.SelectedIndexChanged += new System.EventHandler(this.listBoxObjects_SelectedIndexChanged);
			// 
			// toolStrip3
			// 
			this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newObject,
            this.deleteObject,
            this.duplicateObject,
            this.toolStripSeparator8,
            this.moveObjectBack,
            this.moveObjectForward});
			this.toolStrip3.Location = new System.Drawing.Point(0, 0);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.Size = new System.Drawing.Size(154, 25);
			this.toolStrip3.TabIndex = 9;
			// 
			// newObject
			// 
			this.newObject.Image = global::LazyShell.Properties.Resources.new_file;
			this.newObject.Name = "newObject";
			this.newObject.Size = new System.Drawing.Size(23, 22);
			this.newObject.ToolTipText = "New Object";
			this.newObject.Click += new System.EventHandler(this.newObject_Click);
			// 
			// deleteObject
			// 
			this.deleteObject.Image = global::LazyShell.Properties.Resources.delete;
			this.deleteObject.Name = "deleteObject";
			this.deleteObject.Size = new System.Drawing.Size(23, 22);
			this.deleteObject.ToolTipText = "Delete Object";
			this.deleteObject.Click += new System.EventHandler(this.deleteObject_Click);
			// 
			// duplicateObject
			// 
			this.duplicateObject.Image = global::LazyShell.Properties.Resources.duplicate;
			this.duplicateObject.Name = "duplicateObject";
			this.duplicateObject.Size = new System.Drawing.Size(23, 22);
			this.duplicateObject.ToolTipText = "Duplicate Object";
			this.duplicateObject.Click += new System.EventHandler(this.duplicateObject_Click);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
			// 
			// moveObjectBack
			// 
			this.moveObjectBack.Image = global::LazyShell.Properties.Resources.back;
			this.moveObjectBack.Name = "moveObjectBack";
			this.moveObjectBack.Size = new System.Drawing.Size(23, 22);
			this.moveObjectBack.ToolTipText = "Shift Back";
			this.moveObjectBack.Click += new System.EventHandler(this.moveObjectBack_Click);
			// 
			// moveObjectForward
			// 
			this.moveObjectForward.Image = global::LazyShell.Properties.Resources.foward;
			this.moveObjectForward.Name = "moveObjectForward";
			this.moveObjectForward.Size = new System.Drawing.Size(23, 22);
			this.moveObjectForward.ToolTipText = "Shift Foward";
			this.moveObjectForward.Click += new System.EventHandler(this.moveObjectForward_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox1.Controls.Add(this.type);
			this.groupBox1.Controls.Add(this.count);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.x);
			this.groupBox1.Controls.Add(this.y);
			this.groupBox1.Location = new System.Drawing.Point(0, 246);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(153, 89);
			this.groupBox1.TabIndex = 18;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Object Properties";
			// 
			// ObjectsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(154, 336);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.listBoxObjects);
			this.Controls.Add(this.toolStrip3);
			this.Location = new System.Drawing.Point(0, 0);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ObjectsForm";
			this.Text = "Minecart Objects";
			((System.ComponentModel.ISupportInitialize)(this.y)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.x)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.count)).EndInit();
			this.toolStrip3.ResumeLayout(false);
			this.toolStrip3.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox type;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown y;
        private System.Windows.Forms.NumericUpDown x;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown count;
        private System.Windows.Forms.ListBox listBoxObjects;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton newObject;
        private System.Windows.Forms.ToolStripButton deleteObject;
        private System.Windows.Forms.ToolStripButton duplicateObject;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton moveObjectBack;
        private System.Windows.Forms.ToolStripButton moveObjectForward;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}