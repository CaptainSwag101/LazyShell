using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LazyShell.Sprites
{
    public partial class CoordAdjustForm : Controls.NewForm
    {
        #region Variables

        public Point Point;
        public bool ApplyToAll;

        #endregion

        // Constructor
        public CoordAdjustForm()
        {
            InitializeComponent();
        }

        #region Event Handlers

        private void CoordAdjust_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                buttonOK.PerformClick();
            else if (e.KeyData == Keys.Escape)
                buttonCancel.PerformClick();
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Point = new Point((int)coordX.Value, (int)coordY.Value);
            this.ApplyToAll = applyToAll.Checked;
            this.Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion
    }
}
