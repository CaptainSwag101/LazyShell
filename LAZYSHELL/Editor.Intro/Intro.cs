using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public partial class Intro : Form
    {
        public long checksum;
        private Opening opening;
        private MainTitle mainTitle;
        public Intro()
        {
            InitializeComponent();
            Do.AddShortcut(toolStrip1, Keys.Control | Keys.S, new EventHandler(save_Click));
            Do.AddShortcut(toolStrip1, Keys.F1, helpTips);
            // create editors
            opening = new Opening(this);
            opening.TopLevel = false;
            opening.Dock = DockStyle.Fill;
            panel1.Controls.Add(opening);
            opening.Visible = true;
            //
            mainTitle = new MainTitle(this);
            mainTitle.TopLevel = false;
            mainTitle.Dock = DockStyle.Right;
            panel1.Controls.Add(mainTitle);
            mainTitle.Visible = true;
            //
            new ToolTipLabel(this, null, helpTips);
            checksum = Do.GenerateChecksum(
                Model.OpeningData, Model.OpeningPalette, Model.TitleData, Model.TitlePalettes,
                Model.TitleSpriteGraphics, Model.TitleSpritePalettes, Model.TitleTileSet);
        }
        public void Assemble()
        {
            opening.Assemble();
            mainTitle.Assemble();
        }
        private void save_Click(object sender, EventArgs e)
        {
            Assemble();
        }
        private void Intro_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Do.GenerateChecksum(
                Model.OpeningData, Model.OpeningPalette, Model.TitleData, Model.TitlePalettes,
                Model.TitleSpriteGraphics, Model.TitleSpritePalettes, Model.TitleTileSet) == checksum)
                goto Close;
            DialogResult result = MessageBox.Show(
                "Opening Credits and Main Title have not been saved.\n\nWould you like to save changes?", "LAZY SHELL",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                Assemble();
            else if (result == DialogResult.No)
            {
                Model.OpeningData = null;
                Model.OpeningPalette = null;
                Model.TitleData = null;
                Model.TitlePalettes = null;
                Model.TitleSpriteGraphics = null;
                Model.TitleSpritePalettes = null;
                Model.TitleTileSet = null;
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
        Close:
            opening.CloseEditors();
            mainTitle.CloseEditors();
        }
    }
}
