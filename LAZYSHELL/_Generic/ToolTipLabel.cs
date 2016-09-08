using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace LazyShell
{
    /// <summary>
    /// Custom Windows Form class for displaying a tooltip window.
    /// </summary>
    public class ToolTipForm : Controls.NewForm
    {
        // Constructor
        public ToolTipForm(Color backColor)
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BackColor = backColor;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
        }
    }

    /// <summary>
    /// Class for managing a form's tooltips by accessing the LazyShell_xml help document.
    /// </summary>
    public class ToolTipLabel
    {
        #region Variables

        private Form form;
        private Point location;
        private Label labelConvertor = new Label();
        private Label labelToolTip = new Label();
        private Label titleToolTip = new Label();
        private object mouseOverControl;
        private ToolTipForm formConvertor;
        private ToolTipForm formToolTip;
        private string toolTipTitle;
        private string toolTipDesc;
        private Panel panelToolTip = new Panel();
        private ToolStripButton baseConvertor;
        private ToolStripButton helpTips;

        #endregion

        /// <summary>
        /// Creates an instance of the tooltip form and initializes all of the controls used within the tooltip.
        /// </summary>
        /// <param name="form">The owner form associated with the tooltip.</param>
        /// <param name="baseConvertor">The button associated with the optional display of a control's 
        /// values in decimal or hexadecimal.</param>
        /// <param name="helpTips">The button associated with the optional display of a control's 
        /// Associated tooltip attribute in the LazyShell_xml document.</param>
        public ToolTipLabel(Form form, ToolStripButton baseConvertor, ToolStripButton helpTips)
        {
            this.form = form;
            this.baseConvertor = baseConvertor;
            this.helpTips = helpTips;
            SetEventHandlers();
            SetControlProperties();
        }

        #region Methods

        private void SetControlProperties()
        {
            // create labels
            formConvertor = new ToolTipForm(SystemColors.Window);
            labelConvertor.AutoSize = true;
            labelConvertor.BackColor = Color.White;
            labelConvertor.BorderStyle = BorderStyle.FixedSingle;
            labelConvertor.Dock = DockStyle.Fill;
            labelConvertor.Font = new Font("Lucida Console", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelConvertor.Location = new Point(0, 0);
            labelConvertor.Margin = Padding.Empty;
            // tooltips
            formToolTip = new ToolTipForm(SystemColors.Info);
            titleToolTip.AutoSize = true;
            titleToolTip.Font = new Font(form.Font, FontStyle.Bold);
            titleToolTip.Location = new Point(0, 0);
            titleToolTip.Margin = Padding.Empty;
            titleToolTip.MaximumSize = new Size(300, 0);
            titleToolTip.Padding = Padding.Empty;
            //
            labelToolTip.AutoSize = true;
            labelToolTip.Font = form.Font;
            labelToolTip.Location = new Point(0, 13);
            labelToolTip.Margin = Padding.Empty;
            labelToolTip.MaximumSize = new Size(300, 0);
            labelToolTip.Padding = Padding.Empty;
            //
            panelToolTip.AutoSize = true;
            panelToolTip.AutoSizeMode = AutoSizeMode.GrowOnly;
            panelToolTip.BackColor = SystemColors.Info;
            panelToolTip.BorderStyle = BorderStyle.FixedSingle;
            panelToolTip.Controls.Add(titleToolTip);
            panelToolTip.Controls.Add(labelToolTip);
            panelToolTip.Margin = Padding.Empty;
            panelToolTip.MaximumSize = new Size(300, 0);
            panelToolTip.Padding = Padding.Empty;
            //
            formConvertor.Controls.Add(labelConvertor);
            formToolTip.Controls.Add(panelToolTip);
        }
        private void SetEventHandlers()
        {
            foreach (Control c in form.Controls)
            {
                c.MouseMove += new MouseEventHandler(ControlMouseMove);
                c.MouseLeave += new EventHandler(ControlMouseLeave);
                SetEventHandlers(c);
                if (c is ToolStrip)
                {
                    ToolStrip t = c as ToolStrip;
                    foreach (ToolStripItem i in t.Items)
                    {
                        i.MouseMove += new MouseEventHandler(ControlMouseMove);
                        i.MouseLeave += new EventHandler(ControlMouseLeave);
                    }
                }
            }
        }
        private void SetEventHandlers(Control control)
        {
            foreach (Control c in control.Controls)
            {
                c.MouseMove += new MouseEventHandler(ControlMouseMove);
                c.MouseLeave += new EventHandler(ControlMouseLeave);
                SetEventHandlers(c);
                if (c is ToolStrip)
                {
                    ToolStrip t = c as ToolStrip;
                    foreach (ToolStripItem i in t.Items)
                    {
                        i.MouseMove += new MouseEventHandler(ControlMouseMove);
                        i.MouseLeave += new EventHandler(ControlMouseLeave);
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves the text of a control's tooltip attribute in the LazyShell_xml document.
        /// </summary>
        /// <param name="control">The specified control associated with the tooltip attribute in the XML document.</param>
        /// <param name="caption">The optional caption to display in bold at the top of the tooltip window.</param>
        /// <returns></returns>
        private string GetToolTipText(object control, string caption)
        {
            #region Get form and control's name

            Form form = null;
            string controlName = "";
            Type type = control.GetType();
            string name = type.BaseType.Name;
            if (name.StartsWith("ToolStrip") && name != "ToolStrip")
            {
                form = (control as ToolStripItem).Owner.FindForm();
                controlName = (control as ToolStripItem).Name;
            }
            else
            {
                form = (control as Control).FindForm();
                if (type.Name == "UpDownEdit")
                {
                    Control temp = form.GetNextControl(control as Control, false);
                    control = form.GetNextControl(temp, false) as NumericUpDown;
                }
                controlName = (control as Control).Name;
            }
            //
            if (form == null)
                return "";

            #endregion

            #region Get control's tooltip from XML

            // Load XML help file from Model
            var LazyShell_help = Model.LazyShell_xml;

            // Select node containing the form's data
            name = string.Format("//*[@form='{0}']", form.Name);
            var window = LazyShell_help.SelectSingleNode(name);

            // Select control's node in form's node
            if (window != null)
            {
                name = string.Format(".//*[@control='{0}']", controlName);
                var tooltip = window.SelectSingleNode(name);

                // Select node containing control's tooltip data
                if (tooltip == null)
                {
                    name = string.Format(".//*[@control2='{0}']", controlName);
                    tooltip = window.SelectSingleNode(name);
                }

                // Select node containing tooltip's text
                if (tooltip != null)
                {
                    var text = tooltip.SelectSingleNode(caption);
                    if (text != null)
                        return text.InnerText;
                }
            }

            #endregion

            return null;
        }

        #endregion

        #region Event Handlers

        public void ControlMouseMove(object sender, MouseEventArgs e)
        {
            if (sender == form)
                return;

            // Initialize a point 20,10 pixels from current position of mouse cursor
            var location = new Point(Cursor.Position.X + 20, Cursor.Position.Y + 10);

            // If position hasn't changed, cancel operation
            if (location.X == this.location.X && location.Y == this.location.Y)
                return;

            // Set new location to point
            this.location = location;

            #region Show Hex <> Dec label for NewToolStripNumericUpDown

            object numericUpDown;
            if (sender is Controls.NewToolStripNumericUpDown)
            {
                if (baseConvertor == null || !baseConvertor.Checked)
                {
                    formConvertor.Visible = false;
                    return;
                }

                // Get NumericUpDown control containing value to convert
                var toolStripNumericUpDown = sender as Controls.NewToolStripNumericUpDown;

                // Convert NumericUpDown's value and set label's text
                if (toolStripNumericUpDown.Hexadecimal)
                    labelConvertor.Text = "DEC:  " + ((int)toolStripNumericUpDown.Value).ToString();
                else
                    labelConvertor.Text = "HEX:  0x" + ((int)toolStripNumericUpDown.Value).ToString("X4");

                // Set label form's size
                formConvertor.Width = labelConvertor.Width;
                formConvertor.Height = labelConvertor.Height;

                // Set label form's location
                if (location.X + formConvertor.Width > Screen.PrimaryScreen.WorkingArea.Width - 10)
                    location.X -= formConvertor.Width + 30;
                if (location.Y + formConvertor.Height > Screen.PrimaryScreen.WorkingArea.Height - 30)
                    location.Y -= formConvertor.Height + 30;
                formConvertor.Location = location;

                // Bring label form to front as an inactive form
                Do.ShowInactiveTopmost(formConvertor);

                // Finished, break operation
                return;
            }

            #endregion

            #region Show ToolTip label for any type control

            object control = sender;
            if (helpTips != null && helpTips.Checked)
            {
                if (mouseOverControl != control)
                {
                    toolTipTitle = GetToolTipText(control, "title");
                    toolTipDesc = GetToolTipText(control, "description");
                }

                // Only show tooltip label if has description
                if (toolTipDesc != null)
                {
                    if (mouseOverControl != control)
                    {
                        titleToolTip.Text = toolTipTitle;
                        labelToolTip.Text = toolTipDesc;
                    }

                    // Set label form's location
                    if (location.X + formToolTip.Width > Screen.PrimaryScreen.WorkingArea.Width - 10)
                        location.X -= formToolTip.Width + 30;
                    if (location.Y + formToolTip.Height > Screen.PrimaryScreen.WorkingArea.Height - 30)
                        location.Y -= formToolTip.Height + 30;
                    formToolTip.Location = location;

                    // Bring label form to front as an inactive form
                    if (!formToolTip.Visible)
                        Do.ShowInactiveTopmost(formToolTip);
                }
                else
                    formToolTip.Hide();
            }
            else
                formToolTip.Visible = false;

            #endregion

            #region Show Hex <> Dec label for NumericUpDown

            if (baseConvertor != null && baseConvertor.Checked)
            {
                if (control.GetType().Name == "UpDownEdit" ||
                    control.GetType().Name == "NumericUpDown")
                {
                    // Get NumericUpDown control containing value to convert
                    if (control.GetType().Name == "UpDownEdit")
                    {
                        var temp = form.GetNextControl(control as Control, false);
                        numericUpDown = form.GetNextControl(temp, false) as NumericUpDown;
                    }
                    else
                        numericUpDown = control as NumericUpDown;

                    // Convert NumericUpDown's value and set label's text
                    if ((numericUpDown as NumericUpDown).Hexadecimal)
                        labelConvertor.Text = "DEC:  " + ((int)(numericUpDown as NumericUpDown).Value).ToString();
                    else
                        labelConvertor.Text = "HEX:  0x" + ((int)(numericUpDown as NumericUpDown).Value).ToString("X4");

                    // Set label form's size
                    formConvertor.Width = labelConvertor.Width;
                    formConvertor.Height = labelConvertor.Height;

                    // Set label form's location
                    if (location.X + formConvertor.Width > Screen.PrimaryScreen.WorkingArea.Width - 10)
                        location.X -= formConvertor.Width + 30;
                    if (location.Y + formConvertor.Height > Screen.PrimaryScreen.WorkingArea.Height - 30)
                        location.Y -= formConvertor.Height + 30;
                    formConvertor.Location = location;

                    // Bring label form to front as an inactive form
                    Do.ShowInactiveTopmost(formConvertor);
                }
                else
                    formConvertor.Hide();
            }
            else
                formConvertor.Hide();

            #endregion

            mouseOverControl = control;
        }
        private void ControlMouseLeave(object sender, EventArgs e)
        {
            formConvertor.Hide();
            formToolTip.Hide();
            mouseOverControl = null;
        }

        #endregion
    }
}
