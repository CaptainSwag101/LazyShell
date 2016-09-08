using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell.Undo
{
    interface Edit
    {
        bool AutoRedo { get; set; }
        void Execute();
    }
}
