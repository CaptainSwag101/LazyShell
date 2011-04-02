using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
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
}
