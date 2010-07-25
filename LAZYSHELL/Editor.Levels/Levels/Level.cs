using System;
using System.Collections.Generic;
using System.Text;

// A single level object containing all the level data for a single level
// IE. a levelmap object containing GFXSETS, Mapsets, and Tilesets... ect
namespace LAZYSHELL
{
    public class Level
    {
        private byte[] data;
        private int index;
        private int levelMap;
        private LevelLayer layer;
        private LevelNPCs levelNPCs;
        private LevelExits levelExits;
        private LevelEvents levelEvents;
        private LevelOverlaps levelOverlaps;

        public int Index { get { return index; } set { index = value; } }
        public int LevelMap { get { return levelMap; } set { levelMap = value; } }
        public LevelLayer Layer { get { return layer; } set { layer = value; } }
        public LevelNPCs LevelNPCs { get { return levelNPCs; } set { levelNPCs = value; } }
        public LevelExits LevelExits { get { return levelExits; } set { levelExits = value; } }
        public LevelEvents LevelEvents { get { return levelEvents; } set { levelEvents = value; } }
        public LevelOverlaps LevelOverlaps { get { return levelOverlaps; } set { levelOverlaps = value; } }

        public Level(byte[] data, int index)
        {
            this.data = data;
            this.index = index;

            levelMap = data[(index * 18) + 0x1D0040];

            this.layer = new LevelLayer(data, index);
            this.levelNPCs = new LevelNPCs(data, index);
            this.levelExits = new LevelExits(data, index);
            this.levelEvents = new LevelEvents(data, index);
            this.levelOverlaps = new LevelOverlaps(data, index);
        }
        public void Assemble()
        {
            Bits.SetByte(data, (index * 18) + 0x1D0040, (byte)levelMap);

            layer.Assemble();
        }
        public void Clear()
        {
            layer.Clear();
            levelEvents.Clear();
            levelExits.Clear();
            levelNPCs.Clear();
            levelOverlaps.Clear();
        }
    }
}
