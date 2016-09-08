using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell
{
    /// <summary>
    /// Form that supports the editing of one or more elements of a tilemap.
    /// </summary>
    public class MapEditor : Controls.DockForm
    {
        // Forms
        public PaletteEditor PaletteEditor { get; set; }
        public GraphicEditor GraphicEditor { get; set; }
        public TilesetForm[] TilesetForms { get; set; }
        public TilesetForm TilesetForm
        {
            get { return TilesetForms[Layer]; }
            set { TilesetForms[Layer] = value; }
        }
        public TilemapForm TilemapForm { get; set; }

        // Elements
        public Overlay Overlay { get; set; }
        public PaletteSet PaletteSet { get; set; }
        public Tileset Tileset { get; set; }
        public Tilemap Tilemap { get; set; }
        public int Layer { get; set; }

        // Updaters
        public TilesetUpdater TilesetUpdater { get; set; }
        public TilemapUpdater TilemapUpdater { get; set; }
        public PaletteUpdater PaletteUpdater { get; set; }
        public GraphicUpdater GraphicUpdater { get; set; }
        public TileUpdater TileUpdater { get; set; }
    }
}
