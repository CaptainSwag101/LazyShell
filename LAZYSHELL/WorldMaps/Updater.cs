using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.WorldMaps
{
    class GraphicUpdater : LAZYSHELL.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LAZYSHELL.Model.Program.WorldMaps.UpdateGraphics();
        }
    }
    class PaletteUpdater : LAZYSHELL.PaletteUpdater
    {
        // Updating
        public override void UpdatePalette()
        {
            LAZYSHELL.Model.Program.WorldMaps.UpdatePalette();
        }
    }
    class LogoPaletteUpdater : LAZYSHELL.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LAZYSHELL.Model.Program.WorldMaps.UpdateLogoPalette();
        }
    }
    class LogoGraphicUpdater : LAZYSHELL.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LAZYSHELL.Model.Program.WorldMaps.UpdateLogoGraphics();
        }
    }
    class TileUpdater : LAZYSHELL.TileUpdater
    {
        public override void UpdateTile()
        {
            LAZYSHELL.Model.Program.WorldMaps.UpdateTile();
        }
    }
}
