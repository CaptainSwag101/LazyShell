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
        private ToolStripControlHost name;
        private ToolStripNumericUpDown number;
        private bool includeChildForms = true;
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
        public History(Form form, bool includeChildForms)
        {
            this.form = form;
            this.includeChildForms = includeChildForms;
            foreach (Control c in form.Controls)
            {
                //c.KeyDown += new KeyEventHandler(ControlKeyDown);
                c.MouseDown += new MouseEventHandler(ControlMouseDown);
                Type type = c.GetType();
                if (type.BaseType != typeof(Form) || includeChildForms)
                    SetEventHandlers(c);
            }
        }
        public History(Form form, ToolStripControlHost name, ToolStripNumericUpDown number)
        {
            this.form = form;
            this.name = name;
            this.number = number;
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
                    Type type = c.GetType();
                    if (type.BaseType != typeof(Form) || includeChildForms)
                        SetEventHandlers(c);
                }
        }
        private void AddValue(Control control, ref string temp)
        {
            if (control.GetType() == typeof(NumericUpDown))
                temp += "Value = " + ((NumericUpDown)control).Value + " | ";
            else if (control.GetType() == typeof(ComboBox))
                temp += "SelectedIndex = " + ((ComboBox)control).SelectedIndex + " | ";
            else if (control.GetType() == typeof(CheckedListBox) ||
                control.GetType() == typeof(NewCheckedListBox) ||
                control.GetType() == typeof(ListBox))
                temp += "SelectedIndex = " + ((ListBox)control).SelectedIndex + " | ";
        }
        private void AddElementIndex(ref string temp)
        {
            if (name != null || number != null)
                temp += " | Element = ";
            string numberTag = "";
            string nameTag = "";
            if (number != null)
            {
                int index = (int)number.Value;
                int length = number.Maximum.ToString().Length;
                numberTag = index.ToString("d" + length);
                numberTag = "{" + numberTag + "}  ";
            }
            if (name != null)
            {
                if (number != null)
                    nameTag = Lists.RemoveTag(name.Text);
                else
                    nameTag = name.Text;
            }
            temp += numberTag + nameTag + "\r\n";
        }
        // event handlers
        private void ControlKeyDown(object sender, KeyEventArgs e)
        {
            Control control = (Control)sender;
            if (control.Name == "")
                return;
            string temp = "KeyDown \"" + control.Name + "\" | ";
            AddValue(control, ref temp);
            temp += "Form \"" + form.Name + "\" | " + DateTime.Now.ToString();
            AddElementIndex(ref temp);
            Model.History = Model.History.Insert(0, temp);
        }
        private void ToolStripItemMouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.None) return;
            ToolStripItem item = (ToolStripItem)sender;
            string temp = "MouseDown \"" + item.Name + "\" | X:" + e.X + ",Y:" + e.Y + " | ";
            Type type = item.GetType();
            if (type == typeof(ToolStripNumericUpDown))
                temp += "Value = " + ((ToolStripNumericUpDown)item).Value + " | ";
            else if (type == typeof(LAZYSHELL.ToolStripComboBox))
                temp += "SelectedIndex = " + ((LAZYSHELL.ToolStripComboBox)item).SelectedIndex + " | ";
            else if (type == typeof(System.Windows.Forms.ToolStripComboBox))
                temp += "SelectedIndex = " + ((System.Windows.Forms.ToolStripComboBox)item).SelectedIndex + " | ";
            temp += "Form \"" + form.Name + "\" | " + DateTime.Now.ToString();
            AddElementIndex(ref temp);
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
            temp += "Form \"" + form.Name + "\" | " + DateTime.Now.ToString();
            AddElementIndex(ref temp);
            Model.History = Model.History.Insert(0, temp);
        }
    }
}
