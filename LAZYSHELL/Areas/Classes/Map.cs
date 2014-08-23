using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LAZYSHELL.Areas
{
    /// <summary>
    /// Class containing all of the data for drawing a map containing the regions used by one or more areas.
    /// </summary>
    [Serializable()]
    public class Map : Element
    {
        #region Variables

        // ROM buffer
        private byte[] rom
        {
            get { return Model.ROM; }
            set { Model.ROM = value; }
        }
        // Inherited
        public override int Index { get; set; }
        // Properties
        public byte GraphicSet1 { get; set; }
        public byte GraphicSet2 { get; set; }
        public byte GraphicSet3 { get; set; }
        public byte GraphicSet4 { get; set; }
        public byte GraphicSet5 { get; set; }
        public byte GraphicSetL3 { get; set; }
        public byte TilesetL1 { get; set; }
        public byte TilesetL2 { get; set; }
        public byte TilesetL3 { get; set; }
        public byte TilemapL1 { get; set; }
        public byte TilemapL2 { get; set; }
        public byte TilemapL3 { get; set; }
        public bool TopPriorityL3 { get; set; }
        public byte CollisionMap { get; set; }
        public byte PaletteSet { get; set; }
        public byte Battlefield { get; set; }

        #endregion

        // Constructor
        public Map(int index)
        {
            this.Index = index;
            ReadFromROM();
        }

        #region Methods

        // Reading/writing
        private void ReadFromROM()
        {
            int offset = (Index * 15) + 0x1D2440;
            GraphicSet1 = rom[offset++];
            GraphicSet2 = rom[offset++];
            GraphicSet3 = rom[offset++];
            GraphicSet4 = rom[offset++];
            GraphicSet5 = rom[offset++];
            TilesetL1 = rom[offset++];
            //
            byte temp = rom[offset++];
            TopPriorityL3 = (temp & 0x80) == 0x80;
            TilesetL2 = (byte)(temp & 0x7F);
            //
            TilemapL1 = rom[offset++];
            TilemapL2 = rom[offset++];
            CollisionMap = rom[offset++];
            PaletteSet = rom[offset++];
            GraphicSetL3 = rom[offset++];
            TilesetL3 = rom[offset++];
            temp = rom[offset++];
            TilemapL3 = (byte)(temp & 0x3F);
            Battlefield = rom[offset];
        }
        public void WriteToROM()
        {
            int offset = (Index * 15) + 0x1D2440;
            rom[offset++] = GraphicSet1;
            rom[offset++] = GraphicSet2;
            rom[offset++] = GraphicSet3;
            rom[offset++] = GraphicSet4;
            rom[offset++] = GraphicSet5;
            rom[offset++] = TilesetL1;
            //
            rom[offset] = TilesetL2;
            Bits.SetBit(rom, offset++, 7, TopPriorityL3);
            //
            rom[offset++] = TilemapL1;
            rom[offset++] = TilemapL2;
            rom[offset++] = CollisionMap;
            rom[offset++] = PaletteSet;
            rom[offset++] = GraphicSetL3;
            rom[offset++] = TilesetL3;
            rom[offset++] = (byte)(TilemapL3 + 0x40);
            rom[offset] = Battlefield;
        }
        // Inherited
        public override void Clear()
        {
            this.GraphicSet1 = 0;
            this.GraphicSet2 = 0;
            this.GraphicSet3 = 0;
            this.GraphicSet4 = 0;
            this.GraphicSet5 = 0;
            this.TilesetL1 = 0;
            this.TilesetL2 = 0;
            this.TopPriorityL3 = false;
            this.TilemapL1 = 0;
            this.TilemapL2 = 0;
            this.CollisionMap = 0;
            this.PaletteSet = 0;
            this.GraphicSetL3 = 0;
            this.TilesetL3 = 0;
            this.TilemapL3 = 0;
            this.Battlefield = 0;
        }

        #endregion
    }
}
