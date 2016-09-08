using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LazyShell
{
    /// <summary>
    /// Base type class for all classes of each element in the Mario RPG ROM.
    /// </summary>
    [Serializable()]
    public abstract class Element
    {
        public abstract int Index { get; set; }
        public abstract void Clear();
    }
}
