namespace LAZYSHELL.Areas
{
    partial class NPCsForm
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
            this.attributes = new System.Windows.Forms.CheckedListBox();
            this.afterBattle = new System.Windows.Forms.ComboBox();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.insert = new System.Windows.Forms.ToolStripButton();
            this.delete = new System.Windows.Forms.ToolStripButton();
            this.copy = new System.Windows.Forms.ToolStripButton();
            this.paste = new System.Windows.Forms.ToolStripButton();
            this.duplicate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.moveUp = new System.Windows.Forms.ToolStripButton();
            this.moveDown = new System.Windows.Forms.ToolStripButton();
            this.f = new System.Windows.Forms.ComboBox();
            this.x = new System.Windows.Forms.NumericUpDown();
            this.label29 = new System.Windows.Forms.Label();
            this.y = new System.Windows.Forms.NumericUpDown();
            this.z_half = new System.Windows.Forms.CheckBox();
            this.label30 = new System.Windows.Forms.Label();
            this.z = new System.Windows.Forms.NumericUpDown();
            this.label56 = new System.Windows.Forms.Label();
            this.engageTrigger = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.engageType = new System.Windows.Forms.ComboBox();
            this.openNPCEditor = new System.Windows.Forms.Button();
            this.visible = new System.Windows.Forms.CheckBox();
            this.npcID = new System.Windows.Forms.NumericUpDown();
            this.action = new System.Windows.Forms.NumericUpDown();
            this.speedPlus = new System.Windows.Forms.NumericUpDown();
            this.mem70A7 = new System.Windows.Forms.NumericUpDown();
            this.eventOrPack = new System.Windows.Forms.NumericUpDown();
            this.labelPropertyA = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.openEventOrPackForm = new System.Windows.Forms.Button();
            this.openEventsForm = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.headerLabel1 = new LAZYSHELL.Controls.HeaderLabel();
            this.headerLabel2 = new LAZYSHELL.Controls.HeaderLabel();
            this.headerLabel3 = new LAZYSHELL.Controls.HeaderLabel();
            this.headerLabel4 = new LAZYSHELL.Controls.HeaderLabel();
            this.headerLabel5 = new LAZYSHELL.Controls.HeaderLabel();
            this.bytesLeft = new System.Windows.Forms.Label();
            this.toolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.action)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedPlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mem70A7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventOrPack)).BeginInit();
            this.SuspendLayout();
            // 
            // attributes
            // 
            this.attributes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.attributes.CheckOnClick = true;
            this.attributes.ColumnWidth = 122;
            this.attributes.Items.AddRange(new object[] {
            "Face on trigger",
            "{B2,b4}",
            "{B2,b5}",
            "Sequence playback",
            "Can\'t float",
            "{B3,b0}",
            "Can\'t walk under",
            "Can\'t pass walls",
            "Can\'t jump through",
            "Can\'t pass NPCs",
            "{B3,b5}",
            "Can\'t walk through",
            "{B3,b7}",
            "Slidable along walls",
            "{B4,b1}"});
            this.attributes.Location = new System.Drawing.Point(3, 397);
            this.attributes.MultiColumn = true;
            this.attributes.Name = "attributes";
            this.attributes.Size = new System.Drawing.Size(256, 132);
            this.attributes.TabIndex = 0;
            this.attributes.SelectedIndexChanged += new System.EventHandler(this.attributes_SelectedIndexChanged);
            // 
            // afterBattle
            // 
            this.afterBattle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.afterBattle.DropDownWidth = 350;
            this.afterBattle.IntegralHeight = false;
            this.afterBattle.Items.AddRange(new object[] {
            "remove permanently (from area memory)",
            "remove temporarily (return on area re-entry)",
            "do not remove at all (disable trigger)",
            "remove permanently (if ran away, can walk through while blinking)",
            "remove temporarily (if ran away, can walk through while blinking)"});
            this.afterBattle.Location = new System.Drawing.Point(128, 253);
            this.afterBattle.Name = "afterBattle";
            this.afterBattle.Size = new System.Drawing.Size(132, 21);
            this.afterBattle.TabIndex = 0;
            this.afterBattle.SelectedIndexChanged += new System.EventHandler(this.afterBattle_SelectedIndexChanged);
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insert,
            this.delete,
            this.copy,
            this.paste,
            this.duplicate,
            this.toolStripSeparator10,
            this.moveUp,
            this.moveDown});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(262, 25);
            this.toolStrip3.TabIndex = 9;
            // 
            // insert
            // 
            this.insert.Image = global::LAZYSHELL.Properties.Resources.npcAdd;
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(23, 22);
            this.insert.ToolTipText = "New NPC";
            this.insert.Click += new System.EventHandler(this.insert_Click);
            // 
            // delete
            // 
            this.delete.Image = global::LAZYSHELL.Properties.Resources.npcRemove;
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(23, 22);
            this.delete.ToolTipText = "Delete NPC";
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // copy
            // 
            this.copy.Image = global::LAZYSHELL.Properties.Resources.copy;
            this.copy.Name = "copy";
            this.copy.Size = new System.Drawing.Size(23, 22);
            this.copy.ToolTipText = "Copy NPC";
            this.copy.Click += new System.EventHandler(this.copy_Click);
            // 
            // paste
            // 
            this.paste.Image = global::LAZYSHELL.Properties.Resources.paste;
            this.paste.Name = "paste";
            this.paste.Size = new System.Drawing.Size(23, 22);
            this.paste.ToolTipText = "Paste NPC";
            this.paste.Click += new System.EventHandler(this.paste_Click);
            // 
            // duplicate
            // 
            this.duplicate.Image = global::LAZYSHELL.Properties.Resources.duplicate;
            this.duplicate.Name = "duplicate";
            this.duplicate.Size = new System.Drawing.Size(23, 22);
            this.duplicate.ToolTipText = "Duplicate NPC";
            this.duplicate.Click += new System.EventHandler(this.duplicate_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // moveUp
            // 
            this.moveUp.Image = global::LAZYSHELL.Properties.Resources.moveup;
            this.moveUp.Name = "moveUp";
            this.moveUp.Size = new System.Drawing.Size(23, 22);
            this.moveUp.ToolTipText = "Move NPC Up";
            this.moveUp.Click += new System.EventHandler(this.moveUp_Click);
            // 
            // moveDown
            // 
            this.moveDown.Image = global::LAZYSHELL.Properties.Resources.movedown;
            this.moveDown.Name = "moveDown";
            this.moveDown.Size = new System.Drawing.Size(23, 22);
            this.moveDown.ToolTipText = "Move NPC Down";
            this.moveDown.Click += new System.EventHandler(this.moveDown_Click);
            // 
            // f
            // 
            this.f.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.f.Items.AddRange(new object[] {
            "E",
            "SE",
            "S",
            "SW",
            "W",
            "NW",
            "N",
            "NE"});
            this.f.Location = new System.Drawing.Point(160, 336);
            this.f.Name = "f";
            this.f.Size = new System.Drawing.Size(50, 21);
            this.f.TabIndex = 7;
            this.f.SelectedIndexChanged += new System.EventHandler(this.f_SelectedIndexChanged);
            // 
            // x
            // 
            this.x.Location = new System.Drawing.Point(160, 294);
            this.x.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(50, 21);
            this.x.TabIndex = 1;
            this.x.ValueChanged += new System.EventHandler(this.x_ValueChanged);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(131, 296);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(23, 13);
            this.label29.TabIndex = 0;
            this.label29.Text = "X,Y";
            // 
            // y
            // 
            this.y.Location = new System.Drawing.Point(210, 294);
            this.y.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.y.Name = "y";
            this.y.Size = new System.Drawing.Size(50, 21);
            this.y.TabIndex = 2;
            this.y.ValueChanged += new System.EventHandler(this.y_ValueChanged);
            // 
            // z_half
            // 
            this.z_half.Appearance = System.Windows.Forms.Appearance.Button;
            this.z_half.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.z_half.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.z_half.ForeColor = System.Drawing.Color.Gray;
            this.z_half.Location = new System.Drawing.Point(211, 315);
            this.z_half.Name = "z_half";
            this.z_half.Size = new System.Drawing.Size(48, 20);
            this.z_half.TabIndex = 5;
            this.z_half.Text = "+1/2";
            this.z_half.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.z_half.UseCompatibleTextRendering = true;
            this.z_half.UseVisualStyleBackColor = false;
            this.z_half.CheckedChanged += new System.EventHandler(this.z_half_CheckedChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(131, 339);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(13, 13);
            this.label30.TabIndex = 6;
            this.label30.Text = "F";
            // 
            // z
            // 
            this.z.Location = new System.Drawing.Point(160, 315);
            this.z.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.z.Name = "z";
            this.z.Size = new System.Drawing.Size(50, 21);
            this.z.TabIndex = 4;
            this.z.ValueChanged += new System.EventHandler(this.z_ValueChanged);
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(131, 318);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(13, 13);
            this.label56.TabIndex = 3;
            this.label56.Text = "Z";
            // 
            // engageTrigger
            // 
            this.engageTrigger.DropDownHeight = 171;
            this.engageTrigger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.engageTrigger.DropDownWidth = 210;
            this.engageTrigger.IntegralHeight = false;
            this.engageTrigger.Items.AddRange(new object[] {
            "(none)",
            "press A from any side",
            "press A from front",
            "do anything EXCEPT touch any side",
            "press A from any side / touch any side",
            "press A from front / touch from front",
            "do anything",
            "hit from below",
            "jump on",
            "jump on / hit from below",
            "touch any side",
            "touch from front",
            "do anything EXCEPT press A"});
            this.engageTrigger.Location = new System.Drawing.Point(178, 63);
            this.engageTrigger.Name = "engageTrigger";
            this.engageTrigger.Size = new System.Drawing.Size(82, 21);
            this.engageTrigger.TabIndex = 3;
            this.engageTrigger.SelectedIndexChanged += new System.EventHandler(this.engageTrigger_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Trigger";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Type";
            // 
            // engageType
            // 
            this.engageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.engageType.Items.AddRange(new object[] {
            "Object",
            "Treasure",
            "Battle"});
            this.engageType.Location = new System.Drawing.Point(178, 42);
            this.engageType.Name = "engageType";
            this.engageType.Size = new System.Drawing.Size(82, 21);
            this.engageType.TabIndex = 1;
            this.engageType.SelectedIndexChanged += new System.EventHandler(this.engageType_SelectedIndexChanged);
            // 
            // openNPCEditor
            // 
            this.openNPCEditor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.openNPCEditor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openNPCEditor.Location = new System.Drawing.Point(128, 105);
            this.openNPCEditor.Name = "openNPCEditor";
            this.openNPCEditor.Size = new System.Drawing.Size(68, 21);
            this.openNPCEditor.TabIndex = 4;
            this.openNPCEditor.Text = "NPC #";
            this.openNPCEditor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.openNPCEditor.UseCompatibleTextRendering = true;
            this.openNPCEditor.UseVisualStyleBackColor = false;
            this.openNPCEditor.Click += new System.EventHandler(this.openNPCEditor_Click);
            // 
            // visible
            // 
            this.visible.Appearance = System.Windows.Forms.Appearance.Button;
            this.visible.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.visible.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.visible.ForeColor = System.Drawing.Color.Gray;
            this.visible.Location = new System.Drawing.Point(128, 215);
            this.visible.Name = "visible";
            this.visible.Size = new System.Drawing.Size(132, 18);
            this.visible.TabIndex = 18;
            this.visible.Text = "SHOW NPC";
            this.visible.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.visible.UseCompatibleTextRendering = true;
            this.visible.UseVisualStyleBackColor = false;
            this.visible.CheckedChanged += new System.EventHandler(this.visible_CheckedChanged);
            // 
            // npcID
            // 
            this.npcID.Location = new System.Drawing.Point(199, 104);
            this.npcID.Maximum = new decimal(new int[] {
            511,
            0,
            0,
            0});
            this.npcID.Name = "npcID";
            this.npcID.Size = new System.Drawing.Size(61, 21);
            this.npcID.TabIndex = 5;
            this.npcID.ValueChanged += new System.EventHandler(this.npcID_ValueChanged);
            // 
            // action
            // 
            this.action.Location = new System.Drawing.Point(199, 146);
            this.action.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.action.Name = "action";
            this.action.Size = new System.Drawing.Size(61, 21);
            this.action.TabIndex = 9;
            this.action.ValueChanged += new System.EventHandler(this.action_ValueChanged);
            // 
            // speedPlus
            // 
            this.speedPlus.Location = new System.Drawing.Point(199, 167);
            this.speedPlus.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.speedPlus.Name = "speedPlus";
            this.speedPlus.Size = new System.Drawing.Size(61, 21);
            this.speedPlus.TabIndex = 11;
            this.speedPlus.ValueChanged += new System.EventHandler(this.speedPlus_ValueChanged);
            // 
            // mem70A7
            // 
            this.mem70A7.Location = new System.Drawing.Point(199, 188);
            this.mem70A7.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.mem70A7.Name = "mem70A7";
            this.mem70A7.Size = new System.Drawing.Size(61, 21);
            this.mem70A7.TabIndex = 13;
            this.mem70A7.ValueChanged += new System.EventHandler(this.mem70A7_ValueChanged);
            // 
            // eventOrPack
            // 
            this.eventOrPack.Location = new System.Drawing.Point(199, 125);
            this.eventOrPack.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.eventOrPack.Name = "eventOrPack";
            this.eventOrPack.Size = new System.Drawing.Size(61, 21);
            this.eventOrPack.TabIndex = 7;
            this.eventOrPack.ValueChanged += new System.EventHandler(this.eventOrPack_ValueChanged);
            // 
            // labelPropertyA
            // 
            this.labelPropertyA.AutoSize = true;
            this.labelPropertyA.Location = new System.Drawing.Point(131, 192);
            this.labelPropertyA.Name = "labelPropertyA";
            this.labelPropertyA.Size = new System.Drawing.Size(63, 13);
            this.labelPropertyA.TabIndex = 12;
            this.labelPropertyA.Text = "Mem $70A7";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(131, 171);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(52, 13);
            this.label54.TabIndex = 10;
            this.label54.Text = "Speed up";
            // 
            // openEventOrPackForm
            // 
            this.openEventOrPackForm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.openEventOrPackForm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openEventOrPackForm.Location = new System.Drawing.Point(128, 125);
            this.openEventOrPackForm.Name = "openEventOrPackForm";
            this.openEventOrPackForm.Size = new System.Drawing.Size(68, 21);
            this.openEventOrPackForm.TabIndex = 6;
            this.openEventOrPackForm.Text = "Event #";
            this.openEventOrPackForm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.openEventOrPackForm.UseCompatibleTextRendering = true;
            this.openEventOrPackForm.UseVisualStyleBackColor = false;
            this.openEventOrPackForm.Click += new System.EventHandler(this.openForm_Click);
            // 
            // openEventsForm
            // 
            this.openEventsForm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.openEventsForm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openEventsForm.Location = new System.Drawing.Point(128, 145);
            this.openEventsForm.Name = "openEventsForm";
            this.openEventsForm.Size = new System.Drawing.Size(68, 21);
            this.openEventsForm.TabIndex = 8;
            this.openEventsForm.Text = "Action #";
            this.openEventsForm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.openEventsForm.UseCompatibleTextRendering = true;
            this.openEventsForm.UseVisualStyleBackColor = false;
            this.openEventsForm.Click += new System.EventHandler(this.openEventsForm_Click);
            // 
            // listBox
            // 
            this.listBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox.FormattingEnabled = true;
            this.listBox.IntegralHeight = false;
            this.listBox.Location = new System.Drawing.Point(0, 25);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(126, 335);
            this.listBox.TabIndex = 19;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // headerLabel1
            // 
            this.headerLabel1.Location = new System.Drawing.Point(126, 25);
            this.headerLabel1.Name = "headerLabel1";
            this.headerLabel1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel1.Size = new System.Drawing.Size(136, 14);
            this.headerLabel1.TabIndex = 20;
            this.headerLabel1.Text = "NPC Type";
            // 
            // headerLabel2
            // 
            this.headerLabel2.Location = new System.Drawing.Point(126, 87);
            this.headerLabel2.Name = "headerLabel2";
            this.headerLabel2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel2.Size = new System.Drawing.Size(136, 14);
            this.headerLabel2.TabIndex = 20;
            this.headerLabel2.Text = "Main Properties";
            // 
            // headerLabel3
            // 
            this.headerLabel3.Location = new System.Drawing.Point(126, 236);
            this.headerLabel3.Name = "headerLabel3";
            this.headerLabel3.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel3.Size = new System.Drawing.Size(136, 14);
            this.headerLabel3.TabIndex = 20;
            this.headerLabel3.Text = "After Battle";
            // 
            // headerLabel4
            // 
            this.headerLabel4.Location = new System.Drawing.Point(126, 277);
            this.headerLabel4.Name = "headerLabel4";
            this.headerLabel4.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel4.Size = new System.Drawing.Size(136, 14);
            this.headerLabel4.TabIndex = 20;
            this.headerLabel4.Text = "Coordinates";
            // 
            // headerLabel5
            // 
            this.headerLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.headerLabel5.Location = new System.Drawing.Point(0, 380);
            this.headerLabel5.Name = "headerLabel5";
            this.headerLabel5.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.headerLabel5.Size = new System.Drawing.Size(262, 14);
            this.headerLabel5.TabIndex = 20;
            this.headerLabel5.Text = "Miscellaneous";
            // 
            // bytesLeft
            // 
            this.bytesLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bytesLeft.BackColor = System.Drawing.Color.Lime;
            this.bytesLeft.Location = new System.Drawing.Point(0, 363);
            this.bytesLeft.Name = "bytesLeft";
            this.bytesLeft.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.bytesLeft.Size = new System.Drawing.Size(262, 14);
            this.bytesLeft.TabIndex = 21;
            this.bytesLeft.Text = "0 bytes left";
            // 
            // NPCsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 532);
            this.Controls.Add(this.bytesLeft);
            this.Controls.Add(this.attributes);
            this.Controls.Add(this.f);
            this.Controls.Add(this.afterBattle);
            this.Controls.Add(this.x);
            this.Controls.Add(this.openNPCEditor);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.y);
            this.Controls.Add(this.visible);
            this.Controls.Add(this.z_half);
            this.Controls.Add(this.openEventsForm);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.npcID);
            this.Controls.Add(this.z);
            this.Controls.Add(this.openEventOrPackForm);
            this.Controls.Add(this.label56);
            this.Controls.Add(this.label54);
            this.Controls.Add(this.action);
            this.Controls.Add(this.labelPropertyA);
            this.Controls.Add(this.eventOrPack);
            this.Controls.Add(this.speedPlus);
            this.Controls.Add(this.mem70A7);
            this.Controls.Add(this.engageTrigger);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.engageType);
            this.Controls.Add(this.headerLabel5);
            this.Controls.Add(this.headerLabel4);
            this.Controls.Add(this.headerLabel3);
            this.Controls.Add(this.headerLabel2);
            this.Controls.Add(this.headerLabel1);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.toolStrip3);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "NPCsForm";
            this.Text = "NPCs";
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npcID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.action)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedPlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mem70A7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventOrPack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox attributes;
        private System.Windows.Forms.ComboBox afterBattle;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton insert;
        private System.Windows.Forms.ToolStripButton delete;
        private System.Windows.Forms.ToolStripButton copy;
        private System.Windows.Forms.ToolStripButton paste;
        private System.Windows.Forms.ToolStripButton duplicate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton moveUp;
        private System.Windows.Forms.ToolStripButton moveDown;
        private System.Windows.Forms.ComboBox f;
        private System.Windows.Forms.NumericUpDown x;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.NumericUpDown y;
        private System.Windows.Forms.CheckBox z_half;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.NumericUpDown z;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Button openNPCEditor;
        private System.Windows.Forms.CheckBox visible;
        private System.Windows.Forms.NumericUpDown npcID;
        private System.Windows.Forms.ComboBox engageTrigger;
        private System.Windows.Forms.NumericUpDown action;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown speedPlus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown mem70A7;
        private System.Windows.Forms.NumericUpDown eventOrPack;
        private System.Windows.Forms.Label labelPropertyA;
        private System.Windows.Forms.ComboBox engageType;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Button openEventOrPackForm;
        private System.Windows.Forms.Button openEventsForm;
        private System.Windows.Forms.ListBox listBox;
        private Controls.HeaderLabel headerLabel1;
        private Controls.HeaderLabel headerLabel2;
        private Controls.HeaderLabel headerLabel3;
        private Controls.HeaderLabel headerLabel4;
        private Controls.HeaderLabel headerLabel5;
        private System.Windows.Forms.Label bytesLeft;
    }
}