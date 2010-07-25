using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LAZYSHELL
{
    public class ToolTipLabel
    {
        private Form form;
        private ToolTip toolTip;
        private Label labelConvertor = new Label();
        private Label labelToolTip = new Label();
        private ToolStripButton buttonConvertor;
        private ToolStripButton buttonToolTip;
        [DllImport("User32.dll")]
        static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("User32.dll")]
        static extern void ReleaseDC(IntPtr dc);
        [DllImport("User32.dll")]
        static extern bool GetCursorPos(ref Point lpPoint);
        public ToolTipLabel(Form form, ToolTip toolTip, ToolStripButton buttonConvertor, ToolStripButton buttonToolTip)
        {
            this.form = form;
            this.toolTip = toolTip;
            this.buttonConvertor = buttonConvertor;
            this.buttonToolTip = buttonToolTip;
            foreach (Control c in form.Controls)
            {
                c.MouseMove += new MouseEventHandler(ControlMouseMove);
                c.MouseLeave += new EventHandler(ControlMouseLeave);
                SetEventHandlers(c);
            }
            // create labels
            labelConvertor.AutoSize = true;
            labelConvertor.BackColor = Color.White;
            labelConvertor.BorderStyle = BorderStyle.FixedSingle;
            labelConvertor.Font = new Font("Lucida Console", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelConvertor.Margin = Padding.Empty;
            labelConvertor.Visible = false;
            labelToolTip.AutoSize = true;
            labelToolTip.BackColor = SystemColors.Info;
            labelToolTip.BorderStyle = BorderStyle.FixedSingle;
            labelToolTip.Margin = Padding.Empty;
            labelToolTip.Visible = false;
            form.Controls.Add(labelConvertor);
            form.Controls.Add(labelToolTip);
        }

        private void SetEventHandlers(Control control)
        {
            foreach (Control c in control.Controls)
            {
                c.MouseMove += new MouseEventHandler(ControlMouseMove);
                c.MouseLeave += new EventHandler(ControlMouseLeave);
                SetEventHandlers(c);
            }
        }
        public void ControlMouseMove(object sender, MouseEventArgs e)
        {
            if (sender == form) return;
            Point location = new Point(Cursor.Position.X - form.Location.X + 10, Cursor.Position.Y - form.Location.Y);
            // set the conversion label
            object numericUpDown;
            if (sender.GetType() == typeof(ToolStripNumericUpDown))
            {
                if (buttonConvertor == null || !buttonConvertor.Checked)
                {
                    labelConvertor.Visible = false;
                    return;
                }
                ToolStripNumericUpDown toolStripNumericUpDown = (ToolStripNumericUpDown)sender;
                if (toolStripNumericUpDown.Hexadecimal)
                    labelConvertor.Text = "DEC:  " + toolStripNumericUpDown.Value.ToString("d");
                else
                    labelConvertor.Text = "HEX:  0x" + toolStripNumericUpDown.Value.ToString("X4");
                if (location.X + labelConvertor.Width > form.Width - 10)
                    location.X -= labelConvertor.Width + 20;
                if (location.Y + labelConvertor.Height > form.Height - 30)
                    location.Y -= labelConvertor.Height + 45;
                labelConvertor.Location = location;
                labelConvertor.BringToFront();
                labelConvertor.Visible = true;
                return;
            }
            // set the tool tip
            Control control = (Control)sender;
            if (buttonToolTip != null && buttonToolTip.Checked)
            {
                if (toolTip.GetToolTip(control) != "")
                {
                    labelToolTip.Text = toolTip.GetToolTip(control);
                    if (location.X + labelToolTip.Width > form.Width - 10)
                        location.X -= labelToolTip.Width + 20;
                    if (location.Y + labelToolTip.Height > form.Height - 30)
                        location.Y -= labelToolTip.Height + 45;
                    labelToolTip.Location = location;
                    labelToolTip.BringToFront();
                    labelToolTip.Visible = true;
                }
                else
                    labelToolTip.Visible = false;
            }
            else
                labelToolTip.Visible = false;

            if (buttonConvertor != null && buttonConvertor.Checked)
            {
                if (control.GetType().Name == "UpDownEdit" ||
                    control.GetType().Name == "NumericUpDown")
                {
                    if (control.GetType().Name == "UpDownEdit")
                    {
                        Control temp = form.GetNextControl(control, false);
                        numericUpDown = (NumericUpDown)form.GetNextControl(temp, false);
                    }
                    else
                        numericUpDown = (NumericUpDown)control;

                    if (((NumericUpDown)numericUpDown).Hexadecimal)
                        labelConvertor.Text = "DEC:  " + ((int)((NumericUpDown)numericUpDown).Value).ToString("d");
                    else
                        labelConvertor.Text = "HEX:  0x" + ((int)((NumericUpDown)numericUpDown).Value).ToString("X4");

                    if (location.X + labelConvertor.Width > form.Width - 10)
                        location.X -= labelConvertor.Width + 20;
                    if (location.Y + labelConvertor.Height > form.Height - 30)
                        location.Y -= labelConvertor.Height + 45;
                    labelConvertor.Location = location;
                    labelConvertor.BringToFront();
                    labelConvertor.Visible = true;
                }
                else
                    labelConvertor.Visible = false;
            }
            else
                labelConvertor.Visible = false;
        }
        private void ControlMouseLeave(object sender, EventArgs e)
        {
            labelConvertor.Hide();
            labelToolTip.Hide();
        }
    }
}
