using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell.Battlefields
{
    class GraphicUpdater : LazyShell.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LazyShell.Model.Program.Battlefields.UpdateGraphics();
        }
    }
    class PaletteUpdater : LazyShell.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LazyShell.Model.Program.Battlefields.UpdatePalette();
        }
    }
    class TileUpdater : LazyShell.TileUpdater
    {
        public override void UpdateTile()
        {
            LazyShell.Model.Program.Battlefields.UpdateTile();
        }
    }
}
