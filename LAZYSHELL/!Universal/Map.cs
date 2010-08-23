using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LAZYSHELL
{
    public abstract class Map
    {
        public abstract int[] Pixels { get; set; }
        public abstract byte[] Tilemap { get; set; }
        public abstract Bitmap Image { get; set; }
    }
}
