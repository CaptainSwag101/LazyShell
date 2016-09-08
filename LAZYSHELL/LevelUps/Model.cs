using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell.LevelUps
{
    public static class Model
    {
        #region Variables

        // ROM buffer
        public static byte[] ROM
        {
            get { return LazyShell.Model.ROM; }
            set { LazyShell.Model.ROM = value; }
        }

        // Elements
        private static LevelUp[] levelUps;
        public static LevelUp[] LevelUps
        {
            get
            {
                levelUps = new LevelUp[31];
                for (int i = 2; i < levelUps.Length; i++)
                    levelUps[i] = new LevelUp(i);
                return levelUps;
            }
            set { levelUps = value; }
        }

        #endregion

        #region Methods

        // Model management
        public static void ClearAll()
        {
            levelUps = null;
        }
        public static void LoadAll()
        {
            object dummy;
            dummy = LevelUps;
        }

        #endregion
    }
}
