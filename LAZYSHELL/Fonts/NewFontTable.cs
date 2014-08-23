using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL.Fonts
{
    public partial class NewFontTable : Controls.NewForm
    {
        #region Variables
        
        // Forms
        private OwnerForm ownerForm;

        // Elements
        private Glyph[] font
        {
            get { return ownerForm.Glyphs; }
        }
        private FontType fontType
        {
            get { return ownerForm.FontType; }
        }
        private int[] palette
        {
            get { return ownerForm.Palette; }
        }

        // System font properties
        private FontFamily[] ff = FontFamily.Families;
        private FontStyle bold;
        private FontStyle italics;
        private FontStyle underline;

        // Screen capture
        [DllImport("gdi32.dll")]
        private static extern bool BitBlt(
        IntPtr hdcDest, // handle to destination DC
        int nXDest, // x-coord of destination upper-left corner
        int nYDest, // y-coord of destination upper-left corner
        int nWidth, // width of destination rectangle
        int nHeight, // height of destination rectangle
        IntPtr hdcSrc, // handle to source DC
        int nXSrc, // x-coordinate of source upper-left corner
        int nYSrc, // y-coordinate of source upper-left corner
        System.Int32 dwRop // raster operation code
        );
        private const Int32 SRCCOPY = 0xCC0020;

        // Initial symbol table
        private readonly char[] textBoxChars = new char[]
        {
                ' ','!','“','”',' ',' ','‘','’',
                '(',')',' ',' ',',','-','.','/',
                '0','1','2','3','4','5','6','7',
                '8','9','~',' ',' ',' ',' ','?',
                '©','A','B','C','D','E','F','G',
                'H','I','J','K','L','M','N','O',
                'P','Q','R','S','T','U','V','W',
                'X','Y','Z',' ',' ',' ',' ',' ',
                ' ','a','b','c','d','e','f','g',
                'h','i','j','k','l','m','n','o',
                'p','q','r','s','t','u','v','w',
                'x','y','z',' ',' ',' ',' ',' ',
                ' ',' ',' ',' ',' ',' ',' ',' ',
                ' ',' ',' ',' ',' ',' ',':',';',
                '<','>',' ','#','+','×','%',' ',
                ' ',' ','*','\'','&',' ',' ',' ',
        };

        #endregion

        // Constructors
        public NewFontTable(OwnerForm ownerForm)
        {
            this.ownerForm = ownerForm;
            this.Owner = ownerForm;
            InitializeComponent();
            InitializeTable();
        }
        public void Reload()
        {
            InitializeTable();
        }

        // Methods
        private void InitializeTable()
        {
            fontTable.Visible = false;
            fontTable.Controls.Clear();
            if (fontFamily.Items.Count == 0)
            {
                for (int x = 0; x < ff.Length; x++)
                {
                    fontFamily.Items.Add(ff[x].Name);
                    if (ff[x].Name == "Tahoma")
                        fontFamily.SelectedIndex = x;
                }
            }
            Size s = new Size(), u = new Size();
            u.Width = font[0].MaxWidth;
            characterHeight.Value = u.Height = font[0].Height;
            fontTable.BackColor = Color.FromArgb(palette[3]);
            fontTable.ForeColor = Color.FromArgb(palette[1]);
            switch (fontType)
            {
                case FontType.Menu:
                case FontType.Description: s.Width = 16; s.Height = 8; break;
                case FontType.Dialogue: s.Width = 8; s.Height = 16; break;
            }
            TextBox textBox;
            for (int y = s.Height - 1; y >= 0; y--)
            {
                for (int x = 0; x < s.Width; x++)
                {
                    textBox = new TextBox();
                    textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    textBox.Height = u.Height;
                    textBox.MaxLength = 1;
                    textBox.Size = new System.Drawing.Size(u.Width, u.Height);
                    textBox.TabIndex = y * s.Width + x;
                    textBox.Left = x * u.Width;
                    textBox.Top = y * u.Height - 2;
                    textBox.Text = textBoxChars[y * s.Width + x].ToString();
                    fontTable.Controls.Add(textBox);
                    textBox.BackColor = fontTable.BackColor;
                    textBox.ForeColor = fontTable.ForeColor;
                    textBox.BringToFront();
                    textBox.Enter += new EventHandler(rtb_Enter);
                }
            }
            fontTable.Height = s.Height * u.Height;
            fontTable.Visible = true;
        }

        #region Event Handlers

        // Table
        private void rtb_Enter(object sender, EventArgs e)
        {
            (sender as RichTextBox).SelectAll();
        }

        // System font properties
        private void fontFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fontBold.Checked && !ff[fontFamily.SelectedIndex].IsStyleAvailable(FontStyle.Bold))
            {
                fontBold.Checked = false;
                bold = FontStyle.Regular;
            }
            if (fontItalics.Checked && !ff[fontFamily.SelectedIndex].IsStyleAvailable(FontStyle.Italic))
            {
                fontItalics.Checked = false;
                italics = FontStyle.Regular;
            }
            if (fontUnderline.Checked && !ff[fontFamily.SelectedIndex].IsStyleAvailable(FontStyle.Underline))
            {
                fontUnderline.Checked = false;
                underline = FontStyle.Regular;
            }
            if (!fontBold.Checked && !fontItalics.Checked && !fontUnderline.Checked && !ff[fontFamily.SelectedIndex].IsStyleAvailable(FontStyle.Regular))
            {
                if (ff[fontFamily.SelectedIndex].IsStyleAvailable(FontStyle.Bold))
                {
                    fontBold.Checked = true;
                    bold = italics = underline = FontStyle.Bold;
                }
                else if (ff[fontFamily.SelectedIndex].IsStyleAvailable(FontStyle.Italic))
                {
                    fontItalics.Checked = true;
                    bold = italics = underline = FontStyle.Italic;
                }
                else if (ff[fontFamily.SelectedIndex].IsStyleAvailable(FontStyle.Underline))
                {
                    fontUnderline.Checked = true;
                    bold = italics = underline = FontStyle.Underline;
                }
            }
            try
            {
                fontTable.Font = new Font(ff[fontFamily.SelectedIndex].Name, (float)fontSize.Value, (FontStyle)(bold | italics | underline));
            }
            catch
            {
                MessageBox.Show("Font does not support the current selected styles.", "LAZY SHELL");
            }
        }
        private void fontSize_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                fontTable.Font = new Font(ff[fontFamily.SelectedIndex].Name, (float)fontSize.Value, (FontStyle)(bold | italics | underline));
            }
            catch
            {
                MessageBox.Show("Font does not support the current selected size.", "LAZY SHELL");
            }
        }
        private void fontUnderline_Click(object sender, EventArgs e)
        {
            try
            {
                underline = fontUnderline.Checked ? FontStyle.Underline : FontStyle.Regular;
                fontTable.Font = new Font(ff[fontFamily.SelectedIndex].Name, (float)fontSize.Value, (FontStyle)(bold | italics | underline));
            }
            catch
            {
                MessageBox.Show("Font does not support the current selected styles.", "LAZY SHELL");
            }
        }
        private void fontItalics_Click(object sender, EventArgs e)
        {
            try
            {
                italics = fontItalics.Checked ? FontStyle.Italic : FontStyle.Regular;
                fontTable.Font = new Font(ff[fontFamily.SelectedIndex].Name, (float)fontSize.Value, (FontStyle)(bold | italics | underline));
            }
            catch
            {
                MessageBox.Show("Font does not support the current selected styles.", "LAZY SHELL");
            }
        }
        private void fontBold_Click(object sender, EventArgs e)
        {
            try
            {
                bold = fontBold.Checked ? FontStyle.Bold : FontStyle.Regular;
                fontTable.Font = new Font(ff[fontFamily.SelectedIndex].Name, (float)fontSize.Value, (FontStyle)(bold | italics | underline));
            }
            catch
            {
                MessageBox.Show("Font does not support the current selected styles.", "LAZY SHELL");
            }
        }

        // Shifting
        private void shiftTableUp_Click(object sender, EventArgs e)
        {
            foreach (Control c in fontTable.Controls)
                c.Top--;
        }
        private void shiftTableDown_Click(object sender, EventArgs e)
        {
            foreach (Control c in fontTable.Controls)
                c.Top++;
        }
        private void shiftTableRight_Click(object sender, EventArgs e)
        {
            foreach (Control c in fontTable.Controls)
                c.Left++;
        }
        private void shiftTableLeft_Click(object sender, EventArgs e)
        {
            foreach (Control c in fontTable.Controls)
                c.Left--;
        }

        // Modification
        private void resetTable_Click(object sender, EventArgs e)
        {
            InitializeTable();
        }
        private void characterHeight_ValueChanged(object sender, EventArgs e)
        {
            foreach (Control c in fontTable.Controls)
                c.Height = (int)characterHeight.Value;
        }
        private void autoSetWidths_CheckedChanged(object sender, EventArgs e)
        {
            padding.Enabled = autoSetWidths.Checked;
        }

        // Generate
        private void generateFontTableImage_Click(object sender, EventArgs e)
        {
            // Capture image of font table's region on screen
            Graphics graphic = this.fontTable.CreateGraphics();
            Size s = this.fontTable.Size;
            Bitmap import = new Bitmap(s.Width, s.Height, graphic);
            Graphics memGraphic = Graphics.FromImage(import);
            IntPtr dc1 = graphic.GetHdc();
            IntPtr dc2 = memGraphic.GetHdc();
            BitBlt(dc2, 0, 0, this.fontTable.ClientRectangle.Width,
            this.fontTable.ClientRectangle.Height, dc1, 0, 0, SRCCOPY);
            graphic.ReleaseHdc(dc1);
            memGraphic.ReleaseHdc(dc2);
            import.MakeTransparent(fontTable.BackColor);

            // Convert to bitmap
            int[] palette = new int[4];
            for (int i = 0; i < 4; i++)
                palette[i] = this.palette[i];
            byte[] graphicBlock = new byte[(import.Width * import.Height) / 4];
            Do.PixelsToBPP(
                Do.ImageToPixels(import, new Size(import.Width, import.Height)),
                graphicBlock, new Size(import.Width / 8, import.Height / 8), palette, 0x10);

            // Write to font's graphics
            switch (fontType)
            {
                case FontType.Menu:
                    Do.CopyOverFontTable(graphicBlock, font, new Size(import.Width / 8, import.Height / 12), palette);
                    break;
                case FontType.Dialogue:
                    Do.CopyOverFontTable(graphicBlock, font, new Size(import.Width / 16, import.Height / 12), palette);
                    break;
                case FontType.Description:
                case FontType.Triangles:
                    Do.CopyOverFontTable(graphicBlock, font, new Size(import.Width / 8, import.Height / 8), palette);
                    break;
            }

            // Redraw text image in dialogue forms
            ownerForm.RedrawText();
        }

        #endregion

    }
}
