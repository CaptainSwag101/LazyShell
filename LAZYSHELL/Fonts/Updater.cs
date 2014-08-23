using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.Fonts
{
    class GraphicUpdater : LAZYSHELL.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LAZYSHELL.Model.Program.Fonts.UpdateGraphics();
        }
    }
    class GraphicFontUpdater : LAZYSHELL.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LAZYSHELL.Model.Program.Fonts.UpdateGraphicsFont();
        }
    }
    class GraphicMenuUpdater : LAZYSHELL.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LAZYSHELL.Model.Program.Fonts.UpdateGraphicsMenu();
        }
    }
    class PaletteUpdater : LAZYSHELL.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LAZYSHELL.Model.Program.Fonts.UpdatePalettes();
        }
    }
    class PaletteMenuUpdater : LAZYSHELL.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LAZYSHELL.Model.Program.Fonts.UpdatePalettesMenu();
        }
    }
}
