using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.Undo
{
    interface Edit
    {
        bool AutoRedo { get; set; }
        void Execute();
    }
}
