using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using LazyShell.Properties;
using LazyShell.Undo;

namespace LazyShell.Audio
{
    public partial class ScoreWriterForm : Controls.DockForm
    {
        #region Variables

        private Score score;
        private Overlay overlay;
        private Settings settings;
        private List<Staff> staffs
        {
            get { return score.Staffs; }
            set { score.Staffs = value; }
        }
        private ToolStripButton insertObject;

        #region Mouse behavior

        private bool mouseEnter = false;
        private int mouseOverStaff = -1;
        private Pitch mouseOverPitch = Pitch.Null;
        private int mouseOverLine = -1;
        private int mouseOverOctave = -1;
        private int mouseDownStaff = -1;
        private int mouseOverNote = -1;
        private int mouseDownNote = -1;
        private Point mousePosition = new Point(-1, -1);

        #endregion

        private Bitmap clefF;
        private Bitmap clefG;
        private Bitmap insert;
        private int timeBeats
        {
            get { return (int)timeBeatsSW.Value; }
            set { timeBeatsSW.Value = value; }
        }
        private int timeValue
        {
            get { return (int)timeValueSW.Value; }
            set { timeValueSW.Value = value; }
        }
        private int staffHeight
        {
            get { return (int)staffHeightSW.Value; }
            set { staffHeightSW.Value = value; }
        }
        private int noteSpacing
        {
            get { return (int)noteSpacingSW.Value; }
            set { noteSpacingSW.Value = value; }
        }
        private Key key
        {
            get { return (Key)keySW.SelectedIndex; }
            set { keySW.SelectedIndex = (int)value; }
        }
        private List<object> notes
        {
            get { return staffs[mouseDownStaff].Notes; }
            set { staffs[mouseDownStaff].Notes = value; }
        }
        private List<object> copyBuffer;
        private UndoStack commandStack;
        private OwnerForm owner;
        private SPC spc
        {
            get { return owner.SPC; }
            set { owner.SPC = value; }
        }

        #endregion

        // Constructor
        public ScoreWriterForm(OwnerForm owner)
        {
            this.owner = owner;
            InitializeComponent();
            InitializeVariables();
        }

        #region Methods

        #region Initialization

        private void InitializeVariables()
        {
            this.overlay = new Overlay();
            this.settings = Settings.Default;
            this.commandStack = new UndoStack();
            //
            this.score = new Score();
            this.clefF = global::LazyShell.Properties.Resources.clefF;
            this.clefG = global::LazyShell.Properties.Resources.clefG;
            this.insert = global::LazyShell.Properties.Resources.insert;
        }
        private void EnableToolStrips()
        {
            this.Updating = true;
            //
            foreach (ToolStripItem item in toolStripMain.Items)
                item.Enabled = true;
            toolStripNote.Enabled = true;
            toolStripAction.Enabled = true;
            //
            this.Updating = false;
        }
        /// <summary>
        /// Refreshes the maximum size of the hScrollBar based on the
        /// staff containing the most notes in the score.
        /// </summary>
        private void SetHScrollBar()
        {
            for (int i = 0; i < staffs.Count; i++)
            {
                int maximum = 0;
                foreach (Note note in staffs[i].Notes)
                {
                    maximum += note.Ticks;
                    if (maximum > hScrollBar.Maximum)
                        hScrollBar.Maximum = maximum;
                }
            }
            picture.Invalidate();
        }
        private void SetNoteLabel()
        {
            if (mouseOverStaff >= 0 && mouseOverStaff == mouseDownStaff)
                labelNote.Text += mouseOverOctave.ToString();
            else
                labelNote.Text = "...";
        }
        //
        private void LoadScoreProperties()
        {
            keySW.SelectedIndex = (int)score.Key;
            timeBeatsSW.Value = score.TimeBeats;
            timeValueSW.Value = score.TimeValue;
            picture.Invalidate();
        }
        private void LoadStaffProperties()
        {
            if (staffs.Count == 0 || mouseDownStaff < 0)
                return;
            this.Updating = true;
            //
            if (score.Staffs.Count > 0)
            {
                staffDelete.Enabled = true;
                staffMoveDown.Enabled = true;
                staffMoveUp.Enabled = true;
                undo.Enabled = true;
                redo.Enabled = true;
                clef.Enabled = true;
                clef.SelectedIndex = staffs[mouseDownStaff].Clef;
            }
            else
            {
                mouseDownStaff = -1;
                staffDelete.Enabled = false;
                staffMoveDown.Enabled = false;
                staffMoveUp.Enabled = false;
                clef.Enabled = false;
            }
            //
            this.Updating = false;
        }
        private void EnableToolStripControls()
        {
            staffDelete.Enabled = staffs.Count != 0;
            staffMoveDown.Enabled = staffs.Count != 0;
            staffMoveUp.Enabled = staffs.Count != 0;
            keySW.Enabled = staffs.Count != 0;
            clef.Enabled = staffs.Count != 0;
        }

        #endregion

        #region Helping methods

        /// <summary>
        /// Returns the index of the note at a specified X coordinate
        /// in the currently selected staff/channel.
        /// </summary>
        /// <param name="x">The X coordinate in the staff.</param>
        /// <returns></returns>
        public int GetNoteIndex(int x)
        {
            if (mouseDownStaff == -1)
                return -1;
            int x_ = 64 + Music.GetKeyWidth(key);
            int index = 0;
            foreach (var item in staffs[mouseDownStaff].Notes)
            {
                if (item is Note)
                {
                    var note = item as Note;
                    if (x_ >= x)
                        break;
                    x_ += (int)((double)noteSpacing / 100.0 * note.Ticks);
                }
                index++;
            }
            return index;
        }
        private void SetMouseOver(int x, int y)
        {
            mousePosition = new Point(x, y);
            mouseOverNote = -1;
            mouseOverPitch = Pitch.Null;
            mouseOverStaff = -1;
            if (staffs.Count == 0 || y / staffHeight >= staffs.Count)
            {
                picture.Invalidate();
                labelNote.Text = "...";
                return;
            }
            //
            mouseOverStaff = y / staffHeight;
            if (mouseOverStaff != mouseDownStaff)
            {
                picture.Invalidate();
                labelNote.Text = "...";
                return;
            }
            //
            x = Math.Max(x + hScrollBar.Value, 0);
            y = y % staffHeight;
            mouseOverNote = GetNoteIndex(x);
            // 88 pixels p/staff, pitches are separate by 4 pixels, 11 lines p/staff
            int staffOffset = 0;
            if (clef.SelectedIndex == 0)
                staffOffset = -1;
            else if (clef.SelectedIndex == 1)
                staffOffset = 1;
            // 272 is the staff size where everything is perfect
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
                default: mouseOverPitch = Pitch.Null; labelNote.Text = ""; break;
            }
            // adjust pitch based on checked accidental AND key signature
            if (sharp.Checked)
                mouseOverPitch++;
            if (flat.Checked)
                mouseOverPitch--;
            Accidental accidental = Music.GetAccidental(this.key, mouseOverPitch);
            if (!natural.Checked && accidental == Accidental.Natural)
            {
                if ((this.key >= Key.CMajor && this.key <= Key.CsMajor) ||
                    (this.key >= Key.AMinor && this.key <= Key.AsMinor)) // sharp key
                    mouseOverPitch++;
                else
                    mouseOverPitch--; // flat key
            }
            // 7 lines per octave, so 28 (7 * 4), offset by 52
            mouseOverOctave = line / 7;
            if (mouseOverPitch == Pitch.Rest)
            {
                mouseOverPitch = Pitch.C;
                mouseOverOctave++;
            }
        }
        private bool WithinSelection(int index)
        {
            if (overlay.Select.Empty)
                return false;
            int selectionStart = GetNoteIndex(overlay.Select.Location.X + hScrollBar.Value);
            int selectionEnd = GetNoteIndex(overlay.Select.Terminal.X + hScrollBar.Value);
            return index >= selectionStart && index < selectionEnd;
        }
        private int GetStaffWidth(int staffIndex)
        {
            int staffWidth = 0;
            foreach (var item in staffs[staffIndex].Notes)
            {
                if (item is Note)
                    staffWidth += (int)((double)noteSpacing / 100.0 * (item as Note).Ticks);
            }
            return staffWidth;
        }

        #endregion

        #region Painting picture

        private void DrawNote(Graphics g, Note note, Note lastNote, Note lastItem, int x,
            int staffHeight, int clef, Key key, int staffIndex, bool hilite, bool select)
        {
            int y = staffIndex * staffHeight;
            int middle = staffHeight / 2;
            int yCoord = y + middle;
            int clefOffset = 0;
            if (clef == 0)
                clefOffset = -4;
            else if (clef == 1)
                clefOffset = 4;
            Bitmap stem = null;
            Bitmap head = null;
            Bitmap rest = null;
            Color color = Color.Black;
            if (hilite)
                color = Color.Red;
            else if (select)
            {
                color = Color.Blue;
                hilite = true;
            }
            if (!note.Rest && !note.Tie)
            {
                int pitch = note.Octave * 12 + (int)note.Pitch;
                int ticks = note.Ticks;
                yCoord = y + middle + note.Y(key) + clefOffset - 5;
                if (!note.Percussive)
                {
                    head = Music.GetHead(ticks, pitch, hilite, color);
                    stem = Music.GetStem(ticks, pitch, hilite, color);
                    // draw extra lines
                    DrawOuterLines(g, Pens.Gray, x + 7, y, middle, clef, note.Octave, note.Pitch, note.Line);
                    if (stem != null)
                        g.DrawImage(stem, x, pitch < 59 ? yCoord : yCoord + 12);
                    g.DrawImage(head, x, yCoord);
                    Accidental accidental = Music.GetAccidental(key, note.Pitch);
                    if (accidental == Accidental.Sharp)
                        g.DrawImage(hilite ? Do.Fill(Icons.Sharp, color) : Icons.Sharp, x - 2, yCoord + 4);
                    else if (accidental == Accidental.Flat)
                        g.DrawImage(hilite ? Do.Fill(Icons.Flat, color) : Icons.Flat, x - 2, yCoord + 4);
                    else if (accidental == Accidental.Natural)
                        g.DrawImage(hilite ? Do.Fill(Icons.Natural, color) : Icons.Natural, x - 2, yCoord + 4);
                }
                else
                    g.DrawImage(hilite ? Do.Fill(Icons.NotePercussion, color) : Icons.NotePercussion, x, yCoord);
            }
            else if (note.Rest)
            {
                int ticks = note.Ticks;
                yCoord = y + middle - 4 - 5;
                rest = Music.GetRest(ticks, hilite, color);
                g.DrawImage(rest, x, yCoord);
            }
            else if (note.Tie && lastNote != null && lastItem != null)
            {
                int pitch = lastNote.Octave * 12 + (int)lastNote.Pitch;
                int ticks = note.Ticks;
                yCoord = y + middle + lastNote.Y(key) + clefOffset - 5;
                if (!lastNote.Percussive)
                {
                    head = Music.GetHead(ticks, pitch, hilite, color);
                    stem = Music.GetStem(ticks, pitch, hilite, color);
                    Bitmap sharp = Icons.Sharp;
                    // draw extra lines
                    DrawOuterLines(g, Pens.Gray, x + 7, y, middle, clef, lastNote.Octave, lastNote.Pitch, lastNote.Line);
                    if (stem != null)
                        g.DrawImage(stem, x, pitch < 59 ? yCoord : yCoord + 12);
                    g.DrawImage(head, x, yCoord);
                    Accidental accidental = Music.GetAccidental(key, lastNote.Pitch);
                    if (accidental == Accidental.Sharp)
                        g.DrawImage(hilite ? Do.Fill(Icons.Sharp, color) : Icons.Sharp, x - 2, yCoord + 4);
                    else if (accidental == Accidental.Flat)
                        g.DrawImage(hilite ? Do.Fill(Icons.Flat, color) : Icons.Flat, x - 2, yCoord + 4);
                    else if (accidental == Accidental.Natural)
                        g.DrawImage(hilite ? Do.Fill(Icons.Natural, color) : Icons.Natural, x - 2, yCoord + 4);
                }
                else
                    g.DrawImage(hilite ? Do.Fill(Icons.NotePercussion, color) : Icons.NotePercussion, x, yCoord);
                // draw tie, must stretch/shrink according to notespacing
                double ratio = (double)noteSpacing / 100.0;
                Rectangle src = new Rectangle(0, 0, 16, 16);
                Rectangle dst = new Rectangle(
                    x - (int)(lastNote.Ticks * ratio) + 8,
                    pitch < 59 ? yCoord + 8 : yCoord + 2,
                    (int)((double)lastNote.Ticks * ratio), 16);
                Bitmap tie = pitch < 59 ? Icons.TieUnder : Icons.TieOver;
                g.DrawImage(tie, dst, src, GraphicsUnit.Pixel);
            }
        }
        private void DrawBarsLines(Graphics g, int clef, Key key, int staffIndex, int xOffset, bool drawClefs, int staffWidth)
        {
            // set variables
            int width = (int)g.ClipBounds.Width;
            int height = staffHeight;
            // draw dotted separators
            Pen pen = new Pen(Color.Gray);
            pen.DashStyle = DashStyle.Dot;
            pen.Alignment = PenAlignment.Center;
            g.DrawLine(pen,
                0, staffIndex * height + 4,
                width, staffIndex * height + 4);
            g.DrawLine(pen,
                0, staffIndex * height + height - 4,
                width, staffIndex * height + height - 4);
            pen.DashStyle = DashStyle.Solid;
            // draw start bars
            int x = xOffset;
            int x_ = xOffset;
            int y = staffIndex * height;
            int middle = height / 2;
            pen.Width = 4;
            g.DrawLine(pen, x, y + middle - 16, x, y + middle + 16);
            pen.Width = 1;
            g.DrawLine(pen, x + 6, y + middle - 16, x + 6, y + middle + 16);
            // draw clefs
            if (drawClefs)
            {
                if (clef == 0)
                    g.DrawImage(clefG, x + 16, y + middle - 24);
                else if (clef == 1)
                    g.DrawImage(clefF, x + 16, y + middle - 24);
            }
            // get X offset from key signature width
            int keyWidth = Music.GetKeyWidth(key);
            x += keyWidth;
            // draw ledger lines
            int measureTop = (staffIndex * height) + (height / 2) - 16;
            int measureLength = (int)((double)timeBeats / (double)timeValue * 192.0);
            measureLength = (int)((double)noteSpacing / 100.0 * (double)measureLength);
            if (staffWidth % measureLength == 0)
                staffWidth = staffWidth / measureLength * measureLength;
            else
                staffWidth = staffWidth / measureLength * measureLength + measureLength;
            int measureLeft = measureLength + 64 + x;
            int maxWidth = Math.Max(staffWidth + x + 64 + 8, measureLeft + 8);
            g.DrawLine(pen, 0, y + middle - 16, maxWidth, y + middle - 16);
            g.DrawLine(pen, 0, y + middle - 8, maxWidth, y + middle - 8);
            g.DrawLine(pen, 0, y + middle, maxWidth, y + middle);
            g.DrawLine(pen, 0, y + middle + 8, maxWidth, y + middle + 8);
            g.DrawLine(pen, 0, y + middle + 16, maxWidth, y + middle + 16);
            // draw measure bar lines
            while (measureLeft < width)
            {
                if (measureLeft - x - 64 >= staffWidth)
                {
                    // draw end bars
                    pen.Width = 1; g.DrawLine(pen, measureLeft, measureTop, measureLeft, measureTop + 32);
                    pen.Width = 4; g.DrawLine(pen, measureLeft + 6, measureTop, measureLeft + 6, measureTop + 32);
                    break;
                }
                else
                {
                    g.DrawLine(Pens.Gray, measureLeft, measureTop, measureLeft, measureTop + 32);
                    measureLeft += measureLength;
                }
            }
            // draw time sig
            Font font = new Font("Times New Roman", 18, FontStyle.Bold);
            if (timeBeats >= 10)
                g.DrawString(timeBeatsSW.ToString(), font, Brushes.Black, 40 + x - 6, measureTop - 4);
            else
                g.DrawString(timeBeatsSW.ToString(), font, Brushes.Black, 40 + x, measureTop - 4);
            if (timeValue >= 10)
                g.DrawString(timeValueSW.ToString(), font, Brushes.Black, 40 + x - 6, measureTop + 12);
            else
                g.DrawString(timeValueSW.ToString(), font, Brushes.Black, 40 + x, measureTop + 12);
            // draw key sig (sharps)
            if (Music.GetAccidental(key, Pitch.F) == Accidental.Sharp) { g.DrawImage(Icons.Sharp, x_ + 36, y + middle - 26); }
            if (Music.GetAccidental(key, Pitch.C) == Accidental.Sharp) { g.DrawImage(Icons.Sharp, x_ + 40, y + middle - 14); }
            if (Music.GetAccidental(key, Pitch.G) == Accidental.Sharp) { g.DrawImage(Icons.Sharp, x_ + 44, y + middle - 30); }
            if (Music.GetAccidental(key, Pitch.D) == Accidental.Sharp) { g.DrawImage(Icons.Sharp, x_ + 48, y + middle - 18); }
            if (Music.GetAccidental(key, Pitch.A) == Accidental.Sharp) { g.DrawImage(Icons.Sharp, x_ + 52, y + middle - 6); }
            if (Music.GetAccidental(key, Pitch.E) == Accidental.Sharp) { g.DrawImage(Icons.Sharp, x_ + 56, y + middle - 22); }
            if (Music.GetAccidental(key, Pitch.B) == Accidental.Sharp) { g.DrawImage(Icons.Sharp, x_ + 60, y + middle - 10); }
            // draw key sig (flats)
            if (Music.GetAccidental(key, Pitch.B) == Accidental.Flat) { g.DrawImage(Icons.Flat, x_ + 36, y + middle - 10); }
            if (Music.GetAccidental(key, Pitch.E) == Accidental.Flat) { g.DrawImage(Icons.Flat, x_ + 40, y + middle - 22); }
            if (Music.GetAccidental(key, Pitch.A) == Accidental.Flat) { g.DrawImage(Icons.Flat, x_ + 44, y + middle - 6); }
            if (Music.GetAccidental(key, Pitch.D) == Accidental.Flat) { g.DrawImage(Icons.Flat, x_ + 48, y + middle - 18); }
            if (Music.GetAccidental(key, Pitch.G) == Accidental.Flat) { g.DrawImage(Icons.Flat, x_ + 52, y + middle - 30); }
            if (Music.GetAccidental(key, Pitch.C) == Accidental.Flat) { g.DrawImage(Icons.Flat, x_ + 56, y + middle - 14); }
            if (Music.GetAccidental(key, Pitch.F) == Accidental.Flat) { g.DrawImage(Icons.Flat, x_ + 60, y + middle - 26); }
        }
        private void DrawEndBars(Graphics g, int staffIndex, int xOffset)
        {
            int height = staffHeight;
            int x = xOffset;
            int y = staffIndex * height;
            int middle = height / 2;
            Pen pen = new Pen(Color.Gray, 1); pen.Alignment = PenAlignment.Outset;
            g.DrawLine(pen, x, y + middle - 16, x, y + middle + 16); pen.Width = 4;
            g.DrawLine(pen, x + 6, y + middle - 16, x + 6, y + middle + 16);
        }
        private void DrawOuterLines(Graphics g, Pen pen, int x, int y,
            int middle, int clef, int octave, Pitch pitch, int line)
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

        #endregion

        #region Selection editing

        private void Copy()
        {
            if (overlay.Select.Empty)
                return;
            int start = GetNoteIndex(overlay.Select.Location.X + hScrollBar.Value);
            int end = GetNoteIndex(overlay.Select.Terminal.X + hScrollBar.Value);
            if (start >= end)
                return;
            copyBuffer = new List<object>();
            for (int i = start; i < end; i++)
                copyBuffer.Add((this.notes[i] as Note).Copy());
        }
        private void Paste(int index)
        {
            if (copyBuffer == null)
                return;
            if (index > this.notes.Count)
                return;
            var temp = new List<object>();
            foreach (Note note in copyBuffer)
                temp.Add(note.Copy());
            commandStack.Push(new ScoreEdit(ScoreAction.PasteNotes, this.notes, temp, index));
            SetHScrollBar();
        }
        private void Delete()
        {
            if (overlay.Select.Empty)
                return;
            int start = GetNoteIndex(overlay.Select.Location.X + hScrollBar.Value);
            int end = GetNoteIndex(overlay.Select.Terminal.X + hScrollBar.Value);
            if (start >= end)
                return;
            List<object> temp = new List<object>();
            for (int i = start; i < end; i++)
                temp.Add(this.notes[i]);
            commandStack.Push(new ScoreEdit(ScoreAction.DeleteNotes, this.notes, temp, start));
            SetHScrollBar();
        }

        #endregion

        #region Note editing

        private void Draw()
        {
            if (insertObject == null)
                return;
            //
            if (insertObject == null)
                return;
            //
            Beat beat = Beat.Empty;
            byte opcode = 0;
            byte param1 = 0;
            Note note;
            Command ssc;
            switch (insertObject.Name)
            {
                case "ticksNoteButton": goto case "Note";
                case "noteWhole": beat = Beat.Whole; goto case "Note";
                case "noteHalfD": beat = Beat.HalfDotted; goto case "Note";
                case "noteHalf": beat = Beat.Half; goto case "Note";
                case "noteQuarterD": beat = Beat.QuarterDotted; goto case "Note";
                case "noteQuarter": beat = Beat.Quarter; goto case "Note";
                case "note8thD": beat = Beat.EighthDotted; goto case "Note";
                case "noteQuarterT": beat = Beat.QuarterTriplet; goto case "Note";
                case "note8th": beat = Beat.Eighth; goto case "Note";
                case "note8thT": beat = Beat.EighthTriplet; goto case "Note";
                case "note16th": beat = Beat.Sixteenth; goto case "Note";
                case "note16thT": beat = Beat.SixteenthTriplet; goto case "Note";
                case "note32nd": beat = Beat.ThirtySecond; goto case "Note";
                case "note64th": beat = Beat.SixtyFourth; goto case "Note";
                case "Note":
                    if (tie.Checked)
                        goto case "Tie";
                    if (ticksNoteButton.Checked)
                    {
                        opcode = (byte)(13 * 14 + mouseOverPitch);
                        param1 = (byte)ticksNoteValue.Value;
                        ssc = new Command(new byte[] { opcode, param1 }, spc, mouseOverStaff);
                    }
                    else
                    {
                        opcode = (byte)((int)beat * 14 + mouseOverPitch);
                        ssc = new Command(new byte[] { opcode }, spc, mouseOverStaff);
                    }
                    note = new Note(ssc, mouseOverOctave, false, 0);
                    commandStack.Push(new ScoreEdit(ScoreAction.InsertNote, staffs[mouseOverStaff].Notes, mouseDownNote, note));
                    break;
                case "ticksRestButton": goto case "Rest";
                case "restWhole": beat = Beat.Whole; goto case "Rest";
                case "restHalfD": beat = Beat.HalfDotted; goto case "Rest";
                case "restHalf": beat = Beat.Half; goto case "Rest";
                case "restQuarterD": beat = Beat.QuarterDotted; goto case "Rest";
                case "restQuarter": beat = Beat.Quarter; goto case "Rest";
                case "rest8thD": beat = Beat.EighthDotted; goto case "Rest";
                case "restQuarterT": beat = Beat.QuarterTriplet; goto case "Rest";
                case "rest8th": beat = Beat.Eighth; goto case "Rest";
                case "rest8thT": beat = Beat.EighthTriplet; goto case "Rest";
                case "rest16th": beat = Beat.Sixteenth; goto case "Rest";
                case "rest16thT": beat = Beat.SixteenthTriplet; goto case "Rest";
                case "rest32nd": beat = Beat.ThirtySecond; goto case "Rest";
                case "rest64th": beat = Beat.SixtyFourth; goto case "Rest";
                case "Rest":
                    if (tie.Checked)
                        goto case "Tie";
                    if (ticksRestButton.Checked)
                    {
                        opcode = (byte)(13 * 14 + 12);
                        param1 = (byte)ticksRestValue.Value;
                        ssc = new Command(new byte[] { opcode, param1 }, spc, mouseOverStaff);
                    }
                    else
                    {
                        opcode = (byte)((int)beat * 14 + 12);
                        ssc = new Command(new byte[] { opcode }, spc, mouseOverStaff);
                    }
                    note = new Note(ssc, mouseOverOctave, false, 0);
                    commandStack.Push(new ScoreEdit(ScoreAction.InsertNote, staffs[mouseOverStaff].Notes, mouseDownNote, note));
                    break;
                case "Tie":
                    if (mouseDownNote == 0)
                    {
                        MessageBox.Show("Cannot put a tied note at the beginning of the staff.", "LAZY SHELL");
                        return;
                    }
                    if (ticksNoteButton.Checked || ticksRestButton.Checked)
                    {
                        opcode = (byte)(13 * 14 + 13);
                        if (ticksNoteButton.Checked)
                            param1 = (byte)ticksNoteValue.Value;
                        else if (ticksRestButton.Checked)
                            param1 = (byte)ticksRestValue.Value;
                        ssc = new Command(new byte[] { opcode, param1 }, spc, mouseOverStaff);
                    }
                    else
                    {
                        opcode = (byte)((int)beat * 14 + 13);
                        ssc = new Command(new byte[] { opcode }, spc, mouseOverStaff);
                    }
                    note = new Note(ssc, mouseOverOctave, false, 0);
                    commandStack.Push(new ScoreEdit(ScoreAction.InsertNote, staffs[mouseOverStaff].Notes, mouseDownNote, note));
                    break;
            }
            SetHScrollBar();
        }
        private void Erase()
        {
            if (mouseDownNote >= this.notes.Count)
                return;
            object temp = this.notes[mouseDownNote];
            commandStack.Push(new ScoreEdit(ScoreAction.EraseNote, this.notes, mouseDownNote, temp));
            SetHScrollBar();
        }

        #endregion

        #region Import / Export

        private void ExportScore()
        {
            // first, open and create directory
            var folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.SelectedPath = Settings.Default.LastDirectory;
            folderBrowserDialog1.Description = "Select directory to export to";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                Settings.Default.LastDirectory = folderBrowserDialog1.SelectedPath;
            else
                return;
            //
            for (int i = 0; i < staffs.Count; i++)
            {
                var script = File.CreateText(folderBrowserDialog1.SelectedPath + "\\staff" + i + ".txt");
                int octave = -2;
                Command ssc;
                foreach (var item in staffs[i].Notes)
                {
                    if (item is Note)
                    {
                        Note note = item as Note;
                        if (note.Octave == octave + 1)
                        {
                            octave++;
                            ssc = new Command(new byte[] { 0xC4 }, spc, i);
                            script.WriteLine(ssc.ToString());
                        }
                        else if (note.Octave == octave - 1)
                        {
                            octave--;
                            ssc = new Command(new byte[] { 0xC5 }, spc, i);
                            script.WriteLine(ssc.ToString());
                        }
                        else if (note.Octave != octave)
                        {
                            octave = note.Octave;
                            ssc = new Command(new byte[] { 0xC6, (byte)octave }, spc, i);
                            script.WriteLine(ssc.ToString());
                        }
                    }
                    script.WriteLine(item.ToString());
                }
                // terminate script
                ssc = new Command(new byte[] { 0xD0 }, spc, i);
                script.WriteLine(ssc.ToString());
                script.Close();
            }
        }
        private void ImportScore()
        {
            var commands = new List<Command>();
            if (!owner.ImportSPCScript(ref commands))
                return;
            //
            var notes = new List<object>();
            int index = 0;
            int octave = 6;
            bool percussive = false;
            int sample = 0;
            while (index < commands.Count)
            {
                var ssc = commands[index++];
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
            staffNew.PerformClick();
            mouseDownStaff = staffs.Count - 1;
            this.notes = notes;
            SetHScrollBar();
        }
        private void SequenceLoop(List<Command> commands, List<object> notes, ref int index,
            int start, int count, ref int octave_, ref bool percussive, ref int sample)
        {
            int octave = octave_;
            while (count > 0 && index < commands.Count)
            {
                var ssc = commands[index++];
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

        #endregion

        #endregion

        #region Event Handlers

        private void hScrollBar_ValueChanged(object sender, EventArgs e)
        {
            picture.Invalidate();
        }
        private void hScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            picture.Invalidate();
        }

        // ToolStrip
        private void note_Click(object sender, EventArgs e)
        {
            var insertObject = sender as ToolStripButton;
            foreach (var item in toolStripMain.Items)
            {
                if (item is ToolStripButton &&
                    item != insertObject)
                    (item as ToolStripButton).Checked = false;
            }
            foreach (var item in toolStripNote.Items)
            {
                if (item is ToolStripButton &&
                    item != insertObject &&
                    item != sharp &&
                    item != natural &&
                    item != flat &&
                    item != tie)
                    (item as ToolStripButton).Checked = false;
            }
            if (insertObject == ticksNoteButton)
                ticksRestButton.Checked = false;
            if (insertObject == ticksRestButton)
                ticksNoteButton.Checked = false;
            if (insertObject.Checked)
            {
                draw.Checked = true;
                this.insertObject = insertObject;
                picture.Cursor = NewCursors.Draw;
            }
            else
            {
                this.insertObject = null;
                picture.Cursor = Cursors.Arrow;
            }
        }
        private void draw_CheckedChanged(object sender, EventArgs e)
        {
            if (draw.Checked)
            {
                erase.Checked = false;
                select.Checked = false;
                paste.Checked = false;
                picture.Cursor = NewCursors.Draw;
            }
            else
                picture.Cursor = Cursors.Arrow;
            picture.Invalidate();
        }
        private void erase_CheckedChanged(object sender, EventArgs e)
        {
            if (erase.Checked)
            {
                draw.Checked = false;
                select.Checked = false;
                paste.Checked = false;
                picture.Cursor = NewCursors.Erase;
            }
            else
                picture.Cursor = Cursors.Arrow;
            picture.Invalidate();
        }
        private void select_CheckedChanged(object sender, EventArgs e)
        {
            if (select.Checked)
            {
                draw.Checked = false;
                erase.Checked = false;
                paste.Checked = false;
                picture.Cursor = Cursors.Cross;
            }
            else
            {
                overlay.Select.Clear();
                picture.Cursor = Cursors.Arrow;
            }
            picture.Invalidate();
        }
        private void paste_CheckedChanged(object sender, EventArgs e)
        {
            if (paste.Checked)
            {
                draw.Checked = false;
                erase.Checked = false;
                select.Checked = false;
                picture.Cursor = NewCursors.Draw;
            }
            else
                picture.Cursor = Cursors.Arrow;
            picture.Invalidate();
        }
        private void delete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void cut_Click(object sender, EventArgs e)
        {
            Delete();
            Copy();
        }
        private void copy_Click(object sender, EventArgs e)
        {
            Copy();
        }
        private void accidental_Click(object sender, EventArgs e)
        {
            if (sender == sharp)
            {
                flat.Checked = false;
                natural.Checked = false;
            }
            else if (sender == flat)
            {
                sharp.Checked = false;
                natural.Checked = false;
            }
            else
            {
                sharp.Checked = false;
                flat.Checked = false;
            }
        }
        private void tie_Click(object sender, EventArgs e)
        {
        }

        // Picture
        private void picture_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            int staffIndex = 0;
            foreach (var staff in staffs)
            {
                int x = -hScrollBar.Value + 64 + Music.GetKeyWidth(this.key);
                int y = staffIndex * staffHeight;
                int middle = staffHeight / 2;

                // draw staff hilite
                var brush = new SolidBrush(Color.White);
                if (staffIndex == mouseDownStaff)
                    e.Graphics.FillRectangle(brush, 0, y + 4, picture.Width, staffHeight - 8);

                // draw staff ledger lines
                DrawBarsLines(e.Graphics, staff.Clef, score.Key, staffIndex, -hScrollBar.Value, true, GetStaffWidth(staffIndex));

                // draw notes
                int indexNotes = 0;
                Note lastNote = null; // the last previous note, with a pitch
                Note lastItem = null; // the last previous note
                for (int i = 0; i < staff.Notes.Count; i++)
                {
                    object item = staff.Notes[i];
                    if (!(item is Note))
                    {
                        indexNotes++;
                        continue;
                    }
                    var note = item as Note;
                    if (x < -32 || x - 32 > picture.Width)
                    {
                        x += (int)((double)noteSpacingSW.Value / 100.0 * note.Ticks);
                        if (!note.Rest && !note.Tie)
                            lastNote = note;
                        lastItem = note;
                        indexNotes++;
                        continue;
                    }
                    bool hilite = mouseEnter && indexNotes == mouseOverNote &&
                        staffIndex == mouseOverStaff && staffIndex == mouseDownStaff;
                    bool selectNote;
                    if (overlay.Select != null)
                        selectNote = WithinSelection(i) && staffIndex == mouseDownStaff;
                    else
                        selectNote = mouseDownNote == i && staffIndex == mouseDownStaff;
                    DrawNote(e.Graphics, note, lastNote, lastItem, x, staffHeight,
                        staff.Clef, score.Key, staffIndex, hilite, selectNote);
                    x += (int)((double)noteSpacingSW.Value / 100.0 * note.Ticks);
                    if (!note.Rest && !note.Tie)
                        lastNote = note;
                    lastItem = note;
                    indexNotes++;
                }

                // draw extra lines beyond normal lines, if mouse over it
                if (mouseEnter && staffIndex == mouseOverStaff && staffIndex == mouseDownStaff && !select.Checked)
                {
                    DrawOuterLines(e.Graphics, new Pen(Color.Gray), mousePosition.X, y, middle,
                        staff.Clef, mouseOverOctave, mouseOverPitch, mouseOverLine);
                    brush.Color = Color.FromArgb(128, Color.Black);
                    if (insertObject != null && mouseEnter && mousePosition.X != -1 && mousePosition.Y != -1)
                        e.Graphics.FillEllipse(brush, mousePosition.X - 4, mousePosition.Y / 4 * 4, 8, 8);
                }
                staffIndex++;
            }

            // draw selection box
            if (select.Checked && overlay.Select != null)
            {
                e.Graphics.PixelOffsetMode = PixelOffsetMode.Default;
                overlay.Select.DrawSelectionBox(e.Graphics, 1);
            }
        }
        private void picture_MouseDown(object sender, MouseEventArgs e)
        {
            overlay.Select.Clear();
            if (staffs.Count == 0)
                return;
            if (mouseOverStaff == -1)
                return;
            if (mouseDownStaff != mouseOverStaff)
            {
                mouseDownStaff = mouseOverStaff;
                if (mouseDownStaff < staffs.Count)
                    LoadStaffProperties();
                return;
            }
            // If clicking picture right after undo/redo, must manually trigger mouseMove event
            if (mouseOverNote == -1)
                picture_MouseMove(sender, e);

            // Get index to insert between notes
            mouseDownNote = mouseOverNote;

            // Edit note(s)
            if (draw.Checked)
            {
                Draw();
                return;
            }
            if (erase.Checked)
            {
                Erase();
                return;
            }
            if (select.Checked)
            {
                overlay.Select.Reload(1, e.X, e.Y, 1, 1, picture);
                picture.Invalidate();
                return;
            }
            if (paste.Checked)
            {
                Paste(mouseDownNote);
                return;
            }
        }
        private void picture_MouseEnter(object sender, EventArgs e)
        {
            mouseEnter = true;
            picture.Focus();
        }
        private void picture_MouseLeave(object sender, EventArgs e)
        {
            mouseEnter = false;
            labelNote.Text = "...";
            picture.Invalidate();
        }
        private void picture_MouseMove(object sender, MouseEventArgs e)
        {
            int x = Math.Max(e.X, 0);
            int y = Math.Max(e.Y, 0);

            #region Selecting
            if (select.Checked)
            {
                // if making a new selection
                if (e.Button == MouseButtons.Left && overlay.Select != null)
                {
                    // cancel if within same bounds as last call
                    if (overlay.Select.Final == new Point(x, y))
                        return;
                    // otherwise, set the lower right edge of the selection
                    overlay.Select.Final = new Point(
                        Math.Min(x, picture.Width),
                        Math.Min(y, picture.Height));
                }
            }
            #endregion

            SetMouseOver(x, y);
            SetNoteLabel();

            picture.Invalidate();
        }
        private void picture_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.D: 
                    draw.PerformClick(); break;
                case Keys.E: 
                    erase.PerformClick(); break;
                case Keys.S: 
                    select.PerformClick(); break;
                case Keys.Control | Keys.C: 
                    copy.PerformClick(); break;
                case Keys.Control | Keys.X: 
                    cut.PerformClick(); break;
                case Keys.Delete: 
                    delete.PerformClick(); break;
                case Keys.Control | Keys.Z: 
                    undo.PerformClick(); break;
                case Keys.Control | Keys.Y: 
                    redo.PerformClick(); break;
                case Keys.Left:
                    if (mouseDownNote > 0)
                    {
                        mouseDownNote--;
                        Note note = staffs[mouseDownStaff].Notes[mouseDownNote] as Note;

                        // Adjust ScrollBar's left value
                        int ticks = (int)((double)noteSpacing / 100.0 * note.Ticks);
                        if (hScrollBar.Value - ticks >= 0)
                            hScrollBar.Value -= ticks;
                        picture.Invalidate();
                    }
                    break;
                case Keys.Right:
                    if (mouseDownNote < staffs[mouseDownStaff].Notes.Count - 1)
                    {
                        mouseDownNote++;
                        Note note = staffs[mouseDownStaff].Notes[mouseDownNote] as Note;

                        // Adjust ScrollBar's right value
                        int ticks = (int)((double)noteSpacing / 100.0 * note.Ticks);
                        if (hScrollBar.Value + ticks <= hScrollBar.Maximum)
                            hScrollBar.Value += ticks;
                        picture.Invalidate();
                    }
                    break;
            }
        }

        // Common commands
        private void saveScoreFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = settings.ProjectPathCustom;
            saveFileDialog.Title = "Save as new score file...";
            saveFileDialog.FileName = "score.lsscore";
            saveFileDialog.Filter = "Score File (*.lsnotes)|*.lsscore";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            //
            var s = File.Create(saveFileDialog.FileName);
            var b = new BinaryFormatter();
            b.Serialize(s, score);
            s.Close();
        }
        private void openScoreFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = settings.ProjectPathCustom;
            openFileDialog.Title = "Open existing score file...";
            openFileDialog.Filter = "Score File (*.lsscore)|*.lsscore";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            //
            var s = File.OpenRead(openFileDialog.FileName);
            var b = new BinaryFormatter();
            try
            {
                score = b.Deserialize(s) as Score;
            }
            catch
            {
                MessageBox.Show("This is not a valid score file.", "LAZY SHELL",
                MessageBoxButtons.OK);
                s.Close();
                return;
            }
            s.Close();
            //
            mouseDownStaff = 0;
            LoadScoreProperties();
            LoadStaffProperties();
            SetHScrollBar();
        }
        private void exportScoreFiles_Click(object sender, EventArgs e)
        {
            ExportScore();
        }
        private void exportStaffsMML_Click(object sender, EventArgs e)
        {
            owner.ExportMMLScript(ExportMode.ExportStaffs);
        }
        private void importScoreFiles_Click(object sender, EventArgs e)
        {
            ImportScore();
        }
        private void staffHeight_ValueChanged(object sender, EventArgs e)
        {
            staffHeightSW.Value = (int)staffHeightSW.Value / 8 * 8;
            picture.Invalidate();
        }
        private void staffNew_Click(object sender, EventArgs e)
        {
            if (staffs.Count >= 8)
                return;
            commandStack.Push(new ScoreEdit(ScoreAction.AddStaff, staffs, staffs.Count, new Staff()));
            mouseDownStaff++;
            //
            EnableToolStripControls();
            if (staffs.Count > 0)
                LoadStaffProperties();
            picture.Invalidate();
        }
        private void staffDelete_Click(object sender, EventArgs e)
        {
            if (mouseDownStaff == -1)
                return;
            //
            commandStack.Push(new ScoreEdit(ScoreAction.DeleteStaff, staffs, mouseDownStaff, staffs[mouseDownStaff]));
            if (staffs.Count >= mouseDownStaff)
                mouseDownStaff = staffs.Count - 1;
            //
            EnableToolStripControls();
            LoadStaffProperties();
            //
            picture.Invalidate();
        }
        private void staffMoveUp_Click(object sender, EventArgs e)
        {
            if (mouseDownStaff <= 0)
                return;
            staffs.Reverse(mouseDownStaff - 1, 2);
            mouseDownStaff--;
            picture.Invalidate();
        }
        private void staffMoveDown_Click(object sender, EventArgs e)
        {
            if (mouseDownStaff == -1)
                return;
            if (mouseDownStaff >= staffs.Count - 1)
                return;
            staffs.Reverse(mouseDownStaff, 2);
            mouseDownStaff++;
            picture.Invalidate();
        }
        private void clef_SelectedIndexChanged(object sender, EventArgs e)
        {
            staffs[mouseDownStaff].Clef = clef.SelectedIndex;
            picture.Invalidate();
        }
        private void keySW_SelectedIndexChanged(object sender, EventArgs e)
        {
            score.Key = (Key)keySW.SelectedIndex;
            picture.Invalidate();
        }
        private void timeBeatsSW_ValueChanged(object sender, EventArgs e)
        {
            score.TimeBeats = (int)timeBeatsSW.Value;
            picture.Invalidate();
        }
        private void timeValueSW_ValueChanged(object sender, EventArgs e)
        {
            score.TimeValue = (int)timeValueSW.Value;
            picture.Invalidate();
        }
        private void noteSpacingSW_ValueChanged(object sender, EventArgs e)
        {
            noteSpacingSW.Value = (int)noteSpacingSW.Value / 10 * 10;
            SetHScrollBar();
        }

        #endregion
    }
}
