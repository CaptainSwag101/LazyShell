using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LAZYSHELL.Undo
{
    class PhysicalMapEditCommand : Command
    {
        Levels updater;
        Map tilemap;
        Solidity solidity = Solidity.Instance;
        Point topLeft, bottomRight, tempStart;
        byte[] changes;
        bool autoRedo = false; public bool AutoRedo() { return this.autoRedo; }

        public PhysicalMapEditCommand(
            Levels updater,
            Map tilemap,
            Point topLeft,
            Point bottomRight,
            Point tempStart,
            byte[] changes)
        {
            this.updater = updater;
            this.tilemap = tilemap;

            if (topLeft.Y < bottomRight.Y)
            {
                this.topLeft = topLeft;
                this.bottomRight = bottomRight;
            }
            else if (topLeft == bottomRight && topLeft.X <= bottomRight.X)
            {
                this.topLeft = topLeft;
                this.bottomRight = bottomRight;
            }
            else if (bottomRight.Y < topLeft.Y)
            {
                this.topLeft = bottomRight;
                this.bottomRight = topLeft;
            }
            this.tempStart = tempStart;

            this.changes = new byte[changes.Length];
            changes.CopyTo(this.changes, 0);

            Execute();
        }

        public void Execute()
        {
            byte temp = 0;
            int p = 0, r = 0;

            Point start = topLeft;// new Point(topLeft.X / 16 * 16, topLeft.Y / 16 * 16);
            Point stop = bottomRight;// new Point(bottomRight.X / 16 * 16, bottomRight.Y / 16 * 16);

            if (start.X > 1023) start.X = 1023;
            if (start.Y > 1023) start.Y = 1023;
            if (stop.X > 1023) stop.X = 1023;
            if (stop.X > 1023) stop.X = 1023;

            bool[] made = new bool[changes.Length / 2];
            for (int y = start.Y, b = tempStart.Y; y < stop.Y; y++, b++)
            {
                for (int x = start.X, a = tempStart.X; x < stop.X; x++, a++)
                {
                    if (y * 1024 + x < solidity.PixelTiles.Length &&
                        b * 1024 + a < solidity.PixelTiles.Length)
                    {
                        p = solidity.PixelTiles[y * 1024 + x] * 2;
                        r = solidity.PixelTiles[b * 1024 + a] * 2;

                        if (!made[p / 2])
                        {
                            temp = tilemap.Tilemap[p];
                            tilemap.Tilemap[p] = changes[r];
                            changes[r] = temp;

                            temp = tilemap.Tilemap[p + 1];
                            tilemap.Tilemap[p + 1] = changes[r + 1];
                            changes[r + 1] = temp;

                            made[p / 2] = true;
                        }
                    }
                }
            }
        }
    }
}
