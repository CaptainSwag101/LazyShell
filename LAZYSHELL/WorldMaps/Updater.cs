using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell.WorldMaps
{
    class GraphicUpdater : LazyShell.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LazyShell.Model.Program.WorldMaps.UpdateGraphics();
        }
    }
    class PaletteUpdater : LazyShell.PaletteUpdater
    {
        // Updating
        public override void UpdatePalette()
        {
            LazyShell.Model.Program.WorldMaps.UpdatePalette();
        }
    }
    class LogoPaletteUpdater : LazyShell.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LazyShell.Model.Program.WorldMaps.UpdateLogoPalette();
        }
    }
    class LogoGraphicUpdater : LazyShell.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LazyShell.Model.Program.WorldMaps.UpdateLogoGraphics();
        }
    }
    class TileUpdater : LazyShell.TileUpdater
    {
        public override void UpdateTile()
        {
            LazyShell.Model.Program.WorldMaps.UpdateTile();
        }
    }
}
