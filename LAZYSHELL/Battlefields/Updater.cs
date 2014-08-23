using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.Battlefields
{
    class GraphicUpdater : LAZYSHELL.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LAZYSHELL.Model.Program.Battlefields.UpdateGraphics();
        }
    }
    class PaletteUpdater : LAZYSHELL.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LAZYSHELL.Model.Program.Battlefields.UpdatePalette();
        }
    }
    class TileUpdater : LAZYSHELL.TileUpdater
    {
        public override void UpdateTile()
        {
            LAZYSHELL.Model.Program.Battlefields.UpdateTile();
        }
    }
}
