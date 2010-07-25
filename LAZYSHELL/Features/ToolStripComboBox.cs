using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    [ToolboxItemAttribute(true)]
    public class ToolStripComboBox : System.Windows.Forms.ToolStripControlHost
    {
        public ToolStripComboBox()
            : base(new ComboBox())
        {
            this.DropDownControl.Margin = new Padding(1, 0, 1, 0);
        }
        private ComboBox DropDownControl
        {
            get { return Control as ComboBox; }
        }
        public DrawMode DrawMode { get { return DropDownControl.DrawMode; } set { DropDownControl.DrawMode = value; } }
        public int DropDownHeight { get { return DropDownControl.DropDownHeight; } set { DropDownControl.DropDownHeight = value; } }
        public ComboBoxStyle DropDownStyle { get { return DropDownControl.DropDownStyle; } set { DropDownControl.DropDownStyle = value; } }
        public int DropDownWidth { get { return DropDownControl.DropDownWidth; } set { DropDownControl.DropDownWidth = value; } }
        public int ItemHeight { get { return DropDownControl.ItemHeight; } set { DropDownControl.ItemHeight = value; } }
        public ComboBox.ObjectCollection Items { get { return DropDownControl.Items; } }
        public Point Location { get { return DropDownControl.Location; } set { DropDownControl.Location = value; } }
        public int SelectedIndex { get { return DropDownControl.SelectedIndex; } set { DropDownControl.SelectedIndex = value; } }
        public object SelectedItem { get { return DropDownControl.SelectedItem; } set { DropDownControl.SelectedItem = value; } }
        public void BeginUpdate()
        {
            DropDownControl.BeginUpdate();
        }
        public void EndUpdate()
        {
            DropDownControl.EndUpdate();
        }

        protected override void OnSubscribeControlEvents(Control c)
        {
            base.OnSubscribeControlEvents(c);
            ((ComboBox)c).SelectedIndexChanged += new EventHandler(OnSelectedIndexChanged);
            ((ComboBox)c).DrawItem += new DrawItemEventHandler(OnDrawItem);
        }
        protected override void OnUnsubscribeControlEvents(Control c)
        {
            base.OnUnsubscribeControlEvents(c);
            ((ComboBox)c).SelectedIndexChanged -= new EventHandler(OnSelectedIndexChanged);
            ((ComboBox)c).DrawItem -= new DrawItemEventHandler(OnDrawItem);
        }
        public event EventHandler SelectedIndexChanged;
        public event DrawItemEventHandler DrawItem;
        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndexChanged != null)
                SelectedIndexChanged(this, e);
        }
        private void OnDrawItem(object sender, DrawItemEventArgs e)
        {
            if (DrawItem != null)
                DrawItem(this, e);
        }
    }
}
