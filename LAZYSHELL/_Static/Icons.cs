using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using LazyShell.Properties;

namespace LazyShell
{
    /// <summary>
    /// Class for accessing the icons used by the application for drawing to canvas.
    /// </summary>
    public sealed class Icons
    {
        #region Music notes

        public static readonly Bitmap NoteWhole = global::LazyShell.Properties.Resources.noteWhole;
        public static readonly Bitmap NoteHalfDotted = global::LazyShell.Properties.Resources.noteHalfDotted;
        public static readonly Bitmap NoteHalf = global::LazyShell.Properties.Resources.noteHalf;
        public static readonly Bitmap NoteHalfTriplet = global::LazyShell.Properties.Resources.noteHalfTriplet;
        public static readonly Bitmap NoteQuarterDotted = global::LazyShell.Properties.Resources.noteDotted;
        public static readonly Bitmap NoteQuarter = global::LazyShell.Properties.Resources.noteQuarter;
        public static readonly Bitmap Note8thDotted = global::LazyShell.Properties.Resources.note8thDotted;
        public static readonly Bitmap NoteQuarterTriplet = global::LazyShell.Properties.Resources.noteQuarterTriplet;
        public static readonly Bitmap Note8th = global::LazyShell.Properties.Resources.note8th;
        public static readonly Bitmap Note8thTriplet = global::LazyShell.Properties.Resources.note8thTriplet;
        public static readonly Bitmap Note16th = global::LazyShell.Properties.Resources.note16th;
        public static readonly Bitmap Note16thDotted = global::LazyShell.Properties.Resources.note16thDotted;
        public static readonly Bitmap Note16thTriplet = global::LazyShell.Properties.Resources.note16thTriplet;
        public static readonly Bitmap Note32nd = global::LazyShell.Properties.Resources.note32nd;
        public static readonly Bitmap Note32ndDotted = global::LazyShell.Properties.Resources.note32ndDotted;
        public static readonly Bitmap Note32ndTriplet = global::LazyShell.Properties.Resources.note32ndTriplet;
        public static readonly Bitmap Note64th = global::LazyShell.Properties.Resources.note64th;
        public static readonly Bitmap Note64thTriplet = global::LazyShell.Properties.Resources.note64thTriplet;
        public static readonly Bitmap NotePercussion = global::LazyShell.Properties.Resources.notePercussion;

        #endregion

        #region Music rests

        public static readonly Bitmap RestWhole = global::LazyShell.Properties.Resources.restWhole;
        public static readonly Bitmap RestHalfDotted = global::LazyShell.Properties.Resources.restHalfDotted;
        public static readonly Bitmap RestHalf = global::LazyShell.Properties.Resources.restHalf;
        public static readonly Bitmap RestHalfTriplet = global::LazyShell.Properties.Resources.restHalfTriplet;
        public static readonly Bitmap RestQuarterDotted = global::LazyShell.Properties.Resources.restDotted;
        public static readonly Bitmap RestQuarter = global::LazyShell.Properties.Resources.restQuarter;
        public static readonly Bitmap Rest8thDotted = global::LazyShell.Properties.Resources.rest8thDotted;
        public static readonly Bitmap RestQuarterTriplet = global::LazyShell.Properties.Resources.restQuarterTriplet;
        public static readonly Bitmap Rest8th = global::LazyShell.Properties.Resources.rest8th;
        public static readonly Bitmap Rest8thTriplet = global::LazyShell.Properties.Resources.rest8thTriplet;
        public static readonly Bitmap Rest16th = global::LazyShell.Properties.Resources.rest16th;
        public static readonly Bitmap Rest16thDotted = global::LazyShell.Properties.Resources.rest16thDotted;
        public static readonly Bitmap Rest16thTriplet = global::LazyShell.Properties.Resources.rest16thTriplet;
        public static readonly Bitmap Rest32ndDotted = global::LazyShell.Properties.Resources.rest32ndDotted;
        public static readonly Bitmap Rest32nd = global::LazyShell.Properties.Resources.rest32nd;
        public static readonly Bitmap Rest32ndTriplet = global::LazyShell.Properties.Resources.rest32ndTriplet;
        public static readonly Bitmap Rest64th = global::LazyShell.Properties.Resources.rest64th;
        public static readonly Bitmap Rest64thTriplet = global::LazyShell.Properties.Resources.rest64thTriplet;

        #endregion

        #region Music note parts

        public static readonly Bitmap NoteStemUp = global::LazyShell.Properties.Resources.noteStemUp;
        public static readonly Bitmap NoteStemUp8th = global::LazyShell.Properties.Resources.noteStemUp8th;
        public static readonly Bitmap NoteStemUp16th = global::LazyShell.Properties.Resources.noteStemUp16th;
        public static readonly Bitmap NoteStemUp32nd = global::LazyShell.Properties.Resources.noteStemUp32nd;
        public static readonly Bitmap NoteStemUp64th = global::LazyShell.Properties.Resources.noteStemUp64th;
        public static readonly Bitmap NoteStemDown = global::LazyShell.Properties.Resources.noteStemDown;
        public static readonly Bitmap NoteStemDown8th = global::LazyShell.Properties.Resources.noteStemDown8th;
        public static readonly Bitmap NoteStemDown16th = global::LazyShell.Properties.Resources.noteStemDown16th;
        public static readonly Bitmap NoteStemDown32nd = global::LazyShell.Properties.Resources.noteStemDown32nd;
        public static readonly Bitmap NoteStemDown64th = global::LazyShell.Properties.Resources.noteStemDown64th;
        public static readonly Bitmap NoteHead = global::LazyShell.Properties.Resources.noteHead;
        public static readonly Bitmap NoteHeadDotted = global::LazyShell.Properties.Resources.noteHeadDotted;
        public static readonly Bitmap NoteHeadTriplet = global::LazyShell.Properties.Resources.noteHeadTriplet;
        public static readonly Bitmap NoteHeadPercussion = global::LazyShell.Properties.Resources.noteHeadPercussion;
        public static readonly Bitmap NoteEmpty = global::LazyShell.Properties.Resources.noteEmpty;
        public static readonly Bitmap NoteEmptyDotted = global::LazyShell.Properties.Resources.noteEmptyDotted;
        public static readonly Bitmap NoteEmptyTriplet = global::LazyShell.Properties.Resources.noteEmptyTriplet;
        public static readonly Bitmap TieOver = global::LazyShell.Properties.Resources.tieOver;
        public static readonly Bitmap TieUnder = global::LazyShell.Properties.Resources.tieUnder;

        #endregion

        #region Misc music icons

        public static readonly Bitmap Sharp = global::LazyShell.Properties.Resources.sharp;
        public static readonly Bitmap Flat = global::LazyShell.Properties.Resources.flat;
        public static readonly Bitmap Natural = global::LazyShell.Properties.Resources.natural;
        public static readonly Bitmap OctaveUp = global::LazyShell.Properties.Resources.octaveUp;
        public static readonly Bitmap OctaveDown = global::LazyShell.Properties.Resources.octaveDown;
        public static readonly Bitmap OctaveSet = global::LazyShell.Properties.Resources.octaveSet;
        public static readonly Bitmap Terminate = global::LazyShell.Properties.Resources.terminate;
        public static readonly Bitmap Metronome = global::LazyShell.Properties.Resources.metronome;
        public static readonly Bitmap Loop = global::LazyShell.Properties.Resources.repeatStart;
        public static readonly Bitmap LoopEnd = global::LazyShell.Properties.Resources.repeatEnd;
        public static readonly Bitmap FirstSection = global::LazyShell.Properties.Resources.firstSection;
        public static readonly Bitmap LoopInf = global::LazyShell.Properties.Resources.repeatInf;
        public static readonly Bitmap Instrument = global::LazyShell.Properties.Resources.instrument;
        public static readonly Bitmap Volume = global::LazyShell.Properties.Resources.volume;
        public static readonly Bitmap Portamento = global::LazyShell.Properties.Resources.portamento;
        public static readonly Bitmap SpeakerBalance = global::LazyShell.Properties.Resources.speakerBalance;
        public static readonly Bitmap Tremolo = global::LazyShell.Properties.Resources.tremolo;
        public static readonly Bitmap ReverbOn = global::LazyShell.Properties.Resources.reverbOn;
        public static readonly Bitmap ReverbOff = global::LazyShell.Properties.Resources.reverbOff;
        public static readonly Bitmap DrumsOn = global::LazyShell.Properties.Resources.drumsOn;
        public static readonly Bitmap DrumsOff = global::LazyShell.Properties.Resources.drumsOff;
        public static readonly Bitmap Vibrato = global::LazyShell.Properties.Resources.vibrato;

        #endregion

        private static Bitmap transparentBG;
        /// <summary>
        /// Creates a 256x256 image with a tiled checkered white/grey
        /// background from the image file in the global::LazyShell.Properties.Resources.
        /// </summary>
        public static Bitmap TransparentBG
        {
            get
            {
                if (transparentBG == null)
                {
                    transparentBG = new Bitmap(256, 256);
                    var g = Graphics.FromImage(transparentBG);
                    var _transparent = global::LazyShell.Properties.Resources._transparent;
                    for (int y = 0; y < 256; y += 8)
                    {
                        for (int x = 0; x < 256; x += 8)
                            g.DrawImage(_transparent, x, y);
                    }
                }
                return transparentBG;
            }
        }
    }
}
