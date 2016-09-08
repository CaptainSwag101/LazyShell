using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell.Sprites
{
    class GraphicUpdater : LazyShell.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LazyShell.Model.Program.Sprites.UpdateGraphics();
        }
    }
    class PaletteUpdater : LazyShell.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LazyShell.Model.Program.Sprites.UpdatePalette();
        }
    }
}
