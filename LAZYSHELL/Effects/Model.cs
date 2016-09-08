using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell.Effects
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
        private static Effect[] effects;
        private static Animation[] animations;
        public static Effect[] Effects
        {
            get
            {
                if (effects == null)
                {
                    // there is an effect animation with the incorrect data block length
                    if (ROM[0x331EB2] == 0x85)
                        ROM[0x331EB2] = 0x86;
                    effects = new Effect[128];
                    for (int i = 0; i < effects.Length; i++)
                        effects[i] = new Effect(i);
                }
                return effects;
            }
            set { effects = value; }
        }
        public static Animation[] Animations
        {
            get
            {
                if (animations == null)
                {
                    animations = new Animation[64];
                    for (int i = 0; i < animations.Length; i++)
                        animations[i] = new Animation(i);
                }
                return animations;
            }
            set { animations = value; }
        }

        #endregion

        #region Methods

        // Free bytes
        public static int FreeAnimationBytes(int index)
        {
            int maxSize, min, max, totalSize = 0;
            if (index < 39)
            {
                maxSize = 0xFFFF; min = 0; max = 39;
            }
            else
            {
                maxSize = 0xCFFF; min = 39; max = 64;
            }
            for (int i = min; i < max; i++)
                totalSize += animations[i].Buffer.Length;
            return maxSize - totalSize;
        }

        // Data management
        public static void ClearAll()
        {
            animations = null;
            effects = null;
        }
        public static void LoadAll()
        {
            object dummy;
            dummy = Animations;
            dummy = Effects;
        }

        #endregion
    }
}
