
namespace LAZYSHELL.Monsters
{
    partial class BattleScriptForm
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
            this.moveUp = new System.Windows.Forms.ToolStripButton();
            this.moveDown = new System.Windows.Forms.ToolStripButton();
            this.copy = new System.Windows.Forms.ToolStripButton();
            this.paste = new System.Windows.Forms.ToolStripButton();
            this.delete = new System.Windows.Forms.ToolStripButton();
            this.edit = new System.Windows.Forms.ToolStripButton();
            this.expandAll = new System.Windows.Forms.ToolStripButton();
            this.collapseAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.bytesLeft = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.label1 = new System.Windows.Forms.ToolStripLabel();
            this.hexText = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.insert = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.undo = new System.Windows.Forms.ToolStripButton();
            this.redo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStripGoto = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.goToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandTree = new LAZYSHELL.Controls.NewTreeView();
            this.toolStrip2.SuspendLayout();
            this.contextMenuStripGoto.SuspendLayout();
            this.SuspendLayout();
            // 
            // moveUp
            // 
            this.moveUp.AutoSize = false;
            this.moveUp.Image = global::LAZYSHELL.Properties.Resources.moveup;
            this.moveUp.Name = "moveUp";
            this.moveUp.Size = new System.Drawing.Size(22, 22);
            this.moveUp.ToolTipText = "Move Command Up (Shift+Up)";
            this.moveUp.Click += new System.EventHandler(this.moveUp_Click);
            // 
            // moveDown
            // 
            this.moveDown.AutoSize = false;
            this.moveDown.Image = global::LAZYSHELL.Properties.Resources.movedown;
            this.moveDown.Name = "moveDown";
            this.moveDown.Size = new System.Drawing.Size(22, 22);
            this.moveDown.ToolTipText = "Move Command Down (Shift+Down)";
            this.moveDown.Click += new System.EventHandler(this.moveDown_Click);
            // 
            // copy
            // 
            this.copy.AutoSize = false;
            this.copy.Image = global::LAZYSHELL.Properties.Resources.copy;
            this.copy.Name = "copy";
            this.copy.Size = new System.Drawing.Size(22, 22);
            this.copy.ToolTipText = "Copy Command (Ctrl+C)";
            this.copy.Click += new System.EventHandler(this.copy_Click);
            // 
            // paste
            // 
            this.paste.AutoSize = false;
            this.paste.Image = global::LAZYSHELL.Properties.Resources.paste;
            this.paste.Name = "paste";
            this.paste.Size = new System.Drawing.Size(22, 22);
            this.paste.ToolTipText = "Paste Command (Ctrl+V)";
            this.paste.Click += new System.EventHandler(this.paste_Click);
            // 
            // delete
            // 
            this.delete.AutoSize = false;
            this.delete.Image = global::LAZYSHELL.Properties.Resources.delete;
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(22, 22);
            this.delete.ToolTipText = "Delete Command (Del)";
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // edit
            // 
            this.edit.AutoSize = false;
            this.edit.Image = global::LAZYSHELL.Properties.Resources.edit;
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(22, 22);
            this.edit.ToolTipText = "Edit Command";
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // expandAll
            // 
            this.expandAll.AutoSize = false;
            this.expandAll.Image = global::LAZYSHELL.Properties.Resources.expandAll;
            this.expandAll.Name = "expandAll";
            this.expandAll.Size = new System.Drawing.Size(22, 22);
            this.expandAll.ToolTipText = "Expand All";
            this.expandAll.Click += new System.EventHandler(this.expandAll_Click);
            // 
            // collapseAll
            // 
            this.collapseAll.AutoSize = false;
            this.collapseAll.Image = global::LAZYSHELL.Properties.Resources.collapseAll;
            this.collapseAll.Name = "collapseAll";
            this.collapseAll.Size = new System.Drawing.Size(22, 22);
            this.collapseAll.ToolTipText = "Collapse All";
            this.collapseAll.Click += new System.EventHandler(this.collapseAll_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // bytesLeft
            // 
            this.bytesLeft.Name = "bytesLeft";
            this.bytesLeft.Size = new System.Drawing.Size(53, 22);
            this.bytesLeft.Text = "bytes left";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // label1
            // 
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 22);
            this.label1.Text = "HEX:";
            // 
            // hexText
            // 
            this.hexText.Name = "hexText";
            this.hexText.ReadOnly = true;
            this.hexText.Size = new System.Drawing.Size(70, 25);
            this.hexText.Text = "00-00-00-00";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insert,
            this.edit,
            this.copy,
            this.paste,
            this.delete,
            this.toolStripSeparator4,
            this.moveUp,
            this.moveDown,
            this.toolStripSeparator1,
            this.undo,
            this.redo,
            this.toolStripSeparator8,
            this.expandAll,
            this.collapseAll,
            this.toolStripSeparator6,
            this.bytesLeft,
            this.toolStripSeparator7,
            this.label1,
            this.hexText});
            this.toolStrip2.Location = new System.Drawing.Point(0, 611);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(558, 25);
            this.toolStrip2.TabIndex = 2;
            // 
            // insert
            // 
            this.insert.Image = global::LAZYSHELL.Properties.Resources.new_file;
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(23, 22);
            this.insert.ToolTipText = "Insert new command";
            this.insert.Click += new System.EventHandler(this.insert_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // undo
            // 
            this.undo.Image = global::LAZYSHELL.Properties.Resources.undo;
            this.undo.Name = "undo";
            this.undo.Size = new System.Drawing.Size(23, 22);
            this.undo.ToolTipText = "Undo (Ctrl+Z)";
            this.undo.Click += new System.EventHandler(this.undo_Click);
            // 
            // redo
            // 
            this.redo.Image = global::LAZYSHELL.Properties.Resources.redo;
            this.redo.Name = "redo";
            this.redo.Size = new System.Drawing.Size(23, 22);
            this.redo.ToolTipText = "Redo (Ctrl+Y)";
            this.redo.Click += new System.EventHandler(this.redo_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
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
            this.goToToolStripMenuItem.Image = global::LAZYSHELL.Properties.Resources.jumpTo;
            this.goToToolStripMenuItem.Name = "goToToolStripMenuItem";
            this.goToToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // commandTree
            // 
            this.commandTree.CheckBoxes = true;
            this.commandTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandTree.HideSelection = false;
            this.commandTree.HotTracking = true;
            this.commandTree.ItemHeight = 16;
            treeNode1.Name = "";
            treeNode1.Text = "";
            this.commandTree.LastNode = treeNode1;
            this.commandTree.Location = new System.Drawing.Point(0, 0);
            this.commandTree.Name = "commandTree";
            this.commandTree.Size = new System.Drawing.Size(558, 611);
            this.commandTree.TabIndex = 0;
            this.commandTree.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.commandTree_BeforeCheck);
            this.commandTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.commandTree_AfterCheck);
            this.commandTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.commandTree_AfterSelect);
            this.commandTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.commandTree_NodeMouseClick);
            this.commandTree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.commandTree_KeyDown);
            this.commandTree.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.commandTree_MouseDoubleClick);
            // 
            // BattleScriptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 636);
            this.Controls.Add(this.commandTree);
            this.Controls.Add(this.toolStrip2);
            this.Name = "BattleScriptForm";
            this.Text = "Battle Script";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BattleScriptForm_FormClosing);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.contextMenuStripGoto.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private Controls.NewTreeView commandTree;
        private System.Windows.Forms.ToolStripButton moveUp;
        private System.Windows.Forms.ToolStripButton moveDown;
        private System.Windows.Forms.ToolStripButton copy;
        private System.Windows.Forms.ToolStripButton paste;
        private System.Windows.Forms.ToolStripButton delete;
        private System.Windows.Forms.ToolStripButton edit;
        private System.Windows.Forms.ToolStripButton expandAll;
        private System.Windows.Forms.ToolStripButton collapseAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel bytesLeft;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel label1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripTextBox hexText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGoto;
        private System.Windows.Forms.ToolStripMenuItem goToToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton undo;
        private System.Windows.Forms.ToolStripButton redo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton insert;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}