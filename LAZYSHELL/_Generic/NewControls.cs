using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using LazyShell.Properties;
using WeifenLuo.WinFormsUI.Docking;

namespace LazyShell.Controls
{
    public class HeaderLabel : Label
    {
        private Color backColor = SystemColors.GradientActiveCaption;
        public override Color BackColor
        {
            get
            {
                return backColor;
            }
            set
            {
                backColor = value;
            }
        }
        private Font font = new Font("Tahoma", 8.25F, FontStyle.Regular);
        public override Font Font
        {
            get
            {
                return font;
            }
            set
            {
                font = value;
            }
        }
        private Color foreColor = SystemColors.WindowText;
        public override Color ForeColor
        {
            get
            {
                return foreColor;
            }
            set
            {
                foreColor = value;
            }
        }
        public HeaderLabel()
            : base()
        {
            this.Padding = new Padding(3, 0, 0, 0);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            var region = new Rectangle(0, 0, this.Width, this.Height + 5);
            var brush = new LinearGradientBrush(region, 
                SystemColors.GradientActiveCaption, 
                SystemColors.GradientInactiveCaption, 
                LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(brush, region);

            // Finished
            base.OnPaint(e);
        }
    }
    public class NewBackgroundWorker : BackgroundWorker
    {
        public bool RunPending { get; set; }
        protected override void OnDoWork(DoWorkEventArgs e)
        {
            if (this.IsBusy)
            {
                this.CancelAsync();
                this.RunPending = true;
            }
            else
                base.OnDoWork(e);
        }
        protected override void OnRunWorkerCompleted(RunWorkerCompletedEventArgs e)
        {
            this.RunPending = false;
            base.OnRunWorkerCompleted(e);
        }
    }
    public class NewCheckedListBox : CheckedListBox
    {
        // Constructor
        public NewCheckedListBox()
		{ }

        #region Drawing

        // Variables
        public new event DrawItemEventHandler DrawItem;

        // Event Handlers
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

        #endregion
    }

    public class DockForm : DockContent
    {
        public DockForm()
        {
            this.DoubleBuffered = true;
            this.Font = new Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.HideOnClose = true;
            this.Icon = global::LazyShell.Properties.Resources.LazyShell_icon;
        }

        #region Form Status

        // Public accessors
        public History History { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether any controls in the form have been modified by the user.
        /// </summary>
        public bool Modified { get; set; }
        /// <summary>
        /// Retrieves the height of the form's title bar.
        /// </summary>
        public int TitleHeight
        {
            get
            {
                var screenRectangle = RectangleToScreen(this.ClientRectangle);
                return screenRectangle.Top - this.Top;
            }
        }
        private Controls.NewToolStripButton toggleButton;
        /// <summary>
        /// The button that controls the visible status of the form.
        /// </summary>
        public NewToolStripButton ToggleButton
        {
            get { return toggleButton; }
            set
            {
                toggleButton = value;
                toggleButton.Form = this;
            }
        }
        /// <summary>
        /// Gets or sets a value indicating that the form is currently updating its controls.
        /// </summary>
        public bool Updating
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets a value indicating whether a form is currently closing.
        /// </summary>
        public bool IsClosing { get; set; }

        #endregion

        #region Event Handlers

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // Reduces flickering, waits until all controls painted before showing form
                //cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.ToggleButton != null)
                this.ToggleButton.Checked = this.DockState != DockState.Hidden;
        }

        #endregion
    }

    public class NewForm : Form
    {
        public NewForm()
        {
            this.DoubleBuffered = true;
            this.Font = new Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Icon = global::LazyShell.Properties.Resources.LazyShell_icon;
            this.Location = new Point(20, 20);
            this.SnapEdgeBoundary = 10;
            this.SnapToEdges = true;
            this.StartPosition = FormStartPosition.Manual;
        }

        #region Form Status

        // Public accessors
        public History History { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether any controls in the form have been modified by the user.
        /// </summary>
        public bool Modified { get; set; }
        /// <summary>
        /// Retrieves the height of the form's title bar.
        /// </summary>
        public int TitleHeight
        {
            get
            {
                var screenRectangle = RectangleToScreen(this.ClientRectangle);
                return screenRectangle.Top - this.Top;
            }
        }
        private Controls.NewToolStripButton toggleButton;
        /// <summary>
        /// The button that controls the visible status of the form.
        /// </summary>
        public NewToolStripButton ToggleButton
        {
            get { return toggleButton; }
            set
            {
                toggleButton = value;
                toggleButton.Form = this;
            }
        }
        /// <summary>
        /// Gets or sets a value indicating that the form is currently updating its controls.
        /// </summary>
        public bool Updating
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets a value indicating whether a form is currently closing.
        /// </summary>
        public bool IsClosing { get; set; }

	    protected DockPanel dock;
        /// <summary>
        /// The DockPanel container used in this form.
        /// </summary>
        public DockPanel DockPanel
		{
	        get
	        {
		        return dock;
	        }
	        set
	        {
				dock = value;
	        }
		}

        #endregion

        #region Snap To Forms

        // Private variables
        private List<NewForm> attachedToForms = new List<NewForm>();
        private Edges prevEdges = new Edges();
        private bool snapActive = false;

        // Public accessors
        public bool DisableSnap { get; set; }
        /// <summary>
        /// Minimum distance in pixels between the edges of forms for snapping.
        /// </summary>
        public int SnapEdgeBoundary { get; set; }
        public bool SnapToEdges { get; set; }

        // Methods
        /// <summary>
        /// Retrieves a list of forms that are attached to this form.
        /// </summary>
        /// <returns></returns>
        private List<NewForm> AttachedToForms()
        {
            var attachedToForms = new List<NewForm>();
            // look for forms attached to this form
            foreach (Form form in Application.OpenForms)
            {
                // skip if null or is this form
                if (form == null || form == this || !(form is NewForm))
                    continue;
                // only if within horizontal boundaries of current form
                if (this.Left < form.Right + SnapEdgeBoundary && this.Right >= form.Left - SnapEdgeBoundary)
                {
                    if (form.Top == this.Bottom && !attachedToForms.Contains((NewForm)form))
                    {
                        attachedToForms.Add((NewForm)form);
                        // now look for forms attached to the current form
                        foreach (Form form2 in Application.OpenForms)
                        {
                            if (form2 == null || form2 == this || form2 == form || !(form2 is NewForm))
                                continue;
                            // only if within horizontal boundaries of form2
                            if (form.Left < form2.Right + SnapEdgeBoundary && form.Right >= form2.Left - SnapEdgeBoundary)
                            {
                                if (form2.Top == form.Bottom && !attachedToForms.Contains((NewForm)form2))
                                    attachedToForms.Add((NewForm)form2);
                            }
                        }
                    }
                }
                // only if within vertical boundaries of current form
                if (this.Top < form.Bottom + SnapEdgeBoundary && this.Bottom >= form.Top - SnapEdgeBoundary)
                {
                    if (form.Left == this.Right && !attachedToForms.Contains((NewForm)form))
                    {
                        attachedToForms.Add((NewForm)form);
                        // now look for forms attached to the current form
                        foreach (Form form2 in Application.OpenForms)
                        {
                            if (form2 == null || form2 == this || form2 == form || !(form2 is NewForm))
                                continue;
                            // only if within vertical boundaries of form2
                            if (form.Top < form2.Bottom + SnapEdgeBoundary && form.Bottom >= form2.Top - SnapEdgeBoundary)
                            {
                                if (form2.Left == form.Right && !attachedToForms.Contains((NewForm)form2))
                                    attachedToForms.Add((NewForm)form2);
                            }
                        }
                    }
                }
            }
            return attachedToForms;
        }
        /// <summary>
        /// Snaps the current form to all open forms in the application
        /// </summary>
        /// <param name="resizing">Sets whether to recognize the parent function as a resizing operation.</param>
        private SnapResult SnapToForm(bool resizing)
        {
            SnapResult snapResult = new SnapResult();
            FormCollection snapToForms = Application.OpenForms;
            if (!SnapToEdges || DisableSnap || snapActive || snapToForms == null || snapToForms.Count == 0)
                return snapResult;
            snapActive = true;
            bool snappedToLeftEdge = false;
            bool snappedToRightEdge = false;
            bool snappedToTopEdge = false;
            bool snappedToBottomEdge = false;
            // snap the current form to any open forms within the snapBoundary
            foreach (Form form in snapToForms)
            {
                if (form == null || form == this || !(form is NewForm) || !((NewForm)form).SnapToEdges)
                    continue;
                #region Snap Horizontally
                // only snap this form horizontally if within vertical boundaries of current form
                if (this.Top < form.Bottom + SnapEdgeBoundary && this.Bottom >= form.Top - SnapEdgeBoundary)
                {
                    // snap the right edge of this form to the left edge of the current form
                    if (this.Right >= form.Left - SnapEdgeBoundary && this.Right < form.Left + SnapEdgeBoundary && this.Right != form.Left)
                    {
                        if (!snappedToLeftEdge)
                        {
                            if (!resizing)
                                this.Left = form.Left - this.Width;
                            else
                                this.Width += form.Left - this.Right; // add distance between edges to width
                            snappedToLeftEdge = true;
                        }
                    }
                    // snap the left edge of this form to the left edge of the current form
                    else if (this.Left >= form.Left - SnapEdgeBoundary && this.Left < form.Left + SnapEdgeBoundary && this.Left != form.Left)
                    {
                        if (!snappedToLeftEdge)
                        {
                            if (!resizing)
                            {
                                this.Left = form.Left;
                                snappedToLeftEdge = true;
                            }
                        }
                    }
                    // snap the left edge of this form to the right edge of the current form
                    else if (this.Left >= form.Right - SnapEdgeBoundary && this.Left < form.Right + SnapEdgeBoundary && this.Left != form.Right)
                    {
                        if (!snappedToRightEdge)
                        {
                            if (!resizing)
                            {
                                this.Left = form.Right;
                                snappedToRightEdge = true;
                            }
                        }
                    }
                    // snap the right edge of this form to the right edge of the current form
                    else if (this.Right >= form.Right - SnapEdgeBoundary && this.Right < form.Right + SnapEdgeBoundary && this.Right != form.Right)
                    {
                        if (!snappedToRightEdge)
                        {
                            if (!resizing)
                                this.Left = form.Right - this.Width;
                            else
                                this.Width += form.Right - this.Right; // add distance between edges to width
                            snappedToRightEdge = true;
                        }
                    }
                }
                #endregion
                #region Snap Vertically
                // only snap this form vertically if within horizontal boundaries of current form
                if (this.Left < form.Right + SnapEdgeBoundary && this.Right >= form.Left - SnapEdgeBoundary)
                {
                    // snap the bottom edge of this form to the top edge of the current form
                    if (this.Bottom >= form.Top - SnapEdgeBoundary && this.Bottom < form.Top + SnapEdgeBoundary && this.Bottom != form.Top)
                    {
                        if (!snappedToTopEdge)
                        {
                            if (!resizing)
                                this.Top = form.Top - this.Height;
                            else
                                this.Height += form.Top - this.Bottom; // add distance between edges to height
                            snappedToTopEdge = true;
                        }
                    }
                    // snap the top edge of this form to the top edge of the current form
                    else if (this.Top >= form.Top - SnapEdgeBoundary && this.Top < form.Top + SnapEdgeBoundary && this.Top != form.Top)
                    {
                        if (!snappedToTopEdge)
                        {
                            if (!resizing)
                            {
                                this.Top = form.Top;
                                snappedToTopEdge = true;
                            }
                        }
                    }
                    // snap the top edge of this form to the bottom edge of the current form
                    else if (this.Top >= form.Bottom - SnapEdgeBoundary && this.Top < form.Bottom + SnapEdgeBoundary && this.Top != form.Bottom)
                    {
                        if (!snappedToBottomEdge)
                        {
                            if (!resizing)
                            {
                                this.Top = form.Bottom;
                                snappedToBottomEdge = true;
                            }
                        }
                    }
                    // snap the bottom edge of this form to the bottom edge of the current form
                    else if (this.Bottom >= form.Bottom - SnapEdgeBoundary && this.Bottom < form.Bottom + SnapEdgeBoundary && this.Bottom != form.Bottom)
                    {
                        if (!snappedToBottomEdge)
                        {
                            if (!resizing)
                                this.Top = form.Bottom - this.Height;
                            else
                                this.Height += form.Bottom - this.Bottom;
                            snappedToBottomEdge = true;
                        }
                    }
                }
                #endregion
            }
            snapActive = false;
            snapResult.Left = snappedToLeftEdge;
            snapResult.Right = snappedToRightEdge;
            snapResult.Top = snappedToTopEdge;
            snapResult.Bottom = snappedToBottomEdge;
            return snapResult;
        }
        /// <summary>
        /// Disables snap to edges for this and all owned forms.
        /// </summary>
        public void DisableSnapToEdges()
        {
            foreach (NewForm form in this.OwnedForms)
                form.SnapToEdges = false;
        }
        /// <summary>
        /// Enables snap to edges for this and all owned forms.
        /// </summary>
        public void EnableSnapToEdges()
        {
            foreach (NewForm form in this.OwnedForms)
                form.SnapToEdges = true;
        }

        // Internal structures
        private struct Edges
        {
            public int Left, Right, Top, Bottom;
        }
        private struct SnapResult
        {
            public bool Left, Top, Right, Bottom;
        }

        #endregion

        #region Event Handlers

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // Reduces flickering, waits until all controls painted before showing form
                //cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Only hide if it's an owned form and it's owner is not closing
            if (!this.Modal && this.Owner != null && e.CloseReason != CloseReason.FormOwnerClosing)
            {
                this.Hide();
                e.Cancel = true;

                // Uncheck the ToggleButton
                if (ToggleButton != null)
                    ToggleButton.Checked = false;
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (!SnapToEdges || DisableSnap)
                return;
            SnapToForm(true);
        }
        protected override void OnResizeBegin(EventArgs e)
        {
            base.OnResizeBegin(e);
            if (!SnapToEdges || DisableSnap)
                return;
            /* temporarily disable snapping for owned forms to eliminate
             * interference between moving owner form as a principle
             * magnet and snapping operations for owned forms */
            foreach (Form form in Application.OpenForms)
            {
                // only disable if owner is this form
                if (form.Owner == this && form is NewForm)
                    ((NewForm)form).DisableSnap = true;
            }
        }
        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            if (!SnapToEdges || DisableSnap)
                return;
            // remove universal disable for snapping operations
            foreach (Form form in Application.OpenForms)
            {
                if (form is NewForm)
                    ((NewForm)form).DisableSnap = false;
            }
        }
        protected override void OnLocationChanged(EventArgs e)
        {
            // run the default event
            base.OnLocationChanged(e);
            //if (!SnapToEdges || DisableSnap)
            //    return;
            //// only if attached to at least one form and not an owned form
            //if (attachedToForms.Count > 0 && this.Owner == null)
            //{
            //    // glues forms currently attached to this form
            //    foreach (var form in attachedToForms)
            //    {
            //        // skip if null, is this form, or this form is NOT its owner
            //        if (form == null || form == this || form.Owner != this)
            //            continue;
            //        // make same changes to this form's location to owned forms
            //        form.Top += this.Top - prevEdges.Top;
            //        form.Left += this.Left - prevEdges.Left;
            //    }
            //}
            //else
            SnapToForm(false); // otherwise perform snapping operation
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.ToggleButton != null)
                this.ToggleButton.Checked = this.Visible;
        }

        #endregion

        #region Windows commands

        private const int WM_MOVING = 0x0216;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_MOVING)
            {
                prevEdges.Left = this.Left;
                prevEdges.Right = this.Right;
                prevEdges.Top = this.Top;
                prevEdges.Bottom = this.Bottom;
                // set global variable for access in LocationChanged event
                this.attachedToForms = AttachedToForms();
            }
            base.WndProc(ref m);
        }

        #endregion
    }

    public class NewListView : ListView
    {
        // Constructor
        public NewListView()
        {
            //Activate double buffering
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            //Enable the OnNotifyMessage event so we get a chance to filter out 
            // Windows messages before they get to the form's WndProc
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);
        }

        // Event Handlers
        protected override void OnNotifyMessage(Message m)
        {
            //Filter out the WM_ERASEBKGND message
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }
    }

    /// <summary>
    /// Custom TextBox class to manage the control's paint events.
    /// </summary>
    public class NewRichTextBox : RichTextBox
    {
        // Constructor
        public NewRichTextBox()
        {
        }

        #region Windows messages

        private IntPtr EVENTMASK = IntPtr.Zero;
        private const int WM_SETREDRAW = 0x000B;
        private const int WM_USER = 0x400;
        private const int EM_GETEVENTMASK = (WM_USER + 59);
        private const int EM_SETEVENTMASK = (WM_USER + 69);
        [DllImport("user32", CharSet = CharSet.Auto)]
        private extern static IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);

        // Drawing
        public void BeginUpdate()
        {
            // Stop redrawing:
            SendMessage(this.Handle, WM_SETREDRAW, 0, IntPtr.Zero);
            // Stop sending of events:
            EVENTMASK = SendMessage(this.Handle, EM_GETEVENTMASK, 0, IntPtr.Zero);
        }
        public void EndUpdate()
        {
            // turn on events
            SendMessage(this.Handle, EM_SETEVENTMASK, 0, EVENTMASK);
            // turn on redrawing
            SendMessage(this.Handle, WM_SETREDRAW, 1, IntPtr.Zero);
            // this forces a repaint, which for some reason is necessary in some cases.
            this.Invalidate();
        }

        #endregion
    }

    public class NewToolStrip : ToolStrip
    {
        // Constructor
        public NewToolStrip()
        {
        }

        #region Windows commands

        private const int WM_SETREDRAW = 0x0B;
        private const int WM_PAINT = 0x0F;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private bool enablePaint = true;

        // Methods
        public void SuspendDrawing()
        {
            SendMessage(this.Handle, WM_SETREDRAW, false, 0);
        }
        public void ResumeDrawing()
        {
            SendMessage(this.Handle, WM_SETREDRAW, true, 0);
            Refresh();
        }

        // Windows process
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

        #endregion
    }

    public class NewTreeView : TreeView
    {
        // Constructor
        public NewTreeView()
        {
        }

        #region Node Retrieval

        // Public accessors
        public TreeNode LastNode
        {
            get
            {
                if (this.Nodes.Count > 0)
                    return this.Nodes[this.Nodes.Count - 1];
                return new TreeNode();
            }
            set
            {
                if (this.Nodes.Count > 0)
                    this.Nodes[this.Nodes.Count - 1] = value;
            }
        }

        // Methods
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
        /// <summary>
        /// Returns the full index of the selected node in the TreeView. Indexes are incremented only if they contain child nodes.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int GetFullParentIndex()
        {
            return GetFullParentIndex(this.SelectedNode);
        }

        /// <summary>
        /// Returns the full index of a specified node's parent in the TreeView. Indexes are incremented only if they contain child nodes.
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

        #endregion

        #region Drawing

        // Private variables
        private Point scrollPos = new Point(0, 0);
        private bool enablePaint = true;

        // Methods
        /// <summary>
        /// Disables any redrawing of the TreeView.
        /// </summary>
        public new void BeginUpdate()
        {
            enablePaint = false;
            LockWindowUpdate(this.Handle);
            scrollPos = new Point(
                GetScrollPos((int)this.Handle, SB_HORZ),
                GetScrollPos((int)this.Handle, SB_VERT));
            SendMessage(this.Handle, WM_SETREDRAW, (IntPtr)0, IntPtr.Zero);
        }
        /// <summary>
        /// Enables redrawing of the TreeView.
        /// </summary>
        public new void EndUpdate()
        {
            SendMessage(this.Handle, WM_SETREDRAW, (IntPtr)1, IntPtr.Zero);
            SetScrollPos((IntPtr)this.Handle, SB_HORZ, scrollPos.X, true);
            SetScrollPos((IntPtr)this.Handle, SB_VERT, scrollPos.Y, true);
            LockWindowUpdate(IntPtr.Zero);
            enablePaint = true;
        }

        #endregion

        #region Windows Messages

        // Variables
        private const int SB_HORZ = 0x0;
        private const int SB_VERT = 0x1;
        private const int WM_SETREDRAW = 0x0B;
        private const int WM_LBUTTONDBLCLK = 0x203;
        private const int WM_ERASEBKGND = 0x14;
        private const int WM_PAINT = 0x0F;

        // Methods
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        [DllImport("user32.dll")]
        private static extern bool LockWindowUpdate(IntPtr hWndLock);

        // Get/set the scrollbar position of the treeview
        [DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern int GetScrollPos(int hWnd, int nBar);
        [DllImport("user32.dll")]
        public static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);

        // Window process
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
                    // Disable double-click on checkbox to fix Microsoft Vista bug
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

        #endregion
    }

    public class NewListBox : ListBox
    {
        #region Variables

        private int lastSelectedIndex = -1;
        public int LastSelectedIndex
        {
            get { return lastSelectedIndex; }
            set { lastSelectedIndex = value; }
        }

        #endregion

        // Event Handlers
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
        }
    }

    public class NewPanel : Panel
    {
        // Constructor
        public NewPanel()
        {
        }

        #region Event Handlers

        // Scrolling
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            // only scroll with wheel if CTRL key not held
            if ((Control.ModifierKeys & Keys.Control) == 0)
                base.OnMouseWheel(e);
        }
        protected override Point ScrollToControl(Control activeControl)
        {
            return this.DisplayRectangle.Location;
        }

        #endregion

        #region Windows messages

        // Windows messages
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 0x0B;

        // Drawing
        public void SuspendDrawing()
        {
            SendMessage(this.Handle, WM_SETREDRAW, false, 0);
        }
        public void ResumeDrawing()
        {
            SendMessage(this.Handle, WM_SETREDRAW, true, 0);
            this.Parent.Refresh();
            Refresh();
        }

        #endregion
    }

    public class NewPictureBox : PictureBox
    {
        // Constructor
        public NewPictureBox()
        {
            this.zoomBox = new ZoomBox(zoomBoxZoom);
            this.SetStyle(ControlStyles.Selectable, true);
            this.TabStop = true;
        }

        #region Zooming

        // Private variables
        private int zoom = 1;
        private bool zoomEnabled = true;
        private ZoomBox zoomBox;
        private int zoomBoxZoom = 4;
        private bool zoomBoxEnabled = false;
        private Point zoomBoxPosition = new Point(32, 32);
        // Public accessors
        public int Zoom
        {
            get { return zoom; }
            set { zoom = value; }
        }
        public bool ZoomEnabled
        {
            get { return zoomEnabled; }
            set { zoomEnabled = value; }
        }
        public ZoomBox ZoomBox
        {
            get { return zoomBox; }
            set { zoomBox = value; }
        }
        public int ZoomBoxZoom
        {
            get { return zoomBoxZoom; }
            set { zoomBoxZoom = value; }
        }
        public bool ZoomBoxEnabled
        {
            get { return zoomBoxEnabled; }
            set
            {
                zoomBoxEnabled = value;
                if (!zoomBoxEnabled)
                    zoomBox.Visible = false;
                Cursor.Position = Cursor.Position;
            }
        }
        public Point ZoomBoxPosition
        {
            get { return zoomBoxPosition; }
            set { zoomBoxPosition = value; }
        }
        // Methods
        public void ZoomIn(int x, int y)
        {
            if (!zoomEnabled)
                return;
            if (this.Parent == null || zoom >= 8 ||
                Width >= 8192 || Height >= 8192)
                return;
            if (!(this.Parent is NewPanel))
                return;
            var parent = (NewPanel)this.Parent;
            parent.SuspendDrawing();
            //
            zoom *= 2;
            autoScrollPos = new Point(Math.Abs(this.Left), Math.Abs(this.Top));
            autoScrollPos.X += x;
            autoScrollPos.Y += y;
            this.Width *= 2;
            this.Height *= 2;
            parent.AutoScrollPosition = autoScrollPos;
            parent.VerticalScroll.SmallChange *= 2;
            parent.HorizontalScroll.SmallChange *= 2;
            parent.VerticalScroll.LargeChange *= 2;
            parent.HorizontalScroll.LargeChange *= 2;
            this.Invalidate();
            this.Focus();
            //
            parent.ResumeDrawing();
            parent.Invalidate();
        }
        public void ZoomOut(int x, int y)
        {
            if (!zoomEnabled)
                return;
            if (this.Parent == null || zoom <= 1)
                return;
            if (!(this.Parent is NewPanel))
                return;
            var parent = this.Parent as NewPanel;
            parent.SuspendDrawing();
            //
            zoom /= 2;
            autoScrollPos = new Point(Math.Abs(this.Left), Math.Abs(this.Top));
            autoScrollPos.X -= x / 2;
            autoScrollPos.Y -= y / 2;
            this.Width /= 2;
            this.Height /= 2;
            parent.AutoScrollPosition = autoScrollPos;
            parent.VerticalScroll.SmallChange /= 2;
            parent.HorizontalScroll.SmallChange /= 2;
            parent.VerticalScroll.LargeChange /= 2;
            parent.HorizontalScroll.LargeChange /= 2;
            this.Invalidate();
            this.Focus();
            //
            parent.ResumeDrawing();
            parent.Invalidate();
        }
        public void ZoomIn()
        {
            while (zoom < 8)
                ZoomIn(0, 0);
        }
        public void ZoomOut()
        {
            while (zoom > 1)
                ZoomOut(0, 0);
        }
        public void RefreshZoomBox()
        {
            if (zoomBoxEnabled && zoomBox != null)
            {
                zoomBox.Location = new Point(
                    MousePosition.X + zoomBoxPosition.X,
                    MousePosition.Y + zoomBoxPosition.Y);
                zoomBox.Visible = true;
                zoomBox.PictureBox.Invalidate();
            }
        }

        #endregion

        #region Drawing

        public void Draw(int x, int y, int width, int height, Color fill)
        {
            Graphics g = this.CreateGraphics();
            SolidBrush brush = new SolidBrush(fill);
            g.FillRectangle(brush, x, y, width, height);
        }
        public void Draw(Rectangle rectangle, Color fill)
        {
            Draw(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, fill);
        }
        /// <summary>
        /// Erases a rectangular portion of the image. Zoom must be pre-factored into parameter values.
        /// </summary>
        /// <param name="x">The X coord of the rectangle.</param>
        /// <param name="y">The Y coord of the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        public void Erase(int x, int y, int width, int height)
        {
            Rectangle temp = new Rectangle(x % 128, y % 128, width, height);
            if (temp.X < 0) temp.X += 128;
            if (temp.Y < 0) temp.Y += 128;
            Bitmap emptyblock = new Bitmap(Icons.TransparentBG.Clone(temp, PixelFormat.DontCare));
            Graphics g = this.CreateGraphics();
            g.DrawImage(emptyblock, x, y, width, height);
        }
        public void Erase(Rectangle rectangle)
        {
            Erase(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        #endregion

        #region Cursor Detection

        private Point autoScrollPos;
        private Point mousePosition;
        private bool mouseDown = false;
        private MouseButtons mouseButton;
        public void CallMouseMove()
        {
            base.OnMouseMove(new MouseEventArgs(MouseButtons.None, 0, -1, -1, 0));
        }
        public void CallMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
        }

        #endregion

        #region Methods

        public void Focus(Form form)
        {
            if (GetForegroundWindow() == form.Handle)
                Focus();
        }
        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Up || keyData == Keys.Down)
                return true;
            if (keyData == Keys.Left || keyData == Keys.Right)
                return true;
            return base.IsInputKey(keyData);
        }
        // Overridden functions
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
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            Cursor.Position = Cursor.Position;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            // if another mouse button pressed while this one pressed, cancel the operation
            if (mouseDown && mouseButton != e.Button)
                return;
            mouseDown = true;
            mouseButton = e.Button;
            base.OnMouseDown(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            if (zoomBox != null)
                zoomBox.Visible = false;
            base.OnMouseLeave(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            mousePosition = e.Location;
            RefreshZoomBox();
            //this.Focus();
            base.OnMouseMove(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            // if mouse button being released is NOT the first one still being held, cancel
            if (mouseButton != e.Button)
                return;
            mouseDown = false;
            base.OnMouseUp(e);
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                if (e.Delta > 0 && zoom < 8)
                    ZoomIn(e.X, e.Y);
                else if (e.Delta < 0 && zoom > 1)
                    ZoomOut(e.X, e.Y);
            }
            base.OnMouseWheel(e);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Control | Keys.Up:
                case Keys.Control | Keys.Add:
                    ZoomIn(mousePosition.X, mousePosition.Y); break;
                case Keys.Control | Keys.Down:
                case Keys.Control | Keys.Subtract:
                    ZoomOut(mousePosition.X, mousePosition.Y); break;
            }
            base.OnPreviewKeyDown(e);
        }
        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            if (mouseDown)
                return;
            base.OnInvalidated(e);
        }

        #endregion

        #region Windows Messages

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);
        private const int WM_SETREDRAW = 0x0B;

        #endregion
    }

    public class NewGroupBox : GroupBox
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            //Pen border = new Pen(SystemColors.ControlDark);
            //border.Width = 1; border.Alignment = PenAlignment.Outset;
            Rectangle header = new Rectangle(0, 0, this.Width - 1, 14);
            Rectangle body = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            Brush fillHeader = new LinearGradientBrush(header, SystemColors.ActiveCaption, this.Parent.BackColor, LinearGradientMode.Horizontal);
            Brush fillBody = new SolidBrush(Parent.BackColor);
            e.Graphics.FillRectangle(fillBody, body);
            e.Graphics.FillRectangle(fillHeader, header);
            //e.Graphics.DrawRectangle(border, body);
            //
            Brush foreColor = new SolidBrush(SystemColors.ActiveCaptionText);
            Font font = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold);
            e.Graphics.DrawString(this.Text, font, foreColor, 2, 0);
        }
    }

    public class NewProgressBar : System.Windows.Forms.ProgressBar
    {
        // Constructor
        public NewProgressBar()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.Text = this.Name;
        }

        // Event Handlers
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Draw progress fill
            SolidBrush foreColor = new SolidBrush(this.ForeColor);
            int width = (int)((double)this.Value / (double)this.Maximum * (double)this.Width);
            e.Graphics.FillRectangle(foreColor, 0, 0, width, this.Height);
            // Draw text string
            SizeF sizeF = e.Graphics.MeasureString(this.Text, this.Font);
            PointF pointF = new PointF(this.Width / 2 - (sizeF.Width / 2), this.Height / 2 - (sizeF.Height / 2));
            foreColor = new SolidBrush(SystemColors.ControlText);
            Font font = new Font(this.Parent.Font.FontFamily, 7F, FontStyle.Bold);
            e.Graphics.DrawString(this.Text, font, foreColor, pointF);
        }
    }
}
