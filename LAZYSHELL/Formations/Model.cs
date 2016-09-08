using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell.Formations
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
        private static Formation[] formations;
        private static Pack[] packs;
        private static byte[] musics;
        public static Formation[] Formations
        {
            get
            {
                if (formations == null)
                {
                    formations = new Formation[512];
                    for (int i = 0; i < formations.Length; i++)
                        formations[i] = new Formation(i);
                }
                return formations;
            }
            set { formations = value; }
        }
        public static Pack[] Packs
        {
            get
            {
                if (packs == null)
                {
                    packs = new Pack[256];
                    for (int i = 0; i < packs.Length; i++)
                        packs[i] = new Pack(i);
                }
                return packs;
            }
            set { packs = value; }
        }
        public static byte[] Musics
        {
            get
            {
                if (musics == null)
                {
                    musics = new byte[8];
                    for (int i = 0; i < musics.Length; i++)
                        musics[i] = ROM[0x029F51 + i];
                }
                return musics;
            }
            set { musics = value; }
        }

        #endregion

        #region Methods

        // Data management
        public static void ClearAll()
        {
            musics = null;
            packs = null;
            formations = null;
        }
        public static void LoadAll()
        {
            object dummy;
            dummy = Musics;
            dummy = Packs;
            dummy = Formations;
        }

        #endregion
    }
}
