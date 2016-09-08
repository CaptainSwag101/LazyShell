namespace LazyShell.Dialogues
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
			this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
			this.toolStrip3 = new System.Windows.Forms.ToolStrip();
			this.save = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.helpTips = new System.Windows.Forms.ToolStripButton();
			this.baseConvertor = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
			this.toggleDialogues = new LazyShell.Controls.NewToolStripButton();
			this.toggleDTETable = new LazyShell.Controls.NewToolStripButton();
			this.toggleBattleDialogues = new LazyShell.Controls.NewToolStripButton();
			this.toolStrip3.SuspendLayout();
			this.SuspendLayout();
			// 
			// dockPanel
			// 
			this.dockPanel.BackColor = System.Drawing.SystemColors.ControlDark;
			this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dockPanel.Location = new System.Drawing.Point(0, 25);
			this.dockPanel.Name = "dockPanel";
			this.dockPanel.Size = new System.Drawing.Size(502, 434);
			this.dockPanel.TabIndex = 17;
			// 
			// toolStrip3
			// 
			this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save,
            this.toolStripSeparator4,
            this.helpTips,
            this.baseConvertor,
            this.toolStripSeparator10,
            this.toggleDialogues,
            this.toggleDTETable,
            this.toggleBattleDialogues});
			this.toolStrip3.Location = new System.Drawing.Point(0, 0);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.Size = new System.Drawing.Size(502, 25);
			this.toolStrip3.TabIndex = 16;
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
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
			// 
			// helpTips
			// 
			this.helpTips.CheckOnClick = true;
			this.helpTips.Image = global::LazyShell.Properties.Resources.help;
			this.helpTips.Name = "helpTips";
			this.helpTips.Size = new System.Drawing.Size(23, 22);
			this.helpTips.ToolTipText = "Help Tips";
			// 
			// baseConvertor
			// 
			this.baseConvertor.CheckOnClick = true;
			this.baseConvertor.Image = global::LazyShell.Properties.Resources.baseConversion;
			this.baseConvertor.Name = "baseConvertor";
			this.baseConvertor.Size = new System.Drawing.Size(23, 22);
			this.baseConvertor.ToolTipText = "Base Convertor";
			// 
			// toolStripSeparator10
			// 
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
			// 
			// toggleDialogues
			// 
			this.toggleDialogues.Checked = true;
			this.toggleDialogues.CheckOnClick = true;
			this.toggleDialogues.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toggleDialogues.Form = null;
			this.toggleDialogues.Image = global::LazyShell.Properties.Resources.openDialogues;
			this.toggleDialogues.Name = "toggleDialogues";
			this.toggleDialogues.Size = new System.Drawing.Size(23, 22);
			this.toggleDialogues.ToolTipText = "Compression Table";
			// 
			// toggleDTETable
			// 
			this.toggleDTETable.Checked = true;
			this.toggleDTETable.CheckOnClick = true;
			this.toggleDTETable.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toggleDTETable.Form = null;
			this.toggleDTETable.Image = global::LazyShell.Properties.Resources.table;
			this.toggleDTETable.Name = "toggleDTETable";
			this.toggleDTETable.Size = new System.Drawing.Size(23, 22);
			this.toggleDTETable.ToolTipText = "Compression Table";
			// 
			// toggleBattleDialogues
			// 
			this.toggleBattleDialogues.Checked = true;
			this.toggleBattleDialogues.CheckOnClick = true;
			this.toggleBattleDialogues.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toggleBattleDialogues.Form = null;
			this.toggleBattleDialogues.Image = global::LazyShell.Properties.Resources.openBattleDialogues;
			this.toggleBattleDialogues.Name = "toggleBattleDialogues";
			this.toggleBattleDialogues.Size = new System.Drawing.Size(23, 22);
			this.toggleBattleDialogues.ToolTipText = "Battle Dialogues";
			// 
			// OwnerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(502, 459);
			this.Controls.Add(this.dockPanel);
			this.Controls.Add(this.toolStrip3);
			this.IsMdiContainer = true;
			this.Location = new System.Drawing.Point(0, 0);
			this.Name = "OwnerForm";
			this.Text = "Dialogues - Lazy Shell";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OwnerForm_FormClosing);
			this.toolStrip3.ResumeLayout(false);
			this.toolStrip3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton helpTips;
        private System.Windows.Forms.ToolStripButton baseConvertor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private Controls.NewToolStripButton toggleDTETable;
        private Controls.NewToolStripButton toggleBattleDialogues;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
        private Controls.NewToolStripButton toggleDialogues;
    }
}