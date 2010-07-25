namespace LAZYSHELL
{
    partial class Notes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notes));
            this.elementType = new System.Windows.Forms.ComboBox();
            this.elementIndexes = new System.Windows.Forms.ListBox();
            this.indexDescription = new System.Windows.Forms.RichTextBox();
            this.indexLabel = new System.Windows.Forms.TextBox();
            this.buttonMoveUp = new System.Windows.Forms.Button();
            this.buttonMoveDown = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.indexNumber = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelIndexNumber = new System.Windows.Forms.Panel();
            this.panelAddressBit = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.addressBit = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.notesFile = new System.Windows.Forms.TextBox();
            this.generalNotes = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newButton = new System.Windows.Forms.ToolStripButton();
            this.loadButton = new System.Windows.Forms.ToolStripButton();
            this.save = new System.Windows.Forms.ToolStripButton();
            this.saveAs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.numerize = new System.Windows.Forms.ToolStripButton();
            this.alwaysOnTop = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.indexNumber)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panelIndexNumber.SuspendLayout();
            this.panelAddressBit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.address)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressBit)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // elementType
            // 
            this.elementType.DropDownHeight = 306;
            this.elementType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.elementType.FormattingEnabled = true;
            this.elementType.IntegralHeight = false;
            this.elementType.Items.AddRange(new object[] {
            "LEVELS...",
            "  Levels",
            "",
            "SCRIPTS...",
            "  Event Scripts",
            "  Action Scripts",
            "  Battle Scripts",
            "  Memory Bits",
            "",
            "SPRITES...",
            "  Sprites",
            "  Effects",
            "  Dialogues",
            "",
            "STATS...",
            "  Monsters",
            "  Formations",
            "  Packs",
            "  Spells",
            "  Attacks",
            "  Items",
            "  Shops"});
            this.elementType.Location = new System.Drawing.Point(6, 6);
            this.elementType.Name = "elementType";
            this.elementType.Size = new System.Drawing.Size(336, 21);
            this.elementType.TabIndex = 2;
            this.elementType.SelectedIndexChanged += new System.EventHandler(this.elementType_SelectedIndexChanged);
            // 
            // elementIndexes
            // 
            this.elementIndexes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.elementIndexes.FormattingEnabled = true;
            this.elementIndexes.Location = new System.Drawing.Point(0, 0);
            this.elementIndexes.Name = "elementIndexes";
            this.elementIndexes.Size = new System.Drawing.Size(336, 316);
            this.elementIndexes.TabIndex = 1;
            this.elementIndexes.SelectedIndexChanged += new System.EventHandler(this.elementIndexes_SelectedIndexChanged);
            // 
            // indexDescription
            // 
            this.indexDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.indexDescription.Location = new System.Drawing.Point(6, 100);
            this.indexDescription.Name = "indexDescription";
            this.indexDescription.Size = new System.Drawing.Size(336, 321);
            this.indexDescription.TabIndex = 2;
            this.indexDescription.Text = "";
            this.indexDescription.TextChanged += new System.EventHandler(this.indexDescription_TextChanged);
            // 
            // indexLabel
            // 
            this.indexLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.indexLabel.Location = new System.Drawing.Point(6, 60);
            this.indexLabel.Name = "indexLabel";
            this.indexLabel.Size = new System.Drawing.Size(336, 21);
            this.indexLabel.TabIndex = 1;
            this.indexLabel.TextChanged += new System.EventHandler(this.indexLabel_TextChanged);
            // 
            // buttonMoveUp
            // 
            this.buttonMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMoveUp.Location = new System.Drawing.Point(171, 324);
            this.buttonMoveUp.Name = "buttonMoveUp";
            this.buttonMoveUp.Size = new System.Drawing.Size(165, 23);
            this.buttonMoveUp.TabIndex = 4;
            this.buttonMoveUp.Text = "MOVE UP";
            this.buttonMoveUp.UseVisualStyleBackColor = true;
            this.buttonMoveUp.Click += new System.EventHandler(this.buttonMoveUp_Click);
            // 
            // buttonMoveDown
            // 
            this.buttonMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMoveDown.Location = new System.Drawing.Point(171, 348);
            this.buttonMoveDown.Name = "buttonMoveDown";
            this.buttonMoveDown.Size = new System.Drawing.Size(165, 23);
            this.buttonMoveDown.TabIndex = 5;
            this.buttonMoveDown.Text = "MOVE DOWN";
            this.buttonMoveDown.UseVisualStyleBackColor = true;
            this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDown_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDelete.Location = new System.Drawing.Point(0, 348);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(165, 23);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "DELETE";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // indexNumber
            // 
            this.indexNumber.Location = new System.Drawing.Point(84, 0);
            this.indexNumber.Name = "indexNumber";
            this.indexNumber.Size = new System.Drawing.Size(130, 21);
            this.indexNumber.TabIndex = 0;
            this.indexNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.indexNumber.ValueChanged += new System.EventHandler(this.indexNumber_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Index number:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Index Label:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(247, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Index Description:";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAdd.Location = new System.Drawing.Point(0, 324);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(165, 23);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "ADD";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonLoad.Location = new System.Drawing.Point(171, 377);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(165, 23);
            this.buttonLoad.TabIndex = 6;
            this.buttonLoad.Text = "LOAD INTO EDITOR";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.indexLabel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.indexDescription);
            this.groupBox1.Controls.Add(this.panelIndexNumber);
            this.groupBox1.Controls.Add(this.panelAddressBit);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(348, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 427);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Index Properties";
            // 
            // panelIndexNumber
            // 
            this.panelIndexNumber.Controls.Add(this.label1);
            this.panelIndexNumber.Controls.Add(this.indexNumber);
            this.panelIndexNumber.Location = new System.Drawing.Point(6, 20);
            this.panelIndexNumber.Name = "panelIndexNumber";
            this.panelIndexNumber.Size = new System.Drawing.Size(214, 21);
            this.panelIndexNumber.TabIndex = 0;
            // 
            // panelAddressBit
            // 
            this.panelAddressBit.Controls.Add(this.label5);
            this.panelAddressBit.Controls.Add(this.address);
            this.panelAddressBit.Controls.Add(this.label4);
            this.panelAddressBit.Controls.Add(this.addressBit);
            this.panelAddressBit.Location = new System.Drawing.Point(6, 20);
            this.panelAddressBit.Name = "panelAddressBit";
            this.panelAddressBit.Size = new System.Drawing.Size(215, 21);
            this.panelAddressBit.TabIndex = 0;
            this.panelAddressBit.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Address:";
            // 
            // address
            // 
            this.address.Hexadecimal = true;
            this.address.Location = new System.Drawing.Point(56, 0);
            this.address.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.address.Minimum = new decimal(new int[] {
            28672,
            0,
            0,
            0});
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(76, 21);
            this.address.TabIndex = 7;
            this.address.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.address.Value = new decimal(new int[] {
            28672,
            0,
            0,
            0});
            this.address.ValueChanged += new System.EventHandler(this.address_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(138, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Bit:";
            // 
            // addressBit
            // 
            this.addressBit.Location = new System.Drawing.Point(167, 0);
            this.addressBit.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.addressBit.Name = "addressBit";
            this.addressBit.Size = new System.Drawing.Size(47, 21);
            this.addressBit.TabIndex = 7;
            this.addressBit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.addressBit.ValueChanged += new System.EventHandler(this.addressBit_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.elementIndexes);
            this.panel1.Controls.Add(this.buttonLoad);
            this.panel1.Controls.Add(this.buttonDelete);
            this.panel1.Controls.Add(this.buttonMoveUp);
            this.panel1.Controls.Add(this.buttonMoveDown);
            this.panel1.Controls.Add(this.buttonAdd);
            this.panel1.Location = new System.Drawing.Point(6, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 400);
            this.panel1.TabIndex = 3;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Enabled = false;
            this.buttonOK.Location = new System.Drawing.Point(566, 539);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(647, 539);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowse.Location = new System.Drawing.Point(647, 39);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 1;
            this.buttonBrowse.Text = "Browse...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // notesFile
            // 
            this.notesFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.notesFile.Location = new System.Drawing.Point(12, 41);
            this.notesFile.Name = "notesFile";
            this.notesFile.ReadOnly = true;
            this.notesFile.Size = new System.Drawing.Size(629, 21);
            this.notesFile.TabIndex = 0;
            // 
            // generalNotes
            // 
            this.generalNotes.Location = new System.Drawing.Point(6, 6);
            this.generalNotes.Name = "generalNotes";
            this.generalNotes.Size = new System.Drawing.Size(690, 427);
            this.generalNotes.TabIndex = 2;
            this.generalNotes.Text = "";
            this.generalNotes.TextChanged += new System.EventHandler(this.generalNotes_TextChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Enabled = false;
            this.tabControl1.Location = new System.Drawing.Point(12, 68);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(710, 465);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.elementType);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(702, 439);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Database Elements";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.generalNotes);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(702, 439);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "General Notes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newButton,
            this.loadButton,
            this.save,
            this.saveAs,
            this.toolStripSeparator1,
            this.numerize,
            this.alwaysOnTop});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(734, 25);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newButton
            // 
            this.newButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newButton.Image = global::LAZYSHELL.Properties.Resources.new_small;
            this.newButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.newButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(23, 22);
            this.newButton.Text = "New Notes Database";
            this.newButton.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // loadButton
            // 
            this.loadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.loadButton.Image = global::LAZYSHELL.Properties.Resources.open_small;
            this.loadButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.loadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(23, 22);
            this.loadButton.Text = "Open Existing Notes Database";
            this.loadButton.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // save
            // 
            this.save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.save.Enabled = false;
            this.save.Image = global::LAZYSHELL.Properties.Resources.save_small;
            this.save.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(23, 22);
            this.save.Text = "Save";
            this.save.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAs
            // 
            this.saveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveAs.Enabled = false;
            this.saveAs.Image = global::LAZYSHELL.Properties.Resources.saveAs_small;
            this.saveAs.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.saveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveAs.Name = "saveAs";
            this.saveAs.Size = new System.Drawing.Size(23, 22);
            this.saveAs.Text = "Save As";
            this.saveAs.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // numerize
            // 
            this.numerize.CheckOnClick = true;
            this.numerize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.numerize.Image = global::LAZYSHELL.Properties.Resources.numerize;
            this.numerize.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.numerize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.numerize.Name = "numerize";
            this.numerize.Size = new System.Drawing.Size(23, 22);
            this.numerize.Text = "Numbered Indexes";
            this.numerize.Click += new System.EventHandler(this.tagIndexesWithNumbersToolStripMenuItem_Click);
            // 
            // alwaysOnTop
            // 
            this.alwaysOnTop.Checked = true;
            this.alwaysOnTop.CheckOnClick = true;
            this.alwaysOnTop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.alwaysOnTop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.alwaysOnTop.Image = global::LAZYSHELL.Properties.Resources.alwaysOnTop;
            this.alwaysOnTop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.alwaysOnTop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.alwaysOnTop.Name = "alwaysOnTop";
            this.alwaysOnTop.Size = new System.Drawing.Size(23, 22);
            this.alwaysOnTop.Text = "Always On Top";
            this.alwaysOnTop.CheckedChanged += new System.EventHandler(this.alwaysOnTopToolStripMenuItem_CheckedChanged);
            // 
            // Notes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 574);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.notesFile);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Notes";
            this.Text = "NOTES - Lazy Shell";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Notes_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.indexNumber)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelIndexNumber.ResumeLayout(false);
            this.panelIndexNumber.PerformLayout();
            this.panelAddressBit.ResumeLayout(false);
            this.panelAddressBit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.address)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressBit)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox elementType;
        private System.Windows.Forms.ListBox elementIndexes;
        private System.Windows.Forms.RichTextBox indexDescription;
        private System.Windows.Forms.TextBox indexLabel;
        private System.Windows.Forms.Button buttonMoveUp;
        private System.Windows.Forms.Button buttonMoveDown;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.NumericUpDown indexNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.TextBox notesFile;
        private System.Windows.Forms.Panel panelAddressBit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown addressBit;
        private System.Windows.Forms.Panel panelIndexNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown address;
        private System.Windows.Forms.RichTextBox generalNotes;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton loadButton;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.ToolStripButton saveAs;
        private System.Windows.Forms.ToolStripButton newButton;
        private System.Windows.Forms.ToolStripButton numerize;
        private System.Windows.Forms.ToolStripButton alwaysOnTop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}