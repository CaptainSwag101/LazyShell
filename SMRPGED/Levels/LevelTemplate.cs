using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SMRPGED
{
    [Serializable]
    public class LevelTemplate
    {
        string name; public string Name { get { return name; } set { name = value; } }

        byte[] physical = new byte[0x20C2]; public byte[] Physical { get { return physical; } }
        byte[][] tilemaps = new byte[3][]; public byte[][] Tilemaps { get { return tilemaps; } }

        // so when painting the template it starts at the right isometric coord
        bool even; public bool Even { get { return even; } }

        Point start; public Point Start { get { return start; } }
        Size size; public Size Size { get { return size; } }

        public void Transfer(byte[][] tilemaps, LevelMap levelMap, PhysicalMap physicalMap, Point start, Point stop)
        {
            this.start = start;
            int offset = 0, o = 0, p = 0;
            size = new Size(stop.X - start.X, stop.Y - start.Y);

            this.tilemaps[0] = new byte[(size.Width * size.Height) * 2];
            this.tilemaps[1] = new byte[(size.Width * size.Height) * 2];
            this.tilemaps[2] = new byte[(size.Width * size.Height)];

            for (int y = start.Y / 16, b = 0; y < stop.Y / 16; y++, b++)
            {
                for (int x = start.X / 16, a = 0; x < stop.X / 16; x++, a++, o++)
                {
                    offset = (x * 2) + (y * 128);
                    this.tilemaps[0][o * 2] = tilemaps[0][offset];
                    this.tilemaps[0][o * 2 + 1] = tilemaps[0][offset + 1];
                    this.tilemaps[1][o * 2] = tilemaps[1][offset];
                    this.tilemaps[1][o * 2 + 1] = tilemaps[1][offset + 1];
                    this.tilemaps[2][o] = tilemaps[2][y * 64 + x];
                }
            }

            even = (size.Width / 16) % 2 == 0;

            for (int y = start.Y; y < stop.Y; y++)
            {
                for (int x = start.X; x < stop.X; x++)
                {
                    p = physicalMap.OrthTileNum[y * 1024 + x] * 2;
                    physical[p] = physicalMap.ThePhysicalMap[p];
                    physical[p + 1] = physicalMap.ThePhysicalMap[p + 1];
                }
            }
        }
    }
}
