using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    public partial class AttacksEditor : Form
    {
        private Model model = State.Instance.Model;
        private Settings settings = Settings.Default;
        public Spells spellsEditor;
        public Attacks attacksEditor;
        public AttacksEditor()
        {
            settings.Keystrokes[0x20] = "\x20";
            settings.KeystrokesMenu[0x20] = "\x20";
            InitializeComponent();
            Do.AddShortcut(toolStrip3, Keys.Control | Keys.S, new EventHandler(save_Click));
            Do.AddShortcut(toolStrip3, Keys.F1, helpTips);
            Do.AddShortcut(toolStrip3, Keys.F2, baseConversion);
            this.toolTip1.InitialDelay = 0;
            // create editors
            attacksEditor = new Attacks();
            attacksEditor.TopLevel = false;
            attacksEditor.Dock = DockStyle.Left;
            attacksEditor.SetToolTips(toolTip1);
            panel1.Controls.Add(attacksEditor);
            attacksEditor.Visible = true;
            spellsEditor = new Spells();
            spellsEditor.TopLevel = false;
            spellsEditor.Dock = DockStyle.Left;
            spellsEditor.SetToolTips(toolTip1);
            panel1.Controls.Add(spellsEditor);
            spellsEditor.Visible = true;
            new ToolTipLabel(this, toolTip1, baseConversion, helpTips);
        }
        public void Assemble()
        {
            foreach (Attack a in model.Attacks)
                a.Assemble();
            // Assemble the model.Spells
            int i;
            ushort len = 0x2bb6; // offset to the start of spell descriptions
            for (i = 0; i < model.Spells.Length && len + (model.Spells[i].RawDescription != null ? model.Spells[i].RawDescription.Length : 0) < (0x2bb6 + 0x36A); i++)
                len += model.Spells[i].Assemble(len);
            len = 0x55f0; // offset for extra space
            for (; i < model.Spells.Length && len + (model.Spells[i].RawDescription != null ? model.Spells[i].RawDescription.Length : 0) < (0x55f0 + 0xa10); i++)
                len += model.Spells[i].Assemble(len);
            if (i != model.Spells.Length)
                System.Windows.Forms.MessageBox.Show("Spell Descriptions total length exceeds max size, decrease total size to save correctly.\nNote: not all text has been saved.");
        }
        private void AttacksEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Attacks and spells have not been saved.\n\nWould you like to save changes?", "LAZY SHELL",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                Assemble();
            else if (result == DialogResult.No)
            {
                model.Spells = null;
                model.Attacks = null;
                model.AttackNames = null;
                model.SpellNames = null;
                return;
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
        }
        private void save_Click(object sender, EventArgs e)
        {
            Assemble();
        }
        private void importSpellsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new IOElements((Element[])model.Spells, spellsEditor.Index, "IMPORT SPELLS...").ShowDialog();
            spellsEditor.RefreshSpells();
        }
        private void importAttacksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new IOElements((Element[])model.Attacks, attacksEditor.Index, "IMPORT ATTACKS...").ShowDialog();
            attacksEditor.RefreshAttacks();
        }
        private void exportSpellsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new IOElements((Element[])model.Spells, spellsEditor.Index, "EXPORT SPELLS...").ShowDialog();
        }
        private void exportAttacksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new IOElements((Element[])model.Attacks, attacksEditor.Index, "EXPORT ATTACKS...").ShowDialog();
        }
        private void clearSpellsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ClearElements(model.Spells, spellsEditor.Index, "CLEAR SPELLS...").ShowDialog();
            spellsEditor.RefreshSpells();
        }
        private void clearAttacksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ClearElements(model.Attacks, attacksEditor.Index, "CLEAR ATTACKS...").ShowDialog();
            attacksEditor.RefreshAttacks();
        }
        private void showSpells_Click(object sender, EventArgs e)
        {
            spellsEditor.Visible = showSpells.Checked;
        }
        private void showAttacks_Click(object sender, EventArgs e)
        {
            attacksEditor.Visible = showAttacks.Checked;
        }

        private void AttacksEditor_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void AttacksEditor_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }
    }
}
