using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using LAZYSHELL.Properties;
using LAZYSHELL.ScriptsEditor.Commands;

namespace LAZYSHELL
{
    public partial class SPCEditor
    {
        #region Variables
        List<Staff> staffs = new List<Staff>();
        ToolStripButton insertObject;
        private int mouseOverStaff = -1;
        private Pitch mouseOverPitch = Pitch.None;
        private int mouseOverLine = -1;
        private int mouseOverOctave = -1;
        private int mouseDownStaff = -1;
        private int mouseOverNote = -1;
        private int mouseDownNote = -1;
        private Point mousePosition = new Point(-1, -1);
        private Bitmap clefF = Resources.clefF;
        private Bitmap clefG = Resources.clefG;
        private Bitmap insert = Resources.insert;
        private int timeBeats
        {
            get
            {
                if (scoreWriter.Checked)
                    return (int)timeBeatsSW.Value;
                else
                    return (int)timeBeatsSV.Value;
            }
            set
            {
                if (scoreWriter.Checked)
                    timeBeatsSW.Value = value;
                else
                    timeBeatsSV.Value = value;
            }
        }
        private int timeValue
        {
            get
            {
                if (scoreWriter.Checked)
                    return (int)timeValueSW.Value;
                else
                    return (int)timeValueSV.Value;
            }
            set
            {
                if (scoreWriter.Checked)
                    timeValueSW.Value = value;
                else
                    timeValueSV.Value = value;
            }
        }
        private int staffHeight
        {
            get
            {
                if (scoreWriter.Checked)
                    return (int)staffHeightSW.Value;
                else
                    return (int)staffHeightSV.Value;
            }
            set
            {
                if (scoreWriter.Checked)
                    staffHeightSW.Value = value;
                else
                    staffHeightSV.Value = value;
            }
        }
        private int noteSpacing
        {
            get
            {
                if (scoreWriter.Checked)
                    return (int)noteSpacingSW.Value;
                else
                    return (int)noteSpacingSV.Value;
            }
            set
            {
                if (scoreWriter.Checked)
                    noteSpacingSW.Value = value;
                else
                    noteSpacingSV.Value = value;
            }
        }
        #endregion
        #region Functions
        private void RefreshScoreWriter()
        {
        }
        private void RefreshStaff()
        {
            if (staffs.Count == 0)
                return;
            clef.SelectedIndex = staffs[mouseDownStaff].Clef;
            key.SelectedIndex = (int)staffs[mouseDownStaff].Key;
            //
            foreach (ToolStripItem item in wToolStrip1.Items)
                item.Enabled = true;
            wToolStrip2.Enabled = true;
        }
        private List<SPCCommand>[] StaffsToChannels()
        {
            List<SPCCommand>[] channels = new List<SPCCommand>[8];
            for (int c = 0; c < 8 && c < staffs.Count; c++)
            {
                int thisOctave = -1;
                channels[c] = new List<SPCCommand>();
                foreach (object item in staffs[c].Notes)
                {
                    Note note = (Note)item;
                    if (note.Octave == thisOctave + 1)
                    {
                        channels[c].Add(new SPCCommand(new byte[] { 0xC4 }, spc, c));
                        thisOctave++;
                    }
                    else if (note.Octave == thisOctave - 1)
                    {
                        channels[c].Add(new SPCCommand(new byte[] { 0xC5 }, spc, c));
                        thisOctave--;
                    }
                    else if (note.Octave != thisOctave)
                    {
                        channels[c].Add(new SPCCommand(new byte[] { 0xC6, (byte)note.Octave }, spc, c));
                        thisOctave = note.Octave;
                    }
                    channels[c].Add(note.Command);
                }
            }
            return channels;
        }
        private int DrawNote(Graphics g, Note note, int x, int staffHeight, int clef, int staffIndex)
        {
            return DrawNote(g, note, x, staffHeight, clef, staffIndex, false, 0);
        }
        private int DrawNote(Graphics g, Note note, int x, int staffHeight, int clef, int staffIndex, bool hilite, int hold)
        {
            int pitch = note.Octave * 12 + (int)note.Pitch;
            int y = staffIndex * staffHeight;
            int middle = staffHeight / 2;
            int yCoord = y + middle;
            int clefOffset = 0;
            if (clef == 0) clefOffset = -4;
            else if (clef == 1) clefOffset = 4;
            Bitmap stem = null;
            Bitmap head = null;
            if (!note.Rest && !note.Hold)
            {
                int ticks = note.Ticks + hold;
                yCoord = y + middle + note.Y + clefOffset - 4;
                if (ticks >= 192) { head = Icons.noteEmpty; }
                else if (ticks >= 144) { head = Icons.noteEmpty; }
                else if (ticks >= 96) { head = Icons.noteEmpty; stem = pitch >= 59 ? Icons.noteStemDown : Icons.noteStemUp; }
                else if (ticks >= 72) { head = Icons.noteHeadDotted; stem = pitch >= 59 ? Icons.noteStemDown : Icons.noteStemUp; }
                else if (ticks >= 64) { head = Icons.noteEmptyTriplet; stem = pitch >= 59 ? Icons.noteStemDown : Icons.noteStemUp; }
                else if (ticks >= 48) { head = Icons.noteHead; stem = pitch >= 59 ? Icons.noteStemDown : Icons.noteStemUp; }
                else if (ticks >= 36) { head = Icons.noteHeadDotted; stem = pitch >= 59 ? Icons.noteStemDown8th : Icons.noteStemUp8th; }
                else if (ticks >= 32) { head = Icons.noteHeadTriplet; stem = pitch >= 59 ? Icons.noteStemDown : Icons.noteStemUp; }
                else if (ticks >= 24) { head = Icons.noteHead; stem = pitch >= 59 ? Icons.noteStemDown8th : Icons.noteStemUp8th; }
                else if (ticks >= 18) { head = Icons.noteHeadDotted; stem = pitch >= 59 ? Icons.noteStemDown16th : Icons.noteStemUp16th; }
                else if (ticks >= 16) { head = Icons.noteHeadTriplet; stem = pitch >= 59 ? Icons.noteStemDown8th : Icons.noteStemUp8th; }
                else if (ticks >= 12) { head = Icons.noteHead; stem = stem = pitch >= 59 ? Icons.noteStemDown16th : Icons.noteStemUp16th; }
                else if (ticks >= 9) { head = Icons.noteHeadDotted; stem = pitch >= 59 ? Icons.noteStemDown32nd : Icons.noteStemUp32nd; }
                else if (ticks >= 8) { head = Icons.noteHeadTriplet; stem = pitch >= 59 ? Icons.noteStemDown16th : Icons.noteStemUp16th; }
                else if (ticks >= 6) { head = Icons.noteHead; stem = pitch >= 59 ? Icons.noteStemDown32nd : Icons.noteStemUp32nd; }
                else if (ticks >= 4) { head = Icons.noteHeadTriplet; stem = pitch >= 59 ? Icons.noteStemDown32nd : Icons.noteStemUp32nd; }
                else if (ticks >= 3) { head = Icons.noteHead; stem = pitch >= 59 ? Icons.noteStemDown64th : Icons.noteStemUp64th; }
                else if (ticks >= 2) { head = Icons.noteHeadTriplet; stem = pitch >= 59 ? Icons.noteStemDown64th : Icons.noteStemUp64th; }
                else if (ticks >= 1) { head = Icons.noteHead; stem = Icons.note64th; }
                else { head = Icons.noteHead; stem = Icons.note64th; }
                Bitmap sharp = Icons.sharp;
                if (!note.Percussive)
                {
                    if (hilite)
                    {
                        head = Do.Fill(head, Color.Red);
                        if (stem != null)
                            stem = Do.Fill(stem, Color.Red);
                        sharp = Do.Fill(sharp, Color.Red);
                    }
                    // draw extra lines
                    DrawOutsideLines(g, Pens.Gray, x + 7, y, middle, clef, note.Octave, note.Pitch, note.Line);
                    if (stem != null)
                        g.DrawImage(stem, x, pitch < 59 ? yCoord : yCoord + 12);
                    g.DrawImage(head, x, yCoord);
                    if (note.Sharp)
                        g.DrawImage(sharp, x - 2, yCoord + 4);
                }
                else
                    g.DrawImage(hilite ? Do.Fill(Icons.notePercussion, Color.Red) : Icons.notePercussion, x, yCoord);
            }
            else if (note.Rest)
            {
                int ticks = note.Ticks;
                yCoord = y + middle + clefOffset - 4;
                if (ticks >= 192) { head = Icons.restWhole; }
                else if (ticks >= 144) { head = Icons.restHalfDotted; }
                else if (ticks >= 96) { head = Icons.restHalf; }
                else if (ticks >= 72) { head = Icons.restQuarterDotted; }
                else if (ticks >= 64) { head = Icons.restHalfTriplet; }
                else if (ticks >= 48) { head = Icons.restQuarter; }
                else if (ticks >= 36) { head = Icons.rest8thDotted; }
                else if (ticks >= 32) { head = Icons.restQuarterTriplet; }
                else if (ticks >= 24) { head = Icons.rest8th; }
                else if (ticks >= 18) { head = Icons.rest16thDotted; }
                else if (ticks >= 16) { head = Icons.rest8thTriplet; }
                else if (ticks >= 12) { head = Icons.rest16th; }
                else if (ticks >= 9) { head = Icons.rest32ndDotted; }
                else if (ticks >= 8) { head = Icons.rest16thTriplet; }
                else if (ticks >= 6) { head = Icons.rest32nd; }
                else if (ticks >= 4) { head = Icons.rest32ndTriplet; }
                else if (ticks >= 3) { head = Icons.rest64th; }
                else if (ticks >= 2) { head = Icons.rest64thTriplet; }
                else if (ticks >= 1) { head = Icons.rest64th; }
                else { head = Icons.rest64th; }
                if (hilite) head = Do.Fill(head, Color.Red);
                if (!scoreWriter.Checked && showRests.Checked)
                    g.DrawImage(head, x, yCoord);
                else if (scoreWriter.Checked)
                    g.DrawImage(head, x, yCoord);
            }
            return yCoord;
        }
        private void DrawBarsLines(Graphics g, int clef, int staffIndex, int xOffset, bool drawClefs)
        {
            int width = (int)g.ClipBounds.Width;
            int height = staffHeight;
            int x = xOffset;
            int y = staffIndex * height;
            Pen pen = new Pen(Color.Gray); pen.DashStyle = DashStyle.Dot;
            g.DrawLine(pen,
                0, staffIndex * height + 4,
                width, staffIndex * height + 4);
            g.DrawLine(pen,
                0, staffIndex * height + height - 4,
                width, staffIndex * height + height - 4);
            pen.DashStyle = DashStyle.Solid;
            int middle = height / 2;
            g.DrawLine(pen, 0, y + middle - 16, width, y + middle - 16);
            g.DrawLine(pen, 0, y + middle - 8, width, y + middle - 8);
            g.DrawLine(pen, 0, y + middle, width, y + middle);
            g.DrawLine(pen, 0, y + middle + 8, width, y + middle + 8);
            g.DrawLine(pen, 0, y + middle + 16, width, y + middle + 16);
            // draw bars
            pen.Width = 6;
            g.DrawLine(pen, x, y + middle - 16, x, y + middle + 16);
            pen.Width = 1;
            g.DrawLine(pen, x + 8, y + middle - 16, x + 8, y + middle + 16);
            // draw clefs
            if (drawClefs)
            {
                if (clef == 0)
                    g.DrawImage(clefG, x + 16, y + middle - 24);
                else if (clef == 1)
                    g.DrawImage(clefF, x + 16, y + middle - 24);
            }
            // draw time sig and measure bar lines
            int measureTop = (staffIndex * height) + (height / 2) - 16;
            int measureLength = (int)((double)timeBeats / (double)timeValue * 192.0);
            measureLength = (int)((double)noteSpacing / 100.0 * measureLength);
            int measureLeft = measureLength + 64 + xOffset;
            while (measureLeft < width)
            {
                g.DrawLine(Pens.Gray, measureLeft, measureTop, measureLeft, measureTop + 32);
                measureLeft += measureLength;
            }
            Font font = new Font("Times New Roman", 18, FontStyle.Bold);
            if (timeBeats >= 10)
                g.DrawString(timeBeats.ToString(), font, Brushes.Black, 40 + xOffset - 6, measureTop - 4);
            else
                g.DrawString(timeBeats.ToString(), font, Brushes.Black, 40 + xOffset, measureTop - 4);
            if (timeValue >= 10)
                g.DrawString(timeValue.ToString(), font, Brushes.Black, 40 + xOffset - 6, measureTop + 12);
            else
                g.DrawString(timeValue.ToString(), font, Brushes.Black, 40 + xOffset, measureTop + 12);
        }
        private void DrawOutsideLines(
            Graphics g, Pen pen, int x, int y, int middle,
            int clef, int octave, Pitch pitch, int line)
        {
            int count = -1;
            bool drawUpperLines = false;
            bool drawLowerLines = false;
            int totalPitch = octave * 12 + (int)pitch;
            if (clef == 0 && totalPitch >= 69)
            {
                count = (octave - 5) * 7 + line - 5;
                drawUpperLines = true;
            }
            else if (clef == 1 && totalPitch >= 72)
            {
                count = (octave - 5) * 7 + line - 7;
                drawUpperLines = true;
            }
            if (clef == 0 && totalPitch <= 49)
            {
                count = (4 - octave) * 7 - line + 2;
                drawLowerLines = true;
            }
            else if (clef == 1 && totalPitch <= 53)
            {
                count = (4 - octave) * 7 - line + 4;
                drawLowerLines = true;
            }
            count /= 2;
            if (drawUpperLines)
            {
                while (count-- >= 0)
                    g.DrawLine(pen,
                        x - 6, y + middle - 32 - (count * 8),
                        x + 6, y + middle - 32 - (count * 8));
            }
            if (drawLowerLines)
            {
                while (count-- > 0)
                    g.DrawLine(pen,
                        x - 6, y + middle + 24 + (count * 8),
                        x + 6, y + middle + 24 + (count * 8));
            }
        }
        private void SetScrollBars()
        {
            int maximum = 0;
            for (int i = 0; i < staffs.Count; i++)
            {
                foreach (object item in staffs[i].Notes)
                {
                    if (item.GetType() != typeof(Note))
                        continue;
                    Note note = (Note)item;
                    maximum += note.Ticks;
                    if (maximum > hScrollBar3.Maximum)
                        hScrollBar3.Maximum = maximum;
                }
            }
            scoreWriterPicture.Invalidate();
        }
        #endregion
        #region Event Handlers
        private void scoreWriter_Click(object sender, EventArgs e)
        {
            groupBox6.Visible = scoreWriter.Checked;
            groupBox6.BringToFront();
        }
        private void hScrollBar3_ValueChanged(object sender, EventArgs e)
        {
            scoreWriterPicture.Invalidate();
        }
        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            scoreWriterPicture.Invalidate();
        }
        //
        private void writer_Click(object sender, EventArgs e)
        {
            ToolStripButton insertObject = (ToolStripButton)sender;
            foreach (ToolStripItem item in wToolStrip1.Items)
                if (item.GetType() == typeof(ToolStripButton) &&
                    item != insertObject)
                    ((ToolStripButton)item).Checked = false;
            foreach (ToolStripItem item in wToolStrip2.Items)
                if (item.GetType() == typeof(ToolStripButton) &&
                    item != insertObject &&
                    item != wSharp &&
                    item != wNatural &&
                    item != wFlat)
                    ((ToolStripButton)item).Checked = false;
            if (insertObject.Checked)
            {
                this.insertObject = insertObject;
                scoreWriterPicture.Cursor = NewCursors.Draw;
            }
            else
            {
                this.insertObject = null;
                scoreWriterPicture.Cursor = Cursors.Arrow;
            }
        }
        private void wErase_Click(object sender, EventArgs e)
        {
            foreach (ToolStripItem item in wToolStrip2.Items)
                if (item.GetType() == typeof(ToolStripButton) && item != wErase)
                    ((ToolStripButton)item).Checked = false;
            if (wErase.Checked)
                scoreWriterPicture.Cursor = NewCursors.Erase;
            else
                scoreWriterPicture.Cursor = Cursors.Arrow;
        }
        private void wAccidental_Click(object sender, EventArgs e)
        {
            if (sender == wSharp)
            {
                wFlat.Checked = false;
                wNatural.Checked = false;
            }
            else if (sender == wFlat)
            {
                wSharp.Checked = false;
                wNatural.Checked = false;
            }
            else
            {
                wSharp.Checked = false;
                wFlat.Checked = false;
            }
        }
        //
        private void scoreWriterPicture_Paint(object sender, PaintEventArgs e)
        {
            int staffIndex = 0;
            foreach (Staff staff in staffs)
            {
                int x = -hScrollBar3.Value + 64;
                int y = staffIndex * staffHeight;
                int middle = staffHeight / 2;
                // draw staff hilite
                SolidBrush brush = new SolidBrush(Color.White);
                if (staffIndex == mouseDownStaff)
                    e.Graphics.FillRectangle(brush, 0, y + 4, scoreWriterPicture.Width, staffHeight - 8);
                // draw staff ledger lines
                DrawBarsLines(e.Graphics, staff.Clef, staffIndex, -hScrollBar3.Value, true);
                // draw notes
                int indexNotes = 0;
                foreach (object item in staff.Notes)
                {
                    if (item.GetType() != typeof(Note))
                    {
                        indexNotes++;
                        continue;
                    }
                    Note note = (Note)item;
                    if (x < -32 || x - 32 > scoreWriterPicture.Width)
                    {
                        x += (int)((double)noteSpacingSW.Value / 100.0 * note.Ticks);
                        indexNotes++;
                        continue;
                    }
                    DrawNote(e.Graphics, note, x, staffHeight, staff.Clef, staffIndex);
                    if (mouseEnter && indexNotes == mouseOverNote &&
                        staffIndex == mouseOverStaff && staffIndex == mouseDownStaff)
                        e.Graphics.DrawImage(insert, x - 8, mousePosition.Y);
                    x += (int)((double)noteSpacingSW.Value / 100.0 * note.Ticks);
                    indexNotes++;
                }
                // draw extra lines beyond normal lines, if mouse over it
                if (mouseEnter && staffIndex == mouseOverStaff && staffIndex == mouseDownStaff)
                {
                    DrawOutsideLines(e.Graphics, new Pen(Color.Gray), mousePosition.X, y, middle,
                        staff.Clef, mouseOverOctave, mouseOverPitch, mouseOverLine);
                    brush.Color = Color.FromArgb(128, Color.Black);
                    if (insertObject != null && mouseEnter && mousePosition.X != -1 && mousePosition.Y != -1)
                        e.Graphics.FillEllipse(brush, mousePosition.X - 4, mousePosition.Y / 4 * 4 + 1, 8, 8);
                }
                staffIndex++;
            }
        }
        private void scoreWriterPicture_MouseDown(object sender, MouseEventArgs e)
        {
            if (staffs.Count == 0)
                return;
            if (mouseOverStaff == -1)
                return;
            if (mouseDownStaff != mouseOverStaff)
            {
                mouseDownStaff = mouseOverStaff;
                if (mouseDownStaff < staffs.Count)
                    RefreshStaff();
                return;
            }
            // Get index to insert between notes (and commands), 64 is after the clef
            mouseDownNote = mouseOverNote;
            if (wErase.Checked)
            {
                if (mouseDownNote < staffs[mouseDownStaff].Notes.Count)
                    staffs[mouseDownStaff].Notes.RemoveAt(mouseDownNote);
                scoreWriterPicture.Invalidate();
                return;
            }
            //
            if (insertObject == null)
                return;
            //
            int beat = 0;
            byte opcode = 0;
            Note note;
            SPCCommand ssc;
            switch (insertObject.Name)
            {
                case "wNoteWhole": beat = 0; goto case "Note";
                case "wNoteHalfD": beat = 1; goto case "Note";
                case "wNoteHalf": beat = 2; goto case "Note";
                case "wNoteQuarterD": beat = 3; goto case "Note";
                case "wNoteQuarter": beat = 4; goto case "Note";
                case "wNote8thD": beat = 5; goto case "Note";
                case "wNoteQuarterT": beat = 6; goto case "Note";
                case "wNote8th": beat = 7; goto case "Note";
                case "wNote8thT": beat = 8; goto case "Note";
                case "wNote16th": beat = 9; goto case "Note";
                case "wNote16thT": beat = 10; goto case "Note";
                case "wNote32nd": beat = 11; goto case "Note";
                case "wNote64th": beat = 12; goto case "Note";
                case "Note":
                    opcode = (byte)(beat * 14 + mouseOverPitch);
                    ssc = new SPCCommand(new byte[] { opcode }, spc, mouseOverStaff);
                    note = new Note(ssc, mouseOverOctave, false, 0);
                    staffs[mouseOverStaff].Notes.Insert(mouseDownNote, note);
                    break;
                case "wRestWhole": beat = 0; goto case "Rest";
                case "wRestHalfD": beat = 1; goto case "Rest";
                case "wRestHalf": beat = 2; goto case "Rest";
                case "wRestQuarterD": beat = 3; goto case "Rest";
                case "wRestQuarter": beat = 4; goto case "Rest";
                case "wRest8thD": beat = 5; goto case "Rest";
                case "wRestQuarterT": beat = 6; goto case "Rest";
                case "wRest8th": beat = 7; goto case "Rest";
                case "wRest8thT": beat = 8; goto case "Rest";
                case "wRest16th": beat = 9; goto case "Rest";
                case "wRest16thT": beat = 10; goto case "Rest";
                case "wRest32nd": beat = 11; goto case "Rest";
                case "wRest64th": beat = 12; goto case "Rest";
                case "Rest":
                    opcode = (byte)(beat * 14 + 12);
                    ssc = new SPCCommand(new byte[] { opcode }, spc, mouseOverStaff);
                    note = new Note(ssc, mouseOverOctave, false, 0);
                    staffs[mouseOverStaff].Notes.Insert(mouseDownNote, note);
                    break;
            }
            SetScrollBars();
        }
        private void scoreWriterPicture_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter = true;
        }
        private void scoreWriterPicture_MouseLeave(object sender, EventArgs e)
        {
            mouseEnter = false;
            labelNote.Text = "...";
            scoreWriterPicture.Invalidate();
        }
        private void scoreWriterPicture_MouseMove(object sender, MouseEventArgs e)
        {
            int x = Math.Max(e.X, 0);
            int y = Math.Max(e.Y, 0);
            mousePosition = new Point(x, y);
            mouseOverNote = -1;
            mouseOverPitch = Pitch.None;
            mouseOverStaff = -1;
            if (staffs.Count == 0 || y / staffHeight >= staffs.Count)
            {
                scoreWriterPicture.Invalidate();
                labelNote.Text = "...";
                return;
            }
            //
            mouseOverStaff = y / staffHeight;
            if (mouseOverStaff != mouseDownStaff)
            {
                scoreWriterPicture.Invalidate();
                labelNote.Text = "...";
                return;
            }
            //
            x = Math.Max(x + hScrollBar3.Value, 0);
            y = y % staffHeight;
            mouseOverNote = GetNoteIndex(x, true);
            // 88 pixels p/staff, pitches are separate by 4 pixels, 11 lines p/staff
            int staffOffset = 0;
            if (clef.SelectedIndex == 0)
                staffOffset = -1;
            else if (clef.SelectedIndex == 1)
                staffOffset = 1;
            // 288 is the staff size where everything is perfect
            int line = (staffHeight / 4) - (y / 4) + ((272 - staffHeight) / 8) + staffOffset;
            mouseOverLine = line % 7;
            switch (mouseOverLine)
            {
                case 0: mouseOverPitch = Pitch.C; labelNote.Text = "C"; break; // A, A#
                case 1: mouseOverPitch = Pitch.D; labelNote.Text = "D"; break; // B
                case 2: mouseOverPitch = Pitch.E; labelNote.Text = "E"; break; // C, C#
                case 3: mouseOverPitch = Pitch.F; labelNote.Text = "F"; break; // D, D#
                case 4: mouseOverPitch = Pitch.G; labelNote.Text = "G"; break; // E
                case 5: mouseOverPitch = Pitch.A; labelNote.Text = "A"; break; // F, F#
                case 6: mouseOverPitch = Pitch.B; labelNote.Text = "B"; break; // G, G#
                default: mouseOverPitch = Pitch.None; labelNote.Text = ""; break;
            }
            if (wSharp.Checked)
                mouseOverPitch++;
            // 7 lines per octave, so 28 (7 * 4), offset by 52
            mouseOverOctave = line / 7;
            if (mouseOverStaff == mouseDownStaff)
                labelNote.Text += mouseOverOctave.ToString();
            else
                labelNote.Text = "...";
            scoreWriterPicture.Invalidate();
        }
        // Common commands
        private void saveScoreFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = settings.NotePathCustom;
            saveFileDialog.Title = "Save as new score file...";
            saveFileDialog.FileName = "score.lsscore";
            saveFileDialog.Filter = "Score File (*.lsnotes)|*.lsscore";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            //
            Stream s = File.Create(saveFileDialog.FileName);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, staffs);
            s.Close();
        }
        private void openScoreFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = settings.NotePathCustom;
            openFileDialog.Title = "Open existing score file...";
            openFileDialog.Filter = "Score File (*.lsscore)|*.lsscore";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            //
            Stream s = File.OpenRead(openFileDialog.FileName);
            BinaryFormatter b = new BinaryFormatter();
            try
            {
                staffs = (List<Staff>)b.Deserialize(s);
            }
            catch
            {
                MessageBox.Show("This is not a valid score file.", "LAZY SHELL",
                MessageBoxButtons.OK);
                s.Close();
                return;
            }
            s.Close();
            SetScrollBars();
        }
        private void exportScoreFiles_Click(object sender, EventArgs e)
        {
            // first, open and create directory
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.SelectedPath = Settings.Default.LastDirectory;
            folderBrowserDialog1.Description = "Select directory to export to";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                Settings.Default.LastDirectory = folderBrowserDialog1.SelectedPath;
            else
                return;
            //
            for (int i = 0; i < staffs.Count; i++)
            {
                StreamWriter script = File.CreateText(folderBrowserDialog1.SelectedPath + "\\staff" + i + ".txt");
                foreach (object item in staffs[i].Notes)
                    script.WriteLine(item.ToString());
                script.Close();
            }
        }
        private void exportStaffsMML_Click(object sender, EventArgs e)
        {
            ExportMMLScript(3);
        }
        private void importScoreFiles_Click(object sender, EventArgs e)
        {
            List<SPCCommand> commands = new List<SPCCommand>();
            if (!ImportSPCScript(ref commands))
                return;
            //
            List<object> notes = new List<object>();
            int index = 0;
            int octave = 6;
            bool percussive = false;
            int sample = 0;
            while (index < commands.Count)
            {
                SPCCommand ssc = commands[index++];
                if (ssc.Opcode >= 0xC4)
                    notes.Add(ssc);
                switch (ssc.Opcode)
                {
                    case 0xC4: octave++; break;
                    case 0xC5: octave--; break;
                    case 0xC6: octave = ssc.Param1; break;
                    case 0xD4:
                        SequenceLoop(commands, notes, ref index, index, ssc.Param1, ref octave, ref percussive, ref sample);
                        break;
                    case 0xD5: break;
                    case 0xDE: sample = ssc.Param1; goto default;
                    case 0xEE: percussive = true; goto default;
                    case 0xEF: percussive = false; goto default;
                    default:
                        if (ssc.Opcode < 0xC4 || ssc.Opcode == 0xDE || ssc.Opcode == 0xEE || ssc.Opcode == 0xEF)
                            notes.Add(new Note(ssc, octave, percussive, sample));
                        break;
                }
            }
            wStaffNew_Click(null, null);
            mouseDownStaff = staffs.Count - 1;
            staffs[mouseDownStaff].Notes = notes;
            SetScrollBars();
        }
        private void SequenceLoop(List<SPCCommand> commands, List<object> notes,
            ref int index, int start, int count, ref int octave_, ref bool percussive, ref int sample)
        {
            int octave = octave_;
            while (count > 0 && index < commands.Count)
            {
                SPCCommand ssc = commands[index++];
                if (count == 1 && ssc.Opcode >= 0xC4)
                    notes.Add(ssc);
                if (ssc.Opcode == 0xD6 && count == 1)
                {
                    while (index < commands.Count && commands[index].Opcode != 0xD5) index++; break;
                }
                switch (ssc.Opcode)
                {
                    case 0xC4: octave++; break;
                    case 0xC5: octave--; break;
                    case 0xC6: octave = ssc.Param1; break;
                    case 0xD4:
                        SequenceLoop(commands, notes, ref index, index, ssc.Param1, ref octave, ref percussive, ref sample);
                        break;
                    case 0xD5: count--; if (count > 0) { index = start; octave = octave_; } break;
                    case 0xD6: break;
                    case 0xDE: sample = ssc.Param1; goto default;
                    case 0xEE: percussive = true; goto default;
                    case 0xEF: percussive = false; goto default;
                    default:
                        if (ssc.Opcode < 0xC4 || ssc.Opcode == 0xDE || ssc.Opcode == 0xEE || ssc.Opcode == 0xEF)
                            notes.Add(new Note(ssc, octave, percussive, sample));
                        break;
                }
            }
            octave_ = octave;
        }
        private void staffHeight_ValueChanged(object sender, EventArgs e)
        {
            staffHeightSW.Value = (int)staffHeightSW.Value / 8 * 8;
            scoreWriterPicture.Invalidate();
        }
        private void wStaffNew_Click(object sender, EventArgs e)
        {
            if (Type == 0 && staffs.Count == 8)
                return;
            else if (Type != 0 && staffs.Count == 2)
                return;
            staffs.Add(new Staff());
            if (staffs.Count == 1)
            {
                mouseDownStaff = 0;
                wStaffDelete.Enabled = true;
                wStaffMoveDown.Enabled = true;
                wStaffMoveUp.Enabled = true;
                RefreshStaff();
            }
            scoreWriterPicture.Invalidate();
        }
        private void wStaffDelete_Click(object sender, EventArgs e)
        {
            if (mouseDownStaff == -1)
                return;
            staffs.RemoveAt(mouseDownStaff);
            wStaffDelete.Enabled = staffs.Count != 0;
            wStaffMoveDown.Enabled = staffs.Count != 0;
            wStaffMoveUp.Enabled = staffs.Count != 0;
            if (staffs.Count > 0)
                mouseDownStaff = 0;
            RefreshStaff();
            scoreWriterPicture.Invalidate();
        }
        private void wStaffMoveUp_Click(object sender, EventArgs e)
        {
            if (mouseDownStaff <= 0)
                return;
            staffs.Reverse(mouseDownStaff - 1, 2);
            mouseDownStaff--;
            scoreWriterPicture.Invalidate();
        }
        private void wStaffMoveDown_Click(object sender, EventArgs e)
        {
            if (mouseDownStaff == -1)
                return;
            if (mouseDownStaff >= staffs.Count - 1)
                return;
            staffs.Reverse(mouseDownStaff, 2);
            mouseDownStaff++;
            scoreWriterPicture.Invalidate();
        }
        private void clef_SelectedIndexChanged(object sender, EventArgs e)
        {
            staffs[mouseDownStaff].Clef = clef.SelectedIndex;
            scoreWriterPicture.Invalidate();
        }
        private void key_SelectedIndexChanged(object sender, EventArgs e)
        {
            staffs[mouseDownStaff].Key = (Key)key.SelectedIndex;
            scoreWriterPicture.Invalidate();
        }
        private void noteSpacingSW_ValueChanged(object sender, EventArgs e)
        {
            noteSpacingSW.Value = (int)noteSpacingSW.Value / 10 * 10;
            SetScrollBars();
        }
        // Notes and rests, etc.
        #endregion
    }
    public class Staff
    {
        public int Clef = 0; // Treble
        public Key Key = 0; // C major
        public List<object> Notes = new List<object>();
        public Staff(int clef, Key key)
        {
            this.Clef = clef;
            this.Key = key;
        }
        public Staff()
        {
        }
    }
}
