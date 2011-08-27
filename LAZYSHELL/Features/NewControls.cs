using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
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
                ControlPaint.DrawMenuGlyph(e.Graphics, check, MenuGlyph.Checkmark, this.ForeColor, Color.Transparent);
            Rectangle checkBox = new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Height - 6, e.Bounds.Height - 6);
            e.Graphics.DrawRectangle(new Pen(this.ForeColor), checkBox);
        }
    }
    public class NewListView : ListView
    {
        public NewListView()
        {
            //Activate double buffering
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            //Enable the OnNotifyMessage event so we get a chance to filter out 
            // Windows messages before they get to the form's WndProc
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);
        }
        protected override void OnNotifyMessage(Message m)
        {
            //Filter out the WM_ERASEBKGND message
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }
    }
    public class NewRichTextBox : RichTextBox
    {
        private const int WM_SETREDRAW = 0x000B;
        private const int WM_USER = 0x400;
        private const int EM_GETEVENTMASK = (WM_USER + 59);
        private const int EM_SETEVENTMASK = (WM_USER + 69);
        [DllImport("user32", CharSet = CharSet.Auto)]
        private extern static IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);
        IntPtr eventMask = IntPtr.Zero;

        public NewRichTextBox()
        {
        }
        public void BeginUpdate()
        {
            // Stop redrawing:
            SendMessage(this.Handle, WM_SETREDRAW, 0, IntPtr.Zero);
            // Stop sending of events:
            eventMask = SendMessage(this.Handle, EM_GETEVENTMASK, 0, IntPtr.Zero);
        }
        public void EndUpdate()
        {
            // turn on events
            SendMessage(this.Handle, EM_SETEVENTMASK, 0, eventMask);
            // turn on redrawing
            SendMessage(this.Handle, WM_SETREDRAW, 1, IntPtr.Zero);
            // this forces a repaint, which for some reason is necessary in some cases.
            this.Invalidate();
        }
    }
    public class NewToolStrip : ToolStrip
    {
        private const int WM_PAINT = 0x0F;
        private bool enablePaint = true;
        /// <summary>
        /// Manually enables or disables painting of the TreeView.
        /// </summary>
        public bool EnablePaint { get { return enablePaint; } set { enablePaint = value; } }
        public NewToolStrip()
        {
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_PAINT:
                    if (EnablePaint)
                        base.WndProc(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
    }
    public class NewTreeView : TreeView
    {
        private const int WM_ERASEBKGND = 0x14;
        private const int WM_PAINT = 0x0F;
        private bool enablePaint = true;
        /// <summary>
        /// Manually enables or disables painting of the TreeView.
        /// </summary>
        public bool EnablePaint { get { return enablePaint; } set { enablePaint = value; } }
        public NewTreeView()
        {
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_PAINT:
                    if (EnablePaint)
                        base.WndProc(ref m);
                    break;
                case WM_ERASEBKGND:
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
    }
    public class NewPanel : Panel
    {
        private const int WM_ERASEBKGND = 0x14;
        private const int WM_PAINT = 0x0F;
        private bool enablePaint = true;
          /// <summary>
        /// Manually enables or disables painting of the TreeView.
        /// </summary>
        public bool EnablePaint { get { return enablePaint; } set { enablePaint = value; } }
        public NewPanel()
        {
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_PAINT:
                    if (EnablePaint)
                        base.WndProc(ref m);
                    break;
                case WM_ERASEBKGND:
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
  }
}
