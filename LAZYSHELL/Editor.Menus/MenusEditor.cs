using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    public partial class MenusEditor : Form
    {
        public long Checksum;
        private Overworld overworld; public Overworld Overworld { get { return overworld; } set { overworld = value; } }
        private GameSelect gameSelect; public GameSelect GameSelect { get { return gameSelect; } set { gameSelect = value; } }
        private Settings settings = Settings.Default;
        private TextHelperReduced textHelper = TextHelperReduced.Instance;
        private int index { get { return menuTextName.SelectedIndex; } set { menuTextName.SelectedIndex = value; } }
        private MenuTexts menuText { get { return Model.MenuTexts[index]; } set { Model.MenuTexts[index] = value; } }
        private bool updating;
        //
        public MenusEditor()
        {
            settings.Keystrokes[0x20] = "\x20";
            settings.KeystrokesMenu[0x20] = "\x20";
            //
            InitializeComponent();
            Do.AddShortcut(toolStrip1, Keys.Control | Keys.S, new EventHandler(save_Click));
            LoadOverworldEditor();
            LoadGameSelectEditor();
            //
            for (int i = 0; i < Model.MenuTexts.Length; i++)
                this.menuTextName.Items.Add(Model.MenuTexts[i].GetMenuString(textCodeFormat.Checked));
            this.index = 0;
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
            Checksum = Do.GenerateChecksum(Model.MenuTexts, Model.MenuFrameGraphics, Model.MenuBGGraphics,
                Model.GameSelectGraphics, Model.GameSelectTileset, Model.GameSelectSpeakers);
        }
        private void RefreshMenuText()
        {
            updating = true;
            this.menuTextBox.Text = menuText.GetMenuString(textCodeFormat.Checked);
            CalculateFreeSpace();
            updating = false;
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
        private int CalculateFreeSpace()
        {
            int used = 0;
            MenuTexts lastMenuText = null;
            foreach (MenuTexts menuText in Model.MenuTexts)
            {
                if (lastMenuText != null && menuText.Length != 0 && Bits.Compare(menuText.MenuText, lastMenuText.MenuText))
                    continue;
                lastMenuText = menuText;
                used += menuText.Length + 1;
            }
            int left = 0x700 - used;
            this.charactersLeft.Text = "(" + left.ToString() + " characters left)";
            this.charactersLeft.BackColor = left >= 0 ? SystemColors.Control : Color.Red;
            return left;
        }
        private void Assemble()
        {
            int offset = 0;
            byte[] temp = new byte[0x700];
            MenuTexts lastMenuText = null;
            foreach (MenuTexts menuText in Model.MenuTexts)
            {
                if (lastMenuText != null && menuText.Length != 0 && Bits.Compare(menuText.MenuText, lastMenuText.MenuText))
                {
                    Bits.SetShort(Model.Data, menuText.Index * 2 + 0x3EEF00, lastMenuText.Offset);
                    menuText.Offset = lastMenuText.Offset;
                    continue;
                }
                if (offset + menuText.Length + 1 >= 0x700)
                {
                    MessageBox.Show("Menu texts exceed allotted ROM space. Stopped saving at index " + menuText.Index + ".");
                    break;
                }
                menuText.Offset = offset;
                lastMenuText = menuText;
                //
                Bits.SetShort(Model.Data, menuText.Index * 2 + 0x3EEF00, offset);
                Bits.SetCharArray(temp, offset, menuText.MenuText);
                offset += menuText.Length;
                temp[offset++] = 0;
            }
            Bits.SetByteArray(Model.Data, 0x3EF000, temp);
            //Bits.SetShort(Model.Data, 0x3EF600, 0x344F);
            overworld.Assemble();
            gameSelect.Assemble();
            Checksum = Do.GenerateChecksum(Model.MenuTexts, Model.MenuFrameGraphics, Model.MenuBGGraphics,
                Model.GameSelectGraphics, Model.GameSelectTileset, Model.GameSelectSpeakers);
        }
        //
        private void save_Click(object sender, EventArgs e)
        {
            Assemble();
        }
        private void MenusEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Do.GenerateChecksum(Model.MenuTexts, Model.MenuFrameGraphics, Model.MenuBGGraphics,
                Model.GameSelectGraphics, Model.GameSelectTileset, Model.GameSelectSpeakers) == Checksum)
                goto Close;
            DialogResult result = MessageBox.Show(
                "Menus have not been saved.\n\nWould you like to save changes?", "LAZY SHELL",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                Assemble();
            else if (result == DialogResult.No)
            {
                Model.MenuFrameGraphics = null;
                Model.FontPaletteMenu = null;
                Model.MenuBGGraphics = null;
                Model.MenuBGPalette = null;
                Model.ShopBGPalette = null;
                Model.MenuBGTileset = null;
                Model.MenuCursorGraphics = null;
                //
                Model.GameSelectGraphics = null;
                Model.GameSelectPalettes = null;
                Model.GameSelectPaletteSet = null;
                Model.GameSelectTileset = null;
                //
                Model.MenuTexts = null;
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
        private void menuTextNum_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            menuTextName.SelectedIndex = (int)menuTextNum.Value;
            updating = false;
            RefreshMenuText();
        }
        private void menuTextName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            menuTextNum.Value = menuTextName.SelectedIndex;
            updating = false;
            RefreshMenuText();
        }
        private void menuTextBox_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            //
            char[] text = menuTextBox.Text.ToCharArray();
            char[] swap;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '\n')
                {
                    int tempSel = menuTextBox.SelectionStart;
                    swap = new char[text.Length + 2];
                    for (int x = 0; x < i; x++)
                        swap[x] = text[x];
                    swap[i] = '[';
                    swap[i + 1] = '1';
                    swap[i + 2] = ']';
                    for (int x = i + 3; x < swap.Length; x++)
                        swap[x] = text[x - 2];
                    menuTextBox.Text = new string(swap);
                    text = menuTextBox.Text.ToCharArray();
                    i += 2;
                    menuTextBox.SelectionStart = tempSel + 2;
                }
            }
            if (textHelper.VerifyCorrectSymbols(this.menuTextBox.Text.ToCharArray(), !textCodeFormat.Checked))
            {
                menuText.SetMenuString(menuTextBox.Text, textCodeFormat.Checked);
                menuText.Error = textHelper.Error;
                updating = true;
                int index = this.index;
                menuTextName.Items.RemoveAt(index);
                menuTextName.Items.Insert(index, menuTextBox.Text);
                menuTextName.Text = menuTextBox.Text;
                menuTextName.Invalidate();
                this.index = index;
                updating = false;
            }
            CalculateFreeSpace();
            overworld.Picture.Invalidate();
            gameSelect.Picture.Invalidate();
        }
        private void textCodeFormat_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
