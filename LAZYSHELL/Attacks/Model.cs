using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.Attacks
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
        private static Attack[] attacks;
        public static Attack[] Attacks
        {
            get
            {
                if (attacks == null)
                {
                    attacks = new Attack[129];
                    for (int i = 0; i < attacks.Length; i++)
                        attacks[i] = new Attack(i);
                }
                return attacks;
            }
            set { attacks = value; }
        }
        // Sorted lists
        private static SortedList names;
        public static SortedList Names
        {
            get
            {
                if (names == null)
                {
                    names = new SortedList(Attacks);
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

        // Model management
        public static void ClearAll()
        {
            attacks = null;
            names = null;
        }
        public static void LoadAll()
        {
            object dummy;
            dummy = Attacks;
            dummy = Names;
        }

        #endregion
    }
}
