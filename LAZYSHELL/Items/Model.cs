using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.Items
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
        private static Item[] items;
        public static Item[] Items
        {
            get
            {
                if (items == null)
                {
                    items = new Item[256];
                    for (int i = 0; i < items.Length; i++)
                        items[i] = new Item(i);
                }
                return items;
            }
            set { items = value; }
        }

        // Sorted lists
        private static SortedList names;
        public static SortedList Names
        {
            get
            {
                if (names == null)
                {
                    names = new SortedList(Items);
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

        // Data management
        public static void ClearAll()
        {
            names = null;
            items = null;
        }
        public static void LoadAll()
        {
            object dummy;
            dummy = Names;
            dummy = Items;
        }

        #endregion
    }
}
