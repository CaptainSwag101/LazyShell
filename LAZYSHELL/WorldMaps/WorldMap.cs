using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.WorldMaps
{
    [Serializable()]
    public class WorldMap : Element
    {
        #region Variables

        // ROM buffer
        private byte[] rom
        {
            get { return Model.ROM; }
            set { Model.ROM = value; }
        }

        // Index
        public override int Index { get; set; }

        // Properties
        public byte Tileset { get; set; }
        public sbyte X { get; set; }
        public sbyte Y { get; set; }
        public byte Locations { get; set; }

        #endregion

        // Constructor
        public WorldMap(int index)
        {
            this.Index = index;
            ReadFromROM();
        }

        #region Methods

        // Read/write ROM
        private void ReadFromROM()
        {
            int offset = Index * 3 + 0x3EF800;
            Tileset = (byte)rom[offset++];
            X = (sbyte)(rom[offset++] - 1 ^ 255);
            Y = (sbyte)(rom[offset++] - 1 ^ 255);
            Locations = (byte)rom[0x3EF820 + Index];
        }
        public void WriteToROM()
        {
            int offset = Index * 3 + 0x3EF800;
            rom[offset++] = Tileset;
            rom[offset++] = (byte)((byte)X - 1 ^ 255);
            rom[offset] = (byte)((byte)Y - 1 ^ 255);
            //
            offset = 0x3EF820 + Index;
            rom[offset] = Locations;
        }

        // Universal functions
        public override void Clear()
        {
            Tileset = 0;
            X = 0;
            Y = 0;
            Locations = 0;
        }

        #endregion
    }
}
