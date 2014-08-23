using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LAZYSHELL.Properties;

namespace LAZYSHELL.Menus
{
    public partial class MenuTextForm : Controls.NewForm
    {
        #region Variables

        // Forms
        private OwnerForm ownerForm;

        // Index
        public int Index
        {
            get { return name.SelectedIndex; }
            set { name.SelectedIndex = value; }
        }
        private Settings settings;
        private Dialogues.ParserReduced parserReduced;

        // Elements
        private MenuText menuText
        {
            get { return Model.Menu_Texts[Index]; }
            set { Model.Menu_Texts[Index] = value; }
        }

        #endregion

        // Constructor
        public MenuTextForm(OwnerForm ownerForm)
        {
            this.ownerForm = ownerForm;
            this.Owner = ownerForm;
            InitializeComponent();
            InitializeVariables();
            InitializeListControls();
        }

        #region Methods

        // Initialization
        private void InitializeVariables()
        {
            settings = Settings.Default;
            parserReduced = Dialogues.ParserReduced.Instance;
        }
        private void InitializeListControls()
        {
            for (int i = 0; i < Model.Menu_Texts.Length; i++)
                this.name.Items.Add(Model.Menu_Texts[i].GetText(textView.Checked));
        }
        private void LoadProperties()
        {
            this.Updating = true;
            //
            this.textBox.Text = menuText.GetText(textView.Checked);
            this.toolStripSeparator1.Visible =
                this.toolStripLabel1.Visible =
                this.xCoord.Visible = Index >= 14 && Index <= 19;
            this.xCoord.Value = menuText.X;
            SetFreeBytesLabel();
            //
            this.Updating = false;
        }
        private void SetFreeBytesLabel()
        {
            int freeBytes = Model.FreeMenuTextSpace();
            this.charactersLeft.Text = "(" + freeBytes + " characters left)";
            this.charactersLeft.BackColor = freeBytes >= 0 ? SystemColors.Control : Color.Red;
        }

        // Saving
        private void WriteToROM()
        {
            int offset = 0;
            byte[] temp = new byte[0x700];
            MenuText lastMenuText = null;
            foreach (var text in Model.Menu_Texts)
            {
                if (lastMenuText != null && text.Length != 0 && Bits.Compare(text.Text, lastMenuText.Text))
                {
                    Bits.SetShort(Model.ROM, text.Index * 2 + 0x3EEF00, lastMenuText.Offset);
                    text.Offset = lastMenuText.Offset;
                    continue;
                }
                if (offset + text.Length + 1 >= 0x700)
                {
                    MessageBox.Show("Menu texts exceed allotted ROM space. Stopped saving at index " + text.Index + ".");
                    break;
                }
                text.Offset = offset;
                lastMenuText = text;
                //
                Bits.SetShort(Model.ROM, text.Index * 2 + 0x3EEF00, offset);
                Bits.SetChars(temp, offset, text.Text);
                offset += text.Length;
                temp[offset++] = 0;
                switch (text.Index)
                {
                    case 14: Bits.SetByteBits(Model.ROM, 0x03328E, (byte)(text.X * 2), 0x3F); break;
                    case 15: Bits.SetByteBits(Model.ROM, 0x03327E, (byte)(text.X * 2), 0x3F); break;
                    case 16: Bits.SetByteBits(Model.ROM, 0x033282, (byte)(text.X * 2), 0x3F); break;
                    case 17: Bits.SetByteBits(Model.ROM, 0x033286, (byte)(text.X * 2), 0x3F); break;
                    case 18: Bits.SetByteBits(Model.ROM, 0x03328A, (byte)(text.X * 2), 0x3F); break;
                    case 19: Bits.SetByteBits(Model.ROM, 0x03327A, (byte)(text.X * 2), 0x3F); break;
                }
            }
            Bits.SetBytes(Model.ROM, 0x3EF000, temp);
        }

        #endregion

        #region Event Handlers

        // MenuTextForm
        private void MenuTextForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
                this.Location = new Point(Cursor.Position.X + 20, Cursor.Position.Y + 20);
        }

        // Navigators
        private void num_ValueChanged(object sender, EventArgs e)
        {
            name.SelectedIndex = (int)num.Value;
            if (this.Updating)
                return;
            LoadProperties();
        }
        private void name_SelectedIndexChanged(object sender, EventArgs e)
        {
            num.Value = name.SelectedIndex;
        }

        // TextBox
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            //
            char[] text = textBox.Text.ToCharArray();
            char[] swap;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '\n')
                {
                    int tempSel = textBox.SelectionStart;
                    swap = new char[text.Length + 2];
                    for (int x = 0; x < i; x++)
                        swap[x] = text[x];
                    swap[i] = '[';
                    swap[i + 1] = '1';
                    swap[i + 2] = ']';
                    for (int x = i + 3; x < swap.Length; x++)
                        swap[x] = text[x - 2];
                    textBox.Text = new string(swap);
                    text = textBox.Text.ToCharArray();
                    i += 2;
                    textBox.SelectionStart = tempSel + 2;
                }
            }
            if (parserReduced.VerifySymbols(this.textBox.Text.ToCharArray(), !textView.Checked))
            {
                this.menuText.SetText(textBox.Text, textView.Checked);
                this.menuText.Error = parserReduced.Error;
                this.Updating = true;
                int index = this.Index;
                name.Items.RemoveAt(index);
                name.Items.Insert(index, textBox.Text);
                name.Text = textBox.Text;
                name.Invalidate();
                this.Index = index;
                this.Updating = false;
            }
            SetFreeBytesLabel();
            ownerForm.Picture.Invalidate();
        }
        private void textView_CheckedChanged(object sender, EventArgs e)
        {
        }

        // Coordinates
        private void xCoord_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            menuText.X = (int)xCoord.Value;
            ownerForm.SetTextObjects();
            ownerForm.Picture.Invalidate();
        }

        #endregion
    }
}
