using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace LazyShell
{
    public partial class LineSeparator : UserControl
    {
        public LineDirection LineDirection { get; set; }
        public LineSeparator()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(LineSeparator_Paint);
            this.MaximumSize = new Size(2, 2000);
            this.MinimumSize = new Size(2, 0);
            this.Width = 350;
        }
        private void LineSeparator_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen dark = new Pen(SystemColors.ControlDark);
            Pen lite = new Pen(SystemColors.Window);
            if (LineDirection == LineDirection.Horizontal)
            {
                g.DrawLine(dark, new Point(0, 0), new Point(this.Width, 0));
                g.DrawLine(lite, new Point(0, 1), new Point(this.Width, 1));
            }
            else if (LineDirection == LineDirection.Vertical)
            {
                g.DrawLine(dark, new Point(0, 0), new Point(0, this.Height));
                g.DrawLine(lite, new Point(1, 0), new Point(1, this.Height));
            }
        }
    }
    public enum LineDirection
    {
        Vertical, Horizontal
    }
}
