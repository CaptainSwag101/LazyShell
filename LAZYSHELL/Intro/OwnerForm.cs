using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LazyShell.Properties;
using WeifenLuo.WinFormsUI.Docking;

namespace LazyShell.Intro
{
    public partial class OwnerForm : Controls.NewForm
    {
        #region Variables

        public PreGameForm PreGameForm { get; set; }
        public TitleScreenForm TitleScreenForm { get; set; }

        #endregion

        // Constructor
        public OwnerForm()
        {
            InitializeComponent();
            InitializeForms();
            CreateHelperForms();
            CreateShortcuts();
            //
            this.History = new History(this, false);
        }

        #region Methods

        // Initialization
        private void InitializeForms()
        {
            TitleScreenForm = new TitleScreenForm(this);
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
			TitleScreenForm.Show(dockPanel, DockState.Document);
            TitleScreenForm.LoadTilesetEditor();
            PreGameForm = new PreGameForm(this);
            PreGameForm.Show(dockPanel, DockState.DockRight);
        }
        private void CreateShortcuts()
        {
            Do.AddShortcut(toolStrip1, Keys.Control | Keys.S, new EventHandler(save_Click));
            Do.AddShortcut(toolStrip1, Keys.F1, helpTips);
        }
        private void CreateHelperForms()
        {
            new ToolTipLabel(this, null, helpTips);
        }

        // Saving
        public void WriteToROM()
        {
            PreGameForm.WriteToROM();
            TitleScreenForm.WriteToROM();
            PreGameForm.Modified = false;
            TitleScreenForm.Modified = false;
            this.Modified = false;
        }

        #endregion

        #region Event Handlers

        // OwnerForm
        private void OwnerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.Modified)
                return;
            var result = MessageBox.Show(
                "Opening Credits and Main Title have not been saved.\n\nWould you like to save changes?",
                "LAZY SHELL", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                WriteToROM();
            else if (result == DialogResult.No)
            {
                Model.Cast_Data = null;
                Model.Cast_Palette = null;
                Model.Title_Data = null;
                Model.Title_Palettes = null;
                Model.Title_SpriteGraphics = null;
                Model.Title_SpritePalettes = null;
                Model.Title_Tileset = null;
            }
            else if (result == DialogResult.Cancel)
                e.Cancel = true;
        }

        // Data management
        private void save_Click(object sender, EventArgs e)
        {
            WriteToROM();
        }

        #endregion
    }
}
