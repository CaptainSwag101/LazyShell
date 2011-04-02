using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public class NewCheckedListBox : CheckedListBox
    {
        public NewCheckedListBox()
            : base()
        {
        }
        public new event DrawItemEventHandler DrawItem;
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (DrawItem != null)
                DrawItem(this, e);
            Font drawFont = e.Font;
            Rectangle check = new Rectangle(e.Bounds.X + 1, e.Bounds.Y, e.Bounds.Height, e.Bounds.Height);
            if (this.CheckedIndices.Contains(e.Index))
                ControlPaint.DrawMenuGlyph(e.Graphics, check, MenuGlyph.Checkmark, this.ForeColor, this.BackColor);
            Rectangle checkBox = new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Height - 6, e.Bounds.Height - 6);
            e.Graphics.DrawRectangle(new Pen(this.ForeColor), checkBox);
        }
    }
}
