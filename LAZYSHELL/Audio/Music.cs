using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LAZYSHELL.Audio
{
    /// <summary>
    /// Helper class for interpreting musical information when drawing a music score.
    /// </summary>
    public static class Music
    {
        /// <summary>
        /// Returns the width of a key signature's region to be drawn in the score.
        /// </summary>
        /// <param name="key">The key signature.</param>
        /// <returns></returns>
        public static int GetKeyWidth(Key key)
        {
            int width = 0;
            if (Music.GetAccidental(key, Pitch.F) == Accidental.Sharp) { width += 4; }
            if (Music.GetAccidental(key, Pitch.C) == Accidental.Sharp) { width += 4; }
            if (Music.GetAccidental(key, Pitch.G) == Accidental.Sharp) { width += 4; }
            if (Music.GetAccidental(key, Pitch.D) == Accidental.Sharp) { width += 4; }
            if (Music.GetAccidental(key, Pitch.A) == Accidental.Sharp) { width += 4; }
            if (Music.GetAccidental(key, Pitch.E) == Accidental.Sharp) { width += 4; }
            if (Music.GetAccidental(key, Pitch.B) == Accidental.Sharp) { width += 4; }
            //
            if (Music.GetAccidental(key, Pitch.B) == Accidental.Flat) { width += 4; }
            if (Music.GetAccidental(key, Pitch.E) == Accidental.Flat) { width += 4; }
            if (Music.GetAccidental(key, Pitch.A) == Accidental.Flat) { width += 4; }
            if (Music.GetAccidental(key, Pitch.D) == Accidental.Flat) { width += 4; }
            if (Music.GetAccidental(key, Pitch.G) == Accidental.Flat) { width += 4; }
            if (Music.GetAccidental(key, Pitch.C) == Accidental.Flat) { width += 4; }
            if (Music.GetAccidental(key, Pitch.F) == Accidental.Flat) { width += 4; }
            return width;
        }
        /// <summary>
        /// Creates an note stem image based on the user-specified parameters.
        /// </summary>
        /// <param name="ticks">The ticks of the note containing the stem.</param>
        /// <param name="pitch">The pitch of the note containing the stem.</param>
        /// <param name="hilite">Specifies whether to color the stem with a hilite color.</param>
        /// <param name="hiliteColor">The hilite color to color the stem with.</param>
        /// <returns></returns>
        public static Bitmap GetStem(int ticks, int pitch, bool hilite, Color hiliteColor)
        {
            Bitmap stem = null;
            if (ticks >= 192) { }
            else if (ticks >= 144) { stem = pitch >= 59 ? Icons.NoteStemDown : Icons.NoteStemUp; }
            else if (ticks >= 96) { stem = pitch >= 59 ? Icons.NoteStemDown : Icons.NoteStemUp; }
            else if (ticks >= 72) { stem = pitch >= 59 ? Icons.NoteStemDown : Icons.NoteStemUp; }
            else if (ticks >= 64) { stem = pitch >= 59 ? Icons.NoteStemDown : Icons.NoteStemUp; }
            else if (ticks >= 48) { stem = pitch >= 59 ? Icons.NoteStemDown : Icons.NoteStemUp; }
            else if (ticks >= 36) { stem = pitch >= 59 ? Icons.NoteStemDown8th : Icons.NoteStemUp8th; }
            else if (ticks >= 32) { stem = pitch >= 59 ? Icons.NoteStemDown : Icons.NoteStemUp; }
            else if (ticks >= 24) { stem = pitch >= 59 ? Icons.NoteStemDown8th : Icons.NoteStemUp8th; }
            else if (ticks >= 18) { stem = pitch >= 59 ? Icons.NoteStemDown16th : Icons.NoteStemUp16th; }
            else if (ticks >= 16) { stem = pitch >= 59 ? Icons.NoteStemDown8th : Icons.NoteStemUp8th; }
            else if (ticks >= 12) { stem = stem = pitch >= 59 ? Icons.NoteStemDown16th : Icons.NoteStemUp16th; }
            else if (ticks >= 9) { stem = pitch >= 59 ? Icons.NoteStemDown32nd : Icons.NoteStemUp32nd; }
            else if (ticks >= 8) { stem = pitch >= 59 ? Icons.NoteStemDown16th : Icons.NoteStemUp16th; }
            else if (ticks >= 6) { stem = pitch >= 59 ? Icons.NoteStemDown32nd : Icons.NoteStemUp32nd; }
            else if (ticks >= 4) { stem = pitch >= 59 ? Icons.NoteStemDown32nd : Icons.NoteStemUp32nd; }
            else if (ticks >= 3) { stem = pitch >= 59 ? Icons.NoteStemDown64th : Icons.NoteStemUp64th; }
            else if (ticks >= 2) { stem = pitch >= 59 ? Icons.NoteStemDown64th : Icons.NoteStemUp64th; }
            else if (ticks >= 1) { stem = Icons.Note64th; }
            else { stem = Icons.Note64th; }
            if (hilite && stem != null)
                stem = Do.Fill(stem, hiliteColor);
            return stem;
        }
        /// <summary>
        /// Creates an note head image based on the user-specified parameters.
        /// </summary>
        /// <param name="ticks">The ticks of the note containing the note head.</param>
        /// <param name="pitch">The pitch of the note containing the note head.</param>
        /// <param name="hilite">Specifies whether to color the note head with a hilite color.</param>
        /// <param name="hiliteColor">The hilite color to color the note head with.</param>
        /// <returns></returns>
        public static Bitmap GetHead(int ticks, int pitch, bool hilite, Color hiliteColor)
        {
            Bitmap head;
            if (ticks >= 192) { head = Icons.NoteEmpty; }
            else if (ticks >= 144) { head = Icons.NoteEmptyDotted; }
            else if (ticks >= 96) { head = Icons.NoteEmpty; }
            else if (ticks >= 72) { head = Icons.NoteHeadDotted; }
            else if (ticks >= 64) { head = Icons.NoteEmptyTriplet; }
            else if (ticks >= 48) { head = Icons.NoteHead; }
            else if (ticks >= 36) { head = Icons.NoteHeadDotted; }
            else if (ticks >= 32) { head = Icons.NoteHeadTriplet; }
            else if (ticks >= 24) { head = Icons.NoteHead; }
            else if (ticks >= 18) { head = Icons.NoteHeadDotted; }
            else if (ticks >= 16) { head = Icons.NoteHeadTriplet; }
            else if (ticks >= 12) { head = Icons.NoteHead; }
            else if (ticks >= 9) { head = Icons.NoteHeadDotted; }
            else if (ticks >= 8) { head = Icons.NoteHeadTriplet; }
            else if (ticks >= 6) { head = Icons.NoteHead; }
            else if (ticks >= 4) { head = Icons.NoteHeadTriplet; }
            else if (ticks >= 3) { head = Icons.NoteHead; }
            else if (ticks >= 2) { head = Icons.NoteHeadTriplet; }
            else if (ticks >= 1) { head = Icons.NoteHead; }
            else { head = Icons.NoteHead; }
            if (hilite)
                head = Do.Fill(head, hiliteColor);
            return head;
        }
        /// <summary>
        /// Creates a rest image based on the user-specified parameters.
        /// </summary>
        /// <param name="ticks">The ticks of the rest.</param>
        /// <param name="hilite">Specifies whether to color the rest with a hilite color.</param>
        /// <param name="hiliteColor">The hilite color to color the rest with.</param>
        /// <returns></returns>
        public static Bitmap GetRest(int ticks, bool hilite, Color hiliteColor)
        {
            Bitmap rest;
            if (ticks >= 192) { rest = Icons.RestWhole; }
            else if (ticks >= 144) { rest = Icons.RestHalfDotted; }
            else if (ticks >= 96) { rest = Icons.RestHalf; }
            else if (ticks >= 72) { rest = Icons.RestQuarterDotted; }
            else if (ticks >= 64) { rest = Icons.RestHalfTriplet; }
            else if (ticks >= 48) { rest = Icons.RestQuarter; }
            else if (ticks >= 36) { rest = Icons.Rest8thDotted; }
            else if (ticks >= 32) { rest = Icons.RestQuarterTriplet; }
            else if (ticks >= 24) { rest = Icons.Rest8th; }
            else if (ticks >= 18) { rest = Icons.Rest16thDotted; }
            else if (ticks >= 16) { rest = Icons.Rest8thTriplet; }
            else if (ticks >= 12) { rest = Icons.Rest16th; }
            else if (ticks >= 9) { rest = Icons.Rest32ndDotted; }
            else if (ticks >= 8) { rest = Icons.Rest16thTriplet; }
            else if (ticks >= 6) { rest = Icons.Rest32nd; }
            else if (ticks >= 4) { rest = Icons.Rest32ndTriplet; }
            else if (ticks >= 3) { rest = Icons.Rest64th; }
            else if (ticks >= 2) { rest = Icons.Rest64thTriplet; }
            else if (ticks >= 1) { rest = Icons.Rest64th; }
            else { rest = Icons.Rest64th; }
            if (hilite)
                rest = Do.Fill(rest, hiliteColor);
            return rest;
        }
        /// <summary>
        /// Returns the accidental status of a pitch in a specified key signature.
        /// </summary>
        /// <param name="key">The key signature.</param>
        /// <param name="pitch">The pitch.</param>
        /// <returns></returns>
        public static Accidental GetAccidental(Key key, Pitch pitch)
        {
            switch (pitch)
            {
                case Pitch.A:
                    if (key >= Key.BMajor && key <= Key.CsMajor) return Accidental.Sharp; // Sharps, major
                    if (key >= Key.GsMinor && key <= Key.AsMinor) return Accidental.Sharp; // Sharps, minor
                    if (key >= Key.EbMajor && key <= Key.CbMajor) return Accidental.Flat; // Flats, major
                    if (key >= Key.CMinor && key <= Key.AbMinor) return Accidental.Flat; // Flats, minor
                    break;
                case Pitch.B:
                    if (key == Key.CsMajor || key == Key.AsMinor) return Accidental.Sharp; // Sharps, major, minor
                    if (key >= Key.FMajor && key <= Key.CbMajor) return Accidental.Flat; // Flats, major
                    if (key >= Key.DMinor && key <= Key.AbMinor) return Accidental.Flat; // Flats, minor
                    break;
                case Pitch.C:
                    if (key >= Key.DMajor && key <= Key.CsMajor) return Accidental.Sharp; // Sharps, major
                    if (key >= Key.BMinor && key <= Key.AsMinor) return Accidental.Sharp; // Sharps, minor
                    if (key >= Key.GbMajor && key <= Key.CbMajor) return Accidental.Flat; // Flats, major
                    if (key >= Key.EbMinor && key <= Key.AbMinor) return Accidental.Flat; // Flats, minor
                    break;
                case Pitch.D:
                    if (key >= Key.EMajor && key <= Key.CsMajor) return Accidental.Sharp; // Sharps, major
                    if (key >= Key.CsMinor && key <= Key.AsMinor) return Accidental.Sharp; // Sharps, minor
                    if (key >= Key.AbMajor && key <= Key.CbMajor) return Accidental.Flat; // Flats, major
                    if (key >= Key.FMinor && key <= Key.AbMinor) return Accidental.Flat; // Flats, minor
                    break;
                case Pitch.E:
                    if (key >= Key.FsMajor && key <= Key.CsMajor) return Accidental.Sharp; // Sharps, major
                    if (key >= Key.DsMinor && key <= Key.AsMinor) return Accidental.Sharp; // Sharps, minor
                    if (key >= Key.BbMajor && key <= Key.CbMajor) return Accidental.Flat; // Flats, major
                    if (key >= Key.DMinor && key <= Key.AbMinor) return Accidental.Flat; // Flats, minor
                    break;
                case Pitch.F:
                    if (key >= Key.GMajor && key <= Key.CsMajor) return Accidental.Sharp; // Sharps, major
                    if (key >= Key.EMinor && key <= Key.AsMinor) return Accidental.Sharp; // Sharps, minor
                    if (key == Key.CbMajor || key == Key.AbMinor) return Accidental.Flat; // Flats, major, minor
                    break;
                case Pitch.G:
                    if (key >= Key.AMajor && key <= Key.CsMajor) return Accidental.Sharp; // Sharps, major
                    if (key >= Key.FsMinor && key <= Key.AsMinor) return Accidental.Sharp; // Sharps, minor
                    if (key >= Key.DbMajor && key <= Key.CbMajor) return Accidental.Flat; // Flats, major
                    if (key >= Key.BbMinor && key <= Key.AbMinor) return Accidental.Flat; // Flats, major
                    break;
            }
            return Accidental.Natural; // Natural
        }
        /// <summary>
        /// Returns what accidentals need to be SHOWN based on a given key signature. Thus, only non-black keys are checked.
        /// </summary>
        /// <param name="key">The key signature.</param>
        /// <param name="pitch">The pitch.</param>
        /// <returns></returns>
        public static Accidental ShowAccidental(Key key, Pitch pitch)
        {
            switch (pitch)
            {
                case Pitch.C:
                    if (key >= Key.DMajor && key <= Key.CsMajor) return Accidental.Natural; // Natural, major
                    if (key >= Key.BMinor && key <= Key.AsMinor) return Accidental.Natural; // Natural, minor
                    if (key >= Key.GbMajor && key <= Key.CbMajor) return Accidental.Natural; // Natural, major
                    if (key >= Key.EbMinor && key <= Key.AbMinor) return Accidental.Natural; // Natural, minor
                    break;
                case Pitch.Cs:
                    if (key >= Key.CMajor && key <= Key.GMajor) return Accidental.Sharp; // Sharps, major
                    if (key >= Key.AMinor && key <= Key.EMinor) return Accidental.Sharp; // Sharps, minor
                    if (key >= Key.FMajor && key <= Key.EbMajor) return Accidental.Flat; // Flats, major
                    if (key >= Key.DMinor && key <= Key.CMinor) return Accidental.Flat; // Flats, minor
                    break;
                case Pitch.D:
                    if (key >= Key.EMajor && key <= Key.CsMajor) return Accidental.Natural; // Natural, major
                    if (key >= Key.CsMinor && key <= Key.AsMinor) return Accidental.Natural; // Natural, minor
                    if (key >= Key.AbMajor && key <= Key.CbMajor) return Accidental.Natural; // Natural, major
                    if (key >= Key.FMinor && key <= Key.AbMinor) return Accidental.Natural; // Natural, minor
                    break;
                case Pitch.Ds:
                    if (key >= Key.CMajor && key <= Key.AMajor) return Accidental.Sharp; // Sharps, major
                    if (key >= Key.AMinor && key <= Key.FMinor) return Accidental.Sharp; // Sharps, minor
                    if (key == Key.FMajor || key == Key.DMinor) return Accidental.Flat; // Flats, major/minor
                    break;
                case Pitch.E:
                    if (key >= Key.FsMajor && key <= Key.CsMajor) return Accidental.Natural; // Sharps, major
                    if (key >= Key.DsMinor && key <= Key.AsMinor) return Accidental.Natural; // Sharps, minor
                    if (key >= Key.BbMajor && key <= Key.CbMajor) return Accidental.Natural; // Flats, major
                    if (key >= Key.DMinor && key <= Key.AbMinor) return Accidental.Natural; // Flats, minor
                    break;
                case Pitch.F:
                    if (key >= Key.GMajor && key <= Key.CsMajor) return Accidental.Natural; // Natural, major
                    if (key >= Key.EMinor && key <= Key.AsMinor) return Accidental.Natural; // Natural, minor
                    if (key == Key.CbMajor || key == Key.AbMinor) return Accidental.Natural; // Natural, major/minor
                    break;
                case Pitch.Fs:
                    if (key == Key.CMajor || key == Key.AMinor) return Accidental.Sharp; // Sharps, major
                    if (key >= Key.FMajor && key <= Key.AbMajor) return Accidental.Flat; // Flats, major
                    if (key >= Key.DMinor && key <= Key.FMinor) return Accidental.Flat; // Flats, minor
                    break;
                case Pitch.G:
                    if (key >= Key.AMajor && key <= Key.CsMajor) return Accidental.Natural; // Natural, major
                    if (key >= Key.FsMinor && key <= Key.AsMinor) return Accidental.Natural; // Natural, minor
                    if (key >= Key.DbMajor && key <= Key.CbMajor) return Accidental.Natural; // Natural, major
                    if (key >= Key.BbMinor && key <= Key.AbMinor) return Accidental.Natural; // Natural, major
                    break;
                case Pitch.Gs:
                    if (key >= Key.CMajor && key <= Key.DMajor) return Accidental.Sharp; // Sharps, major
                    if (key >= Key.AMinor && key <= Key.BMinor) return Accidental.Sharp; // Sharps, minor
                    if (key >= Key.FMajor && key <= Key.BbMajor) return Accidental.Flat; // Flats, major
                    if (key >= Key.DMinor && key <= Key.GMinor) return Accidental.Flat; // Flats, minor
                    break;
                case Pitch.A:
                    if (key >= Key.BMajor && key <= Key.CsMajor) return Accidental.Natural; // Natural, major
                    if (key >= Key.GsMinor && key <= Key.AsMinor) return Accidental.Natural; // Natural, minor
                    if (key >= Key.EbMajor && key <= Key.CbMajor) return Accidental.Natural; // Natural, major
                    if (key >= Key.CMinor && key <= Key.AbMinor) return Accidental.Natural; // Natural, minor
                    break;
                case Pitch.As:
                    if (key >= Key.CMajor && key <= Key.EMajor) return Accidental.Sharp; // Sharps, major
                    if (key >= Key.AMinor && key <= Key.CsMinor) return Accidental.Sharp; // Sharps, minor
                    if (key == Key.CMajor || key == Key.AMinor) return Accidental.Flat; // Flats, major/minor
                    break;
                case Pitch.B:
                    if (key == Key.CsMajor || key == Key.AsMinor) return Accidental.Natural; // Natural, major/minor
                    if (key >= Key.FMajor && key <= Key.CbMajor) return Accidental.Natural; // Natural, major
                    if (key >= Key.DMinor && key <= Key.AbMinor) return Accidental.Natural; // Natural, minor
                    break;
            }
            return Accidental.None; // Natural
        }
        /// <summary>
        /// Converts the notes of a specified staff collection into an array 
        /// of 8 channels containing their designated command collections.
        /// </summary>
        /// <param name="staffs">The staff collection.</param>
        /// <param name="spc">The owning SPC of the channels.</param>
        /// <returns></returns>
        public static List<Command>[] StaffsToChannels(List<Staff> staffs, SPC spc)
        {
            var channels = new List<Command>[8];
            for (int c = 0; c < 8 && c < staffs.Count; c++)
            {
                int thisOctave = -1;
                channels[c] = new List<Command>();
                foreach (object item in staffs[c].Notes)
                {
                    var note = item as Note;
                    if (note.Octave == thisOctave + 1)
                    {
                        channels[c].Add(new Command(new byte[] { 0xC4 }, spc, c));
                        thisOctave++;
                    }
                    else if (note.Octave == thisOctave - 1)
                    {
                        channels[c].Add(new Command(new byte[] { 0xC5 }, spc, c));
                        thisOctave--;
                    }
                    else if (note.Octave != thisOctave)
                    {
                        channels[c].Add(new Command(new byte[] { 0xC6, (byte)note.Octave }, spc, c));
                        thisOctave = note.Octave;
                    }
                    channels[c].Add(note.Command);
                }
            }
            return channels;
        }
    }

    #region Classes

    /// <summary>
    /// Class containing the information for an entire score in the score writer.
    /// </summary>
    [Serializable()]
    public class Score
    {
        public List<Staff> Staffs = new List<Staff>();
        public Key Key = Key.CMajor;
        public int TimeBeats = 4;
        public int TimeValue = 4;
    }

    /// <summary>
    /// Class containing the information for a staff in the score writer.
    /// </summary>
    [Serializable()]
    public class Staff
    {
        public int Clef = 0; // Treble
        public List<object> Notes = new List<object>();
        public Staff(int clef)
        {
            this.Clef = clef;
        }
        public Staff()
        {
        }
    }

    /// <summary>
    /// Class containing the information for a collection of copied notes.
    /// </summary>
    [Serializable()]
    public class CopyNotes
    {
        public int FirstOctave = 5;
        public int LastOctave = 5;
        public List<Command> Commands = new List<Command>();
    }

    #endregion

    #region Enumerators

    /// <summary>
    /// The pitch of a note in an spc track.
    /// </summary>
    public enum Pitch
    {
        C, Cs, D, Ds, E, F, Fs, G, Gs, A, As, B, Rest, Tie, Null
    }
    /// <summary>
    /// The accidental type of a note in an spc track.
    /// </summary>
    public enum Accidental
    {
        None, Flat, Natural, Sharp
    }
    /// <summary>
    /// Conventional key signatures of a music score.
    /// </summary>
    public enum Key
    {
        CMajor, GMajor, DMajor, AMajor, EMajor, BMajor, FsMajor, CsMajor, // Sharps
        FMajor, BbMajor, EbMajor, AbMajor, DbMajor, GbMajor, CbMajor, // Flats
        AMinor, EMinor, BMinor, FsMinor, CsMinor, GsMinor, DsMinor, AsMinor, // Sharps
        DMinor, GMinor, CMinor, FMinor, BbMinor, EbMinor, AbMinor // Flats
    }
    /// <summary>
    /// Conventional time units of a musical note.
    /// </summary>
    public enum Beat
    {
        Whole,
        HalfDotted,
        Half,
        QuarterDotted,
        Quarter,
        EighthDotted,
        QuarterTriplet,
        Eighth,
        EighthTriplet,
        Sixteenth,
        SixteenthTriplet,
        ThirtySecond,
        SixtyFourth,
        Empty
    }
    /// <summary>
    /// Native game SPC format of a file.
    /// </summary>
    public enum NativeSPC
    {
        SMRPG,
        SMWLevel,
        SMWOverworld,
        Custom
    }

    #endregion
}
