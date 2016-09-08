using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using LazyShell.Areas;
using LazyShell.Properties;
using LazyShell.EventScripts;

namespace LazyShell
{
    public class Overlay
    {
        #region Variables

        // Overlay object images
        public List<Bitmap> NPCImages { get; set; }
        private Bitmap npcBaseImage;
        private Bitmap npcBaseImageH;
        private Bitmap exitBaseImage;
        private Bitmap exitBaseImageH;
        private Bitmap exitBlockImage;
        private Bitmap exitBlockImageH;
        private Bitmap eventBaseImage;
        private Bitmap eventBaseImageH;
        private Bitmap eventBlockImage;
        private Bitmap eventBlockImageH;
        private Bitmap baseShadowImage;
        private Bitmap baseShadowImageH;
        private Bitmap overlapBaseImage;
        private Bitmap overlapBaseImageH;

        // Current opacity level of overlay
        public int Opacity { get; set; }

        #endregion

        public Overlay()
        {
            this.Select = new Selection();
            this.SelectTS = new Selection();
            this.Opacity = 255;
        }

        #region Methods

        // Overlay elements
        public void DrawTileGrid(Graphics g, Color c, Size s, Size u, bool dashed, int offset)
        {
            DrawTileGrid(g, c, s, u, 1, dashed, offset);
        }
        public void DrawTileGrid(Graphics g, Color c, Size s, Size u, int z, bool dashed)
        {
            DrawTileGrid(g, c, s, u, z, dashed, 0);
        }
        /// <summary>
        /// Draws a tile grid to a graphics surface with a specific unit and size.
        /// </summary>
        /// <param name="g">The graphics surface to draw to.</param>
        /// <param name="c">The color of the grid lines.</param>
        /// <param name="s">The size of the grid lines.</param>
        /// <param name="u">The distance, in pixels, between each grid line.</param>
        /// <param name="z">The zoom factor to figure into the drawing operation.</param>
        /// <param name="dashed">Indicates whether to draw dashed or solid lines.</param>
        /// <param name="offset">The number of pixels to offset the gridlines.</param>
        public void DrawTileGrid(Graphics g, Color c, Size s, Size u, int z, bool dashed, int offset)
        {
            c = Color.FromArgb(Opacity, c);
            Pen p = new Pen(new SolidBrush(c));
            if (dashed)
                p.DashPattern = new float[] { 1, 1 };
            Point h = new Point();
            Point v = new Point();
            for (h.Y = z * u.Height + offset; h.Y < s.Height + offset; h.Y += z * u.Height)
                g.DrawLine(p, h, new Point(h.X + s.Width, h.Y));
            for (v.X = z * u.Width + offset; v.X < s.Width + offset; v.X += z * u.Width)
                g.DrawLine(p, v, new Point(v.X, v.Y + s.Height));
        }
        /// <summary>
        /// Draws an isometric grid to a graphics surface with a specific unit and size.
        /// </summary>
        /// <param name="g">The graphics surface to draw to.</param>
        /// <param name="c">The color of the grid lines.</param>
        /// <param name="s">The size of the grid lines.</param>
        /// <param name="u">The distance, in pixels, between each grid line.</param>
        /// <param name="z">The zoom factor to figure into the drawing operation.</param>
        public void DrawIsometricGrid(Graphics g, Color c, Size s, Size u, int z)
        {
            c = Color.FromArgb(Opacity, c);
            Pen p = new Pen(new SolidBrush(c));
            Point n = new Point();

            // Draw lines from upper-left to bottom-right
            for (n.Y = z * u.Height - (8 * z); n.Y < s.Height * 2; n.Y += z * u.Height)
                g.DrawLine(p, n, new Point(n.Y * 2, 0));

            // Draw lines from upper-right to bottom-left
            n.X = s.Width;
            for (n.Y = z * u.Height - (8 * z); n.Y < s.Height * 2; n.Y += z * u.Height)
                g.DrawLine(p, n, new Point(s.Width - (n.Y * 2), 0));
        }
        public void DrawAreaMask(Graphics g, Point stop, Point start, int z)
        {
            int u = z * 16;
            Point p = new Point(start.X * u, start.Y * u);
            Size s = new Size((stop.X - start.X) * u + u, (stop.Y - start.Y) * u + u);
            Brush b = new SolidBrush(Color.FromArgb(75, Color.Orange));
            Rectangle r = new Rectangle(p, s);
            if (r.Right >= 1024 * z)
                r.Width = (1024 - 1) * z;
            if (r.Bottom >= 1024 * z)
                r.Height = (1024 - 1) * z;
            g.FillRectangle(b, r);
            g.DrawRectangle(Pens.Orange, r);
        }
        public void DrawBoundaries(Graphics g, Point location, int z)
        {
            Pen pen = new Pen(SystemColors.ControlDark);
            pen.Width = z; pen.Alignment = PenAlignment.Inset;
            location.X = location.X / 16 * 16;
            location.Y = location.Y / 16 * 16;
            g.FillRectangle(new SolidBrush(Color.FromArgb(50, 0, 0, 0)), location.X * z, location.Y * z, 256 * z, 224 * z);
            g.DrawRectangle(pen, location.X * z, location.Y * z, 256 * z, 224 * z);
        }
        public void DrawHoverBox(Graphics g, Point location, Size size, int zoom, bool fill)
        {
            int x = location.X;
            int y = location.Y;
            Rectangle r = new Rectangle(x * zoom, y * zoom, size.Width * zoom, size.Height * zoom);
            if (fill)
                g.FillRectangle(new SolidBrush(Color.FromArgb(96, 0, 0, 0)), r);
            else
            {
                r.Width--;
                r.Height--;
                g.DrawRectangle(Pens.Gray, r);
            }
        }

        // Exit triggers
        private void CreateExitTriggerImages()
        {
            Bitmap exitFieldBase = global::LazyShell.Properties.Resources.fieldBase;
            Bitmap exitFieldBlock = global::LazyShell.Properties.Resources.fieldBlock;
            int[] exitFieldBasePixels = Do.ImageToPixels(exitFieldBase);
            int[] exitFieldBlockPixels = Do.ImageToPixels(exitFieldBlock);
            Do.Colorize(exitFieldBasePixels, 60.0, 1.0);
            Do.Colorize(exitFieldBlockPixels, 60.0, 1.0);
            Do.Gradient(exitFieldBasePixels, 32, 16, 128.0, -128.0, true);
            Do.Gradient(exitFieldBlockPixels, 32, 16, 128.0, 0, true);
            exitBaseImage = Do.PixelsToImage(exitFieldBasePixels, 32, 16);
            exitBlockImage = Do.PixelsToImage(exitFieldBlockPixels, 32, 32);
            exitBaseImageH = Do.Hilite(exitBaseImage, 32, 16);
            exitBlockImageH = Do.Hilite(exitBlockImage, 32, 32);
        }
        public void DrawExitTriggers(ExitTriggerCollection triggers, ExitTrigger selectedTrigger, Graphics g, int z)
        {
            var sortedTriggers = new List<Areas.ExitTrigger>();
            foreach (var trigger in triggers.Triggers)
            {
                sortedTriggers.Add(trigger);
            }
            sortedTriggers.Sort(delegate(ExitTrigger exit1, ExitTrigger exit2)
            {
                return exit1.Y.CompareTo(exit2.Y);
            });
            foreach (var trigger in sortedTriggers)
                DrawExitTrigger(trigger, selectedTrigger, g, z);
        }
        private void DrawExitTrigger(ExitTrigger trigger, ExitTrigger selectedTrigger, Graphics g, int z)
        {
            if (exitBaseImage == null)
                CreateExitTriggerImages();
            if (baseShadowImage == null)
                CreateNPCObjectImages();

            // Initialize coordinate pair
            int x = ((trigger.X & 127) * 32) + (16 * (trigger.Y & 1)) - 16;
            int y = ((trigger.Y & 127) * 8) - 8;
            bool hilite = trigger == selectedTrigger;
            Rectangle rsrc, rdst;

            // Draw the complete # of blocks
            if (trigger.Width > 0)
            {
                if (trigger.F == 0)
                {
                    y -= trigger.Width * 8;
                    x += trigger.Width * 16;
                }

                // Draw shadow
                for (int w = 0; w <= trigger.Width; w++)
                {
                    if (trigger.Z > 0)
                    {
                        if (trigger.F == 0)
                            rsrc = new Rectangle(-(w * 16) + x, w * 8 + y, 32, 16);
                        else
                            rsrc = new Rectangle(w * 16 + x, w * 8 + y, 32, 16);
                        rdst = new Rectangle(rsrc.X * z, rsrc.Y * z, rsrc.Width * z, rsrc.Height * z);
                        g.DrawImage(hilite ? baseShadowImageH : baseShadowImage, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
                    }
                }

                // Draw field base
                for (int w = 0; w <= trigger.Width; w++)
                {
                    if (w == 0)
                        y -= trigger.Z * 16;
                    // Draw flat base
                    if (trigger.Height == 0)
                    {
                        rsrc = new Rectangle(x, y, 32, 16);
                        rdst = new Rectangle(rsrc.X * z, rsrc.Y * z, rsrc.Width * z, rsrc.Height * z);
                        g.DrawImage(hilite ? exitBaseImageH : exitBaseImage, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
                    }
                    // Draw block base(s)
                    else if (trigger.Height > 0)
                    {
                        y -= 16;
                        for (int h = 0; h < trigger.Height; h++)
                        {
                            rsrc = new Rectangle(x, y - (h * 16), 32, 32);
                            rdst = new Rectangle(rsrc.X * z, rsrc.Y * z, rsrc.Width * z, rsrc.Height * z);
                            g.DrawImage(hilite ? exitBlockImageH : exitBlockImage, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
                        }
                        y += 16;
                    }
                    x += trigger.F == 0 ? -16 : 16;
                    y += 8;
                }
            }
            else
            {
                // Draw shadow
                if (trigger.Z > 0)
                {
                    rsrc = new Rectangle(x, y, 32, 16);
                    rdst = new Rectangle(rsrc.X * z, rsrc.Y * z, rsrc.Width * z, rsrc.Height * z);
                    g.DrawImage(hilite ? baseShadowImageH : baseShadowImage, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
                }

                // Draw flat base
                y -= trigger.Z * 16;
                if (trigger.Height == 0)
                {
                    rsrc = new Rectangle(x, y, 32, 16);
                    rdst = new Rectangle(rsrc.X * z, rsrc.Y * z, rsrc.Width * z, rsrc.Height * z);
                    g.DrawImage(hilite ? exitBaseImageH : exitBaseImage, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
                }
                // Draw block base(s)
                else if (trigger.Height > 0)
                {
                    y -= 16;
                    for (int h = 0; h < trigger.Height; h++)
                    {
                        rsrc = new Rectangle(x, y - (h * 16), 32, 32);
                        rdst = new Rectangle(rsrc.X * z, rsrc.Y * z, rsrc.Width * z, rsrc.Height * z);
                        g.DrawImage(hilite ? exitBlockImageH : exitBlockImage, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
                    }
                }
            }
        }
        public void DrawExitTriggerTags(ExitTriggerCollection triggers, ExitTrigger selectedTrigger, Graphics g, int z)
        {
            if (triggers.Count == 0)
                return;

            // Initialize brushes, fonts
            Rectangle r = new Rectangle();
            SolidBrush brush = new SolidBrush(Color.FromArgb(128, Color.Yellow));
            SolidBrush brush_ = new SolidBrush(Color.FromArgb(192, Color.Yellow));
            Font font = new Font("Tahoma", 8.25F);
            Font font_ = new Font("Tahoma", 8.25F, FontStyle.Bold);

            // Draw exit triggers
            foreach (ExitTrigger trigger in triggers.Triggers)
            {
                r.X = ((trigger.X & 127) * 32) + (16 * (trigger.Y & 1)) - 16; r.X *= z;
                r.Y = ((trigger.Y & 127) * 8) - 8; r.Y *= z;
                string name;
                if (trigger.ExitType == 0)
                    name = Lists.Numerize(Lists.Areas, trigger.Destination);
                else
                    name = Lists.Numerize(Lists.Locations, trigger.Destination);
                RectangleF label = new RectangleF(new PointF(r.X, r.Y + 24),
                    g.MeasureString(name, font_, new PointF(0, 0), StringFormat.GenericDefault));
                if (trigger == selectedTrigger)
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
            }
        }

        // Event triggers
        private void CreateEventTriggerImages()
        {
            Bitmap eventFieldBase = global::LazyShell.Properties.Resources.fieldBase;
            Bitmap eventFieldBlock = global::LazyShell.Properties.Resources.fieldBlock;
            int[] eventFieldBasePixels = Do.ImageToPixels(eventFieldBase);
            int[] eventFieldBlockPixels = Do.ImageToPixels(eventFieldBlock);
            Do.Colorize(eventFieldBasePixels, 120.0, 1.0);
            Do.Colorize(eventFieldBlockPixels, 120.0, 1.0);
            Do.Gradient(eventFieldBasePixels, 32, 16, 128.0, -128.0, true);
            Do.Gradient(eventFieldBlockPixels, 32, 16, 128.0, 0, true);
            eventBaseImage = Do.PixelsToImage(eventFieldBasePixels, 32, 16);
            eventBlockImage = Do.PixelsToImage(eventFieldBlockPixels, 32, 32);
            eventBaseImageH = Do.Hilite(eventBaseImage, 32, 16);
            eventBlockImageH = Do.Hilite(eventBlockImage, 32, 32);
        }
        public void DrawEventTriggers(EventTriggerCollection triggers, EventTrigger selectedTrigger, Graphics g, int z)
        {
            var sortedTriggers = new List<EventTrigger>();
            foreach (var trigger in triggers)
            {
                sortedTriggers.Add(trigger);
            }
            sortedTriggers.Sort(delegate(EventTrigger trigger1, EventTrigger trigger2)
            {
                return trigger1.Y.CompareTo(trigger2.Y);
            });
            foreach (var trigger in sortedTriggers)
                DrawEventTrigger(trigger, selectedTrigger, g, z);
        }
        private void DrawEventTrigger(EventTrigger trigger, EventTrigger selectedTrigger, Graphics g, int z)
        {
            if (eventBaseImage == null)
                CreateEventTriggerImages();
            if (baseShadowImage == null)
                CreateNPCObjectImages();

            // Initialize coordinate pair
            int x = ((trigger.X & 127) * 32) + (16 * (trigger.Y & 1)) - 16;
            int y = ((trigger.Y & 127) * 8) - 8;
            bool hilite = trigger == selectedTrigger;
            Rectangle rsrc, rdst;

            // Draw the complete # of blocks
            if (trigger.Width > 0)
            {
                if (trigger.F == 0)
                {
                    y -= trigger.Width * 8;
                    x += trigger.Width * 16;
                }

                // Draw shadow
                for (int w = 0; w <= trigger.Width; w++)
                {
                    if (trigger.Z > 0)
                    {
                        if (trigger.F == 0)
                            rsrc = new Rectangle(-(w * 16) + x, w * 8 + y, 32, 16);
                        else
                            rsrc = new Rectangle(w * 16 + x, w * 8 + y, 32, 16);
                        rdst = new Rectangle(rsrc.X * z, rsrc.Y * z, rsrc.Width * z, rsrc.Height * z);
                        g.DrawImage(hilite ? baseShadowImageH : baseShadowImage, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
                    }
                }

                // Draw field base
                for (int w = 0; w <= trigger.Width; w++)
                {
                    if (w == 0)
                        y -= trigger.Z * 16;
                    if (trigger.Height == 0)
                    {
                        rsrc = new Rectangle(x, y, 32, 16);
                        rdst = new Rectangle(rsrc.X * z, rsrc.Y * z, rsrc.Width * z, rsrc.Height * z);
                        g.DrawImage(hilite ? eventBaseImageH : eventBaseImage, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
                    }
                    else if (trigger.Height > 0)
                    {
                        y -= 16;
                        for (int h = 0; h < trigger.Height; h++)
                        {
                            rsrc = new Rectangle(x, y - (h * 16), 32, 32);
                            rdst = new Rectangle(rsrc.X * z, rsrc.Y * z, rsrc.Width * z, rsrc.Height * z);
                            g.DrawImage(hilite ? eventBlockImageH : eventBlockImage, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
                        }
                        y += 16;
                    }
                    x += trigger.F == 0 ? -16 : 16;
                    y += 8;
                }
            }
            else
            {
                if (trigger.Z > 0)
                {
                    rsrc = new Rectangle(x, y, 32, 16);
                    rdst = new Rectangle(rsrc.X * z, rsrc.Y * z, rsrc.Width * z, rsrc.Height * z);
                    g.DrawImage(hilite ? baseShadowImageH : baseShadowImage, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
                }
                y -= trigger.Z * 16;
                if (trigger.Height == 0)
                {
                    rsrc = new Rectangle(x, y, 32, 16);
                    rdst = new Rectangle(rsrc.X * z, rsrc.Y * z, rsrc.Width * z, rsrc.Height * z);
                    g.DrawImage(hilite ? eventBaseImageH : eventBaseImage, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
                }
                else if (trigger.Height > 0)
                {
                    y -= 16;
                    for (int h = 0; h < trigger.Height; h++)
                    {
                        rsrc = new Rectangle(x, y - (h * 16), 32, 32);
                        rdst = new Rectangle(rsrc.X * z, rsrc.Y * z, rsrc.Width * z, rsrc.Height * z);
                        g.DrawImage(hilite ? eventBlockImageH : eventBlockImage, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
                    }
                }
            }
        }
        public void DrawEventTriggerTags(EventTriggerCollection triggers, EventTrigger selectedTrigger, Graphics g, int z)
        {
            if (triggers.Count == 0)
                return;

            // Draw event strings
            foreach (var trigger in triggers.Triggers)
            {
                if (trigger != selectedTrigger)
                    DrawEventTriggerTag(g, triggers, selectedTrigger, trigger, z);
            }
            if (selectedTrigger != null)
                DrawEventTriggerTag(g, triggers, selectedTrigger, selectedTrigger, z);
        }
        private void DrawEventTriggerTag(Graphics g, EventTriggerCollection triggers, EventTrigger selectedTrigger, EventTrigger trigger, int z)
        {
            // Initialize brushes, fonts
            var brush = new SolidBrush(Color.FromArgb(128, 0, 255, 0));
            var brush_ = new SolidBrush(Color.FromArgb(192, 0, 255, 0));
            var font = new Font("Tahoma", 8.25F);
            var font_ = new Font("Tahoma", 8.25F, FontStyle.Bold | FontStyle.Underline);
            var font_b = new Font("Tahoma", 8.25F, FontStyle.Bold);
            var lucida = new Font("Lucida Console", 8.25F);

            // Initialize region
            var r = new Rectangle();
            r.X = ((trigger.X & 127) * 32) + (16 * (trigger.Y & 1)) - 16; r.X *= z;
            r.Y = ((trigger.Y & 127) * 8) - 8; r.Y *= z;

            // Draw label string
            string name = "Event #" + trigger.RunEvent.ToString();
            var label = new RectangleF(new PointF(r.X, r.Y + 24),
                g.MeasureString(name, font_, new PointF(0, 0), StringFormat.GenericDefault));
            if (trigger != selectedTrigger)
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(128, Color.Black)), label);
                g.DrawString(name, font, brush, r.X, r.Y + 24);
            }
            else
            {
                g.FillRectangle(brush, r);
                g.FillRectangle(new SolidBrush(Color.FromArgb(192, Color.Black)), label);
                g.DrawString(name, font_, brush_, r.X, r.Y + 24);

                // Draw command collection stub
                string script = EventScripts.Parser.ParseScript(EventScripts.Model.EventScripts[selectedTrigger.RunEvent], 8, 40);
                RectangleF commandbox = new RectangleF(r.X + 2, r.Y + 40, 256, (label.Height - 2) * script.Split('\n').Length);
                g.FillRectangle(brush_, commandbox);
                g.DrawString(script, font_b, new SolidBrush(Color.Black), r.X + 6, r.Y + 44);
            }
        }

        // NPC objects
        private void CreateNPCObjectImages()
        {
            Bitmap npcFieldBase = global::LazyShell.Properties.Resources.fieldBase;
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
            npcBaseImage = Do.PixelsToImage(npcFieldBasePixels, 32, 16);
            npcBaseImageH = Do.Hilite(npcBaseImage, 32, 16);
            baseShadowImage = Do.PixelsToImage(fieldBaseShadow, 32, 16);
            baseShadowImageH = Do.Hilite(baseShadowImage, 32, 16);
        }
        public void DrawNPCObjects(NPCObjectCollection npcObjects, NPCObject selectedNPCObject, NPCProperties[] npcProperties)
        {
            NPCImages = new List<Bitmap>();
            foreach (var npc in npcObjects)
            {
                DrawNPCObject(npc, npcProperties, npc.NPCID, npc.EngageType);
            }
        }
        private void DrawNPCObject(NPCObject npcObject, NPCProperties[] npcProperties, int npcid, EngageType engagetype)
        {
            int NPCID = 0;
            if (engagetype == EngageType.Event)
                NPCID = Math.Min(511, npcid);
            else
                NPCID = Math.Min(511, npcid);
            Size size = new Size(0, 0);
            var sprite = Sprites.Model.Sprites[npcProperties[NPCID].Sprite];
            int[] pixels = sprite.GetPixels(false, true, 0, npcObject.F, false, false, ref size);
            Bitmap image = Do.PixelsToImage(pixels, size.Width, size.Height);
            this.NPCImages.Add(image);
        }
        public void DrawNPCObjects(NPCObjectCollection npcObjects, NPCObject selectedNPCObject, Graphics g, int z)
        {
            List<NPCObject> sortedNPCObjects = new List<NPCObject>();
            foreach (var npcObject in npcObjects)
            {
                sortedNPCObjects.Add(npcObject);
            }
            sortedNPCObjects.Sort(delegate(NPCObject npc1, NPCObject npc2)
            {
                return npc1.Y.CompareTo(npc2.Y);
            });
            foreach (var npcObject in sortedNPCObjects)
                DrawNPCObject(npcObjects, npcObject, selectedNPCObject, g, z);
        }
        private void DrawNPCObject(NPCObjectCollection npcObjects, NPCObject npcObject, NPCObject selectedNPCObject, Graphics g, int z)
        {
            if (npcBaseImage == null)
                CreateNPCObjectImages();

            // Initialize coordinate pair
            int x = ((npcObject.X & 127) * 32) + (16 * (npcObject.Y & 1)) - 16;
            int y = ((npcObject.Y & 127) * 8) - 8;

            // Initialize regions
            var rsrc = new Rectangle(x, y, 32, 16);
            var rdst = new Rectangle(x * z, y * z, 32 * z, 16 * z);

            // Draw the base shadow
            if (npcObject != selectedNPCObject)
                g.DrawImage(baseShadowImage, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
            else
                g.DrawImage(baseShadowImageH, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);

            // Draw the base
            y -= npcObject.Z * 16;
            y -= npcObject.ZHalf ? 8 : 0;
            rsrc = new Rectangle(x, y, 32, 16);
            rdst = new Rectangle(x * z, y * z, 32 * z, 16 * z);
            if (npcObject != selectedNPCObject)
                g.DrawImage(npcBaseImage, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
            else
                g.DrawImage(npcBaseImageH, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);

            // Draw the NPC sprite image
            x = x - 112;
            y = y - 120 - 1;
            int index = npcObjects.IndexOf(npcObject);
            rsrc = new Rectangle(x, y, NPCImages[index].Width, NPCImages[index].Height);
            rdst = new Rectangle(x * z, y * z, rsrc.Width * z, rsrc.Height * z);
            if (npcObject.ShowNPC)
                g.DrawImage(NPCImages[index], rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
        }
        public void DrawNPCObjectTags(NPCObjectCollection npcObjects, NPCObject selectedNPCObject, Graphics g, int z)
        {
            if (npcObjects.Count == 0)
                return;
            int index = 0;
            // Draw tags for NPC objects
            foreach (var npcObject in npcObjects.NPCObjects)
            {
                if (npcObject != selectedNPCObject)
                    DrawNPCObjectTag(npcObjects, npcObject, selectedNPCObject, g, index++, z);
                else
                    index++;
            }
            if (selectedNPCObject != null)
            {
                DrawNPCObjectTag(npcObjects, selectedNPCObject, selectedNPCObject, g, index++, z);
            }
        }
        private void DrawNPCObjectTag(NPCObjectCollection npcObjects, NPCObject npcObject, NPCObject selectedNPCObject, Graphics g, int index, int z)
        {
            // Initialize brushes, fonts
            SolidBrush brush = new SolidBrush(Color.FromArgb(128, 255, 0, 0));
            SolidBrush brush_ = new SolidBrush(Color.FromArgb(192, 255, 0, 0));
            Font font = new Font("Tahoma", 8.25F);
            Font font_ = new Font("Tahoma", 8.25F, FontStyle.Bold | FontStyle.Underline);
            Font font_b = new Font("Tahoma", 8.25F, FontStyle.Bold);
            Font lucida = new Font("Lucida Console", 8.25F);

            // Initialize region
            Rectangle r = new Rectangle();
            r.X = ((npcObject.X & 127) * 32) + (16 * (npcObject.Y & 1)) - 16; r.X *= z;
            r.Y = ((npcObject.Y & 127) * 8) - 8; r.Y *= z;

            // Draw label string
            string name = "NPC #" + index;
            RectangleF label = new RectangleF(new PointF(r.X, r.Y + 24),
                g.MeasureString(name, font_, new PointF(0, 0), StringFormat.GenericDefault));
            if (npcObject != selectedNPCObject)
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(128, Color.Black)), label);
                g.DrawString(name, font, brush, r.X, r.Y + 24);
            }
            else
            {
                g.FillRectangle(brush, r);
                g.FillRectangle(new SolidBrush(Color.FromArgb(192, Color.Black)), label);
                g.DrawString(name, font_, brush_, r.X, r.Y + 24);

                // Draw command collection stub
                string text = "";
                RectangleF commandbox = new RectangleF();
                EngageType engagetype = npcObject.EngageType;
                if (engagetype == EngageType.Event)
                {
                    int eventIndex = Math.Min(4095, (int)npcObject.Event);
                    text = "{EVENT #" + eventIndex.ToString() + "}\n";
                    text += EventScripts.Parser.ParseScript(EventScripts.Model.EventScripts[eventIndex], 8, 80);
                    commandbox = new RectangleF(r.X + 2, r.Y + 40, 512, (label.Height - 2) * text.Split('\n').Length);
                }
                else if (engagetype == EngageType.Treasure)
                {
                    int eventIndex = Math.Min(4095, (int)npcObject.Event);
                    text = "{EVENT #" + eventIndex.ToString() + "}\n";
                    text += EventScripts.Parser.ParseScript(EventScripts.Model.EventScripts[eventIndex], 8, 80);
                    commandbox = new RectangleF(r.X + 2, r.Y + 40, 512, (label.Height - 2) * text.Split('\n').Length);
                }
                else if (engagetype == EngageType.Battle)
                {
                    int packIndex = Math.Min(255, (int)npcObject.Pack);
                    text = "{PACK #" + packIndex.ToString() + "}\n";
                    text += Formations.Model.Formations[Formations.Model.Packs[packIndex].Formations[0]].ToString() + "\n";
                    text += Formations.Model.Formations[Formations.Model.Packs[packIndex].Formations[1]].ToString() + "\n";
                    text += Formations.Model.Formations[Formations.Model.Packs[packIndex].Formations[2]].ToString() + "\n";
                    commandbox = new RectangleF(r.X + 2, r.Y + 40, 512, (label.Height - 2) * 5);
                }
                g.FillRectangle(brush_, commandbox);
                g.DrawString(text, font_b, new SolidBrush(Color.Black), r.X + 6, r.Y + 44);
            }
        }

        // Overlaps
        private void CreateOverlapObjectImages()
        {
            Bitmap overlapFieldBase = global::LazyShell.Properties.Resources.fieldBase;
            int[] overlapFieldBasePixels = Do.ImageToPixels(overlapFieldBase);
            Do.Colorize(overlapFieldBasePixels, 240.0, 1.0);
            Do.Gradient(overlapFieldBasePixels, 32, 16, 128.0, -128.0, true);
            overlapBaseImage = Do.PixelsToImage(overlapFieldBasePixels, 32, 16);
            overlapBaseImageH = Do.Hilite(overlapBaseImage, 32, 16);
        }
        public void DrawOverlapObjects(OverlapCollection overlaps, Overlap selectedOverlap, OverlapTileset overlapTileset, Graphics g, int z)
        {
            if (overlapBaseImage == null)
                CreateOverlapObjectImages();
            if (baseShadowImage == null)
                CreateNPCObjectImages();

            // Draw the overlaps to the graphics surface
            foreach (var overlap in overlaps.Overlaps)
            {
                // Initialize coordinate pair
                int x = ((overlap.X & 127) * 32) + (16 * (overlap.Y & 1)) - 16;
                int y = ((overlap.Y & 127) * 8) - 8;

                // Initialize region
                var rsrc = new Rectangle(x, y, 32, 16);
                var rdst = new Rectangle(x * z, y * z, 32 * z, 16 * z);

                // Draw base shadow
                if (overlap != selectedOverlap)
                    g.DrawImage(baseShadowImage, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
                else
                    g.DrawImage(baseShadowImageH, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);

                // Generate overlap's RGB pixel array
                int[] pixels = Bits.Copy(overlapTileset.Tileset[overlap.Type].Pixels);

                // Apply gradient and translucent effects to pixels
                Do.Gradient(pixels, 32, 32, 0, 64, false);
                Do.Opacity(pixels, 32, 32, 224);

                // Convert the overlap's pixels to bitmap
                Bitmap tile = Do.PixelsToImage(pixels, 32, 32);
                if (overlap == selectedOverlap)
                    tile = Do.Hilite(tile, 32, 32);

                // Draw base
                y = ((overlap.Y & 127) * 8) - 8 - (overlap.Z * 16) - (overlap.B1b7 ? 8 : 0);
                rsrc = new Rectangle(x, y, 32, 16);
                rdst = new Rectangle(x * z, y * z, 32 * z, 16 * z);
                if (overlap != selectedOverlap)
                    g.DrawImage(overlapBaseImage, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
                else
                    g.DrawImage(overlapBaseImageH, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);

                // Draw overlap's image
                rsrc.Height = 32; rsrc.Y -= 16;
                rdst.Height = 32 * z; rdst.Y -= 16 * z;
                g.DrawImage(tile, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
            }
        }

        // Tile switches
        public void DrawTileSwitches(TileSwitchCollection tileSwitches, TileSwitch selectedTileSwitch, bool alternateSelected, Graphics g, ImageAttributes ia, int z)
        {
            if (tileSwitches.Count == 0)
                return;
            Rectangle rsrc;
            Rectangle rdst;
            Pen pen;
            foreach (var tileSwitch in tileSwitches.TileSwitches)
            {
                if (tileSwitch == selectedTileSwitch && !alternateSelected)
                    continue;

                // Draw the tile switch image
                rsrc = new Rectangle(tileSwitch.X * 16, tileSwitch.Y * 16, tileSwitch.Width * 16, tileSwitch.Height * 16);
                rdst = new Rectangle(tileSwitch.X * 16 * z, tileSwitch.Y * 16 * z, tileSwitch.Width * 16 * z, tileSwitch.Height * 16 * z);
                g.DrawImage(tileSwitch.ImageA, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel, ia);

                // Create dashed rectangle border
                pen = new Pen(Color.Red);
                pen.DashStyle = DashStyle.Dot;
                pen.Alignment = PenAlignment.Outset;
                pen.Width = 2 * z;
                rdst.X -= 1 * z;
                rdst.Y -= 1 * z;
                rdst.Width += 2 * z;
                rdst.Height += 2 * z;

                // Draw dashed rectangle border
                g.DrawRectangle(pen, rdst);
            }
            if (tileSwitches.TileSwitches.Count == 0)
                return;

            // Draw selected tile switch
            rsrc = new Rectangle(selectedTileSwitch.X * 16, selectedTileSwitch.Y * 16, selectedTileSwitch.Width * 16, selectedTileSwitch.Height * 16);
            rdst = new Rectangle(selectedTileSwitch.X * 16 * z, selectedTileSwitch.Y * 16 * z, selectedTileSwitch.Width * 16 * z, selectedTileSwitch.Height * 16 * z);
            if (!alternateSelected)
                g.DrawImage(selectedTileSwitch.ImageA, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel, ia);
            else
                g.DrawImage(selectedTileSwitch.ImageB, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel, ia);

            // Create heavy dashed rectangle border
            pen = new Pen(Color.Red);
            pen.DashStyle = DashStyle.Dot;
            pen.Alignment = PenAlignment.Outset;
            pen.Width = 4 * z;
            rdst.X -= 2 * z;
            rdst.Y -= 2 * z;
            rdst.Width += 4 * z;
            rdst.Height += 4 * z;

            // Draw dashed rectangle border
            g.DrawRectangle(pen, rdst);
        }

        // Collision switches
        public void DrawCollisionSwitches(CollisionSwitchCollection collisionSwitches, CollisionSwitch selectedCollisionSwitch, CollisionTile[] tiles, Graphics g, Rectangle rdst, ImageAttributes ia, int z)
        {
            foreach (var collisionSwitch in collisionSwitches)
            {
                if (collisionSwitch == selectedCollisionSwitch)
                    continue;
                g.DrawImage(collisionSwitch.Image, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel, ia);
            }
            if (collisionSwitches.Count == 0)
                return;
            g.DrawImage(selectedCollisionSwitch.Image, rdst, 0, 0, 1024, 1024, GraphicsUnit.Pixel, ia);
        }
        /// <summary>
        /// Draws the diamond-shaped dashed borders for the collision switches in a collection to a graphics surface.
        /// </summary>
        public void DrawCollisionSwitches(CollisionSwitchCollection collisionSwitches, CollisionSwitch selectedCollisionSwitch, Graphics g, int z)
        {
            if (collisionSwitches.Count == 0)
                return;
            foreach (var collisionSwitch in collisionSwitches)
            {
                int x = ((collisionSwitch.X & 127) * 32) + (16 * (collisionSwitch.Y & 1)) - 16;
                int y = ((collisionSwitch.Y & 127) * 8) - 8;
                Point top = new Point(x + 16, y);
                Point right = new Point(top.X + (collisionSwitch.Width * 16), y + (collisionSwitch.Width * 8));
                Point bottom = new Point(right.X - (collisionSwitch.Height * 16), right.Y + (collisionSwitch.Height * 8));
                Point left = new Point(bottom.X - (collisionSwitch.Width * 16), bottom.Y - (collisionSwitch.Width * 8));
                top.Y -= collisionSwitch != selectedCollisionSwitch ? 2 : 4; top.X *= z; top.Y *= z;
                right.X += collisionSwitch != selectedCollisionSwitch ? 4 : 6; right.X *= z; right.Y *= z;
                bottom.Y += collisionSwitch != selectedCollisionSwitch ? 2 : 4; bottom.X *= z; bottom.Y *= z;
                left.X -= collisionSwitch != selectedCollisionSwitch ? 4 : 6; left.X *= z; left.Y *= z;
                Pen pen = new Pen(Color.Red);
                pen.Width = collisionSwitch != selectedCollisionSwitch ? 2 * z : 4 * z; pen.DashStyle = DashStyle.Dot;
                g.DrawPolygon(pen, new Point[] { top, right, bottom, left, top });
            }
        }

        // Mushrooms
        public void DrawMushrooms(Minecart.MinecartData minecartData, Minecart.MinecartObject[] mushrooms, Graphics g, int z)
        {
            foreach (var mushroom in mushrooms)
            {
                int x = mushroom.X * 16;
                int y = mushroom.Y * 16;
                Rectangle rsrc = new Rectangle(x, y, 16, 16);
                Rectangle rdst = new Rectangle(x * z, y * z, 16 * z, 16 * z);
                g.DrawRectangle(new Pen(Color.Red, z), rdst);
                g.DrawImage(minecartData.Mushroom, rdst, 0, 0, rsrc.Width, rsrc.Height, GraphicsUnit.Pixel);
            }
        }

        // Rails
        public void DrawRailProperties(byte[] bytes, int width, int height, Graphics g, int z)
        {
            Font font = new Font("Tahoma", 9F, FontStyle.Bold);
            Brush pass = new SolidBrush(Color.FromArgb(128, 0, 255, 0));
            Brush slow = new SolidBrush(Color.FromArgb(128, 255, 0, 0));
            Brush exit = new SolidBrush(Color.FromArgb(128, 0, 0, 255));
            Brush what = new SolidBrush(Color.FromArgb(128, 0, 255, 255));
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Rectangle coord = new Rectangle(x * 16 * z, y * 16 * z, 16 * z, 16 * z);
                    int tile;
                    if (bytes != null)
                        tile = bytes[y * width + x];
                    else
                        tile = y * width + x;
                    if (tile >= 0 && tile < 16)
                        g.FillRectangle(pass, coord);
                    if (tile >= 16 && tile < 32)
                        g.FillRectangle(slow, coord);
                    if (tile >= 32 && tile < 48)
                        g.FillRectangle(exit, coord);
                    if (tile >= 48 && tile < 64)
                        g.FillRectangle(what, coord);
                }
            }
        }

        #endregion

        #region Selection

        // Variables
        public Selection Select;
        public Selection SelectTS;

        /// <summary>
        /// Class for drawing and managing a dashed-line selected region in a drawing area.
        /// </summary>
        public class Selection
        {
            #region Variables

            /// <summary>
            /// The picture box control associated with the selection.
            /// </summary>
            public PictureBox Picture { get; set; }

            // Marching ants
            private Timer antTimer;
            private int antOffset;
            private Timer glowTimer;
            private int glowOpacity;

            // Animated zoom region
            private Timer zoomTimer;
            private Bitmap zoomRegion;
            private int zoomFactor;

            // Dimensions, coordinates
            public int X
            {
                get { return Location.X; }
            }
            public int Y
            {
                get { return Location.Y; }
            }
            public int Height
            {
                get { return size.Height; }
            }
            public int Width
            {
                get { return size.Width; }
            }
            public int Unit { get; set; }
            private Size size;
            public Size Size
            {
                get
                {
                    return new Size(
                        Math.Abs(Terminal.X - Location.X),
                        Math.Abs(Terminal.Y - Location.Y));
                }
                set
                {
                    size = new Size(value.Width / Unit * Unit, value.Height / Unit * Unit);
                    final = new Point(Location.X + size.Width, Location.Y + size.Height);
                }
            }
            /// <summary>
            /// The real location (upper-left corner), in pixels, of the selection.
            /// </summary>
            public Point Location
            {
                get
                {
                    int x = initial.X;
                    int y = initial.Y;
                    if (initial.X >= final.X)
                        x = final.X - Unit;
                    if (initial.Y >= final.Y)
                        y = final.Y - Unit;
                    return new Point(
                        Math.Max(0, x), 
                        Math.Max(0, y));
                }
                set
                {
                    initial = value;
                    final = new Point(
                        value.X + size.Width, 
                        value.Y + size.Height);
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
                    initial = new Point(value.X / Unit * Unit, value.Y / Unit * Unit);
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
                    final = new Point(value.X / Unit * Unit, value.Y / Unit * Unit);
                    size = new Size(
                        Math.Abs(Terminal.X - Location.X),
                        Math.Abs(Terminal.Y - Location.Y));
                }
            }
            public bool Empty
            {
                get
                {
                    return size.Width == 0 || size.Height == 0;
                }
            }
            /// <summary>
            /// Returns a rectangle containing the location and size of the selection.
            /// </summary>
            public Rectangle Region
            {
                get { return new Rectangle(Location, Size); }
            }

            #endregion

            /// <summary>
            /// Creates an instance of the Selection class.
            /// </summary>
            public Selection()
            {
                this.Unit = 1;
                this.zoomFactor = 1;
                this.antOffset = 15;
            }

            #region Methods

            /// <summary>
            /// Sets this instance's properties.
            /// </summary>
            /// <param name="unit">The size, in pixels, of the units to draw the selection by.</param>
            /// <param name="initial">The top-left location, in pixels, of this instance's selected region.</param>
            /// <param name="size">The size, in pixels, of this instance's selection box.</param>
            /// <param name="picture">The PictureBox control associated with this instance.</param>
            public void Set(int unit, Point initial, Size size, PictureBox picture)
            {
                Clear();
                this.Unit = unit;
                this.initial = new Point(initial.X / unit * unit, initial.Y / unit * unit);
                this.size = new Size(size.Width / unit * unit, size.Height / unit * unit);
                this.final = new Point(initial.X + size.Width, initial.Y + size.Height);
                this.Picture = picture;
                if (this.antTimer == null)
                {
                    this.antTimer = new Timer();
                    this.antTimer.Tick += new EventHandler(antTimer_Tick);
                }
                this.antTimer.Start();
            }
            /// <summary>
            /// Sets this instance's properties.
            /// </summary>
            /// <param name="unit">The size, in pixels, of the units to draw the selection by.</param>
            /// <param name="x">The X coordinate, in pixels, of this instance's selected region.</param>
            /// <param name="y">The Y coordinate, in pixels, of this instance's selected region.</param>
            /// <param name="width">The width, in pixels, of this instance's selected region.</param>
            /// <param name="height">The height, in pixels, of this instance's selected region.</param>
            /// <param name="picture">The PictureBox control associated with this instance.</param>
            public void Reload(int unit, int x, int y, int width, int height, PictureBox picture)
            {
                Clear();
                this.Unit = unit;
                this.initial = new Point(x / unit * unit, y / unit * unit);
                this.size = new Size(width / unit * unit, height / unit * unit);
                this.final = new Point(x + size.Width, y + size.Height);
                this.Picture = picture;
                if (this.antTimer == null)
                {
                    this.antTimer = new Timer();
                    this.antTimer.Tick += new EventHandler(antTimer_Tick);
                }
                this.antTimer.Start();
            }
            /// <summary>
            /// 
            /// </summary>
            public void Clear()
            {
                this.Unit = 1;
                this.initial = new Point(0, 0);
                this.size = new Size(0, 0);
                this.final = new Point(0, 0);
                if (this.glowTimer != null)
                    this.glowTimer.Stop();
                if (this.antTimer != null)
                    this.antTimer.Stop();
                this.antOffset = 15;
                if (this.zoomRegion != null)
                    this.zoomRegion.Dispose();
                if (this.zoomTimer != null)
                    this.zoomTimer.Stop();
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
                mouse.X = (x / Unit * Unit) - Math.Min(Location.X, Terminal.X);
                mouse.Y = (y / Unit * Unit) - Math.Min(Location.Y, Terminal.Y);
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
                Point mouse = MousePosition((x / Unit * Unit), (y / Unit * Unit));
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
            /// <summary>
            /// Draws the selected region of this instance to a drawing surface.
            /// </summary>
            /// <param name="g">The drawing surface.</param>
            /// <param name="z">The zoom factor.</param>
            /// <param name="color">The color of the dashed selection box.</param>
            public void DrawSelectionBox(Graphics g, int z, Color color)
            {
                // to prevent crashing b/c of memory overflow
                try
                {
                    Point start = Location;
                    Point stop = Terminal;
                    if (stop.X == start.X)
                        return;
                    if (stop.Y == start.Y)
                        return;
                    Point p = new Point(start.X * z, start.Y * z);
                    Size s = new Size((stop.X * z) - (start.X * z) - 1, (stop.Y * z) - (start.Y * z) - 1);
                    Pen penw = new Pen(color);
                    Pen penb = new Pen(Color.FromArgb(color.R / 4, color.G / 4, color.B / 4));
                    if (antOffset < 0)
                        antOffset = 15;
                    penb.DashOffset = antOffset;
                    penb.DashPattern = new float[] { 4, 4 };
                    Rectangle src = new Rectangle(p, s);
                    if (glowOpacity > 0)
                        g.FillRectangle(new SolidBrush(Color.FromArgb(glowOpacity, color)), src);
                    g.DrawRectangle(penw, src);
                    g.DrawRectangle(penb, src);
                    //
                    if (zoomFactor > 1 && zoomRegion != null)
                    {
                        int x = src.X - ((Width * zoomFactor - Width) / 2);
                        int y = src.Y - ((Height * zoomFactor - Height) / 2);
                        Rectangle dst = new Rectangle(x, y, Width * zoomFactor, Height * zoomFactor);
                        src = new Rectangle(0, 0, Width + 1, Height + 1);
                        g.DrawImage(zoomRegion, dst, src, GraphicsUnit.Pixel);
                    }
                }
                catch
                {
                }
            }
            /// <summary>
            /// Draws the selected region of this instance to a drawing surface.
            /// </summary>
            /// <param name="g">The drawing surface.</param>
            /// <param name="z">The zoom factor.</param>
            public void DrawSelectionBox(Graphics g, int z)
            {
                DrawSelectionBox(g, z, Color.White);
            }
            public void GlowSelection()
            {
                glowOpacity = 255;
                glowTimer = new Timer();
                glowTimer.Tick += new EventHandler(glowTimer_Tick);
                glowTimer.Start();
            }
            /// <summary>
            /// Activates an animated zoom region in a specified source image based on this instance's selected region.
            /// </summary>
            /// <param name="image"></param>
            public void ZoomRegion(Bitmap image)
            {
                zoomRegion = image.Clone(Region, PixelFormat.DontCare);
                zoomFactor = 8;
                zoomTimer = new Timer();
                zoomTimer.Interval = 20;
                zoomTimer.Tick += new EventHandler(zoomTimer_Tick);
                zoomTimer.Start();
            }

            #endregion

            #region Event Handlers

            private void glowTimer_Tick(object sender, EventArgs e)
            {
                glowOpacity -= 32;
                if (glowOpacity <= 0)
                    glowTimer.Stop();
                this.Picture.Refresh();
            }
            private void antTimer_Tick(object sender, EventArgs e)
            {
                if (Width < 4 || Height < 4)
                    return;
                antOffset--;
                if (antOffset < 0)
                    antOffset = 15;
                this.Picture.Refresh();
            }
            private void zoomTimer_Tick(object sender, EventArgs e)
            {
                zoomFactor--;
                if (zoomFactor <= 1)
                {
                    zoomFactor = 1;
                    if (zoomRegion != null)
                        zoomRegion.Dispose();
                    zoomTimer.Stop();
                }
                this.Picture.Refresh();
            }

            #endregion
        }

        #endregion
    }
}
