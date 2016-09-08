using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell
{
    public interface Preview
    {
        int[] GetPreview(params object[] args);
    }
}
