using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
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
}
