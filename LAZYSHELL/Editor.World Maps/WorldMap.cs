using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL
{
    [Serializable()]
    public class WorldMap : Element
    {
        [NonSerialized()]
        private byte[] data;
        public override byte[] Data { get { return data; } set { data = value; } }
        private int worldMapNum;
        public override int Index { get { return worldMapNum; } set { worldMapNum = value; } }

        private byte tileset; public byte Tileset { get { return tileset; } set { tileset = value; } }
        private sbyte x; public sbyte X { get { return x; } set { x = value; } }
        private sbyte y; public sbyte Y { get { return y; } set { y = value; } }
        private byte pointCount; public byte PointCount { get { return pointCount; } set { pointCount = value; } }

        public WorldMap(byte[] data, int worldMapNum)
        {
            this.data = data;
            this.worldMapNum = worldMapNum;

            InitializeWorldMap(data);
        }

        private void InitializeWorldMap(byte[] data)
        {
            int offset = worldMapNum * 3 + 0x3EF800;

            tileset = (byte)data[offset]; offset++;
            x = (sbyte)(data[offset] - 1 ^ 255); offset++;
            y = (sbyte)(data[offset] - 1 ^ 255); offset++;

            pointCount = (byte)data[0x3EF820 + worldMapNum];
        }
        public void Assemble()
        {
            int offset = worldMapNum * 3 + 0x3EF800;

            data[offset] = tileset; offset++;
            data[offset] = (byte)((byte)x - 1 ^ 255); offset++;
            data[offset] = (byte)((byte)y - 1 ^ 255);

            offset = 0x3EF820 + worldMapNum;
            data[offset] = pointCount;
        }
        public override void Clear()
        {
            tileset = 0;
            x = 0;
            y = 0;
            pointCount = 0;
        }
    }
}
