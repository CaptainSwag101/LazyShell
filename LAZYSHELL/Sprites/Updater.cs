using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.Sprites
{
    class GraphicUpdater : LAZYSHELL.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LAZYSHELL.Model.Program.Sprites.UpdateGraphics();
        }
    }
    class PaletteUpdater : LAZYSHELL.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LAZYSHELL.Model.Program.Sprites.UpdatePalette();
        }
    }
}
