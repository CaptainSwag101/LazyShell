using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        private int[] exitFieldBasePixels;
        private int[] exitFieldBlockPixels;
        private int[] eventFieldBasePixels;
        private int[] eventFieldBlockPixels;
        private int[] npcFieldBasePixels;
        private int[] overlapFieldBasePixels;
        private int[] fieldBaseShadow;
        private Bitmap npcsImage, exitsImage, eventsImage, overlapsImage;
        //private IList<Bitmap> solidModsImages;
        //private IList<Bitmap> tileModsImages;
        public Bitmap NPCsImage { get { return npcsImage; } set { npcsImage = value; } }
        public Bitmap ExitsImage { get { return exitsImage; } set { exitsImage = value; } }
        public Bitmap EventsImage { get { return eventsImage; } set { eventsImage = value; } }
        public Bitmap OverlapsImage { get { return overlapsImage; } set { overlapsImage = value; } }
        public int alpha = 255;
        private bool highlight;
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
        public void DrawCartographicGrid(Graphics g, Color c, Size s, Size u, int z)
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
            Point p = new Point(start.X * 16 * z, start.Y * 16 * z);
            Size s = new Size((stop.X - start.X) * 16 + 16 * z, (stop.Y - start.Y) * 16 + 16 * z);
            Brush b = new SolidBrush(Color.FromArgb(75, Color.Orange));
            if (p.X == 0) p.X++; if (p.Y == 0) p.Y++;
            Rectangle r = new Rectangle(p, s);
            if (r.Right >= 1024 - 1 * z) r.Width = 1024 - 2 * z;
            if (r.Bottom >= 1024 - 1 * z) r.Height = 1024 - 2 * z;
            g.FillRectangle(b, r);
        }
        public void DrawBoundaries(Graphics g, Point location, int z)
        {
            location.X = location.X / 16 * 16;
            location.Y = location.Y / 16 * 16;
            g.FillRectangle(new SolidBrush(Color.FromArgb(50, 0, 0, 0)), location.X, location.Y, 256, 224);
            g.DrawRectangle(new Pen(SystemColors.ControlDark), location.X - 1, location.Y - 1, 258, 226);
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
        private void CopySuboverlayToOverlay(int[] dst, int dstWidth, int[] src, int srcWidth, int srcHeight, int x_, int y_)
        {
            for (int y = 0; y < srcHeight; y++)
            {
                for (int x = 0; x < srcWidth; x++)
                {
                    if (src[y * srcWidth + x] == 0) continue;
                    Color color = Color.FromArgb(src[y * srcWidth + x]);
                    int l = (int)(color.GetBrightness() * 255);
                    int r = Math.Min(255, 255 + l);
                    int g = Math.Min(255, l);
                    int b = Math.Min(255, 255 + l);
                    if (y_ + y >= 0 && x_ + x >= 0)
                    {
                        if (highlight)
                            dst[((y_ + y) * dstWidth) + (x_ + x)] = Color.FromArgb(r, g, b).ToArgb();
                        else
                            dst[((y_ + y) * dstWidth) + (x_ + x)] = src[y * srcWidth + x];
                    }
                }
            }
        }
        // exits
        public void DrawLevelExits(LevelExits exits)
        {
            int[] pixels = new int[1024 * 1024];
            int currentExit = exits.CurrentExit;
            highlight = false;

            int x, y;

            if (exitFieldBasePixels == null || exitFieldBlockPixels == null)
                GenerateExitPixels();
            if (fieldBaseShadow == null)
                GenerateNPCPixels();

            int[] order = new int[exits.Count];
            int[] coordY = new int[exits.Count];
            for (int i = 0; i < exits.Count; i++)
            {
                exits.CurrentExit = i;
                coordY[i] = exits.Y;
            }

            for (int i = 0; i < exits.Count; i++)
                order[i] = i;
            int[] temp = new int[coordY.Length]; coordY.CopyTo(temp, 0);
            Array.Sort(temp, order);

            for (int g = 0; g < exits.Count; g++)
            {
                int i = order[g];

                exits.CurrentExit = i;

                highlight = i == exits.SelectedExit;

                x = ((exits.X & 127) * 32) + (16 * (exits.Y & 1)) - 16;
                y = ((exits.Y & 127) * 8) - 8;

                // Draw the complete # of blocks
                if (exits.Width > 0)
                {
                    if (exits.Face == 0)
                    {
                        y -= exits.Width * 8;
                        x += exits.Width * 16;
                    }
                    for (int w = 0; w <= exits.Width; w++)
                    {
                        // draw shadow
                        if (exits.Z > 0)
                        {
                            if (exits.Face == 0)
                                CopySuboverlayToOverlay(pixels, 1024, fieldBaseShadow, 32, 16, -(w * 16) + x, w * 8 + y);
                            else
                                CopySuboverlayToOverlay(pixels, 1024, fieldBaseShadow, 32, 16, w * 16 + x, w * 8 + y);
                        }
                    }
                    for (int w = 0; w <= exits.Width; w++)
                    {
                        if (w == 0) y -= exits.Z * 16;

                        // draw the whole field
                        if (exits.Height == 0)
                            CopySuboverlayToOverlay(pixels, 1024, exitFieldBasePixels, 32, 16, x, y);
                        else if (exits.Height > 0)
                        {
                            y -= 16;
                            for (int h = 0; h < exits.Height; h++)
                                CopySuboverlayToOverlay(pixels, 1024, exitFieldBlockPixels, 32, 32, x, y - (h * 16));
                            y += 16;
                        }
                        x += exits.Face == 0 ? -16 : 16;
                        y += 8;
                    }
                }
                else
                {
                    // draw shadow
                    if (exits.Z > 0)
                        CopySuboverlayToOverlay(pixels, 1024, fieldBaseShadow, 32, 16, x, y);

                    y -= exits.Z * 16;

                    if (exits.Height == 0)
                        CopySuboverlayToOverlay(pixels, 1024, exitFieldBasePixels, 32, 16, x, y);
                    else if (exits.Height > 0)
                    {
                        y -= 16;
                        for (int h = 0; h < exits.Height; h++)
                            CopySuboverlayToOverlay(pixels, 1024, exitFieldBlockPixels, 32, 32, x, y - (h * 16));
                    }
                }
                // End Drawing
            }
            exitsImage = new Bitmap(Do.PixelsToImage(pixels, 1024, 1024));
            pixels = null;

            if (exits.Count > 0)
                exits.CurrentExit = currentExit;
        }
        public void DrawLevelExits(LevelExits exits, Graphics g)
        {
            // draw exit strings
            Rectangle r = new Rectangle();
            Pen pen = new Pen(Color.Yellow, 2);
            SolidBrush brush = new SolidBrush(Color.FromArgb(128, Color.Yellow));
            SolidBrush brush_ = new SolidBrush(Color.FromArgb(192, Color.Yellow));
            Font font = new Font("Tahoma", 8.25F);
            Font font_ = new Font("Tahoma", 8.25F, FontStyle.Bold);
            foreach (Exit exit in exits.Exits)
            {
                r.X = ((exit.X & 127) * 32) + (16 * (exit.Y & 1)) - 16;
                r.Y = ((exit.Y & 127) * 8) - 8;
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
        private void GenerateExitPixels()
        {
            Bitmap exitFieldBase = global::LAZYSHELL.Properties.Resources.fieldBase;
            Bitmap exitFieldBlock = global::LAZYSHELL.Properties.Resources.fieldBlock;
            exitFieldBasePixels = Do.ImageToPixels(exitFieldBase);
            exitFieldBlockPixels = Do.ImageToPixels(exitFieldBlock);

            Do.Colorize(exitFieldBasePixels, 60.0, 1.0);
            Do.Colorize(exitFieldBlockPixels, 60.0, 1.0);
            Do.Gradient(exitFieldBasePixels, 32, 16, 128.0, -128.0, true);
            Do.Gradient(exitFieldBlockPixels, 32, 16, 128.0, 0, true);
        }
        // events
        public void DrawLevelEvents(LevelEvents events)
        {
            int[] pixels = new int[1024 * 1024];
            int currentEvent = events.CurrentEvent;
            highlight = false;

            int x, y;

            if (eventFieldBasePixels == null || eventFieldBlockPixels == null)
                GenerateEventPixels();
            if (fieldBaseShadow == null)
                GenerateNPCPixels();

            int[] order = new int[events.Count];
            int[] coordY = new int[events.Count];
            for (int i = 0; i < events.Count; i++)
            {
                events.CurrentEvent = i;
                coordY[i] = events.Y;
            }

            for (int i = 0; i < events.Count; i++)
                order[i] = i;
            int[] temp = new int[coordY.Length]; coordY.CopyTo(temp, 0);
            Array.Sort(temp, order);

            for (int g = 0; g < events.Count; g++)
            {
                int i = order[g];

                events.CurrentEvent = i;

                highlight = i == events.SelectedEvent;

                x = ((events.X & 127) * 32) + (16 * (events.Y & 1)) - 16;
                y = ((events.Y & 127) * 8) - 8;

                // Draw the complete # of blocks
                if (events.Width > 0)
                {
                    if (events.Facing == 0)
                    {
                        y -= events.Width * 8;
                        x += events.Width * 16;
                    }
                    for (int w = 0; w <= events.Width; w++)
                    {
                        // draw shadow
                        if (events.Z > 0)
                        {
                            if (events.Facing == 0)
                                CopySuboverlayToOverlay(pixels, 1024, fieldBaseShadow, 32, 16, -(w * 16) + x, w * 8 + y);
                            else
                                CopySuboverlayToOverlay(pixels, 1024, fieldBaseShadow, 32, 16, w * 16 + x, w * 8 + y);
                        }
                    }
                    for (int w = 0; w <= events.Width; w++)
                    {
                        if (w == 0) y -= events.Z * 16;

                        // draw the whole field
                        if (events.Height == 0)
                            CopySuboverlayToOverlay(pixels, 1024, eventFieldBasePixels, 32, 16, x, y);
                        else if (events.Height > 0)
                        {
                            y -= 16;
                            for (int h = 0; h < events.Height; h++)
                                CopySuboverlayToOverlay(pixels, 1024, eventFieldBlockPixels, 32, 32, x, y - (h * 16));
                            y += 16;
                        }
                        x += events.Facing == 0 ? -16 : 16;
                        y += 8;
                    }
                }
                else
                {
                    // draw shadow
                    if (events.Z > 0)
                        CopySuboverlayToOverlay(pixels, 1024, fieldBaseShadow, 32, 16, x, y);

                    y -= events.Z * 16;

                    if (events.Height == 0)
                        CopySuboverlayToOverlay(pixels, 1024, eventFieldBasePixels, 32, 16, x, y);
                    else if (events.Height > 0)
                    {
                        y -= 16;
                        for (int h = 0; h < events.Height; h++)
                            CopySuboverlayToOverlay(pixels, 1024, eventFieldBlockPixels, 32, 32, x, y - (h * 16));
                    }
                }
                // End Drawing
            }
            eventsImage = new Bitmap(Do.PixelsToImage(pixels, 1024, 1024));
            pixels = null;

            if (events.Count > 0)
                events.CurrentEvent = currentEvent;
        }
        public void DrawLevelEvents(LevelEvents events, Graphics g)
        {
            // draw exit strings
            foreach (Event event_ in events.Events)
            {
                if (event_ != events.Event_)
                    DrawLevelEvent(g, events, event_);
            }
            if (events.Event_ != null)
                DrawLevelEvent(g, events, events.Event_);
        }
        private void DrawLevelEvent(Graphics g, LevelEvents events, Event temp)
        {
            Rectangle r = new Rectangle();
            Pen pen = new Pen(Color.Yellow, 2);
            SolidBrush brush = new SolidBrush(Color.FromArgb(128, 0, 255, 0));
            SolidBrush brush_ = new SolidBrush(Color.FromArgb(192, 0, 255, 0));
            Font font = new Font("Tahoma", 8.25F);
            Font font_ = new Font("Tahoma", 8.25F, FontStyle.Bold | FontStyle.Underline);
            Font font_b = new Font("Tahoma", 8.25F, FontStyle.Bold);
            Font lucida = new Font("Lucida Console", 8.25F);

            r.X = ((temp.X & 127) * 32) + (16 * (temp.Y & 1)) - 16;
            r.Y = ((temp.Y & 127) * 8) - 8;

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
        private void GenerateEventPixels()
        {
            Bitmap eventFieldBase = global::LAZYSHELL.Properties.Resources.fieldBase;
            Bitmap eventFieldBlock = global::LAZYSHELL.Properties.Resources.fieldBlock;
            eventFieldBasePixels = Do.ImageToPixels(eventFieldBase);
            eventFieldBlockPixels = Do.ImageToPixels(eventFieldBlock);

            Do.Colorize(eventFieldBasePixels, 120.0, 1.0);
            Do.Colorize(eventFieldBlockPixels, 120.0, 1.0);
            Do.Gradient(eventFieldBasePixels, 32, 16, 128.0, -128.0, true);
            Do.Gradient(eventFieldBlockPixels, 32, 16, 128.0, 0, true);
        }
        // npcs
        public void DrawLevelNPCs(LevelNPCs npcs, NPCProperties[] npcProperties)
        {
            int[] whole = new int[1024 * 1024];
            int currentNPC = npcs.CurrentNPC;
            int currentInstance = 0;
            if (npcs.Count > 0)
                currentInstance = npcs.CurrentInstance;

            highlight = false;

            if (npcFieldBasePixels == null)
                GenerateNPCPixels();

            int total = 0;
            for (int i = 0; i < npcs.Count; i++, total++)
            {
                npcs.CurrentNPC = i;
                total += npcs.InstanceCount;
            }
            int[] order = new int[total];
            int[] coordY = new int[total];
            int[][] pixels = new int[total][];      // the sprite image
            Point[] point = new Point[total];       // exact pixel coords to draw to
            Point[] coords = new Point[total];      // actual coords of sprite
            Size[] size = new Size[total];          // size of the sprite image
            bool[] floating = new bool[total];
            bool[] show = new bool[total];
            bool[] selected = new bool[total];
            for (int i = 0, a = 0; i < npcs.Count; i++, a++)
            {
                npcs.CurrentNPC = i;

                coordY[a] = npcs.Y;
                if (npcs.EngageType == 0)
                {
                    pixels[a] = npcProperties[npcs.NPCID + npcs.PropertyA].CreateImage(npcs.Face, false, 0);
                    size[a].Height = npcProperties[npcs.NPCID + npcs.PropertyA].ImageHeight;
                    size[a].Width = npcProperties[npcs.NPCID + npcs.PropertyA].ImageWidth;
                }
                else
                {
                    pixels[a] = npcProperties[npcs.NPCID].CreateImage(npcs.Face, false, 0);
                    size[a].Height = npcProperties[npcs.NPCID].ImageHeight;
                    size[a].Width = npcProperties[npcs.NPCID].ImageWidth;
                }
                point[a].X = coords[a].X = ((npcs.X & 127) * 32) + (16 * (npcs.Y & 1)) - 16;
                point[a].Y = ((npcs.Y & 127) * 8) - 8 - (npcs.Z * 16) - (npcs.CoordYBit7 ? 8 : 0);
                coords[a].Y = ((npcs.Y & 127) * 8) - 8;
                floating[a] = npcs.Z > 0 || npcs.CoordYBit7;
                show[a] = npcs.CoordXBit7;
                selected[a] = i == npcs.SelectedNPC && !npcs.IsInstanceSelected;

                for (int o = 0; o < npcs.InstanceCount; o++, a++)
                {
                    npcs.CurrentInstance = o;

                    coordY[a + 1] = npcs.InstanceCoordY;
                    if (npcs.EngageType == 0)
                    {
                        pixels[a + 1] = npcProperties[npcs.NPCID + npcs.InstancePropertyA].CreateImage(npcs.InstanceFace, false, 0);
                        size[a + 1].Height = npcProperties[npcs.NPCID + npcs.InstancePropertyA].ImageHeight;
                        size[a + 1].Width = npcProperties[npcs.NPCID + npcs.InstancePropertyA].ImageWidth;
                    }
                    else
                    {
                        pixels[a + 1] = npcProperties[npcs.NPCID].CreateImage(npcs.InstanceFace, false, 0);
                        size[a + 1].Height = npcProperties[npcs.NPCID].ImageHeight;
                        size[a + 1].Width = npcProperties[npcs.NPCID].ImageWidth;
                    }
                    point[a + 1].X = coords[a + 1].X = ((npcs.InstanceCoordX & 127) * 32) + (16 * (npcs.InstanceCoordY & 1)) - 16;
                    point[a + 1].Y = ((npcs.InstanceCoordY & 127) * 8) - 8 - (npcs.InstanceCoordZ * 16) - (npcs.InstanceCoordYBit7 ? 8 : 0);
                    coords[a + 1].Y = ((npcs.InstanceCoordY & 127) * 8) - 8;
                    floating[a + 1] = npcs.InstanceCoordZ > 0 || npcs.InstanceCoordYBit7;
                    show[a + 1] = npcs.InstanceCoordXBit7;
                    selected[a + 1] = i == npcs.SelectedNPC && o == npcs.SelectedInstance && npcs.IsInstanceSelected;
                }
            }

            for (int i = 0; i < total; i++)
                order[i] = i;
            int[] temp = new int[coordY.Length]; coordY.CopyTo(temp, 0);
            Array.Sort(temp, order);

            int x, y;

            if (npcs.Count > 0)
            {
                npcs.CurrentNPC = currentNPC;
                if (npcs.InstanceCount > 0)
                    npcs.CurrentInstance = currentInstance;
            }

            for (int g = 0; g < total; g++)
            {
                int i = order[g];

                // Draw dark grey shadow at actual coords
                highlight = selected[i];
                if (floating[i])
                    CopySuboverlayToOverlay(whole, 1024, fieldBaseShadow, 32, 16, coords[i].X, coords[i].Y);

                // Draw red field base at exact pixel coords
                x = point[i].X;
                y = point[i].Y;

                CopySuboverlayToOverlay(whole, 1024, npcFieldBasePixels, 32, 16, x, y);
                highlight = false;

                x += 32 - size[i].Width / 2 - 16;
                y -= size[i].Height - 4 - 8;

                // draw the npc
                if (show[i])
                    CopySuboverlayToOverlay(whole, 1024, pixels[i], size[i].Width, size[i].Height, x, y);
            }
            npcsImage = new Bitmap(Do.PixelsToImage(whole, 1024, 1024));
            pixels = null;
            whole = null;

            if (npcs.Count > 0)
            {
                npcs.CurrentNPC = currentNPC;
                if (npcs.InstanceCount > 0)
                    npcs.CurrentInstance = currentInstance;
            }
        }
        public void DrawLevelNPCs(LevelNPCs npcs, Graphics g)
        {
            // draw exit strings
            int index = 0;
            int current = 0;
            foreach (NPC npc in npcs.Npcs)
            {
                if (npc != npcs.Npc || npcs.IsInstanceSelected)
                    DrawLevelNPC(npcs, g, npc, index++, false, null);
                else
                    current = index++;
                foreach (NPC instance in npc.Instances)
                {
                    if (npc != npcs.Npc || instance != npcs.Npc.Instance_ || !npcs.IsInstanceSelected)
                        DrawLevelNPC(npcs, g, instance, index++, false, null);
                    else
                        current = index++;
                }
            }
            if (npcs.Npc != null)
            {
                if (!npcs.IsInstanceSelected)
                    DrawLevelNPC(npcs, g, npcs.Npc, current, true, null);
                else
                    DrawLevelNPC(npcs, g, npcs.Npc.Instance_, current, true, npcs.Npc);
            }
        }
        private void DrawLevelNPC(LevelNPCs npcs, Graphics g, NPC npc, int index, bool selected, NPC parent)
        {
            Rectangle r = new Rectangle();
            Pen pen = new Pen(Color.Yellow, 2);
            SolidBrush brush = new SolidBrush(Color.FromArgb(128, 255, 0, 0));
            SolidBrush brush_ = new SolidBrush(Color.FromArgb(192, 255, 0, 0));
            Font font = new Font("Tahoma", 8.25F);
            Font font_ = new Font("Tahoma", 8.25F, FontStyle.Bold | FontStyle.Underline);
            Font font_b = new Font("Tahoma", 8.25F, FontStyle.Bold);
            Font lucida = new Font("Lucida Console", 8.25F);

            r.X = ((npc.X & 127) * 32) + (16 * (npc.Y & 1)) - 16;
            r.Y = ((npc.Y & 127) * 8) - 8;

            string name = "NPC #" + index;
            RectangleF label = new RectangleF(new PointF(r.X, r.Y + 24),
                g.MeasureString(name, font_, new PointF(0, 0), StringFormat.GenericDefault));

            if (!selected)
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
                    property = npc.EventORpack + npc.PropertyB;
                    engagetype = npc.EngageType;
                }
                else
                {
                    property = parent.EventORpack + npc.PropertyB;
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
        private void GenerateNPCPixels()
        {
            Bitmap npcFieldBase = global::LAZYSHELL.Properties.Resources.fieldBase;
            npcFieldBasePixels = Do.ImageToPixels(npcFieldBase);
            Do.Colorize(npcFieldBasePixels, 0.0, 1.0);
            Do.Gradient(npcFieldBasePixels, 32, 16, 128.0, -128.0, true);

            fieldBaseShadow = new int[32 * 16];
            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    if (npcFieldBasePixels[y * 32 + x] != 0)
                        fieldBaseShadow[y * 32 + x] = Color.FromArgb(64 - (y * 4), 64 - (y * 4), 64 - (y * 4)).ToArgb();
                }
            }
        }
        // overlaps
        public void DrawLevelOverlaps(LevelOverlaps overlaps, OverlapTileset overlapTileset)
        {
            int[] pixels = new int[1024 * 1024];
            int currentOverlap = overlaps.CurrentOverlap;
            highlight = false;

            if (overlapFieldBasePixels == null)
                GenerateOverlapPixels();

            int x, y;

            for (int g = 0; g < overlaps.Count; g++)
            {
                overlaps.CurrentOverlap = g;

                x = ((overlaps.X & 127) * 32) + (16 * (overlaps.Y & 1)) - 16;
                y = ((overlaps.Y & 127) * 8) - 8;

                // Draw dark grey shadow at actual coords
                highlight = g == overlaps.SelectedOverlap;
                if (overlaps.Z > 0)
                    CopySuboverlayToOverlay(pixels, 1024, fieldBaseShadow, 32, 16, x, y);

                y = ((overlaps.Y & 127) * 8) - 8 - (overlaps.Z * 16) - (overlaps.B1b7 ? 8 : 0);

                // Draw blue field base at exact pixel coords
                CopySuboverlayToOverlay(pixels, 1024, overlapFieldBasePixels, 32, 16, x, y);
                int[] tilepixels = Bits.Copy(overlapTileset.OverlapTiles[overlaps.Type].Pixels);
                Do.Gradient(tilepixels, 32, 32, 0, 64, false);
                Do.Opacity(tilepixels, 32, 32, 224);
                CopySuboverlayToOverlay(pixels, 1024, tilepixels, 32, 32, x, y - 16);
                highlight = false;
            }
            overlapsImage = new Bitmap(Do.PixelsToImage(pixels, 1024, 1024));
            pixels = null;

            if (overlaps.Count > 0)
                overlaps.CurrentOverlap = currentOverlap;
        }
        private void GenerateOverlapPixels()
        {
            Bitmap overlapFieldBase = global::LAZYSHELL.Properties.Resources.fieldBase;
            overlapFieldBasePixels = Do.ImageToPixels(overlapFieldBase);
            Do.Colorize(overlapFieldBasePixels, 240.0, 1.0);
            Do.Gradient(overlapFieldBasePixels, 32, 16, 128.0, -128.0, true);
        }
        // mods
        public void DrawLevelTileMods(LevelTileMods tileMods, Graphics g)
        {
            Rectangle region;
            Pen pen;
            foreach (LevelTileMods.Mod mod in tileMods.Mods)
            {
                if (tileMods.Mod_ == mod && !tileMods.SelectedB)
                    continue;
                g.DrawImage(mod.ImageA, new Point(mod.X * 16, mod.Y * 16));
                region = new Rectangle(mod.X * 16, mod.Y * 16, mod.Width * 16, mod.Height * 16);
                pen = new Pen(Color.Red);
                pen.DashStyle = DashStyle.Dot;
                pen.Alignment = PenAlignment.Outset;
                pen.Width = 2;
                region.X -= 1;
                region.Y -= 1;
                region.Width += 2;
                region.Height += 2;
                g.DrawRectangle(pen, region);
            }
            if (tileMods.Mods.Count == 0) return;
            LevelTileMods.Mod current = tileMods.Mod_;
            if (!tileMods.SelectedB)
                g.DrawImage(current.ImageA, new Point(current.X * 16, current.Y * 16));
            else
                g.DrawImage(current.ImageB, new Point(current.X * 16, current.Y * 16));
            region = new Rectangle(current.X * 16, current.Y * 16, current.Width * 16, current.Height * 16);
            pen = new Pen(Color.Red);
            pen.DashStyle = DashStyle.Dot;
            pen.Alignment = PenAlignment.Outset;
            pen.Width = 4;
            region.X -= 2;
            region.Y -= 2;
            region.Width += 4;
            region.Height += 4;
            g.DrawRectangle(pen, region);
        }
        public void DrawLevelSolidMods(LevelSolidMods solidMods, SolidityTile[] tiles, Graphics g)
        {
            Solidity solidity = Solidity.Instance;
            foreach (LevelSolidMods.Mod mod in solidMods.Mods)
            {
                if (mod == solidMods.Mod_)
                    continue;
                g.DrawImage(mod.Image, 0, 0);
            }
            if (solidMods.Mods.Count == 0) return;
            g.DrawImage(solidMods.Mod_.Image, 0, 0);
        }
        public void DrawLevelSolidMods(LevelSolidMods solidMods, Graphics g)
        {
            foreach (LevelSolidMods.Mod mod in solidMods.Mods)
            {
                int x = ((mod.X & 127) * 32) + (16 * (mod.Y & 1)) - 16;
                int y = ((mod.Y & 127) * 8) - 8;
                Point top = new Point(x + 16, y);
                Point right = new Point(top.X + (mod.Width * 16), y + (mod.Width * 8));
                Point bottom = new Point(right.X - (mod.Height * 16), right.Y + (mod.Height * 8));
                Point left = new Point(bottom.X - (mod.Width * 16), bottom.Y - (mod.Width * 8));
                top.Y -= mod != solidMods.Mod_ ? 2 : 4;
                right.X += mod != solidMods.Mod_ ? 4 : 6;
                bottom.Y += mod != solidMods.Mod_ ? 2 : 4;
                left.X -= mod != solidMods.Mod_ ? 4 : 6;
                Pen pen = new Pen(Color.Red);
                pen.Width = mod != solidMods.Mod_ ? 2 : 4; pen.DashStyle = DashStyle.Dot;
                g.DrawPolygon(pen, new Point[] { top, right, bottom, left, top });
            }
        }
        #endregion
    }
}
