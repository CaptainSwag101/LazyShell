using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace LAZYSHELL
{
    public class ToolTipForm : Form
    {
        public ToolTipForm(Color backColor)
        {
            this.BackColor = backColor;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Size = new Size(300, 300);
            this.TopMost = true;
        }
        protected override bool ShowWithoutActivation { get { return true; } }
    }
    public class ToolTipLabel
    {
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
        private FlowLayoutPanel panelToolTip = new FlowLayoutPanel();
        private ToolStripButton baseConvertor;
        private ToolStripButton helpTips;
        public ToolTipLabel(Form form, ToolStripButton baseConvertor, ToolStripButton helpTips)
        {
            this.form = form;
            this.baseConvertor = baseConvertor;
            this.helpTips = helpTips;
            foreach (Control c in form.Controls)
            {
                c.MouseMove += new MouseEventHandler(ControlMouseMove);
                c.MouseLeave += new EventHandler(ControlMouseLeave);
                SetEventHandlers(c);
                if (c.GetType() == typeof(ToolStrip))
                {
                    ToolStrip t = (ToolStrip)c;
                    foreach (ToolStripItem i in t.Items)
                    {
                        i.MouseMove += new MouseEventHandler(ControlMouseMove);
                        i.MouseLeave += new EventHandler(ControlMouseLeave);
                    }
                }
            }
            // create labels
            formConvertor = new ToolTipForm(SystemColors.Window);
            labelConvertor.AutoSize = true;
            labelConvertor.BackColor = Color.White;
            labelConvertor.BorderStyle = BorderStyle.FixedSingle;
            labelConvertor.Dock = DockStyle.Fill;
            labelConvertor.Font = new Font("Lucida Console", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelConvertor.Location = new Point(0, 0);
            labelConvertor.Margin = Padding.Empty;
            //
            formToolTip = new ToolTipForm(SystemColors.Info);
            panelToolTip.BackColor = SystemColors.Info;
            panelToolTip.BorderStyle = BorderStyle.FixedSingle;
            panelToolTip.Controls.Add(titleToolTip);
            panelToolTip.Controls.Add(labelToolTip);
            panelToolTip.Dock = DockStyle.Fill;
            panelToolTip.Margin = Padding.Empty;
            panelToolTip.Padding = Padding.Empty;
            labelToolTip.AutoSize = true;
            labelToolTip.Font = form.Font;
            labelToolTip.Margin = Padding.Empty;
            labelToolTip.Padding = Padding.Empty;
            titleToolTip.Font = new Font(form.Font, FontStyle.Bold);
            titleToolTip.Margin = Padding.Empty;
            titleToolTip.Padding = Padding.Empty;
            titleToolTip.Size = new Size(300, 13);
            //
            formConvertor.Controls.Add(labelConvertor);
            formToolTip.Controls.Add(panelToolTip);
        }
        public static string GetToolTipText(object item, string caption)
        {
            Form form = null;
            string control = "";
            Type type = item.GetType();
            if (type.BaseType.Name.StartsWith("ToolStrip"))
            {
                form = ((ToolStripItem)item).Owner.FindForm();
                control = ((ToolStripItem)item).Name;
            }
            else
            {
                form = ((Control)item).FindForm();
                if (type.Name == "UpDownEdit")
                {
                    Control temp = form.GetNextControl((Control)item, false);
                    item = (NumericUpDown)form.GetNextControl(temp, false);
                }
                control = ((Control)item).Name;
            }
            //
            if (form == null) return "";
            //
            XmlDocument LAZYSHELL_help = Model.LAZYSHELL_xml;
            string name = string.Format("//*[@form='{0}']", form.Name);
            // find form in nodes
            XmlNode window = LAZYSHELL_help.SelectSingleNode(name);
            if (window != null)
            {
                // find control in nodes
                name = string.Format(".//*[@control='{0}']", control);
                XmlNode tooltip = window.SelectSingleNode(name);
                if (tooltip == null)
                {
                    name = string.Format(".//*[@control2='{0}']", control);
                    tooltip = window.SelectSingleNode(name);
                }
                if (tooltip != null)
                {
                    XmlNode text = tooltip.SelectSingleNode(caption);
                    if (text != null) return text.InnerText;
                }
            }
            return null;
        }
        private void SetEventHandlers(Control control)
        {
            foreach (Control c in control.Controls)
            {
                c.MouseMove += new MouseEventHandler(ControlMouseMove);
                c.MouseLeave += new EventHandler(ControlMouseLeave);
                SetEventHandlers(c);
                if (c.GetType() == typeof(ToolStrip))
                {
                    ToolStrip t = (ToolStrip)c;
                    foreach (ToolStripItem i in t.Items)
                    {
                        i.MouseMove += new MouseEventHandler(ControlMouseMove);
                        i.MouseLeave += new EventHandler(ControlMouseLeave);
                    }
                }
            }
        }
        public void ControlMouseMove(object sender, MouseEventArgs e)
        {
            if (sender == form) return;
            Point location = new Point(Cursor.Position.X + 20, Cursor.Position.Y + 10);
            if (location.X == this.location.X && location.Y == this.location.Y)
                return;
            this.location = location;
            // set the conversion label for toolstrip items
            object numericUpDown;
            if (sender.GetType() == typeof(ToolStripNumericUpDown))
            {
                if (baseConvertor == null || !baseConvertor.Checked)
                {
                    formConvertor.Visible = false;
                    return;
                }
                ToolStripNumericUpDown toolStripNumericUpDown = (ToolStripNumericUpDown)sender;
                if (toolStripNumericUpDown.Hexadecimal)
                    labelConvertor.Text = "DEC:  " + toolStripNumericUpDown.Value.ToString();
                else
                    labelConvertor.Text = "HEX:  0x" + toolStripNumericUpDown.Value.ToString("X4");
                //
                formConvertor.Width = labelConvertor.Width;
                formConvertor.Height = labelConvertor.Height;
                if (location.X + formConvertor.Width > Screen.PrimaryScreen.WorkingArea.Width - 10)
                    location.X -= formConvertor.Width + 30;
                if (location.Y + formConvertor.Height > Screen.PrimaryScreen.WorkingArea.Height - 30)
                    location.Y -= formConvertor.Height + 30;
                formConvertor.Location = location;
                Do.ShowInactiveTopmost(formConvertor);
                return;
            }
            // set the tool tip
            object control = sender;
            if (helpTips != null && helpTips.Checked)
            {
                if (mouseOverControl != control)
                {
                    toolTipTitle = GetToolTipText(control, "title");
                    toolTipDesc = GetToolTipText(control, "description");
                }
                if (toolTipDesc != null)
                {
                    if (mouseOverControl != control)
                    {
                        formToolTip.Width = 300;
                        labelToolTip.Text = toolTipDesc;
                        titleToolTip.Text = toolTipTitle;
                        formToolTip.Height = titleToolTip.Height + labelToolTip.Height + 4;
                        if (formToolTip.Height <= 30)
                            formToolTip.Width = labelToolTip.Width + 2;
                        else
                            formToolTip.Width = 300;
                    }
                    //
                    if (location.X + formToolTip.Width > Screen.PrimaryScreen.WorkingArea.Width - 10)
                        location.X -= formToolTip.Width + 30;
                    if (location.Y + formToolTip.Height > Screen.PrimaryScreen.WorkingArea.Height - 30)
                        location.Y -= formToolTip.Height + 30;
                    formToolTip.Location = location;
                    if (!formToolTip.Visible)
                        Do.ShowInactiveTopmost(formToolTip);
                }
                else
                    formToolTip.Hide();
            }
            else
                formToolTip.Visible = false;
            // set the conversion label for controls
            if (baseConvertor != null && baseConvertor.Checked)
            {
                if (control.GetType().Name == "UpDownEdit" ||
                    control.GetType().Name == "NumericUpDown")
                {
                    if (control.GetType().Name == "UpDownEdit")
                    {
                        Control temp = form.GetNextControl((Control)control, false);
                        numericUpDown = (NumericUpDown)form.GetNextControl(temp, false);
                    }
                    else
                        numericUpDown = (NumericUpDown)control;

                    if (((NumericUpDown)numericUpDown).Hexadecimal)
                        labelConvertor.Text = "DEC:  " + ((int)((NumericUpDown)numericUpDown).Value).ToString();
                    else
                        labelConvertor.Text = "HEX:  0x" + ((int)((NumericUpDown)numericUpDown).Value).ToString("X4");
                    //
                    formConvertor.Width = labelConvertor.Width;
                    formConvertor.Height = labelConvertor.Height;
                    if (location.X + formConvertor.Width > Screen.PrimaryScreen.WorkingArea.Width - 10)
                        location.X -= formConvertor.Width + 30;
                    if (location.Y + formConvertor.Height > Screen.PrimaryScreen.WorkingArea.Height - 30)
                        location.Y -= formConvertor.Height + 30;
                    formConvertor.Location = location;
                    Do.ShowInactiveTopmost(formConvertor);
                }
                else
                    formConvertor.Hide();
            }
            else
                formConvertor.Hide();
            //
            mouseOverControl = control;
        }
        private void ControlMouseLeave(object sender, EventArgs e)
        {
            formConvertor.Hide();
            formToolTip.Hide();
            mouseOverControl = null;
        }
    }
}
