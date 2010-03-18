using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SMRPGED.Undo
{
    class PhysicalMapEditCommand : Command
    {
        Levels updater;
        PhysicalMap physicalMap;
        Point topLeft, bottomRight, tempStart;
        byte[] changes;
        bool autoRedo = false; public bool AutoRedo() { return this.autoRedo; }

        public PhysicalMapEditCommand(
            Levels updater,
            PhysicalMap physicalMap,
            Point topLeft,
            Point bottomRight,
            Point tempStart,
            byte[] changes)
        {
            this.updater = updater;
            this.physicalMap = physicalMap;

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
                    if (y * 1024 + x < physicalMap.OrthTileNum.Length &&
                        b * 1024 + a < physicalMap.OrthTileNum.Length)
                    {
                        p = physicalMap.OrthTileNum[y * 1024 + x] * 2;
                        r = physicalMap.OrthTileNum[b * 1024 + a] * 2;

                        if (!made[p / 2])
                        {
                            temp = physicalMap.ThePhysicalMap[p];
                            physicalMap.ThePhysicalMap[p] = changes[r];
                            changes[r] = temp;

                            temp = physicalMap.ThePhysicalMap[p + 1];
                            physicalMap.ThePhysicalMap[p + 1] = changes[r + 1];
                            changes[r + 1] = temp;

                            made[p / 2] = true;
                        }
                    }
                    physicalMap.MakeEdit();
                }
            }

            //updater.UpdateLevel();
        }
    }
}
