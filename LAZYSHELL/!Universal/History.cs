using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public class History
    {
        // variables
        private Form form;
        // constructor
        public History(Form form)
        {
            this.form = form;
            foreach (Control c in form.Controls)
            {
                //c.KeyDown += new KeyEventHandler(ControlKeyDown);
                c.MouseDown += new MouseEventHandler(ControlMouseDown);
                SetEventHandlers(c);
            }
        }
        // functions
        private void SetEventHandlers(Control control)
        {
            if (control.GetType() == typeof(ToolStrip))
                foreach (ToolStripItem item in ((ToolStrip)control).Items)
                    item.MouseDown += new MouseEventHandler(ToolStripItemMouseDown);
            else
                foreach (Control c in control.Controls)
                {
                    //c.KeyDown += new KeyEventHandler(ControlKeyDown);
                    c.MouseDown += new MouseEventHandler(ControlMouseDown);
                    SetEventHandlers(c);
                }
        }
        private void AddValue(Control control, ref string temp)
        {
            if (control.GetType() == typeof(NumericUpDown))
                temp += "value=" + ((NumericUpDown)control).Value + " | ";
            else if (control.GetType() == typeof(ComboBox))
                temp += "index=" + ((ComboBox)control).SelectedIndex + " | ";
            else if (control.GetType() == typeof(CheckedListBox) ||
                control.GetType() == typeof(NewCheckedListBox) ||
                control.GetType() == typeof(ListBox))
                temp += "index=" + ((ListBox)control).SelectedIndex + " | ";
        }
        // event handlers
        private void ControlKeyDown(object sender, KeyEventArgs e)
        {
            Control control = (Control)sender;
            if (control.Name == "")
                return;
            string temp = "KeyDown \"" + control.Name + "\" | ";
            AddValue(control, ref temp);
            temp += "Form \"" + form.Name + "\" | " + DateTime.Now.ToString() + "\r\n";
            Model.History = Model.History.Insert(0, temp);
        }
        private void ToolStripItemMouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.None) return;
            ToolStripItem item = (ToolStripItem)sender;
            string temp = "MouseDown \"" + item.Name + "\" | X:" + e.X + ",Y:" + e.Y + " | ";
            temp += "Form \"" + form.Name + "\" | " + DateTime.Now.ToString() + "\r\n";
            Model.History = Model.History.Insert(0, temp);
        }
        private void ControlMouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.None) return;
            Control control = (Control)sender;
            if (control.Parent != null && control.Parent.GetType() == typeof(NumericUpDown))
                control = control.Parent;
            string temp = "MouseDown \"" + control.Name + "\" | X:" + e.X + ",Y:" + e.Y + " | ";
            AddValue(control, ref temp);
            temp += "Form \"" + form.Name + "\" | " + DateTime.Now.ToString() + "\r\n";
            Model.History = Model.History.Insert(0, temp);
        }
    }
}
