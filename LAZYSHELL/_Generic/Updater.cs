using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell
{
    public abstract class GraphicUpdater
    {
        public abstract void UpdateGraphics();
    }
    public abstract class PaletteUpdater
    {
        public abstract void UpdatePalette();
    }
    public abstract class TilemapUpdater
    {
        public abstract void UpdateTilemap();
    }
    public abstract class TilesetUpdater
    {
        public abstract void UpdateTileset();
    }
    public abstract class TileUpdater
    {
        public abstract void UpdateTile();
    }
}
