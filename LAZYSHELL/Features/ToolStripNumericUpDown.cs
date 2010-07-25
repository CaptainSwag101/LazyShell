using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Text;

namespace LAZYSHELL
{
    [ToolboxItemAttribute(true)]
    public class ToolStripNumericUpDown : ToolStripControlHost
    {
        public ToolStripNumericUpDown()
            : base(new NumericUpDown())
        {
            this.NumericUpDownControl.TextAlign = HorizontalAlignment.Right;
        }
        private NumericUpDown NumericUpDownControl
        {
            get { return Control as NumericUpDown; }
        }
        public bool Hexadecimal { get { return NumericUpDownControl.Hexadecimal; } set { NumericUpDownControl.Hexadecimal = value; } }
        public Point Location { get { return NumericUpDownControl.Location; } set { NumericUpDownControl.Location = value; } }
        public decimal Maximum { get { return NumericUpDownControl.Maximum; } set { NumericUpDownControl.Maximum = value; } }
        public decimal Minimum { get { return NumericUpDownControl.Minimum; } set { NumericUpDownControl.Minimum = value; } }
        public decimal Value { get { return NumericUpDownControl.Value; } set { NumericUpDownControl.Value = value; } }
        protected override void OnSubscribeControlEvents(Control c)
        {
            base.OnSubscribeControlEvents(c);
            ((NumericUpDown)c).ValueChanged += new EventHandler(OnValueChanged);
        }
        protected override void OnUnsubscribeControlEvents(Control c)
        {
            base.OnUnsubscribeControlEvents(c);
            ((NumericUpDown)c).ValueChanged -= new EventHandler(OnValueChanged);
        }
        public event EventHandler ValueChanged;
        private void OnValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(this, e);
        }
    }
}