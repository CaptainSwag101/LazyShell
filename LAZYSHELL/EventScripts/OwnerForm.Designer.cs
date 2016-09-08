namespace LazyShell.EventScripts
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("");
			this.commandTree = new LazyShell.Controls.NewTreeView();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.insert = new System.Windows.Forms.ToolStripButton();
			this.edit = new System.Windows.Forms.ToolStripButton();
			this.copy = new System.Windows.Forms.ToolStripButton();
			this.paste = new System.Windows.Forms.ToolStripButton();
			this.delete = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.moveUp = new System.Windows.Forms.ToolStripButton();
			this.moveDown = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.undo = new System.Windows.Forms.ToolStripButton();
			this.redo = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.expandAll = new System.Windows.Forms.ToolStripButton();
			this.collapseAll = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.toggleByteEditor = new LazyShell.Controls.NewToolStripButton();
			this.eventHexText = new System.Windows.Forms.ToolStripTextBox();
			this.labelBytesLeft = new System.Windows.Forms.ToolStripLabel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.scriptType = new System.Windows.Forms.ToolStripComboBox();
			this.num = new LazyShell.Controls.NewToolStripNumericUpDown();
			this.scriptLabel = new System.Windows.Forms.ToolStripTextBox();
			this.navigateBck = new System.Windows.Forms.ToolStripButton();
			this.navigateFwd = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.searchScripts = new System.Windows.Forms.ToolStripButton();
			this.gotoAddrButton = new System.Windows.Forms.ToolStripButton();
			this.findReferences = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
			this.contextMenuStripGoto = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.goToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip4 = new System.Windows.Forms.ToolStrip();
			this.save = new System.Windows.Forms.ToolStripButton();
			this.helpTips = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.import = new System.Windows.Forms.ToolStripDropDownButton();
			this.importEventScripts = new System.Windows.Forms.ToolStripMenuItem();
			this.importActionScripts = new System.Windows.Forms.ToolStripMenuItem();
			this.export = new System.Windows.Forms.ToolStripDropDownButton();
			this.exportEventScripts = new System.Windows.Forms.ToolStripMenuItem();
			this.exportActionScripts = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.dumpEventScriptText = new System.Windows.Forms.ToolStripMenuItem();
			this.dumpActionScriptText = new System.Windows.Forms.ToolStripMenuItem();
			this.clear = new System.Windows.Forms.ToolStripDropDownButton();
			this.clearEventScripts = new System.Windows.Forms.ToolStripMenuItem();
			this.clearActionScripts = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.baseConvertor = new System.Windows.Forms.ToolStripButton();
			this.openHexEditor = new System.Windows.Forms.ToolStripButton();
			this.autoPointerUpdate = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.openPreviewer = new System.Windows.Forms.ToolStripButton();
			this.toolStrip2.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.contextMenuStripGoto.SuspendLayout();
			this.toolStrip4.SuspendLayout();
			this.SuspendLayout();
			// 
			// commandTree
			// 
			this.commandTree.CheckBoxes = true;
			this.commandTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.commandTree.FullRowSelect = true;
			this.commandTree.HideSelection = false;
			this.commandTree.HotTracking = true;
			treeNode1.Name = "";
			treeNode1.Text = "";
			this.commandTree.LastNode = treeNode1;
			this.commandTree.Location = new System.Drawing.Point(0, 75);
			this.commandTree.Name = "commandTree";
			this.commandTree.Size = new System.Drawing.Size(792, 581);
			this.commandTree.TabIndex = 6;
			this.commandTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.commandTree_AfterCheck);
			this.commandTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.commandTree_AfterSelect);
			this.commandTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.commandTree_NodeMouseClick);
			this.commandTree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.commandTree_KeyDown);
			this.commandTree.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.commandTree_MouseDoubleClick);
			// 
			// toolStrip2
			// 
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insert,
            this.edit,
            this.copy,
            this.paste,
            this.delete,
            this.toolStripSeparator5,
            this.moveUp,
            this.moveDown,
            this.toolStripSeparator8,
            this.undo,
            this.redo,
            this.toolStripSeparator9,
            this.expandAll,
            this.collapseAll,
            this.toolStripSeparator3,
            this.toggleByteEditor,
            this.eventHexText});
			this.toolStrip2.Location = new System.Drawing.Point(0, 50);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(792, 25);
			this.toolStrip2.TabIndex = 7;
			// 
			// insert
			// 
			this.insert.Image = global::LazyShell.Properties.Resources.new_file;
			this.insert.Name = "insert";
			this.insert.Size = new System.Drawing.Size(23, 22);
			this.insert.ToolTipText = "Insert New Command";
			this.insert.Click += new System.EventHandler(this.insert_Click);
			// 
			// edit
			// 
			this.edit.Image = global::LazyShell.Properties.Resources.edit;
			this.edit.Name = "edit";
			this.edit.Size = new System.Drawing.Size(23, 22);
			this.edit.ToolTipText = "Edit Command";
			this.edit.Click += new System.EventHandler(this.edit_Click);
			// 
			// copy
			// 
			this.copy.Image = global::LazyShell.Properties.Resources.copy;
			this.copy.Name = "copy";
			this.copy.Size = new System.Drawing.Size(23, 22);
			this.copy.ToolTipText = "Copy Command (Ctrl+C)";
			this.copy.Click += new System.EventHandler(this.copyCommand_Click);
			// 
			// paste
			// 
			this.paste.Image = global::LazyShell.Properties.Resources.paste;
			this.paste.Name = "paste";
			this.paste.Size = new System.Drawing.Size(23, 22);
			this.paste.ToolTipText = "Paste Command (Ctrl+V)";
			this.paste.Click += new System.EventHandler(this.pasteCommand_Click);
			// 
			// delete
			// 
			this.delete.Image = global::LazyShell.Properties.Resources.delete;
			this.delete.Name = "delete";
			this.delete.Size = new System.Drawing.Size(23, 22);
			this.delete.ToolTipText = "Delete Command (Del)";
			this.delete.Click += new System.EventHandler(this.deleteCommand_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
			// 
			// moveUp
			// 
			this.moveUp.Image = global::LazyShell.Properties.Resources.moveup;
			this.moveUp.Name = "moveUp";
			this.moveUp.Size = new System.Drawing.Size(23, 22);
			this.moveUp.ToolTipText = "Move Command Up (Shift+Up)";
			this.moveUp.Click += new System.EventHandler(this.moveUp_Click);
			// 
			// moveDown
			// 
			this.moveDown.Image = global::LazyShell.Properties.Resources.movedown;
			this.moveDown.Name = "moveDown";
			this.moveDown.Size = new System.Drawing.Size(23, 22);
			this.moveDown.ToolTipText = "Move Command Down (Shift+Down)";
			this.moveDown.Click += new System.EventHandler(this.moveDown_Click);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
			// 
			// undo
			// 
			this.undo.Image = global::LazyShell.Properties.Resources.undo;
			this.undo.Name = "undo";
			this.undo.Size = new System.Drawing.Size(23, 22);
			this.undo.ToolTipText = "Undo (Ctrl+Z)";
			this.undo.Click += new System.EventHandler(this.undo_Click);
			// 
			// redo
			// 
			this.redo.Image = global::LazyShell.Properties.Resources.redo;
			this.redo.Name = "redo";
			this.redo.Size = new System.Drawing.Size(23, 22);
			this.redo.ToolTipText = "Redo (Ctrl+Y)";
			this.redo.Click += new System.EventHandler(this.redo_Click);
			// 
			// toolStripSeparator9
			// 
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
			// 
			// expandAll
			// 
			this.expandAll.Image = global::LazyShell.Properties.Resources.expandAll;
			this.expandAll.Name = "expandAll";
			this.expandAll.Size = new System.Drawing.Size(23, 22);
			this.expandAll.ToolTipText = "Expand Command Tree";
			this.expandAll.Click += new System.EventHandler(this.expandAll_Click);
			// 
			// collapseAll
			// 
			this.collapseAll.Image = global::LazyShell.Properties.Resources.collapseAll;
			this.collapseAll.Name = "collapseAll";
			this.collapseAll.Size = new System.Drawing.Size(23, 22);
			this.collapseAll.ToolTipText = "Collapse Command Tree";
			this.collapseAll.Click += new System.EventHandler(this.collapseAll_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// toggleByteEditor
			// 
			this.toggleByteEditor.CheckOnClick = true;
			this.toggleByteEditor.Form = null;
			this.toggleByteEditor.Image = global::LazyShell.Properties.Resources.hexEditor;
			this.toggleByteEditor.Name = "toggleByteEditor";
			this.toggleByteEditor.Size = new System.Drawing.Size(23, 22);
			this.toggleByteEditor.ToolTipText = "Edit Command Bytes";
			// 
			// eventHexText
			// 
			this.eventHexText.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.eventHexText.Name = "eventHexText";
			this.eventHexText.ReadOnly = true;
			this.eventHexText.Size = new System.Drawing.Size(250, 25);
			// 
			// labelBytesLeft
			// 
			this.labelBytesLeft.Name = "labelBytesLeft";
			this.labelBytesLeft.Size = new System.Drawing.Size(64, 22);
			this.labelBytesLeft.Text = "0 bytes left";
			this.labelBytesLeft.ToolTipText = "bytes left";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scriptType,
            this.num,
            this.scriptLabel,
            this.navigateBck,
            this.navigateFwd,
            this.toolStripSeparator7,
            this.searchScripts,
            this.gotoAddrButton,
            this.findReferences,
            this.toolStripSeparator10,
            this.labelBytesLeft});
			this.toolStrip1.Location = new System.Drawing.Point(0, 25);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(792, 25);
			this.toolStrip1.TabIndex = 5;
			// 
			// scriptType
			// 
			this.scriptType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.scriptType.DropDownWidth = 100;
			this.scriptType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.scriptType.Items.AddRange(new object[] {
            "Event Scripts",
            "Action Scripts"});
			this.scriptType.Name = "scriptType";
			this.scriptType.Size = new System.Drawing.Size(100, 25);
			this.scriptType.SelectedIndexChanged += new System.EventHandler(this.type_SelectedIndexChanged);
			// 
			// num
			// 
			this.num.AutoSize = false;
			this.num.ContextMenuStrip = null;
			this.num.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.num.Hexadecimal = false;
			this.num.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.num.Location = new System.Drawing.Point(111, 1);
			this.num.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.num.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.num.Name = "eventNum";
			this.num.Size = new System.Drawing.Size(55, 22);
			this.num.Text = "0";
			this.num.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.num.ValueChanged += new System.EventHandler(this.num_ValueChanged);
			// 
			// scriptLabel
			// 
			this.scriptLabel.Name = "scriptLabel";
			this.scriptLabel.ReadOnly = true;
			this.scriptLabel.Size = new System.Drawing.Size(200, 25);
			this.scriptLabel.TextChanged += new System.EventHandler(this.eventLabel_TextChanged);
			// 
			// navigateBck
			// 
			this.navigateBck.Enabled = false;
			this.navigateBck.Image = global::LazyShell.Properties.Resources.back;
			this.navigateBck.Name = "navigateBck";
			this.navigateBck.Size = new System.Drawing.Size(23, 22);
			this.navigateBck.ToolTipText = "Navigate Backward";
			this.navigateBck.Click += new System.EventHandler(this.navigateBck_Click);
			// 
			// navigateFwd
			// 
			this.navigateFwd.Enabled = false;
			this.navigateFwd.Image = global::LazyShell.Properties.Resources.foward;
			this.navigateFwd.Name = "navigateFwd";
			this.navigateFwd.Size = new System.Drawing.Size(23, 22);
			this.navigateFwd.ToolTipText = "Navigate Forward";
			this.navigateFwd.Click += new System.EventHandler(this.navigateFwd_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
			// 
			// searchScripts
			// 
			this.searchScripts.Image = global::LazyShell.Properties.Resources.search;
			this.searchScripts.Name = "searchScripts";
			this.searchScripts.Size = new System.Drawing.Size(23, 22);
			this.searchScripts.ToolTipText = "Find command";
			// 
			// gotoAddrButton
			// 
			this.gotoAddrButton.Image = global::LazyShell.Properties.Resources.jumpTo;
			this.gotoAddrButton.Name = "gotoAddrButton";
			this.gotoAddrButton.Size = new System.Drawing.Size(23, 22);
			this.gotoAddrButton.ToolTipText = "Goto Address";
			this.gotoAddrButton.Click += new System.EventHandler(this.gotoAddrButton_Click);
			// 
			// findReferences
			// 
			this.findReferences.Image = global::LazyShell.Properties.Resources.findReferences;
			this.findReferences.Name = "findReferences";
			this.findReferences.Size = new System.Drawing.Size(23, 22);
			this.findReferences.ToolTipText = "Find all references to event";
			this.findReferences.Click += new System.EventHandler(this.findReferences_Click);
			// 
			// toolStripSeparator10
			// 
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
			// 
			// contextMenuStripGoto
			// 
			this.contextMenuStripGoto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToToolStripMenuItem});
			this.contextMenuStripGoto.Name = "contextMenuStripGoto";
			this.contextMenuStripGoto.Size = new System.Drawing.Size(68, 26);
			// 
			// goToToolStripMenuItem
			// 
			this.goToToolStripMenuItem.Image = global::LazyShell.Properties.Resources.jumpTo;
			this.goToToolStripMenuItem.Name = "goToToolStripMenuItem";
			this.goToToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
			// 
			// toolStrip4
			// 
			this.toolStrip4.CanOverflow = false;
			this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save,
            this.helpTips,
            this.toolStripSeparator4,
            this.import,
            this.export,
            this.clear,
            this.toolStripSeparator2,
            this.baseConvertor,
            this.openHexEditor,
            this.autoPointerUpdate,
            this.toolStripSeparator6,
            this.openPreviewer});
			this.toolStrip4.Location = new System.Drawing.Point(0, 0);
			this.toolStrip4.Name = "toolStrip4";
			this.toolStrip4.Size = new System.Drawing.Size(792, 25);
			this.toolStrip4.TabIndex = 8;
			// 
			// save
			// 
			this.save.Image = global::LazyShell.Properties.Resources.save;
			this.save.Name = "save";
			this.save.Size = new System.Drawing.Size(23, 22);
			this.save.ToolTipText = "Save";
			// 
			// helpTips
			// 
			this.helpTips.CheckOnClick = true;
			this.helpTips.Image = global::LazyShell.Properties.Resources.help;
			this.helpTips.Name = "helpTips";
			this.helpTips.Size = new System.Drawing.Size(23, 22);
			this.helpTips.ToolTipText = "Help Tips";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
			// 
			// import
			// 
			this.import.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importEventScripts,
            this.importActionScripts});
			this.import.Image = global::LazyShell.Properties.Resources.importData;
			this.import.Name = "import";
			this.import.Size = new System.Drawing.Size(29, 22);
			// 
			// importEventScripts
			// 
			this.importEventScripts.Name = "importEventScripts";
			this.importEventScripts.Size = new System.Drawing.Size(195, 22);
			this.importEventScripts.Text = "Import Event Scripts...";
			// 
			// importActionScripts
			// 
			this.importActionScripts.Name = "importActionScripts";
			this.importActionScripts.Size = new System.Drawing.Size(195, 22);
			this.importActionScripts.Text = "Import Action Scripts...";
			// 
			// export
			// 
			this.export.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportEventScripts,
            this.exportActionScripts,
            this.toolStripSeparator1,
            this.dumpEventScriptText,
            this.dumpActionScriptText});
			this.export.Image = global::LazyShell.Properties.Resources.exportData;
			this.export.Name = "export";
			this.export.Size = new System.Drawing.Size(29, 22);
			// 
			// exportEventScripts
			// 
			this.exportEventScripts.Name = "exportEventScripts";
			this.exportEventScripts.Size = new System.Drawing.Size(211, 22);
			this.exportEventScripts.Text = "Export Event Scripts...";
			// 
			// exportActionScripts
			// 
			this.exportActionScripts.Name = "exportActionScripts";
			this.exportActionScripts.Size = new System.Drawing.Size(211, 22);
			this.exportActionScripts.Text = "Export Action Scripts...";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(208, 6);
			// 
			// dumpEventScriptText
			// 
			this.dumpEventScriptText.Image = global::LazyShell.Properties.Resources.exportText;
			this.dumpEventScriptText.Name = "dumpEventScriptText";
			this.dumpEventScriptText.Size = new System.Drawing.Size(211, 22);
			this.dumpEventScriptText.Text = "Dump Event Script Text...";
			// 
			// dumpActionScriptText
			// 
			this.dumpActionScriptText.Image = global::LazyShell.Properties.Resources.exportText;
			this.dumpActionScriptText.Name = "dumpActionScriptText";
			this.dumpActionScriptText.Size = new System.Drawing.Size(211, 22);
			this.dumpActionScriptText.Text = "Dump Action Script Text...";
			// 
			// clear
			// 
			this.clear.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearEventScripts,
            this.clearActionScripts});
			this.clear.Image = global::LazyShell.Properties.Resources.clear;
			this.clear.Name = "clear";
			this.clear.Size = new System.Drawing.Size(29, 22);
			// 
			// clearEventScripts
			// 
			this.clearEventScripts.Name = "clearEventScripts";
			this.clearEventScripts.Size = new System.Drawing.Size(186, 22);
			this.clearEventScripts.Text = "Clear Event Scripts...";
			// 
			// clearActionScripts
			// 
			this.clearActionScripts.Name = "clearActionScripts";
			this.clearActionScripts.Size = new System.Drawing.Size(186, 22);
			this.clearActionScripts.Text = "Clear Action Scripts...";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// baseConvertor
			// 
			this.baseConvertor.CheckOnClick = true;
			this.baseConvertor.Image = global::LazyShell.Properties.Resources.baseConversion;
			this.baseConvertor.Name = "baseConvertor";
			this.baseConvertor.Size = new System.Drawing.Size(23, 22);
			this.baseConvertor.ToolTipText = "Base Convertor";
			// 
			// openHexEditor
			// 
			this.openHexEditor.Image = global::LazyShell.Properties.Resources.hexEditor;
			this.openHexEditor.Name = "openHexEditor";
			this.openHexEditor.Size = new System.Drawing.Size(23, 22);
			this.openHexEditor.ToolTipText = "Hex Editor";
			this.openHexEditor.Click += new System.EventHandler(this.openHexEditor_Click);
			// 
			// autoPointerUpdate
			// 
			this.autoPointerUpdate.Checked = true;
			this.autoPointerUpdate.CheckOnClick = true;
			this.autoPointerUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
			this.autoPointerUpdate.Image = global::LazyShell.Properties.Resources.update;
			this.autoPointerUpdate.Name = "autoPointerUpdate";
			this.autoPointerUpdate.Size = new System.Drawing.Size(23, 22);
			this.autoPointerUpdate.ToolTipText = "Auto Pointer Update";
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
			// 
			// openPreviewer
			// 
			this.openPreviewer.Image = global::LazyShell.Properties.Resources.preview;
			this.openPreviewer.Name = "openPreviewer";
			this.openPreviewer.Size = new System.Drawing.Size(23, 22);
			this.openPreviewer.ToolTipText = "Open Previewer";
			this.openPreviewer.Click += new System.EventHandler(this.openPreviewer_Click);
			// 
			// OwnerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(792, 676);
			this.Controls.Add(this.commandTree);
			this.Controls.Add(this.toolStrip2);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.toolStrip4);
			this.Location = new System.Drawing.Point(0, 0);
			this.Name = "OwnerForm";
			this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "Event Scripts - Lazy Shell";
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.contextMenuStripGoto.ResumeLayout(false);
			this.toolStrip4.ResumeLayout(false);
			this.toolStrip4.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Controls.NewTreeView commandTree;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton moveUp;
        private System.Windows.Forms.ToolStripButton moveDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton paste;
        private System.Windows.Forms.ToolStripButton delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton undo;
        private System.Windows.Forms.ToolStripButton redo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton edit;
        private System.Windows.Forms.ToolStripButton expandAll;
        private System.Windows.Forms.ToolStripButton collapseAll;
        private System.Windows.Forms.ToolStripLabel labelBytesLeft;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripTextBox eventHexText;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox scriptType;
        private System.Windows.Forms.ToolStripTextBox scriptLabel;
        private Controls.NewToolStripNumericUpDown num;
        private System.Windows.Forms.ToolStripButton navigateBck;
        private System.Windows.Forms.ToolStripButton navigateFwd;
        private System.Windows.Forms.ToolStripButton gotoAddrButton;
        private System.Windows.Forms.ToolStripButton searchScripts;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGoto;
        private System.Windows.Forms.ToolStripMenuItem goToToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton insert;
        private System.Windows.Forms.ToolStripButton copy;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripDropDownButton import;
        private System.Windows.Forms.ToolStripMenuItem importEventScripts;
        private System.Windows.Forms.ToolStripMenuItem importActionScripts;
        private System.Windows.Forms.ToolStripDropDownButton export;
        private System.Windows.Forms.ToolStripMenuItem exportEventScripts;
        private System.Windows.Forms.ToolStripMenuItem exportActionScripts;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem dumpEventScriptText;
        private System.Windows.Forms.ToolStripMenuItem dumpActionScriptText;
        private System.Windows.Forms.ToolStripDropDownButton clear;
        private System.Windows.Forms.ToolStripMenuItem clearEventScripts;
        private System.Windows.Forms.ToolStripMenuItem clearActionScripts;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton helpTips;
        private System.Windows.Forms.ToolStripButton baseConvertor;
        private System.Windows.Forms.ToolStripButton openHexEditor;
        private System.Windows.Forms.ToolStripButton autoPointerUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton openPreviewer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton findReferences;
        private Controls.NewToolStripButton toggleByteEditor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
    }
}