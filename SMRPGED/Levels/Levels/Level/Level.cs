using System;
using System.Collections.Generic;
using System.Text;

// A single level object containing all the level data for a single level
// IE. a levelmap object containing GFXSETS, Mapsets, and Tilesets... ect
namespace SMRPGED
{
    public class Level
    {
        private byte[] data;
        private int levelNum;
        private int levelMap;
        private LevelLayer layer;
        private LevelNPCs levelNPCs;
        private LevelExits levelExits;
        private LevelEvents levelEvents;
        private LevelOverlaps levelOverlaps;

        public int LevelNum { get { return levelNum; } set { levelNum = value; } }
        public int LevelMap { get { return levelMap; } set { levelMap = value; } }
        public LevelLayer Layer { get { return layer; } set { layer = value; } }
        public LevelNPCs LevelNPCs { get { return levelNPCs; } set { levelNPCs = value; } }
        public LevelExits LevelExits { get { return levelExits; } set { levelExits = value; } }
        public LevelEvents LevelEvents { get { return levelEvents; } set { levelEvents = value; } }
        public LevelOverlaps LevelOverlaps { get { return levelOverlaps; } set { levelOverlaps = value; } }

        public Level(byte[] data, int levelNum)
        {
            this.data = data;
            this.levelNum = levelNum;

            levelMap = BitManager.GetByte(data, (levelNum * 18) + 0x1D0040);

            this.layer = new LevelLayer(data, levelNum);
            this.levelNPCs = new LevelNPCs(data, levelNum);
            this.levelExits = new LevelExits(data, levelNum);
            this.levelEvents = new LevelEvents(data, levelNum);
            this.levelOverlaps = new LevelOverlaps(data, levelNum);
        }
        public void Assemble()
        {
            BitManager.SetByte(data, (levelNum * 18) + 0x1D0040, (byte)levelMap);

            layer.Assemble();
        }
    }
}
