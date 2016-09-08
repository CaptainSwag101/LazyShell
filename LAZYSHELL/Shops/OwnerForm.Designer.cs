
namespace LazyShell.Shops
{
    partial class OwnerForm
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
			this.buyOptions = new System.Windows.Forms.CheckedListBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.name = new LazyShell.Controls.NewToolStripComboBox();
			this.shopItemsPanel = new System.Windows.Forms.Panel();
			this.shopItems = new System.Windows.Forms.ListBox();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.moveUp = new System.Windows.Forms.ToolStripButton();
			this.moveDown = new System.Windows.Forms.ToolStripButton();
			this.shopItemNum = new System.Windows.Forms.NumericUpDown();
			this.shopItemName = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.discount = new System.Windows.Forms.ComboBox();
			this.toolStrip3 = new System.Windows.Forms.ToolStrip();
			this.save = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.import = new System.Windows.Forms.ToolStripButton();
			this.export = new System.Windows.Forms.ToolStripButton();
			this.reset = new System.Windows.Forms.ToolStripButton();
			this.clear = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.helpTips = new System.Windows.Forms.ToolStripButton();
			this.headerLabel1 = new LazyShell.Controls.HeaderLabel();
			this.headerLabel2 = new LazyShell.Controls.HeaderLabel();
			this.toolStrip1.SuspendLayout();
			this.shopItemsPanel.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.shopItemNum)).BeginInit();
			this.toolStrip3.SuspendLayout();
			this.SuspendLayout();
			// 
			// buyOptions
			// 
			this.buyOptions.CheckOnClick = true;
			this.buyOptions.Items.AddRange(new object[] {
            "Buy w/Frog Coins, only once",
            "Buy w/Frog Coins",
            "Buy only, no selling",
            "Buy only, no selling"});
			this.buyOptions.Location = new System.Drawing.Point(3, 395);
			this.buyOptions.Name = "buyOptions";
			this.buyOptions.Size = new System.Drawing.Size(185, 68);
			this.buyOptions.TabIndex = 0;
			this.buyOptions.SelectedIndexChanged += new System.EventHandler(this.buyOptions_SelectedIndexChanged);
			// 
			// toolStrip1
			// 
			this.toolStrip1.CanOverflow = false;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.name});
			this.toolStrip1.Location = new System.Drawing.Point(0, 25);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(191, 26);
			this.toolStrip1.TabIndex = 0;
			// 
			// name
			// 
			this.name.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.name.ContextMenuStrip = null;
			this.name.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.name.DropDownHeight = 497;
			this.name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.name.DropDownWidth = 250;
			this.name.ItemHeight = 15;
			this.name.Location = new System.Drawing.Point(9, 2);
			this.name.Name = "name";
			this.name.SelectedIndex = -1;
			this.name.SelectedItem = null;
			this.name.Size = new System.Drawing.Size(180, 23);
			this.name.SelectedIndexChanged += new System.EventHandler(this.shopName_SelectedIndexChanged);
			this.name.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.shopName_DrawItem);
			// 
			// shopItemsPanel
			// 
			this.shopItemsPanel.Controls.Add(this.shopItems);
			this.shopItemsPanel.Controls.Add(this.toolStrip2);
			this.shopItemsPanel.Controls.Add(this.shopItemNum);
			this.shopItemsPanel.Controls.Add(this.shopItemName);
			this.shopItemsPanel.Location = new System.Drawing.Point(3, 68);
			this.shopItemsPanel.Name = "shopItemsPanel";
			this.shopItemsPanel.Size = new System.Drawing.Size(185, 280);
			this.shopItemsPanel.TabIndex = 1;
			// 
			// shopItems
			// 
			this.shopItems.Dock = System.Windows.Forms.DockStyle.Top;
			this.shopItems.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.shopItems.FormattingEnabled = true;
			this.shopItems.ItemHeight = 15;
			this.shopItems.Location = new System.Drawing.Point(0, 25);
			this.shopItems.Name = "shopItems";
			this.shopItems.Size = new System.Drawing.Size(185, 229);
			this.shopItems.TabIndex = 0;
			this.shopItems.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.shopItems_DrawItem);
			this.shopItems.SelectedIndexChanged += new System.EventHandler(this.shopItems_SelectedIndexChanged);
			// 
			// toolStrip2
			// 
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveUp,
            this.moveDown});
			this.toolStrip2.Location = new System.Drawing.Point(0, 0);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(185, 25);
			this.toolStrip2.TabIndex = 3;
			this.toolStrip2.Text = "toolStrip2";
			// 
			// moveUp
			// 
			this.moveUp.Image = global::LazyShell.Properties.Resources.moveup;
			this.moveUp.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.moveUp.Name = "moveUp";
			this.moveUp.Size = new System.Drawing.Size(23, 22);
			this.moveUp.ToolTipText = "Move item up";
			this.moveUp.Click += new System.EventHandler(this.moveUp_Click);
			// 
			// moveDown
			// 
			this.moveDown.Image = global::LazyShell.Properties.Resources.movedown;
			this.moveDown.Name = "moveDown";
			this.moveDown.Size = new System.Drawing.Size(23, 22);
			this.moveDown.ToolTipText = "Move item down";
			this.moveDown.Click += new System.EventHandler(this.moveDown_Click);
			// 
			// shopItemNum
			// 
			this.shopItemNum.Location = new System.Drawing.Point(131, 256);
			this.shopItemNum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.shopItemNum.Name = "shopItemNum";
			this.shopItemNum.Size = new System.Drawing.Size(51, 21);
			this.shopItemNum.TabIndex = 2;
			this.shopItemNum.ValueChanged += new System.EventHandler(this.shopItemNum_ValueChanged);
			// 
			// shopItemName
			// 
			this.shopItemName.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.shopItemName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.shopItemName.DropDownHeight = 317;
			this.shopItemName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.shopItemName.DropDownWidth = 150;
			this.shopItemName.IntegralHeight = false;
			this.shopItemName.ItemHeight = 15;
			this.shopItemName.Items.AddRange(new object[] {
            "full price",
            "6% off",
            "12% off",
            "18% off",
            "25% off",
            "31% off",
            "37% off",
            "43% off",
            "50% off",
            "56% off",
            "62% off",
            "68% off",
            "75% off",
            "81% off",
            "87% off",
            "93% off"});
			this.shopItemName.Location = new System.Drawing.Point(3, 256);
			this.shopItemName.Name = "shopItemName";
			this.shopItemName.Size = new System.Drawing.Size(128, 21);
			this.shopItemName.TabIndex = 1;
			this.shopItemName.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.shopItemName_DrawItem);
			this.shopItemName.SelectedIndexChanged += new System.EventHandler(this.shopItemName_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 371);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Item discount";
			// 
			// discount
			// 
			this.discount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.discount.FormattingEnabled = true;
			this.discount.Items.AddRange(new object[] {
            "full price",
            "6% off",
            "12% off",
            "18% off",
            "25% off",
            "31% off",
            "37% off",
            "43% off",
            "50% off",
            "56% off",
            "62% off",
            "68% off",
            "75% off",
            "81% off",
            "87% off",
            "93% off"});
			this.discount.Location = new System.Drawing.Point(81, 368);
			this.discount.Name = "discount";
			this.discount.Size = new System.Drawing.Size(107, 21);
			this.discount.TabIndex = 1;
			// 
			// toolStrip3
			// 
			this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save,
            this.toolStripSeparator1,
            this.import,
            this.export,
            this.reset,
            this.clear,
            this.toolStripSeparator2,
            this.helpTips});
			this.toolStrip3.Location = new System.Drawing.Point(0, 0);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.Size = new System.Drawing.Size(191, 25);
			this.toolStrip3.TabIndex = 10;
			this.toolStrip3.Text = "toolStrip3";
			// 
			// save
			// 
			this.save.Image = global::LazyShell.Properties.Resources.save;
			this.save.Name = "save";
			this.save.Size = new System.Drawing.Size(23, 22);
			this.save.ToolTipText = "Save";
			this.save.Click += new System.EventHandler(this.save_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// import
			// 
			this.import.Image = global::LazyShell.Properties.Resources.importData;
			this.import.Name = "import";
			this.import.Size = new System.Drawing.Size(23, 22);
			this.import.ToolTipText = "Import attack";
			this.import.Click += new System.EventHandler(this.import_Click);
			// 
			// export
			// 
			this.export.Image = global::LazyShell.Properties.Resources.exportData;
			this.export.Name = "export";
			this.export.Size = new System.Drawing.Size(23, 22);
			this.export.ToolTipText = "Export attack";
			this.export.Click += new System.EventHandler(this.export_Click);
			// 
			// reset
			// 
			this.reset.Image = global::LazyShell.Properties.Resources.reset;
			this.reset.Name = "reset";
			this.reset.Size = new System.Drawing.Size(23, 22);
			this.reset.ToolTipText = "Reset attack";
			this.reset.Click += new System.EventHandler(this.reset_Click);
			// 
			// clear
			// 
			this.clear.Image = global::LazyShell.Properties.Resources.clear;
			this.clear.Name = "clear";
			this.clear.Size = new System.Drawing.Size(23, 22);
			this.clear.ToolTipText = "Clear";
			this.clear.Click += new System.EventHandler(this.clear_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// helpTips
			// 
			this.helpTips.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.helpTips.Image = global::LazyShell.Properties.Resources.about;
			this.helpTips.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.helpTips.Name = "helpTips";
			this.helpTips.Size = new System.Drawing.Size(23, 22);
			this.helpTips.ToolTipText = "Show/hide help tips label";
			// 
			// headerLabel1
			// 
			this.headerLabel1.Location = new System.Drawing.Point(0, 351);
			this.headerLabel1.Name = "headerLabel1";
			this.headerLabel1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.headerLabel1.Size = new System.Drawing.Size(191, 14);
			this.headerLabel1.TabIndex = 18;
			this.headerLabel1.Text = "Properties";
			// 
			// headerLabel2
			// 
			this.headerLabel2.Location = new System.Drawing.Point(0, 51);
			this.headerLabel2.Name = "headerLabel2";
			this.headerLabel2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.headerLabel2.Size = new System.Drawing.Size(191, 14);
			this.headerLabel2.TabIndex = 19;
			this.headerLabel2.Text = "Shop Items";
			// 
			// OwnerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(191, 466);
			this.Controls.Add(this.headerLabel2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.headerLabel1);
			this.Controls.Add(this.buyOptions);
			this.Controls.Add(this.discount);
			this.Controls.Add(this.shopItemsPanel);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.toolStrip3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Location = new System.Drawing.Point(0, 0);
			this.Name = "OwnerForm";
			this.Text = "Shops - Lazy Shell";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OwnerForm_FormClosing);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.shopItemsPanel.ResumeLayout(false);
			this.shopItemsPanel.PerformLayout();
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.shopItemNum)).EndInit();
			this.toolStrip3.ResumeLayout(false);
			this.toolStrip3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.CheckedListBox buyOptions;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private Controls.NewToolStripComboBox name;
        private System.Windows.Forms.Panel shopItemsPanel;
        private System.Windows.Forms.ComboBox discount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton import;
        private System.Windows.Forms.ToolStripButton export;
        private System.Windows.Forms.ToolStripButton reset;
        private System.Windows.Forms.ToolStripButton clear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton helpTips;
        private System.Windows.Forms.ListBox shopItems;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton moveUp;
        private System.Windows.Forms.ToolStripButton moveDown;
        private System.Windows.Forms.NumericUpDown shopItemNum;
        private System.Windows.Forms.ComboBox shopItemName;
        private Controls.HeaderLabel headerLabel1;
        private Controls.HeaderLabel headerLabel2;
    }
}