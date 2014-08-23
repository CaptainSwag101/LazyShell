using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.Minecart
{
    class GraphicUpdater : LAZYSHELL.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LAZYSHELL.Model.Program.Minecart.UpdateGraphics();
        }
    }
    class GraphicSpritesUpdater : LAZYSHELL.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LAZYSHELL.Model.Program.Minecart.UpdateGraphicsSprites();
        }
    }
    class GraphicObjectsUpdater : LAZYSHELL.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LAZYSHELL.Model.Program.Minecart.UpdateGraphicsObjects();
        }
    }
    class PaletteUpdater : LAZYSHELL.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LAZYSHELL.Model.Program.Minecart.UpdatePalette();
        }
    }
    class PaletteSpritesUpdater : LAZYSHELL.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LAZYSHELL.Model.Program.Minecart.UpdateGraphicsSprites();
        }
    }
    class PaletteObjectsUpdater : LAZYSHELL.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LAZYSHELL.Model.Program.Minecart.UpdatePalettesObjects();
        }
    }
    class TilemapUpdater : LAZYSHELL.TilemapUpdater
    {
        public override void UpdateTilemap()
        {
            LAZYSHELL.Model.Program.Minecart.UpdateTilemap();
        }
    }
    class TilesetUpdater : LAZYSHELL.TilesetUpdater
    {
        public override void UpdateTileset()
        {
            LAZYSHELL.Model.Program.Minecart.UpdateTileset();
        }
    }
    class TileUpdater : LAZYSHELL.TileUpdater
    {
        public override void UpdateTile()
        {
            LAZYSHELL.Model.Program.Minecart.UpdateTile();
        }
    }
}
