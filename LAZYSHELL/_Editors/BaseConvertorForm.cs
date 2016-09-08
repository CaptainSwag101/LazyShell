using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LazyShell
{
    public partial class BaseConvertorForm : Controls.NewForm
    {
        // Constructor
        public BaseConvertorForm()
        {
            InitializeComponent();
            this.Left = Cursor.Position.X + 10;
            this.Top = Cursor.Position.Y + 10;
        }

        #region Event Handlers

        // BaseConvertorForm
        private void BaseConvertorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.FormOwnerClosing)
            {
                this.Hide();
                e.Cancel = true;
            }
        }
        private void BaseConvertorForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.Left = Cursor.Position.X + 10;
                this.Top = Cursor.Position.Y + 10;
            }
        }

        // TextBox
        private void baseConvDec_TextChanged(object sender, EventArgs e)
        {
            try
            {
                long value = Convert.ToInt64(baseConvDec.Text, 10);
                if (value <= 0xFFFFFFFF)
                    baseConvHex.Text = value.ToString("X");
            }
            catch
            {
                baseConvHex.Text = "";
            }
        }
        private void baseConvHex_TextChanged(object sender, EventArgs e)
        {
            try
            {
                long value = Convert.ToInt64(baseConvHex.Text, 16);
                baseConvDec.Text = value.ToString();
            }
            catch
            {
                baseConvDec.Text = "";
            }
        }
        
        #endregion
    }
}
