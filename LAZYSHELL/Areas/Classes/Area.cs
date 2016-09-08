using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell.Areas
{
    /// <summary>
    /// Class containing all of the properties and object collections of an Area.
    /// </summary>
    [Serializable()]
    public class Area : Element
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
        public int Map { get; set; }
        public Layering Layering { get; set; }

        // Collections
        public NPCObjectCollection NPCObjects { get; set; }
        public ExitTriggerCollection ExitTriggers { get; set; }
        public EventTriggerCollection EventTriggers { get; set; }
        public OverlapCollection Overlaps { get; set; }
        public TileSwitchCollection TileSwitches { get; set; }
        public CollisionSwitchCollection CollisionSwitches { get; set; }

        // Priority set
        public int PrioritySet
        {
            get
            {
                if (Layering != null)
                    return Layering.PrioritySet;
                return -1;
            }
        }

        #endregion

        // Constructor
        public Area(int index)
        {
            this.Index = index;
            ReadFromROM();
        }
        public Area() { }

        #region Methods

        // Read/write ROM
        private void ReadFromROM()
        {
            this.Map = rom[(Index * 18) + 0x1D0040];
            this.Layering = new Layering(Index);
            this.NPCObjects = new NPCObjectCollection(Index);
            this.ExitTriggers = new ExitTriggerCollection(Index);
            this.EventTriggers = new EventTriggerCollection(Index);
            this.Overlaps = new OverlapCollection(Index);
            this.TileSwitches = new TileSwitchCollection(Index);
            this.CollisionSwitches = new CollisionSwitchCollection(Index);
        }
        public void WriteToROM()
        {
            rom[(Index * 18) + 0x1D0040] = (byte)Map;
            Layering.WriteToROM();
        }

        // Inherited
        public override void Clear()
        {
            Layering.Clear();
            EventTriggers.Clear();
            ExitTriggers.Clear();
            NPCObjects.Clear();
            Overlaps.Clear();
            TileSwitches.Clear();
            CollisionSwitches.Clear();
        }
        public override string ToString()
        {
            return Lists.Numerize(Lists.Areas, this.Index);
        }

        #endregion
    }
}
