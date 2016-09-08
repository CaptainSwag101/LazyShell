using System;
using System.Collections.Generic;
using System.Text;

namespace LazyShell.Minecart
{
    public static class Model
    {
        #region Variables

        // ROM buffer
        public static byte[] ROM
        {
            get { return LazyShell.Model.ROM; }
            set { LazyShell.Model.ROM = value; }
        }

        #region Mode7

        private static byte[] m7Graphics;
        private static byte[] m7TilesetSubtiles;
        private static byte[] m7Palettes;
        private static byte[] m7TilesetPalettes;
        private static PaletteSet m7PaletteSet;
        private static byte[] m7TilemapA;
        private static byte[] m7TilemapB;
        private static byte[] m7TilesetBG;
        public static byte[] M7Graphics
        {
            get
            {
                if (m7Graphics == null)
                    m7Graphics = Comp.Decompress(ROM, 0x388000, 0x388000, 0x2000);
                return m7Graphics;
            }
            set { m7Graphics = value; }
        }
        public static byte[] M7TilesetSubtiles
        {
            get
            {
                if (m7TilesetSubtiles == null)
                    m7TilesetSubtiles = Comp.Decompress(ROM, 0x388002, 0x388000, 0x400);
                return m7TilesetSubtiles;
            }
            set { m7TilesetSubtiles = value; }
        }
        public static byte[] M7Palettes
        {
            get
            {
                if (m7Palettes == null)
                    m7Palettes = Comp.Decompress(ROM, 0x388004, 0x388000, 0x100);
                return m7Palettes;
            }
            set { m7Palettes = value; }
        }
        public static byte[] M7TilesetPalettes
        {
            get
            {
                if (m7TilesetPalettes == null)
                    m7TilesetPalettes = Comp.Decompress(ROM, 0x388006, 0x388000, 0x100);
                return m7TilesetPalettes;
            }
            set { m7TilesetPalettes = value; }
        }
        public static PaletteSet M7PaletteSet
        {
            get
            {
                if (m7PaletteSet == null)
                    m7PaletteSet = new PaletteSet(M7Palettes, 0, 0, 8, 16, 32);
                return m7PaletteSet;
            }
            set { m7PaletteSet = value; }
        }
        public static byte[] M7TilemapA
        {
            get
            {
                if (m7TilemapA == null)
                    m7TilemapA = Comp.Decompress(ROM, 0x388008, 0x388000, 0x1000);
                return m7TilemapA;
            }
            set { m7TilemapA = value; }
        }
        public static byte[] M7TilemapB
        {
            get
            {
                if (m7TilemapB == null)
                    m7TilemapB = Comp.Decompress(ROM, 0x38800A, 0x388000, 0x1000);
                return m7TilemapB;
            }
            set { m7TilemapB = value; }
        }
        public static byte[] M7TilesetBG
        {
            get
            {
                if (m7TilesetBG == null)
                    m7TilesetBG = Comp.Decompress(ROM, 0x38800C, 0x388000, 0x800);
                return m7TilesetBG;
            }
            set { m7TilesetBG = value; }
        }

        #endregion

        #region Objects

        private static byte[] objects;
        private static byte[] objectGraphics;
        private static byte[] objectPalettes;
        private static PaletteSet objectPaletteSet;
        public static byte[] Objects
        {
            get
            {
                if (objects == null)
                {
                    byte[] temp = new byte[0x1000];
                    int offset = Bits.GetShort(ROM, 0x38801C) + 0x388000;
                    int size = Comp.Decompress(ROM, temp, offset + 1, 0x1000);
                    objects = new byte[size];
                    Buffer.BlockCopy(temp, 0, objects, 0, size);
                }
                return objects;
            }
            set { objects = value; }
        }
        public static byte[] ObjectGraphics
        {
            get
            {
                if (objectGraphics == null)
                    objectGraphics = Comp.Decompress(ROM, 0x38800E, 0x388000, 0x800);
                return objectGraphics;
            }
            set { objectGraphics = value; }
        }
        public static byte[] ObjectPalettes
        {
            get
            {
                if (objectPalettes == null)
                    objectPalettes = Comp.Decompress(ROM, 0x388010, 0x388000, 0x40);
                return objectPalettes;
            }
            set { objectPalettes = value; }
        }
        public static PaletteSet ObjectPaletteSet
        {
            get
            {
                if (objectPaletteSet == null)
                    objectPaletteSet = new PaletteSet(ObjectPalettes, 0, 0, 2, 16, 32);
                return objectPaletteSet;
            }
            set { objectPaletteSet = value; }
        }

        #endregion

        #region Side-scrolling

        private static byte[] ssGraphics;
        private static byte[] ssTileset;
        private static byte[] ssBGTileset;
        private static byte[] ssPalettes;
        private static PaletteSet ssPaletteSet;
        private static byte[] ssTilemap;
        public static byte[] SSTilemap
        {
            get
            {
                if (ssTilemap == null)
                    ssTilemap = Comp.Decompress(ROM, 0x388012, 0x388000, 0x1000);
                return ssTilemap;
            }
            set { ssTilemap = value; }
        }
        public static byte[] SSGraphics
        {
            get
            {
                if (ssGraphics == null)
                    ssGraphics = Comp.Decompress(ROM, 0x388014, 0x388000, 0x4000);
                return ssGraphics;
            }
            set { ssGraphics = value; }
        }
        public static byte[] SSTileset
        {
            get
            {
                if (ssTileset == null)
                    ssTileset = Comp.Decompress(ROM, 0x388016, 0x388000, 0x800);
                return ssTileset;
            }
            set { ssTileset = value; }
        }
        public static byte[] SSPalettes
        {
            get
            {
                if (ssPalettes == null)
                    ssPalettes = Comp.Decompress(ROM, 0x388018, 0x388000, 0x100);
                return ssPalettes;
            }
            set { ssPalettes = value; }
        }
        public static PaletteSet SSPaletteSet
        {
            get
            {
                if (ssPaletteSet == null)
                    ssPaletteSet = new PaletteSet(SSPalettes, 0, 0, 8, 16, 32);
                return ssPaletteSet;
            }
            set { ssPaletteSet = value; }
        }
        public static byte[] SSBGTileset
        {
            get
            {
                if (ssBGTileset == null)
                    ssBGTileset = Comp.Decompress(ROM, 0x38801A, 0x388000, 0x1000);
                return ssBGTileset;
            }
            set { ssBGTileset = value; }
        }

        #endregion

        #endregion

        #region Methods

        // Data management
        public static void ClearAll()
        {
            m7Graphics = null;
            m7Palettes = null;
            m7PaletteSet = null;
            m7TilemapA = null;
            m7TilemapB = null;
            m7TilesetBG = null;
            m7TilesetPalettes = null;
            m7TilesetSubtiles = null;
            objectGraphics = null;
            objectPalettes = null;
            objectPaletteSet = null;
            objects = null;
            ssBGTileset = null;
            ssGraphics = null;
            ssPalettes = null;
            ssPaletteSet = null;
            ssTilemap = null;
            ssTileset = null;
        }
        public static void LoadAll()
        {
            object dummy;
            dummy = M7Graphics;
            dummy = M7Palettes;
            dummy = M7PaletteSet;
            dummy = M7TilemapA;
            dummy = M7TilemapB;
            dummy = M7TilesetBG;
            dummy = M7TilesetPalettes;
            dummy = M7TilesetSubtiles;
            dummy = ObjectGraphics;
            dummy = ObjectPalettes;
            dummy = ObjectPaletteSet;
            dummy = Objects;
            dummy = SSBGTileset;
            dummy = SSGraphics;
            dummy = SSPalettes;
            dummy = SSPaletteSet;
            dummy = SSTilemap;
            dummy = SSTileset;
        }

        #endregion
    }
}
