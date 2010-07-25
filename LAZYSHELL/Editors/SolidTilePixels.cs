using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LAZYSHELL
{
    public class SolidTilePixels
    {
        private int[] quadBasePixels = new int[16 * 8];
        private int[] quadBlockPixels = new int[16 * 24];
        private int[] halfQuadBlockPixels = new int[16 * 16];
        private int[] stairsUpRightLowPixels = new int[16 * 24];
        private int[] stairsUpRightHighPixels = new int[16 * 24];
        private int[] stairsUpLeftLowPixels = new int[16 * 24];
        private int[] stairsUpLeftHighPixels = new int[16 * 24];
        private int[] fieldBasePixels = new int[32 * 16];
        private int[] fieldBlockPixels = new int[32 * 32];
        public int[] QuadBasePixels { get { return quadBasePixels; } }
        public int[] QuadBlockPixels { get { return quadBlockPixels; } }
        public int[] HalfQuadBlockPixels { get { return halfQuadBlockPixels; } }
        public int[] StairsUpRightLowPixels { get { return stairsUpRightLowPixels; } }
        public int[] StairsUpRightHighPixels { get { return stairsUpRightHighPixels; } }
        public int[] StairsUpLeftLowPixels { get { return stairsUpLeftLowPixels; } }
        public int[] StairsUpLeftHighPixels { get { return stairsUpLeftHighPixels; } }
        public int[] FieldBasePixels { get { return fieldBasePixels; } }
        public int[] FieldBlockPixels { get { return fieldBlockPixels; } }
        public SolidTilePixels()
        {
            quadBasePixels = Do.ImageToPixels(global::LAZYSHELL.Properties.Resources.quadBase, Color.White);
            quadBlockPixels = Do.ImageToPixels(global::LAZYSHELL.Properties.Resources.quadBlock, Color.White);
            halfQuadBlockPixels = Do.ImageToPixels(global::LAZYSHELL.Properties.Resources.halfQuadBlock, Color.White);
            stairsUpLeftLowPixels = Do.ImageToPixels(global::LAZYSHELL.Properties.Resources.stairsUpLeftLow, Color.White);
            stairsUpLeftHighPixels = Do.ImageToPixels(global::LAZYSHELL.Properties.Resources.stairsUpLeftHigh, Color.White);
            stairsUpRightLowPixels = Do.ImageToPixels(global::LAZYSHELL.Properties.Resources.stairsUpRightLow, Color.White);
            stairsUpRightHighPixels = Do.ImageToPixels(global::LAZYSHELL.Properties.Resources.stairsUpRightHigh, Color.White);
            fieldBasePixels = Do.ImageToPixels(global::LAZYSHELL.Properties.Resources.fieldBase, Color.White);
            fieldBlockPixels = Do.ImageToPixels(global::LAZYSHELL.Properties.Resources.fieldBlock, Color.White);
        }
    }
}
