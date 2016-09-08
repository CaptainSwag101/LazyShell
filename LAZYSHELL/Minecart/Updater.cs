using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell.Minecart
{
    class GraphicUpdater : LazyShell.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LazyShell.Model.Program.Minecart.UpdateGraphics();
        }
    }
    class GraphicSpritesUpdater : LazyShell.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LazyShell.Model.Program.Minecart.UpdateGraphicsSprites();
        }
    }
    class GraphicObjectsUpdater : LazyShell.GraphicUpdater
    {
        public override void UpdateGraphics()
        {
            LazyShell.Model.Program.Minecart.UpdateGraphicsObjects();
        }
    }
    class PaletteUpdater : LazyShell.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LazyShell.Model.Program.Minecart.UpdatePalette();
        }
    }
    class PaletteSpritesUpdater : LazyShell.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LazyShell.Model.Program.Minecart.UpdateGraphicsSprites();
        }
    }
    class PaletteObjectsUpdater : LazyShell.PaletteUpdater
    {
        public override void UpdatePalette()
        {
            LazyShell.Model.Program.Minecart.UpdatePalettesObjects();
        }
    }
    class TilemapUpdater : LazyShell.TilemapUpdater
    {
        public override void UpdateTilemap()
        {
            LazyShell.Model.Program.Minecart.UpdateTilemap();
        }
    }
    class TilesetUpdater : LazyShell.TilesetUpdater
    {
        public override void UpdateTileset()
        {
            LazyShell.Model.Program.Minecart.UpdateTileset();
        }
    }
    class TileUpdater : LazyShell.TileUpdater
    {
        public override void UpdateTile()
        {
            LazyShell.Model.Program.Minecart.UpdateTile();
        }
    }
}
