using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    public class Overlay
    {
        #region Variables
        private State state;
        // overlay objects
        private int[] exitFieldBasePixels;
        private int[] exitFieldBlockPixels;
        private int[] eventFieldBasePixels;
        private int[] eventFieldBlockPixels;
        private int[] npcFieldBasePixels;
        private int[] overlapFieldBasePixels;
        private int[] fieldBaseShadow;
        private Bitmap npcsImage, exitsImage, eventsImage, overlapsImage;
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
            state = State.Instance;
        }
        public void DrawCartographicGrid(Graphics g, Color c, Size s, Size u, int z)
        {
            c = Color.FromArgb(alpha, c);
            Pen p = new Pen(new SolidBrush(c));
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
        private void CopySuboverlayToOverlay(int[] overlay, int overlayWidth, int[] sub, int subWidth, int subHeight, int xPixel, int yPixel)
        {
            int temp;
            for (int y = 0; y < subHeight; y++)
            {
                for (int x = 0; x < subWidth; x++)
                {
                    temp = sub[y * subWidth + x];
                    if (yPixel + y >= 0 && xPixel + x >= 0 && temp != 0)
                    {
                        if (highlight) temp = temp / 2 | (0xFF << 32);
                        overlay[((yPixel + y) * overlayWidth) + (xPixel + x)] = temp;
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

            int[] order = new int[exits.NumberOfExits];
            int[] coordY = new int[exits.NumberOfExits];
            for (int i = 0; i < exits.NumberOfExits; i++)
            {
                exits.CurrentExit = i;
                coordY[i] = exits.Y;
            }

            for (int i = 0; i < exits.NumberOfExits; i++)
                order[i] = i;
            int[] temp = new int[coordY.Length]; coordY.CopyTo(temp, 0);
            Array.Sort(temp, order);

            for (int g = 0; g < exits.NumberOfExits; g++)
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
                        if (exits.FieldCoordZ > 0)
                        {
                            if (exits.Face == 0)
                                CopySuboverlayToOverlay(pixels, 1024, fieldBaseShadow, 32, 16, -(w * 16) + x, w * 8 + y);
                            else
                                CopySuboverlayToOverlay(pixels, 1024, fieldBaseShadow, 32, 16, w * 16 + x, w * 8 + y);
                        }
                    }
                    for (int w = 0; w <= exits.Width; w++)
                    {
                        if (w == 0) y -= exits.FieldCoordZ * 16;

                        // draw the whole field
                        if (exits.FieldHeight == 0)
                            CopySuboverlayToOverlay(pixels, 1024, exitFieldBasePixels, 32, 16, x, y);
                        else if (exits.FieldHeight > 0)
                        {
                            y -= 16;
                            for (int h = 0; h < exits.FieldHeight; h++)
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
                    if (exits.FieldCoordZ > 0)
                        CopySuboverlayToOverlay(pixels, 1024, fieldBaseShadow, 32, 16, x, y);

                    y -= exits.FieldCoordZ * 16;

                    if (exits.FieldHeight == 0)
                        CopySuboverlayToOverlay(pixels, 1024, exitFieldBasePixels, 32, 16, x, y);
                    else if (exits.FieldHeight > 0)
                    {
                        y -= 16;
                        for (int h = 0; h < exits.FieldHeight; h++)
                            CopySuboverlayToOverlay(pixels, 1024, exitFieldBlockPixels, 32, 32, x, y - (h * 16));
                    }
                }
                // End Drawing
            }
            exitsImage = new Bitmap(Do.PixelsToImage(pixels, 1024, 1024));
            pixels = null;

            if (exits.NumberOfExits > 0)
                exits.CurrentExit = currentExit;
        }
        private void GenerateExitPixels()
        {
            Bitmap exitFieldBase = global::LAZYSHELL.Properties.Resources.fieldBase;
            Bitmap exitFieldBlock = global::LAZYSHELL.Properties.Resources.fieldBlock;
            exitFieldBasePixels = new int[32 * 16];
            exitFieldBlockPixels = new int[32 * 32];

            for (int y = 0; y < 32; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    if (y < 16) exitFieldBasePixels[y * 32 + x] = exitFieldBase.GetPixel(x, y).ToArgb();
                    exitFieldBlockPixels[y * 32 + x] = exitFieldBlock.GetPixel(x, y).ToArgb();

                    if (y < 16 && exitFieldBasePixels[y * 32 + x] == Color.White.ToArgb()) exitFieldBasePixels[y * 32 + x] = 0;
                    if (exitFieldBlockPixels[y * 32 + x] == Color.White.ToArgb()) exitFieldBlockPixels[y * 32 + x] = 0;
                }
            }

            exitFieldBasePixels = ColorExitPixels(16, exitFieldBasePixels, false);
            exitFieldBlockPixels = ColorExitPixels(32, exitFieldBlockPixels, false);
        }
        private int[] ColorExitPixels(int height, int[] thePixels, bool isShadow)
        {
            int[] somePixels = new int[32 * 256];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    if (thePixels[y * 32 + x] == Color.FromArgb(192, 192, 192).ToArgb()) somePixels[y * 32 + x] = Color.FromArgb(255, 255, 0).ToArgb();
                    else if (thePixels[y * 32 + x] == Color.FromArgb(128, 128, 128).ToArgb()) somePixels[y * 32 + x] = Color.FromArgb(192, 192, 0).ToArgb();
                    else somePixels[y * 32 + x] = thePixels[y * 32 + x];

                }
            }
            return somePixels;
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

            int[] order = new int[events.NumberOfEvents];
            int[] coordY = new int[events.NumberOfEvents];
            for (int i = 0; i < events.NumberOfEvents; i++)
            {
                events.CurrentEvent = i;
                coordY[i] = events.Y;
            }

            for (int i = 0; i < events.NumberOfEvents; i++)
                order[i] = i;
            int[] temp = new int[coordY.Length]; coordY.CopyTo(temp, 0);
            Array.Sort(temp, order);

            for (int g = 0; g < events.NumberOfEvents; g++)
            {
                int i = order[g];

                events.CurrentEvent = i;

                highlight = i == events.SelectedEvent;

                x = ((events.X & 127) * 32) + (16 * (events.Y & 1)) - 16;
                y = ((events.Y & 127) * 8) - 8;

                // Draw the complete # of blocks
                if (events.FieldWidth > 0)
                {
                    if (events.FieldRadialPosition == 0)
                    {
                        y -= events.FieldWidth * 8;
                        x += events.FieldWidth * 16;
                    }
                    for (int w = 0; w <= events.FieldWidth; w++)
                    {
                        // draw shadow
                        if (events.FieldCoordZ > 0)
                        {
                            if (events.FieldRadialPosition == 0)
                                CopySuboverlayToOverlay(pixels, 1024, fieldBaseShadow, 32, 16, -(w * 16) + x, w * 8 + y);
                            else
                                CopySuboverlayToOverlay(pixels, 1024, fieldBaseShadow, 32, 16, w * 16 + x, w * 8 + y);
                        }
                    }
                    for (int w = 0; w <= events.FieldWidth; w++)
                    {
                        if (w == 0) y -= events.FieldCoordZ * 16;

                        // draw the whole field
                        if (events.FieldHeight == 0)
                            CopySuboverlayToOverlay(pixels, 1024, eventFieldBasePixels, 32, 16, x, y);
                        else if (events.FieldHeight > 0)
                        {
                            y -= 16;
                            for (int h = 0; h < events.FieldHeight; h++)
                                CopySuboverlayToOverlay(pixels, 1024, eventFieldBlockPixels, 32, 32, x, y - (h * 16));
                            y += 16;
                        }
                        x += events.FieldRadialPosition == 0 ? -16 : 16;
                        y += 8;
                    }
                }
                else
                {
                    // draw shadow
                    if (events.FieldCoordZ > 0)
                        CopySuboverlayToOverlay(pixels, 1024, fieldBaseShadow, 32, 16, x, y);

                    y -= events.FieldCoordZ * 16;

                    if (events.FieldHeight == 0)
                        CopySuboverlayToOverlay(pixels, 1024, eventFieldBasePixels, 32, 16, x, y);
                    else if (events.FieldHeight > 0)
                    {
                        y -= 16;
                        for (int h = 0; h < events.FieldHeight; h++)
                            CopySuboverlayToOverlay(pixels, 1024, eventFieldBlockPixels, 32, 32, x, y - (h * 16));
                    }
                }
                // End Drawing
            }
            eventsImage = new Bitmap(Do.PixelsToImage(pixels, 1024, 1024));
            pixels = null;

            if (events.NumberOfEvents > 0)
                events.CurrentEvent = currentEvent;
        }
        private void GenerateEventPixels()
        {
            Bitmap eventFieldBase = global::LAZYSHELL.Properties.Resources.fieldBase;
            Bitmap eventFieldBlock = global::LAZYSHELL.Properties.Resources.fieldBlock;
            eventFieldBasePixels = new int[32 * 16];
            eventFieldBlockPixels = new int[32 * 32];

            for (int y = 0; y < 32; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    if (y < 16) eventFieldBasePixels[y * 32 + x] = eventFieldBase.GetPixel(x, y).ToArgb();
                    eventFieldBlockPixels[y * 32 + x] = eventFieldBlock.GetPixel(x, y).ToArgb();

                    if (y < 16 && eventFieldBasePixels[y * 32 + x] == Color.White.ToArgb()) eventFieldBasePixels[y * 32 + x] = 0;
                    if (eventFieldBlockPixels[y * 32 + x] == Color.White.ToArgb()) eventFieldBlockPixels[y * 32 + x] = 0;
                }
            }

            eventFieldBasePixels = ColorEventPixels(16, eventFieldBasePixels, false);
            eventFieldBlockPixels = ColorEventPixels(32, eventFieldBlockPixels, false);
        }
        private int[] ColorEventPixels(int height, int[] thePixels, bool isShadow)
        {
            int[] somePixels = new int[32 * 256];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    if (thePixels[y * 32 + x] == Color.FromArgb(192, 192, 192).ToArgb()) somePixels[y * 32 + x] = Color.FromArgb(0, 255, 0).ToArgb();
                    else if (thePixels[y * 32 + x] == Color.FromArgb(128, 128, 128).ToArgb()) somePixels[y * 32 + x] = Color.FromArgb(0, 192, 0).ToArgb();
                    else somePixels[y * 32 + x] = thePixels[y * 32 + x];

                }
            }
            return somePixels;
        }
        // npcs
        public void DrawLevelNPCs(LevelNPCs npcs, NPCProperties[] npcProperties)
        {
            int[] whole = new int[1024 * 1024];
            int currentNPC = npcs.CurrentNPC;
            int currentInstance = 0;
            if (npcs.NumberOfNPCs > 0)
                currentInstance = npcs.CurrentInstance;

            highlight = false;

            if (npcFieldBasePixels == null)
                GenerateNPCPixels();

            int total = 0;
            for (int i = 0; i < npcs.NumberOfNPCs; i++, total++)
            {
                npcs.CurrentNPC = i;
                total += npcs.NumberOfInstances;
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
            for (int i = 0, a = 0; i < npcs.NumberOfNPCs; i++, a++)
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

                for (int o = 0; o < npcs.NumberOfInstances; o++, a++)
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

            if (npcs.NumberOfNPCs > 0)
            {
                npcs.CurrentNPC = currentNPC;
                if (npcs.NumberOfInstances > 0)
                    npcs.CurrentInstance = currentInstance;
            }

            for (int g = 0; g < total; g++)
            {
                int i = order[g];

                // Draw dark grey shadow at actual coords
                if (floating[i])
                    CopySuboverlayToOverlay(whole, 1024, fieldBaseShadow, 32, 16, coords[i].X, coords[i].Y);

                // Draw red field base at exact pixel coords
                x = point[i].X;
                y = point[i].Y;

                highlight = selected[i];
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

            if (npcs.NumberOfNPCs > 0)
            {
                npcs.CurrentNPC = currentNPC;
                if (npcs.NumberOfInstances > 0)
                    npcs.CurrentInstance = currentInstance;
            }
        }
        private void GenerateNPCPixels()
        {
            Bitmap npcFieldBase = global::LAZYSHELL.Properties.Resources.fieldBase;
            npcFieldBasePixels = new int[32 * 16];
            fieldBaseShadow = new int[32 * 16];

            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    npcFieldBasePixels[y * 32 + x] = npcFieldBase.GetPixel(x, y).ToArgb();
                    if (npcFieldBasePixels[y * 32 + x] == Color.White.ToArgb()) npcFieldBasePixels[y * 32 + x] = 0;
                }
            }
            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    if (npcFieldBasePixels[y * 32 + x] != 0)
                        fieldBaseShadow[y * 32 + x] = Color.FromArgb(64, 64, 64).ToArgb();
                }
            }

            npcFieldBasePixels = ColorNPCPixels(16, npcFieldBasePixels, false);
        }
        private int[] ColorNPCPixels(int height, int[] thePixels, bool isShadow)
        {
            int[] somePixels = new int[32 * 256];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    if (thePixels[y * 32 + x] == Color.FromArgb(192, 192, 192).ToArgb()) somePixels[y * 32 + x] = Color.FromArgb(255, 0, 0).ToArgb();
                    else if (thePixels[y * 32 + x] == Color.FromArgb(128, 128, 128).ToArgb()) somePixels[y * 32 + x] = Color.FromArgb(192, 0, 0).ToArgb();
                    else somePixels[y * 32 + x] = thePixels[y * 32 + x];

                }
            }
            return somePixels;
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

            for (int g = 0; g < overlaps.NumberOfOverlaps; g++)
            {
                overlaps.CurrentOverlap = g;

                x = ((overlaps.X & 127) * 32) + (16 * (overlaps.Y & 1)) - 16;
                y = ((overlaps.Y & 127) * 8) - 8;

                // Draw dark grey shadow at actual coords
                if (overlaps.Z > 0)
                    CopySuboverlayToOverlay(pixels, 1024, fieldBaseShadow, 32, 16, x, y);

                y = ((overlaps.Y & 127) * 8) - 8 - (overlaps.Z * 16) - (overlaps.B1b7 ? 8 : 0);

                // Draw blue field base at exact pixel coords
                highlight = g == overlaps.SelectedOverlap;
                CopySuboverlayToOverlay(pixels, 1024, overlapFieldBasePixels, 32, 16, x, y);
                CopySuboverlayToOverlay(pixels, 1024, overlapTileset.OverlapTiles[overlaps.Type].Pixels, 32, 32, x, y - 16);
                highlight = false;
            }
            overlapsImage = new Bitmap(Do.PixelsToImage(pixels, 1024, 1024));
            pixels = null;

            if (overlaps.NumberOfOverlaps > 0)
                overlaps.CurrentOverlap = currentOverlap;
        }
        private void GenerateOverlapPixels()
        {
            Bitmap overlapFieldBase = global::LAZYSHELL.Properties.Resources.fieldBase;
            overlapFieldBasePixels = new int[32 * 16];

            for (int y = 0; y < 32; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    if (y < 16)
                        overlapFieldBasePixels[y * 32 + x] = overlapFieldBase.GetPixel(x, y).ToArgb();
                    if (y < 16 && overlapFieldBasePixels[y * 32 + x] == Color.White.ToArgb())
                        overlapFieldBasePixels[y * 32 + x] = 0;
                }
            }

            overlapFieldBasePixels = ColorOverlapPixels(16, overlapFieldBasePixels, false);
        }
        private int[] ColorOverlapPixels(int height, int[] thePixels, bool isShadow)
        {
            int[] somePixels = new int[32 * 256];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    if (thePixels[y * 32 + x] == Color.FromArgb(192, 192, 192).ToArgb()) somePixels[y * 32 + x] = Color.FromArgb(0, 0, 255).ToArgb();
                    else if (thePixels[y * 32 + x] == Color.FromArgb(128, 128, 128).ToArgb()) somePixels[y * 32 + x] = Color.FromArgb(0, 0, 192).ToArgb();
                    else somePixels[y * 32 + x] = thePixels[y * 32 + x];

                }
            }
            return somePixels;
        }
        #endregion
    }
}
