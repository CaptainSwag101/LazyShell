using System;
using System.Collections.Generic;
using System.Text;

namespace SMRPGED.Undo
{
    interface Command
    {
        bool AutoRedo();
        void Execute();
    }
}
