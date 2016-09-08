using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell.NewGame
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
        private static Ally[] allies;
        private static NewGame newGame;
        public static NewGame NewGame
        {
            get
            {
                if (newGame == null)
                    newGame = new NewGame();
                return newGame;
            }
            set { newGame = value; }
        }
        public static Ally[] Allies
        {
            get
            {
                if (allies == null)
                {
                    allies = new Ally[5];
                    for (int i = 0; i < allies.Length; i++)
                        allies[i] = new Ally(i);
                }
                return allies;
            }
            set { allies = value; }
        }

        #endregion

        #region Methods

        // Data management
        public static void ClearAll()
        {
            allies = null;
            newGame = null;
        }
        public static void LoadAll()
        {
            object dummy;
            dummy = allies;
            dummy = NewGame;
        }

        #endregion
    }
}
