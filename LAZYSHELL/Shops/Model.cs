using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell.Shops
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
        private static Shop[] shops;
        public static Shop[] Shops
        {
            get
            {
                if (shops == null)
                {
                    shops = new Shop[33];
                    for (int i = 0; i < shops.Length; i++)
                        shops[i] = new Shop(i);
                }
                return shops;
            }
            set { shops = value; }
        }

        #endregion

        #region Methods

        // Model management
        public static void ClearAll()
        {
            shops = null;
        }
        public static void LoadAll()
        {
            object dummy;
            dummy = Shops;
        }

        #endregion
    }
}
