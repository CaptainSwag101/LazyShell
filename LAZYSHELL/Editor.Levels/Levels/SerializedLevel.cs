using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL
{
    [Serializable()]
    class SerializedLevel
    {
        public LevelMap levelMap;
        public int levelMapNum;
        public byte[] tileSetL1;
        public byte[] tileSetL2;
        public byte[] tileSetL3;
        public byte[] tileMapL1;
        public byte[] tileMapL2;
        public byte[] tileMapL3;
        public byte[] solidityMap;
        public LevelLayer levelLayer;
        public LevelNPCs levelNPCs;
        public LevelExits levelExits;
        public LevelEvents levelEvents;
        public LevelOverlaps levelOverlaps;
        public SerializedLevel()
        {

        }
    }
}
