using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.Magic
{
    public static class Model
    {
        #region Variables

        // ROM buffer
        public static byte[] ROM
        {
            get { return LAZYSHELL.Model.ROM; }
            set { LAZYSHELL.Model.ROM = value; }
        }

        // Elements
        private static Spell[] spells;
        public static Spell[] Spells
        {
            get
            {
                if (spells == null)
                {
                    spells = new Spell[128];
                    for (int i = 0; i < spells.Length; i++)
                        spells[i] = new Spell(i);
                }
                return spells;
            }
            set { spells = value; }
        }

        // Names
        private static SortedList names;
        public static SortedList Names
        {
            get
            {
                if (names == null)
                {
                    names = new SortedList(Spells);
                    names.SortAlphabetically();
                }
                return names;
            }
            set
            {
                names = value;
                if (names != null)
                    names.SortAlphabetically();
            }
        }

        #endregion

        #region Methods

        public static void ClearAll()
        {
            names = null;
            spells = null;
        }
        public static void LoadAll()
        {
            object dummy;
            dummy = Names;
            dummy = Spells;
        }

        #endregion
    }
}
