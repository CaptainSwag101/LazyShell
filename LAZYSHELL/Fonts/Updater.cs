using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell.Fonts
{
    class GraphicUpdater : LazyShell.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LazyShell.Model.Program.Fonts.UpdateGraphics();
        }
    }
    class GraphicFontUpdater : LazyShell.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LazyShell.Model.Program.Fonts.UpdateGraphicsFont();
        }
    }
    class GraphicMenuUpdater : LazyShell.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LazyShell.Model.Program.Fonts.UpdateGraphicsMenu();
        }
    }
    class PaletteUpdater : LazyShell.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LazyShell.Model.Program.Fonts.UpdatePalettes();
        }
    }
    class PaletteMenuUpdater : LazyShell.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LazyShell.Model.Program.Fonts.UpdatePalettesMenu();
        }
    }
}
