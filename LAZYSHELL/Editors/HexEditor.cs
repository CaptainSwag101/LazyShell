using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace LAZYSHELL
{
    public partial class HexEditor : Form
    {
        #region Variables
        private byte[] data
        {
            get
            {
                return viewCurrent.Checked ? current : original;
            }
        }
        private byte[] current_unmodified;
        private byte[] current;
        private byte[] original;
        private int selection { get { return richTextBox.SelectionStart / 3 + offset; } }
        private bool updating = false;
        private bool atLowerNibble { get { return richTextBox.SelectionStart % 3 == 1; } }
        private bool atUpperNibble = false;
        private int end { get { return ((line_count - 1) * 16 + 15) * 3; } }
        private int offset; public int Offset { get { return offset; } set { offset = value; } }
        private List<Change> oldProperties = new List<Change>();
        private List<Change> newProperties = new List<Change>();
        private byte[] clipboard;
        private int line_count
        {
            get
            {
                return (richTextBox1.Height - 5) / 15;
            }
        }
        private int line
        {
            get
            {
                return richTextBox.SelectionStart / (16 * 3);
            }
        }
        private int byte_count
        {
            get
            {
                return line_count * 16;
            }
        }
        private NewRichTextBox richTextBox
        {
            get
            {
                return richTextBox2.Visible ? richTextBox2 : richTextBox3;
            }
            set
            {
                if (richTextBox2.Visible)
                    richTextBox2 = value;
                else
                    richTextBox3 = value;
            }
        }
        private int selectionStart;
        public int SelectionStart { get { return selectionStart; } set { selectionStart = value; } }
        private int selectionLength;
        private bool isMovingUpDown;
        #endregion
        #region Functions
        public HexEditor()
        {
        }
        public HexEditor(byte[] current, byte[] original)
        {
            this.current_unmodified = current;
            this.current = Bits.Copy(current);
            this.original = original;
            InitializeComponent();
            RefreshHexEditor();
        }
        public void ClearMemory()
        {
            oldProperties.Clear();
            newProperties.Clear();
        }
        public void Compare()
        {
            ClearMemory();
            for (int offset = 0; offset < 0x400000; offset++)
            {
                int changedStart = 0;
                int changedLength = 0;
                int index = offset;
                while (current_unmodified[offset] != current[offset])
                {
                    changedStart = offset++;
                    changedLength += 3;
                }
                if (changedLength > 0)
                    oldProperties.Add(new Change(index, new byte[changedLength / 3], Color.Green));
            }
            current_unmodified.CopyTo(current, 0);
            RefreshHexEditor();
        }
        public void RefreshHexEditor()
        {
            updating = true;
            vScrollBar1.Value = offset / 16;
            string bytes2 = "";
            string bytes3 = "";
            string offsets = "";
            int offset_line = offset & 0xFFFFF0;
            for (int i = 0; i < line_count; i++)
            {
                offsets += (i * 16 + offset_line).ToString("X6");
                if (i < line_count - 1)
                    offsets += "\r";
                for (int a = 0; a < 16; a++)
                {
                    bytes2 += (current[i * 16 + offset_line + a]).ToString("X2") + " ";
                    bytes3 += (original[i * 16 + offset_line + a]).ToString("X2") + " ";
                }
            }
            //
            richTextBox1.BeginUpdate();
            richTextBox1.Text = offsets;
            richTextBox1.EndUpdate();
            //
            richTextBox.BeginUpdate();
            richTextBox2.Text = bytes2;
            richTextBox3.Text = bytes3;
            richTextBox2.SelectionStart = 0;
            richTextBox2.SelectionLength = richTextBox2.Text.Length;
            richTextBox2.SelectionColor = Color.DarkBlue;
            for (int offsetCounter = offset & 0xFFFFF0, i = 0; i < line_count * 16; i++)
            {
                // first set the length of the changed offsets, to colorize all at once (b/c faster)
                int changedStart = 0;
                int changedLength = 0;
                Change change = Do.FindOffset(oldProperties, offsetCounter++);
                if (change != null)
                {
                    changedStart = i * 3;
                    if (change.Values.Length == 1)
                    {
                        changedLength = 3;
                        while (Do.Contains(oldProperties, offsetCounter++))
                            changedLength += 3;
                        i += changedLength / 3;
                    }
                    else
                    {
                        offsetCounter--;
                        changedLength = (change.Values.Length - (offsetCounter - change.Offset)) * 3;
                        i += changedLength / 3;
                        offsetCounter += changedLength / 3;
                        offsetCounter++;
                    }
                }
                if (changedLength > 0)
                {
                    richTextBox2.SelectionStart = changedStart;
                    richTextBox2.SelectionLength = changedLength;
                    richTextBox2.SelectionColor = change.Color;
                }
            }
            richTextBox2.SelectionStart = richTextBox3.SelectionStart = selectionStart;
            richTextBox2.SelectionLength = richTextBox3.SelectionLength = selectionLength;
            richTextBox.Focus();
            richTextBox.EndUpdate();
            //
            UpdateInformationLabels();
            updating = false;
        }
        private void UpdateInformationLabels()
        {
            info_offset.Text = "Offset: " + selection.ToString("X6");
            if (richTextBox.SelectionLength / 3 == 3)
                info_value.Text = "Value: " + Bits.Get24Bit(data, selection).ToString();
            else if (richTextBox.SelectionLength / 3 == 2)
                info_value.Text = "Value: " + Bits.GetShort(data, selection).ToString();
            else if (richTextBox.SelectionLength / 3 <= 1)
                info_value.Text = "Value: " + data[selection].ToString();
            else
                info_value.Text = "Value: ";
            int sel = richTextBox.SelectionLength / 3;
            info_sel.Text = "Sel: 0x" + sel.ToString("X") + " (" + sel.ToString() + ") bytes";
        }
        #endregion
        #region Event Handlers
        private void HexViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
        private void richTextBox_SelectionChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            richTextBox.BeginUpdate();
            if (richTextBox.SelectionStart / 3 + offset >= data.Length)
                richTextBox.SelectionStart = end;
            else if (richTextBox.SelectionStart % 3 == 2 && !atUpperNibble &&
                richTextBox.SelectionStart / 3 + offset + 1 < data.Length)
                richTextBox.SelectionStart++;
            else if (richTextBox.SelectionStart % 3 == 2 && atUpperNibble)
                richTextBox.SelectionStart--;
            atUpperNibble = richTextBox.SelectionStart % 3 == 0;
            UpdateInformationLabels();
            richTextBox.EndUpdate();
            updating = false;
        }
        private void richTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            //offset += richTextBox2.SelectionStart / 3;
        }
        private void richTextBox_MouseUp(object sender, MouseEventArgs e)
        {
            selectionStart = richTextBox.SelectionStart;
            selectionLength = richTextBox.SelectionLength;
        }
        private void richTextBox_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Delta > 0 && vScrollBar1.Value > 0)
                vScrollBar1.Value--;
            else if (e.Delta < 0 && vScrollBar1.Value < vScrollBar1.Maximum)
                vScrollBar1.Value++;
        }
        private void richTextBox_SizeChanged(object sender, EventArgs e)
        {
            RefreshHexEditor();
        }
        private void richTextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            int column = richTextBox.SelectionStart / 3;
            if (!isMovingUpDown)
            {
                selectionStart = richTextBox.SelectionStart;
                selectionLength = richTextBox.SelectionLength;
            }
            switch (e.KeyData)
            {
                case Keys.Control | Keys.Z:
                    undo_Click(null, null);
                    break;
                case Keys.Control | Keys.Y:
                    redo_Click(null, null);
                    break;
                case Keys.Control | Keys.S:
                    save_Click(null, null);
                    break;
                case Keys.Down:
                    if (line != line_count - 1)
                        break;
                    offset += 0x10;
                    if (offset + (line_count * 16) >= data.Length)
                        offset = data.Length - (line_count * 16);
                    RefreshHexEditor();
                    isMovingUpDown = true;
                    break;
                case Keys.Up:
                    if (line != 0)
                        break;
                    offset -= 0x10;
                    if (offset < 0)
                        offset = 0;
                    RefreshHexEditor();
                    isMovingUpDown = true;
                    break;
                case Keys.PageDown:
                    offset += line_count * 16;
                    if (offset >= data.Length)
                        offset = data.Length - (line_count * 16);
                    RefreshHexEditor();
                    isMovingUpDown = true;
                    break;
                case Keys.PageUp:
                    offset -= (line_count * 16);
                    if (offset < 0)
                        offset = 0;
                    RefreshHexEditor();
                    isMovingUpDown = true;
                    break;
                case Keys.Home:
                    selectionStart = 0;
                    offset = 0;
                    RefreshHexEditor();
                    break;
                case Keys.End:
                    selectionStart = line_count * 16 * 3 - 3;
                    offset = data.Length - (line_count * 16);
                    RefreshHexEditor();
                    break;
                default:
                    byte value = 255;
                    try
                    {
                        value = Convert.ToByte(((char)e.KeyValue).ToString(), 16);
                    }
                    catch
                    {
                        break;
                    }
                    if (value > 15)
                        break;
                    if (!richTextBox2.Visible)
                    {
                        MessageBox.Show("Changing the original ROM's data is not allowed.");
                        break;
                    }
                    oldProperties.Add(new Change(offset + column, current[offset + column], Color.Red));
                    if (!atLowerNibble)
                    {
                        value <<= 4;
                        current[offset + column] &= 0x0F;
                        current[offset + column] |= value;
                        RefreshHexEditor();
                        richTextBox2.SelectionStart = selectionStart + 1;
                    }
                    else
                    {
                        current[offset + column] &= 0xF0;
                        current[offset + column] |= value;
                        RefreshHexEditor();
                        richTextBox2.SelectionStart = selectionStart + 2;
                    }
                    break;
            }
        }
        private void richTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (isMovingUpDown)
                richTextBox.SelectionStart = selectionStart;
            isMovingUpDown = false;
        }
        private void richTextBox_KeyDown(object sender, KeyEventArgs e)
        {
        }
        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            offset = Math.Min(vScrollBar1.Value * 16, 0x400000 - (line_count * 16));
            RefreshHexEditor();
        }
        // toolstrip2
        private void save_Click(object sender, EventArgs e)
        {
            current.CopyTo(current_unmodified, 0);
            Model.ClearModel();
            ClearMemory();
            RefreshHexEditor();
        }
        private void copy_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectionLength < 3) return;
            int column = richTextBox.SelectionStart / 3;
            clipboard = Bits.GetByteArray(data, offset + column, richTextBox.SelectionLength / 3);
        }
        private void paste_Click(object sender, EventArgs e)
        {
            int column = richTextBox.SelectionStart / 3;
            if (offset + column + clipboard.Length >= 0x400000)
                return;

            oldProperties.Add(new Change(offset + column,
                Bits.GetByteArray(current, offset + column, clipboard.Length), Color.Red));
            Bits.SetByteArray(current, offset + column, clipboard);
            RefreshHexEditor();
        }
        private void undo_Click(object sender, EventArgs e)
        {
            if (oldProperties.Count == 0) return;

            int offset = oldProperties[oldProperties.Count - 1].Offset;

            byte[] oldValues = oldProperties[oldProperties.Count - 1].Values;
            oldProperties.RemoveAt(oldProperties.Count - 1);

            byte[] newValues = Bits.GetByteArray(current, offset, oldValues.Length);
            newProperties.Add(new Change(offset, newValues, Color.Red));

            Bits.SetByteArray(current, offset, oldValues);

            RefreshHexEditor();
        }
        private void redo_Click(object sender, EventArgs e)
        {
            if (newProperties.Count == 0) return;

            int offset = newProperties[newProperties.Count - 1].Offset;

            byte[] newValues = newProperties[newProperties.Count - 1].Values;
            newProperties.RemoveAt(newProperties.Count - 1);

            byte[] oldValues = Bits.GetByteArray(current, offset, newValues.Length);
            oldProperties.Add(new Change(offset, oldValues, Color.Red));

            Bits.SetByteArray(current, offset, newValues);

            RefreshHexEditor();
        }
        private void fillWith_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter) return;
            if (richTextBox2.SelectionLength < 3) return;
            int column = richTextBox.SelectionStart / 3;
            byte value;
            try
            {
                value = Convert.ToByte(fillWith.Text, 16);
                byte[] values = new byte[richTextBox2.SelectionLength / 3];
                Bits.Fill(values, value);
                oldProperties.Add(new Change(offset + column,
                    Bits.GetByteArray(current, offset + column, values.Length), Color.Red));
                Bits.Fill(current, value, offset + column, values.Length);
            }
            catch
            {
                return;
            }
            RefreshHexEditor();
        }
        private void baseConvDec_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            try
            {
                long value = Convert.ToInt64(baseConvDec.Text, 10);
                if (value <= 0xFFFFFFFF)
                    baseConvHex.Text = value.ToString("X");
            }
            catch
            {
                baseConvHex.Text = "";
            }
            updating = false;
        }
        private void baseConvHex_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            try
            {
                long value = Convert.ToInt64(baseConvHex.Text, 16);
                baseConvDec.Text = value.ToString();
            }
            catch
            {
                baseConvDec.Text = "";
            }
            updating = false;
        }
        // toolstrip1
        private void viewCurrent_Click(object sender, EventArgs e)
        {
            viewOriginal.Checked = false;
            richTextBox2.Show();
            richTextBox3.Hide();
            viewCurrent.Checked = true;
            RefreshHexEditor();
            richTextBox.Focus();
            richTextBox.SelectionStart = selectionStart;
            richTextBox.SelectionLength = selectionLength;
        }
        private void viewOriginal_Click(object sender, EventArgs e)
        {
            viewCurrent.Checked = false;
            richTextBox3.Show();
            richTextBox2.Hide();
            viewOriginal.Checked = true;
            RefreshHexEditor();
            richTextBox.Focus();
            richTextBox.SelectionStart = selectionStart;
            richTextBox.SelectionLength = selectionLength;
        }
        private void gotoAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
                return;
            try
            {
                int input = Convert.ToInt32(gotoAddress.Text, 16);
                if (input >= 0 && input < 0x400000)
                {
                    offset = input & 0xFFFFF0;
                    if (line_count * 16 + offset >= 0x400000)
                        offset = 0x400000 - (line_count * 16);
                    selectionStart = (input - offset - 1) * 3;
                }
                else if (input < 0x000000)
                {
                    MessageBox.Show("Offset too low. Must be between $000000 and $2FFFFF.");
                    return;
                }
                else if (input >= 0x400000)
                {
                    MessageBox.Show("Offset too high. Must be between $000000 and $2FFFFF.");
                    return;
                }
            }
            catch
            {
            }
            finally
            {
                RefreshHexEditor();
                richTextBox.Focus();
            }
        }
        private void searchValues_KeyDown(object sender, KeyEventArgs e)
        {
            if (searchValues.Text == "" ||
                searchValues.Text.Length % 2 != 0 ||
                e.KeyData != Keys.Enter)
                return;
            try
            {
                byte[] values = new byte[searchValues.Text.Length / 2];
                for (int i = 0; i < searchValues.Text.Length / 2; i++)
                {
                    string ascii = searchValues.Text.Substring(i * 2, 2);
                    byte value = Convert.ToByte(ascii, 16);
                    values[i] = value;
                }
                int offset, foundAt;

                offset = this.offset;
                foundAt = Bits.Find(data, values, richTextBox.SelectionStart / 3 + richTextBox.SelectionLength + offset);
                if (foundAt != -1)
                {
                    this.offset = foundAt & 0xFFFFF0;
                    selectionStart = (foundAt & 15) * 3;
                    selectionLength = values.Length * 3;
                    RefreshHexEditor();
                    searchValues.Focus();
                }
                else if (MessageBox.Show("Search string was not found.\n\n" + "Restart from beginning?", "ZONE DOCTOR",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    offset = this.offset;
                    foundAt = Bits.Find(data, values, 0);
                    if (foundAt != -1)
                    {
                        this.offset = foundAt & 0xFFFFF0;
                        selectionStart = (foundAt & 15) * 3;
                        selectionLength = values.Length * 3;
                        RefreshHexEditor();
                        searchValues.Focus();
                    }
                    else
                        MessageBox.Show("Search string was not found.");
                }
            }
            catch
            {
                MessageBox.Show("Invalid search string.");
            }
        }
        #endregion
        public class Change
        {
            public int Offset;
            public byte[] Values;
            public byte Value { get { return Values[0]; } }
            public int Length { get { return Values.Length; } }
            public Change(int offset, byte value, Color color)
            {
                Offset = offset;
                Values = new byte[] { value };
                Color = color;
            }
            public Change(int offset, byte[] values, Color color)
            {
                Offset = offset;
                Values = Bits.Copy(values);
                Color = color;
            }
            public Color Color;
        }
    }
}
