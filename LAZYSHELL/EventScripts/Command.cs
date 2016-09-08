using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell.EventScripts
{
    public abstract class Command : LazyShell.Command
    {
        // Pointer retrieval
        public abstract ushort ReadPointer();
        public abstract void WritePointer(ushort pointer);
        public abstract ushort ReadPointerSpecial(int index);
        public abstract void WritePointerSpecial(int index, ushort pointer);
    }
}
