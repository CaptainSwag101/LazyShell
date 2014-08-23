using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.Effects
{
    class GraphicUpdater : LAZYSHELL.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LAZYSHELL.Model.Program.Effects.UpdateGraphics();
        }
    }
    class PaletteUpdater : LAZYSHELL.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LAZYSHELL.Model.Program.Effects.UpdatePalette();
        }
    }
    class TileUpdater : LAZYSHELL.TileUpdater
    {
        public override void UpdateTile()
        {
            LAZYSHELL.Model.Program.Effects.MoldsForm.UpdateTile();
        }
    }
}
