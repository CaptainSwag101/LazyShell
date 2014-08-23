using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.Intro
{
    class GraphicTitleUpdater : LAZYSHELL.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LAZYSHELL.Model.Program.Intro.TitleScreenForm.UpdateGraphics();
        }
    }
    class GraphicPreGameUpdater : LAZYSHELL.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LAZYSHELL.Model.Program.Intro.PreGameForm.UpdateGraphics();
        }
    }
    class GraphicSpriteUpdater : LAZYSHELL.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LAZYSHELL.Model.Program.Intro.TitleScreenForm.UpdateSpriteGraphics();
        }
    }
    class PaletteTitleUpdater : LAZYSHELL.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LAZYSHELL.Model.Program.Intro.TitleScreenForm.UpdatePalette();
        }
    }
    class PalettePreGameUpdater : LAZYSHELL.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LAZYSHELL.Model.Program.Intro.PreGameForm.UpdatePalette();
        }
    }
    class PaletteSpriteUpdater : LAZYSHELL.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LAZYSHELL.Model.Program.Intro.TitleScreenForm.UpdateSpritePalettes();
        }
    }
    class TilesetUpdater : LAZYSHELL.TilesetUpdater
    {
        public override void UpdateTileset()
        {
            LAZYSHELL.Model.Program.Intro.TitleScreenForm.UpdateTileset();
        }
    }
    class TileUpdater : LAZYSHELL.TileUpdater
    {
        public override void UpdateTile()
        {
            LAZYSHELL.Model.Program.Intro.TitleScreenForm.UpdateTile();
        }
    }
}
