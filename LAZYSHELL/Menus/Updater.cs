using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.Menus
{
    class PaletteBGUpdater : LAZYSHELL.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LAZYSHELL.Model.Program.Menus.UpdateBGPalette();
        }
    }
    class GraphicBGUpdater : LAZYSHELL.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LAZYSHELL.Model.Program.Menus.UpdateBGGraphic();
        }
    }
    class PaletteFGUpdater : LAZYSHELL.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LAZYSHELL.Model.Program.Menus.UpdateFGPalette();
        }
    }
    class GraphicFGUpdater : LAZYSHELL.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LAZYSHELL.Model.Program.Menus.UpdateFGGraphic();
        }
    }
    class PaletteCursorsUpdater : LAZYSHELL.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LAZYSHELL.Model.Program.Menus.UpdateCursorsPalette();
        }
    }
    class GraphicCursorsUpdater : LAZYSHELL.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LAZYSHELL.Model.Program.Menus.UpdateCursorsGraphic();
        }
    }
    class PaletteSpeakersUpdater : LAZYSHELL.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LAZYSHELL.Model.Program.Menus.UpdateSpeakersPalette();
        }
    }
    class GraphicSpeakersUpdater : LAZYSHELL.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LAZYSHELL.Model.Program.Menus.UpdateSpeakersGraphic();
        }
    }
}
