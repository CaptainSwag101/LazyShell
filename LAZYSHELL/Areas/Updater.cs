using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LAZYSHELL.Areas
{
    class GraphicUpdater : LAZYSHELL.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LAZYSHELL.Model.Program.Areas.UpdateGraphics();
        }
    }
    class PaletteUpdater : LAZYSHELL.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LAZYSHELL.Model.Program.Areas.UpdatePalette();
        }
    }
    class TilesetUpdater : LAZYSHELL.TilesetUpdater
    {
        public override void UpdateTileset()
        {
            LAZYSHELL.Model.Program.Areas.UpdateTileset();
        }
    }
}
