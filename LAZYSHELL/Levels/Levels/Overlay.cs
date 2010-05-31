using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using LAZYSHELL.Properties;

namespace LAZYSHELL
{
    class Overlay
    {
        private State state;
        private int[] levelOverlay = new int[1024 * 1024]; // Applied last, shows what the user is currently doing;
        private int[] exitFieldBasePixels;
        private int[] exitFieldBlockPixels;
        private int[] eventFieldBasePixels;
        private int[] eventFieldBlockPixels;
        private int[] npcFieldBasePixels;
        private int[] overlapFieldBasePixels;
        private int[] fieldBaseShadow;
        public int bfX = 0;
        public int bfY = 0;
        public int alpha = 255;
        private bool highlight;
        public bool bfield, bdlg, wmap;

        private int tileSelected = 0; public int TileSelected { get { return tileSelected; } set { tileSelected = value; } }
        private int mapTileSelected = 0; public int MapTileSelected { get { return mapTileSelected; } set { mapTileSelected = value; } }

        private Point dragStart, dragStop, tileSetDragStart, tileSetDragStop;
        public Point DragStart
        {
            get { return GetTopLeft(dragStart, dragStop); }
            set { dragStart = WithinBounds(value, 1024, 1024); }
        }
        public Point DragStop
        {
            get { return GetBottomRight(dragStart, dragStop); }
            set { dragStop = WithinBounds(value, 1024, 1024); }
        }
        public Point TileSetDragStart
        {
            get { return GetTopLeft(tileSetDragStart, tileSetDragStop); }
            set
            {
                if (bfield)
                    tileSetDragStart = WithinBounds(value, 512, 512);
                else if (bdlg)
                    tileSetDragStart = WithinBounds(value, 256, 32);
                else if (wmap)
                    tileSetDragStart = WithinBounds(value, 256, 256);
                else
                    tileSetDragStart = WithinBounds(value, 256, 512);
            }
        }
        public Point TileSetDragStop
        {
            get { return GetBottomRight(tileSetDragStart, tileSetDragStop); }
            set
            {
                if (bfield)
                    tileSetDragStop = WithinBounds(value, 512, 512);
                else if (bdlg)
                    tileSetDragStop = WithinBounds(value, 256, 32);
                else if (wmap)
                    tileSetDragStop = WithinBounds(value, 256, 256);
                else
                    tileSetDragStop = WithinBounds(value, 256, 512);
            }
        }
        private Point physTilePoint;
        private int physTileTotalHeight;
        private bool clearSelection = false;

        public Size SelectionSize;

        public Point PhysTilePoint { get { return physTilePoint; } set { physTilePoint = value; } }
        public int PhysTileTotalHeight { get { return physTileTotalHeight; } set { physTileTotalHeight = value; } }
        public bool ClearSelection { get { return clearSelection; } set { clearSelection = value; } }

        private Bitmap npcsImage, exitsImage, eventsImage, overlapsImage;
        public Bitmap NPCsImage { get { return npcsImage; } set { npcsImage = value; } }
        public Bitmap ExitsImage { get { return exitsImage; } set { exitsImage = value; } }
        public Bitmap EventsImage { get { return eventsImage; } set { eventsImage = value; } }
        public Bitmap OverlapsImage { get { return overlapsImage; } set { overlapsImage = value; } }

        public Overlay()
        {
            state = State.Instance;
        }

        private void CopyToArray(int[] source, int[] dest)
        {
            for (int i = 0; i < source.Length; i++)
                if (source[i] != 0)
                    dest[i] = source[i];
        }

        public Point WithinBounds(Point p, int maxX, int maxY)
        {
            if (p.X > maxX)
                p.X = maxX;
            if (p.Y > maxY)
                p.Y = maxY;
            if (p.X < 0)
                p.X = 0;
            if (p.Y < 0)
                p.Y = 0;

            return p;
        }
        private Point GetTopLeft(Point start, Point end)
        {
            int sx, sy, ex, ey;
            sx = start.X;
            sy = start.Y;
            ex = end.X;
            ey = end.Y;

            // Case 1, s.x < e.x && s.y < e.y
            // Do nothing, were fine
            // Case 2, s.x > e.x && s.y > e.y
            if (sx > ex && sy > ey)
            {
                Swap(ref sx, ref ex);
                Swap(ref sy, ref ey);
            }
            // Case 3, s.x < e.x && s.y > e.y
            if (sx < ex && sy > ey)
            {
                Swap(ref sy, ref ey);
            }
            // Case 4, s.x > e.x && s.y < e.y
            if (sx > ex && sy < ey)
            {
                Swap(ref sx, ref ex);
            }

            return new Point(sx, sy);
        }
        private Point GetBottomRight(Point start, Point end)
        {
            int sx, sy, ex, ey;
            sx = start.X;
            sy = start.Y;
            ex = end.X;
            ey = end.Y;

            // Case 1, s.x < e.x && s.y < e.y
            // Do nothing, were fine
            // Case 2, s.x > e.x && s.y > e.y
            if (sx > ex && sy > ey)
            {
                Swap(ref sx, ref ex);
                Swap(ref sy, ref ey);
            }
            // Case 3, s.x < e.x && s.y > e.y
            if (sx < ex && sy > ey)
            {
                Swap(ref sy, ref ey);
            }
            // Case 4, s.x > e.x && s.y < e.y
            if (sx > ex && sy < ey)
            {
                Swap(ref sx, ref ex);
            }

            return new Point(ex, ey);
        }

        private void Swap(ref int a, ref int b)
        {
            int temp;
            temp = a;
            a = b;
            b = temp;
        }
        public void ClearArray(int[] arr)
        {
            if (arr == null)
                return;

            for (int i = 0; i < arr.Length; i++)
                arr[i] = 0;
        }

        // "Size s" is the size of the control, "Size u" is the distance between grid lines
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
        public void DrawOrthographicGrid(Graphics g, Color c, Size s, Size u, int z)
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
            Pen n = new Pen(new SolidBrush(Color.Orange), 2 * z);
            if (p.X == 0) p.X++; if (p.Y == 0) p.Y++;
            Rectangle r = new Rectangle(p, s);
            if (r.Right >= 1024 - 1 * z) r.Width = 1024 - 2 * z;
            if (r.Bottom >= 1024 - 1 * z) r.Height = 1024 - 2 * z;
            g.DrawRectangle(n, r);
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
        public void DrawOrthographicSelection(Graphics g, Point p, Size s, int z)
        {
            if (p.X == 1024 && p.Y == 1024)
                return;

            int[] pixels = new int[s.Width * s.Height];

            // draw the orthbox            
            int row, col;
            int topStart = 0;

            int colorA, colorB;

            for (int i = 0; i < 2; i++)
            {
                row = 8 + 768 - topStart;
                for (col = 0; col < 16; col += 2)
                {
                    if ((row + col) % 2 == 1) { colorA = Color.Black.ToArgb(); colorB = Color.White.ToArgb(); }
                    else { colorA = Color.White.ToArgb(); colorB = Color.Black.ToArgb(); }
                    pixels[col + (row * 32)] = colorA;
                    pixels[col + 1 + (row * 32)] = colorB;
                    pixels[col + ((row - 1) * 32)] = colorB;
                    pixels[col + 1 + ((row - 1) * 32)] = colorA;

                    row++;
                }
                row = 15 + 768 - topStart;
                for (col = 16; col < 32; col += 2)
                {
                    if ((row + col) % 2 == 1) { colorA = Color.Black.ToArgb(); colorB = Color.White.ToArgb(); }
                    else { colorA = Color.White.ToArgb(); colorB = Color.Black.ToArgb(); }
                    pixels[col + (row * 32)] = colorA;
                    pixels[col + 1 + (row * 32)] = colorB;
                    pixels[col + ((row - 1) * 32)] = colorB;
                    pixels[col + 1 + ((row - 1) * 32)] = colorA;
                    row--;
                }
                row = 7 + 768 - topStart;
                for (col = 0; col < 16; col += 2)
                {
                    if ((row + col) % 2 == 1) { colorA = Color.Black.ToArgb(); colorB = Color.White.ToArgb(); }
                    else { colorA = Color.White.ToArgb(); colorB = Color.Black.ToArgb(); }
                    pixels[col + (row * 32)] = colorA;
                    pixels[col + 1 + (row * 32)] = colorB;
                    pixels[col + ((row + 1) * 32)] = colorB;
                    pixels[col + 1 + ((row + 1) * 32)] = colorA;
                    row--;
                }
                row = 0 + 768 - topStart;
                for (col = 16; col < 32; col += 2)
                {
                    if ((row + col) % 2 == 1) { colorA = Color.Black.ToArgb(); colorB = Color.White.ToArgb(); }
                    else { colorA = Color.White.ToArgb(); colorB = Color.Black.ToArgb(); }
                    pixels[col + (row * 32)] = colorA;
                    pixels[col + 1 + (row * 32)] = colorB;
                    pixels[col + ((row + 1) * 32)] = colorB;
                    pixels[col + 1 + ((row + 1) * 32)] = colorA;
                    row++;
                }

                topStart = physTileTotalHeight;
            }

            col = 0;
            for (row = 784 - physTileTotalHeight; row < 784; row++)
            {
                if (row % 2 == 1) { colorA = Color.Black.ToArgb(); colorB = Color.White.ToArgb(); }
                else { colorA = Color.White.ToArgb(); colorB = Color.Black.ToArgb(); }
                pixels[col + ((row - 8) * 32)] = colorA;
                pixels[col + 1 + ((row - 8) * 32)] = colorB;
                pixels[col + 14 + (row * 32)] = colorA;
                pixels[col + 14 + 1 + (row * 32)] = colorB;
                pixels[col + 16 + ((row - 16) * 32)] = colorA;
                pixels[col + 16 + 1 + ((row - 16) * 32)] = colorB;
                pixels[col + 30 + ((row - 8) * 32)] = colorA;
                pixels[col + 30 + 1 + ((row - 8) * 32)] = colorB;
            }

            Rectangle rsrc = new Rectangle(0, 0, s.Width, s.Height);
            Rectangle rdst = new Rectangle(p.X * z, (p.Y - 768) * z, z * s.Width, z * s.Height);
            g.DrawImage(new Bitmap(DrawImageFromIntArr(pixels, s.Width, s.Height)), rdst, rsrc, GraphicsUnit.Pixel);
            //g.DrawImage(new Bitmap(DrawImageFromIntArr(pixels, s.Width, s.Height)), p.X, p.Y - 768);

            pixels = null;
        }

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
                coordY[i] = exits.FieldCoordY;
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

                x = ((exits.FieldCoordX & 127) * 32) + (16 * (exits.FieldCoordY & 1)) - 16;
                y = ((exits.FieldCoordY & 127) * 8) - 8;

                // Draw the complete # of blocks
                if (exits.LengthOverOne)
                {
                    if (exits.FieldRadialPosition == 0)
                    {
                        y -= exits.FieldWidth * 8;
                        x += exits.FieldWidth * 16;
                    }
                    for (int w = 0; w <= exits.FieldWidth; w++)
                    {
                        // draw shadow
                        if (exits.FieldCoordZ > 0)
                        {
                            if (exits.FieldRadialPosition == 0)
                                CopySuboverlayToOverlay(pixels, 1024, fieldBaseShadow, 32, 16, -(w * 16) + x, w * 8 + y);
                            else
                                CopySuboverlayToOverlay(pixels, 1024, fieldBaseShadow, 32, 16, w * 16 + x, w * 8 + y);
                        }
                    }
                    for (int w = 0; w <= exits.FieldWidth; w++)
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
                        x += exits.FieldRadialPosition == 0 ? -16 : 16;
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
            exitsImage = new Bitmap(DrawImageFromIntArr(pixels, 1024, 1024));
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
                coordY[i] = events.FieldCoordY;
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

                x = ((events.FieldCoordX & 127) * 32) + (16 * (events.FieldCoordY & 1)) - 16;
                y = ((events.FieldCoordY & 127) * 8) - 8;

                // Draw the complete # of blocks
                if (events.LengthOverOne)
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
            eventsImage = new Bitmap(DrawImageFromIntArr(pixels, 1024, 1024));
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

                coordY[a] = npcs.CoordY;
                if (npcs.EngageType == 0)
                {
                    pixels[a] = npcProperties[npcs.NPCID + npcs.PropertyA].CreateImage(npcs.RadialPosition, false, 0);
                    size[a].Height = npcProperties[npcs.NPCID + npcs.PropertyA].ImageHeight;
                    size[a].Width = npcProperties[npcs.NPCID + npcs.PropertyA].ImageWidth;
                }
                else
                {
                    pixels[a] = npcProperties[npcs.NPCID].CreateImage(npcs.RadialPosition, false, 0);
                    size[a].Height = npcProperties[npcs.NPCID].ImageHeight;
                    size[a].Width = npcProperties[npcs.NPCID].ImageWidth;
                }
                point[a].X = coords[a].X = ((npcs.CoordX & 127) * 32) + (16 * (npcs.CoordY & 1)) - 16;
                point[a].Y = ((npcs.CoordY & 127) * 8) - 8 - (npcs.CoordZ * 16) - (npcs.CoordYBit7 ? 8 : 0);
                coords[a].Y = ((npcs.CoordY & 127) * 8) - 8;
                floating[a] = npcs.CoordZ > 0 || npcs.CoordYBit7;
                show[a] = npcs.CoordXBit7;
                selected[a] = i == npcs.SelectedNPC && !npcs.IsInstanceSelected;

                for (int o = 0; o < npcs.NumberOfInstances; o++, a++)
                {
                    npcs.CurrentInstance = o;

                    coordY[a + 1] = npcs.InstanceCoordY;
                    if (npcs.EngageType == 0)
                    {
                        pixels[a + 1] = npcProperties[npcs.NPCID + npcs.InstancePropertyA].CreateImage(npcs.InstanceRadialPosition, false, 0);
                        size[a + 1].Height = npcProperties[npcs.NPCID + npcs.InstancePropertyA].ImageHeight;
                        size[a + 1].Width = npcProperties[npcs.NPCID + npcs.InstancePropertyA].ImageWidth;
                    }
                    else
                    {
                        pixels[a + 1] = npcProperties[npcs.NPCID].CreateImage(npcs.InstanceRadialPosition, false, 0);
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
            npcsImage = new Bitmap(DrawImageFromIntArr(whole, 1024, 1024));
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

                x = ((overlaps.CoordX & 127) * 32) + (16 * (overlaps.CoordY & 1)) - 16;
                y = ((overlaps.CoordY & 127) * 8) - 8;

                // Draw dark grey shadow at actual coords
                if (overlaps.CoordZ > 0)
                    CopySuboverlayToOverlay(pixels, 1024, fieldBaseShadow, 32, 16, x, y);

                y = ((overlaps.CoordY & 127) * 8) - 8 - (overlaps.CoordZ * 16) - (overlaps.B1b7 ? 8 : 0);

                // Draw blue field base at exact pixel coords
                highlight = g == overlaps.SelectedOverlap;
                CopySuboverlayToOverlay(pixels, 1024, overlapFieldBasePixels, 32, 16, x, y);
                CopySuboverlayToOverlay(pixels, 1024, overlapTileset.OverlapTiles[overlaps.Type].Pixels(), 32, 32, x, y - 16);
                highlight = false;
            }
            overlapsImage = new Bitmap(DrawImageFromIntArr(pixels, 1024, 1024));
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

        private Bitmap DrawImageFromIntArr(int[] arr, int width, int height)
        {
            Bitmap image = null;
            unsafe
            {
                fixed (void* firstPixel = &arr[0])
                {
                    IntPtr ip = new IntPtr(firstPixel);
                    if (image != null)
                        image.Dispose();
                    image = new Bitmap(width, height, width * 4, System.Drawing.Imaging.PixelFormat.Format32bppPArgb, ip);

                }
            }
            return image;
        }
    }
}
