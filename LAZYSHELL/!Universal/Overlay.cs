using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using LAZYSHELL.Properties;
using LAZYSHELL.ScriptsEditor.Commands;

namespace LAZYSHELL
{
    public class Overlay
    {
        #region Variables
        private State state = State.Instance;
        // overlay objects
        public List<Bitmap> NPCImages;
        private Bitmap npcFieldBaseImage;
        private Bitmap npcFieldBaseImageH;
        private Bitmap exitFieldBaseImage;
        private Bitmap exitFieldBaseImageH;
        private Bitmap exitFieldBlockImage;
        private Bitmap exitFieldBlockImageH;
        private Bitmap eventFieldBaseImage;
        private Bitmap eventFieldBaseImageH;
        private Bitmap eventFieldBlockImage;
        private Bitmap eventFieldBlockImageH;
        private Bitmap fieldBaseShadowImage;
        private Bitmap fieldBaseShadowImageH;
        private Bitmap overlapFieldBaseImage;
        private Bitmap overlapFieldBaseImageH;
        public int alpha = 255;
        // selecting
        public Selection Select;
        public Selection SelectTS;
        public class Selection
        {
            /// <summary>
            /// The picture box control associated with the selection.
            /// </summary>
            private PictureBox pictureBox;
            public PictureBox PictureBox { get { return pictureBox; } set { pictureBox = value; } }
            public int X { get { return Math.Min(initial.X, final.X); } }
            public int Y { get { return Math.Min(initial.Y, final.Y); } }
            public int Height { get { return size.Height; } }
            public int Width { get { return size.Width; } }
            private int unit = 1; public int Unit { get { return unit; } set { unit = value; } }
            private Size size;
            public Size Size
            {
                get
                {
                    return new Size(
                        Math.Abs(initial.X - final.X),
                        Math.Abs(initial.Y - final.Y));
                }
                set
                {
                    size = new Size(value.Width / unit * unit, value.Height / unit * unit);
                    final = new Point(initial.X + size.Width, initial.Y + size.Height);
                }
            }
            /// <summary>
            /// The real location (upper-left corner), in pixels, of the selection.
            /// </summary>
            public Point Location
            {
                get
                {
                    return new Point(
                        Math.Min(initial.X, final.X),
                        Math.Min(initial.Y, final.Y));
                }
                set
                {
                    initial = value;
                    final = new Point(value.X + size.Width, value.Y + size.Height);
                }
            }
            /// <summary>
            /// The real ending (lower-right corner), in pixels, of the selection.
            /// </summary>
            public Point Terminal
            {
                get
                {
                    return new Point(
                        Math.Max(initial.X, final.X),
                        Math.Max(initial.Y, final.Y));
                }
                set
                {
                    final = value;
                    initial = new Point(value.X - size.Width, value.Y - size.Height);
                }
            }
            private Point initial;
            /// <summary>
            /// Where, in pixels, the selection was first started.
            /// </summary>
            public Point Initial
            {
                get { return initial; }
                set
                {
                    initial = new Point(value.X / unit * unit, value.Y / unit * unit);
                }
            }
            private Point final;
            /// <summary>
            /// Where, in pixels, the selection was finished.
            /// </summary>
            public Point Final
            {
                get { return final; }
                set
                {
                    final = new Point(value.X / unit * unit, value.Y / unit * unit);
                    size = new Size(
                        Math.Abs(initial.X - final.X),
                        Math.Abs(initial.Y - final.Y));
                }
            }
            /// <summary>
            /// Returns a rectangle containing the location and size of the selection.
            /// </summary>
            public Rectangle Region { get { return new Rectangle(Location, Size); } }
            public Selection(int unit, Point initial, Size size)
            {
                this.unit = unit;
                this.initial = new Point(initial.X / unit * unit, initial.Y / unit * unit);
                this.size = new Size(size.Width / unit * unit, size.Height / unit * unit);
                this.final = new Point(initial.X + size.Width, initial.Y + size.Height);
            }
            public Selection(int unit, Point initial, Point final)
            {
                this.unit = unit;
                this.initial = new Point(initial.X / unit * unit, initial.Y / unit * unit);
                this.final = new Point(final.X + size.Width, final.Y + size.Height);
                this.size = new Size(
                    Math.Abs(initial.X - final.X),
                    Math.Abs(initial.Y - final.Y));
            }
            public Selection(int unit, int x, int y, int width, int height)
            {
                this.unit = unit;
                this.initial = new Point(x / unit * unit, y / unit * unit);
                this.size = new Size(width / unit * unit, height / unit * unit);
                this.final = new Point(x + size.Width, y + size.Height);
            }
            /// <summary>
            /// Returns the mouse's relative position within the selection.
            /// </summary>
            /// <param name="x">The X coord of the mouse in the entire image.</param>
            /// <param name="y">The Y coord of the mouse in the entire image.</param>
            /// <returns></returns>
            public Point MousePosition(int x, int y)
            {
                Point mouse = new Point();
                mouse.X = (x / unit * unit) - Math.Min(initial.X, final.X);
                mouse.Y = (y / unit * unit) - Math.Min(initial.Y, final.Y);
                return mouse;
            }
            /// <summary>
            /// Checks if the mouse's coordinates inside the entire image are within the selection.
            /// </summary>
            /// <param name="x">The X coord of the mouse in the entire image.</param>
            /// <param name="y">The Y coord of the mouse in the entire image.</param>
            /// <returns></returns>
            public bool MouseWithin(int x, int y)
            {
                Point mouse = MousePosition((x / unit * unit), (y / unit * unit));
                if (mouse.X < 0 || mouse.X >= size.Width)
                    return false;
                if (mouse.Y < 0 || mouse.Y >= size.Height)
                    return false;
                return true;
            }
            /// <summary>
            /// Returns an image of the selection's region within a specified image.
            /// </summary>
            /// <param name="image">The image containing the selection.</param>
            /// <returns></returns>
            public Bitmap GetSelectionImage(Bitmap image)
            {
                return image.Clone(Region, System.Drawing.Imaging.PixelFormat.DontCare);
            }
        }
        #endregion
        #region Functions
        public Overlay()
        {
        }
        public void DrawCartesianGrid(Graphics g, Color c, Size s, Size u, int z)
        {
            c = Color.FromArgb(alpha, c);
            Pen p = new Pen(new SolidBrush(c)); p.DashPattern = new float[] { 1, 1 };
            Point h = new Point();
            Point v = new Point();
            for (h.Y = z * u.Height; h.Y < s.Height; h.Y += z * u.Height)
                g.DrawLine(p, h, new Point(h.X + s.Width, h.Y));
            for (v.X = z * u.Width; v.X < s.Width; v.X += z * u.Width)
                g.DrawLine(p, v, new Point(v.X, v.Y + s.Height));
        }
        public void DrawIsometricGrid(Graphics g, Color c, Size s, Size u, int z)
        {
            c = Color.FromArgb(alpha, c);
            Pen p = new Pen(new SolidBrush(c));
            Point n = new Point();
            for (n.Y = z * u.Height - (8 * z); n.Y < s.Height * 2; n.Y += z * u.Height)
                g.DrawLine(p, n, new Point(n.Y * 2, 0));
            n.X = s.Width;
            for (n.Y = z * u.Height - (8 * z); n.Y < s.Height * 2; n.Y += z * u.Height)
                g.DrawLine(p, n, new Point(s.Width - (n.Y * 2), 0));
        }
        public void DrawLevelMask(Graphics g, Point stop, Point start, int z)
        {
            int u = z * 16;
            Point p = new Point(start.X * u, start.Y * u);
            Size s = new Size((stop.X - start.X) * u + u, (stop.Y - start.Y) * u + u);
            Brush b = new SolidBrush(Color.FromArgb(75, Color.Orange));
            if (p.X == 0) p.X++; if (p.Y == 0) p.Y++;
            Rectangle r = new Rectangle(p, s);
            if (r.Right >= (1024 - 1) * z) r.Width = (1024 - 2) * z;
            if (r.Bottom >= (1024 - 1) * z) r.Height = (1024 - 2) * z;
            g.FillRectangle(b, r);
        }
        public void DrawBoundaries(Graphics g, Point location, int z)
        {
            Pen pen = new Pen(SystemColors.ControlDark); pen.Width = z; pen.Alignment = PenAlignment.Inset;
            location.X = location.X / 16 * 16;
            location.Y = location.Y / 16 * 16;
            g.FillRectangle(new SolidBrush(Color.FromArgb(50, 0, 0, 0)), location.X * z, location.Y * z, 256 * z, 224 * z);
            g.DrawRectangle(pen, location.X * z, location.Y * z, 256 * z, 224 * z);
        }
        public void DrawSelectionBox(Graphics g, Point stop, Point start, int z)
        {
            if (stop.X == start.X) return;
            if (stop.Y == start.Y) return;

            Point p = new Point(start.X * z, start.Y * z);
            Size s = new Size((stop.X * z) - (start.X * z) - 1, (stop.Y * z) - (start.Y * z) - 1);

            Pen penw = new Pen(Color.White);
            Pen penb = new Pen(Color.Black); penb.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            Rectangle ro = new Rectangle(p, s); p.X++; p.Y++; s.Width -= 2; s.Height -= 2;
            Rectangle ri = new Rectangle(p, s);

            g.DrawRectangle(penw, ro);
            g.DrawRectangle(penw, ri);
            g.DrawRectangle(penb, ro);
            g.DrawRectangle(penb, ri);
        }
        public void DrawSelectionBox(Graphics g, int x_initial, int y_initial, int x_terminal, int y_terminal, int z)
        {
            DrawSelectionBox(g, new Point(x_terminal, y_terminal), new Point(x_initial, y_initial), z);
        }
        // exits
        private void GenerateExitFields()
        {
            Bitmap exitFieldBase = global::LAZYSHELL.Properties.Resources.fieldBase;
            Bitmap exitFieldBlock = global::LAZYSHELL.Properties.Resources.fieldBlock;
            int[] exitFieldBasePixels = Do.ImageToPixels(exitFieldBase);
            int[] exitFieldBlockPixels = Do.ImageToPixels(exitFieldBlock);

            Do.Colorize(exitFieldBasePixels, 60.0, 1.0);
            Do.Colorize(exitFieldBlockPixels, 60.0, 1.0);
            Do.Gradient(exitFieldBasePixels, 32, 16, 128.0, -128.0, true);
            Do.Gradient(exitFieldBlockPixels, 32, 16, 128.0, 0, true);

            exitFieldBaseImage = Do.PixelsToImage(exitFieldBasePixels, 32, 16);
            exitFieldBlockImage = Do.PixelsToImage(exitFieldBlockPixels, 32, 32);
            exitFieldBaseImageH = Do.Hilite(exitFieldBaseImage, 32, 16);
            exitFieldBlockImageH = Do.Hilite(exitFieldBlockImage, 32, 32);
        }
        public void DrawLevelExits(LevelExits exits, Graphics g, int z)
        {
            int index = 0;
            int total = 0;
            List<Exit> sorted = new List<Exit>();
            foreach (Exit exit in exits.Exits)
            {
                exit.Hilite = exits.SelectedExit == index;
                exit.Index = total++;
                sorted.Add(exit);
                index++;
            }
            sorted.Sort(delegate(Exit exit1, Exit exit2) { return exit1.Y.CompareTo(exit2.Y); });
            foreach (Exit exit in sorted)
                DrawLevelExit(exit, g, z);
        }
        private void DrawLevelExit(Exit exit, Graphics g, int z)
        {
            if (exitFieldBaseImage == null)
                GenerateExitFields();
            if (fieldBaseShadowImage == null)
                GenerateNPCFields();
            int x = ((exit.X & 127) * 32) + (16 * (exit.Y & 1)) - 16;
            int y = ((exit.Y & 127) * 8) - 8;
            Rectangle rsrc, rdst;
            // Draw the complete # of blocks
            if (exit.Width > 0)
            {
                if (exit.Face == 0)
                {
                    y -= exit.Width * 8;
                    x += exit.Width * 16;
                }
                // draw shadow
                for (int w = 0; w <= exit.Width; w++)
                {
                    if (exit.Z > 0)
                    {
                        if (exit.Face == 0)
                            rsrc = new Rectangle(-(w * 16) + x, w * 8 + y, 32, 16);
                        else
                            rsrc = new Rectangle(w * 16 + x, w * 8 + y, 32, 16);
                        rdst = new Rectangle(rsrc.X * z, rsrc.Y * z, rsrc.Width * z, rsrc.Height * z);
                        g.DrawImage(exit.Hilite ? fieldBaseShadowImageH : fieldBaseShadowImage, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
                    }
                }
                // draw field base
                for (int w = 0; w <= exit.Width; w++)
                {
                    if (w == 0)
                        y -= exit.Z * 16;
                    if (exit.Height == 0)
                    {
                        rsrc = new Rectangle(x, y, 32, 16);
                        rdst = new Rectangle(rsrc.X * z, rsrc.Y * z, rsrc.Width * z, rsrc.Height * z);
                        g.DrawImage(exit.Hilite ? exitFieldBaseImageH : exitFieldBaseImage, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
                    }
                    else if (exit.Height > 0)
                    {
                        y -= 16;
                        for (int h = 0; h < exit.Height; h++)
                        {
                            rsrc = new Rectangle(x, y - (h * 16), 32, 32);
                            rdst = new Rectangle(rsrc.X * z, rsrc.Y * z, rsrc.Width * z, rsrc.Height * z);
                            g.DrawImage(exit.Hilite ? exitFieldBlockImageH : exitFieldBlockImage, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
                        }
                        y += 16;
                    }
                    x += exit.Face == 0 ? -16 : 16;
                    y += 8;
                }
            }
            else
            {
                if (exit.Z > 0)
                {
                    rsrc = new Rectangle(x, y, 32, 16);
                    rdst = new Rectangle(rsrc.X * z, rsrc.Y * z, rsrc.Width * z, rsrc.Height * z);
                    g.DrawImage(exit.Hilite ? fieldBaseShadowImageH : fieldBaseShadowImage, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
                }
                y -= exit.Z * 16;
                if (exit.Height == 0)
                {
                    rsrc = new Rectangle(x, y, 32, 16);
                    rdst = new Rectangle(rsrc.X * z, rsrc.Y * z, rsrc.Width * z, rsrc.Height * z);
                    g.DrawImage(exit.Hilite ? exitFieldBaseImageH : exitFieldBaseImage, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
                }
                else if (exit.Height > 0)
                {
                    y -= 16;
                    for (int h = 0; h < exit.Height; h++)
                    {
                        rsrc = new Rectangle(x, y - (h * 16), 32, 32);
                        rdst = new Rectangle(rsrc.X * z, rsrc.Y * z, rsrc.Width * z, rsrc.Height * z);
                        g.DrawImage(exit.Hilite ? exitFieldBlockImageH : exitFieldBlockImage, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
                    }
                }
            }
        }
        public void DrawLevelExitTags(LevelExits exits, Graphics g, int z)
        {
            if (exits.Count == 0) return;
            // draw exit strings
            Rectangle r = new Rectangle();
            Pen pen = new Pen(Color.Yellow, 2);
            SolidBrush brush = new SolidBrush(Color.FromArgb(128, Color.Yellow));
            SolidBrush brush_ = new SolidBrush(Color.FromArgb(192, Color.Yellow));
            Font font = new Font("Tahoma", 8.25F);
            Font font_ = new Font("Tahoma", 8.25F, FontStyle.Bold);
            foreach (Exit exit in exits.Exits)
            {
                r.X = ((exit.X & 127) * 32) + (16 * (exit.Y & 1)) - 16; r.X *= z;
                r.Y = ((exit.Y & 127) * 8) - 8; r.Y *= z;
                string name;
                if (exit.ExitType == 0)
                    name = "{" + exit.Destination.ToString("d3") + "} " + Lists.LevelNames[exit.Destination];
                else
                    name = "{" + exit.Destination.ToString("d3") + "} MAP POINT: " + Lists.MapNames[exit.Destination];
                RectangleF label = new RectangleF(new PointF(r.X, r.Y + 24),
                    g.MeasureString(name, font_, new PointF(0, 0), StringFormat.GenericDefault));
                if (exit == exits.Exit_)
                {
                    g.FillRectangle(brush, r);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(192, Color.Black)), label);
                    g.DrawString(name, font_, brush_, r.X, r.Y + 24);
                }
                else
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(128, Color.Black)), label);
                    g.DrawString(name, font, brush, r.X, r.Y + 24);
                }
                g.DrawRectangle(pen, r);
            }
        }
        // events
        private void GenerateEventFields()
        {
            Bitmap eventFieldBase = global::LAZYSHELL.Properties.Resources.fieldBase;
            Bitmap eventFieldBlock = global::LAZYSHELL.Properties.Resources.fieldBlock;
            int[] eventFieldBasePixels = Do.ImageToPixels(eventFieldBase);
            int[] eventFieldBlockPixels = Do.ImageToPixels(eventFieldBlock);

            Do.Colorize(eventFieldBasePixels, 120.0, 1.0);
            Do.Colorize(eventFieldBlockPixels, 120.0, 1.0);
            Do.Gradient(eventFieldBasePixels, 32, 16, 128.0, -128.0, true);
            Do.Gradient(eventFieldBlockPixels, 32, 16, 128.0, 0, true);

            eventFieldBaseImage = Do.PixelsToImage(eventFieldBasePixels, 32, 16);
            eventFieldBlockImage = Do.PixelsToImage(eventFieldBlockPixels, 32, 32);
            eventFieldBaseImageH = Do.Hilite(eventFieldBaseImage, 32, 16);
            eventFieldBlockImageH = Do.Hilite(eventFieldBlockImage, 32, 32);
        }
        public void DrawLevelEvents(LevelEvents events, Graphics g, int z)
        {
            int index = 0;
            int total = 0;
            List<Event> sorted = new List<Event>();
            foreach (Event event_ in events.Events)
            {
                event_.Hilite = events.SelectedEvent == index;
                event_.Index = total++;
                sorted.Add(event_);
                index++;
            }
            sorted.Sort(delegate(Event event1, Event event2) { return event1.Y.CompareTo(event2.Y); });
            foreach (Event event_ in sorted)
                DrawLevelEvent(event_, g, z);
        }
        private void DrawLevelEvent(Event event_, Graphics g, int z)
        {
            if (eventFieldBaseImage == null)
                GenerateEventFields();
            if (fieldBaseShadowImage == null)
                GenerateNPCFields();
            int x = ((event_.X & 127) * 32) + (16 * (event_.Y & 1)) - 16;
            int y = ((event_.Y & 127) * 8) - 8;
            Rectangle rsrc, rdst;
            // Draw the complete # of blocks
            if (event_.Width > 0)
            {
                if (event_.Face == 0)
                {
                    y -= event_.Width * 8;
                    x += event_.Width * 16;
                }
                // draw shadow
                for (int w = 0; w <= event_.Width; w++)
                {
                    if (event_.Z > 0)
                    {
                        if (event_.Face == 0)
                            rsrc = new Rectangle(-(w * 16) + x, w * 8 + y, 32, 16);
                        else
                            rsrc = new Rectangle(w * 16 + x, w * 8 + y, 32, 16);
                        rdst = new Rectangle(rsrc.X * z, rsrc.Y * z, rsrc.Width * z, rsrc.Height * z);
                        g.DrawImage(event_.Hilite ? fieldBaseShadowImageH : fieldBaseShadowImage, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
                    }
                }
                // draw field base
                for (int w = 0; w <= event_.Width; w++)
                {
                    if (w == 0)
                        y -= event_.Z * 16;
                    if (event_.Height == 0)
                    {
                        rsrc = new Rectangle(x, y, 32, 16);
                        rdst = new Rectangle(rsrc.X * z, rsrc.Y * z, rsrc.Width * z, rsrc.Height * z);
                        g.DrawImage(event_.Hilite ? eventFieldBaseImageH : eventFieldBaseImage, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
                    }
                    else if (event_.Height > 0)
                    {
                        y -= 16;
                        for (int h = 0; h < event_.Height; h++)
                        {
                            rsrc = new Rectangle(x, y - (h * 16), 32, 32);
                            rdst = new Rectangle(rsrc.X * z, rsrc.Y * z, rsrc.Width * z, rsrc.Height * z);
                            g.DrawImage(event_.Hilite ? eventFieldBlockImageH : eventFieldBlockImage, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
                        }
                        y += 16;
                    }
                    x += event_.Face == 0 ? -16 : 16;
                    y += 8;
                }
            }
            else
            {
                if (event_.Z > 0)
                {
                    rsrc = new Rectangle(x, y, 32, 16);
                    rdst = new Rectangle(rsrc.X * z, rsrc.Y * z, rsrc.Width * z, rsrc.Height * z);
                    g.DrawImage(event_.Hilite ? fieldBaseShadowImageH : fieldBaseShadowImage, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
                }
                y -= event_.Z * 16;
                if (event_.Height == 0)
                {
                    rsrc = new Rectangle(x, y, 32, 16);
                    rdst = new Rectangle(rsrc.X * z, rsrc.Y * z, rsrc.Width * z, rsrc.Height * z);
                    g.DrawImage(event_.Hilite ? eventFieldBaseImageH : eventFieldBaseImage, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
                }
                else if (event_.Height > 0)
                {
                    y -= 16;
                    for (int h = 0; h < event_.Height; h++)
                    {
                        rsrc = new Rectangle(x, y - (h * 16), 32, 32);
                        rdst = new Rectangle(rsrc.X * z, rsrc.Y * z, rsrc.Width * z, rsrc.Height * z);
                        g.DrawImage(event_.Hilite ? eventFieldBlockImageH : eventFieldBlockImage, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
                    }
                }
            }
        }
        public void DrawLevelEventTags(LevelEvents events, Graphics g, int z)
        {
            if (events.Count == 0) return;
            // draw event strings
            foreach (Event event_ in events.Events)
            {
                if (event_ != events.Event_)
                    DrawLevelEventTag(g, events, event_, z);
            }
            if (events.Event_ != null)
                DrawLevelEventTag(g, events, events.Event_, z);
        }
        private void DrawLevelEventTag(Graphics g, LevelEvents events, Event temp, int z)
        {
            Rectangle r = new Rectangle();
            Pen pen = new Pen(Color.Yellow, 2);
            SolidBrush brush = new SolidBrush(Color.FromArgb(128, 0, 255, 0));
            SolidBrush brush_ = new SolidBrush(Color.FromArgb(192, 0, 255, 0));
            Font font = new Font("Tahoma", 8.25F);
            Font font_ = new Font("Tahoma", 8.25F, FontStyle.Bold | FontStyle.Underline);
            Font font_b = new Font("Tahoma", 8.25F, FontStyle.Bold);
            Font lucida = new Font("Lucida Console", 8.25F);

            r.X = ((temp.X & 127) * 32) + (16 * (temp.Y & 1)) - 16; r.X *= z;
            r.Y = ((temp.Y & 127) * 8) - 8; r.Y *= z;

            string name = "Event #" + temp.RunEvent.ToString();
            RectangleF label = new RectangleF(new PointF(r.X, r.Y + 24),
                g.MeasureString(name, font_, new PointF(0, 0), StringFormat.GenericDefault));

            if (temp != events.Event_)
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(128, Color.Black)), label);
                g.DrawString(name, font, brush, r.X, r.Y + 24);
            }
            else
            {
                g.FillRectangle(brush, r);
                g.FillRectangle(new SolidBrush(Color.FromArgb(192, Color.Black)), label);
                g.DrawString(name, font_, brush_, r.X, r.Y + 24);
                // draw commands
                string script = Do.EventScriptToText(Model.EventScripts[events.Event_.RunEvent], 8, 40);
                RectangleF commandbox = new RectangleF(r.X + 2, r.Y + 40, 256, (label.Height - 2) * script.Split('\n').Length);
                g.FillRectangle(brush_, commandbox);
                g.DrawString(script, font_b, new SolidBrush(Color.Black), r.X + 6, r.Y + 44);
            }
            g.DrawRectangle(pen, r);
        }
        // npcs
        private void GenerateNPCFields()
        {
            Bitmap npcFieldBase = global::LAZYSHELL.Properties.Resources.fieldBase;
            int[] npcFieldBasePixels = Do.ImageToPixels(npcFieldBase);
            Do.Colorize(npcFieldBasePixels, 0.0, 1.0);
            Do.Gradient(npcFieldBasePixels, 32, 16, 128.0, -128.0, true);
            int[] fieldBaseShadow = new int[32 * 16];
            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    if (npcFieldBasePixels[y * 32 + x] != 0)
                        fieldBaseShadow[y * 32 + x] = Color.FromArgb(64 - (y * 4), 64 - (y * 4), 64 - (y * 4)).ToArgb();
                }
            }
            npcFieldBaseImage = Do.PixelsToImage(npcFieldBasePixels, 32, 16);
            npcFieldBaseImageH = Do.Hilite(npcFieldBaseImage, 32, 16);
            fieldBaseShadowImage = Do.PixelsToImage(fieldBaseShadow, 32, 16);
            fieldBaseShadowImageH = Do.Hilite(fieldBaseShadowImage, 32, 16);
        }
        public void DrawLevelNPCs(LevelNPCs npcs, NPCProperties[] npcProperties)
        {
            NPCImages = new List<Bitmap>();
            foreach (NPC npc in npcs.Npcs)
            {
                DrawLevelNPC(npc, npcProperties, npc.NPCID, npc.EngageType);
                foreach (NPC instance in npc.Instances)
                    DrawLevelNPC(instance, npcProperties, npc.NPCID, npc.EngageType);
            }
        }
        private void DrawLevelNPC(NPC npc, NPCProperties[] npcProperties, int npcid, int engagetype)
        {
            int NPCID = engagetype == 0 ? Math.Min(511, npcid + npc.PropertyA) : Math.Min(511, (int)npcid);
            int[] pixels = npcProperties[NPCID].CreateImage(npc.Face, false, 0);
            int height = npcProperties[NPCID].ImageHeight;
            int width = npcProperties[NPCID].ImageWidth;
            Bitmap image = Do.PixelsToImage(pixels, width, height);
            NPCImages.Add(image);
        }
        public void DrawLevelNPCs(LevelNPCs npcs, Graphics g, int z)
        {
            int index = 0;
            int total = 0;
            List<NPC> sorted = new List<NPC>();
            foreach (NPC npc in npcs.Npcs)
            {
                npc.Hilite = !npcs.IsInstanceSelected && npcs.SelectedNPC == index;
                npc.Index = total++;
                sorted.Add(npc);
                int index_ = 0;
                foreach (NPC instance in npc.Instances)
                {
                    instance.Hilite = npcs.SelectedNPC == index && npcs.IsInstanceSelected && npcs.SelectedInstance == index_;
                    instance.Index = total++;
                    sorted.Add(instance);
                    index_++;
                }
                index++;
            }
            sorted.Sort(delegate(NPC npc1, NPC npc2) { return npc1.Y.CompareTo(npc2.Y); });
            foreach (NPC npc in sorted)
                DrawLevelNPC(npc, g, z);
        }
        private void DrawLevelNPC(NPC npc, Graphics g, int z)
        {
            if (npcFieldBaseImage == null)
                GenerateNPCFields();
            int x = ((npc.X & 127) * 32) + (16 * (npc.Y & 1)) - 16;
            int y = ((npc.Y & 127) * 8) - 8;
            Rectangle rdst, rsrc;
            rsrc = new Rectangle(x, y, 32, 16);
            rdst = new Rectangle(x * z, y * z, 32 * z, 16 * z);
            if (!npc.Hilite)
                g.DrawImage(fieldBaseShadowImage, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
            else
                g.DrawImage(fieldBaseShadowImageH, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
            y -= npc.Z * 16;
            y -= npc.CoordYBit7 ? 8 : 0;
            rsrc = new Rectangle(x, y, 32, 16);
            rdst = new Rectangle(x * z, y * z, 32 * z, 16 * z);
            if (!npc.Hilite)
                g.DrawImage(npcFieldBaseImage, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
            else
                g.DrawImage(npcFieldBaseImageH, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
            x += 32 - NPCImages[npc.Index].Width / 2 - 16;
            y -= NPCImages[npc.Index].Height - 4 - 8;
            rsrc = new Rectangle(x, y, NPCImages[npc.Index].Width, NPCImages[npc.Index].Height);
            rdst = new Rectangle(x * z, y * z, rsrc.Width * z, rsrc.Height * z);
            if (npc.CoordXBit7)
                g.DrawImage(NPCImages[npc.Index], rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
        }
        public void DrawLevelNPCTags(LevelNPCs npcs, Graphics g, int z)
        {
            if (npcs.Count == 0) return;
            // draw npc strings
            int index = 0;
            int current = 0;
            foreach (NPC npc in npcs.Npcs)
            {
                if (npc != npcs.Npc || npcs.IsInstanceSelected)
                    DrawLevelNPCTag(npcs, g, npc, index++, null, z);
                else
                    current = index++;
                foreach (NPC instance in npc.Instances)
                {
                    if (npc != npcs.Npc || instance != npcs.Npc.Instance_ || !npcs.IsInstanceSelected)
                        DrawLevelNPCTag(npcs, g, instance, index++, null, z);
                    else
                        current = index++;
                }
            }
            if (npcs.Npc != null)
            {
                if (!npcs.IsInstanceSelected)
                    DrawLevelNPCTag(npcs, g, npcs.Npc, current, null, z);
                else
                    DrawLevelNPCTag(npcs, g, npcs.Npc.Instance_, current, npcs.Npc, z);
            }
        }
        private void DrawLevelNPCTag(LevelNPCs npcs, Graphics g, NPC npc, int index, NPC parent, int z)
        {
            Rectangle r = new Rectangle();
            Pen pen = new Pen(Color.Yellow, 2);
            SolidBrush brush = new SolidBrush(Color.FromArgb(128, 255, 0, 0));
            SolidBrush brush_ = new SolidBrush(Color.FromArgb(192, 255, 0, 0));
            Font font = new Font("Tahoma", 8.25F);
            Font font_ = new Font("Tahoma", 8.25F, FontStyle.Bold | FontStyle.Underline);
            Font font_b = new Font("Tahoma", 8.25F, FontStyle.Bold);
            Font lucida = new Font("Lucida Console", 8.25F);

            r.X = ((npc.X & 127) * 32) + (16 * (npc.Y & 1)) - 16; r.X *= z;
            r.Y = ((npc.Y & 127) * 8) - 8; r.Y *= z;

            string name = "NPC #" + index;
            RectangleF label = new RectangleF(new PointF(r.X, r.Y + 24),
                g.MeasureString(name, font_, new PointF(0, 0), StringFormat.GenericDefault));

            if (!npc.Hilite)
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(128, Color.Black)), label);
                g.DrawString(name, font, brush, r.X, r.Y + 24);
            }
            else
            {
                g.FillRectangle(brush, r);
                g.FillRectangle(new SolidBrush(Color.FromArgb(192, Color.Black)), label);
                g.DrawString(name, font_, brush_, r.X, r.Y + 24);
                // draw commands
                RectangleF commandbox;
                string text = "";
                int property, engagetype;
                if (parent == null)
                {
                    property = Math.Min(npc.EngageType > 1 ? 255 : 4095, npc.EventORpack + npc.PropertyB);
                    engagetype = npc.EngageType;
                }
                else
                {
                    property = Math.Min(parent.EngageType > 1 ? 255 : 4095, parent.EventORpack + npc.PropertyB);
                    engagetype = parent.EngageType;
                }
                if (engagetype == 0)   // default
                {
                    text = "{EVENT #" + property.ToString() + "}\n";
                    text += Do.EventScriptToText(Model.EventScripts[property], 8, 80);
                    commandbox = new RectangleF(r.X + 2, r.Y + 40, 512, (label.Height - 2) * text.Split('\n').Length);
                }
                else if (engagetype == 1)  // treasure
                {
                    text = "{EVENT #" + property.ToString() + "}\n";
                    text += Do.EventScriptToText(Model.EventScripts[property], 8, 80);
                    commandbox = new RectangleF(r.X + 2, r.Y + 40, 512, (label.Height - 2) * text.Split('\n').Length);
                }
                else   // battle
                {
                    text = "{PACK #" + property.ToString() + "}\n";
                    text += Model.Formations[Model.FormationPacks[property].PackFormations[0]].ToString() + "\n";
                    text += Model.Formations[Model.FormationPacks[property].PackFormations[1]].ToString() + "\n";
                    text += Model.Formations[Model.FormationPacks[property].PackFormations[2]].ToString() + "\n";
                    commandbox = new RectangleF(r.X + 2, r.Y + 40, 512, (label.Height - 2) * 5);
                }
                g.FillRectangle(brush_, commandbox);
                g.DrawString(text, font_b, new SolidBrush(Color.Black), r.X + 6, r.Y + 44);
            }
            g.DrawRectangle(pen, r);
        }
        // overlaps
        private void GenerateOverlapFields()
        {
            Bitmap overlapFieldBase = global::LAZYSHELL.Properties.Resources.fieldBase;
            int[] overlapFieldBasePixels = Do.ImageToPixels(overlapFieldBase);
            Do.Colorize(overlapFieldBasePixels, 240.0, 1.0);
            Do.Gradient(overlapFieldBasePixels, 32, 16, 128.0, -128.0, true);
            overlapFieldBaseImage = Do.PixelsToImage(overlapFieldBasePixels, 32, 16);
            overlapFieldBaseImageH = Do.Hilite(overlapFieldBaseImage, 32, 16);
        }
        public void DrawLevelOverlaps(LevelOverlaps overlaps, OverlapTileset overlapTileset, Graphics g, int z)
        {
            if (overlapFieldBaseImage == null)
                GenerateOverlapFields();
            if (fieldBaseShadowImage == null)
                GenerateNPCFields();
            int index = 0;
            Rectangle rsrc, rdst;
            foreach (Overlap overlap in overlaps.Overlaps)
            {
                int x = ((overlap.X & 127) * 32) + (16 * (overlap.Y & 1)) - 16;
                int y = ((overlap.Y & 127) * 8) - 8;
                overlap.Hilite = overlaps.SelectedOverlap == index;
                overlap.Index = index++;
                rsrc = new Rectangle(x, y, 32, 16);
                rdst = new Rectangle(x * z, y * z, 32 * z, 16 * z);
                if (!overlap.Hilite)
                    g.DrawImage(fieldBaseShadowImage, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
                else
                    g.DrawImage(fieldBaseShadowImageH, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
                int[] pixels = Bits.Copy(overlapTileset.OverlapTiles[overlap.Type].Pixels);
                Do.Gradient(pixels, 32, 32, 0, 64, false);
                Do.Opacity(pixels, 32, 32, 224);
                Bitmap tile = Do.PixelsToImage(pixels, 32, 32);
                if (overlap.Hilite)
                    tile = Do.Hilite(tile, 32, 32);
                y = ((overlap.Y & 127) * 8) - 8 - (overlap.Z * 16) - (overlap.B1b7 ? 8 : 0);
                rsrc = new Rectangle(x, y, 32, 16);
                rdst = new Rectangle(x * z, y * z, 32 * z, 16 * z);
                if (!overlap.Hilite)
                    g.DrawImage(overlapFieldBaseImage, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
                else
                    g.DrawImage(overlapFieldBaseImageH, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
                rsrc.Height = 32; rsrc.Y -= 16;
                rdst.Height = 32 * z; rdst.Y -= 16 * z;
                g.DrawImage(tile, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
            }
        }
        // mods
        public void DrawLevelTileMods(LevelTileMods tileMods, Graphics g, ImageAttributes ia, int z)
        {
            if (tileMods.Count == 0) return;
            Rectangle rsrc;
            Rectangle rdst;
            Pen pen;
            foreach (LevelTileMods.Mod mod in tileMods.Mods)
            {
                if (tileMods.Mod_ == mod && !tileMods.SelectedB)
                    continue;
                rsrc = new Rectangle(mod.X * 16, mod.Y * 16, mod.Width * 16, mod.Height * 16);
                rdst = new Rectangle(mod.X * 16 * z, mod.Y * 16 * z, mod.Width * 16 * z, mod.Height * 16 * z);
                g.DrawImage(mod.ImageA, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel, ia);
                pen = new Pen(Color.Red);
                pen.DashStyle = DashStyle.Dot;
                pen.Alignment = PenAlignment.Outset;
                pen.Width = 2 * z;
                rdst.X -= 1 * z;
                rdst.Y -= 1 * z;
                rdst.Width += 2 * z;
                rdst.Height += 2 * z;
                g.DrawRectangle(pen, rdst);
            }
            if (tileMods.Mods.Count == 0) return;
            LevelTileMods.Mod current = tileMods.Mod_;
            rsrc = new Rectangle(current.X * 16, current.Y * 16, current.Width * 16, current.Height * 16);
            rdst = new Rectangle(current.X * 16 * z, current.Y * 16 * z, current.Width * 16 * z, current.Height * 16 * z);
            if (!tileMods.SelectedB)
                g.DrawImage(current.ImageA, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel, ia);
            else
                g.DrawImage(current.ImageB, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel, ia);
            pen = new Pen(Color.Red);
            pen.DashStyle = DashStyle.Dot;
            pen.Alignment = PenAlignment.Outset;
            pen.Width = 4 * z;
            rdst.X -= 2 * z;
            rdst.Y -= 2 * z;
            rdst.Width += 4 * z;
            rdst.Height += 4 * z;
            g.DrawRectangle(pen, rdst);
        }
        public void DrawLevelSolidMods(LevelSolidMods solidMods, SolidityTile[] tiles, Graphics g, Rectangle rdst, ImageAttributes ia, int z)
        {
            Solidity solidity = Solidity.Instance;
            foreach (LevelSolidMods.Mod mod in solidMods.Mods)
            {
                if (mod == solidMods.Mod_)
                    continue;
                g.DrawImage(mod.Image, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel, ia);
            }
            if (solidMods.Mods.Count == 0) return;
            g.DrawImage(solidMods.Mod_.Image, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel, ia);
        }
        public void DrawLevelSolidMods(LevelSolidMods solidMods, Graphics g, int z)
        {
            if (solidMods.Count == 0) return;
            foreach (LevelSolidMods.Mod mod in solidMods.Mods)
            {
                int x = ((mod.X & 127) * 32) + (16 * (mod.Y & 1)) - 16;
                int y = ((mod.Y & 127) * 8) - 8;
                Point top = new Point(x + 16, y);
                Point right = new Point(top.X + (mod.Width * 16), y + (mod.Width * 8));
                Point bottom = new Point(right.X - (mod.Height * 16), right.Y + (mod.Height * 8));
                Point left = new Point(bottom.X - (mod.Width * 16), bottom.Y - (mod.Width * 8));
                top.Y -= mod != solidMods.Mod_ ? 2 : 4; top.X *= z; top.Y *= z;
                right.X += mod != solidMods.Mod_ ? 4 : 6; right.X *= z; right.Y *= z;
                bottom.Y += mod != solidMods.Mod_ ? 2 : 4; bottom.X *= z; bottom.Y *= z;
                left.X -= mod != solidMods.Mod_ ? 4 : 6; left.X *= z; left.Y *= z;
                Pen pen = new Pen(Color.Red);
                pen.Width = mod != solidMods.Mod_ ? 2 * z : 4 * z; pen.DashStyle = DashStyle.Dot;
                g.DrawPolygon(pen, new Point[] { top, right, bottom, left, top });
            }
        }
        #endregion
    }
}
