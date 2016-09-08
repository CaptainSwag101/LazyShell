using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell.Menus
{
    class PaletteBGUpdater : LazyShell.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LazyShell.Model.Program.Menus.UpdateBGPalette();
        }
    }
    class GraphicBGUpdater : LazyShell.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LazyShell.Model.Program.Menus.UpdateBGGraphic();
        }
    }
    class PaletteFGUpdater : LazyShell.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LazyShell.Model.Program.Menus.UpdateFGPalette();
        }
    }
    class GraphicFGUpdater : LazyShell.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LazyShell.Model.Program.Menus.UpdateFGGraphic();
        }
    }
    class PaletteCursorsUpdater : LazyShell.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LazyShell.Model.Program.Menus.UpdateCursorsPalette();
        }
    }
    class GraphicCursorsUpdater : LazyShell.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LazyShell.Model.Program.Menus.UpdateCursorsGraphic();
        }
    }
    class PaletteSpeakersUpdater : LazyShell.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LazyShell.Model.Program.Menus.UpdateSpeakersPalette();
        }
    }
    class GraphicSpeakersUpdater : LazyShell.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LazyShell.Model.Program.Menus.UpdateSpeakersGraphic();
        }
    }
}
