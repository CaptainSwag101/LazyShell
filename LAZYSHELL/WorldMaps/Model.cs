using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.WorldMaps
{
    public static class Model
    {
        #region Variables

        // ROM buffer
        public static byte[] ROM
        {
            get { return LAZYSHELL.Model.ROM; }
            set { LAZYSHELL.Model.ROM = value; }
        }

        // Elements
        private static WorldMap[] worldMaps;
        private static Location[] locations;
        public static WorldMap[] WorldMaps
        {
            get
            {
                if (worldMaps == null)
                {
                    worldMaps = new WorldMap[9];
                    for (int i = 0; i < worldMaps.Length; i++)
                        worldMaps[i] = new WorldMap(i);
                }
                return worldMaps;
            }
            set { worldMaps = value; }
        }
        public static Location[] Locations
        {
            get
            {
                if (locations == null)
                {
                    locations = new Location[56];
                    for (int i = 0; i < locations.Length; i++)
                        locations[i] = new Location(i);
                }
                return locations;
            }
            set { locations = value; }
        }

        // Compressed data
        private static byte[] graphics;
        private static byte[] palettes;
        private static byte[][] tilesets_bytes = new byte[7][];
        private static byte[] sprites_graphics;
        private static byte[] logos_graphics;
        private static byte[] logos_tileset;
        public static byte[] Graphics
        {
            get
            {
                if (graphics == null)
                    graphics = Comp.Decompress(ROM, 0x3E2E82, 0x8000);
                return graphics;
            }
            set { graphics = value; }
        }
        public static byte[] Palettes
        {
            get
            {
                if (palettes == null)
                    palettes = Comp.Decompress(ROM, 0x3E988D, 0x100);
                return palettes;
            }
            set { palettes = value; }
        }
        public static byte[][] Tilesets_Bytes
        {
            get
            {
                if (tilesets_bytes[0] == null)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        int pointer = Bits.GetShort(ROM, i * 2 + 0x3E0014);
                        int offset = 0x3E0000 + pointer + 1;
                        tilesets_bytes[i] = Comp.Decompress(ROM, offset, 0x800);
                    }
                }
                return tilesets_bytes;
            }
            set { tilesets_bytes = value; }
        }
        public static byte[] Sprites_Graphics
        {
            get
            {
                if (sprites_graphics == null)
                    sprites_graphics = Comp.Decompress(ROM, 0x3E90A7, 0x400);
                return sprites_graphics;
            }
            set { sprites_graphics = value; }
        }
        public static byte[] Logos_Graphics
        {
            get
            {
                if (logos_graphics == null)
                    logos_graphics = Comp.Decompress(ROM, 0x3E0000, 0x3E0000, 0x2000);
                return logos_graphics;
            }
            set { logos_graphics = value; }
        }
        public static byte[] Logos_Tileset
        {
            get
            {
                if (logos_tileset == null)
                {
                    int pointer = Bits.GetShort(ROM, 0x3E0022);
                    int offset = 0x3E0000 + pointer + 1;
                    logos_tileset = Comp.Decompress(ROM, offset, 0x800);
                }
                return logos_tileset;
            }
            set { logos_tileset = value; }
        }

        // Palette sets
        private static PaletteSet paletteSet;
        public static PaletteSet PaletteSet
        {
            get
            {
                if (paletteSet == null)
                    paletteSet = new PaletteSet(Palettes, 0, 0, 8, 16, 32);
                return paletteSet;
            }
            set { paletteSet = value; }
        }
        public static PaletteSet logos_PaletteSet;
        public static PaletteSet Logos_PaletteSet
        {
            get
            {
                if (logos_PaletteSet == null)
                    logos_PaletteSet = new PaletteSet(Menus.Model.Menu_Palette_Bytes, 7, 0xE0, 1, 16, 32);
                return logos_PaletteSet;
            }
            set { logos_PaletteSet = value; }
        }

        #endregion

        #region Methods

        // Data management
        public static void ClearAll()
        {
            locations = null;
            graphics = null;
            palettes = null;
            worldMaps = null;
            sprites_graphics = null;
            tilesets_bytes[0] = null;
            logos_graphics = null;
            logos_PaletteSet = null;
            logos_tileset = null;
            paletteSet = null;
        }
        public static void LoadAll()
        {
            object dummy;
            dummy = Locations;
            dummy = Graphics;
            dummy = Palettes;
            dummy = WorldMaps;
            dummy = Sprites_Graphics;
            dummy = Tilesets_Bytes[0];
            dummy = Logos_Graphics;
            dummy = Logos_Tileset;
            dummy = Logos_PaletteSet;
            dummy = PaletteSet;
        }

        #endregion
    }
}
