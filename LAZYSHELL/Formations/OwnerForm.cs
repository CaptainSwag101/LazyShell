using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LazyShell.Properties;
using WeifenLuo.WinFormsUI.Docking;

namespace LazyShell.Formations
{
    public partial class OwnerForm : Controls.NewForm
    {
        #region Variables

        // Settings
        private Settings settings;

        // Elements
        public FormationsForm FormationsForm { get; set; }
        private Formation Formation
        {
            get { return FormationsForm.Formation; }
            set { FormationsForm.Formation = value; }
        }
        public PacksForm PacksForm { get; set; }
        public int FormationIndex
        {
            get { return FormationsForm.Index; }
            set { FormationsForm.Index = value; }
        }
        public int PackIndex
        {
            get { return PacksForm.Index; }
            set { PacksForm.Index = value; }
        }

        #endregion

        // Constructor
        public OwnerForm()
        {
            InitializeComponent();
            InitializeVariables();
            InitializeForms();
            CreateHelperForms();
            CreateShortcuts();
        }

        #region Methods

        // Initialization
        private void InitializeVariables()
        {
            settings = Settings.Default;
        }
        private void InitializeForms()
        {
            FormationsForm = new FormationsForm(this);
            FormationsForm.ToggleButton = toggleFormations;
            FormationsForm.Left = this.Left;
            FormationsForm.Top = this.Bottom;
			DockPanel = new DockPanel();
			DockPanel = dockPanel;

			Settings settings = Settings.Default;
			if (settings.VisualTheme == 0 || settings.VisualTheme == 1)
			{
				DockPanel.Theme = new VS2005Theme();
			}
			else if (settings.VisualTheme == 2)
			{
				//DockPanel.Theme = new VS2013BlueTheme();
			}

			dockPanel = DockPanel;
			FormationsForm.Show(dockPanel, DockState.Document);
            PacksForm = new PacksForm(this);
            PacksForm.ToggleButton = togglePacks;
            PacksForm.Left = FormationsForm.Right;
            PacksForm.Top = this.Bottom;
            PacksForm.Show(FormationsForm.Pane, DockAlignment.Right, 0.50);
        }
        private void CreateHelperForms()
        {
            new ToolTipLabel(this, baseConvertor, helpTips);
        }
        private void CreateShortcuts()
        {
            Do.AddShortcut(toolStrip5, Keys.Control | Keys.S, new EventHandler(save_Click));
            Do.AddShortcut(toolStrip5, Keys.F1, helpTips);
            Do.AddShortcut(toolStrip5, Keys.F2, baseConvertor);
        }

        // Saving
        public void WriteToROM()
        {
            foreach (var f in Model.Formations)
                f.WriteToROM();
            foreach (var p in Model.Packs)
                p.WriteToROM();
            for (int i = 0; i < Model.Musics.Length; i++)
                Model.ROM[0x029F51 + i] = Model.Musics[i];
            PacksForm.Modified = false;
            this.Modified = false;
        }

        #endregion

        #region Event Handlers

        // OwnerForm
        private void OwnerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.Modified && !this.Modified && !PacksForm.Modified)
                return;
            var result = MessageBox.Show(
                "Formations have not been saved.\n\nWould you like to save changes?", "LAZY SHELL",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                WriteToROM();
            else if (result == DialogResult.No)
                Model.ClearAll();
            else if (result == DialogResult.Cancel)
                e.Cancel = true;
        }

        // Data management
        private void save_Click(object sender, EventArgs e)
        {
            WriteToROM();
        }
        private void importFormations_Click(object sender, EventArgs e)
        {
            new IOElements(Model.Formations, IOMode.Import, FormationIndex, "IMPORT FORMATIONS...").ShowDialog();
            FormationsForm.LoadProperties();
        }
        private void importPacks_Click(object sender, EventArgs e)
        {
            new IOElements(Model.Packs, IOMode.Import, PacksForm.Index, "IMPORT PACKS...").ShowDialog();
            PacksForm.LoadProperties();
        }
        private void exportFormations_Click(object sender, EventArgs e)
        {
            new IOElements(Model.Formations, IOMode.Export, FormationIndex, "EXPORT FORMATIONS...").ShowDialog();
        }
        private void exportPacks_Click(object sender, EventArgs e)
        {
            new IOElements(Model.Packs, IOMode.Export, PacksForm.Index, "EXPORT PACKS...").ShowDialog();
        }
        private void clearFormations_Click(object sender, EventArgs e)
        {
            new ClearElements(Model.Formations, FormationIndex, "CLEAR FORMATIONS...").ShowDialog();
            FormationsForm.LoadProperties();
        }
        private void clearPacks_Click(object sender, EventArgs e)
        {
            new ClearElements(Model.Packs, PacksForm.Index, "CLEAR PACKS...").ShowDialog();
            PacksForm.LoadProperties();
        }
        private void resetFormation_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current formation. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            Formation = new Formation(FormationIndex);
            FormationsForm.LoadProperties();
        }
        private void resetPack_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You're about to undo all changes to the current pack. Go ahead with reset?",
                "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            PacksForm.Pack = new Pack(PacksForm.Index);
            PacksForm.LoadProperties();
        }

        #endregion

    }
}
