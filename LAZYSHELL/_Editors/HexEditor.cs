using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace LazyShell
{
    public partial class HexEditor : Controls.NewForm
    {
        #region Variables

        // ROM buffers
        private byte[] rom
        {
            get
            {
                return viewCurrent.Checked ? current : original;
            }
        }
        private byte[] current_unmodified;
        private byte[] current;
        private byte[] original;

        // Edit buffers
        private List<Change> oldChanges = new List<Change>();
        private List<Change> newChanges = new List<Change>();

        // Text
        private int selection
        {
            get { return ROMData.SelectionStart / 3 + offset; }
        }
        private bool atLowerNibble
        {
            get { return ROMData.SelectionStart % 3 == 1; }
        }
        private bool atUpperNibble = false;
        private int end
        {
            get { return ((line_count - 1) * 16 + 15) * 3; }
        }
        private int offset;
        private byte[] clipboard;
        private int last_line
        {
            get { return line_count * 16 + (offset & 0xFFFFF0); }
        }
        private int line_count
        {
            get
            {
                return (ROMOffsets.Height - 5) / 15;
            }
        }
        private int line
        {
            get
            {
                return ROMData.SelectionStart / (16 * 3);
            }
        }
        private int byte_count
        {
            get
            {
                return line_count * 16;
            }
        }
        private Controls.NewRichTextBox ROMData
        {
            get
            {
                return currentROMData.Visible ? currentROMData : originalROMData;
            }
            set
            {
                if (currentROMData.Visible)
                    currentROMData = value;
                else
                    originalROMData = value;
            }
        }
        private int selectionStart;
        private int selectionLength;
        private bool isMovingUpDown;

        // Forms
        private TextBoxForm searchForm;
        private TextBoxForm gotoAddressForm;
        private TextBoxForm fillBytesForm;

        // Functions
        private delegate void GotoAddressFunction(int input);
        private delegate void SearchFunction(byte[] input);
        private delegate void FillBytesFunction(int input);

        #endregion

        // Constructor
        public HexEditor(byte[] current, byte[] original)
        {
            this.current_unmodified = current;
            this.current = Bits.Copy(current);
            this.original = original;

            // Initialization
            InitializeComponent();
            CreateHelperForms();
            CreateShortcuts();
            LoadHexEditor();
        }

        #region Methods

        private void CreateShortcuts()
        {
            Do.AddShortcut(toolStrip2, Keys.F1, helpTips);
        }
        private void CreateHelperForms()
        {
            new ToolTipLabel(this, null, helpTips);
        }
        public void LoadHexEditor()
        {
            this.Updating = true;

            //
            vScrollBar1.Value = offset / 16;
            string bytes2 = "";
            string bytes3 = "";
            string offsets = "";

            // in case enlarging when at end of ROM
            while (last_line > current.Length)
                offset -= 16;

            //
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
            ROMOffsets.BeginUpdate();
            ROMOffsets.Text = offsets;
            ROMOffsets.EndUpdate();

            //
            ROMData.BeginUpdate();
            currentROMData.Text = bytes2;
            originalROMData.Text = bytes3;
            currentROMData.SelectionStart = 0;
            currentROMData.SelectionLength = currentROMData.Text.Length;
            currentROMData.SelectionColor = Color.DarkBlue;
            for (int offsetCounter = offset & 0xFFFFF0, i = 0; i < line_count * 16; i++)
            {
                // first set the length of the changed offsets, to colorize all at once (b/c faster)
                int changedStart = 0;
                int changedLength = 0;
                Change change = Do.FindOffset(oldChanges, offsetCounter++);
                if (change != null)
                {
                    changedStart = i * 3;
                    if (change.Values.Length == 1)
                    {
                        changedLength = 3;
                        while (Do.Contains(oldChanges, offsetCounter++))
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
                    currentROMData.SelectionStart = changedStart;
                    currentROMData.SelectionLength = changedLength;
                    currentROMData.SelectionColor = change.Color;
                }
            }
            currentROMData.SelectionStart = originalROMData.SelectionStart = selectionStart;
            currentROMData.SelectionLength = originalROMData.SelectionLength = selectionLength;
            ROMData.Focus();
            ROMData.EndUpdate();

            //
            UpdateInfoLabels();

            // Finished
            this.Updating = false;
        }

        /// <summary>
        /// Clears the memory stacks of the old and new properties containing
        /// a history of the changes made to the ROM's hex data.
        /// </summary>
        public void ClearChangeHistory()
        {
            oldChanges.Clear();
            newChanges.Clear();
        }
        /// <summary>
        /// Compares the current hex data and the unmodified hex data and redraws 
        /// the text in the textBox with a colored section marking the changes.
        /// </summary>
        public void HighlightChanges()
        {
            ClearChangeHistory();
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
                    oldChanges.Add(new Change(index, new byte[changedLength / 3], Color.Green));
            }
            current_unmodified.CopyTo(current, 0);
            LoadHexEditor();
        }

        // Helping methods
        private void GotoAddress(int input)
        {
            if (input >= 0 && input < 0x400000)
            {
                this.offset = input & 0xFFFFF0;
                if (line_count * 16 + input >= 0x400000)
                    this.offset = 0x400000 - (line_count * 16);
                this.selectionStart = Math.Max(0, (input - input - 1) * 3);
            }
            else if (input < 0x000000)
            {
                MessageBox.Show("Offset too low. Must be between $000000 and $3FFFFF.");
                return;
            }
            else if (input >= 0x400000)
            {
                MessageBox.Show("Offset too high. Must be between $000000 and $3FFFFF.");
                return;
            }
            LoadHexEditor();
            ROMData.Focus();
        }
        private void FillBytes(int input)
        {
            if (currentROMData.SelectionLength < 3)
                return;
            int column = ROMData.SelectionStart / 3;
            byte value = (byte)input;
            try
            {
                byte[] values = new byte[currentROMData.SelectionLength / 3];
                Bits.Fill(values, (byte)value);
                oldChanges.Add(new Change(offset + column,
                    Bits.GetBytes(current, offset + column, values.Length), Color.Red));
                Bits.Fill(current, (byte)value, offset + column, values.Length);
            }
            catch
            {
                return;
            }
            LoadHexEditor();
        }
        private void Search(byte[] input)
        {
            int offset, foundAt;
            offset = this.offset;
            foundAt = Bits.Find(rom, input, ROMData.SelectionStart / 3 + ROMData.SelectionLength + offset);
            if (foundAt != -1)
            {
                this.offset = foundAt & 0xFFFFF0;
                selectionStart = (foundAt & 15) * 3;
                selectionLength = input.Length * 3;
                LoadHexEditor();
            }
            else if (MessageBox.Show("Search string was not found.\n\n" + "Restart from beginning?", "LAZY SHELL",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                offset = this.offset;
                foundAt = Bits.Find(rom, input, 0);
                if (foundAt != -1)
                {
                    this.offset = foundAt & 0xFFFFF0;
                    selectionStart = (foundAt & 15) * 3;
                    selectionLength = input.Length * 3;
                    LoadHexEditor();
                }
                else
                    MessageBox.Show("Search string was not found.");
            }
        }

        /// <summary>
        /// Moves the cursor in the textBox to a specified offset in the ROM's hex data.
        /// </summary>
        /// <param name="offset">The offset to move the cursor to.</param>
        public void SetOffset(int offset)
        {
            this.offset = offset & 0xFFFFF0;
            this.selectionStart = (offset & 15) * 3;
            this.ROMData.SelectionStart = (offset & 15) * 3;
        }
        private void UpdateInfoLabels()
        {
            if (selection + 2 >= rom.Length)
                return;
            info_offset.Text = "Offset: " + selection.ToString("X6");
            if (ROMData.SelectionLength / 3 == 3)
                info_value.Text = "Value: " + Bits.GetInt24(rom, selection).ToString();
            else if (ROMData.SelectionLength / 3 == 2)
                info_value.Text = "Value: " + Bits.GetShort(rom, selection).ToString();
            else if (ROMData.SelectionLength / 3 <= 1)
                info_value.Text = "Value: " + rom[selection].ToString();
            else
                info_value.Text = "Value: ";
            int sel = ROMData.SelectionLength / 3;
            info_sel.Text = "Sel: 0x" + sel.ToString("X") + " (" + sel.ToString() + ") bytes";
        }

        #region Actions

        /// <summary>
        /// Changes the value of the byte's nibble that the cursor is currently at.
        /// </summary>
        /// <param name="value"></param>
        private void EditNibble(byte value)
        {
            int column = ROMData.SelectionStart / 3;
            if (value > 15)
                return;
            if (!currentROMData.Visible)
            {
                MessageBox.Show("Changing the original ROM's data is not allowed.");
                return;
            }
            oldChanges.Add(new Change(offset + column, current[offset + column], Color.Red));
            if (!atLowerNibble)
            {
                value <<= 4;
                current[offset + column] &= 0x0F;
                current[offset + column] |= value;
                LoadHexEditor();
                currentROMData.SelectionStart = selectionStart + 1;
            }
            else
            {
                current[offset + column] &= 0xF0;
                current[offset + column] |= value;
                LoadHexEditor();
                currentROMData.SelectionStart = selectionStart + 2;
            }
        }
        private void EditNibble(char keyValue)
        {
            byte value = 255;
            try
            {
                value = Convert.ToByte(keyValue.ToString(), 16);
                EditNibble(value);
            }
            catch
            {
                return;
            }
        }
        private void Undo()
        {
            if (oldChanges.Count == 0)
                return;
            int offset = oldChanges[oldChanges.Count - 1].Offset;
            byte[] oldValues = oldChanges[oldChanges.Count - 1].Values;
            oldChanges.RemoveAt(oldChanges.Count - 1);
            byte[] newValues = Bits.GetBytes(current, offset, oldValues.Length);
            newChanges.Add(new Change(offset, newValues, Color.Red));
            Bits.SetBytes(current, offset, oldValues);
            LoadHexEditor();
        }
        private void Redo()
        {
            if (newChanges.Count == 0)
                return;
            int offset = newChanges[newChanges.Count - 1].Offset;
            byte[] newValues = newChanges[newChanges.Count - 1].Values;
            newChanges.RemoveAt(newChanges.Count - 1);
            byte[] oldValues = Bits.GetBytes(current, offset, newValues.Length);
            oldChanges.Add(new Change(offset, oldValues, Color.Red));
            Bits.SetBytes(current, offset, newValues);
            LoadHexEditor();
        }
        private void Paste()
        {
            int column = ROMData.SelectionStart / 3;
            if (offset + column + clipboard.Length >= 0x400000)
                return;
            oldChanges.Add(new Change(offset + column,
                Bits.GetBytes(current, offset + column, clipboard.Length), Color.Red));
            Bits.SetBytes(current, offset + column, clipboard);
            LoadHexEditor();
        }
        private void Copy()
        {
            if (ROMData.SelectionLength < 3)
                return;
            int column = ROMData.SelectionStart / 3;
            clipboard = Bits.GetBytes(rom, offset + column, ROMData.SelectionLength / 3);
        }
        private void Save()
        {
            if (MessageBox.Show("Saving the ROM in the hex editor resets all elements in all other editors. " +
                "You will lose any changes made there since the last save.\n\n" +
                "Continue with process?", "LAZY SHELL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            current.CopyTo(current_unmodified, 0);
            Model.ClearAll();
            ClearChangeHistory();
            LoadHexEditor();
        }

        #endregion

        #endregion

        #region Event Handlers

        // HexEditor
        private void HexEditor_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
                this.Location = new Point(Cursor.Position.X + 10, Cursor.Position.Y + 10);
        }
        
        // Hex editing
        private void richTextBox_SelectionChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            this.Updating = true;

            // Check if selection beyond boundaries of hex data
            ROMData.BeginUpdate();
            if (ROMData.SelectionStart / 3 + offset >= rom.Length)
                ROMData.SelectionStart = end;
            else if (ROMData.SelectionStart % 3 == 2 && !atUpperNibble &&
                ROMData.SelectionStart / 3 + offset + 1 < rom.Length)
                ROMData.SelectionStart++;
            else if (ROMData.SelectionStart % 3 == 2 && atUpperNibble)
                ROMData.SelectionStart--;

            // Set upper nibble bool
            atUpperNibble = ROMData.SelectionStart % 3 == 0;

            // Update
            UpdateInfoLabels();
            ROMData.EndUpdate();

            // Finished
            this.Updating = false;
        }
        private void richTextBox_MouseUp(object sender, MouseEventArgs e)
        {
            selectionStart = ROMData.SelectionStart;
            selectionLength = ROMData.SelectionLength;
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
            LoadHexEditor();
        }
        private void richTextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // Synchronize selection if scrolling up/down
            if (!isMovingUpDown)
            {
                selectionStart = ROMData.SelectionStart;
                selectionLength = ROMData.SelectionLength;
            }

            // Execute method for keystroke
            switch (e.KeyData)
            {
                case Keys.Control | Keys.Z: Undo(); break;
                case Keys.Control | Keys.Y: Redo(); break;
                case Keys.Control | Keys.S: Save(); break;
                case Keys.Down:
                    if (line != line_count - 1)
                        break;
                    offset += 0x10;
                    if (offset + (line_count * 16) >= rom.Length)
                        offset = rom.Length - (line_count * 16);
                    LoadHexEditor();
                    isMovingUpDown = true;
                    break;
                case Keys.Up:
                    if (line != 0)
                        break;
                    offset -= 0x10;
                    if (offset < 0)
                        offset = 0;
                    LoadHexEditor();
                    isMovingUpDown = true;
                    break;
                case Keys.PageDown:
                    offset += line_count * 16;
                    if (offset >= rom.Length)
                        offset = rom.Length - (line_count * 16);
                    LoadHexEditor();
                    isMovingUpDown = true;
                    break;
                case Keys.PageUp:
                    offset -= (line_count * 16);
                    if (offset < 0)
                        offset = 0;
                    LoadHexEditor();
                    isMovingUpDown = true;
                    break;
                case Keys.Home:
                    selectionStart = 0;
                    offset = 0;
                    LoadHexEditor();
                    break;
                case Keys.End:
                    selectionStart = line_count * 16 * 3 - 3;
                    offset = rom.Length - (line_count * 16);
                    LoadHexEditor();
                    break;
                default: EditNibble((char)e.KeyValue); break;
            }
        }
        private void richTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (isMovingUpDown)
                ROMData.SelectionStart = selectionStart;
            isMovingUpDown = false;
        }

        // VScrollBar
        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            if (this.Updating)
                return;
            offset = Math.Min(vScrollBar1.Value * 16, 0x400000 - (line_count * 16));
            LoadHexEditor();
        }

        // Data management
        private void save_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void copy_Click(object sender, EventArgs e)
        {
            Copy();
        }
        private void paste_Click(object sender, EventArgs e)
        {
            Paste();
        }
        private void undo_Click(object sender, EventArgs e)
        {
            Undo();
        }
        private void redo_Click(object sender, EventArgs e)
        {
            Redo();
        }

        // Switch ROMs
        private void viewCurrent_Click(object sender, EventArgs e)
        {
            viewOriginal.Checked = false;
            currentROMData.Show();
            originalROMData.Hide();
            viewCurrent.Checked = true;
            LoadHexEditor();
            ROMData.Focus();
            ROMData.SelectionStart = selectionStart;
            ROMData.SelectionLength = selectionLength;
        }
        private void viewOriginal_Click(object sender, EventArgs e)
        {
            viewCurrent.Checked = false;
            originalROMData.Show();
            currentROMData.Hide();
            viewOriginal.Checked = true;
            LoadHexEditor();
            ROMData.Focus();
            ROMData.SelectionStart = selectionStart;
            ROMData.SelectionLength = selectionLength;
        }

        // Helper forms
        private void gotoAddress_Click(object sender, EventArgs e)
        {
            if (gotoAddressForm == null)
            {
                gotoAddressForm = new TextBoxForm(true, false, true, 6, new GotoAddressFunction(GotoAddress), "GOTO ADDRESS");
                gotoAddressForm.Owner = this;
            }
            gotoAddressForm.Show();
        }
        private void search_Click(object sender, EventArgs e)
        {
            if (searchForm == null)
            {
                searchForm = new TextBoxForm(true, true, true, 0, new SearchFunction(Search), "SEARCH FOR VALUES");
                searchForm.Owner = this;
            }
            searchForm.Show();
        }
        private void baseConvertor_Click(object sender, EventArgs e)
        {
            Model.BaseConvertorForm.Show();
            Model.BaseConvertorForm.Activate();
        }
        private void fillBytes_Click(object sender, EventArgs e)
        {
            if (fillBytesForm == null)
            {
                fillBytesForm = new TextBoxForm(true, false, true, 0, new FillBytesFunction(FillBytes), "FILL WITH VALUE");
                fillBytesForm.Owner = this;
            }
            fillBytesForm.Show();
        }

        #endregion

        public class Change
        {
            public int Offset;
            public byte[] Values;
            public byte Value
            {
                get { return Values[0]; }
            }
            public int Length
            {
                get { return Values.Length; }
            }
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
