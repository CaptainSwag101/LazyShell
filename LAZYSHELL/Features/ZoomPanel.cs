using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public partial class ZoomPanel : Form
    {
        private PictureBox pictureBox;
        public PictureBox PictureBox
        {
            get { return pictureBox; }
            set
            {
                pictureBox = value;
                this.Controls.Clear();
                this.Controls.Add(pictureBox);
            }
        }
        public ZoomPanel()
        {
            InitializeComponent();
        }
    }
}
