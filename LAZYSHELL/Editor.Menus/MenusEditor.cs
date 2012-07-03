using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public partial class MenusEditor : Form
    {
        public long Checksum;
        private Overworld overworld; public Overworld Overworld { get { return overworld; } set { overworld = value; } }
        private GameSelect gameSelect; public GameSelect GameSelect { get { return gameSelect; } set { gameSelect = value; } }
        //
        public MenusEditor()
        {
            InitializeComponent();
            Do.AddShortcut(toolStrip1, Keys.Control | Keys.S, new EventHandler(save_Click));
            LoadOverworldEditor();
            LoadGameSelectEditor();
            //
            gameSelect.TopLevel = false;
            gameSelect.Dock = DockStyle.Top;
            //gameSelect.SetToolTips(toolTip1);
            panel1.Controls.Add(gameSelect);
            gameSelect.BringToFront();
            //openGameSelect.Checked = true;
            gameSelect.Visible = true;
            overworld.TopLevel = false;
            overworld.Dock = DockStyle.Fill;
            //overworld.SetToolTips(toolTip1);
            panel1.Controls.Add(overworld);
            overworld.BringToFront();
            //openMenus.Checked = true;
            overworld.Visible = true;
            //
            GC.Collect();
            new History(this);
            //
            Checksum = Do.GenerateChecksum(Model.MenuFramePalette, Model.MenuFrameGraphics, Model.MenuBGPalette, Model.MenuBGGraphics,
                Model.GameSelectGraphics, Model.GameSelectPaletteSet, Model.GameSelectTileset, Model.GameSelectSpeakers);
        }
        private void LoadOverworldEditor()
        {
            if (overworld == null)
                overworld = new Overworld(this);
            else
                overworld.Reload(this);
        }
        private void LoadGameSelectEditor()
        {
            if (gameSelect == null)
                gameSelect = new GameSelect(this);
            else
                gameSelect.Reload(this);
        }
        private void Assemble()
        {
            overworld.Assemble();
            gameSelect.Assemble();
        }
        //
        private void save_Click(object sender, EventArgs e)
        {
            Assemble();
        }

        private void MenusEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Do.GenerateChecksum(Model.MenuFramePalette, Model.MenuFrameGraphics, Model.MenuBGPalette, Model.MenuBGGraphics,
                Model.GameSelectGraphics, Model.GameSelectPaletteSet, Model.GameSelectTileset, Model.GameSelectSpeakers) == Checksum)
                goto Close;
            DialogResult result = MessageBox.Show(
                "Menus have not been saved.\n\nWould you like to save changes?", "LAZY SHELL",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                Assemble();
            else if (result == DialogResult.No)
            {
                Model.MenuFrameGraphics = null;
                Model.MenuFramePalette = null;
                Model.MenuBGGraphics = null;
                Model.MenuBGPalette = null;
                Model.MenuBGTileset = null;
                Model.MenuCursorGraphics = null;
                //
                Model.GameSelectGraphics = null;
                Model.GameSelectPalettes = null;
                Model.GameSelectPaletteSet = null;
                Model.GameSelectTileset = null;
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
        Close:
            gameSelect.Close();
            overworld.Close();
        }
    }
}
