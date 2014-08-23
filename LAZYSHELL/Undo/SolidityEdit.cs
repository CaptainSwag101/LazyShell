using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LAZYSHELL.Undo
{
    class CollisionEdit : Edit
    {
        // Variables
        private Areas.OwnerForm updater;
        private byte[] changes;
        private Point start, stop, initial;
        public Tilemap Tilemap { get; set; }
        public bool AutoRedo { get; set; }
        // Constructor
        public CollisionEdit(Areas.OwnerForm updater, Tilemap tilemap, Point start, Point stop, Point initial, byte[] changes)
        {
            this.updater = updater;
            this.Tilemap = tilemap;
            //
            if (start.Y < stop.Y)
            {
                this.start = start;
                this.stop = stop;
            }
            else if (start == stop && start.X <= stop.X)
            {
                this.start = start;
                this.stop = stop;
            }
            else if (stop.Y < start.Y)
            {
                this.start = stop;
                this.stop = start;
            }
            this.initial = initial;
            this.changes = new byte[changes.Length];
            changes.CopyTo(this.changes, 0);
            //
            Execute();
        }
        public void Execute()
        {
            var start = this.start;
            var stop = this.stop;
            if (start.X > 1023) start.X = 1023;
            if (start.Y > 1023) start.Y = 1023;
            if (stop.X > 1023) stop.X = 1023;
            if (stop.X > 1023) stop.X = 1023;
            var collision = Areas.Collision.Instance;
            //
            bool[] made = new bool[changes.Length / 2];
            for (int y = start.Y, b = initial.Y; y < stop.Y; y++, b++)
            {
                for (int x = start.X, a = initial.X; x < stop.X; x++, a++)
                {
                    if (y * 1024 + x < collision.PixelTiles.Length &&
                        b * 1024 + a < collision.PixelTiles.Length)
                    {
                        int p = collision.PixelTiles[y * 1024 + x] * 2;
                        int r = collision.PixelTiles[b * 1024 + a] * 2;
                        if (!made[p / 2])
                        {
                            byte temp = Tilemap.Tilemap_bytes[p];
                            Tilemap.Tilemap_bytes[p] = changes[r];
                            changes[r] = temp;
                            //
                            temp = Tilemap.Tilemap_bytes[p + 1];
                            Tilemap.Tilemap_bytes[p + 1] = changes[r + 1];
                            changes[r + 1] = temp;
                            //
                            made[p / 2] = true;
                            Tilemap.SetTileNum();
                        }
                    }
                }
            }
        }
    }
}
