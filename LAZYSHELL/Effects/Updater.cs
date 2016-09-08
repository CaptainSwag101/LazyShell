using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell.Effects
{
    class GraphicUpdater : LazyShell.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LazyShell.Model.Program.Effects.UpdateGraphics();
        }
    }
    class PaletteUpdater : LazyShell.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LazyShell.Model.Program.Effects.UpdatePalette();
        }
    }
    class TileUpdater : LazyShell.TileUpdater
    {
        public override void UpdateTile()
        {
            LazyShell.Model.Program.Effects.MoldsForm.UpdateTile();
        }
    }
}
