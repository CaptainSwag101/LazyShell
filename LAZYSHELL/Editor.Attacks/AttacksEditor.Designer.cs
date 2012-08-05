namespace LAZYSHELL
{
    partial class AttacksEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttacksEditor));
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveShortcut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.import = new System.Windows.Forms.ToolStripDropDownButton();
            this.importSpellsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importAttacksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.export = new System.Windows.Forms.ToolStripDropDownButton();
            this.exportSpellsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAttacksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.resetSpellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetAttackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clear = new System.Windows.Forms.ToolStripDropDownButton();
            this.clearSpellsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAttacksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.helpTips = new System.Windows.Forms.ToolStripButton();
            this.baseConversion = new System.Windows.Forms.ToolStripButton();
            this.damageCalculator = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showSpells = new System.Windows.Forms.ToolStripButton();
            this.showAttacks = new System.Windows.Forms.ToolStripButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 509);
            this.panel1.TabIndex = 0;
            // 
            // saveShortcut
            // 
            this.saveShortcut.Name = "saveShortcut";
            this.saveShortcut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveShortcut.Size = new System.Drawing.Size(32, 19);
            this.saveShortcut.Click += new System.EventHandler(this.save_Click);
            // 
            // toolStrip3
            // 
            this.toolStrip3.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save,
            this.toolStripSeparator4,
            this.import,
            this.export,
            this.toolStripDropDownButton1,
            this.clear,
            this.toolStripSeparator2,
            this.helpTips,
            this.baseConversion,
            this.damageCalculator,
            this.toolStripSeparator1,
            this.showSpells,
            this.showAttacks});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip3.Size = new System.Drawing.Size(626, 25);
            this.toolStrip3.TabIndex = 447;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // save
            // 
            this.save.Image = global::LAZYSHELL.Properties.Resources.save_small;
            this.save.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.save.ImageTransparentColor = System.Drawing.Color.Magenta;
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
            // import
            // 
            this.import.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importSpellsToolStripMenuItem,
            this.importAttacksToolStripMenuItem});
            this.import.Image = global::LAZYSHELL.Properties.Resources.import_small;
            this.import.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.import.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(26, 22);
            this.import.ToolTipText = "Import";
            // 
            // importSpellsToolStripMenuItem
            // 
            this.importSpellsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("importSpellsToolStripMenuItem.Image")));
            this.importSpellsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.importSpellsToolStripMenuItem.Name = "importSpellsToolStripMenuItem";
            this.importSpellsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.importSpellsToolStripMenuItem.Text = "Import Spells...";
            this.importSpellsToolStripMenuItem.Click += new System.EventHandler(this.importSpellsToolStripMenuItem_Click);
            // 
            // importAttacksToolStripMenuItem
            // 
            this.importAttacksToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("importAttacksToolStripMenuItem.Image")));
            this.importAttacksToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.importAttacksToolStripMenuItem.Name = "importAttacksToolStripMenuItem";
            this.importAttacksToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.importAttacksToolStripMenuItem.Text = "Import Attacks...";
            this.importAttacksToolStripMenuItem.Click += new System.EventHandler(this.importAttacksToolStripMenuItem_Click);
            // 
            // export
            // 
            this.export.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportSpellsToolStripMenuItem,
            this.exportAttacksToolStripMenuItem});
            this.export.Image = global::LAZYSHELL.Properties.Resources.export_small;
            this.export.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(26, 22);
            this.export.ToolTipText = "Export";
            // 
            // exportSpellsToolStripMenuItem
            // 
            this.exportSpellsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportSpellsToolStripMenuItem.Image")));
            this.exportSpellsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exportSpellsToolStripMenuItem.Name = "exportSpellsToolStripMenuItem";
            this.exportSpellsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.exportSpellsToolStripMenuItem.Text = "Export Spells...";
            this.exportSpellsToolStripMenuItem.Click += new System.EventHandler(this.exportSpellsToolStripMenuItem_Click);
            // 
            // exportAttacksToolStripMenuItem
            // 
            this.exportAttacksToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportAttacksToolStripMenuItem.Image")));
            this.exportAttacksToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exportAttacksToolStripMenuItem.Name = "exportAttacksToolStripMenuItem";
            this.exportAttacksToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.exportAttacksToolStripMenuItem.Text = "Export Attacks...";
            this.exportAttacksToolStripMenuItem.Click += new System.EventHandler(this.exportAttacksToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetSpellToolStripMenuItem,
            this.resetAttackToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::LAZYSHELL.Properties.Resources.reset;
            this.toolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(27, 22);
            // 
            // resetSpellToolStripMenuItem
            // 
            this.resetSpellToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("resetSpellToolStripMenuItem.Image")));
            this.resetSpellToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.resetSpellToolStripMenuItem.Name = "resetSpellToolStripMenuItem";
            this.resetSpellToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.resetSpellToolStripMenuItem.Text = "Reset spell";
            this.resetSpellToolStripMenuItem.Click += new System.EventHandler(this.resetSpellToolStripMenuItem_Click);
            // 
            // resetAttackToolStripMenuItem
            // 
            this.resetAttackToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("resetAttackToolStripMenuItem.Image")));
            this.resetAttackToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.resetAttackToolStripMenuItem.Name = "resetAttackToolStripMenuItem";
            this.resetAttackToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.resetAttackToolStripMenuItem.Text = "Reset attack";
            this.resetAttackToolStripMenuItem.Click += new System.EventHandler(this.resetAttackToolStripMenuItem_Click);
            // 
            // clear
            // 
            this.clear.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearSpellsToolStripMenuItem,
            this.clearAttacksToolStripMenuItem});
            this.clear.Image = global::LAZYSHELL.Properties.Resources.clear_small;
            this.clear.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.clear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(26, 22);
            this.clear.ToolTipText = "Clear";
            // 
            // clearSpellsToolStripMenuItem
            // 
            this.clearSpellsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("clearSpellsToolStripMenuItem.Image")));
            this.clearSpellsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.clearSpellsToolStripMenuItem.Name = "clearSpellsToolStripMenuItem";
            this.clearSpellsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clearSpellsToolStripMenuItem.Text = "Clear Spells...";
            this.clearSpellsToolStripMenuItem.Click += new System.EventHandler(this.clearSpellsToolStripMenuItem_Click);
            // 
            // clearAttacksToolStripMenuItem
            // 
            this.clearAttacksToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("clearAttacksToolStripMenuItem.Image")));
            this.clearAttacksToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.clearAttacksToolStripMenuItem.Name = "clearAttacksToolStripMenuItem";
            this.clearAttacksToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clearAttacksToolStripMenuItem.Text = "Clear Attacks...";
            this.clearAttacksToolStripMenuItem.Click += new System.EventHandler(this.clearAttacksToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // helpTips
            // 
            this.helpTips.CheckOnClick = true;
            this.helpTips.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpTips.Image = global::LAZYSHELL.Properties.Resources.help_small;
            this.helpTips.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.helpTips.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpTips.Name = "helpTips";
            this.helpTips.Size = new System.Drawing.Size(23, 22);
            this.helpTips.Text = "Show Help Tips";
            // 
            // baseConversion
            // 
            this.baseConversion.CheckOnClick = true;
            this.baseConversion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.baseConversion.Image = global::LAZYSHELL.Properties.Resources.baseConversion;
            this.baseConversion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.baseConversion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.baseConversion.Name = "baseConversion";
            this.baseConversion.Size = new System.Drawing.Size(23, 22);
            this.baseConversion.Text = "Show Base Conversion";
            // 
            // damageCalculator
            // 
            this.damageCalculator.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.damageCalculator.Image = global::LAZYSHELL.Properties.Resources.calculator;
            this.damageCalculator.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.damageCalculator.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.damageCalculator.Name = "damageCalculator";
            this.damageCalculator.Size = new System.Drawing.Size(23, 22);
            this.damageCalculator.Text = "Damage Calculator";
            this.damageCalculator.Click += new System.EventHandler(this.damageCalculator_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // showSpells
            // 
            this.showSpells.Checked = true;
            this.showSpells.CheckOnClick = true;
            this.showSpells.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showSpells.Image = global::LAZYSHELL.Properties.Resources.openSpells;
            this.showSpells.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showSpells.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showSpells.Name = "showSpells";
            this.showSpells.Size = new System.Drawing.Size(23, 22);
            this.showSpells.ToolTipText = "Spells";
            this.showSpells.Click += new System.EventHandler(this.showSpells_Click);
            // 
            // showAttacks
            // 
            this.showAttacks.Checked = true;
            this.showAttacks.CheckOnClick = true;
            this.showAttacks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showAttacks.Image = global::LAZYSHELL.Properties.Resources.openAttacks;
            this.showAttacks.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showAttacks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showAttacks.Name = "showAttacks";
            this.showAttacks.Size = new System.Drawing.Size(23, 22);
            this.showAttacks.ToolTipText = "Attacks";
            this.showAttacks.Click += new System.EventHandler(this.showAttacks_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.Active = false;
            // 
            // AttacksEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 534);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip3);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(5, 5);
            this.Name = "AttacksEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ATTACKS - Lazy Shell";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AttacksEditor_FormClosing);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripDropDownButton import;
        private System.Windows.Forms.ToolStripDropDownButton export;
        private System.Windows.Forms.ToolStripDropDownButton clear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton showSpells;
        private System.Windows.Forms.ToolStripButton showAttacks;
        private System.Windows.Forms.ToolStripMenuItem importSpellsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importAttacksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportSpellsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAttacksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearSpellsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAttacksToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton helpTips;
        private System.Windows.Forms.ToolStripButton baseConversion;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem saveShortcut;
        private System.Windows.Forms.ToolStripButton damageCalculator;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem resetSpellToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetAttackToolStripMenuItem;
    }
}