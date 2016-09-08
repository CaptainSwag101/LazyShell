using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LazyShell.Areas
{
    class GraphicUpdater : LazyShell.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LazyShell.Model.Program.Areas.UpdateGraphics();
        }
    }
    class PaletteUpdater : LazyShell.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LazyShell.Model.Program.Areas.UpdatePalette();
        }
    }
    class TilesetUpdater : LazyShell.TilesetUpdater
    {
        public override void UpdateTileset()
        {
            LazyShell.Model.Program.Areas.UpdateTileset();
        }
    }
}
