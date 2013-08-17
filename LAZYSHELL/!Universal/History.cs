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
        private NewForm form;
        private ToolStripControlHost name;
        private ToolStripNumericUpDown number;
        private bool includeChildForms = true;
        // constructor
        public History(NewForm form)
        {
            this.form = form;
            if (form.Name != "SpritePartitions" &&
                form.Name != "PaletteEditor" &&
                form.Name != "GraphicEditor" &&
                form.Name != "TileEditor" &&
                form.Name != "NPCEditor")
                Do.AddHistory("OPENED FORM \"" + form.Name + "\"");
            this.form.FormClosed += new FormClosedEventHandler(FormClosed);
            foreach (Control control in form.Controls)
                SetEventHandler(control);
        }
        public History(NewForm form, bool includeChildForms)
        {
            this.form = form;
            this.includeChildForms = includeChildForms;
            Do.AddHistory("OPENED FORM \"" + form.Name + "\"");
            this.form.FormClosed += new FormClosedEventHandler(FormClosed);
            foreach (Control control in form.Controls)
                SetEventHandler(control);
        }
        public History(NewForm form, ToolStripControlHost name, ToolStripNumericUpDown number)
        {
            this.form = form;
            this.name = name;
            this.number = number;
            Do.AddHistory("OPENED FORM \"" + form.Name + "\"");
            this.form.FormClosed += new FormClosedEventHandler(FormClosed);
            foreach (Control control in form.Controls)
                SetEventHandler(control);
        }
        // functions
        private void SetEventHandlers(Control control)
        {
            if (control.GetType() == typeof(ToolStrip))
            {
                foreach (ToolStripItem item in ((ToolStrip)control).Items)
                    SetEventHandler(item);
            }
            else
            {
                foreach (Control child in control.Controls)
                    SetEventHandler(child);
            }
        }
        private void SetEventHandler(Control control)
        {
            Type type = control.GetType();
            if (type == typeof(NumericUpDown))
                ((NumericUpDown)control).ValueChanged += new EventHandler(ValueChanged);
            else if (type == typeof(ComboBox))
                ((ComboBox)control).SelectedIndexChanged += new EventHandler(SelectedIndexChanged);
            else if (type == typeof(CheckedListBox) || type == typeof(NewCheckedListBox))
                ((CheckedListBox)control).SelectedIndexChanged += new EventHandler(SelectedIndexChanged);
            else if (type == typeof(ListBox))
                ((ListBox)control).SelectedIndexChanged += new EventHandler(SelectedIndexChanged);
            else if (type == typeof(TreeView) || type == typeof(NewTreeView))
                ((TreeView)control).NodeMouseClick += new TreeNodeMouseClickEventHandler(NodeMouseClick);
            else if (type == typeof(CheckBox))
                ((CheckBox)control).CheckedChanged += new EventHandler(CheckedChanged);
            else if (type == typeof(PictureBox) || type == typeof(NewPictureBox))
                ((PictureBox)control).MouseDown += new MouseEventHandler(MouseDown);
            else if (type == typeof(RichTextBox))
                ((RichTextBox)control).TextChanged += new EventHandler(TextChanged);
            else if (type == typeof(TextBox))
                ((TextBox)control).TextChanged += new EventHandler(TextChanged);
            //
            if (type.BaseType != typeof(Form) || includeChildForms)
                SetEventHandlers(control);
        }
        private void SetEventHandler(ToolStripItem item)
        {
            Type type = item.GetType();
            if (type == typeof(ToolStripNumericUpDown))
                ((ToolStripNumericUpDown)item).ValueChanged += new EventHandler(ValueChanged);
            else if (type == typeof(ToolStripComboBox))
                ((ToolStripComboBox)item).SelectedIndexChanged += new EventHandler(SelectedIndexChanged);
            else if (type == typeof(ToolStripButton))
                ((ToolStripButton)item).Click += new EventHandler(Click);
            else if (type == typeof(ToolStripTextBox))
                ((ToolStripTextBox)item).TextChanged += new EventHandler(TextChanged);
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
            temp += numberTag + nameTag.Trim();
        }
        // event handlers
        private void CheckedChanged(object sender, EventArgs e)
        {
            if (form.Updating)
                return;
            CheckBox control = (CheckBox)sender;
            string temp = "\"" + control.Name + "\" | ";
            temp += "Checked = " + control.Checked;
            temp += " | Form \"" + form.Name + "\"";
            AddElementIndex(ref temp);
            //
            Do.AddHistory(temp);
            form.Modified = true;
        }
        private void Click(object sender, EventArgs e)
        {
            if (form.Updating)
                return;
            string temp = "";
            Type type = sender.GetType();
            if (type == typeof(ToolStripButton))
            {
                ToolStripButton control = (ToolStripButton)sender;
                temp = "\"" + control.Name + "\" | ";
                temp += "Checked = " + control.Checked;
            }
            temp += " | Form \"" + form.Name + "\"";
            AddElementIndex(ref temp);
            //
            Do.AddHistory(temp);
            //form.Modified = true;
        }
        private void FormClosed(object sender, FormClosedEventArgs e)
        {
            Do.AddHistory("CLOSED FORM \"" + form.Name + "\"");
            LAZYSHELL.Properties.Settings.Default.Save();
        }
        private void MouseDown(object sender, MouseEventArgs e)
        {
            if (form.Updating)
                return;
            Control control = (Control)sender;
            string temp = "\"" + control.Name + "\" | ";
            temp += "MouseDown = (X:" + e.X + ",Y:" + e.Y + ")";
            temp += " | Form \"" + form.Name + "\"";
            AddElementIndex(ref temp);
            //
            Do.AddHistory(temp);
            form.Modified = true;
        }
        private void NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (form.Updating)
                return;
            TreeView control = (TreeView)sender;
            string text = e.Node.Text;
            string temp = "\"" + control.Name + "\" | ";
            temp += "\"" + text.Substring(0, Math.Min(30, text.Length));
            if (text.Length > 30)
                temp += "...";
            temp += "\"";
            temp += " | Form \"" + form.Name + "\"";
            AddElementIndex(ref temp);
            //
            Do.AddHistory(temp);
            //form.Modified = true;
        }
        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            if (form.Updating)
                return;
            string temp = "";
            Type type = sender.GetType();
            if (type == typeof(ComboBox))
            {
                ComboBox control = (ComboBox)sender;
                temp += "\"" + control.Name + "\" | ";
                temp += "SelectedIndex = " + control.SelectedIndex;
            }
            else if (type == typeof(ToolStripComboBox))
            {
                ToolStripComboBox control = (ToolStripComboBox)sender;
                temp += "\"" + control.Name + "\" | ";
                temp += "SelectedIndex = " + control.SelectedIndex;
            }
            else if (type == typeof(CheckedListBox) || type == typeof(NewCheckedListBox))
            {
                CheckedListBox control = (CheckedListBox)sender;
                temp += "\"" + control.Name + "\" | ";
                temp += "\"" + control.SelectedItem.ToString().Trim() + "\" = ";
                temp += control.GetItemChecked(control.SelectedIndex);
            }
            else if (type == typeof(ListBox))
            {
                ListBox control = (ListBox)sender;
                temp += "\"" + control.Name + "\" | ";
                temp += "\"" + control.SelectedItem.ToString().Trim();
            }
            temp += " | Form \"" + form.Name + "\"";
            AddElementIndex(ref temp);
            //
            Do.AddHistory(temp);
            if (sender != name && type != typeof(ListBox))
                form.Modified = true;
        }
        private void TextChanged(object sender, EventArgs e)
        {
            if (form.Updating)
                return;
            string temp = "";
            Type type = sender.GetType();
            if (type == typeof(RichTextBox))
            {
                RichTextBox control = (RichTextBox)sender;
                string text = control.Text;
                temp += "\"" + control.Name + "\" | ";
                temp += "Text = \"" + text.Substring(0, Math.Min(30, text.Length));
                if (text.Length > 30)
                    temp += "...";
            }
            else if (type == typeof(TextBox))
            {
                TextBox control = (TextBox)sender;
                string text = control.Text;
                temp += "\"" + control.Name + "\" | ";
                temp += "Text = \"" + text.Substring(0, Math.Min(30, text.Length));
                if (text.Length > 30)
                    temp += "...";
            }
            else if (type == typeof(ToolStripTextBox))
            {
                ToolStripTextBox control = (ToolStripTextBox)sender;
                string text = control.Text;
                temp += "\"" + control.Name + "\" | ";
                temp += "Text = \"" + text.Substring(0, Math.Min(30, text.Length));
                if (text.Length > 30)
                    temp += "...";
            }
            temp += "\"";
            temp += " | Form \"" + form.Name + "\"";
            AddElementIndex(ref temp);
            //
            Do.AddHistory(temp);
            form.Modified = true;
        }
        private void ValueChanged(object sender, EventArgs e)
        {
            if (form.Updating || sender == number)
                return;
            string temp = "";
            Type type = sender.GetType();
            if (type == typeof(NumericUpDown))
            {
                NumericUpDown control = (NumericUpDown)sender;
                temp = "\"" + control.Name + "\" | ";
                temp += "Value = " + control.Value;
            }
            else if (type == typeof(ToolStripNumericUpDown))
            {
                ToolStripNumericUpDown control = (ToolStripNumericUpDown)sender;
                temp = "\"" + control.Name + "\" | ";
                temp += "Value = " + control.Value;
            }
            temp += " | Form \"" + form.Name + "\"";
            AddElementIndex(ref temp);
            //
            Do.AddHistory(temp);
            if (sender != number)
                form.Modified = true;
        }
    }
}
