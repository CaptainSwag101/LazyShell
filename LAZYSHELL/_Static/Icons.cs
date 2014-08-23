using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    /// <summary>
    /// Class for accessing the icons used by the application for drawing to canvas.
    /// </summary>
    public sealed class Icons
    {
        #region Music notes

        public static readonly Bitmap NoteWhole = Resources.noteWhole;
        public static readonly Bitmap NoteHalfDotted = Resources.noteHalfDotted;
        public static readonly Bitmap NoteHalf = Resources.noteHalf;
        public static readonly Bitmap NoteHalfTriplet = Resources.noteHalfTriplet;
        public static readonly Bitmap NoteQuarterDotted = Resources.noteDotted;
        public static readonly Bitmap NoteQuarter = Resources.noteQuarter;
        public static readonly Bitmap Note8thDotted = Resources.note8thDotted;
        public static readonly Bitmap NoteQuarterTriplet = Resources.noteQuarterTriplet;
        public static readonly Bitmap Note8th = Resources.note8th;
        public static readonly Bitmap Note8thTriplet = Resources.note8thTriplet;
        public static readonly Bitmap Note16th = Resources.note16th;
        public static readonly Bitmap Note16thDotted = Resources.note16thDotted;
        public static readonly Bitmap Note16thTriplet = Resources.note16thTriplet;
        public static readonly Bitmap Note32nd = Resources.note32nd;
        public static readonly Bitmap Note32ndDotted = Resources.note32ndDotted;
        public static readonly Bitmap Note32ndTriplet = Resources.note32ndTriplet;
        public static readonly Bitmap Note64th = Resources.note64th;
        public static readonly Bitmap Note64thTriplet = Resources.note64thTriplet;
        public static readonly Bitmap NotePercussion = Resources.notePercussion;

        #endregion

        #region Music rests

        public static readonly Bitmap RestWhole = Resources.restWhole;
        public static readonly Bitmap RestHalfDotted = Resources.restHalfDotted;
        public static readonly Bitmap RestHalf = Resources.restHalf;
        public static readonly Bitmap RestHalfTriplet = Resources.restHalfTriplet;
        public static readonly Bitmap RestQuarterDotted = Resources.restDotted;
        public static readonly Bitmap RestQuarter = Resources.restQuarter;
        public static readonly Bitmap Rest8thDotted = Resources.rest8thDotted;
        public static readonly Bitmap RestQuarterTriplet = Resources.restQuarterTriplet;
        public static readonly Bitmap Rest8th = Resources.rest8th;
        public static readonly Bitmap Rest8thTriplet = Resources.rest8thTriplet;
        public static readonly Bitmap Rest16th = Resources.rest16th;
        public static readonly Bitmap Rest16thDotted = Resources.rest16thDotted;
        public static readonly Bitmap Rest16thTriplet = Resources.rest16thTriplet;
        public static readonly Bitmap Rest32ndDotted = Resources.rest32ndDotted;
        public static readonly Bitmap Rest32nd = Resources.rest32nd;
        public static readonly Bitmap Rest32ndTriplet = Resources.rest32ndTriplet;
        public static readonly Bitmap Rest64th = Resources.rest64th;
        public static readonly Bitmap Rest64thTriplet = Resources.rest64thTriplet;

        #endregion

        #region Music note parts

        public static readonly Bitmap NoteStemUp = Resources.noteStemUp;
        public static readonly Bitmap NoteStemUp8th = Resources.noteStemUp8th;
        public static readonly Bitmap NoteStemUp16th = Resources.noteStemUp16th;
        public static readonly Bitmap NoteStemUp32nd = Resources.noteStemUp32nd;
        public static readonly Bitmap NoteStemUp64th = Resources.noteStemUp64th;
        public static readonly Bitmap NoteStemDown = Resources.noteStemDown;
        public static readonly Bitmap NoteStemDown8th = Resources.noteStemDown8th;
        public static readonly Bitmap NoteStemDown16th = Resources.noteStemDown16th;
        public static readonly Bitmap NoteStemDown32nd = Resources.noteStemDown32nd;
        public static readonly Bitmap NoteStemDown64th = Resources.noteStemDown64th;
        public static readonly Bitmap NoteHead = Resources.noteHead;
        public static readonly Bitmap NoteHeadDotted = Resources.noteHeadDotted;
        public static readonly Bitmap NoteHeadTriplet = Resources.noteHeadTriplet;
        public static readonly Bitmap NoteHeadPercussion = Resources.noteHeadPercussion;
        public static readonly Bitmap NoteEmpty = Resources.noteEmpty;
        public static readonly Bitmap NoteEmptyDotted = Resources.noteEmptyDotted;
        public static readonly Bitmap NoteEmptyTriplet = Resources.noteEmptyTriplet;
        public static readonly Bitmap TieOver = Resources.tieOver;
        public static readonly Bitmap TieUnder = Resources.tieUnder;

        #endregion

        #region Misc music icons

        public static readonly Bitmap Sharp = Resources.sharp;
        public static readonly Bitmap Flat = Resources.flat;
        public static readonly Bitmap Natural = Resources.natural;
        public static readonly Bitmap OctaveUp = Resources.octaveUp;
        public static readonly Bitmap OctaveDown = Resources.octaveDown;
        public static readonly Bitmap OctaveSet = Resources.octaveSet;
        public static readonly Bitmap Terminate = Resources.terminate;
        public static readonly Bitmap Metronome = Resources.metronome;
        public static readonly Bitmap Loop = Resources.repeatStart;
        public static readonly Bitmap LoopEnd = Resources.repeatEnd;
        public static readonly Bitmap FirstSection = Resources.firstSection;
        public static readonly Bitmap LoopInf = Resources.repeatInf;
        public static readonly Bitmap Instrument = Resources.instrument;
        public static readonly Bitmap Volume = Resources.volume;
        public static readonly Bitmap Portamento = Resources.portamento;
        public static readonly Bitmap SpeakerBalance = Resources.speakerBalance;
        public static readonly Bitmap Tremolo = Resources.tremolo;
        public static readonly Bitmap ReverbOn = Resources.reverbOn;
        public static readonly Bitmap ReverbOff = Resources.reverbOff;
        public static readonly Bitmap DrumsOn = Resources.drumsOn;
        public static readonly Bitmap DrumsOff = Resources.drumsOff;
        public static readonly Bitmap Vibrato = Resources.vibrato;

        #endregion

        private static Bitmap transparentBG;
        /// <summary>
        /// Creates a 256x256 image with a tiled checkered white/grey
        /// background from the image file in the resources.
        /// </summary>
        public static Bitmap TransparentBG
        {
            get
            {
                if (transparentBG == null)
                {
                    transparentBG = new Bitmap(256, 256);
                    var g = Graphics.FromImage(transparentBG);
                    var _transparent = Resources._transparent;
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
