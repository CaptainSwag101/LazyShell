using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LazyShell.Areas
{
    public partial class OpacityForm : Controls.NewForm
    {
        #region Variables

        private PictureBox picture;
        private Overlay overlay;

        #endregion

        // Constructor
        public OpacityForm(PictureBox picture, Overlay overlay)
        {
            this.picture = picture;
            this.overlay = overlay;
            //
            InitializeComponent();
        }

        #region Event Handlers

        private void opacityLevel_ValueChanged(object sender, EventArgs e)
        {
            this.Text = "OPACITY LEVEL  =  " + opacityLevel.Value + "%";
            overlay.Opacity = opacityLevel.Value;
            picture.Invalidate();
        }
        private void OpacityForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
                this.Location = new Point(Cursor.Position.X + 20, Cursor.Position.Y + 20);
        }

        #endregion
    }
}
