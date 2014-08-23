using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.Monsters
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
        private static Monster[] monsters;
        public static Monster[] Monsters
        {
            get
            {
                if (monsters == null)
                {
                    monsters = new Monster[256];
                    for (int i = 0; i < monsters.Length; i++)
                        monsters[i] = new Monster(i);
                }
                return monsters;
            }
            set { monsters = value; }
        }
        private static BattleScript[] battleScripts;
        public static BattleScript[] BattleScripts
        {
            get
            {
                if (battleScripts == null)
                {
                    battleScripts = new BattleScript[256];
                    for (int i = 0; i < battleScripts.Length; i++)
                        battleScripts[i] = new BattleScript(i);
                }
                return battleScripts;
            }
            set { battleScripts = value; }
        }

        // Sorted lists
        private static SortedList names;
        public static SortedList Names
        {
            get
            {
                if (names == null)
                {
                    names = new SortedList(Monsters);
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

        // Free bytes
        public static int FreePsychopathSpace()
        {
            int totalSize = 0; 
            int maxSize = 0xB641 + 0x2229;
            for (int i = 0; i < monsters.Length - 1; i++)
                totalSize += monsters[i].RawPsychopath.Length;
            return maxSize - totalSize;
        }
        public static int FreeBattlescriptSpace()
        {
            int maxSizeBlock1 = 0x274A; // 0x3959F3 - 0x3932AA;
            int maxSizeBlock2 = 0x0C00; // 0x39FFFF - 0x39F400;
            int maxSize = maxSizeBlock1 + maxSizeBlock2;
            int totalSize = 0;
            //
            int i = 0;
            for (; i < battleScripts.Length && totalSize + battleScripts[i].Length < maxSizeBlock1; i++)
                totalSize += battleScripts[i].Length;
            //
            if (i < battleScripts.Length - 1)
                totalSize = maxSizeBlock1;
            //
            for (; i < battleScripts.Length; i++)
                totalSize += battleScripts[i].Length;
            //
            return maxSize - totalSize - 1;
        }

        // Data management
        public static void ClearAll()
        {
            battleScripts = null;
            names = null;
            monsters = null;
        }
        public static void LoadAll()
        {
            object dummy;
            dummy = BattleScripts;
            dummy = Names;
            dummy = Monsters;
        }

        #endregion
    }
}
