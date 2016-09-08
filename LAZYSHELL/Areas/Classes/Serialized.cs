using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell.Areas
{
    [Serializable()]
    class Serialized
    {
        #region Variables

        public Map Map { get; set; }
        public int MapNum { get; set; }
        public byte[] TilesetL1 { get; set; }
        public byte[] TilesetL2 { get; set; }
        public byte[] TilesetL3 { get; set; }
        public byte[] TilemapL1 { get; set; }
        public byte[] TilemapL2 { get; set; }
        public byte[] TilemapL3 { get; set; }
        public byte[] CollisionMap { get; set; }
        public Layering Layering { get; set; }
        public NPCObjectCollection NPCs { get; set; }
        public ExitTriggerCollection Exits { get; set; }
        public EventTriggerCollection Events { get; set; }
        public OverlapCollection Overlaps { get; set; }

        #endregion

        // Constructor
        public Serialized()
        {
        }
    }
}
