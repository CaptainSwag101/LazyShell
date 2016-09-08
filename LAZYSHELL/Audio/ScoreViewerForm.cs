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
using LazyShell.Properties;
using LazyShell.Undo;

namespace LazyShell.Audio
{
    public partial class ScoreViewerForm : Controls.DockForm
    {
        #region Variables

        // Index
        private int Index
        {
            get { return ownerForm.Index; }
            set { ownerForm.Index = value; }
        }
        private ElementType Type
        {
            get { return ownerForm.Type; }
            set { ownerForm.Type = value; }
        }

        // Forms
        private OwnerForm ownerForm;
        private TrackViewerForm trackViewerForm
        {
            get { return ownerForm.TrackViewerForm; }
            set { ownerForm.TrackViewerForm = value; }
        }

        // Elements
        private SPC SPC
        {
            get { return ownerForm.SPCs[Index]; }
            set { ownerForm.SPCs[Index] = value; }
        }
        private Score score;
        private Overlay overlay;
        public List<Staff> Staffs
        {
            get { return score.Staffs; }
            set { score.Staffs = value; }
        }
        private ToolStripButton insertObject;

        // Bitmaps
        private Bitmap clefF;
        private Bitmap clefG;
        private Bitmap insert;
        public Controls.NewPictureBox Picture
        {
            get { return picture; }
            set { picture = value; }
        }
        private PictureBox TrackViewerPicture
        {
            get { return trackViewerForm.Picture; }
            set { trackViewerForm.Picture = value; }
        }

        // Score properties
        private int timeBeats
        {
            get { return (int)timeBeatsSV.Value; }
            set { timeBeatsSV.Value = value; }
        }
        private int timeValue
        {
            get { return (int)timeValueSV.Value; }
            set { timeValueSV.Value = value; }
        }
        private int staffHeight
        {
            get { return (int)staffHeightSV.Value; }
            set { staffHeightSV.Value = value; }
        }
        private int noteSpacing
        {
            get { return (int)noteSpacingSV.Value; }
            set { noteSpacingSV.Value = value; }
        }
        private Key key
        {
            get { return (Key)keySV.SelectedIndex; }
            set { keySV.SelectedIndex = (int)value; }
        }

        // Collections
        private CopyNotes copyBuffer;
        private UndoStack commandStack;
        private CheckBox[] activeChannels
        {
            get { return trackViewerForm.ActiveChannels; }
            set { trackViewerForm.ActiveChannels = value; }
        }

        #region Mouse behavior

        private int mouseDownChannel
        {
            get { return trackViewerForm.MouseDownChannel; }
            set { trackViewerForm.MouseDownChannel = value; }
        }
        private int mouseOverChannel
        {
            get { return trackViewerForm.MouseOverChannel; }
            set { trackViewerForm.MouseOverChannel = value; }
        }
        private Command mouseOverSSC
        {
            get { return trackViewerForm.MouseOverSSC; }
            set { trackViewerForm.MouseOverSSC = value; }
        }
        private Command mouseDownSSC
        {
            get { return trackViewerForm.MouseDownSSC; }
            set { trackViewerForm.MouseDownSSC = value; }
        }
        private bool mouseEnter
        {
            get { return trackViewerForm.MouseEnterPage; }
            set { trackViewerForm.MouseEnterPage = value; }
        }
        private Pitch mouseOverPitch = Pitch.Null;
        private int mouseOverLine = -1;
        private int mouseOverOctave = -1;
        private int mouseOverNote = -1;
        private int mouseDownNote = -1;
        private Point mousePosition = new Point(-1, -1);

        #endregion

        #endregion

        // Constructor
        public ScoreViewerForm(OwnerForm owner)
        {
            this.ownerForm = owner;
            this.Owner = owner;
            //
            InitializeComponent();
            InitializeVariables();
            InitializeControls();
        }

        #region Methods

        #region Initialization

        public void LoadProperties()
        {
            EnableToolStrips();
            SetHScrollBar();
            labelNote.Text = "...";
            picture.Invalidate();
        }
        private void InitializeVariables()
        {
            this.score = new Score();
            this.overlay = new Overlay();
            this.commandStack = new UndoStack();
            //
            this.clefF = global::LazyShell.Properties.Resources.clefF;
            this.clefG = global::LazyShell.Properties.Resources.clefG;
            this.insert = global::LazyShell.Properties.Resources.insert;
        }
        private void InitializeControls()
        {
            this.Updating = true;
            //
            picture.KeyDown += new KeyEventHandler(picture_KeyDown);
            clefName.SelectedIndex = 0;
            keySV.SelectedIndex = 0;
            //
            this.Updating = false;
        }
        private void EnableToolStrips()
        {
            this.Updating = true;
            //
            if (Index != 0 || Type != ElementType.SPCTrack)
            {
                for (int i = 0; i < SPC.Channels.Length; i++)
                {
                    if (!SPC.ActiveChannels[i])
                        continue;
                    toolStripNote.Enabled = true;
                    toolStripAction.Enabled = true;
                }
            }
            //
            this.Updating = false;
        }
        /// <summary>
        /// Refreshes the maximum size of the hScrollBar based on the
        /// channel containing the most commands in the SPC.
        /// </summary>
        private void SetHScrollBar()
        {
            this.Updating = true;
            //
            hScrollBar.Maximum = 0;
            for (int i = 0; i < 8; i++)
            {
                if (!SPC.ActiveChannels[i])
                    continue;
                if (SPC.Notes == null)
                    continue;
                int maximum = 0;
                foreach (var note in SPC.Notes[i])
                {
                    maximum += (int)((double)noteSpacingSV.Value / 100.0 * note.Ticks);
                    if (maximum > hScrollBar.Maximum)
                        hScrollBar.Maximum = maximum;
                }
            }
            picture.Invalidate();
            //
            this.Updating = false;
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
                    DrawOutsideLines(g, Pens.Gray, x + 7, y, middle, clef, note.Octave, note.Pitch, note.Line);
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
                if (showRests.Checked)
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
                    DrawOutsideLines(g, Pens.Gray, x + 7, y, middle, clef, lastNote.Octave, lastNote.Pitch, lastNote.Line);
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
                g.DrawString(timeBeats.ToString(), font, Brushes.Black, 40 + x - 6, measureTop - 4);
            else
                g.DrawString(timeBeats.ToString(), font, Brushes.Black, 40 + x, measureTop - 4);
            if (timeValue >= 10)
                g.DrawString(timeValue.ToString(), font, Brushes.Black, 40 + x - 6, measureTop + 12);
            else
                g.DrawString(timeValue.ToString(), font, Brushes.Black, 40 + x, measureTop + 12);
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

        #endregion

        #region Octave changing

        /// <summary>
        /// Returns an octave change command if the note before the
        /// mouseOvenote is a different octave than a specified one.
        /// </summary>
        /// <param name="octave">The defined octave.</param>
        /// <returns></returns>
        public Command OctaveChangeBefore(int octave, bool checkNext)
        {
            if (checkNext && mouseOverNote >= 0)
            {
                Note nextNote = null;
                if (mouseOverNote < SPC.Notes[mouseOverChannel].Count)
                    nextNote = SPC.Notes[mouseOverChannel][mouseOverNote];
                if (nextNote != null && octave == nextNote.Octave)
                    return null;
            }
            //
            Command sscA = null;
            Note prevNote = null;
            if (mouseOverNote > 0)
                prevNote = SPC.Notes[mouseOverChannel][mouseOverNote - 1];
            // if different octave than note before, we should define octave change command before new note
            if (prevNote != null && octave != prevNote.Octave)
            {
                if (prevNote.Octave == octave - 1)
                    sscA = new Command(new byte[] { 0xC4 }, SPC, mouseOverChannel); // octave up 1
                else if (prevNote.Octave == octave + 1)
                    sscA = new Command(new byte[] { 0xC5 }, SPC, mouseOverChannel); // octave down 1
                else if (prevNote.Octave != octave)
                    sscA = new Command(new byte[] { 0xC6, (byte)octave }, SPC, mouseOverChannel);
            }
            // if very first note, we should insert new note at very beginning, and define octave change command before new note
            else if (prevNote == null)
                sscA = new Command(new byte[] { 0xC6, (byte)octave }, SPC, mouseOverChannel);
            return sscA;
        }
        /// <summary>
        /// Returns an octave change command if the note after the
        /// mouseOvenote is a different octave than a specified one.
        /// </summary>
        /// <param name="octave">The octave to compare to.</param>
        /// <param name="checkPrev">Checks if previous note is same octave as specified one.</param>
        /// <returns></returns>
        public Command OctaveChangeAfter(int octave, bool checkPrev)
        {
            if (mouseOverNote < 0)
                return null;
            //
            if (checkPrev)
            {
                Note prevNote = null;
                if (mouseOverNote > 0)
                    prevNote = SPC.Notes[mouseOverChannel][mouseOverNote - 1];
                if (prevNote != null && octave == prevNote.Octave)
                    return null;
            }
            //
            Command sscC = null;
            Note nextNote = null;
            if (mouseOverNote + 1 < SPC.Notes[mouseOverChannel].Count)
                nextNote = SPC.Notes[mouseOverChannel][mouseOverNote];
            // make an octave change come before and after the command if necessary
            // if different octave than BOTH notes before AND after, we should insert new note immediately after PREVIOUS note, 
            // and define octave change command both before and after new note
            if (nextNote != null && octave != nextNote.Octave)
            {
                if (nextNote.Octave == octave + 1)
                    sscC = new Command(new byte[] { 0xC4 }, SPC, mouseOverChannel); // octave up 1
                else if (nextNote.Octave == octave - 1)
                    sscC = new Command(new byte[] { 0xC5 }, SPC, mouseOverChannel); // octave down 1
                else if (nextNote.Octave != octave)
                    sscC = new Command(new byte[] { 0xC6, (byte)nextNote.Octave }, SPC, mouseOverChannel);
            }
            return sscC;
        }
        /// <summary>
        /// Returns the index where a new note should be inserted, based on a comparison 
        /// between a specified octave and the octaves of the previous and next notes.
        /// </summary>
        /// <param name="firstOctave">The octave of the first note in the collection.</param>
        /// <param name="lastOctave">The octave of the last note in the collection. 
        /// Same as firstOctave if inserting only one note.</param>
        /// <returns></returns>
        public int OctaveChangeIndex(int firstOctave, int lastOctave)
        {
            if (mouseOverNote < 0)
                return Math.Max(0, SPC.Channels[mouseOverChannel].Count - 1);
            int sscIndex = 0;
            // define notes before and after insertion point
            Note noteA = null;
            if (mouseOverNote > 0)
                noteA = SPC.Notes[mouseOverChannel][mouseOverNote - 1];
            Note noteC = null;
            if (mouseOverNote < SPC.Notes[mouseOverChannel].Count)
                noteC = SPC.Notes[mouseOverChannel][mouseOverNote];
            if (noteA != null)
            {
                if (firstOctave != noteA.Octave && noteC != null && lastOctave == noteC.Octave)
                    sscIndex = noteC.Index;
                else
                    sscIndex = noteA.Index + 1;
            }
            else if (noteA == null && noteC != null)
                sscIndex = lastOctave == noteC.Octave ? noteC.Index : 0;
            return sscIndex;
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
            if (mouseDownChannel == -1)
                return -1;
            int x_ = 64 + Music.GetKeyWidth(key);
            int index = 0;
            foreach (var note in SPC.Notes[mouseDownChannel])
            {
                // skip if not a note, rest, or tie
                if (note.Command.Opcode < 0xC4 && (!note.Rest || showRests.Checked))
                {
                    if (x_ + 8 >= x)
                        break;
                }
                x_ += (int)((double)noteSpacing / 100.0 * note.Ticks);
                index++;
            }
            return index;
        }
        /// <summary>
        /// Sets the values of the mouseOver variables using the specified coordinates.
        /// </summary>
        /// <param name="x">The X coordinate of the mouse position.</param>
        /// <param name="y">The Y coordinate of the mouse position.</param>
        private void SetMouseOver(int x, int y)
        {
            // Reset mouseOver properties
            mousePosition = new Point(x, y);
            mouseOverNote = -1;
            mouseOverPitch = Pitch.Null;
            mouseOverChannel = -1;
            mouseOverSSC = null;

            // If beyond boundaries of score viewer, don't draw note
            if (y / staffHeight >= SPC.Channels.Length)
            {
                picture.Invalidate();
                labelNote.Text = "...";
                return;
            }

            // Set channel mouse is over based on Y position of mouse
            mouseOverChannel = y / staffHeight;

            // If not over the currently selected channel, don't draw note
            if (mouseOverChannel != mouseDownChannel)
            {
                picture.Invalidate();
                labelNote.Text = "...";
                return;
            }

            // Get X position of mouse based on hScrollBar value
            x = Math.Max(x + hScrollBar.Value, 0);

            // Get Y position of mouse within the staff the mouse is over
            y = y % staffHeight;

            // Set mouseOvenote to index of note based on X position
            mouseOverNote = GetNoteIndex(x);

            // Set mouseOverSSC to the command associated with the mouseOvenote index
            if (mouseOverNote >= 0 && mouseOverNote < SPC.Notes[mouseOverChannel].Count)
            {
                Note note = SPC.Notes[mouseOverChannel][mouseOverNote];
                mouseOverSSC = note.Command;
            }

            // Create a value to offset the line at based on the current clef
            int staffOffset = 0;
            if (clefName.SelectedIndex == 0)
                staffOffset = -1; // Treble
            else if (clefName.SelectedIndex == 1)
                staffOffset = 1;  // Bass

            // Get line including octave level (272 is the staff size where everything is perfect)
            int line = (staffHeight / 4) - (y / 4) + ((272 - staffHeight) / 8) + staffOffset;

            // Set mouseOverLine to the base line within the octave
            mouseOverLine = line % 7;

            // First: set mouseOverPitch based on current line
            switch (mouseOverLine)
            {
                case 0: mouseOverPitch = Pitch.C; labelNote.Text = "C"; break;
                case 1: mouseOverPitch = Pitch.D; labelNote.Text = "D"; break;
                case 2: mouseOverPitch = Pitch.E; labelNote.Text = "E"; break;
                case 3: mouseOverPitch = Pitch.F; labelNote.Text = "F"; break;
                case 4: mouseOverPitch = Pitch.G; labelNote.Text = "G"; break;
                case 5: mouseOverPitch = Pitch.A; labelNote.Text = "A"; break;
                case 6: mouseOverPitch = Pitch.B; labelNote.Text = "B"; break;
                default: mouseOverPitch = Pitch.Null; labelNote.Text = ""; break;
            }

            // Second: adjust pitch based on checked accidental AND key signature
            if (sharp.Checked)
                mouseOverPitch++;
            if (flat.Checked)
                mouseOverPitch--;

            // Get the accidental of mouseOverPitch based on key signature
            var accidental = Music.ShowAccidental(this.key, mouseOverPitch);

            // Third: adjust pitch again, based on accidental status in key signature
            if (!natural.Checked && accidental == Accidental.Natural)
            {
                if ((this.key >= Key.CMajor && this.key <= Key.CsMajor) ||
                    (this.key >= Key.AMinor && this.key <= Key.AsMinor))
                    mouseOverPitch++; // sharp key
                else
                    mouseOverPitch--; // flat key
            }

            // Get the octave the mouse is over
            mouseOverOctave = line / 7;

            // Last: if adjusted mouseOverPitch overflowed, reset pitch and raise octave
            if (mouseOverPitch == Pitch.Rest)
            {
                mouseOverPitch = Pitch.C;
                mouseOverOctave++;
            }

            // Finally add octave to note label
            if (mouseOverChannel == mouseDownChannel)
                labelNote.Text += mouseOverOctave.ToString();
            else
                labelNote.Text = "...";

            // Finished
            picture.Invalidate();
        }
        /// <summary>
        /// Indicates whether a note's index in the currently selected channel 
        /// is within the boundaries of the current selection box.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool WithinSelection(int index)
        {
            if (overlay.Select.Empty)
                return false;
            int selectionStart = GetNoteIndex(overlay.Select.Location.X + hScrollBar.Value);
            int selectionEnd = GetNoteIndex(overlay.Select.Terminal.X + hScrollBar.Value);
            return index >= selectionStart && index < selectionEnd;
        }
        /// <summary>
        /// Returns a staff's width based on the number of notes in the staff
        /// and the note spacing property set by the user.
        /// </summary>
        /// <param name="staffIndex"></param>
        /// <returns></returns>
        private int GetStaffWidth(int staffIndex)
        {
            int staffWidth = 0;
            foreach (var note in SPC.Notes[staffIndex])
                staffWidth += (int)((double)noteSpacing / 100.0 * note.Ticks);
            return staffWidth;
        }
        private void SetToolStripEditMode(ToolStripButton button)
        {
            if (button.Checked)
            {
                if (button != draw)
                    draw.Checked = false;
                if (button != select)
                    select.Checked = false;
                if (button != paste)
                    paste.Checked = false;
                if (button != erase)
                    erase.Checked = false;
                //
                if (button == draw)
                    picture.Cursor = NewCursors.Draw;
                else if (button == select)
                    picture.Cursor = Cursors.Cross;
                else if (button == paste)
                    picture.Cursor = NewCursors.Draw;
                else if (button == erase)
                    picture.Cursor = NewCursors.Erase;
            }
            else
                picture.Cursor = Cursors.Arrow;
            picture.Invalidate();
        }

        #endregion

        #region Selection editing

        private void Cut()
        {
            Copy();
            Delete();
        }
        private void Copy()
        {
            if (overlay.Select.Empty)
                return;
            int start = GetNoteIndex(overlay.Select.Location.X + hScrollBar.Value);
            int end = GetNoteIndex(overlay.Select.Terminal.X + hScrollBar.Value);
            if (start >= end)
                return;
            copyBuffer = new CopyNotes();
            copyBuffer.FirstOctave = SPC.Notes[mouseDownChannel][start].Octave;
            copyBuffer.LastOctave = SPC.Notes[mouseDownChannel][end - 1].Octave;
            // create a temporary list of notes to be copied, canceling the operation if there's a repeat
            int index = 0;
            List<Note> notes = new List<Note>();
            for (int i = start; i < end; i++)
            {
                Note note = SPC.Notes[mouseDownChannel][i];
                if (note.Index < index) // this means there was a repeat encountered, we must cancel
                {
                    MessageBox.Show("The current selection contains a repeat command.\n\n" +
                        "Any notes after the repeat command will NOT be copied.",
                        "LAZY SHELL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }
                index = note.Index;
                notes.Add(note);
            }
            if (notes.Count == 0)
                return;
            //
            start = notes[0].Index;
            end = notes[notes.Count - 1].Index;
            List<Command> channel = SPC.Channels[mouseDownChannel];
            for (int i = start; i <= end; i++)
            {
                // don't add repeat commands
                if (channel[i].Opcode < 0xD4 || channel[i].Opcode > 0xD7)
                    copyBuffer.Commands.Add(channel[i].Copy());
            }
        }
        private void Paste(int index)
        {
            if (copyBuffer == null)
                return;
            if (index > SPC.Channels[mouseDownChannel].Count)
                return;
            var temp = new List<Command>();
            foreach (var ssc in copyBuffer.Commands)
                temp.Add(ssc.Copy());
            // add octave changes before and/or after if necessary
            int sscIndex = OctaveChangeIndex(copyBuffer.FirstOctave, copyBuffer.LastOctave);
            var sscA = OctaveChangeBefore(copyBuffer.FirstOctave, temp.Count == 1);
            var sscC = OctaveChangeAfter(copyBuffer.LastOctave, temp.Count == 1 || sscA != null);
            if (sscA != null)
                temp.Insert(0, sscA.Copy());
            if (sscC != null)
                temp.Add(sscC.Copy());
            foreach (var ssc in temp)
                ssc.Channel = mouseDownChannel;
            //
            commandStack.Push(new ScoreEdit(ScoreAction.PasteNotes, SPC.Channels[mouseDownChannel], temp, sscIndex));
            //
            Change();
        }
        private void Delete()
        {
            if (overlay.Select.Empty)
                return;
            if (SPC.Notes[mouseDownChannel].Count == 0)
                return;
            int start = GetNoteIndex(overlay.Select.Location.X + hScrollBar.Value);
            int end = GetNoteIndex(overlay.Select.Terminal.X + hScrollBar.Value);
            if (start >= end)
                return;
            start = SPC.Notes[mouseDownChannel][start].Index;
            if (end < SPC.Notes[mouseDownChannel].Count)
                end = SPC.Notes[mouseDownChannel][end].Index + 1;
            else
                end = SPC.Notes[mouseDownChannel][SPC.Notes[mouseDownChannel].Count - 1].Index + 1;
            List<Command> temp = new List<Command>();
            for (int i = start; i < end; i++)
                temp.Add(SPC.Channels[mouseDownChannel][i]);
            commandStack.Push(new ScoreEdit(ScoreAction.DeleteNotes, SPC.Channels[mouseDownChannel], temp, start));
            overlay.Select.Clear();
            //
            Change();
        }

        #endregion

        #region Note editing

        private void Draw()
        {
            if (insertObject == null)
                return;
            //
            Beat beat = Beat.Empty;
            byte opcode = 0;
            byte param1 = 0;
            int sscIndex = 0;
            Command sscA = null;
            Command sscB = null;
            Command sscC = null;
            switch (insertObject.Name)
            {
                case "rTicksNoteButton": goto case "Note";
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
                        sscB = new Command(new byte[] { opcode, param1 }, SPC, mouseOverChannel);
                    }
                    else
                    {
                        opcode = (byte)((int)beat * 14 + mouseOverPitch);
                        sscB = new Command(new byte[] { opcode }, SPC, mouseOverChannel);
                    }
                    sscA = OctaveChangeBefore(mouseOverOctave, true);
                    sscC = OctaveChangeAfter(mouseOverOctave, true);
                    sscIndex = OctaveChangeIndex(mouseOverOctave, mouseOverOctave);
                    commandStack.Push(new ScoreEdit(ScoreAction.InsertNote, SPC.Channels[mouseOverChannel], sscIndex, sscA, sscB, sscC));
                    break;
                case "rTicksRestButton": goto case "Rest";
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
                        sscB = new Command(new byte[] { opcode, param1 }, SPC, mouseOverChannel);
                    }
                    else
                    {
                        opcode = (byte)((int)beat * 14 + 12);
                        sscB = new Command(new byte[] { opcode }, SPC, mouseOverChannel);
                    }
                    sscIndex = mouseOverSSC.Index;
                    commandStack.Push(new ScoreEdit(ScoreAction.InsertNote, SPC.Channels[mouseOverChannel], sscIndex, sscB));
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
                        sscB = new Command(new byte[] { opcode, param1 }, SPC, mouseOverChannel);
                    }
                    else
                    {
                        opcode = (byte)((int)beat * 14 + 13);
                        sscB = new Command(new byte[] { opcode }, SPC, mouseOverChannel);
                    }
                    sscIndex = mouseOverSSC.Index;
                    commandStack.Push(new ScoreEdit(ScoreAction.InsertNote, SPC.Channels[mouseOverChannel], sscIndex, sscB));
                    break;
            }
            Change();
        }
        private void Erase()
        {
            if (mouseDownNote >= SPC.Notes[mouseOverChannel].Count)
                return;
            int sscIndex = mouseOverSSC.Index;
            commandStack.Push(new ScoreEdit(ScoreAction.EraseNote, SPC.Channels[mouseOverChannel], sscIndex, mouseDownSSC));
            Change();
        }
        private void Undo()
        {
            commandStack.UndoCommand();
            mouseOverPitch = Pitch.Null;
            mouseOverNote = -1;
            Change();
        }
        private void Redo()
        {
            commandStack.RedoCommand();
            mouseOverPitch = Pitch.Null;
            mouseOverNote = -1;
            Change();
        }
        private void Change()
        {
            if (Type == ElementType.SPCTrack)
                (SPC as SPCTrack).WriteToBuffer();
            SPC.CreateNotes();
            SetHScrollBar();
            picture.Invalidate();
            TrackViewerPicture.Invalidate();
            ownerForm.SetFreeBytesLabel();
        }

        #endregion

        #endregion

        #region Event Handlers

        // Picture
        private void picture_Paint(object sender, PaintEventArgs e)
        {
            if (Index == 0 || Type != ElementType.SPCTrack)
                return;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            int staffIndex = 0;
            int max = SPC.Channels.Length;
            for (; staffIndex < max; staffIndex++)
            {
                if (SPC.Channels[staffIndex] == null || !SPC.ActiveChannels[staffIndex])
                    continue;
                int x = -hScrollBar.Value + 64 + Music.GetKeyWidth(this.key);
                int y = staffIndex * staffHeight;
                int middle = staffHeight / 2;

                // Draw staff hilite
                SolidBrush brush = new SolidBrush(Color.White);
                if (staffIndex == mouseDownChannel)
                    e.Graphics.FillRectangle(brush, 0, y + 4, picture.Width, staffHeight - 8);

                // Draw staff ledger lines
                DrawBarsLines(e.Graphics, clefName.SelectedIndex, key, staffIndex, -hScrollBar.Value, true, GetStaffWidth(staffIndex));

                // Draw notes
                int indexNotes = 0;
                Note lastNote = null; // the last previous note, with a pitch
                Note lastItem = null; // the last previous note
                for (int i = 0; i < SPC.Notes[staffIndex].Count; i++)
                {
                    object item = SPC.Notes[staffIndex][i];
                    if (!(item is Note))
                    {
                        indexNotes++;
                        continue;
                    }
                    var note = item as Note;
                    if (x < -32 || x - 32 > picture.Width)
                    {
                        x += (int)((double)noteSpacing / 100.0 * note.Ticks);
                        if (!note.Rest && !note.Tie)
                            lastNote = note;
                        lastItem = note;
                        indexNotes++;
                        continue;
                    }
                    switch (note.Command.Opcode)
                    {
                        case 0xD7: // Loop
                            e.Graphics.DrawImage(Icons.LoopInf, (int)x, y + 8); break;

                        case 0xDE: // Change instrument
                            e.Graphics.DrawImage(Icons.Instrument, (int)x, y + 8);
                            brush.Color = Color.FromArgb(96, 96, 96);
                            Font font = new Font("Arial", 8.25F);
                            e.Graphics.DrawString(Lists.Samples[note.Command.Param1], font, brush, (int)x + 16, y + 8);
                            break;

                        case 0xEE: // Drums on
                            e.Graphics.DrawImage(Icons.DrumsOn, (int)x, y + 8); break;

                        case 0xEF: // Drums off
                            e.Graphics.DrawImage(Icons.DrumsOff, (int)x, y + 8); break;

                        default:   // Draw note

                            // Decide if note is to be a highlighted color (red)
                            bool hilite = mouseEnter && indexNotes == mouseOverNote &&
                                staffIndex == mouseOverChannel && staffIndex == mouseDownChannel;

                            // Decide if note is to be a selected color (blue)
                            bool selectNote;
                            if (overlay.Select != null)
                                selectNote = WithinSelection(i) && staffIndex == mouseDownChannel;
                            else
                                selectNote = mouseDownNote == i && staffIndex == mouseDownChannel;

                            // Draw note onto canvas
                            DrawNote(e.Graphics, note, lastNote, lastItem, x, staffHeight,
                                clefName.SelectedIndex, key, staffIndex, hilite, selectNote);
                            break;
                    }
                    x += (int)((double)noteSpacing / 100.0 * note.Ticks);
                    if (!note.Rest && !note.Tie)
                        lastNote = note;
                    lastItem = note;
                    indexNotes++;
                }

                // Draw extra lines beyond normal lines, if mouse over it
                if (mouseEnter && staffIndex == mouseOverChannel && staffIndex == mouseDownChannel && !select.Checked)
                {
                    DrawOutsideLines(e.Graphics, new Pen(Color.Gray), mousePosition.X, y, middle,
                        clefName.SelectedIndex, mouseOverOctave, mouseOverPitch, mouseOverLine);
                    brush.Color = Color.FromArgb(128, Color.Black);
                    if (insertObject != null && mouseEnter && mousePosition.X != -1 && mousePosition.Y != -1)
                        e.Graphics.FillEllipse(brush, mousePosition.X - 4, mousePosition.Y / 4 * 4, 8, 8);
                }
            }

            // Draw selection box
            if (select.Checked && overlay.Select != null)
            {
                e.Graphics.PixelOffsetMode = PixelOffsetMode.Default;
                overlay.Select.DrawSelectionBox(e.Graphics, 1);
            }
        }
        private void picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (Type != ElementType.SPCTrack)
                return;
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
        }
        private void picture_MouseDown(object sender, MouseEventArgs e)
        {
            if (Type != ElementType.SPCTrack)
                return;
            overlay.Select.Clear();
            if (!SPC.ActiveChannels[mouseOverChannel])
                return;
            if (mouseOverChannel == -1)
                return;
            if (mouseDownChannel != mouseOverChannel)
                mouseDownChannel = mouseOverChannel;

            // If clicking picture right after undo/redo, must manually trigger mouseMove event
            if (mouseOverNote == -1)
                picture_MouseMove(sender, e);

            // Get index to insert between notes (and commands)
            mouseDownSSC = mouseOverSSC;
            mouseDownNote = mouseOverNote;

            // Select note's command in track viewer
            if (mouseDownNote != -1)
                trackViewerForm.SelectCommand(mouseDownSSC);

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
                if (mouseOverSSC != null)
                    Paste(mouseOverSSC.Index);
                else
                    Paste(SPC.Channels[mouseDownChannel].Count);
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
        private void picture_KeyDown(object sender, KeyEventArgs e)
        {
            if (Type != ElementType.SPCTrack)
                return;
            switch (e.KeyData)
            {
                case Keys.D: draw.PerformClick(); break;
                case Keys.E: erase.PerformClick(); break;
                case Keys.S: select.PerformClick(); break;
                case Keys.Control | Keys.C: Copy(); break;
                case Keys.Control | Keys.X: Cut(); break;
                case Keys.Delete: Delete(); break;
                case Keys.Control | Keys.Z: Undo(); break;
                case Keys.Control | Keys.Y: Redo(); break;
                case Keys.Left:
                    if (mouseDownNote > 0)
                    {
                        mouseDownNote--;
                        var note = SPC.Notes[mouseDownChannel][mouseDownNote];
                        mouseDownSSC = note.Command;

                        // Adjust ScrollBar's left value
                        int ticks = (int)((double)noteSpacing / 100.0 * note.Ticks);
                        if (hScrollBar.Value - ticks >= 0)
                            hScrollBar.Value -= ticks;

                        // Select note's command in track viewer
                        if (mouseDownNote != -1)
                            trackViewerForm.SelectCommand(mouseDownSSC);
                    }
                    break;
                case Keys.Right:
                    if (mouseDownNote < SPC.Notes[mouseDownChannel].Count - 1)
                    {
                        mouseDownNote++;
                        var note = SPC.Notes[mouseDownChannel][mouseDownNote];
                        mouseDownSSC = note.Command;

                        // Adjust ScrollBar's right value
                        int ticks = (int)((double)noteSpacing / 100.0 * note.Ticks);
                        if (hScrollBar.Value + ticks <= hScrollBar.Maximum)
                            hScrollBar.Value += ticks;

                        // Select note's command in track viewer
                        if (mouseDownNote != -1)
                            trackViewerForm.SelectCommand(mouseDownSSC);
                    }
                    break;
            }
        }

        // ToolStrip : Properties
        private void staffHeightChannel_ValueChanged(object sender, EventArgs e)
        {
            staffHeightSV.Value = (int)staffHeightSV.Value / 8 * 8;
            picture.Height = (int)(staffHeightSV.Value * 8);
            picture.Invalidate();
        }
        private void keySV_SelectedIndexChanged(object sender, EventArgs e)
        {
            picture.Invalidate();
        }
        private void clefSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            picture.Invalidate();
        }
        private void time_ValueChanged(object sender, EventArgs e)
        {
            picture.Invalidate();
        }
        private void noteSpacing_ValueChanged(object sender, EventArgs e)
        {
            if (Index == 0 && Type == ElementType.SPCTrack)
                return;
            noteSpacingSV.Value = (int)noteSpacingSV.Value / 10 * 10;
            SetHScrollBar();
        }
        private void showRests_CheckedChanged(object sender, EventArgs e)
        {
            picture.Invalidate();
        }
        private void singleChannelNum_ValueChanged(object sender, EventArgs e)
        {
            picture.Invalidate();
        }

        // ToolStrip : Editing
        private void note_Click(object sender, EventArgs e)
        {
            var insertObject = sender as ToolStripButton;
            foreach (var item in toolStripMain.Items)
                if (item is ToolStripButton &&
                    item != insertObject)
                    (item as ToolStripButton).Checked = false;
            foreach (var item in toolStripNote.Items)
                if (item is ToolStripButton &&
                    item != insertObject &&
                    item != sharp &&
                    item != natural &&
                    item != flat &&
                    item != tie)
                    (item as ToolStripButton).Checked = false;
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
            SetToolStripEditMode(sender as ToolStripButton);
        }
        private void erase_CheckedChanged(object sender, EventArgs e)
        {
            SetToolStripEditMode(sender as ToolStripButton);
        }
        private void select_CheckedChanged(object sender, EventArgs e)
        {
            SetToolStripEditMode(sender as ToolStripButton);
        }
        private void paste_CheckedChanged(object sender, EventArgs e)
        {
            SetToolStripEditMode(sender as ToolStripButton);
        }
        private void delete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void cut_Click(object sender, EventArgs e)
        {
            Cut();
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
        private void undo_Click(object sender, EventArgs e)
        {
            Undo();
        }
        private void redo_Click(object sender, EventArgs e)
        {
            Redo();
        }

        // ScrollBar
        private void hScrollBar_ValueChanged(object sender, EventArgs e)
        {
            picture.Invalidate();
        }
        private void hScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            picture.Invalidate();
        }

        #endregion
    }
}
