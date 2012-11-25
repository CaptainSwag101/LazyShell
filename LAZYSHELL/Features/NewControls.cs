using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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
    public class NewForm : Form
    {
        private Timer timer = new Timer();
        private int originalExStyle = -1;
        private bool antiFlicker = true;
        //
        private void DisableAntiFlicker()
        {
            // return if already disabled
            if (!antiFlicker)
                return;
            antiFlicker = false;
            this.MaximizeBox = true;
        }
        private void EnableAntiFlicker()
        {
            // return if already enabled
            if (antiFlicker)
                return;
            antiFlicker = true;
            this.MaximizeBox = true;
        }
        //
        protected override CreateParams CreateParams
        {
            get
            {
                if (originalExStyle == -1)
                    originalExStyle = base.CreateParams.ExStyle;
                CreateParams cp = base.CreateParams;
                if (antiFlicker)
                    cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
                else
                    cp.ExStyle = originalExStyle;
                return cp;
            }
        }
        // disables anti-flicker when activated
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            timer.Start();
        }
        // enables anti-flicker when deactivated
        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            EnableAntiFlicker();
        }
        // set timer for waiting until all controls drawn
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            timer.Tick += new EventHandler(delegate
                {
                    timer.Stop(); DisableAntiFlicker();
                });
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
        //
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
        private const int WM_SETREDRAW = 0x0B;
        private const int WM_PAINT = 0x0F;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private bool enablePaint = true;
        public NewToolStrip()
        {
        }
        public void SuspendDrawing()
        {
            SendMessage(this.Handle, WM_SETREDRAW, false, 0);
        }
        public void ResumeDrawing()
        {
            SendMessage(this.Handle, WM_SETREDRAW, true, 0);
            Refresh();
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_PAINT:
                    if (enablePaint)
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
        private const int SB_HORZ = 0x0;
        private const int SB_VERT = 0x1;
        private const int WM_SETREDRAW = 0x0B;
        private const int WM_LBUTTONDBLCLK = 0x203;
        private const int WM_ERASEBKGND = 0x14;
        private const int WM_PAINT = 0x0F;
        //
        private Point scrollPos = new Point(0, 0);
        //
        private bool enablePaint = true;
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        [DllImport("user32.dll")]
        private static extern bool LockWindowUpdate(IntPtr hWndLock);
        // Get / set the scrollbar position of the treeview
        [DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern int GetScrollPos(int hWnd, int nBar);
        [DllImport("user32.dll")]
        public static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);
        //
        public NewTreeView()
        {
        }
        /// <summary>
        /// Returns the full index of the currently selected node in the treeview.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int GetFullIndex()
        {
            return GetFullIndex(this.SelectedNode);
        }
        /// <summary>
        /// Returns the full index of a specified node in the treeview.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int GetFullIndex(TreeNode node)
        {
            int fullIndex = -1;
            int index = 0;
            foreach (TreeNode child in this.Nodes)
            {
                if (child == node)
                {
                    fullIndex = index;
                    break;
                }
                else
                    GetFullIndex(node, child, ref fullIndex, ref index);
                if (fullIndex >= 0)
                    break;
            }
            return fullIndex;
        }
        private void GetFullIndex(TreeNode node, TreeNode parent, ref int fullIndex, ref int index)
        {
            index++;
            foreach (TreeNode child in parent.Nodes)
            {
                if (child == node)
                {
                    fullIndex = index;
                    break;
                }
                else
                    GetFullIndex(node, child, ref fullIndex, ref index);
                if (fullIndex >= 0)
                    break;
            }
        }
        public int GetFullParentIndex()
        {
            return GetFullParentIndex(this.SelectedNode);
        }
        /// <summary>
        /// Returns the full index of a specified node's parent in the treeview -- indexes are incremented only if they contain child nodes.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int GetFullParentIndex(TreeNode node)
        {
            int fullParentIndex = -1;
            int parentIndex = -1;
            int index = 0;
            foreach (TreeNode child in this.Nodes)
            {
                if (child == node)
                {
                    fullParentIndex = parentIndex;
                    break;
                }
                else
                    GetFullParentIndex(node, child, ref fullParentIndex, ref index);
                if (fullParentIndex >= 0)
                    break;
            }
            return fullParentIndex;
        }
        private void GetFullParentIndex(TreeNode node, TreeNode parent, ref int fullParentIndex, ref int index)
        {
            int parentIndex = parent.Nodes.Count > 0 ? index++ : index;
            foreach (TreeNode child in parent.Nodes)
            {
                if (child == node)
                {
                    fullParentIndex = parentIndex;
                    break;
                }
                else
                    GetFullParentIndex(node, child, ref fullParentIndex, ref index);
                if (fullParentIndex >= 0)
                    break;
            }
        }
        /// <summary>
        /// Selects a node in the treeview based on a specified full index.
        /// </summary>
        /// <param name="fullIndex"></param>
        /// <returns></returns>
        public void SelectNode(int fullIndex)
        {
            int index = 0;
            TreeNode node = null;
            foreach (TreeNode child in this.Nodes)
            {
                if (index == fullIndex)
                {
                    node = child;
                    break;
                }
                else
                    SelectNode(fullIndex, child, ref node, ref index);
                if (node != null)
                    break;
            }
            if (node != null)
                this.SelectedNode = node;
        }
        private void SelectNode(int fullIndex, TreeNode parent, ref TreeNode node, ref int index)
        {
            index++;
            foreach (TreeNode child in parent.Nodes)
            {
                if (index == fullIndex)
                {
                    node = child;
                    break;
                }
                else
                    SelectNode(fullIndex, child, ref node, ref index);
                if (node != null)
                    break;
            }
        }
        /// <summary>
        /// Returns a node in the treeview based on a specified full index.
        /// </summary>
        /// <param name="fullIndex"></param>
        /// <returns></returns>
        public TreeNode GetNode(int fullIndex)
        {
            int index = 0;
            TreeNode node = null;
            foreach (TreeNode child in this.Nodes)
            {
                if (index == fullIndex)
                {
                    node = child;
                    break;
                }
                else
                    GetNode(fullIndex, child, ref node, ref index);
                if (node != null)
                    break;
            }
            return node;
        }
        private void GetNode(int fullIndex, TreeNode parent, ref TreeNode node, ref int index)
        {
            index++;
            foreach (TreeNode child in parent.Nodes)
            {
                if (index == fullIndex)
                {
                    node = child;
                    break;
                }
                else
                    GetNode(fullIndex, child, ref node, ref index);
                if (node != null)
                    break;
            }
        }
        //
        public new void BeginUpdate()
        {
            enablePaint = false;
            LockWindowUpdate(this.Handle);
            scrollPos = new Point(
                GetScrollPos((int)this.Handle, SB_HORZ),
                GetScrollPos((int)this.Handle, SB_VERT));
            SendMessage(this.Handle, WM_SETREDRAW, (IntPtr)0, IntPtr.Zero);
        }
        public new void EndUpdate()
        {
            SendMessage(this.Handle, WM_SETREDRAW, (IntPtr)1, IntPtr.Zero);
            SetScrollPos((IntPtr)this.Handle, SB_HORZ, scrollPos.X, true);
            SetScrollPos((IntPtr)this.Handle, SB_VERT, scrollPos.Y, true);
            LockWindowUpdate(IntPtr.Zero);
            enablePaint = true;
        }
        //
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_PAINT:
                    if (enablePaint)
                        base.WndProc(ref m);
                    break;
                case WM_ERASEBKGND:
                    break;
                case WM_LBUTTONDBLCLK:
                    // disable double-click on checkbox to fix Microsoft Vista bug
                    TreeViewHitTestInfo info = HitTest(new Point((int)m.LParam));
                    if (info != null && info.Location == TreeViewHitTestLocations.StateImage)
                        m.Result = IntPtr.Zero;
                    else
                        base.WndProc(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
    }
    public class NewPanel : Panel
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 0x0B;
        public NewPanel()
        {
        }
        protected override Point ScrollToControl(Control activeControl)
        {
            return this.DisplayRectangle.Location;
        }
        public void SuspendDrawing()
        {
            SendMessage(this.Handle, WM_SETREDRAW, false, 0);
        }
        public void ResumeDrawing()
        {
            SendMessage(this.Handle, WM_SETREDRAW, true, 0);
            Refresh();
        }
    }
    public class NewListBox : ListBox
    {
        private int lastSelectedIndex = -1;
        public int LastSelectedIndex { get { return lastSelectedIndex; } set { lastSelectedIndex = value; } }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
        }
    }
    public class NewPictureBox : PictureBox
    {
        public NewPictureBox()
        {
            this.SetStyle(ControlStyles.Selectable, true);
            this.TabStop = true;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.Focus();
            base.OnMouseDown(e);
        }
        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Up || keyData == Keys.Down)
                return true;
            if (keyData == Keys.Left || keyData == Keys.Right)
                return true;
            return base.IsInputKey(keyData);
        }
        protected override void OnEnter(EventArgs e)
        {
            this.Invalidate();
            base.OnEnter(e);
        }
        protected override void OnLeave(EventArgs e)
        {
            this.Invalidate();
            base.OnLeave(e);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
    public class NewGroupBox : GroupBox
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            Pen border = new Pen(SystemColors.ControlText);
            border.Width = 2; border.Alignment = PenAlignment.Inset;
            Brush fillHeader = new SolidBrush(SystemColors.ControlDarkDark);
            Brush fillBody = new SolidBrush(SystemColors.ControlDark);
            Rectangle header = new Rectangle(0, 0, this.Width, 18);
            Rectangle body = new Rectangle(0, 16, this.Width, this.Height - 16);
            e.Graphics.FillRectangle(fillBody, body);
            e.Graphics.FillRectangle(fillHeader, header);
            e.Graphics.DrawRectangle(border, body);
            e.Graphics.DrawRectangle(border, header);
            //
            Brush foreColor = new SolidBrush(SystemColors.Control);
            Font font = new Font(this.Font.FontFamily, this.Font.Size - 1, FontStyle.Bold);
            string text = this.Text.ToUpper();
            e.Graphics.DrawString(text, font, foreColor, 2, 2);
        }
    }
    public class NewProgressBar : System.Windows.Forms.ProgressBar
    {
        public NewProgressBar()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.Text = this.Name;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // draw progress fill
            SolidBrush foreColor = new SolidBrush(this.ForeColor);
            int width = (int)((double)this.Value / (double)this.Maximum * (double)this.Width);
            e.Graphics.FillRectangle(foreColor, 0, 0, width, this.Height);
            // draw text string
            SizeF sizeF = e.Graphics.MeasureString(this.Text, this.Font);
            PointF pointF = new PointF(this.Width / 2 - (sizeF.Width / 2), this.Height / 2 - (sizeF.Height / 2));
            foreColor = new SolidBrush(SystemColors.ControlText);
            Font font = new Font(this.Parent.Font.FontFamily, 7F, FontStyle.Bold);
            e.Graphics.DrawString(this.Text, font, foreColor, pointF);
        }
    }
}
