namespace LAZYSHELL
{
    partial class Shops
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
            this.shopDiscounts = new System.Windows.Forms.CheckedListBox();
            this.shopBuyOptions = new System.Windows.Forms.CheckedListBox();
            this.shopItem14 = new System.Windows.Forms.ComboBox();
            this.shopItem13 = new System.Windows.Forms.ComboBox();
            this.shopItem15 = new System.Windows.Forms.ComboBox();
            this.shopItem12 = new System.Windows.Forms.ComboBox();
            this.shopItem11 = new System.Windows.Forms.ComboBox();
            this.shopItem10 = new System.Windows.Forms.ComboBox();
            this.shopItem9 = new System.Windows.Forms.ComboBox();
            this.shopItem8 = new System.Windows.Forms.ComboBox();
            this.shopItem7 = new System.Windows.Forms.ComboBox();
            this.shopItem6 = new System.Windows.Forms.ComboBox();
            this.shopItem5 = new System.Windows.Forms.ComboBox();
            this.shopItem4 = new System.Windows.Forms.ComboBox();
            this.shopItem3 = new System.Windows.Forms.ComboBox();
            this.shopItem2 = new System.Windows.Forms.ComboBox();
            this.shopItem1 = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.shopName = new LAZYSHELL.ToolStripComboBox();
            this.shopLabel = new System.Windows.Forms.ToolStripTextBox();
            this.moveUp = new System.Windows.Forms.Button();
            this.moveDown = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // shopDiscounts
            // 
            this.shopDiscounts.CheckOnClick = true;
            this.shopDiscounts.Items.AddRange(new object[] {
            "6% discount",
            "12% discount",
            "25% discount",
            "50% discount"});
            this.shopDiscounts.Location = new System.Drawing.Point(6, 20);
            this.shopDiscounts.Name = "shopDiscounts";
            this.shopDiscounts.Size = new System.Drawing.Size(173, 68);
            this.shopDiscounts.TabIndex = 0;
            this.shopDiscounts.SelectedIndexChanged += new System.EventHandler(this.shopDiscounts_SelectedIndexChanged);
            // 
            // shopBuyOptions
            // 
            this.shopBuyOptions.CheckOnClick = true;
            this.shopBuyOptions.Items.AddRange(new object[] {
            "Buy w/Frog Coins, only once",
            "Buy w/Frog Coins",
            "Buy only, no selling",
            "Buy only, no selling"});
            this.shopBuyOptions.Location = new System.Drawing.Point(6, 20);
            this.shopBuyOptions.Name = "shopBuyOptions";
            this.shopBuyOptions.Size = new System.Drawing.Size(173, 68);
            this.shopBuyOptions.TabIndex = 0;
            this.shopBuyOptions.SelectedIndexChanged += new System.EventHandler(this.shopBuyOptions_SelectedIndexChanged);
            // 
            // shopItem14
            // 
            this.shopItem14.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.shopItem14.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.shopItem14.DropDownHeight = 317;
            this.shopItem14.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shopItem14.IntegralHeight = false;
            this.shopItem14.ItemHeight = 15;
            this.shopItem14.Location = new System.Drawing.Point(6, 293);
            this.shopItem14.Name = "shopItem14";
            this.shopItem14.Size = new System.Drawing.Size(173, 21);
            this.shopItem14.TabIndex = 13;
            this.shopItem14.Tag = "";
            this.shopItem14.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.shopItem14.SelectedIndexChanged += new System.EventHandler(this.shopItem14_SelectedIndexChanged);
            this.shopItem14.Click += new System.EventHandler(this.shopItem_Click);
            // 
            // shopItem13
            // 
            this.shopItem13.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.shopItem13.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.shopItem13.DropDownHeight = 317;
            this.shopItem13.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shopItem13.IntegralHeight = false;
            this.shopItem13.ItemHeight = 15;
            this.shopItem13.Location = new System.Drawing.Point(6, 272);
            this.shopItem13.Name = "shopItem13";
            this.shopItem13.Size = new System.Drawing.Size(173, 21);
            this.shopItem13.TabIndex = 12;
            this.shopItem13.Tag = "";
            this.shopItem13.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.shopItem13.SelectedIndexChanged += new System.EventHandler(this.shopItem13_SelectedIndexChanged);
            this.shopItem13.Click += new System.EventHandler(this.shopItem_Click);
            // 
            // shopItem15
            // 
            this.shopItem15.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.shopItem15.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.shopItem15.DropDownHeight = 317;
            this.shopItem15.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shopItem15.IntegralHeight = false;
            this.shopItem15.ItemHeight = 15;
            this.shopItem15.Location = new System.Drawing.Point(6, 314);
            this.shopItem15.Name = "shopItem15";
            this.shopItem15.Size = new System.Drawing.Size(173, 21);
            this.shopItem15.TabIndex = 14;
            this.shopItem15.Tag = "";
            this.shopItem15.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.shopItem15.SelectedIndexChanged += new System.EventHandler(this.shopItem15_SelectedIndexChanged);
            this.shopItem15.Click += new System.EventHandler(this.shopItem_Click);
            // 
            // shopItem12
            // 
            this.shopItem12.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.shopItem12.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.shopItem12.DropDownHeight = 317;
            this.shopItem12.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shopItem12.IntegralHeight = false;
            this.shopItem12.ItemHeight = 15;
            this.shopItem12.Location = new System.Drawing.Point(6, 251);
            this.shopItem12.Name = "shopItem12";
            this.shopItem12.Size = new System.Drawing.Size(173, 21);
            this.shopItem12.TabIndex = 11;
            this.shopItem12.Tag = "";
            this.shopItem12.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.shopItem12.SelectedIndexChanged += new System.EventHandler(this.shopItem12_SelectedIndexChanged);
            this.shopItem12.Click += new System.EventHandler(this.shopItem_Click);
            // 
            // shopItem11
            // 
            this.shopItem11.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.shopItem11.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.shopItem11.DropDownHeight = 317;
            this.shopItem11.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shopItem11.IntegralHeight = false;
            this.shopItem11.ItemHeight = 15;
            this.shopItem11.Location = new System.Drawing.Point(6, 230);
            this.shopItem11.Name = "shopItem11";
            this.shopItem11.Size = new System.Drawing.Size(173, 21);
            this.shopItem11.TabIndex = 10;
            this.shopItem11.Tag = "";
            this.shopItem11.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.shopItem11.SelectedIndexChanged += new System.EventHandler(this.shopItem11_SelectedIndexChanged);
            this.shopItem11.Click += new System.EventHandler(this.shopItem_Click);
            // 
            // shopItem10
            // 
            this.shopItem10.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.shopItem10.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.shopItem10.DropDownHeight = 317;
            this.shopItem10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shopItem10.IntegralHeight = false;
            this.shopItem10.ItemHeight = 15;
            this.shopItem10.Location = new System.Drawing.Point(6, 209);
            this.shopItem10.Name = "shopItem10";
            this.shopItem10.Size = new System.Drawing.Size(173, 21);
            this.shopItem10.TabIndex = 9;
            this.shopItem10.Tag = "";
            this.shopItem10.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.shopItem10.SelectedIndexChanged += new System.EventHandler(this.shopItem10_SelectedIndexChanged);
            this.shopItem10.Click += new System.EventHandler(this.shopItem_Click);
            // 
            // shopItem9
            // 
            this.shopItem9.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.shopItem9.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.shopItem9.DropDownHeight = 317;
            this.shopItem9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shopItem9.IntegralHeight = false;
            this.shopItem9.ItemHeight = 15;
            this.shopItem9.Location = new System.Drawing.Point(6, 188);
            this.shopItem9.Name = "shopItem9";
            this.shopItem9.Size = new System.Drawing.Size(173, 21);
            this.shopItem9.TabIndex = 8;
            this.shopItem9.Tag = "";
            this.shopItem9.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.shopItem9.SelectedIndexChanged += new System.EventHandler(this.shopItem9_SelectedIndexChanged);
            this.shopItem9.Click += new System.EventHandler(this.shopItem_Click);
            // 
            // shopItem8
            // 
            this.shopItem8.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.shopItem8.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.shopItem8.DropDownHeight = 317;
            this.shopItem8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shopItem8.IntegralHeight = false;
            this.shopItem8.ItemHeight = 15;
            this.shopItem8.Location = new System.Drawing.Point(6, 167);
            this.shopItem8.Name = "shopItem8";
            this.shopItem8.Size = new System.Drawing.Size(173, 21);
            this.shopItem8.TabIndex = 7;
            this.shopItem8.Tag = "";
            this.shopItem8.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.shopItem8.SelectedIndexChanged += new System.EventHandler(this.shopItem8_SelectedIndexChanged);
            this.shopItem8.Click += new System.EventHandler(this.shopItem_Click);
            // 
            // shopItem7
            // 
            this.shopItem7.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.shopItem7.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.shopItem7.DropDownHeight = 317;
            this.shopItem7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shopItem7.IntegralHeight = false;
            this.shopItem7.ItemHeight = 15;
            this.shopItem7.Location = new System.Drawing.Point(6, 146);
            this.shopItem7.Name = "shopItem7";
            this.shopItem7.Size = new System.Drawing.Size(173, 21);
            this.shopItem7.TabIndex = 6;
            this.shopItem7.Tag = "";
            this.shopItem7.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.shopItem7.SelectedIndexChanged += new System.EventHandler(this.shopItem7_SelectedIndexChanged);
            this.shopItem7.Click += new System.EventHandler(this.shopItem_Click);
            // 
            // shopItem6
            // 
            this.shopItem6.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.shopItem6.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.shopItem6.DropDownHeight = 317;
            this.shopItem6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shopItem6.IntegralHeight = false;
            this.shopItem6.ItemHeight = 15;
            this.shopItem6.Location = new System.Drawing.Point(6, 125);
            this.shopItem6.Name = "shopItem6";
            this.shopItem6.Size = new System.Drawing.Size(173, 21);
            this.shopItem6.TabIndex = 5;
            this.shopItem6.Tag = "";
            this.shopItem6.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.shopItem6.SelectedIndexChanged += new System.EventHandler(this.shopItem6_SelectedIndexChanged);
            this.shopItem6.Click += new System.EventHandler(this.shopItem_Click);
            // 
            // shopItem5
            // 
            this.shopItem5.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.shopItem5.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.shopItem5.DropDownHeight = 317;
            this.shopItem5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shopItem5.IntegralHeight = false;
            this.shopItem5.ItemHeight = 15;
            this.shopItem5.Location = new System.Drawing.Point(6, 104);
            this.shopItem5.Name = "shopItem5";
            this.shopItem5.Size = new System.Drawing.Size(173, 21);
            this.shopItem5.TabIndex = 4;
            this.shopItem5.Tag = "";
            this.shopItem5.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.shopItem5.SelectedIndexChanged += new System.EventHandler(this.shopItem5_SelectedIndexChanged);
            this.shopItem5.Click += new System.EventHandler(this.shopItem_Click);
            // 
            // shopItem4
            // 
            this.shopItem4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.shopItem4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.shopItem4.DropDownHeight = 317;
            this.shopItem4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shopItem4.IntegralHeight = false;
            this.shopItem4.ItemHeight = 15;
            this.shopItem4.Location = new System.Drawing.Point(6, 83);
            this.shopItem4.Name = "shopItem4";
            this.shopItem4.Size = new System.Drawing.Size(173, 21);
            this.shopItem4.TabIndex = 3;
            this.shopItem4.Tag = "";
            this.shopItem4.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.shopItem4.SelectedIndexChanged += new System.EventHandler(this.shopItem4_SelectedIndexChanged);
            this.shopItem4.Click += new System.EventHandler(this.shopItem_Click);
            // 
            // shopItem3
            // 
            this.shopItem3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.shopItem3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.shopItem3.DropDownHeight = 317;
            this.shopItem3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shopItem3.IntegralHeight = false;
            this.shopItem3.ItemHeight = 15;
            this.shopItem3.Location = new System.Drawing.Point(6, 62);
            this.shopItem3.Name = "shopItem3";
            this.shopItem3.Size = new System.Drawing.Size(173, 21);
            this.shopItem3.TabIndex = 2;
            this.shopItem3.Tag = "";
            this.shopItem3.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.shopItem3.SelectedIndexChanged += new System.EventHandler(this.shopItem3_SelectedIndexChanged);
            this.shopItem3.Click += new System.EventHandler(this.shopItem_Click);
            // 
            // shopItem2
            // 
            this.shopItem2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.shopItem2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.shopItem2.DropDownHeight = 317;
            this.shopItem2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shopItem2.IntegralHeight = false;
            this.shopItem2.ItemHeight = 15;
            this.shopItem2.Location = new System.Drawing.Point(6, 41);
            this.shopItem2.Name = "shopItem2";
            this.shopItem2.Size = new System.Drawing.Size(173, 21);
            this.shopItem2.TabIndex = 1;
            this.shopItem2.Tag = "";
            this.shopItem2.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.shopItem2.SelectedIndexChanged += new System.EventHandler(this.shopItem2_SelectedIndexChanged);
            this.shopItem2.Click += new System.EventHandler(this.shopItem_Click);
            // 
            // shopItem1
            // 
            this.shopItem1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.shopItem1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.shopItem1.DropDownHeight = 317;
            this.shopItem1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shopItem1.IntegralHeight = false;
            this.shopItem1.ItemHeight = 15;
            this.shopItem1.Location = new System.Drawing.Point(6, 20);
            this.shopItem1.Name = "shopItem1";
            this.shopItem1.Size = new System.Drawing.Size(173, 21);
            this.shopItem1.TabIndex = 0;
            this.shopItem1.Tag = "";
            this.shopItem1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itemName_DrawItem);
            this.shopItem1.SelectedIndexChanged += new System.EventHandler(this.shopItem1_SelectedIndexChanged);
            this.shopItem1.Click += new System.EventHandler(this.shopItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shopName,
            this.shopLabel});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(191, 45);
            this.toolStrip1.TabIndex = 0;
            // 
            // shopName
            // 
            this.shopName.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.shopName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.shopName.DropDownHeight = 497;
            this.shopName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shopName.DropDownWidth = 250;
            this.shopName.ItemHeight = 15;
            this.shopName.Location = new System.Drawing.Point(0, 1);
            this.shopName.Name = "shopName";
            this.shopName.SelectedIndex = -1;
            this.shopName.SelectedItem = null;
            this.shopName.Size = new System.Drawing.Size(190, 21);
            this.shopName.SelectedIndexChanged += new System.EventHandler(this.shopName_SelectedIndexChanged);
            this.shopName.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.shopName_DrawItem);
            // 
            // shopLabel
            // 
            this.shopLabel.Name = "shopLabel";
            this.shopLabel.Size = new System.Drawing.Size(188, 21);
            this.shopLabel.TextChanged += new System.EventHandler(this.shopLabel_TextChanged);
            // 
            // moveUp
            // 
            this.moveUp.Location = new System.Drawing.Point(3, 393);
            this.moveUp.Name = "moveUp";
            this.moveUp.Size = new System.Drawing.Size(90, 23);
            this.moveUp.TabIndex = 2;
            this.moveUp.Text = "MOVE UP";
            this.moveUp.UseVisualStyleBackColor = true;
            this.moveUp.Click += new System.EventHandler(this.moveUp_Click);
            // 
            // moveDown
            // 
            this.moveDown.Location = new System.Drawing.Point(98, 393);
            this.moveDown.Name = "moveDown";
            this.moveDown.Size = new System.Drawing.Size(90, 23);
            this.moveDown.TabIndex = 3;
            this.moveDown.Text = "MOVE DOWN";
            this.moveDown.UseVisualStyleBackColor = true;
            this.moveDown.Click += new System.EventHandler(this.moveDown_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.shopItem15);
            this.groupBox1.Controls.Add(this.shopItem14);
            this.groupBox1.Controls.Add(this.shopItem13);
            this.groupBox1.Controls.Add(this.shopItem12);
            this.groupBox1.Controls.Add(this.shopItem11);
            this.groupBox1.Controls.Add(this.shopItem10);
            this.groupBox1.Controls.Add(this.shopItem9);
            this.groupBox1.Controls.Add(this.shopItem8);
            this.groupBox1.Controls.Add(this.shopItem7);
            this.groupBox1.Controls.Add(this.shopItem6);
            this.groupBox1.Controls.Add(this.shopItem5);
            this.groupBox1.Controls.Add(this.shopItem4);
            this.groupBox1.Controls.Add(this.shopItem3);
            this.groupBox1.Controls.Add(this.shopItem2);
            this.groupBox1.Controls.Add(this.shopItem1);
            this.groupBox1.Location = new System.Drawing.Point(3, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 341);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shop Items";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.shopBuyOptions);
            this.groupBox2.Location = new System.Drawing.Point(3, 422);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(185, 94);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Shop Options";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.shopDiscounts);
            this.groupBox3.Location = new System.Drawing.Point(3, 522);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(185, 94);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Purchase Discounts";
            // 
            // Shops
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(191, 619);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.moveDown);
            this.Controls.Add(this.moveUp);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Shops";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox shopDiscounts;
        private System.Windows.Forms.CheckedListBox shopBuyOptions;
        private System.Windows.Forms.ComboBox shopItem14;
        private System.Windows.Forms.ComboBox shopItem13;
        private System.Windows.Forms.ComboBox shopItem15;
        private System.Windows.Forms.ComboBox shopItem12;
        private System.Windows.Forms.ComboBox shopItem11;
        private System.Windows.Forms.ComboBox shopItem10;
        private System.Windows.Forms.ComboBox shopItem9;
        private System.Windows.Forms.ComboBox shopItem8;
        private System.Windows.Forms.ComboBox shopItem7;
        private System.Windows.Forms.ComboBox shopItem6;
        private System.Windows.Forms.ComboBox shopItem5;
        private System.Windows.Forms.ComboBox shopItem4;
        private System.Windows.Forms.ComboBox shopItem3;
        private System.Windows.Forms.ComboBox shopItem2;
        private System.Windows.Forms.ComboBox shopItem1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private LAZYSHELL.ToolStripComboBox shopName;
        private System.Windows.Forms.ToolStripTextBox shopLabel;
        private System.Windows.Forms.Button moveUp;
        private System.Windows.Forms.Button moveDown;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}