using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LazyShell
{
    public partial class TextBoxForm : Controls.NewForm
    {
        #region Variables

        private bool hex;
        private bool keepOpen;
        private bool byteArray;
        private Delegate function;

        #endregion

        /// <summary>
        /// Opens a form containing a TextBox control.
        /// </summary>
        /// <param name="hex">Specifies whether the input should be treated as hexadecimal.</param>
        /// <param name="byteArray">Specifies whether the input should be treated as a byte array.</param>
        /// <param name="keepOpen">Specifies whether the form remains open when the function is complete.</param>
        /// <param name="maxLength">The maximum number of characters allowed in the TextBox.</param>
        /// <param name="function">The function to execute when the "OK" button is clicked.</param>
        /// <param name="title">The text to display in the form's title bar.</param>
        public TextBoxForm(bool hex, bool byteArray, bool keepOpen, int maxLength, Delegate function, string title)
        {
            this.hex = hex;
            this.keepOpen = keepOpen;
            this.byteArray = byteArray;
            this.function = function;
            InitializeComponent();
            this.Left = Cursor.Position.X + 10;
            this.Top = Cursor.Position.Y + 10;
            if (maxLength == 0)
                this.textBox1.MaxLength = 32767; // max default length
            else
                this.textBox1.MaxLength = maxLength;
            if (hex)
                this.textBox1.Font = new Font("Lucida Console", 8.25F); // use a monospace font for hex
            this.Text = title;
        }

        #region Event Handlers

        // TextBoxForm
        private void TextBoxForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (keepOpen && e.CloseReason != CloseReason.FormOwnerClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }
        private void TextBoxForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.Left = Cursor.Position.X + 10;
                this.Top = Cursor.Position.Y + 10;
            }
        }

        // Buttons
        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (byteArray)
                {
                    byte[] input = new byte[textBox1.Text.Length / 2];
                    for (int i = 0; i < textBox1.Text.Length / 2; i++)
                    {
                        string ascii = textBox1.Text.Substring(i * 2, 2);
                        byte value = Convert.ToByte(ascii, 16);
                        input[i] = value;
                    }
                    // run the delegate reference
                    if (this.function != null)
                        this.function.DynamicInvoke(input);
                    this.Tag = input;
                }
                else
                {
                    int input = 0;
                    if (hex)
                        input = Convert.ToInt32(textBox1.Text, 16);
                    else
                        input = Convert.ToInt32(textBox1.Text, 10);
                    if (this.function != null)
                        this.function.DynamicInvoke(input);
                    this.Tag = input;
                }
                if (!keepOpen)
                    this.Close();
                this.Activate();
            }
            catch
            {
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
