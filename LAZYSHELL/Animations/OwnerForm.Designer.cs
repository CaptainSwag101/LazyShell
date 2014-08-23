
namespace LAZYSHELL.Animations
{
    partial class OwnerForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("");
            this.treeView = new LAZYSHELL.Controls.NewTreeView();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.save = new System.Windows.Forms.ToolStripButton();
            this.export = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.set = new System.Windows.Forms.ToolStripComboBox();
            this.name = new LAZYSHELL.Controls.NewToolStripComboBox();
            this.num = new LAZYSHELL.Controls.NewToolStripNumericUpDown();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.openPreviewer = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.helpTips = new System.Windows.Forms.ToolStripButton();
            this.baseConvertor = new System.Windows.Forms.ToolStripButton();
            this.toolStripCommands = new LAZYSHELL.Controls.NewToolStrip();
            this.edit = new System.Windows.Forms.ToolStripButton();
            this.moveUp = new System.Windows.Forms.ToolStripButton();
            this.moveDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.undo = new System.Windows.Forms.ToolStripButton();
            this.redo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.expandAll = new System.Windows.Forms.ToolStripButton();
            this.collapseAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toggleByteEditor = new LAZYSHELL.Controls.NewToolStripButton();
            this.textBoxHex = new System.Windows.Forms.ToolStripTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip4.SuspendLayout();
            this.toolStripCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.treeView.FullRowSelect = true;
            this.treeView.HideSelection = false;
            this.treeView.HotTracking = true;
            treeNode1.Name = "";
            treeNode1.Text = "";
            this.treeView.LastNode = treeNode1;
            this.treeView.Location = new System.Drawing.Point(0, 51);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(750, 564);
            this.treeView.TabIndex = 2;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            this.treeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView_KeyDown);
            this.treeView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeView_MouseDoubleClick);
            // 
            // toolStrip4
            // 
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save,
            this.export,
            this.toolStripSeparator3,
            this.set,
            this.name,
            this.num,
            this.toolStripSeparator7,
            this.openPreviewer,
            this.toolStripSeparator5,
            this.helpTips,
            this.baseConvertor});
            this.toolStrip4.Location = new System.Drawing.Point(0, 0);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(750, 26);
            this.toolStrip4.TabIndex = 0;
            // 
            // save
            // 
            this.save.Image = global::LAZYSHELL.Properties.Resources.save;
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(23, 23);
            this.save.ToolTipText = "Save";
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // export
            // 
            this.export.Image = global::LAZYSHELL.Properties.Resources.exportText;
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(23, 23);
            this.export.ToolTipText = "Dump Animation Text";
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 26);
            // 
            // set
            // 
            this.set.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.set.DropDownWidth = 160;
            this.set.IntegralHeight = false;
            this.set.Items.AddRange(new object[] {
            "Ally Spells",
            "Battle Events",
            "Items",
            "Monster Attacks",
            "Monster Behaviors",
            "Monster Entrances",
            "Monster Spells",
            "Weapons"});
            this.set.Name = "set";
            this.set.Size = new System.Drawing.Size(160, 26);
            this.set.SelectedIndexChanged += new System.EventHandler(this.set_SelectedIndexChanged);
            // 
            // name
            // 
            this.name.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.name.ContextMenuStrip = null;
            this.name.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.name.DropDownHeight = 500;
            this.name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.name.DropDownWidth = 300;
            this.name.ItemHeight = 15;
            this.name.Location = new System.Drawing.Point(223, 2);
            this.name.Name = "name";
            this.name.SelectedIndex = -1;
            this.name.SelectedItem = null;
            this.name.Size = new System.Drawing.Size(160, 23);
            this.name.SelectedIndexChanged += new System.EventHandler(this.name_SelectedIndexChanged);
            this.name.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.name_DrawItem);
            // 
            // num
            // 
            this.num.AutoSize = false;
            this.num.ContextMenuStrip = null;
            this.num.Hexadecimal = false;
            this.num.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num.Location = new System.Drawing.Point(383, 1);
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
            this.num.Name = "animationNum";
            this.num.Size = new System.Drawing.Size(50, 21);
            this.num.Text = "0";
            this.num.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.num.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 26);
            // 
            // openPreviewer
            // 
            this.openPreviewer.Image = global::LAZYSHELL.Properties.Resources.preview;
            this.openPreviewer.Name = "openPreviewer";
            this.openPreviewer.Size = new System.Drawing.Size(23, 23);
            this.openPreviewer.ToolTipText = "Open Previewer";
            this.openPreviewer.Click += new System.EventHandler(this.openPreviewer_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 26);
            // 
            // helpTips
            // 
            this.helpTips.CheckOnClick = true;
            this.helpTips.Image = global::LAZYSHELL.Properties.Resources.help;
            this.helpTips.Name = "helpTips";
            this.helpTips.Size = new System.Drawing.Size(23, 23);
            this.helpTips.ToolTipText = "Help Tips";
            // 
            // baseConvertor
            // 
            this.baseConvertor.CheckOnClick = true;
            this.baseConvertor.Image = global::LAZYSHELL.Properties.Resources.baseConversion;
            this.baseConvertor.Name = "baseConvertor";
            this.baseConvertor.Size = new System.Drawing.Size(23, 23);
            this.baseConvertor.ToolTipText = "Base Convertor";
            // 
            // toolStripCommands
            // 
            this.toolStripCommands.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.edit,
            this.moveUp,
            this.moveDown,
            this.toolStripSeparator6,
            this.undo,
            this.redo,
            this.toolStripSeparator4,
            this.expandAll,
            this.collapseAll,
            this.toolStripSeparator1,
            this.toggleByteEditor,
            this.textBoxHex});
            this.toolStripCommands.Location = new System.Drawing.Point(0, 26);
            this.toolStripCommands.Name = "toolStripCommands";
            this.toolStripCommands.Size = new System.Drawing.Size(750, 25);
            this.toolStripCommands.TabIndex = 4;
            // 
            // edit
            // 
            this.edit.Image = global::LAZYSHELL.Properties.Resources.edit;
            this.edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(23, 22);
            this.edit.ToolTipText = "Edit Command";
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // moveUp
            // 
            this.moveUp.Image = global::LAZYSHELL.Properties.Resources.moveup;
            this.moveUp.Name = "moveUp";
            this.moveUp.Size = new System.Drawing.Size(23, 22);
            this.moveUp.ToolTipText = "Move Down Command";
            this.moveUp.Click += new System.EventHandler(this.moveUp_Click);
            // 
            // moveDown
            // 
            this.moveDown.Image = global::LAZYSHELL.Properties.Resources.movedown;
            this.moveDown.Name = "moveDown";
            this.moveDown.Size = new System.Drawing.Size(23, 22);
            this.moveDown.ToolTipText = "Move Up Command";
            this.moveDown.Click += new System.EventHandler(this.moveDown_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // undo
            // 
            this.undo.Image = global::LAZYSHELL.Properties.Resources.undo;
            this.undo.Name = "undo";
            this.undo.Size = new System.Drawing.Size(23, 22);
            this.undo.ToolTipText = "Undo";
            this.undo.Click += new System.EventHandler(this.undo_Click);
            // 
            // redo
            // 
            this.redo.Image = global::LAZYSHELL.Properties.Resources.redo;
            this.redo.Name = "redo";
            this.redo.Size = new System.Drawing.Size(23, 22);
            this.redo.ToolTipText = "Redo";
            this.redo.Click += new System.EventHandler(this.redo_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // expandAll
            // 
            this.expandAll.Image = global::LAZYSHELL.Properties.Resources.expandAll;
            this.expandAll.Name = "expandAll";
            this.expandAll.Size = new System.Drawing.Size(23, 22);
            this.expandAll.ToolTipText = "Expand All";
            this.expandAll.Click += new System.EventHandler(this.expandAll_Click);
            // 
            // collapseAll
            // 
            this.collapseAll.Image = global::LAZYSHELL.Properties.Resources.collapseAll;
            this.collapseAll.Name = "collapseAll";
            this.collapseAll.Size = new System.Drawing.Size(23, 22);
            this.collapseAll.ToolTipText = "Collapse All";
            this.collapseAll.Click += new System.EventHandler(this.collapseAll_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toggleByteEditor
            // 
            this.toggleByteEditor.CheckOnClick = true;
            this.toggleByteEditor.Form = null;
            this.toggleByteEditor.Image = global::LAZYSHELL.Properties.Resources.hexEditor;
            this.toggleByteEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toggleByteEditor.Name = "toggleByteEditor";
            this.toggleByteEditor.Size = new System.Drawing.Size(23, 22);
            this.toggleByteEditor.ToolTipText = "Edit Command Bytes";
            // 
            // textBoxHex
            // 
            this.textBoxHex.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxHex.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxHex.Name = "textBoxHex";
            this.textBoxHex.ReadOnly = true;
            this.textBoxHex.Size = new System.Drawing.Size(200, 25);
            // 
            // toolTip1
            // 
            this.toolTip1.Active = false;
            // 
            // OwnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 635);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.toolStripCommands);
            this.Controls.Add(this.toolStrip4);
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "OwnerForm";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "ANIMATIONS - Lazy Shell";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OwnerForm_FormClosing);
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.toolStripCommands.ResumeLayout(false);
            this.toolStripCommands.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private Controls.NewTreeView treeView;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.ToolStripComboBox set;
        private Controls.NewToolStripComboBox name;
        private Controls.NewToolStripNumericUpDown num;
        private Controls.NewToolStrip toolStripCommands;
        private System.Windows.Forms.ToolStripButton moveUp;
        private System.Windows.Forms.ToolStripButton moveDown;
        private System.Windows.Forms.ToolStripButton baseConvertor;
        private System.Windows.Forms.ToolStripButton export;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripButton openPreviewer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton expandAll;
        private System.Windows.Forms.ToolStripButton collapseAll;
        private System.Windows.Forms.ToolStripButton helpTips;
        private System.Windows.Forms.ToolStripButton undo;
        private System.Windows.Forms.ToolStripButton redo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton edit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Controls.NewToolStripButton toggleByteEditor;
        private System.Windows.Forms.ToolStripTextBox textBoxHex;
    }
}