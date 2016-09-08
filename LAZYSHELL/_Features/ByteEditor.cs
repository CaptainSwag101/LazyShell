using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LazyShell
{
    public partial class ByteEditor : Controls.NewForm
    {
        #region Variables

        private int count;
        private bool lockByte0;
        private byte[] bytes
        {
            get
            {
                byte[] value = new byte[nums.Count];
                for (int i = 0; i < nums.Count; i++)
                    value[i] = (byte)nums[i].Value;
                return value;
            }
            set
            {
                for (int i = 0; i < nums.Count && i < value.Length; i++)
                    nums[i].Value = value[i];
            }
        }
        private List<Label> labels;
        private List<NumericUpDown> nums;
        private Delegate applyFunction;

        // Constants
        private const int height = 96;
        private const int buttonY = 39;
        private const int labelX = 12;
        private const int labelY = 14;
        private const int numX = 93;
        private const int numY = 12;
        private const int numHeight = 21;
        private const int numWidth = 75;

        #endregion

        // Constructor
        public ByteEditor(Delegate applyFunction, bool lockByte0)
        {
            this.lockByte0 = lockByte0;
            this.applyFunction = applyFunction;
            InitializeComponent();
        }

        #region Methods

        public void LoadBytes(byte[] bytes)
        {
            this.count = bytes.Length;
            SetFormDimensions();
            CreateControlCollection();
            this.bytes = bytes;
        }
        private void SetFormDimensions()
        {
            this.Height = count * numHeight + height - numHeight;
            this.empty.Top = count * numHeight + buttonY - numHeight;
            this.apply.Top = count * numHeight + buttonY - numHeight;
            this.cancel.Top = count * numHeight + buttonY - numHeight;
        }
        private void CreateControlCollection()
        {
            if (nums != null && nums.Count == count)
                return;

            //
            for (int i = 0; i < this.Controls.Count; i++)
            {
                var control = this.Controls[i];
                if (control is NumericUpDown || control is Label)
                {
                    this.Controls.Remove(control);
                    i--;
                }
            }

            //
            this.labels = new List<Label>();
            this.nums = new List<NumericUpDown>();
            for (int i = 0; i < count; i++)
            {
                // Label
                var label = new Label();
                label.AutoSize = true;
                label.Location = new Point(labelX, i * numHeight + labelY);
                label.Text = "Byte " + i;
                this.labels.Add(label);
                this.Controls.Add(label);

                // NumericUpDown
                var num = new NumericUpDown();
                num.Hexadecimal = true;
                num.Location = new Point(numX, i * numHeight + numY);
                num.Maximum = 255;
                num.Width = numWidth;
                if (lockByte0 && i == 0)
                    num.Enabled = false;
                this.nums.Add(num);
                this.Controls.Add(num);
            }
        }

        #endregion

        #region Event Handlers

        // ByteEditor
        private void ByteEditor_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
                this.Location = new Point(Cursor.Position.X + 20, Cursor.Position.Y + 20);
        }

        // Buttons
        private void empty_Click(object sender, EventArgs e)
        {
            Bits.Fill(bytes, 0x0A);
        }
        private void apply_Click(object sender, EventArgs e)
        {
            applyFunction.DynamicInvoke(bytes);
        }
        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
