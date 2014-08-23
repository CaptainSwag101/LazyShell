using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.Intro
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

        // Title screen
        private static byte[] title_data;
        private static Tileset title_tileset;
        private static PaletteSet title_palette;
        private static PaletteSet title_spritePalette;
        private static byte[] title_spriteGraphics;
        public static byte[] Title_Data
        {
            get
            {
                if (title_data == null)
                    title_data = Comp.Decompress(ROM, 0x3F216F, 0xDA60);
                return title_data;
            }
            set { title_data = value; }
        }
        public static Tileset Title_Tileset
        {
            get
            {
                if (title_tileset == null)
                    title_tileset = new Tileset(Title_Palettes, TilesetType.Title);
                return title_tileset;
            }
            set { title_tileset = value; }
        }
        public static PaletteSet Title_Palettes
        {
            get
            {
                if (title_palette == null)
                    title_palette = new PaletteSet(ROM, 0, 0x3F0088, 8, 16, 32);
                return title_palette;
            }
            set { title_palette = value; }
        }
        public static PaletteSet Title_SpritePalettes
        {
            get
            {
                if (title_spritePalette == null)
                    title_spritePalette = new PaletteSet(ROM, 0, 0x3F0188, 5, 16, 32);
                return title_spritePalette;
            }
            set { title_spritePalette = value; }
        }
        public static byte[] Title_SpriteGraphics
        {
            get
            {
                if (title_spriteGraphics == null)
                    title_spriteGraphics = Bits.GetBytes(title_data, 0x2000, 0x4C00);
                return title_spriteGraphics;
            }
            set { title_spriteGraphics = value; }
        }

        // Cast credits
        private static byte[] cast_data;
        private static PaletteSet cast_palette;
        public static byte[] Cast_Data
        {
            get
            {
                if (cast_data == null)
                    cast_data = Comp.Decompress(ROM, 0x3F1914, 0x17C0);
                return cast_data;
            }
            set
            {
                cast_data = value;
            }
        }
        public static PaletteSet Cast_Palette
        {
            get
            {
                if (cast_palette == null)
                    cast_palette = new PaletteSet(ROM, 0, 0x3F0080, 1, 16, 32);
                return cast_palette;
            }
            set { cast_palette = value; }
        }

        #endregion

        #region Methods

        // Model management
        public static void ClearAll()
        {
            cast_data = null;
            cast_palette = null;
            title_data = null;
            title_palette = null;
            title_spriteGraphics = null;
            title_spritePalette = null;
            title_tileset = null;
        }
        public static void LoadAll()
        {
            object dummy;
            dummy = Cast_Data;
            dummy = Cast_Palette;
            dummy = Title_Data;
            dummy = Title_Palettes;
            dummy = Title_SpriteGraphics;
            dummy = Title_SpritePalettes;
            dummy = Title_Tileset;
        }

        #endregion
    }
}
