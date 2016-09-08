using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LazyShell
{
    /// <summary>
    /// Class for managing the event history of the user's interaction with the application's controls.
    /// </summary>
    public class History
    {
        #region Variables

        private Form form;
        private bool updating
        {
            get
            {
                if (form is Controls.NewForm)
                    return (form as Controls.NewForm).Updating;
                else if (form is Controls.DockForm)
                    return (form as Controls.DockForm).Updating;
                return false;
            }
        }
        private bool modified
        {
            get
            {
                if (form is Controls.NewForm)
                    return (form as Controls.NewForm).Modified;
                else if (form is Controls.DockForm)
                    return (form as Controls.DockForm).Modified;
                return false;
            }
            set
            {
                if (form is Controls.NewForm)
                    (form as Controls.NewForm).Modified = value;
                else if (form is Controls.DockForm)
                    (form as Controls.DockForm).Modified = value;
            }
        }
        private bool mouseDownControl;
        private ToolStripControlHost name;
        private Controls.NewToolStripNumericUpDown number;
        private bool includeChildForms = true;
        private DateTime dateTime;

        #endregion

        // Constructors
        public History(Form form)
        {
            this.form = form;
            InitializeApplicationHistory();
            InitializeEventHandlers();
        }
        public History(Form form, bool includeChildForms)
        {
            this.form = form;
            this.includeChildForms = includeChildForms;
            InitializeApplicationHistory();
            InitializeEventHandlers();
        }
        public History(Form form, ToolStripControlHost name, Controls.NewToolStripNumericUpDown number)
        {
            this.form = form;
            this.name = name;
            this.number = number;
            InitializeApplicationHistory();
            InitializeEventHandlers();
        }

        #region Methods

        private void InitializeApplicationHistory()
        {
            if (form.Name == "Editor")
                Do.AddHistory("LOADED LAZY SHELL APPLICATION");
            else if (form.Name != "SpritePartitions" &&
                form.Name != "PaletteEditor" &&
                form.Name != "GraphicEditor" &&
                form.Name != "TileEditor" &&
                form.Name != "NPCEditor")
                Do.AddHistory("OPENED FORM \"" + form.Name + "\"");
        }
        private void InitializeEventHandlers()
        {
            this.form.FormClosed += new FormClosedEventHandler(FormClosed);
            foreach (Control control in form.Controls)
                SetEventHandler(control);
        }
        private void SetEventHandlers(Control control)
        {
            if (control is ToolStrip || control is Controls.NewToolStrip)
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
            if (control is NumericUpDown)
                ((NumericUpDown)control).ValueChanged += new EventHandler(ValueChanged);
            else if (control is ComboBox)
                ((ComboBox)control).SelectedIndexChanged += new EventHandler(SelectedIndexChanged);
            else if (control is CheckedListBox || control is Controls.NewCheckedListBox)
                ((CheckedListBox)control).SelectedIndexChanged += new EventHandler(SelectedIndexChanged);
            else if (control is ListBox || control is Controls.NewListBox)
                ((ListBox)control).SelectedIndexChanged += new EventHandler(SelectedIndexChanged);
            else if (control is TreeView || control is Controls.NewTreeView)
                ((TreeView)control).NodeMouseClick += new TreeNodeMouseClickEventHandler(NodeMouseClick);
            else if (control is CheckBox)
                ((CheckBox)control).CheckedChanged += new EventHandler(CheckedChanged);
            else if (control is PictureBox || control is Controls.NewPictureBox)
            {
                ((PictureBox)control).MouseDown += new MouseEventHandler(MouseDown);
                ((PictureBox)control).MouseUp += new MouseEventHandler(MouseUp);
            }
            else if (control is TextBox)
                ((TextBox)control).TextChanged += new EventHandler(TextChanged);
            else if (control is Button)
                ((Button)control).Click += new EventHandler(Click);
            //
            if (!(control is Form) || includeChildForms)
                SetEventHandlers(control);
        }
        private void SetEventHandler(ToolStripItem item)
        {
            if (item is Controls.NewToolStripNumericUpDown)
                ((Controls.NewToolStripNumericUpDown)item).ValueChanged += new EventHandler(ValueChanged);
            else if (item is Controls.NewToolStripComboBox)
                ((Controls.NewToolStripComboBox)item).SelectedIndexChanged += new EventHandler(SelectedIndexChanged);
            else if (item is ToolStripButton)
                ((ToolStripButton)item).Click += new EventHandler(Click);
            else if (item is ToolStripTextBox)
                ((ToolStripTextBox)item).TextChanged += new EventHandler(TextChanged);
        }

        /// <summary>
        /// Tags the start of a string with current index of this instance's associated element.
        /// </summary>
        /// <param name="src">The string to apply the tag to.</param>
        private void AddElementIndex(ref string src)
        {
            if (name != null || number != null)
                src += " | Element = ";
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
            src += numberTag + nameTag.Trim();
        }
        /// <summary>
        /// Specifies whether history logging should be acceptable based on the form's properties.
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        private bool LoggingAccept(object sender)
        {
            if (updating)
                return false;
            if (sender is ToolStripButton)
            {
                var control = sender as ToolStripButton;
                string name = control.Name;
                if (!control.CheckOnClick && !name.Contains("navigate") && name != "save")
                {
                    modified = true;
                }
            }
            else if (sender is ToolStripTextBox)
            {
                var control = sender as ToolStripTextBox;
                string name = control.Name;
                if (!name.Contains("search") && !name.Contains("goto"))
                {
                    modified = true;
                }
            }
            else if (!(sender is ListBox) &&
                !(sender is Controls.NewTreeView) &&
                !(sender is TreeView) &&
                !(sender is TreeNode))
            {
                modified = true;
            }
            if (mouseDownControl)
                return false;

            // 1 second = 1000 milliseconds
            // 1 millisecond = 10000 ticks
            if (dateTime.Ticks > DateTime.Now.Ticks - (10000L * 100L)) // 1/10 of a second
                return false;
            return true;
        }

        #endregion

        #region Event Handlers

        private void CheckedChanged(object sender, EventArgs e)
        {
            if (!LoggingAccept(sender))
                return;
            var control = sender as CheckBox;
            string temp = "\"" + control.Name + "\" | ";
            temp += "Checked = " + control.Checked;
            temp += " | Form \"" + form.Name + "\"";
            AddElementIndex(ref temp);
            //
            Do.AddHistory(temp);
            dateTime = DateTime.Now;
        }
        private void Click(object sender, EventArgs e)
        {
            if (!LoggingAccept(sender))
                return;
            string temp = "";
            if (sender is Button)
            {
                var control = sender as Button;
                temp = "\"" + control.Name + "\"";
            }
            else if (sender is ToolStripButton)
            {
                var control = sender as ToolStripButton;
                temp = "\"" + control.Name + "\"";
            }
            temp += " | Form \"" + form.Name + "\"";
            AddElementIndex(ref temp);
            //
            Do.AddHistory(temp);
            dateTime = DateTime.Now;
        }
        private void FormClosed(object sender, FormClosedEventArgs e)
        {
            Do.AddHistory("CLOSED FORM \"" + form.Name + "\"");
            LazyShell.Properties.Settings.Default.Save();
        }
        private void MouseDown(object sender, MouseEventArgs e)
        {
            if (!LoggingAccept(sender))
                return;
            mouseDownControl = true;
            var control = sender as Control;
            string temp = "\"" + control.Name + "\" | ";
            temp += "MouseDown = (X:" + e.X + ",Y:" + e.Y + ")";
            temp += " | Form \"" + form.Name + "\"";
            AddElementIndex(ref temp);
            //
            Do.AddHistory(temp);
            dateTime = DateTime.Now;
        }
        private void MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownControl = false;
        }
        private void NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (!LoggingAccept(sender))
                return;
            var control = sender as TreeView;
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
            dateTime = DateTime.Now;
        }
        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!LoggingAccept(sender))
                return;
            string temp = "";
            if (sender is ComboBox)
            {
                var control = sender as ComboBox;
                temp += "\"" + control.Name + "\" | ";
                temp += "SelectedIndex = " + control.SelectedIndex;
            }
            else if (sender is Controls.NewToolStripComboBox)
            {
                var control = sender as Controls.NewToolStripComboBox;
                temp += "\"" + control.Name + "\" | ";
                temp += "SelectedIndex = " + control.SelectedIndex;
            }
            else if (sender is CheckedListBox || sender is Controls.NewCheckedListBox)
            {
                var control = sender as CheckedListBox;
                temp += "\"" + control.Name + "\" | ";
                if (control.SelectedItem == null)
                    return;
                temp += "\"" + control.SelectedItem.ToString().Trim() + "\" = ";
                temp += control.GetItemChecked(control.SelectedIndex);
            }
            else if (sender is ListBox || sender is Controls.NewListBox)
            {
                var control = sender as ListBox;
                temp += "\"" + control.Name + "\" | ";
                if (control.SelectedItem == null)
                    return;
                temp += "\"" + control.SelectedItem.ToString().Trim();
            }
            temp += " | Form \"" + form.Name + "\"";
            AddElementIndex(ref temp);
            //
            Do.AddHistory(temp);
            dateTime = DateTime.Now;
        }
        private void TextChanged(object sender, EventArgs e)
        {
            if (!LoggingAccept(sender))
                return;
            string temp = "";
            if (sender is TextBox)
            {
                var control = sender as TextBox;
                string text = control.Text;
                temp += "\"" + control.Name + "\" | ";
                temp += "Text = \"" + text.Substring(0, Math.Min(30, text.Length));
                if (text.Length > 30)
                    temp += "...";
            }
            else if (sender is ToolStripTextBox)
            {
                var control = sender as ToolStripTextBox;
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
            dateTime = DateTime.Now;
        }
        private void ValueChanged(object sender, EventArgs e)
        {
            if (!LoggingAccept(sender))
                return;
            string temp = "";
            if (sender is NumericUpDown)
            {
                var control = sender as NumericUpDown;
                temp = "\"" + control.Name + "\" | ";
                temp += "Value = " + control.Value;
            }
            else if (sender is Controls.NewToolStripNumericUpDown)
            {
                var control = sender as Controls.NewToolStripNumericUpDown;
                temp = "\"" + control.Name + "\" | ";
                temp += "Value = " + control.Value;
            }
            temp += " | Form \"" + form.Name + "\"";
            AddElementIndex(ref temp);
            //
            Do.AddHistory(temp);
            dateTime = DateTime.Now;
        }

        #endregion
    }
}
