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
    public partial class FormationsEditor : Form
    {
        private Model model = State.Instance.Model;
        private Formations formationsEditor;
        private FormationPacks packsEditor;
        private Settings settings = Settings.Default;
        public int FormationIndex { get { return formationsEditor.Index; } set { formationsEditor.Index = value; } }
        public int PackIndex { get { return packsEditor.Index; } set { packsEditor.Index = value; } }
        public FormationsEditor()
        {
            settings.Keystrokes[0x20] = "\x20";
            settings.KeystrokesMenu[0x20] = "\x20";
            InitializeComponent();
            Do.AddShortcut(toolStrip3, Keys.Control | Keys.S, new EventHandler(save_Click));
            Do.AddShortcut(toolStrip3, Keys.F1, enableHelpTips);
            Do.AddShortcut(toolStrip3, Keys.F2, showDecHex);
            // create editors
            formationsEditor = new Formations();
            packsEditor = new FormationPacks(formationsEditor);
            packsEditor.TopLevel = false;
            packsEditor.Dock = DockStyle.Top;
            packsEditor.SetToolTips(toolTip1);
            panel1.Controls.Add(packsEditor);
            packsEditor.Visible = true;
            formationsEditor.TopLevel = false;
            formationsEditor.Dock = DockStyle.Top;
            formationsEditor.SetToolTips(toolTip1);
            panel1.Controls.Add(formationsEditor);
            formationsEditor.Visible = true;
            new ToolTipLabel(this, toolTip1, showDecHex, enableHelpTips);
        }
        // tooltips
        public void Assemble()
        {
            foreach (Formation f in model.Formations)
                f.Assemble();
            foreach (FormationPack fp in model.FormationPacks)
                fp.Assemble();
            for (int i = 0; i < model.FormationMusics.Length; i++)
                model.Data[0x029F51 + i] = model.FormationMusics[i];
        }
        private void FormationsEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Formations have not been saved.\n\nWould you like to save changes?", "LAZY SHELL",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                Assemble();
            else if (result == DialogResult.No)
            {
                model.Formations = null;
                model.FormationMusics = null;
                model.FormationPacks = null;
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
            formationsEditor.searchWindow.Close();
            packsEditor.searchWindow.Close();
        }
        private void save_Click(object sender, EventArgs e)
        {
            Assemble();
        }
        private void importFormationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new IOElements((Element[])model.Formations, formationsEditor.Index, "IMPORT FORMATIONS...").ShowDialog();
            formationsEditor.RefreshFormations();
        }
        private void importPacksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new IOElements((Element[])model.FormationPacks, packsEditor.Index, "IMPORT PACKS...").ShowDialog();
            packsEditor.RefreshFormationPacks();
        }
        private void exportFormationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new IOElements((Element[])model.Formations, formationsEditor.Index, "EXPORT FORMATIONS...").ShowDialog();
        }
        private void exportPacksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new IOElements((Element[])model.FormationPacks, packsEditor.Index, "EXPORT PACKS...").ShowDialog();
        }
        private void clearFormationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ClearElements(model.Formations, formationsEditor.Index, "CLEAR FORMATIONS...").ShowDialog();
            formationsEditor.RefreshFormations();
        }
        private void clearPacksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ClearElements(model.FormationPacks, packsEditor.Index, "CLEAR PACKS...").ShowDialog();
            packsEditor.RefreshFormationPacks();
        }
        private void showFormations_Click(object sender, EventArgs e)
        {
            formationsEditor.Visible = showFormations.Checked;
        }
        private void showPacks_Click(object sender, EventArgs e)
        {
            packsEditor.Visible = showPacks.Checked;
        }
    }
}
