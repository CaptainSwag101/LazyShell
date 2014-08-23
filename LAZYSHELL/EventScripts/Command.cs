using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.EventScripts
{
    public abstract class Command : LAZYSHELL.Command
    {
        // Pointer retrieval
        public abstract ushort ReadPointer();
        public abstract void WritePointer(ushort pointer);
        public abstract ushort ReadPointerSpecial(int index);
        public abstract void WritePointerSpecial(int index, ushort pointer);
    }
}
