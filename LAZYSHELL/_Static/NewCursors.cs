using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms; // remove later
using System.IO;
using LazyShell.Properties;

namespace LazyShell
{
    /// <summary>
    /// Class for accessing application's custom cursors.
    /// </summary>
    public sealed class NewCursors
    {
        // Cursors
        public static readonly Cursor Draw = new Cursor(new MemoryStream(global::LazyShell.Properties.Resources.CursorDraw));
        public static readonly Cursor Dropper = new Cursor(new MemoryStream(global::LazyShell.Properties.Resources.CursorDropper));
        public static readonly Cursor Erase = new Cursor(new MemoryStream(global::LazyShell.Properties.Resources.CursorErase));
        public static readonly Cursor Fill = new Cursor(new MemoryStream(global::LazyShell.Properties.Resources.CursorFill));
        public static readonly Cursor Chunk = new Cursor(new MemoryStream(global::LazyShell.Properties.Resources.CursorTemplate));
        public static readonly Cursor ZoomIn = new Cursor(new MemoryStream(global::LazyShell.Properties.Resources.CursorZoomIn));
        public static readonly Cursor ZoomOut = new Cursor(new MemoryStream(global::LazyShell.Properties.Resources.CursorZoomOut));
    }
}
