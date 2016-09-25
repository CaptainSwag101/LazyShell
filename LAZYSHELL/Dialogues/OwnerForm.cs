using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LazyShell.Properties;
using WeifenLuo.WinFormsUI.Docking;

namespace LazyShell.Dialogues
{
    public partial class OwnerForm : Controls.NewForm
    {
        #region Variables

        // Forms
        public DialoguesForm DialoguesForm { get; set; }
        public BattleDialoguesForm BattleDialoguesForm { get; set; }
        public DTETableForm DTETableForm { get; set; }

        #endregion

        // Constructor
        public OwnerForm()
        {
            InitializeComponent();
            InitializeForms();
            CreateHelperForms();
            CreateShortcuts();
        }

        #region Methods

        private void InitializeForms()
        {
	        DialoguesForm = new DialoguesForm(this) {ToggleButton = toggleDialogues};
			DockPanel = new DockPanel();
	        DockPanel = dockPanel;

	        Settings settings = Settings.Default;
	        if (settings.VisualTheme == 0 || settings.VisualTheme == 1)
	        {
				DockPanel.Theme = new VS2005Theme();
			}
			else if (settings.VisualTheme == 2)
			{
				DockPanel.Theme = new VS2013BlueTheme();
			}
			
	        dockPanel = DockPanel;
	        DialoguesForm.Show(dockPanel, DockState.Document);
            DTETableForm = new DTETableForm(this);
            DTETableForm.ToggleButton = toggleDTETable;
            DTETableForm.Show(DialoguesForm.Pane, DockAlignment.Right, 0.50);
            BattleDialoguesForm = new BattleDialoguesForm(this);
            BattleDialoguesForm.ToggleButton = toggleBattleDialogues;
            BattleDialoguesForm.Show(DTETableForm.Pane, DTETableForm);
        }
        private void CreateHelperForms()
        {
            new ToolTipLabel(this, baseConvertor, helpTips);
        }
        private void CreateShortcuts()
        {
            Do.AddShortcut(toolStrip3, Keys.Control | Keys.S, new EventHandler(save_Click));
            Do.AddShortcut(toolStrip3, Keys.F1, helpTips);
            Do.AddShortcut(toolStrip3, Keys.F2, baseConvertor);
        }
        public void WriteToROM()
        {
            DialoguesForm.WriteToROM();
            BattleDialoguesForm.WriteToROM();
        }

        #endregion

        #region Event Handlers

        // DialoguesForm
        private void OwnerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!DialoguesForm.Modified && !BattleDialoguesForm.Modified)
                return;
            var result = MessageBox.Show(
                "Dialogues have not been saved.\n\nWould you like to save changes?",
                "LAZY SHELL", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                WriteToROM();
            else if (result == DialogResult.No)
                Model.ClearAll();
            else if (result == DialogResult.Cancel)
                e.Cancel = true;
        }

        // MenuStrip
        private void save_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            WriteToROM();
            Cursor.Current = Cursors.Arrow;
        }

        #endregion
    }
}
