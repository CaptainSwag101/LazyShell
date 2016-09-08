using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell.Intro
{
    class GraphicTitleUpdater : LazyShell.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LazyShell.Model.Program.Intro.TitleScreenForm.UpdateGraphics();
        }
    }
    class GraphicPreGameUpdater : LazyShell.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LazyShell.Model.Program.Intro.PreGameForm.UpdateGraphics();
        }
    }
    class GraphicSpriteUpdater : LazyShell.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LazyShell.Model.Program.Intro.TitleScreenForm.UpdateSpriteGraphics();
        }
    }
    class PaletteTitleUpdater : LazyShell.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LazyShell.Model.Program.Intro.TitleScreenForm.UpdatePalette();
        }
    }
    class PalettePreGameUpdater : LazyShell.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LazyShell.Model.Program.Intro.PreGameForm.UpdatePalette();
        }
    }
    class PaletteSpriteUpdater : LazyShell.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LazyShell.Model.Program.Intro.TitleScreenForm.UpdateSpritePalettes();
        }
    }
    class TilesetUpdater : LazyShell.TilesetUpdater
    {
        public override void UpdateTileset()
        {
            LazyShell.Model.Program.Intro.TitleScreenForm.UpdateTileset();
        }
    }
    class TileUpdater : LazyShell.TileUpdater
    {
        public override void UpdateTile()
        {
            LazyShell.Model.Program.Intro.TitleScreenForm.UpdateTile();
        }
    }
}
